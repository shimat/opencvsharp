
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// cvHoughCirclesで用いる、ハフ変換(円検出)の種類
	/// </summary>
#else
    /// <summary>
    /// Methods for cvHoughCircles
    /// </summary>
#endif
	public enum HoughCirclesMethod : int
    {
#if LANG_JP
		/// <summary>
		/// 基本的な2段階のハフ変換 
        /// [CV_HOUGH_GRADIENT]
		/// </summary>
#else
        /// <summary> 
        /// [CV_HOUGH_GRADIENT]
        /// </summary>
#endif
        Gradient = CvConst.CV_HOUGH_GRADIENT,
	};
}
