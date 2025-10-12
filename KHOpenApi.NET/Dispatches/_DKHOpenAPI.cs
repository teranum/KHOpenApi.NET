using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace KHOpenApi.NET;

[ComImport]
[Guid("CF20FBB6-EDD4-4BE5-A473-FEF91977DEB6")]
[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
internal interface _DKHOpenAPI
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
