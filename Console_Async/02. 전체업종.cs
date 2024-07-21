namespace CSharp;

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
ItemInfo[], Field Count = 6, Data Count = 118
| 마켓구분 | 마켓서브타입     | 종목코드 | 종목명              | 전일가 | 현재가 |
|----------|------------------|----------|---------------------|--------|--------|
| 업종     | 코스피           | 001      | 종합(KOSPI)         |      0 |      0 |
| 업종     | 코스피           | 002      | 대형주              |      0 |      0 |
| 업종     | 코스피           | 003      | 중형주              |      0 |      0 |
| 업종     | 코스피           | 004      | 소형주              |      0 |      0 |
| 업종     | 코스피           | 005      | 음식료업            |      0 |      0 |
| 업종     | 코스피           | 006      | 섬유의복            |      0 |      0 |
| 업종     | 코스피           | 007      | 종이목재            |      0 |      0 |
| 업종     | 코스피           | 008      | 화학                |      0 |      0 |
| 업종     | 코스피           | 009      | 의약품              |      0 |      0 |
| 업종     | 코스피           | 010      | 비금속광물          |      0 |      0 |
| 업종     | 코스피           | 011      | 철강금속            |      0 |      0 |
| 업종     | 코스피           | 012      | 기계                |      0 |      0 |
| 업종     | 코스피           | 013      | 전기전자            |      0 |      0 |
| 업종     | 코스피           | 014      | 의료정밀            |      0 |      0 |
| 업종     | 코스피           | 015      | 운수장비            |      0 |      0 |
| 업종     | 코스피           | 016      | 유통업              |      0 |      0 |
| 업종     | 코스피           | 017      | 전기가스업          |      0 |      0 |
| 업종     | 코스피           | 018      | 건설업              |      0 |      0 |
| 업종     | 코스피           | 019      | 운수창고            |      0 |      0 |
*/
