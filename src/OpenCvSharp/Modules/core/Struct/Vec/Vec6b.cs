using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 6-Tuple of byte (System.Byte)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec6b : IVec<byte>, IEquatable<Vec6b>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public byte Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public byte Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public byte Item2;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public byte Item3;

        /// <summary>
        /// The value of the fifth component of this object.
        /// </summary>
        public byte Item4;

        /// <summary>
        /// The value of the sizth component of this object.
        /// </summary>
        public byte Item5;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        public Vec6b(byte item0, byte item1, byte item2, byte item3, byte item4, byte item5)
        {
            Item0 = item0;
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
            Item5 = item5;
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public byte this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return Item0;
                    case 1: return Item1;
                    case 2: return Item2;
                    case 3: return Item3;
                    case 4: return Item4;
                    case 5: return Item5;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(i));
                }
            }
            set
            {
                switch (i)
                {
                    case 0: Item0 = value; break;
                    case 1: Item1 = value; break;
                    case 2: Item2 = value; break;
                    case 3: Item3 = value; break;
                    case 4: Item4 = value; break;
                    case 5: Item5 = value; break;
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
        public bool Equals(Vec6b other)
        {
            return Item0 == other.Item0 && Item1 == other.Item1 && Item2 == other.Item2 && Item3 == other.Item3 && Item4 == other.Item4 && Item5 == other.Item5;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vec6b && Equals((Vec6b) obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec6b a, Vec6b b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec6b a, Vec6b b)
        {
            return !(a == b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
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
        }
    }
}
