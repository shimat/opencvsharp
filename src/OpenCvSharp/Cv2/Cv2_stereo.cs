using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable UnusedMember.Global
using FeatureDetector = Feature2D;

static partial class Cv2
{
    /// <summary>
    /// computes the rectification transformation for a stereo camera from its intrinsic and extrinsic parameters
    /// </summary>
    /// <param name="cameraMatrix1">First camera matrix.</param>
    /// <param name="distCoeffs1">First camera distortion parameters.</param>
    /// <param name="cameraMatrix2">Second camera matrix.</param>
    /// <param name="distCoeffs2">Second camera distortion parameters.</param>
    /// <param name="imageSize">Size of the image used for stereo calibration.</param>
    /// <param name="R">Rotation matrix between the coordinate systems of the first and the second cameras.</param>
    /// <param name="T">Translation vector between coordinate systems of the cameras.</param>
    /// <param name="R1">Output 3x3 rectification transform (rotation matrix) for the first camera.</param>
    /// <param name="R2"> Output 3x3 rectification transform (rotation matrix) for the second camera.</param>
    /// <param name="P1">Output 3x4 projection matrix in the new (rectified) coordinate systems for the first camera.</param>
    /// <param name="P2">Output 3x4 projection matrix in the new (rectified) coordinate systems for the second camera.</param>
    /// <param name="Q">Output 4x4 disparity-to-depth mapping matrix (see reprojectImageTo3D() ).</param>
    /// <param name="flags">Operation flags that may be zero or CV_CALIB_ZERO_DISPARITY. 
    /// If the flag is set, the function makes the principal points of each camera have the same pixel coordinates in the rectified views. 
    /// And if the flag is not set, the function may still shift the images in the horizontal or vertical direction (depending on the orientation of epipolar lines) to maximize the useful image area.</param>
    /// <param name="alpha">Free scaling parameter. 
    /// If it is -1 or absent, the function performs the default scaling. Otherwise, the parameter should be between 0 and 1. 
    /// alpha=0 means that the rectified images are zoomed and shifted so that only valid pixels are visible (no black areas after rectification). 
    /// alpha=1 means that the rectified image is decimated and shifted so that all the pixels from the original images from the cameras are retained 
    /// in the rectified images (no source image pixels are lost). Obviously, any intermediate value yields an intermediate result between those two extreme cases.</param>
    /// <param name="newImageSize">New image resolution after rectification. The same size should be passed to initUndistortRectifyMap(). When (0,0) is passed (default), it is set to the original imageSize . 
    /// Setting it to larger value can help you preserve details in the original image, especially when there is a big radial distortion.</param>
    public static void StereoRectify(InputArray cameraMatrix1, InputArray distCoeffs1,
        InputArray cameraMatrix2, InputArray distCoeffs2,
        Size imageSize, InputArray R, InputArray T,
        OutputArray R1, OutputArray R2,
        OutputArray P1, OutputArray P2,
        OutputArray Q,
        StereoRectificationFlags flags = StereoRectificationFlags.ZeroDisparity,
        double alpha = -1, Size? newImageSize = null)
    {
        var newImageSize0 = newImageSize.GetValueOrDefault(new Size(0, 0));
        StereoRectify(cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2,
            imageSize, R, T, R1, R2, P1, P2, Q, flags, alpha, newImageSize0,
            out _, out _);
    }

