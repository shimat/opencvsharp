using System;
using System.Collections.Generic;
using OpenCvSharp.Face;
using OpenCvSharp.ML;
using OpenCvSharp.XFeatures2D;
using OpenCvSharp.XImgProc;

namespace OpenCvSharp
{
    /// <summary>
    /// Template class for smart reference-counting pointers
    /// </summary>
    internal abstract class Ptr : DisposableCvObject
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
        /// Returns Ptr&lt;T&gt;.get() pointer
        /// </summary>
        public abstract IntPtr Get();

        /// <summary>
        /// Deletes Ptr&lt;T&gt;.get() pointer
        /// </summary>
        protected abstract void Release();

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
                    }
                    ptr = IntPtr.Zero;
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

    }
}
