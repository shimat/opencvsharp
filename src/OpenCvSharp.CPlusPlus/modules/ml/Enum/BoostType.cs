using System;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
	/// ブースティングの種類
	/// </summary>
#else
	/// <summary>
	/// Data layout of decision tree
	/// </summary>
#endif
	public enum BoostType : int
	{
#if LANG_JP
		/// <summary>
		/// Discrete AdaBoost
		/// [CvBoost::DISCRETE]
		/// </summary>
#else
		/// <summary>
		/// Discrete AdaBoost
		/// [CvBoost::DISCRETE]
		/// </summary>
#endif
		Discrete = 0,


#if LANG_JP
		/// <summary>
		/// Real AdaBoost
		/// [CvBoost::REAL]
		/// </summary>
#else
		/// <summary>
		/// Real AdaBoost
		/// [CvBoost::REAL]
		/// </summary>
#endif
		Real = 1,


#if LANG_JP
		/// <summary>
		/// LogitBoost
		/// [CvBoost::LOGIT]
		/// </summary>
#else
		/// <summary>
		/// LogitBoost
		/// [CvBoost::LOGIT]
		/// </summary>
#endif
		Logit = 2,

		
#if LANG_JP
		/// <summary>
		/// Gentle AdaBoost
		/// [CvBoost::GENTLE]
		/// </summary>
#else
		/// <summary>
		/// Gentle AdaBoost
		/// [CvBoost::GENTLE]
		/// </summary>
#endif
		Gentle = 3,
	}
}
