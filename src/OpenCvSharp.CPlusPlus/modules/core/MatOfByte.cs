using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// A matrix whose element is 8UC1 (cv::Mat_&lt;uchar&gt;)
    /// </summary>
    public class MatOfByte : Mat, ITypeSpecificMat<byte>
    {
        private const int ThisDepth = MatType.CV_8U;
        private const int ThisChannels = 1;

        /// <summary>
        /// Initializes by cv::Mat* pointer
        /// </summary>
        /// <param name="ptr"></param>
        public MatOfByte(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Initializes by Mat object
        /// </summary>
        /// <param name="mat"></param>
        public MatOfByte(Mat mat)
            : base(mat.CvPtr)
        {
        }
        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="arr"></param>
        public MatOfByte(params byte[] arr)
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
        public MatOfByte(IEnumerable<byte> enumerable)
            : this(EnumerableEx.ToArray(enumerable))
        {
        }

        #region Indexer
        /// <summary>
        /// 
        /// </summary>
        public sealed unsafe class Indexer : IndexerBase<byte>
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
            public override byte this[int i0]
            {
                get
                {
                    return *(ptr + (steps[0] * i0));
                }
                set
                {
                    *(ptr + (steps[0] * i0)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <returns></returns>
            public override byte this[int i0, int i1]
            {
                get
                {
                    return *(ptr + (steps[0] * i0) + (steps[1] * i1));
                }
                set
                {
                    *(ptr + (steps[0] * i0) + (steps[1] * i1)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <param name="i2"></param>
            /// <returns></returns>
            public override byte this[int i0, int i1, int i2]
            {
                get
                {
                    return *(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                }
                set
                {
                    *(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="idx"></param>
            /// <returns></returns>
            public override byte this[params int[] idx]
            {
                get
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    return *(ptr + offset);
                }
                set
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    *(ptr + offset) = value;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public static MatOfByte FromArray(params byte[] arr)
        {
            return new MatOfByte(arr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        public static MatOfByte FromArray(IEnumerable<byte> enumerable)
        {
            return new MatOfByte(enumerable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToArray()
        {
            int num = CheckVector(ThisChannels, ThisDepth);
            if (num < 0)
                throw new OpenCvSharpException("Native Mat has unexpected type or size: " + ToString());
            if (num == 0)
                return new byte[0];
            byte[] arr = new byte[num * ThisChannels];
            GetArray(0, 0, arr);
            return arr;
        }
    }
}
