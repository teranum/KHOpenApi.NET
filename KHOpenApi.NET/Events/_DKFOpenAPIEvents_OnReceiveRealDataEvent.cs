namespace KHOpenApi.NET;

/// <summary>실시간시세 데이터가 수신될때마다 종목단위로 발생됩니다.
/// <see cref="AxKFOpenAPI.GetCommRealData"/>GetCommRealData()함수를 이용해서 수신된 데이터를 얻을수 있습니다.</summary>
public class _DKFOpenAPIEvents_OnReceiveRealDataEvent(string sJongmokCode, string sRealType, string sRealData) : EventArgs
{
    /// <summary>종목코드</summary>
    public string sJongmokCode = sJongmokCode;
    /// <summary>실시간타입</summary>
    public string sRealType = sRealType;
    /// <summary>실시간 데이터 전문 (사용불가)</summary>
    public string sRealData = sRealData;
}
