using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// Shape of the structuring element
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/d3bc563c6e01c2bc153f23e7393322a95c7d3974/modules/imgproc/include/opencv2/imgproc.hpp#L231
/// </remarks>
[SuppressMessage("Microsoft.Design", "CA1717: Only FlagsAttribute enums should have plural names")]
public enum MorphShapes
{
    /// <summary>
    /// A rectangular element
    /// </summary>
    Rect = 0,

    /// <summary>
    /// A cross-shaped element
    /// </summary>
    Cross = 1,

    /// <summary>
    /// An elliptic element
    /// </summary>
    Ellipse = 2,
}
