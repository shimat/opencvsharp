using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
#if false
    /// <summary>
    /// 2-Tuple
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct Vec2<T> : IEquatable<Vec2<T>>
        where T : unmanaged
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public T Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public T Item1;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        public void Deconstruct(out T item0, out T item1) => (item0, item1) = (Item0, Item1);
#endif

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        public Vec2(T item0, T item1)
        {
            Item0 = item0;
            Item1 = item1;
        }

        /// <summary>
        /// returns a Vec with all elements set to v0
        /// </summary>
        /// <param name="v0"></param>
        /// <returns></returns>
        public static Vec2<T> All(T v0) => new Vec2<T>(v0, v0);

#region Operators

        /// <summary>
        /// this + other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec2<T> Add(Vec2<T> other) => new Vec2<T>(
            SaturateCast.ToByte(Item0 + other.Item0),
            SaturateCast.ToByte(Item1 + other.Item1));

        /// <summary>
        /// this - other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec2<T> Subtract(Vec2<T> other) => new Vec2<T>(
            SaturateCast.ToByte(Item0 - other.Item0),
            SaturateCast.ToByte(Item1 - other.Item1));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec2<T> Multiply(double alpha) => new Vec2<T>(
            SaturateCast.ToByte(Item0 * alpha),
            SaturateCast.ToByte(Item1 * alpha));

        /// <summary>
        /// this * alpha
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public Vec2<T> Divide(double alpha) => new Vec2<T>(
            SaturateCast.ToByte(Item0 / alpha),
            SaturateCast.ToByte(Item1 / alpha));

#pragma warning disable 1591
        public static Vec2<T> operator +(Vec2<T> self) => self;
        public static Vec2<T> operator +(Vec2<T> a, Vec2<T> b) => a.Add(b);
        public static Vec2<T> operator -(Vec2<T> a, Vec2<T> b) => a.Subtract(b);
        public static Vec2<T> operator *(Vec2<T> a, double alpha) => a.Multiply(alpha);
        public static Vec2<T> operator /(Vec2<T> a, double alpha) => a.Divide(alpha);
#pragma warning restore 1591

#endregion

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T this[int i]
        {
            readonly get
            {
                return i switch
                {
                    0 => Item0,
                    1 => Item1,
                    _ => throw new ArgumentOutOfRangeException(nameof(i))
                };
            }
            set
            {
                switch (i)
                {
                    case 0: Item0 = value; break;
                    case 1: Item1 = value; break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(i));
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public readonly bool Equals(Vec2<T> other)
        {
            return Item0 == other.Item0 && Item1 == other.Item1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override readonly bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec2<T> v && Equals(v);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec2<T> a, Vec2<T> b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec2<T> a, Vec2<T> b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override readonly int GetHashCode()
        {
            unchecked
            {
                return (Item0.GetHashCode() * 397) ^ Item1.GetHashCode();
            }
        }

        /// <inheritdoc />
        public override readonly string ToString()
        {
            return $"{nameof(Vec2<T>)} ({Item0}, {Item1})";
        }
    }
#endif
}