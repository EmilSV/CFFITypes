using System.Runtime.InteropServices;

namespace CFFITypes;

/// <summary>
/// Represents C <c>signed char</c>.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct CSchar : IComparable<CSchar>, IEquatable<CSchar>, IFormattable
{
    private readonly sbyte _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="CSchar"/> struct.
    /// </summary>
    public CSchar(sbyte value)
    {
        _value = value;
    }

    public int CompareTo(CSchar other) => _value.CompareTo(other._value);

    public bool Equals(CSchar other) => _value == other._value;

    public override bool Equals(object? obj) => obj is CSchar other && Equals(other);

    public override int GetHashCode() => _value.GetHashCode();

    public override string ToString() => _value.ToString();

    public string ToString(IFormatProvider? formatProvider) => ((char)_value).ToString(formatProvider);

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
    {
        return ((IFormattable)(char)_value).ToString(format, formatProvider);
    }

    public static implicit operator CSchar(sbyte value) => new(value);

    public static implicit operator sbyte(CSchar value) => value._value;

    public static bool operator ==(CSchar left, CSchar right) => left._value == right._value;

    public static bool operator !=(CSchar left, CSchar right) => left._value != right._value;
}
