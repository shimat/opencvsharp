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
	/// ホモグラフィ行列を計算するための手法
	/// </summary>
#else
    /// <summary>
    /// The method used to computed homography matrix
    /// </summary>
#endif
    public enum HomographyMethod : int
    {
#if LANG_JP
        /// <summary>
        /// 全ての点のペアを利用する標準的な手法
        /// [= 0]
        /// </summary>
#else
        /// <summary>
        /// Regular method using all the point pairs
        /// [= 0]
        /// </summary>
#endif
        Zero = 0,


#if LANG_JP
        /// <summary>
        /// LMedS推定によるロバストな手法
        /// [CV_LMEDS]
        /// </summary>
#else
        /// <summary>
        /// Least-Median robust method
        /// [CV_LMEDS]
        /// </summary>
#endif
        LMedS = CvConst.CV_LMEDS,


#if LANG_JP
        /// <summary>
        /// RANSACアルゴリズムに基づくロバストな手法
        /// [CV_RANSAC]
        /// </summary>
#else
        /// <summary>
        /// RANSAC-based robust method
        /// [CV_RANSAC]
        /// </summary>
#endif
        Ransac = CvConst.CV_RANSAC,
    }
}
