using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using KHOpenApi.NET;
using KFOpenApi.NET;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3_test
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        // ocx인터페이스 추가
        private AxKHOpenAPI axKHOpenAPI; // 국내 (영웅문)
        private AxKFOpenAPI axKFOpenAPI; // 해외 (영웅문 글로벌)

        public MainWindow()
        {
            this.InitializeComponent();
            // ActiveX 세팅
            System.IntPtr Handle = WinRT.Interop.WindowNative.GetWindowHandle(this);

            axKHOpenAPI = new AxKHOpenAPI(Handle);
            axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(this.axKHOpenAPI_OnEventConnect);
            button_login_KH.IsEnabled = axKHOpenAPI.Created;

            // WinUI3 x86모드에서 영웅문 글로벌 오류 발생
            //axKFOpenAPI = new AxKFOpenAPI(Handle);
            //axKFOpenAPI.OnEventConnect += new _DKFOpenAPIEvents_OnEventConnectEventHandler(this.axKFOpenAPI_OnEventConnect);
            //button_login_KF.IsEnabled = axKFOpenAPI.Created;
        }


        // 국내로그인 이벤트 핸들러
        private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                textBox1.Text = "로그인 성공";
            }
            else
            {
                textBox1.Text = "로그인 실패";
            }
        }

        // 해외로그인 이벤트 핸들러
        private void axKFOpenAPI_OnEventConnect(object sender, _DKFOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                textBox2.Text = "로그인 성공";
            }
            else
            {
                textBox2.Text = "로그인 실패";
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
    }
}
