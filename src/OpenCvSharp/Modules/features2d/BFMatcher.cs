using System;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// Brute-force descriptor matcher.
    /// For each descriptor in the first set, this matcher finds the closest descriptor in the second set by trying each one.
    /// </summary>
    public class BFMatcher : DescriptorMatcher
    {
        private Ptr detectorPtr;

        //internal override IntPtr PtrObj => detectorPtr.CvPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="normType"></param>
        /// <param name="crossCheck"></param>
        public BFMatcher(NormTypes normType = NormTypes.L2, bool crossCheck = false)
        {
            ptr = NativeMethods.features2d_BFMatcher_new((int) normType, crossCheck ? 1 : 0);
            detectorPtr = null;
        }

        /// <summary>
        /// Creates instance by cv::Ptr&lt;T&gt;
        /// </summary>
        internal BFMatcher(Ptr detectorPtr)
        {
            this.detectorPtr = detectorPtr;
            this.ptr = detectorPtr.Get();
        }

        /// <summary>
        /// Creates instance by raw pointer T*
        /// </summary>
        internal BFMatcher(IntPtr rawPtr)
        {
            detectorPtr = null;
            ptr = rawPtr;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal new static BFMatcher FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<BFMatcher> pointer");
            var ptrObj = new Ptr(ptr);
            return new BFMatcher(ptrObj);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            if (detectorPtr != null)
            {
                detectorPtr.Dispose();
                detectorPtr = null;
                ptr = IntPtr.Zero;
            }
            base.DisposeManaged();
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            if (detectorPtr == null && ptr != IntPtr.Zero)
                NativeMethods.features2d_BFMatcher_delete(ptr);
            ptr = IntPtr.Zero;
            base.DisposeUnmanaged();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Return true if the matcher supports mask in match methods.
        /// </summary>
        /// <returns></returns>
        public override bool IsMaskSupported()
        {
            ThrowIfDisposed();
            var res = NativeMethods.features2d_BFMatcher_isMaskSupported(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.features2d_Ptr_BFMatcher_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_BFMatcher_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
