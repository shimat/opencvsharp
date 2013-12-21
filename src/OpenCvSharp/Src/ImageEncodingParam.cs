using System;
using System.Collections.Generic;
using System.Text;

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
        public ImageEncodingID EncodingID { get; set; }
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
        public ImageEncodingParam(ImageEncodingID id, int value)
        {
            EncodingID = id;
            Value = value;
        }

    }

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
    public class JpegEncodingParam : ImageEncodingParam
    {
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="value">パラメータの値。0から100の値を取る（大きいほど高品質）。デフォルト値は95。</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">value of parameter, from 0 to 100 (the higher is the better), 95 by default.</param>
#endif
        public JpegEncodingParam(int value)
            : base(ImageEncodingID.JpegQuality, value)
        {
        }

    }

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
    public class PngEncodingParam : ImageEncodingParam
    {
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="value">パラメータの値。圧縮レベルを0から9の値で指定する（大きいほど高圧縮率で、かつ圧縮に時間を要する）。デフォルト値は3。</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">value of parameter, from 0 to 9 (the higher value means smaller size and longer compression time), 3 by default.</param>
#endif
        public PngEncodingParam(int value)
            : base(ImageEncodingID.PngCompression, value)
        {
        }

    }

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
    public class PxmEncodingParam : ImageEncodingParam
    {
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="value">パラメータの値。フォーマットをバイナリ(1)かアスキー(0)かで指定する。デフォルト値は1。</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">value of parameter. binary format flag, 0 or 1, 1 by default.</param>
#endif
        public PxmEncodingParam(int value)
            : base(ImageEncodingID.PxmBinary, value)
        {
        }

    }
}
