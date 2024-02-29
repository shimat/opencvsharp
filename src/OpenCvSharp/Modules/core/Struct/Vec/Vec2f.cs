using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
/// 2-Tuple of float (System.Single)
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
// ReSharper disable once InconsistentNaming
public struct Vec2f : IVec<Vec2f, float>, IEquatable<Vec2f>
{
    /// <summary>
    /// The value of the first component of this object.
    /// </summary>
    public float Item0;

    /// <summary>
    /// The value of the second component of this object.
    /// </summary>
    public float Item1;

    /// <summary>
    /// Deconstructing a Vector
    /// </summary>
    /// <param name="item0"></param>
    /// <param name="item1"></param>
    public readonly void Deconstruct(out float item0, out float item1) => (item0, item1) = (Item0, Item1);

    /// <summary>
    /// Initializer
    /// </summary>
    /// <param name="item0"></param>
    /// <param name="item1"></param>
    public Vec2f(float item0, float item1)
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
    public readonly Vec2f Add(Vec2f other) => new(
        Item0 + other.Item0,
        Item1 + other.Item1);

    /// <summary>
    /// this - other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec2f Subtract(Vec2f other) => new(
        Item0 - other.Item0,
        Item1 - other.Item1);

    /// <summary>
    /// this * alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec2f Multiply(double alpha) => new(
        (float)(Item0 * alpha),
        (float)(Item1 * alpha));

    /// <summary>
    /// this / alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec2f Divide(double alpha) => new(
        (float)(Item0 / alpha),
        (float)(Item1 / alpha));

#pragma warning disable 1591
    public static Vec2f operator +(Vec2f a, Vec2f b) => a.Add(b);
    public static Vec2f operator -(Vec2f a, Vec2f b) => a.Subtract(b);
    public static Vec2f operator *(Vec2f a, double alpha) => a.Multiply(alpha);
    public static Vec2f operator /(Vec2f a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

    /// <summary>
    /// Indexer
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public float this[int i]
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
    public Vec2i ToVec2i() => new((int)Item0, (int)Item1);
    public Vec2d ToVec2d() => new(Item0, Item1);
    // ReSharper restore InconsistentNaming
#pragma warning restore 1591

    /// <inheritdoc />
    public readonly bool Equals(Vec2f other)
    {
        return Item0.Equals(other.Item0) && Item1.Equals(other.Item1);
    }

    /// <inheritdoc />
    public override readonly bool Equals(object? obj)
    {
        if (obj is null) return false;
        return obj is Vec2f v && Equals(v);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Vec2f a, Vec2f b)
    {
        return a.Equals(b);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Vec2f a, Vec2f b)
    {
        return !(a == b);
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
        return $"{nameof(Vec2f)} ({Item0}, {Item1})";
    }
}
