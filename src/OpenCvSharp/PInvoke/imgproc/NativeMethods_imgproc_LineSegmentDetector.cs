using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_LineSegmentDetector_detect_OutputArray(IntPtr obj, IntPtr image, IntPtr lines,
            IntPtr width, IntPtr prec, IntPtr nfa);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_LineSegmentDetector_detect_vector(IntPtr obj, IntPtr image, IntPtr lines,
            IntPtr width, IntPtr prec, IntPtr nfa);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_LineSegmentDetector_drawSegments(IntPtr obj, IntPtr image, IntPtr lines);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_LineSegmentDetector_compareSegments(IntPtr obj, Size size,
            IntPtr lines1, IntPtr lines2, IntPtr image);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgproc_createLineSegmentDetector(
            int refine, double scale, double sigma_scale, double quant, double ang_th,
            double log_eps, double density_th, int n_bins);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Ptr_LineSegmentDetector_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgproc_Ptr_LineSegmentDetector_get(IntPtr obj);
    }
}