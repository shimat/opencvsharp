using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// Detects corners using FAST algorithm by E. Rosten
    /// </summary>
#else
    /// <summary>
    /// Detects corners using FAST algorithm by E. Rosten
    /// </summary>
#endif
    public class FastFeatureDetector : FeatureDetector
    {
        private bool disposed;
        private Ptr<FastFeatureDetector> detectorPtr;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="threshold"></param>
        /// <param name="nonmaxSuppression"></param>
        public FastFeatureDetector(int threshold = 10, bool nonmaxSuppression = true)
        {
            ptr = NativeMethods.features2d_FastFeatureDetector_new(threshold, nonmaxSuppression ? 1 : 0);
        }

        /// <summary>
        /// Creates instance by cv::Ptr&lt;cv::SURF&gt;
        /// </summary>
        internal FastFeatureDetector(Ptr<FastFeatureDetector> detectorPtr)
        {
            this.detectorPtr = detectorPtr;
            this.ptr = detectorPtr.Get();
        }

        /// <summary>
        /// Creates instance by raw pointer cv::SURF*
        /// </summary>
        internal FastFeatureDetector(IntPtr rawPtr)
        {
            detectorPtr = null;
            ptr = rawPtr;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static new FastFeatureDetector FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<FastFeatureDetector> pointer");
            var ptrObj = new Ptr<FastFeatureDetector>(ptr);
            return new FastFeatureDetector(ptrObj);
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
                            NativeMethods.features2d_FastFeatureDetector_delete(ptr);
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
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public KeyPoint[] Run(Mat image, Mat mask)
        {
            ThrowIfDisposed();
            return base.Detect(image, mask);
        }


        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get
            {
                return NativeMethods.features2d_FastFeatureDetector_info(ptr);
            }
        }
        #endregion
    }
}
