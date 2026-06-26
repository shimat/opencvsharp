using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

/// <summary>
/// Blittable P/Invoke representation of <c>EdgeDrawing::Params</c>.
/// Bool fields use <c>int</c> (0/1) to match the C++ CvEdgeDrawingParams struct layout exactly.
/// This type is internal; use <c>OpenCvSharp.XImgProc.EdgeDrawingParams</c> in consumer code.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct CvEdgeDrawingParams
{
    public int    PFmode;
    public int    EdgeDetectionOperator;
    public int    GradientThresholdValue;
    public int    AnchorThresholdValue;
    public int    ScanInterval;
    public int    MinPathLength;
    public float  Sigma;
    public int    SumFlag;
    public int    NFAValidation;
    public int    MinLineLength;
    public double MaxDistanceBetweenTwoLines;
    public double LineFitErrorThreshold;
    public double MaxErrorThreshold;
}

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_EdgeDrawing_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_EdgeDrawing_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createEdgeDrawing(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_EdgeDrawing_detectEdges(OpenCvSafeHandle obj, IntPtr src);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_EdgeDrawing_getEdgeImage(OpenCvSafeHandle obj, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_EdgeDrawing_getGradientImage(OpenCvSafeHandle obj, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_EdgeDrawing_getSegments(OpenCvSafeHandle obj, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_EdgeDrawing_getSegmentIndicesOfLines(OpenCvSafeHandle obj, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_EdgeDrawing_detectLines(OpenCvSafeHandle obj, IntPtr lines);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_EdgeDrawing_detectLines_vector(OpenCvSafeHandle obj, IntPtr lines);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_EdgeDrawing_detectEllipses(OpenCvSafeHandle obj, IntPtr ellipses);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_EdgeDrawing_detectEllipses_vector(OpenCvSafeHandle obj, IntPtr ellipses);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_EdgeDrawing_Params_default(out CvEdgeDrawingParams returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_EdgeDrawing_getParams(OpenCvSafeHandle obj, out CvEdgeDrawingParams returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_EdgeDrawing_setParams(OpenCvSafeHandle obj, ref CvEdgeDrawingParams parameters);
}
