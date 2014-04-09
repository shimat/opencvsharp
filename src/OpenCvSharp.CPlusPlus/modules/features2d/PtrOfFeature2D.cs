using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Template class for smart reference-counting pointers
    /// </summary>
    internal class PtrOfFeature2D : Ptr<Feature2D>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        public PtrOfFeature2D(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Calls native release function
        /// </summary>
        protected override void Release()
        {
            NativeMethods.features2d_Ptr_Feature2D_delete(ptr);
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        /// <returns></returns>
        protected override IntPtr GetObj()
        {
            return NativeMethods.features2d_Ptr_Feature2D_obj(ptr);
        }

        /// <summary>
        /// Converts raw pointer to managed wrapper object
        /// </summary>
        /// <returns></returns>
        protected override Feature2D ToWrapperObject()
        {
            return Feature2D.FromRawPtr(ptr);
        }
    }
}
