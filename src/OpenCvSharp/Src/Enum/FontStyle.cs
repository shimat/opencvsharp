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
    /// cvFontQtで用いるフォントスタイルのフラグ
    /// </summary>
#else
    /// <summary>
    /// The operation flags for cvFontQt
    /// </summary>
#endif
    public enum FontStyle : int
    {
#if LANG_JP
        /// <summary>
        /// QFont::StyleNormal
        /// </summary>
#else
        /// <summary>
        /// QFont::StyleNormal
        /// </summary>
#endif
        Normal = CvConst.CV_STYLE_NORMAL,


#if LANG_JP
        /// <summary>
        /// QFont::StyleItalic
        /// </summary>
#else
        /// <summary>
        /// QFont::StyleItalic
        /// </summary>
#endif
        Italic = CvConst.CV_STYLE_ITALIC,


#if LANG_JP
        /// <summary>
        /// QFont::StyleOblique
        /// </summary>
#else
        /// <summary>
        /// QFont::StyleOblique
        /// </summary>
#endif
        Oblique = CvConst.CV_STYLE_OBLIQUE,
    }
}
