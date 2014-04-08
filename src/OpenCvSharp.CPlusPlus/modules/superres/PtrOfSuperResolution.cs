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
        /// <param name="self"></param>
        protected override void Release(IntPtr self)
        {
            NativeMethods.superres_Ptr_SuperResolution_delete(self);
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        protected override IntPtr GetObjPtr(IntPtr self)
        {
            return NativeMethods.superres_Ptr_SuperResolution_obj(self);
        }

        /// <summary>
        /// Converts raw pointer to managed wrapper object
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        protected override SuperResolutionImpl ObjPtrToValue(IntPtr ptr)
        {
            return SuperResolutionImpl.FromRawPtr(ptr);
        }
    }
}
