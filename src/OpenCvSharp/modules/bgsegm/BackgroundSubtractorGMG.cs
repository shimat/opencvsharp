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
        private Ptr<BackgroundSubtractorGMG> objectPtr;
        /// <summary>
        /// 
        /// </summary>
        private bool disposed;

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
            this.objectPtr = new Ptr<BackgroundSubtractorGMG>(ptr);
            this.ptr = objectPtr.Get(); 
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
        /// Clean up any resources being used.
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
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        if (objectPtr != null)
                        {
                            objectPtr.Dispose();
                        }
                        objectPtr = null;
                        ptr = IntPtr.Zero;
                    }
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
        public int MaxFeatures
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getMaxFeatures(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getNumFrames(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getQuantizationLevels(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getBackgroundPrior(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getSmoothingRadius(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getDecisionThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getMinVal(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getMaxVal(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMaxVal(ptr, value);
            }
        }
        
        #endregion

    }
}