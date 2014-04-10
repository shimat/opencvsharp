using System;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Template class for smart reference-counting pointers
    /// </summary>
    internal class PtrOfBackgroundSubtractorMOG2 : Ptr<BackgroundSubtractorMOG2>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        public PtrOfBackgroundSubtractorMOG2(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Calls native release function
        /// </summary>
        protected override void Release()
        {
            NativeMethods.video_Ptr_BackgroundSubtractorMOG2_delete(ptr);
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
        protected override BackgroundSubtractorMOG2 ToWrapperObject()
        {
            return BackgroundSubtractorMOG2.FromRawPtr(GetObj());
        }
    }
}
