using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 2-Tuple of int (System.Int32)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec2i : IVec<Vec2i, int>, IEquatable<Vec2i>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public readonly int Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public readonly int Item1;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        public void Deconstruct(out int item0, out int item1) 
            => (item0, item1) = (Item0, Item1);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        public Vec2i(int item0, int item1)
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
        public Vec2i Add(Vec2i other) => new Vec2i(
            SaturateCast.ToInt32(Item0 + other.Item0),
            SaturateCast.ToInt32(Item1 + other.Item1));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec2i Subtract(Vec2i other) => new Vec2i(
            SaturateCast.ToInt32(Item0 - other.Item0),
            SaturateCast.ToInt32(Item1 - other.Item1));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec2i Multiply(double alpha) => new Vec2i(
            SaturateCast.ToInt32(Item0 * alpha),
            SaturateCast.ToInt32(Item1 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec2i Divide(double alpha) => new Vec2i(
            SaturateCast.ToInt32(Item0 / alpha),
            SaturateCast.ToInt32(Item1 / alpha));

#pragma warning disable 1591
        public static Vec2i operator +(Vec2i self) => self;
        public static Vec2i operator -(Vec2i self) => new Vec2i(-self.Item0, -self.Item1);
        public static Vec2i operator +(Vec2i a, Vec2i b) => a.Add(b);
        public static Vec2i operator -(Vec2i a, Vec2i b) => a.Subtract(b);
        public static Vec2i operator *(Vec2i a, double alpha) => a.Multiply(alpha);
        public static Vec2i operator /(Vec2i a, double alpha) => a.Divide(alpha);
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
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        public Vec2f ToVec2f() => new Vec2f(Item0, Item1);
        public Vec2d ToVec2d() => new Vec2d(Item0, Item1);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591


        /// <inheritdoc />
        public bool Equals(Vec2i other)
        {
            return Item0 == other.Item0 &&
                   Item1 == other.Item1;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec2i v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec2i a, Vec2i b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec2i a, Vec2i b)
        {
            return !a.Equals(b);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
            unchecked
            {
                return (Item0 * 397) ^ Item1;
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