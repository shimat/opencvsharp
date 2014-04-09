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
        protected override void Release()
        {
            NativeMethods.features2d_Ptr_DescriptorMatcher_delete(ptr);
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        /// <returns></returns>
        protected override IntPtr GetObj()
        {
            return NativeMethods.features2d_Ptr_DescriptorMatcher_obj(ptr);
        }

        /// <summary>
        /// Converts raw pointer to managed wrapper object
        /// </summary>
        /// <returns></returns>
        protected override DescriptorMatcher ToWrapperObject()
        {
            return DescriptorMatcher.FromRawPtr(ptr);
        }
    }
}
