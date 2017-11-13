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
            ptr = IntPtr.Zero;
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
                var res = NativeMethods.video_BackgroundSubtractorMOG2_getHistory(objectPtr.CvPtr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setHistory(objectPtr.CvPtr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.video_BackgroundSubtractorMOG2_getNMixtures(objectPtr.CvPtr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setNMixtures(objectPtr.CvPtr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.video_BackgroundSubtractorMOG2_getBackgroundRatio(objectPtr.CvPtr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setBackgroundRatio(objectPtr.CvPtr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.video_BackgroundSubtractorMOG2_getVarThreshold(objectPtr.CvPtr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setVarThreshold(objectPtr.CvPtr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.video_BackgroundSubtractorMOG2_getVarThresholdGen(objectPtr.CvPtr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setVarThresholdGen(objectPtr.CvPtr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.video_BackgroundSubtractorMOG2_getVarInit(objectPtr.CvPtr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setVarInit(objectPtr.CvPtr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.video_BackgroundSubtractorMOG2_getVarMin(objectPtr.CvPtr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setVarMin(objectPtr.CvPtr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.video_BackgroundSubtractorMOG2_getVarMax(objectPtr.CvPtr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setVarMax(objectPtr.CvPtr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.video_BackgroundSubtractorMOG2_getComplexityReductionThreshold(objectPtr.CvPtr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setComplexityReductionThreshold(objectPtr.CvPtr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.video_BackgroundSubtractorMOG2_getDetectShadows(objectPtr.CvPtr) != 0;
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setDetectShadows(objectPtr.CvPtr, value ? 1 : 0);
                GC.KeepAlive(this);
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
                var res = NativeMethods.video_BackgroundSubtractorMOG2_getShadowValue(objectPtr.CvPtr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setShadowValue(objectPtr.CvPtr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.video_BackgroundSubtractorMOG2_getShadowThreshold(objectPtr.CvPtr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorMOG2_setShadowThreshold(objectPtr.CvPtr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.video_Ptr_BackgroundSubtractorMOG2_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.video_Ptr_BackgroundSubtractorMOG2_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}