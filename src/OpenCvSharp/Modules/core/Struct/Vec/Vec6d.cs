using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 6-Tuple of double (System.Double)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Vec6d : IVec<Vec6d, double>, IEquatable<Vec6d>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public readonly double Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public readonly double Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public readonly double Item2;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public readonly double Item3;

        /// <summary>
        /// The value of the fifth component of this object.
        /// </summary>
        public readonly double Item4;

        /// <summary>
        /// The value of the sixth component of this object.
        /// </summary>
        public readonly double Item5;

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
        public void Deconstruct(out double item0, out double item1, out double item2, out double item3, out double item4, out double item5) 
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
        public Vec6d(double item0, double item1, double item2, double item3, double item4, double item5)
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
        public Vec6d Add(Vec6d other) => new Vec6d(
            Item0 + other.Item0,
            Item1 + other.Item1,
            Item2 + other.Item2,
            Item3 + other.Item3,
            Item4 + other.Item4,
            Item5 + other.Item5);

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec6d Subtract(Vec6d other) => new Vec6d(
            Item0 - other.Item0,
            Item1 - other.Item1,
            Item2 - other.Item2,
            Item3 - other.Item3,
            Item4 - other.Item4,
            Item5 - other.Item5);

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec6d Multiply(double alpha) => new Vec6d(
            Item0 * alpha,
            Item1 * alpha,
            Item2 * alpha,
            Item3 * alpha,
            Item4 * alpha,
            Item5 * alpha);

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec6d Divide(double alpha) => new Vec6d(
            Item0 / alpha,
            Item1 / alpha,
            Item2 / alpha,
            Item3 / alpha,
            Item4 / alpha,
            Item5 / alpha);

#pragma warning disable 1591
        public static Vec6d operator +(Vec6d self) => self;
        public static Vec6d operator -(Vec6d self) => new Vec6d(-self.Item0, -self.Item1, -self.Item2, -self.Item3, -self.Item4, -self.Item5);
        public static Vec6d operator +(Vec6d a, Vec6d b) => a.Add(b);
        public static Vec6d operator -(Vec6d a, Vec6d b) => a.Subtract(b);
        public static Vec6d operator *(Vec6d a, double alpha) => a.Multiply(alpha);
        public static Vec6d operator /(Vec6d a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double this[int i]
        {
            get
            {
                return i switch
                {
                    0 => Item0,
                    1 => Item1,
                    2 => Item2,
                    3 => Item3,
                    4 => Item4,
                    5 => Item5,
                    _ => throw new ArgumentOutOfRangeException(nameof(i))
                };
            }
        }

        #endregion
        
        /// <inheritdoc />
        public bool Equals(Vec6d other)
        {
            return Item0.Equals(other.Item0) && 
                   Item1.Equals(other.Item1) &&
                   Item2.Equals(other.Item2) && 
                   Item3.Equals(other.Item3) && 
                   Item4.Equals(other.Item4) &&
                   Item5.Equals(other.Item5);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec6d v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec6d a, Vec6d b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec6d a, Vec6d b)
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
