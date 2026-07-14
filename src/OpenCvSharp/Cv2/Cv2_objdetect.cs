using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

static partial class Cv2
{
    /// <summary>
    /// Groups the object candidate rectangles.
    /// </summary>
    /// <param name="rectList"> Input/output vector of rectangles. Output vector includes retained and grouped rectangles.</param>
    /// <param name="groupThreshold">Minimum possible number of rectangles minus 1. The threshold is used in a group of rectangles to retain it.</param>
    /// <param name="eps"></param>
    public static void GroupRectangles(IList<Rect> rectList, int groupThreshold, double eps = 0.2)
    {
        ArgumentNullException.ThrowIfNull(rectList);

        using var rectListVec = new StdVector<Rect>(rectList);

        NativeMethods.HandleException(
            NativeMethods.objdetect_groupRectangles1(rectListVec.CvPtr, groupThreshold, eps));

        ClearAndAddRange(rectList, rectListVec.ToArray());
    }

    /// <summary>
    /// Groups the object candidate rectangles.
    /// </summary>
    /// <param name="rectList"> Input/output vector of rectangles. Output vector includes retained and grouped rectangles.</param>
    /// <param name="weights"></param>
    /// <param name="groupThreshold">Minimum possible number of rectangles minus 1. The threshold is used in a group of rectangles to retain it.</param>
    /// <param name="eps">Relative difference between sides of the rectangles to merge them into a group.</param>
    public static void GroupRectangles(IList<Rect> rectList, out int[] weights, int groupThreshold, double eps = 0.2)
    {
        ArgumentNullException.ThrowIfNull(rectList);

        using var rectListVec = new StdVector<Rect>(rectList);
        using var weightsVec = new StdVector<int>();

        NativeMethods.HandleException(
            NativeMethods.objdetect_groupRectangles2(rectListVec.CvPtr, weightsVec.CvPtr, groupThreshold, eps));

        ClearAndAddRange(rectList, rectListVec.ToArray());
        weights = weightsVec.ToArray();
    }

    /// <summary>
    /// Groups the object candidate rectangles.
    /// </summary>
    /// <param name="rectList"></param>
    /// <param name="groupThreshold"></param>
    /// <param name="eps"></param>
    /// <param name="weights"></param>
    /// <param name="levelWeights"></param>
    public static void GroupRectangles(IList<Rect> rectList, int groupThreshold, double eps, out int[] weights, out double[] levelWeights)
    {
        ArgumentNullException.ThrowIfNull(rectList);

        using var rectListVec = new StdVector<Rect>(rectList);
        using var weightsVec = new StdVector<int>();
        using var levelWeightsVec = new StdVector<double>();

        NativeMethods.HandleException(
            NativeMethods.objdetect_groupRectangles3(
                rectListVec.CvPtr, groupThreshold, eps, weightsVec.CvPtr, levelWeightsVec.CvPtr));

        ClearAndAddRange(rectList, rectListVec.ToArray());
        weights = weightsVec.ToArray();
        levelWeights = levelWeightsVec.ToArray();
    }

