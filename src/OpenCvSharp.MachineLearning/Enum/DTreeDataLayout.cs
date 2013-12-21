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
	/// 決定木のデータレイアウト
	/// </summary>
#else
	/// <summary>
	/// Data layout of decision tree
	/// </summary>
#endif
	public enum DTreeDataLayout : int
	{
#if LANG_JP
		/// <summary>
		/// 
		/// [CV_ROW_SAMPLE]
		/// </summary>
#else
		/// <summary>
		/// 
		/// [CV_ROW_SAMPLE]
		/// </summary>
#endif
		RowSample = 1,



#if LANG_JP
		/// <summary>
		/// 
		/// [CV_COL_SAMPLE]
		/// </summary>
#else
		/// <summary>
		/// 
		/// [CV_COL_SAMPLE]
		/// </summary>
#endif
		ColSample = 0,
	}
}
