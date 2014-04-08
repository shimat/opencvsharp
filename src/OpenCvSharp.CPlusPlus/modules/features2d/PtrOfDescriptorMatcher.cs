using System;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Template class for smart reference-counting pointers
    /// </summary>
    internal class PtrOfDescriptorMatcher : Ptr<DescriptorMatcher>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        public PtrOfDescriptorMatcher(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Calls native release function
        /// </summary>
        /// <param name="self"></param>
        protected override void Release(IntPtr self)
        {
            NativeMethods.features2d_Ptr_DescriptorMatcher_delete(self);
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        protected override IntPtr GetObjPtr(IntPtr self)
        {
            return NativeMethods.features2d_Ptr_DescriptorMatcher_obj(self);
        }

        /// <summary>
        /// Converts raw pointer to managed wrapper object
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        protected override DescriptorMatcher ObjPtrToValue(IntPtr ptr)
        {
            return DescriptorMatcher.FromRawPtr(ptr);
        }
    }
}
