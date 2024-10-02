using KHOpenApi.NET;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // ocx인터페이스 추가
        private AxKHOpenAPI axKHOpenAPI; // 국내 (영웅문)
        private AxKFOpenAPI axKFOpenAPI; // 해외 (영웅문 글로벌)

        public Form1()
        {
            InitializeComponent();

            Text = "WinForm " + (Environment.Is64BitProcess ? "(64비트)" : "(32비트)");

            // ActiveX 세팅
            axKHOpenAPI = new AxKHOpenAPI(Handle);
            button_login_KH.Enabled = axKHOpenAPI.Created;

            axKFOpenAPI = new AxKFOpenAPI(Handle);
            button_login_KF.Enabled = axKFOpenAPI.Created;
        }

        private async void button_login_KH_Click(object sender, EventArgs e)
        {
            // 국내 로그인 요청
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                log_list.Items.Add("국내 로그인 요청중...");
                var (ret, msg) = await axKHOpenAPI.CommConnectAsync();
                if (ret == 0)
                {
                    log_list.Items.Add("국내 로그인 성공");
                }
                else
                {
                    log_list.Items.Add("국내 로그인 실패: " + msg);
                }
            }
        }

        private async void button_login_KF_Click(object sender, EventArgs e)
        {
            // 해외 로그인 요청
            if (axKFOpenAPI.GetConnectState() == 0)
            {
                log_list.Items.Add("해외 로그인 요청중...");
                var (ret, msg) = await axKFOpenAPI.CommConnectAsync(1);
                if (ret == 0)
                {
                    log_list.Items.Add("해외 로그인 성공");
                }
                else
                {
                    log_list.Items.Add("해외 로그인 실패: " + msg);
                }
            }
        }

        private async void button_KH_info_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                log_list.Items.Add("로그인을 먼저 해주세요.");
                return;
            }

            // 국내 종목정보 요청
            var response = await axKHOpenAPI.RequestTrAsync("OPT10001"
                , [("종목코드", textBox_KH_code.Text)]
                , ["종목코드", "종목명", "시가", "고가", "저가", "현재가"]
                , []);
            if (response.nErrCode != 0)
            {
                log_list.Items.Add($"종목정보요청 실패: {response.rsp_msg}");
            }

            for (int i = 0; i < response.OutputSingleDatas.Length; i++)
            {
                log_list.Items.Add($"{response.InSingleFields[i]}: {response.OutputSingleDatas[i]}");
            }
        }

        private async void button_KH_chart_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                log_list.Items.Add("로그인을 먼저 해주세요.");
                return;
            }
            log_list.Items.Clear();

            // 국내 차트 요청
            string[] reqName =
                [
                "일자",
                "시가",
                "고가",
                "저가",
                "현재가",
                "거래량",
                // ...
                ];

            Dictionary<string, string> indatas = new()
            {
                { "종목코드", textBox_KH_code.Text },
                { "기준일자", string.Empty },
                { "수정주가구분", "1" },
            };

            var resposeTrData = await axKHOpenAPI.RequestTrAsync("OPT10081", indatas, [], reqName);
            if (resposeTrData.nErrCode != 0)
            {
                log_list.Items.Add($"종목차트요청 실패: {resposeTrData.rsp_msg}");
                return;
            }

            log_list.Items.Add($"[{resposeTrData.tr_cd}] : {resposeTrData.OutputMultiDatas.Count}개");
            resposeTrData.OutputMultiDatas.Select(x => string.Join(" ", x)).ToList().ForEach(x => log_list.Items.Add(x));


            /* 같은 요청을 CommRqDataAsync 이용할 경우
            string result = string.Empty;
            List<string> listChart = [];
            axKHOpenAPI.SetInputValue("종목코드", textBox_KH_code.Text);
            var (nRet, sMsg) = await axKHOpenAPI.CommRqDataAsync("종목차트요청", "OPT10081", 0, "0101", (e)=>
            {
                // 종목코드
                string 종목코드 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim();
                // 데이터 개수
                int nRepeatCnt = axKHOpenAPI.GetRepeatCnt(e.sTrCode, e.sRQName);
                result = $"[{e.sTrCode}], {e.sRQName} : {종목코드} - {nRepeatCnt}";

                for (int i = 0; i < nRepeatCnt; i++)
                {
                    string line = $"{i:d3} : ";
                    for (int j = 0; j < reqName.Length; j++)
                    {
                        line += axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, reqName[j]).Trim() + " ";
                    }
                    listChart.Add(line);
                }
            });

            if (nRet == 0)
            {
                listBox_result.Items.Add(result);

                foreach (var line in listChart)
                {
                    listBox_result.Items.Add(line);
                }
            }
            else
            {
                listBox_result.Items.Add($"종목차트요청 실패: {sMsg}");
            }

             */
        }
    }
}
