using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

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

/// <summary>요청했던 조회데이터를 수신했을때 발생됩니다. 수신된 데이터는 이 이벤트내부에서 <see cref="AxKHOpenAPI.GetCommData"/> 함수를 이용해서 얻어올 수 있습니다.</summary>
public class _DKHOpenAPIEvents_OnReceiveTrDataEvent(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPrevNext, int nDataLength, string sErrorCode, string sMessage, string sSplmMsg) : EventArgs
{
    /// <summary>화면번호</summary>
    public string sScrNo = sScrNo;
    /// <summary>사용자 구분명</summary>
    public string sRQName = sRQName;
    /// <summary>TR이름</summary>
    public string sTrCode = sTrCode;
    /// <summary>레코드 이름</summary>
    public string sRecordName = sRecordName;
    /// <summary>연속조회 유무를 판단하는 값 0: 연속(추가조회)데이터 없음, 2:연속(추가조회) 데이터 있음</summary>
    public string sPrevNext = sPrevNext;
    /// <summary>사용안함</summary>
    public int nDataLength = nDataLength;
    /// <summary>사용안함, 단 비동기 요청시 응답 코드</summary>
    public string sErrorCode = sErrorCode;
    /// <summary>사용안함, 단 비동기 요청시 응답 메시지</summary>
    public string sMessage = sMessage;
    /// <summary>사용안함</summary>
    public string sSplmMsg = sSplmMsg;
}

/// <summary>
/// 실시간데이터를 수신했을때 발생됩니다.
/// <see cref="AxKHOpenAPI.SetRealReg"/>함수로 등록한 실시간 데이터도 이 이벤트로 전달됩니다.
/// <see cref="AxKHOpenAPI.GetCommRealData"/>함수를 이용해서 수신된 데이터를 얻을수 있습니다.
/// </summary>
public class _DKHOpenAPIEvents_OnReceiveRealDataEvent(string sRealKey, string sRealType, string sRealData) : EventArgs
{
    /// <summary>종목코드</summary>
    public string sRealKey = sRealKey;
    /// <summary>실시간타입</summary>
    public string sRealType = sRealType;
    /// <summary>실시간 데이터 전문 (사용불가)</summary>
    public string sRealData = sRealData;
}

/// <summary>
/// 데이터 요청 또는 주문전송 후에 서버가 보낸 메시지를 수신합니다.<br/><br/>
/// 예) "조회가 완료되었습니다"<br/>
/// 예) "계좌번호 입력을 확인해주세요"<br/>
/// 예) "조회할 자료가 없습니다."<br/>
/// 예) "증거금 부족으로 주문이 거부되었습니다."
/// </summary>
/// <remarks>※ 메시지에 포함된 6자리 코드번호는 변경될 수 있으니, 여기에 수신된 코드번호를 특정 용도로 사용하지 마시기 바랍니다.</remarks>
public class _DKHOpenAPIEvents_OnReceiveMsgEvent(string sScrNo, string sRQName, string sTrCode, string sMsg) : EventArgs
{
    /// <summary>화면번호</summary>
    public string sScrNo = sScrNo;
    /// <summary>사용자 구분명</summary>
    public string sRQName = sRQName;
    /// <summary>TR이름</summary>
    public string sTrCode = sTrCode;
    /// <summary>서버에서 전달하는 메시지</summary>
    public string sMsg = sMsg;
}

/// <summary>
/// 주문전송 후 주문접수, 체결통보, 잔고통보를 수신할 때 마다 발생됩니다.<br/> <see cref="AxKHOpenAPI.GetChejanData"/>함수를 이용해서 FID항목별 값을 얻을수 있습니다.
/// </summary>
public class _DKHOpenAPIEvents_OnReceiveChejanDataEvent(string sGubun, int nItemCnt, string sFIdList) : EventArgs
{
    /// <summary>체결구분. 접수와 체결시 '0'값, 국내주식 잔고변경은 '1'값, 파생잔고변경은 '4'</summary>
    public string sGubun = sGubun;
    /// <summary>FIDs Count</summary>
    public int nItemCnt = nItemCnt;
    /// <summary>FIDs Array</summary>
    public string sFIdList = sFIdList;
}

/// <summary>
/// 로그인 처리 이벤트입니다. 성공이면 인자값 nErrCode가 0이며 에러는 다음과 같은 값이 전달됩니다.
/// </summary>
/// <param name="nErrCode">로그인 상태를 전달하는데 자세한 내용은 아래 상세내용 참고</param>
/// <remarks>
/// -100 사용자 정보교환 실패<br/>
/// -101 서버접속 실패<br/>
/// -102 버전처리 실패
/// </remarks>
public class _DKHOpenAPIEvents_OnEventConnectEvent(int nErrCode) : EventArgs
{
    /// <summary>로그인 상태: 성공이면 0이며 에러는 다음과 같은 값이 전달됩니다.</summary>
    /// <remarks>
    /// -100 사용자 정보교환 실패<br/>
    /// -101 서버접속 실패<br/>
    /// -102 버전처리 실패
    /// </remarks>
    public int nErrCode = nErrCode;
}

/// <summary>
/// 예약 이벤트. 실시간 등록을 통해 등록한 실시간 데이터를 수신하면 발생합니다.
/// </summary>
/// <param name="sRealKey"></param>
public class _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent(string sRealKey) : EventArgs
{
    /// <summary>실시간타입</summary>
    public string sRealKey = sRealKey;
}

/// <summary>
/// 실시간 조건검색 요청으로 신규종목이 편입되거나 기존 종목이 이탈될때 마다 발생됩니다.<br/> ※ 편입되었다가 순간적으로 다시 이탈되는 종목에대한 신호는 조건검색 서버마다 차이가 발생할 수 있습니다. 
/// </summary>
/// <param name="sTrCode">종목코드</param>
/// <param name="strType">이벤트 종류, "I":종목편입, "D", 종목이탈</param>
/// <param name="strConditionName">조건식 이름</param>
/// <param name="strConditionIndex">조건식 고유번호</param>
public class _DKHOpenAPIEvents_OnReceiveRealConditionEvent(string sTrCode, string strType, string strConditionName, string strConditionIndex) : EventArgs
{
    /// <summary>종목코드</summary>
    public string sTrCode = sTrCode;
    /// <summary>이벤트 종류, "I":종목편입, "D", 종목이탈</summary>
    public string strType = strType;
    /// <summary>조건식 이름</summary>
    public string strConditionName = strConditionName;
    /// <summary>조건식 고유번호</summary>
    public string strConditionIndex = strConditionIndex;
}

/// <summary>
/// 조건검색 요청에대한 서버 응답 수신시 발생하는 이벤트입니다. <br/>
/// 종목코드 리스트는 각 종목코드가 ';'로 구분되서 전달됩니다.
/// </summary>
/// <param name="sScrNo"></param>
/// <param name="strCodeList"></param>
/// <param name="strConditionName"></param>
/// <param name="nIndex"></param>
/// <param name="nNext"></param>
public class _DKHOpenAPIEvents_OnReceiveTrConditionEvent(string sScrNo, string strCodeList, string strConditionName, int nIndex, int nNext) : EventArgs
{
    /// <summary>화면번호</summary>
    public string sScrNo = sScrNo;
    /// <summary>종목코드 리스트, 각 종목코드가 ';'로 구분되서 전달됩니다.</summary>
    public string strCodeList = strCodeList;
    /// <summary>조건식 이름</summary>
    public string strConditionName = strConditionName;
    /// <summary>조건식 고유번호</summary>
    public int nIndex = nIndex;
    /// <summary>연속조회 유무를 판단하는 값 0: 연속(추가조회)데이터 없음, 2:연속(추가조회) 데이터 있음</summary>
    public int nNext = nNext;
}

/// <summary>
/// 저장된 사용자 조건식 불러오기 요청에 대한 응답 수신시 발생되는 이벤트입니다.
/// </summary>
/// <param name="lRet">호출 성공여부, 1: 성공, 나머지 실패</param>
/// <param name="sMsg">호출결과 메시지</param>
public class _DKHOpenAPIEvents_OnReceiveConditionVerEvent(int lRet, string sMsg) : EventArgs
{
    /// <summary>호출 성공여부, 1: 성공, 나머지 실패</summary>
    public int lRet = lRet;
    /// <summary>호출결과 메시지</summary>
    public string sMsg = sMsg;
}

/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveTrDataEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveTrDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveRealDataEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveRealDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveMsgEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveMsgEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveChejanDataEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveChejanDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnEventConnectEvent"/>
public delegate void _DKHOpenAPIEvents_OnEventConnectEventHandler(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveInvestRealDataEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveInvestRealDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveRealConditionEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveRealConditionEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveTrConditionEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveTrConditionEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveConditionVerEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveConditionVerEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e);


