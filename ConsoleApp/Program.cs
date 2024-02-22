using KHOpenApi.NET;

namespace ConsoleApp;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        new Sample().Run();
        NativeLoop.LoopForever(); // if need for break, press CTRL+C
    }
}

class Sample
{
    readonly AxKHOpenAPI api = new();
    private static void OutLog(string msg = "") => Console.WriteLine(msg);
    public void Run()
    {
        if (!api.Created)
        {
            OutLog("OpenApi 미설치");
            return;
        }

        // 이벤트 핸들러 추가
        api.OnEventConnect += Api_OnEventConnect;
        api.OnReceiveConditionVer += Api_OnReceiveConditionVer;
        api.OnReceiveMsg += (s, e) => OutLog($"OnReceiveMsg: {e.sRQName} {e.sTrCode} {e.sMsg}");
        api.OnReceiveRealData += (s, e) => OutLog($"OnReceiveRealData: {e.sRealKey} {e.sRealType} {e.sRealData}");
        api.OnReceiveTrData += (s, e) => OutLog($"OnReceiveTrData: {e.sRQName} {e.sTrCode} {e.sPrevNext}");

        // 로그인
        OutLog("로그인 요청...");
        if (0 != api.CommConnect())
        {
            OutLog("로그인 요청(CommConnect): 실패");
            return;
        }
    }

    private void Api_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
    {
        if (e.nErrCode != 0)
        {
            OutLog($"로그인 실패({e.nErrCode})");
            return;
        }
        OutLog("로그인 성공");

        // 사용자 정보
        OutLog();
        OutLog("사용자 정보");
        OutLog($"접속서버구분: {(api.GetLoginInfo("GetServerGubun").Equals("1") ? "모의투자" : "실투자")}");
        OutLog($"사용자 ID: {api.GetLoginInfo("USER_ID")}");
        OutLog($"사용자 이름: {api.GetLoginInfo("USER_NAME")}");
        var acc_list = api.GetLoginInfo("ACCTLIST_DETAIL").Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
        OutLog($"계좌 리스트: {acc_list.Count}개");
        acc_list.ForEach(OutLog);

        // 사용자 조건검색리스트요청
        OutLog();
        OutLog("사용자 조건검색리스트요청...");
        if (1 != api.GetConditionLoad())
        {
            OutLog("사용자 조건검색리스트요청: 실패");
            return;
        }
    }

    private void Api_OnReceiveConditionVer(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
    {
        if (1 != e.lRet)
        {
            OutLog($"사용자 조건검색리스트요청: 실패{e.lRet}");
        }
        else
        {
            var cond_list = api.GetConditionNameList().Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
            OutLog($"조건검색식 개수: {cond_list.Count}");
            cond_list.ForEach(OutLog);

            OutLog();
            DoOtherWork();
        }
    }

    private async void DoOtherWork()
    {
        OutLog("10초후 삼성전자의 일봉데이터를 불러옵니다.");
        await Task.Delay(10000); // 10초 대기

        // 삼성전자의 일봉데이터를 가져오기
        api.SetInputValue("종목코드", "005930");
        api.SetInputValue("기준일자", "");
        api.SetInputValue("수정주가구분", "1");
        int reqResult = await api.CommRqDataAsync("주식일봉차트조회요청", "opt10081", 0, "9001",
            (e) =>
            {
                api.DisconnectRealData("9001");
                int nRepeateCount = api.GetRepeatCnt(e.sTrCode, e.sRecordName);
                OutLog($"주식일봉차트조회요청: {nRepeateCount}건 [일자 시가 고가 저가 종가 거래량]");
                for (int i = 0; i < nRepeateCount; i++)
                {
                    var 일자 = api.GetCommData(e.sTrCode, e.sRecordName, i, "일자");
                    var 시가 = api.GetCommData(e.sTrCode, e.sRecordName, i, "시가");
                    var 고가 = api.GetCommData(e.sTrCode, e.sRecordName, i, "고가");
                    var 저가 = api.GetCommData(e.sTrCode, e.sRecordName, i, "저가");
                    var 종가 = api.GetCommData(e.sTrCode, e.sRecordName, i, "현재가");
                    var 거래량 = api.GetCommData(e.sTrCode, e.sRecordName, i, "거래량");
                    OutLog($"{일자}{시가}{고가}{저가}{종가}{거래량}");
                }
            });
        if (reqResult < 0)
        {
            OutLog($"주식일봉차트조회요청: 실패({reqResult})");
        }
        OutLog();

        // 작업 추가 ....

    }
}
