using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// 
    /// </summary>
    public class DualTVL1OpticalFlow : DenseOpticalFlowExt
    {
        /// <summary>
        /// 
        /// </summary>
        private Ptr detectorPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        private DualTVL1OpticalFlow()
        {
            detectorPtr = null;
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static DualTVL1OpticalFlow FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid pointer");

            var ptrObj = new Ptr(ptr);
            var obj = new DualTVL1OpticalFlow
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
        public double Tau
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_DualTVL1OpticalFlow_getTau(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_DualTVL1OpticalFlow_setTau(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Lambda
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_DualTVL1OpticalFlow_getLambda(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_DualTVL1OpticalFlow_setLambda(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Theta
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_DualTVL1OpticalFlow_getTheta(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_DualTVL1OpticalFlow_setTheta(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ScalesNumber
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_DualTVL1OpticalFlow_getScalesNumber(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_DualTVL1OpticalFlow_setScalesNumber(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int WarpingsNumber
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_DualTVL1OpticalFlow_getWarpingsNumber(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_DualTVL1OpticalFlow_setWarpingsNumber(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Epsilon
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_DualTVL1OpticalFlow_getEpsilon(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_DualTVL1OpticalFlow_setEpsilon(ptr, value);
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
                var res = NativeMethods.superres_DualTVL1OpticalFlow_getIterations(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_DualTVL1OpticalFlow_setIterations(ptr, value);
                GC.KeepAlive(this);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool UseInitialFlow
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_DualTVL1OpticalFlow_getUseInitialFlow(ptr);
                GC.KeepAlive(this);
                return res != 0;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_DualTVL1OpticalFlow_setUseInitialFlow(ptr, value ? 1 : 0);
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
                var res = NativeMethods.superres_Ptr_DualTVL1OpticalFlow_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.superres_Ptr_DualTVL1OpticalFlow_delete(ptr);
                base.Dispose();
            }
        }
    }
}
