/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

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
        public StarDetector(int maxSize = 45, int responseThreshold = 30, int lineThresholdProjected = 10, 
            int lineThresholdBinarized = 8, int suppressNonmaxSize = 5)
        {
            ptr = NativeMethods.features2d_StarDetector_new(
                maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized, suppressNonmaxSize);
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
                    if (ptr != IntPtr.Zero)
                        NativeMethods.features2d_StarDetector_delete(ptr);
                    ptr = IntPtr.Zero;
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
            NativeMethods.features2d_StarDetector_detect(ptr, image.CvPtr, out keypoints);

            using (VectorOfKeyPoint keypointsVec = new VectorOfKeyPoint(keypoints))
            {
                return keypointsVec.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override AlgorithmInfo Info
        {
            get
            {
                ThrowIfDisposed();
                IntPtr pInfo = NativeMethods.features2d_StarDetector_info(ptr);
                return new AlgorithmInfo(pInfo);
            }
        }
        #endregion
    }
}
