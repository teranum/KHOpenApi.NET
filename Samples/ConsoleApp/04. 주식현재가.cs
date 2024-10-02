using System.ComponentModel;

namespace CSharp;

[Description("주식현재가")]
internal class _04 : SampleBase
{
    public override async Task ActionImplement()
    {
        // OPT10001: 주식기본정보요청
        var response = await api.RequestTrAsync(
            "OPT10001" // TR코드
            , [("종목코드", "005930")] // 입력데이터
            , ["종목명", "액면가", "영업이익", "시가", "고가", "저가", "현재가", "거래량"] // 가져올 싱글데이터
            , [] // 가져올 멀티데이터
            );
        print(response);
    }
}

// Output:
/*
tr_cd: OPT10001
입력데이터
| Key      | Value  |
|----------|--------|
| 종목코드 | 005930 |

출력데이터
nErrCode: 0
rsp_msg: 정상처리
cont_key:

싱글데이터, Field Count = 8, Row Count = 1
| 종목명   | 액면가 | 영업이익 | 시가   | 고가   | 저가   | 현재가 | 거래량   |
|----------|--------|----------|--------|--------|--------|--------|----------|
| 삼성전자 | 100    | 65670    | -85600 | -86100 | -84100 | -84400 | 18569122 |
*/
