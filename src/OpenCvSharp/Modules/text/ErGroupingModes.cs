namespace OpenCvSharp.Text;

/// <summary>
/// text::erGrouping / text::detectRegions operation modes.
/// </summary>
public enum ErGroupingModes
{
    /// <summary>
    /// Exhaustive Search algorithm for grouping horizontally aligned text.
    /// </summary>
    OrientationHoriz,

    /// <summary>
    /// Text grouping method for grouping arbitrary oriented text.
    /// Not supported: removed upstream due to NFA code removal (opencv/opencv_contrib#2235).
    /// </summary>
    OrientationAny,
}
