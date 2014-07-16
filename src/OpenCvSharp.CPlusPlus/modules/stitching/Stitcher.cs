using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// High level image stitcher. 
    /// It's possible to use this class without being aware of the entire stitching 
    /// pipeline. However, to be able to achieve higher stitching stability and 
    /// quality of the final images at least being familiar with the theory is recommended
    /// </summary>
    public sealed class Stitcher : DisposableCvObject
    {
        private bool disposed;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming
        public const int ORIG_RESOL = -1;

        /// <summary>
        /// Status code
        /// </summary>
        public enum Status
        {
            OK,
            ErrorNeedMoreImgs,
        }
// ReSharper restore InconsistentNaming
#pragma warning restore 1591

        #region Init & Disposal
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr">cv::Stitcher*</param>
        private Stitcher(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates a stitcher with the default parameters.
        /// </summary>
        /// <param name="tryUseGpu">Flag indicating whether GPU should be used 
        /// whenever it's possible.</param>
        public static Stitcher CreateDefault(bool tryUseGpu = false)
        {
            IntPtr ptr = NativeMethods.stitching_Stitcher_createDefault(tryUseGpu ? 1 : 0);
            return new Stitcher(ptr);
        }

        /// <summary>
        /// Deletes all resources 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (ptr != IntPtr.Zero)
                    {
                        NativeMethods.stitching_Stitcher_delete(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Try to stitch the given images.
        /// </summary>
        /// <param name="images">Input images.</param>
        /// <param name="pano">Final pano.</param>
        /// <returns>Status code.</returns>
        public Status Stitch(InputArray images, OutputArray pano)
        {
            if (images == null)
                throw new ArgumentNullException("images");
            if (pano == null) 
                throw new ArgumentNullException("pano");
            images.ThrowIfDisposed();
            pano.ThrowIfNotReady();

            Status status = (Status)NativeMethods.stitching_Stitcher_stitch1_InputArray(
                ptr, images.CvPtr, pano.CvPtr);

            pano.Fix();

            return status;
        }

        /// <summary>
        /// Try to stitch the given images.
        /// </summary>
        /// <param name="images">Input images.</param>
        /// <param name="pano">Final pano.</param>
        /// <returns>Status code.</returns>
        public Status Stitch(IEnumerable<Mat> images, OutputArray pano)
        {
            if (images == null)
                throw new ArgumentNullException("images");
            if (pano == null)
                throw new ArgumentNullException("pano");
            pano.ThrowIfNotReady();

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);

            Status status = (Status)NativeMethods.stitching_Stitcher_stitch1_array(
                ptr, imagesPtrs, imagesPtrs.Length, pano.CvPtr);

            pano.Fix();

            return status;
        }

        /// <summary>
        /// Try to stitch the given images.
        /// </summary>
        /// <param name="images">Input images.</param>
        /// <param name="rois">Region of interest rectangles.</param>
        /// <param name="pano">Final pano.</param>
        /// <returns>Status code.</returns>
        public Status Stitch(InputArray images, Rect[][] rois, OutputArray pano)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