[ClassInterface(ClassInterfaceType.None)]
internal class AxKHOpenAPIEventMulticaster(AxKHOpenAPI parent) : _DKHOpenAPIEvents
{
    private readonly AxKHOpenAPI parent = parent;

    public virtual void OnReceiveTrData(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPrevNext, int nDataLength, string sErrorCode, string sMessage, string sSplmMsg) => parent.RaiseOnOnReceiveTrData(parent, new(sScrNo, sRQName, sTrCode, sRecordName, sPrevNext, nDataLength, sErrorCode, sMessage, sSplmMsg));

    public virtual void OnReceiveRealData(string sRealKey, string sRealType, string sRealData) => parent.RaiseOnOnReceiveRealData(parent, new(sRealKey, sRealType, sRealData));

    public virtual void OnReceiveMsg(string sScrNo, string sRQName, string sTrCode, string sMsg) => parent.RaiseOnOnReceiveMsg(parent, new(sScrNo, sRQName, sTrCode, sMsg));

    public virtual void OnReceiveChejanData(string sGubun, int nItemCnt, string sFIdList) => parent.RaiseOnOnReceiveChejanData(parent, new(sGubun, nItemCnt, sFIdList));

    public virtual void OnEventConnect(int nErrCode) => parent.RaiseOnOnEventConnect(parent, new(nErrCode));

    public virtual void OnReceiveInvestRealData(string sRealKey) => parent.RaiseOnOnReceiveInvestRealData(parent, new(sRealKey));

    public virtual void OnReceiveRealCondition(string sTrCode, string strType, string strConditionName, string strConditionIndex) => parent.RaiseOnOnReceiveRealCondition(parent, new(sTrCode, strType, strConditionName, strConditionIndex));

    public virtual void OnReceiveTrCondition(string sScrNo, string strCodeList, string strConditionName, int nIndex, int nNext) => parent.RaiseOnOnReceiveTrCondition(parent, new(sScrNo, strCodeList, strConditionName, nIndex, nNext));

    public virtual void OnReceiveConditionVer(int lRet, string sMsg) => parent.RaiseOnOnReceiveConditionVer(parent, new(lRet, sMsg));
}

