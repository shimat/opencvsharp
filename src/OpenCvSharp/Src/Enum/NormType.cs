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
	/// 正規化のタイプ
	/// </summary>
#else
    /// <summary>
    /// Type of norm
    /// </summary>
#endif
    [Flags]
    public enum NormType : int
    {
#if LANG_JP
        /// <summary>
        /// 配列のC-norm（絶対値の最大値）を正規化 
        /// [CV_C]
        /// </summary>
#else
        /// <summary>
        /// The C-norm (maximum of absolute values) of the array is normalized.
        /// [CV_C]
        /// </summary>
#endif
        C = CvConst.CV_C,


#if LANG_JP
        /// <summary>
        /// 配列のL1-norm（絶対値の合計）を正規化 
        /// [CV_L1]
        /// </summary>
#else
        /// <summary>
        /// The L1-norm (sum of absolute values) of the array is normalized.
        /// [CV_L1]
        /// </summary>
#endif
        L1 = CvConst.CV_L1,


#if LANG_JP
        /// <summary>
        /// 配列のL2-norm（ユークリッド距離）を正規化  
        /// [CV_L2]
        /// </summary>
#else
        /// <summary>
        /// The (Euclidean) L2-norm of the array is normalized.
        /// [CV_L2]
        /// </summary>
#endif
        L2 = CvConst.CV_L2,


#if LANG_JP
        /// <summary>
        /// [CV_NORM_MASK]
        /// </summary>
#else
        /// <summary>
        /// [CV_NORM_MASK]
        /// </summary>
#endif
        NormMask = CvConst.CV_NORM_MASK,


#if LANG_JP
        /// <summary> 
        /// [CV_RELATIVE]
        /// </summary>
#else
        /// <summary>
        /// [CV_RELATIVE]
        /// </summary>
#endif
        Relative = CvConst.CV_RELATIVE,


#if LANG_JP
        /// <summary>
        /// [CV_DIFF]
        /// </summary>
#else
        /// <summary>
        /// [CV_DIFF]
        /// </summary>
#endif
        Diff = CvConst.CV_DIFF,


#if LANG_JP
        /// <summary>
        /// 配列の値が指定の範囲に収まるようにスケーリングとシフトを行う 
        /// [CV_MINMAX]
        /// </summary>
#else
        /// <summary>
        /// The array values are scaled and shifted to the specified range.
        /// [CV_MINMAX]
        /// </summary>
#endif
        MinMax = CvConst.CV_MINMAX,



#if LANG_JP
        /// <summary>
        /// [CV_DIFF_C]
        /// </summary>
#else
        /// <summary>
        /// [CV_DIFF_C]
        /// </summary>
#endif
        DiffC = CvConst.CV_DIFF_C,
#if LANG_JP
        /// <summary>
        /// [CV_DIFF_L1]
        /// </summary>
#else
        /// <summary>
        /// [CV_DIFF_L1]
        /// </summary>
#endif
        DiffL1 = CvConst.CV_DIFF_L1,
#if LANG_JP
        /// <summary>
        /// [CV_DIFF_L2]
        /// </summary>
#else
        /// <summary>
        /// [CV_DIFF_L2]
        /// </summary>
#endif
        DiffL2 = CvConst.CV_DIFF_L2,
#if LANG_JP
        /// <summary>
        /// [CV_RELATIVE_C]
        /// </summary>
#else
        /// <summary>
        /// [CV_RELATIVE_C]
        /// </summary>
#endif
        RelativeC = CvConst.CV_RELATIVE_C,
#if LANG_JP
        /// <summary>
        /// [CV_RELATIVE_L1]
        /// </summary>
#else
        /// <summary>
        /// [CV_RELATIVE_L1]
        /// </summary>
#endif
        RelativeL1 = CvConst.CV_RELATIVE_L1,
#if LANG_JP
        /// <summary>
        /// [CV_RELATIVE_L2]
        /// </summary>
#else
        /// <summary>
        /// [CV_RELATIVE_L2]
        /// </summary>
#endif
        RelativeL2 = CvConst.CV_RELATIVE_L2,
    }
}
