using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // imread

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true,
             EntryPoint = "imgcodecs_imread")]
        public static extern ExceptionStatus imgcodecs_imread_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string fileName, int flags, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true,
             EntryPoint = "imgcodecs_imread")]
        public static extern ExceptionStatus imgcodecs_imread_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string fileName, int flags, out IntPtr returnValue);

        [Pure]
        public static ExceptionStatus imgcodecs_imread(string fileName, int flags, out IntPtr returnValue)
        {
            if (IsWindows())
                return imgcodecs_imread_Windows(fileName, flags, out returnValue);
            return imgcodecs_imread_NotWindows(fileName, flags, out returnValue);
        }

        // imreadmulti

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true,
             EntryPoint = "imgcodecs_imreadmulti")]
        public static extern ExceptionStatus imgcodecs_imreadmulti_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string fileName, IntPtr mats, int flags, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true,
             EntryPoint = "imgcodecs_imreadmulti")]
        public static extern ExceptionStatus imgcodecs_imreadmulti_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string fileName, IntPtr mats, int flags, out int returnValue);

        [Pure]
        public static ExceptionStatus imgcodecs_imreadmulti(string fileName, IntPtr mats, int flags, out int returnValue)
        {
            if (IsWindows())
                return imgcodecs_imreadmulti_Windows(fileName, mats, flags, out returnValue);
            return imgcodecs_imreadmulti_NotWindows(fileName, mats, flags, out returnValue);
        }

        // imwrite

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true,
             EntryPoint = "imgcodecs_imwrite")]
        public static extern ExceptionStatus imgcodecs_imwrite_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string fileName, IntPtr img, [In] int[] @params, int paramsLength, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true,
             EntryPoint = "imgcodecs_imwrite")]
        public static extern ExceptionStatus imgcodecs_imwrite_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string fileName, IntPtr img, [In] int[] @params, int paramsLength, out int returnValue);

        [Pure]
        public static ExceptionStatus imgcodecs_imwrite(string fileName, IntPtr img, int[] @params, int paramsLength, out int returnValue)
        {
            if (IsWindows())
                return imgcodecs_imwrite_Windows(fileName, img, @params, paramsLength, out returnValue);
            return imgcodecs_imwrite_NotWindows(fileName, img, @params, paramsLength, out returnValue);
        }

        // imwrite_multi

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true,
             EntryPoint = "imgcodecs_imwrite_multi")]
        public static extern ExceptionStatus imgcodecs_imwrite_multi_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string fileName, IntPtr img, [In] int[] @params, int paramsLength, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true,
             EntryPoint = "imgcodecs_imwrite_multi")]
        public static extern ExceptionStatus imgcodecs_imwrite_multi_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string fileName, IntPtr img, [In] int[] @params, int paramsLength, out int returnValue);

        [Pure]
        public static ExceptionStatus imgcodecs_imwrite_multi(string fileName, IntPtr img, int[] @params, int paramsLength, out int returnValue)
        {
            if (IsWindows())
                return imgcodecs_imwrite_multi_Windows(fileName, img, @params, paramsLength, out returnValue);
            return imgcodecs_imwrite_multi_NotWindows(fileName, img, @params, paramsLength, out returnValue);
        }

        // 

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_imdecode_Mat(
            IntPtr buf, int flags, out IntPtr returnValue);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_imdecode_vector(
            byte[] buf, IntPtr bufLength, int flags, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus imgcodecs_imdecode_vector(
            byte* buf, IntPtr bufLength, int flags, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_imdecode_InputArray(
            IntPtr buf, int flags, out IntPtr returnValue);

        // Do not consider that "ext" may not be ASCII characters
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_imencode_vector(
            [MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr img, IntPtr buf, [In] int[] @params, int paramsLength, out int returnValue);

        // haveImageReader

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true,
             EntryPoint = "imgcodecs_imwrite")]
        public static extern ExceptionStatus imgcodecs_haveImageReader_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string fileName, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true,
             EntryPoint = "imgcodecs_imwrite")]
        public static extern ExceptionStatus imgcodecs_haveImageReader_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string fileName, out int returnValue);

        [Pure]
        public static ExceptionStatus imgcodecs_haveImageReader(string fileName, out int returnValue)
        {
            if (IsWindows())
                return imgcodecs_haveImageReader_Windows(fileName, out returnValue);
            return imgcodecs_haveImageReader_NotWindows(fileName, out returnValue);
        }
        
        // haveImageWriter

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern ExceptionStatus imgcodecs_haveImageWriter(
            [MarshalAs(UnmanagedType.LPStr)] string fileName, out int returnValue);
    }
}