using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stereo_stereoRectify_InputArray(
        IntPtr cameraMatrix1, IntPtr distCoeffs1,
        IntPtr cameraMatrix2, IntPtr distCoeffs2,
        Size imageSize, IntPtr R, IntPtr T,
        IntPtr R1, IntPtr R2,
        IntPtr P1, IntPtr P2,
        IntPtr Q, int flags,
        double alpha, Size newImageSize,
        out Rect validPixROI1, out Rect validPixROI2);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus stereo_stereoRectify_array(
        double* cameraMatrix1,
        double[] distCoeffs1, int dc1Size,
        double* cameraMatrix2,
        double[] distCoeffs2, int dc2Size,
        Size imageSize,
        double* R, double[] T,
        double* R1, double* R2, double* P1, double* P2,
        double* Q, int flags, double alpha, Size newImageSize,
        out Rect validPixROI1, out Rect validPixROI2);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stereo_stereoRectifyUncalibrated_InputArray(
        IntPtr points1, IntPtr points2,
        IntPtr F, Size imgSize,
        IntPtr H1, IntPtr H2,
        double threshold,
        out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus stereo_stereoRectifyUncalibrated_array(
        Point2d[] points1, int points1Size,
        Point2d[] points2, int points2Size,
        double* F, Size imgSize,
        double* H1, double* H2,
        double threshold,
        out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stereo_rectify3Collinear_InputArray(
        IntPtr cameraMatrix1, IntPtr distCoeffs1,
        IntPtr cameraMatrix2, IntPtr distCoeffs2,
        IntPtr cameraMatrix3, IntPtr distCoeffs3,
        IntPtr[] imgpt1, int imgpt1Size,
        IntPtr[] imgpt3, int imgpt3Size,
        Size imageSize, IntPtr R12, IntPtr T12,
        IntPtr R13, IntPtr T13,
        IntPtr R1, IntPtr R2, IntPtr R3,
        IntPtr P1, IntPtr P2, IntPtr P3,
        IntPtr Q, double alpha, Size newImgSize,
        out Rect roi1, out Rect roi2, int flags,
        out float returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stereo_filterSpeckles(
        IntPtr img, double newVal, int maxSpeckleSize,
        double maxDiff, IntPtr buf);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stereo_getValidDisparityROI(
        Rect roi1, Rect roi2,
        int minDisparity, int numberOfDisparities, int SADWindowSize,
        out Rect returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stereo_validateDisparity(
        IntPtr disparity, IntPtr cost,
        int minDisparity, int numberOfDisparities, int disp12MaxDisp);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stereo_reprojectImageTo3D(
        IntPtr disparity, IntPtr _3dImage,
        IntPtr Q, int handleMissingValues, int ddepth);
}
