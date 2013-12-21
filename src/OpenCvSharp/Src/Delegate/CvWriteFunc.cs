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
    /// 
    /// </summary>
    /// <param name="storage"></param>
    /// <param name="name"></param>
    /// <param name="struct_ptr"></param>
    /// <returns></returns>
#else
    /// <summary>
    /// 
    /// </summary>
    /// <param name="storage"></param>
    /// <param name="name"></param>
    /// <param name="struct_ptr"></param>
    /// <returns></returns>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int CvWriteFunc(IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr struct_ptr/*, CvAttrList attributes*/);

}
