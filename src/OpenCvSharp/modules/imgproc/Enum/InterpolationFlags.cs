using System;

namespace OpenCvSharp
{
#if LANG_JP
   	/// <summary>
	/// 画像の補間方法
	/// </summary>
#else
    /// <summary>
    /// Interpolation algorithm
    /// </summary>
#endif
    [Flags]
    public enum InterpolationFlags : int
    {
#if LANG_JP
		/// <summary>
		/// 最近隣接補間 
		/// </summary>
#else
        /// <summary>
        /// Nearest-neighbor interpolation, 
        /// </summary>
#endif
        Nearest = 0,

#if LANG_JP
		/// <summary>
		/// バイリニア補間 
		/// </summary>
#else
        /// <summary>
        /// Bilinear interpolation (used by default) 
        /// </summary>
#endif
        Linear = 1,
        
#if LANG_JP
		/// <summary>
		/// バイキュービック補間 
		/// </summary>
#else
        /// <summary>
        /// Bicubic interpolation. 
        /// </summary>
#endif
        Cubic = 2,

#if LANG_JP
		/// <summary>
        /// ピクセル領域の関係を用いてリサンプリングする．画像縮小の際は，モアレの無い処理結果を得ることができる手法である．拡大の際は，CV_INTER_NN と同様 .
		/// </summary>
#else
        /// <summary>
        /// Resampling using pixel area relation. It is the preferred method for image decimation that gives moire-free results. In case of zooming it is similar to CV_INTER_NN method. 
        /// </summary>
#endif
        Area = 3,
        
        /// <summary>
        /// Lanczos interpolation over 8x8 neighborhood
        /// </summary>
        Lanczos4 = 4,

        /// <summary>
        /// mask for interpolation codes
        /// </summary>
        Max = 7,

#if LANG_JP
		/// <summary>
		/// 出力画像の全ピクセルの値を埋める．対応ピクセルが入力画像外であるようなピクセルである場合は， fillvalがセットされる 
		/// </summary>
#else
        /// <summary>
        /// Fill all the destination image pixels. If some of them correspond to outliers in the source image, they are set to fillval. 
        /// </summary>
#endif
        WarpFillOutliers = 8,

#if LANG_JP
		/// <summary>
		/// このフラグは map_matrixが出力画像から入力画像への逆変換のための行列であることを意味するので，直接ピクセル補間に用いることができる．
        /// これがセットされていない場合，この関数は map_matrix を使って逆変換を計算する. 
		/// </summary>
#else
        /// <summary>
        /// Indicates that matrix is inverse transform from destination image to source and, 
        /// thus, can be used directly for pixel interpolation. Otherwise, the function finds the inverse transform from map_matrix. 
        /// </summary>
#endif
        WarpInverseMap = 16,
    }
}
