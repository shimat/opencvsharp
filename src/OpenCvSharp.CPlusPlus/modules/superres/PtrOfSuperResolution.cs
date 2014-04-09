using System;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Template class for smart reference-counting pointers
    /// </summary>
    internal class PtrOfSuperResolution : Ptr<SuperResolutionImpl>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        public PtrOfSuperResolution(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Calls native release function
        /// </summary>
        protected override void Release()
        {
            NativeMethods.superres_Ptr_SuperResolution_delete(ptr);
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        /// <returns></returns>
        protected override IntPtr GetObj()
        {
            return NativeMethods.superres_Ptr_SuperResolution_obj(ptr);
        }

        /// <summary>
        /// Converts raw pointer to managed wrapper object
        /// </summary>
        /// <returns></returns>
        protected override SuperResolutionImpl ToWrapperObject()
        {
            return SuperResolutionImpl.FromRawPtr(ptr);
        }
    }
}
