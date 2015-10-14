using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    using FeatureDetector = Feature2D;

    static partial class Cv2
    {
        #region Rodrigues
        /// <summary>
        /// converts rotation vector to rotation matrix or vice versa using Rodrigues transformation
        /// </summary>
        /// <param name="src">Input rotation vector (3x1 or 1x3) or rotation matrix (3x3).</param>
        /// <param name="dst">Output rotation matrix (3x3) or rotation vector (3x1 or 1x3), respectively.</param>
        /// <param name="jacobian">Optional output Jacobian matrix, 3x9 or 9x3, which is a matrix of partial derivatives of the output array components with respect to the input array components.</param>
        public static void Rodrigues(InputArray src, OutputArray dst, OutputArray jacobian = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.calib3d_Rodrigues(src.CvPtr, dst.CvPtr, ToPtr(jacobian));
            dst.Fix();
            if (jacobian != null)
                jacobian.Fix();
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
                throw new ArgumentNullException("vector");
            if (vector.Length != 3)
                throw new ArgumentException("vector.Length != 3");

            using (var vectorM = new Mat(3, 1, MatType.CV_64FC1, vector))
            using (var matrixM = new MatOfDouble())
            using (var jacobianM = new MatOfDouble())
            {
                NativeMethods.calib3d_Rodrigues_VecToMat(vectorM.CvPtr, matrixM.CvPtr, jacobianM.CvPtr);
                matrix = matrixM.ToRectangularArray();
                jacobian = jacobianM.ToRectangularArray();
            }
        }
        /// <summary>
        /// converts rotation vector to rotation matrix using Rodrigues transformation
        /// </summary>
        /// <param name="vector">Input rotation vector (3x1).</param>
        /// <param name="matrix">Output rotation matrix (3x3).</param>
        public static void Rodrigues(double[] vector, out double[,] matrix)
        {
            double[,] jacobian;
            Rodrigues(vector, out matrix, out jacobian);
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
                throw new ArgumentNullException("matrix");
            if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
                throw new ArgumentException("matrix must be double[3,3]");

            using (var matrixM = new Mat(3, 3, MatType.CV_64FC1, matrix))
            using (var vectorM = new MatOfDouble())
            using (var jacobianM = new MatOfDouble())
            {
                NativeMethods.calib3d_Rodrigues_MatToVec(matrixM.CvPtr, vectorM.CvPtr, jacobianM.CvPtr);
                vector = vectorM.ToArray();
                jacobian = jacobianM.ToRectangularArray();
            }
        }
        /// <summary>
        /// converts rotation matrix to rotation vector using Rodrigues transformation
        /// </summary>
        /// <param name="matrix">Input rotation matrix (3x3).</param>
        /// <param name="vector">Output rotation vector (3x1).</param>
        public static void Rodrigues(double[,] matrix, out double[] vector)
        {
            double[,] jacobian;
            Rodrigues(matrix, out vector, out jacobian);
        }
        #endregion
        #region FindHomography
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
            OutputArray mask = null)
        {
            if (srcPoints == null)
                throw new ArgumentNullException("srcPoints");
            if (dstPoints == null)
                throw new ArgumentNullException("dstPoints");
            srcPoints.ThrowIfDisposed();
            dstPoints.ThrowIfDisposed();

            IntPtr mat = NativeMethods.calib3d_findHomography_InputArray(srcPoints.CvPtr, dstPoints.CvPtr, (int)method,
                ransacReprojThreshold, ToPtr(mask));

            if (mask != null)
                mask.Fix();
            return new Mat(mat);
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
            OutputArray mask = null)
        {
            if (srcPoints == null)
                throw new ArgumentNullException("srcPoints");
            if (dstPoints == null)
                throw new ArgumentNullException("dstPoints");

            Point2d[] srcPointsArray = EnumerableEx.ToArray(srcPoints);
            Point2d[] dstPointsArray = EnumerableEx.ToArray(dstPoints);

            IntPtr mat = NativeMethods.calib3d_findHomography_vector(srcPointsArray, srcPointsArray.Length,
                dstPointsArray, dstPointsArray.Length, (int)method, ransacReprojThreshold, ToPtr(mask));

            if (mask != null)
                mask.Fix();
            return new Mat(mat);
        }
        #endregion
        #region RQDecomp3x3
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
            OutputArray qx = null, OutputArray qy = null, OutputArray qz = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (mtxR == null)
                throw new ArgumentNullException("mtxR");
            if (mtxQ == null)
                throw new ArgumentNullException("mtxQ");
            src.ThrowIfDisposed();
            mtxR.ThrowIfNotReady();
            mtxQ.ThrowIfNotReady();
            Vec3d ret;
            NativeMethods.calib3d_RQDecomp3x3_InputArray(src.CvPtr, mtxR.CvPtr, mtxQ.CvPtr,
                ToPtr(qx), ToPtr(qy), ToPtr(qz), out ret);
            if (qx != null)
                qx.Fix();
            if (qy != null)
                qy.Fix();
            if (qz != null)
                qz.Fix();
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
            double[,] qx, qy, qz;
            return RQDecomp3x3(src, out mtxR, out mtxQ, out qx, out qy, out qz);
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
                throw new ArgumentNullException("src");
            if (src.GetLength(0) != 3 || src.GetLength(1) != 3)
                throw new ArgumentException("src must be double[3,3]");

            using (var srcM = new Mat(3, 3, MatType.CV_64FC1))
            using (var mtxRM = new MatOfDouble())
            using (var mtxQM = new MatOfDouble())
            using (var qxM = new MatOfDouble())
            using (var qyM = new MatOfDouble())
            using (var qzM = new MatOfDouble())
            {
                Vec3d ret;
                NativeMethods.calib3d_RQDecomp3x3_Mat(srcM.CvPtr,
                    mtxRM.CvPtr, mtxQM.CvPtr, qxM.CvPtr, qyM.CvPtr, qzM.CvPtr,
                    out ret);
                mtxR = mtxRM.ToRectangularArray();
                mtxQ = mtxQM.ToRectangularArray();
                qx = qxM.ToRectangularArray();
                qy = qyM.ToRectangularArray();
                qz = qzM.ToRectangularArray();
                return ret;
            }
        }
        #endregion
        #region DecomposeProjectionMatrix
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
        public static void DecomposeProjectionMatrix(InputArray projMatrix,
                                                     OutputArray cameraMatrix,
                                                     OutputArray rotMatrix,
                                                     OutputArray transVect,
                                                     OutputArray rotMatrixX = null,
                                                     OutputArray rotMatrixY = null,
                                                     OutputArray rotMatrixZ = null,
                                                     OutputArray eulerAngles = null)
        {
            if (projMatrix == null)
                throw new ArgumentNullException("projMatrix");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (rotMatrix == null)
                throw new ArgumentNullException("rotMatrix");
            projMatrix.ThrowIfDisposed();
            cameraMatrix.ThrowIfNotReady();
            rotMatrix.ThrowIfNotReady();
            transVect.ThrowIfNotReady();

            NativeMethods.calib3d_decomposeProjectionMatrix_InputArray(
                projMatrix.CvPtr, cameraMatrix.CvPtr, rotMatrix.CvPtr, transVect.CvPtr,
                ToPtr(rotMatrixX), ToPtr(rotMatrixY), ToPtr(rotMatrixZ), ToPtr(eulerAngles));

            cameraMatrix.Fix();
            rotMatrix.Fix();
            transVect.Fix();
            if (rotMatrixX != null)
                rotMatrixX.Fix();
            if (rotMatrixY != null)
                rotMatrixY.Fix();
            if (rotMatrixZ != null)
                rotMatrixZ.Fix();
            if (eulerAngles != null)
                eulerAngles.Fix();
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
        public static void DecomposeProjectionMatrix(double[,] projMatrix,
                                                     out double[,] cameraMatrix,
                                                     out double[,] rotMatrix,
                                                     out double[] transVect,
                                                     out double[,] rotMatrixX,
                                                     out double[,] rotMatrixY,
                                                     out double[,] rotMatrixZ,
                                                     out double[] eulerAngles)
        {
            if (projMatrix == null)
                throw new ArgumentNullException("projMatrix");
            int dim0 = projMatrix.GetLength(0);
            int dim1 = projMatrix.GetLength(1);
            if (!((dim0 == 3 && dim1 == 4) || (dim0 == 4 && dim1 == 3)))
                throw new ArgumentException("projMatrix must be double[3,4] or double[4,3]");

            using (var projMatrixM = new Mat(3, 4, MatType.CV_64FC1, projMatrix))
            using (var cameraMatrixM = new MatOfDouble())
            using (var rotMatrixM = new MatOfDouble())
            using (var transVectM = new MatOfDouble())
            using (var rotMatrixXM = new MatOfDouble())
            using (var rotMatrixYM = new MatOfDouble())
            using (var rotMatrixZM = new MatOfDouble())
            using (var eulerAnglesM = new MatOfDouble())
            {
                NativeMethods.calib3d_decomposeProjectionMatrix_Mat(
                    projMatrixM.CvPtr,
                    cameraMatrixM.CvPtr, rotMatrixM.CvPtr, transVectM.CvPtr,
                    rotMatrixXM.CvPtr, rotMatrixYM.CvPtr, rotMatrixZM.CvPtr,
                    eulerAnglesM.CvPtr);

                cameraMatrix = cameraMatrixM.ToRectangularArray();
                rotMatrix = rotMatrixM.ToRectangularArray();
                transVect = transVectM.ToArray();
                rotMatrixX = rotMatrixXM.ToRectangularArray();
                rotMatrixY = rotMatrixYM.ToRectangularArray();
                rotMatrixZ = rotMatrixZM.ToRectangularArray();
                eulerAngles = eulerAnglesM.ToArray();
            }
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
            double[,] rotMatrixX, rotMatrixY, rotMatrixZ;
            double[] eulerAngles;
            DecomposeProjectionMatrix(projMatrix, out cameraMatrix, out rotMatrix, out transVect,
                                      out rotMatrixX, out rotMatrixY, out rotMatrixZ, out eulerAngles);
        }
        #endregion
        #region MatMulDeriv

        /// <summary>
        /// computes derivatives of the matrix product w.r.t each of the multiplied matrix coefficients
        /// </summary>
        /// <param name="a">First multiplied matrix.</param>
        /// <param name="b">Second multiplied matrix.</param>
        /// <param name="dABdA">First output derivative matrix d(A*B)/dA of size A.rows*B.cols X A.rows*A.cols .</param>
        /// <param name="dABdB">Second output derivative matrix d(A*B)/dB of size A.rows*B.cols X B.rows*B.cols .</param>
        public static void MatMulDeriv(InputArray a, InputArray b,
                                       OutputArray dABdA,
                                       OutputArray dABdB)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            if (dABdA == null)
                throw new ArgumentNullException("dABdA");
            if (dABdB == null)
                throw new ArgumentNullException("dABdB");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            dABdA.ThrowIfNotReady();
            dABdB.ThrowIfNotReady();
            NativeMethods.calib3d_matMulDeriv(a.CvPtr, b.CvPtr, dABdA.CvPtr, dABdB.CvPtr);
            dABdA.Fix();
            dABdB.Fix();
        }
        #endregion
        #region ComposeRT
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
        public static void ComposeRT(InputArray rvec1, InputArray tvec1,
                                     InputArray rvec2, InputArray tvec2,
                                     OutputArray rvec3, OutputArray tvec3,
                                     OutputArray dr3dr1 = null, OutputArray dr3dt1 = null,
                                     OutputArray dr3dr2 = null, OutputArray dr3dt2 = null,
                                     OutputArray dt3dr1 = null, OutputArray dt3dt1 = null,
                                     OutputArray dt3dr2 = null, OutputArray dt3dt2 = null)
        {
            if (rvec1 == null)
                throw new ArgumentNullException("rvec1");
            if (tvec1 == null)
                throw new ArgumentNullException("tvec1");
            if (rvec2 == null)
                throw new ArgumentNullException("rvec2");
            if (tvec2 == null)
                throw new ArgumentNullException("tvec2");
            rvec1.ThrowIfDisposed();
            tvec1.ThrowIfDisposed();
            rvec2.ThrowIfDisposed();
            tvec2.ThrowIfDisposed();
            rvec3.ThrowIfNotReady();
            tvec3.ThrowIfNotReady();
            NativeMethods.calib3d_composeRT_InputArray(rvec1.CvPtr, tvec1.CvPtr, rvec2.CvPtr, tvec2.CvPtr,
                rvec3.CvPtr, tvec3.CvPtr,
                ToPtr(dr3dr1), ToPtr(dr3dt1), ToPtr(dr3dr2), ToPtr(dr3dt2),
                ToPtr(dt3dr1), ToPtr(dt3dt1), ToPtr(dt3dr2), ToPtr(dt3dt2));
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
        public static void ComposeRT(double[] rvec1, double[] tvec1,
                                     double[] rvec2, double[] tvec2,
                                     out double[] rvec3, out double[] tvec3,
                                     out double[,] dr3dr1, out double[,] dr3dt1,
                                     out double[,] dr3dr2, out double[,] dr3dt2,
                                     out double[,] dt3dr1, out double[,] dt3dt1,
                                     out double[,] dt3dr2, out double[,] dt3dt2)
        {
            if (rvec1 == null)
                throw new ArgumentNullException("rvec1");
            if (tvec1 == null)
                throw new ArgumentNullException("tvec1");
            if (rvec2 == null)
                throw new ArgumentNullException("rvec2");
            if (tvec2 == null)
                throw new ArgumentNullException("tvec2");

            using (var rvec1M = new Mat(3, 1, MatType.CV_64FC1, rvec1))
            using (var tvec1M = new Mat(3, 1, MatType.CV_64FC1, tvec1))
            using (var rvec2M = new Mat(3, 1, MatType.CV_64FC1, rvec2))
            using (var tvec2M = new Mat(3, 1, MatType.CV_64FC1, tvec2))
            using (var rvec3M = new MatOfDouble())
            using (var tvec3M = new MatOfDouble())
            using (var dr3dr1M = new MatOfDouble())
            using (var dr3dt1M = new MatOfDouble())
            using (var dr3dr2M = new MatOfDouble())
            using (var dr3dt2M = new MatOfDouble())
            using (var dt3dr1M = new MatOfDouble())
            using (var dt3dt1M = new MatOfDouble())
            using (var dt3dr2M = new MatOfDouble())
            using (var dt3dt2M = new MatOfDouble())
            {
                NativeMethods.calib3d_composeRT_Mat(rvec1M.CvPtr, tvec1M.CvPtr, rvec2M.CvPtr, tvec2M.CvPtr,
                                                rvec3M.CvPtr, tvec3M.CvPtr,
                                                dr3dr1M.CvPtr, dr3dt1M.CvPtr, dr3dr2M.CvPtr, dr3dt2M.CvPtr,
                                                dt3dr1M.CvPtr, dt3dt1M.CvPtr, dt3dr2M.CvPtr, dt3dt2M.CvPtr);
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
            double[,] dr3dr1, dr3dt1,
                      dr3dr2, dr3dt2,
                      dt3dr1, dt3dt1,
                      dt3dr2, dt3dt2;
            ComposeRT(rvec1, tvec2, rvec2, tvec2, out rvec3, out tvec3,
                      out dr3dr1, out dr3dt1, out dr3dr2, out dr3dt2,
                      out dt3dr1, out dt3dt1, out dt3dr2, out dt3dt2);
        }

        #endregion
        #region ProjectPoints
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
        public static void ProjectPoints(InputArray objectPoints,
                                         InputArray rvec, InputArray tvec,
                                         InputArray cameraMatrix, InputArray distCoeffs,
                                         OutputArray imagePoints,
                                         OutputArray jacobian = null,
                                         double aspectRatio = 0)
        {
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (rvec == null)
                throw new ArgumentNullException("rvec");
            if (tvec == null)
                throw new ArgumentNullException("tvec");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (imagePoints == null)
                throw new ArgumentNullException("imagePoints");
            objectPoints.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();
            imagePoints.ThrowIfNotReady();

            NativeMethods.calib3d_projectPoints_InputArray(objectPoints.CvPtr,
                rvec.CvPtr, tvec.CvPtr, cameraMatrix.CvPtr, ToPtr(distCoeffs),
                imagePoints.CvPtr, ToPtr(jacobian), aspectRatio);
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
        public static void ProjectPoints(IEnumerable<Point3d> objectPoints,
                                         double[] rvec, double[] tvec,
                                         double[,] cameraMatrix, double[] distCoeffs,
                                         out Point2d[] imagePoints,
                                         out double[,] jacobian,
                                         double aspectRatio = 0)
        {
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (rvec == null)
                throw new ArgumentNullException("rvec");
            if (rvec.Length != 3)
                throw new ArgumentException("rvec.Length != 3");
            if (tvec == null)
                throw new ArgumentNullException("tvec");
            if (tvec.Length != 3)
                throw new ArgumentException("tvec.Length != 3");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
                throw new ArgumentException("cameraMatrix must be double[3,3]");

            Point3d[] objectPointsArray = EnumerableEx.ToArray(objectPoints);
            using (var objectPointsM = new Mat(objectPointsArray.Length, 1, MatType.CV_64FC3, objectPointsArray))
            using (var rvecM = new Mat(3, 1, MatType.CV_64FC1, rvec))
            using (var tvecM = new Mat(3, 1, MatType.CV_64FC1, tvec))
            using (var cameraMatrixM = new Mat(3, 3, MatType.CV_64FC1, cameraMatrix))
            using (var imagePointsM = new MatOfPoint2d())
            {
                var distCoeffsM = new Mat();
                if (distCoeffs != null)
                    distCoeffsM = new Mat(distCoeffs.Length, 1, MatType.CV_64FC1, distCoeffs);
                var jacobianM = new MatOfDouble();

                NativeMethods.calib3d_projectPoints_Mat(objectPointsM.CvPtr,
                    rvecM.CvPtr, tvecM.CvPtr, cameraMatrixM.CvPtr, distCoeffsM.CvPtr,
                    imagePointsM.CvPtr, jacobianM.CvPtr, aspectRatio);

                imagePoints = imagePointsM.ToArray();
                jacobian = jacobianM.ToRectangularArray();
            }
        }
        #endregion
        #region SolvePnP

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
                throw new ArgumentNullException("objectPoints");
            if (imagePoints == null)
                throw new ArgumentNullException("imagePoints");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (rvec == null)
                throw new ArgumentNullException("rvec");
            if (tvec == null)
                throw new ArgumentNullException("tvec");
            objectPoints.ThrowIfDisposed();
            imagePoints.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();
            IntPtr distCoeffsPtr = ToPtr(distCoeffs);
            NativeMethods.calib3d_solvePnP_InputArray(
                objectPoints.CvPtr, imagePoints.CvPtr, cameraMatrix.CvPtr, distCoeffsPtr,
                rvec.CvPtr, tvec.CvPtr, useExtrinsicGuess ? 1 : 0, (int)flags);
            rvec.Fix();
            tvec.Fix();
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
            IEnumerable<Point3f> objectPoints,
            IEnumerable<Point2f> imagePoints,
            double[,] cameraMatrix,
            IEnumerable<double> distCoeffs,
            out double[] rvec, out double[] tvec,
            bool useExtrinsicGuess = false,
            SolvePnPFlags flags = SolvePnPFlags.Iterative)
        {
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (imagePoints == null)
                throw new ArgumentNullException("imagePoints");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
                throw new ArgumentException("");

            Point3f[] objectPointsArray = EnumerableEx.ToArray(objectPoints);
            Point2f[] imagePointsArray = EnumerableEx.ToArray(imagePoints);
            double[] distCoeffsArray = EnumerableEx.ToArray(distCoeffs);
            int distCoeffsLength = (distCoeffs == null) ? 0 : distCoeffsArray.Length;
            rvec = new double[3];
            tvec = new double[3];

            NativeMethods.calib3d_solvePnP_vector(
                    objectPointsArray, objectPointsArray.Length,
                    imagePointsArray, imagePointsArray.Length,
                    cameraMatrix, distCoeffsArray, distCoeffsLength,
                    rvec, tvec, useExtrinsicGuess ? 1 : 0, (int)flags);
        }
        #endregion
        #region SolvePnPRansac
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
        /// <param name="minInliersCount">Number of inliers. If the algorithm at some stage finds more inliers than minInliersCount , it finishes.</param>
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
            int minInliersCount = 100,
            OutputArray inliers = null,
            SolvePnPFlags flags = SolvePnPFlags.Iterative)
        {
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (imagePoints == null)
                throw new ArgumentNullException("imagePoints");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (rvec == null)
                throw new ArgumentNullException("rvec");
            if (tvec == null)
                throw new ArgumentNullException("tvec");
            objectPoints.ThrowIfDisposed();
            imagePoints.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();
            IntPtr distCoeffsPtr = ToPtr(distCoeffs);

            NativeMethods.calib3d_solvePnPRansac_InputArray(
                objectPoints.CvPtr, imagePoints.CvPtr, cameraMatrix.CvPtr, distCoeffsPtr,
                rvec.CvPtr, tvec.CvPtr, useExtrinsicGuess ? 1 : 0, iterationsCount,
                reprojectionError, minInliersCount, ToPtr(inliers), (int)flags);

            rvec.Fix();
            tvec.Fix();
            if (inliers != null)
                inliers.Fix();
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
            int[] inliers;
            SolvePnPRansac(objectPoints, imagePoints, cameraMatrix, distCoeffs, out rvec, out tvec, out inliers);
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
        /// <param name="minInliersCount">Number of inliers. If the algorithm at some stage finds more inliers than minInliersCount , it finishes.</param>
        /// <param name="inliers">Output vector that contains indices of inliers in objectPoints and imagePoints .</param>
        /// <param name="flags">Method for solving a PnP problem</param>
        public static void SolvePnPRansac(
            IEnumerable<Point3f> objectPoints,
            IEnumerable<Point2f> imagePoints,
            double[,] cameraMatrix,
            IEnumerable<double> distCoeffs,
            out double[] rvec, out double[] tvec,
            out int[] inliers,
            bool useExtrinsicGuess = false,
            int iterationsCount = 100,
            float reprojectionError = 8.0f,
            int minInliersCount = 100,
            SolvePnPFlags flags = SolvePnPFlags.Iterative)
        {
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (imagePoints == null)
                throw new ArgumentNullException("imagePoints");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");

            if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
                throw new ArgumentException("");

            Point3f[] objectPointsArray = EnumerableEx.ToArray(objectPoints);
            Point2f[] imagePointsArray = EnumerableEx.ToArray(imagePoints);
            double[] distCoeffsArray = EnumerableEx.ToArray(distCoeffs);
            int distCoeffsLength = (distCoeffs == null) ? 0 : distCoeffsArray.Length;
            rvec = new double[3];
            tvec = new double[3];

            using (var inliersVec = new VectorOfInt32())
            {
                NativeMethods.calib3d_solvePnPRansac_vector(
                    objectPointsArray, objectPointsArray.Length,
                    imagePointsArray, imagePointsArray.Length,
                    cameraMatrix, distCoeffsArray, distCoeffsLength,
                    rvec, tvec, useExtrinsicGuess ? 1 : 0, iterationsCount,
                    reprojectionError, minInliersCount, inliersVec.CvPtr, (int)flags);
                inliers = inliersVec.ToArray();
            }
        }
        #endregion
        #region InitCameraMatrix2D
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
                throw new ArgumentNullException("objectPoints");
            if (imagePoints == null)
                throw new ArgumentNullException("imagePoints");

            IntPtr[] objectPointsPtrs = EnumerableEx.SelectPtrs(objectPoints);
            IntPtr[] imagePointsPtrs = EnumerableEx.SelectPtrs(imagePoints);

            IntPtr matPtr = NativeMethods.calib3d_initCameraMatrix2D_Mat(objectPointsPtrs, objectPointsPtrs.Length,
                imagePointsPtrs, imagePointsPtrs.Length, imageSize, aspectRatio);
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
            IEnumerable<IEnumerable<Point3d>> objectPoints,
            IEnumerable<IEnumerable<Point2d>> imagePoints,
            Size imageSize,
            double aspectRatio = 1.0)
        {
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (imagePoints == null)
                throw new ArgumentNullException("imagePoints");

            using (var opArray = new ArrayAddress2<Point3d>(objectPoints))
            using (var ipArray = new ArrayAddress2<Point2d>(imagePoints))
            {
                IntPtr matPtr = NativeMethods.calib3d_initCameraMatrix2D_array(
                    opArray, opArray.Dim1Length, opArray.Dim2Lengths,
                    ipArray, ipArray.Dim1Length, ipArray.Dim2Lengths,
                    imageSize, aspectRatio);
                return new Mat(matPtr);
            }
        }
        #endregion
        #region FindChessboardCorners
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
                throw new ArgumentNullException("image");
            if (corners == null)
                throw new ArgumentNullException("corners");
            image.ThrowIfDisposed();
            corners.ThrowIfNotReady();

            int ret = NativeMethods.calib3d_findChessboardCorners_InputArray(
                image.CvPtr, patternSize, corners.CvPtr, (int)flags);
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
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();

            using (var cornersVec = new VectorOfPoint2f())
            {
                int ret = NativeMethods.calib3d_findChessboardCorners_vector(
                    image.CvPtr, patternSize, cornersVec.CvPtr, (int)flags);
                corners = cornersVec.ToArray();
                return ret != 0;
            }
        }
        #endregion
        #region Find4QuadCornerSubpix
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
                throw new ArgumentNullException("img");
            if (corners == null)
                throw new ArgumentNullException("corners");
            img.ThrowIfDisposed();
            corners.ThrowIfNotReady();

            int ret = NativeMethods.calib3d_find4QuadCornerSubpix_InputArray(
                img.CvPtr, corners.CvPtr, regionSize);
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
        public static bool Find4QuadCornerSubpix(InputArray img, [In, Out] Point2f[] corners, Size regionSize)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (corners == null)
                throw new ArgumentNullException("corners");
            img.ThrowIfDisposed();

            using (var cornersVec = new VectorOfPoint2f(corners))
            {
                int ret = NativeMethods.calib3d_find4QuadCornerSubpix_vector(
                    img.CvPtr, cornersVec.CvPtr, regionSize);

                Point2f[] newCorners = cornersVec.ToArray();
                for (int i = 0; i < corners.Length; i++)
                {
                    corners[i] = newCorners[i];
                }

                return ret != 0;
            }
        }
        #endregion
        #region DrawChessboardCorners
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
                throw new ArgumentNullException("image");
            if (corners == null)
                throw new ArgumentNullException("corners");
            image.ThrowIfNotReady();
            corners.ThrowIfDisposed();

            NativeMethods.calib3d_drawChessboardCorners_InputArray(
                image.CvPtr, patternSize, corners.CvPtr, patternWasFound ? 1 : 0);
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
                throw new ArgumentNullException("image");
            if (corners == null)
                throw new ArgumentNullException("corners");
            image.ThrowIfNotReady();

            Point2f[] cornersArray = EnumerableEx.ToArray(corners);
            NativeMethods.calib3d_drawChessboardCorners_array(
                image.CvPtr, patternSize, cornersArray, cornersArray.Length,
                patternWasFound ? 1 : 0);
            image.Fix();
        }
        #endregion
        #region FindCirclesGrid
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
            FeatureDetector blobDetector = null)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (centers == null)
                throw new ArgumentNullException("centers");
            image.ThrowIfDisposed();
            centers.ThrowIfNotReady();

            int ret = NativeMethods.calib3d_findCirclesGrid_InputArray(
                image.CvPtr, patternSize, centers.CvPtr, (int)flags, ToPtr(blobDetector));
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
            FeatureDetector blobDetector = null)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();

            using (var centersVec = new VectorOfPoint2f())
            {
                int ret = NativeMethods.calib3d_findCirclesGrid_vector(
                image.CvPtr, patternSize, centersVec.CvPtr, (int)flags, ToPtr(blobDetector));
                centers = centersVec.ToArray();
                return ret != 0;
            }
        }
        #endregion
        #region CalibrateCamera
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
                throw new ArgumentNullException("objectPoints");
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (distCoeffs == null)
                throw new ArgumentNullException("distCoeffs");
            cameraMatrix.ThrowIfNotReady();
            distCoeffs.ThrowIfNotReady();

            TermCriteria criteria0 = criteria.GetValueOrDefault(
                new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 30, Double.Epsilon));

            IntPtr[] objectPointsPtrs = EnumerableEx.SelectPtrs(objectPoints);
            IntPtr[] imagePointsPtrs = EnumerableEx.SelectPtrs(imagePoints);

            double ret;
            using (var rvecsVec = new VectorOfMat())
            using (var tvecsVec = new VectorOfMat())
            {
                ret = NativeMethods.calib3d_calibrateCamera_InputArray(
                    objectPointsPtrs, objectPointsPtrs.Length,
                    imagePointsPtrs, objectPointsPtrs.Length,
                    imageSize, cameraMatrix.CvPtr, distCoeffs.CvPtr,
                    rvecsVec.CvPtr, tvecsVec.CvPtr, (int)flags, criteria0);
                rvecs = rvecsVec.ToArray();
                tvecs = tvecsVec.ToArray();
            }

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
                throw new ArgumentNullException("objectPoints");
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (distCoeffs == null)
                throw new ArgumentNullException("distCoeffs");

            TermCriteria criteria0 = criteria.GetValueOrDefault(
                new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 30, Double.Epsilon));

            using (var op = new ArrayAddress2<Point3f>(objectPoints))
            using (var ip = new ArrayAddress2<Point2f>(imagePoints))
            using (var rvecsVec = new VectorOfMat())
            using (var tvecsVec = new VectorOfMat())
            {
                double ret = NativeMethods.calib3d_calibrateCamera_vector(
                    op.Pointer, op.Dim1Length, op.Dim2Lengths,
                    ip.Pointer, ip.Dim1Length, ip.Dim2Lengths,
                    imageSize, cameraMatrix, distCoeffs, distCoeffs.Length,
                    rvecsVec.CvPtr, tvecsVec.CvPtr, (int)flags, criteria0);
                Mat[] rvecsM = rvecsVec.ToArray();
                Mat[] tvecsM = tvecsVec.ToArray();
                rvecs = EnumerableEx.SelectToArray(rvecsM, m => m.Get<Vec3d>(0));
                tvecs = EnumerableEx.SelectToArray(tvecsM, m => m.Get<Vec3d>(0));
                return ret;
            }
        }
        #endregion
        #region CalibrationMatrixValues
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
                throw new ArgumentNullException("cameraMatrix");
            cameraMatrix.ThrowIfDisposed();

            NativeMethods.calib3d_calibrationMatrixValues_InputArray(cameraMatrix.CvPtr,
                imageSize, apertureWidth, apertureHeight, out fovx, out fovy, out focalLength,
                out principalPoint, out aspectRatio);
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
                throw new ArgumentNullException("cameraMatrix");
            if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
                throw new ArgumentException("cameraMatrix must be 3x3");

            NativeMethods.calib3d_calibrationMatrixValues_array(cameraMatrix,
                imageSize, apertureWidth, apertureHeight, out fovx, out fovy, out focalLength,
                out principalPoint, out aspectRatio);
        }
        #endregion
        #region StereoCalibrate

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
        public static double StereoCalibrate(IEnumerable<InputArray> objectPoints,
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
                throw new ArgumentNullException("objectPoints");
            if (imagePoints1 == null)
                throw new ArgumentNullException("imagePoints1");
            if (imagePoints2 == null)
                throw new ArgumentNullException("imagePoints2");
            if (cameraMatrix1 == null)
                throw new ArgumentNullException("cameraMatrix1");
            if (distCoeffs1 == null)
                throw new ArgumentNullException("distCoeffs1");
            if (cameraMatrix2 == null)
                throw new ArgumentNullException("cameraMatrix2");
            if (distCoeffs2 == null)
                throw new ArgumentNullException("distCoeffs2");
            cameraMatrix1.ThrowIfDisposed();
            distCoeffs1.ThrowIfDisposed();
            cameraMatrix2.ThrowIfDisposed();
            distCoeffs2.ThrowIfDisposed();
            cameraMatrix1.ThrowIfNotReady();
            cameraMatrix2.ThrowIfNotReady();
            distCoeffs1.ThrowIfNotReady();
            distCoeffs2.ThrowIfNotReady();

            IntPtr[] opPtrs = EnumerableEx.SelectPtrs(objectPoints);
            IntPtr[] ip1Ptrs = EnumerableEx.SelectPtrs(imagePoints1);
            IntPtr[] ip2Ptrs = EnumerableEx.SelectPtrs(imagePoints2);

            TermCriteria criteria0 = criteria.GetValueOrDefault(
                new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 30, 1e-6));

            double result =
                NativeMethods.calib3d_stereoCalibrate_InputArray(
                    opPtrs, opPtrs.Length,
                    ip1Ptrs, ip1Ptrs.Length, ip2Ptrs, ip2Ptrs.Length,
                    cameraMatrix1.CvPtr, distCoeffs1.CvPtr,
                    cameraMatrix2.CvPtr, distCoeffs2.CvPtr,
                    imageSize, ToPtr(R), ToPtr(T), ToPtr(E), ToPtr(F),
                    (int)flags, criteria0);

            cameraMatrix1.Fix();
            distCoeffs1.Fix();
            cameraMatrix2.Fix();
            distCoeffs2.Fix();
            if (R != null)
                R.Fix();
            if (T != null)
                T.Fix();
            if (E != null)
                E.Fix();
            if (F != null)
                F.Fix();

            return result;
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
        public static double StereoCalibrate(IEnumerable<IEnumerable<Point3d>> objectPoints,
                                             IEnumerable<IEnumerable<Point2d>> imagePoints1,
                                             IEnumerable<IEnumerable<Point2d>> imagePoints2,
                                             double[,] cameraMatrix1, double[] distCoeffs1,
                                             double[,] cameraMatrix2, double[] distCoeffs2,
                                             Size imageSize, OutputArray R,
                                             OutputArray T, OutputArray E, OutputArray F,
                                             CalibrationFlags flags = CalibrationFlags.FixIntrinsic,
                                             TermCriteria? criteria = null)
        {
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (imagePoints1 == null)
                throw new ArgumentNullException("imagePoints1");
            if (imagePoints2 == null)
                throw new ArgumentNullException("imagePoints2");
            if (cameraMatrix1 == null)
                throw new ArgumentNullException("cameraMatrix1");
            if (distCoeffs1 == null)
                throw new ArgumentNullException("distCoeffs1");
            if (cameraMatrix2 == null)
                throw new ArgumentNullException("cameraMatrix2");
            if (distCoeffs2 == null)
                throw new ArgumentNullException("distCoeffs2");

            TermCriteria criteria0 = criteria.GetValueOrDefault(
                new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 30, 1e-6));

            using (var op = new ArrayAddress2<Point3d>(objectPoints))
            using (var ip1 = new ArrayAddress2<Point2d>(imagePoints1))
            using (var ip2 = new ArrayAddress2<Point2d>(imagePoints2))
            {
                return NativeMethods.calib3d_stereoCalibrate_array(
                        op.Pointer, op.Dim1Length, op.Dim2Lengths,
                        ip1.Pointer, ip1.Dim1Length, ip1.Dim2Lengths,
                        ip2.Pointer, ip2.Dim1Length, ip2.Dim2Lengths,
                        cameraMatrix1, distCoeffs1, distCoeffs1.Length,
                        cameraMatrix2, distCoeffs2, distCoeffs2.Length,
                        imageSize, ToPtr(R), ToPtr(T), ToPtr(E), ToPtr(F),
                        (int)flags, criteria0);
            }
        }

        #endregion
        #region StereoRectify

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
            Size newImageSize0 = newImageSize.GetValueOrDefault(new Size(0, 0));
            Rect validPixROI1, validPixROI2;
            StereoRectify(cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2,
                imageSize, R, T, R1, R2, P1, P2, Q, flags, alpha, newImageSize0,
                out validPixROI1, out validPixROI2);
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
                throw new ArgumentNullException("cameraMatrix1");
            if (distCoeffs1 == null)
                throw new ArgumentNullException("distCoeffs1");
            if (cameraMatrix2 == null)
                throw new ArgumentNullException("cameraMatrix2");
            if (distCoeffs2 == null)
                throw new ArgumentNullException("distCoeffs2");
            if (R == null)
                throw new ArgumentNullException("R");
            if (T == null)
                throw new ArgumentNullException("T");
            if (R1 == null)
                throw new ArgumentNullException("R1");
            if (R2 == null)
                throw new ArgumentNullException("R2");
            if (P1 == null)
                throw new ArgumentNullException("P1");
            if (P2 == null)
                throw new ArgumentNullException("P2");
            if (Q == null)
                throw new ArgumentNullException("Q");
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

            NativeMethods.calib3d_stereoRectify_InputArray(
                    cameraMatrix1.CvPtr, distCoeffs1.CvPtr,
                    cameraMatrix2.CvPtr, distCoeffs2.CvPtr,
                    imageSize, R.CvPtr, T.CvPtr,
                    R1.CvPtr, R2.CvPtr, P1.CvPtr, P2.CvPtr, Q.CvPtr,
                    (int)flags, alpha, newImageSize, out validPixROI1, out validPixROI2);

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
            Size newImageSize0 = newImageSize.GetValueOrDefault(new Size(0, 0));
            Rect validPixROI1, validPixROI2;
            StereoRectify(
                cameraMatrix1, distCoeffs1,
                cameraMatrix2, distCoeffs2,
                imageSize, R, T,
                out R1, out R2, out P1, out P2, out Q,
                flags, alpha, newImageSize0, out validPixROI1, out validPixROI2);
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
                throw new ArgumentNullException("cameraMatrix1");
            if (distCoeffs1 == null)
                throw new ArgumentNullException("distCoeffs1");
            if (cameraMatrix2 == null)
                throw new ArgumentNullException("cameraMatrix2");
            if (distCoeffs2 == null)
                throw new ArgumentNullException("distCoeffs2");
            if (R == null)
                throw new ArgumentNullException("R");
            if (T == null)
                throw new ArgumentNullException("T");

            R1 = new double[3, 3];
            R2 = new double[3, 3];
            P1 = new double[3, 4];
            P2 = new double[3, 4];
            Q = new double[4, 4];
            NativeMethods.calib3d_stereoRectify_array(
                    cameraMatrix1, distCoeffs1, distCoeffs1.Length,
                    cameraMatrix2, distCoeffs2, distCoeffs2.Length,
                    imageSize, R, T,
                    R1, R2, P1, P2, Q,
                    (int)flags, alpha, newImageSize, out validPixROI1, out validPixROI2);
        }


        #endregion
        #region StereoRectifyUncalibrated

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
                throw new ArgumentNullException("points1");
            if (points2 == null)
                throw new ArgumentNullException("points2");
            if (F == null)
                throw new ArgumentNullException("F");
            if (H1 == null)
                throw new ArgumentNullException("H1");
            if (H2 == null)
                throw new ArgumentNullException("H2");
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();
            F.ThrowIfDisposed();
            H1.ThrowIfNotReady();
            H2.ThrowIfNotReady();

            int ret = NativeMethods.calib3d_stereoRectifyUncalibrated_InputArray(
                points1.CvPtr, points2.CvPtr, F.CvPtr, imgSize, H1.CvPtr, H2.CvPtr, threshold);
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
        public static bool StereoRectifyUncalibrated(IEnumerable<Point2d> points1,
                                                     IEnumerable<Point2d> points2,
                                                     double[,] F, Size imgSize,
                                                     out double[,] H1, out double[,] H2,
                                                     double threshold = 5
            )
        {
            if (points1 == null)
                throw new ArgumentNullException("points1");
            if (points2 == null)
                throw new ArgumentNullException("points2");
            if (F == null)
                throw new ArgumentNullException("F");
            if (F.GetLength(0) != 3 || F.GetLength(1) != 3)
                throw new ArgumentException("F != double[3,3]");

            Point2d[] points1Array = EnumerableEx.ToArray(points1);
            Point2d[] points2Array = EnumerableEx.ToArray(points2);

            H1 = new double[3, 3];
            H2 = new double[3, 3];

            int ret = NativeMethods.calib3d_stereoRectifyUncalibrated_array(
                points1Array, points1Array.Length,
                points2Array, points2Array.Length,
                F, imgSize, H1, H2, threshold);
            return ret != 0;
        }

        #endregion
        #region Rectify3Collinear
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
        public static float Rectify3Collinear(InputArray cameraMatrix1, InputArray distCoeffs1,
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
                throw new ArgumentNullException("cameraMatrix1");
            if (distCoeffs1 == null)
                throw new ArgumentNullException("distCoeffs1");
            if (cameraMatrix2 == null)
                throw new ArgumentNullException("cameraMatrix2");
            if (distCoeffs2 == null)
                throw new ArgumentNullException("distCoeffs2");
            if (cameraMatrix3 == null)
                throw new ArgumentNullException("cameraMatrix3");
            if (distCoeffs3 == null)
                throw new ArgumentNullException("distCoeffs3");
            if (imgpt1 == null)
                throw new ArgumentNullException("imgpt1");
            if (imgpt3 == null)
                throw new ArgumentNullException("imgpt3");
            if (R12 == null)
                throw new ArgumentNullException("R12");
            if (T12 == null)
                throw new ArgumentNullException("T12");
            if (R13 == null)
                throw new ArgumentNullException("R13");
            if (T13 == null)
                throw new ArgumentNullException("T13");
            if (R1 == null)
                throw new ArgumentNullException("R1");
            if (R2 == null)
                throw new ArgumentNullException("R2");
            if (R3 == null)
                throw new ArgumentNullException("R3");
            if (P1 == null)
                throw new ArgumentNullException("P1");
            if (P2 == null)
                throw new ArgumentNullException("P2");
            if (P3 == null)
                throw new ArgumentNullException("P3");
            if (Q == null)
                throw new ArgumentNullException("Q");
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

            IntPtr[] imgpt1Ptrs = EnumerableEx.SelectPtrs(imgpt1);
            IntPtr[] imgpt3Ptrs = EnumerableEx.SelectPtrs(imgpt3);
            float ret = NativeMethods.calib3d_rectify3Collinear_InputArray(
                cameraMatrix1.CvPtr, distCoeffs1.CvPtr,
                cameraMatrix2.CvPtr, distCoeffs2.CvPtr,
                cameraMatrix3.CvPtr, distCoeffs3.CvPtr,
                imgpt1Ptrs, imgpt1Ptrs.Length, imgpt3Ptrs, imgpt3Ptrs.Length,
                imageSize, R12.CvPtr, T12.CvPtr, R13.CvPtr, T13.CvPtr,
                R1.CvPtr, R2.CvPtr, R3.CvPtr, P1.CvPtr, P2.CvPtr, P3.CvPtr,
                Q.CvPtr, alpha, newImgSize, out roi1, out roi2, (int)flags);
            R1.Fix();
            R2.Fix();
            R3.Fix();
            P1.Fix();
            P2.Fix();
            P3.Fix();
            Q.Fix();
            return ret;
        }
        #endregion
        #region GetOptimalNewCameraMatrix

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
        public static Mat GetOptimalNewCameraMatrix(InputArray cameraMatrix, InputArray distCoeffs,
                                                    Size imageSize, double alpha, Size newImgSize,
                                                    out Rect validPixROI, bool centerPrincipalPoint = false)
        {
            if (cameraMatrix == null)
                throw new ArgumentNullException();
            cameraMatrix.ThrowIfDisposed();

            IntPtr mat = NativeMethods.calib3d_getOptimalNewCameraMatrix_InputArray(
                cameraMatrix.CvPtr, ToPtr(distCoeffs), imageSize, alpha, newImgSize,
                out validPixROI, centerPrincipalPoint ? 1 : 0);
            return new Mat(mat);
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
        public static double[,] GetOptimalNewCameraMatrix(double[,] cameraMatrix, double[] distCoeffs,
                                                    Size imageSize, double alpha, Size newImgSize,
                                                    out Rect validPixROI, bool centerPrincipalPoint = false)
        {
            if (cameraMatrix == null)
                throw new ArgumentNullException();

            var newCameraMatrix = new double[3, 3];
            NativeMethods.calib3d_getOptimalNewCameraMatrix_array(
                cameraMatrix, distCoeffs, distCoeffs.Length,
                imageSize, alpha, newImgSize,
                out validPixROI, centerPrincipalPoint ? 1 : 0,
                newCameraMatrix);
            return newCameraMatrix;
        }
        #endregion
        #region ConvertPointsHomogeneous
        /// <summary>
        /// converts point coordinates from normal pixel coordinates to homogeneous coordinates ((x,y)->(x,y,1))
        /// </summary>
        /// <param name="src">Input vector of N-dimensional points.</param>
        /// <param name="dst">Output vector of N+1-dimensional points.</param>
        public static void ConvertPointsToHomogeneous(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.calib3d_convertPointsToHomogeneous_InputArray(src.CvPtr, dst.CvPtr);
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
                throw new ArgumentNullException("src");

            Vec2f[] srcA = EnumerableEx.ToArray(src);
            Vec3f[] dstA = new Vec3f[srcA.Length];
            NativeMethods.calib3d_convertPointsToHomogeneous_array1(srcA, dstA, srcA.Length);
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
                throw new ArgumentNullException("src");

            Vec3f[] srcA = EnumerableEx.ToArray(src);
            Vec4f[] dstA = new Vec4f[srcA.Length];
            NativeMethods.calib3d_convertPointsToHomogeneous_array2(srcA, dstA, srcA.Length);
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
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.calib3d_convertPointsFromHomogeneous_InputArray(src.CvPtr, dst.CvPtr);
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
                throw new ArgumentNullException("src");

            Vec3f[] srcA = EnumerableEx.ToArray(src);
            Vec2f[] dstA = new Vec2f[srcA.Length];
            NativeMethods.calib3d_convertPointsFromHomogeneous_array1(srcA, dstA, srcA.Length);
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
                throw new ArgumentNullException("src");

            Vec4f[] srcA = EnumerableEx.ToArray(src);
            Vec3f[] dstA = new Vec3f[srcA.Length];
            NativeMethods.calib3d_convertPointsFromHomogeneous_array2(srcA, dstA, srcA.Length);
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
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.calib3d_convertPointsHomogeneous(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }
        #endregion
        #region FindFundamentalMat
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
            OutputArray mask = null)
        {
            if (points1 == null)
                throw new ArgumentNullException("points1");
            if (points2 == null)
                throw new ArgumentNullException("points2");
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();

            IntPtr mat = NativeMethods.calib3d_findFundamentalMat_InputArray(
                points1.CvPtr, points2.CvPtr, (int)method,
                param1, param2, ToPtr(mask));
            if (mask != null)
                mask.Fix();
            return new Mat(mat);
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
            IEnumerable<Point2d> points1, IEnumerable<Point2d> points2,
            FundamentalMatMethod method = FundamentalMatMethod.Ransac,
            double param1 = 3.0, double param2 = 0.99,
            OutputArray mask = null)
        {
            if (points1 == null)
                throw new ArgumentNullException("points1");
            if (points2 == null)
                throw new ArgumentNullException("points2");

            Point2d[] points1Array = EnumerableEx.ToArray(points1);
            Point2d[] points2Array = EnumerableEx.ToArray(points2);

            IntPtr mat = NativeMethods.calib3d_findFundamentalMat_array(
                points1Array, points1Array.Length,
                points2Array, points2Array.Length, (int)method,
                param1, param2, ToPtr(mask));
            if (mask != null)
                mask.Fix();
            return new Mat(mat);
        }
        #endregion
        #region ComputeCorrespondEpilines
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
                throw new ArgumentNullException("points");
            if (F == null)
                throw new ArgumentNullException("F");
            if (lines == null)
                throw new ArgumentNullException("lines");
            points.ThrowIfDisposed();
            F.ThrowIfDisposed();
            lines.ThrowIfNotReady();

            NativeMethods.calib3d_computeCorrespondEpilines_InputArray(
                points.CvPtr, whichImage, F.CvPtr, lines.CvPtr);
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
                throw new ArgumentNullException("points");
            if (F == null)
                throw new ArgumentNullException("F");
            if (F.GetLength(0) != 3 && F.GetLength(1) != 3)
                throw new ArgumentException("F != double[3,3]");

            Point2d[] pointsArray = EnumerableEx.ToArray(points);
            Point3f[] lines = new Point3f[pointsArray.Length];

            NativeMethods.calib3d_computeCorrespondEpilines_array2d(
                pointsArray, pointsArray.Length,
                whichImage, F, lines);

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
                throw new ArgumentNullException("points");
            if (F == null)
                throw new ArgumentNullException("F");
            if (F.GetLength(0) != 3 && F.GetLength(1) != 3)
                throw new ArgumentException("F != double[3,3]");

            Point3d[] pointsArray = EnumerableEx.ToArray(points);
            Point3f[] lines = new Point3f[pointsArray.Length];

            NativeMethods.calib3d_computeCorrespondEpilines_array3d(
                pointsArray, pointsArray.Length,
                whichImage, F, lines);

            return lines;
        }
        #endregion
        #region TriangulatePoints
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
                throw new ArgumentNullException("projMatr1");
            if (projMatr2 == null)
                throw new ArgumentNullException("projMatr2");
            if (projPoints1 == null)
                throw new ArgumentNullException("projPoints1");
            if (projPoints2 == null)
                throw new ArgumentNullException("projPoints2");
            if (points4D == null)
                throw new ArgumentNullException("points4D");
            projMatr1.ThrowIfDisposed();
            projMatr2.ThrowIfDisposed();
            projPoints1.ThrowIfDisposed();
            projPoints2.ThrowIfDisposed();
            points4D.ThrowIfNotReady();

            NativeMethods.calib3d_triangulatePoints_InputArray(
                projMatr1.CvPtr, projMatr2.CvPtr,
                projPoints1.CvPtr, projPoints2.CvPtr, points4D.CvPtr);

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
            double[,] projMatr1, double[,] projMatr2,
            IEnumerable<Point2d> projPoints1, IEnumerable<Point2d> projPoints2)
        {
            if (projMatr1 == null)
                throw new ArgumentNullException("projMatr1");
            if (projMatr2 == null)
                throw new ArgumentNullException("projMatr2");
            if (projPoints1 == null)
                throw new ArgumentNullException("projPoints1");
            if (projPoints2 == null)
                throw new ArgumentNullException("projPoints2");
            if (projMatr1.GetLength(0) != 3 && projMatr1.GetLength(1) != 4)
                throw new ArgumentException("projMatr1 != double[3,4]");
            if (projMatr2.GetLength(0) != 3 && projMatr2.GetLength(1) != 4)
                throw new ArgumentException("projMatr2 != double[3,4]");

            Point2d[] projPoints1Array = EnumerableEx.ToArray(projPoints1);
            Point2d[] projPoints2Array = EnumerableEx.ToArray(projPoints2);
            var points4D = new Vec4d[projPoints1Array.Length];

            NativeMethods.calib3d_triangulatePoints_array(
                projMatr1, projMatr2,
                projPoints1Array, projPoints1Array.Length,
                projPoints2Array, projPoints2Array.Length,
                points4D);

            return points4D;
        }
        #endregion
        #region CorrectMatches
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
                throw new ArgumentNullException("F");
            if (points1 == null)
                throw new ArgumentNullException("points1");
            if (points2 == null)
                throw new ArgumentNullException("points2");
            if (newPoints1 == null)
                throw new ArgumentNullException("newPoints1");
            if (newPoints2 == null)
                throw new ArgumentNullException("newPoints2");
            F.ThrowIfDisposed();
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();
            newPoints1.ThrowIfNotReady();
            newPoints2.ThrowIfNotReady();

            NativeMethods.calib3d_correctMatches_InputArray(
                F.CvPtr, points1.CvPtr, points2.CvPtr,
                newPoints1.CvPtr, newPoints2.CvPtr);

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
            double[,] F, IEnumerable<Point2d> points1, IEnumerable<Point2d> points2,
            out Point2d[] newPoints1, out Point2d[] newPoints2)
        {
            if (F == null)
                throw new ArgumentNullException("F");
            if (points1 == null)
                throw new ArgumentNullException("points1");
            if (points2 == null)
                throw new ArgumentNullException("points2");

            Point2d[] points1Array = EnumerableEx.ToArray(points1);
            Point2d[] points2Array = EnumerableEx.ToArray(points2);
            newPoints1 = new Point2d[points1Array.Length];
            newPoints2 = new Point2d[points2Array.Length];

            NativeMethods.calib3d_correctMatches_array(
                F, points1Array, points1Array.Length,
                points2Array, points2Array.Length,
                newPoints1, newPoints2);
        }
        #endregion

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
            InputOutputArray buf = null)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfNotReady();

            NativeMethods.calib3d_filterSpeckles(img.CvPtr, newVal, maxSpeckleSize, maxDiff, ToPtr(buf));
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
            return NativeMethods.calib3d_getValidDisparityROI(
                roi1, roi2, minDisparity, numberOfDisparities, SADWindowSize);
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
                throw new ArgumentNullException("disparity");
            if (cost == null)
                throw new ArgumentNullException("cost");
            disparity.ThrowIfNotReady();
            cost.ThrowIfDisposed();

            NativeMethods.calib3d_validateDisparity(
                disparity.CvPtr, cost.CvPtr, minDisparity, numberOfDisparities, disp12MaxDisp);
            disparity.Fix();
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
                throw new ArgumentNullException("disparity");
            if (_3dImage == null)
                throw new ArgumentNullException("_3dImage");
            if (Q == null)
                throw new ArgumentNullException("Q");
            disparity.ThrowIfDisposed();
            _3dImage.ThrowIfNotReady();
            Q.ThrowIfDisposed();

            NativeMethods.calib3d_reprojectImageTo3D(
                disparity.CvPtr, _3dImage.CvPtr, Q.CvPtr, handleMissingValues ? 1 : 0, ddepth);

            _3dImage.Fix();
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
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (outVal == null)
                throw new ArgumentNullException("outVal");
            if (inliers == null)
                throw new ArgumentNullException("inliers");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            outVal.ThrowIfNotReady();
            inliers.ThrowIfNotReady();

            int ret = NativeMethods.calib3d_estimateAffine3D(
                src.CvPtr, dst.CvPtr, outVal.CvPtr, inliers.CvPtr, ransacThreshold, confidence);

            outVal.Fix();
            inliers.Fix();
            return ret;
        }
    }
}
