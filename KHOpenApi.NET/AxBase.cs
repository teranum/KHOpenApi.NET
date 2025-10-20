using KHOpenApi.NET.Internals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace KHOpenApi.NET;

/// <summary>
/// ActiveX 컨트롤을 위한 기본 클래스입니다.
/// COM 개체와의 상호작용을 위한 공통 기능을 제공합니다.
/// </summary>
public abstract partial class AxBase : IDisposable
{
    /// <summary>
    /// 비동기 요청시 타임아웃 시간을 설정합니다. 기본값은 5000ms입니다.
    /// </summary>
    /// <value>타임아웃 시간 (밀리초). 최소값은 1000ms입니다.</value>
    public int AsyncTimeOut
    {
        get => _asyncTimeOut;
        set
        {
            // 최소 타임아웃 시간을 1초로 제한
            _asyncTimeOut = (value < 1000) ? 1000 : value;
        }
    }

    /// <summary>
    /// OCX가 생성되었는지 여부를 반환합니다.
    /// </summary>
    /// <value>OCX가 성공적으로 생성되었으면 true, 그렇지 않으면 false</value>
    public bool Created => dispatch is not null;

    /// <summary>
    /// OCX 컨테이너 윈도우 핸들
    /// </summary>
    public IntPtr ContainerHandle => hWndContainer;

    /// 비동기 요청 타임아웃 값을 저장하는 필드
    private int _asyncTimeOut = 5000;

    /// COM 개체와의 상호작용을 위한 IDispatch 인터페이스
    internal readonly IDispatch? dispatch;

    /// OCX 컨테이너 윈도우 핸들
    private readonly IntPtr hWndContainer = IntPtr.Zero;

    /// 이벤트 연결을 위한 Connection Point
    private readonly IConnectionPoint? _connectionPoint;

    /// Connection Point에서 발급된 쿠키 값
    private readonly int _nCookie;

    private bool _disposed;
    private readonly object _disposeLock = new();

    /// 소멸자 - 윈도우 핸들과 COM 연결을 정리합니다.
    ~AxBase()
    {
        Dispose(false);
    }

