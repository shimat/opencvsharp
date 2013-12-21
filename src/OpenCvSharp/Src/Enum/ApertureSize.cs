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
	/// 拡張Sobelカーネルのサイズ
	/// </summary>
#else
    /// <summary>
    /// Size of the extended Sobel kernel
    /// </summary>
#endif
    public enum ApertureSize : int
    {
#if LANG_JP
		/// <summary>
		/// サイズ 1
		/// </summary>
#else
        /// <summary>
        /// Size 1
        /// </summary>
#endif
        Size1 = 1,


#if LANG_JP
		/// <summary>
		/// サイズ 3
		/// </summary>
#else
        /// <summary>
        /// Size 3
        /// </summary>
#endif
        Size3 = 3,


#if LANG_JP
		/// <summary>
		/// サイズ 5
		/// </summary>
#else
        /// <summary>
        /// Size 5
        /// </summary>
#endif
        Size5 = 5,


#if LANG_JP
		/// <summary>
		/// サイズ 7
		/// </summary>
#else
        /// <summary>
        /// Size 7
        /// </summary>
#endif
        Size7 = 7,


#if LANG_JP
		/// <summary>
		/// 3x3 Sobelよりも精度の良い結果が得られる3x3 のSharr のフィルタ.
        /// [CV_SCHARR]
		/// </summary>
#else
        /// <summary>
        /// Corresponds to 3x3 Scharr filter that may give more accurate results than 3x3 Sobel. 
        /// [CV_SCHARR]
        /// </summary>
#endif
        Scharr = CvConst.CV_SCHARR,
    }
}
