using System.ComponentModel;

namespace CSharp;

[Description("주식계좌 예수금조회")]
internal class _07 : SampleBase
{
    public override async Task ActionImplement()
    {
        print(api.GetLoginInfo("ACCTLIST_DETAIL").Split(';', StringSplitOptions.RemoveEmptyEntries));
        var 계좌번호 = await GetInputAsync("계좌번호를 입력하세요 (10자리 숫자):");
        var response = await api.RequestTrAsync(
            "OPW00004" // 계좌평가현황요청
            , [
                ("계좌번호", 계좌번호),
                ("비밀번호", string.Empty), // 사용안함(공백)
                ("상장폐지조회구분", "0"), // 0:전체, 1:상장폐지종목제외
                ("비밀번호입력매체구분", "00"), // 00 (공백불가)
                ]
            , ["예수금", "유가잔고평가액", "예탁자산평가액", "총매입금액", "당일투자손익"] // 가져올 싱글데이터
            , ["종목코드", "종목명", "보유수량", "평균단가", "현재가", "평가금액", "손익금액", "손익율", "평전일매수수량"]// 가져올 멀티데이터
            );
        print(response);
    }
}

// Output:
/*
tr_cd: OPW00004
입력데이터
| Key                  | Value      |
|----------------------|------------|
| 계좌번호             | XXXXXXXXXX |
| 비밀번호             |            |
| 상장폐지조회구분     | 0          |
| 비밀번호입력매체구분 | 00         |

출력데이터
nErrCode: 0
rsp_msg: [100000] 조회가 완료되었습니다.
cont_key:

싱글데이터, Field Count = 5, Row Count = 1
| 예수금       | 유가잔고평가액 | 예탁자산평가액 | 총매입금액   | 당일투자손익 |
|--------------|----------------|----------------|--------------|--------------|

멀티데이터, Field Count = 9, Row Count = 1
| 종목코드 | 종목명   | 보유수량     | 평균단가     | 현재가       | 평가금액     | 손익금액     | 손익율       | 평전일매수수량 |
|----------|----------|--------------|--------------|--------------|--------------|--------------|--------------|----------------|
...
*/
