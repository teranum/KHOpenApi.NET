namespace KHOpenApi.NET.Internals;

/// <summary>내부 오류 코드를 정의하는 정적 클래스</summary>
internal static class InternalErrorCodes
{
    ///<summary>비동기 작업이 이미 진행 중임을 나타내는 오류 코드</summary>
    public const int ERR_ASYNC_WORKING = -901;
    ///<summary>비동기 작업이 타임아웃 되었음을 나타내는 오류 코드</summary>
    public const int ERR_ASYNC_TIMEOUT = -902;
    ///<summary>비동기 작업에 대한 주문 번호가 없음을 나타내는 오류 코드</summary>
    public const int ERR_ASYNC_NOORDER = -903;
}
