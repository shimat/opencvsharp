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
    public readonly struct Vec6w : IVec<Vec6w, ushort>, IEquatable<Vec6w>
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

        /// <summary>
        /// The value of the fifth component of this object.
        /// </summary>
        public readonly ushort Item4;

        /// <summary>
        /// The value of the sixth component of this object.
        /// </summary>
        public readonly ushort Item5;

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
        public void Deconstruct(out ushort item0, out ushort item1, out ushort item2, out ushort item3, out ushort item4, out ushort item5) 
            => (item0, item1, item2, item3, item4, item5) = (Item0, Item1, Item2, Item3, Item4, Item5);
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
        public Vec6w(ushort item0, ushort item1, ushort item2, ushort item3, ushort item4, ushort item5)
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
        public Vec6w Add(Vec6w other) => new Vec6w(
            SaturateCast.ToUInt16(Item0 + other.Item0),
            SaturateCast.ToUInt16(Item1 + other.Item1),
            SaturateCast.ToUInt16(Item2 + other.Item2),
            SaturateCast.ToUInt16(Item3 + other.Item3),
            SaturateCast.ToUInt16(Item4 + other.Item4),
            SaturateCast.ToUInt16(Item5 + other.Item5));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec6w Subtract(Vec6w other) => new Vec6w(
            SaturateCast.ToUInt16(Item0 - other.Item0),
            SaturateCast.ToUInt16(Item1 - other.Item1),
            SaturateCast.ToUInt16(Item2 - other.Item2),
            SaturateCast.ToUInt16(Item3 - other.Item3),
            SaturateCast.ToUInt16(Item4 - other.Item4),
            SaturateCast.ToUInt16(Item5 - other.Item5));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec6w Multiply(double alpha) => new Vec6w(
            SaturateCast.ToUInt16(Item0 * alpha),
            SaturateCast.ToUInt16(Item1 * alpha),
            SaturateCast.ToUInt16(Item2 * alpha),
            SaturateCast.ToUInt16(Item3 * alpha),
            SaturateCast.ToUInt16(Item4 * alpha),
            SaturateCast.ToUInt16(Item5 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec6w Divide(double alpha) => new Vec6w(
            SaturateCast.ToUInt16(Item0 / alpha),
            SaturateCast.ToUInt16(Item1 / alpha),
            SaturateCast.ToUInt16(Item2 / alpha),
            SaturateCast.ToUInt16(Item3 / alpha),
            SaturateCast.ToUInt16(Item4 / alpha),
            SaturateCast.ToUInt16(Item5 / alpha));

#pragma warning disable 1591
        public static Vec6w operator +(Vec6w self) => self;
        public static Vec6w operator +(Vec6w a, Vec6w b) => a.Add(b);
        public static Vec6w operator -(Vec6w a, Vec6w b) => a.Subtract(b);
        public static Vec6w operator *(Vec6w a, double alpha) => a.Multiply(alpha);
        public static Vec6w operator /(Vec6w a, double alpha) => a.Divide(alpha);
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
                4 => Item4,
                5 => Item5,
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        //public Vec6b ToVec6b() => new Vec6b((byte)Item0, (byte)Item1, (byte)Item2, (byte)Item3, (byte)Item4, (byte)Item5);
        public Vec6s ToVec6s() => new Vec6s((short)Item0, (short)Item1, (short)Item2, (short)Item3, (short)Item4, (short)Item5);
        public Vec6i ToVec6i() => new Vec6i(Item0, Item1, Item2, Item3, Item4, Item5);
        public Vec6f ToVec6f() => new Vec6f(Item0, Item1, Item2, Item3, Item4, Item5);
        public Vec6d ToVec6d() => new Vec6d(Item0, Item1, Item2, Item3, Item4, Item5);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591

        /// <inheritdoc />
        public bool Equals(Vec6w other)
        {
            return Item0 == other.Item0 && 
                   Item1 == other.Item1 &&
                   Item2 == other.Item2 && 
                   Item3 == other.Item3 &&
                   Item4 == other.Item4 &&
                   Item5 == other.Item5;
        }
        
        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec6w v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec6w a, Vec6w b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec6w a, Vec6w b)
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
