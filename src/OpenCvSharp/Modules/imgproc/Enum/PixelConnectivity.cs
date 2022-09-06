#pragma warning disable CA1008 // Enums should have zero value
#pragma warning disable CA1027 // Mark enums with FlagsAttribute

namespace OpenCvSharp;

/// <summary>
/// PixelConnectivity for LineIterator
/// </summary>
public enum PixelConnectivity
{
    /// <summary>
    /// Connectivity 4 (N,S,E,W)
    /// </summary>
    Connectivity4 = 4,

    /// <summary>
    /// Connectivity 8 (N,S,E,W,NE,SE,SW,NW)
    /// </summary>
    Connectivity8 = 8,
}
