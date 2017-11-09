using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Ballard, D.H. (1981). Generalizing the Hough transform to detect arbitrary shapes. 
    /// Pattern Recognition 13 (2): 111-122.
    /// Detects position only without traslation and rotation
    /// </summary>
    public class GeneralizedHoughBallard : GeneralizedHough
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt; object
        /// </summary>
        private Ptr ptrObj;

        /// <summary>
        /// 
        /// </summary>
        private GeneralizedHoughBallard(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates a predefined GeneralizedHoughBallard object
        /// </summary>
        /// <returns></returns>
        public static GeneralizedHoughBallard Create()
        {
            IntPtr ptr = NativeMethods.imgproc_createGeneralizedHoughBallard();
            return new GeneralizedHoughBallard(ptr);
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

        /// <summary>
        /// R-Table levels.
        /// </summary>
        /// <returns></returns>
        public int Levels
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughBallard_getLevels(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughBallard_setLevels(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// The accumulator threshold for the template centers at the detection stage. 
        /// The smaller it is, the more false positions may be detected.
        /// </summary>
        /// <returns></returns>
        public int VotesThreshold
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughBallard_getVotesThreshold(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughBallard_setVotesThreshold(ptr, value);
                GC.KeepAlive(this);
            }
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.imgproc_Ptr_GeneralizedHoughBallard_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.imgproc_Ptr_GeneralizedHoughBallard_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
