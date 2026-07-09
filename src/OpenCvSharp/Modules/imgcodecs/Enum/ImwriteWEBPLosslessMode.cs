namespace OpenCvSharp;

/// <summary>
/// Imwrite WEBP specific values for the IMWRITE_WEBP_LOSSLESS_MODE parameter key.
/// </summary>
public enum ImwriteWEBPLosslessMode
{
    /// <summary>
    /// Lossy compression mode. Uses IMWRITE_WEBP_QUALITY to control compression. (Default)
    /// If IMWRITE_WEBP_QUALITY is not specified, it falls back to LosslessOn to maintain backward compatibility.
    /// </summary>
    LosslessOff = 0,

    /// <summary>
    /// Standard lossless compression. May modify or discard RGB values of fully transparent pixels to improve compression ratio.
    /// </summary>
    LosslessOn = 1,

    /// <summary>
    /// Exact lossless compression. Preserves all RGB data even for pixels with 0 alpha (equivalent to WebP's exact flag).
    /// </summary>
    LosslessPreserveColor = 2
}
