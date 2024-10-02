using System.ComponentModel;

namespace CSharp;

[Description("국선 잔고-미체결-주문")]
internal class _15 : SampleBase
{
    public override async Task ActionImplement()
    {
        // 선물옵션 조회
        var accounts = api.GetLoginInfo("ACCTLIST_DETAIL").Split(';', StringSplitOptions.RemoveEmptyEntries);
        var stock_account = accounts.FirstOrDefault(x => x.Contains("선물옵션"));
        if (stock_account == null)
        {
            print("선물옵션계좌가 없습니다.");
            return;
        }
        var account = stock_account.Split(',')[0];
        print($"선물옵션: {account}");

        // 가장 최근월물 표시
        var recent_F_code = api.GetFutureList().Split(';').FirstOrDefault();
        print($"최근월물: {recent_F_code}");

        while (true)
        {
            // 잔고조회
            var jango_response = await api.RequestTrAsync("OPT50027", [ ("계좌번호", account) ]
                , []
                , ["매매구분", "종목코드", "종목명", "보유수량", "매입단가", "현재가"]
            );
            print("잔고내역 (매매구분값이 1일때 매도)", jango_response.RequestMultiFields, jango_response.OutputMultiDatas.ToArray());

            // 미체결조회
            var miche_response = await api.RequestTrAsync("OPT50026",
                [
                    ("종목코드", string.Empty), // 전문 조회할 종목코드(공백허용, 공백입력시 조회구분 "0" 입력하여 전체 종목 대상으로 조회)
                    ("조회구분", "0"), // 0:전체종목, 1:종목별조회
                    ("매매구분", "0"), // 0:전체, 1:매도, 2:매수
                    ("체결구분", "1"), // 0:전체, 1:미체결내역, 2:체결내역
                    ("계좌번호", account), // 전문 조회할 보유계좌번호 10자리
                    ("주문번호", string.Empty), // 조회할 주문번호(공백허용, 공백입력시 전체 주문 대상으로 조회)
                ]
                , []
                , ["주문번호", "매매구분", "종목코드", "종목명", "주문수량", "주문가격", "미체결수량"]
            );
            print("미체결내역 (매매구분값이 1일때 매도)", miche_response.RequestMultiFields, miche_response.OutputMultiDatas.ToArray());

            // 주문요청 입력
            var 주문요청 = await GetInputAsync("주문을 입력하세요 (1:매수, 2:매도, 3:정정, 4:취소):");
            if (주문요청.Equals("1") || 주문요청.Equals("2")) // 신규매수/신규매도
            {
                var 종목코드 = await GetInputAsync("종목코드를 입력하세요(8자리 숫자):");
                var 주문수량 = await GetInputAsync("주문수량을 입력하세요(숫자):");
                var 주문가격 = await GetInputAsync("주문가격을 입력하세요(숫자):");

                _ = int.TryParse(주문수량, out var nOrderQty);
                _ = double.TryParse(주문가격, out var dPrice);

                if (nOrderQty == 0 || dPrice == 0)
                {
                    print("잘못된 입력입니다.");
                    return;
                }

                bool b매수 = 주문요청.Equals("1");
                var (nRet, sMsg) = await api.SendOrderFOAsync("신규주문", "2001", account, 종목코드, 1, b매수 ? "2" : "1", "1", nOrderQty, dPrice.ToString(), string.Empty);

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
                var 매매구분 = matched_miche[1];
                var 종목코드 = matched_miche[2];
                var 미체결수량 = matched_miche[6];
                _ = int.TryParse(미체결수량, out var nOrderQty);

                if (주문요청.Equals("3"))
                {
                    // 정정
                    var 정정가격 = await GetInputAsync("정정가격을 입력하세요(숫자):");
                    _ = double.TryParse(정정가격, out var dPrice);

                    if (dPrice == 0)
                    {
                        print("잘못된 입력입니다.");
                        return;
                    }

                    var (nRet, sMsg) = await api.SendOrderFOAsync("정정주문", "2002", account, 종목코드, 2, 매매구분, "1", nOrderQty, dPrice.ToString(), 원주문번호);

                    print($"({nRet}, {sMsg})");
                }
                else
                {
                    // 취소
                    var (nRet, sMsg) = await api.SendOrderFOAsync("취소주문", "2003", account, 종목코드, 3, 매매구분, "1", nOrderQty, string.Empty, 원주문번호);

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
*/
