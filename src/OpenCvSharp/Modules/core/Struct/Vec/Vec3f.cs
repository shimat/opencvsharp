using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
/// 3-Tuple of float (System.Single)
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
// ReSharper disable once InconsistentNaming
public struct Vec3f : IVec<Vec3f, float>, IEquatable<Vec3f>
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
    /// The value of the third component of this object.
    /// </summary>
    public float Item2;

    /// <summary>
    /// Deconstructing a Vector
    /// </summary>
    /// <param name="item0"></param>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    public readonly void Deconstruct(out float item0, out float item1, out float item2) => (item0, item1, item2) = (Item0, Item1, Item2);

    /// <summary>
    /// Initializer
    /// </summary>
    /// <param name="item0"></param>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    public Vec3f(float item0, float item1, float item2)
    {
        Item0 = item0;
        Item1 = item1;
        Item2 = item2;
    }

    #region Operators

    /// <summary>
    /// this + other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec3f Add(Vec3f other) => new(
        Item0 + other.Item0,
        Item1 + other.Item1,
        Item2 + other.Item2);

    /// <summary>
    /// this - other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec3f Subtract(Vec3f other) => new(
        Item0 - other.Item0,
        Item1 - other.Item1,
        Item2 - other.Item2);

    /// <summary>
    /// this * alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec3f Multiply(double alpha) => new(
        (float)(Item0 * alpha),
        (float)(Item1 * alpha),
        (float)(Item2 * alpha));

    /// <summary>
    /// this / alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec3f Divide(double alpha) => new(
        (float)(Item0 / alpha),
        (float)(Item1 / alpha),
        (float)(Item2 / alpha));

#pragma warning disable 1591
    public static Vec3f operator +(Vec3f a, Vec3f b) => a.Add(b);
    public static Vec3f operator -(Vec3f a, Vec3f b) => a.Subtract(b);
    public static Vec3f operator *(Vec3f a, double alpha) => a.Multiply(alpha);
    public static Vec3f operator /(Vec3f a, double alpha) => a.Divide(alpha);
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
                2 => Item2,
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };
        }
        set
        {
            switch (i)
            {
                case 0: Item0 = value; break;
                case 1: Item1 = value; break;
                case 2: Item2 = value; break;
                default: throw new ArgumentOutOfRangeException(nameof(i));
            }
        }
    }

    #endregion

#pragma warning disable 1591
    // ReSharper disable InconsistentNaming
    public Vec3i ToVec3i() => new((int)Item0, (int)Item1, (int)Item2);
    public Vec3d ToVec3d() => new(Item0, Item1, Item2);
    // ReSharper restore InconsistentNaming
#pragma warning restore 1591

    /// <inheritdoc />
    public readonly bool Equals(Vec3f other)
    {
        return Item0.Equals(other.Item0) && Item1.Equals(other.Item1) && Item2.Equals(other.Item2);
    }

    /// <inheritdoc />
    public override readonly bool Equals(object? obj)
    {
        if (obj is null) return false;
        return obj is Vec3f v && Equals(v);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Vec3f a, Vec3f b)
    {
        return a.Equals(b);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Vec3f a, Vec3f b)
    {
        return !(a == b);
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
            return hashCode;
        }
#else
            return HashCode.Combine(Item0, Item1, Item2);
#endif
    }

    /// <inheritdoc />
    public override readonly string ToString()
    {
        return $"{nameof(Vec3f)} ({Item0}, {Item1}, {Item2})";
    }
}
