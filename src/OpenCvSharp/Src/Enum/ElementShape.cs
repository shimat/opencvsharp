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
	/// 構造要素の形状
	/// </summary>
#else
    /// <summary>
    /// Shape of the structuring element
    /// </summary>
#endif
    public enum ElementShape : int
    {
#if LANG_JP
		/// <summary>
		/// 矩形 
        /// [CV_SHAPE_RECT]
		/// </summary>
#else
        /// <summary>
        /// A rectangular element
        /// [CV_SHAPE_RECT]
        /// </summary>
#endif
        Rect = CvConst.CV_SHAPE_RECT,


#if LANG_JP
		/// <summary>
		/// 十字型 
        /// [CV_SHAPE_CROSS]
		/// </summary>
#else
        /// <summary>
        /// A cross-shaped element
        /// [CV_SHAPE_CROSS]
        /// </summary>
#endif
        Cross = CvConst.CV_SHAPE_CROSS,


#if LANG_JP
		/// <summary>
		/// 楕円 
        /// [CV_SHAPE_ELLIPSE]
		/// </summary>
#else
        /// <summary>
        /// An elliptic element
        /// [CV_SHAPE_ELLIPSE]
        /// </summary>
#endif
        Ellipse = CvConst.CV_SHAPE_ELLIPSE,


#if LANG_JP
		/// <summary>
		/// ユーザ定義の形状 
        /// [CV_SHAPE_CUSTOM]
		/// </summary>
#else
        /// <summary>
        /// A user-defined element. In this case the parameter values specifies the mask, that is, which neighbors of the pixel must be considered. 
        /// [CV_SHAPE_CUSTOM]
        /// </summary>
#endif
        Custom = CvConst.CV_SHAPE_CUSTOM,
    }
}
