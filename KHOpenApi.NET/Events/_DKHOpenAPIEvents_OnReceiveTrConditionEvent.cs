namespace KHOpenApi.NET;

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
