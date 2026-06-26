// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// These constants are used to set a type of data which odometry will use.
/// </summary>
public enum OdometryType
{
    /// <summary>
    /// only depth data
    /// </summary>
    DEPTH = 0,

    /// <summary>
    /// only rgb image
    /// </summary>
    RGB = 1,

    /// <summary>
    /// depth and rgb data simultaneously
    /// </summary>
    RGB_DEPTH = 2
}
