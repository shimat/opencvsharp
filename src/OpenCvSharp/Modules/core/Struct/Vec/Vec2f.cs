using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 2-Tuple of float (System.Single)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec2f : IVec<Vec2f, float>, IEquatable<Vec2f>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public readonly float Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public readonly float Item1;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        public void Deconstruct(out float item0, out float item1) => (item0, item1) = (Item0, Item1);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        public Vec2f(float item0, float item1)
        {
            Item0 = item0;
            Item1 = item1;
        }

        #region Operators

        /// <summary>
        /// this + other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec2f Add(Vec2f other) => new Vec2f(
            Item0 + other.Item0,
            Item1 + other.Item1);

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec2f Subtract(Vec2f other) => new Vec2f(
            Item0 - other.Item0,
            Item1 - other.Item1);

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec2f Multiply(double alpha) => new Vec2f(
            (float)(Item0 * alpha),
            (float)(Item1 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec2f Divide(double alpha) => new Vec2f(
            (float)(Item0 / alpha),
            (float)(Item1 / alpha));

#pragma warning disable 1591
        public static Vec2f operator +(Vec2f self) => self;
        public static Vec2f operator -(Vec2f self) => new Vec2f(-self.Item0, -self.Item1);
        public static Vec2f operator +(Vec2f a, Vec2f b) => a.Add(b);
        public static Vec2f operator -(Vec2f a, Vec2f b) => a.Subtract(b);
        public static Vec2f operator *(Vec2f a, double alpha) => a.Multiply(alpha);
        public static Vec2f operator /(Vec2f a, double alpha) => a.Divide(alpha);
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
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        public Vec2i ToVec2i() => new Vec2i((int)Item0, (int)Item1);
        public Vec2d ToVec2d() => new Vec2d(Item0, Item1);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591


        /// <inheritdoc />
        public bool Equals(Vec2f other)
        {
            return Item0.Equals(other.Item0) && Item1.Equals(other.Item1);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec2f v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec2f a, Vec2f b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec2f a, Vec2f b)
        {
            return !(a == b);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
            unchecked
            {
                return (Item0.GetHashCode() * 397) ^ Item1.GetHashCode();
            }
#else
            return HashCode.Combine(Item0, Item1);
#endif
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{GetType().Name} ({Item0}, {Item1})";
        }
    }
}