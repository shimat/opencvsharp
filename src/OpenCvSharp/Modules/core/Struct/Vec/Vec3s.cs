using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 3-Tuple of short (System.Int16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec3s : IVec<Vec3s, short>, IEquatable<Vec3s>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public readonly short Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public readonly short Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public readonly short Item2;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public void Deconstruct(out short item0, out short item1, out short item2) => (item0, item1, item2) = (Item0, Item1, Item2);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public Vec3s(short item0, short item1, short item2)
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
        public Vec3s Add(Vec3s other) => new Vec3s(
            SaturateCast.ToInt16(Item0 + other.Item0),
            SaturateCast.ToInt16(Item1 + other.Item1),
            SaturateCast.ToInt16(Item2 + other.Item2));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec3s Subtract(Vec3s other) => new Vec3s(
            SaturateCast.ToInt16(Item0 - other.Item0),
            SaturateCast.ToInt16(Item1 - other.Item1),
            SaturateCast.ToInt16(Item2 - other.Item2));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec3s Multiply(double alpha) => new Vec3s(
            SaturateCast.ToInt16(Item0 * alpha),
            SaturateCast.ToInt16(Item1 * alpha),
            SaturateCast.ToInt16(Item2 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec3s Divide(double alpha) => new Vec3s(
            SaturateCast.ToInt16(Item0 / alpha),
            SaturateCast.ToInt16(Item1 / alpha),
            SaturateCast.ToInt16(Item2 / alpha));

#pragma warning disable 1591
        public static Vec3s operator +(Vec3s self) => self;
        public static Vec3s operator -(Vec3s self) => self.Multiply(-1);
        public static Vec3s operator +(Vec3s a, Vec3s b) => a.Add(b);
        public static Vec3s operator -(Vec3s a, Vec3s b) => a.Subtract(b);
        public static Vec3s operator *(Vec3s a, double alpha) => a.Multiply(alpha);
        public static Vec3s operator /(Vec3s a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public short this[int i] =>
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
        //public Vec6b ToVec6b() => new Vec6b((byte)Item0, (byte)Item1, (byte)Item2, (byte)Item3, (byte)Item4, (byte)Item5);
        public Vec3w ToVec3w() => new Vec3w((ushort)Item0, (ushort)Item1, (ushort)Item2);
        public Vec3i ToVec3i() => new Vec3i(Item0, Item1, Item2);
        public Vec3f ToVec3f() => new Vec3f(Item0, Item1, Item2);
        public Vec3d ToVec3d() => new Vec3d(Item0, Item1, Item2);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591


        /// <inheritdoc />
        public bool Equals(Vec3s other)
        {
            return Item0 == other.Item0 &&
                   Item1 == other.Item1 &&
                   Item2 == other.Item2;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec3s v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec3s a, Vec3s b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec3s a, Vec3s b)
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