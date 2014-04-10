using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Template class for smart reference-counting pointers
    /// </summary>
    internal class PtrOfBackgroundSubtractorMOG : Ptr<BackgroundSubtractorMOG>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        public PtrOfBackgroundSubtractorMOG(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Calls native release function
        /// </summary>
        protected override void Release()
        {
            NativeMethods.video_Ptr_BackgroundSubtractorMOG_delete(ptr);
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        /// <returns></returns>
        protected override IntPtr GetObj()
        {
            return NativeMethods.video_Ptr_BackgroundSubtractorMOG_obj(ptr);
        }

        /// <summary>
        /// Converts raw pointer (not Ptr&lt;T&gt; but T*) to managed wrapper object
        /// </summary>
        /// <returns></returns>
        protected override BackgroundSubtractorMOG ToWrapperObject()
        {
            return BackgroundSubtractorMOG.FromRawPtr(GetObj());
        }
    }
}
