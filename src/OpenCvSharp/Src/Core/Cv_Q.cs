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
        #region QueryFrame
#if LANG_JP
        /// <summary>
        /// カメラやビデオファイルから一つのフレームを取り出し，それを展開して返す．
        /// この関数は，単純にcvGrabFrame とcvRetrieveFrame をまとめて呼び出しているだけである．
        /// 返された画像は，ユーザが解放したり，変更したりするべきではない．
        /// </summary>
        /// <param name="capture">ビデオキャプチャクラス</param>
        /// <returns>1フレームの画像 (GC禁止フラグが立っている). キャプチャできなかった場合はnull.</returns>
#else
        /// <summary>
        /// Grabs a frame from camera or video file, decompresses and returns it. 
        /// This function is just a combination of cvGrabFrame and cvRetrieveFrame in one call. 
        /// The returned image should not be released or modified by user. 
        /// </summary>
        /// <param name="capture">video capturing structure. </param>
        /// <returns></returns>
#endif
        public static IplImage QueryFrame(CvCapture capture)
        {
            if (capture == null)
                throw new ArgumentNullException("capture");
            
            IntPtr ptr = CvInvoke.cvQueryFrame(capture.CvPtr);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new IplImage(ptr, false);
        }
        #endregion
        #region QueryHistValue_*D
#if LANG_JP
        /// <summary>
        /// 1次元ヒストグラムの指定されたビンの値を返す． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="hist">ヒストグラム</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <returns>指定した要素の値</returns>
#else
        /// <summary>
        /// Queries value of histogram bin.
        /// </summary>
        /// <param name="hist">Histogram. </param>
        /// <param name="idx0">1st index of the bin.</param>
        /// <returns></returns>
#endif
        public static double QueryHistValue_1D(CvHistogram hist, int idx0)
        {
            return CvInvoke.cvGetReal1D(hist.BinsPtr, idx0);
        }
#if LANG_JP
        /// <summary>
        /// 2次元ヒストグラムの指定されたビンの値を返す． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="hist">ヒストグラム</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <returns>指定した要素の値</returns>
#else
        /// <summary>
        /// Queries value of histogram bin.
        /// </summary>
        /// <param name="hist">Histogram. </param>
        /// <param name="idx0">1st index of the bin.</param>
        /// <param name="idx1">2nd index of the bin.</param>
        /// <returns></returns>
#endif
        public static double QueryHistValue_2D(CvHistogram hist, int idx0, int idx1)
        {
            return CvInvoke.cvGetReal2D(hist.BinsPtr, idx0, idx1);
        }
#if LANG_JP
        /// <summary>
        /// 3次元ヒストグラムの指定されたビンの値を返す． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="hist">ヒストグラム</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <returns>指定した要素の値</returns>
#else
        /// <summary>
        /// Queries value of histogram bin.
        /// </summary>
        /// <param name="hist">Histogram. </param>
        /// <param name="idx0">1st index of the bin.</param>
        /// <param name="idx1">2nd index of the bin.</param>
        /// <param name="idx2">3rd index of the bin.</param>
        /// <returns></returns>
#endif
        public static double QueryHistValue_3D(CvHistogram hist, int idx0, int idx1, int idx2)
        {
            return CvInvoke.cvGetReal3D(hist.BinsPtr, idx0, idx1, idx2);
        }
#if LANG_JP
        /// <summary>
        /// n次元ヒストグラムの指定されたビンの値を返す． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="hist">ヒストグラム</param>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
        /// <returns>指定した要素の値</returns>
#else
        /// <summary>
        /// Queries value of histogram bin.
        /// </summary>
        /// <param name="hist">1st index of the bin.</param>
        /// <param name="idx">Array of indices.</param>
        /// <returns></returns>
#endif
        public static double QueryHistValue_nD(CvHistogram hist, params int[] idx)
        {
            return CvInvoke.cvGetRealND(hist.BinsPtr, idx);
        }
        #endregion
    }
}
