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
        #region KalmanCorrect
#if LANG_JP
        /// <summary>
        /// モデル状態を修正する. 修正された状態を kalman->state_post に保存し，これを出力として返す．
        /// </summary>
        /// <param name="kalman">更新されるカルマンフィルタ状態</param>
        /// <param name="measurement">観測ベクトルを含むCvMat</param>
        /// <returns>修正された状態を kalman->state_post に保存し，これを出力として返す．</returns>
#else
        /// <summary>
        /// Adjusts model state
        /// </summary>
        /// <param name="kalman">Kalman filter</param>
        /// <param name="measurement">CvMat containing the measurement vector. </param>
        /// <returns>The function stores adjusted state at kalman->state_post and returns it on output.</returns>
#endif
        public static CvMat KalmanCorrect(CvKalman kalman, CvMat measurement)
        {
            if (kalman == null)
                throw new ArgumentNullException("kalman");
            if (measurement == null)
                throw new ArgumentNullException("measurement");
            IntPtr result = CvInvoke.cvKalmanCorrect(kalman.CvPtr, measurement.CvPtr);
            return new CvMat(result, false);
        }
#if LANG_JP
        /// <summary>
        /// モデル状態を修正する. 修正された状態を kalman->state_post に保存し，これを出力として返す．cvKalmanCorrectのエイリアス.
        /// </summary>
        /// <param name="kalman">更新されるカルマンフィルタ状態</param>
        /// <param name="measurement">観測ベクトルを含むCvMat</param>
        /// <returns>修正された状態を kalman->state_post に保存し，これを出力として返す．</returns>
#else
        /// <summary>
        /// Adjusts model state
        /// </summary>
        /// <param name="kalman">Kalman filter</param>
        /// <param name="measurement">CvMat containing the measurement vector. </param>
        /// <returns>The function stores adjusted state at kalman->state_post and returns it on output.</returns>
#endif
        public static CvMat KalmanUpdateByMeasurement(CvKalman kalman, CvMat measurement)
        {
            return KalmanCorrect(kalman, measurement);
        }
        #endregion
        #region KalmanPredict
#if LANG_JP
        /// <summary>
        /// 次のモデル状態を推定する.
        /// </summary>
        /// <param name="kalman">カルマンフィルタ状態</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Estimates subsequent model state
        /// </summary>
        /// <param name="kalman">Kalman filter state. </param>
        /// <returns>The function returns the estimated state. </returns>
#endif
        public static CvMat KalmanPredict(CvKalman kalman)
        {
            return KalmanPredict(kalman, null);
        }
#if LANG_JP
        /// <summary>
        /// 次のモデル状態を推定する
        /// </summary>
        /// <param name="kalman">カルマンフィルタ状態</param>
        /// <param name="control">コントロールベクトル (uk)．外部コントロールが存在しない場合（control_params=0）に限り，null である．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Estimates subsequent model state
        /// </summary>
        /// <param name="kalman">Kalman filter state. </param>
        /// <param name="control">Control vector (uk), should be null iff there is no external control (control_params=0).</param>
        /// <returns>The function returns the estimated state. </returns>
#endif
        public static CvMat KalmanPredict(CvKalman kalman, CvMat control)
        {
            if (kalman == null)
                throw new ArgumentNullException("kalman");
            IntPtr controlPtr = (control == null) ? IntPtr.Zero : control.CvPtr;
            IntPtr result = CvInvoke.cvKalmanPredict(kalman.CvPtr, controlPtr);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvMat(result, false);
        }
#if LANG_JP
        /// <summary>
        /// 次のモデル状態を推定する. cvKalmanPredictのエイリアス.
        /// </summary>
        /// <param name="kalman">カルマンフィルタ状態</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Estimates subsequent model state
        /// </summary>
        /// <param name="kalman">Kalman filter state. </param>
        /// <returns>The function returns the estimated state. </returns>
#endif
        public static CvMat KalmanUpdateByTime(CvKalman kalman)
        {
            return KalmanPredict(kalman);
        }
#if LANG_JP
        /// <summary>
        /// 次のモデル状態を推定する. cvKalmanPredictのエイリアス.
        /// </summary>
        /// <param name="kalman">カルマンフィルタ状態</param>
        /// <param name="control">コントロールベクトル (uk)．外部コントロールが存在しない場合（control_params=0）に限り，null である．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Estimates subsequent model state
        /// </summary>
        /// <param name="kalman">Kalman filter state. </param>
        /// <param name="control">Control vector (uk), should be null iff there is no external control (control_params=0).</param>
        /// <returns>The function returns the estimated state. </returns>
#endif
        public static CvMat KalmanUpdateByTime(CvKalman kalman, CvMat control)
        {
            return KalmanPredict(kalman, control);
        }
        #endregion
        #region KMeans
