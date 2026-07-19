using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// 3-Tuple of byte (System.Byte)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
// ReSharper disable once InconsistentNaming
public record struct Vec3b(byte Item0, byte Item1, byte Item2)
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
    /// The value of the third component of this object.
    /// </summary>
    public byte Item2 = Item2;

    #region Operators

    /// <summary>
    /// this + other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec3b Add(Vec3b other) => new(
        SaturateCast.ToByte(Item0 + other.Item0),
        SaturateCast.ToByte(Item1 + other.Item1),
        SaturateCast.ToByte(Item2 + other.Item2));

    /// <summary>
    /// this - other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Vec3b Subtract(Vec3b other) => new(
        SaturateCast.ToByte(Item0 - other.Item0),
        SaturateCast.ToByte(Item1 - other.Item1),
        SaturateCast.ToByte(Item2 - other.Item2));

    /// <summary>
    /// this * alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec3b Multiply(double alpha) => new(
        SaturateCast.ToByte(Item0 * alpha),
        SaturateCast.ToByte(Item1 * alpha),
        SaturateCast.ToByte(Item2 * alpha));

    /// <summary>
    /// this / alpha
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public readonly Vec3b Divide(double alpha) => new(
        SaturateCast.ToByte(Item0 / alpha),
        SaturateCast.ToByte(Item1 / alpha),
        SaturateCast.ToByte(Item2 / alpha));

#pragma warning disable 1591
    public static Vec3b operator +(Vec3b a, Vec3b b) => a.Add(b);
    public static Vec3b operator -(Vec3b a, Vec3b b) => a.Subtract(b);
    public static Vec3b operator *(Vec3b a, double alpha) => a.Multiply(alpha);
    public static Vec3b operator /(Vec3b a, double alpha) => a.Divide(alpha);
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
    public Vec3s ToVec3s() => new(Item0, Item1, Item2);
    public Vec3w ToVec3w() => new(Item0, Item1, Item2);
    public Vec3i ToVec3i() => new(Item0, Item1, Item2);
    public Vec3f ToVec3f() => new(Item0, Item1, Item2);
    public Vec3d ToVec3d() => new(Item0, Item1, Item2);
    // ReSharper restore InconsistentNaming
#pragma warning restore 1591

    /// <summary>Returns a <see cref="Span{T}"/> over the 3 elements of this vector.</summary>
    public Span<byte> AsSpan() => MemoryMarshal.CreateSpan(ref Item0, 3);
}
