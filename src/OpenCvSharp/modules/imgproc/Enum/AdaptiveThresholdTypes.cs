
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// 適応的閾値処理で使用するアルゴリズムの種類
	/// </summary>
#else
    /// <summary>
    /// Adaptive thresholding algorithms
    /// </summary>
#endif
    public enum AdaptiveThresholdTypes : int
    {
#if LANG_JP
		/// <summary>
		/// 注目ピクセルの block_size × block_size 隣接領域の平均から，param1 を引いた値を閾値とする.
		/// </summary>
#else
        /// <summary>
        /// It is a mean of block_size × block_size pixel neighborhood, subtracted by param1.
        /// </summary>
#endif
        MeanC = 0,


#if LANG_JP
		/// <summary>
		/// 注目ピクセルの block_size × block_size 隣接領域の重み付き総和（ガウシアン）から param1 を引いた値を閾値とする. 
		/// </summary>
#else
        /// <summary>
        /// it is a weighted sum (Gaussian) of block_size × block_size pixel neighborhood, subtracted by param1.
        /// </summary>
#endif
        GaussianC = 1,
    }
}
