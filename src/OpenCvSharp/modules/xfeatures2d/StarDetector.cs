using System;

namespace OpenCvSharp.XFeatures2D
{
#if LANG_JP
    /// <summary>
    /// Star Detector
    /// </summary>
#else
    /// <summary>
    /// The "Star" Detector
    /// </summary>
#endif
    [Serializable]
    public class StarDetector : Feature2D
    {
        private bool disposed;
        private Ptr<StarDetector> ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        internal StarDetector(IntPtr p)
        {
            ptrObj = new Ptr<StarDetector>(p);
            ptr = ptrObj.Get();
        }

#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
        /// <param name="lineThresholdBinarized"></param>
        /// <param name="suppressNonmaxSize"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
        /// <param name="lineThresholdBinarized"></param>
        /// <param name="suppressNonmaxSize"></param>
#endif
        public static StarDetector Create(
            int maxSize = 45, 
            int responseThreshold = 30, 
            int lineThresholdProjected = 10, 
            int lineThresholdBinarized = 8,
            int suppressNonmaxSize = 5)
        {
            IntPtr ptr = NativeMethods.xfeatures2d_StarDetector_create(
                maxSize, responseThreshold, lineThresholdProjected, 
                lineThresholdBinarized, suppressNonmaxSize);
            return new StarDetector(ptr);
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
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
                        }
                    }
                    // releases unmanaged resources

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

        #endregion
    }
}
