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
    /// cvLoadImageで用いる読み込みフラグ ．
	/// </summary>
#else
    /// <summary>
    /// Specifies colorness and Depth of the loaded image
    /// </summary>
#endif
	[Flags]
	public enum LoadMode : int
	{
        #if LANG_JP
		/// <summary>
		/// 8 ビット，カラーまたはグレースケール [CV_LOAD_IMAGE_UNCHANGED]
		/// </summary>
#else
        /// <summary>
        /// 8 bit, color or gray [CV_LOAD_IMAGE_UNCHANGED]
        /// </summary>
#endif		
        Unchanged = CvConst.CV_LOAD_IMAGE_UNCHANGED,


#if LANG_JP
		/// <summary>
		/// 8 ビット，グレースケール [CV_LOAD_IMAGE_GRAYSCALE]
		/// </summary>
#else
        /// <summary>
        /// 8 bit, gray [CV_LOAD_IMAGE_GRAYSCALE]
        /// </summary>
#endif
		GrayScale = CvConst.CV_LOAD_IMAGE_GRAYSCALE,


#if LANG_JP
		/// <summary>
		/// AnyDepth と併用されない限り 8 ビット，カラー [CV_LOAD_IMAGE_COLOR]
		/// </summary>
#else
        /// <summary>
        /// 8 bit unless combined with AnyDepth, color [CV_LOAD_IMAGE_COLOR]
        /// </summary>
#endif
		Color = CvConst.CV_LOAD_IMAGE_COLOR,


#if LANG_JP
		/// <summary>
		///任意のデプス，グレー [CV_LOAD_IMAGE_ANYDEPTH]
		/// </summary>
#else
        /// <summary>
        /// any Depth, if specified on its own gray [CV_LOAD_IMAGE_ANYDEPTH]
        /// </summary>
#endif
		AnyDepth = CvConst.CV_LOAD_IMAGE_ANYDEPTH,


        #if LANG_JP
		/// <summary>
		/// 8 ビット，カラーまたはグレースケール [CV_LOAD_IMAGE_ANYCOLOR]. 
		/// AnyDepth と併用可能.
		/// </summary>
#else
        /// <summary>
        /// by itself equivalent to Unchanged but can be modified with AnyDepth [CV_LOAD_IMAGE_ANYCOLOR]
        /// </summary>
#endif
        AnyColor = CvConst.CV_LOAD_IMAGE_ANYCOLOR,
	};
}
