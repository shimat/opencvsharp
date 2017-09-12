
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// CvCaptureのキャプチャタイプ(カメラorファイル)
    /// </summary>
#else
    /// <summary>
    /// Capture type of CvCapture (Camera or AVI file)
    /// </summary>
#endif
    public enum CaptureType
    {
#if LANG_JP
        /// <summary>
        /// AVIファイルからのキャプチャ
        /// </summary>
#else
        /// <summary>
        /// Captures from an AVI file
        /// </summary>
#endif
        File,


#if LANG_JP
        /// <summary>
        /// カメラからのキャプチャ
        /// </summary>
#else
        /// <summary>
        /// Captures from digital camera
        /// </summary>
#endif
        Camera,


        /// <summary>
        /// 
        /// </summary>
        NotSpecified
    }
}
