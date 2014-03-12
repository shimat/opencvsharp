using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// A matrix whose element is 64FC1 (cv::Mat_&lt;double&gt;)
    /// </summary>
    public class MatOfDouble : Mat, ITypeSpecificMat<double>
    {
        private const int ThisDepth = MatType.CV_64F;
        private const int ThisChannels = 1;

        #region Init

        /// <summary>
        /// 
        /// </summary>
        public MatOfDouble()
            : base()
        {
        }

        /// <summary>
        /// Initializes by cv::Mat* pointer
        /// </summary>
        /// <param name="ptr"></param>
        public MatOfDouble(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Initializes by Mat object
        /// </summary>
        /// <param name="mat"></param>
        public MatOfDouble(Mat mat)
            : base(mat.CvPtr)
        {
        }
        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="arr"></param>
        public MatOfDouble(params double[] arr)
            : base()
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            if (arr.Length == 0)
                throw new ArgumentException("arr.Length == 0");
            int numElems = arr.Length / ThisChannels;
            Create(numElems, 1, MatType.MakeType(ThisDepth, ThisChannels));
            SetArray(0, 0, arr);
        }
        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="enumerable"></param>
        public MatOfDouble(IEnumerable<double> enumerable)
            : this(EnumerableEx.ToArray(enumerable))
        {
        }
        #endregion

        #region Indexer
        /// <summary>
        /// 
        /// </summary>
        public sealed unsafe class Indexer : IndexerBase<double>
        {
            private readonly byte *ptr;

            internal Indexer(Mat parent)
                : base(parent)
            {
                ptr = (byte*)parent.Data.ToPointer();
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <returns></returns>
            public override double this[int i0]
            {
                get
                {
                    return *(double*)(ptr + (steps[0] * i0));
                }
                set
                {
                    *(double*)(ptr + (steps[0] * i0)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <returns></returns>
            public override double this[int i0, int i1]
            {
                get
                {
                    return *(double*)(ptr + (steps[0] * i0) + (steps[1] * i1));
                }
                set
                {
                    *(double*)(ptr + (steps[0] * i0) + (steps[1] * i1)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <param name="i2"></param>
            /// <returns></returns>
            public override double this[int i0, int i1, int i2]
            {
                get
                {
                    return *(double*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                }
                set
                {
                    *(double*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="idx"></param>
            /// <returns></returns>
            public override double this[params int[] idx]
            {
                get
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    return *(double*)(ptr + offset);
                }
                set
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    *(double*)(ptr + offset) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Indexer GetIndexer() 
        {
            return new Indexer(this);
        }
        #endregion

        #region FromArray
        /// <summary>
        /// Convert managed array object to Mat
        /// </summary>
        /// <param name="arr"></param>
        public static MatOfDouble FromArray(params double[] arr)
        {
            return new MatOfDouble(arr);
        }
        /// <summary>
        /// Convert enumerable object to Mat
        /// </summary>
        /// <param name="enumerable"></param>
        public static MatOfDouble FromArray(IEnumerable<double> enumerable)
        {
            return new MatOfDouble(enumerable);
        }
        #endregion

        #region ToArray
        /// <summary>
        /// Convert this mat to managed array
        /// </summary>
        /// <returns></returns>
        public double[] ToArray()
        {
            int numOfElems = Rows * Cols;
            if (numOfElems == 0)
                return new double[0];
            double[] arr = new double[numOfElems];
            GetArray(0, 0, arr);
            return arr;
        }
        /// <summary>
        /// Convert this mat to managed rectangular array
        /// </summary>
        /// <returns></returns>
        public double[,] ToRectangularArray()
        {
            if (Rows == 0 || Cols == 0)
                return new double[0, 0];
            double[,] arr = new double[Rows, Cols];
            GetArray(0, 0, arr);
            return arr;
        }
        #endregion
    }
}
