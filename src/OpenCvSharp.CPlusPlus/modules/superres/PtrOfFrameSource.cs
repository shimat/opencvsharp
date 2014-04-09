using System;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Template class for smart reference-counting pointers
    /// </summary>
    internal class PtrOfFrameSource : Ptr<FrameSource>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        public PtrOfFrameSource(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Calls native release function
        /// </summary>
        protected override void Release()
        {
            NativeMethods.superres_Ptr_FrameSource_delete(ptr);
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        /// <returns></returns>
        protected override IntPtr GetObj()
        {
            return NativeMethods.superres_Ptr_FrameSource_obj(ptr);
        }

        /// <summary>
        /// Converts raw pointer to managed wrapper object
        /// </summary>
        /// <returns></returns>
        protected override FrameSource ToWrapperObject()
        {
            return FrameSourceImpl.FromRawPtr(ptr);
        }
    }
}
