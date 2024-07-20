using System.Collections.Generic;

namespace KHOpenApi.NET;

/// <summary>요청 응답 데이터</summary>
public class ResponseTrData
{
    /// <summary>TR Code</summary>
    public string tr_cd { get; set; } = string.Empty;

    /// <summary>0: 요청성공, 0 이 아닐시 요청실패</summary>
    public int nErrCode { get; set; }

    /// <summary>응답메시지</summary>
    public string rsp_msg { get; set; } = string.Empty;

    /// <summary>연속키, 빈문자열시 연속 없음</summary>
    public string cont_key { get; set; } = string.Empty;
    /// <summary>싱글데이터</summary>
    public string[] singleDatas { get; set; } = [];
    /// <summary>멀티데이터</summary>
    public IList<string[]> multiDatas { get; set; } = [];
}
