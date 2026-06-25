using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void imgproc_LineSegmentDetector_detect_OutputArray(IntPtr obj, IntPtr image, IntPtr lines,
        IntPtr width, IntPtr prec, IntPtr nfa);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void imgproc_LineSegmentDetector_detect_vector(IntPtr obj, IntPtr image, IntPtr lines,
        IntPtr width, IntPtr prec, IntPtr nfa);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void imgproc_LineSegmentDetector_drawSegments(IntPtr obj, IntPtr image, IntPtr lines);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int imgproc_LineSegmentDetector_compareSegments(IntPtr obj, Size size,
        IntPtr lines1, IntPtr lines2, IntPtr image);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr imgproc_createLineSegmentDetector(
        int refine, double scale, double sigma_scale, double quant, double ang_th,
        double log_eps, double density_th, int n_bins);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_Ptr_LineSegmentDetector_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_Ptr_LineSegmentDetector_delete(IntPtr obj);
}
