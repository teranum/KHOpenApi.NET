using KFOpenApi.NET;
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
            axKHOpenAPI.OnEventConnect += axKHOpenAPI_OnEventConnect;
            button_login_KH.Enabled = axKHOpenAPI.Created;

            axKFOpenAPI = new AxKFOpenAPI(Handle);
            axKFOpenAPI.OnEventConnect += axKFOpenAPI_OnEventConnect;
            button_login_KF.Enabled = axKFOpenAPI.Created;
        }

        // 국내로그인 이벤트 핸들러
        private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                listBox_result.Items.Add("국내 로그인 성공");
            }
            else
            {
                listBox_result.Items.Add("국내 로그인 실패");
            }
        }

        // 해외로그인 이벤트 핸들러
        private void axKFOpenAPI_OnEventConnect(object sender, _DKFOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                listBox_result.Items.Add("해외 로그인 성공");
            }
            else
            {
                listBox_result.Items.Add("해외 로그인 실패");
            }
        }

        private void button_login_KH_Click(object sender, EventArgs e)
        {
            // 국내 로그인 요청
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                listBox_result.Items.Add("국내 로그인 요청");
                axKHOpenAPI.CommConnect();
            }
        }

        private void button_login_KF_Click(object sender, EventArgs e)
        {
            // 해외 로그인 요청
            if (axKFOpenAPI.GetConnectState() == 0)
            {
                listBox_result.Items.Add("해외 로그인 요청");
                axKFOpenAPI.CommConnect(1);
            }
        }

        private void button_KH_info_Click(object sender, EventArgs e)
        {
            _ = 국내_종목정보_요청Async();
        }

        private void button_KH_chart_Click(object sender, EventArgs e)
        {
            _ = 국내_일봉차트_요청Async();
        }

        async Task 국내_종목정보_요청Async()
        {
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                listBox_result.Items.Add("로그인을 먼저 해주세요.");
                return;
            }

            // 국내 종목정보 요청
            string[] reqName =
                [
                "종목코드",
                "종목명",
                "시가",
                "고가",
                "저가",
                "현재가",
                // ...
                ];

            string result = string.Empty;
            axKHOpenAPI.SetInputValue("종목코드", textBox_KH_code.Text);
            int nRet = await axKHOpenAPI.CommRqDataAsync("종목정보요청", "OPT10001", 0, "0101", (e) => 
            {
                result = $"[{e.sTrCode}], {e.sRQName} : ";
                for (int i = 0; i < reqName.Length; i++)
                {
                    result += axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, reqName[i]).Trim() + " ";
                }
            }).ConfigureAwait(true);

            if (nRet == 0)
            {
                listBox_result.Items.Add(result);
            } else
            {
                listBox_result.Items.Add("종목정보요청 실패");
            }
        }

        async Task 국내_일봉차트_요청Async()
        {
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                listBox_result.Items.Add("로그인을 먼저 해주세요.");
                return;
            }

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

            string result = string.Empty;
            List<string> listChart = [];
            axKHOpenAPI.SetInputValue("종목코드", textBox_KH_code.Text);
            int nRet = await axKHOpenAPI.CommRqDataAsync("종목차트요청", "OPT10081", 0, "0101", (e)=>
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
            }).ConfigureAwait(true);

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
                listBox_result.Items.Add("종목차트요청 실패");
            }
        }
    }
}
