using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// 3-Tuple of int (System.Int32)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
// ReSharper disable once InconsistentNaming
public record struct Vec3i(int Item0, int Item1, int Item2) : IVec<Vec3i, int>
{
    /// <summary>
    /// The value of the first component of this object.
    /// </summary>
    public int Item0 = Item0;

    /// <summary>
    /// The value of the second component of this object.
    /// </summary>
    public int Item1 = Item1;

    /// <summary>
    /// The value of the third component of this object.
    /// </summary>
    public int Item2 = Item2;

    #region Operators

    /// <summary>
    /// this + other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec3i Add(Vec3i other) => new(
        SaturateCast.ToInt32(Item0 + other.Item0),
        SaturateCast.ToInt32(Item1 + other.Item1),
        SaturateCast.ToInt32(Item2 + other.Item2));

    /// <summary>
    /// this - other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec3i Subtract(Vec3i other) => new(
        SaturateCast.ToInt32(Item0 - other.Item0),
        SaturateCast.ToInt32(Item1 - other.Item1),
        SaturateCast.ToInt32(Item2 - other.Item2));

    /// <summary>
    /// this * alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec3i Multiply(double alpha) => new(
        SaturateCast.ToInt32(Item0 * alpha),
        SaturateCast.ToInt32(Item1 * alpha),
        SaturateCast.ToInt32(Item2 * alpha));

    /// <summary>
    /// this / alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec3i Divide(double alpha) => new(
        SaturateCast.ToInt32(Item0 / alpha),
        SaturateCast.ToInt32(Item1 / alpha),
        SaturateCast.ToInt32(Item2 / alpha));

#pragma warning disable 1591
    public static Vec3i operator +(Vec3i a, Vec3i b) => a.Add(b);
    public static Vec3i operator -(Vec3i a, Vec3i b) => a.Subtract(b);
    public static Vec3i operator *(Vec3i a, double alpha) => a.Multiply(alpha);
    public static Vec3i operator /(Vec3i a, double alpha) => a.Divide(alpha);
    public static Vec3i operator -(Vec3i a) => new(SaturateCast.ToInt32(-(long)a.Item0), SaturateCast.ToInt32(-(long)a.Item1), SaturateCast.ToInt32(-(long)a.Item2));
#pragma warning restore 1591

    /// <summary>
    /// Indexer
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public int this[int i]
    {
        readonly get =>
            i switch
            {
                0 => Item0,
                1 => Item1,
                2 => Item2,
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };
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
    public Vec3f ToVec3f() => new(Item0, Item1, Item2);
    public Vec3d ToVec3d() => new(Item0, Item1, Item2);
    // ReSharper restore InconsistentNaming
#pragma warning restore 1591

    /// <summary>Returns a <see cref="Span{T}"/> over the 3 elements of this vector.</summary>
    public Span<int> AsSpan() => MemoryMarshal.CreateSpan(ref Item0, 3);
}
