namespace KHOpenApi.NET.Internals;

internal static class ScrNumManager
{
    private const int _requreMinIndex = 9950;
    private const int _requreMaxIndex = 9999;

    private static int _requestIndex = _requreMinIndex;
    public static string GetRequestScrNum()
    {
        _requestIndex++;
        if (_requestIndex > _requreMaxIndex)
            _requestIndex = _requreMinIndex;
        return _requestIndex.ToString("D4");
    }
}
