/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// MSER (Maximal Stable Extremal Regions) 抽出機
    /// </summary>
#else
    /// <summary>
    /// Maximal Stable Extremal Regions class
    /// </summary>
#endif
    public class MSER : FeatureDetector
    {
        private bool disposed;

        #region Init & Disposal
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
        public MSER(
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
            ptr = CppInvoke.features2d_MSER_new(delta, minArea, maxArea, maxVariation, minDiversity,
                                                maxEvolution, areaThreshold, minMargin, edgeBlurSize);
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
                    }
                    // releases unmanaged resources
                    if (ptr != IntPtr.Zero)
                        CppInvoke.features2d_MSER_delete(ptr);
                    ptr = IntPtr.Zero;
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
#if LANG_JP
        /// <summary>
        /// MSERのすべての輪郭情報を抽出する
        /// </summary>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Extracts the contours of Maximally Stable Extremal Regions
        /// </summary>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
#endif
        public Point[][] Run(Mat image, Mat mask)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();

            IntPtr msers;
            CppInvoke.features2d_MSER_detect(ptr, image.CvPtr, out msers, Cv2.ToPtr(mask));

            using (VectorOfVectorPoint msersVec = new VectorOfVectorPoint(msers))
            {
                return msersVec.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public AlgorithmInfo Info
        {
            get
            {
                ThrowIfDisposed();
                IntPtr pInfo = CppInvoke.features2d_MSER_info(ptr);
                return new AlgorithmInfo(pInfo);
            }
        }
        #endregion
    }
}
