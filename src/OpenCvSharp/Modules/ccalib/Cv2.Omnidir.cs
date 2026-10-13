using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>Functions for CMei's omnidirectional camera model.</summary>
#pragma warning disable CA1034 // Nested types should not be visible
    public static class Omnidir
#pragma warning restore CA1034
    {
        /// <summary>Projects 3D object points to omnidirectional image points.</summary>
        /// <param name="objectPoints">3D object points.</param>
        /// <param name="imagePoints">Output 2D image points.</param>
        /// <param name="rvec">Rotation vector.</param>
        /// <param name="tvec">Translation vector.</param>
        /// <param name="k">Camera matrix.</param>
        /// <param name="xi">CMei mirror parameter.</param>
        /// <param name="d">Four distortion coefficients.</param>
        /// <param name="jacobian">Optional output Jacobian.</param>
        public static void ProjectPoints(
            InputArray objectPoints, OutputArray imagePoints, InputArray rvec, InputArray tvec,
            InputArray k, double xi, InputArray d, OutputArray jacobian = default)
        {
            NativeMethods.HandleException(NativeMethods.ccalib_omnidir_projectPoints(
                objectPoints.Proxy, imagePoints.Proxy, rvec.Proxy, tvec.Proxy,
                k.Proxy, xi, d.Proxy, jacobian.Proxy));
            GC.KeepAlive(objectPoints.Source);
            GC.KeepAlive(imagePoints.Source);
            GC.KeepAlive(rvec.Source);
            GC.KeepAlive(tvec.Source);
            GC.KeepAlive(k.Source);
            GC.KeepAlive(d.Source);
            GC.KeepAlive(jacobian.Source);
        }

        /// <summary>Undistorts image points into normalized coordinates.</summary>
        /// <param name="distorted">Distorted 2D image points.</param>
        /// <param name="undistorted">Output normalized points.</param>
        /// <param name="k">Camera matrix.</param>
        /// <param name="d">Four distortion coefficients.</param>
        /// <param name="xi">A one-element matrix containing the CMei mirror parameter.</param>
        /// <param name="r">Rectification rotation.</param>
        public static void UndistortPoints(
            InputArray distorted, OutputArray undistorted, InputArray k, InputArray d,
            InputArray xi, InputArray r)
        {
            NativeMethods.HandleException(NativeMethods.ccalib_omnidir_undistortPoints(
                distorted.Proxy, undistorted.Proxy, k.Proxy, d.Proxy, xi.Proxy, r.Proxy));
            GC.KeepAlive(distorted.Source);
            GC.KeepAlive(undistorted.Source);
            GC.KeepAlive(k.Source);
            GC.KeepAlive(d.Source);
            GC.KeepAlive(xi.Source);
            GC.KeepAlive(r.Source);
        }

        /// <summary>Creates omnidirectional undistortion and rectification maps for Remap.</summary>
        /// <param name="k">Camera matrix.</param>
        /// <param name="d">Four distortion coefficients.</param>
        /// <param name="xi">A one-element matrix containing the CMei mirror parameter.</param>
        /// <param name="r">Rectification rotation.</param>
        /// <param name="p">New camera or projection matrix.</param>
        /// <param name="size">Rectified image size.</param>
        /// <param name="m1type">First map type, CV_32FC1 or CV_16SC2.</param>
        /// <param name="map1">Output first map.</param>
        /// <param name="map2">Output second map.</param>
        /// <param name="flags">Rectification projection.</param>
        public static void InitUndistortRectifyMap(
            InputArray k, InputArray d, InputArray xi, InputArray r, InputArray p,
            Size size, MatType m1type, OutputArray map1, OutputArray map2,
            OmnidirRectifyFlags flags = OmnidirRectifyFlags.Perspective)
        {
            NativeMethods.HandleException(NativeMethods.ccalib_omnidir_initUndistortRectifyMap(
                k.Proxy, d.Proxy, xi.Proxy, r.Proxy, p.Proxy, size, (int)m1type, map1.Proxy, map2.Proxy, (int)flags));
            GC.KeepAlive(k.Source);
            GC.KeepAlive(d.Source);
            GC.KeepAlive(xi.Source);
            GC.KeepAlive(r.Source);
            GC.KeepAlive(p.Source);
            GC.KeepAlive(map1.Source);
            GC.KeepAlive(map2.Source);
        }

        /// <summary>Rectifies an omnidirectional camera image.</summary>
        /// <param name="distorted">Input image.</param>
        /// <param name="undistorted">Output rectified image.</param>
        /// <param name="k">Camera matrix.</param>
        /// <param name="d">Four distortion coefficients.</param>
        /// <param name="xi">A one-element matrix containing the CMei mirror parameter.</param>
        /// <param name="flags">Rectification projection.</param>
        /// <param name="knew">New camera matrix; defaults to the input camera matrix.</param>
        /// <param name="newSize">Output image size; defaults to the input size.</param>
        /// <param name="r">Rectification rotation; defaults to identity.</param>
        public static void UndistortImage(
            InputArray distorted, OutputArray undistorted, InputArray k, InputArray d,
            InputArray xi, OmnidirRectifyFlags flags = OmnidirRectifyFlags.Perspective,
            InputArray knew = default, Size newSize = default, InputArray r = default)
        {
            NativeMethods.HandleException(NativeMethods.ccalib_omnidir_undistortImage(
                distorted.Proxy, undistorted.Proxy, k.Proxy, d.Proxy, xi.Proxy,
                (int)flags, knew.Proxy, newSize, r.Proxy));
            GC.KeepAlive(distorted.Source);
            GC.KeepAlive(undistorted.Source);
            GC.KeepAlive(k.Source);
            GC.KeepAlive(d.Source);
            GC.KeepAlive(xi.Source);
            GC.KeepAlive(knew.Source);
            GC.KeepAlive(r.Source);
        }

        /// <summary>Calibrates CMei's omnidirectional camera model from multiple pattern views.</summary>
        /// <param name="objectPoints">Per-view 3D pattern points as CV_64FC3 matrices.</param>
        /// <param name="imagePoints">Matching per-view image points as CV_64FC2 matrices.</param>
        /// <param name="imageSize">Calibration image size.</param>
        /// <param name="k">Input/output camera matrix; single-camera calibration estimates its values independently of the initial contents.</param>
        /// <param name="xi">Input/output one-element CMei mirror parameter; initial contents are ignored.</param>
        /// <param name="d">Input/output four distortion coefficients; initial contents are ignored.</param>
        /// <param name="rvecs">Output per-view rotation vectors.</param>
        /// <param name="tvecs">Output per-view translation vectors.</param>
        /// <param name="flags">Calibration options.</param>
        /// <param name="criteria">Optimization stopping criteria.</param>
        /// <param name="indices">Optional output indices of the views used in calibration.</param>
        /// <returns>Root mean squared reprojection error.</returns>
        public static double Calibrate(
            IEnumerable<Mat> objectPoints, IEnumerable<Mat> imagePoints, Size imageSize,
            InputOutputArray k, InputOutputArray xi, InputOutputArray d,
            out Mat[] rvecs, out Mat[] tvecs,
            OmnidirCalibrationFlags flags = 0, TermCriteria? criteria = null,
            OutputArray indices = default)
        {
            ArgumentNullException.ThrowIfNull(objectPoints);
            ArgumentNullException.ThrowIfNull(imagePoints);
            var objectPointsArray = objectPoints.ToArray();
            var imagePointsArray = imagePoints.ToArray();
            using var objectPointsVec = new VectorOfMat(objectPointsArray);
            using var imagePointsVec = new VectorOfMat(imagePointsArray);
            using var rvecsVec = new VectorOfMat();
            using var tvecsVec = new VectorOfMat();
            var criteriaValue = criteria.GetValueOrDefault(
                new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 100, 1e-6));

            NativeMethods.HandleException(NativeMethods.ccalib_omnidir_calibrate(
                objectPointsVec.CvPtr, imagePointsVec.CvPtr, imageSize,
                k.Proxy, xi.Proxy, d.Proxy, rvecsVec.CvPtr, tvecsVec.CvPtr,
                (int)flags, criteriaValue, indices.Proxy, out var error));

            rvecs = rvecsVec.ToArray();
            tvecs = tvecsVec.ToArray();
            GC.KeepAlive(objectPointsArray);
            GC.KeepAlive(imagePointsArray);
            GC.KeepAlive(k.Source);
            GC.KeepAlive(xi.Source);
            GC.KeepAlive(d.Source);
            GC.KeepAlive(indices.Source);
            return error;
        }
    }
}
