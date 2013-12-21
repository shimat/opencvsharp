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
	/// SVMパラメータの種類
	/// </summary>
#else
	/// <summary>
	/// SVM params type
	/// </summary>
#endif
	public enum SVMParamType : int
	{
		/// <summary>
		/// [CvSVM::C]
		/// </summary>
		C = 0,
		/// <summary>
		/// [CvSVM::GAMMA]
		/// </summary>
		Gamma = 1,
		/// <summary>
		/// [CvSVM::P]
		/// </summary>
		P = 2,
		/// <summary>
		/// [CvSVM::NU]
		/// </summary>
		Nu = 3,
		/// <summary>
		/// [CvSVM::COEF]
		/// </summary>
		Coef = 4,
		/// <summary>
		/// [CvSVM::DEGREE]
		/// </summary>
		Degree = 5,
	}
}