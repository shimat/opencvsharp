/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Utilities;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// P/Invoke methods of OpenCV 2.x C++ interface
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static partial class CppInvoke
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_namedWindow([MarshalAs(UnmanagedType.LPStr)] string winname, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_imshow([MarshalAs(UnmanagedType.LPStr)] string winname, IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_imread(string filename, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_imwrite([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr img, [In] int[] @params, int paramsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_imdecode(IntPtr buf, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_imencode([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr img, out IntPtr buf, [In] int[] @params, int paramsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_waitKey(int delay);
    }
}