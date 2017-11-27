using System;

namespace OpenCvSharp
{
// ReSharper disable once InconsistentNaming

#if LANG_JP
    /// <summary>
    /// MSER (Maximal Stable Extremal Regions) 抽出機
    /// </summary>
#else
    /// <summary>
    /// Maximal Stable Extremal Regions class
    /// </summary>
#endif
    // ReSharper disable once InconsistentNaming
    public class MSER : Feature2D
    {
        private Ptr ptrObj;

        //internal override IntPtr PtrObj => ptrObj.CvPtr;

        #region Init & Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::MSER*
        /// </summary>
        protected MSER(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="minArea">prune the area which smaller than min_area</param>
        /// <param name="maxArea">prune the area which bigger than max_area</param>
        /// <param name="maxVariation">prune the area have simliar size to its children</param>
        /// <param name="minDiversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="maxEvolution">for color image, the evolution steps</param>
        /// <param name="areaThreshold">the area threshold to cause re-initialize</param>
        /// <param name="minMargin">ignore too small margin</param>
        /// <param name="edgeBlurSize">the aperture size for edge blur</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="minArea">prune the area which smaller than min_area</param>
        /// <param name="maxArea">prune the area which bigger than max_area</param>
        /// <param name="maxVariation">prune the area have simliar size to its children</param>
        /// <param name="minDiversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="maxEvolution">for color image, the evolution steps</param>
        /// <param name="areaThreshold">the area threshold to cause re-initialize</param>
        /// <param name="minMargin">ignore too small margin</param>
        /// <param name="edgeBlurSize">the aperture size for edge blur</param>
#endif
        public static MSER Create(
            int delta = 5, 
            int minArea = 60, 
            int maxArea = 14400, 
            double maxVariation = 0.25, 
            double minDiversity = 0.2, 
            int maxEvolution = 200, 
            double areaThreshold = 1.01, 
            double minMargin = 0.003, 
            int edgeBlurSize = 5)
        {
            IntPtr ptr = NativeMethods.features2d_MSER_create(delta, minArea, maxArea, maxVariation, minDiversity,
                                                maxEvolution, areaThreshold, minMargin, edgeBlurSize);
            return new MSER(ptr);
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

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int Delta
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_MSER_getDelta(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_MSER_setDelta(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MinArea
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_MSER_getMinArea(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_MSER_setMinArea(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MaxArea
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_MSER_getMaxArea(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_MSER_setMaxArea(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Pass2Only
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_MSER_getPass2Only(ptr) != 0;
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_MSER_setPass2Only(ptr, value ? 1 : 0);
                GC.KeepAlive(this);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="msers"></param>
        /// <param name="bboxes"></param>
        public virtual void DetectRegions(
            InputArray image, out Point[][] msers, out Rect[] bboxes)
        {
            ThrowIfDisposed();
            if (image == null) 
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            using (var msersVec = new VectorOfVectorPoint())
            using (var bboxesVec = new VectorOfRect())
            {
                NativeMethods.features2d_MSER_detectRegions(
                    ptr, image.CvPtr, msersVec.CvPtr, bboxesVec.CvPtr);
                GC.KeepAlive(this);
                msers = msersVec.ToArray();
                bboxes = bboxesVec.ToArray();
            }

            GC.KeepAlive(image);
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.features2d_Ptr_MSER_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_MSER_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