    /// <summary>
    /// AxBase 클래스의 새 인스턴스를 초기화합니다.
    /// </summary>
    /// <param name="hWndParent">부모 윈도우 핸들. IntPtr.Zero이면 자동으로 적절한 부모를 찾습니다.</param>
    protected AxBase(nint hWndParent)
    {
        EnsureStaThread();

        // 부모 윈도우 핸들이 없으면 자동으로 찾기
        if (hWndParent == IntPtr.Zero)
        {
            // 먼저 메인 윈도우 핸들을 시도
            hWndParent = Process.GetCurrentProcess().MainWindowHandle;
            if (hWndParent == IntPtr.Zero)
            {
                // 메인 윈도우가 없으면 콘솔 윈도우 사용
                hWndParent = NativeMethods.GetConsoleWindow();
            }
        }

        // ATL ActiveX 윈도우 초기화
        if (NativeMethods.AtlAxWinInit())
        {
            // 현재 타입의 GUID를 문자열로 변환
            var clsid = GetType().GUID.ToString("B");
            // 컨트롤 ID를 GUID 해시를 기반으로 생성 (9000-9999 범위)
            int ctrl_id = 9000 + (int)((uint)clsid.GetHashCode() % 1000);

            const int WS_VISIBLE = 0x10000000; // 윈도우 스타일 상수
            const int WS_CHILD = 0x40000000; // 윈도우 스타일 상수
            // ActiveX 컨테이너 윈도우 생성 (화면 밖에 숨김)
            hWndContainer = NativeMethods.CreateWindowEx(0, "AtlAxWin", clsid, WS_VISIBLE | WS_CHILD, -100, -100, 0, 0, hWndParent, (IntPtr)ctrl_id, IntPtr.Zero, IntPtr.Zero);

            if (hWndContainer != IntPtr.Zero)
            {
                try
                {
                    // 윈도우에서 ActiveX 컨트롤 개체 가져오기
                    NativeMethods.AtlAxGetControl(hWndContainer, out object pUnknown);
                    if (pUnknown != null)
                    {
                        // IDispatch 인터페이스로 캐스팅
                        dispatch = (IDispatch)pUnknown;
                        if (dispatch != null)
                        {
                            // 이벤트 연결을 위한 Connection Point 설정
                            var pConnectionPointContainer = (IConnectionPointContainer)pUnknown;
                            pConnectionPointContainer.EnumConnectionPoints(out var enumPoints);
                            var rgelt = new IConnectionPoint[1];

                            // 첫 번째 Connection Point 가져오기
                            if (enumPoints.Next(1, rgelt, IntPtr.Zero) == 0)
                            {
                                _connectionPoint = rgelt[0];
                                // 이벤트 싱크 연결
                                _connectionPoint.Advise(CreateEventSink(), out _nCookie);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    // 오류 발생시 윈도우 정리
                    try { NativeMethods.DestroyWindow(hWndContainer); } catch { /* ignore */ }
                    hWndContainer = IntPtr.Zero;
                    dispatch = null;
                }
            }
        }
    }

    /// <summary>
    /// 이벤트 싱크 개체를 반환합니다. 파생 클래스에서 구현해야 합니다.
    /// </summary>
    /// <returns>이벤트를 처리할 개체</returns>
    protected abstract object CreateEventSink();
    internal List<AsyncNode> InternalAsyncNodes = [];

    /// <summary>
    /// 내부 비동기 노드에 이벤트를 전달하고 처리 여부를 반환합니다.
    /// 모든 <see cref="AsyncNode.EventCallback"/>를 호출하며,
    /// 하나라도 true를 반환하면 처리된 것으로 간주합니다.
    /// </summary>
    /// <param name="evenId">이벤트 식별자.</param>
    /// <param name="e">이벤트 페이로드(임의 형식).</param>
    /// <returns>하나 이상의 콜백이 이벤트를 처리했으면 true, 아니면 false.</returns>
    /// <remarks>
    /// - 예외 처리: 콜백 내부에서 발생한 예외는 전파됩니다.
    /// - 스레드 안전성: <see cref="InternalAsyncNodes"/> 접근은 동기화가 필요할 수 있습니다.
    /// </remarks>
    protected bool ProcInternalAsyncNode(int evenId, EventArgs e)
    {
        foreach (var node in InternalAsyncNodes)
        {
            if (node.EventCallback is not null && node.EventCallback(evenId, e))
            {
                // 이벤트가 처리되었음을 나타냄
                return true;
            }
        }
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNull([NotNull] object? obj)
    {
        if (obj == null)
        {
            throw new InvalidOperationException($"객체가 생성되지 않았습니다.");
        }
    }

    /// <summary>
    /// 현재 스레드가 STA인지 확인합니다. COM ActiveX 사용을 위해 필수입니다.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected static void EnsureStaThread()
    {
        if (Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
        {
            throw new InvalidOperationException("ActiveX/COM은 STA(ThreadState.ApartmentState.STA) 스레드에서만 생성/호출할 수 있습니다. STA 스레드에서 인스턴스화하세요.");
        }
    }

    /// <summary>
    /// 리소스를 해제합니다.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// 리소스를 해제합니다.
    /// </summary>
    /// <param name="disposing">관리 리소스 해제 여부</param>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        lock (_disposeLock)
        {
            if (_disposed) return;

            // 1) 이벤트 연결 해제
            try
            {
                if (_connectionPoint != null && _nCookie != 0)
                {
                    _connectionPoint.Unadvise(_nCookie);
                }
            }
            catch { /* ignore */ }

            // 2) 윈도우 제거
            try
            {
                if (hWndContainer != IntPtr.Zero)
                {
                    NativeMethods.DestroyWindow(hWndContainer);
                }
            }
            catch { /* ignore */ }

            // 3) COM RCW 해제 (가능한 경우)
            try
            {
                if (dispatch != null && Marshal.IsComObject(dispatch))
                {
                    Marshal.FinalReleaseComObject(dispatch);
                }
            }
            catch { /* ignore */ }

            try
            {
                if (_connectionPoint != null && Marshal.IsComObject(_connectionPoint))
                {
                    Marshal.FinalReleaseComObject(_connectionPoint);
                }
            }
            catch { /* ignore */ }

            _disposed = true;
        }
    }
}
