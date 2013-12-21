/*
 * (C) 2008-2013 Schima
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
    /// MSER抽出機
    /// </summary>
#else
    /// <summary>
    /// Maximally-Stable Extremal Region Extractor
    /// </summary>
#endif
    [Serializable]
    public class MSER : CvMSERParams, ICloneable
    {
        #region Constructors
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
#endif
        public MSER()
            : base()
        {
        }
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
        /// <param name="min_diversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="max_evolution">for color image, the evolution steps</param>
        /// <param name="area_threshold">the area threshold to cause re-initialize</param>
        /// <param name="min_margin">ignore too small margin</param>
        /// <param name="edge_blur_size">the aperture size for edge blur</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
        /// <param name="min_diversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="max_evolution">for color image, the evolution steps</param>
        /// <param name="area_threshold">the area threshold to cause re-initialize</param>
        /// <param name="min_margin">ignore too small margin</param>
        /// <param name="edge_blur_size">the aperture size for edge blur</param>
#endif
        public MSER(int delta, int min_area, int max_area, float max_variation, float min_diversity, int max_evolution, double area_threshold, double min_margin, int edge_blur_size)
            : base(delta, min_area, max_area, max_variation, min_diversity, max_evolution, area_threshold, min_margin, edge_blur_size)
        {
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
        public CvPoint[][] Extract(Mat image, Mat mask)
        {
            if(image == null)
                throw new ArgumentNullException("image");

            CvMat _image = image.ToCvMat();
            IntPtr pmask = (mask == null) ? IntPtr.Zero : mask.ToCvMat().CvPtr;
            IntPtr pcontours = IntPtr.Zero;

            using(CvMemStorage storage = new CvMemStorage(0))
	        {
        	    CvInvoke.cvExtractMSER(_image.CvPtr, pmask, ref pcontours, storage.CvPtr, Struct);
                if (pcontours == IntPtr.Zero)
                {
                    return new CvPoint[0][];
                }
                CvSeq<IntPtr> seq = new CvSeq<IntPtr>(pcontours);
                CvContour[] contours = Array.ConvertAll<IntPtr, CvContour>(seq.ToArray(), delegate(IntPtr p) { return new CvContour(p); });
                CvPoint[][] result = new CvPoint[contours.Length][];
                for (int i = 0; i < contours.Length; i++)
                {
                    result[i] = contours[i].ToArray();
                }
                return result;
	        }
        }
        #endregion

        #region ICloneable Members
#if LANG_JP
        /// <summary>
        /// 現在のインスタンスのコピーである新しいオブジェクトを作成します。    
        /// </summary>
        /// <returns>このインスタンスのコピーである新しいオブジェクト。</returns>
#else
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
#endif
        public new MSER Clone()
        {
            return (MSER)MemberwiseClone();
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
    }
}
