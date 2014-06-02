
using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// SIFT 実装.
    /// </summary>
#else
    /// <summary>
    /// SIFT implementation.
    /// </summary>
#endif
    public class SIFT : Feature2D
    {
        private bool disposed;
        private Ptr<SIFT> detectorPtr;

        #region Init & Disposal

        /// <summary>
        /// The SIFT constructor.
        /// </summary>
        /// <param name="nFeatures">The number of best features to retain. 
        /// The features are ranked by their scores (measured in SIFT algorithm as the local contrast)</param>
        /// <param name="nOctaveLayers">The number of layers in each octave. 3 is the value used in D. Lowe paper. 
        /// The number of octaves is computed automatically from the image resolution.</param>
        /// <param name="contrastThreshold">The contrast threshold used to filter out weak features in semi-uniform 
        /// (low-contrast) regions. The larger the threshold, the less features are produced by the detector.</param>
        /// <param name="edgeThreshold">The threshold used to filter out edge-like features. Note that the its meaning is 
        /// different from the contrastThreshold, i.e. the larger the edgeThreshold, the less features are filtered out (more features are retained).</param>
        /// <param name="sigma">The sigma of the Gaussian applied to the input image at the octave #0. 
        /// If your image is captured with a weak camera with soft lenses, you might want to reduce the number.</param>
        public SIFT(int nFeatures = 0, int nOctaveLayers = 3,
            double contrastThreshold = 0.04, double edgeThreshold = 10,
            double sigma = 1.6)
            : base()
        {
            ptr = NativeMethods.nonfree_SIFT_new(nFeatures, nOctaveLayers, 
                contrastThreshold, edgeThreshold, sigma);
        }

        /// <summary>
        /// Creates instance by cv::Ptr&lt;cv::SURF&gt;
        /// </summary>
        internal SIFT(Ptr<SIFT> detectorPtr)
            : base()
        {
            this.detectorPtr = detectorPtr;
            this.ptr = detectorPtr.Obj;
        }
        /// <summary>
        /// Creates instance by raw pointer cv::SURF*
        /// </summary>
        internal SIFT(IntPtr rawPtr)
            : base()
        {
            detectorPtr = null;
            ptr = rawPtr;
        }

        /// <summary>
        /// Creates a cv::Algorithm object using cv::Algorithm::create()
        /// </summary>
        /// <param name="name">The algorithm name, one of the names returned by Algorithm.GetList()</param>
        /// <returns></returns>
        public static SIFT CreateAlgorithm(string name)
        {
            // cv::Ptr<cv::Algorithm> を受け取る
            IntPtr p = NativeMethods.nonfree_SIFT_createAlgorithm(name);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException("Algorithm name [" + name + "] not found");
            return FromPtr(p);
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static new SIFT FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<SIFT> pointer");
            var ptrObj = new Ptr<SIFT>(ptr);
            return new SIFT(ptrObj);
        }
        /// <summary>
        /// Creates instance from raw pointer T*
        /// </summary>
        /// <param name="ptr"></param>
        internal static new SIFT FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid SIFT pointer");
            return new SIFT(ptr); 
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
                    }
                    else if (ptr != IntPtr.Zero)
                    {
                        NativeMethods.nonfree_SIFT_delete(ptr);
                    }
                    detectorPtr = null;
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

        #region Properties
        
        /// <summary>
        /// returns the descriptor size in float's (64 or 128)
        /// </summary>
        /// <returns></returns>
        public int DescriptorSize
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.nonfree_SIFT_descriptorSize(ptr);
            }
        }

        /// <summary>
        /// returns the descriptor type
        /// </summary>
        /// <returns></returns>
        public int DescriptorType
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.nonfree_SIFT_descriptorType(ptr);
            }
        }

        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get { return NativeMethods.nonfree_SIFT_info(ptr); }
        }
        #endregion

        #region Methods

#if LANG_JP
        /// <summary>
        /// Extract features and computes their descriptors using SIFT algorithm
        /// </summary>
        /// <param name="img">Input 8-bit grayscale image</param>
        /// <param name="mask">Optional input mask that marks the regions where we should detect features.</param>
        /// <returns>The output vector of keypoints</returns>
#else
        /// <summary>
        /// Extract features and computes their descriptors using SIFT algorithm
        /// </summary>
        /// <param name="img">Input 8-bit grayscale image</param>
        /// <param name="mask">Optional input mask that marks the regions where we should detect features.</param>
        /// <returns>The output vector of keypoints</returns>
#endif
        public KeyPoint[] Run(InputArray img, InputArray mask)
        {
            ThrowIfDisposed();
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();

            using (VectorOfKeyPoint keypointsVec = new VectorOfKeyPoint())
            {
                NativeMethods.nonfree_SIFT_run1(ptr, img.CvPtr, Cv2.ToPtr(mask), keypointsVec.CvPtr);
                return keypointsVec.ToArray();
            }
        }

#if LANG_JP
        /// <summary>
        /// keypoint を検出し，その SIFT ディスクリプタを計算します．
        /// </summary>
        /// <param name="img">Input 8-bit grayscale image</param>
        /// <param name="mask">Optional input mask that marks the regions where we should detect features.</param>
        /// <param name="keypoints">The input/output vector of keypoints</param>
        /// <param name="descriptors">The output matrix of descriptors. </param>
        /// <param name="useProvidedKeypoints">Boolean flag. If it is true, the keypoint detector is not run. 
        /// Instead, the provided vector of keypoints is used and the algorithm just computes their descriptors.</param>
