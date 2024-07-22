namespace CSharp;

internal class _14 : SampleBase
{
    public override async Task ActionImplement()
    {
        // 주식계좌 조회
        var accounts = api.GetLoginInfo("ACCTLIST_DETAIL").Split(';', StringSplitOptions.RemoveEmptyEntries);
        var stock_account = accounts.FirstOrDefault(x => x.Contains("위탁종합"));
        if (stock_account == null)
        {
            print("주식계좌가 없습니다.");
            return;
        }
        var account = stock_account.Split(',')[0];
        print($"주식계좌: {account}");

        while (true)
        {
            // 잔고조회
            var jango_response = await api.RequestTrAsync("OPW00018",
                [
                    ("계좌번호", account), // 전문 조회할 보유계좌번호 10자리
                    ("비밀번호", string.Empty), // 사용안함(공백)
                    ("비밀번호입력매체구분", "00"), // 00 (공백불가)
                    ("조회구분", "2"), // 1:합산, 2:개별
                ]
                , []
                , ["종목번호", "종목명", "보유수량", "매입가", "현재가", "평가손익"]
            );
            print("잔고", jango_response.RequestMultiFields, jango_response.OutputMultiDatas.ToArray());

            // 미체결조회
            var miche_response = await api.RequestTrAsync("OPT10075",
                [
                    ("계좌번호", account), // 전문 조회할 보유계좌번호 10자리
                    ("전체종목구분", "0"), // 0:전체, 1:종목
                    ("매매구분", "0"), // 0:전체, 1:매도, 2:매수
                    ("종목코드", string.Empty), // 전문 조회할 종목코드 (공백허용, 공백입력시 전체종목구분 "0" 입력하여 전체 종목 대상으로 조회)
                    ("체결구분", "1"), // 0:전체, 2:체결, 1:미체결
                ]
                , []
                , ["주문번호", "주문구분", "종목코드", "종목명", "주문수량", "주문가격", "미체결수량"]
            );
            print("미체결", miche_response.RequestMultiFields, miche_response.OutputMultiDatas.ToArray());

            // 주문요청 입력
            var 주문요청 = await GetInputAsync("주문을 입력하세요 (1:매수, 2:매도, 3:정정, 4:취소):");
            if (주문요청.Equals("1") || 주문요청.Equals("2")) // 신규매수/신규매도
            {
                var 종목코드 = await GetInputAsync("종목코드를 입력하세요(6자리 숫자):");
                var 주문수량 = await GetInputAsync("주문수량을 입력하세요(숫자):");
                var 주문가격 = await GetInputAsync("주문가격을 입력하세요(숫자):");

                _ = int.TryParse(주문수량, out var nOrderQty);
                _ = int.TryParse(주문가격, out var nPrice);

                if (nOrderQty == 0 || nPrice == 0)
                {
                    print("잘못된 입력입니다.");
                    return;
                }

                bool b매수 = 주문요청.Equals("1");
                var (nRet, sMsg) = await api.SendOrderAsync("신규주문", "2001", account, b매수 ? 1 : 2, 종목코드, nOrderQty, nPrice, "00", string.Empty);

                print($"({nRet}, {sMsg})");

            }
            else if (주문요청.Equals("3") || 주문요청.Equals("4")) // 정정/취소
            {
                var 주문번호 = await GetInputAsync("주문번호를 입력하세요:");
                var matched_miche = miche_response.OutputMultiDatas.FirstOrDefault(x => x[0].Equals(주문번호));
                if (matched_miche == null)
                {
                    print("주문번호에 해당 되는 미체결내역을 찾을수 없습니다.");
                    return;
                }

                var 원주문번호 = matched_miche[0];
                bool b매수 = matched_miche[1][0] == '+';
                var 종목코드 = matched_miche[2];
                var 미체결수량 = matched_miche[6];
                _ = int.TryParse(미체결수량, out var nOrderQty);

                if (주문요청.Equals("3"))
                {
                    // 정정
                    var 정정가격 = await GetInputAsync("정정가격을 입력하세요(숫자):");
                    _ = int.TryParse(정정가격, out var nPrice);

                    if (nPrice == 0)
                    {
                        print("잘못된 입력입니다.");
                        return;
                    }

                    var (nRet, sMsg) = await api.SendOrderAsync("정정주문", "2002", account, b매수 ? 5 : 6, 종목코드, nOrderQty, nPrice, "00", 원주문번호);

                    print($"({nRet}, {sMsg})");
                }
                else
                {
                    // 취소
                    var (nRet, sMsg) = await api.SendOrderAsync("취소주문", "2003", account, b매수 ? 3 : 4, 종목코드, nOrderQty, 0, "00", 원주문번호);

                    print($"({nRet}, {sMsg})");
                }
            }
            else
            {
                print("잘못된 입력입니다.");
                return;
            }
        }
    }
}

// Output:
/*
주문을 입력하세요 (1:매수, 2:매도, 3:정정, 4:취소):1
종목코드를 입력하세요(6자리 숫자):005930
주문수량을 입력하세요(숫자):1
주문가격을 입력하세요(숫자):70000
(0, [107066] 매수주문이 완료되었습니다.)
잔고, Field Count = 6, Row Count = 0
| 종목번호 | 종목명   | 보유수량        | 매입가          | 현재가       | 평가손익        |
|----------|----------|-----------------|-----------------|--------------|-----------------|

미체결, Field Count = 7, Row Count = 1
| 주문번호 | 주문구분 | 종목코드 | 종목명   | 주문수량 | 주문가격 | 미체결수량 |
|----------|----------|----------|----------|----------|----------|------------|
| 0080904  | +매수    | 005930   | 삼성전자 | 1        | 70000    | 1          |

주문을 입력하세요 (1:매수, 2:매도, 3:정정, 4:취소):3
주문번호를 입력하세요:0080904
정정가격을 입력하세요(숫자):71000
(0, [107062] 매수정정 주문입력이 완료되었습니다)
잔고, Field Count = 6, Row Count = 0
| 종목번호 | 종목명   | 보유수량        | 매입가          | 현재가       | 평가손익        |
|----------|----------|-----------------|-----------------|--------------|-----------------|

미체결, Field Count = 7, Row Count = 1
| 주문번호 | 주문구분  | 종목코드 | 종목명   | 주문수량 | 주문가격 | 미체결수량 |
|----------|----------|----------|-----------|----------|----------|------------|
| 0082314  | +매수정정 | 005930   | 삼성전자 | 1        | 71000    | 1          |

주문을 입력하세요 (1:매수, 2:매도, 3:정정, 4:취소):4
주문번호를 입력하세요:0082314
(0, [107071] 매수취소 주문입력이 완료되었습니다)
잔고, Field Count = 6, Row Count = 0
| 종목번호 | 종목명   | 보유수량        | 매입가          | 현재가       | 평가손익        |
|----------|----------|-----------------|-----------------|--------------|-----------------|

미체결, Field Count = 7, Row Count = 0
| 주문번호 | 주문구분 | 종목코드 | 종목명 | 주문수량 | 주문가격 | 미체결수량 |
|----------|----------|----------|--------|----------|----------|------------|
*/
