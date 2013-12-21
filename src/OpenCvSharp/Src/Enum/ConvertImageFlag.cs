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
	/// cvConvertImageの処理フラグ
	/// </summary>
#else
    /// <summary>
    /// cvConvertImage operation flags
    /// </summary>
#endif
	public enum ConvertImageFlag : int
	{
#if LANG_JP
		/// <summary>
		/// 画像を垂直方向に反転 [CV_CVTIMG_FLIP]
		/// </summary>
#else
        /// <summary>
        /// flip the image vertically [CV_CVTIMG_FLIP]
        /// </summary>
#endif
        Flip = CvConst.CV_CVTIMG_FLIP,
#if LANG_JP
		/// <summary>
		/// 赤と青のチャンネルを入れ替える [CV_CVTIMG_SWAP_RB]
		/// </summary>
#else
        /// <summary>
        /// swap red and blue channels [CV_CVTIMG_SWAP_RB]
        /// </summary>
#endif
        SwapRB = CvConst.CV_CVTIMG_SWAP_RB,
	};
}
