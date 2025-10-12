# 🚀 KHOpenApi.NET

<div align="center">

[![NuGet version](https://badge.fury.io/nu/KHOpenApi.NET.svg)](https://badge.fury.io/nu/KHOpenApi.NET)
[![Downloads](https://img.shields.io/nuget/dt/KHOpenApi.NET.svg)](https://www.nuget.org/packages/KHOpenApi.NET)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-Standard%202.0-blueviolet.svg)](https://dotnet.microsoft.com/download/dotnet-standard)
[![Platform](https://img.shields.io/badge/platform-Windows-lightgrey.svg)](https://www.microsoft.com/windows)

**키움증권 OpenAPI를 위한 현대적인 C# 래퍼 라이브러리**

*영웅문 국내(Hero) & 영웅문 글로벌(Global) 지원*

</div>

---

## 📋 목차

- [🌟 주요 특징](#-주요-특징)
- [🔧 지원 환경](#-지원-환경)
- [📦 설치](#-설치)
- [🚀 빠른 시작](#-빠른-시작)
  - [WPF](#wpf)
  - [WinForms](#winforms)
  - [WinUI3](#winui3)
- [💡 사용 예제](#-사용-예제)
  - [비동기 로그인](#-비동기-로그인)
  - [비동기 TR 요청](#-비동기-tr-요청)
  - [간편 TR 요청](#-간편-tr-요청)
  - [조건검색](#-조건검색)
  - [주문 처리](#-주문-처리)
- [📚 API 문서](#-api-문서)
- [📄 라이선스](#-라이선스)

---

## 🌟 주요 특징

| 기능 | 설명 |
|------|------|
| 🔄 **비동기 지원** | `async/await` 패턴으로 현대적인 비동기 프로그래밍 |
| 🌐 **멀티 플랫폼** | WPF, WinForms, WinUI3 완벽 지원 |
| 🏠 **국내/해외** | 영웅문(Hero) 및 영웅문 글로벌(Global) 지원 |
| ⚡ **고성능** | .NET Standard 2.0 기반 최적화 |
| 🛡️ **안정성** | 완전한 타입 안전성과 예외 처리 |

### ✨ 비동기 API 지원

- ✅ **로그인**: `CommConnectAsync`
- ✅ **데이터 조회**: `CommRqDataAsync`, `CommKwRqDataAsync`, `RequestTrAsync`
- ✅ **조건검색**: `GetConditionLoadAsync`, `SendConditionAsync`
- ✅ **주문처리**: `SendOrderAsync`, `SendOrderFOAsync`, `SendOrderCreditAsync`

---

## 🔧 지원 환경

### 개발 환경
- **IDE**: Visual Studio 2022
- **프레임워크**: .NET Standard 2.0
- **플랫폼**: Windows 10/11

### 지원 UI 프레임워크
| 프레임워크 | 지원 여부 | 비고 |
|------------|-----------|------|
| 🖥️ **WPF** | ✅ | 완전 지원 |
| 📋 **WinForms** | ✅ | 완전 지원 |
| 🎨 **WinUI3** | ✅ | x64 권장 (x86에서 글로벌 API 제한) |

---

## 📦 설치

### NuGet Package Manager
```bash
Install-Package KHOpenApi.NET
```

### .NET CLI
```bash
dotnet add package KHOpenApi.NET
```

### PackageReference
```xml
<PackageReference Include="KHOpenApi.NET" Version="1.6.0" />
```

---

## 🚀 빠른 시작

### WPF

```csharp
public partial class MainWindow : Window
{
    // 🔌 OCX 인터페이스 선언
    private AxKHOpenAPI axKHOpenAPI; // 🏠 국내 (영웅문)
    private AxKFOpenAPI axKFOpenAPI; // 🌏 해외 (영웅문 글로벌)

    public MainWindow()
    {
        InitializeComponent();
        
        // 🔧 ActiveX 초기화
        var handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

        axKHOpenAPI = new AxKHOpenAPI(handle);
        button_login_KH.IsEnabled = axKHOpenAPI.Created;

        axKFOpenAPI = new AxKFOpenAPI(handle);
        button_login_KF.IsEnabled = axKFOpenAPI.Created;
    }

    private async void button_login_KH_Click(object sender, RoutedEventArgs e)
    {
        // 🏠 국내 로그인 요청
        log_list.Items.Add("🔄 국내 로그인 요청중...");
        var (ret, msg) = await axKHOpenAPI.CommConnectAsync();
        
        if (ret == 0)
        {
            log_list.Items.Add("✅ 국내 로그인 성공");
        }
        else
        {
            log_list.Items.Add($"❌ 국내 로그인 실패: {msg}");
        }
    }

    private async void button_login_KF_Click(object sender, RoutedEventArgs e)
    {
        // 🌏 해외 로그인 요청
        log_list.Items.Add("🔄 해외 로그인 요청중...");
        var (ret, msg) = await axKFOpenAPI.CommConnectAsync(1);
        
        if (ret == 0)
        {
            log_list.Items.Add("✅ 해외 로그인 성공");
        }
        else
        {
            log_list.Items.Add($"❌ 해외 로그인 실패: {msg}");
        }
    }
}
```

### WinForms

```csharp
public partial class Form1 : Form
{
    // 🔌 OCX 인터페이스 선언
    private AxKHOpenAPI axKHOpenAPI; // 🏠 국내 (영웅문)
    private AxKFOpenAPI axKFOpenAPI; // 🌏 해외 (영웅문 글로벌)

    public Form1()
    {
        InitializeComponent();

        // 🔧 ActiveX 초기화
        axKHOpenAPI = new AxKHOpenAPI(Handle);
        
        // WPF 예제와 동일한 방식으로 사용
        // ...
    }
}
```

### WinUI3

> ⚠️ **주의**: WinUI3 x86 모드에서 글로벌 OpenAPI 오류 발생 가능. x64 모드 권장.

```csharp
public sealed partial class MainWindow : Window
{
    // 🔌 OCX 인터페이스 선언
    private AxKHOpenAPI axKHOpenAPI; // 🏠 국내 (영웅문)
    private AxKFOpenAPI axKFOpenAPI; // 🌏 해외 (영웅문 글로벌)

    public MainWindow()
    {
        this.InitializeComponent();
        
        // 🔧 ActiveX 초기화
        System.IntPtr handle = WinRT.Interop.WindowNative.GetWindowHandle(this);
        axKHOpenAPI = new AxKHOpenAPI(handle);
        
        // WPF 예제와 동일한 방식으로 사용
        // ...
    }
}
```

---

## 💡 사용 예제

### 🔐 비동기 로그인

```csharp
/// <summary>
/// 🔐 비동기 로그인 및 조건식 로딩
/// </summary>
async Task TestLoginAsync()
{
    // 🏠 로그인 시도
    var (nRet, sMsg) = await axKHOpenAPI.CommConnectAsync();
    if (0 != nRet)
    {
        OutLog($"❌ 로그인 실패: {sMsg}");
        return;
    }
    
    // 📋 조건검색 리스트 로딩
    (nRet, sMsg) = await axKHOpenAPI.GetConditionLoadAsync();
    if (1 != nRet)
    {
        OutLog($"❌ 사용자 조건검색리스트요청 실패: {sMsg}");
        return;
    }

    var condList = sMsg.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
    OutLog($"📊 조건검색식 개수: {condList.Count}");
    
    // 🚀 추가 작업 수행...
}
```

### 📊 비동기 TR 요청

```csharp
/// <summary>
/// 📊 종목 정보 조회 예제
/// </summary>
async Task TestRequestAsync()
{
    // 📈 삼성전자 종목정보 가져오기
    string itemCode = "005930";
    axKHOpenAPI.SetInputValue("종목코드", itemCode);
    
    string 종목명 = string.Empty;
    var (nRet, sMsg) = await axKHOpenAPI.CommRqDataAsync(
        "주식기본정보요청", 
        "OPT10001", 
        0, 
        "1000", 
        e =>
        {
            종목명 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "종목명").Trim();
        });
    
    // 📋 결과 처리
    if (nRet == 0)
        log_list.Items.Add($"✅ {종목명}");
    else
        log_list.Items.Add($"❌ 비동기 요청실패: {sMsg}");
}
```

### ⚡ 간편 TR 요청

> 🆕 **v1.5.3+** 지원 기능

```csharp
/// <summary>
/// ⚡ 간편 TR 요청 예제들
/// </summary>
async Task TestSimpleRequestAsync()
{
    // 📊 예제 1: 주식기본정보요청
    var response = await api.RequestTrAsync(
        "OPT10001", // TR코드
        [("종목코드", "005930")], // 입력데이터
        ["종목명", "액면가", "영업이익", "시가", "고가", "저가", "현재가", "거래량"], // 싱글데이터
        [] // 멀티데이터
    );
    
    // 📈 예제 2: 주식일봉차트조회요청
    var indatas = new Dictionary<string, string> 
    {
        { "종목코드", "005930" },
        { "기준일자", "20240704" },
        { "수정주가구분", "1" }
    };
    response = await axKHOpenAPI.RequestTrAsync(
        "OPT10081", 
        indatas, 
        ["종목코드"], 
        ["일자", "현재가", "거래량"]
    );
    
    // 📋 예제 3: 관심종목정보요청
    response = await axKHOpenAPI.RequestTrAsync(
        "OPTKWFID", 
        [("종목코드", "005930")], 
        [], 
        ["종목명", "현재가", "기준가", "시가", "고가", "저가"]
    );
    
    // 💰 예제 4: 거래대금상위요청
    response = await api.RequestTrAsync(
        "OPT10032", // 거래대금상위요청
        [
            ("시장구분", "000"), // 000:전체, 001:코스피, 101:코스닥
            ("관리종목포함", "0") // 0:관리종목 미포함, 1:관리종목 포함
        ],
        [], // 싱글데이터
        ["종목코드", "종목명", "현재순위", "전일순위", "현재가", "전일대비", 
         "등락률", "현재거래량", "전일거래량", "거래대금"] // 멀티데이터
    );
    
    // ✅ 결과 처리
    if (response.nErrCode == 0)
    {
        // 🎉 요청성공
        // response.OutputSingleDatas, response.OutputMultiDatas 활용
    }
    else
    {
        // ❌ 요청실패
        Console.WriteLine($"오류: {response.rsp_msg}");
    }
}
```

### 🔍 조건검색

> 🆕 **v1.5.3+** 지원 기능

```csharp
/// <summary>
/// 🔍 비동기 조건검색 예제
/// </summary>
async Task TestConditionAsync()
{
    var (nRet, sMsg) = await api.SendConditionAsync(
        "8001", 
        conditionInfo.Name, 
        conditionInfo.Code, 
        0
    );
    
    if (nRet != 1)
    {
        Console.WriteLine($"❌ 검색식 요청실패: {sMsg}");
        return;
    }
    
    // 📊 검색된 종목코드 처리
    // sMsg 형식: 종목코드1;종목코드2... 또는 종목코드1^현재가1;종목코드2^현재가2...
    Console.WriteLine($"✅ 검색 결과: {sMsg}");
}
```

### 💼 주문 처리

> 🆕 **v1.5.3+** 지원 기능

```csharp
/// <summary>
/// 💼 비동기 주문 처리 예제
/// </summary>
async Task TestOrderAsync()
{
    // 📈 삼성전자 주식 1주, 80,000원 지정가 매수주문
    string itemCode = "005930";
    int qty = 1;
    int price = 80000;
    
    var (nRet, sMsg) = await axKHOpenAPI.SendOrderAsync(
        "매수주문",    // 화면번호
        "0101",       // 주문타입
        계좌번호,      // 계좌번호
        1,            // 주문구분 (1:매수)
        itemCode,     // 종목코드
        qty,          // 주문량
        price,        // 주문가격
        "00",         // 호가구분 (00:지정가)
        string.Empty  // 원주문번호
    );

    // 📋 결과 처리
    if (nRet != 0)
    {
        Console.WriteLine($"❌ 주문 요청실패: {sMsg}");
        return;
    }

    Console.WriteLine("✅ 주문 성공! 서버까지 주문이 정상적으로 전달되었습니다.");
}
```

---

## 📚 API 문서

### 🔄 지원되는 비동기 메서드

| 카테고리 | 메서드 | 설명 | 지원 버전 |
|----------|--------|------|-----------|
| **🔐 인증** | `CommConnectAsync` | 로그인 | v1.5.0+ |
| **📋 조건** | `GetConditionLoadAsync` | 조건식 로딩 | v1.5.0+ |
| **📊 조회** | `CommRqDataAsync` | TR 요청 | v1.5.0+ |
| **📊 조회** | `CommKwRqDataAsync` | 관심종목 요청 | v1.5.0+ |
| **⚡ 간편** | `RequestTrAsync` | 간편 TR 요청 | v1.5.3+ |
| **🔍 검색** | `SendConditionAsync` | 조건검색 | v1.5.3+ |
| **💼 주문** | `SendOrderAsync` | 현물 주문 | v1.5.3+ |
| **💼 주문** | `SendOrderFOAsync` | 선물옵션 주문 | v1.5.3+ |
| **💼 주문** | `SendOrderCreditAsync` | 신용 주문 | v1.5.3+ |

---

## 📄 라이선스

이 프로젝트는 MIT 라이선스 하에 배포됩니다. 자세한 내용은 [LICENSE](LICENSE) 파일을 참조하세요.

---

<div align="center">

**⭐ 도움이 되셨다면 스타를 눌러주세요!**

Made with ❤️ by [teranum](https://github.com/teranum)

</div>


