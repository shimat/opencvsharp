using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

public static partial class Cv2
{
    public static partial class Detail
    {
        /// <summary>Estimates two focal lengths from a homography.</summary>
        public static void FocalsFromHomography(Mat homography,
            out double f0, out double f1, out bool f0Ok, out bool f1Ok)
        {
            ArgumentNullException.ThrowIfNull(homography);
            homography.ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_detail_focalsFromHomography(
                homography.CvPtr, out f0, out f1, out var ok0, out var ok1));
            f0Ok = ok0 != 0;
            f1Ok = ok1 != 0;
            GC.KeepAlive(homography);
        }

        /// <summary>Calibrates the camera from rotation homographies.</summary>
        public static bool CalibrateRotatingCamera(IEnumerable<Mat> homographies, Mat cameraMatrix)
        {
            ArgumentNullException.ThrowIfNull(homographies);
            ArgumentNullException.ThrowIfNull(cameraMatrix);
            using var input = new VectorOfMat(homographies);
            NativeMethods.HandleException(NativeMethods.stitching_detail_calibrateRotatingCamera(
                input.CvPtr, cameraMatrix.CvPtr, out var result));
            GC.KeepAlive(cameraMatrix);
            return result != 0;
        }

        /// <summary>Finds the overlap of two image regions.</summary>
        public static bool OverlapRoi(Point tl1, Point tl2, Size sz1, Size sz2, out Rect roi)
        {
            NativeMethods.HandleException(NativeMethods.stitching_detail_overlapRoi(
                tl1, tl2, sz1, sz2, out roi, out var result));
            return result != 0;
        }

        /// <summary>Finds the bounding region of images at the specified corners.</summary>
        public static Rect ResultRoi(IEnumerable<Point> corners, IEnumerable<Size> sizes)
        {
            var (cornerArray, sizeArray) = PrepareRegions(corners, sizes);
            NativeMethods.HandleException(NativeMethods.stitching_detail_resultRoiSizes(
                cornerArray, sizeArray, cornerArray.Length, out var result));
            return result;
        }

        /// <summary>Finds the bounding region of UMat images at the specified corners.</summary>
        public static Rect ResultRoi(IEnumerable<Point> corners, IEnumerable<UMat> images)
        {
            ArgumentNullException.ThrowIfNull(corners);
            ArgumentNullException.ThrowIfNull(images);
            var cornerArray = corners.ToArray();
            var imageArray = images.ToArray();
            ValidateRegionCount(cornerArray.Length, imageArray.Length);
            var pointers = imageArray.Select(image =>
            {
                ArgumentNullException.ThrowIfNull(image);
                image.ThrowIfDisposed();
                return image.CvPtr;
            }).ToArray();
            NativeMethods.HandleException(NativeMethods.stitching_detail_resultRoiImages(
                cornerArray, pointers, cornerArray.Length, out var result));
            GC.KeepAlive(imageArray);
            return result;
        }

        /// <summary>Finds the common region of images at the specified corners.</summary>
        public static Rect ResultRoiIntersection(IEnumerable<Point> corners, IEnumerable<Size> sizes)
        {
            var (cornerArray, sizeArray) = PrepareRegions(corners, sizes);
            NativeMethods.HandleException(NativeMethods.stitching_detail_resultRoiIntersection(
                cornerArray, sizeArray, cornerArray.Length, out var result));
            return result;
        }

        /// <summary>Finds the top-left corner of a collection of image regions.</summary>
        public static Point ResultTl(IEnumerable<Point> corners)
        {
            ArgumentNullException.ThrowIfNull(corners);
            var cornerArray = corners.ToArray();
            if (cornerArray.Length == 0)
                throw new ArgumentException("At least one corner is required.", nameof(corners));
            NativeMethods.HandleException(NativeMethods.stitching_detail_resultTl(
                cornerArray, cornerArray.Length, out var result));
            return result;
        }

        /// <summary>Selects count distinct random indices from [0, size).</summary>
        public static int[] SelectRandomSubset(int count, int size)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(count);
            ArgumentOutOfRangeException.ThrowIfNegative(size);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(count, size);
            using var subset = new StdVector<int>();
            NativeMethods.HandleException(NativeMethods.stitching_detail_selectRandomSubset(
                count, size, subset.CvPtr));
            return subset.ToArray();
        }

        /// <summary>Gets or sets the OpenCV stitching detail log level.</summary>
        public static int StitchingLogLevel
        {
            get
            {
                NativeMethods.HandleException(NativeMethods.stitching_detail_getLogLevel(out var level));
                return level;
            }
            set => NativeMethods.HandleException(NativeMethods.stitching_detail_setLogLevel(value));
        }

        private static (Point[] Corners, Size[] Sizes) PrepareRegions(
            IEnumerable<Point> corners, IEnumerable<Size> sizes)
        {
            ArgumentNullException.ThrowIfNull(corners);
            ArgumentNullException.ThrowIfNull(sizes);
            var cornerArray = corners.ToArray();
            var sizeArray = sizes.ToArray();
            ValidateRegionCount(cornerArray.Length, sizeArray.Length);
            return (cornerArray, sizeArray);
        }

        private static void ValidateRegionCount(int corners, int values)
        {
            if (corners == 0 || corners != values)
                throw new ArgumentException("Corners and values must have equal, nonzero lengths.");
        }
    }
}
