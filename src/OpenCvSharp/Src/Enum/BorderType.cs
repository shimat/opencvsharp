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
	/// cvCopyMakeBorderで指定する, 境界線のタイプ
	/// </summary>
#else
    /// <summary>
    /// Type of the border to create around the copied source image rectangle
    /// </summary>
#endif
    public enum BorderType : int
    {
#if LANG_JP
		/// <summary>
		/// 境界はこの関数の最後のパラメータとして渡された定数 value で埋められる. 
        /// [IPL_BORDER_CONSTANT]
		/// </summary>
#else
        /// <summary>
        /// Border is filled with the fixed value, passed as last parameter of the function.
        /// [IPL_BORDER_CONSTANT]
        /// </summary>
#endif
        Constant = CvConst.IPL_BORDER_CONSTANT,


#if LANG_JP
		/// <summary>
		/// 画像の最も上/下の行と最も左/右の列（画像領域の一番外側の値）を用いて境界線を生成する．
        /// [IPL_BORDER_REPLICATE]
		/// </summary>
#else
        /// <summary>
        /// The pixels from the top and bottom rows, the left-most and right-most columns are replicated to fill the border.
        /// [IPL_BORDER_REPLICATE]
        /// </summary>
#endif
        Replicate = CvConst.IPL_BORDER_REPLICATE,


#if LANG_JP
		/// <summary>
		/// 
        /// [IPL_BORDER_REFLECT]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [IPL_BORDER_REFLECT]
        /// </summary>
#endif
        Reflict = CvConst.IPL_BORDER_REFLECT,


#if LANG_JP
		/// <summary>
		/// 
        /// [IPL_BORDER_REFLECT_101]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [IPL_BORDER_REFLECT_101]
        /// </summary>
#endif
        Reflict101 = CvConst.IPL_BORDER_REFLECT_101,


#if LANG_JP
		/// <summary>
		/// 
        /// [IPL_BORDER_WRAP]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [IPL_BORDER_WRAP]
        /// </summary>
#endif
        Wrap = CvConst.IPL_BORDER_WRAP,


#if LANG_JP
		/// <summary>
		/// 
        /// [BORDER_DEFAULT]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [BORDER_DEFAULT]
        /// </summary>
#endif
        Default = CvConst.IPL_BORDER_DEFAULT,
    }
}
