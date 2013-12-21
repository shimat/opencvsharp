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
	/// モルフォロジー演算の種類
	/// </summary>
#else
    /// <summary>
    /// Type of morphological operation
    /// </summary>
#endif
    [Flags]
    public enum MorphologyOperation : int
    {
#if LANG_JP
		/// <summary>
		/// オープニング [CV_MOP_OPEN].
		/// dst=open(src,element)=dilate(erode(src,element),element)
		/// </summary>
#else
        /// <summary>
        /// Opening 
        /// [CV_MOP_OPEN]
        /// </summary>
#endif
        Open = CvConst.CV_MOP_OPEN,


#if LANG_JP
		/// <summary>
		/// クロージング [CV_MOP_CLOSE].
		/// dst=close(src,element)=erode(dilate(src,element),element)
		/// </summary>
#else
        /// <summary>
        /// Closing
        /// [CV_MOP_CLOSE]
        /// </summary>
#endif
        Close = CvConst.CV_MOP_CLOSE,


#if LANG_JP
		/// <summary>
		/// モルフォロジー勾配（エッジ検出） [CV_MOP_GRADIENT].
		/// dst=morph_grad(src,element)=dilate(src,element)-erode(src,element)
		/// </summary>
#else
        /// <summary>
        /// Morphological gradient
        /// [CV_MOP_GRADIENT]
        /// </summary>
#endif
        Gradient = CvConst.CV_MOP_GRADIENT,


#if LANG_JP
		/// <summary>
		/// トップハット変換(top hat) [CV_MOP_TOPHAT].
		/// dst=tophat(src,element)=src-open(src,element)
		/// </summary>
#else
        /// <summary>
        /// "Top hat"
        /// [CV_MOP_TOPHAT]
        /// </summary>
#endif
        TopHat = CvConst.CV_MOP_TOPHAT,


#if LANG_JP
		/// <summary>
		/// ブラックハット変換(black hat) [CV_MOP_BLACKHAT]
		/// dst=blackhat(src,element)=close(src,element)-src
		/// </summary>
#else
        /// <summary>
        /// "Black hat"
        /// [CV_MOP_BLACKHAT]
        /// </summary>
#endif
        BlackHat = CvConst.CV_MOP_BLACKHAT,
    }
}
