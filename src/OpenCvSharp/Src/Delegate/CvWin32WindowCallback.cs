/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// WndProc
    /// </summary>
    /// <param name="hwnd">メッセージのウィンドウ ハンドル</param>
    /// <param name="msg">メッセージの ID 番号</param>
    /// <param name="wParam">メッセージの WParam フィールド</param>
    /// <param name="lParam">メッセージの LParam フィールド</param>
    /// <param name="result">メッセージの処理に応答して Windows に返される値</param>
#else
    /// <summary>
    /// WndProc
    /// </summary>
    /// <param name="hwnd"></param>
    /// <param name="msg">Windows message ID</param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <param name="result"></param>
#endif
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CvWin32WindowCallback(IntPtr hwnd, [MarshalAs(UnmanagedType.U4)]int msg, IntPtr wParam, IntPtr lParam, IntPtr result);

}
