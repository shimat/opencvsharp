using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_FastLineDetector_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_FastLineDetector_get(IntPtr ptr, out IntPtr returnValue);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_FastLineDetector_detect_OutputArray(IntPtr obj, IntPtr image, IntPtr lines);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_FastLineDetector_detect_vector(IntPtr obj, IntPtr image, IntPtr lines);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_FastLineDetector_drawSegments_InputArray(IntPtr obj, IntPtr image, IntPtr lines, int draw_arrow);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_FastLineDetector_drawSegments_vector(IntPtr obj, IntPtr image, IntPtr lines, int draw_arrow);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_createFastLineDetector(
            int length_threshold, float distance_threshold, double canny_th1, double canny_th2, int canny_aperture_size,
            int do_merge, out IntPtr returnValue);
    }
}