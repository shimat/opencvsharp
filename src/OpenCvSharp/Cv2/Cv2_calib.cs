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
    /// initializes camera matrix from a few 3D points and the corresponding projections.
    /// </summary>
    /// <param name="objectPoints">Vector of vectors (vector&lt;vector&lt;Point3d&gt;&gt;) of the calibration pattern points in the calibration pattern coordinate space. In the old interface all the per-view vectors are concatenated.</param>
    /// <param name="imagePoints">Vector of vectors (vector&lt;vector&lt;Point2d&gt;&gt;) of the projections of the calibration pattern points. In the old interface all the per-view vectors are concatenated.</param>
    /// <param name="imageSize">Image size in pixels used to initialize the principal point.</param>
    /// <param name="aspectRatio">If it is zero or negative, both f_x and f_y are estimated independently. Otherwise, f_x = f_y * aspectRatio .</param>
    /// <returns></returns>
    public static Mat InitCameraMatrix2D(
        IEnumerable<Mat> objectPoints,
        IEnumerable<Mat> imagePoints,
        Size imageSize,
        double aspectRatio = 1.0)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints is null)
            throw new ArgumentNullException(nameof(imagePoints));

        var objectPointsPtrs = objectPoints.Select(x => x.CvPtr).ToArray();
        var imagePointsPtrs = imagePoints.Select(x => x.CvPtr).ToArray();

        NativeMethods.HandleException(
            NativeMethods.calib_initCameraMatrix2D_Mat(
                objectPointsPtrs, objectPointsPtrs.Length,
                imagePointsPtrs, imagePointsPtrs.Length, imageSize, aspectRatio,
                out var matPtr));
        return new Mat(matPtr);
    }

    /// <summary>
    /// initializes camera matrix from a few 3D points and the corresponding projections.
    /// </summary>
    /// <param name="objectPoints">Vector of vectors of the calibration pattern points in the calibration pattern coordinate space. In the old interface all the per-view vectors are concatenated.</param>
    /// <param name="imagePoints">Vector of vectors of the projections of the calibration pattern points. In the old interface all the per-view vectors are concatenated.</param>
    /// <param name="imageSize">Image size in pixels used to initialize the principal point.</param>
    /// <param name="aspectRatio">If it is zero or negative, both f_x and f_y are estimated independently. Otherwise, f_x = f_y * aspectRatio .</param>
    /// <returns></returns>
    public static Mat InitCameraMatrix2D(
        IEnumerable<IEnumerable<Point3f>> objectPoints,
        IEnumerable<IEnumerable<Point2f>> imagePoints,
        Size imageSize,
        double aspectRatio = 1.0)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints is null)
            throw new ArgumentNullException(nameof(imagePoints));

        using var opArray = new ArrayAddress2<Point3f>(objectPoints);
        using var ipArray = new ArrayAddress2<Point2f>(imagePoints);
        NativeMethods.HandleException(
            NativeMethods.calib_initCameraMatrix2D_array(
                opArray.GetPointer(), opArray.GetDim1Length(), opArray.GetDim2Lengths(),
                ipArray.GetPointer(), ipArray.GetDim1Length(), ipArray.GetDim2Lengths(),
                imageSize, aspectRatio, out var matPtr));
        return new Mat(matPtr);
    }

    /// <summary>
    /// Finds the positions of internal corners of the chessboard.
    /// </summary>
    /// <param name="image">Source chessboard view. It must be an 8-bit grayscale or color image.</param>
    /// <param name="patternSize">Number of inner corners per a chessboard row and column 
    /// ( patternSize = Size(points_per_row,points_per_colum) = Size(columns, rows) ).</param>
    /// <param name="corners">Output array of detected corners.</param>
    /// <param name="flags">Various operation flags that can be zero or a combination of the ChessboardFlag values</param>
    /// <returns>The function returns true if all of the corners are found and they are placed in a certain order (row by row, left to right in every row). 
    /// Otherwise, if the function fails to find all the corners or reorder them, it returns false.</returns>
    public static bool FindChessboardCorners(
        InputArray image,
        Size patternSize,
        OutputArray corners,
        ChessboardFlags flags = ChessboardFlags.AdaptiveThresh | ChessboardFlags.NormalizeImage)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (corners is null)
            throw new ArgumentNullException(nameof(corners));
        image.ThrowIfDisposed();
        corners.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.calib_findChessboardCorners_InputArray(
                image.CvPtr, patternSize, corners.CvPtr, (int) flags, out var ret));
        GC.KeepAlive(image);
        corners.Fix();
        return ret != 0;
    }
    /// <summary>
    /// Finds the positions of internal corners of the chessboard.
    /// </summary>
    /// <param name="image">Source chessboard view. It must be an 8-bit grayscale or color image.</param>
    /// <param name="patternSize">Number of inner corners per a chessboard row and column 
    /// ( patternSize = Size(points_per_row,points_per_colum) = Size(columns, rows) ).</param>
    /// <param name="corners">Output array of detected corners.</param>
    /// <param name="flags">Various operation flags that can be zero or a combination of the ChessboardFlag values</param>
    /// <returns>The function returns true if all of the corners are found and they are placed in a certain order (row by row, left to right in every row). 
    /// Otherwise, if the function fails to find all the corners or reorder them, it returns false.</returns>
    public static bool FindChessboardCorners(
        InputArray image,
        Size patternSize,
        out Point2f[] corners,
        ChessboardFlags flags = ChessboardFlags.AdaptiveThresh | ChessboardFlags.NormalizeImage)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        image.ThrowIfDisposed();

        using var cornersVec = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.calib_findChessboardCorners_vector(
                image.CvPtr, patternSize, cornersVec.CvPtr, (int) flags, out var ret));
        GC.KeepAlive(image);
        corners = cornersVec.ToArray();
        return ret != 0;
    }

    /// <summary>
    /// Finds centers in the grid of circles.
    /// </summary>
    /// <param name="image">grid view of input circles; it must be an 8-bit grayscale or color image.</param>
    /// <param name="patternSize">number of circles per row and column ( patternSize = Size(points_per_row, points_per_colum) ).</param>
    /// <param name="centers">output array of detected centers.</param>
    /// <param name="flags">various operation flags that can be one of the FindCirclesGridFlag values</param>
    /// <param name="blobDetector">feature detector that finds blobs like dark circles on light background.</param>
    /// <returns></returns>
    public static bool FindCirclesGrid(
        InputArray image,
        Size patternSize,
        OutputArray centers,
        FindCirclesGridFlags flags = FindCirclesGridFlags.SymmetricGrid,
        FeatureDetector? blobDetector = null)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (centers is null)
            throw new ArgumentNullException(nameof(centers));
        image.ThrowIfDisposed();
        centers.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.calib_findCirclesGrid_InputArray(
                image.CvPtr, patternSize, centers.CvPtr, (int) flags, ToPtr(blobDetector), out var ret));
        GC.KeepAlive(image);
        GC.KeepAlive(centers);
        GC.KeepAlive(blobDetector);
        centers.Fix();
        return ret != 0;
    }

    /// <summary>
    /// Finds centers in the grid of circles.
    /// </summary>
    /// <param name="image">grid view of input circles; it must be an 8-bit grayscale or color image.</param>
    /// <param name="patternSize">number of circles per row and column ( patternSize = Size(points_per_row, points_per_colum) ).</param>
    /// <param name="centers">output array of detected centers.</param>
    /// <param name="flags">various operation flags that can be one of the FindCirclesGridFlag values</param>
    /// <param name="blobDetector">feature detector that finds blobs like dark circles on light background.</param>
    /// <returns></returns>
    public static bool FindCirclesGrid(
        InputArray image,
        Size patternSize,
        out Point2f[] centers,
        FindCirclesGridFlags flags = FindCirclesGridFlags.SymmetricGrid,
        FeatureDetector? blobDetector = null)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        image.ThrowIfDisposed();

        using var centersVec = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.calib_findCirclesGrid_vector(
                image.CvPtr, patternSize, centersVec.CvPtr, (int) flags, ToPtr(blobDetector), out var ret));
        GC.KeepAlive(image);
        GC.KeepAlive(blobDetector);
        centers = centersVec.ToArray();
        return ret != 0;
    }

    /// <summary>
    /// finds intrinsic and extrinsic camera parameters from several fews of a known calibration pattern.
    /// </summary>
    /// <param name="objectPoints">In the new interface it is a vector of vectors of calibration pattern points in the calibration pattern coordinate space. 
    /// The outer vector contains as many elements as the number of the pattern views. If the same calibration pattern is shown in each view and 
    /// it is fully visible, all the vectors will be the same. Although, it is possible to use partially occluded patterns, or even different patterns 
    /// in different views. Then, the vectors will be different. The points are 3D, but since they are in a pattern coordinate system, then, 
    /// if the rig is planar, it may make sense to put the model to a XY coordinate plane so that Z-coordinate of each input object point is 0.
    /// In the old interface all the vectors of object points from different views are concatenated together.</param>
    /// <param name="imagePoints">In the new interface it is a vector of vectors of the projections of calibration pattern points. 
    /// imagePoints.Count() and objectPoints.Count() and imagePoints[i].Count() must be equal to objectPoints[i].Count() for each i.</param>
    /// <param name="imageSize">Size of the image used only to initialize the intrinsic camera matrix.</param>
    /// <param name="cameraMatrix">Output 3x3 floating-point camera matrix. 
    /// If CV_CALIB_USE_INTRINSIC_GUESS and/or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of fx, fy, cx, cy must be 
    /// initialized before calling the function.</param>
    /// <param name="distCoeffs">Output vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements.</param>
    /// <param name="rvecs">Output vector of rotation vectors (see Rodrigues() ) estimated for each pattern view. That is, each k-th rotation vector 
    /// together with the corresponding k-th translation vector (see the next output parameter description) brings the calibration pattern 
    /// from the model coordinate space (in which object points are specified) to the world coordinate space, that is, a real position of the 
    /// calibration pattern in the k-th pattern view (k=0.. M -1)</param>
    /// <param name="tvecs">Output vector of translation vectors estimated for each pattern view.</param>
    /// <param name="flags">Different flags that may be zero or a combination of the CalibrationFlag values</param>
    /// <param name="criteria">Termination criteria for the iterative optimization algorithm.</param>
    /// <returns>Root mean square (RMS) re-projection error. A value below 1.0 is generally considered acceptable for a good calibration.</returns>
    public static double CalibrateCamera(
        IEnumerable<Mat> objectPoints,
        IEnumerable<Mat> imagePoints,
        Size imageSize,
        InputOutputArray cameraMatrix,
        InputOutputArray distCoeffs,
        out Mat[] rvecs,
        out Mat[] tvecs,
        CalibrationFlags flags = CalibrationFlags.None,
        TermCriteria? criteria = null)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints is null)
            throw new ArgumentNullException(nameof(imagePoints));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (distCoeffs is null)
            throw new ArgumentNullException(nameof(distCoeffs));
        cameraMatrix.ThrowIfNotReady();
        distCoeffs.ThrowIfNotReady();

        var criteria0 = criteria.GetValueOrDefault(
            new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 30, Double.Epsilon));

        var objectPointsPtrs = objectPoints.Select(x => x.CvPtr).ToArray();
        var imagePointsPtrs = imagePoints.Select(x => x.CvPtr).ToArray();

        using var rvecsVec = new VectorOfMat();
        using var tvecsVec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.calib_calibrateCamera_InputArray(
                objectPointsPtrs, objectPointsPtrs.Length,
                imagePointsPtrs, objectPointsPtrs.Length,
                imageSize, cameraMatrix.CvPtr, distCoeffs.CvPtr,
                rvecsVec.CvPtr, tvecsVec.CvPtr, (int) flags, criteria0, out var ret));
        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(distCoeffs);
        GC.KeepAlive(objectPoints);
        GC.KeepAlive(imagePoints);
        rvecs = rvecsVec.ToArray();
        tvecs = tvecsVec.ToArray();

        cameraMatrix.Fix();
        distCoeffs.Fix();
        return ret;
    }

    /// <summary>
    /// finds intrinsic and extrinsic camera parameters from several fews of a known calibration pattern.
    /// </summary>
    /// <param name="objectPoints">In the new interface it is a vector of vectors of calibration pattern points in the calibration pattern coordinate space. 
    /// The outer vector contains as many elements as the number of the pattern views. If the same calibration pattern is shown in each view and 
    /// it is fully visible, all the vectors will be the same. Although, it is possible to use partially occluded patterns, or even different patterns 
    /// in different views. Then, the vectors will be different. The points are 3D, but since they are in a pattern coordinate system, then, 
    /// if the rig is planar, it may make sense to put the model to a XY coordinate plane so that Z-coordinate of each input object point is 0.
    /// In the old interface all the vectors of object points from different views are concatenated together.</param>
    /// <param name="imagePoints">In the new interface it is a vector of vectors of the projections of calibration pattern points. 
    /// imagePoints.Count() and objectPoints.Count() and imagePoints[i].Count() must be equal to objectPoints[i].Count() for each i.</param>
    /// <param name="imageSize">Size of the image used only to initialize the intrinsic camera matrix.</param>
    /// <param name="cameraMatrix">Output 3x3 floating-point camera matrix. 
    /// If CV_CALIB_USE_INTRINSIC_GUESS and/or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of fx, fy, cx, cy must be 
    /// initialized before calling the function.</param>
    /// <param name="distCoeffs">Output vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements.</param>
    /// <param name="rvecs">Output vector of rotation vectors (see Rodrigues() ) estimated for each pattern view. That is, each k-th rotation vector 
    /// together with the corresponding k-th translation vector (see the next output parameter description) brings the calibration pattern 
    /// from the model coordinate space (in which object points are specified) to the world coordinate space, that is, a real position of the 
    /// calibration pattern in the k-th pattern view (k=0.. M -1)</param>
    /// <param name="tvecs">Output vector of translation vectors estimated for each pattern view.</param>
    /// <param name="flags">Different flags that may be zero or a combination of the CalibrationFlag values</param>
    /// <param name="criteria">Termination criteria for the iterative optimization algorithm.</param>
    /// <returns>Root mean square (RMS) re-projection error. A value below 1.0 is generally considered acceptable for a good calibration.</returns>
    public static double CalibrateCamera(
        IEnumerable<IEnumerable<Point3f>> objectPoints,
        IEnumerable<IEnumerable<Point2f>> imagePoints,
        Size imageSize,
        double[,] cameraMatrix,
        double[] distCoeffs,
        out Vec3d[] rvecs,
        out Vec3d[] tvecs,
        CalibrationFlags flags = CalibrationFlags.None,
        TermCriteria? criteria = null)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints is null)
            throw new ArgumentNullException(nameof(imagePoints));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (distCoeffs is null)
            throw new ArgumentNullException(nameof(distCoeffs));

        var criteria0 = criteria.GetValueOrDefault(
            new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 30, Double.Epsilon));

        using var op = new ArrayAddress2<Point3f>(objectPoints);
        using var ip = new ArrayAddress2<Point2f>(imagePoints);
        using var rvecsVec = new VectorOfMat();
        using var tvecsVec = new VectorOfMat();
        unsafe
        {
            fixed (double* cameraMatrixPtr = cameraMatrix)
            {
                NativeMethods.HandleException(
                    NativeMethods.calib_calibrateCamera_vector(
                        op.GetPointer(), op.GetDim1Length(), op.GetDim2Lengths(),
                        ip.GetPointer(), ip.GetDim1Length(), ip.GetDim2Lengths(),
                        imageSize, cameraMatrixPtr, distCoeffs, distCoeffs.Length,
                        rvecsVec.CvPtr, tvecsVec.CvPtr, (int) flags, criteria0, out var ret));
                var rvecsM = rvecsVec.ToArray();
                var tvecsM = tvecsVec.ToArray();
                rvecs = rvecsM.Select(m => m.Get<Vec3d>(0)).ToArray();
                tvecs = tvecsM.Select(m => m.Get<Vec3d>(0)).ToArray();
                return ret;
            }
        }
    }

    /// <summary>
    /// Registers a pair of cameras (OpenCV 5), estimating the relative pose (R, T) between them.
    /// The two cameras may use different camera models (pinhole / fisheye).
    /// </summary>
    /// <param name="objectPoints1">Object points observed by the first camera.</param>
    /// <param name="objectPoints2">Object points observed by the second camera.</param>
    /// <param name="imagePoints1">Image points for the first camera.</param>
    /// <param name="imagePoints2">Image points for the second camera.</param>
    /// <param name="cameraMatrix1">Intrinsic matrix of the first camera.</param>
    /// <param name="distCoeffs1">Distortion coefficients of the first camera.</param>
    /// <param name="cameraModel1">Camera model of the first camera.</param>
    /// <param name="cameraMatrix2">Intrinsic matrix of the second camera.</param>
    /// <param name="distCoeffs2">Distortion coefficients of the second camera.</param>
    /// <param name="cameraModel2">Camera model of the second camera.</param>
    /// <param name="r">Input/Output rotation between the first and second camera coordinate systems.</param>
    /// <param name="t">Input/Output translation between the camera coordinate systems.</param>
    /// <param name="e">Output essential matrix.</param>
    /// <param name="f">Output fundamental matrix.</param>
    /// <param name="perViewErrors">Output per-view RMS reprojection errors.</param>
    /// <param name="flags">Operation flags.</param>
    /// <param name="criteria">Termination criteria for the iterative optimization algorithm.</param>
    /// <returns>Overall RMS reprojection error.</returns>
    public static double RegisterCameras(
        IEnumerable<Mat> objectPoints1, IEnumerable<Mat> objectPoints2,
        IEnumerable<Mat> imagePoints1, IEnumerable<Mat> imagePoints2,
        InputArray cameraMatrix1, InputArray distCoeffs1, CameraModel cameraModel1,
        InputArray cameraMatrix2, InputArray distCoeffs2, CameraModel cameraModel2,
        InputOutputArray r, InputOutputArray t, OutputArray e, OutputArray f,
        OutputArray perViewErrors, int flags = 0, TermCriteria? criteria = null)
    {
        if (objectPoints1 is null)
            throw new ArgumentNullException(nameof(objectPoints1));
        if (objectPoints2 is null)
            throw new ArgumentNullException(nameof(objectPoints2));
        if (imagePoints1 is null)
            throw new ArgumentNullException(nameof(imagePoints1));
        if (imagePoints2 is null)
            throw new ArgumentNullException(nameof(imagePoints2));
        if (cameraMatrix1 is null)
            throw new ArgumentNullException(nameof(cameraMatrix1));
        if (distCoeffs1 is null)
            throw new ArgumentNullException(nameof(distCoeffs1));
        if (cameraMatrix2 is null)
            throw new ArgumentNullException(nameof(cameraMatrix2));
        if (distCoeffs2 is null)
            throw new ArgumentNullException(nameof(distCoeffs2));
        if (r is null)
            throw new ArgumentNullException(nameof(r));
        if (t is null)
            throw new ArgumentNullException(nameof(t));
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        if (f is null)
            throw new ArgumentNullException(nameof(f));
        if (perViewErrors is null)
            throw new ArgumentNullException(nameof(perViewErrors));
        cameraMatrix1.ThrowIfDisposed();
        distCoeffs1.ThrowIfDisposed();
        cameraMatrix2.ThrowIfDisposed();
        distCoeffs2.ThrowIfDisposed();
        r.ThrowIfNotReady();
        t.ThrowIfNotReady();
        e.ThrowIfNotReady();
        f.ThrowIfNotReady();
        perViewErrors.ThrowIfNotReady();

        var criteria0 = criteria.GetValueOrDefault(
            new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 100, 1e-6));
        var op1 = objectPoints1.Select(x => x.CvPtr).ToArray();
        var op2 = objectPoints2.Select(x => x.CvPtr).ToArray();
        var ip1 = imagePoints1.Select(x => x.CvPtr).ToArray();
        var ip2 = imagePoints2.Select(x => x.CvPtr).ToArray();

        NativeMethods.HandleException(
            NativeMethods.calib_registerCameras(
                op1, op1.Length, op2, op2.Length, ip1, ip1.Length, ip2, ip2.Length,
                cameraMatrix1.CvPtr, distCoeffs1.CvPtr, (int)cameraModel1,
                cameraMatrix2.CvPtr, distCoeffs2.CvPtr, (int)cameraModel2,
                r.CvPtr, t.CvPtr, e.CvPtr, f.CvPtr, perViewErrors.CvPtr, flags, criteria0, out var ret));

        r.Fix();
        t.Fix();
        e.Fix();
        f.Fix();
        perViewErrors.Fix();
        GC.KeepAlive(cameraMatrix1);
        GC.KeepAlive(distCoeffs1);
        GC.KeepAlive(cameraMatrix2);
        GC.KeepAlive(distCoeffs2);
        GC.KeepAlive(objectPoints1);
        GC.KeepAlive(objectPoints2);
        GC.KeepAlive(imagePoints1);
        GC.KeepAlive(imagePoints2);
        return ret;
    }

    /// <summary>
    /// Estimates intrinsics and extrinsics (camera poses) for a multi-camera system, a.k.a. multi-view
    /// calibration (OpenCV 5).
    /// </summary>
    /// <remarks>
    /// The point matrices must use single-channel CV_32F layout: each object-point matrix is
    /// NUM_POINTS x 3 (CV_32FC1) and each image-point matrix is NUM_POINTS x 2 (CV_32FC1). Partially
    /// observed patterns are supported by setting the unobserved image points to invalid values
    /// (e.g. (-1, -1)) and clearing the corresponding entry in <paramref name="detectionMask"/>.
    /// </remarks>
    /// <param name="objPoints">Calibration pattern object points per frame (each NUM_POINTS x 3, CV_32FC1).</param>
    /// <param name="imagePoints">Detected pattern points per camera then per frame
    /// (NUM_CAMERAS x NUM_FRAMES, each NUM_POINTS x 2, CV_32FC1).</param>
    /// <param name="imageSize">Image resolution for each camera.</param>
    /// <param name="detectionMask">Per-camera per-frame detection mask (NUM_CAMERAS x NUM_FRAMES, CV_8U).</param>
    /// <param name="models">Per-camera camera models (NUM_CAMERAS x 1, CV_8U; see <see cref="CameraModel"/>).</param>
    /// <param name="ks">Output per-camera intrinsic matrices.</param>
    /// <param name="distortions">Output per-camera distortion coefficients.</param>
    /// <param name="rs">Output per-camera rotation matrices relative to camera 0.</param>
    /// <param name="ts">Output per-camera translation vectors relative to camera 0.</param>
    /// <param name="flagsForIntrinsics">Optional per-camera intrinsics-calibration flags (NUM_CAMERAS x 1, CV_32S).</param>
    /// <param name="flags">Common multi-view calibration flags.</param>
    /// <param name="criteria">Termination criteria for the iterative optimization algorithm.</param>
    /// <returns>Overall RMS reprojection error.</returns>
    public static double CalibrateMultiview(
        IEnumerable<Mat> objPoints,
        IReadOnlyList<IReadOnlyList<Mat>> imagePoints,
        IEnumerable<Size> imageSize,
        InputArray detectionMask,
        InputArray models,
        out Mat[] ks, out Mat[] distortions, out Mat[] rs, out Mat[] ts,
        InputArray? flagsForIntrinsics = null,
        int flags = 0,
        TermCriteria? criteria = null)
    {
        if (objPoints is null)
            throw new ArgumentNullException(nameof(objPoints));
        if (imagePoints is null)
            throw new ArgumentNullException(nameof(imagePoints));
        if (imageSize is null)
            throw new ArgumentNullException(nameof(imageSize));
        if (detectionMask is null)
            throw new ArgumentNullException(nameof(detectionMask));
        if (models is null)
            throw new ArgumentNullException(nameof(models));
        detectionMask.ThrowIfDisposed();
        models.ThrowIfDisposed();
        flagsForIntrinsics?.ThrowIfDisposed();

        var criteria0 = criteria.GetValueOrDefault(
            new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 100, double.Epsilon));

        var objPointsPtrs = objPoints.Select(x => x.CvPtr).ToArray();

        var framesPerCamera = new int[imagePoints.Count];
        var flatImagePoints = new List<IntPtr>();
        for (var c = 0; c < imagePoints.Count; c++)
        {
            var frames = imagePoints[c];
            framesPerCamera[c] = frames.Count;
            for (var fr = 0; fr < frames.Count; fr++)
                flatImagePoints.Add(frames[fr].CvPtr);
        }

        var imageSizeArray = imageSize as Size[] ?? imageSize.ToArray();

        using var ksVec = new VectorOfMat();
        using var distVec = new VectorOfMat();
        using var rsVec = new VectorOfMat();
        using var tsVec = new VectorOfMat();

        NativeMethods.HandleException(
            NativeMethods.calib_calibrateMultiview(
                objPointsPtrs, objPointsPtrs.Length,
                flatImagePoints.ToArray(), framesPerCamera.Length, framesPerCamera,
                imageSizeArray, imageSizeArray.Length,
                detectionMask.CvPtr, models.CvPtr,
                ksVec.CvPtr, distVec.CvPtr, rsVec.CvPtr, tsVec.CvPtr,
                ToPtr(flagsForIntrinsics), flags, criteria0, out var ret));

        ks = ksVec.ToArray();
        distortions = distVec.ToArray();
        rs = rsVec.ToArray();
        ts = tsVec.ToArray();

        GC.KeepAlive(objPoints);
        GC.KeepAlive(imagePoints);
        GC.KeepAlive(detectionMask);
        GC.KeepAlive(models);
        GC.KeepAlive(flagsForIntrinsics);
        return ret;
    }

    /// <summary>
    /// finds intrinsic and extrinsic parameters of a stereo camera
    /// </summary>
    /// <param name="objectPoints">Vector of vectors of the calibration pattern points.</param>
    /// <param name="imagePoints1">Vector of vectors of the projections of the calibration pattern points, observed by the first camera.</param>
    /// <param name="imagePoints2">Vector of vectors of the projections of the calibration pattern points, observed by the second camera.</param>
    /// <param name="cameraMatrix1">Input/output first camera matrix</param>
    /// <param name="distCoeffs1">Input/output vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// The output vector length depends on the flags.</param>
    /// <param name="cameraMatrix2"> Input/output second camera matrix. The parameter is similar to cameraMatrix1 .</param>
    /// <param name="distCoeffs2">Input/output lens distortion coefficients for the second camera. The parameter is similar to distCoeffs1 .</param>
    /// <param name="imageSize">Size of the image used only to initialize intrinsic camera matrix.</param>
    /// <param name="R">Output rotation matrix between the 1st and the 2nd camera coordinate systems.</param>
    /// <param name="T">Output translation vector between the coordinate systems of the cameras.</param>
    /// <param name="E">Output essential matrix.</param>
    /// <param name="F">Output fundamental matrix.</param>
    /// <param name="criteria">Termination criteria for the iterative optimization algorithm.</param>
    /// <param name="flags">Different flags that may be zero or a combination of the CalibrationFlag values</param>
    /// <returns></returns>
    public static double StereoCalibrate(
        IEnumerable<InputArray> objectPoints,
        IEnumerable<InputArray> imagePoints1,
        IEnumerable<InputArray> imagePoints2,
        InputOutputArray cameraMatrix1, InputOutputArray distCoeffs1,
        InputOutputArray cameraMatrix2, InputOutputArray distCoeffs2,
        Size imageSize, OutputArray R,
        OutputArray T, OutputArray E, OutputArray F,
        CalibrationFlags flags = CalibrationFlags.FixIntrinsic,
        TermCriteria? criteria = null)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints1 is null)
            throw new ArgumentNullException(nameof(imagePoints1));
        if (imagePoints2 is null)
            throw new ArgumentNullException(nameof(imagePoints2));
        if (cameraMatrix1 is null)
            throw new ArgumentNullException(nameof(cameraMatrix1));
        if (distCoeffs1 is null)
            throw new ArgumentNullException(nameof(distCoeffs1));
        if (cameraMatrix2 is null)
            throw new ArgumentNullException(nameof(cameraMatrix2));
        if (distCoeffs2 is null)
            throw new ArgumentNullException(nameof(distCoeffs2));
        cameraMatrix1.ThrowIfDisposed();
        distCoeffs1.ThrowIfDisposed();
        cameraMatrix2.ThrowIfDisposed();
        distCoeffs2.ThrowIfDisposed();
        cameraMatrix1.ThrowIfNotReady();
        cameraMatrix2.ThrowIfNotReady();
        distCoeffs1.ThrowIfNotReady();
        distCoeffs2.ThrowIfNotReady();

        var opPtrs = objectPoints.Select(x => x.CvPtr).ToArray();
        var ip1Ptrs = imagePoints1.Select(x => x.CvPtr).ToArray();
        var ip2Ptrs = imagePoints2.Select(x => x.CvPtr).ToArray();

        var criteria0 = criteria.GetValueOrDefault(
            new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 30, 1e-6));

        NativeMethods.HandleException(
            NativeMethods.calib_stereoCalibrate_InputArray(
                opPtrs, opPtrs.Length,
                ip1Ptrs, ip1Ptrs.Length, ip2Ptrs, ip2Ptrs.Length,
                cameraMatrix1.CvPtr, distCoeffs1.CvPtr,
                cameraMatrix2.CvPtr, distCoeffs2.CvPtr,
                imageSize, ToPtr(R), ToPtr(T), ToPtr(E), ToPtr(F),
                (int) flags, criteria0, out var ret));

        GC.KeepAlive(cameraMatrix1);
        GC.KeepAlive(distCoeffs1);
        GC.KeepAlive(cameraMatrix2);
        GC.KeepAlive(distCoeffs2);
        GC.KeepAlive(R);
        GC.KeepAlive(T);
        GC.KeepAlive(E);
        GC.KeepAlive(F);
        GC.KeepAlive(objectPoints);
        GC.KeepAlive(imagePoints1);
        GC.KeepAlive(imagePoints2);
        cameraMatrix1.Fix();
        distCoeffs1.Fix();
        cameraMatrix2.Fix();
        distCoeffs2.Fix();
        R.Fix();
        T.Fix();
        E.Fix();
        F.Fix();

        return ret;
    }

    /// <summary>
    /// finds intrinsic and extrinsic parameters of a stereo camera
    /// </summary>
    /// <param name="objectPoints">Vector of vectors of the calibration pattern points.</param>
    /// <param name="imagePoints1">Vector of vectors of the projections of the calibration pattern points, observed by the first camera.</param>
    /// <param name="imagePoints2">Vector of vectors of the projections of the calibration pattern points, observed by the second camera.</param>
    /// <param name="cameraMatrix1">Input/output first camera matrix</param>
    /// <param name="distCoeffs1">Input/output vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// The output vector length depends on the flags.</param>
    /// <param name="cameraMatrix2"> Input/output second camera matrix. The parameter is similar to cameraMatrix1 .</param>
    /// <param name="distCoeffs2">Input/output lens distortion coefficients for the second camera. The parameter is similar to distCoeffs1 .</param>
    /// <param name="imageSize">Size of the image used only to initialize intrinsic camera matrix.</param>
    /// <param name="R">Output rotation matrix between the 1st and the 2nd camera coordinate systems.</param>
    /// <param name="T">Output translation vector between the coordinate systems of the cameras.</param>
    /// <param name="E">Output essential matrix.</param>
    /// <param name="F">Output fundamental matrix.</param>
    /// <param name="criteria">Termination criteria for the iterative optimization algorithm.</param>
    /// <param name="flags">Different flags that may be zero or a combination of the CalibrationFlag values</param>
    /// <returns></returns>
    public static double StereoCalibrate(
        IEnumerable<Mat> objectPoints,
        IEnumerable<Mat> imagePoints1,
        IEnumerable<Mat> imagePoints2,
        Mat cameraMatrix1, Mat distCoeffs1,
        Mat cameraMatrix2, Mat distCoeffs2,
        Size imageSize, Mat R, Mat T, Mat E, Mat F,
        CalibrationFlags flags = CalibrationFlags.FixIntrinsic,
        TermCriteria? criteria = null)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints1 is null)
            throw new ArgumentNullException(nameof(imagePoints1));
        if (imagePoints2 is null)
            throw new ArgumentNullException(nameof(imagePoints2));
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
        if (E is null)
            throw new ArgumentNullException(nameof(E));
        if (F is null)
            throw new ArgumentNullException(nameof(F));

        var opPtrs = objectPoints.Select(x => x.CvPtr).ToArray();
        var ip1Ptrs = imagePoints1.Select(x => x.CvPtr).ToArray();
        var ip2Ptrs = imagePoints2.Select(x => x.CvPtr).ToArray();

        var criteria0 = criteria.GetValueOrDefault(
            new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 30, 1e-6));

        NativeMethods.HandleException(
            NativeMethods.calib_stereoCalibrate_Mat(
                opPtrs, opPtrs.Length,
                ip1Ptrs, ip1Ptrs.Length,
                ip2Ptrs, ip2Ptrs.Length,
                cameraMatrix1.CvPtr, distCoeffs1.CvPtr,
                cameraMatrix2.CvPtr, distCoeffs2.CvPtr,
                imageSize, R.CvPtr, T.CvPtr, E.CvPtr, F.CvPtr,
                (int)flags, criteria0, out var ret));

        GC.KeepAlive(objectPoints);
        GC.KeepAlive(imagePoints1);
        GC.KeepAlive(imagePoints2);
        GC.KeepAlive(cameraMatrix1);
        GC.KeepAlive(distCoeffs1);
        GC.KeepAlive(cameraMatrix2);
        GC.KeepAlive(distCoeffs2);
        GC.KeepAlive(R);
        GC.KeepAlive(T);
        GC.KeepAlive(E);
        GC.KeepAlive(F);

        return ret;
    }

    /// <summary>
    /// finds intrinsic and extrinsic parameters of a stereo camera
    /// </summary>
    /// <param name="objectPoints">Vector of vectors of the calibration pattern points.</param>
    /// <param name="imagePoints1">Vector of vectors of the projections of the calibration pattern points, observed by the first camera.</param>
    /// <param name="imagePoints2">Vector of vectors of the projections of the calibration pattern points, observed by the second camera.</param>
    /// <param name="cameraMatrix1">Input/output first camera matrix</param>
    /// <param name="distCoeffs1">Input/output vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// The output vector length depends on the flags.</param>
    /// <param name="cameraMatrix2"> Input/output second camera matrix. The parameter is similar to cameraMatrix1 .</param>
    /// <param name="distCoeffs2">Input/output lens distortion coefficients for the second camera. The parameter is similar to distCoeffs1 .</param>
    /// <param name="imageSize">Size of the image used only to initialize intrinsic camera matrix.</param>
    /// <param name="R">Output rotation matrix between the 1st and the 2nd camera coordinate systems.</param>
    /// <param name="T">Output translation vector between the coordinate systems of the cameras.</param>
    /// <param name="E">Output essential matrix.</param>
    /// <param name="F">Output fundamental matrix.</param>
    /// <param name="criteria">Termination criteria for the iterative optimization algorithm.</param>
    /// <param name="flags">Different flags that may be zero or a combination of the CalibrationFlag values</param>
    /// <returns></returns>
    public static double StereoCalibrate(
        IEnumerable<IEnumerable<Point3f>> objectPoints,
        IEnumerable<IEnumerable<Point2f>> imagePoints1,
        IEnumerable<IEnumerable<Point2f>> imagePoints2,
        double[,] cameraMatrix1, double[] distCoeffs1,
        double[,] cameraMatrix2, double[] distCoeffs2,
        Size imageSize, OutputArray R,
        OutputArray T, OutputArray E, OutputArray F,
        CalibrationFlags flags = CalibrationFlags.FixIntrinsic,
        TermCriteria? criteria = null)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints1 is null)
            throw new ArgumentNullException(nameof(imagePoints1));
        if (imagePoints2 is null)
            throw new ArgumentNullException(nameof(imagePoints2));
        if (cameraMatrix1 is null)
            throw new ArgumentNullException(nameof(cameraMatrix1));
        if (distCoeffs1 is null)
            throw new ArgumentNullException(nameof(distCoeffs1));
        if (cameraMatrix2 is null)
            throw new ArgumentNullException(nameof(cameraMatrix2));
        if (distCoeffs2 is null)
            throw new ArgumentNullException(nameof(distCoeffs2));

        var criteria0 = criteria.GetValueOrDefault(
            new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 30, 1e-6));

        using var op = new ArrayAddress2<Point3f>(objectPoints);
        using var ip1 = new ArrayAddress2<Point2f>(imagePoints1);
        using var ip2 = new ArrayAddress2<Point2f>(imagePoints2);
        unsafe
        {
            fixed (double* cameraMatrix1Ptr = cameraMatrix1)
            fixed (double* cameraMatrix2Ptr = cameraMatrix2)
            {
                NativeMethods.HandleException(
                    NativeMethods.calib_stereoCalibrate_array(
                        op.GetPointer(), op.GetDim1Length(), op.GetDim2Lengths(),
                        ip1.GetPointer(), ip1.GetDim1Length(), ip1.GetDim2Lengths(),
                        ip2.GetPointer(), ip2.GetDim1Length(), ip2.GetDim2Lengths(),
                        cameraMatrix1Ptr, distCoeffs1, distCoeffs1.Length,
                        cameraMatrix2Ptr, distCoeffs2, distCoeffs2.Length,
                        imageSize, ToPtr(R), ToPtr(T), ToPtr(E), ToPtr(F),
                        (int) flags, criteria0, out var ret));
                GC.KeepAlive(R);
                GC.KeepAlive(T);
                GC.KeepAlive(E);
                GC.KeepAlive(F);
                return ret;
            }
        }
    }

    /// <summary>
    /// Computes Hand-Eye calibration.
    /// 
    /// The function performs the Hand-Eye calibration using various methods. One approach consists in estimating the
    /// rotation then the translation(separable solutions) and the following methods are implemented:
    /// - R.Tsai, R.Lenz A New Technique for Fully Autonomous and Efficient 3D Robotics Hand/EyeCalibration \cite Tsai89
    /// - F.Park, B.Martin Robot Sensor Calibration: Solving AX = XB on the Euclidean Group \cite Park94
    /// - R.Horaud, F.Dornaika Hand-Eye Calibration \cite Horaud95
    ///
    /// Another approach consists in estimating simultaneously the rotation and the translation(simultaneous solutions),
    /// with the following implemented method:
    /// - N.Andreff, R.Horaud, B.Espiau On-line Hand-Eye Calibration \cite Andreff99
    /// - K.Daniilidis Hand-Eye Calibration Using Dual Quaternions \cite Daniilidis98
    /// </summary>
    /// <param name="R_gripper2base">Rotation part extracted from the homogeneous matrix that
    /// transforms a pointexpressed in the gripper frame to the robot base frame that contains the rotation
    /// matrices for all the transformationsfrom gripper frame to robot base frame.</param>
    /// <param name="t_gripper2base">Translation part extracted from the homogeneous matrix that transforms a point
    /// expressed in the gripper frame to the robot base frame.
    /// This is a vector(`vector&lt;Mat&gt;`) that contains the translation vectors for all the transformations
    /// from gripper frame to robot base frame.</param>
    /// <param name="R_target2cam">Rotation part extracted from the homogeneous matrix that transforms a point
    /// expressed in the target frame to the camera frame.
    /// This is a vector(`vector&lt;Mat&gt;`) that contains the rotation matrices for all the transformations
    /// from calibration target frame to camera frame.</param>
    /// <param name="t_target2cam">Rotation part extracted from the homogeneous matrix that transforms a point
    /// expressed in the target frame to the camera frame.
    /// This is a vector(`vector&lt;Mat&gt;`) that contains the translation vectors for all the transformations
    /// from calibration target frame to camera frame.</param>
    /// <param name="R_cam2gripper">Estimated rotation part extracted from the homogeneous matrix that transforms a point
    /// expressed in the camera frame to the gripper frame.</param>
    /// <param name="t_cam2gripper">Estimated translation part extracted from the homogeneous matrix that transforms a point
    /// expressed in the camera frame to the gripper frame.</param>
    /// <param name="method">One of the implemented Hand-Eye calibration method</param>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static void CalibrateHandEye(
        IEnumerable<Mat> R_gripper2base,
        IEnumerable<Mat> t_gripper2base,
        IEnumerable<Mat> R_target2cam,
        IEnumerable<Mat> t_target2cam,
        OutputArray R_cam2gripper,
        OutputArray t_cam2gripper,
        HandEyeCalibrationMethod method = HandEyeCalibrationMethod.TSAI)
    {
        if (R_gripper2base is null)
            throw new ArgumentNullException(nameof(R_gripper2base));
        if (t_gripper2base is null)
            throw new ArgumentNullException(nameof(t_gripper2base));
        if (R_target2cam is null)
            throw new ArgumentNullException(nameof(R_target2cam));
        if (t_target2cam is null)
            throw new ArgumentNullException(nameof(t_target2cam));
        if (R_cam2gripper is null)
            throw new ArgumentNullException(nameof(R_cam2gripper));
        if (t_cam2gripper is null)
            throw new ArgumentNullException(nameof(t_cam2gripper));
        R_cam2gripper.ThrowIfNotReady();
        t_cam2gripper.ThrowIfNotReady();

        var R_gripper2baseArray = R_gripper2base as Mat[] ?? R_gripper2base.ToArray();
        var t_gripper2baseArray = t_gripper2base as Mat[] ?? t_gripper2base.ToArray();
        var R_target2camArray = R_target2cam as Mat[] ?? R_target2cam.ToArray();
        var t_target2camArray = t_target2cam as Mat[] ?? t_target2cam.ToArray();
        if (R_gripper2baseArray.Length == 0)
            throw new ArgumentException("Empty sequence", nameof(R_gripper2base));
        if (t_gripper2baseArray.Length == 0)
            throw new ArgumentException("Empty sequence", nameof(t_gripper2base));
        if (R_target2camArray.Length == 0)
            throw new ArgumentException("Empty sequence", nameof(R_target2cam));
        if (t_target2camArray.Length == 0)
            throw new ArgumentException("Empty sequence", nameof(t_target2cam));

        var R_gripper2basePtrArray = R_gripper2baseArray.Select(m => m.CvPtr).ToArray();
        var t_gripper2basePtrArray = t_gripper2baseArray.Select(m => m.CvPtr).ToArray();
        var R_target2camPtrArray = R_target2camArray.Select(m => m.CvPtr).ToArray();
        var t_target2camPtrArray = t_target2camArray.Select(m => m.CvPtr).ToArray();
        NativeMethods.HandleException(
            NativeMethods.calib_calibrateHandEye(
                R_gripper2basePtrArray, R_gripper2basePtrArray.Length,
                t_gripper2basePtrArray, t_gripper2basePtrArray.Length,
                R_target2camPtrArray, R_target2camPtrArray.Length,
                t_target2camPtrArray, t_target2camPtrArray.Length,
                R_cam2gripper.CvPtr, t_cam2gripper.CvPtr, (int)method));

        GC.KeepAlive(R_gripper2base);
        GC.KeepAlive(t_gripper2base);
        GC.KeepAlive(R_target2cam);
        GC.KeepAlive(t_target2cam);
        R_cam2gripper.Fix();
        t_cam2gripper.Fix();

        foreach (var mat in R_gripper2baseArray) GC.KeepAlive(mat);
        foreach (var mat in t_gripper2baseArray) GC.KeepAlive(mat);
        foreach (var mat in R_target2camArray) GC.KeepAlive(mat);
        foreach (var mat in t_target2camArray) GC.KeepAlive(mat);
    }

    /// <summary>
    /// Computes Robot-World/Hand-Eye calibration.
    /// The function performs the Robot-World/Hand-Eye calibration using various methods. One approach consists in estimating the
    /// rotation then the translation(separable solutions):
    /// - M.Shah, Solving the robot-world/hand-eye calibration problem using the kronecker product \cite Shah2013SolvingTR
    /// </summary>
    /// <param name="R_world2cam">[in] R_world2cam Rotation part extracted from the homogeneous matrix that transforms a point
    /// expressed in the world frame to the camera frame. This is a vector of Mat that contains the rotation,
    /// `(3x3)` rotation matrices or `(3x1)` rotation vectors,for all the transformations from world frame to the camera frame.</param>
    /// <param name="t_world2cam">[in] Translation part extracted from the homogeneous matrix that transforms a point
    /// expressed in the world frame to the camera frame. This is a vector (`vector&lt;Mat&gt;`) that contains the `(3x1)`
    /// translation vectors for all the transformations from world frame to the camera frame.</param>
    /// <param name="R_base2gripper">[in] Rotation part extracted from the homogeneous matrix that transforms a point expressed
    /// in the robot base frame to the gripper frame. This is a vector (`vector&lt;Mat&gt;`) that contains the rotation,
    /// `(3x3)` rotation matrices or `(3x1)` rotation vectors, for all the transformations from robot base frame to the gripper frame.</param>
    /// <param name="t_base2gripper">[in] Rotation part extracted from the homogeneous matrix that transforms a point
    /// expressed in the robot base frame to the gripper frame. This is a vector (`vector&lt;Mat&gt;`) that contains the
    /// `(3x1)` translation vectors for all the transformations from robot base frame to the gripper frame.</param>
    /// <param name="R_base2world">[out] R_base2world Estimated `(3x3)` rotation part extracted from the homogeneous matrix
    /// that transforms a point expressed in the robot base frame to the world frame.</param>
    /// <param name="t_base2world">[out] t_base2world Estimated `(3x1)` translation part extracted from the homogeneous matrix
    /// that transforms a point expressed in the robot base frame to the world frame.</param>
    /// <param name="R_gripper2cam">[out] R_gripper2cam Estimated `(3x3)` rotation part extracted from the homogeneous matrix
    /// that transforms a point expressed in the gripper frame to the camera frame.</param>
    /// <param name="t_gripper2cam">[out] Estimated `(3x1)` translation part extracted from the homogeneous matrix that
    /// transforms a pointexpressed in the gripper frame to the camera frame.</param>
    /// <param name="method">One of the implemented Robot-World/Hand-Eye calibration method</param>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static void CalibrateRobotWorldHandEye(
        IEnumerable<Mat> R_world2cam,
        IEnumerable<Mat> t_world2cam,
        IEnumerable<Mat> R_base2gripper,
        IEnumerable<Mat> t_base2gripper,
        OutputArray R_base2world, 
        OutputArray t_base2world,
        OutputArray R_gripper2cam,
        OutputArray t_gripper2cam,
        RobotWorldHandEyeCalibrationMethod method = RobotWorldHandEyeCalibrationMethod.SHAH)
    {
        if (R_world2cam is null)
            throw new ArgumentNullException(nameof(R_world2cam));
        if (t_world2cam is null)
            throw new ArgumentNullException(nameof(t_world2cam));
        if (R_base2gripper is null)
            throw new ArgumentNullException(nameof(R_base2gripper));
        if (t_base2gripper is null)
            throw new ArgumentNullException(nameof(t_base2gripper));
        if (R_base2world is null)
            throw new ArgumentNullException(nameof(R_base2world));
        if (t_base2world is null)
            throw new ArgumentNullException(nameof(t_base2world));
        if (R_gripper2cam is null)
            throw new ArgumentNullException(nameof(R_gripper2cam));
        if (t_gripper2cam is null)
            throw new ArgumentNullException(nameof(t_gripper2cam));
        R_base2world.ThrowIfNotReady();
        t_base2world.ThrowIfNotReady();
        R_gripper2cam.ThrowIfNotReady();
        t_gripper2cam.ThrowIfNotReady();
        var R_world2camArray = R_world2cam as Mat[] ?? R_world2cam.ToArray();
        var t_world2camArray = t_world2cam as Mat[] ?? t_world2cam.ToArray();
        var R_base2gripperArray = R_base2gripper as Mat[] ?? R_base2gripper.ToArray();
        var t_base2gripperArray = t_base2gripper as Mat[] ?? t_base2gripper.ToArray();
        if (R_world2camArray.Length == 0)
            throw new ArgumentException("Empty sequence", nameof(R_world2cam));
        if (t_world2camArray.Length == 0)
            throw new ArgumentException("Empty sequence", nameof(t_world2cam));
        if (R_base2gripperArray.Length == 0)
            throw new ArgumentException("Empty sequence", nameof(R_base2gripper));
        if (t_base2gripperArray.Length == 0)
            throw new ArgumentException("Empty sequence", nameof(t_base2gripper));

        var R_base2worldPtrArray = R_world2camArray.Select(m => m.CvPtr).ToArray();
        var t_world2camPtrArray = t_world2camArray.Select(m => m.CvPtr).ToArray();
        var R_base2gripperPtrArray = R_base2gripperArray.Select(m => m.CvPtr).ToArray();
        var t_base2gripperPtrArray = t_base2gripperArray.Select(m => m.CvPtr).ToArray();
        NativeMethods.HandleException(
            NativeMethods.calib_calibrateRobotWorldHandEye_OutputArray(
                R_base2worldPtrArray, R_base2worldPtrArray.Length,
                t_world2camPtrArray, t_world2camPtrArray.Length,
                R_base2gripperPtrArray, R_base2gripperPtrArray.Length,
                t_base2gripperPtrArray, t_base2gripperPtrArray.Length,
                R_base2world.CvPtr, t_base2world.CvPtr, R_gripper2cam.CvPtr, t_gripper2cam.CvPtr,
                (int)method));

        R_base2world.Fix();
        t_base2world.Fix();
        R_gripper2cam.Fix();
        t_gripper2cam.Fix();
        foreach (var mat in R_world2camArray) GC.KeepAlive(mat);
        foreach (var mat in t_world2camArray) GC.KeepAlive(mat);
        foreach (var mat in R_base2gripperArray) GC.KeepAlive(mat);
        foreach (var mat in t_base2gripperArray) GC.KeepAlive(mat);
    }

    /// <summary>
    /// omputes Robot-World/Hand-Eye calibration.
    /// The function performs the Robot-World/Hand-Eye calibration using various methods. One approach consists in estimating the
    /// rotation then the translation(separable solutions):
    /// - M.Shah, Solving the robot-world/hand-eye calibration problem using the kronecker product \cite Shah2013SolvingTR
    /// </summary>
    /// <param name="R_world2cam">[in] R_world2cam Rotation part extracted from the homogeneous matrix that transforms a point
    /// expressed in the world frame to the camera frame. This is a vector of Mat that contains the rotation,
    /// `(3x3)` rotation matrices or `(3x1)` rotation vectors,for all the transformations from world frame to the camera frame.</param>
    /// <param name="t_world2cam">[in] Translation part extracted from the homogeneous matrix that transforms a point
    /// expressed in the world frame to the camera frame. This is a vector (`vector&lt;Mat&gt;`) that contains the `(3x1)`
    /// translation vectors for all the transformations from world frame to the camera frame.</param>
    /// <param name="R_base2gripper">[in] Rotation part extracted from the homogeneous matrix that transforms a point expressed
    /// in the robot base frame to the gripper frame. This is a vector (`vector&lt;Mat&gt;`) that contains the rotation,
    /// `(3x3)` rotation matrices or `(3x1)` rotation vectors, for all the transformations from robot base frame to the gripper frame.</param>
    /// <param name="t_base2gripper">[in] Rotation part extracted from the homogeneous matrix that transforms a point
    /// expressed in the robot base frame to the gripper frame. This is a vector (`vector&lt;Mat&gt;`) that contains the
    /// `(3x1)` translation vectors for all the transformations from robot base frame to the gripper frame.</param>
    /// <param name="R_base2world">[out] R_base2world Estimated `(3x3)` rotation part extracted from the homogeneous matrix
    /// that transforms a point expressed in the robot base frame to the world frame.</param>
    /// <param name="t_base2world">[out] t_base2world Estimated `(3x1)` translation part extracted from the homogeneous matrix
    /// that transforms a point expressed in the robot base frame to the world frame.</param>
    /// <param name="R_gripper2cam">[out] R_gripper2cam Estimated `(3x3)` rotation part extracted from the homogeneous matrix
    /// that transforms a point expressed in the gripper frame to the camera frame.</param>
    /// <param name="t_gripper2cam">[out] Estimated `(3x1)` translation part extracted from the homogeneous matrix that
    /// transforms a pointexpressed in the gripper frame to the camera frame.</param>
    /// <param name="method">One of the implemented Robot-World/Hand-Eye calibration method</param>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static void CalibrateRobotWorldHandEye(
        IEnumerable<Mat> R_world2cam,
        IEnumerable<Mat> t_world2cam,
        IEnumerable<Mat> R_base2gripper,
        IEnumerable<Mat> t_base2gripper,
        out double[,] R_base2world,
        out double[] t_base2world,
        out double[,] R_gripper2cam,
        out double[] t_gripper2cam,
        RobotWorldHandEyeCalibrationMethod method = RobotWorldHandEyeCalibrationMethod.SHAH)
    {
        if (R_world2cam is null)
            throw new ArgumentNullException(nameof(R_world2cam));
        if (t_world2cam is null)
            throw new ArgumentNullException(nameof(t_world2cam));
        if (R_base2gripper is null)
            throw new ArgumentNullException(nameof(R_base2gripper));
        if (t_base2gripper is null)
            throw new ArgumentNullException(nameof(t_base2gripper));
        var R_world2camArray = R_world2cam as Mat[] ?? R_world2cam.ToArray();
        var t_world2camArray = t_world2cam as Mat[] ?? t_world2cam.ToArray();
        var R_base2gripperArray = R_base2gripper as Mat[] ?? R_base2gripper.ToArray();
        var t_base2gripperArray = t_base2gripper as Mat[] ?? t_base2gripper.ToArray();
        if (R_world2camArray.Length == 0)
            throw new ArgumentException("Empty sequence", nameof(R_world2cam));
        if (t_world2camArray.Length == 0)
            throw new ArgumentException("Empty sequence", nameof(t_world2cam));
        if (R_base2gripperArray.Length == 0)
            throw new ArgumentException("Empty sequence", nameof(R_base2gripper));
        if (t_base2gripperArray.Length == 0)
            throw new ArgumentException("Empty sequence", nameof(t_base2gripper));

        var R_base2worldPtrArray = R_world2camArray.Select(m => m.CvPtr).ToArray();
        var t_world2camPtrArray = t_world2camArray.Select(m => m.CvPtr).ToArray();
        var R_base2gripperPtrArray = R_base2gripperArray.Select(m => m.CvPtr).ToArray();
        var t_base2gripperPtrArray = t_base2gripperArray.Select(m => m.CvPtr).ToArray();
        R_base2world = new double[3, 3];
        t_base2world = new double[3];
        R_gripper2cam = new double[3, 3];
        t_gripper2cam = new double[3];
        NativeMethods.HandleException(
            NativeMethods.calib_calibrateRobotWorldHandEye_Pointer(
                R_base2worldPtrArray, R_base2worldPtrArray.Length,
                t_world2camPtrArray, t_world2camPtrArray.Length,
                R_base2gripperPtrArray, R_base2gripperPtrArray.Length,
                t_base2gripperPtrArray, t_base2gripperPtrArray.Length,
                R_base2world, t_base2world, R_gripper2cam, t_gripper2cam,
                (int) method));
            
        foreach (var mat in R_world2camArray) GC.KeepAlive(mat);
        foreach (var mat in t_world2camArray) GC.KeepAlive(mat);
        foreach (var mat in R_base2gripperArray) GC.KeepAlive(mat);
        foreach (var mat in t_base2gripperArray) GC.KeepAlive(mat);
    }
}
