using OpenCvSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
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
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_Rodrigues(src.CvPtr, dst.CvPtr, ToPtr(jacobian)));

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
            if (vector == null)
                throw new ArgumentNullException(nameof(vector));
            if (vector.Length != 3)
                throw new ArgumentException("vector.Length != 3");

            using var vectorM = new Mat(3, 1, MatType.CV_64FC1, vector);
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
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
                throw new ArgumentException("matrix must be double[3,3]");

            using var matrixM = new Mat(3, 3, MatType.CV_64FC1, matrix);
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
        /// <returns></returns>
        public static Mat FindHomography(InputArray srcPoints, InputArray dstPoints,
            HomographyMethods method = HomographyMethods.None, double ransacReprojThreshold = 3,
            OutputArray? mask = null)
        {
            if (srcPoints == null)
                throw new ArgumentNullException(nameof(srcPoints));
            if (dstPoints == null)
                throw new ArgumentNullException(nameof(dstPoints));
            srcPoints.ThrowIfDisposed();
            dstPoints.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_findHomography_InputArray(
                    srcPoints.CvPtr, dstPoints.CvPtr, (int)method,
                ransacReprojThreshold, ToPtr(mask), out var ret));

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
        /// <returns></returns>
        public static Mat FindHomography(IEnumerable<Point2d> srcPoints, IEnumerable<Point2d> dstPoints,
            HomographyMethods method = HomographyMethods.None, double ransacReprojThreshold = 3,
            OutputArray? mask = null)
        {
            if (srcPoints == null)
                throw new ArgumentNullException(nameof(srcPoints));
            if (dstPoints == null)
                throw new ArgumentNullException(nameof(dstPoints));

            var srcPointsArray = srcPoints as Point2d[] ?? srcPoints.ToArray();
            var dstPointsArray = dstPoints as Point2d[] ?? dstPoints.ToArray();

            NativeMethods.HandleException(
                NativeMethods.calib3d_findHomography_vector(
                srcPointsArray, srcPointsArray.Length,
                dstPointsArray, dstPointsArray.Length, (int)method, ransacReprojThreshold, ToPtr(mask), out var ret));

            GC.KeepAlive(mask);
            mask?.Fix();
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
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (mtxR == null)
                throw new ArgumentNullException(nameof(mtxR));
            if (mtxQ == null)
                throw new ArgumentNullException(nameof(mtxQ));
            src.ThrowIfDisposed();
            mtxR.ThrowIfNotReady();
            mtxQ.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_RQDecomp3x3_InputArray(
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
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (src.GetLength(0) != 3 || src.GetLength(1) != 3)
                throw new ArgumentException("src must be double[3,3]");

            using var srcM = new Mat(3, 3, MatType.CV_64FC1, src);
            using var mtxRM = new Mat<double>();
            using var mtxQM = new Mat<double>();
            using var qxM = new Mat<double>();
            using var qyM = new Mat<double>();
            using var qzM = new Mat<double>();
            NativeMethods.HandleException(
                NativeMethods.calib3d_RQDecomp3x3_Mat(
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
            if (projMatrix == null)
                throw new ArgumentNullException(nameof(projMatrix));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (rotMatrix == null)
                throw new ArgumentNullException(nameof(rotMatrix));
            if (transVect == null)
                throw new ArgumentNullException(nameof(transVect));
            projMatrix.ThrowIfDisposed();
            cameraMatrix.ThrowIfNotReady();
            rotMatrix.ThrowIfNotReady();
            transVect.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_decomposeProjectionMatrix_InputArray(
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
            if (projMatrix == null)
                throw new ArgumentNullException(nameof(projMatrix));
            var dim0 = projMatrix.GetLength(0);
            var dim1 = projMatrix.GetLength(1);
            if (!((dim0 == 3 && dim1 == 4) || (dim0 == 4 && dim1 == 3)))
                throw new ArgumentException("projMatrix must be double[3,4] or double[4,3]");

            using var projMatrixM = new Mat(3, 4, MatType.CV_64FC1, projMatrix);
            using var cameraMatrixM = new Mat<double>();
            using var rotMatrixM = new Mat<double>();
            using var transVectM = new Mat<double>();
            using var rotMatrixXM = new Mat<double>();
            using var rotMatrixYM = new Mat<double>();
            using var rotMatrixZM = new Mat<double>();
            using var eulerAnglesM = new Mat<double>();
            NativeMethods.HandleException(
                NativeMethods.calib3d_decomposeProjectionMatrix_Mat(
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
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            if (dABdA == null)
                throw new ArgumentNullException(nameof(dABdA));
            if (dABdB == null)
                throw new ArgumentNullException(nameof(dABdB));
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            dABdA.ThrowIfNotReady();
            dABdB.ThrowIfNotReady();
            NativeMethods.HandleException(
                NativeMethods.calib3d_matMulDeriv(a.CvPtr, b.CvPtr, dABdA.CvPtr, dABdB.CvPtr));
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
            if (rvec1 == null)
                throw new ArgumentNullException(nameof(rvec1));
            if (tvec1 == null)
                throw new ArgumentNullException(nameof(tvec1));
            if (rvec2 == null)
                throw new ArgumentNullException(nameof(rvec2));
            if (tvec2 == null)
                throw new ArgumentNullException(nameof(tvec2));
            if (rvec3 == null)
                throw new ArgumentNullException(nameof(rvec3));
            if (tvec3 == null)
                throw new ArgumentNullException(nameof(tvec3));
            rvec1.ThrowIfDisposed();
            tvec1.ThrowIfDisposed();
            rvec2.ThrowIfDisposed();
            tvec2.ThrowIfDisposed();
            rvec3.ThrowIfNotReady();
            tvec3.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_composeRT_InputArray(
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
            if (rvec1 == null)
                throw new ArgumentNullException(nameof(rvec1));
            if (tvec1 == null)
                throw new ArgumentNullException(nameof(tvec1));
            if (rvec2 == null)
                throw new ArgumentNullException(nameof(rvec2));
            if (tvec2 == null)
                throw new ArgumentNullException(nameof(tvec2));

            using var rvec1M = new Mat(3, 1, MatType.CV_64FC1, rvec1);
            using var tvec1M = new Mat(3, 1, MatType.CV_64FC1, tvec1);
            using var rvec2M = new Mat(3, 1, MatType.CV_64FC1, rvec2);
            using var tvec2M = new Mat(3, 1, MatType.CV_64FC1, tvec2);
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
                NativeMethods.calib3d_composeRT_Mat(
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
            if (objectPoints == null)
                throw new ArgumentNullException(nameof(objectPoints));
            if (rvec == null)
                throw new ArgumentNullException(nameof(rvec));
            if (tvec == null)
                throw new ArgumentNullException(nameof(tvec));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (imagePoints == null)
                throw new ArgumentNullException(nameof(imagePoints));
            objectPoints.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();
            imagePoints.ThrowIfNotReady();

            if (jacobian == null)
                jacobian = new Mat();

            NativeMethods.HandleException(
                NativeMethods.calib3d_projectPoints_InputArray(
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
        public static void ProjectPoints(
            IEnumerable<Point3f> objectPoints,
            double[] rvec, double[] tvec,
            double[,] cameraMatrix, double[] distCoeffs,
            out Point2f[] imagePoints,
            out double[,] jacobian,
            double aspectRatio = 0)
        {
            if (objectPoints == null)
                throw new ArgumentNullException(nameof(objectPoints));
            if (rvec == null)
                throw new ArgumentNullException(nameof(rvec));
            if (rvec.Length != 3)
                throw new ArgumentException($"{nameof(rvec)}.Length != 3");
            if (tvec == null)
                throw new ArgumentNullException(nameof(tvec));
            if (tvec.Length != 3)
                throw new ArgumentException($"{nameof(tvec)}.Length != 3");
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
                throw new ArgumentException("cameraMatrix must be double[3,3]");

            var objectPointsArray = objectPoints as Point3f[] ?? objectPoints.ToArray();
            using var objectPointsM = new Mat(objectPointsArray.Length, 1, MatType.CV_32FC3, objectPointsArray);
            using var rvecM = new Mat(3, 1, MatType.CV_64FC1, rvec);
            using var tvecM = new Mat(3, 1, MatType.CV_64FC1, tvec);
            using var cameraMatrixM = new Mat(3, 3, MatType.CV_64FC1, cameraMatrix);
            using var distCoeffsM = (distCoeffs == null)
                ? new Mat()
                : new Mat(distCoeffs.Length, 1, MatType.CV_64FC1, distCoeffs);
            using var imagePointsM = new Mat<Point2f>();
            using var jacobianM = new Mat<double>();
            NativeMethods.HandleException(
                NativeMethods.calib3d_projectPoints_Mat(
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
            SolvePnPFlags flags = SolvePnPFlags.Iterative)
        {
            if (objectPoints == null)
                throw new ArgumentNullException(nameof(objectPoints));
            if (imagePoints == null)
                throw new ArgumentNullException(nameof(imagePoints));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (distCoeffs == null)
                throw new ArgumentNullException(nameof(distCoeffs));
            if (rvec == null)
                throw new ArgumentNullException(nameof(rvec));
            if (tvec == null)
                throw new ArgumentNullException(nameof(tvec));
            objectPoints.ThrowIfDisposed();
            imagePoints.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();
            var distCoeffsPtr = ToPtr(distCoeffs);

            NativeMethods.HandleException(NativeMethods.calib3d_solvePnP_InputArray(
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
        public static void SolvePnP(
            IEnumerable<Point3f> objectPoints,
            IEnumerable<Point2f> imagePoints,
            double[,] cameraMatrix,
            IEnumerable<double>? distCoeffs,
            ref double[] rvec, 
            ref double[] tvec,
            bool useExtrinsicGuess = false,
            SolvePnPFlags flags = SolvePnPFlags.Iterative)
        {
            if (objectPoints == null)
                throw new ArgumentNullException(nameof(objectPoints));
            if (imagePoints == null)
                throw new ArgumentNullException(nameof(imagePoints));
            if (cameraMatrix == null)
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
                        NativeMethods.calib3d_solvePnP_vector(
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
            SolvePnPFlags flags = SolvePnPFlags.Iterative)
        {
            if (objectPoints == null)
                throw new ArgumentNullException(nameof(objectPoints));
            if (imagePoints == null)
                throw new ArgumentNullException(nameof(imagePoints));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (distCoeffs == null)
                throw new ArgumentNullException(nameof(distCoeffs));
            if (rvec == null)
                throw new ArgumentNullException(nameof(rvec));
            if (tvec == null)
                throw new ArgumentNullException(nameof(tvec));
            objectPoints.ThrowIfDisposed();
            imagePoints.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();
            var distCoeffsPtr = ToPtr(distCoeffs);

            NativeMethods.HandleException(
                NativeMethods.calib3d_solvePnPRansac_InputArray(
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
            SolvePnPFlags flags = SolvePnPFlags.Iterative)
        {
            if (objectPoints == null)
                throw new ArgumentNullException(nameof(objectPoints));
            if (imagePoints == null)
                throw new ArgumentNullException(nameof(imagePoints));
            if (cameraMatrix == null)
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
                        NativeMethods.calib3d_solvePnPRansac_vector(
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
            if (objectPoints == null)
                throw new ArgumentNullException(nameof(objectPoints));
            if (imagePoints == null)
                throw new ArgumentNullException(nameof(imagePoints));

            var objectPointsPtrs = objectPoints.Select(x => x.CvPtr).ToArray();
            var imagePointsPtrs = imagePoints.Select(x => x.CvPtr).ToArray();

            NativeMethods.HandleException(
                NativeMethods.calib3d_initCameraMatrix2D_Mat(
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
            if (objectPoints == null)
                throw new ArgumentNullException(nameof(objectPoints));
            if (imagePoints == null)
                throw new ArgumentNullException(nameof(imagePoints));

            using var opArray = new ArrayAddress2<Point3f>(objectPoints);
            using var ipArray = new ArrayAddress2<Point2f>(imagePoints);
            NativeMethods.HandleException(
                NativeMethods.calib3d_initCameraMatrix2D_array(
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
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (corners == null)
                throw new ArgumentNullException(nameof(corners));
            image.ThrowIfDisposed();
            corners.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_findChessboardCorners_InputArray(
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
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            using var cornersVec = new VectorOfPoint2f();
            NativeMethods.HandleException(
                NativeMethods.calib3d_findChessboardCorners_vector(
                    image.CvPtr, patternSize, cornersVec.CvPtr, (int) flags, out var ret));
            GC.KeepAlive(image);
            corners = cornersVec.ToArray();
            return ret != 0;
        }

        /// <summary>
        /// Checks whether the image contains chessboard of the specific size or not.
        /// </summary>
        /// <param name="img"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool CheckChessboard(InputArray img, Size size)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_checkChessboard(img.CvPtr, size, out var ret));
            GC.KeepAlive(img);
            return ret != 0;
        }

        /// <summary>
        /// Finds the positions of internal corners of the chessboard using a sector based approach.
        /// </summary>
        /// <param name="image">image Source chessboard view. It must be an 8-bit grayscale or color image.</param>
        /// <param name="patternSize">Number of inner corners per a chessboard row and column
        /// (patternSize = Size(points_per_row, points_per_column) = Size(columns, rows) ).</param>
        /// <param name="corners">Output array of detected corners.</param>
        /// <param name="flags">flags Various operation flags that can be zero or a combination of the ChessboardFlags values.</param>
        /// <returns></returns>
        public static bool FindChessboardCornersSB(
            InputArray image, Size patternSize, OutputArray corners, ChessboardFlags flags = 0)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (corners == null)
                throw new ArgumentNullException(nameof(corners));
            image.ThrowIfDisposed();
            corners.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_findChessboardCornersSB_OutputArray(
                    image.CvPtr, patternSize, corners.CvPtr, (int) flags, out var ret));

            GC.KeepAlive(image);
            GC.KeepAlive(corners);
            return ret != 0;
        }

        /// <summary>
        /// Finds the positions of internal corners of the chessboard using a sector based approach.
        /// </summary>
        /// <param name="image">image Source chessboard view. It must be an 8-bit grayscale or color image.</param>
        /// <param name="patternSize">Number of inner corners per a chessboard row and column
        /// (patternSize = Size(points_per_row, points_per_column) = Size(columns, rows) ).</param>
        /// <param name="corners">Output array of detected corners.</param>
        /// <param name="flags">flags Various operation flags that can be zero or a combination of the ChessboardFlags values.</param>
        /// <returns></returns>
        public static bool FindChessboardCornersSB(
            InputArray image, Size patternSize, out Point2f[] corners, ChessboardFlags flags = 0)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            using var cornersVec = new VectorOfPoint2f();
            NativeMethods.HandleException(
                NativeMethods.calib3d_findChessboardCornersSB_vector(
                    image.CvPtr, patternSize, cornersVec.CvPtr, (int) flags, out var ret));

            corners = cornersVec.ToArray();
            GC.KeepAlive(image);
            return ret != 0;
        }

        /// <summary>
        /// finds subpixel-accurate positions of the chessboard corners
        /// </summary>
        /// <param name="img"></param>
        /// <param name="corners"></param>
        /// <param name="regionSize"></param>
        /// <returns></returns>
        public static bool Find4QuadCornerSubpix(InputArray img, InputOutputArray corners, Size regionSize)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (corners == null)
                throw new ArgumentNullException(nameof(corners));
            img.ThrowIfDisposed();
            corners.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_find4QuadCornerSubpix_InputArray(
                    img.CvPtr, corners.CvPtr, regionSize, out var ret));
            GC.KeepAlive(img);
            corners.Fix();
            return ret != 0;
        }
        /// <summary>
        /// finds subpixel-accurate positions of the chessboard corners
        /// </summary>
        /// <param name="img"></param>
        /// <param name="corners"></param>
        /// <param name="regionSize"></param>
        /// <returns></returns>
        public static bool Find4QuadCornerSubpix(InputArray img, Point2f[] corners, Size regionSize)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (corners == null)
                throw new ArgumentNullException(nameof(corners));
            img.ThrowIfDisposed();

            using var cornersVec = new VectorOfPoint2f(corners);
            NativeMethods.HandleException(
                NativeMethods.calib3d_find4QuadCornerSubpix_vector(
                    img.CvPtr, cornersVec.CvPtr, regionSize, out var ret));
            GC.KeepAlive(img);

            var newCorners = cornersVec.ToArray();
            for (var i = 0; i < corners.Length; i++)
            {
                corners[i] = newCorners[i];
            }

            return ret != 0;
        }

        /// <summary>
        /// Renders the detected chessboard corners.
        /// </summary>
        /// <param name="image">Destination image. It must be an 8-bit color image.</param>
        /// <param name="patternSize">Number of inner corners per a chessboard row and column (patternSize = cv::Size(points_per_row,points_per_column)).</param>
        /// <param name="corners">Array of detected corners, the output of findChessboardCorners.</param>
        /// <param name="patternWasFound">Parameter indicating whether the complete board was found or not. The return value of findChessboardCorners() should be passed here.</param>
        public static void DrawChessboardCorners(InputOutputArray image, Size patternSize,
            InputArray corners, bool patternWasFound)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (corners == null)
                throw new ArgumentNullException(nameof(corners));
            image.ThrowIfNotReady();
            corners.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_drawChessboardCorners_InputArray(
                    image.CvPtr, patternSize, corners.CvPtr, patternWasFound ? 1 : 0));
            GC.KeepAlive(corners);
            image.Fix();
        }
        /// <summary>
        /// Renders the detected chessboard corners.
        /// </summary>
        /// <param name="image">Destination image. It must be an 8-bit color image.</param>
        /// <param name="patternSize">Number of inner corners per a chessboard row and column (patternSize = cv::Size(points_per_row,points_per_column)).</param>
        /// <param name="corners">Array of detected corners, the output of findChessboardCorners.</param>
        /// <param name="patternWasFound">Parameter indicating whether the complete board was found or not. The return value of findChessboardCorners() should be passed here.</param>
        public static void DrawChessboardCorners(InputOutputArray image, Size patternSize,
            IEnumerable<Point2f> corners, bool patternWasFound)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (corners == null)
                throw new ArgumentNullException(nameof(corners));
            image.ThrowIfNotReady();

            var cornersArray = corners as Point2f[] ?? corners.ToArray();
            NativeMethods.HandleException(
                NativeMethods.calib3d_drawChessboardCorners_array(
                    image.CvPtr, patternSize, cornersArray, cornersArray.Length,
                    patternWasFound ? 1 : 0));
            image.Fix();
        }

        /// <summary>
        /// Draw axes of the world/object coordinate system from pose estimation.
        /// </summary>
        /// <param name="image">Input/output image. It must have 1 or 3 channels. The number of channels is not altered.</param>
        /// <param name="cameraMatrix">Input 3x3 floating-point matrix of camera intrinsic parameters.</param>
        /// <param name="distCoeffs">Input vector of distortion coefficients
        /// \f$(k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6[, s_1, s_2, s_3, s_4[, \tau_x, \tau_y]]]])\f$ of
        /// 4, 5, 8, 12 or 14 elements.If the vector is empty, the zero distortion coefficients are assumed.</param>
        /// <param name="rvec">Rotation vector (see @ref Rodrigues ) that, together with tvec , brings points from
        /// the model coordinate system to the camera coordinate system.</param>
        /// <param name="tvec">Translation vector.</param>
        /// <param name="length">Length of the painted axes in the same unit than tvec (usually in meters).</param>
        /// <param name="thickness">Line thickness of the painted axes.</param>
        /// <remarks>This function draws the axes of the world/object coordinate system w.r.t. to the camera frame.
        /// OX is drawn in red, OY in green and OZ in blue.</remarks>
        public static void DrawFrameAxes(
            InputOutputArray image, InputArray cameraMatrix, InputArray distCoeffs,
            InputArray rvec, InputArray tvec, float length, int thickness = 3)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (distCoeffs == null)
                throw new ArgumentNullException(nameof(distCoeffs));
            if (rvec == null)
                throw new ArgumentNullException(nameof(rvec));
            if (tvec == null)
                throw new ArgumentNullException(nameof(tvec));
            image.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_drawFrameAxes(
                    image.CvPtr, cameraMatrix.CvPtr, distCoeffs.CvPtr, rvec.CvPtr, tvec.CvPtr, length, thickness));

            GC.KeepAlive(image);
            GC.KeepAlive(cameraMatrix);
            GC.KeepAlive(distCoeffs);
            GC.KeepAlive(rvec);
            GC.KeepAlive(tvec);
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
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (centers == null)
                throw new ArgumentNullException(nameof(centers));
            image.ThrowIfDisposed();
            centers.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_findCirclesGrid_InputArray(
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
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            using var centersVec = new VectorOfPoint2f();
            NativeMethods.HandleException(
                NativeMethods.calib3d_findCirclesGrid_vector(
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
        /// <returns></returns>
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
            if (objectPoints == null)
                throw new ArgumentNullException(nameof(objectPoints));
            if (imagePoints == null)
                throw new ArgumentNullException(nameof(imagePoints));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (distCoeffs == null)
                throw new ArgumentNullException(nameof(distCoeffs));
            cameraMatrix.ThrowIfNotReady();
            distCoeffs.ThrowIfNotReady();

            var criteria0 = criteria.GetValueOrDefault(
                new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 30, Double.Epsilon));

            var objectPointsPtrs = objectPoints.Select(x => x.CvPtr).ToArray();
            var imagePointsPtrs = imagePoints.Select(x => x.CvPtr).ToArray();

            using var rvecsVec = new VectorOfMat();
            using var tvecsVec = new VectorOfMat();
            NativeMethods.HandleException(
                NativeMethods.calib3d_calibrateCamera_InputArray(
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
        /// <returns></returns>
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
            if (objectPoints == null)
                throw new ArgumentNullException(nameof(objectPoints));
            if (imagePoints == null)
                throw new ArgumentNullException(nameof(imagePoints));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (distCoeffs == null)
                throw new ArgumentNullException(nameof(distCoeffs));

            var criteria0 = criteria.GetValueOrDefault(
                new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 30, Double.Epsilon));

            using var op = new ArrayAddress2<Point3f>(objectPoints);
            using var ip = new ArrayAddress2<Point2f>(imagePoints);
            using var rvecsVec = new VectorOfMat();
            using var tvecsVec = new VectorOfMat();
            unsafe
            {
                fixed (double* cameraMatrixPtr = cameraMatrix)
                {
                    NativeMethods.HandleException(
                        NativeMethods.calib3d_calibrateCamera_vector(
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
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            cameraMatrix.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_calibrationMatrixValues_InputArray(
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
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
                throw new ArgumentException("cameraMatrix must be 3x3");

            unsafe
            {
                fixed (double* cameraMatrixPtr = cameraMatrix)
                {
                    NativeMethods.HandleException(
                        NativeMethods.calib3d_calibrationMatrixValues_array(
                            cameraMatrixPtr,
                            imageSize, apertureWidth, apertureHeight, out fovx, out fovy, out focalLength,
                            out principalPoint, out aspectRatio));
                }
            }
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
            if (objectPoints == null)
                throw new ArgumentNullException(nameof(objectPoints));
            if (imagePoints1 == null)
                throw new ArgumentNullException(nameof(imagePoints1));
            if (imagePoints2 == null)
                throw new ArgumentNullException(nameof(imagePoints2));
            if (cameraMatrix1 == null)
                throw new ArgumentNullException(nameof(cameraMatrix1));
            if (distCoeffs1 == null)
                throw new ArgumentNullException(nameof(distCoeffs1));
            if (cameraMatrix2 == null)
                throw new ArgumentNullException(nameof(cameraMatrix2));
            if (distCoeffs2 == null)
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
                new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 30, 1e-6));

            NativeMethods.HandleException(
                NativeMethods.calib3d_stereoCalibrate_InputArray(
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
            R?.Fix();
            T?.Fix();
            E?.Fix();
            F?.Fix();

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
            if (objectPoints == null)
                throw new ArgumentNullException(nameof(objectPoints));
            if (imagePoints1 == null)
                throw new ArgumentNullException(nameof(imagePoints1));
            if (imagePoints2 == null)
                throw new ArgumentNullException(nameof(imagePoints2));
            if (cameraMatrix1 == null)
                throw new ArgumentNullException(nameof(cameraMatrix1));
            if (distCoeffs1 == null)
                throw new ArgumentNullException(nameof(distCoeffs1));
            if (cameraMatrix2 == null)
                throw new ArgumentNullException(nameof(cameraMatrix2));
            if (distCoeffs2 == null)
                throw new ArgumentNullException(nameof(distCoeffs2));

            var criteria0 = criteria.GetValueOrDefault(
                new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 30, 1e-6));

            using var op = new ArrayAddress2<Point3f>(objectPoints);
            using var ip1 = new ArrayAddress2<Point2f>(imagePoints1);
            using var ip2 = new ArrayAddress2<Point2f>(imagePoints2);
            unsafe
            {
                fixed (double* cameraMatrix1Ptr = cameraMatrix1)
                fixed (double* cameraMatrix2Ptr = cameraMatrix2)
                {
                    NativeMethods.HandleException(
                        NativeMethods.calib3d_stereoCalibrate_array(
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
            if (cameraMatrix1 == null)
                throw new ArgumentNullException(nameof(cameraMatrix1));
            if (distCoeffs1 == null)
                throw new ArgumentNullException(nameof(distCoeffs1));
            if (cameraMatrix2 == null)
                throw new ArgumentNullException(nameof(cameraMatrix2));
            if (distCoeffs2 == null)
                throw new ArgumentNullException(nameof(distCoeffs2));
            if (R == null)
                throw new ArgumentNullException(nameof(R));
            if (T == null)
                throw new ArgumentNullException(nameof(T));
            if (R1 == null)
                throw new ArgumentNullException(nameof(R1));
            if (R2 == null)
                throw new ArgumentNullException(nameof(R2));
            if (P1 == null)
                throw new ArgumentNullException(nameof(P1));
            if (P2 == null)
                throw new ArgumentNullException(nameof(P2));
            if (Q == null)
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
                NativeMethods.calib3d_stereoRectify_InputArray(
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
            if (cameraMatrix1 == null)
                throw new ArgumentNullException(nameof(cameraMatrix1));
            if (distCoeffs1 == null)
                throw new ArgumentNullException(nameof(distCoeffs1));
            if (cameraMatrix2 == null)
                throw new ArgumentNullException(nameof(cameraMatrix2));
            if (distCoeffs2 == null)
                throw new ArgumentNullException(nameof(distCoeffs2));
            if (R == null)
                throw new ArgumentNullException(nameof(R));
            if (T == null)
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
                        NativeMethods.calib3d_stereoRectify_array(
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
            if (points1 == null)
                throw new ArgumentNullException(nameof(points1));
            if (points2 == null)
                throw new ArgumentNullException(nameof(points2));
            if (F == null)
                throw new ArgumentNullException(nameof(F));
            if (H1 == null)
                throw new ArgumentNullException(nameof(H1));
            if (H2 == null)
                throw new ArgumentNullException(nameof(H2));
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();
            F.ThrowIfDisposed();
            H1.ThrowIfNotReady();
            H2.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_stereoRectifyUncalibrated_InputArray(
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
        public static bool StereoRectifyUncalibrated(
            IEnumerable<Point2d> points1,
            IEnumerable<Point2d> points2,
            double[,] F, Size imgSize,
            out double[,] H1, out double[,] H2,
            double threshold = 5)
        {
            if (points1 == null)
                throw new ArgumentNullException(nameof(points1));
            if (points2 == null)
                throw new ArgumentNullException(nameof(points2));
            if (F == null)
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
                        NativeMethods.calib3d_stereoRectifyUncalibrated_array(
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
            if (cameraMatrix1 == null)
                throw new ArgumentNullException(nameof(cameraMatrix1));
            if (distCoeffs1 == null)
                throw new ArgumentNullException(nameof(distCoeffs1));
            if (cameraMatrix2 == null)
                throw new ArgumentNullException(nameof(cameraMatrix2));
            if (distCoeffs2 == null)
                throw new ArgumentNullException(nameof(distCoeffs2));
            if (cameraMatrix3 == null)
                throw new ArgumentNullException(nameof(cameraMatrix3));
            if (distCoeffs3 == null)
                throw new ArgumentNullException(nameof(distCoeffs3));
            if (imgpt1 == null)
                throw new ArgumentNullException(nameof(imgpt1));
            if (imgpt3 == null)
                throw new ArgumentNullException(nameof(imgpt3));
            if (R12 == null)
                throw new ArgumentNullException(nameof(R12));
            if (T12 == null)
                throw new ArgumentNullException(nameof(T12));
            if (R13 == null)
                throw new ArgumentNullException(nameof(R13));
            if (T13 == null)
                throw new ArgumentNullException(nameof(T13));
            if (R1 == null)
                throw new ArgumentNullException(nameof(R1));
            if (R2 == null)
                throw new ArgumentNullException(nameof(R2));
            if (R3 == null)
                throw new ArgumentNullException(nameof(R3));
            if (P1 == null)
                throw new ArgumentNullException(nameof(P1));
            if (P2 == null)
                throw new ArgumentNullException(nameof(P2));
            if (P3 == null)
                throw new ArgumentNullException(nameof(P3));
            if (Q == null)
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
                NativeMethods.calib3d_rectify3Collinear_InputArray(
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
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            cameraMatrix.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_getOptimalNewCameraMatrix_InputArray(
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
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (distCoeffs == null)
                throw new ArgumentNullException(nameof(distCoeffs));

            IntPtr matPtr;
            unsafe
            {
                fixed (double* cameraMatrixPtr = cameraMatrix)
                {
                    NativeMethods.HandleException(
                        NativeMethods.calib3d_getOptimalNewCameraMatrix_array(
                        cameraMatrixPtr, distCoeffs, distCoeffs.Length,
                        imageSize, alpha, newImgSize,
                        out validPixROI, centerPrincipalPoint ? 1 : 0, out matPtr));
                    if (matPtr == IntPtr.Zero)
                        return null;
                }
            }

            using var mat = new Mat<double>(matPtr);
            return mat.ToRectangularArray();
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
        public static void CalibrateHandEye(
            IEnumerable<Mat> R_gripper2base,
            IEnumerable<Mat> t_gripper2base,
            IEnumerable<Mat> R_target2cam,
            IEnumerable<Mat> t_target2cam,
            OutputArray R_cam2gripper,
            OutputArray t_cam2gripper,
            HandEyeCalibrationMethod method = HandEyeCalibrationMethod.TSAI)
        {
            if (R_gripper2base == null)
                throw new ArgumentNullException(nameof(R_gripper2base));
            if (t_gripper2base == null)
                throw new ArgumentNullException(nameof(t_gripper2base));
            if (R_target2cam == null)
                throw new ArgumentNullException(nameof(R_target2cam));
            if (t_target2cam == null)
                throw new ArgumentNullException(nameof(t_target2cam));
            if (R_cam2gripper == null)
                throw new ArgumentNullException(nameof(R_cam2gripper));
            if (t_cam2gripper == null)
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
                NativeMethods.calib3d_calibrateHandEye(
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
        /// converts point coordinates from normal pixel coordinates to homogeneous coordinates ((x,y)->(x,y,1))
        /// </summary>
        /// <param name="src">Input vector of N-dimensional points.</param>
        /// <param name="dst">Output vector of N+1-dimensional points.</param>
        public static void ConvertPointsToHomogeneous(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_convertPointsToHomogeneous_InputArray(src.CvPtr, dst.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// converts point coordinates from normal pixel coordinates to homogeneous coordinates ((x,y)->(x,y,1))
        /// </summary>
        /// <param name="src">Input vector of N-dimensional points.</param>
        /// <returns>Output vector of N+1-dimensional points.</returns>
        public static Vec3f[] ConvertPointsToHomogeneous(IEnumerable<Vec2f> src)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));

            var srcA = src as Vec2f[] ?? src.ToArray();
            var dstA = new Vec3f[srcA.Length];
            NativeMethods.HandleException(
                NativeMethods.calib3d_convertPointsToHomogeneous_array1(srcA, dstA, srcA.Length));
            return dstA;
        }

        /// <summary>
        /// converts point coordinates from normal pixel coordinates to homogeneous coordinates ((x,y)->(x,y,1))
        /// </summary>
        /// <param name="src">Input vector of N-dimensional points.</param>
        /// <returns>Output vector of N+1-dimensional points.</returns>
        public static Vec4f[] ConvertPointsToHomogeneous(IEnumerable<Vec3f> src)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));

            var srcA = src as Vec3f[] ?? src.ToArray();
            var dstA = new Vec4f[srcA.Length];
            NativeMethods.HandleException(
                NativeMethods.calib3d_convertPointsToHomogeneous_array2(srcA, dstA, srcA.Length));
            return dstA;
        }

        /// <summary>
        /// converts point coordinates from homogeneous to normal pixel coordinates ((x,y,z)->(x/z, y/z))
        /// </summary>
        /// <param name="src">Input vector of N-dimensional points.</param>
        /// <param name="dst">Output vector of N-1-dimensional points.</param>
        public static void ConvertPointsFromHomogeneous(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.HandleException(
                NativeMethods.calib3d_convertPointsFromHomogeneous_InputArray(src.CvPtr, dst.CvPtr));
            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// converts point coordinates from homogeneous to normal pixel coordinates ((x,y,z)->(x/z, y/z))
        /// </summary>
        /// <param name="src">Input vector of N-dimensional points.</param>
        /// <returns>Output vector of N-1-dimensional points.</returns>
        public static Vec2f[] ConvertPointsFromHomogeneous(IEnumerable<Vec3f> src)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));

            var srcA = src as Vec3f[] ?? src.ToArray();
            var dstA = new Vec2f[srcA.Length];
            NativeMethods.HandleException(
                NativeMethods.calib3d_convertPointsFromHomogeneous_array1(srcA, dstA, srcA.Length));
            return dstA;
        }

        /// <summary>
        /// converts point coordinates from homogeneous to normal pixel coordinates ((x,y,z)->(x/z, y/z))
        /// </summary>
        /// <param name="src">Input vector of N-dimensional points.</param>
        /// <returns>Output vector of N-1-dimensional points.</returns>
        public static Vec3f[] ConvertPointsFromHomogeneous(IEnumerable<Vec4f> src)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));

            var srcA = src as Vec4f[] ?? src.ToArray();
            var dstA = new Vec3f[srcA.Length];
            NativeMethods.HandleException(
                NativeMethods.calib3d_convertPointsFromHomogeneous_array2(srcA, dstA, srcA.Length));
            return dstA;
        }

        /// <summary>
        /// Converts points to/from homogeneous coordinates.
        /// </summary>
        /// <param name="src">Input array or vector of 2D, 3D, or 4D points.</param>
        /// <param name="dst">Output vector of 2D, 3D, or 4D points.</param>
        public static void ConvertPointsHomogeneous(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.HandleException(
                NativeMethods.calib3d_convertPointsHomogeneous(src.CvPtr, dst.CvPtr));
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
            FundamentalMatMethod method = FundamentalMatMethod.Ransac,
            double param1 = 3.0, double param2 = 0.99,
            OutputArray? mask = null)
        {
            if (points1 == null)
                throw new ArgumentNullException(nameof(points1));
            if (points2 == null)
                throw new ArgumentNullException(nameof(points2));
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_findFundamentalMat_InputArray(
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
        public static Mat FindFundamentalMat(
            IEnumerable<Point2f> points1, 
            IEnumerable<Point2f> points2,
            FundamentalMatMethod method = FundamentalMatMethod.Ransac,
            double param1 = 3.0,
            double param2 = 0.99,
            OutputArray? mask = null)
        {
            if (points1 == null)
                throw new ArgumentNullException(nameof(points1));
            if (points2 == null)
                throw new ArgumentNullException(nameof(points2));

            var points1Array = points1 as Point2f[] ?? points1.ToArray();
            var points2Array = points2 as Point2f[] ?? points2.ToArray();

            NativeMethods.HandleException(
                NativeMethods.calib3d_findFundamentalMat_arrayF32(
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
        public static Mat FindFundamentalMat(
            IEnumerable<Point2d> points1, 
            IEnumerable<Point2d> points2,
            FundamentalMatMethod method = FundamentalMatMethod.Ransac,
            double param1 = 3.0,
            double param2 = 0.99,
            OutputArray? mask = null)
        {
            if (points1 == null)
                throw new ArgumentNullException(nameof(points1));
            if (points2 == null)
                throw new ArgumentNullException(nameof(points2));

            var points1Array = points1 as Point2d[] ?? points1.ToArray();
            var points2Array = points2 as Point2d[] ?? points2.ToArray();

            NativeMethods.HandleException(
                NativeMethods.calib3d_findFundamentalMat_arrayF64(
                    points1Array, points1Array.Length,
                    points2Array, points2Array.Length, (int) method,
                    param1, param2, ToPtr(mask), out var ret));
            mask?.Fix();
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
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            if (F == null)
                throw new ArgumentNullException(nameof(F));
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));
            points.ThrowIfDisposed();
            F.ThrowIfDisposed();
            lines.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_computeCorrespondEpilines_InputArray(
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
        public static Point3f[] ComputeCorrespondEpilines(IEnumerable<Point2d> points,
                                                     int whichImage, double[,] F)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            if (F == null)
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
                        NativeMethods.calib3d_computeCorrespondEpilines_array2d(
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
        public static Point3f[] ComputeCorrespondEpilines(IEnumerable<Point3d> points,
                                                     int whichImage, double[,] F)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            if (F == null)
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
                        NativeMethods.calib3d_computeCorrespondEpilines_array3d(
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
            if (projMatr1 == null)
                throw new ArgumentNullException(nameof(projMatr1));
            if (projMatr2 == null)
                throw new ArgumentNullException(nameof(projMatr2));
            if (projPoints1 == null)
                throw new ArgumentNullException(nameof(projPoints1));
            if (projPoints2 == null)
                throw new ArgumentNullException(nameof(projPoints2));
            if (points4D == null)
                throw new ArgumentNullException(nameof(points4D));
            projMatr1.ThrowIfDisposed();
            projMatr2.ThrowIfDisposed();
            projPoints1.ThrowIfDisposed();
            projPoints2.ThrowIfDisposed();
            points4D.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_triangulatePoints_InputArray(
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
        public static Vec4d[] TriangulatePoints(
            double[,] projMatr1, 
            double[,] projMatr2,
            IEnumerable<Point2d> projPoints1, 
            IEnumerable<Point2d> projPoints2)
        {
            if (projMatr1 == null)
                throw new ArgumentNullException(nameof(projMatr1));
            if (projMatr2 == null)
                throw new ArgumentNullException(nameof(projMatr2));
            if (projPoints1 == null)
                throw new ArgumentNullException(nameof(projPoints1));
            if (projPoints2 == null)
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
                        NativeMethods.calib3d_triangulatePoints_array(
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
            if (F == null)
                throw new ArgumentNullException(nameof(F));
            if (points1 == null)
                throw new ArgumentNullException(nameof(points1));
            if (points2 == null)
                throw new ArgumentNullException(nameof(points2));
            if (newPoints1 == null)
                throw new ArgumentNullException(nameof(newPoints1));
            if (newPoints2 == null)
                throw new ArgumentNullException(nameof(newPoints2));
            F.ThrowIfDisposed();
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();
            newPoints1.ThrowIfNotReady();
            newPoints2.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_correctMatches_InputArray(
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
        public static void CorrectMatches(
            double[,] F,
            IEnumerable<Point2d> points1,
            IEnumerable<Point2d> points2,
            out Point2d[] newPoints1,
            out Point2d[] newPoints2)
        {
            if (F == null)
                throw new ArgumentNullException(nameof(F));
            if (points1 == null)
                throw new ArgumentNullException(nameof(points1));
            if (points2 == null)
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
                        NativeMethods.calib3d_correctMatches_array(
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
            if (E == null)
                throw new ArgumentNullException(nameof(E));
            if (points1 == null)
                throw new ArgumentNullException(nameof(points1));
            if (points2 == null)
                throw new ArgumentNullException(nameof(points2));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (R == null)
                throw new ArgumentNullException(nameof(R));
            if (t == null)
                throw new ArgumentNullException(nameof(t));
            E.ThrowIfDisposed();
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();
            R.ThrowIfNotReady();
            t.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_recoverPose_InputArray1(
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
            if (E == null)
                throw new ArgumentNullException(nameof(E));
            if (points1 == null)
                throw new ArgumentNullException(nameof(points1));
            if (points2 == null)
                throw new ArgumentNullException(nameof(points2));
            if (R == null)
                throw new ArgumentNullException(nameof(R));
            if (t == null)
                throw new ArgumentNullException(nameof(t));
            E.ThrowIfDisposed();
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();
            R.ThrowIfNotReady();
            t.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_recoverPose_InputArray2(
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
            if (E == null)
                throw new ArgumentNullException(nameof(E));
            if (points1 == null)
                throw new ArgumentNullException(nameof(points1));
            if (points2 == null)
                throw new ArgumentNullException(nameof(points2));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (R == null)
                throw new ArgumentNullException(nameof(R));
            if (t == null)
                throw new ArgumentNullException(nameof(t));
            E.ThrowIfDisposed();
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();
            R.ThrowIfNotReady();
            t.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_recoverPose_InputArray3(
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
            if (points1 == null)
                throw new ArgumentNullException(nameof(points1));
            if (points2 == null)
                throw new ArgumentNullException(nameof(points2));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_findEssentialMat_InputArray1(
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
            if (points1 == null)
                throw new ArgumentNullException(nameof(points1));
            if (points2 == null)
                throw new ArgumentNullException(nameof(points2));
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_findEssentialMat_InputArray2(
                    points1.CvPtr, points2.CvPtr, focal, pp,
                    (int) method, prob, threshold, ToPtr(mask), out var ret));

            mask?.Fix();
            GC.KeepAlive(points1);
            GC.KeepAlive(points2);
            return new Mat(ret);
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
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_filterSpeckles(img.CvPtr, newVal, maxSpeckleSize, maxDiff, ToPtr(buf)));
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
                NativeMethods.calib3d_getValidDisparityROI(
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
            if (disparity == null)
                throw new ArgumentNullException(nameof(disparity));
            if (cost == null)
                throw new ArgumentNullException(nameof(cost));
            disparity.ThrowIfNotReady();
            cost.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_validateDisparity(
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
            if (disparity == null)
                throw new ArgumentNullException(nameof(disparity));
            if (_3dImage == null)
                throw new ArgumentNullException(nameof(_3dImage));
            if (Q == null)
                throw new ArgumentNullException(nameof(Q));
            disparity.ThrowIfDisposed();
            _3dImage.ThrowIfNotReady();
            Q.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_reprojectImageTo3D(
                    disparity.CvPtr, _3dImage.CvPtr, Q.CvPtr, handleMissingValues ? 1 : 0, ddepth));

            _3dImage.Fix();
            GC.KeepAlive(disparity);
            GC.KeepAlive(_3dImage);
            GC.KeepAlive(Q);
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
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (outVal == null)
                throw new ArgumentNullException(nameof(outVal));
            if (inliers == null)
                throw new ArgumentNullException(nameof(inliers));
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            outVal.ThrowIfNotReady();
            inliers.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_estimateAffine3D(
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
            if (pt1 == null)
                throw new ArgumentNullException(nameof(pt1));
            if (pt2 == null)
                throw new ArgumentNullException(nameof(pt2));
            if (f == null)
                throw new ArgumentNullException(nameof(f));
            pt1.ThrowIfDisposed();
            pt2.ThrowIfDisposed();
            f.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_sampsonDistance_InputArray(pt1.CvPtr, pt2.CvPtr, f.CvPtr, out var ret));

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
            if (f == null)
                throw new ArgumentNullException(nameof(f));
            if (f.GetLength(0) != 3 || f.GetLength(1) != 3)
                throw new ArgumentException("f should be 3x3 matrix", nameof(f));

            unsafe
            {
                fixed (double* fPtr = f)
                {
                    NativeMethods.HandleException(
                        NativeMethods.calib3d_sampsonDistance_Point3d(pt1, pt2, fPtr, out var ret));
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
            if (from == null)
                throw new ArgumentNullException(nameof(from));
            if (to == null)
                throw new ArgumentNullException(nameof(to));
            from.ThrowIfDisposed();
            to.ThrowIfDisposed();
            inliers?.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_estimateAffine2D(
                    from.CvPtr, to.CvPtr, ToPtr(inliers),
                    (int) method, ransacReprojThreshold, maxIters, confidence, refineIters, out var matPtr));

            GC.KeepAlive(inliers);
            GC.KeepAlive(inliers);
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
            if (from == null)
                throw new ArgumentNullException(nameof(from));
            if (to == null)
                throw new ArgumentNullException(nameof(to));
            from.ThrowIfDisposed();
            to.ThrowIfDisposed();
            inliers?.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_estimateAffinePartial2D(
                    from.CvPtr, to.CvPtr, ToPtr(inliers),
                    (int) method, ransacReprojThreshold, maxIters, confidence, refineIters, out var matPtr));

            GC.KeepAlive(inliers);
            GC.KeepAlive(inliers);
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
            if (h == null)
                throw new ArgumentNullException(nameof(h));
            if (k == null)
                throw new ArgumentNullException(nameof(k));

            h.ThrowIfDisposed();
            k.ThrowIfDisposed();

            using var rotationsVec = new VectorOfMat();
            using var translationsVec = new VectorOfMat();
            using var normalsVec = new VectorOfMat();

            NativeMethods.HandleException(
                NativeMethods.calib3d_decomposeHomographyMat(
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
            if (rotations == null)
                throw new ArgumentNullException(nameof(rotations));
            if (normals == null)
                throw new ArgumentNullException(nameof(normals));
            if (beforePoints == null)
                throw new ArgumentNullException(nameof(beforePoints));
            if (afterPoints == null)
                throw new ArgumentNullException(nameof(afterPoints));
            if (possibleSolutions == null)
                throw new ArgumentNullException(nameof(possibleSolutions));
            beforePoints.ThrowIfDisposed();
            afterPoints.ThrowIfDisposed();
            possibleSolutions.ThrowIfNotReady();
            pointsMask?.ThrowIfDisposed();

            using var rotationsVec = new VectorOfMat(rotations);
            using var normalsVec = new VectorOfMat(normals);
            NativeMethods.HandleException(
                NativeMethods.calib3d_filterHomographyDecompByVisibleRefpoints(
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
        /// corrects lens distortion for the given camera matrix and distortion coefficients
        /// </summary>
        /// <param name="src">Input (distorted) image.</param>
        /// <param name="dst">Output (corrected) image that has the same size and type as src .</param>
        /// <param name="cameraMatrix"> Input camera matrix</param>
        /// <param name="distCoeffs">Input vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6]]) of 4, 5, 
        /// or 8 elements. If the vector is null, the zero distortion coefficients are assumed.</param>
        /// <param name="newCameraMatrix">Camera matrix of the distorted image. 
        /// By default, it is the same as cameraMatrix but you may additionally scale 
        /// and shift the result by using a different matrix.</param>
        public static void Undistort(InputArray src, OutputArray dst,
            InputArray cameraMatrix,
            InputArray distCoeffs,
            InputArray? newCameraMatrix = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            cameraMatrix.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_undistort(src.CvPtr, dst.CvPtr, cameraMatrix.CvPtr,
                    ToPtr(distCoeffs), ToPtr(newCameraMatrix)));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(cameraMatrix);
            GC.KeepAlive(distCoeffs);
            GC.KeepAlive(newCameraMatrix);
            dst.Fix();
        }

        /// <summary>
        /// initializes maps for cv::remap() to correct lens distortion and optionally rectify the image
        /// </summary>
        /// <param name="cameraMatrix"></param>
        /// <param name="distCoeffs"></param>
        /// <param name="r"></param>
        /// <param name="newCameraMatrix"></param>
        /// <param name="size"></param>
        /// <param name="m1Type"></param>
        /// <param name="map1"></param>
        /// <param name="map2"></param>
        public static void InitUndistortRectifyMap(
            InputArray cameraMatrix, InputArray distCoeffs,
            InputArray r, InputArray newCameraMatrix,
            Size size, MatType m1Type, OutputArray map1, OutputArray map2)
        {
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (distCoeffs == null)
                throw new ArgumentNullException(nameof(distCoeffs));
            if (r == null)
                throw new ArgumentNullException(nameof(r));
            if (newCameraMatrix == null)
                throw new ArgumentNullException(nameof(newCameraMatrix));
            if (map1 == null)
                throw new ArgumentNullException(nameof(map1));
            if (map2 == null)
                throw new ArgumentNullException(nameof(map2));
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            r.ThrowIfDisposed();
            newCameraMatrix.ThrowIfDisposed();
            map1.ThrowIfNotReady();
            map2.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_initUndistortRectifyMap(
                    cameraMatrix.CvPtr, distCoeffs.CvPtr, r.CvPtr, newCameraMatrix.CvPtr, size, m1Type, map1.CvPtr, map2.CvPtr));

            GC.KeepAlive(cameraMatrix);
            GC.KeepAlive(distCoeffs);
            GC.KeepAlive(r);
            GC.KeepAlive(newCameraMatrix);
            GC.KeepAlive(map1);
            GC.KeepAlive(map2);
            map1.Fix();
            map2.Fix();
        }

        /// <summary>
        /// initializes maps for cv::remap() for wide-angle
        /// </summary>
        /// <param name="cameraMatrix"></param>
        /// <param name="distCoeffs"></param>
        /// <param name="imageSize"></param>
        /// <param name="destImageWidth"></param>
        /// <param name="m1Type"></param>
        /// <param name="map1"></param>
        /// <param name="map2"></param>
        /// <param name="projType"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static float InitWideAngleProjMap(
            InputArray cameraMatrix, InputArray distCoeffs,
            Size imageSize, int destImageWidth, MatType m1Type,
            OutputArray map1, OutputArray map2,
            ProjectionType projType, double alpha = 0)
        {
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (distCoeffs == null)
                throw new ArgumentNullException(nameof(distCoeffs));
            if (map1 == null)
                throw new ArgumentNullException(nameof(map1));
            if (map2 == null)
                throw new ArgumentNullException(nameof(map2));
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            map1.ThrowIfNotReady();
            map2.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.calib3d_initWideAngleProjMap(
                    cameraMatrix.CvPtr, distCoeffs.CvPtr, imageSize,
                    destImageWidth, m1Type, map1.CvPtr, map2.CvPtr, (int) projType, alpha, out var ret));

            GC.KeepAlive(cameraMatrix);
            GC.KeepAlive(distCoeffs);
            GC.KeepAlive(map1);
            GC.KeepAlive(map2);
            map1.Fix();
            map2.Fix();
            return ret;
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
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            cameraMatrix.ThrowIfDisposed();
            var imgSize0 = imgSize.GetValueOrDefault(new Size());

            NativeMethods.HandleException(
                NativeMethods.calib3d_getDefaultNewCameraMatrix(
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
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            cameraMatrix.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_undistortPoints(
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
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            cameraMatrix.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.calib3d_undistortPointsIter(
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
        /// The methods in this class use a so-called fisheye camera model.
        /// </summary>
        public static class FishEye
        {
            /// <summary>
            /// Projects points using fisheye model.
            /// 
            /// The function computes projections of 3D points to the image plane given intrinsic and extrinsic 
            /// camera parameters.Optionally, the function computes Jacobians - matrices of partial derivatives of 
            /// image points coordinates(as functions of all the input parameters) with respect to the particular 
            /// parameters, intrinsic and/or extrinsic.
            /// </summary>
            /// <param name="objectPoints">Array of object points, 1xN/Nx1 3-channel (or vector&lt;Point3f&gt; ), 
            /// where N is the number of points in the view.</param>
            /// <param name="imagePoints">Output array of image points, 2xN/Nx2 1-channel or 1xN/Nx1 2-channel, 
            /// or vector&lt;Point2f&gt;.</param>
            /// <param name="rvec"></param>
            /// <param name="tvec"></param>
            /// <param name="k">Camera matrix</param>
            /// <param name="d">Input vector of distortion coefficients</param>
            /// <param name="alpha">The skew coefficient.</param>
            /// <param name="jacobian">Optional output 2Nx15 jacobian matrix of derivatives of image points with respect 
            /// to components of the focal lengths, coordinates of the principal point, distortion coefficients, 
            /// rotation vector, translation vector, and the skew.In the old interface different components of 
            /// the jacobian are returned via different output parameters.</param>
            public static void ProjectPoints(
                InputArray objectPoints, OutputArray imagePoints, InputArray rvec, InputArray tvec,
                InputArray k, InputArray d, double alpha = 0, OutputArray? jacobian = null)
            {
                if (objectPoints == null)
                    throw new ArgumentNullException(nameof(objectPoints));
                if (imagePoints == null)
                    throw new ArgumentNullException(nameof(imagePoints));
                if (rvec == null)
                    throw new ArgumentNullException(nameof(rvec));
                if (tvec == null)
                    throw new ArgumentNullException(nameof(tvec));
                if (k == null)
                    throw new ArgumentNullException(nameof(k));
                if (d == null)
                    throw new ArgumentNullException(nameof(d));
                objectPoints.ThrowIfDisposed();
                rvec.ThrowIfDisposed();
                tvec.ThrowIfDisposed();
                k.ThrowIfDisposed();
                d.ThrowIfDisposed();
                jacobian?.ThrowIfNotReady();

                NativeMethods.HandleException(
                    NativeMethods.calib3d_fisheye_projectPoints2(
                        objectPoints.CvPtr,
                        imagePoints.CvPtr,
                        rvec.CvPtr, tvec.CvPtr,
                        k.CvPtr, d.CvPtr,
                        alpha, ToPtr(jacobian)));

                GC.KeepAlive(objectPoints);
                GC.KeepAlive(rvec);
                GC.KeepAlive(tvec);
                GC.KeepAlive(k);
                GC.KeepAlive(d);
                GC.KeepAlive(imagePoints);
                GC.KeepAlive(jacobian);
            }

            /// <summary>
            /// Distorts 2D points using fisheye model.
            /// </summary>
            /// <param name="undistorted">Array of object points, 1xN/Nx1 2-channel (or vector&lt;Point2f&gt; ), 
            /// where N is the number of points in the view.</param>
            /// <param name="distorted">Output array of image points, 1xN/Nx1 2-channel, or vector&lt;Point2f&gt; .</param>
            /// <param name="k">Camera matrix</param>
            /// <param name="d">Input vector of distortion coefficients</param>
            /// <param name="alpha">The skew coefficient.</param>
            public static void DistortPoints(
                InputArray undistorted, OutputArray distorted, InputArray k, InputArray d, double alpha = 0)
            {
                if (undistorted == null)
                    throw new ArgumentNullException(nameof(undistorted));
                if (distorted == null)
                    throw new ArgumentNullException(nameof(distorted));
                if (k == null)
                    throw new ArgumentNullException(nameof(k));
                if (d == null)
                    throw new ArgumentNullException(nameof(d));
                undistorted.ThrowIfDisposed();
                distorted.ThrowIfNotReady();
                k.ThrowIfDisposed();
                d.ThrowIfDisposed();

                NativeMethods.HandleException(
                    NativeMethods.calib3d_fisheye_distortPoints(
                        undistorted.CvPtr, distorted.CvPtr, k.CvPtr, d.CvPtr, alpha));

                GC.KeepAlive(undistorted);
                GC.KeepAlive(distorted);
                GC.KeepAlive(k);
                GC.KeepAlive(d);
            }

            /// <summary>
            /// Undistorts 2D points using fisheye model
            /// </summary>
            /// <param name="distorted">Array of object points, 1xN/Nx1 2-channel (or vector&lt;Point2f&gt; ), 
            /// where N is the number of points in the view.</param>
            /// <param name="undistorted">Output array of image points, 1xN/Nx1 2-channel, or vector&gt;Point2f&gt; .</param>
            /// <param name="k">Camera matrix</param>
            /// <param name="d">Input vector of distortion coefficients (k_1, k_2, k_3, k_4).</param>
            /// <param name="r">Rectification transformation in the object space: 3x3 1-channel, or vector: 3x1/1x3 1-channel or 1x1 3-channel</param>
            /// <param name="p">New camera matrix (3x3) or new projection matrix (3x4)</param>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            public static void UndistortPoints(
                InputArray distorted, OutputArray undistorted,
                InputArray k, InputArray d, InputArray? r = null, InputArray? p = null)
            {
                if (distorted == null)
                    throw new ArgumentNullException(nameof(distorted));
                if (undistorted == null)
                    throw new ArgumentNullException(nameof(undistorted));
                if (k == null)
                    throw new ArgumentNullException(nameof(k));
                if (d == null)
                    throw new ArgumentNullException(nameof(d));
                distorted.ThrowIfDisposed();
                undistorted.ThrowIfNotReady();
                k.ThrowIfDisposed();
                d.ThrowIfDisposed();
                r?.ThrowIfDisposed();
                p?.ThrowIfDisposed();

                NativeMethods.HandleException(
                    NativeMethods.calib3d_fisheye_undistortPoints(
                        distorted.CvPtr, undistorted.CvPtr, k.CvPtr, d.CvPtr, ToPtr(r), ToPtr(p)));

                GC.KeepAlive(distorted);
                GC.KeepAlive(undistorted);
                GC.KeepAlive(k);
                GC.KeepAlive(d);
                GC.KeepAlive(r);
                GC.KeepAlive(p);
            }

            /// <summary>
            /// Computes undistortion and rectification maps for image transform by cv::remap(). 
            /// If D is empty zero distortion is used, if R or P is empty identity matrixes are used.
            /// </summary>
            /// <param name="k">Camera matrix</param>
            /// <param name="d">Input vector of distortion coefficients (k_1, k_2, k_3, k_4).</param>
            /// <param name="r">Rectification transformation in the object space: 3x3 1-channel, or vector: 3x1/1x3 1-channel or 1x1 3-channel</param>
            /// <param name="p">New camera matrix (3x3) or new projection matrix (3x4)</param>
            /// <param name="size">Undistorted image size.</param>
            /// <param name="m1type">Type of the first output map that can be CV_32FC1 or CV_16SC2 . See convertMaps() for details.</param>
            /// <param name="map1">The first output map.</param>
            /// <param name="map2">The second output map.</param>
            public static void InitUndistortRectifyMap(
                InputArray k, InputArray d, InputArray r, InputArray p,
                Size size, int m1type, OutputArray map1, OutputArray map2)
            {
                if (k == null)
                    throw new ArgumentNullException(nameof(k));
                if (d == null)
                    throw new ArgumentNullException(nameof(d));
                if (r == null)
                    throw new ArgumentNullException(nameof(r));
                if (p == null)
                    throw new ArgumentNullException(nameof(p));
                if (map1 == null)
                    throw new ArgumentNullException(nameof(map1));
                if (map2 == null)
                    throw new ArgumentNullException(nameof(map2));
                k.ThrowIfDisposed();
                d.ThrowIfDisposed();
                r.ThrowIfDisposed();
                p.ThrowIfDisposed();
                map1.ThrowIfNotReady();
                map2.ThrowIfNotReady();

                NativeMethods.HandleException(
                    NativeMethods.calib3d_fisheye_initUndistortRectifyMap(
                        k.CvPtr, d.CvPtr, r.CvPtr, p.CvPtr, size, m1type, map1.CvPtr, map2.CvPtr));
                
                GC.KeepAlive(k);
                GC.KeepAlive(d);
                GC.KeepAlive(r);
                GC.KeepAlive(p);
                GC.KeepAlive(map1);
                GC.KeepAlive(map2);
            }

            /// <summary>
            /// Transforms an image to compensate for fisheye lens distortion.
            /// </summary>
            /// <param name="distorted">image with fisheye lens distortion.</param>
            /// <param name="undistorted">Output image with compensated fisheye lens distortion.</param>
            /// <param name="k">Camera matrix</param>
            /// <param name="d">Input vector of distortion coefficients (k_1, k_2, k_3, k_4).</param>
            /// <param name="knew">Camera matrix of the distorted image. By default, it is the identity matrix but you
            /// may additionally scale and shift the result by using a different matrix.</param>
            /// <param name="newSize"></param>
            public static void UndistortImage(
                InputArray distorted, OutputArray undistorted,
                InputArray k, InputArray d, InputArray? knew = null, Size newSize = default)
            {
                if (distorted == null)
                    throw new ArgumentNullException(nameof(distorted));
                if (undistorted == null)
                    throw new ArgumentNullException(nameof(undistorted));
                if (k == null)
                    throw new ArgumentNullException(nameof(k));
                if (d == null)
                    throw new ArgumentNullException(nameof(d));
                distorted.ThrowIfDisposed();
                undistorted.ThrowIfNotReady();
                k.ThrowIfDisposed();
                d.ThrowIfDisposed();
                knew?.ThrowIfDisposed();

                NativeMethods.HandleException(
                    NativeMethods.calib3d_fisheye_undistortImage(
                        distorted.CvPtr, undistorted.CvPtr, k.CvPtr, d.CvPtr, ToPtr(knew), newSize));

                GC.KeepAlive(distorted);
                GC.KeepAlive(undistorted);
                GC.KeepAlive(k);
                GC.KeepAlive(d);
                GC.KeepAlive(knew);
            }

            /// <summary>
            /// Estimates new camera matrix for undistortion or rectification.
            /// </summary>
            /// <param name="k">Camera matrix</param>
            /// <param name="d">Input vector of distortion coefficients (k_1, k_2, k_3, k_4).</param>
            /// <param name="imageSize"></param>
            /// <param name="r">Rectification transformation in the object space: 3x3 1-channel, or vector: 3x1/1x3
            /// 1-channel or 1x1 3-channel</param>
            /// <param name="p">New camera matrix (3x3) or new projection matrix (3x4)</param>
            /// <param name="balance">Sets the new focal length in range between the min focal length and the max focal 
            /// length.Balance is in range of[0, 1].</param>
            /// <param name="newSize"></param>
            /// <param name="fovScale">Divisor for new focal length.</param>
            public static void EstimateNewCameraMatrixForUndistortRectify(
                InputArray k, InputArray d, Size imageSize, InputArray r,
                OutputArray p, double balance = 0.0, Size newSize = default, double fovScale = 1.0)
            {
                if (k == null)
                    throw new ArgumentNullException(nameof(k));
                if (d == null)
                    throw new ArgumentNullException(nameof(d));
                if (r == null)
                    throw new ArgumentNullException(nameof(r));
                if (p == null)
                    throw new ArgumentNullException(nameof(p));
                k.ThrowIfDisposed();
                d.ThrowIfDisposed();
                r.ThrowIfDisposed();
                p.ThrowIfNotReady();

                NativeMethods.HandleException(
                    NativeMethods.calib3d_fisheye_estimateNewCameraMatrixForUndistortRectify(
                        k.CvPtr, d.CvPtr, imageSize, r.CvPtr, p.CvPtr, balance, newSize, fovScale));

                GC.KeepAlive(k);
                GC.KeepAlive(d);
                GC.KeepAlive(r);
                GC.KeepAlive(p);
            }

            /// <summary>
            /// Performs camera calibaration
            /// </summary>
            /// <param name="objectPoints">vector of vectors of calibration pattern points in the calibration pattern coordinate space.</param>
            /// <param name="imagePoints">vector of vectors of the projections of calibration pattern points. 
            /// imagePoints.size() and objectPoints.size() and imagePoints[i].size() must be equal to 
            /// objectPoints[i].size() for each i.</param>
            /// <param name="imageSize">Size of the image used only to initialize the intrinsic camera matrix.</param>
            /// <param name="k">Output 3x3 floating-point camera matrix</param>
            /// <param name="d">Output vector of distortion coefficients (k_1, k_2, k_3, k_4).</param>
            /// <param name="rvecs">Output vector of rotation vectors (see Rodrigues ) estimated for each pattern view. 
            /// That is, each k-th rotation vector together with the corresponding k-th translation vector(see 
            /// the next output parameter description) brings the calibration pattern from the model coordinate 
            /// space(in which object points are specified) to the world coordinate space, that is, a real 
            /// position of the calibration pattern in the k-th pattern view(k= 0.. * M * -1).</param>
            /// <param name="tvecs">Output vector of translation vectors estimated for each pattern view.</param>
            /// <param name="flags">Different flags that may be zero or a combination of flag values</param>
            /// <param name="criteria">Termination criteria for the iterative optimization algorithm.</param>
            /// <returns></returns>
            public static double Calibrate(
                IEnumerable<Mat> objectPoints, IEnumerable<Mat> imagePoints,
                Size imageSize, InputOutputArray k, InputOutputArray d,
                out IEnumerable<Mat> rvecs, out IEnumerable<Mat> tvecs,
                FishEyeCalibrationFlags flags = 0, TermCriteria? criteria = null)
            {
                if (objectPoints == null)
                    throw new ArgumentNullException(nameof(objectPoints));
                if (imagePoints == null)
                    throw new ArgumentNullException(nameof(imagePoints));
                if (k == null)
                    throw new ArgumentNullException(nameof(k));
                if (d == null)
                    throw new ArgumentNullException(nameof(d));
                k.ThrowIfDisposed();
                d.ThrowIfDisposed();

                var criteriaVal = criteria.GetValueOrDefault(
                    new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 100, double.Epsilon));

                using var objectPointsVec = new VectorOfMat(objectPoints);
                using var imagePointsVec = new VectorOfMat(imagePoints);
                using var rvecsVec = new VectorOfMat();
                using var tvecsVec = new VectorOfMat();
                NativeMethods.HandleException(
                    NativeMethods.calib3d_fisheye_calibrate(
                        objectPointsVec.CvPtr, imagePointsVec.CvPtr, imageSize,
                        k.CvPtr, d.CvPtr, rvecsVec.CvPtr, tvecsVec.CvPtr, (int) flags, criteriaVal, out var result));

                rvecs = rvecsVec.ToArray();
                tvecs = tvecsVec.ToArray();

                GC.KeepAlive(objectPoints);
                GC.KeepAlive(imagePoints);
                GC.KeepAlive(k);
                GC.KeepAlive(d);

                return result;
            }

            /// <summary>
            /// Stereo rectification for fisheye camera model
            /// </summary>
            /// <param name="k1">First camera matrix.</param>
            /// <param name="d1">First camera distortion parameters.</param>
            /// <param name="k2">Second camera matrix.</param>
            /// <param name="d2">Second camera distortion parameters.</param>
            /// <param name="imageSize">Size of the image used for stereo calibration.</param>
            /// <param name="r">Rotation matrix between the coordinate systems of the first and the second cameras.</param>
            /// <param name="tvec">Translation vector between coordinate systems of the cameras.</param>
            /// <param name="r1">Output 3x3 rectification transform (rotation matrix) for the first camera.</param>
            /// <param name="r2">Output 3x3 rectification transform (rotation matrix) for the second camera.</param>
            /// <param name="p1">Output 3x4 projection matrix in the new (rectified) coordinate systems for the first camera.</param>
            /// <param name="p2">Output 3x4 projection matrix in the new (rectified) coordinate systems for the second camera.</param>
            /// <param name="q">Output 4x4 disparity-to-depth mapping matrix (see reprojectImageTo3D ).</param>
            /// <param name="flags">Operation flags that may be zero or CALIB_ZERO_DISPARITY . If the flag is set, 
            /// the function makes the principal points of each camera have the same pixel coordinates in the 
            /// rectified views.And if the flag is not set, the function may still shift the images in the 
            /// horizontal or vertical direction(depending on the orientation of epipolar lines) to maximize the 
            /// useful image area.</param>
            /// <param name="newImageSize">New image resolution after rectification. The same size should be passed to 
            /// initUndistortRectifyMap(see the stereo_calib.cpp sample in OpenCV samples directory). When(0,0) 
            /// is passed(default), it is set to the original imageSize.Setting it to larger value can help you 
            /// preserve details in the original image, especially when there is a big radial distortion.</param>
            /// <param name="balance">Sets the new focal length in range between the min focal length and the max focal
            /// length.Balance is in range of[0, 1].</param>
            /// <param name="fovScale">Divisor for new focal length.</param>
            public static void StereoRectify(
                InputArray k1, InputArray d1, InputArray k2, InputArray d2, 
                Size imageSize, InputArray r, InputArray tvec, OutputArray r1, OutputArray r2, 
                OutputArray p1, OutputArray p2, OutputArray q, FishEyeCalibrationFlags flags, Size newImageSize = default,
                double balance = 0.0, double fovScale = 1.0)
            {
                if (k1 == null)
                    throw new ArgumentNullException(nameof(k1));
                if (d1 == null)
                    throw new ArgumentNullException(nameof(d1));
                if (k2 == null)
                    throw new ArgumentNullException(nameof(k2));
                if (d2 == null)
                    throw new ArgumentNullException(nameof(d2));
                if (r == null)
                    throw new ArgumentNullException(nameof(r));
                if (tvec == null)
                    throw new ArgumentNullException(nameof(tvec));
                if (r1 == null)
                    throw new ArgumentNullException(nameof(r1));
                if (r2 == null)
                    throw new ArgumentNullException(nameof(r2));
                if (p1 == null)
                    throw new ArgumentNullException(nameof(p1));
                if (p2 == null)
                    throw new ArgumentNullException(nameof(p2));
                if (q == null)
                    throw new ArgumentNullException(nameof(q));
                k1.ThrowIfDisposed();
                d1.ThrowIfDisposed();
                k2.ThrowIfDisposed();
                d2.ThrowIfDisposed();
                r.ThrowIfDisposed();
                tvec.ThrowIfDisposed();
                r1.ThrowIfNotReady();
                r2.ThrowIfNotReady();
                p1.ThrowIfNotReady();
                p2.ThrowIfNotReady();
                q.ThrowIfNotReady();

                NativeMethods.HandleException(
                    NativeMethods.calib3d_fisheye_stereoRectify(
                        k1.CvPtr, d1.CvPtr, k2.CvPtr, d2.CvPtr,
                        imageSize, r.CvPtr, tvec.CvPtr, r1.CvPtr, r2.CvPtr,
                        p1.CvPtr, p2.CvPtr, q.CvPtr, (int) flags, newImageSize, balance, fovScale));

                GC.KeepAlive(k1);
                GC.KeepAlive(d1);
                GC.KeepAlive(k2);
                GC.KeepAlive(d2);
                GC.KeepAlive(r);
                GC.KeepAlive(tvec);
                GC.KeepAlive(r1);
                GC.KeepAlive(r2);
                GC.KeepAlive(p1);
                GC.KeepAlive(p2);
                GC.KeepAlive(q);
            }

            /// <summary>
            /// Performs stereo calibration
            /// </summary>
            /// <param name="objectPoints">Vector of vectors of the calibration pattern points.</param>
            /// <param name="imagePoints1">Vector of vectors of the projections of the calibration pattern points, 
            /// observed by the first camera.</param>
            /// <param name="imagePoints2">Vector of vectors of the projections of the calibration pattern points, 
            /// observed by the second camera.</param>
            /// <param name="k1">Input/output first camera matrix</param>
            /// <param name="d1">Input/output vector of distortion coefficients (k_1, k_2, k_3, k_4) of 4 elements.</param>
            /// <param name="k2">Input/output second camera matrix. The parameter is similar to K1 .</param>
            /// <param name="d2">Input/output lens distortion coefficients for the second camera. The parameter is 
            /// similar to D1.</param>
            /// <param name="imageSize">Size of the image used only to initialize intrinsic camera matrix.</param>
            /// <param name="r">Output rotation matrix between the 1st and the 2nd camera coordinate systems.</param>
            /// <param name="t">Output translation vector between the coordinate systems of the cameras.</param>
            /// <param name="flags">Different flags that may be zero or a combination of the FishEyeCalibrationFlags values</param>
            /// <param name="criteria">Termination criteria for the iterative optimization algorithm.</param>
            /// <returns></returns>
            public static double StereoCalibrate(
                IEnumerable<Mat> objectPoints, IEnumerable<Mat> imagePoints1, IEnumerable<Mat> imagePoints2,
                InputOutputArray k1, InputOutputArray d1, InputOutputArray k2, InputOutputArray d2, Size imageSize,
                OutputArray r, OutputArray t, FishEyeCalibrationFlags flags = FishEyeCalibrationFlags.FixIntrinsic,
                TermCriteria? criteria = null)
            {
                if (objectPoints == null)
                    throw new ArgumentNullException(nameof(objectPoints));
                if (imagePoints1 == null)
                    throw new ArgumentNullException(nameof(imagePoints1));
                if (imagePoints2 == null)
                    throw new ArgumentNullException(nameof(imagePoints2));
                if (k1 == null)
                    throw new ArgumentNullException(nameof(k1));
                if (d1 == null)
                    throw new ArgumentNullException(nameof(d1));
                if (k2 == null)
                    throw new ArgumentNullException(nameof(k2));
                if (d2 == null)
                    throw new ArgumentNullException(nameof(d2));
                if (r == null)
                    throw new ArgumentNullException(nameof(r));
                if (t == null)
                    throw new ArgumentNullException(nameof(t));
                k1.ThrowIfNotReady();
                d1.ThrowIfNotReady();
                k2.ThrowIfNotReady();
                d2.ThrowIfNotReady();
                r.ThrowIfNotReady();
                t.ThrowIfNotReady();

                var criteriaVal = criteria.GetValueOrDefault(
                    new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 100, double.Epsilon));

                using var objectPointsVec = new VectorOfMat(objectPoints);
                using var imagePoints1Vec = new VectorOfMat(imagePoints1); 
                using var imagePoints2Vec = new VectorOfMat(imagePoints2);
                NativeMethods.HandleException(
                    NativeMethods.calib3d_fisheye_stereoCalibrate(
                        objectPointsVec.CvPtr, imagePoints1Vec.CvPtr, imagePoints2Vec.CvPtr,
                        k1.CvPtr, d1.CvPtr, k2.CvPtr, d2.CvPtr, imageSize,
                        r.CvPtr, t.CvPtr, (int) flags, criteriaVal, out var result));

                GC.KeepAlive(objectPoints);
                GC.KeepAlive(imagePoints1);
                GC.KeepAlive(imagePoints2);
                GC.KeepAlive(k1);
                GC.KeepAlive(d1);
                GC.KeepAlive(k2);
                GC.KeepAlive(d2);
                GC.KeepAlive(r);
                GC.KeepAlive(t);

                return result;
            }
        }
    }
}
