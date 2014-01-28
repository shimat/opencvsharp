using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    public class Scalar : ICloneable, IEquatable<Scalar>
    {
        private double[] val;

        public double[] Val
        {
            get { return val; }
            protected set { val = value; }
        }

        public Scalar(double v0, double v1, double v2, double v3)
        {
            val = new double[] {v0, v1, v2, v3};
        }

        public Scalar(double v0, double v1, double v2)
        {
            val = new double[] {v0, v1, v2, 0};
        }

        public Scalar(double v0, double v1)
        {
            val = new double[] {v0, v1, 0, 0};
        }

        public Scalar(double v0)
        {
            val = new double[] {v0, 0, 0, 0};
        }

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

        public static Scalar All(double v)
        {
            return new Scalar(v, v, v, v);
        }

        public Scalar Clone()
        {
            return new Scalar(val);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public Scalar Mul(Scalar it, double scale)
        {
            return new Scalar(val[0] * it.val[0] * scale, val[1] * it.val[1] * scale,
                              val[2] * it.val[2] * scale, val[3] * it.val[3] * scale);
        }

        public Scalar Mul(Scalar it)
        {
            return Mul(it, 1);
        }

        public Scalar Conj()
        {
            return new Scalar(val[0], -val[1], -val[2], -val[3]);
        }

        public bool IsReal()
        {
            return
                Math.Abs(val[1] - 0) <= Double.Epsilon &&
                Math.Abs(val[2] - 0) <= Double.Epsilon &&
                Math.Abs(val[3] - 0) <= Double.Epsilon;
        }

        public override int GetHashCode()
        {
            int result = 0;
            foreach (double v in val)
            {
                result = result ^ v.GetHashCode();
            }
            return result;
        }

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


        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}, {3}]", val[0], val[1], val[2], val[3]);
        }

    }

}
