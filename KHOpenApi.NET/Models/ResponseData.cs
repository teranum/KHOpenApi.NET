using System.Collections.Generic;

namespace KHOpenApi.NET;

/// <summary>요청 응답 데이터</summary>
public class ResponseData
{
    /// <summary>0: 요청성공, 0 이 아닐시 요청실패</summary>
    public int nErrCode { get; set; }

    /// <summary>응답메시지</summary>
    public string rsp_msg { get; set; } = string.Empty;

    /// <summary>TR 요청시, TR 코드</summary>
    public string tr_cd { get; set; } = string.Empty;
    /// <summary>TR 요청/응답시, 연속키, 빈문자열시 연속 없음</summary>
    public string cont_key { get; set; } = string.Empty;
    /// <summary>TR 요청/응답시, 출력-싱글데이터 배열</summary>
    public string[] OutputSingleDatas { get; set; } = [];
    /// <summary>TR 요청/응답시, 출력-멀티데이터 배열 리스트</summary>
    public IList<string[]> OutputMultiDatas { get; set; } = [];


    // OPTIONS

    /// <summary>TR 요청시, 입력으로 설정한 데이터 배열</summary>
    public KeyValuePair<string, string>[] InValues { get; set; } = [];

    /// <summary>TR 요청시, 가져올-싱글데이터로 설정한 데이터 배열</summary>
    public string[] InSingleFields { get; set; } = [];
    /// <summary>TR 요청시, 가져올-멀티데이터로 설정한 데이터 배열</summary>
    public string[] InMultiFields { get; set; } = [];

}
