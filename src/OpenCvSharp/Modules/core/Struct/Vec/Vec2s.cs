using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

#pragma warning disable CA1051

namespace OpenCvSharp
{
    /// <summary>
    /// 2-Tuple of short (System.Int16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec2s : IVec<Vec2s, short>, IEquatable<Vec2s>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public readonly short Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public readonly short Item1;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        public void Deconstruct(out short item0, out short item1) => (item0, item1) = (Item0, Item1);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        public Vec2s(short item0, short item1)
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
        public Vec2s Add(Vec2s other) => new Vec2s(
            SaturateCast.ToInt16(Item0 + other.Item0),
            SaturateCast.ToInt16(Item1 + other.Item1));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec2s Subtract(Vec2s other) => new Vec2s(
            SaturateCast.ToInt16(Item0 - other.Item0),
            SaturateCast.ToInt16(Item1 - other.Item1));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec2s Multiply(double alpha) => new Vec2s(
            SaturateCast.ToInt16(Item0 * alpha),
            SaturateCast.ToInt16(Item1 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec2s Divide(double alpha) => new Vec2s(
            SaturateCast.ToInt16(Item0 / alpha),
            SaturateCast.ToInt16(Item1 / alpha));

#pragma warning disable 1591
        public static Vec2s operator +(Vec2s self) => self;
        public static Vec2s operator -(Vec2s self) => self.Multiply(-1);
        public static Vec2s operator +(Vec2s a, Vec2s b) => a.Add(b);
        public static Vec2s operator -(Vec2s a, Vec2s b) => a.Subtract(b);
        public static Vec2s operator *(Vec2s a, double alpha) => a.Multiply(alpha);
        public static Vec2s operator /(Vec2s a, double alpha) => a.Divide(alpha);
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
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        //public Vec6b ToVec6b() => new Vec6b((byte)Item0, (byte)Item1, (byte)Item2, (byte)Item3, (byte)Item4, (byte)Item5);
        public Vec2w ToVec2w() => new Vec2w((ushort)Item0, (ushort)Item1);
        public Vec2i ToVec2i() => new Vec2i(Item0, Item1);
        public Vec2f ToVec2f() => new Vec2f(Item0, Item1);
        public Vec2d ToVec2d() => new Vec2d(Item0, Item1);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591


        /// <inheritdoc />
        public bool Equals(Vec2s other)
        {
            return Item0 == other.Item0 && Item1 == other.Item1;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec2s v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec2s a, Vec2s b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec2s a, Vec2s b)
        {
            return !a.Equals(b);
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