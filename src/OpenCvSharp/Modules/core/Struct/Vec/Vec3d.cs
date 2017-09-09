using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 3-Tuple of double (System.Double)
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3d : IVec<double>, IEquatable<Vec3d>
    {
        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public double Item0;
        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public double Item1;
        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public double Item2;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public Vec3d(double item0, double item1, double item2)
        {
            Item0 = item0;
            Item1 = item1;
            Item2 = item2;
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return Item0;
                    case 1: return Item1;
                    case 2: return Item2;
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
        public bool Equals(Vec3d other)
        {
            return Item0.Equals(other.Item0) && Item1.Equals(other.Item1) && Item2.Equals(other.Item2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vec3d && Equals((Vec3d) obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec3d a, Vec3d b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec3d a, Vec3d b)
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
                return hashCode;
            }
        }
    }
}