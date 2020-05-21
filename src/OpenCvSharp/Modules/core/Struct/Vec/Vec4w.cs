using System;
using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp
{
    /// <summary>
    /// 4-Tuple of ushort (System.UInt16)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct Vec4w : IVec<ushort>, IEquatable<Vec4w>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public ushort Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public ushort Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public ushort Item2;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public ushort Item3;

#if !DOTNET_FRAMEWORK
        /// <summary>
        /// Deconstructing a Vector
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public void Deconstruct(out ushort item0, out ushort item1, out ushort item2, out ushort item3) => (item0, item1, item2, item3) = (Item0, Item1, Item2, Item3);
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

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public ushort this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return Item0;
                    case 1:
                        return Item1;
                    case 2:
                        return Item2;
                    case 3:
                        return Item3;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(i));
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        Item0 = value;
                        break;
                    case 1:
                        Item1 = value;
                        break;
                    case 2:
                        Item2 = value;
                        break;
                    case 3:
                        Item3 = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(i));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Vec4w other)
        {
            return Item0 == other.Item0 && Item1 == other.Item1 && Item2 == other.Item2 && Item3 == other.Item3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Vec4w v && Equals(v);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec4w a, Vec4w b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// 
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
            unchecked
            {
                var hashCode = Item0.GetHashCode();
                hashCode = (hashCode * 397) ^ Item1.GetHashCode();
                hashCode = (hashCode * 397) ^ Item2.GetHashCode();
                hashCode = (hashCode * 397) ^ Item3.GetHashCode();
                return hashCode;
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{GetType().Name} ({Item0}, {Item1}, {Item2}, {Item3})";
        }
    }
}