    /// <summary>
    /// computes the rectification transformation for a stereo camera from its intrinsic and extrinsic parameters
    /// </summary>
    /// <param name="cameraMatrix1">First camera matrix.</param>
    /// <param name="distCoeffs1">First camera distortion parameters.</param>
    /// <param name="cameraMatrix2">Second camera matrix.</param>
    /// <param name="distCoeffs2">Second camera distortion parameters.</param>
    /// <param name="imageSize">Size of the image used for stereo calibration.</param>
    /// <param name="R">Rotation matrix between the coordinate systems of the first and the second cameras.</param>
    /// <param name="T">Translation vector between coordinate systems of the cameras.</param>
    /// <param name="R1">Output 3x3 rectification transform (rotation matrix) for the first camera.</param>
    /// <param name="R2"> Output 3x3 rectification transform (rotation matrix) for the second camera.</param>
    /// <param name="P1">Output 3x4 projection matrix in the new (rectified) coordinate systems for the first camera.</param>
    /// <param name="P2">Output 3x4 projection matrix in the new (rectified) coordinate systems for the second camera.</param>
    /// <param name="Q">Output 4x4 disparity-to-depth mapping matrix (see reprojectImageTo3D() ).</param>
    /// <param name="flags">Operation flags that may be zero or CV_CALIB_ZERO_DISPARITY. 
    /// If the flag is set, the function makes the principal points of each camera have the same pixel coordinates in the rectified views. 
    /// And if the flag is not set, the function may still shift the images in the horizontal or vertical direction (depending on the orientation of epipolar lines) to maximize the useful image area.</param>
    /// <param name="alpha">Free scaling parameter. 
    /// If it is -1 or absent, the function performs the default scaling. Otherwise, the parameter should be between 0 and 1. 
    /// alpha=0 means that the rectified images are zoomed and shifted so that only valid pixels are visible (no black areas after rectification). 
    /// alpha=1 means that the rectified image is decimated and shifted so that all the pixels from the original images from the cameras are retained 
    /// in the rectified images (no source image pixels are lost). Obviously, any intermediate value yields an intermediate result between those two extreme cases.</param>
    /// <param name="newImageSize">New image resolution after rectification. The same size should be passed to initUndistortRectifyMap(). When (0,0) is passed (default), it is set to the original imageSize . 
    /// Setting it to larger value can help you preserve details in the original image, especially when there is a big radial distortion.</param>
    /// <param name="validPixROI1">Optional output rectangles inside the rectified images where all the pixels are valid. If alpha=0 , the ROIs cover the whole images. 
    /// Otherwise, they are likely to be smaller.</param>
    /// <param name="validPixROI2">Optional output rectangles inside the rectified images where all the pixels are valid. If alpha=0 , the ROIs cover the whole images. 
    /// Otherwise, they are likely to be smaller.</param>
    public static void StereoRectify(InputArray cameraMatrix1, InputArray distCoeffs1,
        InputArray cameraMatrix2, InputArray distCoeffs2,
        Size imageSize, InputArray R, InputArray T,
        OutputArray R1, OutputArray R2,
        OutputArray P1, OutputArray P2,
        OutputArray Q, StereoRectificationFlags flags,
        double alpha, Size newImageSize,
        out Rect validPixROI1, out Rect validPixROI2)
    {
        if (cameraMatrix1 is null)
            throw new ArgumentNullException(nameof(cameraMatrix1));
        if (distCoeffs1 is null)
            throw new ArgumentNullException(nameof(distCoeffs1));
        if (cameraMatrix2 is null)
            throw new ArgumentNullException(nameof(cameraMatrix2));
        if (distCoeffs2 is null)
            throw new ArgumentNullException(nameof(distCoeffs2));
        if (R is null)
            throw new ArgumentNullException(nameof(R));
        if (T is null)
            throw new ArgumentNullException(nameof(T));
        if (R1 is null)
            throw new ArgumentNullException(nameof(R1));
        if (R2 is null)
            throw new ArgumentNullException(nameof(R2));
        if (P1 is null)
            throw new ArgumentNullException(nameof(P1));
        if (P2 is null)
            throw new ArgumentNullException(nameof(P2));
        if (Q is null)
            throw new ArgumentNullException(nameof(Q));
        cameraMatrix1.ThrowIfDisposed();
        distCoeffs1.ThrowIfDisposed();
        cameraMatrix2.ThrowIfDisposed();
        distCoeffs2.ThrowIfDisposed();
        R.ThrowIfDisposed();
        T.ThrowIfDisposed();
        R1.ThrowIfNotReady();
        R2.ThrowIfNotReady();
        P1.ThrowIfNotReady();
        P2.ThrowIfNotReady();
        Q.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.stereo_stereoRectify_InputArray(
                cameraMatrix1.CvPtr, distCoeffs1.CvPtr,
                cameraMatrix2.CvPtr, distCoeffs2.CvPtr,
                imageSize, R.CvPtr, T.CvPtr,
                R1.CvPtr, R2.CvPtr, P1.CvPtr, P2.CvPtr, Q.CvPtr,
                (int) flags, alpha, newImageSize, out validPixROI1, out validPixROI2));

