using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 4-Tuple of short (System.Int16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec4s : IVec<Vec4s, short>, IEquatable<Vec4s>
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

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public readonly short Item3;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public void Deconstruct(out short item0, out short item1, out short item2, out short item3) 
            => (item0, item1, item2, item3) = (Item0, Item1, Item2, Item3);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public Vec4s(short item0, short item1, short item2, short item3)
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
        public Vec4s Add(Vec4s other) => new Vec4s(
            SaturateCast.ToInt16(Item0 + other.Item0),
            SaturateCast.ToInt16(Item1 + other.Item1),
            SaturateCast.ToInt16(Item2 + other.Item2),
            SaturateCast.ToInt16(Item3 + other.Item3));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec4s Subtract(Vec4s other) => new Vec4s(
            SaturateCast.ToInt16(Item0 - other.Item0),
            SaturateCast.ToInt16(Item1 - other.Item1),
            SaturateCast.ToInt16(Item2 - other.Item2),
            SaturateCast.ToInt16(Item3 - other.Item3));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec4s Multiply(double alpha) => new Vec4s(
            SaturateCast.ToInt16(Item0 * alpha),
            SaturateCast.ToInt16(Item1 * alpha),
            SaturateCast.ToInt16(Item2 * alpha),
            SaturateCast.ToInt16(Item3 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec4s Divide(double alpha) => new Vec4s(
            SaturateCast.ToInt16(Item0 / alpha),
            SaturateCast.ToInt16(Item1 / alpha),
            SaturateCast.ToInt16(Item2 / alpha),
            SaturateCast.ToInt16(Item3 / alpha));

#pragma warning disable 1591
        public static Vec4s operator +(Vec4s self) => self;
        public static Vec4s operator -(Vec4s self) => self.Multiply(-1);
        public static Vec4s operator +(Vec4s a, Vec4s b) => a.Add(b);
        public static Vec4s operator -(Vec4s a, Vec4s b) => a.Subtract(b);
        public static Vec4s operator *(Vec4s a, double alpha) => a.Multiply(alpha);
        public static Vec4s operator /(Vec4s a, double alpha) => a.Divide(alpha);
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
                3 => Item3,
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        //public Vec6b ToVec6b() => new Vec6b((byte)Item0, (byte)Item1, (byte)Item2, (byte)Item3, (byte)Item4, (byte)Item5);
        public Vec4w ToVec4w() => new Vec4w((ushort)Item0, (ushort)Item1, (ushort)Item2, (ushort)Item3);
        public Vec4i ToVec4i() => new Vec4i(Item0, Item1, Item2, Item3);
        public Vec4f ToVec4f() => new Vec4f(Item0, Item1, Item2, Item3);
        public Vec4d ToVec4d() => new Vec4d(Item0, Item1, Item2, Item3);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591


        /// <inheritdoc />
        public bool Equals(Vec4s other)
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
            return obj is Vec4s v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec4s a, Vec4s b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec4s a, Vec4s b)
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