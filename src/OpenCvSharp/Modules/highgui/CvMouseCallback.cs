﻿using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cvSetMouseCallbackで指定する、HighGUIウィンドウでマウスイベントが発生したときのイベント処理を行うデリゲート
    /// </summary>
    /// <param name="event">CV_EVENT_ であらわされるフラグのうちのひとつ</param>
    /// <param name="x">画像内でのマウスポインタのx座標</param>
    /// <param name="y">画像内でのマウスポインタのy座標</param>
    /// <param name="flags">CV_EVENT_FLAGであらわされるフラグの論理和</param>
    /// <param name="userdata"></param>
#else
    /// <summary>
    /// Delegate to be called every time mouse event occurs in the specified window.
    /// </summary>
    /// <param name="event">one of CV_EVENT_</param>
    /// <param name="x">x-coordinates of mouse pointer in image coordinates</param>
    /// <param name="y">y-coordinates of mouse pointer in image coordinates</param>
    /// <param name="flags">a combination of CV_EVENT_FLAG</param>
    /// <param name="userdata"></param>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CvMouseCallback(
        MouseEvent @event,
        int x,
        int y,
        MouseEvent flags,
        IntPtr userdata);
}
