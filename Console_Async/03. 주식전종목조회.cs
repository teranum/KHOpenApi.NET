namespace CSharp;

internal class _03 : SampleBase
{
    public override Task ActionImplement()
    {
        // 코스피/코스닥 주식 전체목록
        var GroupCodes = new[] { "0", "10" };
        var codes = GroupCodes.Select(x=> api.GetCodeListByMarket(x).Split(';', StringSplitOptions.RemoveEmptyEntries)).SelectMany(x=>x);
        var items = codes.Select(x => (x, api.GetMasterCodeName(x)));
        print(items);
        return Task.CompletedTask;
    }
}

// Output:
/*
ItemInfo[], Field Count = 6, Data Count = 8158
| 마켓구분 | 마켓서브타입 | 종목코드  | 종목명                                   |  전일가 | 현재가 |
|----------|--------------|-----------|------------------------------------------|---------|--------|
| 주식     | 코스피       | 000020    | 동화약품                                 |    8110 |      0 |
| 주식     | 코스피       | 000040    | KR모터스                                 |     643 |      0 |
| 주식     | 코스피       | 000050    | 경방                                     |    7630 |      0 |
| 주식     | 코스피       | 000070    | 삼양홀딩스                               |   69500 |      0 |
| 주식     | 코스피       | 000075    | 삼양홀딩스우                             |   54100 |      0 |
| 주식     | 코스피       | 000080    | 하이트진로                               |   20550 |      0 |
| 주식     | 코스피       | 000087    | 하이트진로2우B                           |   16260 |      0 |
| 주식     | 코스피       | 000100    | 유한양행                                 |   97300 |      0 |
| 주식     | 코스피       | 000105    | 유한양행우                               |   75600 |      0 |
| 주식     | 코스피       | 000120    | CJ대한통운                               |   90700 |      0 |
| 주식     | 코스피       | 000140    | 하이트진로홀딩스                         |    9110 |      0 |
| 주식     | 코스피       | 000145    | 하이트진로홀딩스우                       |   12490 |      0 |
| 주식     | 코스피       | 000150    | 두산                                     |  207000 |      0 |
...
*/
