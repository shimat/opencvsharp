namespace OpenCvSharp
{
#if LANG_JP
	/// <summary>
	/// cvCompareHistで用いる、CvHistogramの比較方法
	/// </summary>
#else
    /// <summary>
    /// Comparison methods for cvCompareHist
    /// </summary>
#endif
    public enum HistCompMethods : int
    {
#if LANG_JP
		/// <summary>
		/// 相関 [CV_COMP_CORREL]
		/// </summary>
#else
        /// <summary>
        /// Correlation [CV_COMP_CORREL]
        /// </summary>
#endif
        Correl = 0,


#if LANG_JP
		/// <summary>
		/// カイ二乗 [CV_COMP_CHISQR]
		/// </summary>
#else
        /// <summary>
        /// Chi-Square [CV_COMP_CHISQR]
        /// </summary>
#endif
        Chisqr = 1,


#if LANG_JP
		/// <summary>
		/// 交差 [CV_COMP_INTERSECT]
		/// </summary>
#else
        /// <summary>
        /// Intersection [CV_COMP_INTERSECT]
        /// </summary>
#endif
        Intersect = 2,


#if LANG_JP
		/// <summary>
		/// Bhattacharyya距離 [CV_COMP_BHATTACHARYYA]. 正規化されたヒストグラムでのみ実行可能である．
		/// </summary>
#else
        /// <summary>
        /// Bhattacharyya distance [CV_COMP_BHATTACHARYYA]
        /// </summary>
#endif
        Bhattacharyya = 3,

        /// <summary>
        /// Synonym for HISTCMP_BHATTACHARYYA
        /// </summary>
        Hellinger = Bhattacharyya,

        /// <summary>
        /// Alternative Chi-Square
        /// \f[d(H_1,H_2) =  2 * \sum _I  \frac{\left(H_1(I)-H_2(I)\right)^2}{H_1(I)+H_2(I)}\f] 
        /// This alternative formula is regularly used for texture comparison. See e.g. @cite Puzicha1997 
        /// </summary>
        ChisqrAlt = 4,

        /// <summary>
        /// Kullback-Leibler divergence 
        /// \f[d(H_1,H_2) = \sum _I H_1(I) \log \left(\frac{H_1(I)}{H_2(I)}\right)\f] 
        /// </summary>
// ReSharper disable once InconsistentNaming
        KLDiv = 5
    }
}
