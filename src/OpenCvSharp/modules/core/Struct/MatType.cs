using System;

namespace OpenCvSharp
{
// ReSharper disable InconsistentNaming
#pragma warning disable 1591

    /// <summary>
    /// Matrix data type (depth and number of channels)
    /// </summary>
    public struct MatType : IEquatable<MatType>, IEquatable<int>
    {
        /// <summary>
        /// Entity value
        /// </summary>
        public int Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public MatType(int value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static implicit operator int(MatType self)
        {
            return self.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator MatType(int value)
        {
            return new MatType(value);
        }

        /// <summary>
        /// 
        /// </summary>
        public int Depth
        {
            get { return Value & (CV_DEPTH_MAX - 1); }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsInteger
        {
            get { return Depth < CV_32F; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Channels
        {
            get { return (Value >> CV_CN_SHIFT) + 1; }
        }

        public bool Equals(MatType other)
        {
            return Value == other.Value;
        }

        public bool Equals(int other)
        {
            return Value == other;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;
            if (other.GetType() != typeof (MatType))
                return false;
            return Equals((MatType) other);
        }

        public static bool operator ==(MatType self, MatType other)
        {
            return self.Equals(other);
        }

        public static bool operator !=(MatType self, MatType other)
        {
            return !self.Equals(other);
        }

        public static bool operator ==(MatType self, int other)
        {
            return self.Equals(other);
        }

        public static bool operator !=(MatType self, int other)
        {
            return !self.Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s;
            switch (Depth)
            {
                case CV_8U:
                    s = "CV_8U";
                    break;
                case CV_8S:
                    s = "CV_8S";
                    break;
                case CV_16U:
                    s = "CV_16U";
                    break;
                case CV_16S:
                    s = "CV_16S";
                    break;
                case CV_32S:
                    s = "CV_32S";
                    break;
                case CV_32F:
                    s = "CV_32F";
                    break;
                case CV_64F:
                    s = "CV_64F";
                    break;
                case CV_USRTYPE1:
                    s = "CV_USRTYPE1";
                    break;
                default:
                    throw new OpenCvSharpException("Unsupported CvType value: " + Value);
            }

            int ch = Channels;
            if (ch <= 4)
                return s + "C" + ch;
            else
                return s + "C(" + ch + ")";
        }

        private const int CV_CN_MAX = 512,
            CV_CN_SHIFT = 3,
            CV_DEPTH_MAX = (1 << CV_CN_SHIFT);

        /// <summary>
        /// type depth constants
        /// </summary>
        public const int
            CV_8U = 0,
            CV_8S = 1,
            CV_16U = 2,
            CV_16S = 3,
            CV_32S = 4,
            CV_32F = 5,
            CV_64F = 6,
            CV_USRTYPE1 = 7;

        /// <summary>
        /// predefined type constants
        /// </summary>
        public static readonly MatType
            CV_8UC1 = CV_8UC(1),
            CV_8UC2 = CV_8UC(2),
            CV_8UC3 = CV_8UC(3),
            CV_8UC4 = CV_8UC(4),
            CV_8SC1 = CV_8SC(1),
            CV_8SC2 = CV_8SC(2),
            CV_8SC3 = CV_8SC(3),
            CV_8SC4 = CV_8SC(4),
            CV_16UC1 = CV_16UC(1),
            CV_16UC2 = CV_16UC(2),
            CV_16UC3 = CV_16UC(3),
            CV_16UC4 = CV_16UC(4),
            CV_16SC1 = CV_16SC(1),
            CV_16SC2 = CV_16SC(2),
            CV_16SC3 = CV_16SC(3),
            CV_16SC4 = CV_16SC(4),
            CV_32SC1 = CV_32SC(1),
            CV_32SC2 = CV_32SC(2),
            CV_32SC3 = CV_32SC(3),
            CV_32SC4 = CV_32SC(4),
            CV_32FC1 = CV_32FC(1),
            CV_32FC2 = CV_32FC(2),
            CV_32FC3 = CV_32FC(3),
            CV_32FC4 = CV_32FC(4),
            CV_64FC1 = CV_64FC(1),
            CV_64FC2 = CV_64FC(2),
            CV_64FC3 = CV_64FC(3),
            CV_64FC4 = CV_64FC(4);


        public static MatType CV_8UC(int ch)
        {
            return MakeType(CV_8U, ch);
        }

        public static MatType CV_8SC(int ch)
        {
            return MakeType(CV_8S, ch);
        }

        public static MatType CV_16UC(int ch)
        {
            return MakeType(CV_16U, ch);
        }

        public static MatType CV_16SC(int ch)
        {
            return MakeType(CV_16S, ch);
        }

        public static MatType CV_32SC(int ch)
        {
            return MakeType(CV_32S, ch);
        }

        public static MatType CV_32FC(int ch)
        {
            return MakeType(CV_32F, ch);
        }

        public static MatType CV_64FC(int ch)
        {
            return MakeType(CV_64F, ch);
        }

        public static MatType MakeType(int depth, int channels)
        {
            if (channels <= 0 || channels >= CV_CN_MAX)
                throw new OpenCvSharpException("Channels count should be 1.." + (CV_CN_MAX - 1));
            if (depth < 0 || depth >= CV_DEPTH_MAX)
                throw new OpenCvSharpException("Data type depth should be 0.." + (CV_DEPTH_MAX - 1));
            return (depth & (CV_DEPTH_MAX - 1)) + ((channels - 1) << CV_CN_SHIFT);
        }
    }
}
