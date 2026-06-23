#pragma warning disable CS1591

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Dnn;

/// <summary>
/// Enum of data layout for model inference.
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
