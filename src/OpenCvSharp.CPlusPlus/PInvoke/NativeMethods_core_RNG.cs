/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    internal static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_new1")]
        public static extern ulong core_RNG_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_new2")]
        public static extern ulong core_RNG_new(ulong state);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint core_RNG_next(ulong state);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte core_RNG_operator_uchar(ulong state);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte core_RNG_operator_schar(ulong state);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort core_RNG_operator_ushort(ulong state);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern short core_RNG_operator_short(ulong state);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint core_RNG_operator_uint(ulong state);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_operatorThis1")]
        public static extern uint core_RNG_operatorThis(ulong state, uint n);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_operatorThis2")]
        public static extern uint core_RNG_operatorThis(ulong state);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_RNG_operator_int(ulong state);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float core_RNG_operator_float(ulong state);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_RNG_operator_double(ulong state);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_uniform_int")]
        public static extern int core_RNG_uniform(ulong state, int a, int b);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_uniform_float")]
        public static extern float core_RNG_uniform(ulong state, float a, float b);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_uniform_double")]
        public static extern double core_RNG_uniform(ulong state, double a, double b);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_RNG_fill(ulong state, IntPtr mat, int distType, IntPtr a, IntPtr b, int saturateRange);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_RNG_gaussian(ulong state, double sigma);
        
    }
}