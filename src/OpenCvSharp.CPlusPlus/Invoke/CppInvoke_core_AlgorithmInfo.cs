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
    /// 
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static partial class CppInvoke
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_AlgorithmInfo_paramHelp(IntPtr obj, string name, StringBuilder dst,
                                                              int dstLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_AlgorithmInfo_paramType(IntPtr obj, string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_AlgorithmInfo_name(IntPtr obj, StringBuilder dst, int dstLength);

    }
}