/// <summary>
/// OpenAPI 클래스
/// </summary>
public class AxKHOpenAPI
{
    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveTrDataEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveTrDataEventHandler OnReceiveTrData;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveRealDataEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveRealDataEventHandler OnReceiveRealData;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveMsgEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveMsgEventHandler OnReceiveMsg;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveChejanDataEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveChejanDataEventHandler OnReceiveChejanData;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnEventConnectEvent"/>
    public event _DKHOpenAPIEvents_OnEventConnectEventHandler OnEventConnect;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveInvestRealDataEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveInvestRealDataEventHandler OnReceiveInvestRealData;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveRealConditionEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveRealConditionEventHandler OnReceiveRealCondition;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveTrConditionEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveTrConditionEventHandler OnReceiveTrCondition;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveConditionVerEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveConditionVerEventHandler OnReceiveConditionVer;
    internal void RaiseOnOnReceiveTrData(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
    {
        if (_async_list.Count > 0)
        {
            var scr_no = int.Parse(e.sScrNo);
            int async_ident_id = AsyncNode.GetIdentId([e.sRQName, _async_SendOrder, scr_no]);
            var async_node = _async_list.Find(x => x._ident_id == async_ident_id);
            if (async_node is null)
            {
                async_ident_id = AsyncNode.GetIdentId([e.sRQName, e.sTrCode, scr_no]);
                async_node = _async_list.Find(x => x._ident_id == async_ident_id);
            }
            if (async_node is not null)
            {
                _async_list.Remove(async_node);
                e.sMessage = async_node._async_msg;
                async_node._async_tr_action?.Invoke(e);
                async_node._async_wait.Set();
                return;
            }
        }

        OnReceiveTrData?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveRealData(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e)
    {
        OnReceiveRealData?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveMsg(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e)
    {
        if (_async_list.Count > 0)
        {
            var scr_no = int.Parse(e.sScrNo);
            int async_ident_id = AsyncNode.GetIdentId([e.sRQName, _async_SendOrder, scr_no]);
            var async_node = _async_list.Find(x => x._ident_id == async_ident_id);
            if (async_node is null)
            {
                async_ident_id = AsyncNode.GetIdentId([e.sRQName, e.sTrCode, scr_no]);
                async_node = _async_list.Find(x => x._ident_id == async_ident_id);
            }
            if (async_node is not null)
            {
                async_node._async_msg = e.sMsg;
                return;
            }
        }

        OnReceiveMsg?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveChejanData(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
    {
        OnReceiveChejanData?.Invoke(this, e);
    }

    internal void RaiseOnOnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
    {
        int async_ident_id = AsyncNode.GetIdentId(["CommConnectAsync"]);
        var async_node = _async_list.Find(x => x._ident_id == async_ident_id);
        if (async_node is not null)
        {
            _async_Connect_nErrCode = e.nErrCode;
            _async_list.Remove(async_node);
            async_node._async_wait.Set();
            return;
        }
        OnEventConnect?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveInvestRealData(object sender, _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent e)
    {
        OnReceiveInvestRealData?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveRealCondition(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
    {
        OnReceiveRealCondition?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveTrCondition(object sender, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
    {
        int async_ident_id = AsyncNode.GetIdentId([e.sScrNo, e.strConditionName]);
        var async_node = _async_list.Find(x => x._ident_id == async_ident_id);
        if (async_node is not null)
        {
            _async_list.Remove(async_node);
            async_node._async_tr_cond_action?.Invoke(e);
            async_node._async_wait.Set();
            return;
        }
        OnReceiveTrCondition?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveConditionVer(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
    {
        int async_ident_id = AsyncNode.GetIdentId(["GetConditionLoadAsync"]);
        var async_node = _async_list.Find(x => x._ident_id == async_ident_id);
        if (async_node is not null)
        {
            _async_ConditionVer_nRet = e.lRet;
            _async_list.Remove(async_node);
            async_node._async_wait.Set();
            return;
        }
        OnReceiveConditionVer?.Invoke(this, e);
    }

    /// <summary>
    /// 수동 로그인설정인 경우 로그인창을 출력.<br/> 자동로그인 설정인 경우 로그인창에서 자동으로 로그인을 시도합니다.
    /// </summary>
    /// <returns>0: 성공, other: 실패</returns>
    /// <remarks>요청이 성공하면 <see cref="OnEventConnect"/> 이벤트가 발생합니다.</remarks>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual int CommConnect()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("CommConnect", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx?.CommConnect() ?? throw new InvalidActiveXStateException("CommConnect", ActiveXInvokeKind.MethodInvoke);
    }

    /// <summary>
    /// 프로그램 종료없이 서버와의 접속만 단절시키는 함수입니다.<br/> ※ 함수 사용 후 사용자의 오해소지가 생기는 이유로 더 이상 사용할 수 없는 함수입니다.
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
    /// 조회요청 함수입니다.<br/>조회데이터는 <see cref="OnReceiveTrData"/> 이벤트로 수신됩니다.
    /// </summary>
    /// <param name="sRQName">사용자 구분명 (임의로 지정, 한글지원)</param>
    /// <param name="sTrCode">조회하려는 TR이름</param>
    /// <param name="nPrevNext">연속조회여부</param>
    /// <param name="sScreenNo">화면번호 (4자리 숫자 임의로 지정)</param>
    /// <returns>리턴값 0이면 조회요청 정상, 나머지는 에러<br/>
    /// -200 시세과부하<br/>
    /// -201 조회전문작성 에러
    /// </returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual int CommRqData(string sRQName, string sTrCode, int nPrevNext, string sScreenNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("CommRqData", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.CommRqData(sRQName, sTrCode, nPrevNext, sScreenNo);
    }

    /// <summary>
    /// 로그인 후 사용할 수 있으며 인자값에 대응하는 정보를 얻을 수 있습니다.
    /// </summary>
    /// <param name="sTag">"ACCOUNT_CNT",  "ACCLIST", "ACCNO", "USER_ID", "USER_NAME", "GetServerGubun", "KEY_BSECGB", "FIREW_SECGB"</param>
    /// <returns>인자값에 대응하는 정보를 얻을 수 있습니다.</returns>
    /// <remarks>
    /// "ACCOUNT_CNT" : 보유계좌 갯수를 반환합니다.<br/>
    /// "ACCLIST" 또는 "ACCNO" : 구분자 ';'로 연결된 보유계좌 목록을 반환합니다.<br/>
    /// "ACCTLIST_DETAIL" : 구분자 ';'로 연결된 보유계좌, 그 안에서 ','로 계좌번호, 계좌명, 계좌상품(위탁종합, 선물옵션, Fx마진, 해외선물, 금현물) 목록을 반환합니다.<br/>
    /// "USER_ID" : 사용자 ID를 반환합니다.<br/>
    /// "USER_NAME" : 사용자 이름을 반환합니다.<br/>
    /// "GetServerGubun" : 접속서버 구분을 반환합니다.(1 : 모의투자, 나머지 : 실거래 서버)<br/>
    /// "KEY_BSECGB" : 키보드 보안 해지여부를 반환합니다.(0 : 정상, 1 : 해지)<br/>
    /// "FIREW_SECGB" : 방화벽 설정여부를 반환합니다.(0 : 미설정, 1 : 설정, 2 : 해지)
    /// </remarks>
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
    /// 서버에 주문을 전송하는 함수 입니다.
    /// </summary>
    /// <param name="sRQName">사용자 구분명</param>
    /// <param name="sScreenNo">화면번호</param>
    /// <param name="sAccNo">계좌번호 10자리</param>
    /// <param name="nOrderType">주문유형 1:신규매수, 2:신규매도 3:매수취소, 4:매도취소, 5:매수정정, 6:매도정정, 7:프로그램매매 매수, 8:프로그램매매 매도</param>
    /// <param name="sCode">종목코드 (6자리)</param>
    /// <param name="nQty">주문수량</param>
    /// <param name="nPrice">주문가격</param>
    /// <param name="sHogaGb">거래구분(혹은 호가구분)은 아래 참고</param>
    /// <param name="sOrgOrderNo">원주문번호. 신규주문에는 공백 입력, 정정/취소시 입력합니다.</param>
    /// <returns>리턴값이 0이면 성공이며 나머지는 에러입니다.<br/>
    /// 1초에 5회만 주문가능하며 그 이상 주문요청하면 에러 -308을 리턴합니다.
    /// </returns>
    /// <remarks>
    /// 9개 인자값을 가진 주식주문 함수이며 리턴값이 0이면 성공이며 나머지는 에러입니다.<br/>
    /// 1초에 5회만 주문가능하며 그 이상 주문요청하면 에러 -308을 리턴합니다.<br/>
    /// ※ 시장가주문시 주문가격은 0으로 입력합니다. 주문가능수량은 해당 종목의 상한가 기준으로 계산됩니다.<br/>
    /// ※ 취소주문일때 주문가격은 0으로 입력합니다.<br/>
    /// ※ 프로그램매매 주문은 실거래 서버에서만 주문하실수 있으며 모의투자 서버에서는 지원하지 않습니다.<br/><br/>
    /// [거래구분]
    /// 00 : 지정가<br/>
    /// 03 : 시장가<br/>
    /// 05 : 조건부지정가<br/>
    /// 06 : 최유리지정가<br/>
    /// 07 : 최우선지정가<br/>
    /// 10 : 지정가IOC<br/>
    /// 13 : 시장가IOC<br/>
    /// 16 : 최유리IOC<br/>
    /// 20 : 지정가FOK<br/>
    /// 23 : 시장가FOK<br/>
    /// 26 : 최유리FOK<br/>
    /// 61 : 장전시간외종가<br/>
    /// 62 : 시간외단일가매매<br/>
    /// 81 : 장후시간외종가<br/>
    /// ※ 모의투자에서는 지정가 주문과 시장가 주문만 가능합니다.<br/><br/>
    /// [정규장 외 주문]<br/>
    /// 장전 동시호가 주문<br/>
    /// 08:30 ~ 09:00.	거래구분 00:지정가/03:시장가 (일반주문처럼)<br/>
    /// ※ 08:20 ~ 08:30 시간의 주문은 키움에서 대기하여 08:30 에 순서대로 거래소로 전송합니다.<br/>
    /// 장전시간외 종가<br/>
    /// 08:30 ~ 08:40. 	거래구분 61:장전시간외종가.  가격 0입력<br/>
    /// ※ 전일 종가로 거래. 미체결시 자동취소되지 않음<br/>
    /// 장마감 동시호가 주문<br/>
    /// 15:20 ~ 15:30.	거래구분 00:지정가/03:시장가 (일반주문처럼)<br/>
    /// 장후 시간외 종가<br/>
    /// 15:40 ~ 16:00.	거래구분 81:장후시간외종가.  가격 0입력<br/>
    /// 시간외 단일가<br/>
    /// 16:00 ~ 18:00.	거래구분 62:시간외단일가.  가격 입력<br/>
    /// ※ 10분 단위로 체결, 당일 종가대비 +-10% 가격으로 거래<br/>
    /// </remarks>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual int SendOrder(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sOrgOrderNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("SendOrder", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sOrgOrderNo);
    }

    /// <summary>
    /// 서버에 주문을 전송하는 함수 입니다, 코스피지수200 선물옵션 전용 주문함수입니다.
    /// </summary>
    /// <param name="sRQName">사용자 구분명</param>
    /// <param name="sScreenNo">화면번호</param>
    /// <param name="sAccNo">계좌번호 10자리</param>
    /// <param name="sCode">종목코드</param>
    /// <param name="lOrdKind">주문종류 1:신규매매, 2:정정, 3:취소</param>
    /// <param name="sSlbyTp">매매구분	1: 매도, 2:매수</param>
    /// <param name="sOrdTp">거래구분(혹은 호가구분)은 아래 참고</param>
    /// <param name="lQty">주문수량</param>
    /// <param name="sPrice">주문가격</param>
    /// <param name="sOrgOrdNo">원주문번호</param>
    /// <returns><inheritdoc cref="SendOrder"/></returns>
    /// <remarks>
    /// [거래구분]<br/>
    /// 1 : 지정가<br/>
    /// 2 : 조건부지정가<br/>
    /// 3 : 시장가<br/>
    /// 4 : 최유리지정가<br/>
    /// 5 : 지정가(IOC)<br/>
    /// 6 : 지정가(FOK)<br/>
    /// 7 : 시장가(IOC)<br/>
    /// 8 : 시장가(FOK)<br/>
    /// 9 : 최유리지정가(IOC)<br/>
    /// A : 최유리지정가(FOK)<br/>
    /// 장종료 후 시간외 주문은 지정가 선택
    /// </remarks>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual int SendOrderFO(string sRQName, string sScreenNo, string sAccNo, string sCode, int lOrdKind, string sSlbyTp, string sOrdTp, int lQty, string sPrice, string sOrgOrdNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("SendOrderFO", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.SendOrderFO(sRQName, sScreenNo, sAccNo, sCode, lOrdKind, sSlbyTp, sOrdTp, lQty, sPrice, sOrgOrdNo);
    }

    /// <summary>
    /// 조회요청시 TR의 Input값을 지정하는 함수입니다.
    /// </summary>
    /// <param name="sID">TR에 명시된 Input이름</param>
    /// <param name="sValue">Input이름으로 지정한 값</param>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual void SetInputValue(string sID, string sValue)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("SetInputValue", ActiveXInvokeKind.MethodInvoke);
        }

        ocx.SetInputValue(sID, sValue);
    }

    /// <summary>SetOutputFID</summary>
    public virtual int SetOutputFID(string sID)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("SetOutputFID", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.SetOutputFID(sID);
    }

    /// <summary>
    /// 일부 TR에서 사용상 제약이 있음므로 이 함수 대신 <see cref="GetCommData"/>함수를 사용하시기 바랍니다.
    /// </summary>
    /// <exception cref="InvalidActiveXStateException"></exception>
    [Obsolete("일부 TR에서 사용상 제약이 있음므로 이 함수 대신 GetCommData()함수를 사용하시기 바랍니다.")]
    public virtual string CommGetData(string sJongmokCode, string sRealType, string sFieldName, int nIndex, string sInnerFieldName)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("CommGetData", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.CommGetData(sJongmokCode, sRealType, sFieldName, nIndex, sInnerFieldName);
    }

    /// <summary>
    /// 화면 내의 모든 리얼데이터 요청을 제거한다.
    /// </summary>
    /// <param name="sScnNo">4자리의 화면번호 입력 (1 ~ 9999 : 숫자형식으로만 가능)</param>
    /// <remarks>
    /// 시세데이터를 요청할때 사용된 화면번호를 이용하여 해당 화면번호로 등록되어져 있는 종목의 실시간시세를 서버에 등록해지 요청합니다.<br/>
    /// 이후 해당 종목의 실시간시세는 수신되지 않습니다.<br/>
    /// 단, 해당 종목이 또다른 화면번호로 실시간 등록되어 있는 경우 해당종목에대한 실시간시세 데이터는 계속 수신됩니다.
    /// </remarks>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual void DisconnectRealData(string sScnNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("DisconnectRealData", ActiveXInvokeKind.MethodInvoke);
        }

        ocx.DisconnectRealData(sScnNo);
    }

    /// <summary>
    /// 수신데이타(멀티데이타) 반복횟수를 반환한다.<br/> 이 함수는 <see cref="OnReceiveTrData"/> 이벤트가 발생될때 그 안에서 사용해야 합니다.
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
    /// 한번에 100종목까지 조회할 수 있는 복수종목 조회함수 입니다.<br/> 함수인자로 사용하는 종목코드 리스트는 조회하려는 종목코드 사이에 구분자';'를 추가해서 만들면 됩니다.<br/>
    /// 수신되는 데이터는 TR목록에서 복수종목정보요청(OPTKWFID) Output을 참고하시면 됩니다.<br/>
    /// ※ OPTKWFID TR은 CommKwRqData()함수 전용으로, CommRqData 로는 사용할 수 없습니다.<br/>
    /// ※ OPTKWFID TR은 영웅문4 HTS의 관심종목과는 무관합니다.<br/>
    /// 조회 데이터는 <see cref="OnReceiveTrData"/> 이벤트로 수신됩니다.
    /// </summary>
    /// <param name="sArrCode">조회하려는 종목코드 리스트</param>
    /// <param name="bNext">연속조회 여부 0:기본값, 1:연속조회(지원안함)</param>
    /// <param name="nCodeCount">종목코드 갯수</param>
    /// <param name="nTypeFlag">0:주식 종목, 3:선물옵션 종목</param>
    /// <param name="sRQName">사용자 구분명</param>
    /// <param name="sScreenNo">화면번호</param>
    /// <returns><inheritdoc cref="CommRqData"/></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual int CommKwRqData(string sArrCode, int bNext, int nCodeCount, int nTypeFlag, string sRQName, string sScreenNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("CommKwRqData", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.CommKwRqData(sArrCode, bNext, nCodeCount, nTypeFlag, sRQName, sScreenNo);
    }

    /// <summary>
    /// ocx 모듈경로를 반환합니다.
    /// </summary>
    /// <returns>경로</returns>
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
    /// 주식 시장별 종목코드 리스트를 ';'로 구분해서 전달합니다.<br/> 시장구분값을 ""공백으로하면 전체시장 코드리스트를 전달합니다.
    /// </summary>
    /// <param name="sMarket">시장구분값</param>
    /// <returns>종목코드 리스트</returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetCodeListByMarket(string sMarket)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetCodeListByMarket", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetCodeListByMarket(sMarket);
    }

    /// <summary>
    /// 서버와 현재 접속 상태를 알려줍니다.
    /// </summary>
    /// <returns>1:연결, 0:연결안됨</returns>
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
    /// 종목코드에 해당하는 종목명을 전달합니다.
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetMasterCodeName(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetMasterCodeName", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetMasterCodeName(sTrCode);
    }

    /// <summary>
    /// 입력한 종목코드에 해당하는 종목 상장주식수를 전달합니다.
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual int GetMasterListedStockCnt(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetMasterListedStockCnt", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetMasterListedStockCnt(sTrCode);
    }

    /// <summary>
    /// 입력한 종목코드에 해당하는 종목의 감리구분을 전달합니다. (정상, 투자주의, 투자경고, 투자위험, 투자주의환기종목)
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetMasterConstruction(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetMasterConstruction", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetMasterConstruction(sTrCode);
    }

    /// <summary>
    /// 입력한 종목의 상장일을 전달합니다.
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetMasterListedStockDate(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetMasterListedStockDate", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetMasterListedStockDate(sTrCode);
    }

    /// <summary>
    /// 입력한 종목의 당일 기준가를 전달합니다.
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetMasterLastPrice(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetMasterLastPrice", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetMasterLastPrice(sTrCode);
    }

    /// <summary>
    /// 입력한 종목의 증거금 비율, 거래정지, 관리종목, 감리종목, 투자융의종목, 담보대출, 액면분할, 신용가능 여부를 전달합니다.
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetMasterStockState(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetMasterStockState", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetMasterStockState(sTrCode);
    }

    /// <summary>GetDataCount</summary>
    public virtual int GetDataCount(string strRecordName)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetDataCount", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetDataCount(strRecordName);
    }

    /// <summary>GetOutputValue</summary>
    public virtual string GetOutputValue(string strRecordName, int nRepeatIdx, int nItemIdx)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetOutputValue", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetOutputValue(strRecordName, nRepeatIdx, nItemIdx);
    }

