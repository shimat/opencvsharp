namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Type of the robust estimation algorithm used by <see cref="SACSegmentation"/>.
/// </summary>
public enum SacMethod
{
    /// <summary>
    /// The RANSAC algorithm described in @cite fischler1981random.
    /// </summary>
    SAC_METHOD_RANSAC = 0,
}
