using System.Runtime.InteropServices;

namespace CFFITypes;

/// <summary>
/// Represents C <c>ssize_t</c>, a signed integer with the same size as a native pointer.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct CSsizeT : IComparable<CSsizeT>, IEquatable<CSsizeT>, IFormattable
{
    private readonly nint _value;

    public CSsizeT(nint value)
    {
        _value = value;
    }

    public int CompareTo(CSsizeT other) => _value.CompareTo(other._value);

    public bool Equals(CSsizeT other) => _value == other._value;

    public override bool Equals(object? obj) => obj is CSsizeT other && Equals(other);

    public override int GetHashCode() => _value.GetHashCode();

    public override string ToString() => _value.ToString();

    public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

    public static implicit operator CSsizeT(nint value) => new(value);

    public static implicit operator nint(CSsizeT value) => value._value;

    public static bool operator ==(CSsizeT left, CSsizeT right) => left._value == right._value;

    public static bool operator !=(CSsizeT left, CSsizeT right) => left._value != right._value;

    public static bool operator <(CSsizeT left, CSsizeT right) => left._value < right._value;

    public static bool operator <=(CSsizeT left, CSsizeT right) => left._value <= right._value;

    public static bool operator >(CSsizeT left, CSsizeT right) => left._value > right._value;

    public static bool operator >=(CSsizeT left, CSsizeT right) => left._value >= right._value;
}
