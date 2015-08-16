using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;
using OpenCvSharp.ML;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    internal class VectorOfDTreesSplit : DisposableCvObject, IStdVector<DTrees.Split>
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose

        /// <summary>
        /// 
        /// </summary>
        public VectorOfDTreesSplit()
        {
            ptr = NativeMethods.vector_DTrees_Split_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfDTreesSplit(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfDTreesSplit(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = NativeMethods.vector_DTrees_Split_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfDTreesSplit(IEnumerable<DTrees.Split> data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            DTrees.Split[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_DTrees_Split_new3(array, new IntPtr(array.Length));
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
                        NativeMethods.vector_DTrees_Split_delete(ptr);
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
            get { return NativeMethods.vector_DTrees_Split_getSize(ptr).ToInt32(); }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return NativeMethods.vector_DTrees_Split_getPointer(ptr); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public DTrees.Split[] ToArray()
        {
            int size = Size;
            if (size == 0)
            {
                return new DTrees.Split[0];
            }
            var dst = new DTrees.Split[size];
            using (var dstPtr = new ArrayAddress1<DTrees.Split>(dst))
            {
                Utility.CopyMemory(dstPtr, ElemPtr, Marshal.SizeOf(typeof(DTrees.Split)) * dst.Length);
            }
            return dst;
        }

        #endregion
    }
}
