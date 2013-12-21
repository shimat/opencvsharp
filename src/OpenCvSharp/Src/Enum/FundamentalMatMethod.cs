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
	/// 基礎行列の計算手法
	/// </summary>
#else
    /// <summary>
    /// Method for computing the fundamental matrix 
    /// </summary>
#endif
    public enum FundamentalMatMethod : int
    {
#if LANG_JP
		/// <summary>
		/// 7-pointアルゴリズム． N == 7 
        /// [CV_FM_7POINT]
		/// </summary>
#else
        /// <summary>
        /// for 7-point algorithm. N == 7 
        /// [CV_FM_7POINT]
        /// </summary>
#endif
        Point7 = CvConst.CV_FM_7POINT,


#if LANG_JP
		/// <summary>
		/// 8-pointアルゴリズム． N > 8 
        /// [CV_FM_8POINT]
		/// </summary>
#else
        /// <summary>
        /// for 8-point algorithm. N >= 8 
        /// [CV_FM_8POINT]
        /// </summary>
#endif
        Point8 = CvConst.CV_FM_8POINT,


#if LANG_JP
		/// <summary>
		/// LMedSアルゴリズム． N >= 8 
        /// [CV_FM_LMEDS_ONLY]
		/// </summary>
#else
        /// <summary>
        /// for LMedS algorithm. N > 8 
        /// [CV_FM_LMEDS_ONLY]
        /// </summary>
#endif
        LMedSOnly = CvConst.CV_FM_LMEDS_ONLY,


#if LANG_JP
		/// <summary>
		/// RANSAC アルゴリズム． N > 8 
        /// [CV_FM_RANSAC_ONLY]
		/// </summary>
#else
        /// <summary>
        /// for RANSAC algorithm. N > 8 
        /// [CV_FM_RANSAC_ONLY]
        /// </summary>
#endif
        RansacOnly = CvConst.CV_FM_RANSAC_ONLY,


#if LANG_JP
		/// <summary>
		/// LMedSアルゴリズム． N >= 8 
        /// [CV_FM_LMEDS]
		/// </summary>
#else
        /// <summary>
        /// for LMedS algorithm. N > 8 
        /// [CV_FM_LMEDS]
        /// </summary>
#endif
        LMedS = CvConst.CV_FM_LMEDS,


#if LANG_JP
		/// <summary>
		/// RANSAC アルゴリズム． N > 8 
        /// [CV_FM_RANSAC]
		/// </summary>
#else
        /// <summary>
        /// for RANSAC algorithm. N > 8 
        /// [CV_FM_RANSAC]
        /// </summary>
#endif
        Ransac = CvConst.CV_FM_RANSAC,
    }
}
