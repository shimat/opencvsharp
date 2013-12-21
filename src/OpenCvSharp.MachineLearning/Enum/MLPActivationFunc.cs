/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.MachineLearning
{
#if LANG_JP
    /// <summary>
	/// 各ニューロンの活性化関数
	/// </summary>
#else
	/// <summary>
	/// Splitting criteria, used to choose optimal splits during a weak tree construction
	/// </summary>
#endif
	public enum MLPActivationFunc : int
	{
#if LANG_JP
		/// <summary>
		/// 
		/// [CvANN_MLP::IDENTITY]
		/// </summary>
#else
		/// <summary>
		/// 
		/// [CvANN_MLP::IDENTITY]
		/// </summary>
#endif
		Identity = 0,


#if LANG_JP
		/// <summary>
		/// 
		/// [CvANN_MLP::SIGMOID_SYM]
		/// </summary>
#else
		/// <summary>
		/// U
		/// [CvANN_MLP::SIGMOID_SYM]
		/// </summary>
#endif
		SigmoidSym = 1,


#if LANG_JP
		/// <summary>
		/// 
		/// [CvANN_MLP::GAUSSIAN]
		/// </summary>
#else
		/// <summary>
		/// 
		/// [CvANN_MLP::GAUSSIAN]
		/// </summary>
#endif
		Gaussian = 2,

	}
}
