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
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="jacobian"></param>
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
        #endregion

        #region SolvePnP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectPoints"></param>
        /// <param name="imagePoints"></param>
        /// <param name="cameraMatrix"></param>
        /// <param name="distCoeffs"></param>
        /// <param name="rvec"></param>
        /// <param name="tvec"></param>
        /// <param name="useExtrinsicGuess"></param>
        public static void SolvePnP(InputArray objectPoints, InputArray imagePoints, InputArray cameraMatrix, InputArray distCoeffs, 
            OutputArray rvec, OutputArray tvec, bool useExtrinsicGuess = false)
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
                rvec.CvPtr, tvec.CvPtr, useExtrinsicGuess ? 1 : 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectPoints"></param>
        /// <param name="imagePoints"></param>
        /// <param name="cameraMatrix"></param>
        /// <param name="distCoeffs"></param>
        /// <param name="rvec"></param>
        /// <param name="tvec"></param>
        /// <param name="useExtrinsicGuess"></param>
        public static void SolvePnP(IEnumerable<Point3f> objectPoints, IEnumerable<Point2f> imagePoints, 
            InputArray cameraMatrix, IEnumerable<double> distCoeffs,
            OutputArray rvec, OutputArray tvec, bool useExtrinsicGuess = false)
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
                    rvec.CvPtr, tvec.CvPtr, useExtrinsicGuess ? 1 : 0);
        }
        #endregion
    }
}
