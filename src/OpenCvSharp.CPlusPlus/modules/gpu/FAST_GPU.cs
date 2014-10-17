using System;

namespace OpenCvSharp.CPlusPlus.Gpu
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Class used for corner detection using the FAST algorithm.
    /// </summary>
    public class FAST_GPU : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// all features have same size
        /// </summary>
        public const int FEATURE_SIZE = 7;

        #region Init and Disposal

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="threshold">Threshold on difference between intensity of the central pixel and pixels on a circle around this pixel.</param>
        /// <param name="nonmaxSuppression">If it is true, non-maximum suppression is applied to detected corners (keypoints).</param>
        /// <param name="keypointsRatio">Inner buffer size for keypoints store is determined as (keypointsRatio * image_width * image_height).</param>
        public FAST_GPU(int threshold, bool nonmaxSuppression = true, double keypointsRatio = 0.05)
        {
            Cv2Gpu.ThrowIfGpuNotAvailable();
            ptr = NativeMethods.gpu_FAST_GPU_new(threshold, nonmaxSuppression ? 1 : 0, keypointsRatio);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
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
    /// Clean up any resources being used.
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
                    if (IsEnabledDispose)
                    {
                        NativeMethods.gpu_FAST_GPU_delete(ptr);
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

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public bool NonmaxSuppression
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.gpu_FAST_GPU_nonmaxSuppression_get(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.gpu_FAST_GPU_nonmaxSuppression_set(ptr, value ? 0 : 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Threshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.gpu_FAST_GPU_threshold_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.gpu_FAST_GPU_threshold_set(ptr, value);
            }
        }

        /// <summary>
        /// max keypoints = keypointsRatio * img.size().area()
        /// </summary>
        public double KeypointsRatio
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.gpu_FAST_GPU_keypointsRatio_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.gpu_FAST_GPU_keypointsRatio_set(ptr, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Releases inner buffer memory.
        /// </summary>
        public void Release()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.gpu_FAST_GPU_release(ptr);
        }

        /// <summary>
        /// Finds the keypoints using FAST detector.
        /// </summary>
        /// <param name="image">Image where keypoints (corners) are detected. 
        /// Only 8-bit grayscale images are supported.</param>
        /// <param name="mask">Optional input mask that marks the regions where we should detect features.</param>
        /// <param name="keypoints">The output vector of keypoints.</param>
        public void Run(GpuMat image, GpuMat mask, GpuMat keypoints)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (image == null)
                throw new ArgumentNullException("image");
            if (mask == null)
                throw new ArgumentNullException("mask");
            if (keypoints == null)
                throw new ArgumentNullException("keypoints");

            NativeMethods.gpu_FAST_GPU_operator1(ptr, image.CvPtr, mask.CvPtr, keypoints.CvPtr);

            GC.KeepAlive(image);
            GC.KeepAlive(mask);
            GC.KeepAlive(keypoints);
        }

        /// <summary>
        /// Finds the keypoints using FAST detector.
        /// </summary>
        /// <param name="image">Image where keypoints (corners) are detected. 
        /// Only 8-bit grayscale images are supported.</param>
        /// <param name="mask">Optional input mask that marks the regions where we should detect features.</param>
        /// <returns>The output vector of keypoints.</returns>
        public KeyPoint[] Run(GpuMat image, GpuMat mask)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (image == null)
                throw new ArgumentNullException("image");
            if (mask == null)
                throw new ArgumentNullException("mask");

            KeyPoint[] result;
            using (var keypoints = new VectorOfKeyPoint())
            {
                NativeMethods.gpu_FAST_GPU_operator2(ptr, image.CvPtr, mask.CvPtr, keypoints.CvPtr);
                result = keypoints.ToArray();
            }

            GC.KeepAlive(image);
            GC.KeepAlive(mask);
            return result;
        }

        /// <summary>
        /// Download keypoints from GPU to CPU memory.
        /// </summary>
        /// <param name="dKeypoints"></param>
        /// <returns></returns>
        public KeyPoint[] DownloadKeypoints(GpuMat dKeypoints)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (dKeypoints == null)
                throw new ArgumentNullException("dKeypoints");

            KeyPoint[] result;
            using (var keypoints = new VectorOfKeyPoint())
            {
                NativeMethods.gpu_FAST_GPU_downloadKeypoints(ptr, dKeypoints.CvPtr, keypoints.CvPtr);
                result = keypoints.ToArray();
            }

            GC.KeepAlive(dKeypoints);
            return result;
        }

        /// <summary>
        /// Converts keypoints from GPU representation to vector of KeyPoint.
        /// </summary>
        /// <param name="hKeypoints"></param>
        /// <returns></returns>
        public KeyPoint[] ConvertKeypoints(Mat hKeypoints)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (hKeypoints == null)
                throw new ArgumentNullException("hKeypoints");

            KeyPoint[] result;
            using (var keypoints = new VectorOfKeyPoint())
            {
                NativeMethods.gpu_FAST_GPU_convertKeypoints(ptr, hKeypoints.CvPtr, keypoints.CvPtr);
                result = keypoints.ToArray();
            }

            GC.KeepAlive(hKeypoints);
            return result;
        }

        /// <summary>
        /// Find keypoints and compute it’s response if nonmaxSuppression is true.
        /// </summary>
        /// <param name="image">Image where keypoints (corners) are detected. Only 8-bit grayscale images are supported.</param>
        /// <param name="mask">Optional input mask that marks the regions where we should detect features.</param>
        /// <returns>count of detected keypoints</returns>
        public int CalcKeyPointsLocation(GpuMat image, GpuMat mask)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (image == null)
                throw new ArgumentNullException("image");
            if (mask == null)
                throw new ArgumentNullException("mask");

            int result = NativeMethods.gpu_FAST_GPU_calcKeyPointsLocation(ptr, image.CvPtr, mask.CvPtr);

            GC.KeepAlive(image);
            GC.KeepAlive(mask);
            return result;
        }

        /// <summary>
        /// Gets final array of keypoints.
        /// Performs nonmax suppression if needed.
        /// </summary>
        /// <param name="keypoints"></param>
        /// <returns>Final count of keypoints</returns>
        public int GetKeyPoints(GpuMat keypoints)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (keypoints == null)
                throw new ArgumentNullException("keypoints");

            int result = NativeMethods.gpu_FAST_GPU_getKeyPoints(ptr, keypoints.CvPtr);

            GC.KeepAlive(keypoints);
            return result;
        }

        #endregion
    }
}
