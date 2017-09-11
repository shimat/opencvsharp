using System;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

#if LANG_JP
    /// <summary>
    /// KAZE 実装
    /// </summary>
#else
    /// <summary>
    /// Class implementing the KAZE keypoint detector and descriptor extractor
    /// </summary>
#endif
    // ReSharper disable once InconsistentNaming
    public class KAZE : Feature2D
    {
        private Ptr ptrObj;

        //internal override IntPtr PtrObj => ptrObj.CvPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected KAZE(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// The KAZE constructor
        /// </summary>
        /// <param name="extended">Set to enable extraction of extended (128-byte) descriptor.</param>
        /// <param name="upright">Set to enable use of upright descriptors (non rotation-invariant).</param>
        /// <param name="threshold">Detector response threshold to accept point</param>
        /// <param name="nOctaves">Maximum octave evolution of the image</param>
        /// <param name="nOctaveLayers">Default number of sublevels per scale level</param>
        /// <param name="diffusivity">Diffusivity type. DIFF_PM_G1, DIFF_PM_G2, DIFF_WEICKERT or DIFF_CHARBONNIER</param>
        public static KAZE Create(
            bool extended = false, bool upright = false, float threshold = 0.001f,
            int nOctaves = 4, int nOctaveLayers = 4, KAZEDiffusivity diffusivity = KAZEDiffusivity.DiffPmG2)
        {
            IntPtr ptr = NativeMethods.features2d_KAZE_create(
                extended, upright, threshold,
                nOctaves, nOctaveLayers, (int) diffusivity);
            return new KAZE(ptr);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int Diffusivity
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.features2d_KAZE_getDiffusivity(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_KAZE_setDiffusivity(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Extended
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.features2d_KAZE_getExtended(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_KAZE_setExtended(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int NOctaveLayers
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.features2d_KAZE_getNOctaveLayers(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_KAZE_setNOctaveLayers(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int NOctaves
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.features2d_KAZE_getNOctaves(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_KAZE_setNOctaves(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public double Threshold
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.features2d_KAZE_getThreshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_KAZE_setThreshold(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Upright
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.features2d_KAZE_getUpright(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_KAZE_setUpright(ptr, value);
            }
        }

        #endregion

        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.features2d_Ptr_KAZE_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_KAZE_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
