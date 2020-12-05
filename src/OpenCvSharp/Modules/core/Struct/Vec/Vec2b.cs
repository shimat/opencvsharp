using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 2-Tuple of byte (System.Byte)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public readonly struct Vec2b : IVec<Vec2b, byte>, IEquatable<Vec2b>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public readonly byte Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public readonly byte Item1;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        public void Deconstruct(out byte item0, out byte item1) => (item0, item1) = (Item0, Item1);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        public Vec2b(byte item0, byte item1)
        {
            Item0 = item0;
            Item1 = item1;
        }

        /// <summary>
        /// returns a Vec with all elements set to v0
        /// </summary>
        /// <param name="v0"></param>
        /// <returns></returns>
        public static Vec2b All(byte v0) => new Vec2b(v0, v0);

        #region Operators

        /// <summary>
        /// this + other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec2b Add(Vec2b other) => new Vec2b(
            SaturateCast.ToByte(Item0 + other.Item0),
            SaturateCast.ToByte(Item1 + other.Item1));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec2b Subtract(Vec2b other) => new Vec2b(
            SaturateCast.ToByte(Item0 - other.Item0),
            SaturateCast.ToByte(Item1 - other.Item1));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec2b Multiply(double alpha) => new Vec2b(
            SaturateCast.ToByte(Item0 * alpha),
            SaturateCast.ToByte(Item1 * alpha));

        /// <summary>
        /// this / alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec2b Divide(double alpha) => new Vec2b(
            SaturateCast.ToByte(Item0 / alpha),
            SaturateCast.ToByte(Item1 / alpha));

#pragma warning disable 1591
        public static Vec2b operator +(Vec2b self) => self;
        public static Vec2b operator +(Vec2b a, Vec2b b) => a.Add(b);
        public static Vec2b operator -(Vec2b a, Vec2b b) => a.Subtract(b);
        public static Vec2b operator *(Vec2b a, double alpha) => a.Multiply(alpha);
        public static Vec2b operator /(Vec2b a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public byte this[int i] =>
            i switch
            {
                0 => Item0,
                1 => Item1,
                _ => throw new ArgumentOutOfRangeException(nameof(i))
            };

        #endregion

#pragma warning disable 1591
        // ReSharper disable InconsistentNaming
        public Vec2s ToVec2s() => new Vec2s(Item0, Item1);
        public Vec2w ToVec2w() => new Vec2w(Item0, Item1);
        public Vec2i ToVec2i() => new Vec2i(Item0, Item1);
        public Vec2f ToVec2f() => new Vec2f(Item0, Item1);
        public Vec2d ToVec2d() => new Vec2d(Item0, Item1);
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591


        /// <inheritdoc />
        public bool Equals(Vec2b other)
        {
            return Item0 == other.Item0 && 
                   Item1 == other.Item1;
        }


        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec2b v && Equals(v);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec2b a, Vec2b b)
        {
            return a.Equals(b);
        }

        /// <summary> 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec2b a, Vec2b b)
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