
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// 輪郭の近似手法
	/// </summary>
#else
    /// <summary>
    /// Approximation method (for all the modes, except CV_RETR_RUNS, which uses built-in approximation). 
    /// </summary>
#endif
    public enum ContourApproximationModes : int
    {
#if LANG_JP
		/// <summary>
        /// [CHAIN_APPROX_NONE]
		/// </summary>
#else
        /// <summary>
        /// CHAIN_APPROX_NONE - translate all the points from the chain code into points; 
        /// </summary>
#endif
        ApproxNone = 1,


#if LANG_JP
		/// <summary>
        /// 水平・垂直・斜めの線分を圧縮し，それらの端点のみを残します．例えば，まっすぐな矩形の輪郭線は，4つの点にエンコードされます． [CV_CHAIN_APPROX_SIMPLE]
		/// </summary>
#else
        /// <summary>
        /// CHAIN_APPROX_SIMPLE - compress horizontal, vertical, and diagonal segments, that is, the function leaves only their ending points; 
        /// </summary>
#endif
        ApproxSimple = 2,


#if LANG_JP
		/// <summary>
        /// Teh-Chinチェーン近似アルゴリズムの1つを適用します． TehChin89 を参照してください． [CV_CHAIN_APPROX_TC89_L1]
		/// </summary>
#else
        /// <summary>
        /// CHAIN_APPROX_TC89_L1 - apply one of the flavors of Teh-Chin chain approximation algorithm. 
        /// </summary>
#endif
// ReSharper disable once InconsistentNaming
        ApproxTC89L1 = 3,


#if LANG_JP
		/// <summary>
        /// Teh-Chinチェーン近似アルゴリズムの1つを適用します． TehChin89 を参照してください． [CV_CHAIN_APPROX_TC89_KCOS]
		/// </summary>
#else
        /// <summary>
        /// CHAIN_APPROX_TC89_KCOS - apply one of the flavors of Teh-Chin chain approximation algorithm. 
        /// </summary>
#endif
// ReSharper disable once InconsistentNaming
        ApproxTC89KCOS = 4,
    }
}
