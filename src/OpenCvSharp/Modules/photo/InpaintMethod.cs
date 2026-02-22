namespace OpenCvSharp;

/// <summary>
/// The inpainting method
/// </summary>
public enum InpaintTypes
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

/// <summary>
/// Obsolete: Use InpaintTypes instead. This enum is kept for backward compatibility.
/// </summary>
[Obsolete("Use InpaintTypes instead", false)]
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
