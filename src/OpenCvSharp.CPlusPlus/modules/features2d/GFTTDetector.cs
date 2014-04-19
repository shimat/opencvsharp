/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// Good Features To Track Detector
    /// </summary>
    public class GFTTDetector : FeatureDetector
    {
        private bool disposed;
        private Ptr<GFTTDetector> detectorPtr;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxCorners"></param>
        /// <param name="qualityLevel"></param>
        /// <param name="minDistance"></param>
        /// <param name="blockSize"></param>
        /// <param name="useHarrisDetector"></param>
        /// <param name="k"></param>
        public GFTTDetector(int maxCorners = 1000, double qualityLevel = 0.01, double minDistance = 1,
                          int blockSize = 3, bool useHarrisDetector = false, double k = 0.04)
        {
            ptr = NativeMethods.features2d_GFTTDetector_new(maxCorners, qualityLevel, minDistance, 
                blockSize, useHarrisDetector ? 1 : 0, k);
        }

        /// <summary>
        /// Creates instance by cv::Ptr&lt;cv::SURF&gt;
        /// </summary>
        internal GFTTDetector(Ptr<GFTTDetector> detectorPtr)
        {
            this.detectorPtr = detectorPtr;
            this.ptr = detectorPtr.Obj;
        }
        /// <summary>
        /// Creates instance by raw pointer cv::SURF*
        /// </summary>
        internal GFTTDetector(IntPtr rawPtr)
        {
            detectorPtr = null;
            ptr = rawPtr;
        }
        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static new GFTTDetector FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<GFTTDetector> pointer");
            var ptrObj = new Ptr<GFTTDetector>(ptr);
            return new GFTTDetector(ptrObj);
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
                            NativeMethods.features2d_GFTTDetector_delete(ptr);
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
                return NativeMethods.features2d_GFTTDetector_info(ptr);
            }
        }
        #endregion
    }
}
