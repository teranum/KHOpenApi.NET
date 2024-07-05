using KFOpenApi.NET;
using KHOpenApi.NET;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ocx인터페이스 추가
        private AxKHOpenAPI axKHOpenAPI; // 국내 (영웅문)
        private AxKFOpenAPI axKFOpenAPI; // 해외 (영웅문 글로벌)

        public MainWindow()
        {
            InitializeComponent();

            Title = "WpfApp " + (Environment.Is64BitProcess ? "(64비트)" : "(32비트)");

            // ActiveX 세팅
            System.IntPtr Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

            axKHOpenAPI = new AxKHOpenAPI(Handle);
            axKHOpenAPI.OnEventConnect += (s, e) => log_list.Items.Add(e.nErrCode == 0 ? "국내 로그인 성공" : "국내 로그인 실패");
            button_login_KH.IsEnabled = axKHOpenAPI.Created;

            axKFOpenAPI = new AxKFOpenAPI(Handle);
            axKFOpenAPI.OnEventConnect += axKFOpenAPI_OnEventConnect;
            button_login_KF.IsEnabled = axKFOpenAPI.Created;
        }

        // 국내로그인 이벤트 핸들러
        private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                log_list.Items.Add("국내 로그인 성공");
            }
            else
            {
                log_list.Items.Add("국내 로그인 실패");
            }
        }

        // 해외로그인 이벤트 핸들러
        private void axKFOpenAPI_OnEventConnect(object sender, _DKFOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                log_list.Items.Add("해외 로그인 성공");
            }
            else
            {
                log_list.Items.Add("해외 로그인 실패");
            }
        }

        private void button_login_KH_Click(object sender, RoutedEventArgs e)
        {
            // 국내 로그인 요청
            axKHOpenAPI.CommConnect();
        }

        private void button_login_KF_Click(object sender, RoutedEventArgs e)
        {
            // 해외 로그인 요청
            axKFOpenAPI.CommConnect(1);
        }

        private void button_Async_Click(object sender, RoutedEventArgs e)
        {
            _ = TestAsync();
        }

        // 비동기 요청 테스트 (nuget 버전 1.5.0 이상 지원)
        async Task TestAsync()
        {
            // 국내 종목정보 가져오기
            string itemCode = "005930";
            axKHOpenAPI.SetInputValue("종목코드", itemCode);
            string 종목명 = string.Empty;
            int nRet = await axKHOpenAPI.CommRqDataAsync("주식기본정보요청", "OPT10001", 0, "1000", e =>
            {
                종목명 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "종목명").Trim();
            });
            // nRet: 0 성공, 음수 실패(-901: 중복요청오류, -902: 5초이상 응답없음, 그외 키움 오류코드 참조)
            if (nRet == 0)
                log_list.Items.Add(종목명);
            else
                log_list.Items.Add($"비동기 요청실패({nRet})");
        }
    }
}
