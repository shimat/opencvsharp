using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp;

/// <summary>
/// 2-Tuple of ushort (System.UInt16)
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
// ReSharper disable once InconsistentNaming
public struct Vec2w : IVec<Vec2w, ushort>, IEquatable<Vec2w>
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
    /// Deconstructing a Vector
    /// </summary>
    /// <param name="item0"></param>
    /// <param name="item1"></param>
    public readonly void Deconstruct(out ushort item0, out ushort item1) => (item0, item1) = (Item0, Item1);

    /// <summary>
    /// Initializer
    /// </summary>
    /// <param name="item0"></param>
    /// <param name="item1"></param>
    public Vec2w(ushort item0, ushort item1)
    {
        Item0 = item0;
        Item1 = item1;
    }

    #region Operators

    /// <summary>
    /// this + other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec2w Add(Vec2w other) => new(
        SaturateCast.ToUInt16(Item0 + other.Item0),
        SaturateCast.ToUInt16(Item1 + other.Item1));

    /// <summary>
    /// this - other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec2w Subtract(Vec2w other) => new(
        SaturateCast.ToUInt16(Item0 - other.Item0),
        SaturateCast.ToUInt16(Item1 - other.Item1));

    /// <summary>
    /// this * alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec2w Multiply(double alpha) => new(
        SaturateCast.ToUInt16(Item0 * alpha),
        SaturateCast.ToUInt16(Item1 * alpha));

    /// <summary>
    /// this / alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec2w Divide(double alpha) => new(
        SaturateCast.ToUInt16(Item0 / alpha),
        SaturateCast.ToUInt16(Item1 / alpha));

#pragma warning disable 1591
    public static Vec2w operator +(Vec2w a, Vec2w b) => a.Add(b);
    public static Vec2w operator -(Vec2w a, Vec2w b) => a.Subtract(b);
    public static Vec2w operator *(Vec2w a, double alpha) => a.Multiply(alpha);
    public static Vec2w operator /(Vec2w a, double alpha) => a.Divide(alpha);
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
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };
        }
        set
        {
            switch (i)
            {
                case 0: Item0 = value; break;
                case 1: Item1 = value; break;
                default: throw new ArgumentOutOfRangeException(nameof(i));
            }
        }
    }

    #endregion

#pragma warning disable 1591
    // ReSharper disable InconsistentNaming
    //public Vec6b ToVec6b() => new Vec6b((byte)Item0, (byte)Item1, (byte)Item2, (byte)Item3, (byte)Item4, (byte)Item5);
    public Vec2s ToVec2s() => new((short)Item0, (short)Item1);
    public Vec2i ToVec2i() => new(Item0, Item1);
    public Vec2f ToVec2f() => new(Item0, Item1);
    public Vec2d ToVec2d() => new(Item0, Item1);
    // ReSharper restore InconsistentNaming
#pragma warning restore 1591

    /// <inheritdoc />
    public readonly bool Equals(Vec2w other)
    {
        return Item0 == other.Item0 && Item1 == other.Item1;
    }

    /// <inheritdoc />
    public override readonly bool Equals(object? obj)
    {
        if (obj is null) return false;
        return obj is Vec2w w && Equals(w);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Vec2w a, Vec2w b)
    {
        return a.Equals(b);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Vec2w a, Vec2w b)
    {
        return !a.Equals(b);
    }

    /// <inheritdoc />
    public override readonly int GetHashCode()
    {
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
        unchecked
        {
            return (Item0.GetHashCode() * 397) ^ Item1.GetHashCode();
        }
#else
            return HashCode.Combine(Item0, Item1);
#endif
    }

    /// <inheritdoc />
    public override readonly string ToString()
    {
        return $"{nameof(Vec2w)} ({Item0}, {Item1})";
    }
}
