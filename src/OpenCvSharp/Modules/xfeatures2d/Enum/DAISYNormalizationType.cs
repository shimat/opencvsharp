// ReSharper disable InconsistentNaming
#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp;

/// <summary>
/// Descriptor normalization type for cv::xfeatures2d::DAISY.
/// </summary>
public enum DAISYNormalizationType
{
    /// <summary>
    /// No normalization is applied (default)
    /// </summary>
    None = 100,

    /// <summary>
    /// Histograms are normalized independently for L2 norm equal to 1.0
    /// </summary>
    Partial = 101,

    /// <summary>
    /// Descriptors are normalized for L2 norm equal to 1.0
    /// </summary>
    Full = 102,

    /// <summary>
    /// Descriptors are normalized for L2 norm equal to 1.0, but no individual value is bigger than 0.154 (as in SIFT)
    /// </summary>
    Sift = 103
}
