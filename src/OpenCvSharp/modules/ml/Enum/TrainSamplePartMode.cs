using System;

namespace OpenCvSharp.ML
{
#if LANG_JP
    /// <summary>
	/// 
	/// </summary>
#else
	/// <summary>
	/// 
	/// </summary>
#endif
    public enum TrainSamplePartMode : int
	{
#if LANG_JP
		/// <summary>
		/// [CV_COUNT]
		/// </summary>
#else
        /// <summary>
        /// [CV_COUNT]
		/// </summary>
#endif
		Count = 0,


#if LANG_JP
		/// <summary>
		/// [CV_PORTION]
		/// </summary>
#else
        /// <summary>
        /// [CV_PORTION]
		/// </summary>
#endif
		Portion = 1,
	}
}
