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
	/// フォント名の識別子．現在はHershey fontsの一部のみサポートされている. 
	/// フォント名のフラグにはイタリックフラグ(Italic)を合成することができる.
	/// </summary>
#else
    /// <summary>
    /// Font name identifier. 
    /// Only a subset of Hershey fonts (http://sources.isc.org/utils/misc/hershey-font.txt) are supported now.
    /// </summary>
#endif
    [Flags]
    public enum FontFace : int
    {
#if LANG_JP
		/// <summary>
		/// 普通サイズのsans-serifフォント 
        /// [CV_FONT_HERSHEY_SIMPLEX]
		/// </summary>
#else
        /// <summary>
        /// Normal size sans-serif font
        /// [CV_FONT_HERSHEY_SIMPLEX]
        /// </summary>
#endif
        HersheySimplex = CvConst.CV_FONT_HERSHEY_SIMPLEX,


#if LANG_JP
		/// <summary>
		/// 小さいサイズのsans-serifフォント
        /// [CV_FONT_HERSHEY_PLAIN]
		/// </summary>
#else
        /// <summary>
        /// Small size sans-serif font
        /// [CV_FONT_HERSHEY_PLAIN]
        /// </summary>
#endif
        HersheyPlain = CvConst.CV_FONT_HERSHEY_PLAIN,


#if LANG_JP
		/// <summary>
		/// 普通サイズのsans-serif フォント（HersheySimplexよりも複雑）
        /// [CV_FONT_HERSHEY_DUPLEX]
		/// </summary>
#else
        /// <summary>
        /// Normal size sans-serif font (more complex than HersheySimplex)
        /// [CV_FONT_HERSHEY_DUPLEX]
        /// </summary>
#endif
        HersheyDuplex = CvConst.CV_FONT_HERSHEY_DUPLEX,


#if LANG_JP
		/// <summary>
		/// 普通サイズのserif フォント 
        /// [CV_FONT_HERSHEY_COMPLEX]
		/// </summary>
#else
        /// <summary>
        /// Normal size serif font
        /// [CV_FONT_HERSHEY_COMPLEX]
        /// </summary>
#endif
        HersheyComplex = CvConst.CV_FONT_HERSHEY_COMPLEX,


#if LANG_JP
		/// <summary>
		/// 普通サイズのserif フォント（HersheyComplexよりも複雑）
        /// [CV_FONT_HERSHEY_TRIPLEX]
		/// </summary>
#else
        /// <summary>
        /// Normal size serif font (more complex than HersheyComplex)
        /// [CV_FONT_HERSHEY_TRIPLEX]
        /// </summary>
#endif
        HersheyTriplex = CvConst.CV_FONT_HERSHEY_TRIPLEX,


#if LANG_JP
		/// <summary>
		/// HersheyComplexの小さいバージョン 
        /// [CV_FONT_HERSHEY_COMPLEX_SMALL]
		/// </summary>
#else
        /// <summary>
        /// Smaller version of HersheyComplex
        /// [CV_FONT_HERSHEY_COMPLEX_SMALL]
        /// </summary>
#endif
        HersheyComplexSmall = CvConst.CV_FONT_HERSHEY_COMPLEX_SMALL,


#if LANG_JP
		/// <summary>
		/// 手書きスタイルのフォント 
        /// [CV_FONT_HERSHEY_SCRIPT_SIMPLEX]
		/// </summary>
#else
        /// <summary>
        /// Hand-writing style font
        /// [CV_FONT_HERSHEY_SCRIPT_SIMPLEX]
        /// </summary>
#endif
        HersheyScriptSimplex = CvConst.CV_FONT_HERSHEY_SCRIPT_SIMPLEX,


#if LANG_JP
		/// <summary>
		/// HersheyScriptSimplexの複雑なバージョン 
        /// [CV_FONT_HERSHEY_SCRIPT_COMPLEX]
		/// </summary>
#else
        /// <summary>
        /// More complex variant of HersheyScriptSimplex
        /// [CV_FONT_HERSHEY_SCRIPT_COMPLEX]
        /// </summary>
#endif
        HersheyScriptComplex = CvConst.CV_FONT_HERSHEY_SCRIPT_COMPLEX,


#if LANG_JP
		/// <summary>
		/// イタリックフラグ 
        /// [CV_FONT_ITALIC]
		/// </summary>
#else
        /// <summary>
        /// Means italic or oblique font. 
        /// [CV_FONT_ITALIC]
        /// </summary>
#endif
        Italic = CvConst.CV_FONT_ITALIC,


#if LANG_JP
		/// <summary>
		/// 
        /// [CV_FONT_VECTOR0]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_FONT_VECTOR0]
        /// </summary>
#endif
        Vector0 = CvConst.CV_FONT_VECTOR0,
    }
}
