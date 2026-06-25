using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_Rodrigues(
        IntPtr src, IntPtr dst, IntPtr jacobian);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_findHomography_InputArray(
        IntPtr srcPoints, IntPtr dstPoints,
        int method, double ransacReprojThreshold, IntPtr mask,
        int maxIters, double confidence,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_findHomography_vector(
        Point2d[] srcPoints, int srcPointsLength,
        Point2d[] dstPoints, int dstPointsLength, int method, double ransacReprojThreshold, IntPtr mask,
        int maxIters, double confidence,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_findHomography_UsacParams(
        IntPtr srcPoints, IntPtr dstPoints, IntPtr mask, ref WUsacParams @params,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_RQDecomp3x3_InputArray(
        IntPtr src, IntPtr mtxR,
        IntPtr mtxQ, IntPtr qx, IntPtr qy, IntPtr qz, out Vec3d outVal);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_RQDecomp3x3_Mat(
        IntPtr src, IntPtr mtxR, IntPtr mtxQ,
        IntPtr qx, IntPtr qy, IntPtr qz, out Vec3d outVal);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_decomposeProjectionMatrix_InputArray(
        IntPtr projMatrix, IntPtr cameraMatrix, IntPtr rotMatrix, IntPtr transVect, 
        IntPtr rotMatrixX, IntPtr rotMatrixY, IntPtr rotMatrixZ, IntPtr eulerAngles);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_decomposeProjectionMatrix_Mat(
        IntPtr projMatrix, IntPtr cameraMatrix, IntPtr rotMatrix, IntPtr transVect, 
        IntPtr rotMatrixX, IntPtr rotMatrixY, IntPtr rotMatrixZ, IntPtr eulerAngles);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_matMulDeriv(
        IntPtr a, IntPtr b, IntPtr dABdA, IntPtr dABdB);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_composeRT_InputArray(
        IntPtr rvec1, IntPtr tvec1, IntPtr rvec2, IntPtr tvec2, IntPtr rvec3, IntPtr tvec3,
        IntPtr dr3dr1, IntPtr dr3dt1, IntPtr dr3dr2, IntPtr dr3dt2, 
        IntPtr dt3dr1, IntPtr dt3dt1, IntPtr dt3dr2, IntPtr dt3dt2);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_composeRT_Mat(
        IntPtr rvec1, IntPtr tvec1, IntPtr rvec2, IntPtr tvec2, IntPtr rvec3, IntPtr tvec3,
        IntPtr dr3dr1, IntPtr dr3dt1, IntPtr dr3dr2, IntPtr dr3dt2,
        IntPtr dt3dr1, IntPtr dt3dt1, IntPtr dt3dr2, IntPtr dt3dt2);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_projectPoints_InputArray(
        IntPtr objectPoints, IntPtr rvec, IntPtr tvec, IntPtr cameraMatrix, IntPtr distCoeffs,
        IntPtr imagePoints, IntPtr jacobian, double aspectRatio);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_projectPoints_Mat(
        IntPtr objectPoints, IntPtr rvec, IntPtr tvec, IntPtr cameraMatrix, IntPtr distCoeffs,
        IntPtr imagePoints, IntPtr jacobian, double aspectRatio);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_solvePnP_InputArray(
        IntPtr selfectPoints, IntPtr imagePoints, IntPtr cameraMatrix, 
        IntPtr distCoeffs, IntPtr rvec, IntPtr tvec, int useExtrinsicGuess, int flags);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus geometry_solvePnP_vector(
        Point3f[] objectPoints, int objectPointsLength,
        Point2f[] imagePoints, int imagePointsLength,
        double* cameraMatrix, double[]? distCoeffs, int distCoeffsLength,
        [Out] double[] rvec, [Out] double[] tvec, int useExtrinsicGuess, int flags);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_solvePnPRansac_InputArray(
        IntPtr objectPoints, IntPtr imagePoints,
        IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr rvec, IntPtr tvec,
        int useExtrinsicGuess, int iterationsCount, float reprojectionError, double confidence,
        IntPtr inliers, int flags);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus geometry_solvePnPRansac_vector(
        Point3f[] objectPoints, int objectPointsLength,
        Point2f[] imagePoints, int imagePointsLength, 
        double* cameraMatrix, double[]? distCoeffs, int distCoeffsLength,
        [Out] double[] rvec, [Out] double[] tvec, int useExtrinsicGuess, int iterationsCount, float reprojectionError, 
        double confidence, IntPtr inliers, int flags);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_calibrationMatrixValues_InputArray(
        IntPtr cameraMatrix,
        Size imageSize, double apertureWidth, double apertureHeight, out double fovx, out double fovy,
        out double focalLength, out Point2d principalPoint, out double aspectRatio);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus geometry_calibrationMatrixValues_array(
        double* cameraMatrix, Size imageSize,
        double apertureWidth, double apertureHeight, out double fovx, out double fovy, out double focalLength,
        out Point2d principalPoint, out double aspectRatio);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_getOptimalNewCameraMatrix_InputArray(
        IntPtr cameraMatrix, IntPtr distCoeffs,
        Size imageSize, double alpha, Size newImgSize,
        out Rect validPixROI, int centerPrincipalPoint,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus geometry_getOptimalNewCameraMatrix_array(
        double* cameraMatrix,
        [In] double[] distCoeffs, int distCoeffsSize,
        Size imageSize, double alpha, Size newImgSize,
        out Rect validPixROI, int centerPrincipalPoint,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_convertPointsToHomogeneous_InputArray(
        IntPtr src, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_convertPointsToHomogeneous_array1(
        [In] Vec2f[] src, [In, Out] Vec3f[] dst, int length);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_convertPointsToHomogeneous_array2(
        [In] Vec3f[] src, [In, Out] Vec4f[] dst, int length);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_convertPointsFromHomogeneous_InputArray(
        IntPtr src, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_convertPointsFromHomogeneous_array1(
        [In] Vec3f[] src, [In, Out] Vec2f[] dst, int length);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_convertPointsFromHomogeneous_array2(
        [In] Vec4f[] src, [In, Out] Vec3f[] dst, int length);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_convertPointsHomogeneous(
        IntPtr src, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_findFundamentalMat_InputArray(
        IntPtr points1, IntPtr points2,
        int method, double param1, double param2, IntPtr mask,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_findFundamentalMat_UsacParams(
        IntPtr points1, IntPtr points2, IntPtr mask, ref WUsacParams @params,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_findFundamentalMat_arrayF64(
        Point2d[] points1, int points1Size,
        Point2d[] points2, int points2Size,
        int method, double param1, double param2, IntPtr mask,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_findFundamentalMat_arrayF32(
        Point2f[] points1, int points1Size,
        Point2f[] points2, int points2Size,
        int method, double param1, double param2, IntPtr mask,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_computeCorrespondEpilines_InputArray(
        IntPtr points, int whichImage, IntPtr F, IntPtr lines);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus geometry_computeCorrespondEpilines_array2d(
        [In] Point2d[] points, int pointsSize,
        int whichImage, double* F, [In, Out] Point3f[] lines);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus geometry_computeCorrespondEpilines_array3d(
        [In] Point3d[] points, int pointsSize,
        int whichImage, double* F, [In, Out] Point3f[] lines);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_triangulatePoints_InputArray(
        IntPtr projMatr1, IntPtr projMatr2,
        IntPtr projPoints1, IntPtr projPoints2,
        IntPtr points4D);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus geometry_triangulatePoints_array(
        double* projMatr1, double* projMatr2,
        [In] Point2d[] projPoints1, int projPoints1Size,
        [In] Point2d[] projPoints2, int projPoints2Size,
        [In, Out] Vec4d[] points4D);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_correctMatches_InputArray(
        IntPtr F, IntPtr points1, IntPtr points2,
        IntPtr newPoints1, IntPtr newPoints2);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus geometry_correctMatches_array(
        double* F, Point2d[] points1, int points1Size,
        Point2d[] points2, int points2Size,
        Point2d[] newPoints1, Point2d[] newPoints2);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_estimateAffine3D(
        IntPtr src, IntPtr dst,
        IntPtr outVal, IntPtr inliers, double ransacThreshold, double confidence,
        out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_sampsonDistance_InputArray(
        IntPtr pt1, IntPtr pt2, IntPtr F, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus geometry_sampsonDistance_Point3d(
        Point3d pt1, Point3d pt2, double* F, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_estimateAffine2D(
        IntPtr from, IntPtr to, IntPtr inliers,
        int method, double ransacReprojThreshold,
        ulong maxIters, double confidence, ulong refineIters, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_estimateAffinePartial2D(
        IntPtr from, IntPtr to, IntPtr inliers,
        int method, double ransacReprojThreshold,
        ulong maxIters, double confidence, ulong refineIters, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_decomposeHomographyMat(
        IntPtr H,
        IntPtr K,
        IntPtr rotations,
        IntPtr translations,
        IntPtr normals,
        out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_filterHomographyDecompByVisibleRefpoints(
        IntPtr rotations,
        IntPtr normals,
        IntPtr beforePoints,
        IntPtr afterPoints,
        IntPtr possibleSolutions,
        IntPtr pointsMask);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_getDefaultNewCameraMatrix(
        IntPtr cameraMatrix, Size imgsize, int centerPrincipalPoint, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_undistortPoints(
        IntPtr src, IntPtr dst,
        IntPtr cameraMatrix, IntPtr distCoeffs,
        IntPtr R, IntPtr P);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_undistortPointsIter(
        IntPtr src, IntPtr dst,
        IntPtr cameraMatrix, IntPtr distCoeffs,
        IntPtr R, IntPtr P, TermCriteria criteria);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_recoverPose_InputArray1(
        IntPtr E, IntPtr points1, IntPtr points2,
        IntPtr cameraMatrix, 
        IntPtr R, IntPtr P, IntPtr mask,
        out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_recoverPose_InputArray2(
        IntPtr E, IntPtr points1, IntPtr points2,
        IntPtr R, IntPtr P, double focal, Point2d pp, IntPtr mask,
        out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_recoverPose_InputArray3(
        IntPtr E, IntPtr points1, IntPtr points2,
        IntPtr cameraMatrix,
        IntPtr R, IntPtr P, double distanceTresh, IntPtr mask, IntPtr triangulatedPoints,
        out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_findEssentialMat_InputArray1(
        IntPtr points1, IntPtr points2, IntPtr cameraMatrix,
        int method, double prob, double threshold, IntPtr mask, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_findEssentialMat_InputArray2(
        IntPtr points1, IntPtr points2, double focal, Point2d pp,
        int method, double prob, double threshold, IntPtr mask, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_solvePnPRefineLM(
        IntPtr objectPoints, IntPtr imagePoints, IntPtr cameraMatrix, IntPtr distCoeffs,
        IntPtr rvec, IntPtr tvec, TermCriteria criteria);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_solvePnPRefineVVS(
        IntPtr objectPoints, IntPtr imagePoints, IntPtr cameraMatrix, IntPtr distCoeffs,
        IntPtr rvec, IntPtr tvec, TermCriteria criteria, double vvsLambda);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_decomposeEssentialMat(
        IntPtr e, IntPtr r1, IntPtr r2, IntPtr t);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_estimateTranslation3D(
        IntPtr src, IntPtr dst, IntPtr outVal, IntPtr inliers,
        double ransacThreshold, double confidence, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus geometry_estimateTranslation2D(
        IntPtr from, IntPtr to, IntPtr inliers,
        int method, double ransacReprojThreshold, ulong maxIters, double confidence, ulong refineIters,
        out Vec2d returnValue);
}
