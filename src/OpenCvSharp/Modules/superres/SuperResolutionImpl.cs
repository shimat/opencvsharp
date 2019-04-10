using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <inheritdoc />
    /// <summary>
    /// class for defined Super Resolution algorithm.
    /// </summary>
    internal sealed class SuperResolutionImpl : SuperResolution
    {
        /// <summary>
        /// 
        /// </summary>
        private Ptr detectorPtr;

        #region Init & Disposal

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private SuperResolutionImpl()
        {
            detectorPtr = null;
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static SuperResolutionImpl FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid FrameSource pointer");

            var ptrObj = new Ptr(ptr);
            var obj = new SuperResolutionImpl
            {
                detectorPtr = ptrObj,
                ptr = ptrObj.Get()
            };
            return obj;
        }

        /// <summary>
        /// Creates instance from raw pointer T*
        /// </summary>
        /// <param name="ptr"></param>
        internal static SuperResolutionImpl FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid FrameSource pointer");
            var obj = new SuperResolutionImpl
            {
                detectorPtr = null,
                ptr = ptr
            };
            return obj;
        }

        /// <inheritdoc />
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

        #region Methods

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="fs"></param>
        public override void SetInput(FrameSource fs)
        {
            ThrowIfDisposed();
            if (fs == null)
                throw new ArgumentNullException(nameof(fs));
            NativeMethods.superres_SuperResolution_setInput(ptr, fs.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(fs);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="frame"></param>
        public override void NextFrame(OutputArray frame)
        {
            ThrowIfDisposed();
            if (frame == null)
                throw new ArgumentNullException(nameof(frame));
            frame.ThrowIfNotReady();
            NativeMethods.superres_SuperResolution_nextFrame(ptr, frame.CvPtr);
            frame.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(frame);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override void Reset()
        {
            ThrowIfDisposed();
            NativeMethods.superres_SuperResolution_reset(ptr);
            GC.KeepAlive(this);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override void CollectGarbage()
        {
            ThrowIfDisposed();
            NativeMethods.superres_SuperResolution_collectGarbage(ptr);
            GC.KeepAlive(this);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="fs"></param>
        protected override void InitImpl(FrameSource fs)
        {
            // ネイティブ実装なので特別に空で。
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="output"></param>
        protected override void ProcessImpl(FrameSource fs, OutputArray output)
        {
            // ネイティブ実装なので特別に空で。
        }

        #endregion

        #region Properties

        /// <summary>
        /// Scale factor
        /// </summary>
        public int Scale
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_SuperResolution_getScale(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_SuperResolution_setScale(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Iterations count
        /// </summary>
        public int Iterations
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_SuperResolution_getIterations(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_SuperResolution_setIterations(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Asymptotic value of steepest descent method
        /// </summary>
        public double Tau
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_SuperResolution_getTau(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_SuperResolution_setTau(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Weight parameter to balance data term and smoothness term
        /// </summary>
        public double Lambda
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_SuperResolution_getLambda(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_SuperResolution_setLambda(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Parameter of spacial distribution in Bilateral-TV
        /// </summary>
        public double Alpha
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_SuperResolution_getAlpha(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_SuperResolution_setAlpha(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Kernel size of Bilateral-TV filter
        /// </summary>
        public int KernelSize
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_SuperResolution_getKernelSize(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_SuperResolution_setKernelSize(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gaussian blur kernel size
        /// </summary>
        public int BlurKernelSize
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_SuperResolution_getBlurKernelSize(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_SuperResolution_setBlurKernelSize(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gaussian blur sigma
        /// </summary>
        public double BlurSigma
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_SuperResolution_getBlurSigma(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_SuperResolution_setBlurSigma(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Radius of the temporal search area
        /// </summary>
        public int TemporalAreaRadius
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_SuperResolution_getTemporalAreaRadius(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_SuperResolution_setTemporalAreaRadius(ptr, value);
                GC.KeepAlive(this);
            }
        }

        // TODO
        /*
        /// <summary>
        /// Dense optical flow algorithm
        /// </summary>
        public DenseOpticalFlowExt OpticalFlow
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.superres_SuperResolution_getOpticalFlow(ptr);
                GC.KeepAlive(this);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.superres_SuperResolution_setOpticalFlow(ptr, value);
                GC.KeepAlive(this);
            }
        }
        */

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.superres_Ptr_SuperResolution_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.superres_Ptr_SuperResolution_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
