# KHOpenApi.NET (영웅문 / 영웅문 Global)

[![NuGet version](https://badge.fury.io/nu/KHOpenApi.NET.png)](https://badge.fury.io/nu/KHOpenApi.NET)

키움증권 OpenAPI를 C#에서 사용하기 위한 래퍼 라이브러리입니다.

## ✨ 주요 기능

- 국내(영웅문), 해외(영웅문 Global) OpenAPI 지원
- WPF, WinForms, WinUI3 지원
- 비동기 로그인/요청/조건검색/주문 API 지원
  - 로그인/조건식: `CommConnectAsync`, `GetConditionLoadAsync`
  - TR 요청: `CommRqDataAsync`, `CommKwRqDataAsync`, `RequestTrAsync`
  - 조건검색: `SendConditionAsync`
  - 주문: `SendOrderAsync`, `SendOrderFOAsync`, `SendOrderCreditAsync`

## 🧩 개발 환경

- Visual Studio 2022+
- `netstandard2.0`

## 🚀 빠른 시작

### 1) WPF

`MainWindow.xaml.cs`

```csharp
public partial class MainWindow : Window
{
    // OCX 인터페이스
    private AxKHOpenAPI axKHOpenAPI; // 국내 (영웅문)
    private AxKFOpenAPI axKFOpenAPI; // 해외 (영웅문 Global)

    public MainWindow()
    {
        InitializeComponent();

        // ActiveX 세팅
        var handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

        axKHOpenAPI = new AxKHOpenAPI(handle);
        button_login_KH.IsEnabled = axKHOpenAPI.Created;

        axKFOpenAPI = new AxKFOpenAPI(handle);
        button_login_KF.IsEnabled = axKFOpenAPI.Created;
    }

    private async void button_login_KH_Click(object sender, RoutedEventArgs e)
    {
        log_list.Items.Add("국내 로그인 요청중...");
        var (ret, msg) = await axKHOpenAPI.CommConnectAsync();
        log_list.Items.Add(ret == 0 ? "국내 로그인 성공" : $"국내 로그인 실패: {msg}");
    }

    private async void button_login_KF_Click(object sender, RoutedEventArgs e)
    {
        log_list.Items.Add("해외 로그인 요청중...");
        var (ret, msg) = await axKFOpenAPI.CommConnectAsync(1);
        log_list.Items.Add(ret == 0 ? "해외 로그인 성공" : $"해외 로그인 실패: {msg}");
    }
}
```

### 2) 비동기 API 예시

```csharp
// 로그인 + 조건식 로딩 (nuget 1.5.0+)
async Task TestLoginAsync()
{
    var (nRet, sMsg) = await axKHOpenAPI.CommConnectAsync();
    if (nRet != 0)
    {
        OutLog($"로그인 실패: {sMsg}");
        return;
    }

    (nRet, sMsg) = await axKHOpenAPI.GetConditionLoadAsync();
    if (nRet != 1)
    {
        OutLog($"사용자 조건검색리스트요청 실패: {sMsg}");
        return;
    }

    var condList = sMsg.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
    OutLog($"조건검색식 개수: {condList.Count}");
}

// TR 비동기 요청 (nuget 1.5.0+)
async Task TestRequestAsync()
{
    axKHOpenAPI.SetInputValue("종목코드", "005930");
    string itemName = string.Empty;

    var (nRet, sMsg) = await axKHOpenAPI.CommRqDataAsync("주식기본정보요청", "OPT10001", 0, "1000", e =>
    {
        itemName = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "종목명").Trim();
    });

    if (nRet == 0)
        log_list.Items.Add(itemName);
    else
        log_list.Items.Add($"비동기 요청실패: {sMsg}");
}

// 간편 TR 요청 (nuget 1.5.3+)
async Task TestSimpleRequestAsync()
{
    var response = await api.RequestTrAsync(
        "OPT10001",
        [("종목코드", "005930")],
        ["종목명", "액면가", "영업이익", "시가", "고가", "저가", "현재가", "거래량"],
        []);

    if (response.nErrCode != 0)
    {
        print($"요청실패: {response.rsp_msg}");
        return;
    }

    // response.OutputSingleDatas / OutputMultiDatas 사용
}

// 비동기 조건검색 (nuget 1.5.3+)
async Task TestConditionAsync()
{
    var (nRet, sMsg) = await api.SendConditionAsync("8001", conditionInfo.Name, conditionInfo.Code, 0);
    if (nRet != 1)
    {
        print($"검색식 요청실패: {sMsg}");
        return;
    }

    // sMsg: 종목코드1;종목코드2;...
}

// 비동기 주문 (nuget 1.5.3+)
async Task TestOrderAsync()
{
    var (nRet, sMsg) = await axKHOpenAPI.SendOrderAsync("매수주문", "0101", 계좌번호, 1, "005930", 1, 80000, "00", string.Empty);
    if (nRet != 0)
    {
        print($"주문 요청실패: {sMsg}");
        return;
    }
}
```

### 3) WinForms

`Form1.cs`

```csharp
public partial class Form1 : Form
{
    private AxKHOpenAPI axKHOpenAPI; // 국내 (영웅문)
    private AxKFOpenAPI axKFOpenAPI; // 해외 (영웅문 Global)

    public Form1()
    {
        InitializeComponent();

        // ActiveX 세팅
        axKHOpenAPI = new AxKHOpenAPI(Handle);

        // WPF 샘플과 동일한 방식으로 사용
    }
}
```

### 4) WinUI3

> target platforms: x86/x64, UnPackaged  
> 참고: WinUI3 x86 모드에서 글로벌 OpenAPI는 오류가 발생할 수 있으며, x64 모드에서는 정상 동작합니다.

`MainWindow.xaml.cs`

```csharp
public sealed partial class MainWindow : Window
{
    private AxKHOpenAPI axKHOpenAPI; // 국내 (영웅문)
    private AxKFOpenAPI axKFOpenAPI; // 해외 (영웅문 Global)

    public MainWindow()
    {
        InitializeComponent();

        // ActiveX 세팅
        IntPtr handle = WinRT.Interop.WindowNative.GetWindowHandle(this);
        axKHOpenAPI = new AxKHOpenAPI(handle);

        // WPF 샘플과 동일한 방식으로 사용
    }
}


