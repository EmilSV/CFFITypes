using System.Runtime.InteropServices;

namespace CFFITypes;

/// <summary>
/// Represents C <c>intptr_t</c>, a signed integer capable of storing a data pointer.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct CIntptrT : IComparable<CIntptrT>, IEquatable<CIntptrT>, IFormattable
{
    private readonly nint _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="CIntptrT"/> struct.
    /// </summary>
    public CIntptrT(nint value)
    {
        _value = value;
    }

    public int CompareTo(CIntptrT other) => _value.CompareTo(other._value);

    public bool Equals(CIntptrT other) => _value == other._value;

    public override bool Equals(object? obj) => obj is CIntptrT other && Equals(other);

    public override int GetHashCode() => _value.GetHashCode();

    public override string ToString() => _value.ToString();

    public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

    public static implicit operator CIntptrT(nint value) => new(value);

    public static implicit operator nint(CIntptrT value) => value._value;

    public static bool operator ==(CIntptrT left, CIntptrT right) => left._value == right._value;

    public static bool operator !=(CIntptrT left, CIntptrT right) => left._value != right._value;

    public static bool operator <(CIntptrT left, CIntptrT right) => left._value < right._value;

    public static bool operator <=(CIntptrT left, CIntptrT right) => left._value <= right._value;

    public static bool operator >(CIntptrT left, CIntptrT right) => left._value > right._value;

    public static bool operator >=(CIntptrT left, CIntptrT right) => left._value >= right._value;
}
