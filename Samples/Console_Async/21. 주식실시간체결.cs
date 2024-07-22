namespace CSharp;

internal class _21 : SampleBase
{
    public override async Task ActionImplement()
    {
        // 이벤트 OnReceiveRealData 구독은 SampleBase에서 처리되었음

        // 삼성전자 실시간 시세 요청
        api.SetRealReg("1000", "005930", "10", "0");

        await GetInputAsync("실시간 시세 작동중, 중지 하려면 아무키나 누르세요");

        api.DisconnectRealData("1000");
    }
}

// Output:
/*
*/
