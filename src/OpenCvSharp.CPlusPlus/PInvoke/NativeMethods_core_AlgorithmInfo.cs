/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    internal static partial class NativeMethods
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