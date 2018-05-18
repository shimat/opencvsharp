using System;

namespace OpenCvSharp.XImgProc.Segmentation
{
    /// <summary>
    /// Selective search segmentation algorithm.
    /// The class implements the algorithm described in @cite uijlings2013selective.
    /// </summary>
    public class SelectiveSearchSegmentation : Algorithm
    {
        private Ptr ptrObj;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected SelectiveSearchSegmentation(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
        }

        /// <summary>
        /// Create a new SelectiveSearchSegmentation class.
        /// </summary>
        /// <returns></returns>
        public static SelectiveSearchSegmentation Create()
        {
            IntPtr p = NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentation();
            return new SelectiveSearchSegmentation(p);
        }
        
        /// <summary>
        /// Set a image used by switch* functions to initialize the class
        /// </summary>
        /// <param name="img">The image</param>
        public virtual void SetBaseImage(InputArray img)
        {
            ThrowIfDisposed();
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();

            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentation_setBaseImage(ptr, img.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(img);
        }

        /// <summary>
        /// Initialize the class with the 'Single stragegy' parameters describled in @cite uijlings2013selective.
        /// </summary>
        /// <param name="k">The k parameter for the graph segmentation</param>
        /// <param name="sigma">The sigma parameter for the graph segmentation</param>
        public virtual void SwitchToSingleStrategy(int k = 200, float sigma = 0.8f)
        {
            ThrowIfDisposed();
            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentation_switchToSingleStrategy(ptr, k, sigma);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Initialize the class with the 'Selective search fast' parameters describled in @cite uijlings2013selective.
        /// </summary>
        /// <param name="baseK">The k parameter for the first graph segmentation</param>
        /// <param name="incK">The increment of the k parameter for all graph segmentations</param>
        /// <param name="sigma">The sigma parameter for the graph segmentation</param>
        public virtual void SwitchToSelectiveSearchFast(int baseK = 150, int incK = 150, float sigma = 0.8f)
        {
            ThrowIfDisposed();
            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchFast(ptr, baseK, incK, sigma);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Initialize the class with the 'Selective search fast' parameters describled in @cite uijlings2013selective.
        /// </summary>
        /// <param name="baseK">The k parameter for the first graph segmentation</param>
        /// <param name="incK">The increment of the k parameter for all graph segmentations</param>
        /// <param name="sigma">The sigma parameter for the graph segmentation</param>
        public virtual void SwitchToSelectiveSearchQuality(int baseK = 150, int incK = 150, float sigma = 0.8f)
        {
            ThrowIfDisposed();
            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchQuality(ptr, baseK, incK, sigma);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Add a new image in the list of images to process.
        /// </summary>
        /// <param name="img">The image</param>
        public virtual void AddImage(InputArray img)
        {
            ThrowIfDisposed();
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();

            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentation_addImage(ptr, img.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(img);
        }

        /// <summary>
        /// Clear the list of images to process
        /// </summary>
        public virtual void ClearImages()
        {
            ThrowIfDisposed();
            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentation_clearImages(ptr);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Add a new graph segmentation in the list of graph segementations to process.
        /// </summary>
        /// <param name="g">The graph segmentation</param>
        public virtual void AddGraphSegmentation(GraphSegmentation g)
        {
            ThrowIfDisposed();
            if (g == null)
                throw new ArgumentNullException(nameof(g));
            g.ThrowIfDisposed();

            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentation_addGraphSegmentation(ptr, g.PtrObj.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(g);
        }

        /// <summary>
        /// Clear the list of graph segmentations to process
        /// </summary>
        public virtual void ClearGraphSegmentations()
        {
            ThrowIfDisposed();
            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentation_clearGraphSegmentations(ptr);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Add a new strategy in the list of strategy to process.
        /// </summary>
        /// <param name="s">The strategy</param>
        public virtual void AddStrategy(SelectiveSearchSegmentationStrategy s)
        {
            ThrowIfDisposed();
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            s.ThrowIfDisposed();

            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentation_addStrategy(ptr, s.PtrObj.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(s);
        }

        /// <summary>
        /// Clear the list of strategy to process;
        /// </summary>
        public virtual void ClearStrategies()
        {
            ThrowIfDisposed();
            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentation_clearStrategies(ptr);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Based on all images, graph segmentations and stragies, computes all possible rects and return them
        /// </summary>
        /// <param name="rects">The list of rects. The first ones are more relevents than the lasts ones.</param>
        public virtual void Process(out Rect[] rects)
        {
            ThrowIfDisposed();
            using (var rectsVec = new VectorOfRect())
            {
                NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentation_process(ptr, rectsVec.CvPtr);
                rects = rectsVec.ToArray();
            }
            GC.KeepAlive(this);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
