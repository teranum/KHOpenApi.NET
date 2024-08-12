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
        OutLog("로그인 요청 (CommConnectAsync)...");
        var (nRet, sMsg) = await api.CommConnectAsync();
        if (0 != nRet)
        {
            OutLog("로그인 요청 (CommConnectAsync): 실패");
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
        OutLog("사용자 조건검색리스트요청 (GetConditionLoadAsync)...");
        (nRet, string sCondList) = await api.GetConditionLoadAsync();
        if (1 != nRet)
        {
            OutLog("사용자 조건검색리스트요청: 실패");
            return;
        }

        var cond_list = sCondList.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
        OutLog($"조건검색식 개수: {cond_list.Count}");
        cond_list.ForEach(OutLog);

        // 조건리스트중 처음 조건식 요청
        if (cond_list.Count > 0)
        {
            var cond_codeName = cond_list[0].Split('^');
            var cond_code = cond_codeName[0];
            var cond_name = cond_codeName[1];
            OutLog();
            OutLog($"조건검색식 요청 (SendConditionAsync): {cond_name}");
            List<string> list = [];
            var (nCondRet, strCodeList) = await api.SendConditionAsync("9876", cond_name, int.Parse(cond_code), 0);
            if (nCondRet == 1)
            {
                var codes = strCodeList.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => api.GetMasterCodeName(x));
                list.AddRange(codes);
                OutLog($"조건검색식 요청: 성공, 검색종목수 = {list.Count}");
                list.ForEach(OutLog);
            }
            else
                OutLog($"조건검색식 요청: 실패");
        }

        // 관심종목정보요청
        OutLog();
        OutLog("관심종목정보요청: 삼성전자, 키움증권 현재가 출력 (CommKwRqDataAsync)");
        List<string> rcv_datas = [];
        (nRet, sMsg) = await api.CommKwRqDataAsync("005930;039490", 0, 2, 0, "관심종목정보요청", "0001", (e) =>
        {
            int nRepeatCnt = api.GetRepeatCnt(e.sTrCode, e.sRQName);
            for (int i = 0; i < nRepeatCnt; i++)
                rcv_datas.Add(api.GetCommData(e.sTrCode, e.sRQName, i, "현재가"));
        });
        if (nRet == 0) // 요청성공
            rcv_datas.ForEach((s) => Console.WriteLine("현재가: " + s));
        else
            Console.WriteLine("요청실패: " + nRet);

        // 관심종목정보요청을 간편요청 (RequestTrAsync) 으로 불러오기
        OutLog();
        OutLog("관심종목정보요청: 삼성전자, 키움증권 현재가 출력 (RequestTrAsync)");
        var indatas = new Dictionary<string, string>
        {
            ["종목코드"] = "005930;039490", // 종목코드 리스트
            ["타입구분"] = "0", // 0: 주식종목, 3: 선물옵션
        };
        var respose = await api.RequestTrAsync("OPTKWFID", indatas, [], ["현재가"]);
        if (respose.nErrCode < 0)
            OutLog($"요청실패: {respose.rsp_msg}");
        else
            respose.OutputMultiDatas.ToList().ForEach((coldatas) => OutLog($"현재가: {coldatas[0]}"));

        DoOtherWork();
    }

    private async void DoOtherWork()
    {
        OutLog("10초후 삼성전자의 일봉데이터를 불러옵니다. (CommRqDataAsync)");
        await Task.Delay(10000); // 10초 대기

        // 삼성전자의 일봉데이터를 가져오기
        api.SetInputValue("종목코드", "005930");
        api.SetInputValue("기준일자", "");
        api.SetInputValue("수정주가구분", "1");
        var (nRet, sMsg) = await api.CommRqDataAsync("주식일봉차트조회요청", "opt10081", 0, "9001",
            (e) =>
            {
                api.DisconnectRealData("9001");
                int nRepeateCount = api.GetRepeatCnt(e.sTrCode, e.sRQName);
                OutLog($"주식일봉차트조회요청: {nRepeateCount}건 [일자 시가 고가 저가 종가 거래량]");
                for (int i = 0; i < nRepeateCount; i++)
                {
                    var 일자 = api.GetCommData(e.sTrCode, e.sRQName, i, "일자");
                    var 시가 = api.GetCommData(e.sTrCode, e.sRQName, i, "시가");
                    var 고가 = api.GetCommData(e.sTrCode, e.sRQName, i, "고가");
                    var 저가 = api.GetCommData(e.sTrCode, e.sRQName, i, "저가");
                    var 종가 = api.GetCommData(e.sTrCode, e.sRQName, i, "현재가");
                    var 거래량 = api.GetCommData(e.sTrCode, e.sRQName, i, "거래량");
                    OutLog($"{일자}{시가}{고가}{저가}{종가}{거래량}");
                }
            });

        if (nRet != 0)
        {
            OutLog($"주식일봉차트조회요청 (CommRqDataAsync): 실패({nRet}: {sMsg})");
            return;
        }

        await Task.Delay(1000); // 1초 대기

        OutLog("같은 데이터를 간편요청 (RequestTrAsync) 으로 불러오기");
        var indatas = new Dictionary<string, string>
        {
            ["종목코드"] = "005930",
            ["기준일자"] = "",
            ["수정주가구분"] = "1",
        };
        var respose = await api.RequestTrAsync("opt10081", indatas, [], ["일자", "시가", "고가", "저가", "현재가", "거래량"]);

        if (respose.nErrCode < 0)
        {
            OutLog($"주식일봉차트조회요청 (RequestTrAsync): 실패({respose.rsp_msg})");
            return;
        }

        foreach (var item in respose.OutputMultiDatas)
        {
            OutLog($"{item[0]}, {item[1]}, {item[2]}, {item[3]}, {item[4]}, {item[5]}");
        }
        OutLog();

        // 작업 추가 ....

    }
}
