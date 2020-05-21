using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_imread(
            [MarshalAs(StringUnmanagedType)] string filename, int flags, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_imreadmulti(
            [MarshalAs(StringUnmanagedType)] string filename, IntPtr mats, int flags, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_imwrite(
            [MarshalAs(StringUnmanagedType)] string filename, IntPtr img, [In] int[] @params, int paramsLength, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ExceptionStatus imgcodecs_imwrite_multi(
            [MarshalAs(StringUnmanagedType)] string filename, IntPtr img, [In] int[] @params, int paramsLength, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_imdecode_Mat(
            IntPtr buf, int flags, out IntPtr returnValue);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_imdecode_vector(
            byte[] buf, IntPtr bufLength, int flags, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_imdecode_InputArray(
            IntPtr buf, int flags, out IntPtr returnValue);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_imencode_vector(
            [MarshalAs(StringUnmanagedType)] string ext, IntPtr img, IntPtr buf, [In] int[] @params, int paramsLength, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_haveImageReader(
            [MarshalAs(StringUnmanagedType)] string fileName, out int returnValue);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_haveImageWriter(
            [MarshalAs(StringUnmanagedType)] string fileName, out int returnValue);
    }
}