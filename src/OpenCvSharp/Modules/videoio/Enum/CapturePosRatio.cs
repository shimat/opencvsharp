
#pragma warning disable 1591

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// ビデオファイル内の相対的な位置
    /// </summary>
#else
    /// <summary>
    /// Position in relative units
    /// </summary>
#endif
    public enum CapturePosAviRatio : int
    {
#if LANG_JP
        /// <summary>
        /// ファイルの最初
        /// </summary>
#else
        /// <summary>
        /// Start of the file
        /// </summary>
#endif
        Start = 0,

#if LANG_JP
        /// <summary>
        /// ファイルの最後
        /// </summary>
#else
        /// <summary>
        /// End of the file
        /// </summary>
#endif
        End = 1,
    }
}
