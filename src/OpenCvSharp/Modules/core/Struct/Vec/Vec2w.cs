using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// 2-Tuple of ushort (System.UInt16)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
// ReSharper disable once InconsistentNaming
public record struct Vec2w(ushort Item0, ushort Item1)
{
    /// <summary>
    /// The value of the first component of this object.
    /// </summary>
    public ushort Item0 = Item0;

    /// <summary>
    /// The value of the second component of this object.
    /// </summary>
    public ushort Item1 = Item1;

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
    //public Vec6b ToVec6b() => new Vec6b((byte)Item0, (byte)Item1, (byte)Item2, (byte)Item3, (byte)Item4, (byte)Item5);
    public Vec2s ToVec2s() => new((short)Item0, (short)Item1);
    public Vec2i ToVec2i() => new(Item0, Item1);
    public Vec2f ToVec2f() => new(Item0, Item1);
    public Vec2d ToVec2d() => new(Item0, Item1);
    // ReSharper restore InconsistentNaming
#pragma warning restore 1591

    /// <summary>Returns a <see cref="Span{T}"/> over the 2 elements of this vector.</summary>
    public Span<ushort> AsSpan() => MemoryMarshal.CreateSpan(ref Item0, 2);
}
