#pragma warning disable CS1591

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// Data layout of a matrix / tensor (OpenCV 5, cv::DataLayout). Defined in the core module and
/// shared by core (<see cref="MatShape"/>) and dnn (e.g. blob-from-image parameters).
/// </summary>
public enum DataLayout
{
    UNKNOWN = 0,
    ND = 1,
    NCHW = 2,
    NCDHW = 3,
    NHWC = 4,
    NDHWC = 5,
    PLANAR = 6,
    BLOCK = 7,
}