    /// <summary>
    /// Groups the object candidate rectangles.
    /// </summary>
    /// <param name="rectList"></param>
    /// <param name="rejectLevels"></param>
    /// <param name="levelWeights"></param>
    /// <param name="groupThreshold"></param>
    /// <param name="eps"></param>
    public static void GroupRectangles(IList<Rect> rectList, out int[] rejectLevels, out double[] levelWeights, int groupThreshold, double eps = 0.2)
    {
        ArgumentNullException.ThrowIfNull(rectList);

        using var rectListVec = new StdVector<Rect>(rectList);
        using var rejectLevelsVec = new StdVector<int>();
        using var levelWeightsVec = new StdVector<double>();

        NativeMethods.HandleException(
            NativeMethods.objdetect_groupRectangles4(
                rectListVec.CvPtr, rejectLevelsVec.CvPtr, levelWeightsVec.CvPtr, groupThreshold, eps));

        ClearAndAddRange(rectList, rectListVec.ToArray());
        rejectLevels = rejectLevelsVec.ToArray();
        levelWeights = levelWeightsVec.ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rectList"></param>
    /// <param name="foundWeights"></param>
    /// <param name="foundScales"></param>
    /// <param name="detectThreshold"></param>
    /// <param name="winDetSize"></param>
    public static void GroupRectanglesMeanshift(IList<Rect> rectList, out double[] foundWeights,
        out double[] foundScales, double detectThreshold = 0.0, Size? winDetSize = null)
    {
        ArgumentNullException.ThrowIfNull(rectList);

        var winDetSize0 = winDetSize.GetValueOrDefault(new Size(64, 128));

        using var rectListVec = new StdVector<Rect>(rectList);
        using var foundWeightsVec = new StdVector<double>();
        using var foundScalesVec = new StdVector<double>();

        NativeMethods.HandleException(
            NativeMethods.objdetect_groupRectangles_meanshift(
                rectListVec.CvPtr, foundWeightsVec.CvPtr, foundScalesVec.CvPtr, detectThreshold, winDetSize0));

        ClearAndAddRange(rectList, rectListVec.ToArray());
        foundWeights = foundWeightsVec.ToArray();
        foundScales = foundScalesVec.ToArray();
    }

    private static void ClearAndAddRange<T>(ICollection<T> list, IEnumerable<T> values)
    {
        list.Clear();
        foreach (var t in values)
        {
            list.Add(t);
        }
    }

    /// <summary>
    /// Checks whether the image contains chessboard of the specific size or not.
    /// </summary>
    /// <param name="img"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static bool CheckChessboard(InputArray img, Size size)
    {
        NativeMethods.HandleException(
            NativeMethods.objdetect_checkChessboard(img.Proxy, size, out var ret));
        GC.KeepAlive(img.Source);
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
        NativeMethods.HandleException(
            NativeMethods.objdetect_findChessboardCornersSB_OutputArray(
                image.Proxy, patternSize, corners.Proxy, (int) flags, out var ret));

        GC.KeepAlive(image.Source);
        GC.KeepAlive(corners.Source);
        return ret != 0;
    }

    /// <summary>
    /// Finds the positions of internal corners of the chessboard using a sector based approach.
    /// </summary>
    /// <param name="image">image Source chessboard view. It must be an 8-bit grayscale or color image.</param>
    /// <param name="patternSize">Number of inner corners per a chessboard row and column
    /// (patternSize = Size(points_per_row, points_per_column) = Size(columns, rows) ).</param>
    /// <param name="flags">flags Various operation flags that can be zero or a combination of the ChessboardFlags values.</param>
    /// <returns>Array of detected corners. Empty if the corners could not be found.</returns>
    public static Point2f[] FindChessboardCornersSB(
        InputArray image, Size patternSize, ChessboardFlags flags = 0)
    {
        using var cornersVec = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.objdetect_findChessboardCornersSB_vector(
                image.Proxy, patternSize, cornersVec.CvPtr, (int) flags, out _));

        GC.KeepAlive(image.Source);
        return cornersVec.ToArray();
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
        NativeMethods.HandleException(
            NativeMethods.objdetect_find4QuadCornerSubpix_InputArray(
                img.Proxy, corners.Proxy, regionSize, out var ret));
        GC.KeepAlive(img.Source);
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
        ArgumentNullException.ThrowIfNull(corners);

        using var cornersVec = new StdVector<Point2f>(corners);
        NativeMethods.HandleException(
            NativeMethods.objdetect_find4QuadCornerSubpix_vector(
                img.Proxy, cornersVec.CvPtr, regionSize, out var ret));
        GC.KeepAlive(img.Source);

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
        NativeMethods.HandleException(
            NativeMethods.objdetect_drawChessboardCorners_InputArray(
                image.Proxy, patternSize, corners.Proxy, patternWasFound ? 1 : 0));
        GC.KeepAlive(corners.Source);
    }

    /// <summary>
    /// Renders the detected chessboard corners.
    /// </summary>
    /// <param name="image">Destination image. It must be an 8-bit color image.</param>
    /// <param name="patternSize">Number of inner corners per a chessboard row and column (patternSize = cv::Size(points_per_row,points_per_column)).</param>
    /// <param name="corners">Array of detected corners, the output of findChessboardCorners.</param>
    /// <param name="patternWasFound">Parameter indicating whether the complete board was found or not. The return value of findChessboardCorners() should be passed here.</param>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static void DrawChessboardCorners(InputOutputArray image, Size patternSize,
        IEnumerable<Point2f> corners, bool patternWasFound)
    {
        ArgumentNullException.ThrowIfNull(corners);

        var cornersArray = corners as Point2f[] ?? corners.ToArray();
        NativeMethods.HandleException(
            NativeMethods.objdetect_drawChessboardCorners_array(
                image.Proxy, patternSize, cornersArray, cornersArray.Length,
                patternWasFound ? 1 : 0));
    }

    /// <summary>
    /// Estimates the sharpness of a detected chessboard.
    /// Image sharpness, as well as brightness, are a critical parameter for accuracy of feature point
    /// extraction. As an example, consider the sharpness level of a camera as being described in
    /// terms of a Gaussian low pass filter and estimate the parameter based on the width of the
    /// transition area between a fully saturated pixel and the background pixel.
    /// </summary>
    /// <param name="image">source chessboard view; it must be a 8-bit grayscale or color image.</param>
    /// <param name="patternSize">the number of inner corners per chessboard row and column.</param>
    /// <param name="corners">Array of detected chessboard corners, the output of findChessboardCorners.</param>
    /// <param name="riseDistance">Rise distance 0.8 means 10% ... 90% of the final signal strength.</param>
    /// <param name="vertical">By default edge responses for horizontal lines are calculated.</param>
    /// <param name="sharpness">Optional output image with the sharpness in the sharpness assessment area.</param>
    /// <returns>
    /// Scalar(average sharpness, average min brightness, average max brightness, 0).
    /// </returns>
    public static Scalar EstimateChessboardSharpness(
        InputArray image, Size patternSize, InputArray corners,
        float riseDistance = 0.8f, bool vertical = false, OutputArray sharpness = default)
    {
        NativeMethods.HandleException(
            NativeMethods.objdetect_estimateChessboardSharpness(
                image.Proxy, patternSize, corners.Proxy, riseDistance, vertical ? 1 : 0,
                sharpness.Proxy, out var ret));

        GC.KeepAlive(image.Source);
        GC.KeepAlive(corners.Source);
        GC.KeepAlive(sharpness.Source);

        return ret;
    }
}
