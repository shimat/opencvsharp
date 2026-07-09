#pragma warning disable CA1008 // Enums should have zero value
#pragma warning disable CA1027 // Mark enums with FlagsAttribute

namespace OpenCvSharp;

/// <summary>
/// The format type IDs for cv::imwrite and cv::inencode
/// </summary>
public enum ImwriteFlags
{
    /// <summary>
    /// For JPEG, it can be a quality from 0 to 100 (the higher is the better). Default value is 95.
    /// </summary>
    JpegQuality = 1,

    /// <summary>
    /// Enable JPEG features, 0 or 1, default is False.
    /// </summary>
    JpegProgressive = 2,

    /// <summary>
    /// Enable JPEG features, 0 or 1, default is False.
    /// </summary>
    JpegOptimize = 3,

    /// <summary>
    /// JPEG restart interval, 0 - 65535, default is 0 - no restart.
    /// </summary>
    JpegRstInterval = 4,

    /// <summary>
    /// Separate luma quality level, 0 - 100, default is 0 - don't use.
    /// </summary>
    JpegLumaQuality = 5,

    /// <summary>
    /// Separate chroma quality level, 0 - 100, default is 0 - don't use.
    /// </summary>
    JpegChromaQuality = 6,

    /// <summary>
    /// For JPEG, set sampling factor. See cv::ImwriteJPEGSamplingFactorParams.
    /// </summary>
    JpegSamplingFactor = 7,

    /// <summary>
    /// For PNG, it can be the compression level from 0 to 9.
    /// A higher value means a smaller size and longer compression time. Default value is 3.
    /// </summary>
    PngCompression = 16,

    /// <summary>
    /// One of cv::ImwritePNGFlags, default is IMWRITE_PNG_StrategyDEFAULT.
    /// </summary>
    PngStrategy = 17,

    /// <summary>
    /// Binary level PNG, 0 or 1, default is 0.
    /// </summary>
    PngBilevel = 18,

    /// <summary>
    /// For PNG, One of cv::ImwritePNGFilterFlags, default is IMWRITE_PNG_FILTER_SUB. For APNG, it is not supported.
    /// </summary>
    PngFilter = 19,

    /// <summary>
    /// For PNG with libpng, sets the size of the internal zlib compression buffer in bytes, from 6 to 1048576 (1024 KiB).
    /// Default is 8192 (8 KiB). If WITH_SPNG=ON, it is not supported. For APNG, it is not supported.
    /// </summary>
    PngZlibBufferSize = 20,

    /// <summary>
    /// For PPM, PGM, or PBM, it can be a binary format flag, 0 or 1. Default value is 1.
    /// </summary>
    PxmBinary = 32,

    /// <summary>
    /// [48] override EXR storage type (FLOAT (FP32) is default)
    /// </summary>
    ExrType = (3 << 4) + 0, /* 48 */ //!< override EXR storage type (FLOAT (FP32) is default)

    /// <summary>
    /// [49] override EXR compression type (ZIP_COMPRESSION = 3 is default)
    /// </summary>
    ExrCompression = (3 << 4) + 1, /* 49 */

    /// <summary>
    /// [50] override EXR DWA compression level (45 is default)
    /// </summary>
    ExrDwaCompressionLevel = (3 << 4) + 2, /* 50 */

    /// <summary>
    /// For WEBP, it can be a lossy quality from 1 to 100 (the higher is the better) for IMWRITE_WEBP_LOSSLESS_OFF.
    /// By default (without this parameter) or if quality &gt; 100, lossless compression is used instead.
    /// </summary>
    WebPQuality = 64,

    /// <summary>
    /// For WEBP, it can be a lossless compression strategy. See cv::ImwriteWEBPLosslessMode.
    /// Default is IMWRITE_WEBP_LOSSLESS_OFF. For Animated WEBP, it is not supported.
    /// </summary>
    WebPLosslessMode = 65,

    /// <summary>
    /// [80] Specify HDR compression. See cv::ImwriteHDRCompressionFlags.
    /// </summary>
    HdrCompression = (5 << 4) + 0, /* 80 */

    /// <summary>
    /// For PAM, sets the TUPLETYPE field to the corresponding string value that is defined for the format
    /// </summary>
    PamTupleType = 128,

