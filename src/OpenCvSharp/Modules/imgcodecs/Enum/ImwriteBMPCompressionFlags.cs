namespace OpenCvSharp;

/// <summary>
/// Imwrite BMP specific values for the IMWRITE_BMP_COMPRESSION parameter key.
/// </summary>
public enum ImwriteBMPCompressionFlags
{
    /// <summary>
    /// Use BI_RGB. OpenCV v4.12.0 or before supports encoding with this compression only.
    /// </summary>
    Rgb = 0,

    /// <summary>
    /// Use BI_BITFIELDS. OpenCV v4.13.0 or later can support encoding with this compression. (only for 32 BPP images)
    /// </summary>
    Bitfields = 3
}
