# KHOpenApi.NET
- 32비트/64비트 공용, 키움증권 OpenApi C# wrapper class
- netstandard2.0 지원
- 개발환경: Visual Studio 2022
- WinUI3, WPF, Winforms 지원
- NUGET https://www.nuget.org/packages/KHOpenApi.NET
- 64비트사용시, 추가적인 설치 필요 https://github.com/terapark/64bit-kiwoom-openapi
---------------
## 1. WinUI3 (target platforms: x86, UnPackaged)
*WinuUI3 x86모드에서 글로벌OpenApi는 오류발생, x64모드에서는 오류없음
#### MainWindow.xaml.cs

```c#
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
            axKFOpenAPI = new AxKFOpenAPI(Handle);
            axKFOpenAPI.OnEventConnect += new _DKFOpenAPIEvents_OnEventConnectEventHandler(this.axKFOpenAPI_OnEventConnect);
            button_login_KF.IsEnabled = axKFOpenAPI.Created;
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

```

---------------
## 2. WPF (NET6.0), WPF_NET48
#### MainWindow.xaml.cs

```c#
    public partial class MainWindow : Window
    {
        // ocx인터페이스 추가
        private AxKHOpenAPI axKHOpenAPI; // 국내 (영웅문)
        private AxKFOpenAPI axKFOpenAPI; // 해외 (영웅문 글로벌)

        public MainWindow()
        {
            InitializeComponent();
            // ActiveX 세팅
            System.IntPtr Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

            axKHOpenAPI = new AxKHOpenAPI(Handle);
            axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(this.axKHOpenAPI_OnEventConnect);
            button_login_KH.IsEnabled = axKHOpenAPI.Created;

            axKFOpenAPI = new AxKFOpenAPI(Handle);
            axKFOpenAPI.OnEventConnect += new _DKFOpenAPIEvents_OnEventConnectEventHandler(this.axKFOpenAPI_OnEventConnect);
            button_login_KF.IsEnabled = axKFOpenAPI.Created;
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

```

---------------
## 3. WinForms (NET6.0), WinForm_NET48
#### Form1.cs

```c#
    public partial class Form1 : Form
    {
        // ocx인터페이스 추가
        private AxKHOpenAPI axKHOpenAPI; // 국내 (영웅문)
        private AxKFOpenAPI axKFOpenAPI; // 해외 (영웅문 글로벌)

        public Form1()
        {
            InitializeComponent();

            // ActiveX 세팅
            axKHOpenAPI = new AxKHOpenAPI(Handle);
            axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(this.axKHOpenAPI_OnEventConnect);
            button_login_KH.Enabled = axKHOpenAPI.Created;

            axKFOpenAPI = new AxKFOpenAPI(Handle);
            axKFOpenAPI.OnEventConnect += new _DKFOpenAPIEvents_OnEventConnectEventHandler(this.axKFOpenAPI_OnEventConnect);
            button_login_KF.Enabled = axKFOpenAPI.Created;
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

        private void button_login_KH_Click(object sender, EventArgs e)
        {
            // 국내 로그인 요청
            axKHOpenAPI.CommConnect();
        }

        private void button_login_KF_Click(object sender, EventArgs e)
        {
            // 해외 로그인 요청
            axKFOpenAPI.CommConnect(1);
        }
    }

```

