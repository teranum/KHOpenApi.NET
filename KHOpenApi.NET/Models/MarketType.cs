namespace KHOpenApi.NET.Models;

/// <summary>
/// 마켓타입
/// </summary>
public enum MarketType
{
    /// <summary>업종</summary>
    업종,
    /// <summary>주식</summary>
    주식,
    /// <summary>선물</summary>
    선물옵션,
}


/// <summary>
/// 마켓 서브타입
/// </summary>
public enum MarketSubType
{
    /// <summary>NONE</summary>
    NONE,
    /// <summary>ELW</summary>
    ELW,
    /// <summary>ETF</summary>
    ETF,
    /// <summary>코넥스</summary>
    KONEX,
    /// <summary>코스피</summary>
    코스피,
    /// <summary>코스닥</summary>
    코스닥,
    /// <summary>뮤추얼펀드</summary>
    뮤추얼펀드,
    /// <summary>신주인수권</summary>
    신주인수권,
    /// <summary>리츠</summary>
    리츠,
    /// <summary>하이얼펀드</summary>
    하이얼펀드,
    /// <summary>K-OTC</summary>
    K_OTC,
    /// <summary>주식선물</summary>
    주식선물,
    /// <summary>상품선물</summary>
    상품선물,
    /// <summary>지수선물</summary>
    지수선물,
    /// <summary>지수선물</summary>
    지수옵션,

    // For 업종
    /// <summary>KOSPI200</summary>
    KOSPI200,
    /// <summary>KOSPI100_KOSPI50</summary>
    KOSPI100_KOSPI50,
    /// <summary>KRX100</summary>
    KRX100,
}
