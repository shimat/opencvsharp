using System;

namespace OpenCvSharp.CPlusPlus.Gpu
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Class for extracting ORB features and descriptors from an image.
    /// </summary>
    public class ORB_GPU : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// all features have same size
        /// </summary>
        public const int DEFAULT_FAST_THRESHOLD = 20;

        #region Init and Disposal

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="nFeatures">The number of desired features.</param>
        /// <param name="scaleFactor">Coefficient by which we divide the dimensions from one scale pyramid level to the next.</param>
        /// <param name="nLevels">The number of levels in the scale pyramid.</param>
        /// <param name="edgeThreshold">How far from the boundary the points should be.</param>
        /// <param name="firstLevel">The level at which the image is given. If 1, that means we will also look at the image scaleFactor times bigger.</param>
        /// <param name="WTA_K"></param>
        /// <param name="scoreType"></param>
        /// <param name="patchSize"></param>
        public ORB_GPU(int nFeatures = 500, float scaleFactor = 1.2f, int nLevels = 8, int edgeThreshold = 31,
                     int firstLevel = 0, int WTA_K = 2, ScoreType scoreType = 0, int patchSize = 31)
        {
            Cv2Gpu.ThrowIfGpuNotAvailable();
            ptr = NativeMethods.gpu_ORB_GPU_new(
                nFeatures, scaleFactor, nLevels, edgeThreshold,
                firstLevel, WTA_K, (int)scoreType, patchSize);
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
                        NativeMethods.gpu_ORB_GPU_delete(ptr);
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
        public int DescriptorSize
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.gpu_ORB_GPU_descriptorSize(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool BlurForDescriptor
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.gpu_ORB_GPU_blurForDescriptor_get(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.gpu_ORB_GPU_blurForDescriptor_set(ptr, value ? 0 : 1);
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
            NativeMethods.gpu_ORB_GPU_release(ptr);
        }

        /// <summary>
        /// Detects keypoints and computes descriptors for them.
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

            NativeMethods.gpu_ORB_GPU_operator1(ptr, image.CvPtr, mask.CvPtr, keypoints.CvPtr);

            GC.KeepAlive(image);
            GC.KeepAlive(mask);
            GC.KeepAlive(keypoints);
        }

        /// <summary>
        /// Detects keypoints and computes descriptors for them.
        /// </summary>
        /// <param name="image">Image where keypoints (corners) are detected. 
        /// Only 8-bit grayscale images are supported.</param>
        /// <param name="mask">Optional input mask that marks the regions where we should detect features.</param>
        /// <param name="keypoints">The output vector of keypoints.</param>
        public void Run(GpuMat image, GpuMat mask, out KeyPoint[] keypoints)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (image == null)
                throw new ArgumentNullException("image");
            if (mask == null)
                throw new ArgumentNullException("mask");

            using (var keypointsVec = new VectorOfKeyPoint())
            {
                NativeMethods.gpu_ORB_GPU_operator2(ptr, image.CvPtr, mask.CvPtr, keypointsVec.CvPtr);
                keypoints = keypointsVec.ToArray();
            }

            GC.KeepAlive(image);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// Detects keypoints and computes descriptors for them.
        /// </summary>
        /// <param name="image">Image where keypoints (corners) are detected. 
        /// Only 8-bit grayscale images are supported.</param>
        /// <param name="mask">Optional input mask that marks the regions where we should detect features.</param>
        /// <param name="keypoints">The output vector of keypoints.</param>
        /// <param name="descriptors"></param>
        public void Run(GpuMat image, GpuMat mask, GpuMat keypoints, GpuMat descriptors)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (image == null)
                throw new ArgumentNullException("image");
            if (mask == null)
                throw new ArgumentNullException("mask");
            if (keypoints == null)
                throw new ArgumentNullException("keypoints");
            if (descriptors == null)
                throw new ArgumentNullException("descriptors");

            NativeMethods.gpu_ORB_GPU_operator3(ptr, image.CvPtr, mask.CvPtr, keypoints.CvPtr, descriptors.CvPtr);

            GC.KeepAlive(image);
            GC.KeepAlive(mask);
            GC.KeepAlive(keypoints);
            GC.KeepAlive(descriptors);
        }

        /// <summary>
        /// Detects keypoints and computes descriptors for them.
        /// </summary>
        /// <param name="image">Image where keypoints (corners) are detected. 
        /// Only 8-bit grayscale images are supported.</param>
        /// <param name="mask">Optional input mask that marks the regions where we should detect features.</param>
        /// <param name="keypoints">The output vector of keypoints.</param>
        /// <param name="descriptors"></param>
        public void Run(GpuMat image, GpuMat mask, out KeyPoint[] keypoints, GpuMat descriptors)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (image == null)
                throw new ArgumentNullException("image");
            if (mask == null)
                throw new ArgumentNullException("mask");
            if (descriptors == null)
                throw new ArgumentNullException("descriptors");

            using (var keypointsVec = new VectorOfKeyPoint())
            {
                NativeMethods.gpu_ORB_GPU_operator4(ptr, image.CvPtr, mask.CvPtr, keypointsVec.CvPtr, descriptors.CvPtr);
                keypoints = keypointsVec.ToArray();
            }

            GC.KeepAlive(image);
            GC.KeepAlive(mask);
            GC.KeepAlive(descriptors);
        }

        /// <summary>
        /// Download keypoints from GPU to CPU memory.
        /// </summary>
        /// <param name="dKeypoints"></param>
        /// <returns></returns>
        public KeyPoint[] DownloadKeyPoints(GpuMat dKeypoints)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (dKeypoints == null)
                throw new ArgumentNullException("dKeypoints");

            KeyPoint[] result;
            using (var keypoints = new VectorOfKeyPoint())
            {
                NativeMethods.gpu_ORB_GPU_downloadKeyPoints(ptr, dKeypoints.CvPtr, keypoints.CvPtr);
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
        public KeyPoint[] ConvertKeyPoints(Mat hKeypoints)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (hKeypoints == null)
                throw new ArgumentNullException("hKeypoints");

            KeyPoint[] result;
            using (var keypoints = new VectorOfKeyPoint())
            {
                NativeMethods.gpu_ORB_GPU_convertKeyPoints(ptr, hKeypoints.CvPtr, keypoints.CvPtr);
                result = keypoints.ToArray();
            }

            GC.KeepAlive(hKeypoints);
            return result;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="threshold"></param>
        /// <param name="nonmaxSuppression"></param>
        /// <returns>Final count of keypoints</returns>
        public void SetFastParams(int threshold, bool nonmaxSuppression)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

            NativeMethods.gpu_ORB_GPU_setFastParams(ptr, threshold, nonmaxSuppression ? 1 : 0);
        }

        #endregion

#pragma warning disable 1591
        public enum ScoreType
        {
            XRow = 0,
            YRow,
            ResponseRow,
            AngleRow,
            OctaveRow,
            SizeRow,
            RowsCount,
        }
#pragma warning restore 1591
    }
}
