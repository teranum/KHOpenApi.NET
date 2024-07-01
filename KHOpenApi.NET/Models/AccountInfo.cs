namespace KHOpenApi.NET;

/// <summary>
/// 계좌 정보
/// </summary>
/// <param name="Number"></param>
/// <param name="Name"></param>
/// <param name="DetailName"></param>
/// <param name="PassNumber"></param>
public class AccountInfo(string Number, string Name, string DetailName, string PassNumber)
{
    /// <summary>계좌번호</summary>
    public string Number { get; } = Number;

    /// <summary>계좌명</summary>
    public string Name { get; } = Name;

    /// <summary>상세계좌명</summary>
    public string DetailName { get; } = DetailName;

    /// <summary>계좌비밀번호</summary>
    public string PassNumber { get; set; } = PassNumber;
}
