using System;
using System.Collections.Generic;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public class StdVectorPoint2f : DisposableCvObject, IStdVector
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose
        /// <summary>
        /// 
        /// </summary>
        public StdVectorPoint2f()
        {
            ptr = CppInvoke.vector_Point2f_new1();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public StdVectorPoint2f(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = CppInvoke.vector_Point2f_new2(new IntPtr(size));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public StdVectorPoint2f(IEnumerable<Point2f> data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            Point2f[] array = Util.ToArray(data);
            ptr = CppInvoke.vector_Point2f_new3(array, new IntPtr(array.Length));
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
                        CppInvoke.vector_Point2f_delete(ptr);
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
            get { return CppInvoke.vector_Point2f_getSize(ptr).ToInt32(); }
        }
        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return CppInvoke.vector_Point2f_getPointer(ptr); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Point2f[] ToArray()
        {            
            int size = Size;
            if (size == 0)
            {
                return new Point2f[0];
            }
            Point2f[] dst = new Point2f[size];
            using (ArrayAddress1<Point2f> dstPtr = new ArrayAddress1<Point2f>(dst))
            {
                Util.CopyMemory(dstPtr, ElemPtr, Point2f.SizeOf * dst.Length);
            }
            return dst;
        }
        #endregion
    }
}
