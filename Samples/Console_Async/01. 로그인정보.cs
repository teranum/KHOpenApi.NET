namespace CSharp;

// 로그인 기능은 SampleBase Main 함수에서 구현됨
internal class _01 : SampleBase
{
    public override Task ActionImplement()
    {
        print("로그인 기능은 SampleBase Main 함수에서 구현됨");

        // API 경로
        print($"API 경로: {api.GetAPIModulePath()}");

        // 사용자정보
        print($"USER_ID: {api.GetLoginInfo("USER_ID")}");
        print($"USER_NAME: {api.GetLoginInfo("USER_NAME")}");
        print(api.GetLoginInfo("ACCTLIST_DETAIL").Split(';', StringSplitOptions.RemoveEmptyEntries));
        return Task.CompletedTask;
    }
}

// Output
/*
연결성공, 접속서버: 실투자
로그인 기능은 SampleBase Main 함수에서 구현됨
API 경로: C:\OpenAPI
USER_ID: XXXXXXXX
USER_NAME: XXX
array, Data Count = 7
| Key | Value                      |
|-----|----------------------------|
|   1 | XXXXXXXXXX,XXX,위탁종합 |
|   2 | XXXXXXXXXX,XXX,위탁연계 |
|   3 | XXXXXXXXXX,XXX,선물옵션 |
*/
