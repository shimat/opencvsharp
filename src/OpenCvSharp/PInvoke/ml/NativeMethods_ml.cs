using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // StatModel

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvStatModel_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvStatModel_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvStatModel_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvStatModel_save(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvStatModel_load(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvStatModel_write(IntPtr obj, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvStatModel_read(IntPtr obj, IntPtr storage, IntPtr node);
    }
}