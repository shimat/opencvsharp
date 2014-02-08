using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 
    /// </summary>
    public class StdVectorFloat : DisposableCvObject, IStdVector
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose
        /// <summary>
        /// 
        /// </summary>
        public StdVectorFloat()
        {
            ptr = CppInvoke.vector_float_new1();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public StdVectorFloat(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = CppInvoke.vector_float_new2(new IntPtr(size));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public StdVectorFloat(IEnumerable<float> data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            float[] array = Util.ToArray(data);
            ptr = CppInvoke.vector_float_new3(array, new IntPtr(array.Length));
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
                        CppInvoke.vector_float_delete(ptr);
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
            get { return CppInvoke.vector_float_getSize(ptr).ToInt32(); }
        }
        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return CppInvoke.vector_float_getPointer(ptr); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public float[] ToArray()
        {            
            int size = Size;
            if (size == 0)
            {
                return new float[0];
            }
            float[] dst = new float[size];
            Marshal.Copy(ElemPtr, dst, 0, dst.Length);
            return dst;
        }
        #endregion
    }
}
