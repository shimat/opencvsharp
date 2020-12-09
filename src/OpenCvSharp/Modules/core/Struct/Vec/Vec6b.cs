using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 6-Tuple of byte (System.Byte)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec6b : IVec<Vec6b, byte>, IEquatable<Vec6b>
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

        /// <summary>
        /// The value of the fifth component of this object.
        /// </summary>
        public readonly byte Item4;

        /// <summary>
        /// The value of the sixth component of this object.
        /// </summary>
        public readonly byte Item5;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        public void Deconstruct(out byte item0, out byte item1, out byte item2, out byte item3, out byte item4, out byte item5) => (item0, item1, item2, item3, item4, item5) = (Item0, Item1, Item2, Item3, Item4, Item5);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        public Vec6b(byte item0, byte item1, byte item2, byte item3, byte item4, byte item5)
        {
            Item0 = item0;
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
            Item5 = item5;
        }

        #region Operators

        /// <summary>
        /// this + other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec6b Add(Vec6b other) => new Vec6b(
            SaturateCast.ToByte(Item0 + other.Item0),
            SaturateCast.ToByte(Item1 + other.Item1),
            SaturateCast.ToByte(Item2 + other.Item2),
            SaturateCast.ToByte(Item3 + other.Item3),
            SaturateCast.ToByte(Item4 + other.Item4),
            SaturateCast.ToByte(Item5 + other.Item5));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec6b Subtract(Vec6b other) => new Vec6b(
            SaturateCast.ToByte(Item0 - other.Item0),
            SaturateCast.ToByte(Item1 - other.Item1),
            SaturateCast.ToByte(Item2 - other.Item2),
            SaturateCast.ToByte(Item3 - other.Item3),
            SaturateCast.ToByte(Item4 - other.Item4),
            SaturateCast.ToByte(Item5 - other.Item5));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec6b Multiply(double alpha) => new Vec6b(
            SaturateCast.ToByte(Item0 * alpha),
            SaturateCast.ToByte(Item1 * alpha),
            SaturateCast.ToByte(Item2 * alpha),
            SaturateCast.ToByte(Item3 * alpha),
            SaturateCast.ToByte(Item4 * alpha),
            SaturateCast.ToByte(Item5 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec6b Divide(double alpha) => new Vec6b(
            SaturateCast.ToByte(Item0 / alpha),
            SaturateCast.ToByte(Item1 / alpha),
            SaturateCast.ToByte(Item2 / alpha),
            SaturateCast.ToByte(Item3 / alpha),
            SaturateCast.ToByte(Item4 / alpha),
            SaturateCast.ToByte(Item5 / alpha));

#pragma warning disable 1591
        public static Vec6b operator +(Vec6b self) => self;
        public static Vec6b operator +(Vec6b a, Vec6b b) => a.Add(b);
        public static Vec6b operator -(Vec6b a, Vec6b b) => a.Subtract(b);
        public static Vec6b operator *(Vec6b a, double alpha) => a.Multiply(alpha);
        public static Vec6b operator /(Vec6b a, double alpha) => a.Divide(alpha);
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
                4 => Item4,
                5 => Item5,
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        public Vec6s ToVec6s() => new Vec6s(Item0, Item1, Item2, Item3, Item4, Item5);
        public Vec6w ToVec6w() => new Vec6w(Item0, Item1, Item2, Item3, Item4, Item5);
        public Vec6i ToVec6i() => new Vec6i(Item0, Item1, Item2, Item3, Item4, Item5);
        public Vec6f ToVec6f() => new Vec6f(Item0, Item1, Item2, Item3, Item4, Item5);
        public Vec6d ToVec6d() => new Vec6d(Item0, Item1, Item2, Item3, Item4, Item5);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591

        /// <inheritdoc />
        public bool Equals(Vec6b other)
        {
            return Item0 == other.Item0 &&
                   Item1 == other.Item1 && 
                   Item2 == other.Item2 && 
                   Item3 == other.Item3 && 
                   Item4 == other.Item4 && 
                   Item5 == other.Item5;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec6b v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec6b a, Vec6b b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec6b a, Vec6b b)
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
                hashCode = (hashCode * 397) ^ Item4.GetHashCode();
                hashCode = (hashCode * 397) ^ Item5.GetHashCode();
                return hashCode;
            }
#else
            return HashCode.Combine(Item0, Item1, Item2, Item3, Item4, Item5);
#endif
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{GetType().Name} ({Item0}, {Item1}, {Item2}, {Item3}, {Item4}, {Item5})";
        }
    }
}
