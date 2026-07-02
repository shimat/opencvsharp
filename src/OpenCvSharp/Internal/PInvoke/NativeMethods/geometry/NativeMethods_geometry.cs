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
    internal static partial ExceptionStatus geometry_Rodrigues(
        in InputArrayProxy src, in OutputArrayProxy dst, in OutputArrayProxy jacobian);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_findHomography_InputArray(
        in InputArrayProxy srcPoints, in InputArrayProxy dstPoints,
        int method, double ransacReprojThreshold, in OutputArrayProxy mask,
        int maxIters, double confidence,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_findHomography_vector(
        Point2d[] srcPoints, int srcPointsLength,
        Point2d[] dstPoints, int dstPointsLength, int method, double ransacReprojThreshold, in OutputArrayProxy mask,
        int maxIters, double confidence,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_findHomography_UsacParams(
        in InputArrayProxy srcPoints, in InputArrayProxy dstPoints, in OutputArrayProxy mask, ref WUsacParams @params,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_RQDecomp3x3_InputArray(
        in InputArrayProxy src, in OutputArrayProxy mtxR,
        in OutputArrayProxy mtxQ, in OutputArrayProxy qx, in OutputArrayProxy qy, in OutputArrayProxy qz, out Vec3d outVal);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_RQDecomp3x3_Mat(
        IntPtr src, IntPtr mtxR, IntPtr mtxQ,
        IntPtr qx, IntPtr qy, IntPtr qz, out Vec3d outVal);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_decomposeProjectionMatrix_InputArray(
        in InputArrayProxy projMatrix, in OutputArrayProxy cameraMatrix, in OutputArrayProxy rotMatrix, in OutputArrayProxy transVect, 
        in OutputArrayProxy rotMatrixX, in OutputArrayProxy rotMatrixY, in OutputArrayProxy rotMatrixZ, in OutputArrayProxy eulerAngles);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_decomposeProjectionMatrix_Mat(
        IntPtr projMatrix, IntPtr cameraMatrix, IntPtr rotMatrix, IntPtr transVect, 
        IntPtr rotMatrixX, IntPtr rotMatrixY, IntPtr rotMatrixZ, IntPtr eulerAngles);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_matMulDeriv(
        in InputArrayProxy a, in InputArrayProxy b, in OutputArrayProxy dABdA, in OutputArrayProxy dABdB);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_composeRT_InputArray(
        in InputArrayProxy rvec1, in InputArrayProxy tvec1, in InputArrayProxy rvec2, in InputArrayProxy tvec2, in OutputArrayProxy rvec3, in OutputArrayProxy tvec3,
        in OutputArrayProxy dr3dr1, in OutputArrayProxy dr3dt1, in OutputArrayProxy dr3dr2, in OutputArrayProxy dr3dt2, 
        in OutputArrayProxy dt3dr1, in OutputArrayProxy dt3dt1, in OutputArrayProxy dt3dr2, in OutputArrayProxy dt3dt2);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_composeRT_Mat(
        IntPtr rvec1, IntPtr tvec1, IntPtr rvec2, IntPtr tvec2, IntPtr rvec3, IntPtr tvec3,
        IntPtr dr3dr1, IntPtr dr3dt1, IntPtr dr3dr2, IntPtr dr3dt2,
        IntPtr dt3dr1, IntPtr dt3dt1, IntPtr dt3dr2, IntPtr dt3dt2);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_projectPoints_InputArray(
        in InputArrayProxy objectPoints, in InputArrayProxy rvec, in InputArrayProxy tvec, in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        in OutputArrayProxy imagePoints, in OutputArrayProxy jacobian, double aspectRatio);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_projectPoints_Mat(
        IntPtr objectPoints, IntPtr rvec, IntPtr tvec, IntPtr cameraMatrix, IntPtr distCoeffs,
        IntPtr imagePoints, IntPtr jacobian, double aspectRatio);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_solvePnP_InputArray(
        in InputArrayProxy selfectPoints, in InputArrayProxy imagePoints, in InputArrayProxy cameraMatrix, 
        in InputArrayProxy distCoeffs, in OutputArrayProxy rvec, in OutputArrayProxy tvec, int useExtrinsicGuess, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus geometry_solvePnP_vector(
        Point3f[] objectPoints, int objectPointsLength,
        Point2f[] imagePoints, int imagePointsLength,
        double* cameraMatrix, double[]? distCoeffs, int distCoeffsLength,
        [Out] double[] rvec, [Out] double[] tvec, int useExtrinsicGuess, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_solvePnPRansac_InputArray(
        in InputArrayProxy objectPoints, in InputArrayProxy imagePoints,
        in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs, in OutputArrayProxy rvec, in OutputArrayProxy tvec,
        int useExtrinsicGuess, int iterationsCount, float reprojectionError, double confidence,
        in OutputArrayProxy inliers, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus geometry_solvePnPRansac_vector(
        Point3f[] objectPoints, int objectPointsLength,
        Point2f[] imagePoints, int imagePointsLength, 
        double* cameraMatrix, double[]? distCoeffs, int distCoeffsLength,
        [Out] double[] rvec, [Out] double[] tvec, int useExtrinsicGuess, int iterationsCount, float reprojectionError, 
        double confidence, IntPtr inliers, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_calibrationMatrixValues_InputArray(
        in InputArrayProxy cameraMatrix,
        Size imageSize, double apertureWidth, double apertureHeight, out double fovx, out double fovy,
        out double focalLength, out Point2d principalPoint, out double aspectRatio);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus geometry_calibrationMatrixValues_array(
        double* cameraMatrix, Size imageSize,
        double apertureWidth, double apertureHeight, out double fovx, out double fovy, out double focalLength,
        out Point2d principalPoint, out double aspectRatio);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_getOptimalNewCameraMatrix_InputArray(
        in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        Size imageSize, double alpha, Size newImgSize,
        out Rect validPixROI, int centerPrincipalPoint,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus geometry_getOptimalNewCameraMatrix_array(
        double* cameraMatrix,
        [In] double[] distCoeffs, int distCoeffsSize,
        Size imageSize, double alpha, Size newImgSize,
        out Rect validPixROI, int centerPrincipalPoint,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_convertPointsToHomogeneous_InputArray(
        in InputArrayProxy src, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_convertPointsToHomogeneous_array1(
        [In] Vec2f[] src, [In, Out] Vec3f[] dst, int length);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_convertPointsToHomogeneous_array2(
        [In] Vec3f[] src, [In, Out] Vec4f[] dst, int length);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_convertPointsFromHomogeneous_InputArray(
        in InputArrayProxy src, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_convertPointsFromHomogeneous_array1(
        [In] Vec3f[] src, [In, Out] Vec2f[] dst, int length);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_convertPointsFromHomogeneous_array2(
        [In] Vec4f[] src, [In, Out] Vec3f[] dst, int length);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_convertPointsHomogeneous(
        in InputArrayProxy src, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_findFundamentalMat_InputArray(
        in InputArrayProxy points1, in InputArrayProxy points2,
        int method, double param1, double param2, in OutputArrayProxy mask,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_findFundamentalMat_UsacParams(
        in InputArrayProxy points1, in InputArrayProxy points2, in OutputArrayProxy mask, ref WUsacParams @params,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_findFundamentalMat_arrayF64(
        Point2d[] points1, int points1Size,
        Point2d[] points2, int points2Size,
        int method, double param1, double param2, in OutputArrayProxy mask,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_findFundamentalMat_arrayF32(
        Point2f[] points1, int points1Size,
        Point2f[] points2, int points2Size,
        int method, double param1, double param2, in OutputArrayProxy mask,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_computeCorrespondEpilines_InputArray(
        in InputArrayProxy points, int whichImage, in InputArrayProxy F, in OutputArrayProxy lines);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus geometry_computeCorrespondEpilines_array2d(
        [In] Point2d[] points, int pointsSize,
        int whichImage, double* F, [In, Out] Point3f[] lines);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus geometry_computeCorrespondEpilines_array3d(
        [In] Point3d[] points, int pointsSize,
        int whichImage, double* F, [In, Out] Point3f[] lines);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_triangulatePoints_InputArray(
        in InputArrayProxy projMatr1, in InputArrayProxy projMatr2,
        in InputArrayProxy projPoints1, in InputArrayProxy projPoints2,
        in OutputArrayProxy points4D);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus geometry_triangulatePoints_array(
        double* projMatr1, double* projMatr2,
        [In] Point2d[] projPoints1, int projPoints1Size,
        [In] Point2d[] projPoints2, int projPoints2Size,
        [In, Out] Vec4d[] points4D);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_correctMatches_InputArray(
        in InputArrayProxy F, in InputArrayProxy points1, in InputArrayProxy points2,
        in OutputArrayProxy newPoints1, in OutputArrayProxy newPoints2);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus geometry_correctMatches_array(
        double* F, Point2d[] points1, int points1Size,
        Point2d[] points2, int points2Size,
        Point2d[] newPoints1, Point2d[] newPoints2);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_estimateAffine3D(
        in InputArrayProxy src, in InputArrayProxy dst,
        in OutputArrayProxy outVal, in OutputArrayProxy inliers, double ransacThreshold, double confidence,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_sampsonDistance_InputArray(
        in InputArrayProxy pt1, in InputArrayProxy pt2, in InputArrayProxy F, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus geometry_sampsonDistance_Point3d(
        Point3d pt1, Point3d pt2, double* F, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_estimateAffine2D(
        in InputArrayProxy from, in InputArrayProxy to, in OutputArrayProxy inliers,
        int method, double ransacReprojThreshold,
        ulong maxIters, double confidence, ulong refineIters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_estimateAffinePartial2D(
        in InputArrayProxy from, in InputArrayProxy to, in OutputArrayProxy inliers,
        int method, double ransacReprojThreshold,
        ulong maxIters, double confidence, ulong refineIters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_decomposeHomographyMat(
        in InputArrayProxy H,
        in InputArrayProxy K,
        IntPtr rotations,
        IntPtr translations,
        IntPtr normals,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_filterHomographyDecompByVisibleRefpoints(
        IntPtr rotations,
        IntPtr normals,
        in InputArrayProxy beforePoints,
        in InputArrayProxy afterPoints,
        in OutputArrayProxy possibleSolutions,
        in InputArrayProxy pointsMask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_getDefaultNewCameraMatrix(
        in InputArrayProxy cameraMatrix, Size imgsize, int centerPrincipalPoint, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_undistortPoints(
        in InputArrayProxy src, in OutputArrayProxy dst,
        in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        in InputArrayProxy R, in InputArrayProxy P);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_undistortPointsIter(
        in InputArrayProxy src, in OutputArrayProxy dst,
        in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        in InputArrayProxy R, in InputArrayProxy P, TermCriteria criteria);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_recoverPose_InputArray1(
        in InputArrayProxy E, in InputArrayProxy points1, in InputArrayProxy points2,
        in InputArrayProxy cameraMatrix, 
        in OutputArrayProxy R, in OutputArrayProxy P, in InputOutputArrayProxy mask,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_recoverPose_InputArray2(
        in InputArrayProxy E, in InputArrayProxy points1, in InputArrayProxy points2,
        in OutputArrayProxy R, in OutputArrayProxy P, double focal, Point2d pp, in InputOutputArrayProxy mask,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_recoverPose_InputArray3(
        in InputArrayProxy E, in InputArrayProxy points1, in InputArrayProxy points2,
        in InputArrayProxy cameraMatrix,
        in OutputArrayProxy R, in OutputArrayProxy P, double distanceTresh, in InputOutputArrayProxy mask, in OutputArrayProxy triangulatedPoints,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_findEssentialMat_InputArray1(
        in InputArrayProxy points1, in InputArrayProxy points2, in InputArrayProxy cameraMatrix,
        int method, double prob, double threshold, in OutputArrayProxy mask, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_findEssentialMat_InputArray2(
        in InputArrayProxy points1, in InputArrayProxy points2, double focal, Point2d pp,
        int method, double prob, double threshold, in OutputArrayProxy mask, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_solvePnPRefineLM(
        in InputArrayProxy objectPoints, in InputArrayProxy imagePoints, in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        in InputOutputArrayProxy rvec, in InputOutputArrayProxy tvec, TermCriteria criteria);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_solvePnPRefineVVS(
        in InputArrayProxy objectPoints, in InputArrayProxy imagePoints, in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        in InputOutputArrayProxy rvec, in InputOutputArrayProxy tvec, TermCriteria criteria, double vvsLambda);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_decomposeEssentialMat(
        in InputArrayProxy e, in OutputArrayProxy r1, in OutputArrayProxy r2, in OutputArrayProxy t);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_estimateTranslation3D(
        in InputArrayProxy src, in InputArrayProxy dst, in OutputArrayProxy outVal, in OutputArrayProxy inliers,
        double ransacThreshold, double confidence, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_estimateTranslation2D(
        in InputArrayProxy from, in InputArrayProxy to, in OutputArrayProxy inliers,
        int method, double ransacReprojThreshold, ulong maxIters, double confidence, ulong refineIters,
        out Vec2d returnValue);
}
