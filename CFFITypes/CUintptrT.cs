using System.Runtime.InteropServices;

namespace CFFITypes;

/// <summary>
/// Represents C <c>uintptr_t</c>, an unsigned integer capable of storing a data pointer.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct CUintptrT : IComparable<CUintptrT>, IEquatable<CUintptrT>, IFormattable
{
    private readonly nuint _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="CUintptrT"/> struct.
    /// </summary>
    public CUintptrT(nuint value)
    {
        _value = value;
    }

    /// <summary>
    /// Gets the underlying native unsigned integer value.
    /// </summary>
    public nuint Value => _value;

    public int CompareTo(CUintptrT other) => _value.CompareTo(other._value);

    public bool Equals(CUintptrT other) => _value == other._value;

    public override bool Equals(object? obj) => obj is CUintptrT other && Equals(other);

    public override int GetHashCode() => _value.GetHashCode();

    public override string ToString() => _value.ToString();

    public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

    public static implicit operator CUintptrT(nuint value) => new(value);

    public static implicit operator nuint(CUintptrT value) => value._value;

    public static bool operator ==(CUintptrT left, CUintptrT right) => left._value == right._value;

    public static bool operator !=(CUintptrT left, CUintptrT right) => left._value != right._value;

    public static bool operator <(CUintptrT left, CUintptrT right) => left._value < right._value;

    public static bool operator <=(CUintptrT left, CUintptrT right) => left._value <= right._value;

    public static bool operator >(CUintptrT left, CUintptrT right) => left._value > right._value;

    public static bool operator >=(CUintptrT left, CUintptrT right) => left._value >= right._value;
}
