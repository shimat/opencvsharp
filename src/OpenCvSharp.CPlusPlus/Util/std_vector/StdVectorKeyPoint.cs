using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    internal class StdVectorKeyPoint : DisposableCvObject, IStdVector
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose
        /// <summary>
        /// 
        /// </summary>
        public StdVectorKeyPoint()
        {
            ptr = CppInvoke.vector_cvKeyPoint_new1();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public StdVectorKeyPoint(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = CppInvoke.vector_cvKeyPoint_new2(new IntPtr(size));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public StdVectorKeyPoint(KeyPoint[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            ptr = CppInvoke.vector_cvKeyPoint_new3(data, new IntPtr(data.Length));
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
                        CppInvoke.vector_cvKeyPoint_delete(ptr);
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
            get { return CppInvoke.vector_cvKeyPoint_getSize(ptr).ToInt32(); }
        }
        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return CppInvoke.vector_cvKeyPoint_getPointer(ptr); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public KeyPoint[] ToArray()
        {            
            int size = Size;
            if (size == 0)
            {
                return new KeyPoint[0];
            }
            KeyPoint[] dst = new KeyPoint[size];
            using (ArrayAddress1<KeyPoint> dstPtr = new ArrayAddress1<KeyPoint>(dst))
            {
                Util.CopyMemory(dstPtr, ElemPtr, Marshal.SizeOf(typeof(KeyPoint)) * dst.Length);
            }
            return dst;
        }
        #endregion
    }
}