#else
        /// <summary>
        /// detects keypoints and computes the SIFT descriptors for them. 
        /// </summary>
        /// <param name="img">Input 8-bit grayscale image</param>
        /// <param name="mask">Optional input mask that marks the regions where we should detect features.</param>
        /// <param name="keypoints">The input/output vector of keypoints</param>
        /// <param name="descriptors">The output matrix of descriptors. </param>
        /// <param name="useProvidedKeypoints">Boolean flag. If it is true, the keypoint detector is not run. 
        /// Instead, the provided vector of keypoints is used and the algorithm just computes their descriptors.</param>
#endif
        public void Run(InputArray img, InputArray mask, out KeyPoint[] keypoints, OutputArray descriptors,
            bool useProvidedKeypoints = false)
        {
            ThrowIfDisposed();
            if (img == null)
                throw new ArgumentNullException("img");
            if (descriptors == null)
                throw new ArgumentNullException("descriptors");
            img.ThrowIfDisposed();
            descriptors.ThrowIfNotReady();

            using (VectorOfKeyPoint keypointsVec = new VectorOfKeyPoint())
            {
                NativeMethods.nonfree_SIFT_run2_OutputArray(ptr, img.CvPtr, Cv2.ToPtr(mask), keypointsVec.CvPtr,
                    descriptors.CvPtr, useProvidedKeypoints ? 1 : 0);

                keypoints = keypointsVec.ToArray();
            }
            descriptors.Fix();
        }

#if LANG_JP
        /// <summary>
        /// keypoint を検出し，その SIFT ディスクリプタを計算します．
        /// </summary>
        /// <param name="img">Input 8-bit grayscale image</param>
        /// <param name="mask">Optional input mask that marks the regions where we should detect features.</param>
        /// <param name="keypoints">The input/output vector of keypoints</param>
        /// <param name="descriptors">The output matrix of descriptors. </param>
        /// <param name="useProvidedKeypoints">Boolean flag. If it is true, the keypoint detector is not run. 
        /// Instead, the provided vector of keypoints is used and the algorithm just computes their descriptors.</param>
#else
        /// <summary>
        /// detects keypoints and computes the SIFT descriptors for them. 
        /// </summary>
        /// <param name="img">Input 8-bit grayscale image</param>
        /// <param name="mask">Optional input mask that marks the regions where we should detect features.</param>
        /// <param name="keypoints">The input/output vector of keypoints</param>
        /// <param name="descriptors">The output matrix of descriptors. </param>
        /// <param name="useProvidedKeypoints">Boolean flag. If it is true, the keypoint detector is not run. 
        /// Instead, the provided vector of keypoints is used and the algorithm just computes their descriptors.</param>
#endif
        public void Run(InputArray img, InputArray mask, out KeyPoint[] keypoints, out float[] descriptors,
            bool useProvidedKeypoints = false)
        {
            // SIFTは std::vector<float> でdescriptorを受け取れないっぽいので、自前実装
            MatOfFloat descriptorsMat = new MatOfFloat();
            Run(img, mask, out keypoints, descriptorsMat, useProvidedKeypoints);

            descriptors = descriptorsMat.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseMat"></param>
        /// <param name="nOctaves"></param>
        /// <returns></returns>
        public Mat[] BuildGaussianPyramid(Mat baseMat, int nOctaves)
        {
            ThrowIfDisposed();
            if (baseMat == null)
                throw new ArgumentNullException("baseMat");
            baseMat.ThrowIfDisposed();

            using (VectorOfMat pyrVec = new VectorOfMat())
            {
                NativeMethods.nonfree_SIFT_buildGaussianPyramid(ptr, baseMat.CvPtr, pyrVec.CvPtr, nOctaves);
                return pyrVec.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pyr"></param>
        /// <returns></returns>
        public Mat[] BuildDoGPyramid(IEnumerable<Mat> pyr)
        {
            ThrowIfDisposed();
            if (pyr == null)
                throw new ArgumentNullException("pyr");

            IntPtr[] pyrPtrs = EnumerableEx.SelectPtrs(pyr);
            using (VectorOfMat dogPyrVec = new VectorOfMat())
            {
                NativeMethods.nonfree_SIFT_buildDoGPyramid(ptr, pyrPtrs, pyrPtrs.Length, dogPyrVec.CvPtr);
                return dogPyrVec.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gaussPyr"></param>
        /// <param name="dogPyr"></param>
        /// <returns></returns>
        public KeyPoint[] FindScaleSpaceExtrema(IEnumerable<Mat> gaussPyr, IEnumerable<Mat> dogPyr)
        {
            ThrowIfDisposed();
            if (gaussPyr == null)
                throw new ArgumentNullException("gaussPyr");
            if (dogPyr == null)
                throw new ArgumentNullException("dogPyr");

            IntPtr[] gaussPyrPtrs = EnumerableEx.SelectPtrs(gaussPyr);
            IntPtr[] dogPyrPtrs = EnumerableEx.SelectPtrs(dogPyr);

            using (VectorOfKeyPoint keyPointsVec = new VectorOfKeyPoint())
            {
                NativeMethods.nonfree_SIFT_findScaleSpaceExtrema(ptr, gaussPyrPtrs, gaussPyrPtrs.Length,
                    dogPyrPtrs, dogPyrPtrs.Length, keyPointsVec.CvPtr);
                return keyPointsVec.ToArray();
            }
        }

        #endregion
    }
}
