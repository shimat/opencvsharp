// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// Indicates what pyramid is to access using OdometryFrame.GetPyramidAt() method.
/// </summary>
public enum OdometryFramePyramidType
{
    /// <summary>
    /// The pyramid of grayscale images
    /// </summary>
    PYR_IMAGE = 0,

    /// <summary>
    /// The pyramid of depth images
    /// </summary>
    PYR_DEPTH = 1,

    /// <summary>
    /// The pyramid of masks
    /// </summary>
    PYR_MASK = 2,

    /// <summary>
    /// The pyramid of point clouds, produced from the pyramid of depths
    /// </summary>
    PYR_CLOUD = 3,

    /// <summary>
    /// The pyramid of dI/dx derivative images
    /// </summary>
    PYR_DIX = 4,

    /// <summary>
    /// The pyramid of dI/dy derivative images
    /// </summary>
    PYR_DIY = 5,

    /// <summary>
    /// The pyramid of "textured" masks (i.e. additional masks for normals or grayscale images)
    /// </summary>
    PYR_TEXMASK = 6,

    /// <summary>
    /// The pyramid of normals
    /// </summary>
    PYR_NORM = 7,

    /// <summary>
    /// The pyramid of normals masks
    /// </summary>
    PYR_NORMMASK = 8
}
