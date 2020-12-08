using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 6-Tuple of float (System.Single)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec6f : IVec<Vec6f, float>, IEquatable<Vec6f>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public readonly float Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public readonly float Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public readonly float Item2;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public readonly float Item3;

        /// <summary>
        /// The value of the fifth component of this object.
        /// </summary>
        public readonly float Item4;

        /// <summary>
        /// The value of the sixth component of this object.
        /// </summary>
        public readonly float Item5;

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
        public void Deconstruct(out float item0, out float item1, out float item2, out float item3, out float item4, out float item5) => (item0, item1, item2, item3, item4, item5) = (Item0, Item1, Item2, Item3, Item4, Item5);
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
        public Vec6f(float item0, float item1, float item2, float item3, float item4, float item5)
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
        public Vec6f Add(Vec6f other) => new Vec6f(
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
        public Vec6f Subtract(Vec6f other) => new Vec6f(
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
        public Vec6f Multiply(double alpha) => new Vec6f(
            (float)(Item0 * alpha),
            (float)(Item1 * alpha),
            (float)(Item2 * alpha),
            (float)(Item3 * alpha),
            (float)(Item4 * alpha),
            (float)(Item5 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec6f Divide(double alpha) => new Vec6f(
            (float)(Item0 / alpha),
            (float)(Item1 / alpha),
            (float)(Item2 / alpha),
            (float)(Item3 / alpha),
            (float)(Item4 / alpha),
            (float)(Item5 / alpha));

#pragma warning disable 1591
        public static Vec6f operator +(Vec6f self) => self;
        public static Vec6f operator -(Vec6f self) => new Vec6f(-self.Item0, -self.Item1, -self.Item2, -self.Item3, -self.Item4, -self.Item5);
        public static Vec6f operator +(Vec6f a, Vec6f b) => a.Add(b);
        public static Vec6f operator -(Vec6f a, Vec6f b) => a.Subtract(b);
        public static Vec6f operator *(Vec6f a, double alpha) => a.Multiply(alpha);
        public static Vec6f operator /(Vec6f a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public float this[int i] =>
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
        public Vec6i ToVec6i() => new Vec6i((int)Item0, (int)Item1, (int)Item2, (int)Item3, (int)Item4, (int)Item5);
        public Vec6d ToVec6d() => new Vec6d(Item0, Item1, Item2, Item3, Item4, Item5);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591

        /// <inheritdoc />
        public bool Equals(Vec6f other)
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
            return obj is Vec6f v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec6f a, Vec6f b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec6f a, Vec6f b)
        {
            return !a.Equals(b);
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
