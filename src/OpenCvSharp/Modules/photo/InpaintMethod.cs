namespace OpenCvSharp;

/// <summary>
/// The inpainting method
/// </summary>
public enum InpaintMethod
{
    /// <summary>
    /// Navier-Stokes based method.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    NS = 0,

    /// <summary>
    /// The method by Alexandru Telea
    /// </summary>
    Telea = 1,
}
