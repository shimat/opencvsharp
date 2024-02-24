using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp;

/// <summary>
/// 2-Tuple of int (System.Int32)
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
// ReSharper disable once InconsistentNaming
public struct Vec2i : IVec<Vec2i, int>, IEquatable<Vec2i>
{
    /// <summary>
    /// The value of the first component of this object.
    /// </summary>
    public int Item0;

    /// <summary>
    /// The value of the second component of this object.
    /// </summary>
    public int Item1;

    /// <summary>
    /// Deconstructing a Vector
    /// </summary>
    /// <param name="item0"></param>
    /// <param name="item1"></param>
    public readonly void Deconstruct(out int item0, out int item1) => (item0, item1) = (Item0, Item1);

    /// <summary>
    /// Initializer
    /// </summary>
    /// <param name="item0"></param>
    /// <param name="item1"></param>
    public Vec2i(int item0, int item1)
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
    public readonly Vec2i Add(Vec2i other) => new(
        SaturateCast.ToInt32(Item0 + other.Item0),
        SaturateCast.ToInt32(Item1 + other.Item1));

    /// <summary>
    /// this - other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec2i Subtract(Vec2i other) => new(
        SaturateCast.ToInt32(Item0 - other.Item0),
        SaturateCast.ToInt32(Item1 - other.Item1));

    /// <summary>
    /// this * alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec2i Multiply(double alpha) => new(
        SaturateCast.ToInt32(Item0 * alpha),
        SaturateCast.ToInt32(Item1 * alpha));

    /// <summary>
    /// this / alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec2i Divide(double alpha) => new(
        SaturateCast.ToInt32(Item0 / alpha),
        SaturateCast.ToInt32(Item1 / alpha));

#pragma warning disable 1591
    public static Vec2i operator +(Vec2i a, Vec2i b) => a.Add(b);
    public static Vec2i operator -(Vec2i a, Vec2i b) => a.Subtract(b);
    public static Vec2i operator *(Vec2i a, double alpha) => a.Multiply(alpha);
    public static Vec2i operator /(Vec2i a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

    /// <summary>
    /// Indexer
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public int this[int i]
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
    public Vec2f ToVec2f() => new(Item0, Item1);
    public Vec2d ToVec2d() => new(Item0, Item1);
    // ReSharper restore InconsistentNaming
#pragma warning restore 1591

    /// <inheritdoc />
    public readonly bool Equals(Vec2i other)
    {
        return Item0 == other.Item0 &&
               Item1 == other.Item1;
    }

    /// <inheritdoc />
    public override readonly bool Equals(object? obj)
    {
        if (obj is null) return false;
        return obj is Vec2i v && Equals(v);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Vec2i a, Vec2i b)
    {
        return a.Equals(b);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Vec2i a, Vec2i b)
    {
        return !a.Equals(b);
    }

    /// <inheritdoc />
    public override readonly int GetHashCode()
    {
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
            unchecked
            {
                return (Item0 * 397) ^ Item1;
            }
#else
        return HashCode.Combine(Item0, Item1);
#endif
    }

    /// <inheritdoc />
    public override readonly string ToString()
    {
        return $"{nameof(Vec2i)} ({Item0}, {Item1})";
    }
}
