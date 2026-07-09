// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// Imwrite TIFF specific values for the IMWRITE_TIFF_COMPRESSION parameter key.
/// </summary>
public enum ImwriteTiffCompressionFlags
{
    /// <summary>
    /// dump mode
    /// </summary>
    None = 1,

    /// <summary>
    /// CCITT modified Huffman RLE
    /// </summary>
    CcittRle = 2,

    /// <summary>
    /// CCITT Group 3 fax encoding / CCITT T.4 (TIFF 6 name)
    /// </summary>
    CcittFax3 = 3,

    /// <summary>
    /// CCITT Group 4 fax encoding / CCITT T.6 (TIFF 6 name)
    /// </summary>
    CcittFax4 = 4,

    /// <summary>
    /// Lempel-Ziv &amp; Welch
    /// </summary>
    Lzw = 5,

    /// <summary>
    /// !6.0 JPEG
    /// </summary>
    OJpeg = 6,

    /// <summary>
    /// Deflate compression, as recognized by Adobe
    /// </summary>
    AdobeDeflate = 8,

    /// <summary>
    /// %JPEG DCT compression
    /// </summary>
    Jpeg = 7,

    /// <summary>
    /// !TIFF/FX T.85 JBIG compression
    /// </summary>
    T85 = 9,

    /// <summary>
    /// !TIFF/FX T.43 colour by layered JBIG compression
    /// </summary>
    T43 = 10,

    /// <summary>
    /// NeXT 2-bit RLE
    /// </summary>
    Next = 32766,

    /// <summary>
    /// #1 w/ word alignment
    /// </summary>
    CcittRleW = 32771,

    /// <summary>
    /// Macintosh RLE
    /// </summary>
    PackBits = 32773,

    /// <summary>
    /// ThunderScan RLE
    /// </summary>
    ThunderScan = 32809,

    /// <summary>
    /// IT8 CT w/padding
    /// </summary>
    It8CtPad = 32895,

    /// <summary>
    /// IT8 Linework RLE
    /// </summary>
    It8Lw = 32896,

    /// <summary>
    /// IT8 Monochrome picture
    /// </summary>
    It8Mp = 32897,

    /// <summary>
    /// IT8 Binary line art
    /// </summary>
    It8Bl = 32898,

    /// <summary>
    /// Pixar companded 10bit LZW
    /// </summary>
    PixarFilm = 32908,

    /// <summary>
    /// Pixar companded 11bit ZIP
    /// </summary>
    PixarLog = 32909,

    /// <summary>
    /// Deflate compression, legacy tag
    /// </summary>
    Deflate = 32946,

    /// <summary>
    /// Kodak DCS encoding
    /// </summary>
    Dcs = 32947,

    /// <summary>
    /// ISO JBIG
    /// </summary>
    Jbig = 34661,

    /// <summary>
    /// SGI Log Luminance RLE
    /// </summary>
    SgiLog = 34676,

    /// <summary>
    /// SGI Log 24-bit packed
    /// </summary>
    SgiLog24 = 34677,

    /// <summary>
    /// Leadtools JPEG2000
    /// </summary>
    Jp2000 = 34712,

    /// <summary>
    /// ESRI Lerc codec: https://github.com/Esri/lerc
    /// </summary>
    Lerc = 34887,

    /// <summary>
    /// LZMA2
    /// </summary>
    Lzma = 34925,

    /// <summary>
    /// ZSTD: not registered in Adobe-maintained registry
    /// </summary>
    Zstd = 50000,

    /// <summary>
    /// WEBP: not registered in Adobe-maintained registry
    /// </summary>
    Webp = 50001,

    /// <summary>
    /// JPEGXL: not registered in Adobe-maintained registry
    /// </summary>
    Jxl = 50002
}
