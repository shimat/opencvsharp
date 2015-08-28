using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    internal class VectorOfVec4f : DisposableCvObject, IStdVector<Vec4f>
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose

        /// <summary>
        /// 
        /// </summary>
        public VectorOfVec4f()
        {
            ptr = NativeMethods.vector_Vec4f_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfVec4f(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = NativeMethods.vector_Vec4f_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfVec4f(IEnumerable<Vec4f> data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            Vec4f[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_Vec4f_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public VectorOfVec4f(IntPtr p)
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
                        NativeMethods.vector_Vec4f_delete(ptr);
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
            get { return NativeMethods.vector_Vec4f_getSize(ptr).ToInt32(); }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return NativeMethods.vector_Vec4f_getPointer(ptr); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Vec4f[] ToArray()
        {
            return ToArray<Vec4f>();
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <typeparam name="T">structure that has four int members (ex. CvLineSegmentPoint, CvRect)</typeparam>
        /// <returns></returns>
        public T[] ToArray<T>() where T : struct
        {
            int typeSize = Marshal.SizeOf(typeof (T));
            if (typeSize != sizeof (float)*4)
            {
                throw new OpenCvSharpException();
            }

            int arySize = Size;
            if (arySize == 0)
            {
                return new T[0];
            }
            T[] dst = new T[arySize];
            using (ArrayAddress1<T> dstPtr = new ArrayAddress1<T>(dst))
            {
                Util.Utility.CopyMemory(dstPtr, ElemPtr, typeSize*dst.Length);
            }
            return dst;
        }

        #endregion
    }
}
