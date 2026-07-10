namespace OpenCvSharp;

/// <summary>
/// Descriptor type for cv::xfeatures2d::BoostDesc.
/// </summary>
public enum BoostDescType
{
    /// <summary>
    /// Base descriptor where each binary dimension is computed as the output of a single weak learner
    /// </summary>
    Bgm = 100,

    /// <summary>
    /// BGM using ASSIGN_HARD gradient binning
    /// </summary>
    BgmHard = 101,

    /// <summary>
    /// BGM using ASSIGN_BILINEAR gradient binning
    /// </summary>
    BgmBilinear = 102,

    /// <summary>
    /// Floating point extension (alias FP-Boost)
    /// </summary>
    Lbgm = 200,

    /// <summary>
    /// 64-bit binary extension of LBGM
    /// </summary>
    Binboost64 = 300,

    /// <summary>
    /// 128-bit binary extension of LBGM
    /// </summary>
    Binboost128 = 301,

    /// <summary>
    /// 256-bit binary extension of LBGM
    /// </summary>
    Binboost256 = 302
}
