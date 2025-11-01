namespace KHOpenApi.NET;

/// <summary>
/// 로그인 처리 이벤트입니다. 성공이면 인자값 nErrCode가 0이며 에러는 다음과 같은 값이 전달됩니다.
/// <para>nErrCode별 상세내용</para>
/// -100 사용자 정보교환 실패<br/>
/// -101 서버접속 실패<br/>
/// -102 버전처리 실패
/// </summary>
public class _DKFOpenAPIEvents_OnEventConnectEvent(int nErrCode) : EventArgs
{
    /// <summary>로그인 상태를 전달하는데 자세한 내용은 아래 상세내용 참고</summary>
    public int nErrCode = nErrCode;
}
