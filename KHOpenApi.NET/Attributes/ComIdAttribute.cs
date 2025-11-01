namespace KHOpenApi.NET.Attributes;

/// <summary>
/// 대상 클래스에 연결할 COM 식별자(ProgID 또는 CLSID)를 지정하는 특성입니다.
/// </summary>
/// <param name="comId">대상 클래스에 매핑할 COM 식별자 문자열입니다.</param>
[AttributeUsage(AttributeTargets.Class)]
public class ComIdAttribute(string comId) : Attribute
{
    /// <summary>
    /// 지정된 COM 식별자 값입니다.
    /// </summary>
    public string Value { get; } = comId;
}
