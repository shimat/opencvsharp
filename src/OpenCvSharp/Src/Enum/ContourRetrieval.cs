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
	/// 輪郭の抽出モード 
	/// </summary>
#else
    /// <summary>
    /// Approximation methods for cvFindContours
    /// </summary>
#endif
    public enum ContourRetrieval : int
    {
#if LANG_JP
		/// <summary>
		/// 最も外側の輪郭のみ抽出 
        /// [CV_RETR_EXTERNAL]
		/// </summary>
#else
        /// <summary>
        /// Retrieve only the extreme outer contours 
        /// [CV_RETR_EXTERNAL]
        /// </summary>
#endif
        External = CvConst.CV_RETR_EXTERNAL,


#if LANG_JP
		/// <summary>
		/// 全ての輪郭を抽出し，リストに追加 
        /// [CV_RETR_LIST]
		/// </summary>
#else
        /// <summary>
        /// Retrieve all the contours and puts them in the list 
        /// [CV_RETR_LIST]
        /// </summary>
#endif
        List = CvConst.CV_RETR_LIST,


#if LANG_JP
		/// <summary>
		/// 全ての輪郭を抽出し，二つのレベルを持つ階層構造を構成する．1番目のレベルは連結成分の外側の境界線，2番目のレベルは穴（連結成分の内側に存在する）の境界線 
        /// [CV_RETR_CCOMP]
		/// </summary>
#else
        /// <summary>
        /// Retrieve all the contours and organizes them into two-level hierarchy: top level are external boundaries of the components, second level are boundaries of the holes 
        /// [CV_RETR_CCOMP]
        /// </summary>
#endif
        CComp = CvConst.CV_RETR_CCOMP,


#if LANG_JP
		/// <summary>
		/// 全ての輪郭を抽出し，枝分かれした輪郭を完全に表現する階層構造を構成する 
        /// [CV_RETR_TREE]
		/// </summary>
#else
        /// <summary>
        /// Retrieve all the contours and reconstructs the full hierarchy of nested contours 
        /// [CV_RETR_TREE]
        /// </summary>
#endif
        Tree = CvConst.CV_RETR_TREE,
    }
}