#if LANG_JP
        /// <summary>
        /// ベクトル集合を，与えられたクラスタ数に分割する.
        /// 入力サンプルを各クラスタに分類するために cluster_count 個のクラスタの中心を求める k-means 法を実装する．
        /// 出力 labels(i) は，配列 samples のi番目の行のサンプルが属するクラスタのインデックスを表す． 
        /// </summary>
        /// <param name="samples">浮動小数点型の入力サンプル行列．1行あたり一つのサンプル.</param>
        /// <param name="clusterCount">集合を分割するクラスタ数</param>
        /// <param name="labels">出力の整数ベクトル．すべてのサンプルについて，それぞれがどのクラスタに属しているかが保存されている.</param>
        /// <param name="termcrit">最大繰り返し数と(または)，精度（1ループでの各クラスタ中心位置移動距離）の指定</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Splits set of vectors by given number of clusters
        /// </summary>
        /// <param name="samples">Floating-point matrix of input samples, one row per sample. </param>
        /// <param name="clusterCount">Number of clusters to split the set by. </param>
        /// <param name="labels">Output integer vector storing cluster indices for every sample. </param>
        /// <param name="termcrit">Specifies maximum number of iterations and/or accuracy (distance the centers move by between the subsequent iterations). </param>
        /// <returns></returns>
#endif
        public static int KMeans2(CvArr samples, int clusterCount, CvArr labels, CvTermCriteria termcrit)
        {
            double compactness;
            return KMeans2(samples, clusterCount, labels, termcrit, 1, null, KMeansFlag.Zero, null, out compactness);
        }
#if LANG_JP
        /// <summary>
        /// ベクトル集合を，与えられたクラスタ数に分割する.
        /// 入力サンプルを各クラスタに分類するために cluster_count 個のクラスタの中心を求める k-means 法を実装する．
        /// 出力 labels(i) は，配列 samples のi番目の行のサンプルが属するクラスタのインデックスを表す． 
        /// </summary>
        /// <param name="samples">浮動小数点型の入力サンプル行列．1行あたり一つのサンプル.</param>
        /// <param name="clusterCount">集合を分割するクラスタ数</param>
        /// <param name="labels">出力の整数ベクトル．すべてのサンプルについて，それぞれがどのクラスタに属しているかが保存されている.</param>
        /// <param name="termcrit">最大繰り返し数と(または)，精度（1ループでの各クラスタ中心位置移動距離）の指定</param>
        /// <param name="attemps"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Splits set of vectors by given number of clusters
        /// </summary>
        /// <param name="samples">Floating-point matrix of input samples, one row per sample. </param>
        /// <param name="clusterCount">Number of clusters to split the set by. </param>
        /// <param name="labels">Output integer vector storing cluster indices for every sample. </param>
        /// <param name="termcrit">Specifies maximum number of iterations and/or accuracy (distance the centers move by between the subsequent iterations). </param>
        /// <param name="attemps"></param>
        /// <returns></returns>
#endif
        public static int KMeans2(CvArr samples, int clusterCount, CvArr labels, CvTermCriteria termcrit, int attemps)
        {
            double compactness;
            return KMeans2(samples, clusterCount, labels, termcrit, attemps, null, KMeansFlag.Zero, null, out compactness);
        }
#if LANG_JP
        /// <summary>
        /// ベクトル集合を，与えられたクラスタ数に分割する.
        /// 入力サンプルを各クラスタに分類するために cluster_count 個のクラスタの中心を求める k-means 法を実装する．
        /// 出力 labels(i) は，配列 samples のi番目の行のサンプルが属するクラスタのインデックスを表す． 
        /// </summary>
        /// <param name="samples">浮動小数点型の入力サンプル行列．1行あたり一つのサンプル.</param>
        /// <param name="clusterCount">集合を分割するクラスタ数</param>
        /// <param name="labels">出力の整数ベクトル．すべてのサンプルについて，それぞれがどのクラスタに属しているかが保存されている.</param>
        /// <param name="termcrit">最大繰り返し数と(または)，精度（1ループでの各クラスタ中心位置移動距離）の指定</param>
        /// <param name="attemps"></param>
        /// <param name="rng"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Splits set of vectors by given number of clusters
        /// </summary>
        /// <param name="samples">Floating-point matrix of input samples, one row per sample. </param>
        /// <param name="clusterCount">Number of clusters to split the set by. </param>
        /// <param name="labels">Output integer vector storing cluster indices for every sample. </param>
        /// <param name="termcrit">Specifies maximum number of iterations and/or accuracy (distance the centers move by between the subsequent iterations). </param>
        /// <param name="attemps"></param>
        /// <param name="rng"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
