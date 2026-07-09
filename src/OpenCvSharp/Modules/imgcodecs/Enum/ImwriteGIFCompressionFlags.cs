namespace OpenCvSharp;

/// <summary>
/// Imwrite GIF specific values for the IMWRITE_GIF_QUALITY parameter key.
/// If larger than 3, it relates to the size of the color table.
/// </summary>
public enum ImwriteGIFCompressionFlags
{
    /// <summary>
    /// Fast, no dithering.
    /// </summary>
    FastNoDither = 1,

    /// <summary>
    /// Fast, Floyd-Steinberg dithering.
    /// </summary>
    FastFloydDither = 2,

    /// <summary>
    /// Color table size 8.
    /// </summary>
    ColorTableSize8 = 3,

    /// <summary>
    /// Color table size 16.
    /// </summary>
    ColorTableSize16 = 4,

    /// <summary>
    /// Color table size 32.
    /// </summary>
    ColorTableSize32 = 5,

    /// <summary>
    /// Color table size 64.
    /// </summary>
    ColorTableSize64 = 6,

    /// <summary>
    /// Color table size 128.
    /// </summary>
    ColorTableSize128 = 7,

    /// <summary>
    /// Color table size 256.
    /// </summary>
    ColorTableSize256 = 8
}
