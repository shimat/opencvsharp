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
	/// 
	/// </summary>
#else
	/// <summary>
	/// 
	/// </summary>
#endif
	public enum PartMode : int
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
