using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    internal class VectorOfVec6d : DisposableCvObject, IStdVector<Vec6d>
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Dispose

        /// <summary>
        /// 
        /// </summary>
        public VectorOfVec6d()
        {
            ptr = NativeMethods.vector_Vec6d_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfVec6d(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = NativeMethods.vector_Vec6d_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfVec6d(IEnumerable<Vec6d> data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            Vec6d[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_Vec6d_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public VectorOfVec6d(IntPtr p)
        {
            ptr = p;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (IsEnabledDispose)
                    {
                        NativeMethods.vector_Vec6d_delete(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get { return NativeMethods.vector_Vec6d_getSize(ptr).ToInt32(); }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return NativeMethods.vector_Vec6d_getPointer(ptr); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Vec6d[] ToArray()
        {
            return ToArray<Vec6d>();
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <typeparam name="T">structure that has four int members (ex. CvLineSegmentPoint, CvRect)</typeparam>
        /// <returns></returns>
        public T[] ToArray<T>() where T : struct
        {
            int typeSize = Marshal.SizeOf(typeof (T));
            if (typeSize != sizeof (double)*6)
            {
                throw new OpenCvSharpException();
            }

            int arySize = Size;
            if (arySize == 0)
            {
                return new T[0];
            }
            var dst = new T[arySize];
            using (var dstPtr = new ArrayAddress1<T>(dst))
            {
                Util.Utility.CopyMemory(dstPtr, ElemPtr, typeSize*dst.Length);
            }
            return dst;
        }

        #endregion
    }
}
