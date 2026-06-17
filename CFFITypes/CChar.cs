using System.Runtime.InteropServices;

namespace CFFITypes;

/// <summary>
/// Represents C <c>char</c>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct CChar : IComparable<CChar>, IEquatable<CChar>, IFormattable
{
    private readonly sbyte _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="CChar"/> struct.
    /// </summary>
    public CChar(sbyte value)
    {
        _value = value;
    }

    public int CompareTo(CChar other) => _value.CompareTo(other._value);

    public bool Equals(CChar other) => _value == other._value;

    public override bool Equals(object? obj) => obj is CChar other && Equals(other);

    public override int GetHashCode() => _value.GetHashCode();

    public override string ToString() => _value.ToString();

    public string ToString(IFormatProvider? formatProvider) => ((char)_value).ToString(formatProvider);

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
    {
        return ((IFormattable)(char)_value).ToString(format, formatProvider);
    }

    public static implicit operator CChar(sbyte value) => new(value);

    public static implicit operator sbyte(CChar value) => value._value;

    public static bool operator ==(CChar left, CChar right) => left._value == right._value;

    public static bool operator !=(CChar left, CChar right) => left._value != right._value;
}
