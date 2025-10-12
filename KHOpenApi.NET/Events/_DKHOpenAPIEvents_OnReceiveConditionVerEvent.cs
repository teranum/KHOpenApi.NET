using System;

namespace KHOpenApi.NET;

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
