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
	/// cvCmp, cvCmpS等のメソッドで用いる, CvArrの比較方法
    /// </summary>
#else
    /// <summary>
    /// The flag specifying the relation between the elements to be checked
    /// </summary>
#endif
    public enum ArrComparison : int
    {
#if LANG_JP
		/// <summary>
		/// src1(I) と value は等しい 
        /// [CV_CMP_EQ]
		/// </summary>
#else
        /// <summary>
        /// src1(I) "equal to" src2(I)
        /// [CV_CMP_EQ]
        /// </summary>
#endif
        EQ = CvConst.CV_CMP_EQ,


#if LANG_JP
		/// <summary>
		/// src1(I) は value より大きい 
        /// [CV_CMP_GT]
		/// </summary>
#else
        /// <summary>
        /// src1(I) "greater than" src2(I)
        /// [CV_CMP_GT]
        /// </summary>
#endif
        GT = CvConst.CV_CMP_GT,


#if LANG_JP
		/// <summary>
		/// src1(I) は value より大きいか等しい 
        /// [CV_CMP_GE]
		/// </summary>
#else
        /// <summary>
        /// src1(I) "greater or equal" src2(I)
        /// [CV_CMP_GE]
        /// </summary>
#endif
        GE = CvConst.CV_CMP_GE,


#if LANG_JP
		/// <summary>
		/// src1(I) は value より小さい 
        /// [CV_CMP_LT]
		/// </summary>
#else
        /// <summary>
        /// src1(I) "less than" src2(I)
        /// [CV_CMP_LT]
        /// </summary>
#endif
        LT = CvConst.CV_CMP_LT,


#if LANG_JP
		/// <summary>
		/// src1(I) は value より小さいか等しい 
        /// [CV_CMP_LE]
		/// </summary>
#else
        /// <summary>
        /// src1(I) "less or equal" src2(I)
        /// [CV_CMP_LE]
        /// </summary>
#endif
        LE = CvConst.CV_CMP_LE,


#if LANG_JP
		/// <summary>
		/// src1(I) と value は等しくない 
        /// [CV_CMP_NE]
		/// </summary>
#else
        /// <summary>
        /// src1(I) "not equal to" src2(I)
        /// [CV_CMP_NE]
        /// </summary>
#endif
        NE = CvConst.CV_CMP_NE,
    }
}
