using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // ReSharper disable InconsistentNaming

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_drawKeypoints(
        IntPtr image, KeyPoint[] keypoints, int keypointsLength,
        IntPtr outImage, Scalar color, int flags);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_drawMatches(
        IntPtr img1, KeyPoint[] keypoints1, int keypoints1Length,
        IntPtr img2, KeyPoint[] keypoints2, int keypoints2Length,
        DMatch[] matches1to2, int matches1to2Length, IntPtr outImg,
        Scalar matchColor, Scalar singlePointColor,
        byte[]? matchesMask, int matchesMaskLength, int flags);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_drawMatchesKnn(
        IntPtr img1, KeyPoint[] keypoints1, int keypoints1Length,
        IntPtr img2, KeyPoint[] keypoints2, int keypoints2Length,
        IntPtr[] matches1to2, int matches1to2Size1, int[] matches1to2Size2,
        IntPtr outImg, Scalar matchColor, Scalar singlePointColor,
        IntPtr[]? matchesMask, int matchesMaskSize1, int[]? matchesMaskSize2, int flags);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_evaluateFeatureDetector(
        IntPtr img1, IntPtr img2, IntPtr H1to2,
        IntPtr keypoints1, IntPtr keypoints2,
        out float repeatability, out int correspCount);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_computeRecallPrecisionCurve(
        IntPtr[] matches1to2, int matches1to2Size1, int[] matches1to2Size2,
        IntPtr[] correctMatches1to2Mask, int correctMatches1to2MaskSize1, int[] correctMatches1to2MaskSize2,
        IntPtr recallPrecisionCurve);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_getRecall(
        Point2f[] recallPrecisionCurve, int recallPrecisionCurveSize, float l_precision, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_getNearestPoint(
        Point2f[] recallPrecisionCurve, int recallPrecisionCurveSize, float l_precision, out int returnValue);

    #region KeyPointsFilter

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KeyPointsFilter_runByImageBorder(
        IntPtr keypoints, Size imageSize, int borderSize);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KeyPointsFilter_runByKeypointSize(
        IntPtr keypoints, float minSize, float maxSize);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KeyPointsFilter_runByPixelsMask(
        IntPtr keypoints, IntPtr mask);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KeyPointsFilter_removeDuplicated(
        IntPtr keypoints);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KeyPointsFilter_removeDuplicatedSorted(
        IntPtr keypoints);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KeyPointsFilter_retainBest(
        IntPtr keypoints, int nPoints);

    #endregion
}
