# [![NuGet version](https://badge.fury.io/nu/KHOpenApi.NET.png)](https://badge.fury.io/nu/KHOpenApi.NET)  KHOpenApi.NET (영웅문-Hero, 영웅문-Global)
- 32비트/64비트 공용, 키움증권 OpenApi C# wrapper class
- 개발환경: Visual Studio 2022, netstandard2.0
- WinUI3, WPF, Winforms 지원
- 비동기 TR 요청 지원 (CommRqDataAsync, CommKwRqDataAsync, SendConditionAsync)
- 64비트사용시, 추가 설치 필요 https://github.com/teranum/64bit-kiwoom-openapi

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
            axKHOpenAPI.OnEventConnect += (s, e) => log_list.Items.Add(e.nErrCode == 0 ? "국내 로그인 성공" : "국내 로그인 실패");
            button_login_KH.IsEnabled = axKHOpenAPI.Created;

            axKFOpenAPI = new AxKFOpenAPI(Handle);
            axKFOpenAPI.OnEventConnect += (s, e) => log_list.Items.Add(e.nErrCode == 0 ? "해외 로그인 성공" : "해외 로그인 실패");
            button_login_KF.IsEnabled = axKFOpenAPI.Created;
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
```

---------------
#### 비동기 함수 지원

```c#
        // 로그인, 조건식 로딩 (CommConnectAsync, GetConditionLoadAsync)
        // TR 요청 (CommRqDataAsync, CommKwRqDataAsync, SendConditionAsync)
        // 간편요청 (RequestTrAsync)
        // 주문 (SendOrderAsync, SendOrderFOAsync, SendOrderFOAsync, SendOrderCreditAsync)

        // 비동기 로그인, 조건식 로딩 (nuget 버전 1.5.0 이상 지원)
        async Task TestLoginAsync()
        {
            if (0 != await axKHOpenAPI.CommConnectAsync())
            {
                OutLog("로그인 요청(CommConnect): 실패");
                return;
            }
            if (1 != await axKHOpenAPI.GetConditionLoadAsync())
            {
                OutLog("사용자 조건검색리스트요청: 실패");
                return;
            }

            var cond_list = axKHOpenAPI.GetConditionNameList().Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
            OutLog($"조건검색식 개수: {cond_list.Count}");

            // DoWork...
        }

        // 비동기 요청 (nuget 버전 1.5.0 이상 지원)
        async Task TestRequestAsync()
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

        // 비동기 간편요청 (nuget 버전 1.5.3 이상 지원)
        async Task TestSimpleRequestAsync()
        {
            // 샘플 1: 주식기본정보요청
            var response = await api.RequestTrAsync(
                "OPT10001" // TR코드
                , [("종목코드", "005930")] // 입력데이터, 또는 Dictionary<string, string> 형태로 입력
                , ["종목명", "액면가", "영업이익", "시가", "고가", "저가", "현재가", "거래량"] // 가져올 싱글데이터
                , [] // 가져올 멀티데이터
                );
            
            // 샘플 2: 주식일봉차트조회요청
            var indatas = new Dictionary<string, string> 
            {
                { "종목코드", "005930" },
                { "기준일자", "20240704" },
                { "수정주가구분", "1" }
            };
            var response = await axKHOpenAPI.RequestTrAsync("OPT10081", indatas, ["종목코드"], ["일자", "현재가", "거래량"]);
            
            // 샘플 3: 관심종목정보요청
            var response = await axKHOpenAPI.RequestTrAsync("OPTKWFID", [("종목코드", "005930")], [], ["종목명", "현재가", "기준가", "시가", "고가", "저가"]);
            
            // 샘플 4: 관심종목정보요청(선물옵션)
            var indatas = new Dictionary<string, string> 
            {
                { "종목코드", "101V9000;101VC000" }, // (종목코드는 세미콜론으로 구분)
                { "타입구분", "3" }, // 0:주식 종목, 3:선물옵션 종목 (기본값은 0)
            };
            var response = await axKHOpenAPI.RequestTrAsync("OPTKWFID", indatas, [], ["종목명", "현재가", "기준가", "시가", "고가", "저가"]);
            
            // 샘플 4: 거래대금상위요청
            var response = await api.RequestTrAsync(
                "OPT10032" // 거래대금상위요청
                , [
                    ("시장구분", "000"), // 000:전체, 001:코스피, 101:코스닥
                    ("관리종목포함", "0"), // 0:관리종목 미포함, 1:관리종목 포함
                    ]
                , [] // 가져올 싱글데이터
                , ["종목코드", "종목명", "현재순위", "전일순위", "현재가", "전일대비", "등락률", "현재거래량", "전일거래량", "거래대금"] // 가져올 멀티데이터
                );
            
            // 결과처리
            if (response.nErrCode == 0)
            {
                // 요청성공, response.OutputSingleDatas, response.OutputMultiDatas 에 결과가 있음
            }
            else
            {
                // 요청실패, response.rsp_msg 에 오류메시지가 있음
            }
        }

        // 비동기 조건검색 (nuget 버전 1.5.3 이상 지원)
        async Task TestConditionAsync()
        {
            var (nRet, sCodeList) = await api.SendConditionAsync("8001", conditionInfo.Name, conditionInfo.Code, 0);
            if (nRet != 1)
            {
                print($"검색식 요청실패: {api.GetErrorMessage(nRet)}");
                return;
            }
            // sCodeList 에 검색된 종목코드가 있음 (세미콜론으로 구분 종목코드1;종목코드2..., 또는 현재가 포함 설정시 종목코드1^현재가1;종목코드2^현재가2 ...로 구분))
        }

        // 비동기 주문 (nuget 버전 1.5.3 이상 지원)
        async Task TestOrderAsync()
        {
            // 삼성전자 주식 1주, 80000원 지정가 매수주문
            string itemCode = "005930";
            int qty = 1;
            int price = 80000;
            var (nRet, msg) = await axKHOpenAPI.SendOrderAsync("매수주문", "0101", 계좌번호, 1, itemCode, qty, price, "00", string.Empty);

            // 결과처리
            if (nRet != 0)
            {
                print($"주문 요청실패: {msg}"); // 실패사유 출력
                return;
            }

            // 주문성공, 서버까지 주문 전달이 확실히 성공 되었음
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