        GC.KeepAlive(cameraMatrix1);
        GC.KeepAlive(distCoeffs1);
        GC.KeepAlive(cameraMatrix2);
        GC.KeepAlive(distCoeffs2);
        GC.KeepAlive(R);
        GC.KeepAlive(T);
        GC.KeepAlive(R1);
        GC.KeepAlive(R2);
        GC.KeepAlive(P1);
        GC.KeepAlive(P2);
        GC.KeepAlive(Q);

        R1.Fix();
        R2.Fix();
        P1.Fix();
        P2.Fix();
        Q.Fix();
    }

    /// <summary>
    /// computes the rectification transformation for a stereo camera from its intrinsic and extrinsic parameters
    /// </summary>
    /// <param name="cameraMatrix1">First camera matrix.</param>
    /// <param name="distCoeffs1">First camera distortion parameters.</param>
    /// <param name="cameraMatrix2">Second camera matrix.</param>
    /// <param name="distCoeffs2">Second camera distortion parameters.</param>
    /// <param name="imageSize">Size of the image used for stereo calibration.</param>
    /// <param name="R">Rotation matrix between the coordinate systems of the first and the second cameras.</param>
    /// <param name="T">Translation vector between coordinate systems of the cameras.</param>
    /// <param name="R1">Output 3x3 rectification transform (rotation matrix) for the first camera.</param>
    /// <param name="R2"> Output 3x3 rectification transform (rotation matrix) for the second camera.</param>
    /// <param name="P1">Output 3x4 projection matrix in the new (rectified) coordinate systems for the first camera.</param>
    /// <param name="P2">Output 3x4 projection matrix in the new (rectified) coordinate systems for the second camera.</param>
    /// <param name="Q">Output 4x4 disparity-to-depth mapping matrix (see reprojectImageTo3D() ).</param>
    /// <param name="flags">Operation flags that may be zero or CV_CALIB_ZERO_DISPARITY. 
    /// If the flag is set, the function makes the principal points of each camera have the same pixel coordinates in the rectified views. 
    /// And if the flag is not set, the function may still shift the images in the horizontal or vertical direction (depending on the orientation of epipolar lines) to maximize the useful image area.</param>
    /// <param name="alpha">Free scaling parameter. 
    /// If it is -1 or absent, the function performs the default scaling. Otherwise, the parameter should be between 0 and 1. 
    /// alpha=0 means that the rectified images are zoomed and shifted so that only valid pixels are visible (no black areas after rectification). 
    /// alpha=1 means that the rectified image is decimated and shifted so that all the pixels from the original images from the cameras are retained 
    /// in the rectified images (no source image pixels are lost). Obviously, any intermediate value yields an intermediate result between those two extreme cases.</param>
    /// <param name="newImageSize">New image resolution after rectification. The same size should be passed to initUndistortRectifyMap(). When (0,0) is passed (default), it is set to the original imageSize . 
    /// Setting it to larger value can help you preserve details in the original image, especially when there is a big radial distortion.</param>
    public static void StereoRectify(double[,] cameraMatrix1, double[] distCoeffs1,
        double[,] cameraMatrix2, double[] distCoeffs2,
        Size imageSize, double[,] R, double[] T,
        out double[,] R1, out double[,] R2,
        out double[,] P1, out double[,] P2,
        out double[,] Q,
        StereoRectificationFlags flags = StereoRectificationFlags.ZeroDisparity,
        double alpha = -1, Size? newImageSize = null)
    {
        var newImageSize0 = newImageSize.GetValueOrDefault(new Size(0, 0));
        StereoRectify(
            cameraMatrix1, distCoeffs1,
            cameraMatrix2, distCoeffs2,
            imageSize, R, T,
            out R1, out R2, out P1, out P2, out Q,
            flags, alpha, newImageSize0, out _, out _);
    }

    /// <summary>
    /// computes the rectification transformation for a stereo camera from its intrinsic and extrinsic parameters
    /// </summary>
    /// <param name="cameraMatrix1">First camera matrix.</param>
    /// <param name="distCoeffs1">First camera distortion parameters.</param>
    /// <param name="cameraMatrix2">Second camera matrix.</param>
    /// <param name="distCoeffs2">Second camera distortion parameters.</param>
    /// <param name="imageSize">Size of the image used for stereo calibration.</param>
    /// <param name="R">Rotation matrix between the coordinate systems of the first and the second cameras.</param>
    /// <param name="T">Translation vector between coordinate systems of the cameras.</param>
    /// <param name="R1">Output 3x3 rectification transform (rotation matrix) for the first camera.</param>
    /// <param name="R2"> Output 3x3 rectification transform (rotation matrix) for the second camera.</param>
    /// <param name="P1">Output 3x4 projection matrix in the new (rectified) coordinate systems for the first camera.</param>
    /// <param name="P2">Output 3x4 projection matrix in the new (rectified) coordinate systems for the second camera.</param>
    /// <param name="Q">Output 4x4 disparity-to-depth mapping matrix (see reprojectImageTo3D() ).</param>
    /// <param name="flags">Operation flags that may be zero or CV_CALIB_ZERO_DISPARITY. 
    /// If the flag is set, the function makes the principal points of each camera have the same pixel coordinates in the rectified views. 
    /// And if the flag is not set, the function may still shift the images in the horizontal or vertical direction (depending on the orientation of epipolar lines) to maximize the useful image area.</param>
    /// <param name="alpha">Free scaling parameter. 
    /// If it is -1 or absent, the function performs the default scaling. Otherwise, the parameter should be between 0 and 1. 
    /// alpha=0 means that the rectified images are zoomed and shifted so that only valid pixels are visible (no black areas after rectification). 
    /// alpha=1 means that the rectified image is decimated and shifted so that all the pixels from the original images from the cameras are retained 
    /// in the rectified images (no source image pixels are lost). Obviously, any intermediate value yields an intermediate result between those two extreme cases.</param>
    /// <param name="newImageSize">New image resolution after rectification. The same size should be passed to initUndistortRectifyMap(). When (0,0) is passed (default), it is set to the original imageSize . 
    /// Setting it to larger value can help you preserve details in the original image, especially when there is a big radial distortion.</param>
    /// <param name="validPixROI1">Optional output rectangles inside the rectified images where all the pixels are valid. If alpha=0 , the ROIs cover the whole images. 
    /// Otherwise, they are likely to be smaller.</param>
    /// <param name="validPixROI2">Optional output rectangles inside the rectified images where all the pixels are valid. If alpha=0 , the ROIs cover the whole images. 
    /// Otherwise, they are likely to be smaller.</param>
    public static void StereoRectify(double[,] cameraMatrix1, double[] distCoeffs1,
        double[,] cameraMatrix2, double[] distCoeffs2,
        Size imageSize, double[,] R, double[] T,
        out double[,] R1, out double[,] R2,
        out double[,] P1, out double[,] P2,
        out double[,] Q, StereoRectificationFlags flags,
        double alpha, Size newImageSize,
        out Rect validPixROI1, out Rect validPixROI2)
    {
        if (cameraMatrix1 is null)
            throw new ArgumentNullException(nameof(cameraMatrix1));
        if (distCoeffs1 is null)
            throw new ArgumentNullException(nameof(distCoeffs1));
        if (cameraMatrix2 is null)
            throw new ArgumentNullException(nameof(cameraMatrix2));
        if (distCoeffs2 is null)
            throw new ArgumentNullException(nameof(distCoeffs2));
        if (R is null)
            throw new ArgumentNullException(nameof(R));
        if (T is null)
            throw new ArgumentNullException(nameof(T));

        R1 = new double[3, 3];
        R2 = new double[3, 3];
        P1 = new double[3, 4];
        P2 = new double[3, 4];
        Q = new double[4, 4];

        unsafe
        {
            fixed (double* cameraMatrix1Ptr = cameraMatrix1)
            fixed (double* cameraMatrix2Ptr = cameraMatrix2)
            fixed (double* RPtr = R)
            fixed (double* R1Ptr = R1)
            fixed (double* R2Ptr = R2)
            fixed (double* P1Ptr = P1)
            fixed (double* P2Ptr = P2)
            fixed (double* QPtr = Q)
            {
                NativeMethods.HandleException(
                    NativeMethods.stereo_stereoRectify_array(
                        cameraMatrix1Ptr, distCoeffs1, distCoeffs1.Length,
                        cameraMatrix2Ptr, distCoeffs2, distCoeffs2.Length,
                        imageSize, RPtr, T,
                        R1Ptr, R2Ptr, P1Ptr, P2Ptr, QPtr,
                        (int) flags, alpha, newImageSize, out validPixROI1, out validPixROI2));
            }
        }
    }

    /// <summary>
    /// computes the rectification transformation for an uncalibrated stereo camera (zero distortion is assumed)
    /// </summary>
    /// <param name="points1">Array of feature points in the first image.</param>
    /// <param name="points2">The corresponding points in the second image. 
    /// The same formats as in findFundamentalMat() are supported.</param>
    /// <param name="F">Input fundamental matrix. It can be computed from the same set 
    /// of point pairs using findFundamentalMat() .</param>
    /// <param name="imgSize">Size of the image.</param>
    /// <param name="H1">Output rectification homography matrix for the first image.</param>
    /// <param name="H2">Output rectification homography matrix for the second image.</param>
    /// <param name="threshold">Optional threshold used to filter out the outliers. 
    /// If the parameter is greater than zero, all the point pairs that do not comply 
    /// with the epipolar geometry (that is, the points for which |points2[i]^T * F * points1[i]| > threshold ) 
    /// are rejected prior to computing the homographies. Otherwise, all the points are considered inliers.</param>
    /// <returns></returns>
    public static bool StereoRectifyUncalibrated(InputArray points1, InputArray points2,
        InputArray F, Size imgSize,
        OutputArray H1, OutputArray H2,
        double threshold = 5)
    {
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));
        if (F is null)
            throw new ArgumentNullException(nameof(F));
        if (H1 is null)
            throw new ArgumentNullException(nameof(H1));
        if (H2 is null)
            throw new ArgumentNullException(nameof(H2));
        points1.ThrowIfDisposed();
        points2.ThrowIfDisposed();
        F.ThrowIfDisposed();
        H1.ThrowIfNotReady();
        H2.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.stereo_stereoRectifyUncalibrated_InputArray(
                points1.CvPtr, points2.CvPtr, F.CvPtr, imgSize, H1.CvPtr, H2.CvPtr, threshold, out var ret));

        GC.KeepAlive(points1);
        GC.KeepAlive(points2);
        GC.KeepAlive(F);
        GC.KeepAlive(H1);
        GC.KeepAlive(H2);
        H1.Fix();
        H2.Fix();
        return ret != 0;
    }

    /// <summary>
    /// computes the rectification transformation for an uncalibrated stereo camera (zero distortion is assumed)
    /// </summary>
    /// <param name="points1">Array of feature points in the first image.</param>
    /// <param name="points2">The corresponding points in the second image. 
    /// The same formats as in findFundamentalMat() are supported.</param>
    /// <param name="F">Input fundamental matrix. It can be computed from the same set 
    /// of point pairs using findFundamentalMat() .</param>
    /// <param name="imgSize">Size of the image.</param>
    /// <param name="H1">Output rectification homography matrix for the first image.</param>
    /// <param name="H2">Output rectification homography matrix for the second image.</param>
    /// <param name="threshold">Optional threshold used to filter out the outliers. 
    /// If the parameter is greater than zero, all the point pairs that do not comply 
    /// with the epipolar geometry (that is, the points for which |points2[i]^T * F * points1[i]| > threshold ) 
    /// are rejected prior to computing the homographies. Otherwise, all the points are considered inliers.</param>
    /// <returns></returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static bool StereoRectifyUncalibrated(
        IEnumerable<Point2d> points1,
        IEnumerable<Point2d> points2,
        double[,] F, Size imgSize,
        out double[,] H1, out double[,] H2,
        double threshold = 5)
    {
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));
        if (F is null)
            throw new ArgumentNullException(nameof(F));
        if (F.GetLength(0) != 3 || F.GetLength(1) != 3)
            throw new ArgumentException("F != double[3,3]");

        var points1Array = points1 as Point2d[] ?? points1.ToArray();
        var points2Array = points2 as Point2d[] ?? points2.ToArray();

        H1 = new double[3, 3];
        H2 = new double[3, 3];

        unsafe
        {
            fixed (double* FPtr = F)
            fixed (double* H1Ptr = H1)
            fixed (double* H2Ptr = H1)
            {
                NativeMethods.HandleException(
                    NativeMethods.stereo_stereoRectifyUncalibrated_array(
                        points1Array, points1Array.Length,
                        points2Array, points2Array.Length,
                        FPtr, imgSize, H1Ptr, H2Ptr, threshold, out var ret));
                return ret != 0;
            }
        }
    }

    /// <summary>
    /// computes the rectification transformations for 3-head camera, where all the heads are on the same line.
    /// </summary>
    /// <param name="cameraMatrix1"></param>
    /// <param name="distCoeffs1"></param>
    /// <param name="cameraMatrix2"></param>
    /// <param name="distCoeffs2"></param>
    /// <param name="cameraMatrix3"></param>
    /// <param name="distCoeffs3"></param>
    /// <param name="imgpt1"></param>
    /// <param name="imgpt3"></param>
    /// <param name="imageSize"></param>
    /// <param name="R12"></param>
    /// <param name="T12"></param>
    /// <param name="R13"></param>
    /// <param name="T13"></param>
    /// <param name="R1"></param>
    /// <param name="R2"></param>
    /// <param name="R3"></param>
    /// <param name="P1"></param>
    /// <param name="P2"></param>
    /// <param name="P3"></param>
    /// <param name="Q"></param>
    /// <param name="alpha"></param>
    /// <param name="newImgSize"></param>
    /// <param name="roi1"></param>
    /// <param name="roi2"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public static float Rectify3Collinear(
        InputArray cameraMatrix1, InputArray distCoeffs1,
        InputArray cameraMatrix2, InputArray distCoeffs2,
        InputArray cameraMatrix3, InputArray distCoeffs3,
        IEnumerable<InputArray> imgpt1, IEnumerable<InputArray> imgpt3,
        Size imageSize, InputArray R12, InputArray T12,
        InputArray R13, InputArray T13,
        OutputArray R1, OutputArray R2, OutputArray R3,
        OutputArray P1, OutputArray P2, OutputArray P3,
        OutputArray Q, double alpha, Size newImgSize,
        out Rect roi1, out Rect roi2, StereoRectificationFlags flags)
    {
        if (cameraMatrix1 is null)
            throw new ArgumentNullException(nameof(cameraMatrix1));
        if (distCoeffs1 is null)
            throw new ArgumentNullException(nameof(distCoeffs1));
        if (cameraMatrix2 is null)
            throw new ArgumentNullException(nameof(cameraMatrix2));
        if (distCoeffs2 is null)
            throw new ArgumentNullException(nameof(distCoeffs2));
        if (cameraMatrix3 is null)
            throw new ArgumentNullException(nameof(cameraMatrix3));
        if (distCoeffs3 is null)
            throw new ArgumentNullException(nameof(distCoeffs3));
        if (imgpt1 is null)
            throw new ArgumentNullException(nameof(imgpt1));
        if (imgpt3 is null)
            throw new ArgumentNullException(nameof(imgpt3));
        if (R12 is null)
            throw new ArgumentNullException(nameof(R12));
        if (T12 is null)
            throw new ArgumentNullException(nameof(T12));
        if (R13 is null)
            throw new ArgumentNullException(nameof(R13));
        if (T13 is null)
            throw new ArgumentNullException(nameof(T13));
        if (R1 is null)
            throw new ArgumentNullException(nameof(R1));
        if (R2 is null)
            throw new ArgumentNullException(nameof(R2));
        if (R3 is null)
            throw new ArgumentNullException(nameof(R3));
        if (P1 is null)
            throw new ArgumentNullException(nameof(P1));
        if (P2 is null)
            throw new ArgumentNullException(nameof(P2));
        if (P3 is null)
            throw new ArgumentNullException(nameof(P3));
        if (Q is null)
            throw new ArgumentNullException(nameof(Q));
        cameraMatrix1.ThrowIfDisposed();
        distCoeffs1.ThrowIfDisposed();
        cameraMatrix2.ThrowIfDisposed();
        distCoeffs2.ThrowIfDisposed();
        cameraMatrix3.ThrowIfDisposed();
        distCoeffs3.ThrowIfDisposed();
        R12.ThrowIfDisposed();
        T12.ThrowIfDisposed();
        R13.ThrowIfDisposed();
        T13.ThrowIfDisposed();
        R1.ThrowIfNotReady();
        R2.ThrowIfNotReady();
        R3.ThrowIfNotReady();
        P1.ThrowIfNotReady();
        P2.ThrowIfNotReady();
        P3.ThrowIfNotReady();
        Q.ThrowIfNotReady();

        var imgpt1Ptrs = imgpt1.Select(x => x.CvPtr).ToArray();
        var imgpt3Ptrs = imgpt3.Select(x => x.CvPtr).ToArray();
        NativeMethods.HandleException(
            NativeMethods.stereo_rectify3Collinear_InputArray(
                cameraMatrix1.CvPtr, distCoeffs1.CvPtr,
                cameraMatrix2.CvPtr, distCoeffs2.CvPtr,
                cameraMatrix3.CvPtr, distCoeffs3.CvPtr,
                imgpt1Ptrs, imgpt1Ptrs.Length, imgpt3Ptrs, imgpt3Ptrs.Length,
                imageSize, R12.CvPtr, T12.CvPtr, R13.CvPtr, T13.CvPtr,
                R1.CvPtr, R2.CvPtr, R3.CvPtr, P1.CvPtr, P2.CvPtr, P3.CvPtr,
                Q.CvPtr, alpha, newImgSize, out roi1, out roi2, (int) flags, out var ret));

        GC.KeepAlive(cameraMatrix1);
        GC.KeepAlive(distCoeffs1);
        GC.KeepAlive(cameraMatrix2);
        GC.KeepAlive(distCoeffs2);
        GC.KeepAlive(cameraMatrix3);
        GC.KeepAlive(distCoeffs3);
        GC.KeepAlive(imgpt1);
        GC.KeepAlive(imgpt3);
        GC.KeepAlive(R12);
        GC.KeepAlive(T12);
        GC.KeepAlive(R13);
        GC.KeepAlive(T13);
        GC.KeepAlive(R1);
        GC.KeepAlive(R2);
        GC.KeepAlive(R3);
        GC.KeepAlive(P1);
        GC.KeepAlive(P2);
        GC.KeepAlive(P3);
        GC.KeepAlive(Q);
        R1.Fix();
        R2.Fix();
        R3.Fix();
        P1.Fix();
        P2.Fix();
        P3.Fix();
        Q.Fix();
        return ret;
    }

    /// <summary>
    /// filters off speckles (small regions of incorrectly computed disparity)
    /// </summary>
    /// <param name="img">The input 16-bit signed disparity image</param>
    /// <param name="newVal">The disparity value used to paint-off the speckles</param>
    /// <param name="maxSpeckleSize">The maximum speckle size to consider it a speckle. Larger blobs are not affected by the algorithm</param>
    /// <param name="maxDiff">Maximum difference between neighbor disparity pixels to put them into the same blob. 
    /// Note that since StereoBM, StereoSGBM and may be other algorithms return a fixed-point disparity map, where disparity values 
    /// are multiplied by 16, this scale factor should be taken into account when specifying this parameter value.</param>
    /// <param name="buf">The optional temporary buffer to avoid memory allocation within the function.</param>
    public static void FilterSpeckles(InputOutputArray img, double newVal, int maxSpeckleSize, double maxDiff,
        InputOutputArray? buf = null)
    {
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        img.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.stereo_filterSpeckles(img.CvPtr, newVal, maxSpeckleSize, maxDiff, ToPtr(buf)));
        GC.KeepAlive(img);
        GC.KeepAlive(buf);
        img.Fix();
    }

    /// <summary>
    /// computes valid disparity ROI from the valid ROIs of the rectified images (that are returned by cv::stereoRectify())
    /// </summary>
    /// <param name="roi1"></param>
    /// <param name="roi2"></param>
    /// <param name="minDisparity"></param>
    /// <param name="numberOfDisparities"></param>
    /// <param name="SADWindowSize"></param>
    /// <returns></returns>
    public static Rect GetValidDisparityROI(Rect roi1, Rect roi2,
        int minDisparity, int numberOfDisparities, int SADWindowSize)
    {
        NativeMethods.HandleException(
            NativeMethods.stereo_getValidDisparityROI(
                roi1, roi2, minDisparity, numberOfDisparities, SADWindowSize, out var ret));
        return ret;
    }

    /// <summary>
    /// validates disparity using the left-right check. The matrix "cost" should be computed by the stereo correspondence algorithm
    /// </summary>
    /// <param name="disparity"></param>
    /// <param name="cost"></param>
    /// <param name="minDisparity"></param>
    /// <param name="numberOfDisparities"></param>
    /// <param name="disp12MaxDisp"></param>
    public static void ValidateDisparity(InputOutputArray disparity, InputArray cost,
        int minDisparity, int numberOfDisparities, int disp12MaxDisp = 1)
    {
        if (disparity is null)
            throw new ArgumentNullException(nameof(disparity));
        if (cost is null)
            throw new ArgumentNullException(nameof(cost));
        disparity.ThrowIfNotReady();
        cost.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.stereo_validateDisparity(
                disparity.CvPtr, cost.CvPtr, minDisparity, numberOfDisparities, disp12MaxDisp));

        disparity.Fix();
        GC.KeepAlive(disparity);
        GC.KeepAlive(cost);
    }

    /// <summary>
    /// reprojects disparity image to 3D: (x,y,d)->(X,Y,Z) using the matrix Q returned by cv::stereoRectify
    /// </summary>
    /// <param name="disparity">Input single-channel 8-bit unsigned, 16-bit signed, 32-bit signed or 32-bit floating-point disparity image.</param>
    /// <param name="_3dImage">Output 3-channel floating-point image of the same size as disparity. 
    /// Each element of _3dImage(x,y) contains 3D coordinates of the point (x,y) computed from the disparity map.</param>
    /// <param name="Q">4 x 4 perspective transformation matrix that can be obtained with stereoRectify().</param>
    /// <param name="handleMissingValues">Indicates, whether the function should handle missing values (i.e. points where the disparity was not computed). 
    /// If handleMissingValues=true, then pixels with the minimal disparity that corresponds to the outliers (see StereoBM::operator() ) are 
    /// transformed to 3D points with a very large Z value (currently set to 10000).</param>
    /// <param name="ddepth">he optional output array depth. If it is -1, the output image will have CV_32F depth. 
    /// ddepth can also be set to CV_16S, CV_32S or CV_32F.</param>
    public static void ReprojectImageTo3D(InputArray disparity,
        OutputArray _3dImage, InputArray Q,
        bool handleMissingValues = false, int ddepth = -1)
    {
        if (disparity is null)
            throw new ArgumentNullException(nameof(disparity));
        if (_3dImage is null)
            throw new ArgumentNullException(nameof(_3dImage));
        if (Q is null)
            throw new ArgumentNullException(nameof(Q));
        disparity.ThrowIfDisposed();
        _3dImage.ThrowIfNotReady();
        Q.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.stereo_reprojectImageTo3D(
                disparity.CvPtr, _3dImage.CvPtr, Q.CvPtr, handleMissingValues ? 1 : 0, ddepth));

        _3dImage.Fix();
        GC.KeepAlive(disparity);
        GC.KeepAlive(_3dImage);
        GC.KeepAlive(Q);
    }
}
