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
    /// converts rotation vector to rotation matrix or vice versa using Rodrigues transformation
    /// </summary>
    /// <param name="src">Input rotation vector (3x1 or 1x3) or rotation matrix (3x3).</param>
    /// <param name="dst">Output rotation matrix (3x3) or rotation vector (3x1 or 1x3), respectively.</param>
    /// <param name="jacobian">Optional output Jacobian matrix, 3x9 or 9x3, which is a matrix of partial derivatives of the output array components with respect to the input array components.</param>
    public static void Rodrigues(InputArray src, OutputArray dst, OutputArray? jacobian = null)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_Rodrigues(src.CvPtr, dst.CvPtr, ToPtr(jacobian)));

        GC.KeepAlive(src);
        GC.KeepAlive(dst);
        GC.KeepAlive(jacobian);
        dst.Fix();
        jacobian?.Fix();
    }

    /// <summary>
    /// converts rotation vector to rotation matrix using Rodrigues transformation
    /// </summary>
    /// <param name="vector">Input rotation vector (3x1).</param>
    /// <param name="matrix">Output rotation matrix (3x3).</param>
    /// <param name="jacobian">Optional output Jacobian matrix, 3x9, which is a matrix of partial derivatives of the output array components with respect to the input array components.</param>
    public static void Rodrigues(double[] vector, out double[,] matrix, out double[,] jacobian)
    {
        if (vector is null)
            throw new ArgumentNullException(nameof(vector));
        if (vector.Length != 3)
            throw new ArgumentException("Length != 3", nameof(vector));

        using var vectorM = Mat.FromPixelData(3, 1, MatType.CV_64FC1, vector);
        using var matrixM = new Mat<double>();
        using var jacobianM = new Mat<double>();
        using var vectorInputArray = InputArray.Create(vectorM);
        using var matrixOutputArray = OutputArray.Create(matrixM);
        using var jacobianOutputArray = OutputArray.Create(jacobianM);
        Rodrigues(vectorInputArray, matrixOutputArray, jacobianOutputArray);
        matrix = matrixM.ToRectangularArray();
        jacobian = jacobianM.ToRectangularArray();
    }

    /// <summary>
    /// converts rotation matrix to rotation vector using Rodrigues transformation
    /// </summary>
    /// <param name="matrix">Input rotation matrix (3x3).</param>
    /// <param name="vector">Output rotation vector (3x1).</param>
    /// <param name="jacobian">Optional output Jacobian matrix, 3x9, which is a matrix of partial derivatives of the output array components with respect to the input array components.</param>
    public static void Rodrigues(double[,] matrix, out double[] vector, out double[,] jacobian)
    {
        if (matrix is null)
            throw new ArgumentNullException(nameof(matrix));
        if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
            throw new ArgumentException("matrix must be double[3,3]");

        using var matrixM = Mat.FromPixelData(3, 3, MatType.CV_64FC1, matrix);
        using var vectorM = new Mat<double>();
        using var jacobianM = new Mat<double>();
        using var matrixOutputArray = InputArray.Create(matrixM);
        using var vectorInputArray = OutputArray.Create(vectorM);
        using var jacobianOutputArray = OutputArray.Create(jacobianM);
        Rodrigues(matrixOutputArray, vectorInputArray, jacobianOutputArray);
        vector = vectorM.ToArray();
        jacobian = jacobianM.ToRectangularArray();
    }

    /// <summary>
    /// computes the best-fit perspective transformation mapping srcPoints to dstPoints.
    /// </summary>
    /// <param name="srcPoints">Coordinates of the points in the original plane, a matrix of the type CV_32FC2</param>
    /// <param name="dstPoints">Coordinates of the points in the target plane, a matrix of the type CV_32FC2</param>
    /// <param name="method">Method used to computed a homography matrix.</param>
    /// <param name="ransacReprojThreshold">Maximum allowed reprojection error to treat a point pair as an inlier (used in the RANSAC method only)</param>
    /// <param name="mask"> Optional output mask set by a robust method ( CV_RANSAC or CV_LMEDS ). Note that the input mask values are ignored.</param>
    /// <param name="maxIters">The maximum number of RANSAC iterations.</param>
    /// <param name="confidence">Confidence level, between 0 and 1.</param>
    /// <returns></returns>
    public static Mat FindHomography(
        InputArray srcPoints, 
        InputArray dstPoints,
        HomographyMethods method = HomographyMethods.None, 
        double ransacReprojThreshold = 3,
        OutputArray? mask = null, 
        int maxIters = 2000,
        double confidence = 0.995)
    {
        if (srcPoints is null)
            throw new ArgumentNullException(nameof(srcPoints));
        if (dstPoints is null)
            throw new ArgumentNullException(nameof(dstPoints));
        srcPoints.ThrowIfDisposed();
        dstPoints.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.geometry_findHomography_InputArray(
                srcPoints.CvPtr, dstPoints.CvPtr, (int)method,
                ransacReprojThreshold, ToPtr(mask), maxIters, confidence,
                out var ret));

        GC.KeepAlive(srcPoints);
        GC.KeepAlive(dstPoints);
        GC.KeepAlive(mask);
        mask?.Fix();
        return new Mat(ret);
    }

    /// <summary>
    /// computes the best-fit perspective transformation mapping srcPoints to dstPoints.
    /// </summary>
    /// <param name="srcPoints">Coordinates of the points in the original plane</param>
    /// <param name="dstPoints">Coordinates of the points in the target plane</param>
    /// <param name="method">Method used to computed a homography matrix.</param>
    /// <param name="ransacReprojThreshold">Maximum allowed reprojection error to treat a point pair as an inlier (used in the RANSAC method only)</param>
    /// <param name="mask"> Optional output mask set by a robust method ( CV_RANSAC or CV_LMEDS ). Note that the input mask values are ignored.</param>
    /// <param name="maxIters">The maximum number of RANSAC iterations.</param>
    /// <param name="confidence">Confidence level, between 0 and 1.</param>
    /// <returns></returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static Mat FindHomography(
        IEnumerable<Point2d> srcPoints, 
        IEnumerable<Point2d> dstPoints,
        HomographyMethods method = HomographyMethods.None, 
        double ransacReprojThreshold = 3,
        OutputArray? mask = null,
        int maxIters = 2000,
        double confidence = 0.995)
    {
        if (srcPoints is null)
            throw new ArgumentNullException(nameof(srcPoints));
        if (dstPoints is null)
            throw new ArgumentNullException(nameof(dstPoints));

        var srcPointsArray = srcPoints as Point2d[] ?? srcPoints.ToArray();
        var dstPointsArray = dstPoints as Point2d[] ?? dstPoints.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_findHomography_vector(
                srcPointsArray, srcPointsArray.Length,
                dstPointsArray, dstPointsArray.Length, 
                (int)method, ransacReprojThreshold, ToPtr(mask), maxIters, confidence,
                out var ret));

        GC.KeepAlive(mask);
        mask?.Fix();
        return new Mat(ret);
    }

    /// <summary>
    /// computes the best-fit perspective transformation mapping srcPoints to dstPoints.
    /// </summary>
    /// <param name="srcPoints">Coordinates of the points in the original plane, a matrix of the type CV_32FC2</param>
    /// <param name="dstPoints">Coordinates of the points in the target plane, a matrix of the type CV_32FC2</param>
    /// <param name="mask"> Optional output mask set by a robust method ( CV_RANSAC or CV_LMEDS ). Note that the input mask values are ignored.</param>
    /// <param name="params"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Mat FindHomography(
        InputArray srcPoints, 
        InputArray dstPoints,
        OutputArray mask,
        UsacParams? @params)
    {
        if (srcPoints is null)
            throw new ArgumentNullException(nameof(srcPoints));
        if (dstPoints is null)
            throw new ArgumentNullException(nameof(dstPoints));
        if (mask is null)
            throw new ArgumentNullException(nameof(mask));
        srcPoints.ThrowIfDisposed();
        dstPoints.ThrowIfDisposed();
        mask.ThrowIfNotReady();

        var p = (@params ?? new UsacParams()).ToNativeStruct();
        NativeMethods.HandleException(
            NativeMethods.geometry_findHomography_UsacParams(
                srcPoints.CvPtr, dstPoints.CvPtr, ToPtr(mask), ref p,
                out var ret));

        GC.KeepAlive(srcPoints);
        GC.KeepAlive(dstPoints);
        GC.KeepAlive(mask);
        mask.Fix();
        return new Mat(ret);
    }

    /// <summary>
    /// Computes RQ decomposition of 3x3 matrix
    /// </summary>
    /// <param name="src">3x3 input matrix.</param>
    /// <param name="mtxR">Output 3x3 upper-triangular matrix.</param>
    /// <param name="mtxQ"> Output 3x3 orthogonal matrix.</param>
    /// <param name="qx">Optional output 3x3 rotation matrix around x-axis.</param>
    /// <param name="qy">Optional output 3x3 rotation matrix around y-axis.</param>
    /// <param name="qz">Optional output 3x3 rotation matrix around z-axis.</param>
    /// <returns></returns>
    public static Vec3d RQDecomp3x3(InputArray src, OutputArray mtxR, OutputArray mtxQ,
        OutputArray? qx = null, OutputArray? qy = null, OutputArray? qz = null)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (mtxR is null)
            throw new ArgumentNullException(nameof(mtxR));
        if (mtxQ is null)
            throw new ArgumentNullException(nameof(mtxQ));
        src.ThrowIfDisposed();
        mtxR.ThrowIfNotReady();
        mtxQ.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_RQDecomp3x3_InputArray(
                src.CvPtr, mtxR.CvPtr, mtxQ.CvPtr,
                ToPtr(qx), ToPtr(qy), ToPtr(qz), out var ret));

        GC.KeepAlive(src);
        GC.KeepAlive(mtxR);
        GC.KeepAlive(mtxQ);
        qx?.Fix();
        qy?.Fix();
        qz?.Fix();
        return ret;
    }

    /// <summary>
    /// Computes RQ decomposition of 3x3 matrix
    /// </summary>
    /// <param name="src">3x3 input matrix.</param>
    /// <param name="mtxR">Output 3x3 upper-triangular matrix.</param>
    /// <param name="mtxQ"> Output 3x3 orthogonal matrix.</param>
    /// <returns></returns>
    public static Vec3d RQDecomp3x3(double[,] src, out double[,] mtxR, out double[,] mtxQ)
    {
        return RQDecomp3x3(src, out mtxR, out mtxQ, out _, out _, out _);
    }

    /// <summary>
    /// Computes RQ decomposition of 3x3 matrix
    /// </summary>
    /// <param name="src">3x3 input matrix.</param>
    /// <param name="mtxR">Output 3x3 upper-triangular matrix.</param>
    /// <param name="mtxQ"> Output 3x3 orthogonal matrix.</param>
    /// <param name="qx">Optional output 3x3 rotation matrix around x-axis.</param>
    /// <param name="qy">Optional output 3x3 rotation matrix around y-axis.</param>
    /// <param name="qz">Optional output 3x3 rotation matrix around z-axis.</param>
    /// <returns></returns>
    public static Vec3d RQDecomp3x3(double[,] src, out double[,] mtxR, out double[,] mtxQ,
        out double[,] qx, out double[,] qy, out double[,] qz)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (src.GetLength(0) != 3 || src.GetLength(1) != 3)
            throw new ArgumentException("src must be double[3,3]");

        using var srcM = Mat.FromPixelData(3, 3, MatType.CV_64FC1, src);
        using var mtxRM = new Mat<double>();
        using var mtxQM = new Mat<double>();
        using var qxM = new Mat<double>();
        using var qyM = new Mat<double>();
        using var qzM = new Mat<double>();
        NativeMethods.HandleException(
            NativeMethods.geometry_RQDecomp3x3_Mat(
                srcM.CvPtr, mtxRM.CvPtr, mtxQM.CvPtr, qxM.CvPtr, qyM.CvPtr, qzM.CvPtr,
                out var ret));
        mtxR = mtxRM.ToRectangularArray();
        mtxQ = mtxQM.ToRectangularArray();
        qx = qxM.ToRectangularArray();
        qy = qyM.ToRectangularArray();
        qz = qzM.ToRectangularArray();
        return ret;
    }

    /// <summary>
    /// Decomposes the projection matrix into camera matrix and the rotation martix and the translation vector
    /// </summary>
    /// <param name="projMatrix">3x4 input projection matrix P.</param>
    /// <param name="cameraMatrix">Output 3x3 camera matrix K.</param>
    /// <param name="rotMatrix">Output 3x3 external rotation matrix R.</param>
    /// <param name="transVect">Output 4x1 translation vector T.</param>
    /// <param name="rotMatrixX">Optional 3x3 rotation matrix around x-axis.</param>
    /// <param name="rotMatrixY">Optional 3x3 rotation matrix around y-axis.</param>
    /// <param name="rotMatrixZ">Optional 3x3 rotation matrix around z-axis.</param>
    /// <param name="eulerAngles">ptional three-element vector containing three Euler angles of rotation in degrees.</param>
    public static void DecomposeProjectionMatrix(
        InputArray projMatrix,
        OutputArray cameraMatrix,
        OutputArray rotMatrix,
        OutputArray transVect,
        OutputArray? rotMatrixX = null,
        OutputArray? rotMatrixY = null,
        OutputArray? rotMatrixZ = null,
        OutputArray? eulerAngles = null)
    {
        if (projMatrix is null)
            throw new ArgumentNullException(nameof(projMatrix));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (rotMatrix is null)
            throw new ArgumentNullException(nameof(rotMatrix));
        if (transVect is null)
            throw new ArgumentNullException(nameof(transVect));
        projMatrix.ThrowIfDisposed();
        cameraMatrix.ThrowIfNotReady();
        rotMatrix.ThrowIfNotReady();
        transVect.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_decomposeProjectionMatrix_InputArray(
                projMatrix.CvPtr, cameraMatrix.CvPtr, rotMatrix.CvPtr, transVect.CvPtr,
                ToPtr(rotMatrixX), ToPtr(rotMatrixY), ToPtr(rotMatrixZ), ToPtr(eulerAngles)));

        GC.KeepAlive(projMatrix);
        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(rotMatrix);
        GC.KeepAlive(transVect);
        GC.KeepAlive(rotMatrixX);
        GC.KeepAlive(rotMatrixY);
        GC.KeepAlive(rotMatrixZ);
        GC.KeepAlive(eulerAngles);

        cameraMatrix.Fix();
        rotMatrix.Fix();
        transVect.Fix();
        rotMatrixX?.Fix();
        rotMatrixY?.Fix();
        rotMatrixZ?.Fix();
        eulerAngles?.Fix();
    }

    /// <summary>
    /// Decomposes the projection matrix into camera matrix and the rotation martix and the translation vector
    /// </summary>
    /// <param name="projMatrix">3x4 input projection matrix P.</param>
    /// <param name="cameraMatrix">Output 3x3 camera matrix K.</param>
    /// <param name="rotMatrix">Output 3x3 external rotation matrix R.</param>
    /// <param name="transVect">Output 4x1 translation vector T.</param>
    /// <param name="rotMatrixX">Optional 3x3 rotation matrix around x-axis.</param>
    /// <param name="rotMatrixY">Optional 3x3 rotation matrix around y-axis.</param>
    /// <param name="rotMatrixZ">Optional 3x3 rotation matrix around z-axis.</param>
    /// <param name="eulerAngles">ptional three-element vector containing three Euler angles of rotation in degrees.</param>
    public static void DecomposeProjectionMatrix(
        double[,] projMatrix,
        out double[,] cameraMatrix,
        out double[,] rotMatrix,
        out double[] transVect,
        out double[,] rotMatrixX,
        out double[,] rotMatrixY,
        out double[,] rotMatrixZ,
        out double[] eulerAngles)
    {
        if (projMatrix is null)
            throw new ArgumentNullException(nameof(projMatrix));
        var dim0 = projMatrix.GetLength(0);
        var dim1 = projMatrix.GetLength(1);
        if (!((dim0 == 3 && dim1 == 4) || (dim0 == 4 && dim1 == 3)))
            throw new ArgumentException("projMatrix must be double[3,4] or double[4,3]");

        using var projMatrixM = Mat.FromPixelData(3, 4, MatType.CV_64FC1, projMatrix);
        using var cameraMatrixM = new Mat<double>();
        using var rotMatrixM = new Mat<double>();
        using var transVectM = new Mat<double>();
        using var rotMatrixXM = new Mat<double>();
        using var rotMatrixYM = new Mat<double>();
        using var rotMatrixZM = new Mat<double>();
        using var eulerAnglesM = new Mat<double>();
        NativeMethods.HandleException(
            NativeMethods.geometry_decomposeProjectionMatrix_Mat(
                projMatrixM.CvPtr,
                cameraMatrixM.CvPtr, rotMatrixM.CvPtr, transVectM.CvPtr,
                rotMatrixXM.CvPtr, rotMatrixYM.CvPtr, rotMatrixZM.CvPtr,
                eulerAnglesM.CvPtr));

        cameraMatrix = cameraMatrixM.ToRectangularArray();
        rotMatrix = rotMatrixM.ToRectangularArray();
        transVect = transVectM.ToArray();
        rotMatrixX = rotMatrixXM.ToRectangularArray();
        rotMatrixY = rotMatrixYM.ToRectangularArray();
        rotMatrixZ = rotMatrixZM.ToRectangularArray();
        eulerAngles = eulerAnglesM.ToArray();
    }

    /// <summary>
    /// Decomposes the projection matrix into camera matrix and the rotation martix and the translation vector
    /// </summary>
    /// <param name="projMatrix">3x4 input projection matrix P.</param>
    /// <param name="cameraMatrix">Output 3x3 camera matrix K.</param>
    /// <param name="rotMatrix">Output 3x3 external rotation matrix R.</param>
    /// <param name="transVect">Output 4x1 translation vector T.</param>
    public static void DecomposeProjectionMatrix(double[,] projMatrix,
        out double[,] cameraMatrix,
        out double[,] rotMatrix,
        out double[] transVect)
    {
        DecomposeProjectionMatrix(projMatrix, out cameraMatrix, out rotMatrix, out transVect,
            out _, out _, out _, out _);
    }

    /// <summary>
    /// computes derivatives of the matrix product w.r.t each of the multiplied matrix coefficients
    /// </summary>
    /// <param name="a">First multiplied matrix.</param>
    /// <param name="b">Second multiplied matrix.</param>
    /// <param name="dABdA">First output derivative matrix d(A*B)/dA of size A.rows*B.cols X A.rows*A.cols .</param>
    /// <param name="dABdB">Second output derivative matrix d(A*B)/dB of size A.rows*B.cols X B.rows*B.cols .</param>
    public static void MatMulDeriv(
        InputArray a, InputArray b,
        OutputArray dABdA, OutputArray dABdB)
    {
        if (a is null)
            throw new ArgumentNullException(nameof(a));
        if (b is null)
            throw new ArgumentNullException(nameof(b));
        if (dABdA is null)
            throw new ArgumentNullException(nameof(dABdA));
        if (dABdB is null)
            throw new ArgumentNullException(nameof(dABdB));
        a.ThrowIfDisposed();
        b.ThrowIfDisposed();
        dABdA.ThrowIfNotReady();
        dABdB.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.geometry_matMulDeriv(a.CvPtr, b.CvPtr, dABdA.CvPtr, dABdB.CvPtr));
        GC.KeepAlive(a);
        GC.KeepAlive(b);
        dABdA.Fix();
        dABdB.Fix();
    }

    /// <summary>
    /// composes 2 [R|t] transformations together. Also computes the derivatives of the result w.r.t the arguments
    /// </summary>
    /// <param name="rvec1">First rotation vector.</param>
    /// <param name="tvec1">First translation vector.</param>
    /// <param name="rvec2">Second rotation vector.</param>
    /// <param name="tvec2">Second translation vector.</param>
    /// <param name="rvec3">Output rotation vector of the superposition.</param>
    /// <param name="tvec3">Output translation vector of the superposition.</param>
    /// <param name="dr3dr1">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dr3dt1">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dr3dr2">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dr3dt2">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dt3dr1">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dt3dt1">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dt3dr2">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dt3dt2">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    public static void ComposeRT(
        InputArray rvec1, InputArray tvec1,
        InputArray rvec2, InputArray tvec2,
        OutputArray rvec3, OutputArray tvec3,
        OutputArray? dr3dr1 = null, OutputArray? dr3dt1 = null,
        OutputArray? dr3dr2 = null, OutputArray? dr3dt2 = null,
        OutputArray? dt3dr1 = null, OutputArray? dt3dt1 = null,
        OutputArray? dt3dr2 = null, OutputArray? dt3dt2 = null)
    {
        if (rvec1 is null)
            throw new ArgumentNullException(nameof(rvec1));
        if (tvec1 is null)
            throw new ArgumentNullException(nameof(tvec1));
        if (rvec2 is null)
            throw new ArgumentNullException(nameof(rvec2));
        if (tvec2 is null)
            throw new ArgumentNullException(nameof(tvec2));
        if (rvec3 is null)
            throw new ArgumentNullException(nameof(rvec3));
        if (tvec3 is null)
            throw new ArgumentNullException(nameof(tvec3));
        rvec1.ThrowIfDisposed();
        tvec1.ThrowIfDisposed();
        rvec2.ThrowIfDisposed();
        tvec2.ThrowIfDisposed();
        rvec3.ThrowIfNotReady();
        tvec3.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_composeRT_InputArray(
                rvec1.CvPtr, tvec1.CvPtr, rvec2.CvPtr, tvec2.CvPtr, rvec3.CvPtr, tvec3.CvPtr,
                ToPtr(dr3dr1), ToPtr(dr3dt1), ToPtr(dr3dr2), ToPtr(dr3dt2),
                ToPtr(dt3dr1), ToPtr(dt3dt1), ToPtr(dt3dr2), ToPtr(dt3dt2)));

        GC.KeepAlive(rvec1);
        GC.KeepAlive(tvec1);
        GC.KeepAlive(rvec2);
        GC.KeepAlive(tvec2);
        GC.KeepAlive(rvec3);
        GC.KeepAlive(tvec3);
        GC.KeepAlive(dr3dr1);
        GC.KeepAlive(dr3dt1);
        GC.KeepAlive(dr3dr2);
        GC.KeepAlive(dr3dt2);
        GC.KeepAlive(dt3dr1);
        GC.KeepAlive(dt3dt1);
        GC.KeepAlive(dt3dr2);
        GC.KeepAlive(dt3dt2);
    }

    /// <summary>
    /// composes 2 [R|t] transformations together. Also computes the derivatives of the result w.r.t the arguments
    /// </summary>
    /// <param name="rvec1">First rotation vector.</param>
    /// <param name="tvec1">First translation vector.</param>
    /// <param name="rvec2">Second rotation vector.</param>
    /// <param name="tvec2">Second translation vector.</param>
    /// <param name="rvec3">Output rotation vector of the superposition.</param>
    /// <param name="tvec3">Output translation vector of the superposition.</param>
    /// <param name="dr3dr1">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dr3dt1">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dr3dr2">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dr3dt2">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dt3dr1">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dt3dt1">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dt3dr2">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    /// <param name="dt3dt2">Optional output derivatives of rvec3 or tvec3 with regard to rvec1, rvec2, tvec1 and tvec2, respectively.</param>
    public static void ComposeRT(
        double[] rvec1, double[] tvec1,
        double[] rvec2, double[] tvec2,
        out double[] rvec3, out double[] tvec3,
        out double[,] dr3dr1, out double[,] dr3dt1,
        out double[,] dr3dr2, out double[,] dr3dt2,
        out double[,] dt3dr1, out double[,] dt3dt1,
        out double[,] dt3dr2, out double[,] dt3dt2)
    {
        if (rvec1 is null)
            throw new ArgumentNullException(nameof(rvec1));
        if (tvec1 is null)
            throw new ArgumentNullException(nameof(tvec1));
        if (rvec2 is null)
            throw new ArgumentNullException(nameof(rvec2));
        if (tvec2 is null)
            throw new ArgumentNullException(nameof(tvec2));

        using var rvec1M = Mat.FromPixelData(3, 1, MatType.CV_64FC1, rvec1);
        using var tvec1M = Mat.FromPixelData(3, 1, MatType.CV_64FC1, tvec1);
        using var rvec2M = Mat.FromPixelData(3, 1, MatType.CV_64FC1, rvec2);
        using var tvec2M = Mat.FromPixelData(3, 1, MatType.CV_64FC1, tvec2);
        using var rvec3M = new Mat<double>();
        using var tvec3M = new Mat<double>();
        using var dr3dr1M = new Mat<double>();
        using var dr3dt1M = new Mat<double>();
        using var dr3dr2M = new Mat<double>();
        using var dr3dt2M = new Mat<double>();
        using var dt3dr1M = new Mat<double>();
        using var dt3dt1M = new Mat<double>();
        using var dt3dr2M = new Mat<double>();
        using var dt3dt2M = new Mat<double>();

        NativeMethods.HandleException(
            NativeMethods.geometry_composeRT_Mat(
                rvec1M.CvPtr, tvec1M.CvPtr, rvec2M.CvPtr, tvec2M.CvPtr,
                rvec3M.CvPtr, tvec3M.CvPtr,
                dr3dr1M.CvPtr, dr3dt1M.CvPtr, dr3dr2M.CvPtr, dr3dt2M.CvPtr,
                dt3dr1M.CvPtr, dt3dt1M.CvPtr, dt3dr2M.CvPtr, dt3dt2M.CvPtr));

        rvec3 = rvec3M.ToArray();
        tvec3 = tvec3M.ToArray();
        dr3dr1 = dr3dr1M.ToRectangularArray();
        dr3dt1 = dr3dt1M.ToRectangularArray();
        dr3dr2 = dr3dr2M.ToRectangularArray();
        dr3dt2 = dr3dt2M.ToRectangularArray();
        dt3dr1 = dt3dr1M.ToRectangularArray();
        dt3dt1 = dt3dt1M.ToRectangularArray();
        dt3dr2 = dt3dr2M.ToRectangularArray();
        dt3dt2 = dt3dt2M.ToRectangularArray();
    }

    /// <summary>
    /// composes 2 [R|t] transformations together. Also computes the derivatives of the result w.r.t the arguments
    /// </summary>
    /// <param name="rvec1">First rotation vector.</param>
    /// <param name="tvec1">First translation vector.</param>
    /// <param name="rvec2">Second rotation vector.</param>
    /// <param name="tvec2">Second translation vector.</param>
    /// <param name="rvec3">Output rotation vector of the superposition.</param>
    /// <param name="tvec3">Output translation vector of the superposition.</param>
    public static void ComposeRT(double[] rvec1, double[] tvec1,
        double[] rvec2, double[] tvec2,
        out double[] rvec3, out double[] tvec3)
    {
        ComposeRT(rvec1, tvec1, rvec2, tvec2, out rvec3, out tvec3,
            out _, out _, out _, out _,
            out _, out _, out _, out _);
    }

    /// <summary>
    /// projects points from the model coordinate space to the image coordinates. 
    /// Also computes derivatives of the image coordinates w.r.t the intrinsic 
    /// and extrinsic camera parameters
    /// </summary>
    /// <param name="objectPoints">Array of object points, 3xN/Nx3 1-channel or 
    /// 1xN/Nx1 3-channel, where N is the number of points in the view.</param>
    /// <param name="rvec">Rotation vector (3x1).</param>
    /// <param name="tvec">Translation vector (3x1).</param>
    /// <param name="cameraMatrix">Camera matrix (3x3)</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients 
    /// (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// If the vector is null, the zero distortion coefficients are assumed.</param>
    /// <param name="imagePoints">Output array of image points, 2xN/Nx2 1-channel 
    /// or 1xN/Nx1 2-channel</param>
    /// <param name="jacobian">Optional output 2Nx(10 + numDistCoeffs) jacobian matrix 
    /// of derivatives of image points with respect to components of the rotation vector, 
    /// translation vector, focal lengths, coordinates of the principal point and 
    /// the distortion coefficients. In the old interface different components of 
    /// the jacobian are returned via different output parameters.</param>
    /// <param name="aspectRatio">Optional “fixed aspect ratio” parameter. 
    /// If the parameter is not 0, the function assumes that the aspect ratio (fx/fy) 
    /// is fixed and correspondingly adjusts the jacobian matrix.</param>
    public static void ProjectPoints(
        InputArray objectPoints,
        InputArray rvec,
        InputArray tvec,
        InputArray cameraMatrix,
        InputArray distCoeffs,
        OutputArray imagePoints,
        OutputArray? jacobian = null,
        double aspectRatio = 0)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (rvec is null)
            throw new ArgumentNullException(nameof(rvec));
        if (tvec is null)
            throw new ArgumentNullException(nameof(tvec));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (imagePoints is null)
            throw new ArgumentNullException(nameof(imagePoints));
        objectPoints.ThrowIfDisposed();
        rvec.ThrowIfDisposed();
        tvec.ThrowIfDisposed();
        cameraMatrix.ThrowIfDisposed();
        imagePoints.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_projectPoints_InputArray(
                objectPoints.CvPtr,
                rvec.CvPtr, tvec.CvPtr, cameraMatrix.CvPtr, ToPtr(distCoeffs),
                imagePoints.CvPtr, ToPtr(jacobian), aspectRatio));

        GC.KeepAlive(objectPoints);
        GC.KeepAlive(rvec);
        GC.KeepAlive(tvec);
        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(distCoeffs);
        GC.KeepAlive(imagePoints);
        GC.KeepAlive(jacobian);
    }

    /// <summary>
    /// projects points from the model coordinate space to the image coordinates. 
    /// Also computes derivatives of the image coordinates w.r.t the intrinsic 
    /// and extrinsic camera parameters
    /// </summary>
    /// <param name="objectPoints">Array of object points, 3xN/Nx3 1-channel or 
    /// 1xN/Nx1 3-channel, where N is the number of points in the view.</param>
    /// <param name="rvec">Rotation vector (3x1).</param>
    /// <param name="tvec">Translation vector (3x1).</param>
    /// <param name="cameraMatrix">Camera matrix (3x3)</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients 
    /// (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// If the vector is null, the zero distortion coefficients are assumed.</param>
    /// <param name="imagePoints">Output array of image points, 2xN/Nx2 1-channel 
    /// or 1xN/Nx1 2-channel</param>
    /// <param name="jacobian">Optional output 2Nx(10 + numDistCoeffs) jacobian matrix 
    /// of derivatives of image points with respect to components of the rotation vector, 
    /// translation vector, focal lengths, coordinates of the principal point and 
    /// the distortion coefficients. In the old interface different components of 
    /// the jacobian are returned via different output parameters.</param>
    /// <param name="aspectRatio">Optional “fixed aspect ratio” parameter. 
    /// If the parameter is not 0, the function assumes that the aspect ratio (fx/fy) 
    /// is fixed and correspondingly adjusts the jacobian matrix.</param>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static void ProjectPoints(
        IEnumerable<Point3f> objectPoints,
        double[] rvec, double[] tvec,
        double[,] cameraMatrix, double[] distCoeffs,
        out Point2f[] imagePoints,
        out double[,] jacobian,
        double aspectRatio = 0)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (rvec is null)
            throw new ArgumentNullException(nameof(rvec));
        if (rvec.Length != 3)
            throw new ArgumentException($"{nameof(rvec)}.Length != 3");
        if (tvec is null)
            throw new ArgumentNullException(nameof(tvec));
        if (tvec.Length != 3)
            throw new ArgumentException($"{nameof(tvec)}.Length != 3");
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
            throw new ArgumentException("cameraMatrix must be double[3,3]");

        var objectPointsArray = objectPoints as Point3f[] ?? objectPoints.ToArray();
        using var objectPointsM = Mat.FromPixelData(objectPointsArray.Length, 1, MatType.CV_32FC3, objectPointsArray);
        using var rvecM = Mat.FromPixelData(3, 1, MatType.CV_64FC1, rvec);
        using var tvecM = Mat.FromPixelData(3, 1, MatType.CV_64FC1, tvec);
        using var cameraMatrixM = Mat.FromPixelData(3, 3, MatType.CV_64FC1, cameraMatrix);
        using var distCoeffsM = (distCoeffs is null)
            ? new Mat()
            : Mat.FromPixelData(distCoeffs.Length, 1, MatType.CV_64FC1, distCoeffs);
        using var imagePointsM = new Mat<Point2f>();
        using var jacobianM = new Mat<double>();
        NativeMethods.HandleException(
            NativeMethods.geometry_projectPoints_Mat(
                objectPointsM.CvPtr, rvecM.CvPtr, tvecM.CvPtr, cameraMatrixM.CvPtr, distCoeffsM.CvPtr,
                imagePointsM.CvPtr, jacobianM.CvPtr, aspectRatio));

        imagePoints = imagePointsM.ToArray();
        jacobian = jacobianM.ToRectangularArray();
    }

    /// <summary>
    /// Finds an object pose from 3D-2D point correspondences.
    /// </summary>
    /// <param name="objectPoints"> Array of object points in the object coordinate space, 3xN/Nx3 1-channel or 1xN/Nx1 3-channel, 
    /// where N is the number of points. vector&lt;Point3f&gt; can be also passed here.</param>
    /// <param name="imagePoints">Array of corresponding image points, 2xN/Nx2 1-channel or 1xN/Nx1 2-channel, 
    /// where N is the number of points. vector&lt;Point2f&gt; can be also passed here.</param>
    /// <param name="cameraMatrix">Input camera matrix</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// If the vector is null, the zero distortion coefficients are assumed.</param>
    /// <param name="rvec">Output rotation vector that, together with tvec , brings points from the model coordinate system to the 
    /// camera coordinate system.</param>
    /// <param name="tvec">Output translation vector.</param>
    /// <param name="useExtrinsicGuess">If true, the function uses the provided rvec and tvec values as initial approximations of 
    /// the rotation and translation vectors, respectively, and further optimizes them.</param>
    /// <param name="flags">Method for solving a PnP problem:</param>
    public static void SolvePnP(
        InputArray objectPoints,
        InputArray imagePoints,
        InputArray cameraMatrix,
        InputArray distCoeffs,
        OutputArray rvec, OutputArray tvec,
        bool useExtrinsicGuess = false,
        SolvePnPMethod flags = SolvePnPMethod.Iterative)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints is null)
            throw new ArgumentNullException(nameof(imagePoints));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (distCoeffs is null)
            throw new ArgumentNullException(nameof(distCoeffs));
        if (rvec is null)
            throw new ArgumentNullException(nameof(rvec));
        if (tvec is null)
            throw new ArgumentNullException(nameof(tvec));
        objectPoints.ThrowIfDisposed();
        imagePoints.ThrowIfDisposed();
        cameraMatrix.ThrowIfDisposed();
        distCoeffs.ThrowIfDisposed();
        rvec.ThrowIfDisposed();
        tvec.ThrowIfDisposed();
        var distCoeffsPtr = ToPtr(distCoeffs);

        NativeMethods.HandleException(NativeMethods.geometry_solvePnP_InputArray(
            objectPoints.CvPtr, imagePoints.CvPtr, cameraMatrix.CvPtr, distCoeffsPtr,
            rvec.CvPtr, tvec.CvPtr, useExtrinsicGuess ? 1 : 0, (int) flags));

        rvec.Fix();
        tvec.Fix();
        GC.KeepAlive(objectPoints);
        GC.KeepAlive(imagePoints);
        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(distCoeffs);
    }

    /// <summary>
    /// Finds an object pose from 3D-2D point correspondences.
    /// </summary>
    /// <param name="objectPoints"> Array of object points in the object coordinate space, 3xN/Nx3 1-channel or 1xN/Nx1 3-channel, 
    /// where N is the number of points. vector&lt;Point3f&gt; can be also passed here.</param>
    /// <param name="imagePoints">Array of corresponding image points, 2xN/Nx2 1-channel or 1xN/Nx1 2-channel, 
    /// where N is the number of points. vector&lt;Point2f&gt; can be also passed here.</param>
    /// <param name="cameraMatrix">Input camera matrix</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// If the vector is null, the zero distortion coefficients are assumed.</param>
    /// <param name="rvec">Output rotation vector that, together with tvec , brings points from the model coordinate system to the 
    /// camera coordinate system.</param>
    /// <param name="tvec">Output translation vector.</param>
    /// <param name="useExtrinsicGuess">If true, the function uses the provided rvec and tvec values as initial approximations of 
    /// the rotation and translation vectors, respectively, and further optimizes them.</param>
    /// <param name="flags">Method for solving a PnP problem</param>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static void SolvePnP(
        IEnumerable<Point3f> objectPoints,
        IEnumerable<Point2f> imagePoints,
        double[,] cameraMatrix,
        IEnumerable<double>? distCoeffs,
        ref double[] rvec, 
        ref double[] tvec,
        bool useExtrinsicGuess = false,
        SolvePnPMethod flags = SolvePnPMethod.Iterative)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints is null)
            throw new ArgumentNullException(nameof(imagePoints));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
            throw new ArgumentException("");

        var objectPointsArray = objectPoints as Point3f[] ?? objectPoints.ToArray();
        var imagePointsArray = imagePoints as Point2f[] ?? imagePoints.ToArray();
        var distCoeffsArray = distCoeffs as double[] ?? distCoeffs?.ToArray();

        if (!useExtrinsicGuess)
        {
            rvec = new double[3];
            tvec = new double[3];
        }

        unsafe
        {
            fixed (double* cameraMatrixPtr = cameraMatrix)
            {
                NativeMethods.HandleException(
                    NativeMethods.geometry_solvePnP_vector(
                        objectPointsArray, objectPointsArray.Length,
                        imagePointsArray, imagePointsArray.Length,
                        cameraMatrixPtr, distCoeffsArray, distCoeffsArray?.Length ?? 0,
                        rvec, tvec, useExtrinsicGuess ? 1 : 0, (int) flags));
            }
        }
    }

    /// <summary>
    /// computes the camera pose from a few 3D points and the corresponding projections. The outliers are possible.
    /// </summary>
    /// <param name="objectPoints">Array of object points in the object coordinate space, 3xN/Nx3 1-channel or 1xN/Nx1 3-channel, 
    /// where N is the number of points. List&lt;Point3f&gt; can be also passed here.</param>
    /// <param name="imagePoints">Array of corresponding image points, 2xN/Nx2 1-channel or 1xN/Nx1 2-channel, where N is the number of points. 
    /// List&lt;Point2f&gt; can be also passed here.</param>
    /// <param name="cameraMatrix">Input 3x3 camera matrix</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// If the vector is null, the zero distortion coefficients are assumed.</param>
    /// <param name="rvec">Output rotation vector that, together with tvec , brings points from the model coordinate system 
    /// to the camera coordinate system.</param>
    /// <param name="tvec">Output translation vector.</param>
    /// <param name="useExtrinsicGuess">If true, the function uses the provided rvec and tvec values as initial approximations 
    /// of the rotation and translation vectors, respectively, and further optimizes them.</param>
    /// <param name="iterationsCount">Number of iterations.</param>
    /// <param name="reprojectionError">Inlier threshold value used by the RANSAC procedure. 
    /// The parameter value is the maximum allowed distance between the observed and computed point projections to consider it an inlier.</param>
    /// <param name="confidence">The probability that the algorithm produces a useful result.</param>
    /// <param name="inliers">Output vector that contains indices of inliers in objectPoints and imagePoints .</param>
    /// <param name="flags">Method for solving a PnP problem</param>
    public static void SolvePnPRansac(
        InputArray objectPoints,
        InputArray imagePoints,
        InputArray cameraMatrix,
        InputArray distCoeffs,
        OutputArray? rvec,
        OutputArray? tvec,
        bool useExtrinsicGuess = false,
        int iterationsCount = 100,
        float reprojectionError = 8.0f,
        double confidence = 0.99,
        OutputArray? inliers = null,
        SolvePnPMethod flags = SolvePnPMethod.Iterative)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints is null)
            throw new ArgumentNullException(nameof(imagePoints));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (distCoeffs is null)
            throw new ArgumentNullException(nameof(distCoeffs));
        if (rvec is null)
            throw new ArgumentNullException(nameof(rvec));
        if (tvec is null)
            throw new ArgumentNullException(nameof(tvec));
        objectPoints.ThrowIfDisposed();
        imagePoints.ThrowIfDisposed();
        cameraMatrix.ThrowIfDisposed();
        distCoeffs.ThrowIfDisposed();
        rvec.ThrowIfDisposed();
        tvec.ThrowIfDisposed();
        var distCoeffsPtr = ToPtr(distCoeffs);

        NativeMethods.HandleException(
            NativeMethods.geometry_solvePnPRansac_InputArray(
                objectPoints.CvPtr, imagePoints.CvPtr, cameraMatrix.CvPtr, distCoeffsPtr,
                rvec.CvPtr, tvec.CvPtr, useExtrinsicGuess ? 1 : 0, iterationsCount,
                reprojectionError, confidence, ToPtr(inliers), (int) flags));

        GC.KeepAlive(objectPoints);
        GC.KeepAlive(imagePoints);
        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(distCoeffs);
        rvec.Fix();
        tvec.Fix();
        inliers?.Fix();
    }

    /// <summary>
    /// computes the camera pose from a few 3D points and the corresponding projections. The outliers are possible.
    /// </summary>
    /// <param name="objectPoints">Array of object points in the object coordinate space, 3xN/Nx3 1-channel or 1xN/Nx1 3-channel, 
    /// where N is the number of points. List&lt;Point3f&gt; can be also passed here.</param>
    /// <param name="imagePoints">Array of corresponding image points, 2xN/Nx2 1-channel or 1xN/Nx1 2-channel, where N is the number of points. 
    /// List&lt;Point2f&gt; can be also passed here.</param>
    /// <param name="cameraMatrix">Input 3x3 camera matrix</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// If the vector is null, the zero distortion coefficients are assumed.</param>
    /// <param name="rvec">Output rotation vector that, together with tvec , brings points from the model coordinate system 
    /// to the camera coordinate system.</param>
    /// <param name="tvec">Output translation vector.</param>
    public static void SolvePnPRansac(
        IEnumerable<Point3f> objectPoints,
        IEnumerable<Point2f> imagePoints,
        double[,] cameraMatrix,
        IEnumerable<double> distCoeffs,
        out double[] rvec, out double[] tvec)
    {
        SolvePnPRansac(objectPoints, imagePoints, cameraMatrix, distCoeffs, out rvec, out tvec, out _);
    }

    /// <summary>
    /// computes the camera pose from a few 3D points and the corresponding projections. The outliers are possible.
    /// </summary>
    /// <param name="objectPoints">Array of object points in the object coordinate space, 3xN/Nx3 1-channel or 1xN/Nx1 3-channel, 
    /// where N is the number of points. List&lt;Point3f&gt; can be also passed here.</param>
    /// <param name="imagePoints">Array of corresponding image points, 2xN/Nx2 1-channel or 1xN/Nx1 2-channel, where N is the number of points. 
    /// List&lt;Point2f&gt; can be also passed here.</param>
    /// <param name="cameraMatrix">Input 3x3 camera matrix</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// If the vector is null, the zero distortion coefficients are assumed.</param>
    /// <param name="rvec">Output rotation vector that, together with tvec , brings points from the model coordinate system 
    /// to the camera coordinate system.</param>
    /// <param name="tvec">Output translation vector.</param>
    /// <param name="useExtrinsicGuess">If true, the function uses the provided rvec and tvec values as initial approximations 
    /// of the rotation and translation vectors, respectively, and further optimizes them.</param>
    /// <param name="iterationsCount">Number of iterations.</param>
    /// <param name="reprojectionError">Inlier threshold value used by the RANSAC procedure. 
    /// The parameter value is the maximum allowed distance between the observed and computed point projections to consider it an inlier.</param>
    /// <param name="confidence">The probability that the algorithm produces a useful result.</param>
    /// <param name="inliers">Output vector that contains indices of inliers in objectPoints and imagePoints .</param>
    /// <param name="flags">Method for solving a PnP problem</param>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static void SolvePnPRansac(
        IEnumerable<Point3f> objectPoints,
        IEnumerable<Point2f> imagePoints,
        double[,] cameraMatrix,
        IEnumerable<double>? distCoeffs,
        out double[] rvec, 
        out double[] tvec,
        out int[] inliers,
        bool useExtrinsicGuess = false,
        int iterationsCount = 100,
        float reprojectionError = 8.0f,
        double confidence = 0.99,
        SolvePnPMethod flags = SolvePnPMethod.Iterative)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints is null)
            throw new ArgumentNullException(nameof(imagePoints));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));

        if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
            throw new ArgumentException($"Size of {nameof(cameraMatrix)} must be 3x3");

        var objectPointsArray = objectPoints as Point3f[] ?? objectPoints.ToArray();
        var imagePointsArray = imagePoints as Point2f[] ?? imagePoints.ToArray();
        var distCoeffsArray = distCoeffs as double[] ?? distCoeffs?.ToArray();
        rvec = new double[3];
        tvec = new double[3];

        using var inliersVec = new VectorOfInt32();
        unsafe
        {
            fixed (double* cameraMatrixPtr = cameraMatrix)
            {
                NativeMethods.HandleException(
                    NativeMethods.geometry_solvePnPRansac_vector(
                        objectPointsArray, objectPointsArray.Length,
                        imagePointsArray, imagePointsArray.Length,
                        cameraMatrixPtr, distCoeffsArray, distCoeffsArray?.Length ?? 0,
                        rvec, tvec, useExtrinsicGuess ? 1 : 0, iterationsCount,
                        reprojectionError, confidence, inliersVec.CvPtr, (int) flags));
                inliers = inliersVec.ToArray();
            }
        }
    }

    /// <summary>
    /// computes several useful camera characteristics from the camera matrix, camera frame resolution and the physical sensor size.
    /// </summary>
    /// <param name="cameraMatrix">Input camera matrix that can be estimated by calibrateCamera() or stereoCalibrate() .</param>
    /// <param name="imageSize">Input image size in pixels.</param>
    /// <param name="apertureWidth">Physical width of the sensor.</param>
    /// <param name="apertureHeight">Physical height of the sensor.</param>
    /// <param name="fovx">Output field of view in degrees along the horizontal sensor axis.</param>
    /// <param name="fovy">Output field of view in degrees along the vertical sensor axis.</param>
    /// <param name="focalLength">Focal length of the lens in mm.</param>
    /// <param name="principalPoint">Principal point in pixels.</param>
    /// <param name="aspectRatio">fy / fx</param>
    public static void CalibrationMatrixValues(
        InputArray cameraMatrix, Size imageSize,
        double apertureWidth, double apertureHeight,
        out double fovx, out double fovy, out double focalLength,
        out Point2d principalPoint, out double aspectRatio)
    {
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        cameraMatrix.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.geometry_calibrationMatrixValues_InputArray(
                cameraMatrix.CvPtr, imageSize, apertureWidth, apertureHeight, 
                out fovx, out fovy, out focalLength, out principalPoint, out aspectRatio));
        GC.KeepAlive(cameraMatrix);
    }

    /// <summary>
    /// computes several useful camera characteristics from the camera matrix, camera frame resolution and the physical sensor size.
    /// </summary>
    /// <param name="cameraMatrix">Input camera matrix that can be estimated by calibrateCamera() or stereoCalibrate() .</param>
    /// <param name="imageSize">Input image size in pixels.</param>
    /// <param name="apertureWidth">Physical width of the sensor.</param>
    /// <param name="apertureHeight">Physical height of the sensor.</param>
    /// <param name="fovx">Output field of view in degrees along the horizontal sensor axis.</param>
    /// <param name="fovy">Output field of view in degrees along the vertical sensor axis.</param>
    /// <param name="focalLength">Focal length of the lens in mm.</param>
    /// <param name="principalPoint">Principal point in pixels.</param>
    /// <param name="aspectRatio">fy / fx</param>
    public static void CalibrationMatrixValues(
        double[,] cameraMatrix, Size imageSize,
        double apertureWidth, double apertureHeight,
        out double fovx, out double fovy, out double focalLength,
        out Point2d principalPoint, out double aspectRatio)
    {
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
            throw new ArgumentException("cameraMatrix must be 3x3");

        unsafe
        {
            fixed (double* cameraMatrixPtr = cameraMatrix)
            {
                NativeMethods.HandleException(
                    NativeMethods.geometry_calibrationMatrixValues_array(
                        cameraMatrixPtr,
                        imageSize, apertureWidth, apertureHeight, out fovx, out fovy, out focalLength,
                        out principalPoint, out aspectRatio));
            }
        }
    }

    /// <summary>
    /// Returns the new camera matrix based on the free scaling parameter.
    /// </summary>
    /// <param name="cameraMatrix">Input camera matrix.</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// If the array is null, the zero distortion coefficients are assumed.</param>
    /// <param name="imageSize">Original image size.</param>
    /// <param name="alpha">Free scaling parameter between 0 (when all the pixels in the undistorted image are valid) 
    /// and 1 (when all the source image pixels are retained in the undistorted image). </param>
    /// <param name="newImgSize">Image size after rectification. By default,it is set to imageSize .</param>
    /// <param name="validPixROI">Optional output rectangle that outlines all-good-pixels region in the undistorted image. See roi1, roi2 description in stereoRectify() .</param>
    /// <param name="centerPrincipalPoint">Optional flag that indicates whether in the new camera matrix the principal point 
    /// should be at the image center or not. By default, the principal point is chosen to best fit a 
    /// subset of the source image (determined by alpha) to the corrected image.</param>
    /// <returns>optimal new camera matrix</returns>
    public static Mat GetOptimalNewCameraMatrix(
        InputArray cameraMatrix, 
        InputArray? distCoeffs,
        Size imageSize,
        double alpha, 
        Size newImgSize,
        out Rect validPixROI,
        bool centerPrincipalPoint = false)
    {
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        cameraMatrix.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.geometry_getOptimalNewCameraMatrix_InputArray(
                cameraMatrix.CvPtr, ToPtr(distCoeffs), imageSize, alpha, newImgSize,
                out validPixROI, centerPrincipalPoint ? 1 : 0, out var ret));
        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(distCoeffs);
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the new camera matrix based on the free scaling parameter.
    /// </summary>
    /// <param name="cameraMatrix">Input camera matrix.</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// If the array is null, the zero distortion coefficients are assumed.</param>
    /// <param name="imageSize">Original image size.</param>
    /// <param name="alpha">Free scaling parameter between 0 (when all the pixels in the undistorted image are valid) 
    /// and 1 (when all the source image pixels are retained in the undistorted image). </param>
    /// <param name="newImgSize">Image size after rectification. By default,it is set to imageSize .</param>
    /// <param name="validPixROI">Optional output rectangle that outlines all-good-pixels region in the undistorted image. See roi1, roi2 description in stereoRectify() .</param>
    /// <param name="centerPrincipalPoint">Optional flag that indicates whether in the new camera matrix the principal point 
    /// should be at the image center or not. By default, the principal point is chosen to best fit a 
    /// subset of the source image (determined by alpha) to the corrected image.</param>
    /// <returns>optimal new camera matrix</returns>
    public static double[,]? GetOptimalNewCameraMatrix(
        double[,] cameraMatrix, double[] distCoeffs,
        Size imageSize, double alpha, Size newImgSize,
        out Rect validPixROI, bool centerPrincipalPoint = false)
    {
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (distCoeffs is null)
            throw new ArgumentNullException(nameof(distCoeffs));

        IntPtr matPtr;
        unsafe
        {
            fixed (double* cameraMatrixPtr = cameraMatrix)
            {
                NativeMethods.HandleException(
                    NativeMethods.geometry_getOptimalNewCameraMatrix_array(
                        cameraMatrixPtr, distCoeffs, distCoeffs.Length,
                        imageSize, alpha, newImgSize,
                        out validPixROI, centerPrincipalPoint ? 1 : 0, out matPtr));
                if (matPtr == IntPtr.Zero)
                    return null;
            }
        }

        using var mat = Mat<double>.FromNativePointer(matPtr);
        return mat.ToRectangularArray();
    }

    /// <summary>
    /// converts point coordinates from normal pixel coordinates to homogeneous coordinates ((x,y)->(x,y,1))
    /// </summary>
    /// <param name="src">Input vector of N-dimensional points.</param>
    /// <param name="dst">Output vector of N+1-dimensional points.</param>
    public static void ConvertPointsToHomogeneous(InputArray src, OutputArray dst)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_convertPointsToHomogeneous_InputArray(src.CvPtr, dst.CvPtr));

        GC.KeepAlive(src);
        GC.KeepAlive(dst);
        dst.Fix();
    }

    /// <summary>
    /// converts point coordinates from normal pixel coordinates to homogeneous coordinates ((x,y)->(x,y,1))
    /// </summary>
    /// <param name="src">Input vector of N-dimensional points.</param>
    /// <returns>Output vector of N+1-dimensional points.</returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static Vec3f[] ConvertPointsToHomogeneous(IEnumerable<Vec2f> src)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));

        var srcA = src as Vec2f[] ?? src.ToArray();
        var dstA = new Vec3f[srcA.Length];
        NativeMethods.HandleException(
            NativeMethods.geometry_convertPointsToHomogeneous_array1(srcA, dstA, srcA.Length));
        return dstA;
    }

    /// <summary>
    /// converts point coordinates from normal pixel coordinates to homogeneous coordinates ((x,y)->(x,y,1))
    /// </summary>
    /// <param name="src">Input vector of N-dimensional points.</param>
    /// <returns>Output vector of N+1-dimensional points.</returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static Vec4f[] ConvertPointsToHomogeneous(IEnumerable<Vec3f> src)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));

        var srcA = src as Vec3f[] ?? src.ToArray();
        var dstA = new Vec4f[srcA.Length];
        NativeMethods.HandleException(
            NativeMethods.geometry_convertPointsToHomogeneous_array2(srcA, dstA, srcA.Length));
        return dstA;
    }

    /// <summary>
    /// converts point coordinates from homogeneous to normal pixel coordinates ((x,y,z)->(x/z, y/z))
    /// </summary>
    /// <param name="src">Input vector of N-dimensional points.</param>
    /// <param name="dst">Output vector of N-1-dimensional points.</param>
    public static void ConvertPointsFromHomogeneous(InputArray src, OutputArray dst)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.geometry_convertPointsFromHomogeneous_InputArray(src.CvPtr, dst.CvPtr));
        GC.KeepAlive(src);
        dst.Fix();
    }

    /// <summary>
    /// converts point coordinates from homogeneous to normal pixel coordinates ((x,y,z)->(x/z, y/z))
    /// </summary>
    /// <param name="src">Input vector of N-dimensional points.</param>
    /// <returns>Output vector of N-1-dimensional points.</returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static Vec2f[] ConvertPointsFromHomogeneous(IEnumerable<Vec3f> src)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));

        var srcA = src as Vec3f[] ?? src.ToArray();
        var dstA = new Vec2f[srcA.Length];
        NativeMethods.HandleException(
            NativeMethods.geometry_convertPointsFromHomogeneous_array1(srcA, dstA, srcA.Length));
        return dstA;
    }

    /// <summary>
    /// converts point coordinates from homogeneous to normal pixel coordinates ((x,y,z)->(x/z, y/z))
    /// </summary>
    /// <param name="src">Input vector of N-dimensional points.</param>
    /// <returns>Output vector of N-1-dimensional points.</returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static Vec3f[] ConvertPointsFromHomogeneous(IEnumerable<Vec4f> src)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));

        var srcA = src as Vec4f[] ?? src.ToArray();
        var dstA = new Vec3f[srcA.Length];
        NativeMethods.HandleException(
            NativeMethods.geometry_convertPointsFromHomogeneous_array2(srcA, dstA, srcA.Length));
        return dstA;
    }

    /// <summary>
    /// Converts points to/from homogeneous coordinates.
    /// </summary>
    /// <param name="src">Input array or vector of 2D, 3D, or 4D points.</param>
    /// <param name="dst">Output vector of 2D, 3D, or 4D points.</param>
    public static void ConvertPointsHomogeneous(InputArray src, OutputArray dst)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.geometry_convertPointsHomogeneous(src.CvPtr, dst.CvPtr));
        GC.KeepAlive(src);
        dst.Fix();
    }

    /// <summary>
    /// Calculates a fundamental matrix from the corresponding points in two images.
    /// </summary>
    /// <param name="points1">Array of N points from the first image. 
    /// The point coordinates should be floating-point (single or double precision).</param>
    /// <param name="points2">Array of the second image points of the same size and format as points1 .</param>
    /// <param name="method">Method for computing a fundamental matrix.</param>
    /// <param name="param1">Parameter used for RANSAC. 
    /// It is the maximum distance from a point to an epipolar line in pixels, beyond which the point is 
    /// considered an outlier and is not used for computing the final fundamental matrix. It can be set to 
    /// something like 1-3, depending on the accuracy of the point localization, image resolution, and the image noise.</param>
    /// <param name="param2">Parameter used for the RANSAC or LMedS methods only. 
    /// It specifies a desirable level of confidence (probability) that the estimated matrix is correct.</param>
    /// <param name="mask">Output array of N elements, every element of which is set to 0 for outliers and 
    /// to 1 for the other points. The array is computed only in the RANSAC and LMedS methods. For other methods, it is set to all 1’s.</param>
    /// <returns>fundamental matrix</returns>
    public static Mat FindFundamentalMat(
        InputArray points1, InputArray points2,
        FundamentalMatMethods method = FundamentalMatMethods.Ransac,
        double param1 = 3.0, double param2 = 0.99,
        OutputArray? mask = null)
    {
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));
        points1.ThrowIfDisposed();
        points2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.geometry_findFundamentalMat_InputArray(
                points1.CvPtr, points2.CvPtr, (int) method,
                param1, param2, ToPtr(mask), out var ret));
        mask?.Fix();
        GC.KeepAlive(points1);
        GC.KeepAlive(points2);
        return new Mat(ret);
    }

    /// <summary>
    /// Calculates a fundamental matrix from the corresponding points in two images.
    /// </summary>
    /// <param name="points1">Array of N points from the first image. 
    /// The point coordinates should be floating-point (single or double precision).</param>
    /// <param name="points2">Array of the second image points of the same size and format as points1 .</param>
    /// <param name="method">Method for computing a fundamental matrix.</param>
    /// <param name="param1">Parameter used for RANSAC. 
    /// It is the maximum distance from a point to an epipolar line in pixels, beyond which the point is 
    /// considered an outlier and is not used for computing the final fundamental matrix. It can be set to 
    /// something like 1-3, depending on the accuracy of the point localization, image resolution, and the image noise.</param>
    /// <param name="param2">Parameter used for the RANSAC or LMedS methods only. 
    /// It specifies a desirable level of confidence (probability) that the estimated matrix is correct.</param>
    /// <param name="mask">Output array of N elements, every element of which is set to 0 for outliers and 
    /// to 1 for the other points. The array is computed only in the RANSAC and LMedS methods. For other methods, it is set to all 1’s.</param>
    /// <returns>fundamental matrix</returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static Mat FindFundamentalMat(
        IEnumerable<Point2f> points1, 
        IEnumerable<Point2f> points2,
        FundamentalMatMethods method = FundamentalMatMethods.Ransac,
        double param1 = 3.0,
        double param2 = 0.99,
        OutputArray? mask = null)
    {
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));

        var points1Array = points1 as Point2f[] ?? points1.ToArray();
        var points2Array = points2 as Point2f[] ?? points2.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_findFundamentalMat_arrayF32(
                points1Array, points1Array.Length,
                points2Array, points2Array.Length, (int) method,
                param1, param2, ToPtr(mask), out var ret));
        mask?.Fix();
        return new Mat(ret);
    }

    /// <summary>
    /// Calculates a fundamental matrix from the corresponding points in two images.
    /// </summary>
    /// <param name="points1">Array of N points from the first image. 
    /// The point coordinates should be floating-point (single or double precision).</param>
    /// <param name="points2">Array of the second image points of the same size and format as points1 .</param>
    /// <param name="method">Method for computing a fundamental matrix.</param>
    /// <param name="param1">Parameter used for RANSAC. 
    /// It is the maximum distance from a point to an epipolar line in pixels, beyond which the point is 
    /// considered an outlier and is not used for computing the final fundamental matrix. It can be set to 
    /// something like 1-3, depending on the accuracy of the point localization, image resolution, and the image noise.</param>
    /// <param name="param2">Parameter used for the RANSAC or LMedS methods only. 
    /// It specifies a desirable level of confidence (probability) that the estimated matrix is correct.</param>
    /// <param name="mask">Output array of N elements, every element of which is set to 0 for outliers and 
    /// to 1 for the other points. The array is computed only in the RANSAC and LMedS methods. For other methods, it is set to all 1’s.</param>
    /// <returns>fundamental matrix</returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static Mat FindFundamentalMat(
        IEnumerable<Point2d> points1, 
        IEnumerable<Point2d> points2,
        FundamentalMatMethods method = FundamentalMatMethods.Ransac,
        double param1 = 3.0,
        double param2 = 0.99,
        OutputArray? mask = null)
    {
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));

        var points1Array = points1 as Point2d[] ?? points1.ToArray();
        var points2Array = points2 as Point2d[] ?? points2.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_findFundamentalMat_arrayF64(
                points1Array, points1Array.Length,
                points2Array, points2Array.Length, (int) method,
                param1, param2, ToPtr(mask), out var ret));
        mask?.Fix();
        return new Mat(ret);
    }

    /// <summary>
    /// Calculates a fundamental matrix from the corresponding points in two images, using the
    /// USAC robust estimation framework (OpenCV 5).
    /// </summary>
    /// <param name="points1">Array of N points from the first image.</param>
    /// <param name="points2">Array of the second image points of the same size and format as points1.</param>
    /// <param name="mask">Output array of N elements; every element marks an inlier (1) or outlier (0).</param>
    /// <param name="params">USAC parameters. Null uses the defaults.</param>
    /// <returns>The estimated fundamental matrix.</returns>
    public static Mat FindFundamentalMat(InputArray points1, InputArray points2, OutputArray mask, UsacParams? @params)
    {
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));
        if (mask is null)
            throw new ArgumentNullException(nameof(mask));
        points1.ThrowIfDisposed();
        points2.ThrowIfDisposed();
        mask.ThrowIfNotReady();

        var p = (@params ?? new UsacParams()).ToNativeStruct();
        NativeMethods.HandleException(
            NativeMethods.geometry_findFundamentalMat_UsacParams(
                points1.CvPtr, points2.CvPtr, ToPtr(mask), ref p, out var ret));

        GC.KeepAlive(points1);
        GC.KeepAlive(points2);
        GC.KeepAlive(mask);
        mask.Fix();
        return new Mat(ret);
    }

    /// <summary>
    /// For points in an image of a stereo pair, computes the corresponding epilines in the other image.
    /// </summary>
    /// <param name="points">Input points. N \times 1 or 1 x N matrix of type CV_32FC2 or CV_64FC2.</param>
    /// <param name="whichImage">Index of the image (1 or 2) that contains the points .</param>
    /// <param name="F">Fundamental matrix that can be estimated using findFundamentalMat() or stereoRectify() .</param>
    /// <param name="lines">Output vector of the epipolar lines corresponding to the points in the other image.
    ///  Each line ax + by + c=0 is encoded by 3 numbers (a, b, c) .</param>
    public static void ComputeCorrespondEpilines(InputArray points,
        int whichImage,
        InputArray F,
        OutputArray lines)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        if (F is null)
            throw new ArgumentNullException(nameof(F));
        if (lines is null)
            throw new ArgumentNullException(nameof(lines));
        points.ThrowIfDisposed();
        F.ThrowIfDisposed();
        lines.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_computeCorrespondEpilines_InputArray(
                points.CvPtr, whichImage, F.CvPtr, lines.CvPtr));

        GC.KeepAlive(F);
        GC.KeepAlive(points);
        lines.Fix();
    }

    /// <summary>
    /// For points in an image of a stereo pair, computes the corresponding epilines in the other image.
    /// </summary>
    /// <param name="points">Input points. N \times 1 or 1 x N matrix of type CV_32FC2 or CV_64FC2.</param>
    /// <param name="whichImage">Index of the image (1 or 2) that contains the points .</param>
    /// <param name="F">Fundamental matrix that can be estimated using findFundamentalMat() or stereoRectify() .</param>
    /// <returns>Output vector of the epipolar lines corresponding to the points in the other image.
    ///  Each line ax + by + c=0 is encoded by 3 numbers (a, b, c) .</returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static Point3f[] ComputeCorrespondEpilines(IEnumerable<Point2d> points,
        int whichImage, double[,] F)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        if (F is null)
            throw new ArgumentNullException(nameof(F));
        if (F.GetLength(0) != 3 && F.GetLength(1) != 3)
            throw new ArgumentException("F != double[3,3]");

        var pointsArray = points as Point2d[] ?? points.ToArray();
        var lines = new Point3f[pointsArray.Length];

        unsafe
        {
            fixed (double* FPtr = F)
            {
                NativeMethods.HandleException(
                    NativeMethods.geometry_computeCorrespondEpilines_array2d(
                        pointsArray, pointsArray.Length,
                        whichImage, FPtr, lines));
            }
        }

        return lines;
    }
    /// <summary>
    /// For points in an image of a stereo pair, computes the corresponding epilines in the other image.
    /// </summary>
    /// <param name="points">Input points. N \times 1 or 1 x N matrix of type CV_32FC2 or CV_64FC2.</param>
    /// <param name="whichImage">Index of the image (1 or 2) that contains the points .</param>
    /// <param name="F">Fundamental matrix that can be estimated using findFundamentalMat() or stereoRectify() .</param>
    /// <returns>Output vector of the epipolar lines corresponding to the points in the other image.
    ///  Each line ax + by + c=0 is encoded by 3 numbers (a, b, c) .</returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static Point3f[] ComputeCorrespondEpilines(IEnumerable<Point3d> points,
        int whichImage, double[,] F)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        if (F is null)
            throw new ArgumentNullException(nameof(F));
        if (F.GetLength(0) != 3 && F.GetLength(1) != 3)
            throw new ArgumentException("F != double[3,3]");

        var pointsArray = points as Point3d[] ?? points.ToArray();
        var lines = new Point3f[pointsArray.Length];

        unsafe
        {
            fixed (double* FPtr = F)
            {
                NativeMethods.HandleException(
                    NativeMethods.geometry_computeCorrespondEpilines_array3d(
                        pointsArray, pointsArray.Length,
                        whichImage, FPtr, lines));
            }
        }

        return lines;
    }

    /// <summary>
    /// Reconstructs points by triangulation.
    /// </summary>
    /// <param name="projMatr1">3x4 projection matrix of the first camera.</param>
    /// <param name="projMatr2">3x4 projection matrix of the second camera.</param>
    /// <param name="projPoints1">2xN array of feature points in the first image. In case of c++ version 
    /// it can be also a vector of feature points or two-channel matrix of size 1xN or Nx1.</param>
    /// <param name="projPoints2">2xN array of corresponding points in the second image. In case of c++ version 
    /// it can be also a vector of feature points or two-channel matrix of size 1xN or Nx1.</param>
    /// <param name="points4D">4xN array of reconstructed points in homogeneous coordinates.</param>
    public static void TriangulatePoints(
        InputArray projMatr1, InputArray projMatr2,
        InputArray projPoints1, InputArray projPoints2,
        OutputArray points4D)
    {
        if (projMatr1 is null)
            throw new ArgumentNullException(nameof(projMatr1));
        if (projMatr2 is null)
            throw new ArgumentNullException(nameof(projMatr2));
        if (projPoints1 is null)
            throw new ArgumentNullException(nameof(projPoints1));
        if (projPoints2 is null)
            throw new ArgumentNullException(nameof(projPoints2));
        if (points4D is null)
            throw new ArgumentNullException(nameof(points4D));
        projMatr1.ThrowIfDisposed();
        projMatr2.ThrowIfDisposed();
        projPoints1.ThrowIfDisposed();
        projPoints2.ThrowIfDisposed();
        points4D.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_triangulatePoints_InputArray(
                projMatr1.CvPtr, projMatr2.CvPtr,
                projPoints1.CvPtr, projPoints2.CvPtr, points4D.CvPtr));

        GC.KeepAlive(projMatr1);
        GC.KeepAlive(projMatr2);
        GC.KeepAlive(projPoints1);
        GC.KeepAlive(projPoints2);
        points4D.Fix();
    }


    /// <summary>
    /// Reconstructs points by triangulation.
    /// </summary>
    /// <param name="projMatr1">3x4 projection matrix of the first camera.</param>
    /// <param name="projMatr2">3x4 projection matrix of the second camera.</param>
    /// <param name="projPoints1">2xN array of feature points in the first image. In case of c++ version 
    /// it can be also a vector of feature points or two-channel matrix of size 1xN or Nx1.</param>
    /// <param name="projPoints2">2xN array of corresponding points in the second image. In case of c++ version 
    /// it can be also a vector of feature points or two-channel matrix of size 1xN or Nx1.</param>
    /// <returns>4xN array of reconstructed points in homogeneous coordinates.</returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static Vec4d[] TriangulatePoints(
        double[,] projMatr1, 
        double[,] projMatr2,
        IEnumerable<Point2d> projPoints1, 
        IEnumerable<Point2d> projPoints2)
    {
        if (projMatr1 is null)
            throw new ArgumentNullException(nameof(projMatr1));
        if (projMatr2 is null)
            throw new ArgumentNullException(nameof(projMatr2));
        if (projPoints1 is null)
            throw new ArgumentNullException(nameof(projPoints1));
        if (projPoints2 is null)
            throw new ArgumentNullException(nameof(projPoints2));
        if (projMatr1.GetLength(0) != 3 && projMatr1.GetLength(1) != 4)
            throw new ArgumentException($"{nameof(projMatr1)} != double[3,4]");
        if (projMatr2.GetLength(0) != 3 && projMatr2.GetLength(1) != 4)
            throw new ArgumentException($"{nameof(projMatr2)} != double[3,4]");

        var projPoints1Array = projPoints1 as Point2d[] ?? projPoints1.ToArray();
        var projPoints2Array = projPoints2 as Point2d[] ?? projPoints2.ToArray();
        var points4D = new Vec4d[projPoints1Array.Length];

        unsafe
        {
            fixed (double* projMatr1Ptr = projMatr1)
            fixed (double* projMatr2Ptr = projMatr2)
            {
                NativeMethods.HandleException(
                    NativeMethods.geometry_triangulatePoints_array(
                        projMatr1Ptr, projMatr2Ptr,
                        projPoints1Array, projPoints1Array.Length,
                        projPoints2Array, projPoints2Array.Length,
                        points4D));
            }
        }

        return points4D;
    }

    /// <summary>
    /// Refines coordinates of corresponding points.
    /// </summary>
    /// <param name="F">3x3 fundamental matrix.</param>
    /// <param name="points1">1xN array containing the first set of points.</param>
    /// <param name="points2">1xN array containing the second set of points.</param>
    /// <param name="newPoints1">The optimized points1.</param>
    /// <param name="newPoints2">The optimized points2.</param>
    public static void CorrectMatches(
        InputArray F, InputArray points1, InputArray points2,
        OutputArray newPoints1, OutputArray newPoints2)
    {
        if (F is null)
            throw new ArgumentNullException(nameof(F));
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));
        if (newPoints1 is null)
            throw new ArgumentNullException(nameof(newPoints1));
        if (newPoints2 is null)
            throw new ArgumentNullException(nameof(newPoints2));
        F.ThrowIfDisposed();
        points1.ThrowIfDisposed();
        points2.ThrowIfDisposed();
        newPoints1.ThrowIfNotReady();
        newPoints2.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_correctMatches_InputArray(
                F.CvPtr, points1.CvPtr, points2.CvPtr,
                newPoints1.CvPtr, newPoints2.CvPtr));

        GC.KeepAlive(F);
        GC.KeepAlive(points1);
        GC.KeepAlive(points2);
        newPoints1.Fix();
        newPoints2.Fix();
    }

    /// <summary>
    /// Refines coordinates of corresponding points.
    /// </summary>
    /// <param name="F">3x3 fundamental matrix.</param>
    /// <param name="points1">1xN array containing the first set of points.</param>
    /// <param name="points2">1xN array containing the second set of points.</param>
    /// <param name="newPoints1">The optimized points1.</param>
    /// <param name="newPoints2">The optimized points2.</param>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static void CorrectMatches(
        double[,] F,
        IEnumerable<Point2d> points1,
        IEnumerable<Point2d> points2,
        out Point2d[] newPoints1,
        out Point2d[] newPoints2)
    {
        if (F is null)
            throw new ArgumentNullException(nameof(F));
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));

        var points1Array = points1 as Point2d[] ?? points1.ToArray();
        var points2Array = points2 as Point2d[] ?? points2.ToArray();
        newPoints1 = new Point2d[points1Array.Length];
        newPoints2 = new Point2d[points2Array.Length];

        unsafe
        {
            fixed (double* FPtr = F)
            {
                NativeMethods.HandleException(
                    NativeMethods.geometry_correctMatches_array(
                        FPtr, points1Array, points1Array.Length,
                        points2Array, points2Array.Length,
                        newPoints1, newPoints2));
            }
        }
    }

    /// <summary>
    /// Recover relative camera rotation and translation from an estimated essential matrix and the corresponding points in two images, using cheirality check.
    /// Returns the number of inliers which pass the check.
    /// </summary>
    /// <param name="E">The input essential matrix.</param>
    /// <param name="points1">Array of N 2D points from the first image. The point coordinates should be floating-point (single or double precision).</param>
    /// <param name="points2">Array of the second image points of the same size and format as points1.</param>
    /// <param name="cameraMatrix">Camera matrix K=⎡⎣⎢fx000fy0cxcy1⎤⎦⎥ . Note that this function assumes that points1 and points2 are feature points from cameras with the same camera matrix.</param>
    /// <param name="R">Recovered relative rotation.</param>
    /// <param name="t">Recovered relative translation.</param>
    /// <param name="mask">Input/output mask for inliers in points1 and points2. :
    /// If it is not empty, then it marks inliers in points1 and points2 for then given essential matrix E.
    /// Only these inliers will be used to recover pose. In the output mask only inliers which pass the cheirality check.
    /// This function decomposes an essential matrix using decomposeEssentialMat and then verifies possible pose hypotheses by doing cheirality check.
    /// The cheirality check basically means that the triangulated 3D points should have positive depth.</param>
    public static int RecoverPose(
        InputArray E, InputArray points1, InputArray points2, InputArray cameraMatrix,
        OutputArray R, OutputArray t,
        InputOutputArray? mask = null)
    {
        if (E is null)
            throw new ArgumentNullException(nameof(E));
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (R is null)
            throw new ArgumentNullException(nameof(R));
        if (t is null)
            throw new ArgumentNullException(nameof(t));
        E.ThrowIfDisposed();
        points1.ThrowIfDisposed();
        points2.ThrowIfDisposed();
        cameraMatrix.ThrowIfDisposed();
        R.ThrowIfNotReady();
        t.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_recoverPose_InputArray1(
                E.CvPtr, points1.CvPtr, points2.CvPtr, cameraMatrix.CvPtr,
                R.CvPtr, t.CvPtr, ToPtr(mask), out var ret));

        GC.KeepAlive(E);
        GC.KeepAlive(points1);
        GC.KeepAlive(points2);
        GC.KeepAlive(cameraMatrix);
        R.Fix();
        t.Fix();
        mask?.Fix();

        return ret;
    }

    /// <summary>
    /// Recover relative camera rotation and translation from an estimated essential matrix and the corresponding points in two images, using cheirality check.
    /// Returns the number of inliers which pass the check.
    /// </summary>
    /// <param name="E">The input essential matrix.</param>
    /// <param name="points1">Array of N 2D points from the first image. The point coordinates should be floating-point (single or double precision).</param>
    /// <param name="points2">Array of the second image points of the same size and format as points1.</param>
    /// <param name="R">Recovered relative rotation.</param>
    /// <param name="t">Recovered relative translation.</param>
    /// <param name="focal">Focal length of the camera. Note that this function assumes that points1 and points2 are feature points from cameras with same focal length and principal point.</param>
    /// <param name="pp">principal point of the camera.</param>
    /// <param name="mask">Input/output mask for inliers in points1 and points2. :
    /// If it is not empty, then it marks inliers in points1 and points2 for then given essential matrix E.
    /// Only these inliers will be used to recover pose. In the output mask only inliers which pass the cheirality check.
    /// This function decomposes an essential matrix using decomposeEssentialMat and then verifies possible pose hypotheses by doing cheirality check.
    /// The cheirality check basically means that the triangulated 3D points should have positive depth.</param>
    public static int RecoverPose(
        InputArray E, InputArray points1, InputArray points2,
        OutputArray R, OutputArray t, double focal, Point2d pp,
        InputOutputArray? mask = null)
    {
        if (E is null)
            throw new ArgumentNullException(nameof(E));
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));
        if (R is null)
            throw new ArgumentNullException(nameof(R));
        if (t is null)
            throw new ArgumentNullException(nameof(t));
        E.ThrowIfDisposed();
        points1.ThrowIfDisposed();
        points2.ThrowIfDisposed();
        R.ThrowIfNotReady();
        t.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_recoverPose_InputArray2(
                E.CvPtr, points1.CvPtr, points2.CvPtr,
                R.CvPtr, t.CvPtr, focal, pp, ToPtr(mask), out var ret));

        GC.KeepAlive(E);
        GC.KeepAlive(points1);
        GC.KeepAlive(points2);
        GC.KeepAlive(pp);
        R.Fix();
        t.Fix();
        mask?.Fix();

        return ret;
    }

    /// <summary>
    /// Recover relative camera rotation and translation from an estimated essential matrix and the corresponding points in two images, using cheirality check.
    /// Returns the number of inliers which pass the check.
    /// </summary>
    /// <param name="E">The input essential matrix.</param>
    /// <param name="points1">Array of N 2D points from the first image. The point coordinates should be floating-point (single or double precision).</param>
    /// <param name="points2">Array of the second image points of the same size and format as points1.</param>
    /// <param name="cameraMatrix">Camera matrix K=⎡⎣⎢fx000fy0cxcy1⎤⎦⎥ . Note that this function assumes that points1 and points2 are feature points from cameras with the same camera matrix.</param>
    /// <param name="R">Recovered relative rotation.</param>
    /// <param name="t">Recovered relative translation.</param>
    /// <param name="distanceTresh">threshold distance which is used to filter out far away points (i.e. infinite points).</param>
    /// <param name="mask">Input/output mask for inliers in points1 and points2. :
    /// If it is not empty, then it marks inliers in points1 and points2 for then given essential matrix E.
    /// Only these inliers will be used to recover pose. In the output mask only inliers which pass the cheirality check.
    /// This function decomposes an essential matrix using decomposeEssentialMat and then verifies possible pose hypotheses by doing cheirality check.
    /// The cheirality check basically means that the triangulated 3D points should have positive depth.</param>
    /// <param name="triangulatedPoints">3d points which were reconstructed by triangulation.</param>
    public static int RecoverPose(
        InputArray E, InputArray points1, InputArray points2, InputArray cameraMatrix,
        OutputArray R, OutputArray t, double distanceTresh,
        InputOutputArray? mask = null, OutputArray? triangulatedPoints = null)
    {
        if (E is null)
            throw new ArgumentNullException(nameof(E));
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (R is null)
            throw new ArgumentNullException(nameof(R));
        if (t is null)
            throw new ArgumentNullException(nameof(t));
        E.ThrowIfDisposed();
        points1.ThrowIfDisposed();
        points2.ThrowIfDisposed();
        cameraMatrix.ThrowIfDisposed();
        R.ThrowIfNotReady();
        t.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_recoverPose_InputArray3(
                E.CvPtr, points1.CvPtr, points2.CvPtr, cameraMatrix.CvPtr,
                R.CvPtr, t.CvPtr, distanceTresh, ToPtr(mask), ToPtr(triangulatedPoints), out var ret));

        GC.KeepAlive(E);
        GC.KeepAlive(points1);
        GC.KeepAlive(points2);
        GC.KeepAlive(cameraMatrix);
        R.Fix();
        t.Fix();
        mask?.Fix();
        triangulatedPoints?.Fix();

        return ret;
    }

    /// <summary>
    /// Calculates an essential matrix from the corresponding points in two images.
    /// </summary>
    /// <param name="points1">Array of N (N >= 5) 2D points from the first image.
    /// The point coordinates should be floating-point (single or double precision).</param>
    /// <param name="points2">Array of the second image points of the same size and format as points1 .</param>
    /// <param name="cameraMatrix">Camera matrix K=⎡⎣⎢fx000fy0cxcy1⎤⎦⎥ . Note that this function assumes that points1 and points2 are feature points from cameras with the same camera matrix.</param>
    /// <param name="method">Method for computing an essential matrix.
    /// RANSAC for the RANSAC algorithm.
    /// LMEDS for the LMedS algorithm.</param>
    /// <param name="prob">Parameter used for the RANSAC or LMedS methods only.
    /// It specifies a desirable level of confidence (probability) that the estimated matrix is correct.</param>
    /// <param name="threshold">Parameter used for RANSAC.
    /// It is the maximum distance from a point to an epipolar line in pixels, beyond which the point is considered an outlier and is not used for computing the final fundamental matrix.
    /// It can be set to something like 1-3, depending on the accuracy of the point localization, image resolution, and the image noise.</param>
    /// <param name="mask">Output array of N elements, every element of which is set to 0 for outliers and to 1 for the other points. The array is computed only in the RANSAC and LMedS methods.</param>
    /// <returns>essential matrix</returns>
    public static Mat FindEssentialMat(
        InputArray points1, InputArray points2, InputArray cameraMatrix,
        EssentialMatMethod method = EssentialMatMethod.Ransac,
        double prob = 0.999, double threshold = 1.0,
        OutputArray? mask = null)
    {
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        points1.ThrowIfDisposed();
        points2.ThrowIfDisposed();
        cameraMatrix.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.geometry_findEssentialMat_InputArray1(
                points1.CvPtr, points2.CvPtr, cameraMatrix.CvPtr,
                (int) method, prob, threshold, ToPtr(mask), out var ret));

        mask?.Fix();
        GC.KeepAlive(points1);
        GC.KeepAlive(points2);
        GC.KeepAlive(cameraMatrix);
        return new Mat(ret);
    }

    /// <summary>
    /// Calculates an essential matrix from the corresponding points in two images.
    /// </summary>
    /// <param name="points1">Array of N (N >= 5) 2D points from the first image.
    /// The point coordinates should be floating-point (single or double precision).</param>
    /// <param name="points2">Array of the second image por LMedS methods only.
    /// It specifies a desirable level of confidence (probability) that the estimated matrix is correct.</param>
    /// <param name="threshold">Parameter used for RANSAC.
    /// It is the maximum distance from a point to an epipolar line in pixels, beyond which the point is considered an outlier and is not used for computing the final fundamental matrix.
    /// It can be set to something like 1-3, depending on ints of the same size and format as points1 .</param>
    /// <param name="focal">Focal length of the camera. Note that this function assumes that points1 and points2 are feature points from cameras with same focal length and principal point.</param>
    /// <param name="pp">principal point of the camera.</param>
    /// <param name="method">Method for computing an essential matrix.
    /// RANSAC for the RANSAC algorithm.
    /// LMEDS for the LMedS algorithm.</param>
    /// <param name="prob">Parameter used for the RANSAC othe accuracy of the point localization, image resolution, and the image noise.</param>
    /// <param name="mask">Output array of N elements, every element of which is set to 0 for outliers and to 1 for the other points. The array is computed only in the RANSAC and LMedS methods.</param>
    /// <returns>essential matrix</returns>
    public static Mat FindEssentialMat(
        InputArray points1, InputArray points2, double focal, Point2d pp,
        EssentialMatMethod method = EssentialMatMethod.Ransac,
        double prob = 0.999, double threshold = 1.0,
        OutputArray? mask = null)
    {
        if (points1 is null)
            throw new ArgumentNullException(nameof(points1));
        if (points2 is null)
            throw new ArgumentNullException(nameof(points2));
        points1.ThrowIfDisposed();
        points2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.geometry_findEssentialMat_InputArray2(
                points1.CvPtr, points2.CvPtr, focal, pp,
                (int) method, prob, threshold, ToPtr(mask), out var ret));

        mask?.Fix();
        GC.KeepAlive(points1);
        GC.KeepAlive(points2);
        return new Mat(ret);
    }

    /// <summary>
    /// Computes an optimal affine transformation between two 3D point sets.
    /// </summary>
    /// <param name="src">First input 3D point set.</param>
    /// <param name="dst">Second input 3D point set.</param>
    /// <param name="outVal">Output 3D affine transformation matrix 3 x 4 .</param>
    /// <param name="inliers">Output vector indicating which points are inliers.</param>
    /// <param name="ransacThreshold">Maximum reprojection error in the RANSAC algorithm to consider a point as an inlier.</param>
    /// <param name="confidence">Confidence level, between 0 and 1, for the estimated transformation. 
    /// Anything between 0.95 and 0.99 is usually good enough. Values too close to 1 can slow down the estimation significantly. 
    /// Values lower than 0.8-0.9 can result in an incorrectly estimated transformation.</param>
    /// <returns></returns>
    public static int EstimateAffine3D(InputArray src, InputArray dst,
        OutputArray outVal, OutputArray inliers,
        double ransacThreshold = 3, double confidence = 0.99)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        if (outVal is null)
            throw new ArgumentNullException(nameof(outVal));
        if (inliers is null)
            throw new ArgumentNullException(nameof(inliers));
        src.ThrowIfDisposed();
        dst.ThrowIfDisposed();
        outVal.ThrowIfNotReady();
        inliers.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_estimateAffine3D(
                src.CvPtr, dst.CvPtr, outVal.CvPtr, inliers.CvPtr, ransacThreshold, confidence, out var ret));

        outVal.Fix();
        inliers.Fix();
        GC.KeepAlive(src);
        GC.KeepAlive(dst);
        return ret;
    }

    /// <summary>
    /// Calculates the Sampson Distance between two points.
    /// </summary>
    /// <param name="pt1">first homogeneous 2d point</param>
    /// <param name="pt2">second homogeneous 2d point</param>
    /// <param name="f">F fundamental matrix</param>
    /// <returns>The computed Sampson distance.</returns>
    /// <remarks>https://github.com/opencv/opencv/blob/master/modules/calib3d/src/fundam.cpp#L1109</remarks>
    public static double SampsonDistance(InputArray pt1, InputArray pt2, InputArray f)
    {
        if (pt1 is null)
            throw new ArgumentNullException(nameof(pt1));
        if (pt2 is null)
            throw new ArgumentNullException(nameof(pt2));
        if (f is null)
            throw new ArgumentNullException(nameof(f));
        pt1.ThrowIfDisposed();
        pt2.ThrowIfDisposed();
        f.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.geometry_sampsonDistance_InputArray(pt1.CvPtr, pt2.CvPtr, f.CvPtr, out var ret));

        GC.KeepAlive(pt1);
        GC.KeepAlive(pt2);

        return ret;
    }

    /// <summary>
    /// Calculates the Sampson Distance between two points.
    /// </summary>
    /// <param name="pt1">first homogeneous 2d point</param>
    /// <param name="pt2">second homogeneous 2d point</param>
    /// <param name="f">F fundamental matrix</param>
    /// <returns>The computed Sampson distance.</returns>
    /// <remarks>https://github.com/opencv/opencv/blob/master/modules/calib3d/src/fundam.cpp#L1109</remarks>
    public static double SampsonDistance(Point3d pt1, Point3d pt2, double[,] f)
    {
        if (f is null)
            throw new ArgumentNullException(nameof(f));
        if (f.GetLength(0) != 3 || f.GetLength(1) != 3)
            throw new ArgumentException("f should be 3x3 matrix", nameof(f));

        unsafe
        {
            fixed (double* fPtr = f)
            {
                NativeMethods.HandleException(
                    NativeMethods.geometry_sampsonDistance_Point3d(pt1, pt2, fPtr, out var ret));
                GC.KeepAlive(f);
                return ret;
            }
        }
    }
        
    /// <summary>
    /// Computes an optimal affine transformation between two 2D point sets.
    /// </summary>
    /// <param name="from">First input 2D point set containing (X,Y).</param>
    /// <param name="to">Second input 2D point set containing (x,y).</param>
    /// <param name="inliers">Output vector indicating which points are inliers (1-inlier, 0-outlier).</param>
    /// <param name="method">Robust method used to compute transformation.</param>
    /// <param name="ransacReprojThreshold">Maximum reprojection error in the RANSAC algorithm to consider a point as an inlier.Applies only to RANSAC.</param>
    /// <param name="maxIters">The maximum number of robust method iterations.</param>
    /// <param name="confidence">Confidence level, between 0 and 1, for the estimated transformation.
    /// Anything between 0.95 and 0.99 is usually good enough.Values too close to 1 can slow down the estimation
    /// significantly.Values lower than 0.8-0.9 can result in an incorrectly estimated transformation.</param>
    /// <param name="refineIters">Maximum number of iterations of refining algorithm (Levenberg-Marquardt).
    /// Passing 0 will disable refining, so the output matrix will be output of robust method.</param>
    /// <returns>Output 2D affine transformation matrix \f$2 \times 3\f$ or empty matrix if transformation could not be estimated.</returns>
    public static Mat? EstimateAffine2D(
        InputArray from, InputArray to, OutputArray? inliers = null,
        RobustEstimationAlgorithms method = RobustEstimationAlgorithms.RANSAC, double ransacReprojThreshold = 3,
        ulong maxIters = 2000, double confidence = 0.99,
        ulong refineIters = 10)
    {
        if (from is null)
            throw new ArgumentNullException(nameof(from));
        if (to is null)
            throw new ArgumentNullException(nameof(to));
        from.ThrowIfDisposed();
        to.ThrowIfDisposed();
        inliers?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_estimateAffine2D(
                from.CvPtr, to.CvPtr, ToPtr(inliers),
                (int) method, ransacReprojThreshold, maxIters, confidence, refineIters, out var matPtr));

        GC.KeepAlive(from);
        GC.KeepAlive(to);
        GC.KeepAlive(inliers);

        return (matPtr == IntPtr.Zero) ? null : new Mat(matPtr);
    }

    /// <summary>
    /// Computes an optimal limited affine transformation with 4 degrees of freedom between two 2D point sets.
    /// </summary>
    /// <param name="from">First input 2D point set.</param>
    /// <param name="to">Second input 2D point set.</param>
    /// <param name="inliers">Output vector indicating which points are inliers.</param>
    /// <param name="method">Robust method used to compute transformation. </param>
    /// <param name="ransacReprojThreshold">Maximum reprojection error in the RANSAC algorithm to consider a point as an inlier.Applies only to RANSAC.</param>
    /// <param name="maxIters">The maximum number of robust method iterations.</param>
    /// <param name="confidence">Confidence level, between 0 and 1, for the estimated transformation.
    /// Anything between 0.95 and 0.99 is usually good enough.Values too close to 1 can slow down the estimation 
    /// significantly.Values lower than 0.8-0.9 can result in an incorrectly estimated transformation.</param>
    /// <param name="refineIters"></param>
    /// <returns>Output 2D affine transformation (4 degrees of freedom) matrix 2x3 or empty matrix if transformation could not be estimated.</returns>
    public static Mat? EstimateAffinePartial2D(
        InputArray from, InputArray to, OutputArray? inliers = null,
        RobustEstimationAlgorithms method = RobustEstimationAlgorithms.RANSAC, double ransacReprojThreshold = 3,
        ulong maxIters = 2000, double confidence = 0.99,
        ulong refineIters = 10)
    {
        if (from is null)
            throw new ArgumentNullException(nameof(from));
        if (to is null)
            throw new ArgumentNullException(nameof(to));
        from.ThrowIfDisposed();
        to.ThrowIfDisposed();
        inliers?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_estimateAffinePartial2D(
                from.CvPtr, to.CvPtr, ToPtr(inliers),
                (int) method, ransacReprojThreshold, maxIters, confidence, refineIters, out var matPtr));

        GC.KeepAlive(from);
        GC.KeepAlive(to);
        GC.KeepAlive(inliers);

        return (matPtr == IntPtr.Zero) ? null : new Mat(matPtr);
    }

    /// <summary>
    /// Decompose a homography matrix to rotation(s), translation(s) and plane normal(s).
    /// </summary>
    /// <param name="h">The input homography matrix between two images.</param>
    /// <param name="k">The input intrinsic camera calibration matrix.</param>
    /// <param name="rotations">Array of rotation matrices.</param>
    /// <param name="translations">Array of translation matrices.</param>
    /// <param name="normals">Array of plane normal matrices.</param>
    /// <returns></returns>
    public static int DecomposeHomographyMat(
        InputArray h,
        InputArray k,
        out Mat[] rotations,
        out Mat[] translations,
        out Mat[] normals)
    {
        if (h is null)
            throw new ArgumentNullException(nameof(h));
        if (k is null)
            throw new ArgumentNullException(nameof(k));

        h.ThrowIfDisposed();
        k.ThrowIfDisposed();

        using var rotationsVec = new VectorOfMat();
        using var translationsVec = new VectorOfMat();
        using var normalsVec = new VectorOfMat();

        NativeMethods.HandleException(
            NativeMethods.geometry_decomposeHomographyMat(
                h.CvPtr, k.CvPtr, rotationsVec.CvPtr, translationsVec.CvPtr, normalsVec.CvPtr, out var ret));

        rotations = rotationsVec.ToArray();
        translations = translationsVec.ToArray();
        normals = normalsVec.ToArray();

        GC.KeepAlive(h);
        GC.KeepAlive(k);
        GC.KeepAlive(rotations);
        GC.KeepAlive(translations);
        GC.KeepAlive(normals);

        return ret;
    }

    /// <summary>
    /// Filters homography decompositions based on additional information.
    /// </summary>
    /// <param name="rotations">Vector of rotation matrices.</param>
    /// <param name="normals">Vector of plane normal matrices.</param>
    /// <param name="beforePoints">Vector of (rectified) visible reference points before the homography is applied</param>
    /// <param name="afterPoints">Vector of (rectified) visible reference points after the homography is applied</param>
    /// <param name="possibleSolutions">Vector of int indices representing the viable solution set after filtering</param>
    /// <param name="pointsMask">optional Mat/Vector of 8u type representing the mask for the inliers as given by the findHomography function</param>
    public static void FilterHomographyDecompByVisibleRefpoints(
        IEnumerable<Mat> rotations,
        IEnumerable<Mat> normals,
        InputArray beforePoints,
        InputArray afterPoints,
        OutputArray possibleSolutions,
        InputArray? pointsMask = null)
    {
        if (rotations is null)
            throw new ArgumentNullException(nameof(rotations));
        if (normals is null)
            throw new ArgumentNullException(nameof(normals));
        if (beforePoints is null)
            throw new ArgumentNullException(nameof(beforePoints));
        if (afterPoints is null)
            throw new ArgumentNullException(nameof(afterPoints));
        if (possibleSolutions is null)
            throw new ArgumentNullException(nameof(possibleSolutions));
        beforePoints.ThrowIfDisposed();
        afterPoints.ThrowIfDisposed();
        possibleSolutions.ThrowIfNotReady();
        pointsMask?.ThrowIfDisposed();

        using var rotationsVec = new VectorOfMat(rotations);
        using var normalsVec = new VectorOfMat(normals);
        NativeMethods.HandleException(
            NativeMethods.geometry_filterHomographyDecompByVisibleRefpoints(
                rotationsVec.CvPtr, normalsVec.CvPtr, beforePoints.CvPtr, afterPoints.CvPtr,
                possibleSolutions.CvPtr, ToPtr(pointsMask)));

        GC.KeepAlive(rotations);
        GC.KeepAlive(normals);
        GC.KeepAlive(beforePoints);
        GC.KeepAlive(afterPoints);
        GC.KeepAlive(possibleSolutions);
        GC.KeepAlive(pointsMask);
    }

    /// <summary>
    /// returns the default new camera matrix (by default it is the same as cameraMatrix unless centerPricipalPoint=true)
    /// </summary>
    /// <param name="cameraMatrix">Input camera matrix.</param>
    /// <param name="imgSize">Camera view image size in pixels.</param>
    /// <param name="centerPrincipalPoint">Location of the principal point in the new camera matrix. 
    /// The parameter indicates whether this location should be at the image center or not.</param>
    /// <returns>the camera matrix that is either an exact copy of the input cameraMatrix 
    /// (when centerPrinicipalPoint=false), or the modified one (when centerPrincipalPoint=true).</returns>
    public static Mat GetDefaultNewCameraMatrix(
        InputArray cameraMatrix, Size? imgSize = null, bool centerPrincipalPoint = false)
    {
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        cameraMatrix.ThrowIfDisposed();
        var imgSize0 = imgSize.GetValueOrDefault(new Size());

        NativeMethods.HandleException(
            NativeMethods.geometry_getDefaultNewCameraMatrix(
                cameraMatrix.CvPtr, imgSize0, centerPrincipalPoint ? 1 : 0, out var matPtr));
        GC.KeepAlive(cameraMatrix);
        return new Mat(matPtr);
    }

    /// <summary>
    /// Computes the ideal point coordinates from the observed point coordinates.
    /// </summary>
    /// <param name="src">Observed point coordinates, 1xN or Nx1 2-channel (CV_32FC2 or CV_64FC2).</param>
    /// <param name="dst">Output ideal point coordinates after undistortion and reverse perspective transformation. 
    /// If matrix P is identity or omitted, dst will contain normalized point coordinates.</param>
    /// <param name="cameraMatrix">Camera matrix</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// If the vector is null, the zero distortion coefficients are assumed.</param>
    /// <param name="r">Rectification transformation in the object space (3x3 matrix). 
    /// R1 or R2 computed by stereoRectify() can be passed here. 
    /// If the matrix is empty, the identity transformation is used.</param>
    /// <param name="p">New camera matrix (3x3) or new projection matrix (3x4). 
    /// P1 or P2 computed by stereoRectify() can be passed here. If the matrix is empty, 
    /// the identity new camera matrix is used.</param>
    public static void UndistortPoints(
        InputArray src, 
        OutputArray dst,
        InputArray cameraMatrix, 
        InputArray distCoeffs,
        InputArray? r = null, 
        InputArray? p = null)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();
        cameraMatrix.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.geometry_undistortPoints(
                src.CvPtr, dst.CvPtr, cameraMatrix.CvPtr,
                ToPtr(distCoeffs), ToPtr(r), ToPtr(p)));
            
        GC.KeepAlive(src);
        GC.KeepAlive(dst);
        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(distCoeffs);
        GC.KeepAlive(r);
        GC.KeepAlive(p);
        dst.Fix();
    }

    /// <summary>
    /// Computes the ideal point coordinates from the observed point coordinates.
    /// </summary>
    /// <param name="src">Observed point coordinates, 1xN or Nx1 2-channel (CV_32FC2 or CV_64FC2).</param>
    /// <param name="dst">Output ideal point coordinates after undistortion and reverse perspective transformation. 
    /// If matrix P is identity or omitted, dst will contain normalized point coordinates.</param>
    /// <param name="cameraMatrix">Camera matrix</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, or 8 elements. 
    /// If the vector is null, the zero distortion coefficients are assumed.</param>
    /// <param name="r">Rectification transformation in the object space (3x3 matrix). 
    /// R1 or R2 computed by stereoRectify() can be passed here. 
    /// If the matrix is empty, the identity transformation is used.</param>
    /// <param name="p">New camera matrix (3x3) or new projection matrix (3x4). 
    /// P1 or P2 computed by stereoRectify() can be passed here. If the matrix is empty, 
    /// the identity new camera matrix is used.</param>
    /// <param name="termCriteria"></param>
    public static void UndistortPointsIter(
        InputArray src, 
        OutputArray dst,
        InputArray cameraMatrix, 
        InputArray distCoeffs,
        InputArray? r = null, 
        InputArray? p = null,
        TermCriteria? termCriteria = null)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();
        cameraMatrix.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.geometry_undistortPointsIter(
                src.CvPtr, dst.CvPtr, cameraMatrix.CvPtr,
                ToPtr(distCoeffs), ToPtr(r), ToPtr(p), termCriteria.GetValueOrDefault()));
            
        GC.KeepAlive(src);
        GC.KeepAlive(dst);
        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(distCoeffs);
        GC.KeepAlive(r);
        GC.KeepAlive(p);
        dst.Fix();
    }

    /// <summary>
    /// Refines a pose (rotation and translation) from 3D-2D point correspondences, starting from an
    /// initial solution, using a Levenberg-Marquardt iterative scheme.
    /// </summary>
    /// <param name="objectPoints">Array of object points in the object coordinate space.</param>
    /// <param name="imagePoints">Array of corresponding image points.</param>
    /// <param name="cameraMatrix">Input camera intrinsic matrix.</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients. If empty, zero distortion is assumed.</param>
    /// <param name="rvec">Input/Output rotation vector. Input values are used as the initial solution.</param>
    /// <param name="tvec">Input/Output translation vector. Input values are used as the initial solution.</param>
    /// <param name="criteria">Criteria when to stop the Levenberg-Marquardt iterative algorithm.</param>
    public static void SolvePnPRefineLM(
        InputArray objectPoints, InputArray imagePoints, InputArray cameraMatrix, InputArray distCoeffs,
        InputOutputArray rvec, InputOutputArray tvec, TermCriteria? criteria = null)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints is null)
            throw new ArgumentNullException(nameof(imagePoints));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (distCoeffs is null)
            throw new ArgumentNullException(nameof(distCoeffs));
        if (rvec is null)
            throw new ArgumentNullException(nameof(rvec));
        if (tvec is null)
            throw new ArgumentNullException(nameof(tvec));
        objectPoints.ThrowIfDisposed();
        imagePoints.ThrowIfDisposed();
        cameraMatrix.ThrowIfDisposed();
        distCoeffs.ThrowIfDisposed();
        rvec.ThrowIfNotReady();
        tvec.ThrowIfNotReady();

        var c = criteria ?? new TermCriteria(CriteriaTypes.Eps | CriteriaTypes.MaxIter, 20, 1.1920929e-07);
        NativeMethods.HandleException(
            NativeMethods.geometry_solvePnPRefineLM(
                objectPoints.CvPtr, imagePoints.CvPtr, cameraMatrix.CvPtr, distCoeffs.CvPtr,
                rvec.CvPtr, tvec.CvPtr, c));

        rvec.Fix();
        tvec.Fix();
        GC.KeepAlive(objectPoints);
        GC.KeepAlive(imagePoints);
        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(distCoeffs);
        GC.KeepAlive(rvec);
        GC.KeepAlive(tvec);
    }

    /// <summary>
    /// Refines a pose (rotation and translation) from 3D-2D point correspondences, starting from an
    /// initial solution, using a virtual visual servoing (VVS) scheme.
    /// </summary>
    /// <param name="objectPoints">Array of object points in the object coordinate space.</param>
    /// <param name="imagePoints">Array of corresponding image points.</param>
    /// <param name="cameraMatrix">Input camera intrinsic matrix.</param>
    /// <param name="distCoeffs">Input vector of distortion coefficients. If empty, zero distortion is assumed.</param>
    /// <param name="rvec">Input/Output rotation vector. Input values are used as the initial solution.</param>
    /// <param name="tvec">Input/Output translation vector. Input values are used as the initial solution.</param>
    /// <param name="criteria">Criteria when to stop the iterative algorithm.</param>
    /// <param name="vvsLambda">Gain for the virtual visual servoing control law.</param>
    public static void SolvePnPRefineVVS(
        InputArray objectPoints, InputArray imagePoints, InputArray cameraMatrix, InputArray distCoeffs,
        InputOutputArray rvec, InputOutputArray tvec, TermCriteria? criteria = null, double vvsLambda = 1)
    {
        if (objectPoints is null)
            throw new ArgumentNullException(nameof(objectPoints));
        if (imagePoints is null)
            throw new ArgumentNullException(nameof(imagePoints));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (distCoeffs is null)
            throw new ArgumentNullException(nameof(distCoeffs));
        if (rvec is null)
            throw new ArgumentNullException(nameof(rvec));
        if (tvec is null)
            throw new ArgumentNullException(nameof(tvec));
        objectPoints.ThrowIfDisposed();
        imagePoints.ThrowIfDisposed();
        cameraMatrix.ThrowIfDisposed();
        distCoeffs.ThrowIfDisposed();
        rvec.ThrowIfNotReady();
        tvec.ThrowIfNotReady();

        var c = criteria ?? new TermCriteria(CriteriaTypes.Eps | CriteriaTypes.MaxIter, 20, 1.1920929e-07);
        NativeMethods.HandleException(
            NativeMethods.geometry_solvePnPRefineVVS(
                objectPoints.CvPtr, imagePoints.CvPtr, cameraMatrix.CvPtr, distCoeffs.CvPtr,
                rvec.CvPtr, tvec.CvPtr, c, vvsLambda));

        rvec.Fix();
        tvec.Fix();
        GC.KeepAlive(objectPoints);
        GC.KeepAlive(imagePoints);
        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(distCoeffs);
        GC.KeepAlive(rvec);
        GC.KeepAlive(tvec);
    }

    /// <summary>
    /// Decomposes an essential matrix to possible rotations and translation.
    /// </summary>
    /// <param name="e">The input essential matrix.</param>
    /// <param name="r1">One possible rotation matrix.</param>
    /// <param name="r2">Another possible rotation matrix.</param>
    /// <param name="t">One possible translation (up to scale).</param>
    public static void DecomposeEssentialMat(InputArray e, OutputArray r1, OutputArray r2, OutputArray t)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        if (r1 is null)
            throw new ArgumentNullException(nameof(r1));
        if (r2 is null)
            throw new ArgumentNullException(nameof(r2));
        if (t is null)
            throw new ArgumentNullException(nameof(t));
        e.ThrowIfDisposed();
        r1.ThrowIfNotReady();
        r2.ThrowIfNotReady();
        t.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_decomposeEssentialMat(e.CvPtr, r1.CvPtr, r2.CvPtr, t.CvPtr));

        r1.Fix();
        r2.Fix();
        t.Fix();
        GC.KeepAlive(e);
        GC.KeepAlive(r1);
        GC.KeepAlive(r2);
        GC.KeepAlive(t);
    }

    /// <summary>
    /// Computes an optimal translation between two 3D point sets using RANSAC.
    /// </summary>
    /// <param name="src">First input 3D point set.</param>
    /// <param name="dst">Second input 3D point set.</param>
    /// <param name="outVal">Output 3D translation vector (3x1).</param>
    /// <param name="inliers">Output vector indicating which points are inliers.</param>
    /// <param name="ransacThreshold">Maximum reprojection error in the RANSAC algorithm to consider a point as an inlier.</param>
    /// <param name="confidence">Confidence level, between 0 and 1.</param>
    /// <returns>True if a translation was found.</returns>
    public static bool EstimateTranslation3D(
        InputArray src, InputArray dst, OutputArray outVal, OutputArray inliers,
        double ransacThreshold = 3, double confidence = 0.99)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        if (outVal is null)
            throw new ArgumentNullException(nameof(outVal));
        if (inliers is null)
            throw new ArgumentNullException(nameof(inliers));
        src.ThrowIfDisposed();
        dst.ThrowIfDisposed();
        outVal.ThrowIfNotReady();
        inliers.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_estimateTranslation3D(
                src.CvPtr, dst.CvPtr, outVal.CvPtr, inliers.CvPtr, ransacThreshold, confidence, out var ret));

        outVal.Fix();
        inliers.Fix();
        GC.KeepAlive(src);
        GC.KeepAlive(dst);
        return ret != 0;
    }

    /// <summary>
    /// Computes an optimal translation between two 2D point sets.
    /// </summary>
    /// <param name="from">First input 2D point set.</param>
    /// <param name="to">Second input 2D point set.</param>
    /// <param name="inliers">Output vector indicating which points are inliers (optional).</param>
    /// <param name="method">Robust method used to compute the transformation.</param>
    /// <param name="ransacReprojThreshold">Maximum reprojection error in the RANSAC algorithm to consider a point as an inlier.</param>
    /// <param name="maxIters">The maximum number of robust method iterations.</param>
    /// <param name="confidence">Confidence level, between 0 and 1.</param>
    /// <param name="refineIters">Maximum number of iterations of refining algorithm (Levenberg-Marquardt).</param>
    /// <returns>The estimated 2D translation vector.</returns>
    public static Vec2d EstimateTranslation2D(
        InputArray from, InputArray to, OutputArray? inliers = null,
        RobustEstimationAlgorithms method = RobustEstimationAlgorithms.RANSAC, double ransacReprojThreshold = 3,
        ulong maxIters = 2000, double confidence = 0.99, ulong refineIters = 0)
    {
        if (from is null)
            throw new ArgumentNullException(nameof(from));
        if (to is null)
            throw new ArgumentNullException(nameof(to));
        from.ThrowIfDisposed();
        to.ThrowIfDisposed();
        inliers?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.geometry_estimateTranslation2D(
                from.CvPtr, to.CvPtr, ToPtr(inliers),
                (int)method, ransacReprojThreshold, maxIters, confidence, refineIters, out var ret));

        inliers?.Fix();
        GC.KeepAlive(from);
        GC.KeepAlive(to);
        GC.KeepAlive(inliers);
        return ret;
    }
}
