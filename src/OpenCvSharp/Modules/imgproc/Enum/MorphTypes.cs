#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp;

/// <summary>
/// Type of morphological operation
/// </summary>
public enum MorphTypes
{
    /// <summary>
    /// 
    /// </summary>
    Erode = 0,

    /// <summary>
    /// 
    /// </summary>
    Dilate = 1,

    /// <summary>
    /// an opening operation
    /// </summary>
    Open = 2,

    /// <summary>
    /// a closing operation
    /// </summary>
    Close = 3,

    /// <summary>
    /// Morphological gradient
    /// </summary>
    Gradient = 4,

    /// <summary>
    /// "Top hat"
    /// </summary>
    TopHat = 5,

    /// <summary>
    /// "Black hat"
    /// </summary>
    BlackHat = 6,

    /// <summary>
    /// "hit and miss"
    /// </summary>
    HitMiss = 7
}
