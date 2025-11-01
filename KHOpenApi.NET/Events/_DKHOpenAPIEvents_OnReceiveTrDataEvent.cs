namespace KHOpenApi.NET;

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
    /// <summary>사용안함</summary>
    public string sErrorCode = sErrorCode;
    /// <summary>사용안함</summary>
    public string sMessage = sMessage;
    /// <summary>사용안함</summary>
    public string sSplmMsg = sSplmMsg;
}
