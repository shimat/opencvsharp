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
	/// cvCheckArrの処理フラグ
	/// </summary>
#else
    /// <summary>
    /// The operation flags for cvCheckArr
    /// </summary>
#endif
    [Flags]
    public enum CheckArrFlag : int
    {
#if LANG_JP
		/// <summary>
		/// すべての要素が NaN か ±(Infinity) でないかだけをチェックする
        /// [= 0]
		/// </summary>
#else
        /// <summary>
        /// The function just checks that every element is neither NaN nor ±Infinity.
        /// </summary>
#endif
        NanOrInfinity = 0,


#if LANG_JP
		/// <summary>
		/// 配列のすべての要素について [minVal,maxVal) の範囲内であるかどうかをチェックする
        /// [CV_CHECK_RANGE]
		/// </summary>
#else
        /// <summary>
        /// The function checks that every value of array is within [minVal,maxVal) range.
        /// [CV_CHECK_RANGE]
        /// </summary>
#endif
        Range = CvConst.CV_CHECK_RANGE,


#if LANG_JP
		/// <summary>
		/// 要素に無効な値や範囲外のものがあっても，エラーを発生させない
        /// [CV_CHECK_QUIET]
		/// </summary>
#else
        /// <summary>
        /// The function does not raises an error if an element is invalid or out of range.
        /// [CV_CHECK_QUIET]
        /// </summary>
#endif
        Quiet = CvConst.CV_CHECK_QUIET,
    }
}
