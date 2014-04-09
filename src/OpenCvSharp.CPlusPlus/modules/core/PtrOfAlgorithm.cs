using System;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Template class for smart reference-counting pointers
    /// </summary>
    internal class PtrOfAlgorithm : Ptr<Algorithm>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        public PtrOfAlgorithm(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawPtr"></param>
        public static PtrOfAlgorithm FromRawPtr(IntPtr rawPtr)
        {
            return new PtrOfAlgorithm(NativeMethods.core_Ptr_Algorithm_new(rawPtr));
        }

        /// <summary>
        /// Calls native release function
        /// </summary>
        protected override void Release()
        {
            NativeMethods.core_Ptr_Algorithm_delete(ptr);
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj 
        /// </summary>
        /// <returns></returns>
        protected override IntPtr GetObj()
        {
            return NativeMethods.core_Ptr_Algorithm_obj(ptr);
        }

        /// <summary>
        /// Converts raw pointer to managed wrapper object
        /// </summary>
        /// <returns></returns>
        protected override Algorithm ToWrapperObject()
        {
            return Algorithm.FromRawPtr(ptr);
        }
    }
}
