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
        private bool disposed;

        /// <summary>
        /// cv::Ptr&lt;T&gt; object
        /// </summary>
        private Ptr<GeneralizedHoughBallard> ptrObj;

        /// <summary>
        /// 
        /// </summary>
        private GeneralizedHoughBallard(IntPtr p)
        {
            ptrObj = new Ptr<GeneralizedHoughBallard>(p);
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

#if LANG_JP
    /// <summary>
    /// リソースの解放
    /// </summary>
    /// <param name="disposing">
    /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
    /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
    ///</param>
#else
        /// <summary>
        /// Releases the resources
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    // releases managed resources
                    if (disposing)
                    {
                    }
                    // releases unmanaged resources
                    if (IsEnabledDispose)
                    {
                        if (ptrObj != null)
                            ptrObj.Dispose();
                        ptrObj = null;
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        /// <summary>
        /// R-Table levels.
        /// </summary>
        /// <returns></returns>
        public int Levels
        {
            get
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughBallard_getLevels(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughBallard_setLevels(ptr, value);
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
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughBallard_getVotesThreshold(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughBallard_setVotesThreshold(ptr, value);
            }
        }
    }
}
