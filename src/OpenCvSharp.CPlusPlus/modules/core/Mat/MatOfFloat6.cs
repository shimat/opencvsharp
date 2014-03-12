using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// A matrix whose element is 32FC6 (cv::Mat_&lt;cv::Vec6f&gt;)
    /// </summary>
    public class MatOfFloat6 : Mat, ITypeSpecificMat<Vec6f>
    {
        private const int ThisDepth = MatType.CV_32F;
        private const int ThisChannels = 6;

        #region Init
        /// <summary>
        /// 
        /// </summary>
        public MatOfFloat6()
            : base()
        {
        }

        /// <summary>
        /// Initializes by cv::Mat* pointer
        /// </summary>
        /// <param name="ptr"></param>
        public MatOfFloat6(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Initializes by Mat object
        /// </summary>
        /// <param name="mat"></param>
        public MatOfFloat6(Mat mat)
            : base(mat.CvPtr)
        {
        }

        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="arr"></param>
        public MatOfFloat6(params Vec6f[] arr)
            : base()
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            if (arr.Length == 0)
                throw new ArgumentException("arr.Length == 0");
            int numElems = arr.Length;
            Create(numElems, 1, MatType.MakeType(ThisDepth, ThisChannels));
            SetArray(0, 0, arr);
        }
        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="enumerable"></param>
        public MatOfFloat6(IEnumerable<Vec6f> enumerable)
            : this(EnumerableEx.ToArray(enumerable))
        {
        }

        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="arr"></param>
        public MatOfFloat6(params float[] arr)
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
        public MatOfFloat6(IEnumerable<float> enumerable)
            : this(EnumerableEx.ToArray(enumerable))
        {
        }
        #endregion

        #region Indexer
        /// <summary>
        /// 
        /// </summary>
        public sealed unsafe class Indexer : IndexerBase<Vec6f>
        {
            private readonly byte* ptr;

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
            public override Vec6f this[int i0]
            {
                get
                {
                    return *(Vec6f*)(ptr + (steps[0] * i0));
                }
                set
                {
                    *(Vec6f*)(ptr + (steps[0] * i0)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <returns></returns>
            public override Vec6f this[int i0, int i1]
            {
                get
                {
                    return *(Vec6f*)(ptr + (steps[0] * i0) + (steps[1] * i1));
                }
                set
                {
                    *(Vec6f*)(ptr + (steps[0] * i0) + (steps[1] * i1)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <param name="i2"></param>
            /// <returns></returns>
            public override Vec6f this[int i0, int i1, int i2]
            {
                get
                {
                    return *(Vec6f*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                }
                set
                {
                    *(Vec6f*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="idx"></param>
            /// <returns></returns>
            public override Vec6f this[params int[] idx]
            {
                get
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    return *(Vec6f*)(ptr + offset);
                }
                set
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    *(Vec6f*)(ptr + offset) = value;
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
        /// Convert enumerable object to Mat
        /// </summary>
        /// <param name="arr"></param>
        public static MatOfFloat6 FromArray(params Vec6f[] arr)
        {
            return new MatOfFloat6(arr);
        }
        /// <summary>
        /// Convert enumerable object to Mat
        /// </summary>
        /// <param name="enumerable"></param>
        public static MatOfFloat6 FromArray(IEnumerable<Vec6f> enumerable)
        {
            return new MatOfFloat6(enumerable);
        }
        /// <summary>
        /// Convert enumerable object to Mat
        /// </summary>
        /// <param name="arr"></param>
        public static MatOfFloat6 FromPrimitiveArray(params float[] arr)
        {
            return new MatOfFloat6(arr);
        }
        /// <summary>
        /// Convert enumerable object to Mat
        /// </summary>
        /// <param name="enumerable"></param>
        public static MatOfFloat6 FromPrimitiveArray(IEnumerable<float> enumerable)
        {
            return new MatOfFloat6(enumerable);
        }
        #endregion

        #region ToArray
        /// <summary>
        /// Convert this mat to managed array
        /// </summary>
        /// <returns></returns>
        public Vec6f[] ToArray()
        {
            int numOfElems = Rows * Cols;
            if (numOfElems == 0)
                return new Vec6f[0];
            Vec6f[] arr = new Vec6f[numOfElems];
            GetArray(0, 0, arr);
            return arr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float[] ToPrimitiveArray()
        {
            int numOfElems = Rows * Cols;
            if (numOfElems == 0)
                return new float[0];
            float[] arr = new float[numOfElems * ThisChannels];
            GetArray(0, 0, arr);
            return arr;
        }
        /// <summary>
        /// Convert this mat to managed rectangular array
        /// </summary>
        /// <returns></returns>
        public Vec6f[,] ToRectangularArray()
        {
            if (Rows == 0 || Cols == 0)
                return new Vec6f[0, 0];
            Vec6f[,] arr = new Vec6f[Rows, Cols];
            GetArray(0, 0, arr);
            return arr;
        }
        #endregion
    }
}
