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
            CppInvoke.calib3d_Rodrigues(src.CvPtr, dst.CvPtr, ToPtr(jacobian));
            dst.Fix();
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
            matrix = new double[3, 3];
            jacobian = new double[3, 9];
            CppInvoke.calib3d_Rodrigues_VectorToMatrix(vector, matrix, jacobian);
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
            vector = new double[3];
            jacobian = new double[3, 9];
            CppInvoke.calib3d_Rodrigues_MatrixToVector(matrix, vector, jacobian);
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

            IntPtr mat = CppInvoke.calib3d_findHomography_InputArray(srcPoints.CvPtr, dstPoints.CvPtr, (int)method,
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
        public static Mat FindHomography(IEnumerable<Point2f> srcPoints, IEnumerable<Point2f> dstPoints,
            HomographyMethod method = HomographyMethod.Zero, double ransacReprojThreshold = 3,
            OutputArray mask = null)
        {
            if (srcPoints == null)
                throw new ArgumentNullException("srcPoints");
            if (dstPoints == null)
                throw new ArgumentNullException("dstPoints");

            Point2f[] srcPointsArray = EnumerableEx.ToArray(srcPoints);
            Point2f[] dstPointsArray = EnumerableEx.ToArray(dstPoints);

            IntPtr mat = CppInvoke.calib3d_findHomography_vector(srcPointsArray, srcPointsArray.Length,
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
            CppInvoke.calib3d_RQDecomp3x3_InputArray(src.CvPtr, mtxR.CvPtr, mtxQ.CvPtr, 
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

            mtxR = new double[3, 3];
            mtxQ = new double[3, 3];
            qx = new double[3, 3];
            qy = new double[3, 3];
            qz = new double[3, 3];
            Vec3d ret;
            CppInvoke.calib3d_RQDecomp3x3_array(src, mtxR, mtxQ, qx, qy, qz, out ret);
            return ret;
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
        public static void SolvePnP(InputArray objectPoints, InputArray imagePoints, InputArray cameraMatrix, InputArray distCoeffs, 
            OutputArray rvec, OutputArray tvec, bool useExtrinsicGuess = false, SolvePnPFlag flags = SolvePnPFlag.Iterative)
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
            CppInvoke.calib3d_solvePnP_InputArray(
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
        public static void SolvePnP(IEnumerable<Point3f> objectPoints, IEnumerable<Point2f> imagePoints, 
            InputArray cameraMatrix, IEnumerable<double> distCoeffs,
            OutputArray rvec, OutputArray tvec, bool useExtrinsicGuess = false, SolvePnPFlag flags = SolvePnPFlag.Iterative)
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

            cameraMatrix.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();

            Point3f[] objectPointsArray = EnumerableEx.ToArray(objectPoints);
            Point2f[] imagePointsArray = EnumerableEx.ToArray(imagePoints);
            double[] distCoeffsArray = EnumerableEx.ToArray(distCoeffs);
            int distCoeffsLength = (distCoeffs == null) ? 0 : distCoeffsArray.Length;

            CppInvoke.calib3d_solvePnP_vector(
                    objectPointsArray, objectPointsArray.Length, 
                    imagePointsArray, imagePointsArray.Length,
                    cameraMatrix.CvPtr, distCoeffsArray, distCoeffsLength, 
                    rvec.CvPtr, tvec.CvPtr, useExtrinsicGuess ? 1 : 0, (int)flags);
            rvec.Fix();
            tvec.Fix();
        }
        #endregion
    }
}
