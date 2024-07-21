namespace KHOpenApi.NET;

/// <summary>키-값 쌍</summary>
public class KeyValue<TKey, TValue>(TKey key, TValue value)
{
    /// <summary>키</summary>
    public TKey Key { get; set; } = key;

    /// <summary>값</summary>
    public TValue Value { get; set; } = value;

    /// <summary>암시적 변환</summary>
    public static implicit operator KeyValue<TKey, TValue>((TKey key, TValue value) valuetuple) => new(valuetuple.key, valuetuple.value);
}
