using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cvFindDominantPointsの処理フラグ
	/// </summary>
#else
    /// <summary>
    /// Various operation flags for cvFindDominantPoints
    /// </summary>
#endif
    [Flags]
    public enum DominantsFlag : int
    {
#if LANG_JP
		/// <summary>
		///  
        /// [CV_DOMINANT_IPAN]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_DOMINANT_IPAN]
        /// </summary>
#endif
        IPAN = CvConst.CV_DOMINANT_IPAN,
    }
}
