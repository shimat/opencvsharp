// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp;

/// <summary>
/// Volume type used by VolumeSettings and Volume.
/// </summary>
public enum VolumeType
{
    /// <summary>
    /// Truncated Signed Distance Function volume.
    /// </summary>
    TSDF = 0,

    /// <summary>
    /// Hash-based Truncated Signed Distance Function volume.
    /// </summary>
    HashTSDF = 1,

    /// <summary>
    /// Colored Truncated Signed Distance Function volume.
    /// </summary>
    ColorTSDF = 2
}
