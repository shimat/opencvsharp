using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public class Mat3b : Mat
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public Mat3b(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        public Mat3b(Mat mat)
            : base(mat.CvPtr)
        {
            IsEnabledDispose = false;
        }

        #region Indexer
        /// <summary>
        /// 
        /// </summary>
        public sealed unsafe class Indexer : IndexerBase<Vec3b>
        {
            private readonly byte* ptr;

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
            public override Vec3b this[int i0]
            {
                get
                {
                    return *(Vec3b*)(ptr + (steps[0] * i0));
                }
                set
                {
                    *(Vec3b*)(ptr + (steps[0] * i0)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <returns></returns>
            public override Vec3b this[int i0, int i1]
            {
                get
                {
                    return *(Vec3b*)(ptr + (steps[0] * i0) + (steps[1] * i1));
                }
                set
                {
                    *(Vec3b*)(ptr + (steps[0] * i0) + (steps[1] * i1)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <param name="i2"></param>
            /// <returns></returns>
            public override Vec3b this[int i0, int i1, int i2]
            {
                get
                {
                    return *(Vec3b*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                }
                set
                {
                    *(Vec3b*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="idx"></param>
            /// <returns></returns>
            public override Vec3b this[params int[] idx]
            {
                get
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    return *(Vec3b*)(ptr + offset);
                }
                set
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    *(Vec3b*)(ptr + offset) = value;
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
    }
}
