
using System;

namespace OpenCvSharp.XFeatures2D
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

        /// <summary>
        /// Creates instance by raw pointer cv::SURF*
        /// </summary>
        protected SURF(IntPtr ptr)
            : base()
        {
            detectorPtr = new Ptr<SURF>(ptr);
            ptr = detectorPtr.Get();
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
        public static SURF Create(double hessianThreshold,
            int nOctaves = 4, int nOctaveLayers = 2,
            bool extended = true, bool upright = false)
        {
            IntPtr ptr = NativeMethods.xfeatures2d_SURF_create(
                hessianThreshold, nOctaves, nOctaveLayers,
                extended ? 1 : 0, upright ? 1 : 0);
            return new SURF(ptr);
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
                        if (detectorPtr != null)
                        {
                            detectorPtr.Dispose();
                            detectorPtr = null;
                        }
                    }

                    // releases unmanaged resources
                    
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
        /// Threshold for the keypoint detector. Only features, whose hessian is larger than hessianThreshold 
        /// are retained by the detector. Therefore, the larger the value, the less keypoints you will get. 
        /// A good default value could be from 300 to 500, depending from the image contrast.
        /// </summary>
        public double HessianThreshold
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.xfeatures2d_SURF_getHessianThreshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.xfeatures2d_SURF_setHessianThreshold(ptr, value);
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
                return NativeMethods.xfeatures2d_SURF_getNOctaves(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.xfeatures2d_SURF_setNOctaves(ptr, value);
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
                return NativeMethods.xfeatures2d_SURF_getNOctaveLayers(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.xfeatures2d_SURF_setNOctaveLayers(ptr, value);
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
                return NativeMethods.xfeatures2d_SURF_getExtended(ptr) != 0;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.xfeatures2d_SURF_setExtended(ptr, value ? 1 : 0);
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
                return NativeMethods.xfeatures2d_SURF_getUpright(ptr) != 0;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.xfeatures2d_SURF_setUpright(ptr, value ? 1 : 0);
            }
        }
        
        #endregion
    }
}
