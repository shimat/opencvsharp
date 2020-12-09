using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 4-Tuple of int (System.Int32)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec4i : IVec<Vec4i, int>, IEquatable<Vec4i>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public readonly int Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public readonly int Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public readonly int Item2;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public readonly int Item3;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public void Deconstruct(out int item0, out int item1, out int item2, out int item3)
            => (item0, item1, item2, item3) = (Item0, Item1, Item2, Item3);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public Vec4i(int item0, int item1, int item2, int item3)
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
        public Vec4i Add(Vec4i other) => new Vec4i(
            SaturateCast.ToInt32(Item0 + other.Item0),
            SaturateCast.ToInt32(Item1 + other.Item1),
            SaturateCast.ToInt32(Item2 + other.Item2),
            SaturateCast.ToInt32(Item3 + other.Item3));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec4i Subtract(Vec4i other) => new Vec4i(
            SaturateCast.ToInt32(Item0 - other.Item0),
            SaturateCast.ToInt32(Item1 - other.Item1),
            SaturateCast.ToInt32(Item2 - other.Item2),
            SaturateCast.ToInt32(Item3 - other.Item3));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec4i Multiply(double alpha) => new Vec4i(
            SaturateCast.ToInt32(Item0 * alpha),
            SaturateCast.ToInt32(Item1 * alpha),
            SaturateCast.ToInt32(Item2 * alpha),
            SaturateCast.ToInt32(Item3 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec4i Divide(double alpha) => new Vec4i(
            SaturateCast.ToInt32(Item0 / alpha),
            SaturateCast.ToInt32(Item1 / alpha),
            SaturateCast.ToInt32(Item2 / alpha),
            SaturateCast.ToInt32(Item3 / alpha));

#pragma warning disable 1591
        public static Vec4i operator +(Vec4i self) => self;
        public static Vec4i operator -(Vec4i self) => new Vec4i(-self.Item0, -self.Item1, -self.Item2, -self.Item3);
        public static Vec4i operator +(Vec4i a, Vec4i b) => a.Add(b);
        public static Vec4i operator -(Vec4i a, Vec4i b) => a.Subtract(b);
        public static Vec4i operator *(Vec4i a, double alpha) => a.Multiply(alpha);
        public static Vec4i operator /(Vec4i a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int this[int i] =>
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
        public Vec4f ToVec4f() => new Vec4f(Item0, Item1, Item2, Item3);
        public Vec4d ToVec4d() => new Vec4d(Item0, Item1, Item2, Item3);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591

        /// <inheritdoc />
        public bool Equals(Vec4i other)
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
            return obj is Vec4i v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec4i a, Vec4i b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec4i a, Vec4i b)
        {
            return !a.Equals(b);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
            unchecked
            {
                var hashCode = Item0;
                hashCode = (hashCode * 397) ^ Item1;
                hashCode = (hashCode * 397) ^ Item2;
                hashCode = (hashCode * 397) ^ Item3;
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