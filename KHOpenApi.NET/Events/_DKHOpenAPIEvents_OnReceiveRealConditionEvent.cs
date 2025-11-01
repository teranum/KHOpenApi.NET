namespace KHOpenApi.NET;

/// <summary>
/// 실시간 조건검색 요청으로 신규종목이 편입되거나 기존 종목이 이탈될때 마다 발생됩니다.<br/> ※ 편입되었다가 순간적으로 다시 이탈되는 종목에대한 신호는 조건검색 서버마다 차이가 발생할 수 있습니다. 
/// </summary>
/// <param name="strCode">종목코드</param>
/// <param name="strType">이벤트 종류, "I":종목편입, "D", 종목이탈</param>
/// <param name="strConditionName">조건식 이름</param>
/// <param name="strConditionIndex">조건식 고유번호</param>
public class _DKHOpenAPIEvents_OnReceiveRealConditionEvent(string strCode, string strType, string strConditionName, string strConditionIndex) : EventArgs
{
    /// <summary>종목코드</summary>
    public string strCode = strCode;
    /// <summary>이벤트 종류, "I":종목편입, "D", 종목이탈</summary>
    public string strType = strType;
    /// <summary>조건식 이름</summary>
    public string strConditionName = strConditionName;
    /// <summary>조건식 고유번호</summary>
    public string strConditionIndex = strConditionIndex;
}
