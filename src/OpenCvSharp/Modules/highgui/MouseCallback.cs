﻿using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cvSetMouseCallbackで指定する、HighGUIウィンドウでマウスイベントが発生したときのイベント処理を行うデリゲート
    /// </summary>
    /// <param name="event">MouseEventTypes であらわされるフラグのうちのひとつ</param>
    /// <param name="x">画像内でのマウスポインタのx座標</param>
    /// <param name="y">画像内でのマウスポインタのy座標</param>
    /// <param name="flags">MouseEventFlags であらわされるフラグの論理和</param>
    /// <param name="userData"></param>
#else
    /// <summary>
    /// Delegate to be called every time mouse event occurs in the specified window.
    /// </summary>
    /// <param name="event">one of MouseEventTypes</param>
    /// <param name="x">x-coordinates of mouse pointer in image coordinates</param>
    /// <param name="y">y-coordinates of mouse pointer in image coordinates</param>
    /// <param name="flags">a combination of MouseEventFlags</param>
    /// <param name="userData"></param>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MouseCallback(
        MouseEventTypes @event,
        int x,
        int y,
        MouseEventFlags flags,
        IntPtr userData);
}
