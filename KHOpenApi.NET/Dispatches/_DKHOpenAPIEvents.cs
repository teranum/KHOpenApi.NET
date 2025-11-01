using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace KHOpenApi.NET;

[ComImport]
[Guid("7335F12D-8973-4BD5-B7F0-12DF03D175B7")]
[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
internal interface _DKHOpenAPIEvents
{
    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
    [DispId(1)]
    void OnReceiveTrData([MarshalAs(UnmanagedType.BStr)] string sScrNo, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRecordName, [MarshalAs(UnmanagedType.BStr)] string sPrevNext, int nDataLength, [MarshalAs(UnmanagedType.BStr)] string sErrorCode, [MarshalAs(UnmanagedType.BStr)] string sMessage, [MarshalAs(UnmanagedType.BStr)] string sSplmMsg);

    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
    [DispId(2)]
    void OnReceiveRealData([MarshalAs(UnmanagedType.BStr)] string sRealKey, [MarshalAs(UnmanagedType.BStr)] string sRealType, [MarshalAs(UnmanagedType.BStr)] string sRealData);

    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
    [DispId(3)]
    void OnReceiveMsg([MarshalAs(UnmanagedType.BStr)] string sScrNo, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sMsg);

    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
    [DispId(4)]
    void OnReceiveChejanData([MarshalAs(UnmanagedType.BStr)] string sGubun, int nItemCnt, [MarshalAs(UnmanagedType.BStr)] string sFIdList);

    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
    [DispId(5)]
    void OnEventConnect(int nErrCode);

    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
    [DispId(6)]
    void OnReceiveInvestRealData([MarshalAs(UnmanagedType.BStr)] string sRealKey);

    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
    [DispId(7)]
    void OnReceiveRealCondition([MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string strType, [MarshalAs(UnmanagedType.BStr)] string strConditionName, [MarshalAs(UnmanagedType.BStr)] string strConditionIndex);

    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
    [DispId(8)]
    void OnReceiveTrCondition([MarshalAs(UnmanagedType.BStr)] string sScrNo, [MarshalAs(UnmanagedType.BStr)] string strCodeList, [MarshalAs(UnmanagedType.BStr)] string strConditionName, int nIndex, int nNext);

    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
    [DispId(9)]
    void OnReceiveConditionVer(int lRet, [MarshalAs(UnmanagedType.BStr)] string sMsg);
}
