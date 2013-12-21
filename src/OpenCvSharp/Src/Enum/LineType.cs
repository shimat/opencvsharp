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
	/// 線分の種類
	/// </summary>
#else
    /// <summary>
    /// Type of the line
    /// </summary>
#endif
    public enum LineType : int
    {
#if LANG_JP
		/// <summary>
		/// 8連結による線分
        /// [= 8]
		/// </summary>
#else
        /// <summary>
        /// 8-connected line.
        /// [= 8]
        /// </summary>
#endif
        Link8 = 8,


#if LANG_JP
		/// <summary>
		/// 4連結による線分
        /// [= 4]
		/// </summary>
#else
        /// <summary>
        /// 4-connected line.
        /// [= 4]
        /// </summary>
#endif
        Link4 = 4,


#if LANG_JP
		/// <summary>
		/// アンチエイリアスされた線分. ガウシアン（Gaussian）フィルタを用いて描かれる．
        /// [CV_AA]
		/// </summary>
#else
        /// <summary>
        /// Antialiased line. 
        /// [CV_AA]
        /// </summary>
#endif
        AntiAlias = CvConst.CV_AA,
    }
}
