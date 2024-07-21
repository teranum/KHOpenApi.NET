namespace CSharp;

internal class _08 : SampleBase
{
    public override Task ActionImplement()
    {
        var codes = api.GetFutureList().Split(';', StringSplitOptions.RemoveEmptyEntries);
        var items = codes.Select(x => (x, api.GetMasterCodeName(x)));
        print(items);
        return Task.CompletedTask;
    }
}

// Output:
/*
ItemInfo[], Field Count = 6, Data Count = 177
| 마켓구분 | 마켓서브타입 | 종목코드 | 종목명               | 전일가 | 현재가 |
|----------|--------------|----------|----------------------|--------|--------|
| 선물옵션 | 지수선물     | 101V9000 | F 202409             |      0 |      0 |
| 선물옵션 | 지수선물     | 101VC000 | F 202412             |      0 |      0 |
| 선물옵션 | 지수선물     | 101W3000 | F 202503             |      0 |      0 |
| 선물옵션 | 지수선물     | 101W6000 | F 202506             |      0 |      0 |
| 선물옵션 | 지수선물     | 101WC000 | F 202512             |      0 |      0 |
| 선물옵션 | 지수선물     | A0166000 | F 202606             |      0 |      0 |
| 선물옵션 | 지수선물     | A016C000 | F 202612             |      0 |      0 |
| 선물옵션 | 지수선물     | 401V9VCS | SP 2409-2412         |      0 |      0 |
| 선물옵션 | 지수선물     | 401V9W3S | SP 2409-2503         |      0 |      0 |
| 선물옵션 | 지수선물     | 401V9W6S | SP 2409-2506         |      0 |      0 |
| 선물옵션 | 지수선물     | 401V9WCS | SP 2409-2512         |      0 |      0 |
| 선물옵션 | 지수선물     | 401V966S | SP 2409-2606         |      0 |      0 |
| 선물옵션 | 지수선물     | 401V96CS | SP 2409-2612         |      0 |      0 |
| 선물옵션 | 지수선물     | 105V8000 | 미니 F 202408        |      0 |      0 |
| 선물옵션 | 지수선물     | 105V9000 | 미니 F 202409        |      0 |      0 |
| 선물옵션 | 지수선물     | 105VA000 | 미니 F 202410        |      0 |      0 |
...
*/
