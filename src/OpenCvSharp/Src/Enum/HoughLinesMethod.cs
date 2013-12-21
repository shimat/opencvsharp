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
	/// cvHoughLines2で用いる、ハフ変換(直線検出)の種類
	/// </summary>
#else
    /// <summary>
    /// The Hough transform variant
    /// </summary>
#endif
    public enum HoughLinesMethod : int
    {
#if LANG_JP
		/// <summary>
		/// 標準的ハフ変換．
        /// 全ての線分は2つの浮動小数点値 (ρ, θ)で表される．ここでρ は点(0,0) から線分までの距離，θ はx軸と線分の法線が成す角度． 
        /// そのため，行列（作成されるシーケンス）は，CV_32FC2 タイプとなる．
        /// [CV_HOUGH_STANDARD]
		/// </summary>
#else
        /// <summary>
        /// Classical or standard Hough transform. 
        /// Every line is represented by two floating-point numbers (ρ, θ), where ρ is a distance between (0,0) point and the line, 
        /// and θ is the angle between x-axis and the normal to the line. 
        /// Thus, the matrix must be (the created sequence will be) of CV_32FC2 type. 
        /// [CV_HOUGH_STANDARD]
        /// </summary>
#endif
        Standard = CvConst.CV_HOUGH_STANDARD,


#if LANG_JP
		/// <summary>
		/// 確率的ハフ変換（画像に長い線が少ない場合に有効）．
        /// 全ての線を返すのではなく，線分を返す． 全ての線分は始点と終点で表され，行列（作成されるシーケンス）は，CV_32SC4 タイプとなる．
        /// [CV_HOUGH_PROBABILISTIC]
		/// </summary>
#else
        /// <summary>
        /// Probabilistic Hough transform (more efficient in case if picture contains a few long linear segments). 
        /// It returns line segments rather than the whole lines. Every segment is represented by starting and ending points, 
        /// and the matrix must be (the created sequence will be) of CV_32SC4 type. 
        /// [CV_HOUGH_PROBABILISTIC]
        /// </summary>
#endif
        Probabilistic = CvConst.CV_HOUGH_PROBABILISTIC,


#if LANG_JP
		/// <summary>
		/// マルチスケール型の古典的ハフ変換． 線は CV_HOUGH_STANDARD と同様の方法でエンコードされる． 
        /// [CV_HOUGH_MULTI_SCALE]
		/// </summary>
#else
        /// <summary>
        /// Multi-scale variant of classical Hough transform. The lines are encoded the same way as in HoughLinesMethod.Standard. 
        /// [CV_HOUGH_MULTI_SCALE]
        /// </summary>
#endif
        MultiScale = CvConst.CV_HOUGH_MULTI_SCALE,
    }
}
