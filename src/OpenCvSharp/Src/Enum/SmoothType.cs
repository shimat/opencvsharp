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
	/// 平滑化の方法
	/// </summary>
#else
    /// <summary>
    /// Type of the smoothing operations
    /// </summary>
#endif
    public enum SmoothType : int
    {
#if LANG_JP
		/// <summary>
		/// スケーリングなしの単純平滑化。ピクセルのparam1*param2隣接の総和。
        /// [CV_BLUR_NO_SCALE]
		/// </summary>
#else
        /// <summary>
        /// (simple blur with no scaling) - for each pixel the result is a sum of pixels values in size1×size2 neighborhood of the pixel. 
        /// If the neighborhood size varies from pixel to pixel, compute the sums using integral image (cvIntegral). 
        /// [CV_BLUR_NO_SCALE]
        /// </summary>
#endif
        BlurNoScale = CvConst.CV_BLUR_NO_SCALE,


#if LANG_JP
		/// <summary>
		/// 単純平滑化。ピクセルのparam1*param2隣接の総和を計算した後、1/(param1*param2)によってスケーリングする。
        /// [CV_BLUR]
		/// </summary>
#else
        /// <summary>
        /// (simple blur) - for each pixel the result is the average value (brightness/color) of size1×size2 neighborhood of the pixel. 
        /// [CV_BLUR]
        /// </summary>
#endif
        Blur = CvConst.CV_BLUR,


#if LANG_JP
		/// <summary>
		/// ガウシアン平滑化。画像とサイズparam1*param2のガウシアンカーネルの畳み込み。
        /// [CV_GAUSSIAN]
		/// </summary>
#else
        /// <summary>
        /// (Gaussian blur) - the image is smoothed using the Gaussian kernel of aperture size size1×size2. sigma1 and sigma2 may optionally be used to specify shape of the kernel. 
        /// [CV_GAUSSIAN]
        /// </summary>
#endif
        Gaussian = CvConst.CV_GAUSSIAN,


#if LANG_JP
		/// <summary>
		/// 中央値平滑化。param1*param1隣接の中央値の取得。
        /// [CV_MEDIAN]
		/// </summary>
#else
        /// <summary>
        /// (median blur) - the image is smoothed using medial filter of size size1×size1 (i.e. only square aperture can be used). 
        /// That is, for each pixel the result is the median computed over size1×size1 neighborhood. 
        /// [CV_MEDIAN]
        /// </summary>
#endif
        Median = CvConst.CV_MEDIAN,

#if LANG_JP
		/// <summary>
		/// エッジ保持平滑化フィルタ。色(輝度値)についてsigma=param1と領域(距離)についてsigma=param2を持つ3*3のバイラテラルフィルタを適用する。
        /// [CV_BILATERAL]
		/// </summary>
#else
        /// <summary>
        /// (bilateral filter) - the image is smoothed using a bilateral 3x3 filter with color sigma=sigma1 and spatial sigma=sigma2. 
        /// If size1!=0, then a circular kernel with diameter size1 is used; otherwise the diameter of the kernel is computed from sigma2.
        /// [CV_BILATERAL]
        /// </summary>
#endif
        Bilateral = CvConst.CV_BILATERAL,
    }
}
