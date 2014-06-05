
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// あらかじめ定義された, CreateStereoBMStateのパラメータのID．
	/// </summary>
#else
    /// <summary>
    /// ID of one of the pre-defined parameter sets for CreateStereoBMState
    /// </summary>
#endif
	public enum StereoBMPreset : int
	{
		/// <summary>
		/// [CV_STEREO_BM_BASIC]
		/// </summary>
		Basic = CvConst.CV_STEREO_BM_BASIC,
		/// <summary>
		/// [CV_STEREO_BM_FISH_EYE]
		/// </summary>
        FishEye = CvConst.CV_STEREO_BM_FISH_EYE,
		/// <summary>
		/// [CV_STEREO_BM_NARROW]
		/// </summary>
        Narrow = CvConst.CV_STEREO_BM_NARROW,
	};
}
