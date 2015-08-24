using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// マウスイベント
    /// </summary>
#else
    /// <summary>
    /// Mouse events
    /// </summary>
#endif
    [Flags]
    public enum MouseEvent : int
    {
        /// <summary>
        /// [EVENT_MOUSEMOVE]
        /// </summary>
        MouseMove = 0,
        /// <summary>
        /// [EVENT_LBUTTONDOWN]
        /// </summary>
        LButtonDown = 1,
        /// <summary>
        /// [EVENT_RBUTTONDOWN]
        /// </summary>
        RButtonDown = 2,
        /// <summary>
        /// [CV_EVENT_MBUTTONDOWN]
        /// </summary>
        MButtonDown = 3,
        /// <summary>
        /// [EVENT_LBUTTONUP]
        /// </summary>
        LButtonUp = 4,
        /// <summary>
        /// [EVENT_RBUTTONUP]
        /// </summary>
        RButtonUp = 5,
        /// <summary>
        /// [EVENT_MBUTTONUP]
        /// </summary>
        MButtonUp = 6,
        /// <summary>
        /// [EVENT_LBUTTONDBLCLK]
        /// </summary>
        LButtonDoubleClick = 7,
        /// <summary>
        /// [EVENT_RBUTTONDBLCLK]
        /// </summary>
        RButtonDoubleClick = 8,
        /// <summary>
        /// [EVENT_MBUTTONDBLCLK]
        /// </summary>
        MButtonDoubleClick = 9,
        /// <summary>
        /// [EVENT_MOUSEWHEEL]
        /// </summary>
        MouseWheel = 8,
        /// <summary>
        /// [EVENT_MOUSEHWHEEL]
        /// </summary>
        MouseHWheel = 9,

        /// <summary>
        /// [EVENT_FLAG_LBUTTON]
        /// </summary>
        FlagLButton = 1,
        /// <summary>
        /// [EVENT_FLAG_RBUTTON]
        /// </summary>
        FlagRButton = 2,
        /// <summary>
        /// [EVENT_FLAG_MBUTTON]
        /// </summary>
        FlagMButton = 4,
        /// <summary>
        /// [EVENT_FLAG_CTRLKEY]
        /// </summary>
        FlagCtrlKey = 8,
        /// <summary>
        /// [EVENT_FLAG_SHIFTKEY]
        /// </summary>
        FlagShiftKey = 16,
        /// <summary>
        /// [EVENT_FLAG_ALTKEY]
        /// </summary>
        FlagAltKey = 32,
    }
}
