using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// K nearest neigbours algorithm
    /// </summary>
    public class BackgroundSubtractorKNN : BackgroundSubtractor
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr<BackgroundSubtractorKNN> objectPtr;
        /// <summary>
        /// 
        /// </summary>
        private bool disposed;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="history"></param>
        /// <param name="dist2Threshold"></param>
        /// <param name="detectShadows"></param>
        /// <returns></returns>
        public static BackgroundSubtractorKNN Create(
            int history=500, double dist2Threshold=400.0, bool detectShadows=true)
        {
            IntPtr ptr = NativeMethods.video_createBackgroundSubtractorKNN(
                history, dist2Threshold, detectShadows ? 1 : 0);
            return new BackgroundSubtractorKNN(ptr);
        }

        internal BackgroundSubtractorKNN(IntPtr ptr)
        {
            this.objectPtr = new Ptr<BackgroundSubtractorKNN>(ptr);
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
        public int History
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getHistory(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setHistory(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NSamples
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getNSamples(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setNSamples(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Dist2Threshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getDist2Threshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setDist2Threshold(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int KNNSamples
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getkNNSamples(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setkNNSamples(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool DetectShadows
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getDetectShadows(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setDetectShadows(ptr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ShadowValue
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getShadowValue(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setShadowValue(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double ShadowThreshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getShadowThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setShadowThreshold(ptr, value);
            }
        }
        
        #endregion
    }
}