#endif
        public static int KMeans2(CvArr samples, int clusterCount, CvArr labels, CvTermCriteria termcrit, int attemps, CvRNG rng, KMeansFlag flag)
        {
            double compactness;
            return KMeans2(samples, clusterCount, labels, termcrit, attemps, rng, flag, null, out compactness);
        }
#if LANG_JP
        /// <summary>
        /// ベクトル集合を，与えられたクラスタ数に分割する.
        /// 入力サンプルを各クラスタに分類するために cluster_count 個のクラスタの中心を求める k-means 法を実装する．
        /// 出力 labels(i) は，配列 samples のi番目の行のサンプルが属するクラスタのインデックスを表す． 
        /// </summary>
        /// <param name="samples">浮動小数点型の入力サンプル行列．1行あたり一つのサンプル.</param>
        /// <param name="clusterCount">集合を分割するクラスタ数</param>
        /// <param name="labels">出力の整数ベクトル．すべてのサンプルについて，それぞれがどのクラスタに属しているかが保存されている.</param>
        /// <param name="termcrit">最大繰り返し数と(または)，精度（1ループでの各クラスタ中心位置移動距離）の指定</param>
        /// <param name="attemps"></param>
        /// <param name="rng"></param>
        /// <param name="flag"></param>
        /// <param name="centers"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Splits set of vectors by given number of clusters
        /// </summary>
        /// <param name="samples">Floating-point matrix of input samples, one row per sample. </param>
        /// <param name="clusterCount">Number of clusters to split the set by. </param>
        /// <param name="labels">Output integer vector storing cluster indices for every sample. </param>
        /// <param name="termcrit">Specifies maximum number of iterations and/or accuracy (distance the centers move by between the subsequent iterations). </param>
        /// <param name="attemps"></param>
        /// <param name="rng"></param>
        /// <param name="flag"></param>
        /// <param name="centers"></param>
        /// <returns></returns>
#endif
        public static int KMeans2(CvArr samples, int clusterCount, CvArr labels, CvTermCriteria termcrit, int attemps, CvRNG rng, KMeansFlag flag, CvArr centers)
        {
            double compactness;
            return KMeans2(samples, clusterCount, labels, termcrit, attemps, rng, flag, centers, out compactness);
        }
#if LANG_JP
        /// <summary>
        /// ベクトル集合を，与えられたクラスタ数に分割する.
        /// 入力サンプルを各クラスタに分類するために cluster_count 個のクラスタの中心を求める k-means 法を実装する．
        /// 出力 labels(i) は，配列 samples のi番目の行のサンプルが属するクラスタのインデックスを表す． 
        /// </summary>
        /// <param name="samples">浮動小数点型の入力サンプル行列．1行あたり一つのサンプル.</param>
        /// <param name="clusterCount">集合を分割するクラスタ数</param>
        /// <param name="labels">出力の整数ベクトル．すべてのサンプルについて，それぞれがどのクラスタに属しているかが保存されている.</param>
        /// <param name="termcrit">最大繰り返し数と(または)，精度（1ループでの各クラスタ中心位置移動距離）の指定</param>
        /// <param name="attemps"></param>
        /// <param name="rng"></param>
        /// <param name="flag"></param>
        /// <param name="centers"></param>
        /// <param name="compactness"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Splits set of vectors by given number of clusters
        /// </summary>
        /// <param name="samples">Floating-point matrix of input samples, one row per sample. </param>
        /// <param name="clusterCount">Number of clusters to split the set by. </param>
        /// <param name="labels">Output integer vector storing cluster indices for every sample. </param>
        /// <param name="termcrit">Specifies maximum number of iterations and/or accuracy (distance the centers move by between the subsequent iterations). </param>
        /// <param name="attemps"></param>
        /// <param name="rng"></param>
        /// <param name="flag"></param>
        /// <param name="centers"></param>
        /// <param name="compactness"></param>
        /// <returns></returns>
#endif
        public static int KMeans2(CvArr samples, int clusterCount, CvArr labels, CvTermCriteria termcrit, int attemps, CvRNG rng, KMeansFlag flag, CvArr centers, out double compactness)
        {
            if (samples == null)
                throw new ArgumentNullException("samples");
            if (labels == null)
                throw new ArgumentNullException("labels");

            if (rng == null)
            {
                rng = new CvRNG();
            }
            IntPtr centersPtr = (centers != null) ? centers.CvPtr : IntPtr.Zero;

            UInt64 rngValue = rng.Seed;
            int result = CvInvoke.cvKMeans2(samples.CvPtr, clusterCount, labels.CvPtr, termcrit, attemps, ref rngValue, flag, centersPtr, out compactness);
            rng.Seed = rngValue;

            return result;
        }
        #endregion
    }
}
