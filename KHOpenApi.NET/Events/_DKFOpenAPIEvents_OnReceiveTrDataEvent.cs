namespace KHOpenApi.NET;

/// <summary>
/// 요청했던 조회데이터를 수신했을때 발생됩니다.
/// </summary>
/// <remarks>수신된 데이터는 이 이벤트내부에서 <see cref="AxKFOpenAPI.GetCommData"/>함수를 이용해서 얻어올 수 있습니다.</remarks>
public class _DKFOpenAPIEvents_OnReceiveTrDataEvent(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPrevNext, string sMessage) : EventArgs
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
    public string sPrevNext = sPrevNext;
    /// <summary>사용안함</summary>
    public string sMessage = sMessage;
}
