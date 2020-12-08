using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 4-Tuple of ushort (System.UInt16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec4w : IVec<Vec4w, ushort>, IEquatable<Vec4w>
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

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public readonly ushort Item3;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public void Deconstruct(out ushort item0, out ushort item1, out ushort item2, out ushort item3) 
            => (item0, item1, item2, item3) = (Item0, Item1, Item2, Item3);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public Vec4w(ushort item0, ushort item1, ushort item2, ushort item3)
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
        public Vec4w Add(Vec4w other) => new Vec4w(
            SaturateCast.ToUInt16(Item0 + other.Item0),
            SaturateCast.ToUInt16(Item1 + other.Item1),
            SaturateCast.ToUInt16(Item2 + other.Item2),
            SaturateCast.ToUInt16(Item3 + other.Item3));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec4w Subtract(Vec4w other) => new Vec4w(
            SaturateCast.ToUInt16(Item0 - other.Item0),
            SaturateCast.ToUInt16(Item1 - other.Item1),
            SaturateCast.ToUInt16(Item2 - other.Item2),
            SaturateCast.ToUInt16(Item3 - other.Item3));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec4w Multiply(double alpha) => new Vec4w(
            SaturateCast.ToUInt16(Item0 * alpha),
            SaturateCast.ToUInt16(Item1 * alpha),
            SaturateCast.ToUInt16(Item2 * alpha),
            SaturateCast.ToUInt16(Item3 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec4w Divide(double alpha) => new Vec4w(
            SaturateCast.ToUInt16(Item0 / alpha),
            SaturateCast.ToUInt16(Item1 / alpha),
            SaturateCast.ToUInt16(Item2 / alpha),
            SaturateCast.ToUInt16(Item3 / alpha));

#pragma warning disable 1591
        public static Vec4w operator +(Vec4w self) => self;
        public static Vec4w operator +(Vec4w a, Vec4w b) => a.Add(b);
        public static Vec4w operator -(Vec4w a, Vec4w b) => a.Subtract(b);
        public static Vec4w operator *(Vec4w a, double alpha) => a.Multiply(alpha);
        public static Vec4w operator /(Vec4w a, double alpha) => a.Divide(alpha);
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
                3 => Item3,
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        //public Vec6b ToVec6b() => new Vec6b((byte)Item0, (byte)Item1, (byte)Item2, (byte)Item3, (byte)Item4, (byte)Item5);
        public Vec4s ToVec4s() => new Vec4s((short)Item0, (short)Item1, (short)Item2, (short)Item3);
        public Vec4i ToVec4i() => new Vec4i(Item0, Item1, Item2, Item3);
        public Vec4f ToVec4f() => new Vec4f(Item0, Item1, Item2, Item3);
        public Vec4d ToVec4d() => new Vec4d(Item0, Item1, Item2, Item3);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591

        /// <inheritdoc />
        public bool Equals(Vec4w other)
        {
            return Item0 == other.Item0 &&
                   Item1 == other.Item1 && 
                   Item2 == other.Item2 && 
                   Item3 == other.Item3;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec4w v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec4w a, Vec4w b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec4w a, Vec4w b)
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