using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

#pragma warning disable CA1051

namespace OpenCvSharp
{
    /// <summary>
    /// 4-Tuple of byte (System.Byte)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec4b : IVec<Vec4b, byte>, IEquatable<Vec4b>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public readonly byte Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public readonly byte Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public readonly byte Item2;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public readonly byte Item3;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public void Deconstruct(out byte item0, out byte item1, out byte item2, out byte item3) => (item0, item1, item2, item3) = (Item0, Item1, Item2, Item3);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public Vec4b(byte item0, byte item1, byte item2, byte item3)
        {
            Item0 = item0;
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        #region Operators

        /// <summary>
        /// this + other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec4b Add(Vec4b other) => new Vec4b(
            SaturateCast.ToByte(Item0 + other.Item0),
            SaturateCast.ToByte(Item1 + other.Item1),
            SaturateCast.ToByte(Item2 + other.Item2),
            SaturateCast.ToByte(Item3 + other.Item3));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec4b Subtract(Vec4b other) => new Vec4b(
            SaturateCast.ToByte(Item0 - other.Item0),
            SaturateCast.ToByte(Item1 - other.Item1),
            SaturateCast.ToByte(Item2 - other.Item2),
            SaturateCast.ToByte(Item3 - other.Item3));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec4b Multiply(double alpha) => new Vec4b(
            SaturateCast.ToByte(Item0 * alpha),
            SaturateCast.ToByte(Item1 * alpha),
            SaturateCast.ToByte(Item2 * alpha),
            SaturateCast.ToByte(Item3 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec4b Divide(double alpha) => new Vec4b(
            SaturateCast.ToByte(Item0 / alpha),
            SaturateCast.ToByte(Item1 / alpha),
            SaturateCast.ToByte(Item2 / alpha),
            SaturateCast.ToByte(Item3 / alpha));

#pragma warning disable 1591
        public static Vec4b operator +(Vec4b self) => self;
        public static Vec4b operator +(Vec4b a, Vec4b b) => a.Add(b);
        public static Vec4b operator -(Vec4b a, Vec4b b) => a.Subtract(b);
        public static Vec4b operator *(Vec4b a, double alpha) => a.Multiply(alpha);
        public static Vec4b operator /(Vec4b a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public byte this[int i] =>
            i switch
            {
                0 => Item0,
                1 => Item1,
                2 => Item2,
                3 => Item3,
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        public Vec4s ToVec4s() => new Vec4s(Item0, Item1, Item2, Item3);
        public Vec4w ToVec4w() => new Vec4w(Item0, Item1, Item2, Item3);
        public Vec4i ToVec4i() => new Vec4i(Item0, Item1, Item2, Item3);
        public Vec4f ToVec4f() => new Vec4f(Item0, Item1, Item2, Item3);
        public Vec4d ToVec4d() => new Vec4d(Item0, Item1, Item2, Item3);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591

        /// <inheritdoc />
        public bool Equals(Vec4b other)
        {
            return Item0 == other.Item0 &&
                   Item1 == other.Item1 && 
                   Item2 == other.Item2 &&
                   Item3 == other.Item3;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec4b v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec4b a, Vec4b b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec4b a, Vec4b b)
        {
            return !(a == b);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
            unchecked
            {
                var hashCode = Item0.GetHashCode();
                hashCode = (hashCode * 397) ^ Item1.GetHashCode();
                hashCode = (hashCode * 397) ^ Item2.GetHashCode();
                hashCode = (hashCode * 397) ^ Item3.GetHashCode();
                return hashCode;
            }
#else
            return HashCode.Combine(Item0, Item1, Item2, Item3);
#endif
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{GetType().Name} ({Item0}, {Item1}, {Item2}, {Item3})";
        }
    }
}