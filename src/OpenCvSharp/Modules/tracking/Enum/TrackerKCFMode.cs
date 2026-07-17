namespace OpenCvSharp.Tracking;

/// <summary>
/// Feature type to be used in the tracking: grayscale, colornames, compressed color-names.
/// Mirrors <c>cv::TrackerKCF::MODE</c>.
/// </summary>
[Flags]
// ReSharper disable once InconsistentNaming
public enum TrackerKCFMode
{
    /// <summary>
    /// Use grayscale values as the feature.
    /// </summary>
    Gray = 1 << 0,

    /// <summary>
    /// Color-names feature.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    CN = 1 << 1,

    /// <summary>
    /// User-supplied feature, set via <see cref="TrackerKCF.SetFeatureExtractor"/>.
    /// </summary>
    Custom = 1 << 2,
}
