using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// The Base Class for Background/Foreground Segmentation.
    /// The class is only used to define the common interface for
    /// the whole family of background/foreground segmentation algorithms.
    /// </summary>
    public class BackgroundSubtractorMOG2 : BackgroundSubtractor
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
        /// <param name="varThreshold"></param>
        /// <param name="detectShadows"></param>
        /// <returns></returns>
        public static BackgroundSubtractorMOG2 Create(
            int history = 500, double varThreshold = 16, bool detectShadows = true)
        {
            IntPtr ptr = NativeMethods.video_createBackgroundSubtractorMOG2(
                history, varThreshold, detectShadows ? 1 : 0);
            return new BackgroundSubtractorMOG2(ptr);
        }

        internal BackgroundSubtractorMOG2(IntPtr ptr)
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
                return NativeMethods.video_BackgroundSubtractorMOG2_getHistory(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setHistory(ptr, value);
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
                return NativeMethods.video_BackgroundSubtractorMOG2_getNMixtures(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setNMixtures(ptr, value);
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
                return NativeMethods.video_BackgroundSubtractorMOG2_getBackgroundRatio(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setBackgroundRatio(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double VarThreshold
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorMOG2_getHistory(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setVarThreshold(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double VarThresholdGen
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorMOG2_getVarThresholdGen(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setVarThresholdGen(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double VarInit
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorMOG2_getVarInit(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setVarInit(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double VarMin
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorMOG2_getVarMin(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setVarMin(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double VarMax
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorMOG2_getVarMax(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setVarMax(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double ComplexityReductionThreshold
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorMOG2_getComplexityReductionThreshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setComplexityReductionThreshold(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool DetectShadows
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorMOG2_getDetectShadows(ptr) != 0;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setDetectShadows(ptr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ShadowValue
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorMOG2_getShadowValue(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setShadowValue(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double ShadowThreshold
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorMOG2_getShadowThreshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setShadowThreshold(ptr, value);
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
                return NativeMethods.video_Ptr_BackgroundSubtractorMOG2_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.video_Ptr_BackgroundSubtractorMOG2_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}