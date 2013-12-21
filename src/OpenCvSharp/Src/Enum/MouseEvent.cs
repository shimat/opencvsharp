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
    /// マウスイベント
    /// </summary>
#else
    /// <summary>
    /// Mosue events
    /// </summary>
#endif
    [Flags]
    public enum MouseEvent : int
    {
        /// <summary>
        /// [CV_EVENT_MOUSEMOVE]
        /// </summary>
        MouseMove = CvConst.CV_EVENT_MOUSEMOVE,
        /// <summary>
        /// [CV_EVENT_LBUTTONDOWN]
        /// </summary>
        LButtonDown = CvConst.CV_EVENT_LBUTTONDOWN,
        /// <summary>
        /// [CV_EVENT_RBUTTONDOWN]
        /// </summary>
        RButtonDown = CvConst.CV_EVENT_RBUTTONDOWN,
        /// <summary>
        /// [CV_EVENT_MBUTTONDOWN]
        /// </summary>
        MButtonDown = CvConst.CV_EVENT_MBUTTONDOWN,
        /// <summary>
        /// [CV_EVENT_LBUTTONUP]
        /// </summary>
        LButtonUp = CvConst.CV_EVENT_LBUTTONUP,
        /// <summary>
        /// [CV_EVENT_RBUTTONUP]
        /// </summary>
        RButtonUp = CvConst.CV_EVENT_RBUTTONUP,
        /// <summary>
        /// [CV_EVENT_MBUTTONUP]
        /// </summary>
        MButtonUp = CvConst.CV_EVENT_MBUTTONUP,
        /// <summary>
        /// [CV_EVENT_LBUTTONDBLCLK]
        /// </summary>
        LButtonDoubleClick = CvConst.CV_EVENT_LBUTTONDBLCLK,
        /// <summary>
        /// [CV_EVENT_RBUTTONDBLCLK]
        /// </summary>
        RButtonDoubleClick = CvConst.CV_EVENT_RBUTTONDBLCLK,
        /// <summary>
        /// [CV_EVENT_MBUTTONDBLCLK]
        /// </summary>
        MButtonDoubleClick = CvConst.CV_EVENT_MBUTTONDBLCLK,

        /// <summary>
        /// [CV_EVENT_FLAG_LBUTTON]
        /// </summary>
        FlagLButton = CvConst.CV_EVENT_FLAG_LBUTTON,
        /// <summary>
        /// [CV_EVENT_FLAG_RBUTTON]
        /// </summary>
        FlagRButton = CvConst.CV_EVENT_FLAG_RBUTTON,
        /// <summary>
        /// [CV_EVENT_FLAG_MBUTTON]
        /// </summary>
        FlagMButton = CvConst.CV_EVENT_FLAG_MBUTTON,
        /// <summary>
        /// [CV_EVENT_FLAG_CTRLKEY]
        /// </summary>
        FlagCtrlKey = CvConst.CV_EVENT_FLAG_CTRLKEY,
        /// <summary>
        /// [CV_EVENT_FLAG_SHIFTKEY]
        /// </summary>
        FlagShiftKey = CvConst.CV_EVENT_FLAG_SHIFTKEY,
        /// <summary>
        /// [CV_EVENT_FLAG_ALTKEY]
        /// </summary>
        FlagAltKey = CvConst.CV_EVENT_FLAG_ALTKEY,
    }
}
