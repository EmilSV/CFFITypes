using System.Runtime.InteropServices;

namespace CFFITypes;

/// <summary>
/// Represents C <c>unsigned char</c>.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct CUchar : IComparable<CUchar>, IEquatable<CUchar>, IFormattable
{
    private readonly byte _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="CUchar"/> struct.
    /// </summary>
    public CUchar(byte value)
    {
        _value = value;
    }

    public int CompareTo(CUchar other) => _value.CompareTo(other._value);

    public bool Equals(CUchar other) => _value == other._value;

    public override bool Equals(object? obj) => obj is CUchar other && Equals(other);

    public override int GetHashCode() => _value.GetHashCode();

    public override string ToString() => _value.ToString();

    public string ToString(IFormatProvider? formatProvider) => ((char)_value).ToString(formatProvider);

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
    {
        return ((IFormattable)(char)_value).ToString(format, formatProvider);
    }

    public static implicit operator CUchar(byte value) => new(value);

    public static implicit operator byte(CUchar value) => value._value;

    public static bool operator ==(CUchar left, CUchar right) => left._value == right._value;

    public static bool operator !=(CUchar left, CUchar right) => left._value != right._value;
}
