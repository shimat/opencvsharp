using System;

namespace OpenCvSharp.XImgProc.Segmentation
{
    /// <inheritdoc />
    /// <summary>
    /// Strategy for the selective search segmentation algorithm.
    /// The class implements a generic stragery for the algorithm described in @cite uijlings2013selective.
    /// </summary>
    public abstract class SelectiveSearchSegmentationStrategy : Algorithm
    {
        /// <summary>
        /// 
        /// </summary>
        public Ptr PtrObj { get; private set; }

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected SelectiveSearchSegmentationStrategy(Ptr ptrObj)
        {
            PtrObj = ptrObj;
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            PtrObj?.Dispose();
            PtrObj = null;
            base.DisposeManaged();
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

    /// <inheritdoc />
    /// <summary>
    /// Color-based strategy for the selective search segmentation algorithm.
    /// The class is implemented from the algorithm described in @cite uijlings2013selective.
    /// </summary>
    public class SelectiveSearchSegmentationStrategyColor : SelectiveSearchSegmentationStrategy {

        /// <inheritdoc />
        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected SelectiveSearchSegmentationStrategyColor(IntPtr p)
            : base(new Ptr(p))
        {
        }

        /// <summary>
        /// Create a new color-based strategy
        /// </summary>
        /// <returns></returns>
        public static SelectiveSearchSegmentationStrategyColor Create()
        {
            IntPtr p = NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyColor();
            return new SelectiveSearchSegmentationStrategyColor(p);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Size-based strategy for the selective search segmentation algorithm.
    /// The class is implemented from the algorithm described in @cite uijlings2013selective.
    /// </summary>
    public class SelectiveSearchSegmentationStrategySize : SelectiveSearchSegmentationStrategy
    {
        /// <inheritdoc />
        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected SelectiveSearchSegmentationStrategySize(IntPtr p)
            : base(new Ptr(p))
        {
        }

        /// <summary>
        /// Create a new size-based strategy
        /// </summary>
        /// <returns></returns>
        public static SelectiveSearchSegmentationStrategySize Create()
        {
            IntPtr p = NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategySize();
            return new SelectiveSearchSegmentationStrategySize(p);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }

    /// <summary>
    /// Texture-based strategy for the selective search segmentation algorithm.
    /// The class is implemented from the algorithm described in @cite uijlings2013selective.
    /// </summary>
    public class SelectiveSearchSegmentationStrategyTexture : SelectiveSearchSegmentationStrategy {
        /// <inheritdoc />
        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected SelectiveSearchSegmentationStrategyTexture(IntPtr p)
            : base(new Ptr(p))
        {
        }

        /// <summary>
        /// Create a new size-based strategy
        /// </summary>
        /// <returns></returns>
        public static SelectiveSearchSegmentationStrategyTexture Create()
        {
            IntPtr p = NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyTexture();
            return new SelectiveSearchSegmentationStrategyTexture(p);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }

    /// <summary>
    /// Fill-based strategy for the selective search segmentation algorithm.
    /// The class is implemented from the algorithm described in @cite uijlings2013selective.
    /// </summary>
    public class SelectiveSearchSegmentationStrategyFill : SelectiveSearchSegmentationStrategy {
        /// <inheritdoc />
        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected SelectiveSearchSegmentationStrategyFill(IntPtr p)
            : base(new Ptr(p))
        {
        }

        /// <summary>
        /// Create a new fill-based strategy
        /// </summary>
        /// <returns></returns>
        public static SelectiveSearchSegmentationStrategyFill Create()
        {
            IntPtr p = NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyFill();
            return new SelectiveSearchSegmentationStrategyFill(p);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
