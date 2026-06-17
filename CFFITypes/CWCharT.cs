using System.Runtime.InteropServices;


#if WINDOWS
using internal_wchar_t = ushort;
#else
using internal_wchar_t = uint;
#endif

namespace CFFITypes;

/// <summary>
/// Represents C <c>wchar_t</c>. The backing layout is 16-bit on Windows and 32-bit on Unix-like targets.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct CWCharT : IComparable<CWCharT>, IEquatable<CWCharT>, IFormattable
{
    private readonly internal_wchar_t _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="CWCharT"/> struct from a character.
    /// </summary>
    public CWCharT(char value)
    {
        _value = (internal_wchar_t)value;
    }

    private CWCharT(uint value)
    {
        _value = (internal_wchar_t)value;
    }


    public static bool TryCreateFromUint(uint value, out CWCharT result)
    {
        if (value > internal_wchar_t.MaxValue)
        {
            result = default;
            return false;
        }

        result = new CWCharT((uint)value);
        return true;
    }

    /// <summary>
    /// Converts the value to <see cref="char"/> when it fits in a UTF-16 code unit.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the value is larger than <see cref="char.MaxValue"/>.</exception>
    public bool TryToChar(out char value)
    {
        if (_value > char.MaxValue)
        {
            value = default;
            return false;
        }

        value = (char)_value;
        return true;
    }

    public int CompareTo(CWCharT other) => _value.CompareTo(other._value);

    public bool Equals(CWCharT other) => _value == other._value;

    public override bool Equals(object? obj) => obj is CWCharT other && Equals(other);

    public override int GetHashCode() => _value.GetHashCode();

    public override string ToString() => _value.ToString();

    public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

    public static implicit operator CWCharT(char value) => new(value);

    public static explicit operator CWCharT(uint value) => new(value);

    public static explicit operator uint(CWCharT value) => value._value;

    public static bool operator ==(CWCharT left, CWCharT right) => left._value == right._value;

    public static bool operator !=(CWCharT left, CWCharT right) => left._value != right._value;

    public static bool operator <(CWCharT left, CWCharT right) => left._value < right._value;

    public static bool operator <=(CWCharT left, CWCharT right) => left._value <= right._value;

    public static bool operator >(CWCharT left, CWCharT right) => left._value > right._value;

    public static bool operator >=(CWCharT left, CWCharT right) => left._value >= right._value;
}
