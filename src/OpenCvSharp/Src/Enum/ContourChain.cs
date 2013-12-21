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
	/// 輪郭の近似手法
	/// </summary>
#else
    /// <summary>
    /// Approximation method (for all the modes, except CV_RETR_RUNS, which uses built-in approximation). 
    /// </summary>
#endif
    public enum ContourChain : int
    {
#if LANG_JP
		/// <summary>
        /// すべての輪郭点を完全に格納します．つまり，この手法により格納された任意の隣り合う2点は，互いに8近傍に存在します． [CV_CHAIN_CODE]
		/// </summary>
#else
        /// <summary>
        /// CV_CHAIN_CODE - output contours in the Freeman chain code. All other methods output polygons (sequences of vertices). 
        /// </summary>
#endif
        Code = CvConst.CV_CHAIN_CODE,


#if LANG_JP
		/// <summary>
        /// 最も外側の輪郭のみ抽出 [CV_CHAIN_APPROX_NONE]
		/// </summary>
#else
        /// <summary>
        /// CV_CHAIN_APPROX_NONE - translate all the points from the chain code into points; 
        /// </summary>
#endif
        ApproxNone = CvConst.CV_CHAIN_APPROX_NONE,


#if LANG_JP
		/// <summary>
        /// 水平・垂直・斜めの線分を圧縮し，それらの端点のみを残します．例えば，まっすぐな矩形の輪郭線は，4つの点にエンコードされます． [CV_CHAIN_APPROX_SIMPLE]
		/// </summary>
#else
        /// <summary>
        /// CV_CHAIN_APPROX_SIMPLE - compress horizontal, vertical, and diagonal segments, that is, the function leaves only their ending points; 
        /// </summary>
#endif
        ApproxSimple = CvConst.CV_CHAIN_APPROX_SIMPLE,


#if LANG_JP
		/// <summary>
        /// Teh-Chinチェーン近似アルゴリズムの1つを適用します． TehChin89 を参照してください． [CV_CHAIN_APPROX_TC89_L1]
		/// </summary>
#else
        /// <summary>
        /// CV_CHAIN_APPROX_TC89_L1 - apply one of the flavors of Teh-Chin chain approximation algorithm. 
        /// </summary>
#endif
        ApproxTC89L1 = CvConst.CV_CHAIN_APPROX_TC89_L1,


#if LANG_JP
		/// <summary>
        /// Teh-Chinチェーン近似アルゴリズムの1つを適用します． TehChin89 を参照してください． [CV_CHAIN_APPROX_TC89_KCOS]
		/// </summary>
#else
        /// <summary>
        /// V_CHAIN_APPROX_TC89_KCOS - apply one of the flavors of Teh-Chin chain approximation algorithm. 
        /// </summary>
#endif
        ApproxTC89KCOS = CvConst.CV_CHAIN_APPROX_TC89_KCOS,


#if LANG_JP
		/// <summary>
        /// use completely different contour retrieval algorithm via linking of horizontal segments of 1’s. Only CV_RETR_LIST retrieval mode can be used with this method. [CV_LINK_RUNS]
		/// </summary>
#else
        /// <summary>
        /// CV_LINK_RUNS - use completely different contour retrieval algorithm via linking of horizontal segments of 1’s. Only CV_RETR_LIST retrieval mode can be used with this method. 
        /// </summary>
#endif
        LinkRuns = CvConst.CV_LINK_RUNS,
    }
}
