namespace CSharp;

internal class _06 : SampleBase
{
    public override async Task ActionImplement()
    {
        // 삼성전자 일봉차트 데이터를 불러올수 있을때 까지 불러온다.

        List<string[]> all_datas = [];

        Dictionary<string, string> indatas = new()
        {
            ["종목코드"] = "005930", // 삼성전자
            ["기준일자"] = string.Empty,
            ["수정주가구분"] = "1",
        };
        string[] requried_fields = ["일자", "시가", "고가", "저가", "현재가", "거래량"];

        int nRequiredFramCount = 0;
        string cont_key = string.Empty;
        Console.Write("일봉차트 요청중");
        while (true)
        {
            var response = await api.RequestTrAsync("OPT10081", indatas, [], requried_fields, cont_key);
            nRequiredFramCount++;
            Console.Write(".");

            if (response.nErrCode < 0)
            {
                Console.WriteLine($"요청실패: {response.rsp_msg}");
                break;
            }

            all_datas.AddRange(response.OutputMultiDatas);

            if (response.cont_key.Length == 0)
                break;

            await Task.Delay(1000); // 1초 대기
            cont_key = response.cont_key;
        }
        Console.WriteLine($"{nRequiredFramCount}개 요청");

        print("일봉데이터", requried_fields, [.. all_datas]);
    }
}

// Output
/*
일봉차트 요청중..................18개 요청
일봉데이터, Field Count = 6, Row Count = 10407
| 일자     | 시가  | 고가  | 저가  | 현재가 | 거래량   |
|----------|-------|-------|-------|--------|----------|
| 20240719 | 85600 | 86100 | 84100 | 84400  | 18569122 |
| 20240718 | 83800 | 86900 | 83800 | 86900  | 24721790 |
| 20240717 | 87100 | 88000 | 86400 | 86700  | 18186490 |
| 20240716 | 86900 | 88000 | 86700 | 87700  | 16166688 |
| 20240715 | 84700 | 87300 | 84100 | 86700  | 25193080 |
| 20240712 | 85900 | 86100 | 84100 | 84400  | 26344386 |
| 20240711 | 88500 | 88800 | 86700 | 87600  | 24677608 |
...
| 19850112 | 127   | 127   | 126   | 127    | 513725   |
| 19850111 | 124   | 125   | 124   | 125    | 398039   |
| 19850110 | 124   | 125   | 124   | 124    | 462745   |
| 19850109 | 126   | 126   | 122   | 123    | 324837   |
| 19850108 | 129   | 129   | 127   | 127    | 845098   |
| 19850107 | 129   | 130   | 128   | 129    | 771895   |
| 19850105 | 129   | 129   | 128   | 128    | 108497   |
| 19850104 | 130   | 130   | 129   | 129    | 111765   |
...
*/