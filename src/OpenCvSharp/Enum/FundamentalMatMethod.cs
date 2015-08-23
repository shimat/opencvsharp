using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// 基礎行列の計算手法
	/// </summary>
#else
    /// <summary>
    /// Method for computing the fundamental matrix 
    /// </summary>
#endif
    [Flags]
    public enum FundamentalMatMethod : int
    {
#if LANG_JP
		/// <summary>
		/// 7-pointアルゴリズム． N == 7 
		/// </summary>
#else
        /// <summary>
        /// for 7-point algorithm. N == 7 
        /// </summary>
#endif
        Point7 = 1,

#if LANG_JP
		/// <summary>
		/// 8-pointアルゴリズム． N > 8 
		/// </summary>
#else
        /// <summary>
        /// for 8-point algorithm. N >= 8 
        /// [CV_FM_8POINT]
        /// </summary>
#endif
        Point8 = 2,

#if LANG_JP
		/// <summary>
		/// LMedSアルゴリズム． N >= 8 
		/// </summary>
#else
        /// <summary>
        /// for LMedS algorithm. N > 8 
        /// </summary>
#endif
        LMedS = 4,


#if LANG_JP
		/// <summary>
		/// RANSAC アルゴリズム． N > 8 
        /// [CV_FM_RANSAC]
		/// </summary>
#else
        /// <summary>
        /// for RANSAC algorithm. N > 8 
        /// </summary>
#endif
        Ransac = 8,
    }
}
