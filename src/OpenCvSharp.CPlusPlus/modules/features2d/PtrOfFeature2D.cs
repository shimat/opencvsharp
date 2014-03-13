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
        /// <param name="self"></param>
        protected override void Release(IntPtr self)
        {
            CppInvoke.core_Ptr_Feature2D_delete(self);
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        protected override IntPtr GetObjPtr(IntPtr self)
        {
            return CppInvoke.core_Ptr_Feature2D_obj(self);
        }

        /// <summary>
        /// Converts raw pointer to managed wrapper object
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        protected override Feature2D ObjPtrToValue(IntPtr ptr)
        {
            return Feature2D.FromRawPtr(ptr);
        }
    }
}
