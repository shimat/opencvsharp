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
    public class KAZE : Feature2D
    {
        private bool disposed;
        private Ptr<KAZE> ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected KAZE(IntPtr p)
        {
            ptrObj = new Ptr<KAZE>(p);
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
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
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
        /// 
        /// </summary>
        public int Diffusivity
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_KAZE_getDiffusivity(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_KAZE_getExtended(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_KAZE_getNOctaveLayers(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_KAZE_getNOctaves(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_KAZE_getThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_KAZE_getUpright(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_KAZE_setUpright(ptr, value);
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
