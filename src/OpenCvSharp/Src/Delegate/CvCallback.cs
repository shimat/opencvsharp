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
    /// 読み込みコールバック関数
    /// </summary>
    /// <param name="index"></param>
    /// <param name="buffer"></param>
    /// <param name="user_data"></param>
    /// <returns></returns>
#else
    /// <summary>
    /// Read callback function
    /// </summary>
    /// <param name="index"></param>
    /// <param name="buffer"></param>
    /// <param name="user_data"></param>
    /// <returns></returns>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int CvCallback(int index, IntPtr buffer, IntPtr user_data);

}
