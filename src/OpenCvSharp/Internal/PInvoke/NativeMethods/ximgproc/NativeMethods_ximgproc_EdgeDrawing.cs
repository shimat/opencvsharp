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
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_Ptr_EdgeDrawing_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_Ptr_EdgeDrawing_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_createEdgeDrawing(out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeDrawing_detectEdges(IntPtr obj, IntPtr src);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeDrawing_getEdgeImage(IntPtr obj, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeDrawing_getGradientImage(IntPtr obj, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeDrawing_getSegments(IntPtr obj, IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeDrawing_getSegmentIndicesOfLines(IntPtr obj, IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeDrawing_detectLines(IntPtr obj, IntPtr lines);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeDrawing_detectLines_vector(IntPtr obj, IntPtr lines);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeDrawing_detectEllipses(IntPtr obj, IntPtr ellipses);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeDrawing_detectEllipses_vector(IntPtr obj, IntPtr ellipses);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeDrawing_Params_default(out CvEdgeDrawingParams returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeDrawing_getParams(IntPtr obj, out CvEdgeDrawingParams returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeDrawing_setParams(IntPtr obj, ref CvEdgeDrawingParams parameters);
}
