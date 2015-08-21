
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// cv::imwrite, cv::inencode で用いるエンコードの種類
	/// </summary>
#else
    /// <summary>
    /// The format type IDs for cv::imwrite and cv::inencode
    /// </summary>
#endif
    public enum ImwriteFlags : int
    {
#if LANG_JP
    /// <summary>
    /// JPEGの場合のフラグ。0から100の値を取る（大きいほど高品質）。デフォルト値は95。
    /// </summary>
#else
        /// <summary>
        /// For JPEG, it can be a quality from 0 to 100 (the higher is the better). Default value is 95.
        /// </summary>
#endif
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

#if LANG_JP
    /// <summary>
    /// PNGの場合のフラグ。圧縮レベルを0から9の値で指定する（大きいほど高圧縮率で、かつ圧縮に時間を要する）。デフォルト値は3。
    /// </summary>
#else
        /// <summary>
        /// For PNG, it can be the compression level from 0 to 9. 
        /// A higher value means a smaller size and longer compression time. Default value is 3.
        /// </summary>
#endif
        PngCompression = 16,

        /// <summary>
        /// One of cv::ImwritePNGFlags, default is IMWRITE_PNG_STRATEGY_DEFAULT.
        /// </summary>
        PngStrategy = 17,

        /// <summary>
        /// Binary level PNG, 0 or 1, default is 0.
        /// </summary>
        PngBilevel = 18,

#if LANG_JP
    /// <summary>
    /// PPM, PGM, PBMの場合のフラグ。フォーマットをバイナリ(1)かアスキー(0)かで指定する。デフォルト値は1。
    /// </summary>
#else
        /// <summary>
        /// For PPM, PGM, or PBM, it can be a binary format flag, 0 or 1. Default value is 1.
        /// </summary>
#endif
        PxmBinary = 32,

        /// <summary>
        /// For WEBP, it can be a quality from 1 to 100 (the higher is the better). By default (without any parameter) and for quality above 100 the lossless compression is used.
        /// </summary>
        WebPQuality = 64
    }
}
