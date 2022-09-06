using System.Diagnostics.CodeAnalysis;

#pragma warning disable CA1008 // Enums should have zero value
#pragma warning disable CA1027 // Mark enums with FlagsAttribute

namespace OpenCvSharp;

/// <summary>
/// Type of the line
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/d3bc563c6e01c2bc153f23e7393322a95c7d3974/modules/imgproc/include/opencv2/imgproc.hpp#L808
/// </remarks>
[SuppressMessage("Microsoft.Design", "CA1717: Only FlagsAttribute enums should have plural names")]
public enum LineTypes
{
    /// <summary>
    /// 8-connected line.
    /// </summary>
    Link8 = 8,

    /// <summary>
    /// 4-connected line.
    /// </summary>
    Link4 = 4,

    /// <summary>
    /// Anti-aliased line. 
    /// </summary>
    AntiAlias = 16
}
