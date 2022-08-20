using KHOpenApi.NET;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ocx인터페이스 추가
        private AxKHOpenAPI axKHOpenAPI;

        public MainWindow()
        {
            InitializeComponent();
            // ActiveX 세팅
            axKHOpenAPI = new AxKHOpenAPI();
            axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(this.axKHOpenAPI_OnEventConnect);
            axContainer.Child = axKHOpenAPI;
        }

        // 로그인 이벤트 핸들러
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

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            // 로그인 요청
            axKHOpenAPI.CommConnect();
        }
    }
}
