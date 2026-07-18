namespace OpenCvSharp.OptFlow;

/// <summary>
/// Support region shape used by <see cref="RLOFOpticalFlowParameter"/>.
/// </summary>
public enum SupportRegionType
{
    /// <summary>
    /// Apply a constant support region.
    /// </summary>
    Fixed = 0,

    /// <summary>
    /// Apply an adaptive support region obtained by cross-based segmentation.
    /// </summary>
    Cross = 1,
}
