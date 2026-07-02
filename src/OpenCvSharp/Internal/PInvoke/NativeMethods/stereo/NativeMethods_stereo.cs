using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stereo_stereoRectify_InputArray(
        in InputArrayProxy cameraMatrix1, in InputArrayProxy distCoeffs1,
        in InputArrayProxy cameraMatrix2, in InputArrayProxy distCoeffs2,
        Size imageSize, in InputArrayProxy R, in InputArrayProxy T,
        in OutputArrayProxy R1, in OutputArrayProxy R2,
        in OutputArrayProxy P1, in OutputArrayProxy P2,
        in OutputArrayProxy Q, int flags,
        double alpha, Size newImageSize,
        out Rect validPixROI1, out Rect validPixROI2);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus stereo_stereoRectify_array(
        double* cameraMatrix1,
        double[] distCoeffs1, int dc1Size,
        double* cameraMatrix2,
        double[] distCoeffs2, int dc2Size,
        Size imageSize,
        double* R, double[] T,
        double* R1, double* R2, double* P1, double* P2,
        double* Q, int flags, double alpha, Size newImageSize,
        out Rect validPixROI1, out Rect validPixROI2);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stereo_stereoRectifyUncalibrated_InputArray(
        in InputArrayProxy points1, in InputArrayProxy points2,
        in InputArrayProxy F, Size imgSize,
        in OutputArrayProxy H1, in OutputArrayProxy H2,
        double threshold,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static unsafe partial ExceptionStatus stereo_stereoRectifyUncalibrated_array(
        Point2d[] points1, int points1Size,
        Point2d[] points2, int points2Size,
        double* F, Size imgSize,
        double* H1, double* H2,
        double threshold,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stereo_rectify3Collinear_InputArray(
        in InputArrayProxy cameraMatrix1, in InputArrayProxy distCoeffs1,
        in InputArrayProxy cameraMatrix2, in InputArrayProxy distCoeffs2,
        in InputArrayProxy cameraMatrix3, in InputArrayProxy distCoeffs3,
        IntPtr[] imgpt1, int imgpt1Size,
        IntPtr[] imgpt3, int imgpt3Size,
        Size imageSize, in InputArrayProxy R12, in InputArrayProxy T12,
        in InputArrayProxy R13, in InputArrayProxy T13,
        in OutputArrayProxy R1, in OutputArrayProxy R2, in OutputArrayProxy R3,
        in OutputArrayProxy P1, in OutputArrayProxy P2, in OutputArrayProxy P3,
        in OutputArrayProxy Q, double alpha, Size newImgSize,
        out Rect roi1, out Rect roi2, int flags,
        out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stereo_filterSpeckles(
        in InputOutputArrayProxy img, double newVal, int maxSpeckleSize,
        double maxDiff, in InputOutputArrayProxy buf);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_getValidDisparityROI(
        Rect roi1, Rect roi2,
        int minDisparity, int numberOfDisparities, int SADWindowSize,
        out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stereo_validateDisparity(
        in InputOutputArrayProxy disparity, in InputArrayProxy cost,
        int minDisparity, int numberOfDisparities, int disp12MaxDisp);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stereo_reprojectImageTo3D(
        in InputArrayProxy disparity, in OutputArrayProxy _3dImage,
        in InputArrayProxy Q, int handleMissingValues, int ddepth);
}
