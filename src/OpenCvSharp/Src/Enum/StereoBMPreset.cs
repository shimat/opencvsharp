/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

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
