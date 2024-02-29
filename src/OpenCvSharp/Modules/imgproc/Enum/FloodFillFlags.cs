namespace OpenCvSharp;

/// <summary>
/// floodFill Operation flags. Lower bits contain a connectivity value, 4 (default) or 8, used within the function. Connectivity determines which neighbors of a pixel are considered. Upper bits can be 0 or a combination of the following flags:
/// </summary>
[Flags]
public enum FloodFillFlags
{
    /// <summary>
    /// 4-connected line.
    /// [= 4]
    /// </summary>
    Link4 = 4,

    /// <summary>
    /// 8-connected line.
    /// [= 8]
    /// </summary>
    Link8 = 8,

    /// <summary>
    /// If set, the difference between the current pixel and seed pixel is considered. Otherwise, the difference between neighbor pixels is considered (that is, the range is floating).
    /// [CV_FLOODFILL_FIXED_RANGE]
    /// </summary>
    FixedRange = 1 << 16,

    /// <summary>
    /// If set, the function does not change the image ( newVal is ignored), but fills the mask. The flag can be used for the second variant only.
    /// [CV_FLOODFILL_MASK_ONLY]
    /// </summary>
    MaskOnly = 1 << 17,
}
