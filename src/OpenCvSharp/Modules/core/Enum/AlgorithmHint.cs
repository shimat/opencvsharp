namespace OpenCvSharp;

/// <summary>
/// Hint that selects between alternative algorithm implementations (OpenCV 5).
/// Passed to functions such as warpAffine, warpPerspective, remap, GaussianBlur and cvtColor.
/// </summary>
public enum AlgorithmHint
{
    /// <summary>
    /// Default algorithm behaviour defined during the OpenCV build.
    /// </summary>
    Default = 0,

    /// <summary>
    /// Use the generic portable implementation (more accurate / reproducible).
    /// </summary>
    Accurate = 1,

    /// <summary>
    /// Allow alternative approximations for a faster implementation; behaviour and result depend on the platform.
    /// </summary>
    Approx = 2
}
