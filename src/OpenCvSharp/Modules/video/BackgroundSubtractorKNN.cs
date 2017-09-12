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
                return NativeMethods.video_BackgroundSubtractorKNN_getHistory(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorKNN_getNSamples(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorKNN_getDist2Threshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorKNN_getkNNSamples(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorKNN_getDetectShadows(ptr) != 0;
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorKNN_getShadowValue(ptr);
            }
            set
            {
                ThrowIfDisposed();
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
                ThrowIfDisposed();
                return NativeMethods.video_BackgroundSubtractorKNN_getShadowThreshold(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.video_BackgroundSubtractorKNN_setShadowThreshold(ptr, value);
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
                return NativeMethods.video_Ptr_BackgroundSubtractorKNN_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.video_Ptr_BackgroundSubtractorKNN_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}