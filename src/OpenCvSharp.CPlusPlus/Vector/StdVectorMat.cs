using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    internal class StdVectorMat : DisposableCvObject, IStdVector
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose
        /// <summary>
        /// 
        /// </summary>
        public StdVectorMat()
        {
            ptr = CppInvoke.vector_Mat_new1();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public StdVectorMat(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = CppInvoke.vector_Mat_new2(new IntPtr(size));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public StdVectorMat(IntPtr ptr)
        {
            this.ptr = ptr;
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
                        CppInvoke.vector_Mat_delete(ptr);
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
            get { return CppInvoke.vector_Mat_getSize(ptr).ToInt32(); }
        }
        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return CppInvoke.vector_Mat_getPointer(ptr); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Mat[] ToArray()
        {
            int size = Size;
            if (size == 0)
                return new Mat[0];

            // Matインスタンスをこちらで用意し、vectorの各要素をそこに代入する。
            // 別インスタンスとはなるが、vector解放時にMatが全部解放されてしまうので
            // 致し方なしか・・・
            Mat[] dst = new Mat[size];
            IntPtr[] dstPtr = new IntPtr[size];
            for (int i = 0; i < size; i++)
            {
                Mat m = new Mat();
                dst[i] = m;
                dstPtr[i] = m.CvPtr;
            }
            CppInvoke.vector_Mat_assignToArray(ptr, dstPtr);

            return dst;
        }

        /// <summary>
        /// 各要素の参照カウントを1追加する
        /// </summary>
        public void AddRef()
        {
            CppInvoke.vector_Mat_addref(ptr);
        }
        #endregion
    }
}
