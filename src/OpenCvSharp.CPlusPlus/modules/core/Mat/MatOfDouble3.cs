using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// A matrix whose element is cv::Vec3d [CV_64FC3] (cv::Mat_&lt;cv::Vec3d&gt;)
    /// </summary>
    public class MatOfDouble3 : Mat, ITypeSpecificMat<Vec3d>
    {
        private const int ThisDepth = MatType.CV_64F;
        private const int ThisChannels = 3;

        #region Init
        /// <summary>
        /// Initializes by cv::Mat* pointer
        /// </summary>
        public MatOfDouble3()
            : base()
        {
        }

        /// <summary>
        /// Initializes by cv::Mat* pointer
        /// </summary>
        /// <param name="ptr"></param>
        public MatOfDouble3(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Initializes by Mat object
        /// </summary>
        /// <param name="mat"></param>
        public MatOfDouble3(Mat mat)
            : base(mat.CvPtr)
        {
        }

        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="arr"></param>
        public MatOfDouble3(params Vec3d[] arr)
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
        /// <param name="arr"></param>
        public MatOfDouble3(Vec3d[,] arr)
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
        public MatOfDouble3(IEnumerable<Vec3d> enumerable)
            : this(EnumerableEx.ToArray(enumerable))
        {
        }

        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="arr"></param>
        public MatOfDouble3(params double[] arr)
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
        public MatOfDouble3(IEnumerable<double> enumerable)
            : this(EnumerableEx.ToArray(enumerable))
        {
        }
        #endregion

        #region Indexer
        /// <summary>
        /// Matrix indexer
        /// </summary>
        public sealed unsafe class Indexer : MatIndexer<Vec3d>
        {
            private readonly byte* ptr;

            internal Indexer(Mat parent)
                : base(parent)
            {
                this.ptr = (byte*)parent.Data.ToPointer();
            }
            /// <summary>
            /// 1-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <returns>A value to the specified array element.</returns>
            public override Vec3d this[int i0]
            {
                get
                {
                    return *(Vec3d*)(ptr + (steps[0] * i0));
                }
                set
                {
                    *(Vec3d*)(ptr + (steps[0] * i0)) = value;
                }
            }
            /// <summary>
            /// 2-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <param name="i1">Index along the dimension 1</param>
            /// <returns>A value to the specified array element.</returns>
            public override Vec3d this[int i0, int i1]
            {
                get
                {
                    return *(Vec3d*)(ptr + (steps[0] * i0) + (steps[1] * i1));
                }
                set
                {
                    *(Vec3d*)(ptr + (steps[0] * i0) + (steps[1] * i1)) = value;
                }
            }
            /// <summary>
            /// 3-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <param name="i1">Index along the dimension 1</param>
            /// <param name="i2"> Index along the dimension 2</param>
            /// <returns>A value to the specified array element.</returns>
            public override Vec3d this[int i0, int i1, int i2]
            {
                get
                {
                    return *(Vec3d*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                }
                set
                {
                    *(Vec3d*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2)) = value;
                }
            }
            /// <summary>
            /// n-dimensional indexer
            /// </summary>
            /// <param name="idx">Array of Mat::dims indices.</param>
            /// <returns>A value to the specified array element.</returns>
            public override Vec3d this[params int[] idx]
            {
                get
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    return *(Vec3d*)(ptr + offset);
                }
                set
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    *(Vec3d*)(ptr + offset) = value;
                }
            }
        }
        /// <summary>
        /// Gets a type-specific indexer. The indexer has getters/setters to access each matrix element.
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
        public static MatOfDouble3 FromArray(params Vec3d[] arr)
        {
            return new MatOfDouble3(arr);
        }
        /// <summary>
        /// Convert enumerable object to Mat
        /// </summary>
        /// <param name="arr"></param>
        public static MatOfDouble3 FromArray(Vec3d[,] arr)
        {
            return new MatOfDouble3(arr);
        }
        /// <summary>
        /// Convert enumerable object to Mat
        /// </summary>
        /// <param name="enumerable"></param>
        public static MatOfDouble3 FromArray(IEnumerable<Vec3d> enumerable)
        {
            return new MatOfDouble3(enumerable);
        }
        /// <summary>
        /// Convert enumerable object to Mat
        /// </summary>
        /// <param name="arr"></param>
        public static MatOfDouble3 FromPrimitiveArray(params double[] arr)
        {
            return new MatOfDouble3(arr);
        }
        /// <summary>
        /// Convert enumerable object to Mat
        /// </summary>
        /// <param name="enumerable"></param>
        public static MatOfDouble3 FromPrimitiveArray(IEnumerable<double> enumerable)
        {
            return new MatOfDouble3(enumerable);
        }
        #endregion

        #region ToArray
        /// <summary>
        /// Convert this mat to managed array
        /// </summary>
        /// <returns></returns>
        public Vec3d[] ToArray()
        {
            int numOfElems = Rows * Cols;
            if (numOfElems == 0)
                return new Vec3d[0];
            Vec3d[] arr = new Vec3d[numOfElems];
            GetArray(0, 0, arr);
            return arr;
        }
        /// <summary>
        /// Convert this mat to managed array
        /// </summary>
        /// <returns></returns>
        public double[] ToPrimitiveArray()
        {
            int numOfElems = Rows * Cols;
            if (numOfElems == 0)
                return new double[0];
            double[] arr = new double[numOfElems * ThisChannels];
            GetArray(0, 0, arr);
            return arr;
        }
        /// <summary>
        /// Convert this mat to managed rectangular array
        /// </summary>
        /// <returns></returns>
        public Vec3d[,] ToRectangularArray()
        {
            if (Rows == 0 || Cols == 0)
                return new Vec3d[0, 0];
            Vec3d[,] arr = new Vec3d[Rows, Cols];
            GetArray(0, 0, arr);
            return arr;
        }
        #endregion
    }
}
