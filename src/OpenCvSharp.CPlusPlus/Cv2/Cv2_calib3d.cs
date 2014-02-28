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
            CppInvoke.imgproc_solvePnP(
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
        public static void SolvePnP(IEnumerable<Point3f> objectPoints, IEnumerable<Point2f> imagePoints, InputArray cameraMatrix, InputArray distCoeffs,
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
            using (StdVectorPoint3f objectPointsVec = new StdVectorPoint3f(objectPoints))
            using (StdVectorPoint2f imagePointssVec = new StdVectorPoint2f(imagePoints))
            {
                IntPtr distCoeffsPtr = ToPtr(distCoeffs);
                CppInvoke.imgproc_solvePnP(
                    objectPointsVec.CvPtr, imagePointssVec.CvPtr, cameraMatrix.CvPtr, distCoeffsPtr, 
                    rvec.CvPtr, tvec.CvPtr, useExtrinsicGuess ? 1 : 0);
            }
        }
        #endregion
    }
}
