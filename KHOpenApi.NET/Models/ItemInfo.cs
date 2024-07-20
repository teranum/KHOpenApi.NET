namespace KHOpenApi.NET.Models;

/// <summary>종목정보</summary>
public class ItemInfo(MarketType 마켓구분, MarketSubType 마켓서브타입, string 종목코드, string 종목명, double 전일가)
{
    /// <summary>마켓구분</summary>
    public MarketType 마켓구분 { get; } = 마켓구분;
    /// <summary>마켓구분</summary>
    public MarketSubType 마켓서브타입 { get; } = 마켓서브타입;
    /// <summary>종목코드</summary>
    public string 종목코드 { get; } = 종목코드;
    /// <summary>종목명</summary>
    public string 종목명 { get; } = 종목명;
    /// <summary>전일가</summary>
    public double 전일가 { get; } = 전일가;
    /// <summary>현재가</summary>
    public double 현재가 { get; set; }

    /// <summary>Tag</summary>
    public object Tag { get; set; }
}
