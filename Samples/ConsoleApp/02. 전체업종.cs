using System.ComponentModel;

namespace CSharp;

[Description("전체업종")]
internal class _02 : SampleBase
{
    public override Task ActionImplement()
    {
        string[] upjongGroups = ["0", "1", "2", "4", "7",]; // 0:장내, 1: 코스닥, 2:KOSPI200, 4:KOSPI100(KOSPI50), 7:KRX100
        var code_names = upjongGroups.Select(x => api.KOA_Functions("GetUpjongCode", x).Split('|', StringSplitOptions.RemoveEmptyEntries)).SelectMany(x => x);
        var items = code_names.Select(x =>
        {
            var infos = x.Split(',');
            var code = infos[1];
            var name = infos[2];
            return (code, name);
        });
        print(items);
        return Task.CompletedTask;
    }
}

// Output:
/*
array, Data Count = 118
| Key | Value                      |
|-----|----------------------------|
|   1 | (001, 종합(KOSPI))         |
|   2 | (002, 대형주)              |
|   3 | (003, 중형주)              |
|   4 | (004, 소형주)              |
|   5 | (005, 음식료업)            |
|   6 | (006, 섬유의복)            |
|   7 | (007, 종이목재)            |
|   8 | (008, 화학)                |
|   9 | (009, 의약품)              |
|  10 | (010, 비금속광물)          |
|  11 | (011, 철강금속)            |
|  12 | (012, 기계)                |
|  13 | (013, 전기전자)            |
...
 */
