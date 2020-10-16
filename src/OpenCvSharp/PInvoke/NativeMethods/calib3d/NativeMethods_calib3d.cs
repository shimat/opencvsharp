
using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_Rodrigues(
            IntPtr src, IntPtr dst, IntPtr jacobian);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findHomography_InputArray(
            IntPtr srcPoints, IntPtr dstPoints,
            int method, double ransacReprojThreshold, IntPtr mask, 
            out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findHomography_vector(
            Point2d[] srcPoints, int srcPointsLength,
            Point2d[] dstPoints, int dstPointsLength, int method, double ransacReprojThreshold, IntPtr mask, 
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_RQDecomp3x3_InputArray(
            IntPtr src, IntPtr mtxR,
            IntPtr mtxQ, IntPtr qx, IntPtr qy, IntPtr qz, out Vec3d outVal);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_RQDecomp3x3_Mat(
            IntPtr src, IntPtr mtxR, IntPtr mtxQ,
            IntPtr qx, IntPtr qy, IntPtr qz, out Vec3d outVal);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_decomposeProjectionMatrix_InputArray(
            IntPtr projMatrix, IntPtr cameraMatrix, IntPtr rotMatrix, IntPtr transVect, 
            IntPtr rotMatrixX, IntPtr rotMatrixY, IntPtr rotMatrixZ, IntPtr eulerAngles);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_decomposeProjectionMatrix_Mat(
            IntPtr projMatrix, IntPtr cameraMatrix, IntPtr rotMatrix, IntPtr transVect, 
            IntPtr rotMatrixX, IntPtr rotMatrixY, IntPtr rotMatrixZ, IntPtr eulerAngles);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_matMulDeriv(
            IntPtr a, IntPtr b, IntPtr dABdA, IntPtr dABdB);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_composeRT_InputArray(
            IntPtr rvec1, IntPtr tvec1, IntPtr rvec2, IntPtr tvec2, IntPtr rvec3, IntPtr tvec3,
            IntPtr dr3dr1, IntPtr dr3dt1, IntPtr dr3dr2, IntPtr dr3dt2, 
            IntPtr dt3dr1, IntPtr dt3dt1, IntPtr dt3dr2, IntPtr dt3dt2);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_composeRT_Mat(
            IntPtr rvec1, IntPtr tvec1, IntPtr rvec2, IntPtr tvec2, IntPtr rvec3, IntPtr tvec3,
            IntPtr dr3dr1, IntPtr dr3dt1, IntPtr dr3dr2, IntPtr dr3dt2,
            IntPtr dt3dr1, IntPtr dt3dt1, IntPtr dt3dr2, IntPtr dt3dt2);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_projectPoints_InputArray(
            IntPtr objectPoints, IntPtr rvec, IntPtr tvec, IntPtr cameraMatrix, IntPtr distCoeffs,
            IntPtr imagePoints, IntPtr jacobian, double aspectRatio);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_projectPoints_Mat(
            IntPtr objectPoints, IntPtr rvec, IntPtr tvec, IntPtr cameraMatrix, IntPtr distCoeffs,
            IntPtr imagePoints, IntPtr jacobian, double aspectRatio);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_solvePnP_InputArray(
            IntPtr selfectPoints, IntPtr imagePoints, IntPtr cameraMatrix, 
            IntPtr distCoeffs, IntPtr rvec, IntPtr tvec, int useExtrinsicGuess, int flags);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_solvePnP_vector(
            Point3f[] objectPoints, int objectPointsLength,
            Point2f[] imagePoints, int imagePointsLength,
            double* cameraMatrix, double[]? distCoeffs, int distCoeffsLength,
            [Out] double[] rvec, [Out] double[] tvec, int useExtrinsicGuess, int flags);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_solvePnPRansac_InputArray(
            IntPtr objectPoints, IntPtr imagePoints,
            IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr rvec, IntPtr tvec,
            int useExtrinsicGuess, int iterationsCount, float reprojectionError, double confidence,
            IntPtr inliers, int flags);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_solvePnPRansac_vector(
            Point3f[] objectPoints, int objectPointsLength,
            Point2f[] imagePoints, int imagePointsLength, 
            double* cameraMatrix, double[]? distCoeffs, int distCoeffsLength,
            [Out] double[] rvec, [Out] double[] tvec, int useExtrinsicGuess, int iterationsCount, float reprojectionError, 
            double confidence, IntPtr inliers, int flags);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_initCameraMatrix2D_Mat(
            IntPtr[] objectPoints, int objectPointsLength,
            IntPtr[] imagePoints, int imagePointsLength,
            Size imageSize, double aspectRatio, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_initCameraMatrix2D_array(
            IntPtr[] objectPoints, int opSize1, int[] opSize2,
            IntPtr[] imagePoints, int ipSize1, int[] ipSize2,
            Size imageSize, double aspectRatio, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findChessboardCorners_InputArray(
            IntPtr image, Size patternSize, IntPtr corners, int flags, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findChessboardCorners_vector(
            IntPtr image, Size patternSize, IntPtr corners, int flags, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_checkChessboard(
            IntPtr img, Size size, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findChessboardCornersSB_OutputArray(
            IntPtr image, Size patternSize, IntPtr corners, int flags, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findChessboardCornersSB_vector(
            IntPtr image, Size patternSize, IntPtr corners, int flags, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_find4QuadCornerSubpix_InputArray(
            IntPtr img, IntPtr corners, Size regionSize, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_find4QuadCornerSubpix_vector(
            IntPtr img, IntPtr corners, Size regionSize, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_drawChessboardCorners_InputArray(
            IntPtr image, Size patternSize, IntPtr corners, int patternWasFound);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_drawChessboardCorners_array(
            IntPtr image, Size patternSize, [In] Point2f[] corners, int cornersLength, int patternWasFound);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_drawFrameAxes(
            IntPtr image, IntPtr cameraMatrix, IntPtr distCoeffs,
            IntPtr rvec, IntPtr tvec, float length, int thickness);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findCirclesGrid_InputArray(
            IntPtr image, Size patternSize,
            IntPtr centers, int flags, IntPtr blobDetector,
            out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findCirclesGrid_vector(
            IntPtr image, Size patternSize,
            IntPtr centers, int flags, IntPtr blobDetector,
            out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_calibrateCamera_InputArray(
            IntPtr[] objectPoints, int objectPointsSize,
            IntPtr[] imagePoints, int imagePointsSize,
            Size imageSize,
            IntPtr cameraMatrix,IntPtr distCoeffs,
            IntPtr rvecs, IntPtr tvecs,
            int flags, TermCriteria criteria,
            out double returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_calibrateCamera_vector(
            IntPtr[] objectPoints, int opSize1, int[] opSize2,
            IntPtr[] imagePoints, int ipSize1, int[] ipSize2,
            Size imageSize,
            double* cameraMatrix,
            [In, Out] double[] distCoeffs, int distCoeffsSize,
            IntPtr rvecs, IntPtr tvecs,
            int flags, TermCriteria criteria,
            out double returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_calibrationMatrixValues_InputArray(
            IntPtr cameraMatrix,
            Size imageSize, double apertureWidth, double apertureHeight, out double fovx, out double fovy,
            out double focalLength, out Point2d principalPoint, out double aspectRatio);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_calibrationMatrixValues_array(
            double* cameraMatrix, Size imageSize,
            double apertureWidth, double apertureHeight, out double fovx, out double fovy, out double focalLength,
            out Point2d principalPoint, out double aspectRatio);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_stereoCalibrate_InputArray(
            IntPtr[] objectPoints, int opSize,
            IntPtr[] imagePoints1, int ip1Size,
            IntPtr[] imagePoints2, int ip2Size,
            IntPtr cameraMatrix1,
            IntPtr distCoeffs1,
            IntPtr cameraMatrix2,
            IntPtr distCoeffs2,
            Size imageSize,
            IntPtr R, IntPtr T,
            IntPtr E, IntPtr F,
            int flags, TermCriteria criteria,
            out double returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_stereoCalibrate_array(
            IntPtr[] objectPoints, int opSize1, int[] opSizes2,
            IntPtr[] imagePoints1, int ip1Size1, int[] ip1Sizes2,
            IntPtr[] imagePoints2, int ip2Size1, int[] ip2Sizes2,
            double* cameraMatrix1,
            [In, Out] double[] distCoeffs1, int dc1Size,
            double* cameraMatrix2,
            [In, Out] double[] distCoeffs2, int dc2Size,
            Size imageSize,
            IntPtr R, IntPtr T,
            IntPtr E, IntPtr F,
            int flags, TermCriteria criteria,
            out double returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_stereoRectify_InputArray(
            IntPtr cameraMatrix1, IntPtr distCoeffs1,
            IntPtr cameraMatrix2, IntPtr distCoeffs2,
            Size imageSize, IntPtr R, IntPtr T,
            IntPtr R1, IntPtr R2,
            IntPtr P1, IntPtr P2,
            IntPtr Q, int flags,
            double alpha, Size newImageSize,
            out Rect validPixROI1, out Rect validPixROI2);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_stereoRectify_array(
            double* cameraMatrix1,
            double[] distCoeffs1, int dc1Size,
            double* cameraMatrix2,
            double[] distCoeffs2, int dc2Size,
            Size imageSize,
            double* R, double[] T,
            double* R1, double* R2, double* P1, double* P2,
            double* Q, int flags, double alpha, Size newImageSize,
            out Rect validPixROI1, out Rect validPixROI2);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_stereoRectifyUncalibrated_InputArray(
            IntPtr points1, IntPtr points2,
            IntPtr F, Size imgSize,
            IntPtr H1, IntPtr H2,
            double threshold,
            out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_stereoRectifyUncalibrated_array(
            Point2d[] points1, int points1Size,
            Point2d[] points2, int points2Size,
            double* F, Size imgSize,
            double* H1, double* H2,
            double threshold,
            out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_rectify3Collinear_InputArray(
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

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_getOptimalNewCameraMatrix_InputArray(
            IntPtr cameraMatrix, IntPtr distCoeffs,
            Size imageSize, double alpha, Size newImgSize,
            out Rect validPixROI, int centerPrincipalPoint,
            out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_getOptimalNewCameraMatrix_array(
            double* cameraMatrix,
            [In] double[] distCoeffs, int distCoeffsSize,
            Size imageSize, double alpha, Size newImgSize,
            out Rect validPixROI, int centerPrincipalPoint,
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_calibrateHandEye(
            IntPtr[] R_gripper2baseMats, int R_gripper2baseMatsSize,
            IntPtr[] t_gripper2baseMats, int t_gripper2baseMatsSize,
            IntPtr[] R_target2camMats, int R_target2camMatsSize,
            IntPtr[] t_target2camMats, int t_target2camMatsSize,
            IntPtr R_cam2gripper,
            IntPtr t_cam2gripper,
            int method);

       [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_convertPointsToHomogeneous_InputArray(
            IntPtr src, IntPtr dst);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_convertPointsToHomogeneous_array1(
            [In] Vec2f[] src, [In, Out] Vec3f[] dst, int length);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_convertPointsToHomogeneous_array2(
            [In] Vec3f[] src, [In, Out] Vec4f[] dst, int length);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_convertPointsFromHomogeneous_InputArray(
            IntPtr src, IntPtr dst);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_convertPointsFromHomogeneous_array1(
            [In] Vec3f[] src, [In, Out] Vec2f[] dst, int length);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_convertPointsFromHomogeneous_array2(
            [In] Vec4f[] src, [In, Out] Vec3f[] dst, int length);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_convertPointsHomogeneous(
            IntPtr src, IntPtr dst);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findFundamentalMat_InputArray(
            IntPtr points1, IntPtr points2,
            int method, double param1, double param2, IntPtr mask,
            out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findFundamentalMat_arrayF64(
            Point2d[] points1, int points1Size,
            Point2d[] points2, int points2Size,
            int method, double param1, double param2, IntPtr mask,
            out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findFundamentalMat_arrayF32(
            Point2f[] points1, int points1Size,
            Point2f[] points2, int points2Size,
            int method, double param1, double param2, IntPtr mask,
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_computeCorrespondEpilines_InputArray(
            IntPtr points, int whichImage, IntPtr F, IntPtr lines);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_computeCorrespondEpilines_array2d(
            [In] Point2d[] points, int pointsSize,
            int whichImage, double* F, [In, Out] Point3f[] lines);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_computeCorrespondEpilines_array3d(
            [In] Point3d[] points, int pointsSize,
            int whichImage, double* F, [In, Out] Point3f[] lines);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_triangulatePoints_InputArray(
            IntPtr projMatr1, IntPtr projMatr2,
            IntPtr projPoints1, IntPtr projPoints2,
            IntPtr points4D);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_triangulatePoints_array(
            double* projMatr1, double* projMatr2,
            [In] Point2d[] projPoints1, int projPoints1Size,
            [In] Point2d[] projPoints2, int projPoints2Size,
            [In, Out] Vec4d[] points4D);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_correctMatches_InputArray(
            IntPtr F, IntPtr points1, IntPtr points2,
            IntPtr newPoints1, IntPtr newPoints2);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_correctMatches_array(
            double* F, Point2d[] points1, int points1Size,
            Point2d[] points2, int points2Size,
            Point2d[] newPoints1, Point2d[] newPoints2);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_filterSpeckles(
            IntPtr img, double newVal, int maxSpeckleSize,
            double maxDiff, IntPtr buf);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_getValidDisparityROI(
            Rect roi1, Rect roi2,
            int minDisparity, int numberOfDisparities, int SADWindowSize,
            out Rect returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_validateDisparity(
            IntPtr disparity, IntPtr cost,
            int minDisparity, int numberOfDisparities, int disp12MaxDisp);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_reprojectImageTo3D(
            IntPtr disparity, IntPtr _3dImage,
            IntPtr Q, int handleMissingValues, int ddepth);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_estimateAffine3D(
            IntPtr src, IntPtr dst,
            IntPtr outVal, IntPtr inliers, double ransacThreshold, double confidence,
            out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_sampsonDistance_InputArray(
            IntPtr pt1, IntPtr pt2, IntPtr F, out double returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus calib3d_sampsonDistance_Point3d(
            Point3d pt1, Point3d pt2, double* F, out double returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_estimateAffine2D(
            IntPtr from, IntPtr to, IntPtr inliers,
            int method, double ransacReprojThreshold,
            ulong maxIters, double confidence, ulong refineIters, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_estimateAffinePartial2D(
            IntPtr from, IntPtr to, IntPtr inliers,
            int method, double ransacReprojThreshold,
            ulong maxIters, double confidence, ulong refineIters, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_decomposeHomographyMat(
            IntPtr H,
            IntPtr K,
            IntPtr rotations,
            IntPtr translations,
            IntPtr normals,
            out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_filterHomographyDecompByVisibleRefpoints(
            IntPtr rotations,
            IntPtr normals,
            IntPtr beforePoints,
            IntPtr afterPoints,
            IntPtr possibleSolutions,
            IntPtr pointsMask);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_undistort(
            IntPtr src, IntPtr dst,
            IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr newCameraMatrix);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_initUndistortRectifyMap(
            IntPtr cameraMatrix, IntPtr distCoeffs,
            IntPtr R, IntPtr newCameraMatrix,
            Size size, int m1type, IntPtr map1, IntPtr map2);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_initWideAngleProjMap(
            IntPtr cameraMatrix, IntPtr distCoeffs,
            Size imageSize, int destImageWidth,
            int m1type, IntPtr map1, IntPtr map2,
            int projType, double alpha, out float returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_getDefaultNewCameraMatrix(
            IntPtr cameraMatrix, Size imgsize, int centerPrincipalPoint, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_undistortPoints(
            IntPtr src, IntPtr dst,
            IntPtr cameraMatrix, IntPtr distCoeffs,
            IntPtr R, IntPtr P);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_undistortPointsIter(
            IntPtr src, IntPtr dst,
            IntPtr cameraMatrix, IntPtr distCoeffs,
            IntPtr R, IntPtr P, TermCriteria criteria);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_recoverPose_InputArray1(
            IntPtr E, IntPtr points1, IntPtr points2,
            IntPtr cameraMatrix, 
            IntPtr R, IntPtr P, IntPtr mask,
            out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_recoverPose_InputArray2(
            IntPtr E, IntPtr points1, IntPtr points2,
            IntPtr R, IntPtr P, double focal, Point2d pp, IntPtr mask,
            out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_recoverPose_InputArray3(
            IntPtr E, IntPtr points1, IntPtr points2,
            IntPtr cameraMatrix,
            IntPtr R, IntPtr P, double distanceTresh, IntPtr mask, IntPtr triangulatedPoints,
            out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findEssentialMat_InputArray1(
            IntPtr points1, IntPtr points2, IntPtr cameraMatrix,
            int method, double prob, double threshold, IntPtr mask, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus calib3d_findEssentialMat_InputArray2(
            IntPtr points1, IntPtr points2, double focal, Point2d pp,
            int method, double prob, double threshold, IntPtr mask, out IntPtr returnValue);
    }
}