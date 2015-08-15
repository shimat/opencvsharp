using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

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
    public class MSER : Feature2D
    {
        private bool disposed;
        private Ptr<MSER> ptrObj;

        #region Init & Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::MSER*
        /// </summary>
        protected MSER(IntPtr p)
        {
            ptrObj = new Ptr<MSER>(p);
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

#if LANG_JP
    /// <summary>
    /// リソースの解放
    /// </summary>
    /// <param name="disposing">
    /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
    /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
    ///</param>
#else
        /// <summary>
        /// Releases the resources
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    // releases managed resources
                    if (disposing)
                    {
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
                        }
                    }
                    // releases unmanaged resources

                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_MSER_getDelta(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_MSER_setDelta(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MinArea
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_MSER_getMinArea(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_MSER_setMinArea(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MaxArea
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_MSER_getMaxArea(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_MSER_setMaxArea(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Pass2Only
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_MSER_getPass2Only(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_MSER_setDelta(ptr, value ? 1 : 0);
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
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (image == null) 
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();

            using (var msersVec = new VectorOfVectorPoint())
            using (var bboxesVec = new VectorOfRect())
            {
                NativeMethods.features2d_MSER_detectRegions(
                    ptr, image.CvPtr, msersVec.CvPtr, bboxesVec.CvPtr);
                msers = msersVec.ToArray();
                bboxes = bboxesVec.ToArray();
            }

            GC.KeepAlive(image);
        }

        #endregion
    }
}
