using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_segmentation_IntelligentScissorsMB_new(
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_segmentation_IntelligentScissorsMB_delete(
        IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_segmentation_IntelligentScissorsMB_setWeights(
        IntPtr obj,
        float weight_non_edge, float weight_gradient_direction, float weight_gradient_magnitude);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_segmentation_IntelligentScissorsMB_setGradientMagnitudeMaxLimit(
        IntPtr obj,
        float gradient_magnitude_threshold_max);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_segmentation_IntelligentScissorsMB_setEdgeFeatureZeroCrossingParameters(
        IntPtr obj,
        float gradient_magnitude_min_value);


    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_segmentation_IntelligentScissorsMB_setEdgeFeatureCannyParameters(
        IntPtr obj,
        double threshold1, double threshold2,
        int apertureSize, int L2gradient);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_segmentation_IntelligentScissorsMB_applyImage(
        IntPtr obj,
        IntPtr image);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_segmentation_IntelligentScissorsMB_applyImageFeatures(
        IntPtr obj,
        IntPtr non_edge,
        IntPtr gradient_direction,
        IntPtr gradient_magnitude,
        IntPtr image);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_segmentation_IntelligentScissorsMB_buildMap(
        IntPtr obj,
        Point sourcePt);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_segmentation_IntelligentScissorsMB_getContour(
        IntPtr obj,
        Point targetPt, IntPtr contour, int backward);
}
