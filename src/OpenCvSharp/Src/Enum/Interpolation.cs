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
	/// 画像の補間方法
	/// </summary>
#else
    /// <summary>
    /// Interpolation method
    /// </summary>
#endif
    [Flags]
    public enum Interpolation : int
    {
#if LANG_JP
		/// <summary>
		/// 最近隣接補間 
        /// [CV_INTER_NN]
		/// </summary>
#else
        /// <summary>
        /// Nearest-neighbor interpolation, 
        /// [CV_INTER_NN]
        /// </summary>
#endif
        NearestNeighbor = CvConst.CV_INTER_NN,


#if LANG_JP
		/// <summary>
		/// バイリニア補間 
        /// [CV_INTER_LINEAR]
		/// </summary>
#else
        /// <summary>
        /// Bilinear interpolation (used by default) 
        /// [CV_INTER_LINEAR]
        /// </summary>
#endif
        Linear = CvConst.CV_INTER_LINEAR,


#if LANG_JP
		/// <summary>
		/// バイキュービック補間 
        /// [CV_INTER_CUBIC]
		/// </summary>
#else
        /// <summary>
        /// Bicubic interpolation. 
        /// [CV_INTER_CUBIC]
        /// </summary>
#endif
        Cubic = CvConst.CV_INTER_CUBIC,


#if LANG_JP
		/// <summary>
        /// ピクセル領域の関係を用いてリサンプリングする．画像縮小の際は，モアレの無い処理結果を得ることができる手法である．拡大の際は，CV_INTER_NN と同様 .
        /// [CV_INTER_AREA]
		/// </summary>
#else
        /// <summary>
        /// Resampling using pixel area relation. It is the preferred method for image decimation that gives moire-free results. In case of zooming it is similar to CV_INTER_NN method. 
        /// [CV_INTER_AREA]
        /// </summary>
#endif
        Area = CvConst.CV_INTER_AREA,


#if LANG_JP
		/// <summary>
		/// 出力画像の全ピクセルの値を埋める．対応ピクセルが入力画像外であるようなピクセルである場合は， fillvalがセットされる 
        /// [CV_WARP_FILL_OUTLIERS]
		/// </summary>
#else
        /// <summary>
        /// Fill all the destination image pixels. If some of them correspond to outliers in the source image, they are set to fillval. 
        /// [CV_WARP_FILL_OUTLIERS]
        /// </summary>
#endif
        FillOutliers = CvConst.CV_WARP_FILL_OUTLIERS,


#if LANG_JP
		/// <summary>
		/// このフラグは map_matrixが出力画像から入力画像への逆変換のための行列であることを意味するので，直接ピクセル補間に用いることができる．
        /// これがセットされていない場合，この関数は map_matrix を使って逆変換を計算する. 
        /// [CV_WARP_INVERSE_MAP]
		/// </summary>
#else
        /// <summary>
        /// Indicates that matrix is inverse transform from destination image to source and, 
        /// thus, can be used directly for pixel interpolation. Otherwise, the function finds the inverse transform from map_matrix. 
        /// [CV_WARP_INVERSE_MAP]
        /// </summary>
#endif
        InverseMap = CvConst.CV_WARP_INVERSE_MAP,


        /// <summary>
        /// [INTER_LANCZOS4]
        /// </summary>
        Lanczos4 = CvConst.CV_INTER_LANCZOS4,

        /// <summary>
        /// [INTER_MAX]
        /// </summary>
        Max = 7,

    }
}
