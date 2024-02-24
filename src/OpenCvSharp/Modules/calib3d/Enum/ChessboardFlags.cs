

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

/// <summary>
/// Various operation flags for cvFindChessboardCorners
/// </summary>
[Flags]
public enum ChessboardFlags 
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// Use adaptive thresholding to convert the image to black-n-white, rather than a fixed threshold level (computed from the average image brightness).
    /// </summary>
    AdaptiveThresh = 1,

    /// <summary>
    /// Normalize the image using cvNormalizeHist before applying fixed or adaptive thresholding.
    /// </summary>
    NormalizeImage = 2,

    /// <summary>
    /// Use additional criteria (like contour area, perimeter, square-like shape) to filter out false quads
    /// that are extracted at the contour retrieval stage.
    /// </summary>
    FilterQuads = 4,

    /// <summary>
    /// Run a fast check on the image that looks for chessboard corners, and shortcut the call if none is found.
    /// This can drastically speed up the call in the degenerate condition when no chessboard is observed.
    /// </summary>
    FastCheck = 8,

    /// <summary>
    /// Run an exhaustive search to improve detection rate.
    /// </summary>
    Exhaustive = 16,

    /// <summary>
    /// Up sample input image to improve sub-pixel accuracy due to aliasing effects.
    /// This should be used if an accurate camera calibration is required.
    /// </summary>
    Accuracy = 32
}
