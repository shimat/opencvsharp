namespace OpenCvSharp.OptFlow;

/// <summary>
/// Descriptor types for the Global Patch Collider (GPC).
/// </summary>
public enum GPCDescType
{
    /// <summary>
    /// Better quality but slow.
    /// </summary>
    DCT = 0,

    /// <summary>
    /// Worse quality but much faster.
    /// </summary>
    WHT,
}
