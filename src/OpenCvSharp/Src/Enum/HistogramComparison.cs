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
	/// cvCompareHistで用いる、CvHistogramの比較方法
	/// </summary>
#else
    /// <summary>
    /// Comparison methods for cvCompareHist
    /// </summary>
#endif
    public enum HistogramComparison : int
    {
#if LANG_JP
		/// <summary>
		/// 相関 [CV_COMP_CORREL]
		/// </summary>
#else
        /// <summary>
        /// Correlation [CV_COMP_CORREL]
        /// </summary>
#endif
        Correl = CvConst.CV_COMP_CORREL,


#if LANG_JP
		/// <summary>
		/// カイ二乗 [CV_COMP_CHISQR]
		/// </summary>
#else
        /// <summary>
        /// Chi-Square [CV_COMP_CHISQR]
        /// </summary>
#endif
        Chisqr = CvConst.CV_COMP_CHISQR,


#if LANG_JP
		/// <summary>
		/// 交差 [CV_COMP_INTERSECT]
		/// </summary>
#else
        /// <summary>
        /// Intersection [CV_COMP_INTERSECT]
        /// </summary>
#endif
        Intersect = CvConst.CV_COMP_INTERSECT,


#if LANG_JP
		/// <summary>
		/// Bhattacharyya距離 [CV_COMP_BHATTACHARYYA]. 正規化されたヒストグラムでのみ実行可能である．
		/// </summary>
#else
        /// <summary>
        /// Bhattacharyya distance [CV_COMP_BHATTACHARYYA]
        /// </summary>
#endif
        Bhattacharyya = CvConst.CV_COMP_BHATTACHARYYA,
    }
}
