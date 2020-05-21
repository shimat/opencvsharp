using System;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Interface for realizations of Domain Transform filter.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class DTFilter : Algorithm
    {
        private Ptr? detectorPtr;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected DTFilter(IntPtr p)
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
        /// Factory method, create instance of DTFilter and produce initialization routines.
        /// </summary>
        /// <param name="guide">guided image (used to build transformed distance, which describes edge structure of
        /// guided image).</param>
        /// <param name="sigmaSpatial">sigma_H parameter in the original article, it's similar to the sigma in the
        /// coordinate space into bilateralFilter.</param>
        /// <param name="sigmaColor">sigma_r parameter in the original article, it's similar to the sigma in the
        /// color space into bilateralFilter.</param>
        /// <param name="mode">one form three modes DTF_NC, DTF_RF and DTF_IC which corresponds to three modes for
        /// filtering 2D signals in the article.</param>
        /// <param name="numIters">optional number of iterations used for filtering, 3 is quite enough.</param>
        /// <returns></returns>
        public static DTFilter Create(
            InputArray guide, double sigmaSpatial, double sigmaColor, 
            EdgeAwareFiltersList mode = EdgeAwareFiltersList.DTF_NC, int numIters = 3)
        {
            if (guide == null)
                throw new ArgumentNullException(nameof(guide));
            guide.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_createDTFilter(
                    guide.CvPtr, sigmaSpatial, sigmaColor, (int)mode, numIters, out var p));
            
            GC.KeepAlive(guide); 
            return new DTFilter(p);
        }

        /// <summary>
        /// Simple one-line Domain Transform filter call. If you have multiple images to filter with the same
        /// guided image then use DTFilter interface to avoid extra computations on initialization stage.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="dDepth"></param>
        public virtual void Filter(InputArray src, OutputArray dst, int dDepth = -1)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_DTFilter_filter(
                    ptr, src.CvPtr, dst.CvPtr, dDepth));

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
                    NativeMethods.ximgproc_Ptr_DTFilter_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_DTFilter_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
