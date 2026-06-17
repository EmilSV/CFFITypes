using System.Runtime.InteropServices;

namespace CFFITypes;

/// <summary>
/// Represents C <c>ptrdiff_t</c>, a signed integer capable of storing pointer differences.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct CPtrdiffT : IComparable<CPtrdiffT>, IEquatable<CPtrdiffT>, IFormattable
{
    private readonly nint _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="CPtrdiffT"/> struct.
    /// </summary>
    public CPtrdiffT(nint value)
    {
        _value = value;
    }

    public int CompareTo(CPtrdiffT other) => _value.CompareTo(other._value);

    public bool Equals(CPtrdiffT other) => _value == other._value;

    public override bool Equals(object? obj) => obj is CPtrdiffT other && Equals(other);

    public override int GetHashCode() => _value.GetHashCode();

    public override string ToString() => _value.ToString();

    public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

    public static implicit operator CPtrdiffT(nint value) => new(value);

    public static implicit operator nint(CPtrdiffT value) => value._value;

    public static bool operator ==(CPtrdiffT left, CPtrdiffT right) => left._value == right._value;

    public static bool operator !=(CPtrdiffT left, CPtrdiffT right) => left._value != right._value;

    public static bool operator <(CPtrdiffT left, CPtrdiffT right) => left._value < right._value;

    public static bool operator <=(CPtrdiffT left, CPtrdiffT right) => left._value <= right._value;

    public static bool operator >(CPtrdiffT left, CPtrdiffT right) => left._value > right._value;

    public static bool operator >=(CPtrdiffT left, CPtrdiffT right) => left._value >= right._value;
}
