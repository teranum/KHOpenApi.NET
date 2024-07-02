namespace KHOpenApi.NET.Models;

/// <summary>
/// 조건식 정보
/// </summary>
/// <param name="name">이름</param>
/// <param name="index">코드</param>
public class ConditionInfo(int index, string name)
{
    /// <summary>이름</summary>
    public string Name { get; } = name;
    /// <summary>코드</summary>
    public int Index { get; } = index;
}
