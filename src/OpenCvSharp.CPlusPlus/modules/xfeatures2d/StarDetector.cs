using System;

namespace OpenCvSharp.CPlusPlus
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
    public class StarDetector : FeatureDetector
    {
        private bool disposed;
        private Ptr<StarDetector> detectorPtr;

        #region Init & Disposal
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
        public StarDetector(
            int maxSize = 45, 
            int responseThreshold = 30, 
            int lineThresholdProjected = 10, 
            int lineThresholdBinarized = 8,
            int suppressNonmaxSize = 5)
        {
            ptr = NativeMethods.xfeatures2d_StarDetector_new(
                maxSize, responseThreshold, lineThresholdProjected, 
                lineThresholdBinarized, suppressNonmaxSize);
        }

        /// <summary>
        /// Creates instance by cv::Ptr&lt;cv::SURF&gt;
        /// </summary>
        internal StarDetector(Ptr<StarDetector> detectorPtr)
        {
            this.detectorPtr = detectorPtr;
            this.ptr = detectorPtr.Get();
        }
        /// <summary>
        /// Creates instance by raw pointer cv::SURF*
        /// </summary>
        internal StarDetector(IntPtr rawPtr)
        {
            detectorPtr = null;
            ptr = rawPtr;
        }
        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static new StarDetector FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<StarDetector> pointer");
            var ptrObj = new Ptr<StarDetector>(ptr);
            return new StarDetector(ptrObj);
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
                            NativeMethods.xfeatures2d_StarDetector_delete(ptr);
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
#if LANG_JP
        /// <summary>
        /// StarDetectorアルゴリズムによりキーポイントを取得する
        /// </summary>
        /// <param name="image">8ビット グレースケールの入力画像</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves keypoints using the StarDetector algorithm.
        /// </summary>
        /// <param name="image">The input 8-bit grayscale image</param>
        /// <returns></returns>
#endif
        public KeyPoint[] Run(Mat image)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();

            IntPtr keypoints;
            NativeMethods.xfeatures2d_StarDetector_detect(ptr, image.CvPtr, out keypoints);

            using (VectorOfKeyPoint keypointsVec = new VectorOfKeyPoint(keypoints))
            {
                return keypointsVec.ToArray();
            }
        }


        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get { return NativeMethods.xfeatures2d_StarDetector_info(ptr); }
        }

        #endregion
    }
}
