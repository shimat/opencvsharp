using System;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Interface for Adaptive Manifold Filter realizations.
    ///
    /// Below listed optional parameters which may be set up with Algorithm::set function.
    /// -   member double sigma_s = 16.0
    /// Spatial standard deviation.
    /// -   member double sigma_r = 0.2
    /// Color space standard deviation.
    /// -   member int tree_height = -1
    /// Height of the manifold tree (default = -1 : automatically computed).
    /// -   member int num_pca_iterations = 1
    /// Number of iterations to computed the eigenvector.
    /// -   member bool adjust_outliers = false
    /// Specify adjust outliers using Eq. 9 or not.
    /// -   member bool use_RNG = true
    /// Specify use random number generator to compute eigenvector or not.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class AdaptiveManifoldFilter : Algorithm
    {
        private Ptr? detectorPtr;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected AdaptiveManifoldFilter(IntPtr p)
        {
            detectorPtr = new Ptr(p);
            ptr = detectorPtr.Get();
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

        /// <summary>
        /// Factory method, create instance of AdaptiveManifoldFilter and produce some initialization routines.
        /// </summary>
        /// <param name="sigmaS">spatial standard deviation.</param>
        /// <param name="sigmaR">color space standard deviation, it is similar to the sigma in the color space into
        /// bilateralFilter.</param>
        /// <param name="adjustOutliers">optional, specify perform outliers adjust operation or not, (Eq. 9) in the
        /// original paper.</param>
        /// <returns></returns>
        public static AdaptiveManifoldFilter Create(
            double sigmaS, double sigmaR, bool adjustOutliers = false)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_createAMFilter(
                    sigmaS, sigmaR, adjustOutliers ? 1 : 0, out var p));
            
            return new AdaptiveManifoldFilter(p);
        }
        
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public double SigmaS
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_AdaptiveManifoldFilter_getSigmaS(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_AdaptiveManifoldFilter_setSigmaS(ptr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double SigmaR
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_AdaptiveManifoldFilter_getSigmaR(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_AdaptiveManifoldFilter_setSigmaR(ptr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TreeHeight
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_AdaptiveManifoldFilter_getTreeHeight(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_AdaptiveManifoldFilter_setTreeHeight(ptr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PCAIterations
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_AdaptiveManifoldFilter_getPCAIterations(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_AdaptiveManifoldFilter_setPCAIterations(ptr, value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AdjustOutliers
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_AdaptiveManifoldFilter_getAdjustOutliers(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_AdaptiveManifoldFilter_setAdjustOutliers(ptr, value ? 1 : 0));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool UseRNG
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_AdaptiveManifoldFilter_getUseRNG(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_AdaptiveManifoldFilter_setUseRNG(ptr, value ? 1 : 0));
                GC.KeepAlive(this);
            }
        }

        #endregion

        /// <summary>
        /// Apply high-dimensional filtering using adaptive manifolds.
        /// </summary>
        /// <param name="src">filtering image with any numbers of channels.</param>
        /// <param name="dst">output image.</param>
        /// <param name="joint">optional joint (also called as guided) image with any numbers of channels.</param>
        public virtual void Filter(InputArray src, OutputArray dst, InputArray? joint = null)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            joint?.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_filter(
                    ptr, src.CvPtr, dst.CvPtr, joint?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(this);
            GC.KeepAlive(src);
            dst.Fix();
            GC.KeepAlive(joint);
        }
        
        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_AdaptiveManifoldFilter_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_AdaptiveManifoldFilter_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
