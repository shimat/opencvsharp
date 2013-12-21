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
    public class StdVectorPoint : DisposableCvObject, IStdVector
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose
        /// <summary>
        /// 
        /// </summary>
        public StdVectorPoint()
        {
            ptr = CppInvoke.vector_cvPoint_new1();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public StdVectorPoint(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = CppInvoke.vector_cvPoint_new2(new IntPtr(size));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public StdVectorPoint(CvPoint[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            ptr = CppInvoke.vector_cvPoint_new3(data, new IntPtr(data.Length));
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
                        CppInvoke.vector_cvPoint_delete(ptr);
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
            get { return CppInvoke.vector_cvPoint_getSize(ptr).ToInt32(); }
        }
        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return CppInvoke.vector_cvPoint_getPointer(ptr); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public CvPoint[] ToArray()
        {            
            int size = Size;
            if (size == 0)
            {
                return new CvPoint[0];
            }
            CvPoint[] dst = new CvPoint[size];
            using (ArrayAddress1<CvPoint> dstPtr = new ArrayAddress1<CvPoint>(dst))
            {
                Util.CopyMemory(dstPtr, ElemPtr, CvPoint.SizeOf * dst.Length);
            }
            return dst;
        }
        #endregion
    }
}
