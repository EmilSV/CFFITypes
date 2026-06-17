using System.Runtime.InteropServices;

namespace CFFITypes;

/// <summary>
/// Represents C <c>size_t</c>, an unsigned integer with the same size as a native pointer.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct CSizeT : IComparable<CSizeT>, IEquatable<CSizeT>, IFormattable
{
    private readonly nuint _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="CSizeT"/> struct.
    /// </summary>
    public CSizeT(nuint value)
    {
        _value = value;
    }

    public int CompareTo(CSizeT other) => _value.CompareTo(other._value);

    public bool Equals(CSizeT other) => _value == other._value;

    public override bool Equals(object? obj) => obj is CSizeT other && Equals(other);

    public override int GetHashCode() => _value.GetHashCode();

    public override string ToString() => _value.ToString();

    public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

    public static implicit operator CSizeT(nuint value) => new(value);

    public static implicit operator nuint(CSizeT value) => value._value;

    public static bool operator ==(CSizeT left, CSizeT right) => left._value == right._value;

    public static bool operator !=(CSizeT left, CSizeT right) => left._value != right._value;

    public static bool operator <(CSizeT left, CSizeT right) => left._value < right._value;

    public static bool operator <=(CSizeT left, CSizeT right) => left._value <= right._value;

    public static bool operator >(CSizeT left, CSizeT right) => left._value > right._value;

    public static bool operator >=(CSizeT left, CSizeT right) => left._value >= right._value;
}
