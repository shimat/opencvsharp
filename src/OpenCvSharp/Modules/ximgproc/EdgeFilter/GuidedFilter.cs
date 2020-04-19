using System;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Interface for realizations of Guided Filter.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class GuidedFilter : Algorithm
    {
        private Ptr? detectorPtr;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected GuidedFilter(IntPtr p)
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
        /// Factory method, create instance of GuidedFilter and produce initialization routines.
        /// </summary>
        /// <param name="guide">guided image (or array of images) with up to 3 channels, if it have more then 3
        /// channels then only first 3 channels will be used.</param>
        /// <param name="radius">radius of Guided Filter.</param>
        /// <param name="eps">regularization term of Guided Filter. eps^2 is similar to the sigma in the color
        /// space into bilateralFilter.</param>
        /// <returns></returns>
        public static GuidedFilter Create(
            InputArray guide, int radius, double eps)
        {
            if (guide == null)
                throw new ArgumentNullException(nameof(guide));
            guide.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_createGuidedFilter(
                    guide.CvPtr, radius, eps, out var p));
            
            GC.KeepAlive(guide); 
            return new GuidedFilter(p);
        }

        /// <summary>
        /// Apply Guided Filter to the filtering image.
        /// </summary>
        /// <param name="src">filtering image with any numbers of channels.</param>
        /// <param name="dst">output image.</param>
        /// <param name="dDepth">optional depth of the output image. dDepth can be set to -1, which will be equivalent to src.depth().</param>
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
                NativeMethods.ximgproc_GuidedFilter_filter(
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
                    NativeMethods.ximgproc_Ptr_GuidedFilter_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_GuidedFilter_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
