using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace KHOpenApi.NET
{
    [ComImport]
    [Guid("CF20FBB6-EDD4-4BE5-A473-FEF91977DEB6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface _DKHOpenAPI
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(1)]
        int CommConnect();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(2)]
        void CommTerminate();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(3)]
        int CommRqData([MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, int nPrevNext, [MarshalAs(UnmanagedType.BStr)] string sScreenNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(4)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetLoginInfo([MarshalAs(UnmanagedType.BStr)] string sTag);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(5)]
        int SendOrder([MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sScreenNo, [MarshalAs(UnmanagedType.BStr)] string sAccNo, int nOrderType, [MarshalAs(UnmanagedType.BStr)] string sCode, int nQty, int nPrice, [MarshalAs(UnmanagedType.BStr)] string sHogaGb, [MarshalAs(UnmanagedType.BStr)] string sOrgOrderNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(6)]
        int SendOrderFO([MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sScreenNo, [MarshalAs(UnmanagedType.BStr)] string sAccNo, [MarshalAs(UnmanagedType.BStr)] string sCode, int lOrdKind, [MarshalAs(UnmanagedType.BStr)] string sSlbyTp, [MarshalAs(UnmanagedType.BStr)] string sOrdTp, int lQty, [MarshalAs(UnmanagedType.BStr)] string sPrice, [MarshalAs(UnmanagedType.BStr)] string sOrgOrdNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(7)]
        void SetInputValue([MarshalAs(UnmanagedType.BStr)] string sID, [MarshalAs(UnmanagedType.BStr)] string sValue);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(8)]
        int SetOutputFID([MarshalAs(UnmanagedType.BStr)] string sID);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(9)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string CommGetData([MarshalAs(UnmanagedType.BStr)] string sJongmokCode, [MarshalAs(UnmanagedType.BStr)] string sRealType, [MarshalAs(UnmanagedType.BStr)] string sFieldName, int nIndex, [MarshalAs(UnmanagedType.BStr)] string sInnerFieldName);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(10)]
        void DisconnectRealData([MarshalAs(UnmanagedType.BStr)] string sScnNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(11)]
        int GetRepeatCnt([MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRecordName);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(12)]
        int CommKwRqData([MarshalAs(UnmanagedType.BStr)] string sArrCode, int bNext, int nCodeCount, int nTypeFlag, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sScreenNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(13)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetAPIModulePath();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(14)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCodeListByMarket([MarshalAs(UnmanagedType.BStr)] string sMarket);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(15)]
        int GetConnectState();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(16)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetMasterCodeName([MarshalAs(UnmanagedType.BStr)] string sTrCode);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(17)]
        int GetMasterListedStockCnt([MarshalAs(UnmanagedType.BStr)] string sTrCode);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(18)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetMasterConstruction([MarshalAs(UnmanagedType.BStr)] string sTrCode);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(19)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetMasterListedStockDate([MarshalAs(UnmanagedType.BStr)] string sTrCode);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(20)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetMasterLastPrice([MarshalAs(UnmanagedType.BStr)] string sTrCode);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(21)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetMasterStockState([MarshalAs(UnmanagedType.BStr)] string sTrCode);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(22)]
        int GetDataCount([MarshalAs(UnmanagedType.BStr)] string strRecordName);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(23)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetOutputValue([MarshalAs(UnmanagedType.BStr)] string strRecordName, int nRepeatIdx, int nItemIdx);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(24)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommData([MarshalAs(UnmanagedType.BStr)] string strTrCode, [MarshalAs(UnmanagedType.BStr)] string strRecordName, int nIndex, [MarshalAs(UnmanagedType.BStr)] string strItemName);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(25)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommRealData([MarshalAs(UnmanagedType.BStr)] string sTrCode, int nFid);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(26)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetChejanData(int nFid);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(27)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetThemeGroupList(int nType);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(28)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetThemeGroupCode([MarshalAs(UnmanagedType.BStr)] string strThemeCode);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(29)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetFutureList();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(30)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetFutureCodeByIndex(int nIndex);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(31)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetActPriceList();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(32)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetMonthList();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(33)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetOptionCode([MarshalAs(UnmanagedType.BStr)] string strActPrice, int nCp, [MarshalAs(UnmanagedType.BStr)] string strMonth);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(34)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetOptionCodeByMonth([MarshalAs(UnmanagedType.BStr)] string sTrCode, int nCp, [MarshalAs(UnmanagedType.BStr)] string strMonth);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(35)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetOptionCodeByActPrice([MarshalAs(UnmanagedType.BStr)] string sTrCode, int nCp, int nTick);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(36)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetSFutureList([MarshalAs(UnmanagedType.BStr)] string strBaseAssetCode);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(37)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetSFutureCodeByIndex([MarshalAs(UnmanagedType.BStr)] string strBaseAssetCode, int nIndex);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(38)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetSActPriceList([MarshalAs(UnmanagedType.BStr)] string strBaseAssetGb);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(39)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetSMonthList([MarshalAs(UnmanagedType.BStr)] string strBaseAssetGb);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(40)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetSOptionCode([MarshalAs(UnmanagedType.BStr)] string strBaseAssetGb, [MarshalAs(UnmanagedType.BStr)] string strActPrice, int nCp, [MarshalAs(UnmanagedType.BStr)] string strMonth);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(41)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetSOptionCodeByMonth([MarshalAs(UnmanagedType.BStr)] string strBaseAssetGb, [MarshalAs(UnmanagedType.BStr)] string sTrCode, int nCp, [MarshalAs(UnmanagedType.BStr)] string strMonth);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(42)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetSOptionCodeByActPrice([MarshalAs(UnmanagedType.BStr)] string strBaseAssetGb, [MarshalAs(UnmanagedType.BStr)] string sTrCode, int nCp, int nTick);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(43)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetSFOBasisAssetList();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(44)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetOptionATM();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(45)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetSOptionATM([MarshalAs(UnmanagedType.BStr)] string strBaseAssetGb);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(46)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetBranchCodeName();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(47)]
        int CommInvestRqData([MarshalAs(UnmanagedType.BStr)] string sMarketGb, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sScreenNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(48)]
        int SendOrderCredit([MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sScreenNo, [MarshalAs(UnmanagedType.BStr)] string sAccNo, int nOrderType, [MarshalAs(UnmanagedType.BStr)] string sCode, int nQty, int nPrice, [MarshalAs(UnmanagedType.BStr)] string sHogaGb, [MarshalAs(UnmanagedType.BStr)] string sCreditGb, [MarshalAs(UnmanagedType.BStr)] string sLoanDate, [MarshalAs(UnmanagedType.BStr)] string sOrgOrderNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(49)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string KOA_Functions([MarshalAs(UnmanagedType.BStr)] string sFunctionName, [MarshalAs(UnmanagedType.BStr)] string sParam);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(50)]
        int SetInfoData([MarshalAs(UnmanagedType.BStr)] string sInfoData);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(51)]
        int SetRealReg([MarshalAs(UnmanagedType.BStr)] string strScreenNo, [MarshalAs(UnmanagedType.BStr)] string strCodeList, [MarshalAs(UnmanagedType.BStr)] string strFidList, [MarshalAs(UnmanagedType.BStr)] string strOptType);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(52)]
        int GetConditionLoad();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(53)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetConditionNameList();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(54)]
        int SendCondition([MarshalAs(UnmanagedType.BStr)] string strScrNo, [MarshalAs(UnmanagedType.BStr)] string strConditionName, int nIndex, int nSearch);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(55)]
        void SendConditionStop([MarshalAs(UnmanagedType.BStr)] string strScrNo, [MarshalAs(UnmanagedType.BStr)] string strConditionName, int nIndex);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(56)]
        [return: MarshalAs(UnmanagedType.Struct)]
        object GetCommDataEx([MarshalAs(UnmanagedType.BStr)] string strTrCode, [MarshalAs(UnmanagedType.BStr)] string strRecordName);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(57)]
        void SetRealRemove([MarshalAs(UnmanagedType.BStr)] string strScrNo, [MarshalAs(UnmanagedType.BStr)] string strDelCode);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(58)]
        int GetMarketType([MarshalAs(UnmanagedType.BStr)] string sTrCode);
    }

    [ComImport]
    [Guid("7335F12D-8973-4BD5-B7F0-12DF03D175B7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface _DKHOpenAPIEvents
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

    public class _DKHOpenAPIEvents_OnReceiveTrDataEvent
    {
        public string sScrNo;

        public string sRQName;

        public string sTrCode;

        public string sRecordName;

        public string sPrevNext;

        public int nDataLength;

        public string sErrorCode;

        public string sMessage;

        public string sSplmMsg;

        public _DKHOpenAPIEvents_OnReceiveTrDataEvent(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPrevNext, int nDataLength, string sErrorCode, string sMessage, string sSplmMsg)
        {
            this.sScrNo = sScrNo;
            this.sRQName = sRQName;
            this.sTrCode = sTrCode;
            this.sRecordName = sRecordName;
            this.sPrevNext = sPrevNext;
            this.nDataLength = nDataLength;
            this.sErrorCode = sErrorCode;
            this.sMessage = sMessage;
            this.sSplmMsg = sSplmMsg;
        }
    }
    public class _DKHOpenAPIEvents_OnReceiveRealDataEvent
    {
        public string sRealKey;

        public string sRealType;

        public string sRealData;

        public _DKHOpenAPIEvents_OnReceiveRealDataEvent(string sRealKey, string sRealType, string sRealData)
        {
            this.sRealKey = sRealKey;
            this.sRealType = sRealType;
            this.sRealData = sRealData;
        }
    }
    public class _DKHOpenAPIEvents_OnReceiveMsgEvent
    {
        public string sScrNo;

        public string sRQName;

        public string sTrCode;

        public string sMsg;

        public _DKHOpenAPIEvents_OnReceiveMsgEvent(string sScrNo, string sRQName, string sTrCode, string sMsg)
        {
            this.sScrNo = sScrNo;
            this.sRQName = sRQName;
            this.sTrCode = sTrCode;
            this.sMsg = sMsg;
        }
    }
    public class _DKHOpenAPIEvents_OnReceiveChejanDataEvent
    {
        public string sGubun;

        public int nItemCnt;

        public string sFIdList;

        public _DKHOpenAPIEvents_OnReceiveChejanDataEvent(string sGubun, int nItemCnt, string sFIdList)
        {
            this.sGubun = sGubun;
            this.nItemCnt = nItemCnt;
            this.sFIdList = sFIdList;
        }
    }
    public class _DKHOpenAPIEvents_OnEventConnectEvent
    {
        public int nErrCode;

        public _DKHOpenAPIEvents_OnEventConnectEvent(int nErrCode)
        {
            this.nErrCode = nErrCode;
        }
    }
    public class _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent
    {
        public string sRealKey;

        public _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent(string sRealKey)
        {
            this.sRealKey = sRealKey;
        }
    }
    public class _DKHOpenAPIEvents_OnReceiveRealConditionEvent
    {
        public string sTrCode;

        public string strType;

        public string strConditionName;

        public string strConditionIndex;

        public _DKHOpenAPIEvents_OnReceiveRealConditionEvent(string sTrCode, string strType, string strConditionName, string strConditionIndex)
        {
            this.sTrCode = sTrCode;
            this.strType = strType;
            this.strConditionName = strConditionName;
            this.strConditionIndex = strConditionIndex;
        }
    }
    public class _DKHOpenAPIEvents_OnReceiveTrConditionEvent
    {
        public string sScrNo;

        public string strCodeList;

        public string strConditionName;

        public int nIndex;

        public int nNext;

        public _DKHOpenAPIEvents_OnReceiveTrConditionEvent(string sScrNo, string strCodeList, string strConditionName, int nIndex, int nNext)
        {
            this.sScrNo = sScrNo;
            this.strCodeList = strCodeList;
            this.strConditionName = strConditionName;
            this.nIndex = nIndex;
            this.nNext = nNext;
        }
    }
    public class _DKHOpenAPIEvents_OnReceiveConditionVerEvent
    {
        public int lRet;

        public string sMsg;

        public _DKHOpenAPIEvents_OnReceiveConditionVerEvent(int lRet, string sMsg)
        {
            this.lRet = lRet;
            this.sMsg = sMsg;
        }
    }


    public delegate void _DKHOpenAPIEvents_OnReceiveTrDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e);
    public delegate void _DKHOpenAPIEvents_OnReceiveRealDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e);
    public delegate void _DKHOpenAPIEvents_OnReceiveMsgEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e);
    public delegate void _DKHOpenAPIEvents_OnReceiveChejanDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e);
    public delegate void _DKHOpenAPIEvents_OnEventConnectEventHandler(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e);
    public delegate void _DKHOpenAPIEvents_OnReceiveInvestRealDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent e);
    public delegate void _DKHOpenAPIEvents_OnReceiveRealConditionEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e);
    public delegate void _DKHOpenAPIEvents_OnReceiveTrConditionEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e);
    public delegate void _DKHOpenAPIEvents_OnReceiveConditionVerEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e);


    [ClassInterface(ClassInterfaceType.None)]
    public class AxKHOpenAPIEventMulticaster : _DKHOpenAPIEvents
    {
        private AxKHOpenAPI parent;

        public AxKHOpenAPIEventMulticaster(AxKHOpenAPI parent)
        {
            this.parent = parent;
        }

        public virtual void OnReceiveTrData(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPrevNext, int nDataLength, string sErrorCode, string sMessage, string sSplmMsg)
        {
            _DKHOpenAPIEvents_OnReceiveTrDataEvent e = new _DKHOpenAPIEvents_OnReceiveTrDataEvent(sScrNo, sRQName, sTrCode, sRecordName, sPrevNext, nDataLength, sErrorCode, sMessage, sSplmMsg);
            parent.RaiseOnOnReceiveTrData(parent, e);
        }

        public virtual void OnReceiveRealData(string sRealKey, string sRealType, string sRealData)
        {
            _DKHOpenAPIEvents_OnReceiveRealDataEvent e = new _DKHOpenAPIEvents_OnReceiveRealDataEvent(sRealKey, sRealType, sRealData);
            parent.RaiseOnOnReceiveRealData(parent, e);
        }

        public virtual void OnReceiveMsg(string sScrNo, string sRQName, string sTrCode, string sMsg)
        {
            _DKHOpenAPIEvents_OnReceiveMsgEvent e = new _DKHOpenAPIEvents_OnReceiveMsgEvent(sScrNo, sRQName, sTrCode, sMsg);
            parent.RaiseOnOnReceiveMsg(parent, e);
        }

        public virtual void OnReceiveChejanData(string sGubun, int nItemCnt, string sFIdList)
        {
            _DKHOpenAPIEvents_OnReceiveChejanDataEvent e = new _DKHOpenAPIEvents_OnReceiveChejanDataEvent(sGubun, nItemCnt, sFIdList);
            parent.RaiseOnOnReceiveChejanData(parent, e);
        }

        public virtual void OnEventConnect(int nErrCode)
        {
            _DKHOpenAPIEvents_OnEventConnectEvent e = new _DKHOpenAPIEvents_OnEventConnectEvent(nErrCode);
            parent.RaiseOnOnEventConnect(parent, e);
        }

        public virtual void OnReceiveInvestRealData(string sRealKey)
        {
            _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent e = new _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent(sRealKey);
            parent.RaiseOnOnReceiveInvestRealData(parent, e);
        }

        public virtual void OnReceiveRealCondition(string sTrCode, string strType, string strConditionName, string strConditionIndex)
        {
            _DKHOpenAPIEvents_OnReceiveRealConditionEvent e = new _DKHOpenAPIEvents_OnReceiveRealConditionEvent(sTrCode, strType, strConditionName, strConditionIndex);
            parent.RaiseOnOnReceiveRealCondition(parent, e);
        }

        public virtual void OnReceiveTrCondition(string sScrNo, string strCodeList, string strConditionName, int nIndex, int nNext)
        {
            _DKHOpenAPIEvents_OnReceiveTrConditionEvent e = new _DKHOpenAPIEvents_OnReceiveTrConditionEvent(sScrNo, strCodeList, strConditionName, nIndex, nNext);
            parent.RaiseOnOnReceiveTrCondition(parent, e);
        }

        public virtual void OnReceiveConditionVer(int lRet, string sMsg)
        {
            _DKHOpenAPIEvents_OnReceiveConditionVerEvent e = new _DKHOpenAPIEvents_OnReceiveConditionVerEvent(lRet, sMsg);
            parent.RaiseOnOnReceiveConditionVer(parent, e);
        }
    }

    public class AxKHOpenAPI
    {
        [DllImport("Atl.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool AtlAxWinInit();
        [DllImport("Atl.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int AtlAxGetControl(IntPtr h, [MarshalAs(UnmanagedType.IUnknown)] out object pp);
        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool DestroyWindow(IntPtr hWnd);

        private const int WS_VISIBLE = 0x10000000;
        private const int WS_CHILD = 0x40000000;

        private IntPtr hWndContainer = IntPtr.Zero;

        private _DKHOpenAPI ocx;
        private System.Runtime.InteropServices.ComTypes.IConnectionPoint _pConnectionPoint;
        private int _nCookie = 0;
        private bool bInitialized = false;

        public bool Created => bInitialized;

        public AxKHOpenAPI(IntPtr hWndParent)
        {
            string clsid = System.Environment.Is64BitProcess ? "{0f3a0d96-1432-4d05-a1ac-220e202bb52c}" : "{a1574a0d-6bfa-4bd7-9020-ded88711818d}";
            if (!bInitialized)
            {
                if (AtlAxWinInit())
                {
                    hWndContainer = CreateWindowEx(0, "AtlAxWin", clsid, WS_VISIBLE | WS_CHILD, -100, -100, 20, 20, hWndParent, (IntPtr)9001, IntPtr.Zero, IntPtr.Zero);
                    if (hWndContainer != IntPtr.Zero)
                    {
                        try
                        {
                            object pUnknown;
                            AtlAxGetControl(hWndContainer, out pUnknown);
                            if (pUnknown != null)
                            {
                                ocx = (_DKHOpenAPI)pUnknown;
                                if (ocx != null)
                                {
                                    Guid guidEvents = typeof(_DKHOpenAPIEvents).GUID;
                                    System.Runtime.InteropServices.ComTypes.IConnectionPointContainer pConnectionPointContainer;
                                    pConnectionPointContainer = (System.Runtime.InteropServices.ComTypes.IConnectionPointContainer)pUnknown;
                                    pConnectionPointContainer.FindConnectionPoint(ref guidEvents, out _pConnectionPoint);
                                    if (_pConnectionPoint != null)
                                    {
                                        AxKHOpenAPIEventMulticaster pEventSink = new AxKHOpenAPIEventMulticaster(this);
                                        _pConnectionPoint.Advise(pEventSink, out _nCookie);
                                        bInitialized = true;
                                    }
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
        }

        public event _DKHOpenAPIEvents_OnReceiveTrDataEventHandler OnReceiveTrData;

        public event _DKHOpenAPIEvents_OnReceiveRealDataEventHandler OnReceiveRealData;

        public event _DKHOpenAPIEvents_OnReceiveMsgEventHandler OnReceiveMsg;

        public event _DKHOpenAPIEvents_OnReceiveChejanDataEventHandler OnReceiveChejanData;

        public event _DKHOpenAPIEvents_OnEventConnectEventHandler OnEventConnect;

        public event _DKHOpenAPIEvents_OnReceiveInvestRealDataEventHandler OnReceiveInvestRealData;

        public event _DKHOpenAPIEvents_OnReceiveRealConditionEventHandler OnReceiveRealCondition;

        public event _DKHOpenAPIEvents_OnReceiveTrConditionEventHandler OnReceiveTrCondition;

        public event _DKHOpenAPIEvents_OnReceiveConditionVerEventHandler OnReceiveConditionVer;
        internal void RaiseOnOnReceiveTrData(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (this.OnReceiveTrData != null)
            {
                this.OnReceiveTrData(sender, e);
            }
        }

        internal void RaiseOnOnReceiveRealData(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            if (this.OnReceiveRealData != null)
            {
                this.OnReceiveRealData(sender, e);
            }
        }

        internal void RaiseOnOnReceiveMsg(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e)
        {
            if (this.OnReceiveMsg != null)
            {
                this.OnReceiveMsg(sender, e);
            }
        }

        internal void RaiseOnOnReceiveChejanData(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
        {
            if (this.OnReceiveChejanData != null)
            {
                this.OnReceiveChejanData(sender, e);
            }
        }

        internal void RaiseOnOnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (this.OnEventConnect != null)
            {
                this.OnEventConnect(sender, e);
            }
        }

        internal void RaiseOnOnReceiveInvestRealData(object sender, _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent e)
        {
            if (this.OnReceiveInvestRealData != null)
            {
                this.OnReceiveInvestRealData(sender, e);
            }
        }

        internal void RaiseOnOnReceiveRealCondition(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
        {
            if (this.OnReceiveRealCondition != null)
            {
                this.OnReceiveRealCondition(sender, e);
            }
        }

        internal void RaiseOnOnReceiveTrCondition(object sender, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
        {
            if (this.OnReceiveTrCondition != null)
            {
                this.OnReceiveTrCondition(sender, e);
            }
        }

        internal void RaiseOnOnReceiveConditionVer(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
        {
            if (this.OnReceiveConditionVer != null)
            {
                this.OnReceiveConditionVer(sender, e);
            }
        }

        public virtual int CommConnect()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommConnect", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommConnect();
        }

        public virtual void CommTerminate()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommTerminate", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.CommTerminate();
        }

        public virtual int CommRqData(string sRQName, string sTrCode, int nPrevNext, string sScreenNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommRqData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommRqData(sRQName, sTrCode, nPrevNext, sScreenNo);
        }

        public virtual string GetLoginInfo(string sTag)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetLoginInfo", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetLoginInfo(sTag);
        }

        public virtual int SendOrder(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sOrgOrderNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendOrder", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sOrgOrderNo);
        }

        public virtual int SendOrderFO(string sRQName, string sScreenNo, string sAccNo, string sCode, int lOrdKind, string sSlbyTp, string sOrdTp, int lQty, string sPrice, string sOrgOrdNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendOrderFO", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendOrderFO(sRQName, sScreenNo, sAccNo, sCode, lOrdKind, sSlbyTp, sOrdTp, lQty, sPrice, sOrgOrdNo);
        }

        public virtual void SetInputValue(string sID, string sValue)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetInputValue", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SetInputValue(sID, sValue);
        }

        public virtual int SetOutputFID(string sID)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetOutputFID", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SetOutputFID(sID);
        }

        public virtual string CommGetData(string sJongmokCode, string sRealType, string sFieldName, int nIndex, string sInnerFieldName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommGetData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommGetData(sJongmokCode, sRealType, sFieldName, nIndex, sInnerFieldName);
        }

        public virtual void DisconnectRealData(string sScnNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DisconnectRealData", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.DisconnectRealData(sScnNo);
        }

        public virtual int GetRepeatCnt(string sTrCode, string sRecordName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetRepeatCnt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetRepeatCnt(sTrCode, sRecordName);
        }

        public virtual int CommKwRqData(string sArrCode, int bNext, int nCodeCount, int nTypeFlag, string sRQName, string sScreenNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommKwRqData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommKwRqData(sArrCode, bNext, nCodeCount, nTypeFlag, sRQName, sScreenNo);
        }

        public virtual string GetAPIModulePath()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetAPIModulePath", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetAPIModulePath();
        }

        public virtual string GetCodeListByMarket(string sMarket)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCodeListByMarket", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCodeListByMarket(sMarket);
        }

        public virtual int GetConnectState()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetConnectState", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetConnectState();
        }

        public virtual string GetMasterCodeName(string sTrCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetMasterCodeName", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetMasterCodeName(sTrCode);
        }

        public virtual int GetMasterListedStockCnt(string sTrCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetMasterListedStockCnt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetMasterListedStockCnt(sTrCode);
        }

        public virtual string GetMasterConstruction(string sTrCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetMasterConstruction", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetMasterConstruction(sTrCode);
        }

        public virtual string GetMasterListedStockDate(string sTrCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetMasterListedStockDate", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetMasterListedStockDate(sTrCode);
        }

        public virtual string GetMasterLastPrice(string sTrCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetMasterLastPrice", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetMasterLastPrice(sTrCode);
        }

        public virtual string GetMasterStockState(string sTrCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetMasterStockState", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetMasterStockState(sTrCode);
        }

        public virtual int GetDataCount(string strRecordName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetDataCount", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetDataCount(strRecordName);
        }

        public virtual string GetOutputValue(string strRecordName, int nRepeatIdx, int nItemIdx)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetOutputValue", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetOutputValue(strRecordName, nRepeatIdx, nItemIdx);
        }

        public virtual string GetCommData(string strTrCode, string strRecordName, int nIndex, string strItemName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommData(strTrCode, strRecordName, nIndex, strItemName);
        }

        public virtual string GetCommRealData(string sTrCode, int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommRealData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommRealData(sTrCode, nFid);
        }

        public virtual string GetChejanData(int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetChejanData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetChejanData(nFid);
        }

        public virtual string GetThemeGroupList(int nType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetThemeGroupList", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetThemeGroupList(nType);
        }

        public virtual string GetThemeGroupCode(string strThemeCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetThemeGroupCode", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetThemeGroupCode(strThemeCode);
        }

        public virtual string GetFutureList()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetFutureList", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetFutureList();
        }

        public virtual string GetFutureCodeByIndex(int nIndex)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetFutureCodeByIndex", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetFutureCodeByIndex(nIndex);
        }

        public virtual string GetActPriceList()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetActPriceList", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetActPriceList();
        }

        public virtual string GetMonthList()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetMonthList", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetMonthList();
        }

        public virtual string GetOptionCode(string strActPrice, int nCp, string strMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetOptionCode", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetOptionCode(strActPrice, nCp, strMonth);
        }

        public virtual string GetOptionCodeByMonth(string sTrCode, int nCp, string strMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetOptionCodeByMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetOptionCodeByMonth(sTrCode, nCp, strMonth);
        }

        public virtual string GetOptionCodeByActPrice(string sTrCode, int nCp, int nTick)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetOptionCodeByActPrice", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetOptionCodeByActPrice(sTrCode, nCp, nTick);
        }

        public virtual string GetSFutureList(string strBaseAssetCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetSFutureList", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetSFutureList(strBaseAssetCode);
        }

        public virtual string GetSFutureCodeByIndex(string strBaseAssetCode, int nIndex)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetSFutureCodeByIndex", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetSFutureCodeByIndex(strBaseAssetCode, nIndex);
        }

        public virtual string GetSActPriceList(string strBaseAssetGb)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetSActPriceList", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetSActPriceList(strBaseAssetGb);
        }

        public virtual string GetSMonthList(string strBaseAssetGb)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetSMonthList", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetSMonthList(strBaseAssetGb);
        }

        public virtual string GetSOptionCode(string strBaseAssetGb, string strActPrice, int nCp, string strMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetSOptionCode", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetSOptionCode(strBaseAssetGb, strActPrice, nCp, strMonth);
        }

        public virtual string GetSOptionCodeByMonth(string strBaseAssetGb, string sTrCode, int nCp, string strMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetSOptionCodeByMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetSOptionCodeByMonth(strBaseAssetGb, sTrCode, nCp, strMonth);
        }

        public virtual string GetSOptionCodeByActPrice(string strBaseAssetGb, string sTrCode, int nCp, int nTick)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetSOptionCodeByActPrice", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetSOptionCodeByActPrice(strBaseAssetGb, sTrCode, nCp, nTick);
        }

        public virtual string GetSFOBasisAssetList()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetSFOBasisAssetList", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetSFOBasisAssetList();
        }

        public virtual string GetOptionATM()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetOptionATM", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetOptionATM();
        }

        public virtual string GetSOptionATM(string strBaseAssetGb)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetSOptionATM", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetSOptionATM(strBaseAssetGb);
        }

        public virtual string GetBranchCodeName()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetBranchCodeName", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetBranchCodeName();
        }

        public virtual int CommInvestRqData(string sMarketGb, string sRQName, string sScreenNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommInvestRqData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommInvestRqData(sMarketGb, sRQName, sScreenNo);
        }

        public virtual int SendOrderCredit(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sCreditGb, string sLoanDate, string sOrgOrderNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendOrderCredit", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendOrderCredit(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sCreditGb, sLoanDate, sOrgOrderNo);
        }

        public virtual string KOA_Functions(string sFunctionName, string sParam)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("KOA_Functions", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.KOA_Functions(sFunctionName, sParam);
        }

        public virtual int SetInfoData(string sInfoData)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetInfoData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SetInfoData(sInfoData);
        }

        public virtual int SetRealReg(string strScreenNo, string strCodeList, string strFidList, string strOptType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetRealReg", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SetRealReg(strScreenNo, strCodeList, strFidList, strOptType);
        }

        public virtual int GetConditionLoad()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetConditionLoad", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetConditionLoad();
        }

        public virtual string GetConditionNameList()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetConditionNameList", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetConditionNameList();
        }

        public virtual int SendCondition(string strScrNo, string strConditionName, int nIndex, int nSearch)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendCondition", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendCondition(strScrNo, strConditionName, nIndex, nSearch);
        }

        public virtual void SendConditionStop(string strScrNo, string strConditionName, int nIndex)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendConditionStop", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SendConditionStop(strScrNo, strConditionName, nIndex);
        }

        public virtual object GetCommDataEx(string strTrCode, string strRecordName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommDataEx", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommDataEx(strTrCode, strRecordName);
        }

        public virtual void SetRealRemove(string strScrNo, string strDelCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetRealRemove", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SetRealRemove(strScrNo, strDelCode);
        }

        public virtual int GetMarketType(string sTrCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetMarketType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetMarketType(sTrCode);
        }

        public enum ActiveXInvokeKind
        {
            MethodInvoke,
            PropertyGet,
            PropertySet
        }
        public class InvalidActiveXStateException : Exception
        {
            private readonly string name;
            private readonly ActiveXInvokeKind kind;

            public InvalidActiveXStateException(string name, ActiveXInvokeKind kind)
            {
                this.name = name;
                this.kind = kind;
            }

            public override string ToString()
            {
                switch (kind)
                {
                    case ActiveXInvokeKind.MethodInvoke:
                        return string.Format("AXInvalidMethodInvoke {0}", name);
                    case ActiveXInvokeKind.PropertyGet:
                        return string.Format("AXInvalidPropertyGet {0}", name);
                    case ActiveXInvokeKind.PropertySet:
                        return string.Format("AXInvalidPropertySet {0}", name);
                    default:
                        return base.ToString();
                }
            }
        }
    }
}