    /// <summary>
    /// For TIFF, use to specify which DPI resolution unit to set; see libtiff documentation for valid values
    /// </summary>
    TiffResUnit = 256,

    /// <summary>
    /// For TIFF, use to specify the X direction DPI
    /// </summary>
    TiffXDpi = 257,

    /// <summary>
    /// For TIFF, use to specify the Y direction DPI
    /// </summary>
    TiffYDpi = 258,

    /// <summary>
    /// For TIFF, use to specify the image compression scheme.
    /// See libtiff for integer constants corresponding to compression formats.
    /// Note, for images whose depth is CV_32F, only libtiff's SGILOG compression scheme is used.
    /// For other supported depths, the compression scheme can be specified by this flag; LZW compression is the default.
    /// </summary>
    TiffCompression = 259,

    /// <summary>
    /// For TIFF, use to specify the number of rows per strip.
    /// </summary>
    TiffRowsPerStrip = 278,

    /// <summary>
    /// For TIFF, use to specify predictor. See cv::ImwriteTiffPredictorFlags. Default is IMWRITE_TIFF_PREDICTOR_HORIZONTAL.
    /// </summary>
    TiffPredictor = 317,

    /// <summary>
    /// For JPEG2000, use to specify the target compression rate (multiplied by 1000).
    /// The value can be from 0 to 1000. Default is 1000.
    /// </summary>
    Jpeg2000CompressionX1000 = 272,

    /// <summary>
    /// For AVIF, it can be a quality between 0 and 100 (the higher the better). Default is 95.
    /// </summary>
    AvifQuality = 512,

    /// <summary>
    /// For AVIF, it can be 8, 10 or 12. If &gt;8, it is stored/read as CV_16U. Default is 8.
    /// </summary>
    AvifDepth = 513,

    /// <summary>
    /// For AVIF, it is between 0 (slowest) and 10 (fastest). Default is 9.
    /// </summary>
    AvifSpeed = 514,

    /// <summary>
    /// For JPEG XL, it can be a quality from 0 to 100 (the higher is the better). Default value is 95.
    /// If set, distance parameter is re-calculated from quality level automatically. This parameter requires libjxl v0.10 or later.
    /// </summary>
    JpegXlQuality = 640,

    /// <summary>
    /// For JPEG XL, encoder effort/speed level without affecting decoding speed; it is between 1 (fastest) and 10 (slowest). Default is 7.
    /// </summary>
    JpegXlEffort = 641,

    /// <summary>
    /// For JPEG XL, distance level for lossy compression: target max butteraugli distance, lower = higher quality, 0 = lossless; range: 0..25. Default is 1.
    /// </summary>
    JpegXlDistance = 642,

    /// <summary>
    /// For JPEG XL, decoding speed tier for the provided options; minimum is 0 (slowest to decode, best quality/density),
    /// and maximum is 4 (fastest to decode, at the cost of some quality/density). Default is 0.
    /// </summary>
    JpegXlDecodingSpeed = 643,

    /// <summary>
    /// For BMP, use to specify compress parameter for 32bpp image. Default is IMWRITE_BMP_COMPRESSION_BITFIELDS.
    /// See cv::ImwriteBMPCompressionFlags.
    /// </summary>
    BmpCompression = 768,

    /// <summary>
    /// Not functional since 4.12.0. Replaced by cv::Animation::loop_count.
    /// </summary>
    GifLoop = 1024,

    /// <summary>
    /// Not functional since 4.12.0. Replaced by cv::Animation::durations.
    /// </summary>
    GifSpeed = 1025,

    /// <summary>
    /// For GIF, it can be a quality from 1 to 8. Default is 2. See cv::ImwriteGIFCompressionFlags.
    /// </summary>
    GifQuality = 1026,

    /// <summary>
    /// For GIF, it can be a quality from -1 (most dither) to 3 (no dither). Default is 0.
    /// </summary>
    GifDither = 1027,

    /// <summary>
    /// For GIF, the alpha channel lower than this will be set to transparent. Default is 1.
    /// </summary>
    GifTransparency = 1028,

    /// <summary>
    /// For GIF, 0 means global color table is used, 1 means local color table is used. Default is 0.
    /// </summary>
    GifColorTable = 1029
}
