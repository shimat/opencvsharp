
using System;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// SURF(Speeded Up Robust Features) を抽出するためのクラス．
    /// </summary>
#else
    /// <summary>
    /// Class for extracting Speeded Up Robust Features from an image.
    /// </summary>
#endif
    public class SURF : Feature2D
    {
        private bool disposed;
        private Ptr<SURF> detectorPtr;

        #region Init & Disposal

#if LANG_JP
    /// <summary>
    /// SURFのデフォルトパラメータを生成する
    /// </summary>
#else
        /// <summary>
        /// Creates SURF default parameters
        /// </summary>
#endif
        public SURF()
            : base()
        {
            ptr = NativeMethods.nonfree_SURF_new();
            detectorPtr = null;
        }

#if LANG_JP
        /// <summary>
        /// SURF初期化
        /// </summary>
        /// <param name="hessianThreshold">keypoint.hessian の値がこの閾値よりも大きい特徴だけが検出される</param>
        /// <param name="nOctaves"></param>
        /// <param name="nOctaveLayers"></param>
        /// <param name="extended">false：基本的なディスクリプタ（64要素）, true：拡張されたディスクリプタ（128要素）</param>
        /// <param name="upright"></param>
#else
        /// <summary>
        /// The SURF constructor.
        /// </summary>
        /// <param name="hessianThreshold">Only features with keypoint.hessian larger than that are extracted. </param>
        /// <param name="nOctaves">The number of a gaussian pyramid octaves that the detector uses. It is set to 4 by default. 
        /// If you want to get very large features, use the larger value. If you want just small features, decrease it.</param>
        /// <param name="nOctaveLayers">The number of images within each octave of a gaussian pyramid. It is set to 2 by default.</param>
        /// <param name="extended">false means basic descriptors (64 elements each), true means extended descriptors (128 elements each) </param>
        /// <param name="upright">false means that detector computes orientation of each feature.
        /// true means that the orientation is not computed (which is much, much faster).</param>
#endif
        public SURF(double hessianThreshold,
            int nOctaves = 4, int nOctaveLayers = 2,
            bool extended = true, bool upright = false)
            : base()
        {
            ptr = NativeMethods.nonfree_SURF_new(hessianThreshold, nOctaves, nOctaveLayers,
                extended ? 1 : 0, upright ? 1 : 0);
            detectorPtr = null;
        }

        /// <summary>
        /// Creates instance by cv::Ptr&lt;cv::SURF&gt;
        /// </summary>
        internal SURF(Ptr<SURF> detectorPtr)
            : base()
        {
            this.detectorPtr = detectorPtr;
            this.ptr = detectorPtr.Obj;
        }
        /// <summary>
        /// Creates instance by raw pointer cv::SURF*
        /// </summary>
        internal SURF(IntPtr rawPtr)
            : base()
        {
            detectorPtr = null;
            ptr = rawPtr;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static new SURF FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<SURF> pointer");
            var ptrObj = new Ptr<SURF>(ptr);
            return new SURF(ptrObj);
        }
        /// <summary>
        /// Creates instance from raw pointer T*
        /// </summary>
        /// <param name="ptr"></param>
        internal static new SURF FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid SURF pointer");
            return new SURF(ptr);;
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
                        NativeMethods.nonfree_SURF_delete(ptr);
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
                return NativeMethods.nonfree_SURF_descriptorSize(ptr);
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
                return NativeMethods.nonfree_SURF_descriptorType(ptr);
            }
        }

        /// <summary>
        /// Threshold for the keypoint detector. Only features, whose hessian is larger than hessianThreshold 
        /// are retained by the detector. Therefore, the larger the value, the less keypoints you will get. 
        /// A good default value could be from 300 to 500, depending from the image contrast.
        /// </summary>
        public double HessianThreshold
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.nonfree_SURF_hessianThreshold_get(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.nonfree_SURF_hessianThreshold_set(ptr, value);
            }
        }
        /// <summary>
        /// The number of a gaussian pyramid octaves that the detector uses. It is set to 4 by default. 
        /// If you want to get very large features, use the larger value. If you want just small features, decrease it.
        /// </summary>
        public int NOctaves
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.nonfree_SURF_nOctaves_get(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.nonfree_SURF_nOctaves_set(ptr, value);
            }
        }
        /// <summary>
        /// The number of images within each octave of a gaussian pyramid. It is set to 2 by default.
        /// </summary>
        public int NOctaveLayers
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.nonfree_SURF_nOctaveLayers_get(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.nonfree_SURF_nOctaveLayers_set(ptr, value);
            }
        }
        /// <summary>
        /// false means that the basic descriptors (64 elements each) shall be computed. 
        /// true means that the extended descriptors (128 elements each) shall be computed
        /// </summary>
        public bool Extended
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.nonfree_SURF_extended_get(ptr) != 0;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.nonfree_SURF_extended_set(ptr, value ? 1 : 0);
            }
        }
        /// <summary>
        /// false means that detector computes orientation of each feature.
        /// true means that the orientation is not computed (which is much, much faster). 
        /// For example, if you match images from a stereo pair, or do image stitching, the matched features 
        /// likely have very similar angles, and you can speed up feature extraction by setting upright=true.
        /// </summary>
        public bool Upright
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.nonfree_SURF_upright_get(ptr) != 0;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.nonfree_SURF_upright_set(ptr, value ? 1 : 0);
            }
        }


        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get { return NativeMethods.nonfree_SURF_info(ptr); }
        }

        #endregion

        #region Methods

