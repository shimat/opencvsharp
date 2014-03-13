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
                        Release(ptr);
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
        /// <param name="self"></param>
        protected abstract void Release(IntPtr self);

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        public T Obj
        {
            get
            {
                IntPtr obj = GetObjPtr(ptr);
                return ObjPtrToValue(obj);
            }
        }
        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj pointer
        /// </summary>
        public IntPtr ObjPointer
        {
            get
            {
                return GetObjPtr(ptr);
            }
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj pointer
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        protected abstract IntPtr GetObjPtr(IntPtr self);

        /// <summary>
        /// Converts raw pointer (not Ptr&lt;T&gt; but T*) to managed wrapper object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected abstract T ObjPtrToValue(IntPtr obj);
    }
}
