using System.ComponentModel;

namespace CSharp;

[Description("조건검색")]
internal class _11 : SampleBase
{
    public override async Task ActionImplement()
    {
        // 먼저 조건검색식 리스트 표시
        var conditions = _sCondList.Split(';', StringSplitOptions.RemoveEmptyEntries);
        var conditionItems = conditions.Select(x => x.Split('^')).Select(x => (int.Parse(x[0]), x[1]));
        print(conditions);

        // 코드 입력
        var 조건식코드 = await GetInputAsync("검색식 코드를 입력하세요 (숫자):");
        _ = int.TryParse(조건식코드, out var nCode);
        (int Code, string Name) conditionInfo = conditionItems.FirstOrDefault(x => x.Item1 == nCode);
        if (conditionInfo == default)
        {
            print("검색식이 없습니다.");
            return;
        }

        // 요청
        var (nRet, sCodeList) = await api.SendConditionAsync("8001", conditionInfo.Name, conditionInfo.Code, 0);
        if (nRet != 1)
        {
            print($"검색식 요청실패: {api.GetErrorMessage(nRet)}");
            return;
        }

        var items = sCodeList.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => 
        {
            var infos = x.Split('^');
            var code = infos[0];
            var name = api.GetMasterCodeName(code);
            var price = string.Empty;
            if (infos.Length > 1)
                price = infos[1];
            return (code, name, price);
        });
        print(items);
    }
}

// Output:
/*
검색식 코드를 입력하세요 (숫자):1
array, Data Count = 15
| Key | Value                      |
|-----|----------------------------|
|   1 | (004250, NPC)              |
|   2 | (006730, 서부T&D)          |
|   3 | (010100, 한국무브넥스)     |
|   4 | (015750, 성우하이텍)       |
|   5 | (033530, 에스제이지세종)   |
|   6 | (053300, 한국정보인증)     |
|   7 | (060310, 3S)               |
|   8 | (085670, 뉴프렉스)         |
|   9 | (090470, 제이스텍)         |
|  10 | (234100, 폴라리스세원)     |
|  11 | (241790, 티이엠씨씨엔에스) |
|  12 | (243840, 신흥에스이씨)     |
|  13 | (262260, 에이프로)         |
|  14 | (336570, 원텍)             |
|  15 | (950130, 엑세스바이오)     |
*/
