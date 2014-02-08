using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Scalar : ICloneable, IEquatable<Scalar>
    {
        /// <summary>
        /// 
        /// </summary>
        public double Val0;
        /// <summary>
        /// 
        /// </summary>
        public double Val1;
        /// <summary>
        /// 
        /// </summary>
        public double Val2;
        /// <summary>
        /// 
        /// </summary>
        public double Val3;
        /// <summary>
        /// 
        /// </summary>
        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return Val0;
                    case 1:
                        return Val0;
                    case 2:
                        return Val0;
                    case 3:
                        return Val0;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        Val0 = value; break;
                    case 1:
                        Val1 = value; break;
                    case 2:
                        Val2 = value; break;
                    case 3:
                        Val3 = value; break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        public Scalar(double v0)
            : this(v0, 0, 0, 0)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public Scalar(double v0, double v1)
            : this(v0, v1, 0, 0)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public Scalar(double v0, double v1, double v2)
            : this(v0, v1, v2, 0)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public Scalar(double v0, double v1, double v2, double v3)
        {
            Val0 = v0;
            Val1 = v1;
            Val2 = v2;
            Val3 = v3;
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static implicit operator CvScalar(Scalar self)
        {
            return new CvScalar(self.Val0, self.Val1, self.Val2, self.Val3);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static implicit operator Scalar(CvScalar scalar)
        {
            return new Scalar(scalar.Val0, scalar.Val1, scalar.Val2, scalar.Val3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Scalar All(double v)
        {
            return new Scalar(v, v, v, v);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Scalar Clone()
        {
            return new Scalar(Val0, Val1, Val2, Val3);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="it"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public Scalar Mul(Scalar it, double scale)
        {
            return new Scalar(Val0 * it.Val0 * scale, Val1 * it.Val1 * scale,
                              Val2 * it.Val2 * scale, Val3 * it.Val3 * scale);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="it"></param>
        /// <returns></returns>
        public Scalar Mul(Scalar it)
        {
            return Mul(it, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Scalar Conj()
        {
            return new Scalar(Val0, -Val1, -Val2, -Val3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsReal()
        {
            return Val1 == 0 && Val2 == 0 && Val3 == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int result = Val0.GetHashCode() ^ Val1.GetHashCode() ^ Val2.GetHashCode() ^ Val3.GetHashCode();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Scalar other)
        {
            return Val0 == other.Val0 &&
                   Val1 == other.Val1 &&
                   Val2 == other.Val2 &&
                   Val3 == other.Val3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool operator ==(Scalar s1, Scalar s2)
        {
            return s1.Equals(s2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool operator !=(Scalar s1, Scalar s2)
        {
            return !s1.Equals(s2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}, {3}]", Val0, Val1, Val2, Val3);
        }

    }

}
