using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 4-Tuple of float (System.Single)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec4f : IVec<Vec4f, float>, IEquatable<Vec4f>
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

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public void Deconstruct(out float item0, out float item1, out float item2, out float item3) 
            => (item0, item1, item2, item3) = (Item0, Item1, Item2, Item3);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public Vec4f(float item0, float item1, float item2, float item3)
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
        public Vec4f Add(Vec4f other) => new Vec4f(
            Item0 + other.Item0,
            Item1 + other.Item1,
            Item2 + other.Item2,
            Item3 + other.Item3);

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec4f Subtract(Vec4f other) => new Vec4f(
            Item0 - other.Item0,
            Item1 - other.Item1,
            Item2 - other.Item2,
            Item3 - other.Item3);

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec4f Multiply(double alpha) => new Vec4f(
            (float)(Item0 * alpha),
            (float)(Item1 * alpha),
            (float)(Item2 * alpha),
            (float)(Item3 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec4f Divide(double alpha) => new Vec4f(
            (float)(Item0 / alpha),
            (float)(Item1 / alpha),
            (float)(Item2 / alpha),
            (float)(Item3 / alpha));

#pragma warning disable 1591
        public static Vec4f operator +(Vec4f self) => self;
        public static Vec4f operator -(Vec4f self) => new Vec4f(-self.Item0, -self.Item1, -self.Item2, -self.Item3);
        public static Vec4f operator +(Vec4f a, Vec4f b) => a.Add(b);
        public static Vec4f operator -(Vec4f a, Vec4f b) => a.Subtract(b);
        public static Vec4f operator *(Vec4f a, double alpha) => a.Multiply(alpha);
        public static Vec4f operator /(Vec4f a, double alpha) => a.Divide(alpha);
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
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        public Vec4i ToVec4i() => new Vec4i((int)Item0, (int)Item1, (int)Item2, (int)Item3);
        public Vec4d ToVec4d() => new Vec4d(Item0, Item1, Item2, Item3);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591

        /// <inheritdoc />
        public bool Equals(Vec4f other)
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
            return obj is Vec4f v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec4f a, Vec4f b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec4f a, Vec4f b)
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