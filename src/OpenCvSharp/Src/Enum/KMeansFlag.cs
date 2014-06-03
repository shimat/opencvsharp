using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// cvKMeans2の処理フラグ
	/// </summary>
#else
    /// <summary>
    /// Miscellaneous flags for cvKMeans2
    /// </summary>
#endif
    [Flags]
    public enum KMeansFlag : int
    {
#if LANG_JP
		/// <summary>
		/// 
        /// [= 0]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [= 0]
        /// </summary>
#endif
        Zero = 0,

#if LANG_JP
		/// <summary>
		/// 
        /// [KMEANS_RANDOM_CENTERS]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [KMEANS_RANDOM_CENTERS]
        /// </summary>
#endif
        RandomCenters = CvConst.KMEANS_RANDOM_CENTERS,

#if LANG_JP
		/// <summary>
		/// 
        /// [KMEANS_PP_CENTERS]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [KMEANS_PP_CENTERS]
        /// </summary>
#endif
        PpCenters = CvConst.KMEANS_PP_CENTERS,

#if LANG_JP
		/// <summary>
		/// 
        /// [CV_KMEANS_USE_INITIAL_LABELS]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [KMEANS_USE_INITIAL_LABELS]
        /// </summary>
#endif
        UseInitialLabels = CvConst.KMEANS_USE_INITIAL_LABELS,
    }
}
