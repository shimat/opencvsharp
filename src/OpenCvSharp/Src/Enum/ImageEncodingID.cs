/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

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
    public enum ImageEncodingID : int
    {
#if LANG_JP
		/// <summary>
		/// JPEGの場合のフラグ。0から100の値を取る（大きいほど高品質）。デフォルト値は95。
        /// [CV_IMWRITE_JPEG_QUALITY]
		/// </summary>
#else
        /// <summary>
        /// In the case of JPEG it can be a quality, from 0 to 100 (the higher is the better), 95 by default.
        /// [CV_IMWRITE_JPEG_QUALITY]
        /// </summary>
#endif
        JpegQuality = CvConst.CV_IMWRITE_JPEG_QUALITY,

#if LANG_JP
		/// <summary>
		/// PNGの場合のフラグ。圧縮レベルを0から9の値で指定する（大きいほど高圧縮率で、かつ圧縮に時間を要する）。デフォルト値は3。
        /// [CV_IMWRITE_PNG_COMPRESSION]
		/// </summary>
#else
        /// <summary>
        /// In the case of PNG it can be the compression level, from 0 to 9 (the higher value means smaller size and longer compression time), 3 by default.
        /// [CV_IMWRITE_PNG_COMPRESSION]
        /// </summary>
#endif
        PngCompression = CvConst.CV_IMWRITE_PNG_COMPRESSION,

#if LANG_JP
		/// <summary>
		/// PPM, PGM, PBMの場合のフラグ。フォーマットをバイナリ(1)かアスキー(0)かで指定する。デフォルト値は1。
        /// [CV_IMWRITE_PXM_BINARY]
		/// </summary>
#else
        /// <summary>
        /// In the case of PPM, PGM or PBM it can a binary format flag, 0 or 1, 1 by default.
        /// [CV_IMWRITE_PXM_BINARY]
        /// </summary>
#endif
        PxmBinary = CvConst.CV_IMWRITE_PXM_BINARY,
    }
}
