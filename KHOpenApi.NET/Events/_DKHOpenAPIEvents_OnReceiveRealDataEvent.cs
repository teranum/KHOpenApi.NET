namespace KHOpenApi.NET;

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
