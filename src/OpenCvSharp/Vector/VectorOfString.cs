using System;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    internal class VectorOfString : DisposableCvObject, IStdVector<string>
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Dispose

        /// <summary>
        /// 
        /// </summary>
        public VectorOfString()
        {
            ptr = NativeMethods.vector_string_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfString(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfString(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = NativeMethods.vector_string_new2(new IntPtr(size));
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
                        NativeMethods.vector_string_delete(ptr);
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
            get { return NativeMethods.vector_string_getSize(ptr).ToInt32(); }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return NativeMethods.vector_string_getPointer(ptr); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public string[] ToArray()
        {
            int size = Size;
            if (size == 0)
                return new string[0];

            var ret = new string[size];
            for (int i = 0; i < size; i++)
            {
                unsafe
                {
                    sbyte* p = NativeMethods.vector_string_elemAt(ptr, i);
                    ret[i] = new string(p);
                }
            }
            return ret;
        }

        #endregion
    }
}
