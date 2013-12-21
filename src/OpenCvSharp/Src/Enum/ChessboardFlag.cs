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
    /// cvFindChessboardCornersの処理フラグ
	/// </summary>
#else
    /// <summary>
    /// Various operation flags for cvFindChessboardCorners
    /// </summary>
#endif
    [Flags]
    public enum ChessboardFlag : int
    {
#if LANG_JP
		/// <summary>
		/// オプション無し
        /// [= 0]
		/// </summary>
#else
        /// <summary>
        /// No options
        /// </summary>
#endif
        Zero = 0,


#if LANG_JP
		/// <summary>
		/// 画像を二値化する際に，固定の閾値を使うのではなく，（画像の平均輝度値から計算される）適応的な閾値を用いる 
        /// [CV_CALIB_CB_ADAPTIVE_THRESH]
		/// </summary>
#else
        /// <summary>
        /// Use adaptive thresholding to convert the image to black-n-white, rather than a fixed threshold level (computed from the average image brightness).
        /// [CV_CALIB_CB_ADAPTIVE_THRESH]
        /// </summary>
#endif
        AdaptiveThresh = CvConst.CV_CALIB_CB_ADAPTIVE_THRESH,


#if LANG_JP
		/// <summary>
		/// 固定閾値処理または適応的閾値処理を行う前に，cvNormalizeHistを用いて画像を正規化する 
        /// [CV_CALIB_CB_NORMALIZE_IMAGE]
		/// </summary>
#else
        /// <summary>
        /// Normalize the image using cvNormalizeHist before applying fixed or adaptive thresholding.
        /// [CV_CALIB_CB_NORMALIZE_IMAGE]
        /// </summary>
#endif
        NormalizeImage = CvConst.CV_CALIB_CB_NORMALIZE_IMAGE,


#if LANG_JP
		/// <summary>
		/// 輪郭の探索 段階で抽出される間違った四角形を無視するために，追加基準(輪郭面積，周囲長，形は正方形など）を使用する 
        /// [CV_CALIB_CB_FILTER_QUADS]
		/// </summary>
#else
        /// <summary>
        /// Use additional criteria (like contour area, perimeter, square-like shape) to filter out false quads that are extracted at the contour retrieval stage.
        /// [CV_CALIB_CB_FILTER_QUADS]
        /// </summary>
#endif
        FilterQuads = CvConst.CV_CALIB_CB_FILTER_QUADS,
    }
}
