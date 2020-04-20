using System;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Interface for implementations of Fast Bilateral Solver.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class FastBilateralSolverFilter : Algorithm
    {
        private Ptr? detectorPtr;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected FastBilateralSolverFilter(IntPtr p)
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
        /// Factory method, create instance of FastBilateralSolverFilter and execute the initialization routines.
        /// </summary>
        /// <param name="guide">image serving as guide for filtering. It should have 8-bit depth and either 1 or 3 channels.</param>
        /// <param name="sigmaSpatial">parameter, that is similar to spatial space sigma (bandwidth) in bilateralFilter.</param>
        /// <param name="sigmaLuma">parameter, that is similar to luma space sigma (bandwidth) in bilateralFilter.</param>
        /// <param name="sigmaChroma">parameter, that is similar to chroma space sigma (bandwidth) in bilateralFilter.</param>
        /// <param name="lambda">smoothness strength parameter for solver.</param>
        /// <param name="numIter">number of iterations used for solver, 25 is usually enough.</param>
        /// <param name="maxTol">convergence tolerance used for solver.</param>
        /// <returns></returns>
        public static FastBilateralSolverFilter Create(
            InputArray guide, double sigmaSpatial, double sigmaLuma, double sigmaChroma, 
            double lambda = 128.0, int numIter = 25, double maxTol = 1e-5)
        {
            if (guide == null)
                throw new ArgumentNullException(nameof(guide));
            guide.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_createFastBilateralSolverFilter(
                    guide.CvPtr, sigmaSpatial, sigmaLuma, sigmaChroma, lambda, numIter, maxTol, out var p));
            
            GC.KeepAlive(guide); 
            return new FastBilateralSolverFilter(p);
        }

        /// <summary>
        /// Apply smoothing operation to the source image.
        /// </summary>
        /// <param name="src">source image for filtering with unsigned 8-bit or signed 16-bit or floating-point 32-bit depth and up to 3 channels.</param>
        /// <param name="confidence">confidence image with unsigned 8-bit or floating-point 32-bit confidence and 1 channel.</param>
        /// <param name="dst">destination image.</param>
        public virtual void Filter(InputArray src, InputArray confidence, OutputArray dst)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (confidence == null)
                throw new ArgumentNullException(nameof(confidence));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            confidence.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_FastBilateralSolverFilter_filter(
                    ptr, src.CvPtr, confidence.CvPtr, dst.CvPtr));

            GC.KeepAlive(this);
            GC.KeepAlive(src);
            GC.KeepAlive(confidence);
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
                    NativeMethods.ximgproc_Ptr_FastBilateralSolverFilter_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_FastBilateralSolverFilter_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
