#pragma warning disable CA1008 // Enums should have zero value
#pragma warning disable CA2217 // Do not mark enums with FlagsAttribute

namespace OpenCvSharp;

/// <summary>
/// Mask size for distance transform
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/d3bc563c6e01c2bc153f23e7393322a95c7d3974/modules/imgproc/include/opencv2/imgproc.hpp#L312
/// </remarks>
[Flags]
public enum DistanceTransformMasks
{
    /// <summary>
    /// 3
    /// </summary>
    Mask3 = 3,

    /// <summary>
    /// 5
    /// </summary>
    Mask5 = 5,

    /// <summary>
    /// 
    /// </summary>
    Precise = 0,
}
