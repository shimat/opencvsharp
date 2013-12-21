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
	/// cvSubdiv2DGetEdgeの戻り値とする辺の条件
	/// </summary>
#else
    /// <summary>
    /// Specifies, which of related edges to return
    /// </summary>
#endif
    public enum CvNextEdgeType : int
    {
#if LANG_JP
		/// <summary>
		/// 入力された辺の始点の近傍にある次の辺（eが入力のとき，上図のeOnext）
        /// [CV_NEXT_AROUND_ORG]
		/// </summary>
#else
        /// <summary>
        /// Next around the edge origin (eOnext on the picture above if e is the input edge) 
        /// [CV_NEXT_AROUND_ORG]
        /// </summary>
#endif
        NextAroundOrg = CvConst.CV_NEXT_AROUND_ORG,


#if LANG_JP
		/// <summary>
		/// 入力された辺の終点の近傍にある次の辺（eDnext） 
        /// [CV_NEXT_AROUND_DST]
		/// </summary>
#else
        /// <summary>
        /// Next around the edge vertex (eDnext) 
        /// [CV_NEXT_AROUND_DST]
        /// </summary>
#endif
        NextAroundDst = CvConst.CV_NEXT_AROUND_DST,



#if LANG_JP
		/// <summary>
		/// 入力された辺の始点の近傍にある一つ前の辺（eRnext の反転）
        /// [CV_PREV_AROUND_ORG]
		/// </summary>
#else
        /// <summary>
        /// Previous around the edge origin (reversed eRnext) 
        /// [CV_PREV_AROUND_ORG]
        /// </summary>
#endif
        PrevAroundOrg = CvConst.CV_PREV_AROUND_ORG,


#if LANG_JP
		/// <summary>
		/// 入力された辺の終点の近傍にある一つ前の辺（eLnext の反転）
        /// [CV_PREV_AROUND_DST]
		/// </summary>
#else
        /// <summary>
        /// Previous around the edge destination (reversed eLnext) 
        /// [CV_PREV_AROUND_DST]
        /// </summary>
#endif
        PrevAroundDst = CvConst.CV_PREV_AROUND_DST,


#if LANG_JP
		/// <summary>
		/// 入力された辺を含む左面の次の辺 （eLnext）
        /// [CV_NEXT_AROUND_LEFT]
		/// </summary>
#else
        /// <summary>
        /// Next around the left facet (eLnext) 
        /// [CV_NEXT_AROUND_LEFT]
        /// </summary>
#endif
        NextAroundLeft = CvConst.CV_NEXT_AROUND_LEFT,


#if LANG_JP
		/// <summary>
		/// 入力された辺を含む右面の次の辺（eRnext） 
        /// [CV_NEXT_AROUND_RIGHT]
		/// </summary>
#else
        /// <summary>
        /// Next around the right facet (eRnext) 
        /// [CV_NEXT_AROUND_RIGHT]
        /// </summary>
#endif
        NextAroundRight = CvConst.CV_NEXT_AROUND_RIGHT,


#if LANG_JP
		/// <summary>
		/// 入力された辺を含む左面の一つ前の辺（eOnext の反転）
        /// [CV_PREV_AROUND_LEFT]
		/// </summary>
#else
        /// <summary>
        /// Previous around the left facet (reversed eOnext) 
        /// [CV_PREV_AROUND_LEFT]
        /// </summary>
#endif
        PrevAroundLeft = CvConst.CV_PREV_AROUND_LEFT,


#if LANG_JP
        /// <summary>
		/// 入力された辺を含む右面の一つ前の辺（eDnext の反転）
        /// [CV_PREV_AROUND_RIGHT]
		/// </summary>
#else
        /// <summary>
        /// Previous around the right facet (reversed eDnext) 
        /// [CV_PREV_AROUND_RIGHT]
        /// </summary>
#endif
        PrevAroundRight = CvConst.CV_PREV_AROUND_RIGHT,
    }
}
