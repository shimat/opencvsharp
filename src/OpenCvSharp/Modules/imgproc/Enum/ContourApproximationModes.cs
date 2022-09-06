using System.Diagnostics.CodeAnalysis;

#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp;

/// <summary>
/// Approximation method (for all the modes, except CV_RETR_RUNS, which uses built-in approximation). 
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/d3bc563c6e01c2bc153f23e7393322a95c7d3974/modules/imgproc/include/opencv2/imgproc.hpp#L431
/// </remarks>
[SuppressMessage("Microsoft.Design", "CA1717: Only FlagsAttribute enums should have plural names")]
public enum ContourApproximationModes
{
    /// <summary>
    /// CHAIN_APPROX_NONE - translate all the points from the chain code into points; 
    /// </summary>
    ApproxNone = 1,

    /// <summary>
    /// CHAIN_APPROX_SIMPLE - compress horizontal, vertical, and diagonal segments, that is, the function leaves only their ending points; 
    /// </summary>
    ApproxSimple = 2,

    /// <summary>
    /// CHAIN_APPROX_TC89_L1 - apply one of the flavors of Teh-Chin chain approximation algorithm. 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    ApproxTC89L1 = 3,

    /// <summary>
    /// CHAIN_APPROX_TC89_KCOS - apply one of the flavors of Teh-Chin chain approximation algorithm. 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    ApproxTC89KCOS = 4,
}
