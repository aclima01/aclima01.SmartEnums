using System.Reflection;

namespace aclima01.SmartEnums;

public abstract class SmartEnum<TEnum> : IEquatable<SmartEnum<TEnum>>
    where TEnum : SmartEnum<TEnum>
{
    private static readonly Dictionary<int, TEnum> SmartEnums = CreateSmartEnums();

    protected SmartEnum(int value, string name)
    {
        Value = value;
        Name = name;
    }

    public int Value { get; protected init; }
    
    public string Name { get; protected init; } = string.Empty;

    public static TEnum? FromValue(int value)
    {
        return SmartEnums.TryGetValue(
            value,
            out TEnum? enumeration) ?
                enumeration : 
                default;
    }

    public static TEnum? FromName(string name)
    {
        return SmartEnums.Values.SingleOrDefault(e => e.Name == name);
    }

    public bool Equals(SmartEnum<TEnum>? other)
    {
        if (other == null) return false;

        return GetType() == other.GetType() &&
            Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is SmartEnum<TEnum> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Name;
    }

    private static Dictionary<int, TEnum> CreateSmartEnums()
    {
        var enumerationType = typeof(TEnum);

        var fieldsForType = enumerationType
            .GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.FlattenHierarchy)
            .Where(fieldInfo =>
                enumerationType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo =>
                (TEnum)fieldInfo.GetValue(default)!);

        return fieldsForType.ToDictionary(x => x.Value);
    }
}