    /// <summary>
    /// <see cref="OnReceiveTrData"/> 이벤트가 발생될때 수신한 데이터를 얻어오는 함수입니다.<br/> 이 함수는 <see cref="OnReceiveTrData"/> 이벤트가 발생될때 그 안에서 사용해야 합니다.
    /// </summary>
    /// <param name="strTrCode">TR 이름</param>
    /// <param name="strRecordName">레코드이름</param>
    /// <param name="nIndex">nIndex번째</param>
    /// <param name="strItemName">nIndex번째</param>
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
    /// 실시간시세 데이터 수신 이벤트인 <see cref="OnReceiveRealData"/> 가 발생될때 실시간데이터를 얻어오는 함수입니다.<br/> 이 함수는 <see cref="OnReceiveRealData"/> 이벤트가 발생될때 그 안에서 사용해야 합니다.
    /// </summary>
    /// <param name="sTrCode"></param>
    /// <param name="nFid"></param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetCommRealData(string sTrCode, int nFid)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetCommRealData", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetCommRealData(sTrCode, nFid);
    }

    /// <summary>
    /// <see cref="OnReceiveChejanData"/> 이벤트가 발생될때 FID에 해당되는 값을 구하는 함수입니다.<br/> 이 함수는 <see cref="OnReceiveChejanData"/> 이벤트 안에서 사용해야 합니다.
    /// </summary>
    /// <param name="nFid">실시간 타입에 포함된 FID(Field ID)</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetChejanData(int nFid)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetChejanData", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetChejanData(nFid);
    }

    /// <summary>GetThemeGroupList</summary>
    public virtual string GetThemeGroupList(int nType)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetThemeGroupList", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetThemeGroupList(nType);
    }

    /// <summary>GetThemeGroupCode</summary>
    public virtual string GetThemeGroupCode(string strThemeCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetThemeGroupCode", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetThemeGroupCode(strThemeCode);
    }

    /// <summary>
    /// 지수선물 종목코드 리스트를 ';'로 구분해서 전달합니다.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetFutureList()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetFutureList", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetFutureList();
    }

    /// <summary>GetFutureCodeByIndex</summary>
    public virtual string GetFutureCodeByIndex(int nIndex)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetFutureCodeByIndex", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetFutureCodeByIndex(nIndex);
    }

    /// <summary>
    /// 지수옵션 행사가에 100을 곱해서 소수점이 없는 값을 ';'로 구분해서 전달합니다.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetActPriceList()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetActPriceList", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetActPriceList();
    }

    /// <summary>
    /// 지수옵션 월물정보를 ';'로 구분해서 전달하는데 순서는 콜 11월물 ~ 콜 최근월물 풋 최근월물 ~ 풋 최근월물가 됩니다.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetMonthList()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetMonthList", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetMonthList();
    }

    /// <summary>
    /// 인자로 지정한 지수옵션 코드를 전달합니다
    /// </summary>
    /// <param name="strActPrice">소수점을 포함한 행사가</param>
    /// <param name="nCp">콜풋구분값, 콜:2, 풋:3</param>
    /// <param name="strMonth">6자리 월물</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetOptionCode(string strActPrice, int nCp, string strMonth)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetOptionCode", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetOptionCode(strActPrice, nCp, strMonth);
    }

    /// <summary>GetOptionCodeByMonth</summary>
    public virtual string GetOptionCodeByMonth(string sTrCode, int nCp, string strMonth)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetOptionCodeByMonth", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetOptionCodeByMonth(sTrCode, nCp, strMonth);
    }

    /// <summary>
    /// 옵션전용 함수. 인자로 지정한 지수옵션 종목의 n틱 차이에 해당되는 종목코드를 전달합니다.
    /// </summary>
    /// <param name="sTrCode">기준이 되는 종목코드</param>
    /// <param name="nCp">콜풋구분값, 콜:2, 풋:3</param>
    /// <param name="nTick">기준종목의 n틱 (0값 제외)</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetOptionCodeByActPrice(string sTrCode, int nCp, int nTick)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetOptionCodeByActPrice", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetOptionCodeByActPrice(sTrCode, nCp, nTick);
    }

    /// <summary>
    /// 기초자산 구분값을 인자로 받아서 주식선물 종목코드, 종목명, 기초자산이름을 구할수 있습니다. 입력값을 공백으로 하면 주식선물 전체 종목코드를 얻을 수 있습니다.
    /// </summary>
    /// <param name="strBaseAssetCode">기초자산 구분값</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetSFutureList(string strBaseAssetCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetSFutureList", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetSFutureList(strBaseAssetCode);
    }

    /// <summary>GetSFutureCodeByIndex</summary>
    public virtual string GetSFutureCodeByIndex(string strBaseAssetCode, int nIndex)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetSFutureCodeByIndex", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetSFutureCodeByIndex(strBaseAssetCode, nIndex);
    }

    /// <summary>GetSActPriceList</summary>
    public virtual string GetSActPriceList(string strBaseAssetGb)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetSActPriceList", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetSActPriceList(strBaseAssetGb);
    }

    /// <summary>GetSMonthList</summary>
    public virtual string GetSMonthList(string strBaseAssetGb)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetSMonthList", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetSMonthList(strBaseAssetGb);
    }

    /// <summary>GetSOptionCode</summary>
    public virtual string GetSOptionCode(string strBaseAssetGb, string strActPrice, int nCp, string strMonth)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetSOptionCode", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetSOptionCode(strBaseAssetGb, strActPrice, nCp, strMonth);
    }

    /// <summary>GetSOptionCodeByMonth</summary>
    public virtual string GetSOptionCodeByMonth(string strBaseAssetGb, string sTrCode, int nCp, string strMonth)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetSOptionCodeByMonth", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetSOptionCodeByMonth(strBaseAssetGb, sTrCode, nCp, strMonth);
    }

    /// <summary>GetSOptionCodeByActPrice</summary>
    public virtual string GetSOptionCodeByActPrice(string strBaseAssetGb, string sTrCode, int nCp, int nTick)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetSOptionCodeByActPrice", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetSOptionCodeByActPrice(strBaseAssetGb, sTrCode, nCp, nTick);
    }

    /// <summary>GetSFOBasisAssetList</summary>
    public virtual string GetSFOBasisAssetList()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetSFOBasisAssetList", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetSFOBasisAssetList();
    }

    /// <summary>
    /// 지수옵션 소수점을 제거한 ATM값을 전달합니다. 예를들어 ATM값이 247.50 인 경우 24750이 전달됩니다.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetOptionATM()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetOptionATM", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetOptionATM();
    }

    /// <summary>GetSOptionATM</summary>
    public virtual string GetSOptionATM(string strBaseAssetGb)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetSOptionATM", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetSOptionATM(strBaseAssetGb);
    }

    /// <summary>GetBranchCodeName</summary>
    public virtual string GetBranchCodeName()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetBranchCodeName", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetBranchCodeName();
    }

    /// <summary>CommInvestRqData</summary>
    public virtual int CommInvestRqData(string sMarketGb, string sRQName, string sScreenNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("CommInvestRqData", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.CommInvestRqData(sMarketGb, sRQName, sScreenNo);
    }

    /// <summary>
    /// 서버에 주문을 전송하는 함수 입니다. 국내주식 신용주문 전용함수입니다. 대주거래는 지원하지 않습니다. ※ 프로그램매매 주문은 실거래 서버에서만 주문하실수 있으며 모의투자 서버에서는 지원하지 않습니다.
    /// </summary>
    /// <param name="sRQName">사용자 구분명</param>
    /// <param name="sScreenNo">화면번호</param>
    /// <param name="sAccNo">계좌번호 10자리</param>
    /// <param name="nOrderType">주문유형 1:신규매수, 2:신규매도 3:매수취소, 4:매도취소, 5:매수정정, 6:매도정정, 7:프로그램매매 매수, 8:프로그램매매 매도</param>
    /// <param name="sCode">종목코드</param>
    /// <param name="nQty">주문수량</param>
    /// <param name="nPrice">주문가격</param>
    /// <param name="sHogaGb">거래구분(혹은 호가구분)은 아래 참고</param>
    /// <param name="sCreditGb">신용거래구분 (아래에서 참고)</param>
    /// <param name="sLoanDate">대출일 (YYYYMMDD. 아래에서 참고)</param>
    /// <param name="sOrgOrderNo">원주문번호</param>
    /// <returns><inheritdoc cref="SendOrder"/></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    /// <remarks>
    /// [거래구분]<br/>
    /// 00 : 지정가<br/>
    /// 03 : 시장가<br/>
    /// 05 : 조건부지정가<br/>
    /// 06 : 최유리지정가<br/>
    /// 07 : 최우선지정가<br/>
    /// 10 : 지정가IOC<br/>
    /// 13 : 시장가IOC<br/>
    /// 16 : 최유리IOC<br/>
    /// 20 : 지정가FOK<br/>
    /// 23 : 시장가FOK<br/>
    /// 26 : 최유리FOK<br/>
    /// 61 : 장전시간외종가<br/>
    /// 62 : 시간외단일가매매<br/>
    /// 81 : 장후시간외종가<br/>
    /// ※ 모의투자에서는 지정가 주문과 시장가 주문만 가능합니다.<br/>
    /// <br/>[신용거래]<br/>
    /// 03 : 신용매수 - 자기융자<br/>
    /// 33 : 신용매도 - 자기융자<br/>
    /// <br/>[대출일]<br/>
    /// YYYYMMDD형식 날짜를 입력합니다. (ex 대출일이 2023년 1월 1일이면 "20230101"입력)<br/>
    /// 신용매도 - 자기융자 일때는 종목별 대출일을 입력하고 신용매도 - 융자합이면 "99991231"을 입력합니다.<br/>
    /// </remarks>
    public virtual int SendOrderCredit(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sCreditGb, string sLoanDate, string sOrgOrderNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("SendOrderCredit", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.SendOrderCredit(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sCreditGb, sLoanDate, sOrgOrderNo);
    }

    /// <summary>
    /// OpenAPI기본 기능외에 기능을 사용하기 쉽도록 만든 함수입니다.
    /// </summary>
    /// <param name="sFunctionName">함수이름 혹은 기능이름</param>
    /// <param name="sParam">함수 매개변수</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string KOA_Functions(string sFunctionName, string sParam)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("KOA_Functions", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.KOA_Functions(sFunctionName, sParam);
    }

    /// <summary>SetInfoData</summary>
    public virtual int SetInfoData(string sInfoData)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("SetInfoData", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.SetInfoData(sInfoData);
    }

    /// <summary>
    /// 종목코드와 FID 리스트를 이용해서 실시간 시세를 등록하는 함수입니다.
    /// </summary>
    /// <param name="strScreenNo">화면번호</param>
    /// <param name="strCodeList">종목코드 리스트</param>
    /// <param name="strFidList">실시간 FID리스트</param>
    /// <param name="strOptType">실시간 등록 타입, 0또는 1</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual int SetRealReg(string strScreenNo, string strCodeList, string strFidList, string strOptType)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("SetRealReg", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.SetRealReg(strScreenNo, strCodeList, strFidList, strOptType);
    }

    /// <summary>
    /// 서버에 저장된 사용자 조건검색 목록을 요청합니다.
    /// </summary>
    /// <returns>조건검색 목록 요청을 성공하면 1, 아니면 0을 리턴합니다.</returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    /// <remarks>조건검색 목록을 모두 수신하면 OnReceiveConditionVer()이벤트가 발생됩니다.</remarks>
    public virtual int GetConditionLoad()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetConditionLoad", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetConditionLoad();
    }

    /// <summary>
    /// 서버에서 수신한 사용자 조건식을 조건식의 고유번호와 조건식 이름을 한 쌍으로 하는 문자열들로 전달합니다.
    /// </summary>
    /// <remarks>이 함수는 OnReceiveConditionVer()이벤트에서 사용해야 합니다.</remarks>
    /// <returns>"1^내조건식1;2^내조건식2;5^내조건식3;,,,,,,,,,,"</returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual string GetConditionNameList()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetConditionNameList", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetConditionNameList();
    }

    /// <summary>
    /// 서버에 조건검색을 요청하는 함수입니다.<br/>요청 결과는 <see cref="OnReceiveTrCondition"/> 이벤트로 수신됩니다
    /// </summary>
    /// <param name="strScrNo">화면번호</param>
    /// <param name="strConditionName">조건식 이름</param>
    /// <param name="nIndex">조건식 고유번호</param>
    /// <param name="nSearch">실시간옵션. 0:조건검색만, 1:조건검색+실시간 조건검색</param>
    /// <returns>리턴값 1이면 성공이며, 0이면 실패입니다.</returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual int SendCondition(string strScrNo, string strConditionName, int nIndex, int nSearch)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("SendCondition", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.SendCondition(strScrNo, strConditionName, nIndex, nSearch);
    }

    /// <summary>
    /// 실시간 조건검색을 중지할 때 사용하는 함수입니다.
    /// </summary>
    /// <param name="strScrNo">화면번호</param>
    /// <param name="strConditionName">조건식 이름</param>
    /// <param name="nIndex">조건식 고유번호</param>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual void SendConditionStop(string strScrNo, string strConditionName, int nIndex)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("SendConditionStop", ActiveXInvokeKind.MethodInvoke);
        }

        ocx.SendConditionStop(strScrNo, strConditionName, nIndex);
    }

    /// <summary>
    /// 조회 수신데이터 크기가 큰 차트데이터를 한번에 가져올 목적으로 만든 차트조회 전용함수입니다.
    /// </summary>
    /// <param name="strTrCode">TR 이름</param>
    /// <param name="strRecordName">레코드이름</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual object GetCommDataEx(string strTrCode, string strRecordName)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetCommDataEx", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetCommDataEx(strTrCode, strRecordName);
    }

    /// <summary>
    /// 실시간시세 해지 함수이며 화면번호와 종목코드를 이용해서 상세하게 설정할 수 있습니다.
    /// </summary>
    /// <param name="strScrNo">화면번호 또는 "ALL"</param>
    /// <param name="strDelCode">종목코드 또는 "ALL"</param>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual void SetRealRemove(string strScrNo, string strDelCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("SetRealRemove", ActiveXInvokeKind.MethodInvoke);
        }

        ocx.SetRealRemove(strScrNo, strDelCode);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    /// <exception cref="InvalidActiveXStateException"></exception>
    public virtual int GetMarketType(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException("GetMarketType", ActiveXInvokeKind.MethodInvoke);
        }

        return ocx.GetMarketType(sTrCode);
    }

    internal enum ActiveXInvokeKind
    {
        MethodInvoke,
        PropertyGet,
        PropertySet,
    }
    internal class InvalidActiveXStateException(string name, ActiveXInvokeKind kind) : Exception
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

    private readonly _DKHOpenAPI ocx;
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
    /// OCX 컨트롤이 생성되었는지 여부를 반환합니다.
    /// </summary>
    public bool Created => bInitialized;

    /// <summary>
    /// OCX 컨트롤을 생성합니다.<br/>
    /// GUI모드에서 메인 윈도우 핸들을 인자로 전달합니다.<br/>
    /// </summary>
    /// <param name="hWndParent"></param>
    public AxKHOpenAPI(nint hWndParent = 0)
    {
        if (hWndParent == IntPtr.Zero)
        {
            hWndParent = Process.GetCurrentProcess().MainWindowHandle;
            if (hWndParent == IntPtr.Zero)
            {
                // 콘솔지원 (버젼 1.5.1 추가)
                hWndParent = GetConsoleWindow();
            }
        }

        string clsid = "{a1574a0d-6bfa-4bd7-9020-ded88711818d}";

        if (AtlAxWinInit())
        {
            hWndContainer = CreateWindowEx(0, "AtlAxWin", clsid, WS_VISIBLE | WS_CHILD, -100, -100, 20, 20, hWndParent, (IntPtr)9001, IntPtr.Zero, IntPtr.Zero);
            if (hWndContainer == IntPtr.Zero && Environment.Is64BitProcess)
            {
                // old 버젼 64비트 OCX경우:
                clsid = "{0f3a0d96-1432-4d05-a1ac-220e202bb52c}";
                hWndContainer = CreateWindowEx(0, "AtlAxWin", clsid, WS_VISIBLE | WS_CHILD, -100, -100, 0, 0, hWndParent, (IntPtr)9002, IntPtr.Zero, IntPtr.Zero);
            }
            if (hWndContainer != IntPtr.Zero)
            {
                try
                {
                    AtlAxGetControl(hWndContainer, out object pUnknown);
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
                                AxKHOpenAPIEventMulticaster pEventSink = new(this);
                                _pConnectionPoint.Advise(pEventSink, out int nCookie);
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

    #region 비동기 요청 (버젼 1.5.0 추가)
    //멀티 업데이트 (버젼 1.5.1 추가)
    //로그인, 조건검색목록 비동기요청 (버젼 1.5.2 추가)
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
        public Action<_DKHOpenAPIEvents_OnReceiveTrDataEvent> _async_tr_action = null;
        public Action<_DKHOpenAPIEvents_OnReceiveTrConditionEvent> _async_tr_cond_action = null;

        // OnReceivedMessage 이벤트로 들어오는 데이터
        public string _async_msg = string.Empty;
    }

    readonly List<AsyncNode> _async_list = [];

    /// <summary>
    /// 비동기 요청을 수행합니다.<br/>
    /// action 콜백함수에서 <see cref="OnReceiveTrData"/> 이벤트를 서술해 줍니다.<br/>
    /// 서버응답없을 경우 -902(타임아웃)을 리턴합니다.
    /// <code language="csharp" >
    /// // 샘플코드: OPT10001: 주식기본정보요청
    /// string 종목명 = string.Empty;
    /// axKHOpenApi.SetInputValue("종목코드", "005930"); // 삼성전자
    /// int nRet = await axKHOpenApi.CommRqDataAsync("주식기본정보요청", "OPT10001", 0, "0001", (e) =>
    /// {
    ///     종목명 = axKHOpenApi.GetCommData(e.sTrCode, e.sRQName, 0, "종목명");
    /// });
    /// if (nRet == 0) // 요청성공
    ///     Console.WriteLine("종목명: " + 종목명);
    /// else
    ///     Console.WriteLine("요청실패: " + nRet);
    /// </code>
    /// </summary>
    /// <inheritdoc cref="CommRqData"/>
    public virtual async Task<int> CommRqDataAsync(string sRQName, string sTrCode, int nPrevNext, string sScreenNo, Action<_DKHOpenAPIEvents_OnReceiveTrDataEvent> action)
    {
        var newAsync = new AsyncNode([sRQName, sTrCode, int.Parse(sScreenNo)])
        {
            _async_tr_action = action,
        };
        _async_list.Add(newAsync);

        int nRet = CommRqData(sRQName, sTrCode, nPrevNext, sScreenNo);
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

    /// <summary>
    /// 비동기 요청을 수행합니다.<br/>
    /// action 콜백함수에서 <see cref="OnReceiveTrData"/> 이벤트를 수신처리 합니다.<br/>
    /// 서버응답없을 경우 -902(타임아웃)을 리턴합니다.
    /// <code language="csharp" >
    /// // 샘플코드: 관심종목정보요청
    /// // 삼성전자, 키움증권 현재가 요청
    /// List&lt;string> rcv_datas = [];
    /// int nRet = await axKHOpenApi.CommKwRqDataAsync("005930;039490", 0, 2, 0, "관심종목정보요청", "0001", (e) =>
    /// {
    ///     int nRepeatCnt = axKHOpenApi.GetRepeatCnt(e.sTrCode, e.sRQName);
    ///     for (int i = 0; i &lt; nRepeatCnt; i++)
    ///         rcv_datas.Add(axKHOpenApi.GetCommData(e.sTrCode, e.sRQName, i, "현재가"));
    /// });
    /// if (nRet == 0) // 요청성공
    ///     rcv_datas.ForEach((s) => Console.WriteLine("현재가: " + s));
    /// else
    ///     Console.WriteLine("요청실패: " + nRet);
    /// </code>
    /// </summary>
    /// <inheritdoc cref="CommKwRqData"/>
    public virtual async Task<int> CommKwRqDataAsync(string sArrCode, int bNext, int nCodeCount, int nTypeFlag, string sRQName, string sScreenNo, Action<_DKHOpenAPIEvents_OnReceiveTrDataEvent> action)
    {
        var newAsync = new AsyncNode([sRQName, "OPTKWFID", int.Parse(sScreenNo)])
        {
            _async_tr_action = action,
        };
        _async_list.Add(newAsync);

        int nRet = CommKwRqData(sArrCode, bNext, nCodeCount, nTypeFlag, sRQName, sScreenNo);
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

    /// <summary>
    /// 비동기 요청을 수행합니다.<br/>
    /// action 콜백함수에서 <see cref="OnReceiveTrCondition"/> 이벤트를 수신처리 합니다.<br/>
    /// 서버응답없을 경우 -902(타임아웃)을 리턴합니다.
    /// </summary>
    /// <inheritdoc cref="SendCondition"/>
    public virtual async Task<int> SendConditionAsync(string strScrNo, string strConditionName, int nIndex, int nSearch, Action<_DKHOpenAPIEvents_OnReceiveTrConditionEvent> action)
    {
        var newAsync = new AsyncNode([strScrNo, strConditionName])
        {
            _async_tr_cond_action = action,
        };
        _async_list.Add(newAsync);

        int nRet = SendCondition(strScrNo, strConditionName, nIndex, nSearch);
        if (nRet == 1)
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

    private int _async_Connect_nErrCode = 0;
    /// <summary>
    /// 비동기 요청을 수행합니다.<br/>
    /// <inheritdoc cref="CommConnect"/>
    /// </summary>
    /// <returns><inheritdoc cref="CommConnect"/><br/>-901: 이미 요청 작동중</returns>
    /// <remarks>함수 내부에서  <see cref="OnEventConnect"/> 이벤트 처리가 자동으로 진횅되며 서버연결 성공/실패 결과를 반환합니다.</remarks>
    public virtual async Task<int> CommConnectAsync()
    {
        if (_async_Connect_nErrCode == -1)
        {
            return -901; // 이미 요청 작동중
        }
        _async_Connect_nErrCode = -1;
        var newAsync = new AsyncNode(["CommConnectAsync"])
        {
        };
        _async_list.Add(newAsync);

        int nRet = CommConnect();
        if (nRet == 0)
        {
            await Task.Run(() =>
            {
                newAsync._async_wait.WaitOne();
            });
            nRet = _async_Connect_nErrCode;
        }
        _async_list.Remove(newAsync);
        _async_Connect_nErrCode = 0;
        return nRet;
    }

    private int _async_ConditionVer_nRet = 0;
    /// <summary>
    /// 비동기 조건식 불러오기 함수.<br/>
    /// <inheritdoc cref="GetConditionLoad"/>
    /// </summary>
    /// <returns><inheritdoc cref="GetConditionLoad"/><br/>-901: 이미 요청 작동중</returns>
    public virtual async Task<int> GetConditionLoadAsync()
    {
        if (_async_ConditionVer_nRet == -1)
        {
            return -901; // 이미 요청 작동중
        }
        _async_ConditionVer_nRet = -1;
        var newAsync = new AsyncNode(["GetConditionLoadAsync"])
        {
        };
        _async_list.Add(newAsync);

        int nRet = GetConditionLoad();
        if (nRet == 1)
        {
            await Task.Run(() =>
            {
                newAsync._async_wait.WaitOne();
            });
            nRet = _async_ConditionVer_nRet;
        }
        _async_list.Remove(newAsync);
        _async_ConditionVer_nRet = 0;
        return nRet;
    }


    #endregion

    #region 비동기 간편요청, 주문 (버젼 1.5.3 추가)
    class ScrNumManager
    {
        private const int _requreMinIndex = 9950;
        private const int _requreMaxIndex = 9999;

        private int _requestIndex = _requreMinIndex;
        public string GetRequestScrNum()
        {
            _requestIndex++;
            if (_requestIndex > _requreMaxIndex)
                _requestIndex = _requreMinIndex;
            return _requestIndex.ToString("D4");
        }
    }

    private readonly ScrNumManager _scrNumManager = new();

    /// <summary>
    /// 비동기 요청을 간단하게 사용하기 위한 함수입니다.<br/>
    /// 입력파라미터로 TR코드, 입력데이터, 싱글필드 리스트, 멀티필드 리스트를 전달하면 비동기로 요청하고 결과를 반환합니다.<br/>
    /// 싱글데이터, 멀티데이터는 Trim된 결과를 반환합니다.<br/>
    /// 함수 내 RQName, ScreenNumber가 자동으로(9950~9999) 생성되며 실시간 시세는 자동으로 해제됩니다.<br/>
    /// 실시간 시세 필요 할 경우, <see cref="SetRealReg"/>를 이용하며, 이때 화면번호는 9950~9999를 제외한 값으로 이용해 주세요.<br/>
    /// 결과는 <see cref="ResponseTrData"/> 로 반환합니다.<br/>
    /// </summary>
    /// <param name="tr_cd">TR코드</param>
    /// <param name="indatas">입력데이터 리스트</param>
    /// <param name="singleFields">싱글 필드리스트</param>
    /// <param name="multiFields">멀티 필드 리스트</param>
    /// <param name="cont_key">연속조회 키</param>
    /// <returns><inheritdoc cref="ResponseTrData"/></returns>
    /// <remarks>
    /// <code language="csharp">
    /// // 샘플 1: 주식기본정보요청
    /// var indatas = new Dictionary&lt;string, string&gt; 
    /// {
    ///     { "종목코드", "005930" },
    /// };
    /// var response = await RequestTrAsync("OPT10001", indatas, ["종목명", "액면가", "신용비율", "외인소진율"], []);
    /// 
    /// // 샘플 2: 주식일봉차트조회요청
    /// var indatas = new Dictionary&lt;string, string&gt; 
    /// {
    ///     { "종목코드", "005930" },
    ///     { "기준일자", "20240704" },
    ///     { "수정주가구분", "1" }
    /// };
    /// var response = await RequestTrAsync("OPT10081", indatas, ["종목코드"], ["일자", "현재가", "거래량"]);
    /// 
    /// // 샘플 3: 관심종목정보요청
    /// var indatas = new Dictionary&lt;string, string&gt; 
    /// {
    ///     { "종목코드", "005930;039490" }, // 삼성전자, 키움증권 (종목코드는 세미콜론으로 구분)
    /// };
    /// var response = await RequestTrAsync("OPTKWFID", indatas, [], ["종목명", "현재가", "기준가", "시가", "고가", "저가"]);
    /// 
    /// // 샘플 4: 관심종목정보요청(선물옵션)
    /// var indatas = new Dictionary&lt;string, string&gt; 
    /// {
    ///     { "종목코드", "101V9000;101VC000" }, // (종목코드는 세미콜론으로 구분)
    ///     { "타입구분", "3" }, // 0:주식 종목, 3:선물옵션 종목 (기본값은 0)
    /// };
    /// var response = await RequestTrAsync("OPTKWFID", indatas, [], ["종목명", "현재가", "기준가", "시가", "고가", "저가"]);
    /// 
    /// // 결과처리
    /// if (response.nErrCode == 0)
    /// {
    ///     // 요청성공, response.singleDatas, response.multiDatas 에 결과가 있음
    /// }
    /// else
    /// {
    ///     // 요청실패, response.rsp_msg 에 오류메시지가 있음
    /// }
    /// </code>
    /// </remarks>
    public virtual async Task<ResponseTrData> RequestTrAsync(string tr_cd, IEnumerable<KeyValuePair<string, string>> indatas, IEnumerable<string> singleFields, IEnumerable<string> multiFields, string cont_key = "")
    {
        var scr_num = _scrNumManager.GetRequestScrNum();
        ResponseTrData responseTrData = new();

        if (tr_cd.ToUpper().Equals("OPTKWFID")) // 관심종목정보요청
        {
            string 종목코드 = string.Empty;
            string 타입구분 = "0";
            foreach (var indata in indatas)
            {
                if (indata.Key.Equals("종목코드") || indata.Key.Equals("sArrCode"))
                {
                    종목코드 = indata.Value;
                }
                else if (indata.Key.Equals("타입구분") || indata.Key.Equals("nTypeFlag"))
                {
                    타입구분 = indata.Value;
                }
            }
            int.TryParse(타입구분, out int nTypeFlag);
            var codes = 종목코드.Split([';'], StringSplitOptions.RemoveEmptyEntries);
            var nKwanRet = await CommKwRqDataAsync(종목코드, 0, codes.Length, nTypeFlag, tr_cd, scr_num,
                (e) =>
                {
                    DisconnectRealData(e.sScrNo);
                    responseTrData.singleDatas = [];
                    responseTrData.multiDatas = [];
                    var nRepeateCnt = GetRepeatCnt(e.sTrCode, e.sRQName);
                    for (int i = 0; i < nRepeateCnt; i++)
                    {
                        var datas = multiFields.Select(x => GetCommData(e.sTrCode, e.sRQName, i, x).Trim()).ToArray();
                        responseTrData.multiDatas.Add(datas);
                    }
                    responseTrData.cont_key = string.Empty;
                    responseTrData.rsp_msg = e.sMessage;
                }
                );
            if (responseTrData.rsp_msg.Length == 0)
            {
                responseTrData.rsp_msg = GetErrorMessage(nKwanRet);
            }
            responseTrData.tr_cd = tr_cd;
            responseTrData.nErrCode = nKwanRet;
            return responseTrData;
        }

        // 일반 TR 요청

        foreach (var indata in indatas) SetInputValue(indata.Key, indata.Value);

        var out_prevNext = string.Empty;
        var out_singles = new List<string>();

        var nRet = await CommRqDataAsync(tr_cd, tr_cd, cont_key.Equals("2") ? 2 : 0, scr_num,
            (e) =>
            {
                DisconnectRealData(e.sScrNo);
                if (e.sPrevNext.Equals("2")) out_prevNext = "2";

                responseTrData.singleDatas = singleFields.Select(x => GetCommData(e.sTrCode, e.sRQName, 0, x).Trim()).ToArray();

                responseTrData.multiDatas = [];
                var nRepeateCnt = GetRepeatCnt(e.sTrCode, e.sRQName);
                for (int i = 0; i < nRepeateCnt; i++)
                {
                    var datas = multiFields.Select(x => GetCommData(e.sTrCode, e.sRQName, i, x).Trim()).ToArray();
                    responseTrData.multiDatas.Add(datas);
                }

                responseTrData.cont_key = e.sPrevNext.Equals("2") ? "2" : string.Empty;
                responseTrData.rsp_msg = e.sMessage;
            }
            );
        if (responseTrData.rsp_msg.Length == 0)
        {
            responseTrData.rsp_msg = GetErrorMessage(nRet);
        }
        responseTrData.tr_cd = tr_cd;
        responseTrData.nErrCode = nRet;
        return responseTrData;
    }


    private const string _async_SendOrder = "SendOrderAsync";
    /// <summary>
    /// 비동기로 <inheritdoc cref="SendOrder"/><br/>
    /// 결과는 <see cref="ResponseTrData"/> 로 반환합니다.<br/>
    /// <see cref="ResponseTrData.nErrCode"/> 값이 0이면 서버까지 주문이 확실히 성공, 0이 아니면 주문실패입니다.<br/>
    /// 주문실패 사유로 <see cref="ResponseTrData.rsp_msg"/> 에 오류메시지가 있습니다.<br/><br/>
    /// <code language="csharp">
    /// // 샘플: 주식주문
    /// var response = await SendOrderAsync(...);
    /// // 결과처리
    /// if (response.nErrCode == 0)
    /// {
    ///     // 주문성공 (서버까지 주문이 확실히 접수됨)
    /// }
    /// else
    /// {
    ///     // 주문실패, response.rsp_msg 에 오류메시지가 있음
    /// }
    /// </code>
    /// </summary>
    /// <inheritdoc cref="SendOrder"/>
    public virtual async Task<ResponseTrData> SendOrderAsync(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sOrgOrderNo)
    {
        bool bExistOrderNumber = false;
        void action(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            var sData = GetCommData(e.sTrCode, e.sRQName, 0, "주문번호");// sData에 주문번호가 있으면 주문성공, 공백이면 주문실패
            bExistOrderNumber = !string.IsNullOrEmpty(sData);
        }
        var newAsync = new AsyncNode([sRQName, _async_SendOrder, int.Parse(sScreenNo)])
        {
            _async_tr_action = action,
        };
        _async_list.Add(newAsync);

        int nRet = SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sOrgOrderNo);
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
            if (nRet == 0 && !bExistOrderNumber)
            {
                nRet = -903;
            }
        }
        _async_list.Remove(newAsync);
        if (newAsync._async_msg.Length == 0)
        {
            newAsync._async_msg = GetErrorMessage(nRet);
        }
        return new()
        {
            nErrCode = nRet,
            rsp_msg = newAsync._async_msg,
        };
    }

    /// <summary>
    /// 비동기로 <inheritdoc cref="SendOrderFO"/><br/>
    /// 결과는 <see cref="ResponseTrData"/> 로 반환합니다.<br/>
    /// <see cref="ResponseTrData.nErrCode"/> 값이 0이면 서버까지 주문이 확실히 성공, 0이 아니면 주문실패입니다.<br/>
    /// 주문실패 사유로 <see cref="ResponseTrData.rsp_msg"/> 에 오류메시지가 있습니다.<br/><br/>
    /// <code language="csharp">
    /// // 샘플: 선물옵션주문
    /// var response = await SendOrderFOAsync(...);
    /// // 결과처리
    /// if (response.nErrCode == 0)
    /// {
    ///     // 주문성공 (서버까지 주문이 확실히 접수됨)
    /// }
    /// else
    /// {
    ///     // 주문실패, response.rsp_msg 에 오류메시지가 있음
    /// }
    /// </code>
    /// </summary>
    /// <inheritdoc cref="SendOrderFO"/>
    public virtual async Task<ResponseTrData> SendOrderFOAsync(string sRQName, string sScreenNo, string sAccNo, string sCode, int lOrdKind, string sSlbyTp, string sOrdTp, int lQty, string sPrice, string sOrgOrdNo)
    {
        bool bExistOrderNumber = false;
        void action(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            var sData = GetCommData(e.sTrCode, e.sRQName, 0, "주문번호");// sData에 주문번호가 있으면 주문성공, 공백이면 주문실패
            bExistOrderNumber = !string.IsNullOrEmpty(sData);
        }
        var newAsync = new AsyncNode([sRQName, _async_SendOrder, int.Parse(sScreenNo)])
        {
            _async_tr_action = action,
        };
        _async_list.Add(newAsync);

        int nRet = SendOrderFO(sRQName, sScreenNo, sAccNo, sCode, lOrdKind, sSlbyTp, sOrdTp, lQty, sPrice, sOrgOrdNo);
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
            if (nRet == 0 && !bExistOrderNumber)
            {
                nRet = -903;
            }
        }
        _async_list.Remove(newAsync);
        if (newAsync._async_msg.Length == 0)
        {
            newAsync._async_msg = GetErrorMessage(nRet);
        }
        return new()
        {
            nErrCode = nRet,
            rsp_msg = newAsync._async_msg,
        };
    }

    /// <summary>
    /// 비동기로 <inheritdoc cref="SendOrderCredit"/><br/>
    /// 결과는 <see cref="ResponseTrData"/> 로 반환합니다.<br/>
    /// <see cref="ResponseTrData.nErrCode"/> 값이 0이면 서버까지 주문이 확실히 성공, 0이 아니면 주문실패입니다.<br/>
    /// 주문실패 사유로 <see cref="ResponseTrData.rsp_msg"/> 에 오류메시지가 있습니다.<br/><br/>
    /// <code language="csharp">
    /// // 샘플: 신용주문
    /// var response = await SendOrderCreditAsync(...);
    /// // 결과처리
    /// if (response.nErrCode == 0)
    /// {
    ///     // 주문성공 (서버까지 주문이 확실히 접수됨)
    /// }
    /// else
    /// {
    ///     // 주문실패, response.rsp_msg 에 오류메시지가 있음
    /// }
    /// </code>
    /// </summary>
    /// <inheritdoc cref="SendOrderCredit"/>
    public virtual async Task<ResponseTrData> SendOrderCreditAsync(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sCreditGb, string sLoanDate, string sOrgOrderNo)
    {
        bool bExistOrderNumber = false;
        void action(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            var sData = GetCommData(e.sTrCode, e.sRQName, 0, "주문번호");// sData에 주문번호가 있으면 주문성공, 공백이면 주문실패
            bExistOrderNumber = !string.IsNullOrEmpty(sData);
        }
        var newAsync = new AsyncNode([sRQName, _async_SendOrder, int.Parse(sScreenNo)])
        {
            _async_tr_action = action,
        };
        _async_list.Add(newAsync);

        int nRet = SendOrderCredit(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sCreditGb, sLoanDate, sOrgOrderNo);
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
            if (nRet == 0 && !bExistOrderNumber)
            {
                nRet = -903;
            }
        }
        _async_list.Remove(newAsync);
        if (newAsync._async_msg.Length == 0)
        {
            newAsync._async_msg = GetErrorMessage(nRet);
        }
        return new()
        {
            nErrCode = nRet,
            rsp_msg = newAsync._async_msg,
        };
    }

    #endregion

    #region 오류코드 (버젼 1.5.3 추가)
    /// <summary>
    /// Error Code에 해당하는 메시지 가져오기
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public virtual string GetErrorMessage(int code)
    {
        return code switch
        {
            1 or 0 => "정상처리",
            -10 => "실패",
            -11 => "조건번호 없음",
            -12 => "조건번호와 조건식 불일치",
            -13 => "조건검색 조회요청 초과",
            -100 => "사용자정보교환 실패",
            -101 => "서버 접속 실패",
            -102 => "버전처리 실패",
            -103 => "개인방화벽 실패",
            -104 => "메모리 보호실패",
            -105 => "함수입력값 오류",
            -106 => "통신연결 종료",
            -107 => "보안모듈 오류",
            -108 => "공인인증 로그인 필요",
            -200 => "시세조회 과부하",
            -201 => "전문작성 초기화 실패",
            -202 => "전문작성 입력값 오류",
            -203 => "데이터 없음",
            -204 => "조회가능한 종목수 초과",
            -205 => "데이터 수신 실패",
            -206 => "조회가능한 FID수 초과",
            -207 => "실시간 해제 오류",
            -209 => "시세조회제한",
            -300 => "입력값 오류",
            -301 => "계좌비밀번호 없음",
            -302 => "타인계좌 사용오류",
            -303 => "주문가격이 주문착오 금액기준 초과",
            -304 => "주문가격이 주문착오 금액기준 초과",
            -305 => "주문수량이 총발행주수의 1% 초과오류",
            -306 => "주문수량은 총발행주수의 3% 초과오류",
            -307 => "주문전송 실패",
            -308 => "주문전송 과부하",
            -309 => "주문수량 300계약 초과",
            -310 => "주문수량 500계약 초과",
            -311 => "주문전송제한 과부하",
            -340 => "계좌정보 없음",
            -500 => "종목코드 없음",
            -901 => "비동기요청: 이미 작동중 입니다",
            -902 => "비동기요청: 타임아웃",
            -903 => "비동기요청: 주문번호가 없습니다.",
            _ => "unknown",
        };
    }

    #endregion
}
