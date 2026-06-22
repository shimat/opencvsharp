// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// Method used to compute surface normals from a depth image (cv::RgbdNormals::RgbdNormalsMethod).
/// </summary>
public enum RgbdNormalsMethod
{
    /// <summary>
    /// FALS (the fastest) method.
    /// </summary>
    RGBD_NORMALS_METHOD_FALS = 0,

    /// <summary>
    /// LINEMOD method (uses bilateral filtering on a depth image).
    /// </summary>
    RGBD_NORMALS_METHOD_LINEMOD = 1,

    /// <summary>
    /// SRI method.
    /// </summary>
    RGBD_NORMALS_METHOD_SRI = 2,

    /// <summary>
    /// Cross product method.
    /// </summary>
    RGBD_NORMALS_METHOD_CROSS_PRODUCT = 3
}
