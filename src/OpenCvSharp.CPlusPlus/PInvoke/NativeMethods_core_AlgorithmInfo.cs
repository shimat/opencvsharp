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
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void core_AlgorithmInfo_paramHelp(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, StringBuilder dst,int dstLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int core_AlgorithmInfo_paramType(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void core_AlgorithmInfo_name(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] StringBuilder dst, int dstLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_AlgorithmInfo_getParams(
            IntPtr obj, IntPtr names);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_AlgorithmInfo_get(
            IntPtr obj, IntPtr algo,
            [MarshalAs(UnmanagedType.LPStr)] string name, int argType, IntPtr value);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_AlgorithmInfo_getInt(
            IntPtr obj, IntPtr algo,
            [MarshalAs(UnmanagedType.LPStr)] string name, int argType, ref int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_AlgorithmInfo_getDouble(
            IntPtr obj, IntPtr algo,
            [MarshalAs(UnmanagedType.LPStr)] string name, int argType, ref double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_AlgorithmInfo_getBool(
            IntPtr obj, IntPtr algo,
            [MarshalAs(UnmanagedType.LPStr)] string name, int argType, ref int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_AlgorithmInfo_getString(
            IntPtr obj, IntPtr algo,
            [MarshalAs(UnmanagedType.LPStr)] string name, int argType,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder value, int valueLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_AlgorithmInfo_getMat(
            IntPtr obj, IntPtr algo,
            [MarshalAs(UnmanagedType.LPStr)] string name, int argType, IntPtr value);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_AlgorithmInfo_setInt(
            IntPtr obj, IntPtr algo,
            [MarshalAs(UnmanagedType.LPStr)] string name, int argType, int value, int force);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_AlgorithmInfo_setDouble(
            IntPtr obj, IntPtr algo,
            [MarshalAs(UnmanagedType.LPStr)] string name, int argType, double value, int force);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_AlgorithmInfo_setBool(
            IntPtr obj, IntPtr algo,
            [MarshalAs(UnmanagedType.LPStr)] string name, int argType, int value, int force);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_AlgorithmInfo_setString(
            IntPtr obj, IntPtr algo,
            [MarshalAs(UnmanagedType.LPStr)] string name, int argType,
            [MarshalAs(UnmanagedType.LPStr)] string value, int force);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_AlgorithmInfo_setMat(
            IntPtr obj, IntPtr algo,
            [MarshalAs(UnmanagedType.LPStr)] string name, int argType, IntPtr value, int force);
    }
}