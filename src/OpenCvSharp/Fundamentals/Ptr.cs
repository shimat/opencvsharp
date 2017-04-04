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
    public abstract class Ptr : DisposableCvObject
    {
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
    }
}
