using KHOpenApi.NET;

namespace ConsoleApp;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Form form = new()
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow,
            ShowInTaskbar = false,
            StartPosition = FormStartPosition.Manual,
            Location = new Point(-2000, -2000),
            Size = new Size(1, 1),
        };
        form.Shown += (s, e) => { new Sample(form.Handle).Run(); };
        Application.Run(form);
    }
}

class Sample(nint handle)
{
    readonly AxKHOpenAPI api = new(handle);
    private static void OutLog(string msg = "") => Console.WriteLine(msg);
    public async void Run()
    {
        if (!api.Created)
        {
            OutLog("OpenApi 미설치");
            return;
        }

        // 로그인
        OutLog("로그인 요청...");
        if (0 != await api.CommConnectAsync())
        {
            OutLog("로그인 요청(CommConnect): 실패");
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
        if (1 != await api.GetConditionLoadAsync())
        {
            OutLog("사용자 조건검색리스트요청: 실패");
            return;
        }

        var cond_list = api.GetConditionNameList().Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
        OutLog($"조건검색식 개수: {cond_list.Count}");
        cond_list.ForEach(OutLog);

        // 조건리스트중 처음 조건식 요청
        if (cond_list.Count > 0)
        {
            var cond_codeName = cond_list[0].Split('^');
            var cond_code = cond_codeName[0];
            var cond_name = cond_codeName[1];
            OutLog();
            OutLog($"조건검색식 요청: {cond_name}");
            List<string> list = [];
            if (1 == await api.SendConditionAsync("9876", cond_name, int.Parse(cond_code), 0,
                (e) =>
                {
                    var codes = e.strCodeList.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x=>api.GetMasterCodeName(x));
                    list.AddRange(codes);
                }))
            {
                OutLog($"조건검색식 요청: 성공, 검색종목수 = {list.Count}");
                list.ForEach(OutLog);
            }
            else
                OutLog($"조건검색식 요청: 실패");
        }

        OutLog();
        DoOtherWork();


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
