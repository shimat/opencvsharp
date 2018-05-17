using System;

namespace OpenCvSharp.XImgProc.Segmentation
{
    /// <summary>
    /// Strategy for the selective search segmentation algorithm.
    /// The class implements a generic stragery for the algorithm described in @cite uijlings2013selective.
    /// </summary>
    public abstract class SelectiveSearchSegmentationStrategy : Algorithm
    {
        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected SelectiveSearchSegmentationStrategy(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Set a initial image, with a segementation.
        /// </summary>
        /// <param name="img">The input image. Any number of channel can be provided</param>
        /// <param name="regions">A segementation of the image. The parameter must be the same size of img.</param>
        /// <param name="sizes">The sizes of different regions</param>
        /// <param name="imageId">If not set to -1, try to cache pre-computations. If the same set og (img, regions, size) is used, the image_id need to be the same.</param>
        public virtual void SetImage(InputArray img, InputArray regions, InputArray sizes, int imageId = -1)
        {
            ThrowIfDisposed();
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (regions == null)
                throw new ArgumentNullException(nameof(regions));
            if (sizes == null)
                throw new ArgumentNullException(nameof(sizes));
            img.ThrowIfDisposed();
            regions.ThrowIfDisposed();
            sizes.ThrowIfDisposed();

            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentationStrategy_setImage(
                ptr, img.CvPtr, regions.CvPtr, sizes.CvPtr, imageId);

            GC.KeepAlive(this);
            GC.KeepAlive(img);
            GC.KeepAlive(regions);
            GC.KeepAlive(sizes);
        }

        /// <summary>
        /// Return the score between two regions (between 0 and 1)
        /// </summary>
        /// <param name="r1">The first region</param>
        /// <param name="r2">The second region</param>
        public virtual float Get(int r1, int r2)
        {
            ThrowIfDisposed();
            var ret =  NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentationStrategy_get(ptr, r1, r2);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// Inform the strategy that two regions will be merged
        /// </summary>
        /// <param name="r1">The first region</param>
        /// <param name="r2">The second region</param>
        public virtual void Merge(int r1, int r2)
        {
            ThrowIfDisposed();
            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentationStrategy_merge(ptr, r1, r2);
            GC.KeepAlive(this);
        }
    }
}
