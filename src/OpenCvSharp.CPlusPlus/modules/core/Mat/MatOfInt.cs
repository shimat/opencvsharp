using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// A matrix whose element is 32SC1 (cv::Mat_&lt;int&gt;)
    /// </summary>
    public class MatOfInt : Mat, ITypeSpecificMat<int>
    {
        private const int ThisDepth = MatType.CV_32S;
        private const int ThisChannels = 1;

        #region Init

        /// <summary>
        /// 
        /// </summary>
        public MatOfInt()
            : base()
        {
        }

        /// <summary>
        /// Initializes by cv::Mat* pointer
        /// </summary>
        /// <param name="ptr"></param>
        public MatOfInt(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Initializes by Mat object
        /// </summary>
        /// <param name="mat"></param>
        public MatOfInt(Mat mat)
            : base(mat.CvPtr)
        {
        }
        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="arr"></param>
        public MatOfInt(params int[] arr)
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
        public MatOfInt(IEnumerable<int> enumerable)
            : this(EnumerableEx.ToArray(enumerable))
        {
        }
        #endregion

        #region Indexer
        /// <summary>
        /// 
        /// </summary>
        public sealed unsafe class Indexer : IndexerBase<int>
        {
            private readonly byte *ptr;

            internal Indexer(Mat parent)
                : base(parent)
            {
                this.ptr = (byte*)parent.Data.ToPointer();
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <returns></returns>
            public override int this[int i0]
            {
                get
                {
                    return *(int*)(ptr + (steps[0] * i0));
                }
                set
                {
                    *(int*)(ptr + (steps[0] * i0)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <returns></returns>
            public override int this[int i0, int i1]
            {
                get
                {
                    return *(int*)(ptr + (steps[0] * i0) + (steps[1] * i1));
                }
                set
                {
                    *(int*)(ptr + (steps[0] * i0) + (steps[1] * i1)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <param name="i2"></param>
            /// <returns></returns>
            public override int this[int i0, int i1, int i2]
            {
                get
                {
                    return *(int*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                }
                set
                {
                    *(int*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="idx"></param>
            /// <returns></returns>
            public override int this[params int[] idx]
            {
                get
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    return *(int*)(ptr + offset);
                }
                set
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    *(int*)(ptr + offset) = value;
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
        public static MatOfInt FromArray(params int[] arr)
        {
            return new MatOfInt(arr);
        }
        /// <summary>
        /// Convert enumerable object to Mat
        /// </summary>
        /// <param name="enumerable"></param>
        public static MatOfInt FromArray(IEnumerable<int> enumerable)
        {
            return new MatOfInt(enumerable);
        }
        #endregion

        #region ToArray
        /// <summary>
        /// Convert this mat to managed array
        /// </summary>
        /// <returns></returns>
        public int[] ToArray()
        {
            int numOfElems = Rows * Cols;
            if (numOfElems == 0)
                return new int[0];
            int[] arr = new int[numOfElems];
            GetArray(0, 0, arr);
            return arr;
        }
        /// <summary>
        /// Convert this mat to managed rectangular array
        /// </summary>
        /// <returns></returns>
        public int[,] ToRectangularArray()
        {
            if (Rows == 0 || Cols == 0)
                return new int[0, 0];
            int[,] arr = new int[Rows, Cols];
            GetArray(0, 0, arr);
            return arr;
        }
        #endregion
    }
}
