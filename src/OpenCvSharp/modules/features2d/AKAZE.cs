using System;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

#if LANG_JP
    /// <summary>
    /// AKAZE 実装
    /// </summary>
#else
    /// <summary>
    /// Class implementing the AKAZE keypoint detector and descriptor extractor, 
    /// described in @cite ANB13
    /// </summary>
    /// <remarks>
    /// AKAZE descriptors can only be used with KAZE or AKAZE keypoints. 
    /// Try to avoid using *extract* and *detect* instead of *operator()* due to performance reasons. 
    /// .. [ANB13] Fast Explicit Diffusion for Accelerated Features in Nonlinear Scale 
    /// Spaces. Pablo F. Alcantarilla, Jesús Nuevo and Adrien Bartoli. 
    /// In British Machine Vision Conference (BMVC), Bristol, UK, September 2013.
    /// </remarks>
#endif
    public class AKAZE : Feature2D
    {
        private bool disposed;
        private Ptr<AKAZE> ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected AKAZE(IntPtr p)
        {
            ptrObj = new Ptr<AKAZE>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// The AKAZE constructor
        /// </summary>
        /// <param name="descriptorType"></param>
        /// <param name="descriptorSize"></param>
        /// <param name="descriptorChannels"></param>
        /// <param name="threshold"></param>
        /// <param name="nOctaves"></param>
        /// <param name="nOctaveLayers"></param>
        /// <param name="diffusivity"></param>
        public static AKAZE Create(
            OpenCvSharp.AKAZEDescriptorType descriptorType = OpenCvSharp.AKAZEDescriptorType.MLDB,
            int descriptorSize = 0,
            int descriptorChannels = 3,
            float threshold = 0.001f,
            int nOctaves = 4,
            int nOctaveLayers = 4,
            KAZEDiffusivity diffusivity = KAZEDiffusivity.DiffPmG2)
        {
            IntPtr ptr = NativeMethods.features2d_AKAZE_create(
                (int) descriptorType, descriptorSize, descriptorChannels,
                threshold, nOctaves, nOctaveLayers, (int) diffusivity);
            return new AKAZE(ptr);
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
        public AKAZEDescriptorType AKAZEDescriptorType // avoid name conflict
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return (AKAZEDescriptorType)NativeMethods.features2d_AKAZE_getDescriptorType(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_AKAZE_setDescriptorType(ptr, (int)value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int AKAZEDescriptorSize // avoid name conflict
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_AKAZE_getDescriptorSize(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_AKAZE_setDescriptorSize(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int AKAZEDescriptorChannels // avoid name conflict
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_AKAZE_getDescriptorChannels(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_AKAZE_setDescriptorChannels(ptr, value);
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
                return NativeMethods.features2d_AKAZE_getThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_AKAZE_setThreshold(ptr, value);
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
                return NativeMethods.features2d_AKAZE_getNOctaves(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_AKAZE_setNOctaves(ptr, value);
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
                return NativeMethods.features2d_AKAZE_getNOctaveLayers(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_AKAZE_setNOctaveLayers(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Diffusivity
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_AKAZE_getDiffusivity(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_AKAZE_setDiffusivity(ptr, value);
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
