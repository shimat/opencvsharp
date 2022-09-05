namespace OpenCvSharp;

/// <summary>
/// Specifies how to flip the array
/// </summary>
public enum FlipMode
{
    /// <summary>
    /// means flipping around x-axis
    /// </summary>
    X = 0,

    /// <summary>
    /// means flipping around y-axis
    /// </summary>
    Y = 1,

    /// <summary>
    /// means flipping around both axises
    /// </summary>
    // ReSharper disable once InconsistentNaming
    XY = -1
}
