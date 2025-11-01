namespace KHOpenApi.NET;

/// <summary>
/// 예약 이벤트. 실시간 등록을 통해 등록한 실시간 데이터를 수신하면 발생합니다.
/// </summary>
/// <param name="sRealKey"></param>
public class _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent(string sRealKey) : EventArgs
{
    /// <summary>실시간타입</summary>
    public string sRealKey = sRealKey;
}