#if LANG_JP
        /// <summary>
        /// 高速なマルチスケール Hesian 検出器を用いて keypoint を検出します．
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// detects keypoints using fast multi-scale Hessian detector
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
#endif
        public KeyPoint[] Run(InputArray img, Mat mask)
        {
            ThrowIfDisposed();
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();

            using (VectorOfKeyPoint keypointsVec = new VectorOfKeyPoint())
            {
                NativeMethods.nonfree_SURF_run1(ptr, img.CvPtr, Cv2.ToPtr(mask), keypointsVec.CvPtr);
                return keypointsVec.ToArray();
            }
        }

#if LANG_JP
        /// <summary>
        /// keypoint を検出し，その SURF ディスクリプタを計算します．[useProvidedKeypoints = true]
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors"></param>
        /// <param name="useProvidedKeypoints"></param>
#else
        /// <summary>
        /// detects keypoints and computes the SURF descriptors for them. [useProvidedKeypoints = true]
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors"></param>
        /// <param name="useProvidedKeypoints"></param>
#endif
        public void Run(InputArray img, InputArray mask, out KeyPoint[] keypoints, out float[] descriptors,
            bool useProvidedKeypoints = false)
        {
            ThrowIfDisposed();
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();

            using (VectorOfKeyPoint keypointsVec = new VectorOfKeyPoint())
            using (VectorOfFloat descriptorsVec = new VectorOfFloat())
            {
                NativeMethods.nonfree_SURF_run2_vector(ptr, img.CvPtr, Cv2.ToPtr(mask), keypointsVec.CvPtr,
                    descriptorsVec.CvPtr, useProvidedKeypoints ? 1 : 0);

                keypoints = keypointsVec.ToArray();
                descriptors = descriptorsVec.ToArray();
            }
        }

#if LANG_JP
        /// <summary>
        /// keypoint を検出し，その SURF ディスクリプタを計算します．[useProvidedKeypoints = true]
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors"></param>
        /// <param name="useProvidedKeypoints"></param>
#else
        /// <summary>
        /// detects keypoints and computes the SURF descriptors for them. [useProvidedKeypoints = true]
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors"></param>
        /// <param name="useProvidedKeypoints"></param>
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
                NativeMethods.nonfree_SURF_run2_OutputArray(ptr, img.CvPtr, Cv2.ToPtr(mask), keypointsVec.CvPtr,
                    descriptors.CvPtr, useProvidedKeypoints ? 1 : 0);
                keypoints = keypointsVec.ToArray();
            }
        }

        #endregion
    }
}
