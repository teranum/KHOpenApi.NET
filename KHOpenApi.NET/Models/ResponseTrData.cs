namespace KHOpenApi.NET;

/// <summary>요청 응답 데이터</summary>
public class ResponseTrData
{
    /// <summary>TR Code</summary>
    public required string tr_cd { get; init; }
    /// <summary>연속키, 빈문자열시 연속 없음</summary>
    public required string cont_key { get; init; }
    /// <summary>응답코드</summary>
    public required string rsp_cd { get; init; }
    /// <summary>응답메시지</summary>
    public required string rsp_msg { get; init; }
    /// <summary>Block 데이터</summary>
    public required IList<(string blockName, IList<string[]> datas)> blockDatas { get; init; }
}
