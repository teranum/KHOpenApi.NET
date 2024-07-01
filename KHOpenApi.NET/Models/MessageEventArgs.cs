namespace KHOpenApi.NET;

/// <summary>
/// 서버 메시지 이벤트
/// </summary>
/// <param name="Message">서버 메시지</param>
public class MessageEventArgs(string Message) : EventArgs
{
    /// <summary>서버 메시지</summary>
    public string Message { get; } = Message;
}
