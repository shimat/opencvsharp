
namespace OpenCvSharp;

/// <summary>
/// Possible set of marker types used for the cv::drawMarker function
/// </summary>
public enum MarkerTypes
{
    /// <summary>
    /// A crosshair marker shape
    /// </summary>
    Cross = 0,

    /// <summary>
    /// A 45 degree tilted crosshair marker shape
    /// </summary>
    TiltedCross = 1,

    /// <summary>
    /// A star marker shape, combination of cross and tilted cross
    /// </summary>
    Star = 2, 

    /// <summary>
    /// A diamond marker shape
    /// </summary>
    Diamond = 3,

    /// <summary>
    /// A square marker shape
    /// </summary>
    Square = 4,

    /// <summary>
    /// An upwards pointing triangle marker shape
    /// </summary>
    TriangleUp = 5,

    /// <summary>
    /// A downwards pointing triangle marker shape
    /// </summary>
    TriangleDown = 6
}
