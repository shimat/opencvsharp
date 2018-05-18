using System;

namespace OpenCvSharp.XImgProc.Segmentation
{
    /// <inheritdoc />
    /// <summary>
    /// Regroup multiple strategies for the selective search segmentation algorithm
    /// </summary>
    public class SelectiveSearchSegmentationStrategyMultiple : SelectiveSearchSegmentationStrategy
    {
        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected SelectiveSearchSegmentationStrategyMultiple(IntPtr p)
            : base(new Ptr(p))
        {
        }

        /// <summary>
        /// Set a initial image, with a segementation.
        /// </summary>
        /// <param name="img">The input image. Any number of channel can be provided</param>
        /// <param name="regions">A segementation of the image. The parameter must be the same size of img.</param>
        /// <param name="sizes">The sizes of different regions</param>
        /// <param name="imageId">If not set to -1, try to cache pre-computations. If the same set og (img, regions, size) is used, the image_id need to be the same.</param>
        public new virtual void SetImage(InputArray img, InputArray regions, InputArray sizes, int imageId = -1)
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
        public new virtual float Get(int r1, int r2)
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
        public new virtual void Merge(int r1, int r2)
        {
            ThrowIfDisposed();
            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentationStrategy_merge(ptr, r1, r2);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Create a new multiple strategy
        /// </summary>
        /// <returns></returns>
        public static SelectiveSearchSegmentationStrategyMultiple Create()
        {
            IntPtr p = NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple0();
            return new SelectiveSearchSegmentationStrategyMultiple(p);
        }

        /// <summary>
        /// Create a new multiple strategy and set one subtrategy
        /// </summary>
        /// <param name="s1">The first strategy</param>
        /// <returns></returns>
        public static SelectiveSearchSegmentationStrategyMultiple Create(
            SelectiveSearchSegmentationStrategy s1)
        {
            if (s1 == null)
                throw new ArgumentNullException(nameof(s1));
            IntPtr p = NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple1(s1.CvPtr);
            return new SelectiveSearchSegmentationStrategyMultiple(p);
        }

        /// <summary>
        /// Create a new multiple strategy and set one subtrategy
        /// </summary>
        /// <param name="s1">The first strategy</param>
        /// <param name="s2">The second strategy</param>
        /// <returns></returns>
        public static SelectiveSearchSegmentationStrategyMultiple Create(
            SelectiveSearchSegmentationStrategy s1, SelectiveSearchSegmentationStrategy s2)
        {
            if (s1 == null)
                throw new ArgumentNullException(nameof(s1));
            IntPtr p = NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple2(s1.CvPtr, s2.CvPtr);
            return new SelectiveSearchSegmentationStrategyMultiple(p);
        }

        /// <summary>
        /// Create a new multiple strategy and set one subtrategy
        /// </summary>
        /// <param name="s1">The first strategy</param>
        /// <param name="s2">The second strategy</param>
        /// <param name="s3">The third strategy</param>
        /// <returns></returns>
        public static SelectiveSearchSegmentationStrategyMultiple Create(
            SelectiveSearchSegmentationStrategy s1, SelectiveSearchSegmentationStrategy s2, SelectiveSearchSegmentationStrategy s3)
        {
            if (s1 == null)
                throw new ArgumentNullException(nameof(s1));
            IntPtr p = NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple3(s1.CvPtr, s2.CvPtr, s3.CvPtr);
            return new SelectiveSearchSegmentationStrategyMultiple(p);
        }

        /// <summary>
        /// Create a new multiple strategy and set one subtrategy
        /// </summary>
        /// <param name="s1">The first strategy</param>
        /// <param name="s2">The second strategy</param>
        /// <param name="s3">The third strategy</param>
        /// <param name="s4">The forth strategy</param>
        /// <returns></returns>
        public static SelectiveSearchSegmentationStrategyMultiple Create(
            SelectiveSearchSegmentationStrategy s1, SelectiveSearchSegmentationStrategy s2, SelectiveSearchSegmentationStrategy s3, SelectiveSearchSegmentationStrategy s4)
        {
            if (s1 == null)
                throw new ArgumentNullException(nameof(s1));
            IntPtr p = NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple4(s1.CvPtr, s2.CvPtr, s3.CvPtr, s4.CvPtr);
            return new SelectiveSearchSegmentationStrategyMultiple(p);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
