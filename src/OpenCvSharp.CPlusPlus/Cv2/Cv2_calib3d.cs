using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Cv2
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

            using (Mat vectorM = new Mat(3, 1, MatType.CV_64FC1, vector))
            using (MatOfDouble matrixM = new MatOfDouble())
            using (MatOfDouble jacobianM = new MatOfDouble())
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

            using (Mat matrixM = new Mat(3, 3, MatType.CV_64FC1, matrix))
            using (MatOfDouble vectorM = new MatOfDouble())
            using (MatOfDouble jacobianM = new MatOfDouble())
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
            HomographyMethod method = HomographyMethod.Zero, double ransacReprojThreshold = 3,
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
            HomographyMethod method = HomographyMethod.Zero, double ransacReprojThreshold = 3,
            OutputArray mask = null)
        {
            if (srcPoints == null)
                throw new ArgumentNullException("srcPoints");
            if (dstPoints == null)
                throw new ArgumentNullException("dstPoints");

            Point2d[] srcPointsArray = EnumerableEx.ToArray(srcPoints);
            Point2d[] dstPointsArray = EnumerableEx.ToArray(dstPoints);

            IntPtr mat = NativeMethods.calib3d_findHomography_vector(srcPointsArray, srcPointsArray.Length,
                srcPointsArray, dstPointsArray.Length, (int)method, ransacReprojThreshold, ToPtr(mask));

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

            using (Mat srcM = new Mat(3, 3, MatType.CV_64FC1))
            using (MatOfDouble mtxRM = new MatOfDouble())
            using (MatOfDouble mtxQM = new MatOfDouble())
            using (MatOfDouble qxM = new MatOfDouble())
            using (MatOfDouble qyM = new MatOfDouble())
            using (MatOfDouble qzM = new MatOfDouble())
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

            using (Mat projMatrixM = new Mat(3, 4, MatType.CV_64FC1, projMatrix))
            using (MatOfDouble cameraMatrixM = new MatOfDouble())
            using (MatOfDouble rotMatrixM = new MatOfDouble())
            using (MatOfDouble transVectM = new MatOfDouble())
            using (MatOfDouble rotMatrixXM = new MatOfDouble())
            using (MatOfDouble rotMatrixYM = new MatOfDouble())
            using (MatOfDouble rotMatrixZM = new MatOfDouble())
            using (MatOfDouble eulerAnglesM = new MatOfDouble())
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

            using (Mat rvec1M = new Mat(3, 1, MatType.CV_64FC1, rvec1))
            using (Mat tvec1M = new Mat(3, 1, MatType.CV_64FC1, tvec1))
            using (Mat rvec2M = new Mat(3, 1, MatType.CV_64FC1, rvec2))
            using (Mat tvec2M = new Mat(3, 1, MatType.CV_64FC1, tvec2))
            using (MatOfDouble rvec3M = new MatOfDouble())
            using (MatOfDouble tvec3M = new MatOfDouble())
            using (MatOfDouble dr3dr1M = new MatOfDouble())
            using (MatOfDouble dr3dt1M = new MatOfDouble())
            using (MatOfDouble dr3dr2M = new MatOfDouble())
            using (MatOfDouble dr3dt2M = new MatOfDouble())
            using (MatOfDouble dt3dr1M = new MatOfDouble())
            using (MatOfDouble dt3dt1M = new MatOfDouble())
            using (MatOfDouble dt3dr2M = new MatOfDouble())
            using (MatOfDouble dt3dt2M = new MatOfDouble())
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
            using (Mat objectPointsM = new Mat(objectPointsArray.Length, 1, MatType.CV_64FC3, objectPointsArray))
            using (Mat rvecM = new Mat(3, 1, MatType.CV_64FC1, rvec))
            using (Mat tvecM = new Mat(3, 1, MatType.CV_64FC1, tvec))
            using (Mat cameraMatrixM = new Mat(3, 3, MatType.CV_64FC1, cameraMatrix))
            using (MatOfPoint2d imagePointsM = new MatOfPoint2d())
            {
                Mat distCoeffsM = new Mat();
                if (distCoeffs != null)
                    distCoeffsM = new Mat(distCoeffs.Length, 1, MatType.CV_64FC1, distCoeffs);
                MatOfDouble jacobianM = new MatOfDouble();

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
            SolvePnPFlag flags = SolvePnPFlag.Iterative)
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
            SolvePnPFlag flags = SolvePnPFlag.Iterative)
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
            SolvePnPFlag flags = SolvePnPFlag.Iterative)
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
            if(inliers != null)
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
            SolvePnPFlag flags = SolvePnPFlag.Iterative)
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

            using (VectorOfInt32 inliersVec = new VectorOfInt32())
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
            if (EnumerableEx.AnyNull(objectPoints))
                throw new ArgumentException("One of objectPoints is null");
            if (EnumerableEx.AnyNull(imagePoints))
                throw new ArgumentException("One of imagePoints is null");

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
            if (EnumerableEx.AnyNull(objectPoints))
                throw new ArgumentException("One of objectPoints is null");
            if (EnumerableEx.AnyNull(imagePoints))
                throw new ArgumentException("One of imagePoints is null");

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
            ChessboardFlag flags = ChessboardFlag.AdaptiveThresh | ChessboardFlag.NormalizeImage)
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
            ChessboardFlag flags = ChessboardFlag.AdaptiveThresh | ChessboardFlag.NormalizeImage)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();

            using (VectorOfPoint2f cornersVec = new VectorOfPoint2f())
            {
                int ret = NativeMethods.calib3d_findChessboardCorners_InputArray(
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

            using (VectorOfPoint2f cornersVec = new VectorOfPoint2f(corners))
            {
                int ret = NativeMethods.calib3d_find4QuadCornerSubpix_InputArray(
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
            FindCirclesGridFlag flags = FindCirclesGridFlag.SymmetricGrid,
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
            FindCirclesGridFlag flags = FindCirclesGridFlag.SymmetricGrid,
            FeatureDetector blobDetector = null)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();

            using (VectorOfPoint2f centersVec = new VectorOfPoint2f())
            {
                int ret = NativeMethods.calib3d_findCirclesGrid_InputArray(
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
            CalibrationFlag flags = CalibrationFlag.Zero, 
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
                new TermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 30, Double.Epsilon));

            IntPtr[] objectPointsPtrs = EnumerableEx.SelectPtrs(objectPoints);
            IntPtr[] imagePointsPtrs = EnumerableEx.SelectPtrs(imagePoints);

            double ret;
            using (VectorOfMat rvecsVec = new VectorOfMat())
            using (VectorOfMat tvecsVec = new VectorOfMat())
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
            IEnumerable<IEnumerable<Point3d>> objectPoints,
            IEnumerable<IEnumerable<Point2d>> imagePoints,
            Size imageSize,
            double[,] cameraMatrix,
            double[] distCoeffs,
            out Vec3d[] rvecs,
            out Vec3d[] tvecs,
            CalibrationFlag flags = CalibrationFlag.Zero,
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
                new TermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 30, Double.Epsilon));

            using (ArrayAddress2<Point3d> op = new ArrayAddress2<Point3d>(objectPoints))
            using (ArrayAddress2<Point2d> ip = new ArrayAddress2<Point2d>(imagePoints))
            using (VectorOfMat rvecsVec = new VectorOfMat())
            using (VectorOfMat tvecsVec = new VectorOfMat())
            {
                double ret = NativeMethods.calib3d_calibrateCamera_vector(
                    op.Pointer, op.Dim1Length, op.Dim2Lengths,
                    ip.Pointer, ip.Dim1Length, ip.Dim2Lengths,
                    imageSize, cameraMatrix, distCoeffs, distCoeffs.Length,
                    rvecsVec.CvPtr, tvecsVec.CvPtr, (int)flags, criteria0);
                Mat[] rvecsM = rvecsVec.ToArray();
                Mat[] tvecsM = tvecsVec.ToArray();
                rvecs = EnumerableEx.SelectToArray(rvecsM, delegate(Mat m)
                {
                    return m.Get<Vec3d>(0);
                });
                tvecs = EnumerableEx.SelectToArray(tvecsM, delegate(Mat m)
                {
                    return m.Get<Vec3d>(0);
                });
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
// ReSharper disable InconsistentNaming

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
                                             TermCriteria? criteria = null,
                                             CalibrationFlag flags = CalibrationFlag.FixIntrinsic)
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

            IntPtr[] opPtrs = EnumerableEx.SelectPtrs(objectPoints);
            IntPtr[] ip1Ptrs = EnumerableEx.SelectPtrs(imagePoints1);
            IntPtr[] ip2Ptrs = EnumerableEx.SelectPtrs(imagePoints2);

            TermCriteria criteria0 = criteria.GetValueOrDefault(
                new TermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 30, 1e-6));

            double result =
                NativeMethods.calib3d_stereoCalibrate_InputArray(
                    opPtrs, opPtrs.Length,
                    ip1Ptrs, ip1Ptrs.Length, ip2Ptrs, ip2Ptrs.Length,
                    cameraMatrix1.CvPtr, distCoeffs1.CvPtr,
                    cameraMatrix2.CvPtr, distCoeffs2.CvPtr,
                    imageSize, ToPtr(R), ToPtr(T), ToPtr(E), ToPtr(F),
                    criteria0, (int)flags
                    );

            cameraMatrix1.Fix();
            distCoeffs1.Fix();
            cameraMatrix2.Fix();
            distCoeffs2.Fix();

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
                                             TermCriteria? criteria = null,
                                             CalibrationFlag flags = CalibrationFlag.FixIntrinsic)
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
                new TermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 30, 1e-6));

            using (ArrayAddress2<Point3d> op = new ArrayAddress2<Point3d>(objectPoints))
            using (ArrayAddress2<Point2d> ip1 = new ArrayAddress2<Point2d>(imagePoints1))
            using (ArrayAddress2<Point2d> ip2 = new ArrayAddress2<Point2d>(imagePoints2))
            {
                return NativeMethods.calib3d_stereoCalibrate_array(
                        op.Pointer, op.Dim1Length, op.Dim2Lengths,
                        ip1.Pointer, ip1.Dim1Length, ip1.Dim2Lengths,
                        ip2.Pointer, ip2.Dim1Length, ip2.Dim2Lengths,
                        cameraMatrix1, distCoeffs1, distCoeffs1.Length,
                        cameraMatrix2, distCoeffs2, distCoeffs2.Length,
                        imageSize, ToPtr(R), ToPtr(T), ToPtr(E), ToPtr(F),
                        criteria0, (int)flags);
            }
        }

// ReSharper restore InconsistentNaming
        #endregion
    }
}
