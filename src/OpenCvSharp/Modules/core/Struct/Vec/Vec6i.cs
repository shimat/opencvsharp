using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// 6-Tuple of int (System.Int32)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
// ReSharper disable once InconsistentNaming
public record struct Vec6i(int Item0, int Item1, int Item2, int Item3, int Item4, int Item5) : IVec<Vec6i, int>
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

    /// <summary>
    /// The value of the fourth component of this object.
    /// </summary>
    public int Item3 = Item3;

    /// <summary>
    /// The value of the fifth component of this object.
    /// </summary>
    public int Item4 = Item4;

    /// <summary>
    /// The value of the sixth component of this object.
    /// </summary>
    public int Item5 = Item5;

    #region Operators

    /// <summary>
    /// this + other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec6i Add(Vec6i other) => new(
        SaturateCast.ToInt32(Item0 + other.Item0),
        SaturateCast.ToInt32(Item1 + other.Item1),
        SaturateCast.ToInt32(Item2 + other.Item2),
        SaturateCast.ToInt32(Item3 + other.Item3),
        SaturateCast.ToInt32(Item4 + other.Item4),
        SaturateCast.ToInt32(Item5 + other.Item5));

    /// <summary>
    /// this - other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec6i Subtract(Vec6i other) => new(
        SaturateCast.ToInt32(Item0 - other.Item0),
        SaturateCast.ToInt32(Item1 - other.Item1),
        SaturateCast.ToInt32(Item2 - other.Item2),
        SaturateCast.ToInt32(Item3 - other.Item3),
        SaturateCast.ToInt32(Item4 - other.Item4),
        SaturateCast.ToInt32(Item5 - other.Item5));

    /// <summary>
    /// this * alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec6i Multiply(double alpha) => new(
        SaturateCast.ToInt32(Item0 * alpha),
        SaturateCast.ToInt32(Item1 * alpha),
        SaturateCast.ToInt32(Item2 * alpha),
        SaturateCast.ToInt32(Item3 * alpha),
        SaturateCast.ToInt32(Item4 * alpha),
        SaturateCast.ToInt32(Item5 * alpha));

    /// <summary>
    /// this / alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec6i Divide(double alpha) => new(
        SaturateCast.ToInt32(Item0 / alpha),
        SaturateCast.ToInt32(Item1 / alpha),
        SaturateCast.ToInt32(Item2 / alpha),
        SaturateCast.ToInt32(Item3 / alpha),
        SaturateCast.ToInt32(Item4 / alpha),
        SaturateCast.ToInt32(Item5 / alpha));

#pragma warning disable 1591
    public static Vec6i operator +(Vec6i a, Vec6i b) => a.Add(b);
    public static Vec6i operator -(Vec6i a, Vec6i b) => a.Subtract(b);
    public static Vec6i operator *(Vec6i a, double alpha) => a.Multiply(alpha);
    public static Vec6i operator /(Vec6i a, double alpha) => a.Divide(alpha);
    public static Vec6i operator -(Vec6i a) => new(SaturateCast.ToInt32(-(long)a.Item0), SaturateCast.ToInt32(-(long)a.Item1), SaturateCast.ToInt32(-(long)a.Item2), SaturateCast.ToInt32(-(long)a.Item3), SaturateCast.ToInt32(-(long)a.Item4), SaturateCast.ToInt32(-(long)a.Item5));
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
                3 => Item3,
                4 => Item4,
                5 => Item5,
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };
        set
        {
            switch (i)
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
    public Vec6f ToVec6f() => new(Item0, Item1, Item2, Item3, Item4, Item5);
    public Vec6d ToVec6d() => new(Item0, Item1, Item2, Item3, Item4, Item5);
    // ReSharper restore InconsistentNaming
#pragma warning restore 1591

    /// <summary>Returns a <see cref="Span{T}"/> over the 6 elements of this vector.</summary>
    public Span<int> AsSpan() => MemoryMarshal.CreateSpan(ref Item0, 6);
}
