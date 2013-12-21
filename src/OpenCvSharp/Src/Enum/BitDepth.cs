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
	/// 画像要素のビットデプス.
	/// </summary>
#else
    /// <summary>
    /// Bit Depth of image elements
    /// </summary>
#endif
	public enum BitDepth : int
	{
#if LANG_JP
		/// <summary>
		/// 符号無し 1 ビット整数 [IPL_DEPTH_1U]
		/// </summary>
#else
        /// <summary>
        /// unsigned 1-bit integers [IPL_DEPTH_1U]
        /// </summary>
#endif
		[Obsolete("", true)] U1 = CvConst.IPL_DEPTH_1U, 


#if LANG_JP
		/// <summary>
		/// 符号無し 8 ビット整数 [IPL_DEPTH_8U]
		/// </summary>
#else
        /// <summary>
        /// unsigned 8-bit integers [IPL_DEPTH_8U]
        /// </summary>
#endif
		U8 = CvConst.IPL_DEPTH_8U,


#if LANG_JP
		/// <summary>
		/// 符号あり 8 ビット整数 [IPL_DEPTH_8S]
		/// </summary>
#else
        /// <summary>
        /// signed 8-bit integers [IPL_DEPTH_8S]
        /// </summary>
#endif
		S8 = CvConst.IPL_DEPTH_8S,


#if LANG_JP
		/// <summary>
		/// 符号無し 16 ビット整数 [IPL_DEPTH_16U]
		/// </summary>
#else
        /// <summary>
        /// unsigned 16-bit integers [IPL_DEPTH_16U]
        /// </summary>
#endif
		U16 = CvConst.IPL_DEPTH_16U,


#if LANG_JP
		/// <summary>
		/// 符号あり 16 ビット整数 [IPL_DEPTH_16S]
		/// </summary>
#else
        /// <summary>
        /// signed 16-bit integers [IPL_DEPTH_16S]
        /// </summary>
#endif
		S16 = CvConst.IPL_DEPTH_16S,


#if LANG_JP
		/// <summary>
		/// 符号あり 32 ビット整数 [IPL_DEPTH_32S]
		/// </summary>
#else
        /// <summary>
        /// signed 32-bit integers [IPL_DEPTH_32S]
        /// </summary>
#endif
		S32 = CvConst.IPL_DEPTH_32S,


#if LANG_JP
		/// <summary>
		/// 単精度浮動小数点数 [IPL_DEPTH_32F]
		/// </summary>
#else
        /// <summary>
        /// single precision floating-point numbers [IPL_DEPTH_32F]
        /// </summary>
#endif
		F32 = CvConst.IPL_DEPTH_32F,


#if LANG_JP
		/// <summary>
		/// 倍精度浮動小数点数 [IPL_DEPTH_64F]
		/// </summary>
#else
        /// <summary>
        /// double precision floating-point numbers [IPL_DEPTH_64F]
        /// </summary>
#endif
        F64 = CvConst.IPL_DEPTH_64F,
    }
}
