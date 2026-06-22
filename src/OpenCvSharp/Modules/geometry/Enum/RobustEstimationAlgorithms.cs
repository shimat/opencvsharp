#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// type of the robust estimation algorithm
/// </summary>
public enum RobustEstimationAlgorithms
{
    /// <summary>
    /// least-median of squares algorithm
    /// </summary>
    LMEDS = 4,

    /// <summary>
    /// RANSAC algorithm
    /// </summary>
    RANSAC = 8,

    /// <summary>
    /// RHO algorithm
    /// </summary>
    RHO = 16,

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
