using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// Adaptive thresholding algorithms
/// </summary>
/// <remarks>
///https://github.com/opencv/opencv/blob/d3bc563c6e01c2bc153f23e7393322a95c7d3974/modules/imgproc/include/opencv2/imgproc.hpp#L333
/// </remarks>
[SuppressMessage("Microsoft.Design", "CA1717: Only FlagsAttribute enums should have plural names")]
public enum AdaptiveThresholdTypes
{
    /// <summary>
    /// It is a mean of block_size × block_size pixel neighborhood, subtracted by param1.
    /// </summary>
    MeanC = 0,

    /// <summary>
    /// it is a weighted sum (Gaussian) of block_size × block_size pixel neighborhood, subtracted by param1.
    /// </summary>
    GaussianC = 1,
}
