namespace KHOpenApi.NET;

/// <summary>
/// 데이터 요청 또는 주문전송 후에 서버가 보낸 메시지를 수신합니다.<br/><br/>
/// 예) "조회가 완료되었습니다"<br/>
/// 예) "계좌번호 입력을 확인해주세요"<br/>
/// 예) "조회할 자료가 없습니다."<br/>
/// 예) "증거금 부족으로 주문이 거부되었습니다."
/// </summary>
/// <remarks>※ 메시지에 포함된 6자리 코드번호는 변경될 수 있으니, 여기에 수신된 코드번호를 특정 용도로 사용하지 마시기 바랍니다.</remarks>
public class _DKHOpenAPIEvents_OnReceiveMsgEvent(string sScrNo, string sRQName, string sTrCode, string sMsg) : EventArgs
{
    /// <summary>화면번호</summary>
    public string sScrNo = sScrNo;
    /// <summary>사용자 구분명</summary>
    public string sRQName = sRQName;
    /// <summary>TR이름</summary>
    public string sTrCode = sTrCode;
    /// <summary>서버에서 전달하는 메시지</summary>
    public string sMsg = sMsg;
}
