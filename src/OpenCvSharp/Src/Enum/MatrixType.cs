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
	/// 行列要素の種類.
	/// 形式は (S|U|F)&lt;bit_depth&gt;C&lt;number_of_channels&gt; ．
	/// </summary>
#else
    /// <summary>
    /// Type of the matrix elements.
    /// Usually it is specified in form (S|U|F)&lt;bit_depth&gt;C&lt;number_of_channels&gt;,
    /// </summary>
#endif
	public enum MatrixType : int
	{
#if LANG_JP
        /// <summary>
		/// 符号なし8ビット整数1チャンネル [CV_8UC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 8-bit unsigned integers [CV_8UC1]
        /// </summary>
#endif
        U8C1 = CvConst.CV_8UC1,
#if LANG_JP
		/// <summary>
		/// 符号なし8ビット整数2チャンネル [CV_8UC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 8-bit unsigned integers [CV_8UC2]
        /// </summary>
#endif
        U8C2 = CvConst.CV_8UC2,
#if LANG_JP
		/// <summary>
		/// 符号なし8ビット整数3チャンネル [CV_8UC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 8-bit unsigned integers [CV_8UC3]
        /// </summary>
#endif
        U8C3 = CvConst.CV_8UC3,
#if LANG_JP
		/// <summary>
		/// 符号なし8ビット整数4チャンネル [CV_8UC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 8-bit unsigned integers [CV_8UC4]
        /// </summary>
#endif
        U8C4 = CvConst.CV_8UC4,
#if LANG_JP
		/// <summary>
		/// 符号あり8ビット整数1チャンネル [CV_8SC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 8-bit signed integers [CV_8SC1]
        /// </summary>
#endif
        S8C1 = CvConst.CV_8SC1,
#if LANG_JP
		/// <summary>
		/// 符号あり8ビット整数2チャンネル [CV_8SC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 8-bit signed integers [CV_8SC2]
        /// </summary>
#endif
        S8C2 = CvConst.CV_8SC2,
#if LANG_JP
		/// <summary>
		/// 符号あり8ビット整数3チャンネル [CV_8SC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 8-bit signed integers [CV_8SC3]
        /// </summary>
#endif
        S8C3 = CvConst.CV_8SC3,
#if LANG_JP
		/// <summary>
		/// 符号あり8ビット整数4チャンネル [CV_8SC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 8-bit signed integers [CV_8SC4]
        /// </summary>
#endif
        S8C4 = CvConst.CV_8SC4,
#if LANG_JP
		/// <summary>
		/// 符号なし16ビット整数1チャンネル [CV_16UC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 16-bit unsigned integers [CV_16UC1]
        /// </summary>
#endif
        U16C1 = CvConst.CV_16UC1,
#if LANG_JP
		/// <summary>
		/// 符号なし16ビット整数2チャンネル [CV_16UC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 16-bit unsigned integers [CV_16UC2]
        /// </summary>
#endif
        U16C2 = CvConst.CV_16UC2,
#if LANG_JP
		/// <summary>
		/// 符号なし16ビット整数3チャンネル [CV_16UC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 16-bit unsigned integers [CV_16UC3]
        /// </summary>
#endif
        U16C3 = CvConst.CV_16UC3,
#if LANG_JP
		/// <summary>
		/// 符号なし16ビット整数4チャンネル [CV_16UC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 16-bit unsigned integers [CV_16UC4]
        /// </summary>
#endif
        U16C4 = CvConst.CV_16UC4,
#if LANG_JP
		/// <summary>
		/// 符号あり16ビット整数1チャンネル [CV_16SC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 16-bit signed integers [CV_16SC1]
        /// </summary>
#endif
        S16C1 = CvConst.CV_16SC1,
#if LANG_JP
		/// <summary>
		/// 符号あり16ビット整数2チャンネル [CV_16SC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 16-bit signed integers [CV_16SC2]
        /// </summary>
#endif
        S16C2 = CvConst.CV_16SC2,
#if LANG_JP
		/// <summary>
		/// 符号あり16ビット整数3チャンネル [CV_16SC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 16-bit signed integers [CV_16SC3]
        /// </summary>
#endif
        S16C3 = CvConst.CV_16SC3,
#if LANG_JP
		/// <summary>
		/// 符号あり16ビット整数4チャンネル [CV_16SC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 16-bit signed integers [CV_16SC4]
        /// </summary>
#endif
        S16C4 = CvConst.CV_16SC4,
#if LANG_JP
		/// <summary>
		/// 符号あり32ビット整数1チャンネル [CV_32SC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 32-bit signed integers [CV_32SC1]
        /// </summary>
#endif
        S32C1 = CvConst.CV_32SC1,
#if LANG_JP
		/// <summary>
		/// 符号あり32ビット整数2チャンネル [CV_32SC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 32-bit signed integers [CV_32SC2]
        /// </summary>
#endif
        S32C2 = CvConst.CV_32SC2,
#if LANG_JP
		/// <summary>
		/// 符号あり32ビット整数3チャンネル [CV_32SC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 32-bit signed integers [CV_32SC3]
        /// </summary>
#endif
        S32C3 = CvConst.CV_32SC3,
#if LANG_JP
		/// <summary>
		/// 符号あり32ビット整数4チャンネル [CV_32SC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 32-bit signed integers [CV_32SC4]
        /// </summary>
#endif
        S32C4 = CvConst.CV_32SC4,
#if LANG_JP
		/// <summary>
		/// 32ビット浮動小数点数1チャンネル [CV_32FC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 32-bit floating-point numbers [CV_32FC1]
        /// </summary>
#endif
        F32C1 = CvConst.CV_32FC1,
#if LANG_JP
		/// <summary>
		/// 32ビット浮動小数点数2チャンネル [CV_32FC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 32-bit floating-point numbers [CV_32FC2]
        /// </summary>
#endif
        F32C2 = CvConst.CV_32FC2,
#if LANG_JP
		/// <summary>
		/// 32ビット浮動小数点数3チャンネル [CV_32FC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 32-bit floating-point numbers [CV_32FC3]
        /// </summary>
#endif
        F32C3 = CvConst.CV_32FC3,
#if LANG_JP
		/// <summary>
		/// 32ビット浮動小数点数4チャンネル [CV_32FC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 32-bit floating-point numbers [CV_32FC4]
        /// </summary>
#endif
        F32C4 = CvConst.CV_32FC4,
#if LANG_JP
		/// <summary>
		/// 64ビット浮動小数点数1チャンネル [CV_64FC1]
		/// </summary>
#else
        /// <summary>
        /// 1-channel 64-bit floating-point numbers [CV_64FC1]
        /// </summary>
#endif
        F64C1 = CvConst.CV_64FC1,
#if LANG_JP
		/// <summary>
		/// 64ビット浮動小数点数2チャンネル [CV_64FC2]
		/// </summary>
#else
        /// <summary>
        /// 2-channel 64-bit floating-point numbers [CV_64FC2]
        /// </summary>
#endif
        F64C2 = CvConst.CV_64FC2,
#if LANG_JP
		/// <summary>
		/// 64ビット浮動小数点数3チャンネル [CV_64FC3]
		/// </summary>
#else
        /// <summary>
        /// 3-channel 64-bit floating-point numbers [CV_64FC3]
        /// </summary>
#endif
        F64C3 = CvConst.CV_64FC3,
#if LANG_JP
		/// <summary>
		/// 64ビット浮動小数点数4チャンネル [CV_64FC4]
		/// </summary>
#else
        /// <summary>
        /// 4-channel 64-bit floating-point numbers [CV_64FC4]
        /// </summary>
#endif
        F64C4 = CvConst.CV_64FC4,
	}
}
