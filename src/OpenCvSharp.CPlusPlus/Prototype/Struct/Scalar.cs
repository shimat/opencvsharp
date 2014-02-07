using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Scalar : ICloneable, IEquatable<Scalar>
    {
        /// <summary>
        /// 
        /// </summary>
        private double[] val;
        /// <summary>
        /// 
        /// </summary>
        public double[] Val
        {
            get { return val; }
            protected set { val = value; }
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
            val = new double[] {v0, v1, v2, v3};
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public Scalar(double v0, double v1, double v2)
        {
            val = new double[] {v0, v1, v2, 0};
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public Scalar(double v0, double v1)
        {
            val = new double[] {v0, v1, 0, 0};
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        public Scalar(double v0)
        {
            val = new double[] {v0, 0, 0, 0};
        }
        /// <summary>
        /// 
        /// </summary>
        public Scalar()
        {
            val = new double[] { 0, 0, 0, 0 };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vals"></param>
        public Scalar(double[] vals)
        {
            if (vals != null && vals.Length == 4)
                val = (double[]) vals.Clone();
            else
            {
                val = new double[4];
                Set(vals);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static implicit operator CvScalar(Scalar self)
        {
            return new CvScalar(self.val[0], self.val[1], self.val[2], self.val[3]);
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
        /// <param name="index"></param>
        /// <returns></returns>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= val.Length)
                    throw new ArgumentOutOfRangeException("index");
                return val[index];
            }
            set
            {
                if (index < 0 || index >= val.Length)
                    throw new ArgumentOutOfRangeException("index");
                val[index] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vals"></param>
        public void Set(double[] vals)
        {
            if (vals != null)
            {
                val[0] = vals.Length > 0 ? vals[0] : 0;
                val[1] = vals.Length > 1 ? vals[1] : 0;
                val[2] = vals.Length > 2 ? vals[2] : 0;
                val[3] = vals.Length > 3 ? vals[3] : 0;
            }
            else
                val[0] = val[1] = val[2] = val[3] = 0;
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
            return new Scalar(val);
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
            return new Scalar(val[0] * it.val[0] * scale, val[1] * it.val[1] * scale,
                              val[2] * it.val[2] * scale, val[3] * it.val[3] * scale);
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
            return new Scalar(val[0], -val[1], -val[2], -val[3]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsReal()
        {
            return
                Math.Abs(val[1] - 0) <= Double.Epsilon &&
                Math.Abs(val[2] - 0) <= Double.Epsilon &&
                Math.Abs(val[3] - 0) <= Double.Epsilon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int result = 0;
            foreach (double v in val)
            {
                result = result ^ v.GetHashCode();
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Scalar other)
        {
            if (other == null)
                return false;
            if (val == null)
                return (other.val == null);
            if (other.val == null)
                return (val == null);
            if (val.Length != other.val.Length)
                return false;
            for (int i = 0; i < val.Length; i++)
            {
                if (Math.Abs(val[i] - other.val[i]) > Double.Epsilon)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}, {3}]", val[0], val[1], val[2], val[3]);
        }

    }

}
