using System;

namespace OpenCvSharp
{
#if LANG_JP
   	/// <summary>
	/// cvHaarDetectObjectsの処理モード
	/// </summary>
#else
    /// <summary>
    /// Modes of operation for cvHaarDetectObjects
    /// </summary>
#endif
    [Flags]
    public enum HaarDetectionType : int
    {
#if LANG_JP
		/// <summary>
        /// これがセットされると，関数は Canny エッジ検出器を 非常に多くのエッジを含む（あるいは非常に少ないエッジしか含まない） 画像領域を，
        /// 探索オブジェクトを含まない領域と見なして棄却する． 顔検出用には特別な閾値が調整されており，この場合，枝刈りにより処理が 高速化される．
        /// [CV_HAAR_DO_CANNY_PRUNING]
		/// </summary>
#else
        /// <summary>
        /// If it is set, the function uses Canny edge detector to reject some image regions that contain too few or too much edges and thus can not contain the searched object. 
        /// The particular threshold values are tuned for face detection and in this case the pruning speeds up the processing.
        /// [CV_HAAR_DO_CANNY_PRUNING]
        /// </summary>
#endif
        DoCannyPruning = 1,


#if LANG_JP
		/// <summary>
        /// スケーリングされる度に，関数は， 分類カスケード中の特徴の座標系を 「拡大」するのではなく，逆に画像を縮小する． 
        /// 現在は，単体でのみ用いることができるオプションである． つまり，このフラグは他のものと併用はできない．
        /// [CV_HAAR_SCALE_IMAGE]
		/// </summary>
#else
        /// <summary>
        /// For each scale factor used the function will downscale the image rather than "zoom" the feature coordinates in the classifier cascade. 
        /// Currently, the option can only be used alone, i.e. the flag can not be set together with the others.
        /// [CV_HAAR_SCALE_IMAGE]
        /// </summary>
#endif
        ScaleImage = 2,


#if LANG_JP
        /// <summary>
        /// これがセットされると，関数は，（もし存在すれば）画像中の最大のオブジェクトを検出する． つまり，出力シーケンスは一つ（あるいは 0）のエレメントを持つ．
        /// [CV_HAAR_FIND_BIGGEST_OBJECT]
		/// </summary>
#else
        /// <summary>
        /// If it is set, the function finds the largest object (if any) in the image. That is, the output sequence will contain one (or zero) element(s).
        /// [CV_HAAR_FIND_BIGGEST_OBJECT]
        /// </summary>
#endif
        FindBiggestObject = 4,


#if LANG_JP
        /// <summary>
        /// FindBiggestObject がセットされており，min_neighbors > 0 である場合にのみ利用されるべきである．
        /// このフラグがセットされると，関数は，現在のスケールにおいて， オブジェクトが検出（かつ，その近傍に充分に候補が検出）された後に，
        /// それより小さいサイズの候補を探索しなくなる． min_neighbors が固定されていると， 大抵の場合，このモードは通常のシングルオブジェクトモード
        /// （flags=FindBiggestObject）よりも不正確な（少しだけ大きい）オブジェクト矩形を返す． しかし，このモードはずっと高速であり，最大で10倍程度の速度差になる．
        /// 正確さを増すために，min_neighbors に大き な値を指定することができる． 
        /// [CV_HAAR_DO_ROUGH_SEARCH]
		/// </summary>
#else
        /// <summary>
        /// It should be used only when FindBiggestObject is set and min_neighbors > 0. 
        /// If the flag is set, the function does not look for candidates of a smaller size 
        /// as soon as it has found the object (with enough neighbor candidates) at the current scale. 
        /// Typically, when min_neighbors is fixed, the mode yields less accurate (a bit larger) object rectangle 
        /// than the regular single-object mode (flags=FindBiggestObject), 
        /// but it is much faster, up to an order of magnitude. A greater value of min_neighbors may be specified to improve the accuracy.
        /// [CV_HAAR_DO_ROUGH_SEARCH]
        /// </summary>
#endif
        DoRoughSearch = 8,
    }
}
