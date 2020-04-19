using System;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Interface for implementations of Fast Global Smoother filter.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class FastGlobalSmootherFilter : Algorithm
    {
        private Ptr? detectorPtr;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected FastGlobalSmootherFilter(IntPtr p)
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
        /// Factory method, create instance of FastGlobalSmootherFilter and execute the initialization routines.
        /// </summary>
        /// <param name="guide">image serving as guide for filtering. It should have 8-bit depth and either 1 or 3 channels.</param>
        /// <param name="lambda">parameter defining the amount of regularization</param>
        /// <param name="sigmaColor">parameter, that is similar to color space sigma in bilateralFilter.</param>
        /// <param name="lambdaAttenuation">internal parameter, defining how much lambda decreases after each iteration. Normally,
        /// it should be 0.25. Setting it to 1.0 may lead to streaking artifacts.</param>
        /// <param name="numIter">number of iterations used for filtering, 3 is usually enough.</param>
        /// <returns></returns>
        public static FastGlobalSmootherFilter Create(
            InputArray guide, double lambda, double sigmaColor, double lambdaAttenuation = 0.25, int numIter = 3)
        {
            if (guide == null)
                throw new ArgumentNullException(nameof(guide));
            guide.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_createFastGlobalSmootherFilter(
                    guide.CvPtr, lambda, sigmaColor, lambdaAttenuation, numIter, out var p));
            
            GC.KeepAlive(guide); 
            return new FastGlobalSmootherFilter(p);
        }

        /// <summary>
        /// Apply smoothing operation to the source image.
        /// </summary>
        /// <param name="src">source image for filtering with unsigned 8-bit or signed 16-bit or floating-point 32-bit depth and up to 4 channels.</param>
        /// <param name="dst">destination image.</param>
        public virtual void Filter(InputArray src, OutputArray dst)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_FastGlobalSmootherFilter_filter(
                    ptr, src.CvPtr, dst.CvPtr));

            GC.KeepAlive(this);
            GC.KeepAlive(src);
            dst.Fix();
        }
        
        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_FastGlobalSmootherFilter_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_FastGlobalSmootherFilter_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
