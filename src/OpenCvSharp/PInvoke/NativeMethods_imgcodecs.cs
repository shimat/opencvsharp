using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr imgcodecs_imread(string filename, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int imgcodecs_imreadmulti([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr mats, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int imgcodecs_imwrite([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr img, [In] int[] @params, int paramsLength);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgcodecs_imdecode_Mat(IntPtr buf, int flags);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgcodecs_imdecode_vector(byte[] buf, IntPtr bufLength, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgcodecs_imdecode_InputArray(IntPtr buf, int flags);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int imgcodecs_imencode_vector([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr img, IntPtr buf, [In] int[] @params, int paramsLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void imgcodecs_cvConvertImage_CvArr(IntPtr src, IntPtr dst, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void imgcodecs_cvConvertImage_Mat(IntPtr src, IntPtr dst, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int imgcodecs_cvHaveImageReader([MarshalAs(UnmanagedType.LPStr)] string fileName);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int imgcodecs_cvHaveImageWriter([MarshalAs(UnmanagedType.LPStr)] string fileName);

    }
}