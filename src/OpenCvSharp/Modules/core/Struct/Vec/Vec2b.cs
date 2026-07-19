using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// 2-Tuple of byte (System.Byte)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
// ReSharper disable once InconsistentNaming
public record struct Vec2b(byte Item0, byte Item1)
{
    /// <summary>
    /// The value of the first component of this object.
    /// </summary>
    public byte Item0 = Item0;

    /// <summary>
    /// The value of the second component of this object.
    /// </summary>
    public byte Item1 = Item1;

    /// <summary>
    /// returns a Vec with all elements set to v0
    /// </summary>
    /// <param name="v0"></param>
    /// <returns></returns>
    public static Vec2b All(byte v0) => new(v0, v0);

    #region Operators

    /// <summary>
    /// this + other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec2b Add(Vec2b other) => new(
        SaturateCast.ToByte(Item0 + other.Item0),
        SaturateCast.ToByte(Item1 + other.Item1));

    /// <summary>
    /// this - other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec2b Subtract(Vec2b other) => new(
        SaturateCast.ToByte(Item0 - other.Item0),
        SaturateCast.ToByte(Item1 - other.Item1));

    /// <summary>
    /// this * alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec2b Multiply(double alpha) => new(
        SaturateCast.ToByte(Item0 * alpha),
        SaturateCast.ToByte(Item1 * alpha));

    /// <summary>
    /// this / alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec2b Divide(double alpha) => new(
        SaturateCast.ToByte(Item0 / alpha),
        SaturateCast.ToByte(Item1 / alpha));

#pragma warning disable 1591
    public static Vec2b operator +(Vec2b a, Vec2b b) => a.Add(b);
    public static Vec2b operator -(Vec2b a, Vec2b b) => a.Subtract(b);
    public static Vec2b operator *(Vec2b a, double alpha) => a.Multiply(alpha);
    public static Vec2b operator /(Vec2b a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

    /// <summary>
    /// Indexer
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public byte this[int i]
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
    public Vec2s ToVec2s() => new(Item0, Item1);
    public Vec2w ToVec2w() => new(Item0, Item1);
    public Vec2i ToVec2i() => new(Item0, Item1);
    public Vec2f ToVec2f() => new(Item0, Item1);
    public Vec2d ToVec2d() => new(Item0, Item1);
    // ReSharper restore InconsistentNaming
#pragma warning restore 1591

    /// <summary>Returns a <see cref="Span{T}"/> over the 2 elements of this vector.</summary>
    public Span<byte> AsSpan() => MemoryMarshal.CreateSpan(ref Item0, 2);
}
