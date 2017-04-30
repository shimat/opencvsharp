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
    // ReSharper disable once InconsistentNaming
    public class AKAZE : Feature2D
    {
        private Ptr ptrObj;

        //internal override IntPtr PtrObj => ptrObj.CvPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected AKAZE(IntPtr p)
        {
            ptrObj = new Ptr(p);
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
        public AKAZEDescriptorType AKAZEDescriptorType // avoid name conflict
        {
            get
            {
                ThrowIfDisposed();
                return (AKAZEDescriptorType)NativeMethods.features2d_AKAZE_getDescriptorType(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_AKAZE_getDescriptorSize(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_AKAZE_getDescriptorChannels(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_AKAZE_getThreshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_AKAZE_getNOctaves(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_AKAZE_getNOctaveLayers(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.features2d_AKAZE_getDiffusivity(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_AKAZE_setDiffusivity(ptr, value);
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
                return NativeMethods.features2d_Ptr_AKAZE_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_AKAZE_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
