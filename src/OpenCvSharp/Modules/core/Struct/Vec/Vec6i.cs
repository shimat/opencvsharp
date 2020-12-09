using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 6-Tuple of int (System.Int32)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec6i : IVec<Vec6i, int>, IEquatable<Vec6i>
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

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public readonly int Item4;

        /// <summary>
        /// The value of the sixth component of this object.
        /// </summary>
        public readonly int Item5;

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
        public void Deconstruct(out int item0, out int item1, out int item2, out int item3, out int item4, out int item5) 
            => (item0, item1, item2, item3, item4, item5) = (Item0, Item1, Item2, Item3, Item4, Item5);
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
        public Vec6i(int item0, int item1, int item2, int item3, int item4, int item5)
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
        public Vec6i Add(Vec6i other) => new Vec6i(
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
        public Vec6i Subtract(Vec6i other) => new Vec6i(
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
        public Vec6i Multiply(double alpha) => new Vec6i(
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
        public Vec6i Divide(double alpha) => new Vec6i(
            SaturateCast.ToInt32(Item0 / alpha),
            SaturateCast.ToInt32(Item1 / alpha),
            SaturateCast.ToInt32(Item2 / alpha),
            SaturateCast.ToInt32(Item3 / alpha),
            SaturateCast.ToInt32(Item4 / alpha),
            SaturateCast.ToInt32(Item5 / alpha));

#pragma warning disable 1591
        public static Vec6i operator +(Vec6i self) => self;
        public static Vec6i operator -(Vec6i self) => new Vec6i(-self.Item0, -self.Item1, -self.Item2, -self.Item3, -self.Item4, -self.Item5);
        public static Vec6i operator +(Vec6i a, Vec6i b) => a.Add(b);
        public static Vec6i operator -(Vec6i a, Vec6i b) => a.Subtract(b);
        public static Vec6i operator *(Vec6i a, double alpha) => a.Multiply(alpha);
        public static Vec6i operator /(Vec6i a, double alpha) => a.Divide(alpha);
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
                4 => Item4,
                5 => Item5,
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        public Vec6f ToVec6f() => new Vec6f(Item0, Item1, Item2, Item3, Item4, Item5);
        public Vec6d ToVec6d() => new Vec6d(Item0, Item1, Item2, Item3, Item4, Item5);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591

        /// <inheritdoc />
        public bool Equals(Vec6i other)
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
            return obj is Vec6i v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec6i a, Vec6i b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec6i a, Vec6i b)
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
                hashCode = (hashCode * 397) ^ Item4;
                hashCode = (hashCode * 397) ^ Item5;
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
