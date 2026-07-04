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
    public static void Rodrigues(InputArray src, OutputArray dst, OutputArray jacobian = default)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_Rodrigues(src.Proxy, dst.Proxy, jacobian.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(jacobian.Source);
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
        Rodrigues(vectorM, matrixM, jacobianM);
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
        Rodrigues(matrixM, vectorM, jacobianM);
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
        OutputArray mask = default, 
        int maxIters = 2000,
        double confidence = 0.995)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_findHomography_InputArray(
                srcPoints.Proxy, dstPoints.Proxy, (int)method,
                ransacReprojThreshold, mask.Proxy, maxIters, confidence,
                out var ret));

        GC.KeepAlive(srcPoints.Source);
        GC.KeepAlive(dstPoints.Source);
        GC.KeepAlive(mask.Source);
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
        OutputArray mask = default,
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
                (int)method, ransacReprojThreshold, mask.Proxy, maxIters, confidence,
                out var ret));

        GC.KeepAlive(mask.Source);
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
        var p = (@params ?? new UsacParams()).ToNativeStruct();
        NativeMethods.HandleException(
            NativeMethods.geometry_findHomography_UsacParams(
                srcPoints.Proxy, dstPoints.Proxy, mask.Proxy, ref p,
                out var ret));

        GC.KeepAlive(srcPoints.Source);
        GC.KeepAlive(dstPoints.Source);
        GC.KeepAlive(mask.Source);
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
        OutputArray qx = default, OutputArray qy = default, OutputArray qz = default)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_RQDecomp3x3_InputArray(
                src.Proxy, mtxR.Proxy, mtxQ.Proxy,
                qx.Proxy, qy.Proxy, qz.Proxy, out var ret));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(mtxR.Source);
        GC.KeepAlive(mtxQ.Source);
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
        OutputArray rotMatrixX = default,
        OutputArray rotMatrixY = default,
        OutputArray rotMatrixZ = default,
        OutputArray eulerAngles = default)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_decomposeProjectionMatrix_InputArray(
                projMatrix.Proxy, cameraMatrix.Proxy, rotMatrix.Proxy, transVect.Proxy,
                rotMatrixX.Proxy, rotMatrixY.Proxy, rotMatrixZ.Proxy, eulerAngles.Proxy));

        GC.KeepAlive(projMatrix.Source);
        GC.KeepAlive(cameraMatrix.Source);
        GC.KeepAlive(rotMatrix.Source);
        GC.KeepAlive(transVect.Source);
        GC.KeepAlive(rotMatrixX.Source);
        GC.KeepAlive(rotMatrixY.Source);
        GC.KeepAlive(rotMatrixZ.Source);
        GC.KeepAlive(eulerAngles.Source);

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
        NativeMethods.HandleException(
            NativeMethods.geometry_matMulDeriv(a.Proxy, b.Proxy, dABdA.Proxy, dABdB.Proxy));
        GC.KeepAlive(a.Source);
        GC.KeepAlive(b.Source);
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
        OutputArray dr3dr1 = default, OutputArray dr3dt1 = default,
        OutputArray dr3dr2 = default, OutputArray dr3dt2 = default,
        OutputArray dt3dr1 = default, OutputArray dt3dt1 = default,
        OutputArray dt3dr2 = default, OutputArray dt3dt2 = default)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_composeRT_InputArray(
                rvec1.Proxy, tvec1.Proxy, rvec2.Proxy, tvec2.Proxy, rvec3.Proxy, tvec3.Proxy,
                dr3dr1.Proxy, dr3dt1.Proxy, dr3dr2.Proxy, dr3dt2.Proxy,
                dt3dr1.Proxy, dt3dt1.Proxy, dt3dr2.Proxy, dt3dt2.Proxy));

        GC.KeepAlive(rvec1.Source);
        GC.KeepAlive(tvec1.Source);
        GC.KeepAlive(rvec2.Source);
        GC.KeepAlive(tvec2.Source);
        GC.KeepAlive(rvec3.Source);
        GC.KeepAlive(tvec3.Source);
        GC.KeepAlive(dr3dr1.Source);
        GC.KeepAlive(dr3dt1.Source);
        GC.KeepAlive(dr3dr2.Source);
        GC.KeepAlive(dr3dt2.Source);
        GC.KeepAlive(dt3dr1.Source);
        GC.KeepAlive(dt3dt1.Source);
        GC.KeepAlive(dt3dr2.Source);
        GC.KeepAlive(dt3dt2.Source);
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
        OutputArray jacobian = default,
        double aspectRatio = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_projectPoints_InputArray(
                objectPoints.Proxy,
                rvec.Proxy, tvec.Proxy, cameraMatrix.Proxy, distCoeffs.Proxy,
                imagePoints.Proxy, jacobian.Proxy, aspectRatio));

        GC.KeepAlive(objectPoints.Source);
        GC.KeepAlive(rvec.Source);
        GC.KeepAlive(tvec.Source);
        GC.KeepAlive(cameraMatrix.Source);
        GC.KeepAlive(distCoeffs.Source);
        GC.KeepAlive(imagePoints.Source);
        GC.KeepAlive(jacobian.Source);
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
        NativeMethods.HandleException(NativeMethods.geometry_solvePnP_InputArray(
            objectPoints.Proxy, imagePoints.Proxy, cameraMatrix.Proxy, distCoeffs.Proxy,
            rvec.Proxy, tvec.Proxy, useExtrinsicGuess ? 1 : 0, (int) flags));

        GC.KeepAlive(objectPoints.Source);
        GC.KeepAlive(imagePoints.Source);
        GC.KeepAlive(cameraMatrix.Source);
        GC.KeepAlive(distCoeffs.Source);
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
        OutputArray rvec,
        OutputArray tvec,
        bool useExtrinsicGuess = false,
        int iterationsCount = 100,
        float reprojectionError = 8.0f,
        double confidence = 0.99,
        OutputArray inliers = default,
        SolvePnPMethod flags = SolvePnPMethod.Iterative)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_solvePnPRansac_InputArray(
                objectPoints.Proxy, imagePoints.Proxy, cameraMatrix.Proxy, distCoeffs.Proxy,
                rvec.Proxy, tvec.Proxy, useExtrinsicGuess ? 1 : 0, iterationsCount,
                reprojectionError, confidence, inliers.Proxy, (int) flags));

        GC.KeepAlive(objectPoints.Source);
        GC.KeepAlive(imagePoints.Source);
        GC.KeepAlive(cameraMatrix.Source);
        GC.KeepAlive(distCoeffs.Source);
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

        using var inliersVec = new StdVector<int>();
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
        NativeMethods.HandleException(
            NativeMethods.geometry_calibrationMatrixValues_InputArray(
                cameraMatrix.Proxy, imageSize, apertureWidth, apertureHeight, 
                out fovx, out fovy, out focalLength, out principalPoint, out aspectRatio));
        GC.KeepAlive(cameraMatrix.Source);
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
        InputArray distCoeffs,
        Size imageSize,
        double alpha, 
        Size newImgSize,
        out Rect validPixROI,
        bool centerPrincipalPoint = false)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_getOptimalNewCameraMatrix_InputArray(
                cameraMatrix.Proxy, distCoeffs.Proxy, imageSize, alpha, newImgSize,
                out validPixROI, centerPrincipalPoint ? 1 : 0, out var ret));
        GC.KeepAlive(cameraMatrix.Source);
        GC.KeepAlive(distCoeffs.Source);
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
        NativeMethods.HandleException(
            NativeMethods.geometry_convertPointsToHomogeneous_InputArray(src.Proxy, dst.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
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
        NativeMethods.HandleException(
            NativeMethods.geometry_convertPointsFromHomogeneous_InputArray(src.Proxy, dst.Proxy));
        GC.KeepAlive(src.Source);
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
        NativeMethods.HandleException(
            NativeMethods.geometry_convertPointsHomogeneous(src.Proxy, dst.Proxy));
        GC.KeepAlive(src.Source);
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
        OutputArray mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_findFundamentalMat_InputArray(
                points1.Proxy, points2.Proxy, (int) method,
                param1, param2, mask.Proxy, out var ret));
        GC.KeepAlive(points1.Source);
        GC.KeepAlive(points2.Source);
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
        OutputArray mask = default)
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
                param1, param2, mask.Proxy, out var ret));
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
        OutputArray mask = default)
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
                param1, param2, mask.Proxy, out var ret));
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
        var p = (@params ?? new UsacParams()).ToNativeStruct();
        NativeMethods.HandleException(
            NativeMethods.geometry_findFundamentalMat_UsacParams(
                points1.Proxy, points2.Proxy, mask.Proxy, ref p, out var ret));

        GC.KeepAlive(points1.Source);
        GC.KeepAlive(points2.Source);
        GC.KeepAlive(mask.Source);
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
        NativeMethods.HandleException(
            NativeMethods.geometry_computeCorrespondEpilines_InputArray(
                points.Proxy, whichImage, F.Proxy, lines.Proxy));

        GC.KeepAlive(F.Source);
        GC.KeepAlive(points.Source);
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
        NativeMethods.HandleException(
            NativeMethods.geometry_triangulatePoints_InputArray(
                projMatr1.Proxy, projMatr2.Proxy,
                projPoints1.Proxy, projPoints2.Proxy, points4D.Proxy));

        GC.KeepAlive(projMatr1.Source);
        GC.KeepAlive(projMatr2.Source);
        GC.KeepAlive(projPoints1.Source);
        GC.KeepAlive(projPoints2.Source);
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
        NativeMethods.HandleException(
            NativeMethods.geometry_correctMatches_InputArray(
                F.Proxy, points1.Proxy, points2.Proxy,
                newPoints1.Proxy, newPoints2.Proxy));

        GC.KeepAlive(F.Source);
        GC.KeepAlive(points1.Source);
        GC.KeepAlive(points2.Source);
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
        InputOutputArray mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_recoverPose_InputArray1(
                E.Proxy, points1.Proxy, points2.Proxy, cameraMatrix.Proxy,
                R.Proxy, t.Proxy, mask.Proxy, out var ret));

        GC.KeepAlive(E.Source);
        GC.KeepAlive(points1.Source);
        GC.KeepAlive(points2.Source);
        GC.KeepAlive(cameraMatrix.Source);

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
        InputOutputArray mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_recoverPose_InputArray2(
                E.Proxy, points1.Proxy, points2.Proxy,
                R.Proxy, t.Proxy, focal, pp, mask.Proxy, out var ret));

        GC.KeepAlive(E.Source);
        GC.KeepAlive(points1.Source);
        GC.KeepAlive(points2.Source);
        GC.KeepAlive(pp);

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
        InputOutputArray mask = default, OutputArray triangulatedPoints = default)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_recoverPose_InputArray3(
                E.Proxy, points1.Proxy, points2.Proxy, cameraMatrix.Proxy,
                R.Proxy, t.Proxy, distanceTresh, mask.Proxy, triangulatedPoints.Proxy, out var ret));

        GC.KeepAlive(E.Source);
        GC.KeepAlive(points1.Source);
        GC.KeepAlive(points2.Source);
        GC.KeepAlive(cameraMatrix.Source);

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
        OutputArray mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_findEssentialMat_InputArray1(
                points1.Proxy, points2.Proxy, cameraMatrix.Proxy,
                (int) method, prob, threshold, mask.Proxy, out var ret));

        GC.KeepAlive(points1.Source);
        GC.KeepAlive(points2.Source);
        GC.KeepAlive(cameraMatrix.Source);
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
        OutputArray mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_findEssentialMat_InputArray2(
                points1.Proxy, points2.Proxy, focal, pp,
                (int) method, prob, threshold, mask.Proxy, out var ret));

        GC.KeepAlive(points1.Source);
        GC.KeepAlive(points2.Source);
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
        NativeMethods.HandleException(
            NativeMethods.geometry_estimateAffine3D(
                src.Proxy, dst.Proxy, outVal.Proxy, inliers.Proxy, ransacThreshold, confidence, out var ret));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
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
        NativeMethods.HandleException(
            NativeMethods.geometry_sampsonDistance_InputArray(pt1.Proxy, pt2.Proxy, f.Proxy, out var ret));

        GC.KeepAlive(pt1.Source);
        GC.KeepAlive(pt2.Source);

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
        InputArray from, InputArray to, OutputArray inliers = default,
        RobustEstimationAlgorithms method = RobustEstimationAlgorithms.RANSAC, double ransacReprojThreshold = 3,
        ulong maxIters = 2000, double confidence = 0.99,
        ulong refineIters = 10)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_estimateAffine2D(
                from.Proxy, to.Proxy, inliers.Proxy,
                (int) method, ransacReprojThreshold, maxIters, confidence, refineIters, out var matPtr));

        GC.KeepAlive(from.Source);
        GC.KeepAlive(to.Source);
        GC.KeepAlive(inliers.Source);

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
        InputArray from, InputArray to, OutputArray inliers = default,
        RobustEstimationAlgorithms method = RobustEstimationAlgorithms.RANSAC, double ransacReprojThreshold = 3,
        ulong maxIters = 2000, double confidence = 0.99,
        ulong refineIters = 10)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_estimateAffinePartial2D(
                from.Proxy, to.Proxy, inliers.Proxy,
                (int) method, ransacReprojThreshold, maxIters, confidence, refineIters, out var matPtr));

        GC.KeepAlive(from.Source);
        GC.KeepAlive(to.Source);
        GC.KeepAlive(inliers.Source);

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
        using var rotationsVec = new VectorOfMat();
        using var translationsVec = new VectorOfMat();
        using var normalsVec = new VectorOfMat();

        NativeMethods.HandleException(
            NativeMethods.geometry_decomposeHomographyMat(
                h.Proxy, k.Proxy, rotationsVec.CvPtr, translationsVec.CvPtr, normalsVec.CvPtr, out var ret));

        rotations = rotationsVec.ToArray();
        translations = translationsVec.ToArray();
        normals = normalsVec.ToArray();

        GC.KeepAlive(h.Source);
        GC.KeepAlive(k.Source);
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
        InputArray pointsMask = default)
    {
        if (rotations is null)
            throw new ArgumentNullException(nameof(rotations));
        if (normals is null)
            throw new ArgumentNullException(nameof(normals));

        using var rotationsVec = new VectorOfMat(rotations);
        using var normalsVec = new VectorOfMat(normals);
        NativeMethods.HandleException(
            NativeMethods.geometry_filterHomographyDecompByVisibleRefpoints(
                rotationsVec.CvPtr, normalsVec.CvPtr, beforePoints.Proxy, afterPoints.Proxy,
                possibleSolutions.Proxy, pointsMask.Proxy));

        GC.KeepAlive(rotations);
        GC.KeepAlive(normals);
        GC.KeepAlive(beforePoints.Source);
        GC.KeepAlive(afterPoints.Source);
        GC.KeepAlive(possibleSolutions.Source);
        GC.KeepAlive(pointsMask.Source);
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
        var imgSize0 = imgSize.GetValueOrDefault(new Size());

        NativeMethods.HandleException(
            NativeMethods.geometry_getDefaultNewCameraMatrix(
                cameraMatrix.Proxy, imgSize0, centerPrincipalPoint ? 1 : 0, out var matPtr));
        GC.KeepAlive(cameraMatrix.Source);
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
        InputArray r = default, 
        InputArray p = default)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_undistortPoints(
                src.Proxy, dst.Proxy, cameraMatrix.Proxy,
                distCoeffs.Proxy, r.Proxy, p.Proxy));
            
        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(cameraMatrix.Source);
        GC.KeepAlive(distCoeffs.Source);
        GC.KeepAlive(r.Source);
        GC.KeepAlive(p.Source);
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
        InputArray r = default, 
        InputArray p = default,
        TermCriteria? termCriteria = null)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_undistortPointsIter(
                src.Proxy, dst.Proxy, cameraMatrix.Proxy,
                distCoeffs.Proxy, r.Proxy, p.Proxy, termCriteria.GetValueOrDefault()));
            
        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(cameraMatrix.Source);
        GC.KeepAlive(distCoeffs.Source);
        GC.KeepAlive(r.Source);
        GC.KeepAlive(p.Source);
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
        var c = criteria ?? new TermCriteria(CriteriaTypes.Eps | CriteriaTypes.MaxIter, 20, 1.1920929e-07);
        NativeMethods.HandleException(
            NativeMethods.geometry_solvePnPRefineLM(
                objectPoints.Proxy, imagePoints.Proxy, cameraMatrix.Proxy, distCoeffs.Proxy,
                rvec.Proxy, tvec.Proxy, c));

        GC.KeepAlive(objectPoints.Source);
        GC.KeepAlive(imagePoints.Source);
        GC.KeepAlive(cameraMatrix.Source);
        GC.KeepAlive(distCoeffs.Source);
        GC.KeepAlive(rvec.Source);
        GC.KeepAlive(tvec.Source);
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
        var c = criteria ?? new TermCriteria(CriteriaTypes.Eps | CriteriaTypes.MaxIter, 20, 1.1920929e-07);
        NativeMethods.HandleException(
            NativeMethods.geometry_solvePnPRefineVVS(
                objectPoints.Proxy, imagePoints.Proxy, cameraMatrix.Proxy, distCoeffs.Proxy,
                rvec.Proxy, tvec.Proxy, c, vvsLambda));

        GC.KeepAlive(objectPoints.Source);
        GC.KeepAlive(imagePoints.Source);
        GC.KeepAlive(cameraMatrix.Source);
        GC.KeepAlive(distCoeffs.Source);
        GC.KeepAlive(rvec.Source);
        GC.KeepAlive(tvec.Source);
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
        NativeMethods.HandleException(
            NativeMethods.geometry_decomposeEssentialMat(e.Proxy, r1.Proxy, r2.Proxy, t.Proxy));

        GC.KeepAlive(e.Source);
        GC.KeepAlive(r1.Source);
        GC.KeepAlive(r2.Source);
        GC.KeepAlive(t.Source);
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
        NativeMethods.HandleException(
            NativeMethods.geometry_estimateTranslation3D(
                src.Proxy, dst.Proxy, outVal.Proxy, inliers.Proxy, ransacThreshold, confidence, out var ret));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
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
        InputArray from, InputArray to, OutputArray inliers = default,
        RobustEstimationAlgorithms method = RobustEstimationAlgorithms.RANSAC, double ransacReprojThreshold = 3,
        ulong maxIters = 2000, double confidence = 0.99, ulong refineIters = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_estimateTranslation2D(
                from.Proxy, to.Proxy, inliers.Proxy,
                (int)method, ransacReprojThreshold, maxIters, confidence, refineIters, out var ret));

        GC.KeepAlive(from.Source);
        GC.KeepAlive(to.Source);
        GC.KeepAlive(inliers.Source);
        return ret;
    }

    /// <summary>
    /// Approximates a polygon with a convex hull with a specified accuracy and number of sides.
    /// </summary>
    /// <param name="curve">Input vector of a 2D points stored in std::vector or Mat, points must be float or integer.</param>
    /// <param name="approxCurve">Result of the approximation. The type is vector of a 2D point (Point2f or Point) in std::vector or Mat.</param>
    /// <param name="nsides">The parameter defines the number of sides of the result polygon.</param>
    /// <param name="epsilonPercentage">Defines the percentage of the maximum of additional area. If it equals -1, it is not used.
    /// Otherwise the algorithm stops if the additional area is greater than contourArea(curve) * percentage. If the additional
    /// area exceeds the limit, the algorithm returns as many vertices as there were at the moment the limit was exceeded.</param>
    /// <param name="ensureConvex">If true, the algorithm creates a convex hull of the input contour. Otherwise the input vector should already be convex.</param>
    public static void ApproxPolyN(
        InputArray curve, OutputArray approxCurve, int nsides, float epsilonPercentage = -1.0f, bool ensureConvex = true)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_approxPolyN(curve.Proxy, approxCurve.Proxy, nsides, epsilonPercentage, ensureConvex ? 1 : 0));

        GC.KeepAlive(curve.Source);
        GC.KeepAlive(approxCurve.Source);
    }

    /// <summary>
    /// Finds a convex polygon of minimum area enclosing a 2D point set and returns its area.
    /// </summary>
    /// <param name="points">Input vector of 2D points, stored in std::vector or Mat.</param>
    /// <param name="polygon">Output vector of 2D points defining the vertices of the enclosing polygon.</param>
    /// <param name="k">Number of vertices of the output polygon.</param>
    /// <returns>The area of the minimal enclosing polygon.</returns>
    public static double MinEnclosingConvexPolygon(InputArray points, OutputArray polygon, int k)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_minEnclosingConvexPolygon(points.Proxy, polygon.Proxy, k, out var ret));

        GC.KeepAlive(points.Source);
        GC.KeepAlive(polygon.Source);
        return ret;
    }

    /// <summary>
    /// Computes for each 2D point the nearest 2D point located on a given ellipse.
    /// </summary>
    /// <param name="ellipseParams">Ellipse parameters.</param>
    /// <param name="points">Input 2D points.</param>
    /// <param name="closestPts">For each 2D point, its corresponding closest 2D point located on the ellipse.</param>
    public static void GetClosestEllipsePoints(RotatedRect ellipseParams, InputArray points, OutputArray closestPts)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_getClosestEllipsePoints(ellipseParams, points.Proxy, closestPts.Proxy));

        GC.KeepAlive(points.Source);
        GC.KeepAlive(closestPts.Source);
    }

    /// <summary>
    /// Builds a Minimum Spanning Tree (MST) using the specified algorithm.
    ///
    /// Supports graphs with negative edge weights. Self-loop edges (edges where source and target are the
    /// same) are ignored. If multiple edges exist between the same pair of nodes, only the one with the
    /// lowest weight is considered. If the graph is disconnected or input is invalid, the function
    /// returns false.
    /// </summary>
    /// <param name="numNodes">Number of nodes in the graph (must be greater than 0).</param>
    /// <param name="inputEdges">Input array of edges representing the graph.</param>
    /// <param name="algorithm">Specifies which algorithm to use to compute the MST.</param>
    /// <param name="root">Starting node for the MST algorithm (only used for certain algorithms).</param>
    /// <returns>The edges of the resulting MST, or null if a valid MST could not be built.</returns>
    public static MSTEdge[]? BuildMST(int numNodes, MSTEdge[] inputEdges, MSTAlgorithm algorithm, int root = 0)
    {
        if (inputEdges is null)
            throw new ArgumentNullException(nameof(inputEdges));
        if (numNodes <= 0)
            throw new ArgumentOutOfRangeException(nameof(numNodes));

        var resultingEdges = new MSTEdge[numNodes - 1];
        NativeMethods.HandleException(
            NativeMethods.geometry_buildMST(
                numNodes, inputEdges, inputEdges.Length, (int)algorithm, root,
                resultingEdges, out var resultingEdgesCount, out var ret));

        if (ret == 0)
            return null;
        if (resultingEdgesCount != resultingEdges.Length)
            Array.Resize(ref resultingEdges, resultingEdgesCount);
        return resultingEdges;
    }

    /// <summary>
    /// Point cloud sampling by Voxel Grid filter downsampling.
    ///
    /// Creates a 3D voxel grid (a set of tiny 3D boxes in space) over the input point cloud data.
    /// In each voxel, all the points present are approximated (downsampled) with the point closest to their centroid.
    /// </summary>
    /// <param name="sampledPointFlags">Output flags of the sampled points. sampledPointFlags[i] is 1 if the i-th point is selected, 0 otherwise.</param>
    /// <param name="inputPts">Original point cloud, Mat of size Nx3/3xN.</param>
    /// <param name="length">Grid length.</param>
    /// <param name="width">Grid width.</param>
    /// <param name="height">Grid height.</param>
    /// <returns>The number of points actually sampled.</returns>
    public static int VoxelGridSampling(OutputArray sampledPointFlags, InputArray inputPts, float length, float width, float height)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_voxelGridSampling(sampledPointFlags.Proxy, inputPts.Proxy, length, width, height, out var ret));

        GC.KeepAlive(sampledPointFlags.Source);
        GC.KeepAlive(inputPts.Source);
        return ret;
    }

    /// <summary>
    /// Point cloud sampling by randomly selecting points.
    /// </summary>
    /// <param name="sampledPts">Point cloud after sampling.</param>
    /// <param name="inputPts">Original point cloud, Mat of size Nx3/3xN.</param>
    /// <param name="sampledPtsSize">The desired point cloud size after sampling.</param>
    public static void RandomSampling(OutputArray sampledPts, InputArray inputPts, int sampledPtsSize)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_randomSampling_Size(sampledPts.Proxy, inputPts.Proxy, sampledPtsSize));

        GC.KeepAlive(sampledPts.Source);
        GC.KeepAlive(inputPts.Source);
    }

    /// <summary>
    /// Point cloud sampling by randomly selecting points.
    /// </summary>
    /// <param name="sampledPts">Point cloud after sampling.</param>
    /// <param name="inputPts">Original point cloud, Mat of size Nx3/3xN.</param>
    /// <param name="sampledScale">Range (0, 1); the percentage of the sampled point cloud relative to the original size.</param>
    public static void RandomSampling(OutputArray sampledPts, InputArray inputPts, float sampledScale)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_randomSampling_Scale(sampledPts.Proxy, inputPts.Proxy, sampledScale));

        GC.KeepAlive(sampledPts.Source);
        GC.KeepAlive(inputPts.Source);
    }

    /// <summary>
    /// Point cloud sampling by Farthest Point Sampling (FPS).
    /// </summary>
    /// <param name="sampledPointFlags">Output flags of the sampled points. sampledPointFlags[i] is 1 if the i-th point is selected, 0 otherwise.</param>
    /// <param name="inputPts">Original point cloud, Mat of size Nx3/3xN.</param>
    /// <param name="sampledPtsSize">The desired point cloud size after sampling.</param>
    /// <param name="distLowerLimit">Sampling is terminated early if the distance from the farthest point to the sampled set is less than this value.</param>
    /// <returns>The number of points actually sampled.</returns>
    public static int FarthestPointSampling(OutputArray sampledPointFlags, InputArray inputPts, int sampledPtsSize, float distLowerLimit = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_farthestPointSampling_Size(
                sampledPointFlags.Proxy, inputPts.Proxy, sampledPtsSize, distLowerLimit, out var ret));

        GC.KeepAlive(sampledPointFlags.Source);
        GC.KeepAlive(inputPts.Source);
        return ret;
    }

    /// <summary>
    /// Point cloud sampling by Farthest Point Sampling (FPS).
    /// </summary>
    /// <param name="sampledPointFlags">Output flags of the sampled points. sampledPointFlags[i] is 1 if the i-th point is selected, 0 otherwise.</param>
    /// <param name="inputPts">Original point cloud, Mat of size Nx3/3xN.</param>
    /// <param name="sampledScale">Range (0, 1); the percentage of the sampled point cloud relative to the original size.</param>
    /// <param name="distLowerLimit">Sampling is terminated early if the distance from the farthest point to the sampled set is less than this value.</param>
    /// <returns>The number of points actually sampled.</returns>
    public static int FarthestPointSampling(OutputArray sampledPointFlags, InputArray inputPts, float sampledScale, float distLowerLimit = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_farthestPointSampling_Scale(
                sampledPointFlags.Proxy, inputPts.Proxy, sampledScale, distLowerLimit, out var ret));

        GC.KeepAlive(sampledPointFlags.Source);
        GC.KeepAlive(inputPts.Source);
        return ret;
    }

    /// <summary>
    /// Estimates the normal and curvature of each point in a point cloud from nearest-neighbor results.
    /// </summary>
    /// <param name="normals">Output normal of each point, Mat of size Nx3.</param>
    /// <param name="curvatures">Output curvature of each point.</param>
    /// <param name="inputPts">Original point cloud, Mat of size Nx3/3xN.</param>
    /// <param name="nnIdx">Index information of the nearest neighbors of all points, Mat of size NxK. The first nearest
    /// neighbor of each point is itself.</param>
    /// <param name="maxNeighborNum">The maximum number of neighbors to use, including the point itself. A non-positive
    /// number (the default) uses the information from <paramref name="nnIdx"/>.</param>
    public static void NormalEstimate(OutputArray normals, OutputArray curvatures, InputArray inputPts, InputArray nnIdx, int maxNeighborNum = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_normalEstimate(normals.Proxy, curvatures.Proxy, inputPts.Proxy, nnIdx.Proxy, maxNeighborNum));

        GC.KeepAlive(normals.Source);
        GC.KeepAlive(curvatures.Source);
        GC.KeepAlive(inputPts.Source);
        GC.KeepAlive(nnIdx.Source);
    }

    /// <summary>
    /// Calculates an affine matrix of 2D rotation.
    /// </summary>
    /// <param name="center">Center of the rotation in the source image.</param>
    /// <param name="angle">Rotation angle in degrees. Positive values mean counter-clockwise rotation (the coordinate origin is assumed to be the top-left corner).</param>
    /// <param name="scale">Isotropic scale factor.</param>
    /// <returns></returns>
    public static Mat GetRotationMatrix2D(Point2f center, double angle, double scale)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_getRotationMatrix2D(center, angle, scale, out var retMat));
        return new Mat(retMat);
    }


    /// <summary>
    /// Inverts an affine transformation.
    /// </summary>
    /// <param name="m">Original affine transformation.</param>
    /// <param name="im">Output reverse affine transformation.</param>
    public static void InvertAffineTransform(InputArray m, OutputArray im)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_invertAffineTransform(m.Proxy, im.Proxy));
        GC.KeepAlive(m.Source);
        GC.KeepAlive(im.Source);
    }


    /// <summary>
    /// Calculates a perspective transform from four pairs of the corresponding points.
    /// The function calculates the 3×3 matrix of a perspective transform.
    /// </summary>
    /// <param name="src">Coordinates of quadrangle vertices in the source image.</param>
    /// <param name="dst">Coordinates of the corresponding quadrangle vertices in the destination image.</param>
    /// <returns></returns>
    public static Mat GetPerspectiveTransform(IEnumerable<Point2f> src, IEnumerable<Point2f> dst)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));

        var srcArray = src.ToArray();
        var dstArray = dst.ToArray();
        NativeMethods.HandleException(
            NativeMethods.geometry_getPerspectiveTransform1(srcArray, dstArray, out var retMat));
        return new Mat(retMat);
    }


    /// <summary>
    /// Calculates a perspective transform from four pairs of the corresponding points.
    /// The function calculates the 3×3 matrix of a perspective transform.
    /// </summary>
    /// <param name="src">Coordinates of quadrangle vertices in the source image.</param>
    /// <param name="dst">Coordinates of the corresponding quadrangle vertices in the destination image.</param>
    /// <returns></returns>
    public static Mat GetPerspectiveTransform(InputArray src, InputArray dst)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_getPerspectiveTransform2(src.Proxy, dst.Proxy, out var retMat));
        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        return new Mat(retMat);
    }


    /// <summary>
    /// Calculates an affine transform from three pairs of the corresponding points.
    /// The function calculates the 2×3 matrix of an affine transform.
    /// </summary>
    /// <param name="src">Coordinates of triangle vertices in the source image.</param>
    /// <param name="dst">Coordinates of the corresponding triangle vertices in the destination image.</param>
    /// <returns></returns>
    public static Mat GetAffineTransform(IEnumerable<Point2f> src, IEnumerable<Point2f> dst)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));

        var srcArray = src.ToArray();
        var dstArray = dst.ToArray();
        NativeMethods.HandleException(
            NativeMethods.geometry_getAffineTransform1(srcArray, dstArray, out var retMat));
        return new Mat(retMat);
    }


    /// <summary>
    /// Calculates an affine transform from three pairs of the corresponding points.
    /// The function calculates the 2×3 matrix of an affine transform.
    /// </summary>
    /// <param name="src">Coordinates of triangle vertices in the source image.</param>
    /// <param name="dst">Coordinates of the corresponding triangle vertices in the destination image.</param>
    /// <returns></returns>
    public static Mat GetAffineTransform(InputArray src, InputArray dst)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_getAffineTransform2(src.Proxy, dst.Proxy, out var retMat));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        return new Mat(retMat);
    }


    /// <summary>
    /// Approximates contour or a curve using Douglas-Peucker algorithm
    /// </summary>
    /// <param name="curve">The polygon or curve to approximate. 
    /// Must be 1 x N or N x 1 matrix of type CV_32SC2 or CV_32FC2.</param>
    /// <param name="approxCurve">The result of the approximation; 
    /// The type should match the type of the input curve</param>
    /// <param name="epsilon">Specifies the approximation accuracy. 
    /// This is the maximum distance between the original curve and its approximation.</param>
    /// <param name="closed">The result of the approximation; 
    /// The type should match the type of the input curve</param>
    public static void ApproxPolyDP(InputArray curve, OutputArray approxCurve, double epsilon, bool closed)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_approxPolyDP_InputArray(curve.Proxy, approxCurve.Proxy, epsilon, closed ? 1 : 0));

        GC.KeepAlive(curve.Source);
        GC.KeepAlive(approxCurve.Source);
    }


    /// <summary>
    /// Approximates contour or a curve using Douglas-Peucker algorithm
    /// </summary>
    /// <param name="curve">The polygon or curve to approximate.</param>
    /// <param name="epsilon">Specifies the approximation accuracy. 
    /// This is the maximum distance between the original curve and its approximation.</param>
    /// <param name="closed">The result of the approximation; 
    /// The type should match the type of the input curve</param>
    /// <returns>The result of the approximation; 
    /// The type should match the type of the input curve</returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static Point[] ApproxPolyDP(IEnumerable<Point> curve, double epsilon, bool closed)
    {
        if(curve is null)
            throw new ArgumentNullException(nameof(curve));
        var curveArray = curve as Point[] ?? curve.ToArray();
        using var approxCurveVec = new StdVector<Point>();
        NativeMethods.HandleException(
            NativeMethods.geometry_approxPolyDP_Point(
                curveArray, curveArray.Length, approxCurveVec.CvPtr, epsilon, closed ? 1 : 0));
        return approxCurveVec.ToArray();
    }


    /// <summary>
    /// Approximates contour or a curve using Douglas-Peucker algorithm
    /// </summary>
    /// <param name="curve">The polygon or curve to approximate.</param>
    /// <param name="epsilon">Specifies the approximation accuracy. 
    /// This is the maximum distance between the original curve and its approximation.</param>
    /// <param name="closed">If true, the approximated curve is closed 
    /// (i.e. its first and last vertices are connected), otherwise it’s not</param>
    /// <returns>The result of the approximation; 
    /// The type should match the type of the input curve</returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static Point2f[] ApproxPolyDP(IEnumerable<Point2f> curve, double epsilon, bool closed)
    {
        if (curve is null)
            throw new ArgumentNullException(nameof(curve));
        var curveArray = curve as Point2f[] ?? curve.ToArray();
        using var approxCurveVec = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.geometry_approxPolyDP_Point2f(
                curveArray, curveArray.Length, approxCurveVec.CvPtr, epsilon, closed ? 1 : 0));
        return approxCurveVec.ToArray();
    }


    /// <summary>
    /// Calculates a contour perimeter or a curve length.
    /// </summary>
    /// <param name="curve">The input vector of 2D points, represented by CV_32SC2 or CV_32FC2 matrix.</param>
    /// <param name="closed">Indicates, whether the curve is closed or not.</param>
    /// <returns></returns>
    public static double ArcLength(InputArray curve, bool closed)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_arcLength_InputArray(curve.Proxy, closed ? 1 : 0, out var ret));
        GC.KeepAlive(curve.Source);
        return ret;
    }


    /// <summary>
    /// Calculates a contour perimeter or a curve length.
    /// </summary>
    /// <param name="curve">The input vector of 2D points.</param>
    /// <param name="closed">Indicates, whether the curve is closed or not.</param>
    /// <returns></returns>
    public static double ArcLength(IEnumerable<Point> curve, bool closed)
    {
        if (curve is null)
            throw new ArgumentNullException(nameof(curve));
        var curveArray = curve.ToArray();
            
        NativeMethods.HandleException(
            NativeMethods.geometry_arcLength_Point(curveArray, curveArray.Length, closed ? 1 : 0, out var ret));
        return ret;
    }


    /// <summary>
    /// Calculates a contour perimeter or a curve length.
    /// </summary>
    /// <param name="curve">The input vector of 2D points.</param>
    /// <param name="closed">Indicates, whether the curve is closed or not.</param>
    /// <returns></returns>
    public static double ArcLength(IEnumerable<Point2f> curve, bool closed)
    {
        if (curve is null)
            throw new ArgumentNullException(nameof(curve));
        var curveArray = curve.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_arcLength_Point2f(curveArray, curveArray.Length, closed ? 1 : 0, out var ret));
        return ret;
    }


    /// <summary>
    /// Calculates the up-right bounding rectangle of a point set.
    /// </summary>
    /// <param name="curve">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
    /// <returns>Minimal up-right bounding rectangle for the specified point set.</returns>
    public static Rect BoundingRect(InputArray curve)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_boundingRect_InputArray(curve.Proxy, out var ret));
        GC.KeepAlive(curve.Source);
        return ret;
    }


    /// <summary>
    /// Calculates the up-right bounding rectangle of a point set.
    /// </summary>
    /// <param name="curve">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
    /// <returns>Minimal up-right bounding rectangle for the specified point set.</returns>
    public static Rect BoundingRect(IEnumerable<Point> curve)
    {
        if (curve is null)
            throw new ArgumentNullException(nameof(curve));
        var curveArray = curve.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_boundingRect_Point(curveArray, curveArray.Length, out var ret));
        return ret;
    }


    /// <summary>
    /// Calculates the up-right bounding rectangle of a point set.
    /// </summary>
    /// <param name="curve">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
    /// <returns>Minimal up-right bounding rectangle for the specified point set.</returns>
    public static Rect BoundingRect(IEnumerable<Point2f> curve)
    {
        if (curve is null)
            throw new ArgumentNullException(nameof(curve));
        var curveArray = curve.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_boundingRect_Point2f(curveArray, curveArray.Length, out var ret));
        return ret;
    }

        
    /// <summary>
    /// Calculates the contour area
    /// </summary>
    /// <param name="contour">The contour vertices, represented by CV_32SC2 or CV_32FC2 matrix</param>
    /// <param name="oriented"></param>
    /// <returns></returns>
    public static double ContourArea(InputArray contour, bool oriented = false)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_contourArea_InputArray(contour.Proxy, oriented ? 1 : 0, out var ret));
        GC.KeepAlive(contour.Source);
        return ret;
    }


    /// <summary>
    /// Calculates the contour area
    /// </summary>
    /// <param name="contour">The contour vertices, represented by CV_32SC2 or CV_32FC2 matrix</param>
    /// <param name="oriented"></param>
    /// <returns></returns>
    public static double ContourArea(IEnumerable<Point> contour, bool oriented = false)
    {
        if (contour is null)
            throw new ArgumentNullException(nameof(contour));
        var contourArray = contour.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_contourArea_Point(contourArray, contourArray.Length, oriented ? 1 : 0, out var ret));
        return ret;
    }


    /// <summary>
    /// Calculates the contour area
    /// </summary>
    /// <param name="contour">The contour vertices, represented by CV_32SC2 or CV_32FC2 matrix</param>
    /// <param name="oriented"></param>
    /// <returns></returns>
    public static double ContourArea(IEnumerable<Point2f> contour, bool oriented = false)
    {
        if (contour is null)
            throw new ArgumentNullException(nameof(contour));
        var contourArray = contour.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_contourArea_Point2f(contourArray, contourArray.Length, oriented ? 1 : 0, out var ret));
        return ret;
    }

        
    /// <summary>
    /// Finds the minimum area rotated rectangle enclosing a 2D point set.
    /// </summary>
    /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
    /// <returns></returns>
    public static RotatedRect MinAreaRect(InputArray points)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_minAreaRect_InputArray(points.Proxy, out var ret));
        GC.KeepAlive(points.Source);
        return ret;
    }


    /// <summary>
    /// Finds the minimum area rotated rectangle enclosing a 2D point set.
    /// </summary>
    /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
    /// <returns></returns>
    public static RotatedRect MinAreaRect(IEnumerable<Point> points)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_minAreaRect_Point(pointsArray, pointsArray.Length, out var ret));
        return ret;
    }


    /// <summary>
    /// Finds the minimum area rotated rectangle enclosing a 2D point set.
    /// </summary>
    /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
    /// <returns></returns>
    public static RotatedRect MinAreaRect(IEnumerable<Point2f> points)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_minAreaRect_Point2f(pointsArray, pointsArray.Length, out var ret));
        return ret;
    }


    /// <summary>
    /// Finds the four vertices of a rotated rect. Useful to draw the rotated rectangle.
    ///
    /// The function finds the four vertices of a rotated rectangle.This function is useful to draw the 
    /// rectangle.In C++, instead of using this function, you can directly use RotatedRect::points method. Please
    /// visit the @ref tutorial_bounding_rotated_ellipses "tutorial on Creating Bounding rotated boxes and ellipses for contours" for more information.
    /// </summary>
    /// <param name="box">The input rotated rectangle. It may be the output of</param>
    /// <param name="points">The output array of four vertices of rectangles.</param>
    /// <returns></returns>
    public static void BoxPoints(RotatedRect box, OutputArray points)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_boxPoints_OutputArray(box, points.Proxy));
    }


    /// <summary>
    /// Finds the four vertices of a rotated rect. Useful to draw the rotated rectangle.
    ///
    /// The function finds the four vertices of a rotated rectangle.This function is useful to draw the 
    /// rectangle.In C++, instead of using this function, you can directly use RotatedRect::points method. Please
    /// visit the @ref tutorial_bounding_rotated_ellipses "tutorial on Creating Bounding rotated boxes and ellipses for contours" for more information.
    /// </summary>
    /// <param name="box">The input rotated rectangle. It may be the output of</param>
    /// <returns>The output array of four vertices of rectangles.</returns>
    public static Point2f[] BoxPoints(RotatedRect box)
    {
        var points = new Point2f[4];
        NativeMethods.HandleException(
            NativeMethods.geometry_boxPoints_Point2f(box, points));
        return points;
    }


    /// <summary>
    /// Finds the minimum area circle enclosing a 2D point set.
    /// </summary>
    /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
    /// <param name="center">The output center of the circle</param>
    /// <param name="radius">The output radius of the circle</param>
    public static void MinEnclosingCircle(InputArray points, out Point2f center, out float radius)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_minEnclosingCircle_InputArray(points.Proxy, out center, out radius));
        GC.KeepAlive(points.Source);
    }


    /// <summary>
    /// Finds the minimum area circle enclosing a 2D point set.
    /// </summary>
    /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
    /// <param name="center">The output center of the circle</param>
    /// <param name="radius">The output radius of the circle</param>
    public static void MinEnclosingCircle(IEnumerable<Point> points, out Point2f center, out float radius)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();
        NativeMethods.HandleException(
            NativeMethods.geometry_minEnclosingCircle_Point(pointsArray, pointsArray.Length, out center, out radius));
    }


    /// <summary>
    /// Finds the minimum area circle enclosing a 2D point set.
    /// </summary>
    /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
    /// <param name="center">The output center of the circle</param>
    /// <param name="radius">The output radius of the circle</param>
    public static void MinEnclosingCircle(IEnumerable<Point2f> points, out Point2f center, out float radius)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();
        NativeMethods.HandleException(
            NativeMethods.geometry_minEnclosingCircle_Point2f(pointsArray, pointsArray.Length, out center, out radius));
    }


    /// <summary>
    /// Finds a triangle of minimum area enclosing a 2D point set and returns its area.
    /// </summary>
    /// <param name="points">Input vector of 2D points with depth CV_32S or CV_32F, stored in std::vector or Mat</param>
    /// <param name="triangle">Output vector of three 2D points defining the vertices of the triangle. The depth</param>
    /// <returns>Triangle area</returns>
    public static double MinEnclosingTriangle(InputArray points, OutputArray triangle)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_minEnclosingTriangle_InputOutputArray(points.Proxy, triangle.Proxy, out var ret));

        GC.KeepAlive(points.Source);
        return ret;
    }


    /// <summary>
    /// Finds a triangle of minimum area enclosing a 2D point set and returns its area.
    /// </summary>
    /// <param name="points">Input vector of 2D points with depth CV_32S or CV_32F, stored in std::vector or Mat</param>
    /// <param name="triangle">Output vector of three 2D points defining the vertices of the triangle. The depth</param>
    /// <returns>Triangle area</returns>
    public static double MinEnclosingTriangle(IEnumerable<Point> points, out Point2f[] triangle)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));

        var pointsArray = points.ToArray();
        using var triangleVec = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.geometry_minEnclosingTriangle_Point(
                pointsArray, pointsArray.Length, triangleVec.CvPtr, out var ret));

        GC.KeepAlive(pointsArray);
        triangle = triangleVec.ToArray();
        return ret;
    }


    /// <summary>
    /// Finds a triangle of minimum area enclosing a 2D point set and returns its area.
    /// </summary>
    /// <param name="points">Input vector of 2D points with depth CV_32S or CV_32F, stored in std::vector or Mat</param>
    /// <param name="triangle">Output vector of three 2D points defining the vertices of the triangle. The depth</param>
    /// <returns>Triangle area</returns>
    public static double MinEnclosingTriangle(IEnumerable<Point2f> points, out Point2f[] triangle)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));

        var pointsArray = points.ToArray();
        using var triangleVec = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.geometry_minEnclosingTriangle_Point2f(
                pointsArray, pointsArray.Length, triangleVec.CvPtr, out var ret));

        GC.KeepAlive(pointsArray);
        triangle = triangleVec.ToArray();
        return ret;
    }


    /// <summary>
    /// Compares two shapes.
    /// </summary>
    /// <param name="contour1">First contour or grayscale image.</param>
    /// <param name="contour2">Second contour or grayscale image.</param>
    /// <param name="method">Comparison method</param>
    /// <param name="parameter">Method-specific parameter (not supported now)</param>
    /// <returns></returns>
    public static double MatchShapes(InputArray contour1, InputArray contour2, ShapeMatchModes method, double parameter = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_matchShapes_InputArray(contour1.Proxy, contour2.Proxy, (int)method, parameter, out var ret));

        GC.KeepAlive(contour1.Source);
        GC.KeepAlive(contour2.Source);
        return ret;
    }


    /// <summary>
    /// Compares two shapes.
    /// </summary>
    /// <param name="contour1">First contour or grayscale image.</param>
    /// <param name="contour2">Second contour or grayscale image.</param>
    /// <param name="method">Comparison method</param>
    /// <param name="parameter">Method-specific parameter (not supported now)</param>
    /// <returns></returns>
    public static double MatchShapes(IEnumerable<Point> contour1, IEnumerable<Point> contour2,
        ShapeMatchModes method, double parameter = 0)
    {
        if (contour1 is null)
            throw new ArgumentNullException(nameof(contour1));
        if (contour2 is null)
            throw new ArgumentNullException(nameof(contour2));
        var contour1Array = contour1.ToArray();
        var contour2Array = contour2.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_matchShapes_Point(
                contour1Array, contour1Array.Length,
                contour2Array, contour2Array.Length, 
                (int) method, parameter, out var ret));
        return ret;
    }


    /// <summary>
    /// Computes convex hull for a set of 2D points.
    /// </summary>
    /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix</param>
    /// <param name="hull">The output convex hull. It is either a vector of points that form the 
    /// hull (must have the same type as the input points), or a vector of 0-based point 
    /// indices of the hull points in the original array (since the set of convex hull 
    /// points is a subset of the original point set).</param>
    /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
    /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
    /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
    /// and y axis is oriented downwards.</param>
    /// <param name="returnPoints"></param>
    public static void ConvexHull(InputArray points, OutputArray hull, bool clockwise = false, bool returnPoints = true)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_convexHull_InputArray(points.Proxy, hull.Proxy, clockwise ? 1 : 0, returnPoints ? 1 : 0));

        GC.KeepAlive(points.Source);
        GC.KeepAlive(hull.Source);
    }


    /// <summary>
    /// Computes convex hull for a set of 2D points.
    /// </summary>
    /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix</param>
    /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
    /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
    /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
    /// and y axis is oriented downwards.</param>
    /// <returns>The output convex hull. It is a vector of points that form 
    /// the hull (must have the same type as the input points).</returns>
    public static Point[] ConvexHull(IEnumerable<Point> points, bool clockwise = false)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();

        using var hullVec = new StdVector<Point>();
        NativeMethods.HandleException(
            NativeMethods.geometry_convexHull_Point_ReturnsPoints(
                pointsArray, pointsArray.Length, hullVec.CvPtr, clockwise ? 1 : 0));

        return hullVec.ToArray();
    }


    /// <summary>
    /// Computes convex hull for a set of 2D points.
    /// </summary>
    /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix</param>
    /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
    /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
    /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
    /// and y axis is oriented downwards.</param>
    /// <returns>The output convex hull. It is a vector of points that form 
    /// the hull (must have the same type as the input points).</returns>
    public static Point2f[] ConvexHull(IEnumerable<Point2f> points, bool clockwise = false)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();

        using var hullVec = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.geometry_convexHull_Point2f_ReturnsPoints(
                pointsArray, pointsArray.Length, hullVec.CvPtr, clockwise ? 1 : 0));
        return hullVec.ToArray();
    }


    /// <summary>
    /// Computes convex hull for a set of 2D points.
    /// </summary>
    /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix</param>
    /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
    /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
    /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
    /// and y axis is oriented downwards.</param>
    /// <returns>The output convex hull. It is a vector of 0-based point indices of the 
    /// hull points in the original array (since the set of convex hull points is a subset of the original point set).</returns>
    public static int[] ConvexHullIndices(IEnumerable<Point> points, bool clockwise = false)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();

        using var hullVec = new StdVector<int>();
        NativeMethods.HandleException(
            NativeMethods.geometry_convexHull_Point_ReturnsIndices(
                pointsArray, pointsArray.Length, hullVec.CvPtr, clockwise ? 1 : 0));
        return hullVec.ToArray();
    }


    /// <summary>
    /// Computes convex hull for a set of 2D points.
    /// </summary>
    /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix</param>
    /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
    /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
    /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
    /// and y axis is oriented downwards.</param>
    /// <returns>The output convex hull. It is a vector of 0-based point indices of the 
    /// hull points in the original array (since the set of convex hull points is a subset of the original point set).</returns>
    public static int[] ConvexHullIndices(IEnumerable<Point2f> points, bool clockwise = false)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();

        using var hullVec = new StdVector<int>();
        NativeMethods.HandleException(
            NativeMethods.geometry_convexHull_Point2f_ReturnsIndices(
                pointsArray, pointsArray.Length, hullVec.CvPtr, clockwise ? 1 : 0));
        return hullVec.ToArray();
    }


    /// <summary>
    /// Computes the contour convexity defects
    /// </summary>
    /// <param name="contour">Input contour.</param>
    /// <param name="convexHull">Convex hull obtained using convexHull() that 
    /// should contain indices of the contour points that make the hull.</param>
    /// <param name="convexityDefects">
    /// The output vector of convexity defects. 
    /// Each convexity defect is represented as 4-element integer vector 
    /// (a.k.a. cv::Vec4i): (start_index, end_index, farthest_pt_index, fixpt_depth), 
    /// where indices are 0-based indices in the original contour of the convexity defect beginning, 
    /// end and the farthest point, and fixpt_depth is fixed-point approximation 
    /// (with 8 fractional bits) of the distance between the farthest contour point and the hull. 
    /// That is, to get the floating-point value of the depth will be fixpt_depth/256.0.
    /// </param>
    public static void ConvexityDefects(InputArray contour, InputArray convexHull, OutputArray convexityDefects)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_convexityDefects_InputArray(contour.Proxy, convexHull.Proxy, convexityDefects.Proxy));

        GC.KeepAlive(contour.Source);
        GC.KeepAlive(convexHull.Source);
        GC.KeepAlive(convexityDefects.Source);
    }


    /// <summary>
    /// Computes the contour convexity defects
    /// </summary>
    /// <param name="contour">Input contour.</param>
    /// <param name="convexHull">Convex hull obtained using convexHull() that 
    /// should contain indices of the contour points that make the hull.</param>
    /// <returns>The output vector of convexity defects. 
    /// Each convexity defect is represented as 4-element integer vector 
    /// (a.k.a. cv::Vec4i): (start_index, end_index, farthest_pt_index, fixpt_depth), 
    /// where indices are 0-based indices in the original contour of the convexity defect beginning, 
    /// end and the farthest point, and fixpt_depth is fixed-point approximation 
    /// (with 8 fractional bits) of the distance between the farthest contour point and the hull. 
    /// That is, to get the floating-point value of the depth will be fixpt_depth/256.0. </returns>
    public static Vec4i[] ConvexityDefects(IEnumerable<Point> contour, IEnumerable<int> convexHull)
    {
        if (contour is null)
            throw new ArgumentNullException(nameof(contour));
        if (convexHull is null)
            throw new ArgumentNullException(nameof(convexHull));

        var contourArray = contour.ToArray();
        var convexHullArray = convexHull.ToArray();
        using var convexityDefectsVec = new StdVector<Vec4i>();
        NativeMethods.HandleException(
            NativeMethods.geometry_convexityDefects_Point(
                contourArray, contourArray.Length,
                convexHullArray, convexHullArray.Length, convexityDefectsVec.CvPtr));

        return convexityDefectsVec.ToArray();
    }


    /// <summary>
    /// Computes the contour convexity defects
    /// </summary>
    /// <param name="contour">Input contour.</param>
    /// <param name="convexHull">Convex hull obtained using convexHull() that 
    /// should contain indices of the contour points that make the hull.</param>
    /// <returns>The output vector of convexity defects. 
    /// Each convexity defect is represented as 4-element integer vector 
    /// (a.k.a. cv::Vec4i): (start_index, end_index, farthest_pt_index, fixpt_depth), 
    /// where indices are 0-based indices in the original contour of the convexity defect beginning, 
    /// end and the farthest point, and fixpt_depth is fixed-point approximation 
    /// (with 8 fractional bits) of the distance between the farthest contour point and the hull. 
    /// That is, to get the floating-point value of the depth will be fixpt_depth/256.0. </returns>
    public static Vec4i[] ConvexityDefects(IEnumerable<Point2f> contour, IEnumerable<int> convexHull)
    {
        if (contour is null)
            throw new ArgumentNullException(nameof(contour));
        if (convexHull is null)
            throw new ArgumentNullException(nameof(convexHull));

        var contourArray = contour.ToArray();
        var convexHullArray = convexHull.ToArray();
        using var convexityDefectsVec = new StdVector<Vec4i>();
        NativeMethods.HandleException(
            NativeMethods.geometry_convexityDefects_Point2f(
                contourArray, contourArray.Length,
                convexHullArray, convexHullArray.Length, convexityDefectsVec.CvPtr));
        return convexityDefectsVec.ToArray();
    }


    /// <summary>
    /// returns true if the contour is convex. 
    /// Does not support contours with self-intersection
    /// </summary>
    /// <param name="contour">Input vector of 2D points</param>
    /// <returns></returns>
    public static bool IsContourConvex(InputArray contour)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_isContourConvex_InputArray(contour.Proxy, out var ret));

        GC.KeepAlive(contour.Source);
        return ret != 0;
    }


    /// <summary>
    /// returns true if the contour is convex. 
    /// Does not support contours with self-intersection
    /// </summary>
    /// <param name="contour">Input vector of 2D points</param>
    /// <returns></returns>
    public static bool IsContourConvex(IEnumerable<Point> contour)
    {
        if (contour is null)
            throw new ArgumentNullException(nameof(contour));
        var contourArray = contour.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_isContourConvex_Point(contourArray, contourArray.Length, out var ret));
        return ret != 0;
    }


    /// <summary>
    /// returns true if the contour is convex. D
    /// oes not support contours with self-intersection
    /// </summary>
    /// <param name="contour">Input vector of 2D points</param>
    /// <returns></returns>
    public static bool IsContourConvex(IEnumerable<Point2f> contour)
    {
        if (contour is null)
            throw new ArgumentNullException(nameof(contour));
        var contourArray = contour.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_isContourConvex_Point2f(contourArray, contourArray.Length, out var ret));
        return ret != 0;
    }


    /// <summary>
    /// finds intersection of two convex polygons
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p12"></param>
    /// <param name="handleNested"></param>
    /// <returns></returns>
    public static float IntersectConvexConvex(InputArray p1, InputArray p2, OutputArray p12, bool handleNested = true)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_intersectConvexConvex_InputArray(
                p1.Proxy, p2.Proxy, p12.Proxy, handleNested ? 1 : 0, out var ret));

        GC.KeepAlive(p1.Source);
        GC.KeepAlive(p2.Source);
        GC.KeepAlive(p12.Source);
        return ret;
    }


    /// <summary>
    /// finds intersection of two convex polygons
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p12"></param>
    /// <param name="handleNested"></param>
    /// <returns></returns>
    public static float IntersectConvexConvex(IEnumerable<Point> p1, IEnumerable<Point> p2,
        out Point[] p12, bool handleNested = true)
    {
        if (p1 is null)
            throw new ArgumentNullException(nameof(p1));
        if (p2 is null)
            throw new ArgumentNullException(nameof(p2));
        var p1Array = p1.ToArray();
        var p2Array = p2.ToArray();

        using var p12Vec = new StdVector<Point>();
        NativeMethods.HandleException(
            NativeMethods.geometry_intersectConvexConvex_Point(
                p1Array, p1Array.Length, p2Array, p2Array.Length, p12Vec.CvPtr, handleNested ? 1 : 0, out var ret));

        p12 = p12Vec.ToArray();

        return ret;
    }


    /// <summary>
    /// finds intersection of two convex polygons
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p12"></param>
    /// <param name="handleNested"></param>
    /// <returns></returns>
    public static float IntersectConvexConvex(IEnumerable<Point2f> p1, IEnumerable<Point2f> p2,
        out Point2f[] p12, bool handleNested = true)
    {
        if (p1 is null)
            throw new ArgumentNullException(nameof(p1));
        if (p2 is null)
            throw new ArgumentNullException(nameof(p2));
        var p1Array = p1.ToArray();
        var p2Array = p2.ToArray();

        using var p12Vec = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.geometry_intersectConvexConvex_Point2f(
                p1Array, p1Array.Length, p2Array, p2Array.Length,
                p12Vec.CvPtr, handleNested ? 1 : 0, out var ret));

        p12 = p12Vec.ToArray();

        return ret;
    }


    /// <summary>
    /// Fits ellipse to the set of 2D points.
    /// </summary>
    /// <param name="points">Input 2D point set</param>
    /// <returns></returns>
    public static RotatedRect FitEllipse(InputArray points)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_fitEllipse_InputArray(points.Proxy, out var ret));

        GC.KeepAlive(points.Source);
        return ret;
    }


    /// <summary>
    /// Fits ellipse to the set of 2D points.
    /// </summary>
    /// <param name="points">Input 2D point set</param>
    /// <returns></returns>
    public static RotatedRect FitEllipse(IEnumerable<Point> points)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_fitEllipse_Point(pointsArray, pointsArray.Length, out var ret));
        return ret;
    }


    /// <summary>
    /// Fits ellipse to the set of 2D points.
    /// </summary>
    /// <param name="points">Input 2D point set</param>
    /// <returns></returns>
    public static RotatedRect FitEllipse(IEnumerable<Point2f> points)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_fitEllipse_Point2f(pointsArray, pointsArray.Length, out var ret));
        return ret;
    }


    /// <summary>
    /// Fits an ellipse around a set of 2D points.
    /// 
    /// The function calculates the ellipse that fits a set of 2D points.
    /// It returns the rotated rectangle in which the ellipse is inscribed.
    /// The Approximate Mean Square(AMS) proposed by @cite Taubin1991 is used.
    /// </summary>
    /// <param name="points">Input 2D point set</param>
    /// <returns></returns>
    public static RotatedRect FitEllipseAMS(InputArray points)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_fitEllipseAMS_InputArray(points.Proxy, out var ret));

        GC.KeepAlive(points.Source);
        return ret;
    }


    /// <summary>
    /// Fits an ellipse around a set of 2D points.
    /// 
    /// The function calculates the ellipse that fits a set of 2D points.
    /// It returns the rotated rectangle in which the ellipse is inscribed.
    /// The Approximate Mean Square(AMS) proposed by @cite Taubin1991 is used.
    /// </summary>
    /// <param name="points">Input 2D point set</param>
    /// <returns></returns>
    public static RotatedRect FitEllipseAMS(IEnumerable<Point> points)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_fitEllipseAMS_Point(pointsArray, pointsArray.Length, out var ret));
        return ret;
    }


    /// <summary>
    /// Fits an ellipse around a set of 2D points.
    /// 
    /// The function calculates the ellipse that fits a set of 2D points.
    /// It returns the rotated rectangle in which the ellipse is inscribed.
    /// The Approximate Mean Square(AMS) proposed by @cite Taubin1991 is used.
    /// </summary>
    /// <param name="points">Input 2D point set</param>
    /// <returns></returns>
    public static RotatedRect FitEllipseAMS(IEnumerable<Point2f> points)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_fitEllipseAMS_Point2f(pointsArray, pointsArray.Length, out var ret));
        return ret;
    }


    /// <summary>
    /// Fits an ellipse around a set of 2D points.
    ///
    /// The function calculates the ellipse that fits a set of 2D points.
    /// It returns the rotated rectangle in which the ellipse is inscribed.
    /// The Direct least square(Direct) method by @cite Fitzgibbon1999 is used.
    /// </summary>
    /// <param name="points">Input 2D point set</param>
    /// <returns></returns>
    public static RotatedRect FitEllipseDirect(InputArray points)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_fitEllipseDirect_InputArray(points.Proxy, out var ret));

        GC.KeepAlive(points.Source);
        return ret;
    }


    /// <summary>
    /// Fits an ellipse around a set of 2D points.
    ///
    /// The function calculates the ellipse that fits a set of 2D points.
    /// It returns the rotated rectangle in which the ellipse is inscribed.
    /// The Direct least square(Direct) method by @cite Fitzgibbon1999 is used.
    /// </summary>
    /// <param name="points">Input 2D point set</param>
    /// <returns></returns>
    public static RotatedRect FitEllipseDirect(IEnumerable<Point> points)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_fitEllipseDirect_Point(pointsArray, pointsArray.Length, out var ret));
        return ret;
    }


    /// <summary>
    /// Fits an ellipse around a set of 2D points.
    ///
    /// The function calculates the ellipse that fits a set of 2D points.
    /// It returns the rotated rectangle in which the ellipse is inscribed.
    /// The Direct least square(Direct) method by @cite Fitzgibbon1999 is used.
    /// </summary>
    /// <param name="points">Input 2D point set</param>
    /// <returns></returns>
    public static RotatedRect FitEllipseDirect(IEnumerable<Point2f> points)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();

        NativeMethods.HandleException(
            NativeMethods.geometry_fitEllipseDirect_Point2f(pointsArray, pointsArray.Length, out var ret));
        return ret;
    }

        
    /// <summary>
    /// Fits line to the set of 2D points using M-estimator algorithm
    /// </summary>
    /// <param name="points">Input vector of 2D or 3D points</param>
    /// <param name="line">Output line parameters. 
    /// In case of 2D fitting, it should be a vector of 4 elements 
    /// (like Vec4f) - (vx, vy, x0, y0), where (vx, vy) is a normalized vector 
    /// collinear to the line and (x0, y0) is a point on the line. 
    /// In case of 3D fitting, it should be a vector of 6 elements 
    /// (like Vec6f) - (vx, vy, vz, x0, y0, z0), where (vx, vy, vz) is a 
    /// normalized vector collinear to the line and (x0, y0, z0) is a point on the line.</param>
    /// <param name="distType">Distance used by the M-estimator</param>
    /// <param name="param">Numerical parameter ( C ) for some types of distances. 
    /// If it is 0, an optimal value is chosen.</param>
    /// <param name="reps">Sufficient accuracy for the radius 
    /// (distance between the coordinate origin and the line).</param>
    /// <param name="aeps">Sufficient accuracy for the angle. 
    /// 0.01 would be a good default value for reps and aeps.</param>
    public static void FitLine(InputArray points, OutputArray line, DistanceTypes distType,
        double param, double reps, double aeps)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_fitLine_InputArray(
                points.Proxy, line.Proxy, (int) distType, param, reps, aeps));

        GC.KeepAlive(points.Source);
        GC.KeepAlive(line.Source);
    }


    /// <summary>
    /// Fits line to the set of 2D points using M-estimator algorithm
    /// </summary>
    /// <param name="points">Input vector of 2D or 3D points</param>
    /// <param name="distType">Distance used by the M-estimator</param>
    /// <param name="param">Numerical parameter ( C ) for some types of distances. 
    /// If it is 0, an optimal value is chosen.</param>
    /// <param name="reps">Sufficient accuracy for the radius 
    /// (distance between the coordinate origin and the line).</param>
    /// <param name="aeps">Sufficient accuracy for the angle. 
    /// 0.01 would be a good default value for reps and aeps.</param>
    /// <returns>Output line parameters.</returns>
    public static Line2D FitLine(IEnumerable<Point> points, DistanceTypes distType,
        double param, double reps, double aeps)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();
        var line = new float[4];
        NativeMethods.HandleException(
            NativeMethods.geometry_fitLine_Point(
                pointsArray, pointsArray.Length, line, (int) distType, param, reps, aeps));
        return new Line2D(line);
    }


    /// <summary>
    /// Fits line to the set of 2D points using M-estimator algorithm
    /// </summary>
    /// <param name="points">Input vector of 2D or 3D points</param>
    /// <param name="distType">Distance used by the M-estimator</param>
    /// <param name="param">Numerical parameter ( C ) for some types of distances. 
    /// If it is 0, an optimal value is chosen.</param>
    /// <param name="reps">Sufficient accuracy for the radius 
    /// (distance between the coordinate origin and the line).</param>
    /// <param name="aeps">Sufficient accuracy for the angle. 
    /// 0.01 would be a good default value for reps and aeps.</param>
    /// <returns>Output line parameters.</returns>
    public static Line2D FitLine(IEnumerable<Point2f> points, DistanceTypes distType,
        double param, double reps, double aeps)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();
        var line = new float[4];
        NativeMethods.HandleException(
            NativeMethods.geometry_fitLine_Point2f(
                pointsArray, pointsArray.Length, line, (int) distType, param, reps, aeps));
        return new Line2D(line);
    }


    /// <summary>
    /// Fits line to the set of 3D points using M-estimator algorithm
    /// </summary>
    /// <param name="points">Input vector of 2D or 3D points</param>
    /// <param name="distType">Distance used by the M-estimator</param>
    /// <param name="param">Numerical parameter ( C ) for some types of distances. 
    /// If it is 0, an optimal value is chosen.</param>
    /// <param name="reps">Sufficient accuracy for the radius 
    /// (distance between the coordinate origin and the line).</param>
    /// <param name="aeps">Sufficient accuracy for the angle. 
    /// 0.01 would be a good default value for reps and aeps.</param>
    /// <returns>Output line parameters.</returns>
    public static Line3D FitLine(IEnumerable<Point3i> points, DistanceTypes distType,
        double param, double reps, double aeps)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();
        var line = new float[6];
        NativeMethods.HandleException(
            NativeMethods.geometry_fitLine_Point3i(
                pointsArray, pointsArray.Length, line, (int) distType, param, reps, aeps));
        return new Line3D(line);
    }


    /// <summary>
    /// Fits line to the set of 3D points using M-estimator algorithm
    /// </summary>
    /// <param name="points">Input vector of 2D or 3D points</param>
    /// <param name="distType">Distance used by the M-estimator</param>
    /// <param name="param">Numerical parameter ( C ) for some types of distances. 
    /// If it is 0, an optimal value is chosen.</param>
    /// <param name="reps">Sufficient accuracy for the radius 
    /// (distance between the coordinate origin and the line).</param>
    /// <param name="aeps">Sufficient accuracy for the angle. 
    /// 0.01 would be a good default value for reps and aeps.</param>
    /// <returns>Output line parameters.</returns>
    public static Line3D FitLine(IEnumerable<Point3f> points, DistanceTypes distType,
        double param, double reps, double aeps)
    {
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        var pointsArray = points.ToArray();
        var line = new float[6];
        NativeMethods.HandleException(
            NativeMethods.geometry_fitLine_Point3f(
                pointsArray, pointsArray.Length, line, (int) distType, param, reps, aeps));
        return new Line3D(line);
    }


    /// <summary>
    /// Checks if the point is inside the contour. Optionally computes the signed distance from the point to the contour boundary
    /// </summary>
    /// <param name="contour"></param>
    /// <param name="pt"></param>
    /// <param name="measureDist"></param>
    /// <returns></returns>
    public static double PointPolygonTest(InputArray contour, Point2f pt, bool measureDist)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_pointPolygonTest_InputArray(
                contour.Proxy, pt, measureDist ? 1 : 0, out var ret));
        GC.KeepAlive(contour.Source);
        return ret;
    }


    /// <summary>
    /// Checks if the point is inside the contour. Optionally computes the signed distance from the point to the contour boundary
    /// </summary>
    /// <param name="contour"></param>
    /// <param name="pt"></param>
    /// <param name="measureDist"></param>
    /// <returns></returns>
    public static double PointPolygonTest(IEnumerable<Point> contour, Point2f pt, bool measureDist)
    {
        if (contour is null)
            throw new ArgumentNullException(nameof(contour));
        var contourArray = contour.ToArray();
        NativeMethods.HandleException(
            NativeMethods.geometry_pointPolygonTest_Point(
                contourArray, contourArray.Length, pt, measureDist ? 1 : 0, out var ret));
        return ret;
    }


    /// <summary>
    /// Checks if the point is inside the contour. 
    /// Optionally computes the signed distance from the point to the contour boundary.
    /// </summary>
    /// <param name="contour">Input contour.</param>
    /// <param name="pt">Point tested against the contour.</param>
    /// <param name="measureDist">If true, the function estimates the signed distance 
    /// from the point to the nearest contour edge. Otherwise, the function only checks 
    /// if the point is inside a contour or not.</param>
    /// <returns>Positive (inside), negative (outside), or zero (on an edge) value.</returns>
    public static double PointPolygonTest(IEnumerable<Point2f> contour, Point2f pt, bool measureDist)
    {
        if (contour is null)
            throw new ArgumentNullException(nameof(contour));
        var contourArray = contour.ToArray();
        NativeMethods.HandleException(
            NativeMethods.geometry_pointPolygonTest_Point2f(
                contourArray, contourArray.Length, pt, measureDist ? 1 : 0, out var ret));
        return ret;
    }


    /// <summary>
    /// Finds out if there is any intersection between two rotated rectangles.
    /// If there is then the vertices of the interesecting region are returned as well.
    /// Below are some examples of intersection configurations. 
    /// The hatched pattern indicates the intersecting region and the red 
    /// vertices are returned by the function.
    /// </summary>
    /// <param name="rect1">First rectangle</param>
    /// <param name="rect2">Second rectangle</param>
    /// <param name="intersectingRegion">
    /// The output array of the verticies of the intersecting region. 
    /// It returns at most 8 vertices.
    /// Stored as std::vector&lt;cv::Point2f&gt; or cv::Mat as Mx1 of type CV_32FC2.</param>
    /// <returns></returns>
    public static RectanglesIntersectTypes RotatedRectangleIntersection(
        RotatedRect rect1, RotatedRect rect2, OutputArray intersectingRegion)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_rotatedRectangleIntersection_OutputArray(
                rect1, rect2, intersectingRegion.Proxy, out var ret));

        GC.KeepAlive(intersectingRegion.Source);

        return (RectanglesIntersectTypes)ret;
    }


    /// <summary>
    /// Finds out if there is any intersection between two rotated rectangles.
    /// If there is then the vertices of the interesecting region are returned as well.
    /// Below are some examples of intersection configurations. 
    /// The hatched pattern indicates the intersecting region and the red 
    /// vertices are returned by the function.
    /// </summary>
    /// <param name="rect1">First rectangle</param>
    /// <param name="rect2">Second rectangle</param>
    /// <param name="intersectingRegion">
    /// The output array of the verticies of the intersecting region. 
    /// It returns at most 8 vertices.</param>
    /// <returns></returns>
    public static RectanglesIntersectTypes RotatedRectangleIntersection(
        RotatedRect rect1, RotatedRect rect2, out Point2f[] intersectingRegion)
    {
        using var intersectingRegionVec = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.geometry_rotatedRectangleIntersection_vector(
                rect1, rect2, intersectingRegionVec.CvPtr, out var ret));

        intersectingRegion = intersectingRegionVec.ToArray();
        return (RectanglesIntersectTypes) ret;
    }
}
