using System.ComponentModel;

namespace CSharp;

[Description("주식전종목조회")]
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
array, Data Count = 3967
|  Key | Value                                              |
|------|----------------------------------------------------|
|    1 | (000020, 동화약품)                                 |
|    2 | (000040, KR모터스)                                 |
|    3 | (000050, 경방)                                     |
|    4 | (000070, 삼양홀딩스)                               |
|    5 | (000075, 삼양홀딩스우)                             |
|    6 | (000080, 하이트진로)                               |
|    7 | (000087, 하이트진로2우B)                           |
|    8 | (000100, 유한양행)                                 |
|    9 | (000105, 유한양행우)                               |
|   10 | (000120, CJ대한통운)                               |
|   11 | (000140, 하이트진로홀딩스)                         |
|   12 | (000145, 하이트진로홀딩스우)                       |
...
*/
