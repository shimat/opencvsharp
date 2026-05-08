using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// 2-Tuple of float (System.Single)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
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
    public static Vec2f operator -(Vec2f a) => new(-a.Item0, -a.Item1);
#pragma warning restore 1591

    /// <summary>
    /// Indexer
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public float this[int i]
    {
        readonly get =>
            i switch
            {
                0 => Item0,
                1 => Item1,
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };
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

#if !NETSTANDARD2_0
    /// <summary>Returns a <see cref="Span{T}"/> over the 2 elements of this vector.</summary>
    public Span<float> AsSpan() => MemoryMarshal.CreateSpan(ref Item0, 2);
#endif

    /// <inheritdoc />
    public readonly bool Equals(Vec2f other) => Item0.Equals(other.Item0) && Item1.Equals(other.Item1);

    /// <inheritdoc />
    public readonly override bool Equals(object? obj)
    {
        if (obj is null) return false;
        return obj is Vec2f v && Equals(v);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Vec2f a, Vec2f b) => a.Item0 == b.Item0 && a.Item1 == b.Item1;

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Vec2f a, Vec2f b) => a.Item0 != b.Item0 || a.Item1 != b.Item1;

    /// <inheritdoc />
    public readonly override int GetHashCode()
    {
#if NETSTANDARD2_0
        unchecked
        {
            return (Item0.GetHashCode() * 397) ^ Item1.GetHashCode();
        }
#else
        return HashCode.Combine(Item0, Item1);
#endif
    }

    /// <inheritdoc />
    public readonly override string ToString() => $"{nameof(Vec2f)} ({Item0}, {Item1})";
}
