/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region HaarDetectObjects
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="image">この画像の中からオブジェクトを検出する</param>
        /// <param name="cascade">Haar 分類器カスケード の内部表現</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="image">Image to detect objects in. </param>
        /// <param name="cascade">Haar classifier cascade in internal representation. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvAvgComp> HaarDetectObjects(CvArr image, CvHaarClassifierCascade cascade, CvMemStorage storage)
        {
            return HaarDetectObjects(image, cascade, storage, 1.1, 3, HaarDetectionType.Zero, new CvSize(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="image">この画像の中からオブジェクトを検出する</param>
        /// <param name="cascade">Haar 分類器カスケード の内部表現</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <param name="scaleFactor">スキャン毎に探索ウィンドウがスケーリングされる際のスケールファクタ． 例えばこの値が 1.1 ならば，ウィンドウが 10% 大きくなる</param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="image">Image to detect objects in. </param>
        /// <param name="cascade">Haar classifier cascade in internal representation. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <param name="scaleFactor">The factor by which the search window is scaled between the subsequent scans, for example, 1.1 means increasing window by 10%. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvAvgComp> HaarDetectObjects(CvArr image, CvHaarClassifierCascade cascade, CvMemStorage storage, double scaleFactor)
        {
            return HaarDetectObjects(image, cascade, storage, scaleFactor, 3, HaarDetectionType.Zero, new CvSize(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="image">この画像の中からオブジェクトを検出する</param>
        /// <param name="cascade">Haar 分類器カスケード の内部表現</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <param name="scaleFactor">スキャン毎に探索ウィンドウがスケーリングされる際のスケールファクタ． 例えばこの値が 1.1 ならば，ウィンドウが 10% 大きくなる</param>
        /// <param name="minNeighbors">（これから 1 を引いた値が）オブジェクトを構成する近傍矩形の最小数となる． min_neighbors-1 よりも少ない矩形しか含まないようなグループは全て棄却される． もし min_neighbors が 0 である場合，この関数はグループを一つも生成せず，候補となる矩形を全て返す．これはユーザがカスタマイズしたグループ化処理を適用したい場合に有用である． </param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="image">Image to detect objects in. </param>
        /// <param name="cascade">Haar classifier cascade in internal representation. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <param name="scaleFactor">The factor by which the search window is scaled between the subsequent scans, for example, 1.1 means increasing window by 10%. </param>
        /// <param name="minNeighbors">Minimum number (minus 1) of neighbor rectangles that makes up an object. All the groups of a smaller number of rectangles than min_neighbors-1 are rejected. If min_neighbors is 0, the function does not any grouping at all and returns all the detected candidate rectangles, which may be useful if the user wants to apply a customized grouping procedure. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvAvgComp> HaarDetectObjects(CvArr image, CvHaarClassifierCascade cascade, CvMemStorage storage, double scaleFactor, int minNeighbors)
        {
            return HaarDetectObjects(image, cascade, storage, scaleFactor, minNeighbors, HaarDetectionType.Zero, new CvSize(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="image">この画像の中からオブジェクトを検出する</param>
        /// <param name="cascade">Haar 分類器カスケード の内部表現</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <param name="scaleFactor">スキャン毎に探索ウィンドウがスケーリングされる際のスケールファクタ． 例えばこの値が 1.1 ならば，ウィンドウが 10% 大きくなる</param>
        /// <param name="minNeighbors">（これから 1 を引いた値が）オブジェクトを構成する近傍矩形の最小数となる． min_neighbors-1 よりも少ない矩形しか含まないようなグループは全て棄却される． もし min_neighbors が 0 である場合，この関数はグループを一つも生成せず，候補となる矩形を全て返す．これはユーザがカスタマイズしたグループ化処理を適用したい場合に有用である． </param>
        /// <param name="flags">処理モード</param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="image">Image to detect objects in. </param>
        /// <param name="cascade">Haar classifier cascade in internal representation. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <param name="scaleFactor">The factor by which the search window is scaled between the subsequent scans, for example, 1.1 means increasing window by 10%. </param>
        /// <param name="minNeighbors">Minimum number (minus 1) of neighbor rectangles that makes up an object. All the groups of a smaller number of rectangles than min_neighbors-1 are rejected. If min_neighbors is 0, the function does not any grouping at all and returns all the detected candidate rectangles, which may be useful if the user wants to apply a customized grouping procedure. </param>
        /// <param name="flags">Mode of operation. Currently the only flag that may be specified is CV_HAAR_DO_CANNY_PRUNING. If it is set, the function uses Canny edge detector to reject some image regions that contain too few or too much edges and thus can not contain the searched object. The particular threshold values are tuned for face detection and in this case the pruning speeds up the processing. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvAvgComp> HaarDetectObjects(CvArr image, CvHaarClassifierCascade cascade, CvMemStorage storage, double scaleFactor, int minNeighbors, HaarDetectionType flags)
        {
            return HaarDetectObjects(image, cascade, storage, scaleFactor, minNeighbors, flags, new CvSize(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 与えられた画像からオブジェクトを含む様な矩形領域を検出し，それらの領域を矩形の列として返す．
        /// </summary>
        /// <param name="image">この画像の中からオブジェクトを検出する</param>
        /// <param name="cascade">Haar 分類器カスケード の内部表現</param>
        /// <param name="storage">オブジェクト候補の矩形が得られた場合に，その矩形列を保存するメモリストレージ</param>
        /// <param name="scaleFactor">スキャン毎に探索ウィンドウがスケーリングされる際のスケールファクタ． 例えばこの値が 1.1 ならば，ウィンドウが 10% 大きくなる</param>
        /// <param name="minNeighbors">（これから 1 を引いた値が）オブジェクトを構成する近傍矩形の最小数となる． min_neighbors-1 よりも少ない矩形しか含まないようなグループは全て棄却される． もし min_neighbors が 0 である場合，この関数はグループを一つも生成せず，候補となる矩形を全て返す．これはユーザがカスタマイズしたグループ化処理を適用したい場合に有用である． </param>
        /// <param name="flags">処理モード</param>
        /// <param name="minSize">最小ウィンドウサイズ．デフォルトでは分類器の学習に用いられたサンプルのサイズが設定される（顔検出の場合は，~20×20）.</param>
        /// <returns>CvAvgCompを要素とするCvSeq</returns>
#else
        /// <summary>
        /// Finds rectangular regions in the given image that are likely to contain objects the cascade has been trained for and returns those regions as a sequence of rectangles.
        /// </summary>
        /// <param name="image">Image to detect objects in. </param>
        /// <param name="cascade">Haar classifier cascade in internal representation. </param>
        /// <param name="storage">Memory storage to store the resultant sequence of the object candidate rectangles. </param>
        /// <param name="scaleFactor">The factor by which the search window is scaled between the subsequent scans, for example, 1.1 means increasing window by 10%. </param>
        /// <param name="minNeighbors">Minimum number (minus 1) of neighbor rectangles that makes up an object. All the groups of a smaller number of rectangles than min_neighbors-1 are rejected. If min_neighbors is 0, the function does not any grouping at all and returns all the detected candidate rectangles, which may be useful if the user wants to apply a customized grouping procedure. </param>
        /// <param name="flags">Mode of operation. Currently the only flag that may be specified is CV_HAAR_DO_CANNY_PRUNING. If it is set, the function uses Canny edge detector to reject some image regions that contain too few or too much edges and thus can not contain the searched object. The particular threshold values are tuned for face detection and in this case the pruning speeds up the processing. </param>
        /// <param name="minSize">Minimum window size. By default, it is set to the size of samples the classifier has been trained on (~20×20 for face detection). </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvAvgComp> HaarDetectObjects(CvArr image, CvHaarClassifierCascade cascade, CvMemStorage storage, double scaleFactor, int minNeighbors, HaarDetectionType flags, CvSize minSize)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (cascade == null)
                throw new ArgumentNullException("cascade");
            if (storage == null)
                throw new ArgumentNullException("storage");
            IntPtr result = CvInvoke.cvHaarDetectObjects(image.CvPtr, cascade.CvPtr, storage.CvPtr, scaleFactor, minNeighbors, flags, minSize);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSeq<CvAvgComp>(result);
        }
        #endregion
        #region HoughCircles
        #region circle_storage = CvMemStorage
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="image">入力画像 （8ビット，シングルチャンネル，グレースケール）．</param>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel grayscale image. </param>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvCircleSegment> HoughCircles(CvArr image, CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist)
        {
            return HoughCircles(image, circleStorage, method, dp, minDist, 100, 100, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="image">入力画像 （8ビット，シングルチャンネル，グレースケール）．</param>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel grayscale image. </param>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvCircleSegment> HoughCircles(CvArr image, CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1)
        {
            return HoughCircles(image, circleStorage, method, dp, minDist, param1, 100, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="image">入力画像 （8ビット，シングルチャンネル，グレースケール）．</param>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <param name="param2">手法に応じた2番目のパラメータ． CV_HOUGH_GRADIENT の場合は，中心検出計算時の閾値．小さすぎると誤検出が多くなる．これに対応する値が大きい円から順に検出される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel grayscale image. </param>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <param name="param2">The second method-specific parameter. In case of CV_HOUGH_GRADIENT it is accumulator threshold at the center detection stage. The smaller it is, the more false circles may be detected. Circles, corresponding to the larger accumulator values, will be returned first. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvCircleSegment> HoughCircles(CvArr image, CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2)
        {
            return HoughCircles(image, circleStorage, method, dp, minDist, param1, param2, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="image">入力画像 （8ビット，シングルチャンネル，グレースケール）．</param>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <param name="param2">手法に応じた2番目のパラメータ． CV_HOUGH_GRADIENT の場合は，中心検出計算時の閾値．小さすぎると誤検出が多くなる．これに対応する値が大きい円から順に検出される．</param>
        /// <param name="minRadius">検出すべき円の最小半径．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel grayscale image. </param>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <param name="param2">The second method-specific parameter. In case of CV_HOUGH_GRADIENT it is accumulator threshold at the center detection stage. The smaller it is, the more false circles may be detected. Circles, corresponding to the larger accumulator values, will be returned first. </param>
        /// <param name="minRadius">Minimal radius of the circles to search for. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvCircleSegment> HoughCircles(CvArr image, CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius)
        {
            return HoughCircles(image, circleStorage, method, dp, minDist, param1, param2, minRadius, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="image">入力画像 （8ビット，シングルチャンネル，グレースケール）．</param>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <param name="param2">手法に応じた2番目のパラメータ． CV_HOUGH_GRADIENT の場合は，中心検出計算時の閾値．小さすぎると誤検出が多くなる．これに対応する値が大きい円から順に検出される．</param>
        /// <param name="minRadius">検出すべき円の最小半径．</param>
        /// <param name="maxRadius">検出すべき円の最大半径 デフォルトの最大半径は max(image_width, image_height) にセットされている．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel grayscale image. </param>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <param name="param2">The second method-specific parameter. In case of CV_HOUGH_GRADIENT it is accumulator threshold at the center detection stage. The smaller it is, the more false circles may be detected. Circles, corresponding to the larger accumulator values, will be returned first. </param>
        /// <param name="minRadius">Minimal radius of the circles to search for. </param>
        /// <param name="maxRadius">Maximal radius of the circles to search for. By default the maximal radius is set to max(image_width, image_height). </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvCircleSegment> HoughCircles(CvArr image, CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (circleStorage == null)
                throw new ArgumentNullException("circleStorage");
            IntPtr result = CvInvoke.cvHoughCircles(image.CvPtr, circleStorage.CvPtr, method, dp, minDist, param1, param2, minRadius, maxRadius);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSeq<CvCircleSegment>(result);
        }
        #endregion
        #region circle_storage = CvMat
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="image">入力画像 （8ビット，シングルチャンネル，グレースケール）．</param>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel grayscale image. </param>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvCircleSegment> HoughCircles(CvArr image, CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist)
        {
            return HoughCircles(image, circleStorage, method, dp, minDist, 100, 100, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="image">入力画像 （8ビット，シングルチャンネル，グレースケール）．</param>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel grayscale image. </param>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvCircleSegment> HoughCircles(CvArr image, CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1)
        {
            return HoughCircles(image, circleStorage, method, dp, minDist, param1, 100, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="image">入力画像 （8ビット，シングルチャンネル，グレースケール）．</param>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <param name="param2">手法に応じた2番目のパラメータ． CV_HOUGH_GRADIENT の場合は，中心検出計算時の閾値．小さすぎると誤検出が多くなる．これに対応する値が大きい円から順に検出される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel grayscale image. </param>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <param name="param2">The second method-specific parameter. In case of CV_HOUGH_GRADIENT it is accumulator threshold at the center detection stage. The smaller it is, the more false circles may be detected. Circles, corresponding to the larger accumulator values, will be returned first. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvCircleSegment> HoughCircles(CvArr image, CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2)
        {
            return HoughCircles(image, circleStorage, method, dp, minDist, param1, param2, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="image">入力画像 （8ビット，シングルチャンネル，グレースケール）．</param>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <param name="param2">手法に応じた2番目のパラメータ． CV_HOUGH_GRADIENT の場合は，中心検出計算時の閾値．小さすぎると誤検出が多くなる．これに対応する値が大きい円から順に検出される．</param>
        /// <param name="minRadius">検出すべき円の最小半径．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel grayscale image. </param>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <param name="param2">The second method-specific parameter. In case of CV_HOUGH_GRADIENT it is accumulator threshold at the center detection stage. The smaller it is, the more false circles may be detected. Circles, corresponding to the larger accumulator values, will be returned first. </param>
        /// <param name="minRadius">Minimal radius of the circles to search for. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvCircleSegment> HoughCircles(CvArr image, CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius)
        {
            return HoughCircles(image, circleStorage, method, dp, minDist, param1, param2, minRadius, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いてグレースケール画像中の円を検出する
        /// </summary>
        /// <param name="image">入力画像 （8ビット，シングルチャンネル，グレースケール）．</param>
        /// <param name="circleStorage">検出された円を保存するメモリストレージ</param>
        /// <param name="method">現状では，CV_HOUGH_GRADIENT（基本的な2段階のハフ変換）のみ実装されている. </param>
        /// <param name="dp">円の中心を求める際に用いられる計算時の解像度．例えば，この値が 1 の場合は，計算は入力画像と同じ解像度で行われる．2 の場合は，計算は幅・高さともに1/2の解像度になる，等． </param>
        /// <param name="minDist">円検出における中心座標間の最小間隔．この値が非常に小さい場合は，正しく抽出されるべき円の近傍に複数の間違った円が検出されることになる．また，逆に非常に大きい場合は，円検出に失敗する． </param>
        /// <param name="param1">手法に応じた1番目のパラメータ． CV_HOUGH_GRADIENT の場合は，Cannyのエッジ検出器で用いる二つの閾値の高い方の値 (低い方の値は，この値を1/2したものになる）．</param>
        /// <param name="param2">手法に応じた2番目のパラメータ． CV_HOUGH_GRADIENT の場合は，中心検出計算時の閾値．小さすぎると誤検出が多くなる．これに対応する値が大きい円から順に検出される．</param>
        /// <param name="minRadius">検出すべき円の最小半径．</param>
        /// <param name="maxRadius">検出すべき円の最大半径 デフォルトの最大半径は max(image_width, image_height) にセットされている．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds circles in grayscale image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel grayscale image. </param>
        /// <param name="circleStorage">The storage for the circles detected. It can be a memory storage or single row/single column matrix (CvMat*) of type CV_32FC3, to which the circles' parameters are written. </param>
        /// <param name="method">Currently, the only implemented method is CV_HOUGH_GRADIENT, which is basically 21HT</param>
        /// <param name="dp">Resolution of the accumulator used to detect centers of the circles. For example, if it is 1, the accumulator will have the same resolution as the input image, if it is 2 - accumulator will have twice smaller width and height, etc. </param>
        /// <param name="minDist">Minimum distance between centers of the detected circles. If the parameter is too small, multiple neighbor circles may be falsely detected in addition to a true one. If it is too large, some circles may be missed. </param>
        /// <param name="param1">The first method-specific parameter. In case of CV_HOUGH_GRADIENT it is the higher threshold of the two passed to Canny edge detector (the lower one will be twice smaller). </param>
        /// <param name="param2">The second method-specific parameter. In case of CV_HOUGH_GRADIENT it is accumulator threshold at the center detection stage. The smaller it is, the more false circles may be detected. Circles, corresponding to the larger accumulator values, will be returned first. </param>
        /// <param name="minRadius">Minimal radius of the circles to search for. </param>
        /// <param name="maxRadius">Maximal radius of the circles to search for. By default the maximal radius is set to max(image_width, image_height). </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvCircleSegment> HoughCircles(CvArr image, CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (circleStorage == null)
                throw new ArgumentNullException("circleStorage");
            IntPtr result = CvInvoke.cvHoughCircles(image.CvPtr, circleStorage.CvPtr, method, dp, minDist, param1, param2, minRadius, maxRadius);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSeq<CvCircleSegment>(result);
        }
        #endregion
        #endregion
        #region HoughLines2
#if LANG_JP
        /// <summary>
        /// ハフ（Hough）変換を用いて2値画像から直線を検出する
        /// </summary>
        /// <param name="image">入力画像（8ビット，シングルチャンネル，２値化画像）．確率的な手法の場合は，画像は関数内で変換される．</param>
        /// <param name="lineStorage">検出された線を保存するメモリストレージ. 関数によって線分のシーケンスがストレージ内につくられ，その参照が返される</param>
        /// <param name="method">ハフ変換の種類</param>
        /// <param name="rho">距離解像度（１ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位で計測）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds lines in binary image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel binary image. In case of probabilistic method the image is modified by the function. </param>
        /// <param name="lineStorage">The storage for the lines detected. It can be a memory storage or single row/single column matrix (CvMat*) of a particular type to which the lines' parameters are written. </param>
        /// <param name="method">The Hough transform variant.</param>
        /// <param name="rho">Distance resolution in pixel-related units. </param>
        /// <param name="theta">Angle resolution measured in radians. </param>
        /// <param name="threshold">Threshold parameter. A line is returned by the function if the corresponding accumulator value is greater than threshold. </param>
        /// <returns></returns>
#endif
        public static CvSeq HoughLines2(CvArr image, CvMemStorage lineStorage, HoughLinesMethod method, double rho, double theta, int threshold)
        {
            return HoughLines2(image, lineStorage, method, rho, theta, threshold, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ（Hough）変換を用いて2値画像から直線を検出する
        /// </summary>
        /// <param name="image">入力画像（8ビット，シングルチャンネル，２値化画像）．確率的な手法の場合は，画像は関数内で変換される．</param>
        /// <param name="lineStorage">検出された線を保存するメモリストレージ. 関数によって線分のシーケンスがストレージ内につくられ，その参照が返される</param>
        /// <param name="method">ハフ変換の種類</param>
        /// <param name="rho">距離解像度（１ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位で計測）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <param name="param1">各手法に応じた１番目のパラメータ．標準的ハフ変換では，使用しない（0）．確率的ハフ変換では，最小の線の長さ．マルチスケールハフ変換では， 距離解像度rhoの除数．（荒い距離解像度では rho であり，詳細な解像度では (rho / param1) となる）．</param>
        /// <param name="param2">各手法に応じた２番目のパラメータ．標準的ハフ変換では，使用しない（0）．確率的ハフ変換では，同一線上に存在する線分として扱う（つまり，それらを統合しても問題ない），二つの線分の最大の間隔． マルチスケールハフ変換では，角度解像度 thetaの除数． （荒い角度解像度では theta であり，詳細な解像度では (theta / param2) となる）． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds lines in binary image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel binary image. In case of probabilistic method the image is modified by the function. </param>
        /// <param name="lineStorage">The storage for the lines detected. It can be a memory storage or single row/single column matrix (CvMat*) of a particular type to which the lines' parameters are written. </param>
        /// <param name="method">The Hough transform variant.</param>
        /// <param name="rho">Distance resolution in pixel-related units. </param>
        /// <param name="theta">Angle resolution measured in radians. </param>
        /// <param name="threshold">Threshold parameter. A line is returned by the function if the corresponding accumulator value is greater than threshold. </param>
        /// <param name="param1">The first method-dependent parameter.</param>
        /// <param name="param2">The second method-dependent parameter.</param>
        /// <returns></returns>
#endif
        public static CvSeq HoughLines2(CvArr image, CvMemStorage lineStorage, HoughLinesMethod method, double rho, double theta, int threshold, double param1, double param2)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (lineStorage == null)
                throw new ArgumentNullException("lineStorage");
            IntPtr result = CvInvoke.cvHoughLines2(image.CvPtr, lineStorage.CvPtr, method, rho, theta, threshold, param1, param2);
            return new CvSeq(result);
        }
#if LANG_JP
        /// <summary>
        /// ハフ（Hough）変換を用いて2値画像から直線を検出する
        /// </summary>
        /// <param name="image">入力画像（8ビット，シングルチャンネル，２値化画像）．確率的な手法の場合は，画像は関数内で変換される．</param>
        /// <param name="lineStorage">検出された線を保存する1行の行列/1列の行列. 行列のヘッダは，そのcols か rowsが検出された線の数となるように，この関数によって変更される．もし実際の線の数が行列のサイズを超える場合は，線の最大可能数が返される（標準的ハフ変換の場合は 投票数でソートされる）．</param>
        /// <param name="method">ハフ変換の種類</param>
        /// <param name="rho">距離解像度（１ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位で計測）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds lines in binary image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel binary image. In case of probabilistic method the image is modified by the function. </param>
        /// <param name="lineStorage">The storage for the lines detected. It can be a memory storage or single row/single column matrix (CvMat*) of a particular type to which the lines' parameters are written. </param>
        /// <param name="method">The Hough transform variant.</param>
        /// <param name="rho">Distance resolution in pixel-related units. </param>
        /// <param name="theta">Angle resolution measured in radians. </param>
        /// <param name="threshold">Threshold parameter. A line is returned by the function if the corresponding accumulator value is greater than threshold. </param>
        /// <returns></returns>
#endif
        public static CvSeq HoughLines2(CvArr image, CvMat lineStorage, HoughLinesMethod method, double rho, double theta, int threshold)
        {
            return HoughLines2(image, lineStorage, method, rho, theta, threshold, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// ハフ（Hough）変換を用いて2値画像から直線を検出する
        /// </summary>
        /// <param name="image">入力画像（8ビット，シングルチャンネル，２値化画像）．確率的な手法の場合は，画像は関数内で変換される．</param>
        /// <param name="lineStorage">検出された線を保存する1行の行列/1列の行列. 行列のヘッダは，そのcols か rowsが検出された線の数となるように，この関数によって変更される．もし実際の線の数が行列のサイズを超える場合は，線の最大可能数が返される（標準的ハフ変換の場合は 投票数でソートされる）．</param>
        /// <param name="method">ハフ変換の種類</param>
        /// <param name="rho">距離解像度（１ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位で計測）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <param name="param1">各手法に応じた１番目のパラメータ．標準的ハフ変換では，使用しない（0）．確率的ハフ変換では，最小の線の長さ．マルチスケールハフ変換では， 距離解像度rhoの除数．（荒い距離解像度では rho であり，詳細な解像度では (rho / param1) となる）．</param>
        /// <param name="param2">各手法に応じた２番目のパラメータ．標準的ハフ変換では，使用しない（0）．確率的ハフ変換では，同一線上に存在する線分として扱う（つまり，それらを統合しても問題ない），二つの線分の最大の間隔． マルチスケールハフ変換では，角度解像度 thetaの除数． （荒い角度解像度では theta であり，詳細な解像度では (theta / param2) となる）． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds lines in binary image using Hough transform.
        /// </summary>
        /// <param name="image">The input 8-bit single-channel binary image. In case of probabilistic method the image is modified by the function. </param>
        /// <param name="lineStorage">The storage for the lines detected. It can be a memory storage or single row/single column matrix (CvMat*) of a particular type to which the lines' parameters are written. </param>
        /// <param name="method">The Hough transform variant.</param>
        /// <param name="rho">Distance resolution in pixel-related units. </param>
        /// <param name="theta">Angle resolution measured in radians. </param>
        /// <param name="threshold">Threshold parameter. A line is returned by the function if the corresponding accumulator value is greater than threshold. </param>
        /// <param name="param1">The first method-dependent parameter.</param>
        /// <param name="param2">The second method-dependent parameter.</param>
        /// <returns></returns>
#endif
        public static CvSeq HoughLines2(CvArr image, CvMat lineStorage, HoughLinesMethod method, double rho, double theta, int threshold, double param1, double param2)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (lineStorage == null)
                throw new ArgumentNullException("lineStorage");
            IntPtr result = CvInvoke.cvHoughLines2(image.CvPtr, lineStorage.CvPtr, method, rho, theta, threshold, param1, param2);
            return new CvSeq(result);
        }
        #endregion
    }
}
