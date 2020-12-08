using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 4-Tuple of double (System.Double)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Vec4d : IVec<Vec4d, double>, IEquatable<Vec4d>
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

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public void Deconstruct(out double item0, out double item1, out double item2, out double item3) 
            => (item0, item1, item2, item3) = (Item0, Item1, Item2, Item3);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public Vec4d(double item0, double item1, double item2, double item3)
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
        public Vec4d Add(Vec4d other) => new Vec4d(
            Item0 + other.Item0,
            Item1 + other.Item1,
            Item2 + other.Item2,
            Item3 + other.Item3);

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec4d Subtract(Vec4d other) => new Vec4d(
            Item0 - other.Item0,
            Item1 - other.Item1,
            Item2 - other.Item2,
            Item3 - other.Item3);

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec4d Multiply(double alpha) => new Vec4d(
            Item0 * alpha,
            Item1 * alpha,
            Item2 * alpha,
            Item3 * alpha);

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec4d Divide(double alpha) => new Vec4d(
            Item0 / alpha,
            Item1 / alpha,
            Item2 / alpha,
            Item3 / alpha);

#pragma warning disable 1591
        public static Vec4d operator +(Vec4d self) => self;
        public static Vec4d operator -(Vec4d self) => new Vec4d(-self.Item0, -self.Item1, -self.Item2, -self.Item3);
        public static Vec4d operator +(Vec4d a, Vec4d b) => a.Add(b);
        public static Vec4d operator -(Vec4d a, Vec4d b) => a.Subtract(b);
        public static Vec4d operator *(Vec4d a, double alpha) => a.Multiply(alpha);
        public static Vec4d operator /(Vec4d a, double alpha) => a.Divide(alpha);
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
                    _ => throw new ArgumentOutOfRangeException(nameof(i))
                };
            }
        }

        #endregion


        /// <inheritdoc />
        public bool Equals(Vec4d other)
        {
            return Item0.Equals(other.Item0) &&
                   Item1.Equals(other.Item1) &&
                   Item2.Equals(other.Item2) && 
                   Item3.Equals(other.Item3);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec4d v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec4d a, Vec4d b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec4d a, Vec4d b)
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