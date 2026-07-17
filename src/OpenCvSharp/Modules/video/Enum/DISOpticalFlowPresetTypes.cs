namespace OpenCvSharp;

/// <summary>
/// Preselected parameter sets for <see cref="DISOpticalFlow"/>, trading off speed for quality.
/// </summary>
public enum DISOpticalFlowPresetTypes
{
    /// <summary>
    /// Fastest preset.
    /// </summary>
    UltraFast = 0,

    /// <summary>
    /// Fast preset.
    /// </summary>
    Fast = 1,

    /// <summary>
    /// Medium preset (default).
    /// </summary>
    Medium = 2
}
