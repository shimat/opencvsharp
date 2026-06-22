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
        if (rectList is null)
            throw new ArgumentNullException(nameof(rectList));

        using var rectListVec = new VectorOfRect(rectList);

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
        if (rectList is null)
            throw new ArgumentNullException(nameof(rectList));

        using var rectListVec = new VectorOfRect(rectList);
        using var weightsVec = new VectorOfInt32();

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
        if (rectList is null)
            throw new ArgumentNullException(nameof(rectList));

        using var rectListVec = new VectorOfRect(rectList);
        using var weightsVec = new VectorOfInt32();
        using var levelWeightsVec = new VectorOfDouble();

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
        if (rectList is null)
            throw new ArgumentNullException(nameof(rectList));

        using var rectListVec = new VectorOfRect(rectList);
        using var rejectLevelsVec = new VectorOfInt32();
        using var levelWeightsVec = new VectorOfDouble();

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
        if (rectList is null)
            throw new ArgumentNullException(nameof(rectList));

        var winDetSize0 = winDetSize.GetValueOrDefault(new Size(64, 128));

        using var rectListVec = new VectorOfRect(rectList);
        using var foundWeightsVec = new VectorOfDouble();
        using var foundScalesVec = new VectorOfDouble();

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
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        img.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.objdetect_checkChessboard(img.CvPtr, size, out var ret));
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
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (corners is null)
            throw new ArgumentNullException(nameof(corners));
        image.ThrowIfDisposed();
        corners.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.objdetect_findChessboardCornersSB_OutputArray(
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
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        image.ThrowIfDisposed();

        using var cornersVec = new VectorOfPoint2f();
        NativeMethods.HandleException(
            NativeMethods.objdetect_findChessboardCornersSB_vector(
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
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        if (corners is null)
            throw new ArgumentNullException(nameof(corners));
        img.ThrowIfDisposed();
        corners.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.objdetect_find4QuadCornerSubpix_InputArray(
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
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        if (corners is null)
            throw new ArgumentNullException(nameof(corners));
        img.ThrowIfDisposed();

        using var cornersVec = new VectorOfPoint2f(corners);
        NativeMethods.HandleException(
            NativeMethods.objdetect_find4QuadCornerSubpix_vector(
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
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (corners is null)
            throw new ArgumentNullException(nameof(corners));
        image.ThrowIfNotReady();
        corners.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.objdetect_drawChessboardCorners_InputArray(
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
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static void DrawChessboardCorners(InputOutputArray image, Size patternSize,
        IEnumerable<Point2f> corners, bool patternWasFound)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (corners is null)
            throw new ArgumentNullException(nameof(corners));
        image.ThrowIfNotReady();

        var cornersArray = corners as Point2f[] ?? corners.ToArray();
        NativeMethods.HandleException(
            NativeMethods.objdetect_drawChessboardCorners_array(
                image.CvPtr, patternSize, cornersArray, cornersArray.Length,
                patternWasFound ? 1 : 0));
        image.Fix();
    }
}
