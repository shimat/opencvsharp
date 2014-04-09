using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Template class for smart reference-counting pointers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class Ptr<T> : DisposableCvObject
    {
        private bool disposed;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        protected Ptr(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Release function
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (ptr != IntPtr.Zero)
                    {
                        Release();
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        /// <summary>
        /// Calls native release function
        /// </summary>
        protected abstract void Release();

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        public T WrapperObject
        {
            get { return ToWrapperObject(); }
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj pointer
        /// </summary>
        public IntPtr Obj
        {
            get { return GetObj(); }
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj pointer
        /// </summary>
        /// <returns></returns>
        protected abstract IntPtr GetObj();

        /// <summary>
        /// Converts raw pointer (not Ptr&lt;T&gt; but T*) to managed wrapper object
        /// </summary>
        /// <returns></returns>
        protected abstract T ToWrapperObject();
    }
}
