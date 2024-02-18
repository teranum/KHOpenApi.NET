﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace KFOpenApi.NET
{
    [ComImport]
    [Guid("85B07632-4F84-4CEF-991D-C79DE781363D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    internal interface _DKFOpenAPI
    {
        //[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        //[DispId(-552)]
        //void AboutBox();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(1)]
        int CommConnect(int nAutoUpgrade);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(2)]
        int CommRqData([MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sPrevNext, [MarshalAs(UnmanagedType.BStr)] string sScreenNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(3)]
        void SetInputValue([MarshalAs(UnmanagedType.BStr)] string sID, [MarshalAs(UnmanagedType.BStr)] string sValue);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(4)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommData([MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRQName, int nIndex, [MarshalAs(UnmanagedType.BStr)] string sItemName);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(5)]
        void CommTerminate();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(6)]
        int GetRepeatCnt([MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRecordName);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(7)]
        void DisconnectRealData([MarshalAs(UnmanagedType.BStr)] string sScreenNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(8)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommRealData([MarshalAs(UnmanagedType.BStr)] string sRealType, int nFid);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(9)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetChejanData(int nFid);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(10)]
        int SendOrder([MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sScreenNo, [MarshalAs(UnmanagedType.BStr)] string sAccNo, int nOrderType, [MarshalAs(UnmanagedType.BStr)] string sCode, int nQty, [MarshalAs(UnmanagedType.BStr)] string sPrice, [MarshalAs(UnmanagedType.BStr)] string sStopPrice, [MarshalAs(UnmanagedType.BStr)] string sHogaGb, [MarshalAs(UnmanagedType.BStr)] string sOrgOrderNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(11)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetLoginInfo([MarshalAs(UnmanagedType.BStr)] string sTag);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(12)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureItemlist();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(13)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionItemlist();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(14)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureCodelist([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(15)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionCodelist([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(16)]
        int GetConnectState();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(17)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetAPIModulePath();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(18)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommonFunc([MarshalAs(UnmanagedType.BStr)] string sFuncName, [MarshalAs(UnmanagedType.BStr)] string sParam);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(19)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetConvertPrice([MarshalAs(UnmanagedType.BStr)] string sCode, [MarshalAs(UnmanagedType.BStr)] string sPrice, int nType);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(20)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutOpCodeInfoByType(int nGubun, [MarshalAs(UnmanagedType.BStr)] string sType);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(21)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutOpCodeInfoByCode([MarshalAs(UnmanagedType.BStr)] string sCode);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(22)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureItemlistByType([MarshalAs(UnmanagedType.BStr)] string sType);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(23)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureCodeByItemMonth([MarshalAs(UnmanagedType.BStr)] string sItem, [MarshalAs(UnmanagedType.BStr)] string sMonth);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(24)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionCodeByMonth([MarshalAs(UnmanagedType.BStr)] string sItem, [MarshalAs(UnmanagedType.BStr)] string sCPGubun, [MarshalAs(UnmanagedType.BStr)] string sActivePrice, [MarshalAs(UnmanagedType.BStr)] string sMonth);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(25)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionMonthByItem([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(26)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionActPriceByItem([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(27)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureItemTypelist();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(28)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommFullData([MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRecordName, int nGubun);
    }

    [ComImport]
    [Guid("952B31F8-06FD-4D5A-A021-5FF57F5030AE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    internal interface _DKFOpenAPIEvents
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(1)]
        void OnReceiveTrData([MarshalAs(UnmanagedType.BStr)] string sScrNo, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRecordName, [MarshalAs(UnmanagedType.BStr)] string sPrevNext);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(2)]
        void OnReceiveMsg([MarshalAs(UnmanagedType.BStr)] string sScrNo, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sMsg);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(3)]
        void OnReceiveRealData([MarshalAs(UnmanagedType.BStr)] string sJongmokCode, [MarshalAs(UnmanagedType.BStr)] string sRealType, [MarshalAs(UnmanagedType.BStr)] string sRealData);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(4)]
        void OnReceiveChejanData([MarshalAs(UnmanagedType.BStr)] string sGubun, int nItemCnt, [MarshalAs(UnmanagedType.BStr)] string sFIdList);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(5)]
        void OnEventConnect(int nErrCode);
    }

    /// <summary>
    /// 요청했던 조회데이터를 수신했을때 발생됩니다.
    /// 수신된 데이터는 이 이벤트내부에서 GetCommData()함수를 이용해서 얻어올 수 있습니다.
    /// </summary>
    public class _DKFOpenAPIEvents_OnReceiveTrDataEvent(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPreNext) : EventArgs
    {
        /// <summary>화면번호</summary>
        public string sScrNo = sScrNo;
        /// <summary>사용자 구분명</summary>
        public string sRQName = sRQName;
        /// <summary>Tran명</summary>
        public string sTrCode = sTrCode;
        /// <summary>레코드명</summary>
        public string sRecordName = sRecordName;
        /// <summary>연속조회 유무를 판단하는 값 0: 연속(추가조회)데이터 없음, 2:연속(추가조회) 데이터 있음</summary>
        public string sPreNext = sPreNext;
    }

    /// <summary>주문전송 또는 데이터 조회요청 후 서버 메시지가 수신됩니다.※ 메시지에 포함된 6자리 코드번호는 변경될 수 있으니, 여기에 수신된 코드번호를 특정 용도로 사용하지 마시기 바랍니다.</summary>
    public class _DKFOpenAPIEvents_OnReceiveMsgEvent(string sScrNo, string sRQName, string sTrCode, string sMsg) : EventArgs
    {
        /// <summary>화면번호</summary>
        public string sScrNo = sScrNo;
        /// <summary>사용자 구분명</summary>
        public string sRQName = sRQName;
        /// <summary>Tran명</summary>
        public string sTrCode = sTrCode;
        /// <summary>서버에서 전달하는 메시지</summary>
        public string sMsg = sMsg;
    }

    /// <summary>실시간시세 데이터가 수신될때마다 종목단위로 발생됩니다. SetRealReg()함수로 등록한 실시간 데이터도 이 이벤트로 전달됩니다. GetCommRealData()함수를 이용해서 수신된 데이터를 얻을수 있습니다.</summary>
    public class _DKFOpenAPIEvents_OnReceiveRealDataEvent(string sJongmokCode, string sRealType, string sRealData) : EventArgs
    {
        /// <summary>종목코드</summary>
        public string sJongmokCode = sJongmokCode;
        /// <summary>실시간타입</summary>
        public string sRealType = sRealType;
        /// <summary>실시간 데이터 전문 (사용불가)</summary>
        public string sRealData = sRealData;
    }

    /// <summary>주문전송 후 주문접수, 체결통보, 잔고통보를 수신할 때 마다 발생됩니다. GetChejanData()함수를 이용해서 FID항목별 값을 얻을수 있습니다.</summary>
    public class _DKFOpenAPIEvents_OnReceiveChejanDataEvent(string sGubun, int nItemCnt, string sFIdList) : EventArgs
    {
        /// <summary>체결구분. 접수와 체결시 '0'값, 국내주식 잔고변경은 '1'값, 파생잔고변경은 '4'</summary>
        public string sGubun = sGubun;
        /// <summary>FID 개수</summary>
        public int nItemCnt = nItemCnt;
        /// <summary>FID 목록</summary>
        public string sFIdList = sFIdList;
    }

    /// <summary>로그인 처리 이벤트입니다. 성공이면 인자값 nErrCode가 0이며 에러는 다음과 같은 값이 전달됩니다.</summary>
    public class _DKFOpenAPIEvents_OnEventConnectEvent(int nErrCode) : EventArgs
    {
        /// <summary>로그인 처리 이벤트입니다. 성공이면 인자값 nErrCode가 0이며, 그 외 에러값이 전달됩니다.</summary>
        public int nErrCode = nErrCode;
    }

    /// 요청했던 조회데이터를 수신했을때 발생됩니다.
    public delegate void _DKFOpenAPIEvents_OnReceiveTrDataEventHandler(object sender, _DKFOpenAPIEvents_OnReceiveTrDataEvent e);
    /// <summary>실시간시세 데이터가 수신될때마다 종목단위로 발생됩니다. SetRealReg()함수로 등록한 실시간 데이터도 이 이벤트로 전달됩니다. GetCommRealData()함수를 이용해서 수신된 데이터를 얻을수 있습니다.</summary>
    public delegate void _DKFOpenAPIEvents_OnReceiveRealDataEventHandler(object sender, _DKFOpenAPIEvents_OnReceiveRealDataEvent e);
    /// <summary>주문전송 또는 데이터 조회요청 후 서버 메시지가 수신됩니다.※ 메시지에 포함된 6자리 코드번호는 변경될 수 있으니, 여기에 수신된 코드번호를 특정 용도로 사용하지 마시기 바랍니다.</summary>
    public delegate void _DKFOpenAPIEvents_OnReceiveMsgEventHandler(object sender, _DKFOpenAPIEvents_OnReceiveMsgEvent e);
    /// <summary>주문전송 후 주문접수, 체결통보, 잔고통보를 수신할 때 마다 발생됩니다. GetChejanData()함수를 이용해서 FID항목별 값을 얻을수 있습니다.</summary>
    public delegate void _DKFOpenAPIEvents_OnReceiveChejanDataEventHandler(object sender, _DKFOpenAPIEvents_OnReceiveChejanDataEvent e);
    /// <summary>로그인 처리 이벤트입니다. 성공이면 인자값 nErrCode가 0이며 에러는 다음과 같은 값이 전달됩니다.</summary>
    public delegate void _DKFOpenAPIEvents_OnEventConnectEventHandler(object sender, _DKFOpenAPIEvents_OnEventConnectEvent e);


    [ClassInterface(ClassInterfaceType.None)]
    internal class AxKFOpenAPIEventMulticaster(AxKFOpenAPI parent) : _DKFOpenAPIEvents
    {
        private readonly AxKFOpenAPI parent = parent;

        public virtual void OnReceiveTrData(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPreNext) => parent.RaiseOnOnReceiveTrData(parent, new(sScrNo, sRQName, sTrCode, sRecordName, sPreNext));

        public virtual void OnReceiveMsg(string sScrNo, string sRQName, string sTrCode, string sMsg) => parent.RaiseOnOnReceiveMsg(parent, new(sScrNo, sRQName, sTrCode, sMsg));

        public virtual void OnReceiveRealData(string sJongmokCode, string sRealType, string sRealData) => parent.RaiseOnOnReceiveRealData(parent, new(sJongmokCode, sRealType, sRealData));

        public virtual void OnReceiveChejanData(string sGubun, int nItemCnt, string sFIdList) => parent.RaiseOnOnReceiveChejanData(parent, new(sGubun, nItemCnt, sFIdList));

        public virtual void OnEventConnect(int nErrCode) => parent.RaiseOnOnEventConnect(parent, new(nErrCode));
    }

    /// <summary>
    /// OCX Wrapper Class
    /// </summary>
    public class AxKFOpenAPI
    {
        /// 요청했던 조회데이터를 수신했을때 발생됩니다.
        public event _DKFOpenAPIEvents_OnReceiveTrDataEventHandler OnReceiveTrData;

        /// <summary>실시간시세 데이터가 수신될때마다 종목단위로 발생됩니다. SetRealReg()함수로 등록한 실시간 데이터도 이 이벤트로 전달됩니다. GetCommRealData()함수를 이용해서 수신된 데이터를 얻을수 있습니다.</summary>
        public event _DKFOpenAPIEvents_OnReceiveRealDataEventHandler OnReceiveRealData;

        /// <summary>실시간시세 데이터가 수신될때마다 종목단위로 발생됩니다. SetRealReg()함수로 등록한 실시간 데이터도 이 이벤트로 전달됩니다. GetCommRealData()함수를 이용해서 수신된 데이터를 얻을수 있습니다.</summary>
        public event _DKFOpenAPIEvents_OnReceiveMsgEventHandler OnReceiveMsg;

        /// <summary>주문전송 후 주문접수, 체결통보, 잔고통보를 수신할 때 마다 발생됩니다. GetChejanData()함수를 이용해서 FID항목별 값을 얻을수 있습니다.</summary>
        public event _DKFOpenAPIEvents_OnReceiveChejanDataEventHandler OnReceiveChejanData;

        /// <summary>로그인 처리 이벤트입니다. 성공이면 인자값 nErrCode가 0이며 에러는 다음과 같은 값이 전달됩니다.</summary>
        public event _DKFOpenAPIEvents_OnEventConnectEventHandler OnEventConnect;

        internal void RaiseOnOnReceiveTrData(object sender, _DKFOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            int async_ident_id = AsyncNode.GetIdentId([e.sRQName, e.sTrCode, int.Parse(e.sScrNo)]);
            var async_node = _async_list.Find(x => x._ident_id == async_ident_id);
            if (async_node is not null)
            {
                _async_list.Remove(async_node);
                async_node._async_tr_action?.Invoke(e);
                async_node._async_wait.Set();
                return;
            }
            OnReceiveTrData?.Invoke(this, e);
        }

        internal void RaiseOnOnReceiveRealData(object sender, _DKFOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            OnReceiveRealData?.Invoke(this, e);
        }

        internal void RaiseOnOnReceiveMsg(object sender, _DKFOpenAPIEvents_OnReceiveMsgEvent e)
        {
            OnReceiveMsg?.Invoke(this, e);
        }

        internal void RaiseOnOnReceiveChejanData(object sender, _DKFOpenAPIEvents_OnReceiveChejanDataEvent e)
        {
            OnReceiveChejanData?.Invoke(this, e);
        }

        internal void RaiseOnOnEventConnect(object sender, _DKFOpenAPIEvents_OnEventConnectEvent e)
        {
            OnEventConnect?.Invoke(this, e);
        }

        //public virtual void AboutBox()
        //{
        //    if (ocx == null)
        //    {
        //        throw new InvalidActiveXStateException("AboutBox", ActiveXInvokeKind.MethodInvoke);
        //    }

        //    ocx.AboutBox();
        //}

        /// <summary>
        /// 로그인 윈도우를 실행한다.
        /// </summary>
        /// <param name="nAutoUpgrade">버전처리시, 수동 또는 자동 설정을 위한 구분값(0 : 수동진행, 1 : 자동진행)</param>
        /// <returns></returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int CommConnect(int nAutoUpgrade)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommConnect", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommConnect(nAutoUpgrade);
        }

        /// <summary>
        /// 조회를 서버로 송신한다.
        /// </summary>
        /// <param name="sRQName">사용자구분명 입력</param>
        /// <param name="sTrCode">Tr목록의 TrCode 입력 (예 : opt10001)</param>
        /// <param name="sPrevNext">서버에서 내려준 Next키 값  입력</param>
        /// <param name="sScreenNo">4자리의 화면번호 입력 (1 ~ 9999 : 숫자형식으로만 가능)</param>
        /// <returns></returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int CommRqData(string sRQName, string sTrCode, string sPrevNext, string sScreenNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommRqData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommRqData(sRQName, sTrCode, sPrevNext, sScreenNo);
        }

        /// <summary>
        /// 조회 입력값을 셋팅한다
        /// </summary>
        /// <param name="sID">입력 아이디명</param>
        /// <param name="sValue">입력 값 </param>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual void SetInputValue(string sID, string sValue)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetInputValue", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SetInputValue(sID, sValue);
        }

        /// <summary>
        /// 수신데이타를 반환한다.
        /// </summary>
        /// <param name="strTrCode">Tr목록의 TrCode</param>
        /// <param name="strRecordName">조회시 sRQName</param>
        /// <param name="nIndex">Row 인덱스</param>
        /// <param name="strItemName">Tr목록의 싱글/멀티데이타의 필드명</param>
        /// <returns></returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetCommData(string strTrCode, string strRecordName, int nIndex, string strItemName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommData(strTrCode, strRecordName, nIndex, strItemName);
        }

        /// <summary>
        /// OpenAPI의 서버 접속을 해제한다.
        /// </summary>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual void CommTerminate()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommTerminate", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.CommTerminate();
        }

        /// <summary>
        /// 수신데이타(멀티데이타) 반복횟수를 반환한다.
        /// </summary>
        /// <param name="sTrCode">Tr목록의 TrCode</param>
        /// <param name="sRecordName">조회시 sRQName  </param>
        /// <returns>데이타 반복횟수</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int GetRepeatCnt(string sTrCode, string sRecordName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetRepeatCnt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetRepeatCnt(sTrCode, sRecordName);
        }

        /// <summary>
        /// 화면 내의 모든 리얼데이터 요청을 제거한다.
        /// </summary>
        /// <param name="sScreenNo">4자리의 화면번호 입력 (1 ~ 9999 : 숫자형식으로만 가능)</param>
        /// <remarks>화면을 종료할 때 반드시 위 함수를 호출해야 리얼데이타 해제가 된다.</remarks>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual void DisconnectRealData(string sScreenNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DisconnectRealData", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.DisconnectRealData(sScreenNo);
        }

        /// <summary>
        /// 실시간데이타를 반환한다.
        /// </summary>
        /// <param name="sRealType">"해외선물시세", "해외옵션시세", "해외선물호가", "해외옵션호가" 입력 (미입력해도 가능) </param>
        /// <param name="nFid">실시간목록의 필드값을 참조</param>
        /// <returns>실시간 데이타 반환</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetCommRealData(string sRealType, int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommRealData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommRealData(sRealType, nFid);
        }

        /// <summary>
        /// 체결잔고 실시간 데이타를 반환한다.
        /// </summary>
        /// <param name="nFid">실시간목록의 필드값을 참조  </param>
        /// <returns>체결잔고 데이타 반환</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetChejanData(int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetChejanData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetChejanData(nFid);
        }

        /// <summary>
        /// 주문을 서버로 송신한다.
        /// </summary>
        /// <param name="sRQName">사용자구분명 입력</param>
        /// <param name="sScreenNo">4자리의 화면번호 입력 (1 ~ 9999 : 숫자형식으로만 가능)</param>
        /// <param name="sAccNo">계좌번호</param>
        /// <param name="nOrderType">주문유형 (1:신규매도, 2:신규매수 3:매도취소, 4:매수취소, 5:매도정정, 6:매수정정)</param>
        /// <param name="sCode">종목코드</param>
        /// <param name="nQty">주문수량</param>
        /// <param name="sPrice">주문단가</param>
        /// <param name="sStopPrice">Stop단가</param>
        /// <param name="sHogaGb">거래구분 (1:시장가, 2:지정가, 3:STOP, 4:STOP LIMIT)</param>
        /// <param name="sOrgOrderNo">원주문번호</param>
        /// <returns></returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int SendOrder(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, string sPrice, string sStopPrice, string sHogaGb, string sOrgOrderNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendOrder", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, sPrice, sStopPrice, sHogaGb, sOrgOrderNo);
        }

        /// <summary>
        /// 로그인 사용자 정보를 반환한다.
        /// </summary>
        /// <param name="sTag">사용자정보 구분값</param>
        /// <returns>로그인정보 데이타 반환</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetLoginInfo(string sTag)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetLoginInfo", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetLoginInfo(sTag);
        }

        /// <summary>
        /// 해외선물 상품리스트를 반환한다.
        /// </summary>
        /// <returns>해외선물 상품리스트, 상품간 구분은 ";"</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutureItemlist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureItemlist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureItemlist();
        }

        /// <summary>
        /// 해외선물 상품리스트를 반환한다.
        /// </summary>
        /// <returns>해외옵션 상품리스트, 상품간 구분은 ";"</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalOptionItemlist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionItemlist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionItemlist();
        }

        /// <summary>
        /// 해외상품별 해외선물 종목코드 리스트를 반환
        /// </summary>
        /// <param name="sItem">해외상품 입력 (6A, ES, ...)  </param>
        /// <returns>해외선물 종목코드리스트, 상품간 구분은 ";"</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutureCodelist(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureCodelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureCodelist(sItem);
        }

        /// <summary>
        /// 해외상품별 해외옵션 종목코드 리스트를 반환
        /// </summary>
        /// <param name="sItem">해외상품 입력 (6A, ES, ...)  </param>
        /// <returns>해외옵션 종목코드리스트, 상품간 구분은 ";"</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalOptionCodelist(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionCodelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionCodelist(sItem);
        }

        /// <summary>
        /// 현재 접속상태를 반환한다.
        /// </summary>
        /// <returns>접속상태 (0 : 미연결,  1 : 연결완료) </returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual int GetConnectState()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetConnectState", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetConnectState();
        }

        /// <summary>
        /// OpenAPI모듈의 경로를 반환한다.
        /// </summary>
        /// <returns>Path 경로위치</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetAPIModulePath()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetAPIModulePath", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetAPIModulePath();
        }

        /// <summary>
        /// 공통함수로 추후 추가함수가 필요시 사용할 함수이다.
        /// </summary>
        /// <param name="sFuncName">함수명 입력</param>
        /// <param name="sParam">입력항목 입력  </param>
        /// <returns>함수에 대한 반환값</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetCommonFunc(string sFuncName, string sParam)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommonFunc", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommonFunc(sFuncName, sParam);
        }

        /// <summary>
        /// 가격 진법에 따라 변환된 가격을 반환한다
        /// </summary>
        /// <param name="sCode">종목코드 입력</param>
        /// <param name="sPrice">가격 입력</param>
        /// <param name="nType">가격타입 입력 (0 : 진법(표시가격) -> 10진수,  1 : 10진수 -> 진법(표시가격))  </param>
        /// <returns>가격에 대한 반환값</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetConvertPrice(string sCode, string sPrice, int nType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetConvertPrice", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetConvertPrice(sCode, sPrice, nType);
        }

        /// <summary>
        /// 해외선물옵션 종목코드 정보를 타입별로 반환한다.
        /// </summary>
        /// <param name="nGubun">해외선물옵션 구분값 입력 (0 : 해외선물, 1 : 해외옵션)</param>
        /// <param name="sType">상품타입 입력 ("" : 전체, IDX : 지수, CUR : 통화, INT : 금리, MTL : 금속, ENG : 에너지, CMD : 농산물) </param>
        /// <returns>종목코드 정보리스트들을 문자값으로 반환한다</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutOpCodeInfoByType(int nGubun, string sType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutOpCodeInfoByType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutOpCodeInfoByType(nGubun, sType);
        }

        /// <summary>
        /// 해외선물옵션 종목코드정보를 종목코드별로 반환한다.
        /// </summary>
        /// <param name="sCode">해외선물옵션 종목코드 입력</param>
        /// <returns>종목코드 정보를 문자값으로 반환한다</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutOpCodeInfoByCode(string sCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutOpCodeInfoByCode", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutOpCodeInfoByCode(sCode);
        }

        /// <summary>
        /// 해외선물 상품리스트를 타입별로 반환한다
        /// </summary>
        /// <param name="sType">상품타입 입력 (IDX : 지수, CUR : 통화, INT : 금리, MTL : 금속, ENG : 에너지, CMD : 농산물) </param>
        /// <returns>상품리스트들을 문자값으로 반환한다</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutureItemlistByType(string sType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureItemlistByType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureItemlistByType(sType);
        }

        /// <summary>
        /// 해외선물종목코드를 상품/월물별로 반환한다.
        /// </summary>
        /// <param name="sItem">상품코드 입력 (6A, ES...)</param>
        /// <param name="sMonth">월물 입력 ("201606")</param>
        /// <returns>종목코드를 문자값으로 반환한다</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutureCodeByItemMonth(string sItem, string sMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureCodeByItemMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureCodeByItemMonth(sItem, sMonth);
        }

        /// <summary>
        /// 해외옵션 종목코드를 상품/콜풋/행사가/월물별로 반환한다.
        /// </summary>
        /// <param name="sItem">상품코드 입력 (6A, ES...)</param>
        /// <param name="sCPGubun">콜/풋 구분 입력 (C : 콜, P : 풋)</param>
        /// <param name="sActivePrice">행사가 입력 (0.7615)</param>
        /// <param name="sMonth">월물 입력 ("201606")</param>
        /// <returns>종목코드를 문자값으로 반환한다</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalOptionCodeByMonth(string sItem, string sCPGubun, string sActivePrice, string sMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionCodeByMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionCodeByMonth(sItem, sCPGubun, sActivePrice, sMonth);
        }

        /// <summary>
        /// 해외옵션 월물리스트를 상품별로 반환한다.
        /// </summary>
        /// <param name="sItem">상품코드 입력 (6A, ES...)  </param>
        /// <returns>월물리스트를 문자값으로 반환한다</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalOptionMonthByItem(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionMonthByItem", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionMonthByItem(sItem);
        }

        /// <summary>
        /// 해외옵션행사가리스트를 상품별로 반환한다.
        /// </summary>
        /// <param name="sItem">해외상품 입력 (6A, ES, ...)  </param>
        /// <returns>행사가리스트를 문자값으로 반환한다</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalOptionActPriceByItem(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionActPriceByItem", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionActPriceByItem(sItem);
        }

        /// <summary>
        /// 해외선물 상품타입리스트를 반환한다.
        /// </summary>
        /// <returns>상품타입리스트를 문자값으로 반환한다</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetGlobalFutureItemTypelist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureItemTypelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureItemTypelist();
        }

        /// <summary>
        /// 수신된 전체데이터를 반환한다
        /// </summary>
        /// <param name="sTrCode">Tr목록의 TrCode</param>
        /// <param name="sRecordName">사용자구분명 입력</param>
        /// <param name="nGubun">수신데이타 구분 입력 (0 : 전체(싱글+멀티),  1 : 싱글데이타, 2 : 멀티데이타)</param>
        /// <returns>수신 전체데이터를 문자값으로 반환한다(TR목록에서 필드 사이즈 참조(필드명 옆 가로안의 숫자))</returns>
        /// <exception cref="InvalidActiveXStateException"></exception>
        public virtual string GetCommFullData(string sTrCode, string sRecordName, int nGubun)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommFullData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommFullData(sTrCode, sRecordName, nGubun);
        }

        interface MyInterface
        {
            
        }
        enum ActiveXInvokeKind
        {
            MethodInvoke,
            PropertyGet,
            PropertySet,
        }
        class InvalidActiveXStateException(string name, ActiveXInvokeKind kind) : Exception
        {
            private readonly string _name = name;
            private readonly ActiveXInvokeKind _kind = kind;

            public override string ToString()
            {
                return _kind switch
                {
                    ActiveXInvokeKind.MethodInvoke => string.Format("AXInvalidMethodInvoke {0}", _name),
                    ActiveXInvokeKind.PropertyGet => string.Format("AXInvalidPropertyGet {0}", _name),
                    ActiveXInvokeKind.PropertySet => string.Format("AXInvalidPropertySet {0}", _name),
                    _ => base.ToString(),
                };
            }
        }

        // additonal code
        [DllImport("Atl.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool AtlAxWinInit();
        [DllImport("Atl.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int AtlAxGetControl(IntPtr h, [MarshalAs(UnmanagedType.IUnknown)] out object pp);
        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool DestroyWindow(IntPtr hWnd);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        private const int WS_VISIBLE = 0x10000000;
        private const int WS_CHILD = 0x40000000;

        private readonly IntPtr hWndContainer = IntPtr.Zero;

        private readonly _DKFOpenAPI ocx;
        private readonly System.Runtime.InteropServices.ComTypes.IConnectionPoint _pConnectionPoint;
        private readonly bool bInitialized = false;
        private int _async_TimeOut = 5000;
        /// <summary>
        /// 비동기 요청시 타임아웃 시간을 설정합니다. 기본값은 5000ms입니다.
        /// </summary>
        public int AsyncTimeOut
        {
            get => _async_TimeOut;
            set
            {
                _async_TimeOut = (value < 1000) ? 1000 : value;
            }
        }

        /// <summary>
        /// OCX가 생성되었는지 여부를 반환합니다.
        /// </summary>
        public bool Created => bInitialized;

        /// <summary>
        /// OCX를 생성합니다.
        /// </summary>
        /// <param name="hWndParent"></param>
        public AxKFOpenAPI(nint hWndParent = 0)
        {
            if (hWndParent == IntPtr.Zero)
            {
                hWndParent = Process.GetCurrentProcess().MainWindowHandle;
                if (hWndParent == IntPtr.Zero)
                {
                    hWndParent = GetConsoleWindow();
                }
            }

            string clsid = "{d1acab7d-a3af-49e4-9004-c9e98344e17a}";

            if (AtlAxWinInit())
            {
                hWndContainer = CreateWindowEx(0, "AtlAxWin", clsid, WS_VISIBLE | WS_CHILD, -100, -100, 0, 0, hWndParent, (IntPtr)9002, IntPtr.Zero, IntPtr.Zero);
                if (hWndContainer == IntPtr.Zero && Environment.Is64BitProcess)
                {
                    // old 버젼 64비트 OCX경우:
                    clsid = "{c42af31e-d199-4624-a57c-280d5b019cad}";
                    hWndContainer = CreateWindowEx(0, "AtlAxWin", clsid, WS_VISIBLE | WS_CHILD, -100, -100, 0, 0, hWndParent, (IntPtr)9002, IntPtr.Zero, IntPtr.Zero);
                }
                if (hWndContainer != IntPtr.Zero)
                {
                    try
                    {
                        AtlAxGetControl(hWndContainer, out object pUnknown);
                        if (pUnknown != null)
                        {
                            ocx = (_DKFOpenAPI)pUnknown;
                            if (ocx != null)
                            {
                                Guid guidEvents = typeof(_DKFOpenAPIEvents).GUID;
                                System.Runtime.InteropServices.ComTypes.IConnectionPointContainer pConnectionPointContainer;
                                pConnectionPointContainer = (System.Runtime.InteropServices.ComTypes.IConnectionPointContainer)pUnknown;
                                pConnectionPointContainer.FindConnectionPoint(ref guidEvents, out _pConnectionPoint);
                                if (_pConnectionPoint != null)
                                {
                                    AxKFOpenAPIEventMulticaster pEventSink = new(this);
                                    _pConnectionPoint.Advise(pEventSink, out int nCookie);
                                }
                                bInitialized = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        DestroyWindow(hWndContainer);
                        hWndContainer = IntPtr.Zero;
                    }
                }
            }
        }

        #region 비동기요청 (버젼 1.5.0 추가)
        class AsyncNode(object[] objs)
        {
            public readonly int _ident_id = GetIdentId(objs);

            public static int GetIdentId(object[] objs)
            {
                int id = 0;
                for (int i = 0; i < objs.Length; i++)
                {
                    id = id * 31 + objs[i].GetHashCode();
                }
                return id;
            }

            public readonly ManualResetEvent _async_wait = new(initialState: false);
            public Action<_DKFOpenAPIEvents_OnReceiveTrDataEvent> _async_tr_action = null;
        }

        readonly List<AsyncNode> _async_list = [];

        /// <summary>
        /// 조회를 서버로 송신한다. 비동기 방식으로 수신합니다.
        /// </summary>
        /// <param name="sRQName">사용자구분명 입력</param>
        /// <param name="sTrCode">Tr목록의 TrCode 입력 (예 : opt10001)</param>
        /// <param name="sPrevNext">서버에서 내려준 Next키 값  입력</param>
        /// <param name="sScreenNo">4자리의 화면번호 입력 (1 ~ 9999 : 숫자형식으로만 가능)</param>
        /// <param name="action">이벤트 콜백 함수</param>
        /// <returns></returns>
        public virtual async Task<int> CommRqDataAsync(string sRQName, string sTrCode, string sPrevNext, string sScreenNo, Action<_DKFOpenAPIEvents_OnReceiveTrDataEvent> action)
        {
            var newAsync = new AsyncNode([sRQName, sTrCode, int.Parse(sScreenNo)])
            {
                _async_tr_action = action,
            };
            _async_list.Add(newAsync);

            int nRet = CommRqData(sRQName, sTrCode, sPrevNext, sScreenNo);
            if (nRet == 0)
            {
                bool bTimeOut = false;
                Task taskAsync = Task.Run(() =>
                {
                    if (!newAsync._async_wait.WaitOne(AsyncTimeOut))
                    {
                        bTimeOut = true;
                    }
                });
                await taskAsync.ConfigureAwait(true);
                if (bTimeOut && _async_list.IndexOf(newAsync) >= 0)
                {
                    nRet = -902;
                }
            }
            _async_list.Remove(newAsync);
            return nRet;
        }
        #endregion
    }
}
