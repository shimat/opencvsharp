using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp;

/// <summary>
/// 4-Tuple of ushort (System.UInt16)
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
// ReSharper disable once InconsistentNaming
public struct Vec6w : IVec<Vec6w, ushort>, IEquatable<Vec6w>
{
    /// <summary>
    /// The value of the first component of this object.
    /// </summary>
    public ushort Item0;

    /// <summary>
    /// The value of the second component of this object.
    /// </summary>
    public ushort Item1;

    /// <summary>
    /// The value of the third component of this object.
    /// </summary>
    public ushort Item2;

    /// <summary>
    /// The value of the fourth component of this object.
    /// </summary>
    public ushort Item3;

    /// <summary>
    /// The value of the fifth component of this object.
    /// </summary>
    public ushort Item4;

    /// <summary>
    /// The value of the sixth component of this object.
    /// </summary>
    public ushort Item5;

    /// <summary>
    /// Deconstructing a Vector
    /// </summary>
    /// <param name="item0"></param>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    /// <param name="item4"></param>
    /// <param name="item5"></param>
    public readonly void Deconstruct(out ushort item0, out ushort item1, out ushort item2, out ushort item3, out ushort item4, out ushort item5) 
        => (item0, item1, item2, item3, item4, item5) = (Item0, Item1, Item2, Item3, Item4, Item5);

    /// <summary>
    /// Initializer
    /// </summary>
    /// <param name="item0"></param>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    /// <param name="item4"></param>
    /// <param name="item5"></param>
    public Vec6w(ushort item0, ushort item1, ushort item2, ushort item3, ushort item4, ushort item5)
    {
        Item0 = item0;
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
    }

    #region Operators

    /// <summary>
    /// this + other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec6w Add(Vec6w other) => new(
        SaturateCast.ToUInt16(Item0 + other.Item0),
        SaturateCast.ToUInt16(Item1 + other.Item1),
        SaturateCast.ToUInt16(Item2 + other.Item2),
        SaturateCast.ToUInt16(Item3 + other.Item3),
        SaturateCast.ToUInt16(Item4 + other.Item4),
        SaturateCast.ToUInt16(Item5 + other.Item5));

    /// <summary>
    /// this - other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec6w Subtract(Vec6w other) => new(
        SaturateCast.ToUInt16(Item0 - other.Item0),
        SaturateCast.ToUInt16(Item1 - other.Item1),
        SaturateCast.ToUInt16(Item2 - other.Item2),
        SaturateCast.ToUInt16(Item3 - other.Item3),
        SaturateCast.ToUInt16(Item4 - other.Item4),
        SaturateCast.ToUInt16(Item5 - other.Item5));

    /// <summary>
    /// this * alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec6w Multiply(double alpha) => new(
        SaturateCast.ToUInt16(Item0 * alpha),
        SaturateCast.ToUInt16(Item1 * alpha),
        SaturateCast.ToUInt16(Item2 * alpha),
        SaturateCast.ToUInt16(Item3 * alpha),
        SaturateCast.ToUInt16(Item4 * alpha),
        SaturateCast.ToUInt16(Item5 * alpha));

    /// <summary>
    /// this / alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec6w Divide(double alpha) => new(
        SaturateCast.ToUInt16(Item0 / alpha),
        SaturateCast.ToUInt16(Item1 / alpha),
        SaturateCast.ToUInt16(Item2 / alpha),
        SaturateCast.ToUInt16(Item3 / alpha),
        SaturateCast.ToUInt16(Item4 / alpha),
        SaturateCast.ToUInt16(Item5 / alpha));

#pragma warning disable 1591
    public static Vec6w operator +(Vec6w a, Vec6w b) => a.Add(b);
    public static Vec6w operator -(Vec6w a, Vec6w b) => a.Subtract(b);
    public static Vec6w operator *(Vec6w a, double alpha) => a.Multiply(alpha);
    public static Vec6w operator /(Vec6w a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

    /// <summary>
    /// Indexer
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public ushort this[int i]
    {
        readonly get
        {
            return i switch
            {
                0 => Item0,
                1 => Item1,
                2 => Item2,
                3 => Item3,
                4 => Item4,
                5 => Item5,
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };
        }
        set
        {
            switch(i)
            {
                case 0: Item0 = value; break;
                case 1: Item1 = value; break;
                case 2: Item2 = value; break;
                case 3: Item3 = value; break;
                case 4: Item4 = value; break;
                case 5: Item5 = value; break;
                default: throw new ArgumentOutOfRangeException(nameof(i));
            }
        }
    }

    #endregion

#pragma warning disable 1591
    // ReSharper disable InconsistentNaming
    //public Vec6b ToVec6b() => new Vec6b((byte)Item0, (byte)Item1, (byte)Item2, (byte)Item3, (byte)Item4, (byte)Item5);
    public Vec6s ToVec6s() => new((short)Item0, (short)Item1, (short)Item2, (short)Item3, (short)Item4, (short)Item5);
    public Vec6i ToVec6i() => new(Item0, Item1, Item2, Item3, Item4, Item5);
    public Vec6f ToVec6f() => new(Item0, Item1, Item2, Item3, Item4, Item5);
    public Vec6d ToVec6d() => new(Item0, Item1, Item2, Item3, Item4, Item5);
    // ReSharper restore InconsistentNaming
#pragma warning restore 1591

    /// <inheritdoc />
    public readonly bool Equals(Vec6w other)
    {
        return Item0 == other.Item0 && 
               Item1 == other.Item1 &&
               Item2 == other.Item2 && 
               Item3 == other.Item3 &&
               Item4 == other.Item4 &&
               Item5 == other.Item5;
    }
        
    /// <inheritdoc />
    public override readonly bool Equals(object? obj)
    {
        if (obj is null) return false;
        return obj is Vec6w v && Equals(v);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Vec6w a, Vec6w b)
    {
        return a.Equals(b);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Vec6w a, Vec6w b)
    {
        return !a.Equals(b);
    }

    /// <inheritdoc />
    public override readonly int GetHashCode()
    {
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
        unchecked
        {
            var hashCode = Item0.GetHashCode();
            hashCode = (hashCode * 397) ^ Item1.GetHashCode();
            hashCode = (hashCode * 397) ^ Item2.GetHashCode();
            hashCode = (hashCode * 397) ^ Item3.GetHashCode();
            hashCode = (hashCode * 397) ^ Item4.GetHashCode();
            hashCode = (hashCode * 397) ^ Item5.GetHashCode();
            return hashCode;
        }
#else
            return HashCode.Combine(Item0, Item1, Item2, Item3, Item4, Item5);
#endif
    }

    /// <inheritdoc />
    public override readonly string ToString()
    {
        return $"{nameof(Vec6w)} ({Item0}, {Item1}, {Item2}, {Item3}, {Item4}, {Item5})";
    }
}
