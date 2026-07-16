namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Enum of possible functions to calculate the distance between colors.
/// See https://en.wikipedia.org/wiki/Color_difference for details.
/// </summary>
public enum DistanceType
{
    /// <summary>
    /// The 1976 formula, the first formula that related a measured color difference to a known set of CIELAB coordinates.
    /// </summary>
    CIE76,

    /// <summary>
    /// The 1976 definition extended to address perceptual non-uniformities, for graphic arts.
    /// </summary>
    CIE94GraphicArts,

    /// <summary>
    /// The 1976 definition extended to address perceptual non-uniformities, for textiles.
    /// </summary>
    CIE94Textiles,

    /// <summary>
    /// The CIEDE2000 color difference formula.
    /// </summary>
    CIE2000,

    /// <summary>
    /// The Colour Measurement Committee difference measure (1984), based on the L*C*h color model, 1:1 weighting.
    /// </summary>
    CMC1To1,

    /// <summary>
    /// The Colour Measurement Committee difference measure (1984), based on the L*C*h color model, 2:1 weighting.
    /// </summary>
    CMC2To1,

    /// <summary>
    /// Euclidean distance of the RGB color space.
    /// </summary>
    RGB,

    /// <summary>
    /// Euclidean distance of the linear RGB color space.
    /// </summary>
    RGBL,
}
