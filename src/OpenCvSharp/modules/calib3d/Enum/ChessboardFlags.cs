using System;

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
    public enum ChessboardFlags 
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

#if LANG_JP
		/// <summary>
		/// 画像を二値化する際に，固定の閾値を使うのではなく，（画像の平均輝度値から計算される）適応的な閾値を用いる 
		/// </summary>
#else
        /// <summary>
        /// Use adaptive thresholding to convert the image to black-n-white, rather than a fixed threshold level (computed from the average image brightness).
        /// </summary>
#endif
        AdaptiveThresh = 1,


#if LANG_JP
		/// <summary>
		/// 固定閾値処理または適応的閾値処理を行う前に，cvNormalizeHistを用いて画像を正規化する 
		/// </summary>
#else
        /// <summary>
        /// Normalize the image using cvNormalizeHist before applying fixed or adaptive thresholding.
        /// </summary>
#endif
        NormalizeImage = 2,


#if LANG_JP
		/// <summary>
		/// 輪郭の探索 段階で抽出される間違った四角形を無視するために，追加基準(輪郭面積，周囲長，形は正方形など）を使用する 
		/// </summary>
#else
        /// <summary>
        /// Use additional criteria (like contour area, perimeter, square-like shape) to filter out false quads that are extracted at the contour retrieval stage.
        /// </summary>
#endif
        FilterQuads = 4,

        /// <summary>
        /// 
        /// </summary>
        FastCheck = 8
    }
}
