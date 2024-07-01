# [![NuGet version](https://badge.fury.io/nu/KHOpenApi.NET.png)](https://badge.fury.io/nu/KHOpenApi.NET)  KHOpenApi.NET (영웅문-Hero, 영웅문-Global)
- 32비트/64비트 공용, 키움증권 OpenApi C# wrapper class
- 개발환경: Visual Studio 2022, net8.0-windows (버젼2.0부터 지원, 이전버젼은 netstandard2.0 지원)
- WinUI3, WPF, Winforms 지원
- 비동기 TR 요청 지원 (CommRqDataAsync, CommKwRqDataAsync, SendConditionAsync)
- 64비트사용시, 추가 설치 필요 https://github.com/teranum/64bit-kiwoom-openapi
- 버젼2.0부터 KHOpenApi, KFOpenApi 클래스 추가, 기존 AxKHOpenAPI, AxKFOpenAPI 클래스는 그대로 유지

---------------
KOAStudio WPF Full source Project : https://github.com/teranum/KOAStudio

---------------
## 1. WPF
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
            axKHOpenAPI.OnEventConnect += axKHOpenAPI_OnEventConnect;
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

```

---------------
## 2. WinForms
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

            // WPF샘플과 동일
            ...
        }
        ...
    }

```

---------------
## 3. WinUI3 (target platforms: x86/x64, UnPackaged)
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

            // WPF샘플과 동일
            ...
        }
        ...
    }

```


