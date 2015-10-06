using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// ホモグラフィ行列を計算するための手法
	/// </summary>
#else
    /// <summary>
    /// The method used to computed homography matrix
    /// </summary>
#endif
    [Flags]
    public enum HomographyMethods : int
    {
#if LANG_JP
        /// <summary>
        /// 全ての点のペアを利用する標準的な手法
        /// </summary>
#else
        /// <summary>
        /// Regular method using all the point pairs
        /// </summary>
#endif
        None = 0,


#if LANG_JP
        /// <summary>
        /// LMedS推定によるロバストな手法
        /// </summary>
#else
        /// <summary>
        /// Least-Median robust method
        /// </summary>
#endif
        LMedS = 4,


#if LANG_JP
        /// <summary>
        /// RANSACアルゴリズムに基づくロバストな手法
        /// </summary>
#else
        /// <summary>
        /// RANSAC-based robust method
        /// </summary>
#endif
        Ransac = 8,

        /// <summary>
        /// RHO algorithm
        /// </summary>
        Rho = 16,
    }
}
