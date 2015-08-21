using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cv::imwrite, cv::imencode で用いるエンコードパラメータ
    /// </summary>
#else
    /// <summary>
    /// The format-specific save parameters for cv::imwrite and cv::imencode
    /// </summary>
#endif
    [Serializable]
    public class ImageEncodingParam
    {
#if LANG_JP
    /// <summary>
    /// エンコードの種類
    /// </summary>
#else
        /// <summary>
        /// format type ID
        /// </summary>
#endif
        public ImwriteFlags EncodingId { get; set; }

#if LANG_JP
    /// <summary>
    /// パラメータの値
    /// </summary>
#else
        /// <summary>
        /// value of parameter
        /// </summary>
#endif
        public int Value { get; set; }


#if LANG_JP
    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="id">エンコードの種類</param>
    /// <param name="value">パラメータの値</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">format type ID</param>
        /// <param name="value">value of parameter</param>
#endif
        public ImageEncodingParam(ImwriteFlags id, int value)
        {
            EncodingId = id;
            Value = value;
        }
    }
}
