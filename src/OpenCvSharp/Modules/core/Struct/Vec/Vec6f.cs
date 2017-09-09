using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 6-Tuple of float (System.Single)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec6f : IVec<float>, IEquatable<Vec6f>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public float Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public float Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public float Item2;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public float Item3;

        /// <summary>
        /// The value of the fifth component of this object.
        /// </summary>
        public float Item4;

        /// <summary>
        /// The value of the sixth component of this object.
        /// </summary>
        public float Item5;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        public Vec6f(float item0, float item1, float item2, float item3, float item4, float item5)
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
        public float this[int i]
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
        public bool Equals(Vec6f other)
        {
            return Item0.Equals(other.Item0) && Item1.Equals(other.Item1) && Item2.Equals(other.Item2) && Item3.Equals(other.Item3) && Item4.Equals(other.Item4) && Item5.Equals(other.Item5);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vec6f && Equals((Vec6f) obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec6f a, Vec6f b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec6f a, Vec6f b)
        {
            return !a.Equals(b);
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
