using System;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// 
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
