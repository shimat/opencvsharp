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
	/// ウィンドウのプロパティを取得・設定する際のプロパティID(cvGetWindowProperty/cvSetWindowProperty)
	/// </summary>
#else
    /// <summary>
    /// Property identifiers for cvGetWindowProperty/cvSetWindowProperty
    /// </summary>
#endif
    public enum WindowProperty : int
    {
#if LANG_JP
        /// <summary>
        /// 通常モード
        /// [CV_WND_PROP_AUTOSIZE]
        /// </summary>
#else
        /// <summary>
        /// Normal mode
        /// [CV_WND_PROP_AUTOSIZE]
        /// </summary>
#endif
        AutoSize = CvConst.CV_WND_PROP_AUTOSIZE,


#if LANG_JP
        /// <summary>
        /// フルスクリーン
        /// [CV_WND_PROP_FULLSCREEN]
        /// </summary>
#else
        /// <summary>
        /// Fullscreen
        /// [CV_WND_PROP_FULLSCREEN]
        /// </summary>
#endif
        Fullscreen = CvConst.CV_WND_PROP_FULLSCREEN,

#if LANG_JP
        /// <summary>
        /// アスペクト比を固定しない
        /// </summary>
#else
        /// <summary>
        /// Fix aspect ratio
        /// [CV_WINDOW_FREERATIO]
        /// </summary>
#endif
        FreeRatio = CvConst.CV_WINDOW_FREERATIO,

#if LANG_JP
        /// <summary>
        /// アスペクト比を保つ
        /// </summary>
#else
        /// <summary>
        /// Respect the image ratio
        /// [CV_WINDOW_KEEPRATIO]
        /// </summary>
#endif
        KeepRatio = CvConst.CV_WINDOW_KEEPRATIO,
    }
}
