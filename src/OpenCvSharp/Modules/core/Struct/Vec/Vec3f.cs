using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 3-Tuple of float (System.Single)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec3f : IVec<Vec3f, float>, IEquatable<Vec3f>
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

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public void Deconstruct(out float item0, out float item1, out float item2) 
            => (item0, item1, item2) = (Item0, Item1, Item2);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public Vec3f(float item0, float item1, float item2)
        {
            Item0 = item0;
            Item1 = item1;
            Item2 = item2;
        }

        #region Operators

        /// <summary>
        /// this + other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec3f Add(Vec3f other) => new Vec3f(
            Item0 + other.Item0,
            Item1 + other.Item1,
            Item2 + other.Item2);

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec3f Subtract(Vec3f other) => new Vec3f(
            Item0 - other.Item0,
            Item1 - other.Item1,
            Item2 - other.Item2);

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec3f Multiply(double alpha) => new Vec3f(
            (float)(Item0 * alpha),
            (float)(Item1 * alpha),
            (float)(Item2 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec3f Divide(double alpha) => new Vec3f(
            (float)(Item0 / alpha),
            (float)(Item1 / alpha),
            (float)(Item2 / alpha));

#pragma warning disable 1591
        public static Vec3f operator +(Vec3f self) => self;
        public static Vec3f operator -(Vec3f self) => new Vec3f(-self.Item0, -self.Item1, -self.Item2);
        public static Vec3f operator +(Vec3f a, Vec3f b) => a.Add(b);
        public static Vec3f operator -(Vec3f a, Vec3f b) => a.Subtract(b);
        public static Vec3f operator *(Vec3f a, double alpha) => a.Multiply(alpha);
        public static Vec3f operator /(Vec3f a, double alpha) => a.Divide(alpha);
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
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        public Vec3i ToVec3i() => new Vec3i((int)Item0, (int)Item1, (int)Item2);
        public Vec3d ToVec3d() => new Vec3d(Item0, Item1, Item2);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591


        /// <inheritdoc />
        public bool Equals(Vec3f other)
        {
            return Item0.Equals(other.Item0) && Item1.Equals(other.Item1) && Item2.Equals(other.Item2);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec3f v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec3f a, Vec3f b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec3f a, Vec3f b)
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
                return hashCode;
            }
#else
            return HashCode.Combine(Item0, Item1, Item2);
#endif
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{GetType().Name} ({Item0}, {Item1}, {Item2})";
        }
    }
}