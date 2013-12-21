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
	/// cvNamedWindowで使用するウィンドウのフラグ
	/// </summary>
#else
    /// <summary>
    /// Flags for the window
    /// </summary>
#endif
    public enum WindowMode : int
    {
#if LANG_JP
		/// <summary>
		/// フラグ無し
        /// [0]
		/// </summary>
#else
        /// <summary>
        /// No flags 
        /// [0]
        /// </summary>
#endif
        None = 0,

#if LANG_JP
		/// <summary>
		/// 表示される画像サイズに合わせてウィンドウサイズが自動的に調整される 
        /// [CV_WINDOW_AUTOSIZE]
		/// </summary>
#else
        /// <summary>
        /// Window size is automatically adjusted to fit the displayed image, while user can not change the window size manually. 
        /// [CV_WINDOW_AUTOSIZE]
        /// </summary>
#endif
        AutoSize = CvConst.CV_WINDOW_AUTOSIZE,

#if LANG_JP
        /// <summary>
        /// 機能強化された新しいGUIを表示する（Qtバックエンドのみ）
        /// [CV_GUI_EXPANDED]
        /// </summary>
#else
        /// <summary>
        /// Show new enhance GUI (Qt Backend Only)
        /// [CV_GUI_EXPANDED]
        /// </summary>
#endif
        ExpandedGui = CvConst.CV_GUI_EXPANDED,

#if LANG_JP
        /// <summary>
        /// ステータスバーとツールバーのない以前のウィンドウを表示する（Qtバックエンドのみ）
        /// [CV_GUI_NORMAL]
        /// </summary>
#else
        /// <summary>
        /// Show old style window without statusbar and toolbar (Qt Backend Only)
        /// [CV_GUI_NORMAL]
        /// </summary>
#endif
        NormalGui = CvConst.CV_GUI_NORMAL,


#if LANG_JP
		/// <summary>
		/// ウィンドウサイズに合わせて 表示画像サイズが変更される
		/// </summary>
#else
        /// <summary>
        /// Image size is automatically adjusted to fit the window size
        /// </summary>
#endif
        StretchImage = AutoSize + 1,

#if LANG_JP
        /// <summary>
        /// フルスクリーン
        /// [CV_WND_PROP_FULLSCREEN]
        /// </summary>
#else
        /// <summary>
        /// Fullscreen
        /// [CV_WINDOW_FULLSCREEN]
        /// </summary>
#endif
        Fullscreen = CvConst.CV_WINDOW_FULLSCREEN,

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
