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
        protected override void Release()
        {
            NativeMethods.features2d_Ptr_FeatureDetector_delete(ptr);
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        /// <returns></returns>
        protected override IntPtr GetObj()
        {
            return NativeMethods.features2d_Ptr_FeatureDetector_obj(ptr);
        }

        /// <summary>
        /// Converts raw pointer (not Ptr&lt;T&gt; but T*) to managed wrapper object
        /// </summary>
        /// <returns></returns>
        protected override FeatureDetector ToWrapperObject()
        {
            return FeatureDetector.FromRawPtr(GetObj());
        }
    }
}
