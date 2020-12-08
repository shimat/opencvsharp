using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 3-Tuple of ushort (System.UInt16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec3w : IVec<Vec3w, ushort>, IEquatable<Vec3w>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public readonly ushort Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public readonly ushort Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public readonly ushort Item2;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public void Deconstruct(out ushort item0, out ushort item1, out ushort item2)
            => (item0, item1, item2) = (Item0, Item1, Item2);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public Vec3w(ushort item0, ushort item1, ushort item2)
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
        public Vec3w Add(Vec3w other) => new Vec3w(
            SaturateCast.ToUInt16(Item0 + other.Item0),
            SaturateCast.ToUInt16(Item1 + other.Item1),
            SaturateCast.ToUInt16(Item2 + other.Item2));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec3w Subtract(Vec3w other) => new Vec3w(
            SaturateCast.ToUInt16(Item0 - other.Item0),
            SaturateCast.ToUInt16(Item1 - other.Item1),
            SaturateCast.ToUInt16(Item2 - other.Item2));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec3w Multiply(double alpha) => new Vec3w(
            SaturateCast.ToUInt16(Item0 * alpha),
            SaturateCast.ToUInt16(Item1 * alpha),
            SaturateCast.ToUInt16(Item2 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec3w Divide(double alpha) => new Vec3w(
            SaturateCast.ToUInt16(Item0 / alpha),
            SaturateCast.ToUInt16(Item1 / alpha),
            SaturateCast.ToUInt16(Item2 / alpha));

#pragma warning disable 1591
        public static Vec3w operator +(Vec3w self) => self;
        public static Vec3w operator +(Vec3w a, Vec3w b) => a.Add(b);
        public static Vec3w operator -(Vec3w a, Vec3w b) => a.Subtract(b);
        public static Vec3w operator *(Vec3w a, double alpha) => a.Multiply(alpha);
        public static Vec3w operator /(Vec3w a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public ushort this[int i] =>
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
        public Vec3s ToVec3s() => new Vec3s((short)Item0, (short)Item1, (short)Item2);
        public Vec3i ToVec3i() => new Vec3i(Item0, Item1, Item2);
        public Vec3f ToVec3f() => new Vec3f(Item0, Item1, Item2);
        public Vec3d ToVec3d() => new Vec3d(Item0, Item1, Item2);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591


        /// <inheritdoc />
        public bool Equals(Vec3w other)
        {
            return Item0 == other.Item0 &&
                   Item1 == other.Item1 &&
                   Item2 == other.Item2;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec3w v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec3w a, Vec3w b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec3w a, Vec3w b)
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