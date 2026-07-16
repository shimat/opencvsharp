namespace OpenCvSharp;

/// <summary>
/// Linearization transformation type.
/// </summary>
public enum LinearizationType
{
    /// <summary>
    /// No change is made.
    /// </summary>
    Identity,

    /// <summary>
    /// Gamma correction; needs a value assigned to gamma simultaneously.
    /// </summary>
    Gamma,

    /// <summary>
    /// Polynomial fitting channels respectively; needs a value assigned to the degree simultaneously.
    /// </summary>
    ColorPolyFit,

    /// <summary>
    /// Logarithmic polynomial fitting channels respectively; needs a value assigned to the degree simultaneously.
    /// </summary>
    ColorLogPolyFit,

    /// <summary>
    /// Grayscale polynomial fitting; needs a value assigned to the degree and dst_whites simultaneously.
    /// </summary>
    GrayPolyFit,

    /// <summary>
    /// Grayscale logarithmic polynomial fitting; needs a value assigned to the degree and dst_whites simultaneously.
    /// </summary>
    GrayLogPolyFit,
}
