using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 3-Tuple of int (System.Int32)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec3i : IVec<Vec3i, int>, IEquatable<Vec3i>
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

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public void Deconstruct(out int item0, out int item1, out int item2) 
            => (item0, item1, item2) = (Item0, Item1, Item2);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public Vec3i(int item0, int item1, int item2)
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
        public Vec3i Add(Vec3i other) => new Vec3i(
            SaturateCast.ToInt32(Item0 + other.Item0),
            SaturateCast.ToInt32(Item1 + other.Item1),
            SaturateCast.ToInt32(Item2 + other.Item2));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec3i Subtract(Vec3i other) => new Vec3i(
            SaturateCast.ToInt32(Item0 - other.Item0),
            SaturateCast.ToInt32(Item1 - other.Item1),
            SaturateCast.ToInt32(Item2 - other.Item2));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec3i Multiply(double alpha) => new Vec3i(
            SaturateCast.ToInt32(Item0 * alpha),
            SaturateCast.ToInt32(Item1 * alpha),
            SaturateCast.ToInt32(Item2 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec3i Divide(double alpha) => new Vec3i(
            SaturateCast.ToInt32(Item0 / alpha),
            SaturateCast.ToInt32(Item1 / alpha),
            SaturateCast.ToInt32(Item2 / alpha));

#pragma warning disable 1591
        public static Vec3i operator +(Vec3i self) => self;
        public static Vec3i operator -(Vec3i self) => new Vec3i(-self.Item0, -self.Item1, -self.Item2);
        public static Vec3i operator +(Vec3i a, Vec3i b) => a.Add(b);
        public static Vec3i operator -(Vec3i a, Vec3i b) => a.Subtract(b);
        public static Vec3i operator *(Vec3i a, double alpha) => a.Multiply(alpha);
        public static Vec3i operator /(Vec3i a, double alpha) => a.Divide(alpha);
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
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        public Vec3f ToVec3f() => new Vec3f(Item0, Item1, Item2);
        public Vec3d ToVec3d() => new Vec3d(Item0, Item1, Item2);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591


        /// <inheritdoc />
        public bool Equals(Vec3i other)
        {
            return Item0 == other.Item0 &&
                   Item1 == other.Item1 &&
                   Item2 == other.Item2;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec3i v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec3i a, Vec3i b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec3i a, Vec3i b)
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