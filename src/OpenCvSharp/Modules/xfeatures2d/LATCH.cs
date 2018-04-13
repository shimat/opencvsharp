using System;

namespace OpenCvSharp.XFeatures2D
{
    /// <summary>
    /// LATCH Descriptor. 
    /// 
    /// latch Class for computing the LATCH descriptor.
    /// If you find this code useful, please add a reference to the following paper in your work: 
    /// Gil Levi and Tal Hassner, "LATCH: Learned Arrangements of Three Patch Codes", arXiv preprint arXiv:1501.03719, 15 Jan. 2015.
    ///
    /// Note: a complete example can be found under /samples/cpp/tutorial_code/xfeatures2D/latch_match.cpp
    /// </summary>
    [Serializable]
    public class LATCH : Feature2D
    {
        private Ptr ptrObj;

        /// <summary>
        /// 
        /// </summary>
        internal LATCH(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bytes">the size of the descriptor - can be 64, 32, 16, 8, 4, 2 or 1</param>
        /// <param name="rotationInvariance">whether or not the descriptor should compansate for orientation changes.</param>
        /// <param name="halfSsdSize">the size of half of the mini-patches size. For example, if we would like to compare triplets of patches of size 7x7x
        /// then the half_ssd_size should be (7-1)/2 = 3.</param>
        /// <param name="sigma">sigma value for GaussianBlur smoothing of the source image. Source image will be used without smoothing in case sigma value is 0.
        /// Note: the descriptor can be coupled with any keypoint extractor. The only demand is that if you use set rotationInvariance = True then
        /// you will have to use an extractor which estimates the patch orientation (in degrees). Examples for such extractors are ORB and SIFT.</param>
        public static LATCH Create(int bytes = 32, bool rotationInvariance = true, int halfSsdSize = 3, double sigma = 2.0)
        {
            IntPtr ptr = NativeMethods.xfeatures2d_LATCH_create(
                bytes, rotationInvariance ? 1 : 0, halfSsdSize, sigma);
            return new LATCH(ptr);
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
                var res =  NativeMethods.xfeatures2d_Ptr_LATCH_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.xfeatures2d_Ptr_LATCH_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
