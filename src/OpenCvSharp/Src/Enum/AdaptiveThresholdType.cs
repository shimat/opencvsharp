/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// 適応的閾値処理で使用するアルゴリズムの種類
	/// </summary>
#else
    /// <summary>
    /// Adaptive thresholding algorithms
    /// </summary>
#endif
    public enum AdaptiveThresholdType : int
    {
#if LANG_JP
		/// <summary>
		/// 注目ピクセルの block_size × block_size 隣接領域の平均から，param1 を引いた値を閾値とする.
        /// [CV_ADAPTIVE_THRESH_MEAN_C]
		/// </summary>
#else
        /// <summary>
        /// It is a mean of block_size × block_size pixel neighborhood, subtracted by param1.
        /// [CV_ADAPTIVE_THRESH_MEAN_C]
        /// </summary>
#endif
        MeanC = CvConst.CV_ADAPTIVE_THRESH_MEAN_C,


#if LANG_JP
		/// <summary>
		/// 注目ピクセルの block_size × block_size 隣接領域の重み付き総和（ガウシアン）から param1 を引いた値を閾値とする. 
        /// [CV_ADAPTIVE_THRESH_GAUSSIAN_C]
		/// </summary>
#else
        /// <summary>
        /// it is a weighted sum (Gaussian) of block_size × block_size pixel neighborhood, subtracted by param1.
        /// [CV_ADAPTIVE_THRESH_GAUSSIAN_C]
        /// </summary>
#endif
        GaussianC = CvConst.CV_ADAPTIVE_THRESH_GAUSSIAN_C,
    }
}
