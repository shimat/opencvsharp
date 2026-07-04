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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_approxPolyN(
        in InputArrayProxy curve, in OutputArrayProxy approxCurve, int nsides, float epsilonPercentage, int ensureConvex);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_minEnclosingConvexPolygon(
        in InputArrayProxy points, in OutputArrayProxy polygon, int k, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_getClosestEllipsePoints(
        RotatedRect ellipseParams, in InputArrayProxy points, in OutputArrayProxy closestPts);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_buildMST(
        int numNodes,
        [MarshalAs(UnmanagedType.LPArray), In] MSTEdge[] inputEdges, int inputEdgesLength,
        int algorithm, int root,
        [MarshalAs(UnmanagedType.LPArray), Out] MSTEdge[] resultingEdges, out int resultingEdgesCount,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_voxelGridSampling(
        in OutputArrayProxy sampledPointFlags, in InputArrayProxy inputPts,
        float length, float width, float height, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_randomSampling_Size(
        in OutputArrayProxy sampledPts, in InputArrayProxy inputPts, int sampledPtsSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_randomSampling_Scale(
        in OutputArrayProxy sampledPts, in InputArrayProxy inputPts, float sampledScale);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_farthestPointSampling_Size(
        in OutputArrayProxy sampledPointFlags, in InputArrayProxy inputPts,
        int sampledPtsSize, float distLowerLimit, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_farthestPointSampling_Scale(
        in OutputArrayProxy sampledPointFlags, in InputArrayProxy inputPts,
        float sampledScale, float distLowerLimit, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_normalEstimate(
        in OutputArrayProxy normals, in OutputArrayProxy curvatures,
        in InputArrayProxy inputPts, in InputArrayProxy nnIdx, int maxNeighborNum);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_getRotationMatrix2D(Point2f center, double angle, double scale, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_invertAffineTransform(in InputArrayProxy m, in OutputArrayProxy im);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_getPerspectiveTransform1(Point2f[] src, Point2f[] dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_getPerspectiveTransform2(in InputArrayProxy src, in InputArrayProxy dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_getAffineTransform1(Point2f[] src, Point2f[] dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_getAffineTransform2(in InputArrayProxy src, in InputArrayProxy dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_moments(in InputArrayProxy arr, int binaryImage, out Moments.NativeStruct returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_approxPolyDP_InputArray(in InputArrayProxy curve, in OutputArrayProxy approxCurve,
        double epsilon, int closed);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_approxPolyDP_Point(Point[] curve, int curveLength,
        IntPtr approxCurve, double epsilon, int closed);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_approxPolyDP_Point2f(Point2f[] curve, int curveLength,
        IntPtr approxCurve, double epsilon, int closed);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_arcLength_InputArray(in InputArrayProxy curve, int closed, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_arcLength_Point(Point[] curve, int curveLength, int closed, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_arcLength_Point2f(Point2f[] curve, int curveLength, int closed, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_boundingRect_InputArray(in InputArrayProxy curve, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_boundingRect_Point(Point[] curve, int curveLength, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_boundingRect_Point2f(Point2f[] curve, int curveLength, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_contourArea_InputArray(in InputArrayProxy contour, int oriented, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_contourArea_Point(
        [MarshalAs(UnmanagedType.LPArray)] Point[] contour, int contourLength, int oriented, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_contourArea_Point2f(
        [MarshalAs(UnmanagedType.LPArray)] Point2f[] contour, int contourLength, int oriented, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_minAreaRect_InputArray(in InputArrayProxy points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_minAreaRect_Point(
        [MarshalAs(UnmanagedType.LPArray)] Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_minAreaRect_Point2f(
        [MarshalAs(UnmanagedType.LPArray)] Point2f[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_boxPoints_OutputArray(RotatedRect box, in OutputArrayProxy points);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_boxPoints_Point2f(RotatedRect box, [MarshalAs(UnmanagedType.LPArray), Out] Point2f[] points);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_minEnclosingCircle_InputArray(in InputArrayProxy points, out Point2f center,
        out float radius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_minEnclosingCircle_Point(Point[] points, int pointsLength,
        out Point2f center, out float radius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_minEnclosingCircle_Point2f(Point2f[] points, int pointsLength,
        out Point2f center, out float radius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_minEnclosingTriangle_InputOutputArray(in InputArrayProxy points, in OutputArrayProxy triangle, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_minEnclosingTriangle_Point(
        [MarshalAs(UnmanagedType.LPArray), In] Point[] points, int pointsLength, IntPtr triangle, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_minEnclosingTriangle_Point2f(
        [MarshalAs(UnmanagedType.LPArray), In] Point2f[] points, int pointsLength, IntPtr triangle, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_matchShapes_InputArray(
        in InputArrayProxy contour1, in InputArrayProxy contour2, int method, double parameter, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_matchShapes_Point(
        Point[] contour1, int contour1Length, Point[] contour2, int contour2Length, int method, double parameter, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_convexHull_InputArray(in InputArrayProxy points, in OutputArrayProxy hull,
        int clockwise, int returnPoints);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_convexHull_Point_ReturnsPoints(Point[] points, int pointsLength,
        IntPtr hull, int clockwise);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_convexHull_Point2f_ReturnsPoints(Point2f[] points, int pointsLength,
        IntPtr hull, int clockwise);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_convexHull_Point_ReturnsIndices(Point[] points, int pointsLength,
        IntPtr hull, int clockwise);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_convexHull_Point2f_ReturnsIndices(Point2f[] points, int pointsLength,
        IntPtr hull, int clockwise);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_convexityDefects_InputArray(in InputArrayProxy contour, in InputArrayProxy convexHull,
        in OutputArrayProxy convexityDefects);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_convexityDefects_Point(Point[] contour, int contourLength, int[] convexHull,
        int convexHullLength, IntPtr convexityDefects);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_convexityDefects_Point2f(Point2f[] contour, int contourLength,
        int[] convexHull, int convexHullLength, IntPtr convexityDefects);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_isContourConvex_InputArray(in InputArrayProxy contour, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_isContourConvex_Point(Point[] contour, int contourLength, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_isContourConvex_Point2f(Point2f[] contour, int contourLength, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_intersectConvexConvex_InputArray(in InputArrayProxy p1, in InputArrayProxy p2,
        in OutputArrayProxy p12, int handleNested, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_intersectConvexConvex_Point(Point[] p1, int p1Length, Point[] p2,
        int p2Length, IntPtr p12, int handleNested, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_intersectConvexConvex_Point2f(Point2f[] p1, int p1Length, Point2f[] p2,
        int p2Length, IntPtr p12, int handleNested, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_fitEllipse_InputArray(in InputArrayProxy points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_fitEllipse_Point(Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_fitEllipse_Point2f(Point2f[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_fitEllipseAMS_InputArray(in InputArrayProxy points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_fitEllipseAMS_Point(Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_fitEllipseAMS_Point2f(Point2f[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_fitEllipseDirect_InputArray(in InputArrayProxy points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_fitEllipseDirect_Point(Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_fitEllipseDirect_Point2f(Point2f[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_fitLine_InputArray(in InputArrayProxy points, in OutputArrayProxy line,
        int distType, double param, double reps, double aeps);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_fitLine_Point(Point[] points, int pointsLength, [In, Out] float[] line,
        int distType,
        double param, double reps, double aeps);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_fitLine_Point2f(Point2f[] points, int pointsLength, [In, Out] float[] line,
        int distType, double param, double reps, double aeps);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_fitLine_Point3i(Point3i[] points, int pointsLength, [In, Out] float[] line,
        int distType, double param, double reps, double aeps);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_fitLine_Point3f(Point3f[] points, int pointsLength, [In, Out] float[] line,
        int distType, double param, double reps, double aeps);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_pointPolygonTest_InputArray(
        in InputArrayProxy contour, Point2f pt, int measureDist, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_pointPolygonTest_Point(Point[] contour, int contourLength, Point2f pt,
        int measureDist, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_pointPolygonTest_Point2f(Point2f[] contour, int contourLength,
        Point2f pt, int measureDist, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus geometry_rotatedRectangleIntersection_OutputArray(
        RotatedRect rect1, RotatedRect rect2, in OutputArrayProxy intersectingRegion, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus geometry_rotatedRectangleIntersection_vector(
        RotatedRect rect1, RotatedRect rect2, IntPtr intersectingRegion, out int returnValue);
}
