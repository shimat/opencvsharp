﻿using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_Algorithm_write(IntPtr obj, IntPtr fs);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_Algorithm_read(IntPtr obj, IntPtr fn);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_Algorithm_empty(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = true, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus core_Algorithm_save(IntPtr obj, string filename);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_Algorithm_getDefaultName(IntPtr obj, IntPtr buf);
    }
}