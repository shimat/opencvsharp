using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Background Subtractor module. Takes a series of images and returns a sequence of mask (8UC1)
    ///  images of the same size, where 255 indicates Foreground and 0 represents Background.
    /// </summary>
    public class BackgroundSubtractorGMG : BackgroundSubtractor
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr objectPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initializationFrames"></param>
        /// <param name="decisionThreshold"></param>
        /// <returns></returns>
        public static BackgroundSubtractorGMG Create(
            int initializationFrames = 120, double decisionThreshold = 0.8)
        {
            IntPtr ptr = NativeMethods.bgsegm_createBackgroundSubtractorGMG(
                initializationFrames, decisionThreshold);
            return new BackgroundSubtractorGMG(ptr);
        }

        internal BackgroundSubtractorGMG(IntPtr ptr)
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
        public int MaxFeatures
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getMaxFeatures(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMaxFeatures(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double DefaultLearningRate
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NumFrames
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getNumFrames(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setNumFrames(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int QuantizationLevels
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getQuantizationLevels(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setQuantizationLevels(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double BackgroundPrior
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getBackgroundPrior(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setBackgroundPrior(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SmoothingRadius
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getSmoothingRadius(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setSmoothingRadius(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double DecisionThreshold
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getDecisionThreshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setDecisionThreshold(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool UpdateBackgroundModel
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel(ptr) != 0;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel(ptr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double MinVal
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getMinVal(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMinVal(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double MaxVal
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getMaxVal(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMaxVal(ptr, value);
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
                return NativeMethods.bgsegm_Ptr_BackgroundSubtractorGMG_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.bgsegm_Ptr_BackgroundSubtractorGMG_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}