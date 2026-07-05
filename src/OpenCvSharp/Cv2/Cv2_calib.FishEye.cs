using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

static partial class Cv2
{
    /// <summary>
    /// The methods in this class use a so-called fisheye camera model.
    /// </summary>
#pragma warning disable CA1034 // Nested types should not be visible
    public static class FishEye
#pragma warning restore CA1034
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
            InputArray k, InputArray d, double alpha = 0, OutputArray jacobian = default)
        {
            NativeMethods.HandleException(
                NativeMethods.calib_fisheye_projectPoints2(
                    objectPoints.Proxy,
                    imagePoints.Proxy,
                    rvec.Proxy, tvec.Proxy,
                    k.Proxy, d.Proxy,
                    alpha, jacobian.Proxy));

            GC.KeepAlive(objectPoints.Source);
            GC.KeepAlive(rvec.Source);
            GC.KeepAlive(tvec.Source);
            GC.KeepAlive(k.Source);
            GC.KeepAlive(d.Source);
            GC.KeepAlive(imagePoints.Source);
            GC.KeepAlive(jacobian.Source);
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
            NativeMethods.HandleException(
                NativeMethods.calib_fisheye_distortPoints(
                    undistorted.Proxy, distorted.Proxy, k.Proxy, d.Proxy, alpha));

            GC.KeepAlive(undistorted.Source);
            GC.KeepAlive(distorted.Source);
            GC.KeepAlive(k.Source);
            GC.KeepAlive(d.Source);
        }

        /// <summary>
        /// Distorts 2D points using the fisheye model. Overload that handles cases when undistorted
        /// points were obtained with a non-identity camera matrix
        /// (e.g. the output of EstimateNewCameraMatrixForUndistortRectify).
        /// </summary>
        /// <param name="undistorted">Array of object points, 1xN/Nx1 2-channel (or vector&lt;Point2f&gt;),
        /// where N is the number of points in the view.</param>
        /// <param name="distorted">Output array of image points, 1xN/Nx1 2-channel, or vector&lt;Point2f&gt;.</param>
        /// <param name="kundistorted">Camera intrinsic matrix used as the new camera matrix for undistortion.</param>
        /// <param name="k">Camera intrinsic matrix.</param>
        /// <param name="d">Input vector of distortion coefficients.</param>
        /// <param name="alpha">The skew coefficient.</param>
        public static void DistortPoints(
            InputArray undistorted, OutputArray distorted, InputArray kundistorted, InputArray k, InputArray d, double alpha = 0)
        {
            NativeMethods.HandleException(
                NativeMethods.calib_fisheye_distortPoints2(
                    undistorted.Proxy, distorted.Proxy, kundistorted.Proxy, k.Proxy, d.Proxy, alpha));

            GC.KeepAlive(undistorted.Source);
            GC.KeepAlive(distorted.Source);
            GC.KeepAlive(kundistorted.Source);
            GC.KeepAlive(k.Source);
            GC.KeepAlive(d.Source);
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
            InputArray k, InputArray d, InputArray r = default, InputArray p = default)
        {
            NativeMethods.HandleException(
                NativeMethods.calib_fisheye_undistortPoints(
                    distorted.Proxy, undistorted.Proxy, k.Proxy, d.Proxy, r.Proxy, p.Proxy));

            GC.KeepAlive(distorted.Source);
            GC.KeepAlive(undistorted.Source);
            GC.KeepAlive(k.Source);
            GC.KeepAlive(d.Source);
            GC.KeepAlive(r.Source);
            GC.KeepAlive(p.Source);
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
            NativeMethods.HandleException(
                NativeMethods.calib_fisheye_initUndistortRectifyMap(
                    k.Proxy, d.Proxy, r.Proxy, p.Proxy, size, m1type, map1.Proxy, map2.Proxy));
                
            GC.KeepAlive(k.Source);
            GC.KeepAlive(d.Source);
            GC.KeepAlive(r.Source);
            GC.KeepAlive(p.Source);
            GC.KeepAlive(map1.Source);
            GC.KeepAlive(map2.Source);
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
            InputArray k, InputArray d, InputArray knew = default, Size newSize = default)
        {
            NativeMethods.HandleException(
                NativeMethods.calib_fisheye_undistortImage(
                    distorted.Proxy, undistorted.Proxy, k.Proxy, d.Proxy, knew.Proxy, newSize));

            GC.KeepAlive(distorted.Source);
            GC.KeepAlive(undistorted.Source);
            GC.KeepAlive(k.Source);
            GC.KeepAlive(d.Source);
            GC.KeepAlive(knew.Source);
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
            NativeMethods.HandleException(
                NativeMethods.calib_fisheye_estimateNewCameraMatrixForUndistortRectify(
                    k.Proxy, d.Proxy, imageSize, r.Proxy, p.Proxy, balance, newSize, fovScale));

            GC.KeepAlive(k.Source);
            GC.KeepAlive(d.Source);
            GC.KeepAlive(r.Source);
            GC.KeepAlive(p.Source);
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
            ArgumentNullException.ThrowIfNull(objectPoints);
            ArgumentNullException.ThrowIfNull(imagePoints);

            var criteriaVal = criteria.GetValueOrDefault(
                new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 100, double.Epsilon));

            using var objectPointsVec = new VectorOfMat(objectPoints);
            using var imagePointsVec = new VectorOfMat(imagePoints);
            using var rvecsVec = new VectorOfMat();
            using var tvecsVec = new VectorOfMat();
            NativeMethods.HandleException(
                NativeMethods.calib_fisheye_calibrate(
                    objectPointsVec.CvPtr, imagePointsVec.CvPtr, imageSize,
                    k.Proxy, d.Proxy, rvecsVec.CvPtr, tvecsVec.CvPtr, (int) flags, criteriaVal, out var result));

            rvecs = rvecsVec.ToArray();
            tvecs = tvecsVec.ToArray();

            GC.KeepAlive(objectPoints);
            GC.KeepAlive(imagePoints);
            GC.KeepAlive(k.Source);
            GC.KeepAlive(d.Source);

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
            NativeMethods.HandleException(
                NativeMethods.calib_fisheye_stereoRectify(
                    k1.Proxy, d1.Proxy, k2.Proxy, d2.Proxy,
                    imageSize, r.Proxy, tvec.Proxy, r1.Proxy, r2.Proxy,
                    p1.Proxy, p2.Proxy, q.Proxy, (int) flags, newImageSize, balance, fovScale));

            GC.KeepAlive(k1.Source);
            GC.KeepAlive(d1.Source);
            GC.KeepAlive(k2.Source);
            GC.KeepAlive(d2.Source);
            GC.KeepAlive(r.Source);
            GC.KeepAlive(tvec.Source);
            GC.KeepAlive(r1.Source);
            GC.KeepAlive(r2.Source);
            GC.KeepAlive(p1.Source);
            GC.KeepAlive(p2.Source);
            GC.KeepAlive(q.Source);
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
            ArgumentNullException.ThrowIfNull(objectPoints);
            ArgumentNullException.ThrowIfNull(imagePoints1);
            ArgumentNullException.ThrowIfNull(imagePoints2);

            var criteriaVal = criteria.GetValueOrDefault(
                new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 100, double.Epsilon));

            using var objectPointsVec = new VectorOfMat(objectPoints);
            using var imagePoints1Vec = new VectorOfMat(imagePoints1); 
            using var imagePoints2Vec = new VectorOfMat(imagePoints2);
            NativeMethods.HandleException(
                NativeMethods.calib_fisheye_stereoCalibrate(
                    objectPointsVec.CvPtr, imagePoints1Vec.CvPtr, imagePoints2Vec.CvPtr,
                    k1.Proxy, d1.Proxy, k2.Proxy, d2.Proxy, imageSize,
                    r.Proxy, t.Proxy, (int) flags, criteriaVal, out var result));

            GC.KeepAlive(objectPoints);
            GC.KeepAlive(imagePoints1);
            GC.KeepAlive(imagePoints2);
            GC.KeepAlive(k1.Source);
            GC.KeepAlive(d1.Source);
            GC.KeepAlive(k2.Source);
            GC.KeepAlive(d2.Source);
            GC.KeepAlive(r.Source);
            GC.KeepAlive(t.Source);

            return result;
        }
    }
}
