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
    /// cvFontQtで用いるフォントの太さフラグ
    /// </summary>
#else
    /// <summary>
    /// The operation flags for cvFontQt
    /// </summary>
#endif
    public enum FontWeight : int
    {
#if LANG_JP
        /// <summary>
        /// QFont::Light
        /// </summary>
#else
        /// <summary>
        /// QFont::Light
        /// </summary>
#endif
        Light = CvConst.CV_FONT_LIGHT,


#if LANG_JP
        /// <summary>
        /// QFont::Normal
        /// </summary>
#else
        /// <summary>
        /// QFont::Normal
        /// </summary>
#endif
        Normal = CvConst.CV_FONT_NORMAL,


#if LANG_JP
        /// <summary>
        /// QFont::DemiBold
        /// </summary>
#else
        /// <summary>
        /// QFont::DemiBold
        /// </summary>
#endif
        DemiBold = CvConst.CV_FONT_DEMIBOLD,


#if LANG_JP
        /// <summary>
        /// QFont::Bold
        /// </summary>
#else
        /// <summary>
        /// QFont::Bold
        /// </summary>
#endif
        Bold = CvConst.CV_FONT_BOLD,


#if LANG_JP
        /// <summary>
        /// QFont::Black
        /// </summary>
#else
        /// <summary>
        /// QFont::Black
        /// </summary>
#endif
        Black = CvConst.CV_FONT_BLACK,
    }
}
