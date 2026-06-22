namespace OpenCvSharp;

/// <summary>
/// The method used to computed homography matrix
/// </summary>
public enum HomographyMethods
{
    /// <summary>
    /// Regular method using all the point pairs
    /// </summary>
    None = 0,

    /// <summary>
    /// Least-Median robust method
    /// </summary>
    LMedS = 4,

    /// <summary>
    /// RANSAC-based robust method
    /// </summary>
    Ransac = 8,

    /// <summary>
    /// RHO algorithm
    /// </summary>
    Rho = 16,

    /// <summary>
    /// USAC algorithm, default settings
    /// </summary>
    USAC_DEFAULT = 32,

    /// <summary>
    /// USAC, parallel version
    /// </summary>
    USAC_PARALLEL = 33,

    /// <summary>
    /// USAC, fundamental matrix 8 points
    /// </summary>
    USAC_FM_8PTS = 34,

    /// <summary>
    /// USAC, fast settings
    /// </summary>
    USAC_FAST = 35,

    /// <summary>
    /// USAC, accurate settings
    /// </summary>
    USAC_ACCURATE = 36,

    /// <summary>
    /// USAC, sorted points, runs PROSAC
    /// </summary>
    USAC_PROSAC = 37,

    /// <summary>
    /// USAC, runs MAGSAC++
    /// </summary>
    USAC_MAGSAC = 38
}
