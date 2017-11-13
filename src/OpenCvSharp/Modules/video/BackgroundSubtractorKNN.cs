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
        private Ptr objectPtr;

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
                var res = NativeMethods.video_BackgroundSubtractorKNN_getHistory(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorKNN_setHistory(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NSamples
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.video_BackgroundSubtractorKNN_getNSamples(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorKNN_setNSamples(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Dist2Threshold
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.video_BackgroundSubtractorKNN_getDist2Threshold(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorKNN_setDist2Threshold(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int KNNSamples
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.video_BackgroundSubtractorKNN_getkNNSamples(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorKNN_setkNNSamples(ptr, value);
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
                var res = NativeMethods.video_BackgroundSubtractorKNN_getDetectShadows(ptr) != 0;
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorKNN_setDetectShadows(ptr, value ? 1 : 0);
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
                var res = NativeMethods.video_BackgroundSubtractorKNN_getShadowValue(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorKNN_setShadowValue(ptr, value);
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
                var res = NativeMethods.video_BackgroundSubtractorKNN_getShadowThreshold(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorKNN_setShadowThreshold(ptr, value);
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
                var res = NativeMethods.video_Ptr_BackgroundSubtractorKNN_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.video_Ptr_BackgroundSubtractorKNN_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}