namespace OpenCvSharp;

/// <summary>
/// Imwrite EXR specific values for the IMWRITE_EXR_COMPRESSION parameter key.
/// </summary>
public enum ImwriteEXRCompressionFlags
{
    /// <summary>
    /// No compression.
    /// </summary>
    No = 0,

    /// <summary>
    /// Run length encoding.
    /// </summary>
    Rle = 1,

    /// <summary>
    /// Zlib compression, one scan line at a time.
    /// </summary>
    Zips = 2,

    /// <summary>
    /// Zlib compression, in blocks of 16 scan lines.
    /// </summary>
    Zip = 3,

    /// <summary>
    /// Piz-based wavelet compression.
    /// </summary>
    Piz = 4,

    /// <summary>
    /// Lossy 24-bit float compression.
    /// </summary>
    Pxr24 = 5,

    /// <summary>
    /// Lossy 4-by-4 pixel block compression, fixed compression rate.
    /// </summary>
    B44 = 6,

    /// <summary>
    /// Lossy 4-by-4 pixel block compression, flat fields are compressed more.
    /// </summary>
    B44A = 7,

    /// <summary>
    /// Lossy DCT based compression, in blocks of 32 scanlines. Supported since OpenEXR 2.2.0.
    /// </summary>
    Dwaa = 8,

    /// <summary>
    /// Lossy DCT based compression, in blocks of 256 scanlines. Supported since OpenEXR 2.2.0.
    /// </summary>
    Dwab = 9
}
