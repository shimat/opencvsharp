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
        private bool disposed;
        private Ptr<BFMatcher> detectorPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="normType"></param>
        /// <param name="crossCheck"></param>
        public BFMatcher(NormTypes normType = NormTypes.L2, bool crossCheck = false)
        {
            ptr = NativeMethods.features2d_BFMatcher_new((int) normType, crossCheck ? 1 : 0);
        }

        /// <summary>
        /// Creates instance by cv::Ptr&lt;T&gt;
        /// </summary>
        internal BFMatcher(Ptr<BFMatcher> detectorPtr)
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
            var ptrObj = new Ptr<BFMatcher>(ptr);
            return new BFMatcher(ptrObj);
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
                    if (detectorPtr != null)
                    {
                        detectorPtr.Dispose();
                        detectorPtr = null;
                    }
                    else
                    {
                        if (ptr != IntPtr.Zero)
                            NativeMethods.features2d_BFMatcher_delete(ptr);
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

        #endregion

        #region Methods

        /// <summary>
        /// Return true if the matcher supports mask in match methods.
        /// </summary>
        /// <returns></returns>
        public override bool IsMaskSupported()
        {
            ThrowIfDisposed();
            return NativeMethods.features2d_BFMatcher_isMaskSupported(ptr) != 0;
        }

        #endregion
    }
}
