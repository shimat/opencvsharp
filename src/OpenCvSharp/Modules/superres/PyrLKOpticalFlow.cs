using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// 
    /// </summary>
    public class PyrLKOpticalFlow : DenseOpticalFlowExt
    {
        /// <summary>
        /// 
        /// </summary>
        private Ptr detectorPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        private PyrLKOpticalFlow()
        {
            detectorPtr = null;
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static PyrLKOpticalFlow FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid pointer");

            var ptrObj = new Ptr(ptr);
            var obj = new PyrLKOpticalFlow
            {
                detectorPtr = ptrObj,
                ptr = ptrObj.Get()
            };
            return obj;
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            detectorPtr?.Dispose();
            detectorPtr = null;
            base.DisposeManaged();
        }

        #endregion
        
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int WindowSize
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_PyrLKOpticalFlow_getWindowSize(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_PyrLKOpticalFlow_setWindowSize(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MaxLevel
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_PyrLKOpticalFlow_getMaxLevel(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_PyrLKOpticalFlow_setMaxLevel(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Iterations
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_PyrLKOpticalFlow_getIterations(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_PyrLKOpticalFlow_setIterations(ptr, value);
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
                var res = NativeMethods.superres_Ptr_PyrLKOpticalFlow_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.superres_Ptr_PyrLKOpticalFlow_delete(ptr);
                base.Dispose();
            }
        }
    }
}
