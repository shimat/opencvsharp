using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// 2-Tuple of double (System.Double)
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public struct Vec2d : IVec<Vec2d, double>, IEquatable<Vec2d>
{
    /// <summary>
    /// The value of the first component of this object.
    /// </summary>
    public double Item0;

    /// <summary>
    /// The value of the second component of this object.
    /// </summary>
    public double Item1;

    /// <summary>
    /// Deconstructing a Vector
    /// </summary>
    /// <param name="item0"></param>
    /// <param name="item1"></param>
    public readonly void Deconstruct(out double item0, out double item1) => (item0, item1) = (Item0, Item1);

    /// <summary>
    /// Initializer
    /// </summary>
    /// <param name="item0"></param>
    /// <param name="item1"></param>
    public Vec2d(double item0, double item1)
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
    public readonly Vec2d Add(Vec2d other) => new(
        Item0 + other.Item0,
        Item1 + other.Item1);

    /// <summary>
    /// this - other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec2d Subtract(Vec2d other) => new(
        Item0 - other.Item0,
        Item1 - other.Item1);

    /// <summary>
    /// this * alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec2d Multiply(double alpha) => new(
        Item0 * alpha,
        Item1 * alpha);

    /// <summary>
    /// this / alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec2d Divide(double alpha) => new(
        Item0 / alpha,
        Item1 / alpha);

#pragma warning disable 1591
    public static Vec2d operator +(Vec2d a, Vec2d b) => a.Add(b);
    public static Vec2d operator -(Vec2d a, Vec2d b) => a.Subtract(b);
    public static Vec2d operator *(Vec2d a, double alpha) => a.Multiply(alpha);
    public static Vec2d operator /(Vec2d a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

    /// <summary>
    /// Indexer
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public double this[int i]
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

    /// <inheritdoc />
    public readonly bool Equals(Vec2d other)
    {
        return Item0.Equals(other.Item0) && Item1.Equals(other.Item1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override readonly bool Equals(object? obj)
    {
        if (obj is null) return false;
        return obj is Vec2d v && Equals(v);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Vec2d a, Vec2d b)
    {
        return a.Equals(b);
    }

    /// <summary> 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Vec2d a, Vec2d b)
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
        return $"{nameof(Vec2d)} ({Item0}, {Item1})";
    }
}
