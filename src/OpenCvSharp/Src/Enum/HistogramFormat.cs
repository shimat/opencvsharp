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
	/// ヒストグラム表現フォーマット
	/// </summary>
#else
    /// <summary>
    /// Histogram representation format
    /// </summary>
#endif
    public enum HistogramFormat : int
    {
#if LANG_JP
		/// <summary>
		/// ヒストグラムデータが多次元で密な配列CvMatNDで表現されている 
        /// [CV_HIST_ARRAY]
		/// </summary>
#else
        /// <summary>
        /// Histogram data is represented as an multi-dimensional dense array CvMatND.
        /// [CV_HIST_ARRAY]
        /// </summary>
#endif
        Array = CvConst.CV_HIST_ARRAY,


#if LANG_JP
		/// <summary>
		/// ヒストグラムデータが多次元で疎な配列 CvSparseMat で表現されている 
        /// [CV_HIST_SPARSE]
		/// </summary>
#else
        /// <summary>
        /// Histogram data is represented as a multi-dimensional sparse array CvSparseMat. 
        /// [CV_HIST_SPARSE]
        /// </summary>
#endif
        Sparse = CvConst.CV_HIST_SPARSE,
    }
}
