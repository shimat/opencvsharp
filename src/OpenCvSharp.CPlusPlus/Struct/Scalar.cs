using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Scalar : ICloneable, IEquatable<Scalar>
    {
        #region Field
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
        #endregion

        #region Init
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
        #endregion

        #region Cast
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
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator double(Scalar self)
        {
            return self.Val0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static implicit operator Scalar(double val)
        {
            return new Scalar(val);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static implicit operator CvColor(Scalar self)
        {
            return new CvScalar(self.Val2, self.Val1, self.Val0, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static implicit operator Scalar(CvColor color)
        {
            return new Scalar(color.B, color.G, color.R, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static explicit operator Scalar(DMatch d)
        {
            return new Scalar(d.QueryIdx, d.TrainIdx, d.ImgIdx, d.Distance);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator DMatch(Scalar self)
        {
            return new DMatch((int)self.Val0, (int)self.Val1, (int)self.Val2, (float)self.Val3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static explicit operator Scalar(Vec3b v)
        {
            return new Scalar(v.Item0, v.Item1, v.Item2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static explicit operator Scalar(Point p)
        {
            return new Scalar(p.X, p.Y);
        }
        #endregion

        #region Override
#if LANG_JP
        /// <summary>
        /// Equalsのオーバーライド
        /// </summary>
        /// <param name="obj">比較するオブジェクト</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
#endif
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
#if LANG_JP
        /// <summary>
        /// GetHashCodeのオーバーライド
        /// </summary>
        /// <returns>このオブジェクトのハッシュ値を指定する整数値。</returns>
#else
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this object.</returns>
#endif
        public override int GetHashCode()
        {
            int result = Val0.GetHashCode() ^ Val1.GetHashCode() ^ Val2.GetHashCode() ^ Val3.GetHashCode();
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 文字列形式を返す 
        /// </summary>
        /// <returns>文字列形式</returns>
#else
        /// <summary>
        /// Converts this object to a human readable string.
        /// </summary>
        /// <returns>A string that represents this object.</returns>
#endif
        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}, {3}]", Val0, Val1, Val2, Val3);
        }
        #endregion

        #region Operators
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
        #endregion

        #region Methods
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
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Scalar other)
        {
            return Val0 == other.Val0 &&
                   Val1 == other.Val1 &&
                   Val2 == other.Val2 &&
                   Val3 == other.Val3;
        }
        #endregion
    }

}
