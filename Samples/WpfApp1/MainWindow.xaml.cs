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
            var Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

            axKHOpenAPI = new AxKHOpenAPI(Handle);
            button_login_KH.IsEnabled = axKHOpenAPI.Created;

            axKFOpenAPI = new AxKFOpenAPI(Handle);
            button_login_KF.IsEnabled = axKFOpenAPI.Created;
        }

        private async void button_login_KH_Click(object sender, RoutedEventArgs e)
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

        private async void button_login_KF_Click(object sender, RoutedEventArgs e)
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

        private async void button_Async_Click(object sender, RoutedEventArgs e)
        {
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                log_list.Items.Add("로그인을 먼저 해주세요.");
                return;
            }

            // 국내 종목정보 요청
            var response = await axKHOpenAPI.RequestTrAsync("OPT10001"
                , [("종목코드", "005930")]
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
    }
}
