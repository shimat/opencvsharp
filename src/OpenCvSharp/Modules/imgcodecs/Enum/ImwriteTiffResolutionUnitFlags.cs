namespace OpenCvSharp;

/// <summary>
/// Imwrite TIFF specific values for the IMWRITE_TIFF_RESUNIT parameter key.
/// </summary>
public enum ImwriteTiffResolutionUnitFlags
{
    /// <summary>
    /// No absolute unit of measurement.
    /// </summary>
    None = 1,

    /// <summary>
    /// Inch.
    /// </summary>
    Inch = 2,

    /// <summary>
    /// Centimeter.
    /// </summary>
    Centimeter = 3
}
