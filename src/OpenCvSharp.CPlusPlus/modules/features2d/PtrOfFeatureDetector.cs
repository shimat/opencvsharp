using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Template class for smart reference-counting pointers
    /// </summary>
    internal class PtrOfFeatureDetector : Ptr<FeatureDetector>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        public PtrOfFeatureDetector(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Calls native release function
        /// </summary>
        /// <param name="self"></param>
        protected override void Release(IntPtr self)
        {
            NativeMethods.features2d_Ptr_FeatureDetector_delete(self);
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        protected override IntPtr GetObjPtr(IntPtr self)
        {
            return NativeMethods.features2d_Ptr_FeatureDetector_obj(self);
        }

        /// <summary>
        /// Converts raw pointer (not Ptr&lt;T&gt; but T*) to managed wrapper object
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        protected override FeatureDetector ObjPtrToValue(IntPtr ptr)
        {
            return FeatureDetector.FromRawPtr(ptr);
        }
    }
}
