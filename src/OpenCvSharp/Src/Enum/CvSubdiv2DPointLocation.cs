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
	/// cvSubdiv2DLocateによる点の配置の種類
	/// </summary>
#else
    /// <summary>
    /// Kinds of locating point for cvSubdiv2DLocate
    /// </summary>
#endif
    public enum CvSubdiv2DPointLocation
    {
#if LANG_JP
		/// <summary>
		/// 入力の引数が正しくない 
        /// [CV_PTLOC_ERROR]
		/// </summary>
#else
        /// <summary>
        /// One of input arguments is invalid. Runtime error is raised or, if silent or "parent" error processing mode is selected
        /// [CV_PTLOC_ERROR]
        /// </summary>
#endif
        Error = CvConst.CV_PTLOC_ERROR,


#if LANG_JP
		/// <summary>
		/// 点は細分割平面の参照矩形の外にある 
        /// [CV_PTLOC_OUTSIDE_RECT]
		/// </summary>
#else
        /// <summary>
        /// Point is outside the subdivision reference rectangle.
        /// [CV_PTLOC_OUTSIDE_RECT]
        /// </summary>
#endif
        OutsideRect = CvConst.CV_PTLOC_OUTSIDE_RECT,


#if LANG_JP
		/// <summary>
		/// 点は小平面内に存在する 
        /// [CV_PTLOC_INSIDE]
		/// </summary>
#else
        /// <summary>
        /// Point falls into some facet.
        /// [CV_PTLOC_INSIDE]
        /// </summary>
#endif
        Inside = CvConst.CV_PTLOC_INSIDE,


#if LANG_JP
		/// <summary>
		/// 点は細分割平面内の頂点と一致する 
        /// [CV_PTLOC_VERTEX]
		/// </summary>
#else
        /// <summary>
        /// Point coincides with one of subdivision vertices. 
        /// [CV_PTLOC_VERTEX]
        /// </summary>
#endif
        Vertex = CvConst.CV_PTLOC_VERTEX,


#if LANG_JP
		/// <summary>
		/// 点は辺上に存在する 
        /// [CV_PTLOC_ON_EDGE]
		/// </summary>
#else
        /// <summary>
        /// Point falls onto the edge.
        /// [CV_PTLOC_ON_EDGE]
        /// </summary>
#endif
        OnEdge = CvConst.CV_PTLOC_ON_EDGE,
    }
}
