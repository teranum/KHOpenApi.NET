using System.ComponentModel;

namespace CSharp;

[Description("지수선물마스터조회")]
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
array, Data Count = 177
| Key | Value                            |
|-----|----------------------------------|
|   1 | (101V9000, F 202409)             |
|   2 | (101VC000, F 202412)             |
|   3 | (101W3000, F 202503)             |
|   4 | (101W6000, F 202506)             |
|   5 | (101WC000, F 202512)             |
|   6 | (A0166000, F 202606)             |
|   7 | (A016C000, F 202612)             |
|   8 | (401V9VCS, SP 2409-2412)         |
|   9 | (401V9W3S, SP 2409-2503)         |
|  10 | (401V9W6S, SP 2409-2506)         |
|  11 | (401V9WCS, SP 2409-2512)         |
|  12 | (401V966S, SP 2409-2606)         |
|  13 | (401V96CS, SP 2409-2612)         |
|  14 | (105V8000, 미니 F 202408)        |
|  15 | (105V9000, 미니 F 202409)        |
|  16 | (105VA000, 미니 F 202410)        |
|  17 | (105VB000, 미니 F 202411)        |
|  18 | (105VC000, 미니 F 202412)        |
...
*/
