using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// 4-Tuple of ushort (System.UInt16)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
// ReSharper disable once InconsistentNaming
public record struct Vec4w(ushort Item0, ushort Item1, ushort Item2, ushort Item3)
{
    /// <summary>
    /// The value of the first component of this object.
    /// </summary>
    public ushort Item0 = Item0;

    /// <summary>
    /// The value of the second component of this object.
    /// </summary>
    public ushort Item1 = Item1;

    /// <summary>
    /// The value of the third component of this object.
    /// </summary>
    public ushort Item2 = Item2;

    /// <summary>
    /// The value of the fourth component of this object.
    /// </summary>
    public ushort Item3 = Item3;

    #region Operators

    /// <summary>
    /// this + other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec4w Add(Vec4w other) => new(
        SaturateCast.ToUInt16(Item0 + other.Item0),
        SaturateCast.ToUInt16(Item1 + other.Item1),
        SaturateCast.ToUInt16(Item2 + other.Item2),
        SaturateCast.ToUInt16(Item3 + other.Item3));

    /// <summary>
    /// this - other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec4w Subtract(Vec4w other) => new(
        SaturateCast.ToUInt16(Item0 - other.Item0),
        SaturateCast.ToUInt16(Item1 - other.Item1),
        SaturateCast.ToUInt16(Item2 - other.Item2),
        SaturateCast.ToUInt16(Item3 - other.Item3));

    /// <summary>
    /// this * alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec4w Multiply(double alpha) => new(
        SaturateCast.ToUInt16(Item0 * alpha),
        SaturateCast.ToUInt16(Item1 * alpha),
        SaturateCast.ToUInt16(Item2 * alpha),
        SaturateCast.ToUInt16(Item3 * alpha));

    /// <summary>
    /// this / alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec4w Divide(double alpha) => new(
        SaturateCast.ToUInt16(Item0 / alpha),
        SaturateCast.ToUInt16(Item1 / alpha),
        SaturateCast.ToUInt16(Item2 / alpha),
        SaturateCast.ToUInt16(Item3 / alpha));

#pragma warning disable 1591
    public static Vec4w operator +(Vec4w a, Vec4w b) => a.Add(b);
    public static Vec4w operator -(Vec4w a, Vec4w b) => a.Subtract(b);
    public static Vec4w operator *(Vec4w a, double alpha) => a.Multiply(alpha);
    public static Vec4w operator /(Vec4w a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

    /// <summary>
    /// Indexer
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public ushort this[int i]
    {
        readonly get =>
            i switch
            {
                0 => Item0,
                1 => Item1,
                2 => Item2,
                3 => Item3,
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
                default: throw new ArgumentOutOfRangeException(nameof(i));
            }
        }
    }

    #endregion

#pragma warning disable 1591
    // ReSharper disable InconsistentNaming
    //public Vec6b ToVec6b() => new Vec6b((byte)Item0, (byte)Item1, (byte)Item2, (byte)Item3, (byte)Item4, (byte)Item5);
    public Vec4s ToVec4s() => new((short)Item0, (short)Item1, (short)Item2, (short)Item3);
    public Vec4i ToVec4i() => new(Item0, Item1, Item2, Item3);
    public Vec4f ToVec4f() => new(Item0, Item1, Item2, Item3);
    public Vec4d ToVec4d() => new(Item0, Item1, Item2, Item3);
    // ReSharper restore InconsistentNaming
#pragma warning restore 1591

    /// <summary>Returns a <see cref="Span{T}"/> over the 4 elements of this vector.</summary>
    public Span<ushort> AsSpan() => MemoryMarshal.CreateSpan(ref Item0, 4);
}
