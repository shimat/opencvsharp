
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// cvRandArrメソッド等で用いる, 分布のタイプ
	/// </summary>
#else
    /// <summary>
    /// Distribution type for cvRandArr, etc.
    /// </summary>
#endif
    public enum DistributionType : int
    {
#if LANG_JP
		/// <summary>
		/// 一様分布 
		/// </summary>
#else
        /// <summary>
        /// Uniform distribution
        /// </summary>
#endif
        Uniform = 0,


#if LANG_JP
		/// <summary>
		/// 正規分布（ガウス分布） 
		/// </summary>
#else
        /// <summary>
        /// Normal or Gaussian distribution
        /// </summary>
#endif
        Normal = 1,
    }
}
