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
    /// ボタン状態が変更される度に呼び出されるdelegate
    /// </summary>
    /// <param name="state"></param>
    /// <param name="userdata"></param>
    /// <returns></returns>
#else
    /// <summary>
    /// Pointer to the function to be called every time the button changed its state.
    /// </summary>
    /// <param name="state"></param>
    /// <param name="userdata"></param>
    /// <returns></returns>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CvButtonCallback(int state, object userdata);



    /// <summary>
    /// Pointer to the function to be called every time the button changed its state.
    /// </summary>
    /// <param name="state"></param>
    /// <param name="userdata"></param>
    /// <returns></returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void CvButtonCallbackNative(int state, IntPtr userdata);
}
