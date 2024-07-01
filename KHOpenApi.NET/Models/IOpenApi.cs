namespace KHOpenApi.NET;

/// <summary>
/// OpenAPI 인터페이스
/// </summary>
public interface IOpenApi
{
    /// <inheritdoc cref="MessageEventArgs"/>
    event EventHandler<MessageEventArgs>? OnMessageEvent;

    /// <inheritdoc cref="RealtimeEventArgs"/>
    event EventHandler<RealtimeEventArgs>? OnRealtimeEvent;

    /// <summary>모듈이 로딩 된 경우 true</summary>
    bool ModuleLoaded { get; }

    /// <summary>연결 여부</summary>
    bool IsConnected { get; }

    /// <summary>모의투자 여부</summary>
    bool IsSimulation { get; }

    /// <summary>로그인 된 유저 아이디</summary>
    string UserID { get; }

    /// <summary>
    /// 비동기 연결 요청
    /// </summary>
    /// <returns>true: 연결성공, false: 연결실패</returns>
    Task<bool> ConnectAsync();

    /// <summary>연결 해제</summary>
    bool Close();

    /// <summary>
    /// 마지막 에러 메시지
    /// </summary>
    string LastErrorMessage { get; }

    /// <summary>
    /// 실시간 시세 등록/해제 (계좌 실시간등록 시: (로그인아이디, 계좌번호) 또는 (tr_cd, 계좌번호) 형태로 등록)
    /// </summary>
    /// <param name="tr_cd">증권 거래코드</param>
    /// <param name="tr_key">단축코드 6자리 또는 8자리 (단건, 연속)</param>
    /// <param name="bAdd">시세등록: true, 시세해제: false</param>
    /// <returns>true: 요청성공, false: 요청실패</returns>
    bool RequestRealtime(string tr_cd, string tr_key, bool bAdd);

    /// <summary>
    /// 비동기 TR 요청
    /// </summary>
    /// <param name="tr_cd">증권 거래코드</param>
    /// <param name="indatas">입력 문자 데이터</param>
    /// <param name="cont_key">연속일 경우 그전에 내려온 연속키 값 올림</param>
    /// <param name="reqfids">요청 FID 리스트 (3자리 숫자연속)</param>
    /// <returns></returns>
    Task<ResponseTrData?> RequestAsync(string tr_cd, string indatas, string cont_key = "", string reqfids = "");

    /// <summary>계좌정보 리스트. (로그인 시 자동 등록 됩니다)</summary>
    IReadOnlyList<AccountInfo> AccountInfos { get; }
}
