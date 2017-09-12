using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Gaussian Mixture-based Backbround/Foreground Segmentation Algorithm
    /// </summary>
    public class BackgroundSubtractorMOG : BackgroundSubtractor
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr objectPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="history"></param>
        /// <param name="nMixtures"></param>
        /// <param name="backgroundRatio"></param>
        /// <param name="noiseSigma"></param>
        /// <returns></returns>
        public static BackgroundSubtractorMOG Create(
            int history = 200, int nMixtures = 5, double backgroundRatio = 0.7, double noiseSigma = 0)
        {
            IntPtr ptr = NativeMethods.bgsegm_createBackgroundSubtractorMOG(
                history, nMixtures, backgroundRatio, noiseSigma);
            return new BackgroundSubtractorMOG(ptr);
        }

        internal BackgroundSubtractorMOG(IntPtr ptr)
        {
            this.objectPtr = new Ptr(ptr);
            this.ptr = objectPtr.Get(); 
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            objectPtr?.Dispose();
            objectPtr = null;
            base.DisposeManaged();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int History
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorMOG_getHistory(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setHistory(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NMixtures
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorMOG_getNMixtures(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setNMixtures(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double BackgroundRatio
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorMOG_getBackgroundRatio(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setBackgroundRatio(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double NoiseSigma
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorMOG_getNoiseSigma(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setNoiseSigma(ptr, value);
            }
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.bgsegm_Ptr_BackgroundSubtractorMOG_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.bgsegm_Ptr_BackgroundSubtractorMOG_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}