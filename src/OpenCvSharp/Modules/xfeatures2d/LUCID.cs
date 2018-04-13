using System;

namespace OpenCvSharp.XFeatures2D
{
    /// <summary>
    /// Class implementing the locally uniform comparison image descriptor, described in @cite LUCID.
    /// 
    /// An image descriptor that can be computed very fast, while being 
    /// about as robust as, for example, SURF or BRIEF.
    /// @note It requires a color image as input.
    /// </summary>
    [Serializable]
    public class LUCID : Feature2D
    {
        private Ptr ptrObj;

        /// <summary>
        /// 
        /// </summary>
        internal LUCID(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lucidKernel">kernel for descriptor construction, where 1=3x3, 2=5x5, 3=7x7 and so forth</param>
        /// <param name="blurKernel">kernel for blurring image prior to descriptor construction, where 1=3x3, 2=5x5, 3=7x7 and so forth</param>
        public static LUCID Create(int lucidKernel = 1, int blurKernel = 2)
        {
            IntPtr ptr = NativeMethods.xfeatures2d_LUCID_create(
                lucidKernel, blurKernel);
            return new LUCID(ptr);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res =  NativeMethods.xfeatures2d_Ptr_LUCID_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.xfeatures2d_Ptr_LUCID_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
