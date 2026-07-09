namespace OpenCvSharp;

/// <summary>
/// Imwrite TIFF specific values for the IMWRITE_TIFF_PREDICTOR parameter key.
/// </summary>
public enum ImwriteTiffPredictorFlags
{
    /// <summary>
    /// No prediction scheme used.
    /// </summary>
    None = 1,

    /// <summary>
    /// Horizontal differencing.
    /// </summary>
    Horizontal = 2,

    /// <summary>
    /// Floating point predictor.
    /// </summary>
    FloatingPoint = 3
}
