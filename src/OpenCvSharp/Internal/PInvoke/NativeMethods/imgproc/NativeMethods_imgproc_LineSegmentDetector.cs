using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void imgproc_LineSegmentDetector_detect_OutputArray(IntPtr obj, IntPtr image, IntPtr lines,
        IntPtr width, IntPtr prec, IntPtr nfa);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void imgproc_LineSegmentDetector_detect_vector(IntPtr obj, IntPtr image, IntPtr lines,
        IntPtr width, IntPtr prec, IntPtr nfa);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void imgproc_LineSegmentDetector_drawSegments(IntPtr obj, IntPtr image, IntPtr lines);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int imgproc_LineSegmentDetector_compareSegments(IntPtr obj, Size size,
        IntPtr lines1, IntPtr lines2, IntPtr image);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr imgproc_createLineSegmentDetector(
        int refine, double scale, double sigma_scale, double quant, double ang_th,
        double log_eps, double density_th, int n_bins);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void imgproc_Ptr_LineSegmentDetector_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr imgproc_Ptr_LineSegmentDetector_get(IntPtr obj);
}
