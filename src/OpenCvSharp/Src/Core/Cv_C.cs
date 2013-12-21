/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region CalcAffineFlowPyrLK
#if LANG_JP
        /// <summary>
        /// Modification of a previous sparse optical flow algorithm to calculate affine flow
        /// </summary>
        /// <param name="prev"></param>
        /// <param name="curr"></param>
        /// <param name="prevPyr"></param>
        /// <param name="currPyr"></param>
        /// <param name="prevFeatures"></param>
        /// <param name="currFeatures"></param>
        /// <param name="matrices"></param>
        /// <param name="count"></param>
        /// <param name="winSize"></param>
        /// <param name="level"></param>
        /// <param name="status"></param>
        /// <param name="trackError"></param>
        /// <param name="criteria"></param>
        /// <param name="flags"></param>
#else
        /// <summary>
        /// Modification of a previous sparse optical flow algorithm to calculate affine flow
        /// </summary>
        /// <param name="prev"></param>
        /// <param name="curr"></param>
        /// <param name="prevPyr"></param>
        /// <param name="currPyr"></param>
        /// <param name="prevFeatures"></param>
        /// <param name="currFeatures"></param>
        /// <param name="matrices"></param>
        /// <param name="count"></param>
        /// <param name="winSize"></param>
        /// <param name="level"></param>
        /// <param name="status"></param>
        /// <param name="trackError"></param>
        /// <param name="criteria"></param>
        /// <param name="flags"></param>
#endif
        public static void CalcAffineFlowPyrLK(CvArr prev, CvArr curr, CvArr prevPyr, CvArr currPyr,
            CvPoint2D32f[] prevFeatures, out CvPoint2D32f[] currFeatures, out float[] matrices, int count,
            CvSize winSize, int level, out sbyte[] status, out float[] trackError, CvTermCriteria criteria, LKFlowFlag flags)
        {
            if (prev == null)
                throw new ArgumentNullException("prev");
            if (curr == null)
                throw new ArgumentNullException("curr");
            if (prevPyr == null)
                throw new ArgumentNullException("prevPyr");
            if (currPyr == null)
                throw new ArgumentNullException("currPyr");
            if (prevFeatures == null)
                throw new ArgumentNullException("prevFeatures");

            currFeatures = new CvPoint2D32f[prevFeatures.Length];
            matrices = new float[prevFeatures.Length];
            status = new sbyte[prevFeatures.Length];
            trackError = new float[prevFeatures.Length];

            CvInvoke.cvCalcAffineFlowPyrLK(prev.CvPtr, curr.CvPtr, prevPyr.CvPtr, currPyr.CvPtr, prevFeatures, currFeatures, matrices,
                prevFeatures.Length, winSize, level, status, trackError, criteria, flags);
        }
        #endregion
        #region CalcArrHist
#if LANG_JP
        /// <summary>
        /// 1つの配列のヒストグラムを計算する.
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="hist">ヒストグラムへの参照</param>
#else
        /// <summary>
        /// Calculates the histogram of one single-channel image. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="arr">A Source image (though, you may pass CvMat** as well).</param>
        /// <param name="hist">Reference to the histogram.</param>
#endif
        public static void CalcArrHist(CvArr arr, CvHistogram hist)
        {
            CalcArrHist(arr, hist, false, null);
        }
#if LANG_JP
        /// <summary>
        /// 1つの配列のヒストグラムを計算する.
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="hist">ヒストグラムへの参照</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない．</param>
#else
        /// <summary>
        /// Calculates the histogram of one single-channel image. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="arr">A Source image (though, you may pass CvMat** as well).</param>
        /// <param name="hist">Reference to the histogram.</param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
#endif
        public static void CalcArrHist(CvArr arr, CvHistogram hist, bool accumulate)
        {
            CalcArrHist(arr, hist, accumulate, null);
        }
#if LANG_JP
        /// <summary>
        /// 1つの配列のヒストグラムを計算する.
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="hist">ヒストグラムへの参照</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない．</param>
        /// <param name="mask">処理マスク．入力画像中のどのピクセルをカウントするかを決定する.</param>
#else
        /// <summary>
        /// Calculates the histogram of one single-channel image. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="arr">A Source image (though, you may pass CvMat** as well).</param>
        /// <param name="hist">Reference to the histogram.</param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
        /// <param name="mask">The operation mask, determines what pixels of the source images are counted. </param>
#endif
        public static void CalcArrHist(CvArr arr, CvHistogram hist, bool accumulate, CvArr mask)
        {
            CalcArrHist(new CvArr[] { arr }, hist, accumulate, mask);
        }
#if LANG_JP
        /// <summary>
        /// 配列群のヒストグラムを計算する.
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="arr">入力配列群．全て同じサイズ・タイプ．</param>
        /// <param name="hist">ヒストグラムへの参照</param>
#else
        /// <summary>
        /// Calculates the histogram of single-channel images. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="arr">Source images (though, you may pass CvMat** as well), all are of the same size and type.</param>
        /// <param name="hist">Reference to the histogram.</param>
#endif
        public static void CalcArrHist(CvArr[] arr, CvHistogram hist)
        {
            CalcArrHist(arr, hist, false, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列群のヒストグラムを計算する.
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="arr">入力配列群．全て同じサイズ・タイプ．</param>
        /// <param name="hist">ヒストグラムへの参照</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない． </param>
#else
        /// <summary>
        /// Calculates the histogram of single-channel images. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="arr">Source images (though, you may pass CvMat** as well), all are of the same size and type.</param>
        /// <param name="hist">Reference to the histogram.</param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
#endif
        public static void CalcArrHist(CvArr[] arr, CvHistogram hist, bool accumulate)
        {
            CalcArrHist(arr, hist, accumulate, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列群のヒストグラムを計算する.
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="arr">入力配列群．全て同じサイズ・タイプ．</param>
        /// <param name="hist">ヒストグラムへの参照</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない． </param>
        /// <param name="mask">処理マスク．入力画像中のどのピクセルをカウントするかを決定する.</param>
#else
        /// <summary>
        /// Calculates the histogram of single-channel images. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="arr">Source images (though, you may pass CvMat** as well), all are of the same size and type.</param>
        /// <param name="hist">Reference to the histogram. </param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
        /// <param name="mask">The operation mask, determines what pixels of the source images are counted. </param>
#endif
        public static void CalcArrHist(CvArr[] arr, CvHistogram hist, bool accumulate, CvArr mask)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            if (hist == null)
                throw new ArgumentNullException("hist");
            IntPtr[] arrPtr = new IntPtr[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arrPtr[i] = arr[i].CvPtr;
            }
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvCalcArrHist(arrPtr, hist.CvPtr, accumulate, maskPtr);
        }
        #endregion
        #region CalcArrBackProject
#if LANG_JP
        /// <summary>
        /// バックプロジェクションの計算を行う
        /// </summary>
        /// <param name="image">入力画像群</param>
        /// <param name="backProject">出力のバックプロジェクション画像．入力画像群と同じタイプ．</param>
        /// <param name="hist">ヒストグラム</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates back projection
        /// </summary>
        /// <param name="image">Source images (though you may pass CvMat** as well), all are of the same size and type </param>
        /// <param name="backProject">Destination back projection image of the same type as the source images. </param>
        /// <param name="hist">Histogram. </param>
        /// <returns></returns>
#endif
        public static void CalcArrBackProject(CvArr[] image, CvArr backProject, CvHistogram hist)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (backProject == null)
                throw new ArgumentNullException("backProject");
            if (hist == null)
                throw new ArgumentNullException("hist");
            
            IntPtr[] imagePtr = new IntPtr[image.Length];
            for (int i = 0; i < image.Length; i++)
            {
                imagePtr[i] = image[i].CvPtr;
            }
            CvInvoke.cvCalcArrBackProject(imagePtr, backProject.CvPtr, hist.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// バックプロジェクションの計算を行う
        /// </summary>
        /// <param name="image">入力画像群</param>
        /// <param name="backProject">出力のバックプロジェクション画像．入力画像群と同じタイプ．</param>
        /// <param name="hist">ヒストグラム</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates back projection
        /// </summary>
        /// <param name="image">Source images (though you may pass CvMat** as well), all are of the same size and type </param>
        /// <param name="backProject">Destination back projection image of the same type as the source images. </param>
        /// <param name="hist">Histogram. </param>
        /// <returns></returns>
#endif
        public static void CalcBackProject(IplImage[] image, CvArr backProject, CvHistogram hist)
        {
            CalcArrBackProject(image, backProject, hist);
        }
        #endregion
        #region CalcArrBackProjectPatch
#if LANG_JP
        /// <summary>
        /// ヒストグラムの比較に基づき画像内部でのテンプレート位置を求める
        /// </summary>
        /// <param name="image">入力画像群（ CvMat** 形式でも構わない）．すべて同じサイズ．</param>
        /// <param name="dst">出力画像</param>
        /// <param name="patch_size">入力画像群上をスライドさせるテンプレートのサイズ</param>
        /// <param name="hist">テンプレートのヒストグラム</param>
        /// <param name="method">比較方法．値は関数 cvCompareHist に渡される（この関数に関する記述を参照）</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Locates a template within image by histogram comparison
        /// </summary>
        /// <param name="image">Source images (though you may pass CvMat** as well), all are of the same size and type </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="patch_size">Size of patch slid though the source images. </param>
        /// <param name="hist">Histogram. </param>
        /// <param name="method">Compasion method, passed to cvCompareHist (see description of that function). </param>
        /// <returns></returns>
#endif
        public static void CalcArrBackProjectPatch(CvArr[] image, CvArr dst, CvSize patch_size, CvHistogram hist, HistogramComparison method)
        {
            CalcArrBackProjectPatch(image, dst, patch_size, hist, method, 1f);
        }
#if LANG_JP
        /// <summary>
        /// ヒストグラムの比較に基づき画像内部でのテンプレート位置を求める
        /// </summary>
        /// <param name="image">入力画像群（ CvMat** 形式でも構わない）．すべて同じサイズ．</param>
        /// <param name="dst">出力画像</param>
        /// <param name="patch_size">入力画像群上をスライドさせるテンプレートのサイズ</param>
        /// <param name="hist">テンプレートのヒストグラム</param>
        /// <param name="method">比較方法．値は関数 cvCompareHist に渡される（この関数に関する記述を参照）</param>
        /// <param name="factor">ヒストグラムの正規化係数．出力画像の正規化スケールに影響する．値に確信がない場合は，１にする．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Locates a template within image by histogram comparison
        /// </summary>
        /// <param name="image">Source images (though you may pass CvMat** as well), all are of the same size and type </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="patch_size">Size of patch slid though the source images. </param>
        /// <param name="hist">Histogram. </param>
        /// <param name="method">Compasion method, passed to cvCompareHist (see description of that function). </param>
        /// <param name="factor">Normalization factor for histograms, will affect normalization scale of destination image, pass 1. if unsure. </param>
        /// <returns></returns>
#endif
        public static void CalcArrBackProjectPatch(CvArr[] image, CvArr dst, CvSize patch_size, CvHistogram hist, HistogramComparison method, float factor)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (hist == null)
            {
                throw new ArgumentNullException("hist");
            }
            IntPtr[] image_ptr = new IntPtr[image.Length];
            for (int i = 0; i < image.Length; i++)
            {
                image_ptr[i] = image[i].CvPtr;
            }
            CvInvoke.cvCalcArrBackProjectPatch(image_ptr, dst.CvPtr, patch_size, hist.CvPtr, (int)method, factor);
        }
#if LANG_JP
        /// <summary>
        /// ヒストグラムの比較に基づき画像内部でのテンプレート位置を求める
        /// </summary>
        /// <param name="image">入力画像群（ CvMat** 形式でも構わない）．すべて同じサイズ．</param>
        /// <param name="dst">出力画像</param>
        /// <param name="patch_size">入力画像群上をスライドさせるテンプレートのサイズ</param>
        /// <param name="hist">テンプレートのヒストグラム</param>
        /// <param name="method">比較方法．値は関数 cvCompareHist に渡される（この関数に関する記述を参照）</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Locates a template within image by histogram comparison
        /// </summary>
        /// <param name="image">Source images (though you may pass CvMat** as well), all are of the same size and type </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="patch_size">Size of patch slid though the source images. </param>
        /// <param name="hist">Histogram. </param>
        /// <param name="method">Compasion method, passed to cvCompareHist (see description of that function). </param>
        /// <returns></returns>
#endif
        public static void CalcBackProjectPatch(IplImage[] image, CvArr dst, CvSize patch_size, CvHistogram hist, HistogramComparison method)
        {
            CalcArrBackProjectPatch(image, dst, patch_size, hist, method, 1f);
        }
#if LANG_JP
        /// <summary>
        /// ヒストグラムの比較に基づき画像内部でのテンプレート位置を求める
        /// </summary>
        /// <param name="image">入力画像群（ CvMat** 形式でも構わない）．すべて同じサイズ．</param>
        /// <param name="dst">出力画像</param>
        /// <param name="patch_size">入力画像群上をスライドさせるテンプレートのサイズ</param>
        /// <param name="hist">テンプレートのヒストグラム</param>
        /// <param name="method">比較方法．値は関数 cvCompareHist に渡される（この関数に関する記述を参照）</param>
        /// <param name="factor">ヒストグラムの正規化係数．出力画像の正規化スケールに影響する．値に確信がない場合は，１にする．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Locates a template within image by histogram comparison
        /// </summary>
        /// <param name="image">Source images (though you may pass CvMat** as well), all are of the same size and type </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="patch_size">Size of patch slid though the source images. </param>
        /// <param name="hist">Histogram. </param>
        /// <param name="method">Compasion method, passed to cvCompareHist (see description of that function). </param>
        /// <param name="factor">Normalization factor for histograms, will affect normalization scale of destination image, pass 1. if unsure. </param>
        /// <returns></returns>
#endif
        public static void CalcBackProjectPatch(IplImage[] image, CvArr dst, CvSize patch_size, CvHistogram hist, HistogramComparison method, float factor)
        {
            CalcArrBackProjectPatch(image, dst, patch_size, hist, method, factor);
        }
        #endregion
        #region CalcBayesianProb
#if LANG_JP
        /// <summary>
        /// Calculates bayesian probabilistic histograms
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
#else
        /// <summary>
        /// Calculates bayesian probabilistic histograms
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
#endif
        public static void CalcBayesianProb(CvHistogram[] src, CvHistogram[] dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (src.Length != dst.Length)
                throw new ArgumentException();

            IntPtr[] srcPtr = new IntPtr[src.Length];
            IntPtr[] dstPtr = new IntPtr[dst.Length];
            for (int i = 0; i < src.Length; i++)
            {
                srcPtr[i] = src[i].CvPtr;
                dstPtr[i] = dst[i].CvPtr;
            }
            CvInvoke.cvCalcBayesianProb(srcPtr, src.Length, dstPtr);
        }
        #endregion
        #region CalcCovarMatrix
#if LANG_JP
        /// <summary>
        /// ベクトル集合の共変動行列を計算する
        /// </summary>
        /// <param name="vects">入力ベクトル．これらはすべて同じタイプで同じサイズでなくてはならない．</param>
        /// <param name="cov_mat">浮動小数点型の正方な出力共変動行列</param>
        /// <param name="avg">入力または出力配列（フラグに依存する） - 入力ベクトルの平均ベクトル</param>
        /// <param name="flags">操作フラグ</param>
#else
        /// <summary>
        /// Calculates covariation matrix of the set of vectors
        /// </summary>
        /// <param name="vects">The input vectors. They all must have the same type and the same size. The vectors do not have to be 1D, they can be 2D (e.g. images) etc. </param>
        /// <param name="cov_mat">The output covariation matrix that should be floating-point and square. </param>
        /// <param name="avg">The input or output (depending on the flags) array - the mean (average) vector of the input vectors. </param>
        /// <param name="flags">The operation flags</param>
#endif
        public static void CalcCovarMatrix(CvArr[] vects, CvArr cov_mat, CvArr avg, CovarMatrixFlag flags)
        {
            if (vects == null)
                throw new ArgumentNullException("vects");
            if (cov_mat == null)
                throw new ArgumentNullException("cov_mat");
            if (avg == null)
                throw new ArgumentNullException("avg");
            IntPtr[] vectsPtr = new IntPtr[vects.Length];
            for (int i = 0; i < vects.Length; i++)
            {
                if (vects[i] == null)
                {
                    throw new ArgumentNullException(string.Format("vects[{0}]", i));
                }
                vectsPtr[i] = vects[i].CvPtr;
            }
            CvInvoke.cvCalcCovarMatrix(vectsPtr, vects.Length, cov_mat.CvPtr, avg.CvPtr, flags);
        }
        #endregion
        #region CalcCovarMatrixEx
#if LANG_JP
        /// <summary>
        /// 入力オブジェクト集合の正規直交基底と平均オブジェクトを計算する
        /// </summary>
        /// <param name="object_count">入力オブジェクトの個数.</param>
        /// <param name="input">読み込みコールバック関数へのポインタ.</param>
        /// <param name="io_flags">入出力フラグ.</param>
        /// <param name="iobuf_size">入出力バッファサイズ.</param>
        /// <param name="buffer">入出力バッファへのポインタ.</param>
        /// <param name="userdata">コールバック関数に必要なすべてのデータを含む構造体へのポインタ.</param>
        /// <param name="avg">平均オブジェクト.</param>
        /// <param name="covar_matrix">共分散行列. 出力パラメータであるので, 関数が呼ばれる前に確保されてなければならない.</param>
#else
        /// <summary>
        /// Calculates the covariance matrix for a group of input objects.
        /// </summary>
        /// <param name="object_count">Number of source objects.</param>
        /// <param name="input">Pointer to the read callback function.</param>
        /// <param name="io_flags">Input/output flags.</param>
        /// <param name="iobuf_size">Input/output buffer size.</param>
        /// <param name="buffer">Pointer to the input/output buffer.</param>
        /// <param name="userdata">Pointer to the structure that contains all necessary data for the callback functions.</param>
        /// <param name="avg">Averaged object.</param>
        /// <param name="covar_matrix">Covariance matrix. An output parameter; must be allocated before the call.</param>
#endif
        public static void CalcCovarMatrixEx(int object_count, CvCallback input, EigenObjectsIOFlag io_flags, int iobuf_size, byte[] buffer, IntPtr userdata, IplImage avg, float[] covar_matrix)
        {
            if (avg == null)
                throw new ArgumentNullException("avg");

            //int iobuf_size = (buffer != null) ? buffer.Length : 0;

            using (ScopedGCHandle inputHandle = ScopedGCHandle.Alloc(input))
            using (ScopedGCHandle bufferHandle = ScopedGCHandle.Alloc(buffer, GCHandleType.Pinned))
            {
                CvInvoke.cvCalcCovarMatrixEx(object_count, input, io_flags, iobuf_size, buffer, userdata, avg.CvPtr, covar_matrix);
            }
        }
#if LANG_JP
        /// <summary>
        /// 入力オブジェクト集合の正規直交基底と平均オブジェクトを計算する (ioFlags = CV_EIGOBJ_NO_CALLBACK)
        /// </summary>
        /// <param name="input">IplImage 型の入力オブジェクトの配列</param>
        /// <param name="avg">平均オブジェクト.</param>
        /// <param name="covar_matrix">共分散行列. 出力パラメータであるので, 関数が呼ばれる前に確保されてなければならない.</param>
#else
        /// <summary>
        /// Calculates the covariance matrix for a group of input objects. (ioFlags = CV_EIGOBJ_NO_CALLBACK)
        /// </summary>
        /// <param name="input">Array of IplImage input objects.</param>
        /// <param name="avg">Averaged object.</param>
        /// <param name="covar_matrix">Covariance matrix. An output parameter; must be allocated before the call.</param>
#endif
        public static void CalcCovarMatrixEx(IplImage[] input, IplImage avg, float[] covar_matrix)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (input.Length == 0)
                throw new ArgumentException("", "input");
            if (avg == null)
                throw new ArgumentNullException("avg");

            int object_count = input.Length;

            IntPtr[] inputPtr = new IntPtr[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                inputPtr[i] = input[i].CvPtr;
            }

            using (ScopedGCHandle handle = ScopedGCHandle.Alloc(inputPtr, GCHandleType.Pinned))
            {
                CvInvoke.cvCalcCovarMatrixEx(object_count, handle.AddrOfPinnedObject(), EigenObjectsIOFlag.NoCallback, 0, IntPtr.Zero, IntPtr.Zero, avg.CvPtr, covar_matrix);
            }
        }
        #endregion
        #region CalcDecompCoeff
#if LANG_JP
        /// <summary>
        /// 入力オブジェクトの分解係数を計算する
        /// </summary>
        /// <param name="obj">入力オブジェクト</param>
        /// <param name="eigObj">固有オブジェクト</param>
        /// <param name="avg">平均オブジェクト</param>
        /// <returns>分解系数</returns>
#else
        /// <summary>
        /// Calculates the decomposition coefficient of an input object.
        /// </summary>
        /// <param name="obj">Input object.</param>
        /// <param name="eigObj">Eigen object.</param>
        /// <param name="avg">Averaged object.</param>
        /// <returns>decomposition coefficient</returns>
#endif
        public static double CalcDecompCoeff(IplImage obj, IplImage eigObj, IplImage avg)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            if (eigObj == null)
                throw new ArgumentNullException("eigObj");
            if (avg == null)
                throw new ArgumentNullException("avg");

            return CvInvoke.cvCalcDecompCoeff(obj.CvPtr, eigObj.CvPtr, avg.CvPtr);
        }
        #endregion
        #region CalcEigenObjects
#if LANG_JP
        /// <summary>
        /// 入力オブジェクト集合の共分散行列を計算する (ioFlags = CV_EIGOBJ_NO_CALLBACK)
        /// </summary>
        /// <param name="input">IplImage 型の入力オブジェクトの配列</param>
        /// <param name="output">固有オブジェクトの配列</param>
        /// <param name="ioBufSize">バイト単位で表される入出力バッファサイズ．サイズが分からない場合は，0 にする．</param>
        /// <param name="calcLimit">固有オブジェクトの計算を終了するための終了条件．</param>
        /// <param name="avg">平均オブジェクト．</param>
        /// <param name="eigVals">降順に並んだ固有値配列へのポインタ；null の場合もある．</param>
#else
        /// <summary>
        /// Calculates the orthonormal eigen basis and the averaged object for group a of input objects. (ioFlags = CV_EIGOBJ_NO_CALLBACK)
        /// </summary>
        /// <param name="input">Pointer to the array of IplImage input objects.</param>
        /// <param name="output">Pointer to the array of eigen objects.</param>
        /// <param name="ioBufSize">Input/output buffer size in bytes. The size is zero if unknown.</param>
        /// <param name="calcLimit">Criteria that determine when to stop the calculation of eigen objects.</param>
        /// <param name="avg">Averaged object.</param>
        /// <param name="eigVals">Pointer to the eigenvalues array in the descending order; may be null.</param>
#endif
        public static void CalcEigenObjects(IplImage[] input, IplImage[] output, int ioBufSize, CvTermCriteria calcLimit, IplImage avg, float[] eigVals)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (input.Length == 0)
                throw new ArgumentException("", "input");
            if (output == null)
                throw new ArgumentNullException("output");
            if (output.Length == 0)
                throw new ArgumentException("", "output");
            if (avg == null)
                throw new ArgumentNullException("avg");

            IntPtr[] inputPtr = new IntPtr[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                inputPtr[i] = input[i].CvPtr;
            }
            IntPtr[] outputPtr = new IntPtr[output.Length];
            for (int i = 0; i < output.Length; i++)
            {
                outputPtr[i] = output[i].CvPtr;
            }

            int nObjects = input.Length;

            using (ScopedGCHandle inputHandle = ScopedGCHandle.Alloc(inputPtr, GCHandleType.Pinned))
            using (ScopedGCHandle outputHandle = ScopedGCHandle.Alloc(outputPtr, GCHandleType.Pinned))
            {
                CvInvoke.cvCalcEigenObjects(nObjects, inputHandle.AddrOfPinnedObject(), outputHandle.AddrOfPinnedObject(), EigenObjectsIOFlag.NoCallback, 0, IntPtr.Zero, ref calcLimit, avg.CvPtr, eigVals);
            }
        }
#if LANG_JP
        /// <summary>
        /// 入力オブジェクト集合の共分散行列を計算する (ioFlags = CV_EIGOBJ_OUTPUT_CALLBACK)
        /// </summary>
        /// <param name="nObjects">入力オブジェクトの個数</param>
        /// <param name="input">IplImage 型の入力オブジェクトの配列</param>
        /// <param name="output">書き出しコールバック関数へのポインタ</param>
        /// <param name="ioBufSize">バイト単位で表される入出力バッファサイズ．サイズが分からない場合は，0 にする．</param>
        /// <param name="userData">コールバック関数に必要なすべてのデータを含む構造体へのポインタ．</param>
        /// <param name="calcLimit">固有オブジェクトの計算を終了するための終了条件．</param>
        /// <param name="avg">平均オブジェクト．</param>
        /// <param name="eigVals">降順に並んだ固有値配列へのポインタ；null の場合もある．</param>
#else
        /// <summary>
        /// Calculates the orthonormal eigen basis and the averaged object for group a of input objects. (ioFlags = CV_EIGOBJ_OUTPUT_CALLBACK)
        /// </summary>
        /// <param name="nObjects">nObjects – Number of source objects.</param>
        /// <param name="input">Pointer to the array of IplImage input objects.</param>
        /// <param name="output">Pointer to the write callback function.</param>
        /// <param name="ioBufSize">Input/output buffer size in bytes. The size is zero if unknown.</param>
        /// <param name="userData">Pointer to the structure that contains all of the necessary data for the callback functions.</param>
        /// <param name="calcLimit">Criteria that determine when to stop the calculation of eigen objects.</param>
        /// <param name="avg">Averaged object.</param>
        /// <param name="eigVals">Pointer to the eigenvalues array in the descending order; may be null.</param>
#endif
        public static void CalcEigenObjects(int nObjects, IplImage[] input, CvCallback output, int ioBufSize, IntPtr userData, CvTermCriteria calcLimit, IplImage avg, float[] eigVals)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (input.Length == 0)
                throw new ArgumentException("", "input");
            if (avg == null)
                throw new ArgumentNullException("avg");

            IntPtr[] inputPtr = new IntPtr[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                inputPtr[i] = input[i].CvPtr;
            }

            using (ScopedGCHandle inputHandle = ScopedGCHandle.Alloc(inputPtr, GCHandleType.Pinned))
            using (ScopedGCHandle outputHandle = ScopedGCHandle.Alloc(output, GCHandleType.Normal))
            {
                CvInvoke.cvCalcEigenObjects(nObjects, inputHandle.AddrOfPinnedObject(), output, EigenObjectsIOFlag.OutputCallback, ioBufSize, userData, ref calcLimit, avg.CvPtr, eigVals);
            }
        }
#if LANG_JP
        /// <summary>
        /// 入力オブジェクト集合の共分散行列を計算する (ioFlags = CV_EIGOBJ_INPUT_CALLBACK)
        /// </summary>
        /// <param name="nObjects">入力オブジェクトの個数</param>
        /// <param name="input">読み込みコールバック関数へのポインタ</param>
        /// <param name="output">固有オブジェクトの配列</param>
        /// <param name="ioBufSize">バイト単位で表される入出力バッファサイズ．サイズが分からない場合は，0 にする．</param>
        /// <param name="userData">コールバック関数に必要なすべてのデータを含む構造体へのポインタ．</param>
        /// <param name="calcLimit">固有オブジェクトの計算を終了するための終了条件．</param>
        /// <param name="avg">平均オブジェクト．</param>
        /// <param name="eigVals">降順に並んだ固有値配列へのポインタ；null の場合もある．</param>
#else
        /// <summary>
        /// Calculates the orthonormal eigen basis and the averaged object for group a of input objects. (ioFlags = CV_EIGOBJ_INPUT_CALLBACK)
        /// </summary>
        /// <param name="nObjects">nObjects – Number of source objects.</param>
        /// <param name="input">Pointer to the read callback function.</param>
        /// <param name="output">Pointer to the array of eigen objects.</param>
        /// <param name="ioBufSize">Input/output buffer size in bytes. The size is zero if unknown.</param>
        /// <param name="userData">Pointer to the structure that contains all of the necessary data for the callback functions.</param>
        /// <param name="calcLimit">Criteria that determine when to stop the calculation of eigen objects.</param>
        /// <param name="avg">Averaged object.</param>
        /// <param name="eigVals">Pointer to the eigenvalues array in the descending order; may be null.</param>
#endif
        public static void CalcEigenObjects(int nObjects, CvCallback input, IplImage[] output, int ioBufSize, IntPtr userData, CvTermCriteria calcLimit, IplImage avg, float[] eigVals)
        {
            if (output == null)
                throw new ArgumentNullException("output");
            if (output.Length == 0)
                throw new ArgumentException("", "output");
            if (avg == null)
                throw new ArgumentNullException("avg");

            IntPtr[] outputPtr = new IntPtr[output.Length];
            for (int i = 0; i < output.Length; i++)
            {
                outputPtr[i] = output[i].CvPtr;
            }

            using (ScopedGCHandle inputHandle = ScopedGCHandle.Alloc(input, GCHandleType.Normal))
            using (ScopedGCHandle outputHandle = ScopedGCHandle.Alloc(outputPtr, GCHandleType.Pinned))
            {
                CvInvoke.cvCalcEigenObjects(nObjects, input, outputHandle.AddrOfPinnedObject(), EigenObjectsIOFlag.InputCallback, ioBufSize, userData, ref calcLimit, avg.CvPtr, eigVals);
            }
        }
#if LANG_JP
        /// <summary>
        /// 入力オブジェクト集合の共分散行列を計算する
        /// </summary>
        /// <param name="nObjects">入力オブジェクトの個数</param>
        /// <param name="input">読み込みコールバック関数へのポインタ</param>
        /// <param name="output">書き出しコールバック関数へのポインタ</param>
        /// <param name="ioFlags">入出力フラグ</param>
        /// <param name="ioBufSize">バイト単位で表される入出力バッファサイズ．サイズが分からない場合は，0 にする．</param>
        /// <param name="userData">コールバック関数に必要なすべてのデータを含む構造体へのポインタ．</param>
        /// <param name="calcLimit">固有オブジェクトの計算を終了するための終了条件．</param>
        /// <param name="avg">平均オブジェクト．</param>
        /// <param name="eigVals">降順に並んだ固有値配列へのポインタ；null の場合もある．</param>
#else
        /// <summary>
        /// Calculates the orthonormal eigen basis and the averaged object for group a of input objects.
        /// </summary>
        /// <param name="nObjects">nObjects – Number of source objects.</param>
        /// <param name="input">Pointer to the read callback function.</param>
        /// <param name="output">Pointer to the write callback function.</param>
        /// <param name="ioFlags">Input/output flags.</param>
        /// <param name="ioBufSize">Input/output buffer size in bytes. The size is zero if unknown.</param>
        /// <param name="userData">Pointer to the structure that contains all of the necessary data for the callback functions.</param>
        /// <param name="calcLimit">Criteria that determine when to stop the calculation of eigen objects.</param>
        /// <param name="avg">Averaged object.</param>
        /// <param name="eigVals">Pointer to the eigenvalues array in the descending order; may be null.</param>
#endif
        public static void CalcEigenObjects(int nObjects, CvCallback input, CvCallback output, EigenObjectsIOFlag ioFlags, int ioBufSize, IntPtr userData, CvTermCriteria calcLimit, IplImage avg, float[] eigVals)
        {
            if (avg == null)
                throw new ArgumentNullException("avg");

            using (ScopedGCHandle inputHandle = ScopedGCHandle.Alloc(input, GCHandleType.Normal))
            using (ScopedGCHandle outputHandle = ScopedGCHandle.Alloc(output, GCHandleType.Normal))
            {
                CvInvoke.cvCalcEigenObjects(nObjects, input, output, EigenObjectsIOFlag.InputCallback, ioBufSize, userData, ref calcLimit, avg.CvPtr, eigVals);
            }
        }
        #endregion
        #region CalcEMD2
#if LANG_JP
        /// <summary>
        /// 2つの重み付き点分布間の "最小コスト（minimal work）" 距離を計算する．
        /// </summary>
        /// <param name="signature1">1番目のシグネチャ（点分布），size1×dims+1の浮動小数点型行列．各行は，重みの後に座標を保存する．ユーザ定義のコスト行列を用いる場合は，1列の行列（重みだけ）でも構わない．</param>
        /// <param name="signature2">2番目のシグネチャ（点分布）（signature1と同じフォーマット）．行数や重みの合計が異なることもあるが，この場合は余分の"dummy" 点が signature1 か signature2 のどちらかに追加される．</param>
        /// <param name="distanceType">用いる評価指標.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Computes "minimal work" distance between two weighted point configurations.
        /// </summary>
        /// <param name="signature1">First signature, size1×dims+1 floating-point matrix. Each row stores the point weight followed by the point coordinates. The matrix is allowed to have a single column (weights only) if the user-defined cost matrix is used. </param>
        /// <param name="signature2">Second signature of the same format as signature1, though the number of rows may be different. The total weights may be different, in this case an extra "dummy" point is added to either signature1 or signature2. </param>
        /// <param name="distanceType">Metrics used</param>
        /// <returns></returns>
#endif
        public static float CalcEMD2(CvArr signature1, CvArr signature2, DistanceType distanceType)
        {
            float lowerBound = 0;
            return CalcEMD2(signature1, signature2, distanceType, null, null, null, ref lowerBound);
        }
#if LANG_JP
        /// <summary>
        /// 2つの重み付き点分布間の "最小コスト（minimal work）" 距離を計算する．
        /// </summary>
        /// <param name="signature1">1番目のシグネチャ（点分布），size1×dims+1の浮動小数点型行列．各行は，重みの後に座標を保存する．ユーザ定義のコスト行列を用いる場合は，1列の行列（重みだけ）でも構わない．</param>
        /// <param name="signature2">2番目のシグネチャ（点分布）（signature1と同じフォーマット）．行数や重みの合計が異なることもあるが，この場合は余分の"dummy" 点が signature1 か signature2 のどちらかに追加される．</param>
        /// <param name="distanceType">用いる評価指標.</param>
        /// <param name="distanceFunc">ユーザ定義距離関数．2点の座標を与えると，その点間の距離を返す．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Computes "minimal work" distance between two weighted point configurations.
        /// </summary>
        /// <param name="signature1">First signature, size1×dims+1 floating-point matrix. Each row stores the point weight followed by the point coordinates. The matrix is allowed to have a single column (weights only) if the user-defined cost matrix is used. </param>
        /// <param name="signature2">Second signature of the same format as signature1, though the number of rows may be different. The total weights may be different, in this case an extra "dummy" point is added to either signature1 or signature2. </param>
        /// <param name="distanceType">Metrics used</param>
        /// <param name="distanceFunc">The user-defined distance function. It takes coordinates of two points and returns the distance between the points. </param>
        /// <returns></returns>
#endif
        public static float CalcEMD2(CvArr signature1, CvArr signature2, DistanceType distanceType, CvDistanceFunction distanceFunc)
        {
            float lowerBound = 0;
            return CalcEMD2(signature1, signature2, distanceType, distanceFunc, null, null, ref lowerBound);
        }
#if LANG_JP
        /// <summary>
        /// 2つの重み付き点分布間の "最小コスト（minimal work）" 距離を計算する．
        /// </summary>
        /// <param name="signature1">1番目のシグネチャ（点分布），size1×dims+1の浮動小数点型行列．各行は，重みの後に座標を保存する．ユーザ定義のコスト行列を用いる場合は，1列の行列（重みだけ）でも構わない．</param>
        /// <param name="signature2">2番目のシグネチャ（点分布）（signature1と同じフォーマット）．行数や重みの合計が異なることもあるが，この場合は余分の"dummy" 点が signature1 か signature2 のどちらかに追加される．</param>
        /// <param name="distanceType">用いる評価指標.</param>
        /// <param name="distanceFunc">ユーザ定義距離関数．2点の座標を与えると，その点間の距離を返す．</param>
        /// <param name="costMatrix">ユーザ定義の size1×size2のコスト行列．少なくとも，cost_matrix と distance_func のいずれか一つは NULL でなければならない．コスト行列を用いる場合は，下限値（下記参照）の計算は距離定義関数を必要とするため不可能である．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Computes "minimal work" distance between two weighted point configurations.
        /// </summary>
        /// <param name="signature1">First signature, size1×dims+1 floating-point matrix. Each row stores the point weight followed by the point coordinates. The matrix is allowed to have a single column (weights only) if the user-defined cost matrix is used. </param>
        /// <param name="signature2">Second signature of the same format as signature1, though the number of rows may be different. The total weights may be different, in this case an extra "dummy" point is added to either signature1 or signature2. </param>
        /// <param name="distanceType">Metrics used</param>
        /// <param name="distanceFunc">The user-defined distance function. It takes coordinates of two points and returns the distance between the points. </param>
        /// <param name="costMatrix">The user-defined size1×size2 cost matrix. At least one of cost_matrix and distance_func must be NULL. Also, if a cost matrix is used, lower boundary (see below) can not be calculated, because it needs a metric function. </param>
        /// <returns></returns>
#endif
        public static float CalcEMD2(CvArr signature1, CvArr signature2, DistanceType distanceType, CvDistanceFunction distanceFunc, CvArr costMatrix)
        {
            float lowerBound = 0;
            return CalcEMD2(signature1, signature2, distanceType, distanceFunc, costMatrix, null, ref lowerBound);
        }
#if LANG_JP
        /// <summary>
        /// 2つの重み付き点分布間の "最小コスト（minimal work）" 距離を計算する．
        /// </summary>
        /// <param name="signature1">1番目のシグネチャ（点分布），size1×dims+1の浮動小数点型行列．各行は，重みの後に座標を保存する．ユーザ定義のコスト行列を用いる場合は，1列の行列（重みだけ）でも構わない．</param>
        /// <param name="signature2">2番目のシグネチャ（点分布）（signature1と同じフォーマット）．行数や重みの合計が異なることもあるが，この場合は余分の"dummy" 点が signature1 か signature2 のどちらかに追加される．</param>
        /// <param name="distanceType">用いる評価指標.</param>
        /// <param name="distanceFunc">ユーザ定義距離関数．2点の座標を与えると，その点間の距離を返す．</param>
        /// <param name="costMatrix">ユーザ定義の size1×size2のコスト行列．少なくとも，cost_matrix と distance_func のいずれか一つは NULL でなければならない．コスト行列を用いる場合は，下限値（下記参照）の計算は距離定義関数を必要とするため不可能である．</param>
        /// <param name="flow">結果の size1×size2のフロー行列(flow matrix)． flow_ij はsignature1のi番目の点からsignature2のj番目の点へのフローを示す．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Computes "minimal work" distance between two weighted point configurations.
        /// </summary>
        /// <param name="signature1">First signature, size1×dims+1 floating-point matrix. Each row stores the point weight followed by the point coordinates. The matrix is allowed to have a single column (weights only) if the user-defined cost matrix is used. </param>
        /// <param name="signature2">Second signature of the same format as signature1, though the number of rows may be different. The total weights may be different, in this case an extra "dummy" point is added to either signature1 or signature2. </param>
        /// <param name="distanceType">Metrics used</param>
        /// <param name="distanceFunc">The user-defined distance function. It takes coordinates of two points and returns the distance between the points. </param>
        /// <param name="costMatrix">The user-defined size1×size2 cost matrix. At least one of cost_matrix and distance_func must be NULL. Also, if a cost matrix is used, lower boundary (see below) can not be calculated, because it needs a metric function. </param>
        /// <param name="flow">The resultant size1×size2 flow matrix: flowij is a flow from i-th point of signature1 to j-th point of signature2</param>
        /// <returns></returns>
#endif
        public static float CalcEMD2(CvArr signature1, CvArr signature2, DistanceType distanceType, CvDistanceFunction distanceFunc, CvArr costMatrix, CvArr flow)
        {
            float lowerBound = 0;
            return CalcEMD2(signature1, signature2, distanceType, distanceFunc, costMatrix, flow, ref lowerBound);
        }
#if LANG_JP
        /// <summary>
        /// 2つの重み付き点分布間の "最小コスト（minimal work）" 距離を計算する．
        /// </summary>
        /// <param name="signature1">1番目のシグネチャ（点分布），size1×dims+1の浮動小数点型行列．各行は，重みの後に座標を保存する．ユーザ定義のコスト行列を用いる場合は，1列の行列（重みだけ）でも構わない．</param>
        /// <param name="signature2">2番目のシグネチャ（点分布）（signature1と同じフォーマット）．行数や重みの合計が異なることもあるが，この場合は余分の"dummy" 点が signature1 か signature2 のどちらかに追加される．</param>
        /// <param name="distanceType">用いる評価指標.</param>
        /// <param name="distanceFunc">ユーザ定義距離関数．2点の座標を与えると，その点間の距離を返す．</param>
        /// <param name="costMatrix">ユーザ定義の size1×size2のコスト行列．少なくとも，cost_matrix と distance_func のいずれか一つは NULL でなければならない．コスト行列を用いる場合は，下限値（下記参照）の計算は距離定義関数を必要とするため不可能である．</param>
        /// <param name="flow">結果の size1×size2のフロー行列(flow matrix)． flow_ij はsignature1のi番目の点からsignature2のj番目の点へのフローを示す．</param>
        /// <param name="lowerBound">オプションの入出力パラメータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Computes "minimal work" distance between two weighted point configurations.
        /// </summary>
        /// <param name="signature1">First signature, size1×dims+1 floating-point matrix. Each row stores the point weight followed by the point coordinates. The matrix is allowed to have a single column (weights only) if the user-defined cost matrix is used. </param>
        /// <param name="signature2">Second signature of the same format as signature1, though the number of rows may be different. The total weights may be different, in this case an extra "dummy" point is added to either signature1 or signature2. </param>
        /// <param name="distanceType">Metrics used</param>
        /// <param name="distanceFunc">The user-defined distance function. It takes coordinates of two points and returns the distance between the points. </param>
        /// <param name="costMatrix">The user-defined size1×size2 cost matrix. At least one of cost_matrix and distance_func must be NULL. Also, if a cost matrix is used, lower boundary (see below) can not be calculated, because it needs a metric function. </param>
        /// <param name="flow">The resultant size1×size2 flow matrix: flowij is a flow from i-th point of signature1 to j-th point of signature2</param>
        /// <param name="lowerBound">Optional input/output parameter.</param>
        /// <returns></returns>
#endif
        public static float CalcEMD2(CvArr signature1, CvArr signature2, DistanceType distanceType, CvDistanceFunction distanceFunc, CvArr costMatrix, CvArr flow, ref float lowerBound)
        {
            if (signature1 == null)
                throw new ArgumentNullException("signature1");
            if (signature2 == null)
                throw new ArgumentNullException("signature2");
            IntPtr costMatrixPtr = (costMatrix == null) ? IntPtr.Zero : costMatrix.CvPtr;
            IntPtr flowPtr = (costMatrix == null) ? IntPtr.Zero : flow.CvPtr;
            using (ScopedGCHandle distanceFuncHandle = new ScopedGCHandle(distanceFunc, GCHandleType.Normal))
            {
                return CvInvoke.cvCalcEMD2(signature1.CvPtr, signature2.CvPtr, distanceType, distanceFuncHandle.AddrOfPinnedObject(), costMatrixPtr, flowPtr, ref lowerBound, 0);
            }
        }
        #endregion
        #region CalcGlobalOrientation
#if LANG_JP
        /// <summary>
        /// 選択された複数の領域の全体的なモーション方向を計算する
        /// </summary>
        /// <param name="orientation">モーション勾配方向画像．関数 cvCalcMotionGradient によって計算されている． </param>
        /// <param name="mask">マスク画像．cvCalcMotionGradient によって得られる有効な勾配マスクと，方向を計算する必要がある領域を示すマスクの共通部分．</param>
        /// <param name="mhi">モーション履歴画像．</param>
        /// <param name="timestamp">ミリ秒単位，あるいはその他の単位で表される現在時間．cvUpdateMotionHistory の呼び出し時に引数として渡した時間を保存しておいて，ここでその値を再利用する方が良い．なぜなら大きな画像に対して cvUpdateMotionHistory と cvCalcMotionGradient を行った場合，長い処理時間を要することがあるためである． </param>
        /// <param name="duration">timestamp と同じ時間単位で表される，モーション軌跡の最大保持時間．cvUpdateMotionHistory での引数と同じ．</param>
#else
        /// <summary>
        /// Calculates global motion orientation of some selected region
        /// </summary>
        /// <param name="orientation">Motion gradient orientation image; calculated by the function cvCalcMotionGradient. </param>
        /// <param name="mask">Mask image. It may be a conjunction of valid gradient mask, obtained with cvCalcMotionGradient and mask of the region, whose direction needs to be calculated. </param>
        /// <param name="mhi">Motion history image </param>
        /// <param name="timestamp">Current time in milliseconds or other units, it is better to store time passed to cvUpdateMotionHistory before and reuse it here, because running cvUpdateMotionHistory and cvCalcMotionGradient on large images may take some time. </param>
        /// <param name="duration">Maximal duration of motion track in milliseconds, the same as in cvUpdateMotionHistory. </param>
#endif
        public static double CalcGlobalOrientation(CvArr orientation, CvArr mask, CvArr mhi, double timestamp, double duration)
        {
            if (orientation == null)
                throw new ArgumentNullException("orientation");
            if (mask == null)
                throw new ArgumentNullException("mask");
            if (mhi == null)
                throw new ArgumentNullException("mhi");
            return CvInvoke.cvCalcGlobalOrientation(orientation.CvPtr, mask.CvPtr, mhi.CvPtr, timestamp, duration);
        }
        #endregion
        #region CalcImageHomography
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="center"></param>
        /// <param name="intrinsic"></param>
        /// <param name="homography"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates homography matrix for oblong planar object (e.g. arm)
        /// </summary>
        /// <param name="line">The main object axis direction (vector (dx,dy,dz)). </param>
        /// <param name="center">Object center ((cx,cy,cz)). </param>
        /// <param name="intrinsic">Intrinsic camera parameters (3x3 matrix). </param>
        /// <param name="homography">Output homography matrix (3x3). </param>
        /// <returns></returns>

#endif
        public static void CalcImageHomography(float[] line, CvPoint3D32f center, float[,] intrinsic, out float[,] homography)
        {
            homography = new float[3, 3];
            CvInvoke.cvCalcImageHomography(line, ref center, intrinsic, homography);
        }
        #endregion
        #region CalcHist
#if LANG_JP
        /// <summary>
        /// 1つの画像のヒストグラムを計算する.
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="hist">ヒストグラムへの参照</param>
#else
        /// <summary>
        /// Calculates the histogram of one single-channel image. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="image">Source image.</param>
        /// <param name="hist">Reference to the histogram. </param>
#endif
        public static void CalcHist(IplImage image, CvHistogram hist)
        {
            CalcArrHist(image, hist);
        }
#if LANG_JP
        /// <summary>
        /// 1つの画像のヒストグラムを計算する.
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="hist">ヒストグラムへの参照</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない． </param>
#else
        /// <summary>
        /// Calculates the histogram of one single-channel image. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="image">Source image.</param>
        /// <param name="hist">Reference to the histogram. </param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
#endif
        public static void CalcHist(IplImage image, CvHistogram hist, bool accumulate)
        {
            CalcArrHist(image, hist, accumulate, null);
        }
#if LANG_JP
        /// <summary>
        /// 1つの画像のヒストグラムを計算する.
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="hist">ヒストグラムへの参照</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない．</param>
        /// <param name="mask">処理マスク．入力画像中のどのピクセルをカウントするかを決定する.</param>
#else
        /// <summary>
        /// Calculates the histogram of one single-channel image. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="image">Source image.</param>
        /// <param name="hist">Reference to the histogram. </param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
        /// <param name="mask">The operation mask, determines what pixels of the source images are counted. </param>
#endif
        public static void CalcHist(IplImage image, CvHistogram hist, bool accumulate, CvArr mask)
        {
            CalcArrHist(image, hist, accumulate, mask);
        }
#if LANG_JP
        /// <summary>
        /// 画像群のヒストグラムを計算する.
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="image">入力画像群．全て同じサイズ・タイプ．</param>
        /// <param name="hist">ヒストグラムへの参照</param>
#else
        /// <summary>
        /// Calculates the histogram of single-channel images. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="image">Source images, all are of the same size and type.</param>
        /// <param name="hist">Reference to the histogram. </param>
#endif
        public static void CalcHist(IplImage[] image, CvHistogram hist)
        {
            CalcArrHist(image, hist);
        }
#if LANG_JP
        /// <summary>
        /// 画像群のヒストグラムを計算する.
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="image">入力画像群．全て同じサイズ・タイプ．</param>
        /// <param name="hist">ヒストグラムへの参照</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない． </param>
#else
        /// <summary>
        /// Calculates the histogram of single-channel images. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="image">Source images, all are of the same size and type.</param>
        /// <param name="hist">Reference to the histogram. </param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
#endif
        public static void CalcHist(IplImage[] image, CvHistogram hist, bool accumulate)
        {
            CvArr[] arr = Array.ConvertAll(image, delegate(IplImage img) { return (CvArr)img; });
            CalcArrHist(arr, hist, accumulate, null);
        }
#if LANG_JP
        /// <summary>
        /// 画像群のヒストグラムを計算する.
        /// ヒストグラムのビンを増加（インクリメント）するために用いられるタプルの各要素は， 対応する入力画像群の同じ場所から取り出される.
        /// </summary>
        /// <param name="image">入力画像群．全て同じサイズ・タイプ．</param>
        /// <param name="hist">ヒストグラムへの参照</param>
        /// <param name="accumulate">計算フラグ．セットされている場合は，ヒストグラムは処理前には最初にクリアされない． </param>
        /// <param name="mask">処理マスク．入力画像中のどのピクセルをカウントするかを決定する.</param>
#else
        /// <summary>
        /// Calculates the histogram of single-channel images. 
        /// The elements of a tuple that is used to increment a histogram bin are taken at the same location from the corresponding input images.
        /// </summary>
        /// <param name="image">Source images, all are of the same size and type.</param>
        /// <param name="hist">Reference to the histogram. </param>
        /// <param name="accumulate">Accumulation flag. If it is set, the histogram is not cleared in the beginning. This feature allows user to compute a single histogram from several images, or to update the histogram online. </param>
        /// <param name="mask">The operation mask, determines what pixels of the source images are counted. </param>
#endif
        public static void CalcHist(IplImage[] image, CvHistogram hist, bool accumulate, CvArr mask)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (hist == null)
                throw new ArgumentNullException("hist");
            CvArr[] arr = Array.ConvertAll(image, delegate(IplImage img) { return (CvArr)img; });
            CalcArrHist(arr, hist, accumulate, mask);
        }
        #endregion
        #region CalcMatMulDeriv
#if LANG_JP
        /// <summary>
        /// Computes d(AB)/dA and d(AB)/dB
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="dABdA"></param>
        /// <param name="dABdB"></param>
#else
        /// <summary>
        /// Computes d(AB)/dA and d(AB)/dB
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="dABdA"></param>
        /// <param name="dABdB"></param>
#endif
        public static void CalcMatMulDeriv(CvMat A, CvMat B, CvMat dABdA, CvMat dABdB)
        {
            if (A == null)
                throw new ArgumentNullException("A");
            if (B == null)
                throw new ArgumentNullException("B");

            IntPtr dABdAPtr = (dABdA == null) ? IntPtr.Zero : dABdA.CvPtr;
            IntPtr dABdBPtr = (dABdB == null) ? IntPtr.Zero : dABdB.CvPtr;

            CvInvoke.cvCalcMatMulDeriv(A.CvPtr, B.CvPtr, dABdAPtr, dABdBPtr);
        }
        #endregion
        #region CalcMotionGradient
#if LANG_JP
        /// <summary>
        /// モーション履歴画像の勾配方向を計算する
        /// </summary>
        /// <param name="mhi">モーション履歴画像． </param>
        /// <param name="mask">マスク画像．モーション勾配方向として有効なピクセルがマーキングされているマスク．出力パラメータ．</param>
        /// <param name="orientation">モーション勾配方向画像．値は0~360°の角度値． </param>
        /// <param name="delta1">この関数は，各ピクセル (x,y) の近傍における 最小 (m(x,y)) および 最大 (M(x,y))の mhi 値を見つけ，次の条件を満たす場合にのみ，その勾配が有効であると仮定する．min(delta1,delta2) &lt;= M(x,y)-m(x,y) &lt;= max(delta1,delta2).</param>
        /// <param name="delta2">この関数は，各ピクセル (x,y) の近傍における 最小 (m(x,y)) および 最大 (M(x,y))の mhi 値を見つけ，次の条件を満たす場合にのみ，その勾配が有効であると仮定する．min(delta1,delta2) &lt;= M(x,y)-m(x,y) &lt;= max(delta1,delta2).</param>
#else
        /// <summary>
        /// Calculates gradient orientation of motion history image
        /// </summary>
        /// <param name="mhi">Motion history image </param>
        /// <param name="mask">Mask image; marks pixels where motion gradient data is correct. Output parameter. </param>
        /// <param name="orientation">Motion gradient orientation image; contains angles from 0 to ~360°. </param>
        /// <param name="delta1">The function finds minimum (m(x,y)) and maximum (M(x,y)) mhi values over each pixel (x,y) neihborhood and assumes the gradient is valid only if min(delta1,delta2) &lt;= M(x,y)-m(x,y) &lt;= max(delta1,delta2).</param>
        /// <param name="delta2">The function finds minimum (m(x,y)) and maximum (M(x,y)) mhi values over each pixel (x,y) neihborhood and assumes the gradient is valid only if min(delta1,delta2) &lt;= M(x,y)-m(x,y) &lt;= max(delta1,delta2).</param>
#endif
        public static void CalcMotionGradient(CvArr mhi, CvArr mask, CvArr orientation, double delta1, double delta2)
        {
            CalcMotionGradient(mhi, mask, orientation, delta1, delta2, ApertureSize.Size3);
        }
#if LANG_JP
        /// <summary>
        /// モーション履歴画像の勾配方向を計算する
        /// </summary>
        /// <param name="mhi">モーション履歴画像． </param>
        /// <param name="mask">マスク画像．モーション勾配方向として有効なピクセルがマーキングされているマスク．出力パラメータ．</param>
        /// <param name="orientation">モーション勾配方向画像．値は0~360°の角度値．</param>
        /// <param name="delta1">この関数は，各ピクセル (x,y) の近傍における 最小 (m(x,y)) および 最大 (M(x,y))の mhi 値を見つけ，次の条件を満たす場合にのみ，その勾配が有効であると仮定する．min(delta1,delta2) &lt;= M(x,y)-m(x,y) &lt;= max(delta1,delta2).</param>
        /// <param name="delta2">この関数は，各ピクセル (x,y) の近傍における 最小 (m(x,y)) および 最大 (M(x,y))の mhi 値を見つけ，次の条件を満たす場合にのみ，その勾配が有効であると仮定する．min(delta1,delta2) &lt;= M(x,y)-m(x,y) &lt;= max(delta1,delta2).</param>
        /// <param name="apertureSize">この関数で用いられるいられる微分オペレータのアパーチャサイズ．</param>

#else
        /// <summary>
        /// Calculates gradient orientation of motion history image
        /// </summary>
        /// <param name="mhi">Motion history image </param>
        /// <param name="mask">Mask image; marks pixels where motion gradient data is correct. Output parameter. </param>
        /// <param name="orientation">Motion gradient orientation image; contains angles from 0 to ~360°. </param>
        /// <param name="delta1">The function finds minimum (m(x,y)) and maximum (M(x,y)) mhi values over each pixel (x,y) neihborhood and assumes the gradient is valid only if min(delta1,delta2) &lt;= M(x,y)-m(x,y) &lt;= max(delta1,delta2).</param>
        /// <param name="delta2">The function finds minimum (m(x,y)) and maximum (M(x,y)) mhi values over each pixel (x,y) neihborhood and assumes the gradient is valid only if min(delta1,delta2) &lt;= M(x,y)-m(x,y) &lt;= max(delta1,delta2).</param>
        /// <param name="apertureSize">Aperture size of derivative operators used by the function: CV_SCHARR, 1, 3, 5 or 7 (see cvSobel). </param>
#endif
        public static void CalcMotionGradient(CvArr mhi, CvArr mask, CvArr orientation, double delta1, double delta2, ApertureSize apertureSize)
        {
            if (mhi == null)
                throw new ArgumentNullException("mhi");
            if (orientation == null)
                throw new ArgumentNullException("orientation");

            CvInvoke.cvCalcMotionGradient(mhi.CvPtr, mask.CvPtr, orientation.CvPtr, delta1, delta2, apertureSize);
        }
        #endregion
        #region CalcOpticalFlowBM
        // ReSharper disable InconsistentNaming
#if LANG_JP
        /// <summary>
        /// 重なり合ったblock_size.Width x block_size.Heightピクセルのブロック毎にオプティカルフローを計算する
        /// </summary>
        /// <param name="prev">1番目の画像，8 ビット，シングルチャンネル．</param>
        /// <param name="curr">2番目の画像，8 ビット，シングルチャンネル．</param>
        /// <param name="blockSize">比較対象となる基本ブロックのサイズ． </param>
        /// <param name="shiftSize">ブロック座標の増加量． </param>
        /// <param name="maxRange">走査対象となるブロックの近傍領域．ピクセル単位．</param>
        /// <param name="usePrevious">trueの場合、前の（入力）速度場を用いる． </param>
        /// <param name="velx">次ののオプティカルフローの水平成分. ceil(prev->width/block_size.width)×ceil(prev->height/block_size.height) のサイズ， 32 ビット浮動小数点型，シングルチャンネル. </param>
        /// <param name="vely">velx と同一サイズ，32 ビット浮動小数点型，シングルチャンネルのオプティカルフローの垂直成分．</param>
#else
        /// <summary>
        /// Calculates optical flow for two images by block matching method
        /// </summary>
        /// <param name="prev">First image, 8-bit, single-channel. </param>
        /// <param name="curr">Second image, 8-bit, single-channel. </param>
        /// <param name="blockSize">Size of basic blocks that are compared. </param>
        /// <param name="shiftSize">Block coordinate increments. </param>
        /// <param name="maxRange">Size of the scanned neighborhood in pixels around block. </param>
        /// <param name="usePrevious">Uses previous (input) velocity field. </param>
        /// <param name="velx">Horizontal component of the optical flow of floor((prev->width - block_size.width)/shiftSize.width) × floor((prev->height - block_size.height)/shiftSize.height) size, 32-bit floating-point, single-channel. </param>
        /// <param name="vely">Vertical component of the optical flow of the same size velx, 32-bit floating-point, single-channel. </param>
#endif
        public static void CalcOpticalFlowBM(CvArr prev, CvArr curr, CvSize blockSize, CvSize shiftSize, CvSize maxRange, bool usePrevious, CvArr velx, CvArr vely)
        {
            if (prev == null)
                throw new ArgumentNullException("prev");
            if (curr == null)
                throw new ArgumentNullException("curr");
            if (velx == null)
                throw new ArgumentNullException("velx");
            if (vely == null)
                throw new ArgumentNullException("vely");
            CvInvoke.cvCalcOpticalFlowBM(prev.CvPtr, curr.CvPtr, blockSize, shiftSize, maxRange, usePrevious, velx.CvPtr, vely.CvPtr);
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region CalcOpticalFlowFarneback
#if LANG_JP
        /// <summary>
        /// Estimate optical flow for each pixel using the two-frame G. Farneback algorithm
        /// </summary>
        /// <param name="prev"></param>
        /// <param name="next"></param>
        /// <param name="flow"></param>
        /// <param name="pyr_scale"></param>
        /// <param name="levels"></param>
        /// <param name="winsize"></param>
        /// <param name="iterations"></param>
        /// <param name="poly_n"></param>
        /// <param name="poly_sigma"></param>
        /// <param name="flags"></param>
#else
        /// <summary>
        /// Estimate optical flow for each pixel using the two-frame G. Farneback algorithm
        /// </summary>
        /// <param name="prev"></param>
        /// <param name="next"></param>
        /// <param name="flow"></param>
        /// <param name="pyr_scale"></param>
        /// <param name="levels"></param>
        /// <param name="winsize"></param>
        /// <param name="iterations"></param>
        /// <param name="poly_n"></param>
        /// <param name="poly_sigma"></param>
        /// <param name="flags"></param>
#endif
        public static void CalcOpticalFlowFarneback(CvArr prev, CvArr next, CvArr flow,
            double pyr_scale, int levels, int winsize, int iterations, int poly_n, double poly_sigma, LKFlowFlag flags)
        {
            if (prev == null)
                throw new ArgumentNullException("prev");
            if (next == null)
                throw new ArgumentNullException("next");
            if (flow == null)
                throw new ArgumentNullException("flow");

            CvInvoke.cvCalcOpticalFlowFarneback(prev.CvPtr, next.CvPtr, flow.CvPtr, pyr_scale, levels, winsize, iterations, poly_n, poly_sigma, flags);
        }
        #endregion
        #region CalcOpticalFlowHS
#if LANG_JP
        /// <summary>
        /// Horn &amp; Schunck アルゴリズムを用いて，1番目の入力画像の全ピクセルに対するフローを，2番目の画像を参照して計算する．
        /// </summary>
        /// <param name="prev">1番目の画像，8 ビット，シングルチャンネル．</param>
        /// <param name="curr">2番目の画像，8 ビット，シングルチャンネル．</param>
        /// <param name="use_previous">trueの場合、前の（入力）速度場を用いる．</param>
        /// <param name="velx">入力画像と同じサイズのオプティカルフローの水平成分，32 ビット浮動小数点型，シングルチャンネル．</param>
        /// <param name="vely">入力画像と同じサイズのオプティカルフローの垂直成分，32 ビット浮動小数点型，シングルチャンネル．</param>
        /// <param name="lambda">ラグランジュ乗数</param>
        /// <param name="criteria">速度計算の終了条件</param>	
#else
        /// <summary>
        /// Computes flow for every pixel of the first input image using Horn &amp; Schunck algorithm
        /// </summary>
        /// <param name="prev">First image, 8-bit, single-channel. </param>
        /// <param name="curr">Second image, 8-bit, single-channel. </param>
        /// <param name="use_previous">Uses previous (input) velocity field. </param>
        /// <param name="velx">Horizontal component of the optical flow of the same size as input images, 32-bit floating-point, single-channel. </param>
        /// <param name="vely">Vertical component of the optical flow of the same size as input images, 32-bit floating-point, single-channel. </param>
        /// <param name="lambda">Lagrangian multiplier. </param>
        /// <param name="criteria">Criteria of termination of velocity computing. </param>
#endif
        public static void CalcOpticalFlowHS(CvArr prev, CvArr curr, bool use_previous, CvArr velx, CvArr vely, double lambda, CvTermCriteria criteria)
        {
            if (prev == null)
                throw new ArgumentNullException("prev");
            if (curr == null)
                throw new ArgumentNullException("curr");
            if (velx == null)
                throw new ArgumentNullException("velx");
            if (vely == null)
                throw new ArgumentNullException("vely");
            CvInvoke.cvCalcOpticalFlowHS(prev.CvPtr, curr.CvPtr, use_previous, velx.CvPtr, vely.CvPtr, lambda, criteria);
        }
        #endregion
        #region CalcOpticalFlowLK
#if LANG_JP
        /// <summary>
        /// Lucas &amp; Kanade アルゴリズムを用いて，1番目の入力画像の全ピクセルに対するフローを，2番目の画像を参照して計算する．
        /// </summary>
        /// <param name="prev">1番目の画像，8 ビット，シングルチャンネル．</param>
        /// <param name="curr">2番目の画像，8 ビット，シングルチャンネル．</param>
        /// <param name="winSize">ピクセルをグループ化するために用いられる平均化ウィンドウのサイズ</param>
        /// <param name="velx">入力画像と同じサイズのオプティカルフローの水平成分，32 ビット浮動小数点型，シングルチャンネル．</param>
        /// <param name="vely">入力画像と同じサイズのオプティカルフローの垂直成分，32 ビット浮動小数点型，シングルチャンネル．</param>	
#else
        /// <summary>
        /// Computes flow for every pixel of the first input image using Lucas &amp; Kanade algorithm
        /// </summary>
        /// <param name="prev">First image, 8-bit, single-channel. </param>
        /// <param name="curr">Second image, 8-bit, single-channel. </param>
        /// <param name="winSize">Size of the averaging window used for grouping pixels. </param>
        /// <param name="velx">Horizontal component of the optical flow of the same size as input images, 32-bit floating-point, single-channel. </param>
        /// <param name="vely">Vertical component of the optical flow of the same size as input images, 32-bit floating-point, single-channel. </param>
#endif
        public static void CalcOpticalFlowLK(CvArr prev, CvArr curr, CvSize winSize, CvArr velx, CvArr vely)
        {
            if (prev == null)
                throw new ArgumentNullException("prev");
            if (curr == null)
                throw new ArgumentNullException("curr");
            if (velx == null)
                throw new ArgumentNullException("velx");
            if (vely == null)
                throw new ArgumentNullException("vely");
            CvInvoke.cvCalcOpticalFlowLK(prev.CvPtr, curr.CvPtr, winSize, velx.CvPtr, vely.CvPtr);
        }
        #endregion
        #region CalcOpticalFlowPyrLK
#if LANG_JP
        /// <summary>
        ///  Lucas-Kanade オプティカルフローの， ピラミッドを用いて疎な特徴に対応した反復バージョン（[Bouguet00]）の実装である．
        /// 前フレームにおける特徴点の座標が与えられた場合に，現在のフレームにおける特徴点の座標が計算される．座標はサブピクセル精度で検出される． 
        /// </summary>
        /// <param name="prev">1番目のフレーム（時間 t）</param>
        /// <param name="curr">2番目のフレーム（時間 t + dt）</param>
        /// <param name="prevPyr">最初の画像に対するピラミッドのバッファ．これが NULL でない場合は，このバッファは，レベル 1 からレベル#level までのピラミッドを格納するのに十分なサイズでなければならない． (image_width+8)*image_height/3 バイトの合計が十分なサイズとなる．</param>
        /// <param name="currPyr">prev_pyr と同様に，2番目のフレームに対して用いられる</param>
        /// <param name="prevFeatures">フローを検出するのに必要な点の配列</param>
        /// <param name="currFeatures">2次元の点の配列．2番目の画像（フレーム）中の入力特徴の新たな位置が計算され，ここに格納される</param>
        /// <param name="winSize">各ピラミッドレベルでの探索ウィンドウのサイズ</param>
        /// <param name="level">ピラミッドレベルの最大値．0 の場合はピラミッドは用いられない（シングルレベル）．1 の場合はレベル 2 となる．</param>
        /// <param name="status">配列．特徴に対応するフローが見つかった場合に，配列の各要素 が 1 にセットされる．そうでない場合は0 になる．</param>	
        /// <param name="criteria">各ピラミッドの各点に対するフローを検出する繰り返し計算の終了条件</param>
        /// <param name="flags">雑多なフラグ</param>	
#else
        /// <summary>
        /// Calculates optical flow for a sparse feature set using iterative Lucas-Kanade method in pyramids
        /// </summary>
        /// <param name="prev">First frame, at time t. </param>
        /// <param name="curr">Second frame, at time t + dt . </param>
        /// <param name="prevPyr">Buffer for the pyramid for the first frame. If the pointer is not null , the buffer must have a sufficient size to store the pyramid from level 1 to level #level ; the total size of (image_width+8)*image_height/3 bytes is sufficient. </param>
        /// <param name="currPyr">Similar to prev_pyr, used for the second frame. </param>
        /// <param name="prevFeatures">Array of points for which the flow needs to be found. </param>
        /// <param name="currFeatures">Array of 2D points containing calculated new positions of input features in the second image. </param>
        /// <param name="winSize">Size of the search window of each pyramid level. </param>
        /// <param name="level">Maximal pyramid level number. If 0 , pyramids are not used (single level), if 1 , two levels are used, etc. </param>
        /// <param name="status">Array. Every element of the array is set to 1 if the flow for the corresponding feature has been found, 0 otherwise. </param>
        /// <param name="criteria">Specifies when the iteration process of finding the flow for each point on each pyramid level should be stopped. </param>
        /// <param name="flags">Miscellaneous flags</param>
#endif
        public static void CalcOpticalFlowPyrLK(CvArr prev, CvArr curr, CvArr prevPyr, CvArr currPyr, CvPoint2D32f[] prevFeatures, out CvPoint2D32f[] currFeatures,
            CvSize winSize, int level, out sbyte[] status, CvTermCriteria criteria, LKFlowFlag flags)
        {
            float[] trackError;
            CalcOpticalFlowPyrLK(prev, curr, prevPyr, currPyr, prevFeatures, out currFeatures, winSize, level, out status, out trackError, criteria, flags);
        }
#if LANG_JP
        /// <summary>
        ///  Lucas-Kanade オプティカルフローの， ピラミッドを用いて疎な特徴に対応した反復バージョン（[Bouguet00]）の実装である．
        /// 前フレームにおける特徴点の座標が与えられた場合に，現在のフレームにおける特徴点の座標が計算される．座標はサブピクセル精度で検出される． 
        /// </summary>
        /// <param name="prev">1番目のフレーム（時間 t）</param>
        /// <param name="curr">2番目のフレーム（時間 t + dt）</param>
        /// <param name="prevPyr">最初の画像に対するピラミッドのバッファ．これが NULL でない場合は，このバッファは，レベル 1 からレベル#level までのピラミッドを格納するのに十分なサイズでなければならない． (image_width+8)*image_height/3 バイトの合計が十分なサイズとなる．</param>
        /// <param name="currPyr">prev_pyr と同様に，2番目のフレームに対して用いられる</param>
        /// <param name="prevFeatures">フローを検出するのに必要な点の配列</param>
        /// <param name="currFeatures">2次元の点の配列．2番目の画像（フレーム）中の入力特徴の新たな位置が計算され，ここに格納される</param>
        /// <param name="winSize">各ピラミッドレベルでの探索ウィンドウのサイズ</param>
        /// <param name="level">ピラミッドレベルの最大値．0 の場合はピラミッドは用いられない（シングルレベル）．1 の場合はレベル 2 となる．</param>
        /// <param name="status">配列．特徴に対応するフローが見つかった場合に，配列の各要素 が 1 にセットされる．そうでない場合は0 になる．</param>	
        /// <param name="trackError">移動前の点と移動後の点の周辺領域の差（誤差）を含む倍精度型の配列．オプションパラメータ（NULL も取りうる）．</param>	
        /// <param name="criteria">各ピラミッドの各点に対するフローを検出する繰り返し計算の終了条件</param>
        /// <param name="flags">雑多なフラグ</param>	
#else
        /// <summary>
        /// Calculates optical flow for a sparse feature set using iterative Lucas-Kanade method in pyramids
        /// </summary>
        /// <param name="prev">First frame, at time t. </param>
        /// <param name="curr">Second frame, at time t + dt . </param>
        /// <param name="prevPyr">Buffer for the pyramid for the first frame. If the pointer is not null , the buffer must have a sufficient size to store the pyramid from level 1 to level #level ; the total size of (image_width+8)*image_height/3 bytes is sufficient. </param>
        /// <param name="currPyr">Similar to prev_pyr, used for the second frame. </param>
        /// <param name="prevFeatures">Array of points for which the flow needs to be found. </param>
        /// <param name="currFeatures">Array of 2D points containing calculated new positions of input features in the second image. </param>
        /// <param name="winSize">Size of the search window of each pyramid level. </param>
        /// <param name="level">Maximal pyramid level number. If 0 , pyramids are not used (single level), if 1 , two levels are used, etc. </param>
        /// <param name="status">Array. Every element of the array is set to 1 if the flow for the corresponding feature has been found, 0 otherwise. </param>
        /// <param name="trackError">Array of double numbers containing difference between patches around the original and moved points. Optional parameter; can be NULL . </param>
        /// <param name="criteria">Specifies when the iteration process of finding the flow for each point on each pyramid level should be stopped. </param>
        /// <param name="flags">Miscellaneous flags</param>
#endif
        public static void CalcOpticalFlowPyrLK(CvArr prev, CvArr curr, CvArr prevPyr, CvArr currPyr, CvPoint2D32f[] prevFeatures, out CvPoint2D32f[] currFeatures,
            CvSize winSize, int level, out sbyte[] status, out float[] trackError, CvTermCriteria criteria, LKFlowFlag flags)
        {
            if (prev == null)
                throw new ArgumentNullException("prev");
            if (curr == null)
                throw new ArgumentNullException("curr");
            //if (prev_pyr == null)
            //    throw new ArgumentNullException("prev_pyr");
            //if (curr_pyr == null)
            //    throw new ArgumentNullException("curr_pyr");
            if (prevFeatures == null)
                throw new ArgumentNullException("prevFeatures");

            IntPtr prevPyrPtr = (prevPyr == null) ? IntPtr.Zero : prevPyr.CvPtr;
            IntPtr currPyrPtr = (currPyr == null) ? IntPtr.Zero : currPyr.CvPtr;
            currFeatures = new CvPoint2D32f[prevFeatures.Length];
            status = new sbyte[prevFeatures.Length];
            trackError = new float[prevFeatures.Length];

            CvInvoke.cvCalcOpticalFlowPyrLK(prev.CvPtr, curr.CvPtr, prevPyrPtr, currPyrPtr, prevFeatures, currFeatures, prevFeatures.Length, winSize, level, status, trackError, criteria, flags);
        }
        #endregion
        #region CalcPCA
#if LANG_JP
        /// <summary>
        /// ベクトル集合の主成分分析を行う
        /// </summary>
        /// <param name="data">入力データ．それぞれのベクトルは単一行（CV_PCA_DATA_AS_ROW）か，単一列（CV_PCA_DATA_AS_COL）である．</param>
        /// <param name="avg">平均ベクトル．関数内で計算されるか，ユーザによって与えられる． </param>
        /// <param name="eigenvalues">出力である共変動行列の固有値．</param>
        /// <param name="eigenvectors">出力である共変動行列の固有ベクトル（つまり，主成分）．一つの行が一つのベクトルを意味する．</param>
        /// <param name="flags">操作フラグ.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Performs Principal Component Analysis of a vector set
        /// </summary>
        /// <param name="data">The input data; each vector is either a single row (CV_PCA_DATA_AS_ROW) or a single column (CV_PCA_DATA_AS_COL).  </param>
        /// <param name="avg">The mean (average) vector, computed inside the function or provided by user. </param>
        /// <param name="eigenvalues">The output eigenvalues of covariation matrix. </param>
        /// <param name="eigenvectors">The output eigenvectors of covariation matrix (i.e. principal components); one vector per row. </param>
        /// <param name="flags">The operation flags</param>
        /// <returns></returns>
#endif
        public static void CalcPCA(CvArr data, CvArr avg, CvArr eigenvalues, CvArr eigenvectors, PCAFlag flags)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (avg == null)
            {
                throw new ArgumentNullException("avg");
            }
            CvInvoke.cvCalcPCA(data.CvPtr, avg.CvPtr, eigenvalues.CvPtr, eigenvectors.CvPtr, flags);
        }
        #endregion
        #region CalcPGH
#if LANG_JP
        /// <summary>
        /// 輪郭の pair-wise geometrical histogram を求める
        /// </summary>
        /// <param name="contour">入力輪郭．現在のところ座標が整数値の点のみが利用可能.</param>
        /// <param name="hist">求められたヒストグラム．必ず2次元になる．</param>
#else
        /// <summary>
        /// Calculates pair-wise geometrical histogram for contour
        /// </summary>
        /// <param name="contour">Input contour. Currently, only integer point coordinates are allowed. </param>
        /// <param name="hist">Calculated histogram; must be two-dimensional. </param>
#endif
// ReSharper disable InconsistentNaming
        public static void CalcPGH(CvSeq contour, CvHistogram hist)
// ReSharper restore InconsistentNaming
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            if (hist == null)
            {
                throw new ArgumentNullException("hist");
            }
            CvInvoke.cvCalcPGH(contour.CvPtr, hist.CvPtr);
        }
        #endregion
        #region CalcProbDensity
#if LANG_JP
        /// <summary>
        /// 一つのヒストグラムをもう一方のヒストグラムで割る
        /// </summary>
        /// <param name="hist1">一番目のヒストグラム（除数）</param>
        /// <param name="hist2">二番目のヒストグラム</param>
        /// <param name="dstHist">出力ヒストグラム</param>
#else
        /// <summary>
        /// Divides one histogram by another.
        /// </summary>
        /// <param name="hist1">first histogram (the divisor). </param>
        /// <param name="hist2">second histogram. </param>
        /// <param name="dstHist">destination histogram. </param>
#endif
        public static void CalcProbDensity(CvHistogram hist1, CvHistogram hist2, CvHistogram dstHist)
        {
            CalcProbDensity(hist1, hist2, dstHist, 255);
        }
#if LANG_JP
        /// <summary>
        /// 一つのヒストグラムをもう一方のヒストグラムで割る
        /// </summary>
        /// <param name="hist1">一番目のヒストグラム（除数）</param>
        /// <param name="hist2">二番目のヒストグラム</param>
        /// <param name="dstHist">出力ヒストグラム</param>
        /// <param name="scale">出力ヒストグラムのスケール係数</param>
#else
        /// <summary>
        /// Divides one histogram by another.
        /// </summary>
        /// <param name="hist1">first histogram (the divisor). </param>
        /// <param name="hist2">second histogram. </param>
        /// <param name="dstHist">destination histogram. </param>
        /// <param name="scale">scale factor for the destination histogram. </param>
#endif
        public static void CalcProbDensity(CvHistogram hist1, CvHistogram hist2, CvHistogram dstHist, double scale)
        {
            if (hist1 == null)
                throw new ArgumentNullException("hist1");
            if (hist2 == null)
                throw new ArgumentNullException("hist2");
            if (dstHist == null)
                throw new ArgumentNullException("dstHist");
            CvInvoke.cvCalcProbDensity(hist1.CvPtr, hist2.CvPtr, dstHist.CvPtr, scale);
        }
        #endregion
        #region CalcSubdivVoronoi2D
#if LANG_JP
        /// <summary>
        /// 仮想点の座標を計算する．元の細分割面のある頂点に対応する仮想点全てを接続すると，その頂点を含むボロノイ領域の境界を構成する． 
        /// </summary>
        /// <param name="subdiv">ドロネー細分割．全ての点は追加済みである</param>
#else
        /// <summary>
        /// Calculates coordinates of Voronoi diagram cells.
        /// </summary>
        /// <param name="subdiv">Delaunay subdivision, where all the points are added already. </param>
#endif
        public static void CalcSubdivVoronoi2D(CvSubdiv2D subdiv)
        {
            if (subdiv == null)
            {
                throw new ArgumentNullException("subdiv");
            }
            CvInvoke.cvCalcSubdivVoronoi2D(subdiv.CvPtr);
        }
        #endregion
        #region CalibrateCamera2
#if LANG_JP
        /// <summary>
        /// 内部パラメータと各画像に対する 外部パラメータを推定する．
        /// </summary>
        /// <param name="object_points">オブジェクト（キャリブレーションパターン）上の点群座標の結合行列．3xN または Nx3の配列．Nはすべてのビューでの点の数の合計である.</param>
        /// <param name="image_points">対応する画像上の点群座標の結合行列． 2xN またはNx2 の配列．Nはすべてのビューでの点の数の合計である．</param>
        /// <param name="point_counts">それぞれのビューに含まれる点の数を表すベクトル．サ イズは 1xM または Mx1 でMはビューの数．1xM or Mx1</param>
        /// <param name="image_size">画像サイズ．内部カメラ行列の初期化のみに用いられる.</param>
        /// <param name="intrinsic_matrix">出力されるカメラ行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. CV_CALIB_USE_INTRINSIC_GUESS  や CV_CALIB_FIX_ASPECT_RATION が指定され た場合，fx, fy, cx, cyのパラメータのうち いくつか，またはすべてを初期化する必要がある．</param>
        /// <param name="distortion_coeffs">出力される1x4のひずみ係数ベクトル [k1, k2, p1, p2]. </param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="object_points">The joint matrix of object points, 3xN or Nx3, where N is the total number of points in all views. </param>
        /// <param name="image_points">The joint matrix of corresponding image points, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="point_counts">Vector containing numbers of points in each particular view, 1xM or Mx1, where M is the number of a scene views. </param>
        /// <param name="image_size">Size of the image, used only to initialize intrinsic camera matrix. </param>
        /// <param name="intrinsic_matrix">The output camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS and/or CV_CALIB_FIX_ASPECT_RATION are specified, some or all of fx, fy, cx, cy must be initialized. </param>
        /// <param name="distortion_coeffs">The output 4x1 or 1x4 vector of distortion coefficients [k1, k2, p1, p2]. </param>
#endif
        public static void CalibrateCamera2(CvMat object_points, CvMat image_points, CvMat point_counts, CvSize image_size, CvMat intrinsic_matrix, CvMat distortion_coeffs)
        {
            CalibrateCamera2(object_points, image_points, point_counts, image_size, intrinsic_matrix, distortion_coeffs, null, null, CalibrationFlag.Default);
        }
#if LANG_JP
        /// <summary>
        /// 内部パラメータと各画像に対する 外部パラメータを推定する．
        /// </summary>
        /// <param name="object_points">オブジェクト（キャリブレーションパターン）上の点群座標の結合行列．3xN または Nx3の配列．Nはすべてのビューでの点の数の合計である.</param>
        /// <param name="image_points">対応する画像上の点群座標の結合行列． 2xN またはNx2 の配列．Nはすべてのビューでの点の数の合計である．</param>
        /// <param name="point_counts">それぞれのビューに含まれる点の数を表すベクトル．サ イズは 1xM または Mx1 でMはビューの数．1xM or Mx1</param>
        /// <param name="image_size">画像サイズ．内部カメラ行列の初期化のみに用いられる.</param>
        /// <param name="intrinsic_matrix">出力されるカメラ行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. CV_CALIB_USE_INTRINSIC_GUESS  や CV_CALIB_FIX_ASPECT_RATION が指定され た場合，fx, fy, cx, cyのパラメータのうち いくつか，またはすべてを初期化する必要がある．</param>
        /// <param name="distortion_coeffs">出力される1x4のひずみ係数ベクトル [k1, k2, p1, p2]. </param>
        /// <param name="rotation_vectors">出力される3xMの回転ベクトルの配列 (コンパクトな回転行列の表記についてはcvRodrigues2を参照)．</param>
        /// <param name="translation_vectors">出力される3xMの並進ベクトルの配列．</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="object_points">The joint matrix of object points, 3xN or Nx3, where N is the total number of points in all views. </param>
        /// <param name="image_points">The joint matrix of corresponding image points, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="point_counts">Vector containing numbers of points in each particular view, 1xM or Mx1, where M is the number of a scene views. </param>
        /// <param name="image_size">Size of the image, used only to initialize intrinsic camera matrix. </param>
        /// <param name="intrinsic_matrix">The output camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS and/or CV_CALIB_FIX_ASPECT_RATION are specified, some or all of fx, fy, cx, cy must be initialized. </param>
        /// <param name="distortion_coeffs">The output 4x1 or 1x4 vector of distortion coefficients [k1, k2, p1, p2]. </param>
        /// <param name="rotation_vectors">The output 3xM or Mx3 array of rotation vectors (compact representation of rotation matrices, see cvRodrigues2). </param>
        /// <param name="translation_vectors">The output 3xM or Mx3 array of translation vectors. </param>
#endif
        public static void CalibrateCamera2(CvMat object_points, CvMat image_points, CvMat point_counts, CvSize image_size, CvMat intrinsic_matrix, CvMat distortion_coeffs, CvMat rotation_vectors, CvMat translation_vectors)
        {
            CalibrateCamera2(object_points, image_points, point_counts, image_size, intrinsic_matrix, distortion_coeffs, rotation_vectors, translation_vectors, CalibrationFlag.Default);
        }
#if LANG_JP
        /// <summary>
        /// 内部パラメータと各画像に対する 外部パラメータを推定する．
        /// </summary>
        /// <param name="object_points">オブジェクト（キャリブレーションパターン）上の点群座標の結合行列．3xN または Nx3の配列．Nはすべてのビューでの点の数の合計である.</param>
        /// <param name="image_points">対応する画像上の点群座標の結合行列． 2xN またはNx2 の配列．Nはすべてのビューでの点の数の合計である．</param>
        /// <param name="point_counts">それぞれのビューに含まれる点の数を表すベクトル．サ イズは 1xM または Mx1 でMはビューの数．1xM or Mx1</param>
        /// <param name="image_size">画像サイズ．内部カメラ行列の初期化のみに用いられる.</param>
        /// <param name="intrinsic_matrix">出力されるカメラ行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. CV_CALIB_USE_INTRINSIC_GUESS  や CV_CALIB_FIX_ASPECT_RATION が指定され た場合，fx, fy, cx, cyのパラメータのうち いくつか，またはすべてを初期化する必要がある．</param>
        /// <param name="distortion_coeffs">出力される1x4のひずみ係数ベクトル [k1, k2, p1, p2]. </param>
        /// <param name="rotation_vectors">出力される3xMの回転ベクトルの配列 (コンパクトな回転行列の表記についてはcvRodrigues2を参照)．</param>
        /// <param name="translation_vectors">出力される3xMの並進ベクトルの配列．</param>
        /// <param name="flags">処理フラグ</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="object_points">The joint matrix of object points, 3xN or Nx3, where N is the total number of points in all views. </param>
        /// <param name="image_points">The joint matrix of corresponding image points, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="point_counts">Vector containing numbers of points in each particular view, 1xM or Mx1, where M is the number of a scene views. </param>
        /// <param name="image_size">Size of the image, used only to initialize intrinsic camera matrix. </param>
        /// <param name="intrinsic_matrix">The output camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS and/or CV_CALIB_FIX_ASPECT_RATION are specified, some or all of fx, fy, cx, cy must be initialized. </param>
        /// <param name="distortion_coeffs">The output 4x1 or 1x4 vector of distortion coefficients [k1, k2, p1, p2]. </param>
        /// <param name="rotation_vectors">The output 3xM or Mx3 array of rotation vectors (compact representation of rotation matrices, see cvRodrigues2). </param>
        /// <param name="translation_vectors">The output 3xM or Mx3 array of translation vectors. </param>
        /// <param name="flags">Different flags</param>
#endif
        public static void CalibrateCamera2(CvMat object_points, CvMat image_points, CvMat point_counts, CvSize image_size, CvMat intrinsic_matrix, CvMat distortion_coeffs, CvMat rotation_vectors, CvMat translation_vectors, CalibrationFlag flags)
        {
            if (object_points == null)
                throw new ArgumentNullException("object_points");
            if (image_points == null)
                throw new ArgumentNullException("image_points");
            if (point_counts == null)
                throw new ArgumentNullException("point_counts");
            if (intrinsic_matrix == null)
                throw new ArgumentNullException("intrinsic_matrix");
            if (distortion_coeffs == null)
                throw new ArgumentNullException("distortion_coeffs");

            IntPtr rotation_vectors_ptr = ToPtr(rotation_vectors);
            IntPtr translation_vectors_ptr = ToPtr(translation_vectors);
            CvInvoke.cvCalibrateCamera2(object_points.CvPtr, image_points.CvPtr, point_counts.CvPtr, image_size, intrinsic_matrix.CvPtr, distortion_coeffs.CvPtr, rotation_vectors_ptr, translation_vectors_ptr, flags);
        }
        #endregion
        #region CalibrationMatrixValues
#if LANG_JP
        /// <summary>
        /// 様々なカメラ特性を計算する
        /// </summary>
        /// <param name="camera_matrix">内部パラメータ行列（例えば cvCalibrateCamera2 によって求められたもの）． </param>
        /// <param name="image_size">画像のサイズ．ピクセル単位.</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="camera_matrix">The matrix of intrinsic parameters, e.g. computed by cvCalibrateCamera2</param>
        /// <param name="image_size">Image size in pixels </param>
#endif
        public static void CalibrationMatrixValues(CvMat camera_matrix, CvSize image_size)
        {
            double fovx, fovy;
            double focal_length;
            CvPoint2D64f principal_point;
            double pixel_aspect_ratio;
            CalibrationMatrixValues(camera_matrix, image_size, 0, 0,
                out fovx, out fovy, out focal_length, out principal_point, out pixel_aspect_ratio);
        }
#if LANG_JP
        /// <summary>
        /// 様々なカメラ特性を計算する
        /// </summary>
        /// <param name="camera_matrix">内部パラメータ行列（例えば cvCalibrateCamera2 によって求められたもの）． </param>
        /// <param name="image_size">画像のサイズ．ピクセル単位.</param>
        /// <param name="aperture_width">アパーチャ幅．実際の長さ単位．</param>
        /// <param name="aperture_height">アパーチャ高さ．実際の長さ単位．</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="camera_matrix">The matrix of intrinsic parameters, e.g. computed by cvCalibrateCamera2</param>
        /// <param name="image_size">Image size in pixels </param>
        /// <param name="aperture_width">Aperture width in realworld units</param>
        /// <param name="aperture_height">Aperture width in realworld units</param>
#endif
        public static void CalibrationMatrixValues(CvMat camera_matrix, CvSize image_size, double aperture_width, double aperture_height)
        {
            double fovx, fovy;
            double focal_length;
            CvPoint2D64f principal_point;
            double pixel_aspect_ratio;
            CalibrationMatrixValues(camera_matrix, image_size, aperture_width, aperture_height,
                out fovx, out fovy, out focal_length, out principal_point, out pixel_aspect_ratio);
        }
#if LANG_JP
        /// <summary>
        /// 様々なカメラ特性を計算する
        /// </summary>
        /// <param name="camera_matrix">内部パラメータ行列（例えば cvCalibrateCamera2 によって求められたもの）． </param>
        /// <param name="image_size">画像のサイズ．ピクセル単位.</param>
        /// <param name="aperture_width">アパーチャ幅．実際の長さ単位．</param>
        /// <param name="aperture_height">アパーチャ高さ．実際の長さ単位．</param>
        /// <param name="fovx">x-方向の画角．degree単位.</param>
        /// <param name="fovy">y-方向の画角．degree単位.</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="camera_matrix">The matrix of intrinsic parameters, e.g. computed by cvCalibrateCamera2</param>
        /// <param name="image_size">Image size in pixels </param>
        /// <param name="aperture_width">Aperture width in realworld units</param>
        /// <param name="aperture_height">Aperture width in realworld units</param>
        /// <param name="fovx">Field of view angle in x direction in degrees</param>
        /// <param name="fovy">Field of view angle in y direction in degrees</param>
#endif
        public static void CalibrationMatrixValues(
            CvMat camera_matrix, CvSize image_size, double aperture_width, double aperture_height,
            out double fovx, out double fovy)
        {
            double focal_length;
            CvPoint2D64f principal_point;
            double pixel_aspect_ratio;
            CalibrationMatrixValues(camera_matrix, image_size, aperture_width, aperture_height,
                out fovx, out fovy, out focal_length, out principal_point, out pixel_aspect_ratio);
        }
#if LANG_JP
        /// <summary>
        /// 様々なカメラ特性を計算する
        /// </summary>
        /// <param name="camera_matrix">内部パラメータ行列（例えば cvCalibrateCamera2 によって求められたもの）． </param>
        /// <param name="image_size">画像のサイズ．ピクセル単位.</param>
        /// <param name="aperture_width">アパーチャ幅．実際の長さ単位．</param>
        /// <param name="aperture_height">アパーチャ高さ．実際の長さ単位．</param>
        /// <param name="fovx">x-方向の画角．degree単位.</param>
        /// <param name="fovy">y-方向の画角．degree単位.</param>
        /// <param name="focal_length">焦点距離．実際の長さ単位.</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="camera_matrix">The matrix of intrinsic parameters, e.g. computed by cvCalibrateCamera2</param>
        /// <param name="image_size">Image size in pixels </param>
        /// <param name="aperture_width">Aperture width in realworld units</param>
        /// <param name="aperture_height">Aperture width in realworld units</param>
        /// <param name="fovx">Field of view angle in x direction in degrees</param>
        /// <param name="fovy">Field of view angle in y direction in degrees</param>
        /// <param name="focal_length">Focal length in realworld units</param>
#endif
        public static void CalibrationMatrixValues(
            CvMat camera_matrix, CvSize image_size, double aperture_width, double aperture_height,
            out double fovx, out double fovy, out double focal_length)
        {
            CvPoint2D64f principal_point;
            double pixel_aspect_ratio;
            CalibrationMatrixValues(camera_matrix, image_size, aperture_width, aperture_height,
                out fovx, out fovy, out focal_length, out principal_point, out pixel_aspect_ratio);
        }
#if LANG_JP
        /// <summary>
        /// 様々なカメラ特性を計算する
        /// </summary>
        /// <param name="camera_matrix">内部パラメータ行列（例えば cvCalibrateCamera2 によって求められたもの）． </param>
        /// <param name="image_size">画像のサイズ．ピクセル単位.</param>
        /// <param name="aperture_width">アパーチャ幅．実際の長さ単位．</param>
        /// <param name="aperture_height">アパーチャ高さ．実際の長さ単位．</param>
        /// <param name="fovx">x-方向の画角．degree単位.</param>
        /// <param name="fovy">y-方向の画角．degree単位.</param>
        /// <param name="focal_length">焦点距離．実際の長さ単位.</param>
        /// <param name="principal_point">主点（光学中心）実際の長さ単位.</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="camera_matrix">The matrix of intrinsic parameters, e.g. computed by cvCalibrateCamera2</param>
        /// <param name="image_size">Image size in pixels </param>
        /// <param name="aperture_width">Aperture width in realworld units</param>
        /// <param name="aperture_height">Aperture width in realworld units</param>
        /// <param name="fovx">Field of view angle in x direction in degrees</param>
        /// <param name="fovy">Field of view angle in y direction in degrees</param>
        /// <param name="focal_length">Focal length in realworld units</param>
        /// <param name="principal_point">The principal point in realworld units</param>
#endif
        public static void CalibrationMatrixValues(
            CvMat camera_matrix, CvSize image_size, double aperture_width, double aperture_height,
            out double fovx, out double fovy, out double focal_length, out CvPoint2D64f principal_point)
        {
            double pixel_aspect_ratio;
            CalibrationMatrixValues(camera_matrix, image_size, aperture_width, aperture_height,
                out fovx, out fovy, out focal_length, out principal_point, out pixel_aspect_ratio);
        }
#if LANG_JP
        /// <summary>
        /// 様々なカメラ特性を計算する
        /// </summary>
        /// <param name="camera_matrix">内部パラメータ行列（例えば cvCalibrateCamera2 によって求められたもの）． </param>
        /// <param name="image_size">画像のサイズ．ピクセル単位.</param>
        /// <param name="aperture_width">アパーチャ幅．実際の長さ単位．</param>
        /// <param name="aperture_height">アパーチャ高さ．実際の長さ単位．</param>
        /// <param name="fovx">x-方向の画角．degree単位.</param>
        /// <param name="fovy">y-方向の画角．degree単位.</param>
        /// <param name="focal_length">焦点距離．実際の長さ単位.</param>
        /// <param name="principal_point">主点（光学中心）実際の長さ単位.</param>
        /// <param name="pixel_aspect_ratio">ピクセルのアスペクト比 fy/fx</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="camera_matrix">The matrix of intrinsic parameters, e.g. computed by cvCalibrateCamera2</param>
        /// <param name="image_size">Image size in pixels </param>
        /// <param name="aperture_width">Aperture width in realworld units</param>
        /// <param name="aperture_height">Aperture width in realworld units</param>
        /// <param name="fovx">Field of view angle in x direction in degrees</param>
        /// <param name="fovy">Field of view angle in y direction in degrees</param>
        /// <param name="focal_length">Focal length in realworld units</param>
        /// <param name="principal_point">The principal point in realworld units</param>
        /// <param name="pixel_aspect_ratio">The pixel aspect ratio ~ fy/fx</param>
#endif
        public static void CalibrationMatrixValues(
            CvMat camera_matrix, CvSize image_size, double aperture_width, double aperture_height,
            out double fovx, out double fovy, out double focal_length, out CvPoint2D64f principal_point, out double pixel_aspect_ratio)
        {
            if (camera_matrix == null)
            {
                throw new ArgumentNullException("camera_matrix");
            }
            CvInvoke.cvCalibrationMatrixValues(camera_matrix.CvPtr, image_size, aperture_width, aperture_height,
                out fovx, out fovy, out focal_length, out principal_point, out pixel_aspect_ratio);
        }
        #endregion
        #region CamShift
#if LANG_JP
        /// <summary>
        /// オブジェクト中心，サイズおよび姿勢を求める
        /// </summary>
        /// <param name="prob_image">オブジェクトヒストグラムのバックプロジェクション</param>
        /// <param name="window">初期探索ウィンドウ</param>
        /// <param name="criteria">ウィンドウ探索を終了するための条件． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds object center, size, and orientation
        /// </summary>
        /// <param name="prob_image">Back projection of object histogram (see cvCalcBackProject). </param>
        /// <param name="window">Initial search window. </param>
        /// <param name="criteria">Criteria applied to determine when the window search should be finished. </param>
        /// <returns>The function returns number of iterations made within cvMeanShift. </returns>
#endif
        public static int CamShift(CvArr prob_image, CvRect window, CvTermCriteria criteria)
        {
            CvConnectedComp comp = new CvConnectedComp();
            CvBox2D box;
            return CamShift(prob_image, window, criteria, out comp, out box);
        }
#if LANG_JP
        /// <summary>
        /// オブジェクト中心，サイズおよび姿勢を求める
        /// </summary>
        /// <param name="prob_image">オブジェクトヒストグラムのバックプロジェクション</param>
        /// <param name="window">初期探索ウィンドウ</param>
        /// <param name="criteria">ウィンドウ探索を終了するための条件． </param>
        /// <param name="comp">結果として得られる構造体．収束した探索ウィンドウの座標（comp->rect フィールド），およびウィンドウ内の全ピクセルの合計値（comp->area フィールド）が含まれる． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds object center, size, and orientation
        /// </summary>
        /// <param name="prob_image">Back projection of object histogram (see cvCalcBackProject). </param>
        /// <param name="window">Initial search window. </param>
        /// <param name="criteria">Criteria applied to determine when the window search should be finished. </param>
        /// <param name="comp">Resultant structure that contains converged search window coordinates (comp->rect field) and sum of all pixels inside the window (comp->area field). </param>
        /// <returns>The function returns number of iterations made within cvMeanShift. </returns>
#endif
        public static int CamShift(CvArr prob_image, CvRect window, CvTermCriteria criteria, out CvConnectedComp comp)
        {
            CvBox2D box;
            return CamShift(prob_image, window, criteria, out comp, out box);
        }
#if LANG_JP
        /// <summary>
        /// オブジェクト中心，サイズおよび姿勢を求める
        /// </summary>
        /// <param name="prob_image">オブジェクトヒストグラムのバックプロジェクション</param>
        /// <param name="window">初期探索ウィンドウ</param>
        /// <param name="criteria">ウィンドウ探索を終了するための条件． </param>
        /// <param name="comp">結果として得られる構造体．収束した探索ウィンドウの座標（comp->rect フィールド），およびウィンドウ内の全ピクセルの合計値（comp->area フィールド）が含まれる． </param>
        /// <param name="box">オブジェクトの外接矩形．NULLでない場合，オブジェクトのサイズと姿勢が含まれる． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds object center, size, and orientation
        /// </summary>
        /// <param name="prob_image">Back projection of object histogram (see cvCalcBackProject). </param>
        /// <param name="window">Initial search window. </param>
        /// <param name="criteria">Criteria applied to determine when the window search should be finished. </param>
        /// <param name="comp">Resultant structure that contains converged search window coordinates (comp->rect field) and sum of all pixels inside the window (comp->area field). </param>
        /// <param name="box">Circumscribed box for the object. If not NULL, contains object size and orientation. </param>
        /// <returns>The function returns number of iterations made within cvMeanShift. </returns>
#endif
        public static int CamShift(CvArr prob_image, CvRect window, CvTermCriteria criteria, out CvConnectedComp comp, out CvBox2D box)
        {
            if (prob_image == null)
                throw new ArgumentNullException("prob_image");

            comp = new CvConnectedComp();
            box = new CvBox2D();

            return CvInvoke.cvCamShift(prob_image.CvPtr, window, criteria, comp.CvPtr, ref box);
        }
        #endregion
        #region Canny
#if LANG_JP
        /// <summary>
        /// Cannyアルゴリズムを使用して，入力画像 imageに含まれているエッジを検出し，それを出力画像 edges に保存する [aperture_size=3]． 
        /// threshold1 と threshold2 のうち小さいほうがエッジ同士を接続するために用いられ，大きいほうが強いエッジの初期検出に用いられる． 
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="edges">この関数によって得られたエッジ画像</param>
        /// <param name="threshold1">１番目の閾値</param>
        /// <param name="threshold2">２番目の閾値</param>
#else
        /// <summary>
        /// Finds the edges on the input image image and marks them in the output image edges using the Canny algorithm. 
        /// The smallest of threshold1 and threshold2 is used for edge linking, the largest - to find initial segments of strong edges.
        /// </summary>
        /// <param name="image">Input image. </param>
        /// <param name="edges">Image to store the edges found by the function. </param>
        /// <param name="threshold1">The first threshold. </param>
        /// <param name="threshold2">The second threshold. </param>
#endif
        public static void Canny(CvArr image, CvArr edges, double threshold1, double threshold2)
        {
            Canny(image, edges, threshold1, threshold2, ApertureSize.Size3);
        }
#if LANG_JP
        /// <summary>
        /// Cannyアルゴリズムを使用して，入力画像 imageに含まれているエッジを検出し，それを出力画像 edges に保存する． 
        /// threshold1 と threshold2 のうち小さいほうがエッジ同士を接続するために用いられ，大きいほうが強いエッジの初期検出に用いられる． 
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="edges">この関数によって得られたエッジ画像</param>
        /// <param name="threshold1">１番目の閾値</param>
        /// <param name="threshold2">２番目の閾値</param>
        /// <param name="aperture_size">Sobel演算子のアパーチャサイズ</param>
#else
        /// <summary>
        /// Finds the edges on the input image image and marks them in the output image edges using the Canny algorithm. 
        /// The smallest of threshold1 and threshold2 is used for edge linking, the largest - to find initial segments of strong edges.
        /// </summary>
        /// <param name="image">Input image. </param>
        /// <param name="edges">Image to store the edges found by the function. </param>
        /// <param name="threshold1">The first threshold. </param>
        /// <param name="threshold2">The second threshold. </param>
        /// <param name="aperture_size">Aperture parameter for Sobel operator. </param>
#endif
        public static void Canny(CvArr image, CvArr edges, double threshold1, double threshold2, ApertureSize aperture_size)
        {
            if (image == null)
                throw new ArgumentNullException();
            if (edges == null)
                throw new ArgumentNullException();
            CvInvoke.cvCanny(image.CvPtr, edges.CvPtr, threshold1, threshold2, aperture_size);
        }
        #endregion
        #region CartToPolar
#if LANG_JP
        /// <summary>
        /// 2次元ベクトルの角度と大きさを計算する
        /// </summary>
        /// <param name="x">x座標の配列．</param>
        /// <param name="y">y座標の配列．</param>
        /// <param name="magnitude">大きさの出力配列．必要でなければnullがセットされる．</param>
#else
        /// <summary>
        /// Calculates magnitude and/or angle of 2d vectors
        /// </summary>
        /// <param name="x">The array of x-coordinates </param>
        /// <param name="y">The array of y-coordinates </param>
        /// <param name="magnitude">The destination array of magnitudes, may be set to null if it is not needed </param>
#endif
        public static void CartToPolar(CvArr x, CvArr y, CvArr magnitude)
        {
            CartToPolar(x, y, magnitude, null);
        }
#if LANG_JP
        /// <summary>
        /// 2次元ベクトルの角度と大きさを計算する
        /// </summary>
        /// <param name="x">x座標の配列．</param>
        /// <param name="y">y座標の配列．</param>
        /// <param name="magnitude">大きさの出力配列．必要でなければnullがセットされる．</param>
        /// <param name="angle">角度の出力配列．必要でなければnullがセットされる．角度はラジアン（0..2π），または度（0..360°）で測定される．</param>
#else
        /// <summary>
        /// Calculates magnitude and/or angle of 2d vectors
        /// </summary>
        /// <param name="x">The array of x-coordinates </param>
        /// <param name="y">The array of y-coordinates </param>
        /// <param name="magnitude">The destination array of magnitudes, may be set to null if it is not needed </param>
        /// <param name="angle">The destination array of angles, may be set to null if it is not needed. The angles are measured in radians (0..2π) or in degrees (0..360°). </param>
#endif
        public static void CartToPolar(CvArr x, CvArr y, CvArr magnitude, CvArr angle)
        {
            CartToPolar(x, y, magnitude, angle, AngleUnit.Radians);
        }
#if LANG_JP
        /// <summary>
        /// 2次元ベクトルの角度と大きさを計算する
        /// </summary>
        /// <param name="x">x座標の配列．</param>
        /// <param name="y">y座標の配列．</param>
        /// <param name="magnitude">大きさの出力配列．必要でなければnullがセットされる．</param>
        /// <param name="angle">角度の出力配列．必要でなければnullがセットされる．角度はラジアン（0..2π），または度（0..360°）で測定される．</param>
        /// <param name="unit">角度を表すためにラジアン（デフォルト値），または度のどちらを用いるかを示すフラグ．</param>
#else
        /// <summary>
        /// Calculates magnitude and/or angle of 2d vectors
        /// </summary>
        /// <param name="x">The array of x-coordinates </param>
        /// <param name="y">The array of y-coordinates </param>
        /// <param name="magnitude">The destination array of magnitudes, may be set to null if it is not needed </param>
        /// <param name="angle">The destination array of angles, may be set to null if it is not needed. The angles are measured in radians (0..2π) or in degrees (0..360°). </param>
        /// <param name="unit">The flag indicating whether the angles are measured in radians, which is default mode, or in degrees. </param>
#endif
        public static void CartToPolar(CvArr x, CvArr y, CvArr magnitude, CvArr angle, AngleUnit unit)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            IntPtr magnitudePtr = (magnitude == null) ? IntPtr.Zero : magnitude.CvPtr;
            IntPtr anglePtr = (angle == null) ? IntPtr.Zero : angle.CvPtr;
            CvInvoke.cvCartToPolar(x.CvPtr, y.CvPtr, magnitudePtr, anglePtr, unit);
        }
        #endregion
        #region Cbrt
#if LANG_JP
        /// <summary>
        /// 数の立方根を計算する．
        /// これは，通常，pow(value,1./3)を計算するよりも高速である．一方，負の引数も正しく処理される．
        /// また，特別な値（±Inf, NaN）は扱うことができない． 
        /// </summary>
        /// <param name="value">浮動小数点型の入力値</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates cubic root
        /// </summary>
        /// <param name="value">The input floating-point value </param>
        /// <returns></returns>
#endif
        public static float Cbrt(float value)
        {
            return CvInvoke.cvCbrt(value);
        }
        #endregion
        #region Ceil
#if LANG_JP
        /// <summary>
        /// 引数より小さくない最小の整数値を返す.
        /// </summary>
        /// <param name="value">浮動小数点型の入力値</param>
        /// <returns>引数より小さくない最小の整数値</returns>
#else
        /// <summary>
        /// Returns the minimum integer value that is not smaller than the argument.
        /// </summary>
        /// <param name="value">The input floating-point value </param>
        /// <returns></returns>
#endif
        public static int Ceil(double value)
        {
            return (int)Math.Ceiling(value);
        }
        #endregion
        #region CheckArr
#if LANG_JP
        /// <summary>
        /// 入力配列のすべての要素について，無効な値が存在しないかをチェックする 
        /// </summary>
        /// <param name="arr">チェック対象の配列</param>
        /// <returns>チェックが正しく終わればtrue</returns>
#else
        /// <summary>
        /// Checks every element of input array for invalid values
        /// </summary>
        /// <returns>returns nonzero if the check succeeded, i.e. all elements are valid and within the range, and zero otherwise.</returns>
#endif
        public static bool CheckArr(CvArr arr)
        {

            return CheckArr(arr, CheckArrFlag.NanOrInfinity);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列のすべての要素について，無効な値が存在しないかをチェックする 
        /// </summary>
        /// <param name="arr">チェック対象の配列</param>
        /// <param name="flags">処理フラグ</param>
        /// <returns>チェックが正しく終わればtrue</returns>
#else
        /// <summary>
        /// Checks every element of input array for invalid values
        /// </summary>
        /// <param name="arr">The array to check. </param>
        /// <param name="flags">The operation flags</param>
        /// <returns>returns nonzero if the check succeeded, i.e. all elements are valid and within the range, and zero otherwise.</returns>
#endif
        public static bool CheckArr(CvArr arr, CheckArrFlag flags)
        {
            return CheckArr(arr, flags, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列のすべての要素について，無効な値が存在しないかをチェックする
        /// </summary>
        /// <param name="arr">チェック対象の配列</param>
        /// <param name="flags">処理フラグ</param>
        /// <param name="minVal">有効な値域の下限値(この値以上)．CheckArrFlag.Range がセットされているときのみ有効．</param>
        /// <param name="maxVal">有効な値域の上限値(この値未満)．CheckArrFlag.Range がセットされているときのみ有効．</param>
        /// <returns>チェックが正しく終わればtrue</returns>
#else
        /// <summary>
        /// Checks every element of input array for invalid values
        /// </summary>
        /// <param name="arr">The array to check. </param>
        /// <param name="flags">The operation flags</param>
        /// <param name="minVal">The inclusive lower boundary of valid values range. It is used only if CV_CHECK_RANGE is set. </param>
        /// <param name="maxVal">The exclusive upper boundary of valid values range. It is used only if CV_CHECK_RANGE is set. </param>
        /// <returns>returns nonzero if the check succeeded, i.e. all elements are valid and within the range, and zero otherwise.</returns>
#endif
        public static bool CheckArr(CvArr arr, CheckArrFlag flags, double minVal, double maxVal)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            return CvInvoke.cvCheckArr(arr.CvPtr, flags, minVal, maxVal) != 0;
        }
#if LANG_JP
        /// <summary>
        /// 入力配列のすべての要素について，無効な値が存在しないかをチェックする. CheckArrのエイリアス.
        /// </summary>
        /// <param name="arr">チェック対象の配列</param>
        /// <returns>チェックが正しく終わればtrue</returns>
#else
        /// <summary>
        /// Checks every element of input array for invalid values
        /// </summary>
        /// <param name="arr">The array to check. </param>
        /// <returns>returns nonzero if the check succeeded, i.e. all elements are valid and within the range, and zero otherwise.</returns>
#endif
        public static bool CheckArray(CvArr arr)
        {
            return CheckArr(arr);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列のすべての要素について，無効な値が存在しないかをチェックする. CheckArrのエイリアス. 
        /// </summary>
        /// <param name="arr">チェック対象の配列</param>
        /// <param name="flags">処理フラグ</param>
        /// <returns>チェックが正しく終わればtrue</returns>
#else
        /// <summary>
        /// Checks every element of input array for invalid values
        /// </summary>
        /// <param name="arr">The array to check. </param>
        /// <param name="flags">The operation flags</param>
        /// <returns>returns nonzero if the check succeeded, i.e. all elements are valid and within the range, and zero otherwise.</returns>
#endif
        public static bool CheckArray(CvArr arr, CheckArrFlag flags)
        {
            return CheckArr(arr, flags);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列のすべての要素について，無効な値が存在しないかをチェックする. CheckArrのエイリアス. 
        /// </summary>
        /// <param name="arr">チェック対象の配列</param>
        /// <param name="flags">処理フラグ</param>
        /// <param name="minVal">有効な値域の下限値(この値以上)．CheckArrFlag.Range がセットされているときのみ有効．</param>
        /// <param name="maxVal">有効な値域の上限値(この値未満)．CheckArrFlag.Range がセットされているときのみ有効．</param>
        /// <returns>チェックが正しく終わればtrue</returns>
#else
        /// <summary>
        /// Checks every element of input array for invalid values
        /// </summary>
        /// <param name="arr">The array to check. </param>
        /// <param name="flags">The operation flags</param>
        /// <param name="minVal">The inclusive lower boundary of valid values range. It is used only if CV_CHECK_RANGE is set. </param>
        /// <param name="maxVal">The exclusive upper boundary of valid values range. It is used only if CV_CHECK_RANGE is set. </param>
        /// <returns>returns nonzero if the check succeeded, i.e. all elements are valid and within the range, and zero otherwise.</returns>
#endif
        public static bool CheckArray(CvArr arr, CheckArrFlag flags, double minVal, double maxVal)
        {
            return CheckArr(arr, flags, minVal, maxVal);
        }
        #endregion
        #region CheckChessboard
#if LANG_JP
        /// <summary>
        /// チェスボードが画像中にあるかどうかを高速に判定する。
        /// チェスボードが無い画像でcvFindChessboardCornersが遅くなる問題への対処として利用できる。
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="size">チェスボードのサイズ</param>
        /// <returns>1のときは、チェスボードが画像中に存在し、cvFindChessboardCornersを呼び出せる。
        /// 0のときはチェスボードが存在しない。-1はエラーを示す。</returns>
#else
        /// <summary>
        /// Performs a fast check if a chessboard is in the input image. 
        /// This is a workaround to a problem of cvFindChessboardCorners being slow on images with no chessboard
        /// </summary>
        /// <param name="src">input image</param>
        /// <param name="size">chessboard size</param>
        /// <returns>Returns 1 if a chessboard can be in this image and findChessboardCorners should be called, 
        /// 0 if there is no chessboard, -1 in case of error</returns>
#endif
        public static int CheckChessboard(IplImage src, CvSize size)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            return CvInvoke.cvCheckChessboard(src.CvPtr, size);
        }
        #endregion
        #region CheckContourConvexity
#if LANG_JP
        /// <summary>
        /// 輪郭が凸であるかを調べる
        /// </summary>
        /// <param name="contour">テストする輪郭（点列のシーケンスか配列）</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Tests contour convexity.
        /// </summary>
        /// <param name="contour">Tested contour (sequence or array of points)</param>
        /// <returns></returns>
#endif
        public static bool CheckContourConvexity(CvArr contour)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            return CvInvoke.cvCheckContourConvexity(contour.CvPtr);
            //return CvDll.cvCheckContourConvexity(contour.CvPtr) != 0;
        }
        #endregion
        #region CheckTermCriteria
#if LANG_JP
        /// <summary>
        /// 終了条件をチェックし，type= Iteration|Epsilon に設定し，反復数の max_iterとeprilon の両方が有効になるように変換する
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="defaultEps"></param>
        /// <param name="defaultMaxIters"></param>
        /// <returns>変換結果</returns>
#else
        /// <summary>
        /// Check termination criteria and transform it so that type=CriteriaType.Iteration | CriteriaType.Epsilon,
        /// and both max_iter and epsilon are valid
        /// </summary>
        /// <param name="criteria">Termination criteria</param>
        /// <param name="defaultEps">Default epsilon</param>
        /// <param name="defaultMaxIters">Default maximum number of iteration</param>
        /// <returns></returns>
#endif
        public static CvTermCriteria CheckTermCriteria(CvTermCriteria criteria, double defaultEps, int defaultMaxIters)
        {
            return CvInvoke.cvCheckTermCriteria(criteria, defaultEps, defaultMaxIters);
        }
        #endregion
        #region Circle
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center_x">円の中心のx座標</param>
        /// <param name="center_y">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center_x">X-coordinate of the center of the circle. </param>
        /// <param name="center_y">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
#endif
        public static void Circle(CvArr img, int center_x, int center_y, int radius, CvScalar color)
        {
            Circle(img, new CvPoint(center_x, center_y), radius, color);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center_x">円の中心のx座標</param>
        /// <param name="center_y">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center_x">X-coordinate of the center of the circle. </param>
        /// <param name="center_y">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
#endif
        public static void Circle(CvArr img, int center_x, int center_y, int radius, CvScalar color, int thickness)
        {
            Circle(img, new CvPoint(center_x, center_y), radius, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center_x">円の中心のx座標</param>
        /// <param name="center_y">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="line_type">線の種類</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center_x">X-coordinate of the center of the circle. </param>
        /// <param name="center_y">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="line_type">Type of the circle boundary.</param>
#endif
        public static void Circle(CvArr img, int center_x, int center_y, int radius, CvScalar color, int thickness, LineType line_type)
        {
            Circle(img, new CvPoint(center_x, center_y), radius, color, thickness, line_type);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center_x">円の中心のx座標</param>
        /// <param name="center_y">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="line_type">線の種類</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数.</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center_x">X-coordinate of the center of the circle. </param>
        /// <param name="center_y">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="line_type">Type of the circle boundary.</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. </param>
#endif
        public static void Circle(CvArr img, int center_x, int center_y, int radius, CvScalar color, int thickness, LineType line_type, int shift)
        {
            Circle(img, new CvPoint(center_x, center_y), radius, color, thickness, line_type, shift);
        }

#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
#endif
        public static void Circle(CvArr img, CvPoint center, int radius, CvScalar color)
        {
            Circle(img, center, radius, color, 1, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
#endif
        public static void Circle(CvArr img, CvPoint center, int radius, CvScalar color, int thickness)
        {
            Circle(img, center, radius, color, thickness, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="line_type">線の種類</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="line_type">Type of the circle boundary.</param>
#endif
        public static void Circle(CvArr img, CvPoint center, int radius, CvScalar color, int thickness, LineType line_type)
        {
            Circle(img, center, radius, color, thickness, line_type, 0);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="line_type">線の種類</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数.</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="line_type">Type of the circle boundary.</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. </param>
#endif
        public static void Circle(CvArr img, CvPoint center, int radius, CvScalar color, int thickness, LineType line_type, int shift)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            CvInvoke.cvCircle(img.CvPtr, center, radius, color, thickness, line_type, shift);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center_x">円の中心のx座標</param>
        /// <param name="center_y">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center_x">X-coordinate of the center of the circle. </param>
        /// <param name="center_y">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
#endif
        public static void DrawCircle(CvArr img, int center_x, int center_y, int radius, CvScalar color)
        {
            Circle(img, new CvPoint(center_x, center_y), radius, color);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center_x">円の中心のx座標</param>
        /// <param name="center_y">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center_x">X-coordinate of the center of the circle. </param>
        /// <param name="center_y">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
#endif
        public static void DrawCircle(CvArr img, int center_x, int center_y, int radius, CvScalar color, int thickness)
        {
            Circle(img, new CvPoint(center_x, center_y), radius, color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center_x">円の中心のx座標</param>
        /// <param name="center_y">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="line_type">線の種類</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center_x">X-coordinate of the center of the circle. </param>
        /// <param name="center_y">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="line_type">Type of the circle boundary.</param>
#endif
        public static void DrawCircle(CvArr img, int center_x, int center_y, int radius, CvScalar color, int thickness, LineType line_type)
        {
            Circle(img, new CvPoint(center_x, center_y), radius, color, thickness, line_type);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center_x">円の中心のx座標</param>
        /// <param name="center_y">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="line_type">線の種類</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数.</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center_x">X-coordinate of the center of the circle. </param>
        /// <param name="center_y">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="line_type">Type of the circle boundary.</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. </param>
#endif
        public static void DrawCircle(CvArr img, int center_x, int center_y, int radius, CvScalar color, int thickness, LineType line_type, int shift)
        {
            Circle(img, new CvPoint(center_x, center_y), radius, color, thickness, line_type, shift);
        }

#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
#endif
        public static void DrawCircle(CvArr img, CvPoint center, int radius, CvScalar color)
        {
            Circle(img, center, radius, color, 1, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
#endif
        public static void DrawCircle(CvArr img, CvPoint center, int radius, CvScalar color, int thickness)
        {
            Circle(img, center, radius, color, thickness, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="line_type">線の種類</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="line_type">Type of the circle boundary.</param>
#endif
        public static void DrawCircle(CvArr img, CvPoint center, int radius, CvScalar color, int thickness, LineType line_type)
        {
            Circle(img, center, radius, color, thickness, line_type, 0);
        }
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．</param>
        /// <param name="line_type">線の種類</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数.</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. </param>
        /// <param name="line_type">Type of the circle boundary.</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. </param>
#endif
        public static void DrawCircle(CvArr img, CvPoint center, int radius, CvScalar color, int thickness, LineType line_type, int shift)
        {
            Circle(img, center, radius, color, thickness, line_type, shift);
        }
        #endregion
        #region ClearGraph
#if LANG_JP
        /// <summary>
        /// グラフから全ての頂点と辺を削除する
        /// </summary>
        /// <param name="graph">グラフ</param>
#else
        /// <summary>
        /// Returns index of graph vertex
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <remarks>The function cvClearGraph removes all vertices and edges from the graph. The function has O(1) time complexity.</remarks>
#endif
        public static void ClearGraph(CvGraph graph)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            CvInvoke.cvClearGraph(graph.CvPtr);
        }
        #endregion
        #region ClearHist
#if LANG_JP
        /// <summary>
        /// ヒストグラムをクリアする.
        /// 密なヒストグラムの場合，全てのヒストグラムのビンを0にセットする， また疎なヒストグラムの場合は，すべてのヒストグラムのビンを削除する．
        /// </summary>
        /// <param name="hist">対象のヒストグラムへの参照</param>
#else
        /// <summary>
        /// Sets all histogram bins to 0 in case of dense histogram and removes all histogram bins in case of sparse array.
        /// </summary>
        /// <param name="hist">Histogram.</param>
#endif
        public static void ClearHist(CvHistogram hist)
        {
            if (hist == null)
            {
                throw new ArgumentNullException("hist");
            }
            CvInvoke.cvClearHist(hist.CvPtr);
        }
        #endregion
        #region ClearMemStorage
#if LANG_JP
        /// <summary>
        /// ストレージの先頭（空き領域の境界）を，一番最初に戻す．
        /// この関数はメモリを解放しない．もしストレージが親を持つ場合，この関数は親に全てのブロックを返す．
        /// </summary>
        /// <param name="storage">対象のストレージへの参照</param>
#else
        /// <summary>
        /// Clears memory storage
        /// </summary>
        /// <param name="storage">Memory storage. </param>
#endif
        public static void ClearMemStorage(CvMemStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }
            CvInvoke.cvClearMemStorage(storage.CvPtr);
        }
        #endregion
        #region ClearND
#if LANG_JP
        /// <summary>
        /// 密な配列と疎な配列の指定した要素をクリア（0にセット）する．要素が存在しなければ，この関数は何もしない．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx">要素のインデックスの配列(可変長引数）</param>
#else
        /// <summary>
        /// Clears the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx">Array of the element indices </param>
#endif
        public static void ClearND(CvArr arr, params int[] idx)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            if (idx == null)
                throw new ArgumentNullException("idx");
            CvInvoke.cvClearND(arr.CvPtr, idx);
        }
        #endregion
        #region ClearSeq
#if LANG_JP
        /// <summary>
        /// シーケンスをクリアする
        /// </summary>
        /// <param name="seq">シーケンス</param>
#else
        /// <summary>
        /// Clears sequence
        /// </summary>
        /// <param name="seq">Sequence. </param>
#endif
        public static void ClearSeq(CvSeq seq)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            CvInvoke.cvClearSeq(seq.CvPtr);
        }
        #endregion
        #region ClearSet
#if LANG_JP
        /// <summary>
        /// セットをクリアする
        /// </summary>
        /// <param name="set">クリアされるセット</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Clears set
        /// </summary>
        /// <param name="set">Cleared set. </param>
        /// <returns>The function cvClearSet removes all elements from set. It has O(1) time complexity.</returns>
#endif
        public static void ClearSet(CvSet set)
        {
            if (set == null)
            {
                throw new ArgumentNullException("set");
            }
            CvInvoke.cvClearSet(set.CvPtr);
        }
        #endregion
        #region ClearSubdivVoronoi2D
#if LANG_JP
        /// <summary>
        /// 全ての仮想点を削除する． 
        /// この関数の前回の呼出し後に細分割が変更された場合，この関数は cvCalcSubdivVoronoi2D の内部で呼ばれる． 
        /// </summary>
        /// <param name="subdiv">ドロネー細分割</param>
#else
        /// <summary>
        /// Removes all virtual points
        /// </summary>
        /// <param name="subdiv">Delaunay subdivision. </param>
#endif
        public static void ClearSubdivVoronoi2D(CvSubdiv2D subdiv)
        {
            if (subdiv == null)
            {
                throw new ArgumentNullException("subdiv");
            }
            CvInvoke.cvClearSubdivVoronoi2D(subdiv.CvPtr);
        }
        #endregion
        #region ClipLine
#if LANG_JP
        /// <summary>
        /// 線分を画像領域で切り取る
        /// </summary>
        /// <param name="imgSize">画像の大きさ</param>
        /// <param name="pt1">線分の1番目の端点．この値はこの関数によって変更される．</param>
        /// <param name="pt2">線分の2番目の端点．この値はこの関数によって変更される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Clips the line against the image rectangle
        /// </summary>
        /// <param name="imgSize">Size of the image. </param>
        /// <param name="pt1">First ending point of the line segment. It is modified by the function. </param>
        /// <param name="pt2">Second ending point of the line segment. It is modified by the function. </param>
        /// <returns>The function cvClipLine calculates a part of the line segment which is entirely in the image. It returns 0 if the line segment is completely outside the image and 1 otherwise. </returns>
#endif
        public static int ClipLine(CvSize imgSize, ref CvPoint pt1, ref CvPoint pt2)
        {
            return CvInvoke.cvClipLine(imgSize, ref pt1, ref pt2);
        }
        #endregion
        #region Clone
#if LANG_JP
        /// <summary>
        /// オブジェクトのコピーを作成する
        /// </summary>
        /// <param name="structPtr">コピーするオブジェクト</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Makes a clone of the object
        /// </summary>
        /// <param name="structPtr">The object to clone. </param>
        /// <returns></returns>
#endif
        public static IntPtr Clone(IntPtr structPtr)
        {
            return CvInvoke.cvClone(structPtr);
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトのコピーを作成する
        /// </summary>
        /// <param name="structPtr">コピーするオブジェクト</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Makes a clone of the object
        /// </summary>
        /// <param name="structPtr">The object to clone. </param>
        /// <returns></returns>
#endif
        public static T Clone<T>(T structPtr)
            where T : ICvPtrHolder
        {
            if (structPtr == null)
            {
                throw new ArgumentNullException("structPtr");
            }
            IntPtr result = CvInvoke.cvClone(structPtr.CvPtr);
            try
            {
                return Util.Cast<T>(result);
            }
            catch
            {
                return default(T);
            }
        }
        #endregion
        #region CloneGraph
#if LANG_JP
        /// <summary>
        /// グラフをコピーする
        /// </summary>
        /// <param name="graph">コピーするグラフ</param>
        /// <param name="storage">コピーのためのコンテナ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Clone graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="storage">Container for the copy. </param>
        /// <returns>The function cvCloneGraph creates full copy of the graph. If the graph vertices or edges have pointers to some external data, it still be shared between the copies. The vertex and edge indices in the new graph may be different from the original, because the function defragments the vertex and edge sets.</returns>
#endif
        public static CvGraph CloneGraph(CvGraph graph, CvMemStorage storage)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }
            return new CvGraph(CvInvoke.cvCloneGraph(graph.CvPtr, storage.CvPtr));
        }
        #endregion
        #region CloneImage
#if LANG_JP
        /// <summary>
        /// ヘッダ，ROI，データを含む画像の完全なコピーを作成する． 
        /// </summary>
        /// <param name="image">オリジナル画像</param>
        /// <returns>コピーされた画像</returns>
#else
        /// <summary>
        /// Makes a full copy of image
        /// </summary>
        /// <param name="image">Original image. </param>
        /// <returns></returns>
#endif
        public static IplImage CloneImage(IplImage image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            IntPtr ptr = CvInvoke.cvCloneImage(image.CvPtr);
            if (ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to clone IplImage");
            }
            return new IplImage(ptr);
        }
        #endregion
        #region CloneMat
#if LANG_JP
        /// <summary>
        /// 行列のコピーを作成する
        /// </summary>
        /// <param name="mat">入力行列</param>
        /// <returns>コピーされた行列</returns>
#else
        /// <summary>
        /// Creates matrix copy
        /// </summary>
        /// <param name="mat">Input matrix</param>
        /// <returns>a copy of input array</returns>
#endif
        public static CvMat CloneMat(CvMat mat)
        {
            if (mat == null)
            {
                throw new ArgumentNullException("mat");
            }
            IntPtr ptr = CvInvoke.cvCloneMat(mat.CvPtr);
            return new CvMat(ptr);
        }
        #endregion
        #region CloneMatND
#if LANG_JP
        /// <summary>
        /// 多次元配列の完全なコピーを作成する
        /// </summary>
        /// <param name="mat">入力行列</param>
        /// <returns>コピーされた行列</returns>
#else
        /// <summary>
        /// Creates full copy of multi-dimensional array
        /// </summary>
        /// <param name="mat">Input array</param>
        /// <returns>a copy of input array</returns>
#endif
        public static CvMatND CloneMatND(CvMatND mat)
        {
            if (mat == null)
            {
                throw new ArgumentNullException("mat");
            }
            IntPtr ptr = CvInvoke.cvCloneMatND(mat.CvPtr);
            return new CvMatND(ptr);
        }
        #endregion
        #region CloneSeq
#if LANG_JP
        /// <summary>
        /// 入力行列のコピーを作成し返す
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <returns>コピーされたCvSeq</returns>
#else
        /// <summary>
        /// Creates a copy of sequence
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <returns></returns>
#endif
        public static CvSeq CloneSeq(CvSeq seq)
        {
            return CloneSeq(seq, null);
        }
#if LANG_JP
        /// <summary>
        /// 入力行列のコピーを作成し返す
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="storage">新しいシーケンスヘッダとコピーされたデータ（もしデータがあれば）を保存する出力ストレージ． nullの場合，入力シーケンスに含まれるストレージを使用する．</param>
        /// <returns>コピーされたCvSeq</returns>
#else
        /// <summary>
        /// Creates a copy of sequence
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <param name="storage">The destination storage to keep the new sequence header and the copied data if any. If it is null, the function uses the storage containing the input sequence. </param>
        /// <returns></returns>
#endif
        public static CvSeq CloneSeq(CvSeq seq, CvMemStorage storage)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            return SeqSlice(seq, CvSlice.WholeSeq, storage, true);
        }
#if LANG_JP
        /// <summary>
        /// 入力行列のコピーを作成し返す
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <returns>コピーされたCvSeq</returns>
#else
        /// <summary>
        /// Creates a copy of sequence
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <returns></returns>
#endif
        public static CvSeq<T> CloneSeq<T>(CvSeq<T> seq) where T : struct
        {
            return CloneSeq<T>(seq, null);
        }
#if LANG_JP
        /// <summary>
        /// 入力行列のコピーを作成し返す
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="storage">新しいシーケンスヘッダとコピーされたデータ（もしデータがあれば）を保存する出力ストレージ． nullの場合，入力シーケンスに含まれるストレージを使用する．</param>
        /// <returns>コピーされたCvSeq</returns>
#else
        /// <summary>
        /// Creates a copy of sequence
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="storage">The destination storage to keep the new sequence header and the copied data if any. If it is null, the function uses the storage containing the input sequence. </param>
        /// <returns></returns>
#endif
        public static CvSeq<T> CloneSeq<T>(CvSeq<T> seq, CvMemStorage storage) where T : struct
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            return SeqSlice<T>(seq, CvSlice.WholeSeq, storage, true);
        }
        #endregion
        #region CloneSparseMat
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat">入力行列</param>
        /// <returns>コピーされた行列</returns>
#else
        /// <summary>
        /// Creates full copy of sparse array
        /// </summary>
        /// <param name="mat">Input array</param>
        /// <returns>a copy of input array</returns>
#endif
        public static CvSparseMat CloneSparseMat(CvSparseMat mat)
        {
            if (mat == null)
            {
                throw new ArgumentNullException("mat");
            }
            IntPtr ptr = CvInvoke.cvCloneSparseMat(mat.CvPtr);
            return new CvSparseMat(ptr);
        }
        #endregion
        #region Cmp
#if LANG_JP
        /// <summary>
        /// 二つの配列の各要素ごとの比較を行う. 対応する要素を比較し，出力配列の値にセットする．
        /// dst(I) = src1(I) op src2(I) .
        /// 比較結果が真（true）であれば dst(I) には 0xff（要素すべてのビットが 1 ）をセットし，それ以外の場合（false）であれば 0 をセットする．
        /// </summary>
        /// <param name="src1">入力配列（シングルチャンネル）</param>
        /// <param name="src2">2番目の入力配列．どちらの入力配列もシングルチャンネルでなければならない．</param>
        /// <param name="dst">出力配列（タイプは 8u か 8s でないといけない）</param>
        /// <param name="cmpOp">比較方法を示すフラグ</param>
#else
        /// <summary>
        /// Performs per-element comparison of two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. Both source array must have a single channel. </param>
        /// <param name="dst">The destination array, must have 8u or 8s type. </param>
        /// <param name="cmpOp">The flag specifying the relation between the elements to be checked</param>
#endif
        public static void Cmp(CvArr src1, CvArr src2, CvArr dst, ArrComparison cmpOp)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvCmp(src1.CvPtr, src2.CvPtr, dst.CvPtr, cmpOp);
        }
        #endregion
        #region CmpS
#if LANG_JP
        /// <summary>
        /// 配列要素とスカラーを比較し，出力配列の値をセットする．
        /// dst(I) = src1(I) op scalar .
        /// 比較結果が真（true）であれば dst(I) には 0xff（要素すべてのビットが 1 ）をセットし，それ以外の場合（false）であれば 0 をセットする．
        /// </summary>
        /// <param name="src">入力配列（シングルチャンネル）</param>
        /// <param name="value">それぞれの配列要素と比較されるスカラー</param>
        /// <param name="dst">出力配列（タイプは 8u か 8s でないといけない）</param>
        /// <param name="cmpOp">比較方法を示すフラグ</param>
#else
        /// <summary>
        /// Performs per-element comparison of array and scalar
        /// </summary>
        /// <param name="src">The source array, must have a single channel. </param>
        /// <param name="value">The scalar value to compare each array element with. </param>
        /// <param name="dst">The destination array, must have 8u or 8s type. </param>
        /// <param name="cmpOp">The flag specifying the relation between the elements to be checked</param>
#endif
        public static void CmpS(CvArr src, double value, CvArr dst, ArrComparison cmpOp)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvCmpS(src.CvPtr, value, dst.CvPtr, cmpOp);
        }
        #endregion
        #region ConDensInitSampleSet
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condens"></param>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
#else
        /// <summary>
        /// Initializes sample set for ConDensation algorithm
        /// </summary>
        /// <param name="condens">Structure to be initialized. </param>
        /// <param name="lowerBound">Vector of the lower boundary for each dimension. </param>
        /// <param name="upperBound">Vector of the upper boundary for each dimension. </param>
#endif
        public static void ConDensInitSampleSet(CvConDensation condens, CvMat lowerBound, CvMat upperBound)
        {
            CvInvoke.cvConDensInitSampleSet(condens.CvPtr, lowerBound.CvPtr, upperBound.CvPtr);
        }
        #endregion
        #region ConDensUpdateByTime
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condens"></param>
#else
        /// <summary>
        /// Estimates subsequent model state
        /// </summary>
        /// <param name="condens">Structure to be updated. </param>
#endif
        public static void ConDensUpdateByTime(CvConDensation condens)
        {
            CvInvoke.cvConDensUpdateByTime(condens.CvPtr);
        }
        #endregion
        #region CompleteSymm
#if LANG_JP
        /// <summary>
        /// 指定した行列を、その下三角行列を用いて対称行列として書き換える
        /// </summary>
        /// <param name="matrix"></param>
#else
        /// <summary>
        /// Completes the symmetric matrix from the lower part
        /// </summary>
        /// <param name="matrix"></param>
#endif
        public static void CompleteSymm(CvMat matrix)
        {
            CompleteSymm(matrix, false);
        }
#if LANG_JP
        /// <summary>
        /// 指定した行列を、その下三角行列 (LtoR=false) または上三角行列 (LtoR=true) を用いて対称行列として書き換える
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="LtoR"></param>
#else
        /// <summary>
        /// Completes the symmetric matrix from the lower (LtoR=0) or from the upper (LtoR!=0) part
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="LtoR"></param>
#endif
        public static void CompleteSymm(CvMat matrix, bool LtoR)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix");
            CvInvoke.cvCompleteSymm(matrix.CvPtr, LtoR);
        }
        #endregion
        #region CompareHist
#if LANG_JP
        /// <summary>
        /// 2つの密なヒストグラムを比較する.
        /// 疎なヒストグラム，あるいは重み付けされた点が集まったような，より一般的な構造を比較するためには，関数cvCalcEMD2 を用いる方が良い場合もある.
        /// </summary>
        /// <param name="hist1">1番目の密なヒストグラム</param>
        /// <param name="hist2">2番目の密なヒストグラム</param>
        /// <param name="method">比較手法</param>
#else
        /// <summary>
        /// Compares two dense histograms.
        /// </summary>
        /// <param name="hist1">The first dense histogram. </param>
        /// <param name="hist2">The second dense histogram. </param>
        /// <param name="method">Comparison method.</param>
        /// <returns></returns>
#endif
        public static double CompareHist(CvHistogram hist1, CvHistogram hist2, HistogramComparison method)
        {
            if (hist1 == null)
                throw new ArgumentNullException("hist1");
            if (hist2 == null)
                throw new ArgumentNullException("hist2");
            return CvInvoke.cvCompareHist(hist1.CvPtr, hist2.CvPtr, method);
        }
        #endregion
        #region ComposeRT
#if LANG_JP
        /// <summary>
        /// Computes r3 = rodrigues(rodrigues(r2)*rodrigues(r1)),
        /// t3 = rodrigues(r2)*t1 + t2 and the respective derivatives
        /// </summary>
        /// <param name="rvec1"></param>
        /// <param name="tvec1"></param>
        /// <param name="rvec2"></param>
        /// <param name="tvec2"></param>
        /// <param name="rvec3"></param>
        /// <param name="tvec3"></param>
        /// <param name="dr3dr1"></param>
        /// <param name="dr3dt1"></param>
        /// <param name="dr3dr2"></param>
        /// <param name="dr3dt2"></param>
        /// <param name="dt3dr1"></param>
        /// <param name="dt3dt1"></param>
        /// <param name="dt3dr2"></param>
        /// <param name="dt3dt2"></param>
#else
        /// <summary>
        /// Computes r3 = rodrigues(rodrigues(r2)*rodrigues(r1)),
        /// t3 = rodrigues(r2)*t1 + t2 and the respective derivatives
        /// </summary>
        /// <param name="rvec1"></param>
        /// <param name="tvec1"></param>
        /// <param name="rvec2"></param>
        /// <param name="tvec2"></param>
        /// <param name="rvec3"></param>
        /// <param name="tvec3"></param>
        /// <param name="dr3dr1"></param>
        /// <param name="dr3dt1"></param>
        /// <param name="dr3dr2"></param>
        /// <param name="dr3dt2"></param>
        /// <param name="dt3dr1"></param>
        /// <param name="dt3dt1"></param>
        /// <param name="dt3dr2"></param>
        /// <param name="dt3dt2"></param>
#endif
        public static void ComposeRT(CvMat rvec1, CvMat tvec1, CvMat rvec2, CvMat tvec2, CvMat rvec3, CvMat tvec3,
                 CvMat dr3dr1, CvMat dr3dt1, CvMat dr3dr2, CvMat dr3dt2, CvMat dt3dr1, CvMat dt3dt1, CvMat dt3dr2, CvMat dt3dt2)
        {
            if (rvec1 == null)
                throw new ArgumentNullException("rvec1");
            if (tvec1 == null)
                throw new ArgumentNullException("tvec1");
            if (rvec2 == null)
                throw new ArgumentNullException("rvec2");
            if (tvec2 == null)
                throw new ArgumentNullException("tvec2");

            IntPtr rvec3Ptr = (rvec3 == null) ? IntPtr.Zero : rvec3.CvPtr;
            IntPtr tvec3Ptr = (tvec3 == null) ? IntPtr.Zero : tvec3.CvPtr;
            IntPtr dr3dr1Ptr = (dr3dr1 == null) ? IntPtr.Zero : dr3dr1.CvPtr;
            IntPtr dr3dt1Ptr = (dr3dt1 == null) ? IntPtr.Zero : dr3dt1.CvPtr;
            IntPtr dr3dr2Ptr = (dr3dr2 == null) ? IntPtr.Zero : dr3dr2.CvPtr;
            IntPtr dr3dt2Ptr = (dr3dt2 == null) ? IntPtr.Zero : dr3dt2.CvPtr;
            IntPtr dt3dr1Ptr = (dt3dr1 == null) ? IntPtr.Zero : dt3dr1.CvPtr;
            IntPtr dt3dt1Ptr = (dt3dt1 == null) ? IntPtr.Zero : dt3dt1.CvPtr;
            IntPtr dt3dr2Ptr = (dt3dr2 == null) ? IntPtr.Zero : dt3dr2.CvPtr;
            IntPtr dt3dt2Ptr = (dt3dt2 == null) ? IntPtr.Zero : dt3dt2.CvPtr;

            CvInvoke.cvComposeRT(rvec1.CvPtr, tvec1.CvPtr, rvec2.CvPtr, tvec2.CvPtr, rvec3Ptr, tvec3Ptr, dr3dr1Ptr, dr3dt1Ptr, dr3dr2Ptr, dr3dt2Ptr, dt3dr1Ptr, dt3dt1Ptr, dt3dr2Ptr, dt3dt2Ptr);
        }
        #endregion
        #region ComputeCorrespondEpilines
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の点対応から基礎行列（F行列）を計算する
        /// </summary>
        /// <param name="points">入力点で大きさは2xN, Nx2, 3xN，また はNx3の配列である (ここで N は 点の数)． マルチチャンネルの 1xN，または Nx1 の配列も使用可能．</param>
        /// <param name="which_image">pointsを含む画像のインデックス（1 または 2）．</param>
        /// <param name="fundamental_matrix">基礎行列</param>
        /// <param name="correspondent_lines">計算されたエピポーラ線．大きさは3xN また Nx3 の配列．</param>
#else
        /// <summary>
        /// For points in one image of stereo pair computes the corresponding epilines in the other image
        /// </summary>
        /// <param name="points">The input points. 2xN, Nx2, 3xN or Nx3 array (where N number of points). Multi-channel 1xN or Nx1 array is also acceptable. </param>
        /// <param name="which_image">Index of the image (1 or 2) that contains the points</param>
        /// <param name="fundamental_matrix">Fundamental matrix </param>
        /// <param name="correspondent_lines">Computed epilines, 3xN or Nx3 array </param>
#endif
        public static void ComputeCorrespondEpilines(CvMat points, int which_image, CvMat fundamental_matrix, out CvMat correspondent_lines)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            if (fundamental_matrix == null)
                throw new ArgumentNullException("fundamental_matrix");
            int size = Math.Max(points.Rows, points.Cols);
            correspondent_lines = new CvMat(3, size, MatrixType.F32C1);
            CvInvoke.cvComputeCorrespondEpilines(points.CvPtr, which_image, fundamental_matrix.CvPtr, correspondent_lines.CvPtr);
        }
        #endregion
        #region ContourArea
#if LANG_JP
        /// <summary>
        /// 輪郭全体の領域，または輪郭の一部を計算する． 
        /// 後者の場合，輪郭の弧と選択された2点を繋ぐ弦で区切られたエリア全体が計算される．
        /// </summary>
        /// <param name="contour">輪郭（頂点のシーケンスまたは配列）</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates area of the whole contour or contour section.
        /// </summary>
        /// <param name="contour">Contour (sequence or array of vertices). </param>
        /// <returns></returns>
#endif
        public static double ContourArea(CvArr contour)
        {
            return ContourArea(contour, CvSlice.WholeSeq);
        }
#if LANG_JP
        /// <summary>
        /// 輪郭全体の領域，または輪郭の一部を計算する． 
        /// 後者の場合，輪郭の弧と選択された2点を繋ぐ弦で区切られたエリア全体が計算される．
        /// </summary>
        /// <param name="contour">輪郭（頂点のシーケンスまたは配列）</param>
        /// <param name="slice">注目領域の輪郭の始点と終点．デフォルトでは全領域が計算される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates area of the whole contour or contour section.
        /// </summary>
        /// <param name="contour">Contour (sequence or array of vertices). </param>
        /// <param name="slice">Starting and ending points of the contour section of interest, by default area of the whole contour is calculated. </param>
        /// <returns></returns>
#endif
        public static double ContourArea(CvArr contour, CvSlice slice)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            return CvInvoke.cvContourArea(contour.CvPtr, slice);
        }
        #endregion
        #region ContourFromContourTree
#if LANG_JP
        /// <summary>
        /// ツリーから輪郭を復元する
        /// </summary>
        /// <param name="tree">輪郭の二分木</param>
        /// <param name="storage">復元した輪郭の出力先</param>
        /// <param name="criteria">復元を止める基準</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Restores contour from tree.
        /// </summary>
        /// <param name="tree">Contour tree. </param>
        /// <param name="storage">Container for the reconstructed contour. </param>
        /// <param name="criteria">Criteria, where to stop reconstruction. </param>
        /// <returns></returns>
#endif
        public static CvSeq ContourFromContourTree(CvContourTree tree, CvMemStorage storage, CvTermCriteria criteria)
        {
            if (tree == null)
                throw new ArgumentNullException("tree");
            if (storage == null)
                throw new ArgumentNullException("storage");
            IntPtr result = CvInvoke.cvContourFromContourTree(tree.CvPtr, storage.CvPtr, criteria);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSeq(result);
        }
        #endregion
        #region ContoursMoments
#if LANG_JP
        /// <summary>
        /// Alias for Moments with CvSeq contours
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="moments"></param>
#else
        /// <summary>
        /// Alias for Moments with CvSeq contours
        /// </summary>
        /// <param name="contour">Contours</param>
        /// <param name="moments">Moments</param>
#endif
        public static void ContoursMoments(CvSeq contour, out CvMoments moments)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            moments = new CvMoments();
            CvInvoke.cvMoments(contour.CvPtr, moments, false);
        }
        #endregion
        #region ContourPerimeter
#if LANG_JP
        /// <summary>
        /// cvArcLength(curve,Whole_Seq,1) のエイリアス
        /// </summary>
        /// <param name="contour"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Alias for cvArcLength(curve,Whole_Seq,1)
        /// </summary>
        /// <param name="contour">Contours</param>
        /// <returns></returns>
#endif
        public static double ContourPerimeter(CvArr contour)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            return ArcLength(contour, CvSlice.WholeSeq, 1);
        }
        #endregion
        #region ConvertImage
#if LANG_JP
        /// <summary>
        /// 画像を必要に応じて変換する
        /// </summary>
        /// <param name="src">入力画像.</param>
        /// <param name="dst">出力画像．1 チャンネル 8 ビット画像，あるいは，3 チャンネル 8 ビット画像である．</param>
        /// <param name="flags">操作フラグ．</param>
#else
        /// <summary>
        /// Converts one image to another and flips the result vertically if required. 
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image. Must be single-channel or 3-channel 8-bit image. </param>
        /// <param name="flags">The operation flags</param>
#endif
        public static void ConvertImage(CvArr src, CvArr dst, ConvertImageFlag flags)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            CvInvoke.cvConvertImage(src.CvPtr, dst.CvPtr, flags);
        }
        #endregion
        #region ConvertMaps
#if LANG_JP
        /// <summary>
        /// Converts mapx &amp; mapy from floating-point to integer formats for cvRemap
        /// </summary>
        /// <param name="mapx"></param>
        /// <param name="mapy"></param>
        /// <param name="mapxy"></param>
        /// <param name="mapalpha"></param>
#else
        /// <summary>
        /// Converts mapx &amp; mapy from floating-point to integer formats for cvRemap
        /// </summary>
        /// <param name="mapx"></param>
        /// <param name="mapy"></param>
        /// <param name="mapxy"></param>
        /// <param name="mapalpha"></param>
#endif
        public static void ConvertMaps(CvArr mapx, CvArr mapy, CvArr mapxy, CvArr mapalpha)
        {
            if (mapx == null)
                throw new ArgumentNullException("mapx");
            if (mapxy == null)
                throw new ArgumentNullException("mapxy");

            IntPtr mapyPtr = (mapy == null) ? IntPtr.Zero : mapy.CvPtr;
            IntPtr mapalphaPtr = (mapalpha == null) ? IntPtr.Zero : mapalpha.CvPtr;

            CvInvoke.cvConvertMaps(mapx.CvPtr, mapyPtr, mapxy.CvPtr, mapalphaPtr);
        }
        #endregion
        #region ConvertPointsHomogeneous
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の点対応から基礎行列（F行列）を計算する
        /// </summary>
        /// <param name="src">入力点の配列．大きさは2xN, Nx2, 3xN, Nx3, 4xN，またはNx4（ここでNは点の数）．マルチチャンネルの1xNまたはNx1の配列も使用可能．</param>
        /// <param name="dst">出力点の配列．入力配列と同じ数の点が含まれる次元数は，同じ， あるいは入力より1少ないか1大きい．そして2..4の範囲内でなければならない． </param>
#else
        /// <summary>
        /// Convert points to/from homogeneous coordinates
        /// </summary>
        /// <param name="src">The input point array, 2xN, Nx2, 3xN, Nx3, 4xN or Nx4  (where N is the number of points). Multi-channel 1xN or Nx1 array is also acceptable. </param>
        /// <param name="dst">The output point array, must contain the same number of points as the input; The dimensionality must be the same, 1 less or 1 more than the input, and also within 2..4. </param>
#endif
        public static void ConvertPointsHomogenious(CvMat src, CvMat dst)
        {
            ConvertPointsHomogenious(src, dst);
        }
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の点対応から基礎行列（F行列）を計算する
        /// </summary>
        /// <param name="src">入力点の配列．大きさは2xN, Nx2, 3xN, Nx3, 4xN，またはNx4（ここでNは点の数）．マルチチャンネルの1xNまたはNx1の配列も使用可能．</param>
        /// <param name="dst">出力点の配列．入力配列と同じ数の点が含まれる次元数は，同じ， あるいは入力より1少ないか1大きい．そして2..4の範囲内でなければならない． </param>
#else
        /// <summary>
        /// Convert points to/from homogeneous coordinates
        /// </summary>
        /// <param name="src">The input point array, 2xN, Nx2, 3xN, Nx3, 4xN or Nx4  (where N is the number of points). Multi-channel 1xN or Nx1 array is also acceptable. </param>
        /// <param name="dst">The output point array, must contain the same number of points as the input; The dimensionality must be the same, 1 less or 1 more than the input, and also within 2..4. </param>
#endif
        public static void ConvertPointsHomogeneous(CvMat src, CvMat dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvConvertPointsHomogeneous(src.CvPtr, dst.CvPtr);
        }
        #endregion
        #region ConvertScale
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．[scale=1, shift=0]
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. </param>
#endif
        public static void ConvertScale(CvArr src, CvArr dst)
        {
            ConvertScale(src, dst, 1, 0);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．[shift=0]
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="scale">スケーリング係数</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. </param>
        /// <param name="scale">Scale factor. </param>
#endif
        public static void ConvertScale(CvArr src, CvArr dst, double scale)
        {
            ConvertScale(src, dst, scale, 0);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="scale">スケーリング係数</param>
        /// <param name="shift">スケーリングした入力配列の要素に加える値</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. </param>
        /// <param name="scale">Scale factor. </param>
        /// <param name="shift">Value added to the scaled source array elements. </param>
#endif
        public static void ConvertScale(CvArr src, CvArr dst, double scale, double shift)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvConvertScale(src.CvPtr, dst.CvPtr, scale, shift);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．[scale=1, shift=0]
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. </param>
#endif
        public static void CvtScale(CvArr src, CvArr dst)
        {
            ConvertScale(src, dst, 1, 0);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．[shift=0]
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="scale">スケーリング係数</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. </param>
        /// <param name="scale">Scale factor. </param>
#endif
        public static void CvtScale(CvArr src, CvArr dst, double scale)
        {
            ConvertScale(src, dst, scale, 0);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="scale">スケーリング係数</param>
        /// <param name="shift">スケーリングした入力配列の要素に加える値</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. </param>
        /// <param name="scale">Scale factor. </param>
        /// <param name="shift">Value added to the scaled source array elements. </param>
#endif
        public static void CvtScale(CvArr src, CvArr dst, double scale, double shift)
        {
            ConvertScale(src, dst, scale, shift);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．[scale=1, shift=0]
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. </param>
#endif
        public static void Scale(CvArr src, CvArr dst)
        {
            ConvertScale(src, dst, 1, 0);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．[shift=0]
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="scale">スケーリング係数</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. </param>
        /// <param name="scale">Scale factor. </param>
#endif
        public static void Scale(CvArr src, CvArr dst, double scale)
        {
            ConvertScale(src, dst, scale, 0);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって配列の値を変換する．
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="scale">スケーリング係数</param>
        /// <param name="shift">スケーリングした入力配列の要素に加える値</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. </param>
        /// <param name="scale">Scale factor. </param>
        /// <param name="shift">Value added to the scaled source array elements. </param>
#endif
        public static void Scale(CvArr src, CvArr dst, double scale, double shift)
        {
            ConvertScale(src, dst, scale, shift);
        }
#if LANG_JP
        /// <summary>
        /// scale=1, shift=0 でのcvConvertScale呼び出し. 任意の線形変換によって配列の値を変換する．
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列（デプスは 8u）</param>
#else
        /// <summary>
        /// Converts one array to another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. </param>
#endif
        public static void Convert(CvArr src, CvArr dst)
        {
            ConvertScale(src, dst);
        }
        #endregion
        #region ConvertScaleAbs
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって，入力配列の要素を8ビット符号無し整数型の配列に変換する．[scale=1, shift=0]
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列（デプスは 8u）</param>
#else
        /// <summary>
        /// Converts input array elements to 8-bit unsigned integer another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array (should have 8u depth). </param>
#endif
        public static void ConvertScaleAbs(CvArr src, CvArr dst)
        {
            ConvertScaleAbs(src, dst, 1, 0);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって，入力配列の要素を8ビット符号無し整数型の配列に変換する．[shift=0]
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">ScaleAbs 係数</param>
#else
        /// <summary>
        /// Converts input array elements to 8-bit unsigned integer another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array (should have 8u depth). </param>
        /// <param name="scale">ScaleAbs factor. </param>
#endif
        public static void ConvertScaleAbs(CvArr src, CvArr dst, double scale)
        {
            ConvertScaleAbs(src, dst, scale, 0);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって，入力配列の要素を8ビット符号無し整数型の配列に変換する．
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">ScaleAbs 係数</param>
        /// <param name="shift">スケーリングした入力配列の要素に加える値</param>
#else
        /// <summary>
        /// Converts input array elements to 8-bit unsigned integer another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array (should have 8u depth). </param>
        /// <param name="scale">ScaleAbs factor. </param>
        /// <param name="shift">Value added to the scaled source array elements. </param>
#endif
        public static void ConvertScaleAbs(CvArr src, CvArr dst, double scale, double shift)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvConvertScaleAbs(src.CvPtr, dst.CvPtr, scale, shift);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって，入力配列の要素を8ビット符号無し整数型の配列に変換する．[scale=1, shift=0]
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列（デプスは 8u）</param>
#else
        /// <summary>
        /// Converts input array elements to 8-bit unsigned integer another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array (should have 8u depth). </param>
#endif
        public static void CvtScaleAbs(CvArr src, CvArr dst)
        {
            ConvertScaleAbs(src, dst, 1, 0);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって，入力配列の要素を8ビット符号無し整数型の配列に変換する．[shift=0]
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">ScaleAbs 係数</param>
#else
        /// <summary>
        /// Converts input array elements to 8-bit unsigned integer another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array (should have 8u depth). </param>
        /// <param name="scale">ScaleAbs factor. </param>
#endif
        public static void CvtScaleAbs(CvArr src, CvArr dst, double scale)
        {
            ConvertScaleAbs(src, dst, scale, 0);
        }
#if LANG_JP
        /// <summary>
        /// 任意の線形変換によって，入力配列の要素を8ビット符号無し整数型の配列に変換する．
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列（デプスは 8u）</param>
        /// <param name="scale">ScaleAbs 係数</param>
        /// <param name="shift">スケーリングした入力配列の要素に加える値</param>
#else
        /// <summary>
        /// Converts input array elements to 8-bit unsigned integer another with optional linear transformation
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array (should have 8u depth). </param>
        /// <param name="scale">ScaleAbs factor. </param>
        /// <param name="shift">Value added to the scaled source array elements. </param>
#endif
        public static void CvtScaleAbs(CvArr src, CvArr dst, double scale, double shift)
        {
            ConvertScaleAbs(src, dst, scale, shift);
        }
        #endregion
        #region ConvexHull2
        #region hull = int[]
#if LANG_JP
        /// <summary>
        /// Sklanskyのアルゴリズムを使って2次元の点列の凸包を見つける
        /// </summary>
        /// <param name="input">32ビット整数型，もしくは浮動小数点型で表された2次元の点のシーケンスまたは配列． </param>
        /// <param name="hull">出力される凸包．凸包を構成する点の元の配列におけるインデックス（0基準）のベクトル</param>
        /// <param name="orientation">凸包を構成するデータの並び．</param>
#else
        /// <summary>
        /// Finds convex hull of point set
        /// </summary>
        /// <param name="input">Array of 2D points with 32-bit integer or floating-point coordinates. </param>
        /// <param name="hull">Vector of 0-based point indices of the hull points in the original array.</param>
        /// <param name="orientation">Desired orientation of convex hull: CV_CLOCKWISE or CV_COUNTER_CLOCKWISE. </param>
#endif
        public static void ConvexHull2(CvArr input, out int[] hull, ConvexHullOrientation orientation)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            int inputLength;
            if (input is CvSeq)
            {
                inputLength = ((CvSeq)input).Total;
            }
            else
            {
                CvSize s = input.GetSize();
                inputLength = s.Height * s.Width * input.ElemChannels / 2;
            }

            int[] hullData = new int[inputLength];
            using (CvMat hullMat = new CvMat(hullData.Length, 1, MatrixType.S32C1, hullData))
            {
                CvInvoke.cvConvexHull2(input.CvPtr, hullMat.CvPtr, orientation, 0);

                hull = new int[hullMat.Rows + hullMat.Cols - 1];
                Array.Copy(hullData, 0, hull, 0, hull.Length);
            }
        }
#if LANG_JP
        /// <summary>
        /// Sklanskyのアルゴリズムを使って2次元の点列の凸包を見つける
        /// </summary>
        /// <param name="input">32ビット整数型，もしくは浮動小数点型で表された2次元の点のシーケンスまたは配列． </param>
        /// <param name="hull">出力される凸包．凸包を構成する点の元の配列におけるインデックス（0基準）のベクトル</param>
        /// <param name="orientation">凸包を構成するデータの並び．</param>
#else
        /// <summary>
        /// Finds convex hull of point set
        /// </summary>
        /// <param name="input">Array of 2D points with 32-bit integer coordinates. </param>
        /// <param name="hull">Vector of 0-based point indices of the hull points in the original array.</param>
        /// <param name="orientation">Desired orientation of convex hull: CV_CLOCKWISE or CV_COUNTER_CLOCKWISE. </param>
#endif
        public static void ConvexHull2(CvPoint[] input, out int[] hull, ConvexHullOrientation orientation)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            using (CvMat inputMat = new CvMat(input.Length, 1, MatrixType.S32C2, input))
            {
                ConvexHull2(inputMat, out hull, orientation);
            }
        }
#if LANG_JP
        /// <summary>
        /// Sklanskyのアルゴリズムを使って2次元の点列の凸包を見つける
        /// </summary>
        /// <param name="input">32ビット整数型，もしくは浮動小数点型で表された2次元の点のシーケンスまたは配列． </param>
        /// <param name="hull">出力される凸包．凸包を構成する点の元の配列におけるインデックス（0基準）のベクトル</param>
        /// <param name="orientation">凸包を構成するデータの並び．</param>
#else
        /// <summary>
        /// Finds convex hull of point set
        /// </summary>
        /// <param name="input">Array of 2D points with 32-bit floating-point coordinates. </param>
        /// <param name="hull">Vector of 0-based point indices of the hull points in the original array.</param>
        /// <param name="orientation">Desired orientation of convex hull: CV_CLOCKWISE or CV_COUNTER_CLOCKWISE. </param>
#endif
        public static void ConvexHull2(CvPoint2D32f[] input, out int[] hull, ConvexHullOrientation orientation)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            using (CvMat inputMat = new CvMat(input.Length, 1, MatrixType.F32C2, input))
            {
                ConvexHull2(inputMat, out hull, orientation);
            }
        }
        #endregion
        #region hull = CvPoint[], CvPoint2D32f[]
#if LANG_JP
        /// <summary>
        /// Sklanskyのアルゴリズムを使って2次元の点列の凸包を見つける
        /// </summary>
        /// <param name="input">32ビット整数型，もしくは浮動小数点型で表された2次元の点のシーケンスまたは配列． </param>
        /// <param name="hull">出力される凸包．凸包を構成する点の元の配列におけるインデックス（0基準）のベクトル</param>
        /// <param name="orientation">凸包を構成するデータの並び．</param>
#else
        /// <summary>
        /// Finds convex hull of point set
        /// </summary>
        /// <param name="input">Array of 2D points with 32-bit integer or floating-point coordinates. </param>
        /// <param name="hull">The output convex hull. It is either a vector of points that form the hull.</param>
        /// <param name="orientation">Desired orientation of convex hull: CV_CLOCKWISE or CV_COUNTER_CLOCKWISE. </param>
#endif
        public static void ConvexHull2(CvArr input, out CvPoint[] hull, ConvexHullOrientation orientation)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            int inputLength;
            if (input is CvSeq)
            {
                inputLength = ((CvSeq)input).Total;
            }
            else
            {
                CvSize s = input.GetSize();
                inputLength = s.Height * s.Width * input.ElemChannels / 2;
            }

            CvPoint[] hullData = new CvPoint[inputLength];
            using (CvMat hullMat = new CvMat(hullData.Length, 1, MatrixType.S32C2, hullData))
            {
                CvInvoke.cvConvexHull2(input.CvPtr, hullMat.CvPtr, orientation, 1);

                hull = new CvPoint[hullMat.Rows + hullMat.Cols - 1];
                Array.Copy(hullData, 0, hull, 0, hull.Length);
            }
        }
#if LANG_JP
        /// <summary>
        /// Sklanskyのアルゴリズムを使って2次元の点列の凸包を見つける
        /// </summary>
        /// <param name="input">32ビット整数型，もしくは浮動小数点型で表された2次元の点のシーケンスまたは配列． </param>
        /// <param name="hull">出力される凸包．凸包を構成する点の元の配列におけるインデックス（0基準）のベクトル</param>
        /// <param name="orientation">凸包を構成するデータの並び．</param>
#else
        /// <summary>
        /// Finds convex hull of point set
        /// </summary>
        /// <param name="input">Array of 2D points with 32-bit integer or floating-point coordinates. </param>
        /// <param name="hull">The output convex hull. It is either a vector of points that form the hull.</param>
        /// <param name="orientation">Desired orientation of convex hull: CV_CLOCKWISE or CV_COUNTER_CLOCKWISE. </param>
#endif
        public static void ConvexHull2(CvArr input, out CvPoint2D32f[] hull, ConvexHullOrientation orientation)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            int inputLength;
            if (input is CvSeq)
            {
                inputLength = ((CvSeq)input).Total;
            }
            else
            {
                CvSize s = input.GetSize();
                inputLength = s.Height * s.Width * input.ElemChannels / 2;
            }

            CvPoint2D32f[] hullData = new CvPoint2D32f[inputLength];
            using (CvMat hullMat = new CvMat(hullData.Length, 1, MatrixType.F32C2, hullData))
            {
                CvInvoke.cvConvexHull2(input.CvPtr, hullMat.CvPtr, orientation, 1);

                hull = new CvPoint2D32f[hullMat.Rows + hullMat.Cols - 1];
                Array.Copy(hullData, 0, hull, 0, hull.Length);
            }
        }
#if LANG_JP
        /// <summary>
        /// Sklanskyのアルゴリズムを使って2次元の点列の凸包を見つける
        /// </summary>
        /// <param name="input">32ビット整数型，もしくは浮動小数点型で表された2次元の点のシーケンスまたは配列． </param>
        /// <param name="hull">出力される凸包．凸包を構成する点の元の配列におけるインデックス（0基準）のベクトル</param>
        /// <param name="orientation">凸包を構成するデータの並び．</param>
#else
        /// <summary>
        /// Finds convex hull of point set
        /// </summary>
        /// <param name="input">Array of 2D points with 32-bit integer coordinates. </param>
        /// <param name="hull">The output convex hull. It is either a vector of points that form the hull.</param>
        /// <param name="orientation">Desired orientation of convex hull: CV_CLOCKWISE or CV_COUNTER_CLOCKWISE. </param>
#endif
        public static void ConvexHull2(CvPoint[] input, out CvPoint[] hull, ConvexHullOrientation orientation)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            using (CvMat inputMat = new CvMat(input.Length, 1, MatrixType.S32C2, input))
            {
                ConvexHull2(inputMat, out hull, orientation);
            }
        }
#if LANG_JP
        /// <summary>
        /// Sklanskyのアルゴリズムを使って2次元の点列の凸包を見つける
        /// </summary>
        /// <param name="input">32ビット整数型，もしくは浮動小数点型で表された2次元の点のシーケンスまたは配列． </param>
        /// <param name="hull">出力される凸包．凸包を構成する点の元の配列におけるインデックス（0基準）のベクトル</param>
        /// <param name="orientation">凸包を構成するデータの並び．</param>
#else
        /// <summary>
        /// Finds convex hull of point set
        /// </summary>
        /// <param name="input">Array of 2D points with 32-bit floating-point coordinates. </param>
        /// <param name="hull">The output convex hull. It is either a vector of points that form the hull.</param>
        /// <param name="orientation">Desired orientation of convex hull: CV_CLOCKWISE or CV_COUNTER_CLOCKWISE. </param>
#endif
        public static void ConvexHull2(CvPoint2D32f[] input, out CvPoint2D32f[] hull, ConvexHullOrientation orientation)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            using (CvMat inputMat = new CvMat(input.Length, 1, MatrixType.F32C2, input))
            {
                ConvexHull2(inputMat, out hull, orientation);
            }
        }
        #endregion
        #endregion
        #region ConvexityDefects
#if LANG_JP
        /// <summary>
        /// 輪郭の凸包から凹状欠損を見つける
        /// </summary>
        /// <param name="contour">入力輪郭</param>
        /// <param name="convexhull">凸包の点そのものではなく，輪郭の点へのポインタまたはインデックスを持つ，つまりcvConvexHull2のreturn_pointsパラメータが0であるような cvConvexHull2 を使って得られた凸包．</param>
#else
        /// <summary>
        /// Finds convexity defects of contour
        /// </summary>
        /// <param name="contour">Input contour. </param>
        /// <param name="convexhull">Convex hull obtained using cvConvexHull2 that should contain pointers or indices to the contour points, not the hull points themselves, i.e. return_points parameter in cvConvexHull2 should be 0. </param>
#endif
        public static CvSeq<CvConvexityDefect> ConvexityDefects(CvArr contour, CvArr convexhull)
        {
            return ConvexityDefects(contour, convexhull, null);
        }
#if LANG_JP
        /// <summary>
        /// 輪郭の凸包から凹状欠損を見つける
        /// </summary>
        /// <param name="contour">入力輪郭</param>
        /// <param name="convexhull">凸包の点そのものではなく，輪郭の点へのポインタまたはインデックスを持つ，つまりcvConvexHull2のreturn_pointsパラメータが0であるような cvConvexHull2 を使って得られた凸包．</param>
        /// <param name="storage">凹状欠損の出力シーケンスを格納する変数．これがnullである場合，代わりに，輪郭あるいは凸包のストレージが（この順番で）利用される．</param>
#else
        /// <summary>
        /// Finds convexity defects of contour
        /// </summary>
        /// <param name="contour">Input contour. </param>
        /// <param name="convexhull">Convex hull obtained using cvConvexHull2 that should contain pointers or indices to the contour points, not the hull points themselves, i.e. return_points parameter in cvConvexHull2 should be 0. </param>
        /// <param name="storage">Container for output sequence of convexity defects. If it is null, contour or hull (in that order) storage is used. </param>
#endif
        public static CvSeq<CvConvexityDefect> ConvexityDefects(CvArr contour, CvArr convexhull, CvMemStorage storage)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            if (convexhull == null)
                throw new ArgumentNullException("convexhull");
            IntPtr storage_ptr = (storage == null) ? IntPtr.Zero : storage.CvPtr;
            return new CvSeq<CvConvexityDefect>(CvInvoke.cvConvexityDefects(contour.CvPtr, convexhull.CvPtr, storage_ptr));
        }

#if LANG_JP
        /// <summary>
        /// 輪郭の凸包から凹状欠損を見つける
        /// </summary>
        /// <param name="contour">入力輪郭</param>
        /// <param name="convexhull">凸包の点そのものではなく，輪郭の点へのインデックスを持つ cvConvexHull2 を使って得られた凸包．</param>
#else
        /// <summary>
        /// Finds convexity defects of contour
        /// </summary>
        /// <param name="contour">Input contour. </param>
        /// <param name="convexhull">Convex hull obtained using cvConvexHull2 that should contain indices to the contour points </param>
#endif
        public static CvSeq<CvConvexityDefect> ConvexityDefects(CvArr contour, int[] convexhull)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            if (convexhull == null)
                throw new ArgumentNullException("convexhull");

            using (CvMemStorage storage = new CvMemStorage())
            {
                CvSeq<int> seq = new CvSeq<int>(SeqType.EltypeS32C1, storage);
                foreach (int item in convexhull)
                {
                    seq.Push(item);
                }
                return ConvexityDefects(contour, seq, storage);
            }
        }
        #endregion
        #region Copy
#if LANG_JP
        /// <summary>
        /// 一つの配列を別の配列にコピーする.
        /// </summary>
        /// <param name="src">コピー元画像</param>
        /// <param name="dst">コピー先の画像</param>
#else
        /// <summary>
        /// Copies one array to another
        /// </summary>
        /// <param name="src">The source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void Copy(CvArr src, CvArr dst)
        {
            Copy(src, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 一つの配列を別の配列にコピーする.
        /// </summary>
        /// <param name="src">コピー元画像</param>
        /// <param name="dst">コピー先の画像</param>
        /// <param name="mask">8 ビットシングルチャンネル配列の処理マスク．コピー先の配列の変更する要素を指定する．</param>
#else
        /// <summary>
        /// Copies one array to another
        /// </summary>
        /// <param name="src">The source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void Copy(CvArr src, CvArr dst, CvArr mask)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvCopy(src.CvPtr, dst.CvPtr, maskPtr);
        }
        #endregion
        #region CopyHist
#if LANG_JP
        /// <summary>
        /// 関数 cvCopyHist は，ヒストグラムのコピーを作成する．
        /// コピー先のヒストグラムへのポインタdstがNULLの場合は，srcと同じサイズの新しいヒストグラムが作成される．
        /// それ以外の場合は，二つのヒストグラムは同一タイプ，サイズでないといけない．
        /// この関数はコピー元のヒストグラムのビンの値を，コピー先にコピーし， src内に定義されているのと同じビンの値域をセットする． 
        /// </summary>
        /// <param name="src">コピー元のヒストグラム．</param>
        /// <param name="dst">コピー先のヒストグラムへのポインタ． </param>        
#else
        /// <summary>
        /// The function cvCopyHist makes a copy of the histogram. 
        /// If the second histogram pointer dst is null, a new histogram of the same size as src is created. 
        /// Otherwise, both histograms must have equal types and sizes. 
        /// Then the function copies the source histogram bins values to destination histogram and sets the same bin values ranges as in src. 
        /// </summary>
        /// <param name="src">Source histogram. </param>
        /// <param name="dst">Reference to destination histogram. </param>
#endif
        public static void CopyHist(CvHistogram src, ref CvHistogram dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
            {
                IntPtr dstPtr = IntPtr.Zero;
                CvInvoke.cvCopyHist(src.CvPtr, ref dstPtr);
                dst = new CvHistogram(dstPtr);
            }
            else
            {
                IntPtr dstPtr = dst.CvPtr;
                CvInvoke.cvCopyHist(src.CvPtr, ref dstPtr);
            }
        }
        #endregion
        #region CopyMakeBorder
#if LANG_JP
        /// <summary>
        /// 画像をコピーし，その周りに境界線をつける
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="offset">入力画像（あるいはROI）がコピーされる出力画像内矩形領域の左上角座標 （左下に原点を持つ画像の場合は，左下角座標）．</param>
        /// <param name="bordertype">コピーされた矩形領域の周りに生成する境界線のタイプ</param>
#else
        /// <summary>
        /// Copies image and makes border around it.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image. </param>
        /// <param name="offset">Coordinates of the top-left corner (or bottom-left in case of images with bottom-left origin) of the destination image rectangle where the source image (or its ROI) is copied. Size of the rectanlge matches the source image size/ROI size. </param>
        /// <param name="bordertype">Type of the border to create around the copied source image rectangle.</param>
#endif
        public static void CopyMakeBorder(CvArr src, CvArr dst, CvPoint offset, BorderType bordertype)
        {
            CopyMakeBorder(src, dst, offset, bordertype, CvScalar.ScalarAll(0));
        }
#if LANG_JP
        /// <summary>
        /// 画像をコピーし，その周りに境界線をつける
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="offset">入力画像（あるいはROI）がコピーされる出力画像内矩形領域の左上角座標 （左下に原点を持つ画像の場合は，左下角座標）．</param>
        /// <param name="bordertype">コピーされた矩形領域の周りに生成する境界線のタイプ</param>
        /// <param name="value">bordertype=Constant の場合は境界を埋める値</param>
#else
        /// <summary>
        /// Copies image and makes border around it.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image. </param>
        /// <param name="offset">Coordinates of the top-left corner (or bottom-left in case of images with bottom-left origin) of the destination image rectangle where the source image (or its ROI) is copied. Size of the rectanlge matches the source image size/ROI size. </param>
        /// <param name="bordertype">Type of the border to create around the copied source image rectangle.</param>
        /// <param name="value">Value of the border pixels if bordertype=IPL_BORDER_CONSTANT. </param>
#endif
        public static void CopyMakeBorder(CvArr src, CvArr dst, CvPoint offset, BorderType bordertype, CvScalar value)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvCopyMakeBorder(src.CvPtr, dst.CvPtr, offset, bordertype, value);
        }
        #endregion
        #region CornerEigenValsAndVecs
#if LANG_JP
        /// <summary>
        /// コーナー検出のために画像ブロックの固有値と固有ベクトルを計算する.
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="eigenvv">結果保存用の画像．入力画像の6倍のサイズが必要．</param>
        /// <param name="block_size">隣接ブロックのサイズ</param>
#else
        /// <summary>
        /// Calculates eigenvalues and eigenvectors of image blocks for corner detection
        /// </summary>
        /// <param name="image">Input image. </param>
        /// <param name="eigenvv">Image to store the results. It must be 6 times wider than the input image. </param>
        /// <param name="block_size">Neighborhood size.</param>
#endif
        public static void CornerEigenValsAndVecs(CvArr image, CvArr eigenvv, int block_size)
        {
            CornerEigenValsAndVecs(image, eigenvv, block_size, ApertureSize.Size3);
        }
#if LANG_JP
        /// <summary>
        /// コーナー検出のために画像ブロックの固有値と固有ベクトルを計算する.
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="eigenvv">結果保存用の画像．入力画像の6倍のサイズが必要．</param>
        /// <param name="block_size">隣接ブロックのサイズ</param>
        /// <param name="aperture_size">Sobel演算子のアパーチャサイズ(cvSobel参照)．</param>
#else
        /// <summary>
        /// Calculates eigenvalues and eigenvectors of image blocks for corner detection
        /// </summary>
        /// <param name="image">Input image. </param>
        /// <param name="eigenvv">Image to store the results. It must be 6 times wider than the input image. </param>
        /// <param name="block_size">Neighborhood size.</param>
        /// <param name="aperture_size">Aperture parameter for Sobel operator</param>
#endif
        public static void CornerEigenValsAndVecs(CvArr image, CvArr eigenvv, int block_size, ApertureSize aperture_size)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (eigenvv == null)
                throw new ArgumentNullException("eigenvv");
            CvInvoke.cvCornerEigenValsAndVecs(image.CvPtr, eigenvv.CvPtr, block_size, aperture_size);
        }
        #endregion
        #region CornerHarris
#if LANG_JP
        /// <summary>
        /// 入力画像について Harris エッジ検出を行う． 
        /// cvCornerMinEigenVal や cvCornerEigenValsAndVecsと同様の機能を持ち，それぞれのピクセルにおいて，
        /// block_size×block_size 隣接における 2×2 サイズの勾配から共変動行列M を計算する．その後， 
        /// det(M) - k * trace(M)^2
        /// を計算し，検出結果として出力画像に保存する．結果画像の極大値を求めることで，画像のコーナーを検出することができる． 
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="harris_responce">検出結果を保存する画像．入力画像 image と同じサイズでなくてはならない.</param>
        /// <param name="block_size">隣接ブロックのサイズ</param>
#else
        /// <summary>
        /// Runs the Harris edge detector on image. 
        /// Similarly to cvCornerMinEigenVal and cvCornerEigenValsAndVecs, 
        /// for each pixel it calculates 2x2 gradient covariation matrix M over block_size×block_size neighborhood.
        /// </summary>
        /// <param name="image">Input image. </param>
        /// <param name="harris_responce">Image to store the Harris detector responces. Should have the same size as image.</param>
        /// <param name="block_size">Neighborhood size.</param>
#endif
        public static void CornerHarris(CvArr image, CvArr harris_responce, int block_size)
        {
            CornerHarris(image, harris_responce, block_size, ApertureSize.Size3, 0.04);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像について Harris エッジ検出を行う． 
        /// cvCornerMinEigenVal や cvCornerEigenValsAndVecsと同様の機能を持ち，それぞれのピクセルにおいて，
        /// block_size×block_size 隣接における 2×2 サイズの勾配から共変動行列M を計算する．その後， 
        /// det(M) - k * trace(M)^2
        /// を計算し，検出結果として出力画像に保存する．結果画像の極大値を求めることで，画像のコーナーを検出することができる． 
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="harris_responce">検出結果を保存する画像．入力画像 image と同じサイズでなくてはならない.</param>
        /// <param name="block_size">隣接ブロックのサイズ</param>
        /// <param name="aperture_size">Sobel演算子のアパーチャサイズ(cvSobel参照)．入力画像が浮動小数点型である場合，このパラメータは差分を計算するために用いられる固定小数点型フィルタの数を表す</param>
#else
        /// <summary>
        /// Runs the Harris edge detector on image. 
        /// Similarly to cvCornerMinEigenVal and cvCornerEigenValsAndVecs, 
        /// for each pixel it calculates 2x2 gradient covariation matrix M over block_size×block_size neighborhood.
        /// </summary>
        /// <param name="image">Input image. </param>
        /// <param name="harris_responce">Image to store the Harris detector responces. Should have the same size as image.</param>
        /// <param name="block_size">Neighborhood size.</param>
        /// <param name="aperture_size">Aperture parameter for Sobel operator (see cvSobel). format. In the case of floating-point input format this parameter is the number of the fixed float filter used for differencing. </param>
#endif
        public static void CornerHarris(CvArr image, CvArr harris_responce, int block_size, ApertureSize aperture_size)
        {
            CornerHarris(image, harris_responce, block_size, aperture_size, 0.04);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像について Harris エッジ検出を行う． 
        /// cvCornerMinEigenVal や cvCornerEigenValsAndVecsと同様の機能を持ち，それぞれのピクセルにおいて，
        /// block_size×block_size 隣接における 2×2 サイズの勾配から共変動行列M を計算する．その後， 
        /// det(M) - k * trace(M)^2
        /// を計算し，検出結果として出力画像に保存する．結果画像の極大値を求めることで，画像のコーナーを検出することができる． 
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="harris_responce">検出結果を保存する画像．入力画像 image と同じサイズでなくてはならない.</param>
        /// <param name="block_size">隣接ブロックのサイズ</param>
        /// <param name="aperture_size">Sobel演算子のアパーチャサイズ(cvSobel参照)．入力画像が浮動小数点型である場合，このパラメータは差分を計算するために用いられる固定小数点型フィルタの数を表す</param>
        /// <param name="k">Harris検出器のパラメータ</param>
#else
        /// <summary>
        /// Runs the Harris edge detector on image. 
        /// Similarly to cvCornerMinEigenVal and cvCornerEigenValsAndVecs, 
        /// for each pixel it calculates 2x2 gradient covariation matrix M over block_size×block_size neighborhood.
        /// </summary>
        /// <param name="image">Input image. </param>
        /// <param name="harris_responce">Image to store the Harris detector responces. Should have the same size as image.</param>
        /// <param name="block_size">Neighborhood size.</param>
        /// <param name="aperture_size">Aperture parameter for Sobel operator (see cvSobel). format. In the case of floating-point input format this parameter is the number of the fixed float filter used for differencing. </param>
        /// <param name="k">Harris detector free parameter.</param>
#endif
        public static void CornerHarris(CvArr image, CvArr harris_responce, int block_size, ApertureSize aperture_size, double k)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (harris_responce == null)
                throw new ArgumentNullException("harris_responce");
            CvInvoke.cvCornerHarris(image.CvPtr, harris_responce.CvPtr, block_size, aperture_size, k);
        }
        #endregion
        #region CornerMinEigenVal
#if LANG_JP
        /// <summary>
        /// コーナー検出のために，画像ブロックの最小固有値を計算する. 
        /// すべてのピクセルについて，隣接ブロックにおける導関数の共変動行列の最小固有値だけを求める関数である．
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="eigenval">最小固有値を保存する画像．image と同じサイズでなくてはならない．</param>
        /// <param name="block_size">隣接ブロックのサイズ</param>
#else
        /// <summary>
        /// Calculates minimal eigenvalue of gradient matrices for corner detection
        /// </summary>
        /// <param name="image">Input image. </param>
        /// <param name="eigenval">Image to store the minimal eigen values. Should have the same size as image</param>
        /// <param name="block_size">Neighborhood size.</param>
#endif
        public static void CornerMinEigenVal(CvArr image, CvArr eigenval, int block_size)
        {
            CornerMinEigenVal(image, eigenval, block_size, ApertureSize.Size3);
        }
#if LANG_JP
        /// <summary>
        /// コーナー検出のために，画像ブロックの最小固有値を計算する. 
        /// すべてのピクセルについて，隣接ブロックにおける導関数の共変動行列の最小固有値だけを求める関数である．
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="eigenval">最小固有値を保存する画像．image と同じサイズでなくてはならない．</param>
        /// <param name="block_size">隣接ブロックのサイズ</param>
        /// <param name="aperture_size">Sobel演算子のアパーチャサイズ(cvSobel参照)．入力画像が浮動小数点型である場合，このパラメータは差分を計算するために用いられる固定小数点型フィルタの数を表す</param>
#else
        /// <summary>
        /// Calculates minimal eigenvalue of gradient matrices for corner detection
        /// </summary>
        /// <param name="image">Input image. </param>
        /// <param name="eigenval">Image to store the minimal eigen values. Should have the same size as image</param>
        /// <param name="block_size">Neighborhood size.</param>
        /// <param name="aperture_size">Aperture parameter for Sobel operator (see cvSobel). format. In the case of floating-point input format this parameter is the number of the fixed float filter used for differencing. </param>
#endif
        public static void CornerMinEigenVal(CvArr image, CvArr eigenval, int block_size, ApertureSize aperture_size)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (eigenval == null)
                throw new ArgumentNullException("eigenval");
            CvInvoke.cvCornerMinEigenVal(image.CvPtr, eigenval.CvPtr, block_size, aperture_size);
        }
        #endregion
        #region CorrectMatches
#if LANG_JP
        /// <summary>
        /// The Optimal Triangulation Method
        /// </summary>
        /// <param name="F">3x3 fundamental matrix</param>
        /// <param name="points1">2xN matrix containing the first set of points</param>
        /// <param name="points2">2xN matrix containing the second set of points</param>
        /// <param name="new_points1">the optimized points1_. if this is null, the corrected points are placed back in points1_</param>
        /// <param name="new_points2">the optimized points2_. if this is null, the corrected points are placed back in points2_</param>
#else
        /// <summary>
        /// The Optimal Triangulation Method
        /// </summary>
        /// <param name="F">3x3 fundamental matrix</param>
        /// <param name="points1">2xN matrix containing the first set of points</param>
        /// <param name="points2">2xN matrix containing the second set of points</param>
        /// <param name="new_points1">the optimized points1_. if this is null, the corrected points are placed back in points1_</param>
        /// <param name="new_points2">the optimized points2_. if this is null, the corrected points are placed back in points2_</param>
#endif
        public static void CorrectMatches(CvMat F, CvMat points1, CvMat points2, CvMat new_points1, CvMat new_points2)
        {
            if (F == null)
                throw new ArgumentNullException("F");
            if (points1 == null)
                throw new ArgumentNullException("points1");
            if (points2 == null)
                throw new ArgumentNullException("points2");

            IntPtr new_points1_ptr = (new_points1 == null) ? IntPtr.Zero : new_points1.CvPtr;
            IntPtr new_points2_ptr = (new_points2 == null) ? IntPtr.Zero : new_points2.CvPtr;

            CvInvoke.cvCorrectMatches(F.CvPtr, points1.CvPtr, points2.CvPtr, new_points1_ptr, new_points2_ptr);
        }
        #endregion
        #region CountNonZero
#if LANG_JP
        /// <summary>
        /// 配列要素において 0 ではない要素をカウントする.
        /// 配列が IplImage の場合， ROI，COI の両方に対応している．
        /// </summary>
        /// <param name="arr">配列（シングルチャンネルまたはCOIがセットされたマルチチャンネルの画像）．</param>
        /// <returns>0 ではない要素数</returns>
#else
        /// <summary>
        /// Counts non-zero array elements
        /// </summary>
        /// <param name="arr">The array, must be single-channel array or multi-channel image with COI set. </param>
        /// <returns>the number of non-zero elements in arr</returns>
#endif
        public static int CountNonZero(CvArr arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            return CvInvoke.cvCountNonZero(arr.CvPtr);
        }
        #endregion
        #region CreateBGCodeBookModel
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public static CvBGCodeBookModel CreateBGCodeBookModel()
        {
            IntPtr ptr = CvInvoke.cvCreateBGCodeBookModel();
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvBGCodeBookModel(ptr);
        }
        #endregion
        #region CreateButton
#if LANG_JP
        /// <summary>
        /// コントロールパネル上にボタンを作成します．
        /// </summary>
#else
        /// <summary>
        /// Create a button on the control panel
        /// </summary>
#endif
        public static int CreateButton()
        {
            CvButton button = new CvButton();
            return button.Result;
        }
#if LANG_JP
        /// <summary>
        /// コントロールパネル上にボタンを作成します．
        /// </summary>
        /// <param name="name">ボタンの名前． （これが null の場合，”button &lt;number of boutton&gt;” という名前になります）</param>
#else
        /// <summary>
        /// Create a button on the control panel
        /// </summary>
        /// <param name="name">Name of the button ( if null, the name will be “button &lt;number of boutton&gt;”)</param>
#endif
        public static int CreateButton(string name)
        {
            CvButton button = new CvButton(name);
            return button.Result;
        }
#if LANG_JP
        /// <summary>
        /// コントロールパネル上にボタンを作成します．
        /// </summary>
        /// <param name="name">ボタンの名前． （これが null の場合，”button &lt;number of boutton&gt;” という名前になります）</param>
        /// <param name="callback">ボタン状態が変更される度に呼び出されるデりゲート</param>
#else
        /// <summary>
        /// Create a button on the control panel
        /// </summary>
        /// <param name="name">Name of the button ( if null, the name will be “button &lt;number of boutton&gt;”)</param>
        /// <param name="callback">Pointer to the function to be called every time the button changed its state.</param>
#endif
        public static int CreateButton(string name, CvButtonCallback callback)
        {
            CvButton button = new CvButton(name, callback);
            return button.Result;
        }
#if LANG_JP
        /// <summary>
        /// コントロールパネル上にボタンを作成します．
        /// </summary>
        /// <param name="name">ボタンの名前． （これが null の場合，”button &lt;number of boutton&gt;” という名前になります）</param>
        /// <param name="callback">ボタン状態が変更される度に呼び出されるデりゲート</param>
        /// <param name="userdata">コールバック関数に渡されるオブジェクト</param>
#else
        /// <summary>
        /// Create a button on the control panel
        /// </summary>
        /// <param name="name">Name of the button ( if null, the name will be “button &lt;number of boutton&gt;”)</param>
        /// <param name="callback">Pointer to the function to be called every time the button changed its state.</param>
        /// <param name="userdata">object passed to the callback function. </param>
#endif
        public static int CreateButton(string name, CvButtonCallback callback, object userdata)
        {
            CvButton button = new CvButton(name, callback, userdata);
            return button.Result;
        }
#if LANG_JP
        /// <summary>
        /// コントロールパネル上にボタンを作成します．
        /// </summary>
        /// <param name="name">ボタンの名前． （これが null の場合，”button &lt;number of boutton&gt;” という名前になります）</param>
        /// <param name="callback">ボタン状態が変更される度に呼び出されるデりゲート</param>
        /// <param name="userdata">コールバック関数に渡されるオブジェクト</param>
        /// <param name="button_type">ボタンの種類</param>
#else
        /// <summary>
        /// Create a button on the control panel
        /// </summary>
        /// <param name="name">Name of the button ( if null, the name will be “button &lt;number of boutton&gt;”)</param>
        /// <param name="callback">Pointer to the function to be called every time the button changed its state.</param>
        /// <param name="userdata">object passed to the callback function. </param>
        /// <param name="button_type">button type</param>
#endif
        public static int CreateButton(string name, CvButtonCallback callback, object userdata, ButtonType button_type)
        {
            CvButton button = new CvButton(name, callback, userdata, button_type);
            return button.Result;
        }
#if LANG_JP
        /// <summary>
        /// コントロールパネル上にボタンを作成します．
        /// </summary>
        /// <param name="name">ボタンの名前． （これが null の場合，”button &lt;number of boutton&gt;” という名前になります）</param>
        /// <param name="callback">ボタン状態が変更される度に呼び出されるデりゲート</param>
        /// <param name="userdata">コールバック関数に渡されるオブジェクト</param>
        /// <param name="button_type">ボタンの種類</param>
        /// <param name="initial_button_state">ボタンのデフォルトの状態．チェックボックスとラジオボックスの場合，これは 0 または 1 になります．</param>
#else
        /// <summary>
        /// Create a button on the control panel
        /// </summary>
        /// <param name="name">Name of the button ( if null, the name will be “button &lt;number of boutton&gt;”)</param>
        /// <param name="callback">Pointer to the function to be called every time the button changed its state.</param>
        /// <param name="userdata">object passed to the callback function. </param>
        /// <param name="button_type">button type</param>
        /// <param name="initial_button_state">Default state of the button. Use for checkbox and radiobox, its value could be 0 or 1. </param>
#endif
        public static int CreateButton(string name, CvButtonCallback callback, object userdata, ButtonType button_type, int initial_button_state)
        {
            CvButton button = new CvButton(name, callback, userdata, button_type, initial_button_state);
            return button.Result;
        }
        #endregion
        #region CreateCameraCapture
#if LANG_JP
        /// <summary>
        /// カメラからのビデオキャプチャを初期化する.
        /// Windows では，次の二つのカメラインタフェースが利用できる：Video for Windows（VFW），Matrox Imaging Library（MIL）． 
        /// Linux では，次の二つカメラインタフェースが利用できる：Video for Linux（V4L），FireWire（IEEE1394）． 
        /// </summary>
        /// <param name="index">使われるカメラのインデックス．使用するカメラが１台のとき，あるいは，何台のカメラを使うかが重要でないときは，-1 でも問題ない場合もある.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates and initialized the CvCapture structure for reading a video stream from the camera. 
        /// Currently two camera interfaces can be used on Windows: Video for Windows (VFW) and Matrox Imaging Library (MIL); and two on Linux: V4L and FireWire (IEEE1394).
        /// </summary>
        /// <param name="index">Index of the camera to be used. If there is only one camera or it does not matter what camera to use -1 may be passed. </param>
        /// <returns></returns>
#endif
        public static CvCapture CreateCameraCapture(int index)
        {
            return new CvCapture(index);
        }
#if LANG_JP
        /// <summary>
        /// カメラからのビデオキャプチャを初期化する.
        /// Windows では，次の二つのカメラインタフェースが利用できる：Video for Windows（VFW），Matrox Imaging Library（MIL）． 
        /// Linux では，次の二つカメラインタフェースが利用できる：Video for Linux（V4L），FireWire（IEEE1394）． 
        /// </summary>
        /// <param name="device">使われるカメラの種類</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates and initialized the CvCapture structure for reading a video stream from the camera. 
        /// Currently two camera interfaces can be used on Windows: Video for Windows (VFW) and Matrox Imaging Library (MIL); and two on Linux: V4L and FireWire (IEEE1394). 
        /// </summary>
        /// <param name="device">Device type</param>
        /// <returns></returns>
#endif
        public static CvCapture CreateCameraCapture(CaptureDevice device)
        {
            return new CvCapture(device);
        }
        #endregion
        #region CreateChildMemStorage
#if LANG_JP
        /// <summary>
        /// 子メモリストレージを生成する．
        /// </summary>
        /// <param name="parent">親メモリストレージ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates child memory storage
        /// </summary>
        /// <param name="parent">Parent memory storage. </param>
        /// <returns></returns>
#endif
        public static CvMemStorage CreateChildMemStorage(CvMemStorage parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }
            IntPtr ptr = CvInvoke.cvCreateChildMemStorage(parent.CvPtr);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvMemStorage(ptr);
        }
        #endregion
        #region CreateConDensation
#if LANG_JP
        /// <summary>
        /// ConDensation フィルタ構造体の領域確保を行う
        /// </summary>
        /// <param name="dynamParams">状態ベクトルの次元</param>
        /// <param name="measureParams">観測ベクトルの次元</param>
        /// <param name="sampleCount">サンプル数</param>
#else
        /// <summary>
        /// Allocates ConDensation filter structure
        /// </summary>
        /// <param name="dynamParams">Dimension of the state vector. </param>
        /// <param name="measureParams">Dimension of the measurement vector. </param>
        /// <param name="sampleCount">Number of samples. </param>
#endif
        public static CvConDensation CreateConDensation(int dynamParams, int measureParams, int sampleCount)
        {
            return new CvConDensation(dynamParams, measureParams, sampleCount);
        }
        #endregion
        #region CreateContourTree
#if LANG_JP
        /// <summary>
        /// 輪郭の階層的表現を生成する
        /// </summary>
        /// <param name="contour">入力輪郭</param>
        /// <param name="storage">結果のツリーの出力先</param>
        /// <param name="threshold">近似精度</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates hierarchical representation of contour
        /// </summary>
        /// <param name="contour">Input contour. </param>
        /// <param name="storage">Container for output tree. </param>
        /// <param name="threshold">Approximation accuracy. </param>
        /// <returns></returns>
#endif
        public static CvContourTree CreateContourTree(CvSeq contour, CvMemStorage storage, double threshold)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            if (storage == null)
                throw new ArgumentNullException("storage");
            IntPtr result = CvInvoke.cvCreateContourTree(contour.CvPtr, storage.CvPtr, threshold);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvContourTree(result);
        }
        #endregion
        #region CreateData
#if LANG_JP
        /// <summary>
        /// 画像，行列あるいは多次元配列のデータを確保する．
        /// </summary>
        /// <param name="arr">配列ヘッダ</param>
#else
        /// <summary>
        /// Allocates array data.
        /// </summary>
        /// <param name="arr">Array header. </param>
#endif
        public static void CreateData(CvArr arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            CvInvoke.cvCreateData(arr.CvPtr);
        }
        #endregion
        #region CreateFeatureTree
#if LANG_JP
        /// <summary>
        /// 特徴ベクトルのツリーを作成する
        /// </summary>
        /// <param name="desc">d 次元特徴ベクトルの n × d 行列（CV_32FC1 or CV_64FC1）.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs a tree of feature vectors
        /// </summary>
        /// <param name="desc">n x d matrix of n d-dimensional feature vectors (CV_32FC1 or CV_64FC1). </param>
        /// <returns></returns>
#endif
        public static CvFeatureTree CreateFeatureTree(CvMat desc)
        {
            if (desc == null)
            {
                throw new ArgumentNullException("desc");
            }
            IntPtr result = CvInvoke.cvCreateFeatureTree(desc.CvPtr);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvFeatureTree(result);
        }
        #endregion
        #region CreateFileCapture
#if LANG_JP
        /// <summary>
        /// ファイルからのビデオキャプチャを初期化する
        /// </summary>
        /// <param name="filename">ビデオファイル名</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates and initialized the CvCapture structure for reading the video stream from the specified file.
        /// After the allocated structure is not used any more it should be released by cvReleaseCapture function. 
        /// </summary>
        /// <param name="filename">Name of the video file. </param>
        /// <returns></returns>
#endif
        public static CvCapture CreateFileCapture(string filename)
        {
            return new CvCapture(filename);
        }
        #endregion
        #region CreateHist
#if LANG_JP
        /// <summary>
        /// 指定サイズのヒストグラムを生成し，そのヒストグラムの参照を返す． 
        /// </summary>
        /// <param name="sizes">ヒストグラム各次元のサイズを示す配列</param>
        /// <param name="type">ヒストグラム表現フォーマット</param>
#else
        /// <summary>
        /// Creates a histogram of the specified size and returns the pointer to the created histogram.
        /// </summary>
        /// <param name="sizes">Number of histogram dimensions. </param>
        /// <param name="type">Histogram representation format.</param>
        /// <returns></returns>
#endif
        public static CvHistogram CreateHist(int[] sizes, HistogramFormat type)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            
            return new CvHistogram(sizes, type);
        }
#if LANG_JP
        /// <summary>
        /// 指定サイズのヒストグラムを生成し，そのヒストグラムの参照を返す． 
        /// </summary>
        /// <param name="sizes">ヒストグラム各次元のサイズを示す配列</param>
        /// <param name="type">ヒストグラム表現フォーマット</param>
        /// <param name="ranges">ヒストグラムのビン（bin）（値域）を示す配列．このパラメータの意味はパラメータuniformに依存している．
        /// このレンジは，ヒストグラムを計算したり，またどのヒストグラムのビンが入力画像のどの値やどのデータ要素に対応するかを決めるためのバックプロジェクションで用いられる．
        /// null の場合は，後から関数 cvSetHistBinRanges を用いて決定される.</param>
#else
        /// <summary>
        /// Creates a histogram of the specified size and returns the pointer to the created histogram.
        /// </summary>
        /// <param name="sizes">Number of histogram dimensions. </param>
        /// <param name="type">Histogram representation format.</param>
        /// <param name="ranges">Array of ranges for histogram bins. Its meaning depends on the uniform parameter value. The ranges are used for when histogram is calculated or backprojected to determine, which histogram bin corresponds to which value/tuple of values from the input image[s]. </param>
        /// <returns></returns>
#endif
        public static CvHistogram CreateHist(int[] sizes, HistogramFormat type, float[][] ranges)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            
            return new CvHistogram(sizes, type, ranges);
        }
#if LANG_JP
        /// <summary>
        /// 指定サイズのヒストグラムを生成し，そのヒストグラムの参照を返す． 
        /// </summary>
        /// <param name="sizes">ヒストグラム各次元のサイズを示す配列</param>
        /// <param name="type">ヒストグラム表現フォーマット</param>
        /// <param name="ranges">ヒストグラムのビン（bin）（値域）を示す配列．このパラメータの意味はパラメータuniformに依存している．
        /// このレンジは，ヒストグラムを計算したり，またどのヒストグラムのビンが入力画像のどの値やどのデータ要素に対応するかを決めるためのバックプロジェクションで用いられる．
        /// null の場合は，後から関数 cvSetHistBinRanges を用いて決定される.</param>
        /// <param name="uniform">一様性に関するフラグ</param>
        /// <returns>多次元ヒストグラムクラス</returns>
#else
        /// <summary>
        /// Creates a histogram of the specified size and returns the pointer to the created histogram.
        /// </summary>
        /// <param name="sizes">Number of histogram dimensions. </param>
        /// <param name="type">Histogram representation format.</param>
        /// <param name="ranges">Array of ranges for histogram bins. Its meaning depends on the uniform parameter value. The ranges are used for when histogram is calculated or backprojected to determine, which histogram bin corresponds to which value/tuple of values from the input image[s]. </param>
        /// <param name="uniform">Uniformity flag.</param>
        /// <returns></returns>
#endif
        public static CvHistogram CreateHist(int[] sizes, HistogramFormat type, float[][] ranges, bool uniform)
        {
            if (sizes == null)
            {
                throw new ArgumentNullException("dims");
            }
            return new CvHistogram(sizes, type, ranges, uniform);
        }
        #endregion
        #region CreateGraph
#if LANG_JP
        /// <summary>
        /// 空のグラフを生成する
        /// </summary>
        /// <param name="graph_flags">生成したグラフのタイプ．無向グラフの場合，CV_SEQ_KIND_GRAPH，有向グラフの場合，CV_SEQ_KIND_GRAPH | CV_GRAPH_FLAG_ORIENTED． </param>
        /// <param name="vtx_size">グラフのヘッダサイズ （sizeof(CvGraph)以上）</param>
        /// <param name="edge_size">グラフの頂点サイズ</param>
        /// <param name="storage">グラフの辺サイズ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates empty graph
        /// </summary>
        /// <param name="graph_flags">Type of the created graph. Usually, it is either CV_SEQ_KIND_GRAPH for generic unoriented graphs and CV_SEQ_KIND_GRAPH | CV_GRAPH_FLAG_ORIENTED for generic oriented graphs. </param>
        /// <param name="vtx_size">Graph vertex size; the custom vertex structure must start with CvGraphVtx  (use CV_GRAPH_VERTEX_FIELDS()) </param>
        /// <param name="edge_size">Graph edge size; the custom edge structure must start with CvGraphEdge  (use CV_GRAPH_EDGE_FIELDS()) </param>
        /// <param name="storage">The graph container. </param>
        /// <returns>The function cvCreateGraph creates an empty graph and returns it.</returns>
#endif
        public static CvGraph CreateGraph(SeqType graph_flags, int vtx_size, int edge_size, CvMemStorage storage)
        {
            return CreateGraph(graph_flags, vtx_size, edge_size, storage, CvGraph.SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// 空のグラフを生成する
        /// </summary>
        /// <param name="graph_flags">生成したグラフのタイプ．無向グラフの場合，CV_SEQ_KIND_GRAPH，有向グラフの場合，CV_SEQ_KIND_GRAPH | CV_GRAPH_FLAG_ORIENTED． </param>
        /// <param name="header_size">グラフのヘッダサイズ （sizeof(CvGraph)以上）</param>
        /// <param name="vtx_size">グラフの頂点サイズ</param>
        /// <param name="edge_size">グラフの辺サイズ</param>
        /// <param name="storage">グラフコンテナ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates empty graph
        /// </summary>
        /// <param name="graph_flags">Type of the created graph. Usually, it is either CV_SEQ_KIND_GRAPH for generic unoriented graphs and CV_SEQ_KIND_GRAPH | CV_GRAPH_FLAG_ORIENTED for generic oriented graphs. </param>
        /// <param name="header_size">Graph header size; may not be less than sizeof(CvGraph).</param>
        /// <param name="vtx_size">Graph vertex size; the custom vertex structure must start with CvGraphVtx  (use CV_GRAPH_VERTEX_FIELDS()) </param>
        /// <param name="edge_size">Graph edge size; the custom edge structure must start with CvGraphEdge  (use CV_GRAPH_EDGE_FIELDS()) </param>
        /// <param name="storage">The graph container. </param>
        /// <returns>The function cvCreateGraph creates an empty graph and returns it.</returns>
#endif
        public static CvGraph CreateGraph(SeqType graph_flags, int vtx_size, int edge_size, CvMemStorage storage, int header_size)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }
            IntPtr result = CvInvoke.cvCreateGraph(graph_flags, header_size, vtx_size, edge_size, storage.CvPtr);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvGraph(result);
        }
        #endregion
        #region CreateGraphScanner
#if LANG_JP
        /// <summary>
        /// グラフの深さ優先走査のための構造体を生成する
        /// </summary>
        /// <param name="graph">グラフ</param>
#else
        /// <summary>
        /// Creates structure for depth-first graph traversal
        /// </summary>
        /// <param name="graph">Graph. </param>
#endif
        public static CvGraphScanner CreateGraphScanner(CvGraph graph)
        {
            return CreateGraphScanner(graph, null);
        }
#if LANG_JP
        /// <summary>
        /// グラフの深さ優先走査のための構造体を生成する
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="vtx">走査開始頂点．nullの場合，走査は先頭の頂点（頂点シーケンスのうち最小のインデックスを持つ頂点）から始まる．</param>
#else
        /// <summary>
        /// Creates structure for depth-first graph traversal
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="vtx">Initial vertex to start from. If NULL, the traversal starts from the first vertex (a vertex with the minimal index in the sequence of vertices). </param>
#endif
        public static CvGraphScanner CreateGraphScanner(CvGraph graph, CvGraphVtx vtx)
        {
            return CreateGraphScanner(graph, vtx, GraphScannerMask.AllItems);
        }
#if LANG_JP
        /// <summary>
        /// グラフの深さ優先走査のための構造体を生成する
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="vtx">走査開始頂点．nullの場合，走査は先頭の頂点（頂点シーケンスのうち最小のインデックスを持つ頂点）から始まる．</param>
        /// <param name="mask">イベントマスク．どのイベントにユーザが着目したいのかを指定する .</param>

#else
        /// <summary>
        /// Creates structure for depth-first graph traversal
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="vtx">Initial vertex to start from. If NULL, the traversal starts from the first vertex (a vertex with the minimal index in the sequence of vertices). </param>
        /// <param name="mask">Event mask indicating which events are interesting to the user (where cvNextGraphItem  function returns control to the user) It can be CV_GRAPH_ALL_ITEMS (all events are interesting) or combination of the following flags:
        /// <br/> * CV_GRAPH_VERTEX - stop at the graph vertices visited for the first time
        ///   <br/>* CV_GRAPH_TREE_EDGE - stop at tree edges (tree edge is the edge connecting the last visited vertex and the vertex to be visited next)
        /// <br/>* CV_GRAPH_BACK_EDGE - stop at back edges (back edge is an edge connecting the last visited vertex with some of its ancestors in the search tree)
        /// <br/>* CV_GRAPH_FORWARD_EDGE - stop at forward edges (forward edge is an edge conecting the last visited vertex with some of its descendants in the search tree). The forward edges are only possible during oriented graph traversal)
        ///   <br/>* CV_GRAPH_CROSS_EDGE - stop at cross edges (cross edge is an edge connecting different search trees or branches of the same tree. The cross edges are only possible during oriented graphs traversal)
        ///   <br/> * CV_GRAPH_ANY_EDGE - stop and any edge (tree, back, forward and cross edges)
        ///   <br/>* CV_GRAPH_NEW_TREE - stop in the beginning of every new search tree. When the traversal procedure visits all vertices and edges reachible from the initial vertex (the visited vertices together with tree edges make up a tree), it searches for some unvisited vertex in the graph and resumes the traversal process from that vertex. Before starting a new tree (including the very first tree when cvNextGraphItem is called for the first time) it generates CV_GRAPH_NEW_TREE event.
        ///    <br/> For unoriented graphs each search tree corresponds to a connected component of the graph.
        ///  <br/> * CV_GRAPH_BACKTRACKING - stop at every already visited vertex during backtracking - returning to already visited vertexes of the traversal tree.</param>
#endif
        public static CvGraphScanner CreateGraphScanner(CvGraph graph, CvGraphVtx vtx, GraphScannerMask mask)
        {
            IntPtr vtxPtr = (vtx == null) ? IntPtr.Zero : vtx.CvPtr;

            return new CvGraphScanner(CvInvoke.cvCreateGraphScanner(graph.CvPtr, vtxPtr, mask));
        }
        #endregion
        #region CreateImage
#if LANG_JP
        /// <summary>
        /// 画像のヘッダを作成し，データ領域を確保する
        /// </summary>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="depth">画像要素のビットデプス</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．</param>
        /// <returns>画像ポインタ</returns>
#else
        /// <summary>
        /// Creates header and allocates data
        /// </summary>
        /// <param name="size">Image width and height. </param>
        /// <param name="depth">Bit depth of image elements.</param>
        /// <param name="channels">Number of channels per element(pixel).</param>
        /// <returns>Reference to image header</returns>
#endif
        public static IplImage CreateImage(CvSize size, BitDepth depth, int channels)
        {
            IntPtr ptr = CvInvoke.cvCreateImage(size, depth, channels);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new IplImage(ptr);
        }
        #endregion
        #region CreateImageHeader
#if LANG_JP
        /// <summary>
        /// メモリ確保と初期化を行い，IplImage クラスを返す
        /// </summary>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="depth">画像要素のビットデプス</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．このチャンネルはインタリーブされる．例えば，通常のカラー画像のデータレイアウトは，b0 g0 r0 b1 g1 r1 ...となっている．</param>
        /// <returns>画像ポインタ</returns>
#else
        /// <summary>
        /// Allocates, initializes, and returns structure IplImage
        /// </summary>
        /// <param name="size">Image width and height. </param>
        /// <param name="depth">Image depth. </param>
        /// <param name="channels">Number of channels. </param>
        /// <returns>Reference to image header</returns>
#endif
        public static IplImage CreateImageHeader(CvSize size, BitDepth depth, int channels)
        {
            IntPtr ptr = CvInvoke.cvCreateImageHeader(size, depth, channels);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new IplImage(ptr);
        }
        #endregion
        #region CreateKalman
#if LANG_JP
        /// <summary>
        /// カルマンフィルタ構造体の領域確保を行う.
        /// </summary>
        /// <param name="dynam_params">状態ベクトルの次元数</param>
        /// <param name="measure_params">観測ベクトルの次元</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates Kalman filter structure
        /// </summary>
        /// <param name="dynam_params">dimensionality of the state vector </param>
        /// <param name="measure_params">dimensionality of the measurement vector </param>
        /// <returns>Kalman structure</returns>
#endif
        public static CvKalman CreateKalman(int dynam_params, int measure_params)
        {
            return new CvKalman(dynam_params, measure_params);
        }
#if LANG_JP
        /// <summary>
        /// カルマンフィルタ構造体の領域確保を行う.
        /// </summary>
        /// <param name="dynam_params">状態ベクトルの次元数</param>
        /// <param name="measure_params">観測ベクトルの次元</param>
        /// <param name="control_params">コントロールベクトルの次元</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates Kalman filter structure
        /// </summary>
        /// <param name="dynam_params">dimensionality of the state vector </param>
        /// <param name="measure_params">dimensionality of the measurement vector </param>
        /// <param name="control_params">dimensionality of the control vector </param>
        /// <returns></returns>

#endif
        public static CvKalman CreateKalman(int dynam_params, int measure_params, int control_params)
        {
            return new CvKalman(dynam_params, measure_params, control_params);
        }
        #endregion
        #region CreateKDTree
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs kd-tree from set of feature descriptors
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
#endif
        public static CvFeatureTree CreateKDTree(CvMat desc)
        {
            if (desc == null)
            {
                throw new ArgumentNullException("desc");
            }
            IntPtr ptr = CvInvoke.cvCreateKDTree(desc.CvPtr);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvFeatureTree(ptr);
        }
        #endregion
        #region CreateLSH
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateLSH(IntPtr ops, int d)
        {
            return CreateLSH(ops, d, 10, 10, MatrixType.F64C1, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateLSH(IntPtr ops, int d, int l)
        {
            return CreateLSH(ops, d, l, 10, MatrixType.F64C1, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateLSH(IntPtr ops, int d, int l, int k)
        {
            return CreateLSH(ops, d, l, k, MatrixType.F64C1, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateLSH(IntPtr ops, int d, int l, int k, MatrixType type)
        {
            return CreateLSH(ops, d, l, k, type, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateLSH(IntPtr ops, int d, int l, int k, MatrixType type, double r)
        {
            return CreateLSH(ops, d, l, k, type, r, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateLSH(IntPtr ops, int d, int l, int k, MatrixType type, double r, Int64 seed)
        {
            IntPtr ptr = CvInvoke.cvCreateLSH(ops, d, l, k, type, r, seed);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvLSH(ptr);
        }
        #endregion
        #region CreateMat
#if LANG_JP
        /// <summary>
        /// 新たな行列とその内部データのためのヘッダを確保し，作成された行列への参照を返す．
        /// </summary>
        /// <param name="rows">行列の行数</param>
        /// <param name="cols">行列の列数</param>
        /// <param name="type">行列要素の種類</param>
        /// <returns>行列</returns>
#else
        /// <summary>
        /// Allocates header for the new matrix and underlying data, and returns a pointer to the created matrix.
        /// </summary>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements.</param>
        /// <returns></returns>
#endif
        public static CvMat CreateMat(int rows, int cols, MatrixType type)
        {
            IntPtr ptr = CvInvoke.cvCreateMat(rows, cols, type);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvMat(ptr);
        }
        #endregion
        #region CreateMatHeader
#if LANG_JP
        /// <summary>
        /// 新たな行列のヘッダを作成し，その参照を返す．
        /// さらに，cvCreateData を用いるか，cvSetData により，ユーザが確保したデータ領域を明示的にセットすることで，行列データが確保される．
        /// </summary>
        /// <param name="rows">行列の行数</param>
        /// <param name="cols">行列の列数</param>
        /// <param name="type">行列要素の種類</param>
#else
        /// <summary>
        /// allocates new matrix header and returns pointer to it.
        /// The matrix data can further be allocated using cvCreateData or set explicitly to user-allocated data via cvSetData.
        /// </summary>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements.</param>
        /// <returns></returns>
#endif
        public static CvMat CreateMatHeader(int rows, int cols, MatrixType type)
        {
            IntPtr ptr = CvInvoke.cvCreateMatHeader(rows, cols, type);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvMat(ptr);
        }
        #endregion
        #region CreateMatND
#if LANG_JP
        /// <summary>
        /// 多次元の密な配列のヘッダとその内部データを確保し，作成された配列のポインタを返す．
        /// </summary>
        /// <param name="dims">配列の次元数．CV_MAX_DIM（デフォルトでは32．ビルド時に変更される可能性もある）を超えてはいけない．</param>
        /// <param name="sizes">次元サイズの配列．</param>
        /// <param name="type">配列要素の種類．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates header for multi-dimensional dense array and the underlying data, and returns pointer to the created array.
        /// </summary>
        /// <param name="dims">Number of array dimensions. It must not exceed CV_MAX_DIM (=32 by default, though it may be changed at build time) </param>
        /// <param name="sizes">Array of dimension sizes. </param>
        /// <param name="type">Type of array elements.</param>
        /// <returns></returns>
#endif
        public static CvMatND CreateMatND(int dims, int[] sizes, MatrixType type)
        {
            if (sizes == null)
            {
                throw new ArgumentNullException("sizes");
            }
            IntPtr ptr = CvInvoke.cvCreateMatND(dims, sizes, type);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvMatND(ptr);
        }
        #endregion
        #region CreateMatNDHeader
#if LANG_JP
        /// <summary>
        /// 多次元の密な配列のヘッダを確保する．
        /// さらに，cvCreateData を用いるか， cvSetData により，ユーザが確保したデータ領域を明示的にセットすることで，配列データが確保される． 
        /// </summary>
        /// <param name="dims">配列の次元数．</param>
        /// <param name="sizes">次元サイズの配列．</param>
        /// <param name="type">配列要素の種類．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates header for multi-dimensional dense array. 
        /// The array data can further be allocated using cvCreateData or set explicitly to user-allocated data via cvSetData. 
        /// </summary>
        /// <param name="dims">Number of array dimensions. </param>
        /// <param name="sizes">Array of dimension sizes. </param>
        /// <param name="type">Type of array elements.</param>
        /// <returns></returns>
#endif
        public static CvMatND CreateMatNDHeader(int dims, int[] sizes, MatrixType type)
        {
            if (sizes == null)
            {
                throw new ArgumentNullException("sizes");
            }
            IntPtr ptr = CvInvoke.cvCreateMatNDHeader(dims, sizes, type);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvMatND(ptr);
        }
        #endregion
        #region CreateMemoryLSH
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateMemoryLSH(int d, int n)
        {
            return CreateMemoryLSH(d, n, 10, 10, MatrixType.F64C1, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateMemoryLSH(int d, int n, int l)
        {
            return CreateMemoryLSH(d, n, l, 10, MatrixType.F64C1, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateMemoryLSH(int d, int n, int l, int k)
        {
            return CreateMemoryLSH(d, n, l, k, MatrixType.F64C1, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateMemoryLSH(int d, int n, int l, int k, MatrixType type)
        {
            return CreateMemoryLSH(d, n, l, k, type, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateMemoryLSH(int d, int n, int l, int k, MatrixType type, double r)
        {
            return CreateMemoryLSH(d, n, l, k, type, r, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateMemoryLSH(int d, int n, int l, int k, MatrixType type, double r, Int64 seed)
        {
            IntPtr ptr = CvInvoke.cvCreateMemoryLSH(d, n, l, k, type, r, seed);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvLSH(ptr);
        }
        #endregion
        #region CreateMemStorage
#if LANG_JP
        /// <summary>
        /// メモリストレージを生成し，その参照を返す．初期状態ではストレージは空である．
        /// block_sizeを除くヘッダのフィールドは全て0に設定されている.
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates memory storage
        /// </summary>
        /// <returns></returns>
#endif
        public static CvMemStorage CreateMemStorage()
        {
            return CreateMemStorage(0);
        }
#if LANG_JP
        /// <summary>
        /// メモリストレージを生成し，その参照を返す．初期状態ではストレージは空である．
        /// block_sizeを除くヘッダのフィールドは全て0に設定されている.
        /// </summary>
        /// <param name="blockSize">ストレージブロックのバイト単位のサイズ．0の場合，デフォルト値（現在は≈64K）が使われる．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates memory storage
        /// </summary>
        /// <param name="blockSize">Size of the storage blocks in bytes. If it is 0, the block size is set to default value - currently it is ≈64K. </param>
        /// <returns></returns>
#endif
        public static CvMemStorage CreateMemStorage(int blockSize)
        {
            IntPtr ptr = CvInvoke.cvCreateMemStorage(blockSize);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvMemStorage(ptr);
        }
        #endregion
        #region CreatePOSITObject
        // ReSharper disable InconsistentNaming
#if LANG_JP
        /// <summary>
        /// オブジェクトの情報を持つ構造体を初期化する
        /// </summary>
        /// <param name="points">3次元オブジェクトモデル上の点データの配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Initializes structure containing object information
        /// </summary>
        /// <param name="points">Array of points of the 3D object model. </param>
        /// <returns></returns>
#endif
        public static CvPOSITObject CreatePOSITObject(CvPoint3D32f[] points)
        {
            return CreatePOSITObject(points, points.Length);
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトの情報を持つ構造体を初期化する
        /// </summary>
        /// <param name="points">3次元オブジェクトモデル上の点データの配列</param>
        /// <param name="pointCount">オブジェクト上の点データの数</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Initializes structure containing object information
        /// </summary>
        /// <param name="points">Array of points of the 3D object model. </param>
        /// <param name="pointCount">Number of object points. </param>
        /// <returns></returns>
#endif
        public static CvPOSITObject CreatePOSITObject(CvPoint3D32f[] points, int pointCount)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            IntPtr ptr = CvInvoke.cvCreatePOSITObject(points, pointCount);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvPOSITObject(ptr);
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region CreatePyramid
#if LANG_JP
        /// <summary>
        /// Builds pyramid for an image
        /// </summary>
        /// <param name="img"></param>
        /// <param name="extraLayers"></param>
        /// <param name="rate"></param>
        /// <param name="layerSizes"></param>
        /// <param name="bufarr"></param>
        /// <param name="calc"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Builds pyramid for an image
        /// </summary>
        /// <param name="img"></param>
        /// <param name="extraLayers"></param>
        /// <param name="rate"></param>
        /// <param name="layerSizes"></param>
        /// <param name="bufarr"></param>
        /// <param name="calc"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
#endif
        public static CvMat[] CreatePyramid(CvArr img, int extraLayers, double rate, CvSize[] layerSizes, CvArr bufarr, bool calc, CvFilter filter)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (extraLayers < 0)
                throw new ArgumentOutOfRangeException("extraLayers", "The number of extra layers must be non negative");

            IntPtr bufarrPtr = (bufarr == null) ? IntPtr.Zero : bufarr.CvPtr;

            IntPtr result = CvInvoke.cvCreatePyramid(img.CvPtr, extraLayers, rate, layerSizes, bufarrPtr, calc, filter);
            if (result == IntPtr.Zero)
            {
                return null;
            }
            else
            {
                int length = extraLayers + 1;
                CvMat[] pyramid = new CvMat[length];
                for (int i = 0; i < length; i++)
                {
                    IntPtr p = new IntPtr(result.ToInt32() + (CvMat.SizeOf * i));
                    pyramid[i] = new CvMat(p, false);
                }
                return pyramid;
            }
        }
        #endregion
        #region CreateSpillTree
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs spill-tree from set of feature descriptors
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
#endif
        public static CvFeatureTree CreateSpillTree(CvMat rawData)
        {
            return CreateSpillTree(rawData, 50, .7, .1);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawData"></param>
        /// <param name="naive"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs spill-tree from set of feature descriptors
        /// </summary>
        /// <param name="rawData"></param>
        /// <param name="naive"></param>
        /// <returns></returns>
#endif
        public static CvFeatureTree CreateSpillTree(CvMat rawData, int naive)
        {
            return CreateSpillTree(rawData, naive, .7, .1);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawData"></param>
        /// <param name="naive"></param>
        /// <param name="rho"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs spill-tree from set of feature descriptors
        /// </summary>
        /// <param name="rawData"></param>
        /// <param name="naive"></param>
        /// <param name="rho"></param>
        /// <returns></returns>
#endif
        public static CvFeatureTree CreateSpillTree(CvMat rawData, int naive, double rho)
        {
            return CreateSpillTree(rawData, naive, rho, .1);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawData"></param>
        /// <param name="naive"></param>
        /// <param name="rho"></param>
        /// <param name="tau"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs spill-tree from set of feature descriptors
        /// </summary>
        /// <param name="rawData"></param>
        /// <param name="naive"></param>
        /// <param name="rho"></param>
        /// <param name="tau"></param>
        /// <returns></returns>
#endif
        public static CvFeatureTree CreateSpillTree(CvMat rawData, int naive, double rho, double tau)
        {
            if (rawData == null)
            {
                throw new ArgumentNullException("rawData");
            }
            IntPtr ptr = CvInvoke.cvCreateSpillTree(rawData.CvPtr, naive, rho, tau);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvFeatureTree(ptr);
        }
        #endregion
        #region CreateSeq
#if LANG_JP
        /// <summary>
        /// シーケンスを生成する
        /// </summary>
        /// <param name="seqFlags">生成されたシーケンスのフラグ．生成されたシーケンスが，特定のシーケンスタイプを引数にとるような関数に一切渡されない場合は，この値に0を指定してもかまわない．そうでない場合は，定義済みのシーケンスタイプのリストから適切なタイプが選択されなければならない．</param>
        /// <param name="headerSize">シーケンスのヘッダサイズ．sizeof(CvSeq)以上でなければならない． また，特別なタイプかその拡張が指示されている場合，そのタイプは基本タイプのヘッダと合致していなければならない．</param>
        /// <param name="elemSize">シーケンスの要素サイズ（バイト単位）．サイズはシーケンスタイプと合致しなければならない．例えば，点群のシーケンスを作成する場合，要素タイプにCV_SEQ_ELTYPE_POINTを指定し，パラメータ elem_size は sizeof(CvPoint) と等しくなければならない．</param>
        /// <param name="storage">シーケンスが保存される場所</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates sequence
        /// </summary>
        /// <param name="seqFlags">Flags of the created sequence. If the sequence is not passed to any function working with a specific type of sequences, the sequence value may be set to 0, otherwise the appropriate type must be selected from the list of predefined sequence types. </param>
        /// <param name="headerSize">Size of the sequence header; must be greater or equal to sizeof(CvSeq). If a specific type or its extension is indicated, this type must fit the base type header. </param>
        /// <param name="elemSize">Size of the sequence elements in bytes. The size must be consistent with the sequence type. For example, for a sequence of points to be created, the element type CV_SEQ_ELTYPE_POINT should be specified and the parameter elem_size must be equal to sizeof(CvPoint). </param>
        /// <param name="storage">Sequence location. </param>
        /// <returns></returns>
#endif
        public static CvSeq CreateSeq(SeqType seqFlags, int headerSize, int elemSize, CvMemStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }
            IntPtr ptr = CvInvoke.cvCreateSeq(seqFlags, headerSize, elemSize, storage.CvPtr);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvSeq(ptr);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスを生成する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seqFlags">生成されたシーケンスのフラグ．生成されたシーケンスが，特定のシーケンスタイプを引数にとるような関数に一切渡されない場合は，この値に0を指定してもかまわない．そうでない場合は，定義済みのシーケンスタイプのリストから適切なタイプが選択されなければならない．</param>
        /// <param name="headerSize">シーケンスのヘッダサイズ．sizeof(CvSeq)以上でなければならない． また，特別なタイプかその拡張が指示されている場合，そのタイプは基本タイプのヘッダと合致していなければならない．</param>
        /// <param name="storage">シーケンスが保存される場所</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates sequence
        /// </summary>
        /// <typeparam name="T">Element type (ex. int, CvPoint)</typeparam>
        /// <param name="seqFlags">Flags of the created sequence. If the sequence is not passed to any function working with a specific type of sequences, the sequence value may be set to 0, otherwise the appropriate type must be selected from the list of predefined sequence types. </param>
        /// <param name="headerSize">Size of the sequence header; must be greater or equal to sizeof(CvSeq). If a specific type or its extension is indicated, this type must fit the base type header. </param>
        /// <param name="storage">Sequence location. </param>
        /// <returns></returns>
#endif
        public static CvSeq<T> CreateSeq<T>(SeqType seqFlags, int headerSize, CvMemStorage storage) where T : struct
        {
            CvSeq seq = CreateSeq(seqFlags, headerSize, Marshal.SizeOf(typeof(T)), storage);
            if (seq == null)
                return null;
            else
                return new CvSeq<T>(seq);
        }
        #endregion
        #region CreateSeqBlock
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
#endif
        public static void CreateSeqBlock(CvSeqWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            CvInvoke.cvCreateSeqBlock(writer.CvPtr);
        }
        #endregion
        #region CreateSet
#if LANG_JP
        /// <summary>
        /// 空のセットを生成する
        /// </summary>
        /// <param name="setFlags">生成するセットのタイプ． </param>
        /// <param name="headerSize">セットのヘッダのサイズ（sizeof(CvSet)以上）． </param>
        /// <param name="elemSize">セットの要素のサイズ（CvSetElem 以上）． </param>
        /// <param name="storage">セットのためのコンテナ． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates empty set
        /// </summary>
        /// <param name="setFlags">Type of the created set. </param>
        /// <param name="headerSize">Set header size; may not be less than sizeof(CvSet). </param>
        /// <param name="elemSize">Set element size; may not be less than CvSetElem. </param>
        /// <param name="storage">Container for the set. </param>
        /// <returns></returns>
#endif
        public static CvSet CreateSet(SeqType setFlags, int headerSize, int elemSize, CvMemStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }
            IntPtr result = CvInvoke.cvCreateSet(setFlags, headerSize, elemSize, storage.CvPtr);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSet(result);
        }
#if LANG_JP
        /// <summary>
        /// 空のセットを生成する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setFlags">生成するセットのタイプ． </param>
        /// <param name="headerSize">セットのヘッダのサイズ（sizeof(CvSet)以上）． </param>
        /// <param name="elemSize">セットの要素のサイズ（CvSetElem 以上）． </param>
        /// <param name="storage">セットのためのコンテナ． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates empty set
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="setFlags">Type of the created set. </param>
        /// <param name="headerSize">Set header size; may not be less than sizeof(CvSet). </param>
        /// <param name="elemSize">Set element size; may not be less than CvSetElem. </param>
        /// <param name="storage">Container for the set. </param>
        /// <returns></returns>
#endif
        public static CvSet<T> CreateSet<T>(SeqType setFlags, int headerSize, int elemSize, CvMemStorage storage) where T : struct
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }
            IntPtr result = CvInvoke.cvCreateSet(setFlags, headerSize, elemSize, storage.CvPtr);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSet<T>(result);
        }
        #endregion
        #region CreateSparseMat
#if LANG_JP
        /// <summary>
        /// 疎な配列を作成する
        /// </summary>
        /// <param name="dims">配列の次元数．密な行列とは逆に，次元数は実質的には無制限である（2^16 まで）．</param>
        /// <param name="sizes">次元サイズの配列．</param>
        /// <param name="type">配列要素の種類.</param>
        /// <returns>多次元の疎な配列</returns>
#else
        /// <summary>
        /// Creates sparse array
        /// </summary>
        /// <param name="dims">Number of array dimensions. As opposite to the dense matrix, the number of dimensions is practically unlimited (up to 2^16). </param>
        /// <param name="sizes">Array of dimension sizes. </param>
        /// <param name="type">Type of array elements.</param>
        /// <returns></returns>
#endif
        public static CvSparseMat CreateSparseMat(int dims, int[] sizes, MatrixType type)
        {
            if (sizes == null)
            {
                throw new ArgumentNullException("sizes");
            }
            IntPtr result = CvInvoke.cvCreateSparseMat(dims, sizes, type);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSparseMat(result);
        }
        #endregion
        #region CreateStereoBMState
        // ReSharper disable InconsistentNaming
#if LANG_JP
        /// <summary>
        /// ステレオブロックマッチング構造体を作成する
        /// </summary>
        /// <returns>ステレオブロックマッチング構造体</returns>
#else
        /// <summary>
        /// Creates block matching stereo correspondence structure
        /// </summary>
        /// <returns>stereo correspondence structure</returns>
#endif
        public static CvStereoBMState CreateStereoBMState()
        {
            return new CvStereoBMState();
        }
#if LANG_JP
        /// <summary>
        /// ステレオブロックマッチング構造体を作成する
        /// </summary>
        /// <param name="preset">あらかじめ定義されたパラメータのID．構造体を作成した後で，任意のパラメータをオーバーライドできる． </param>
        /// <returns>ステレオブロックマッチング構造体</returns>
#else
        /// <summary>
        /// Creates block matching stereo correspondence structure
        /// </summary>
        /// <param name="preset">ID of one of the pre-defined parameter sets. Any of the parameters can be overridden after creating the structure. </param>
        /// <returns>stereo correspondence structure</returns>
#endif
        public static CvStereoBMState CreateStereoBMState(StereoBMPreset preset)
        {
            return new CvStereoBMState(preset);
        }
#if LANG_JP
        /// <summary>
        /// ステレオブロックマッチング構造体を作成する
        /// </summary>
        /// <param name="preset">あらかじめ定義されたパラメータのID．構造体を作成した後で，任意のパラメータをオーバーライドできる． </param>
        /// <param name="numberOfDisparities">視差数（最大視差-最小視差）． このパラメータが 0 の場合，preset から選択される． そうでない場合は，与えられた値が preset の値をオーバーライドする．</param>
        /// <returns>ステレオブロックマッチング構造体</returns>
#else
        /// <summary>
        /// Creates block matching stereo correspondence structure
        /// </summary>
        /// <param name="preset">ID of one of the pre-defined parameter sets. Any of the parameters can be overridden after creating the structure. </param>
        /// <param name="numberOfDisparities">The number of disparities. If the parameter is 0, it is taken from the preset, otherwise the supplied value overrides the one from preset. </param>
        /// <returns>stereo correspondence structure</returns>
#endif
        public static CvStereoBMState CreateStereoBMState(StereoBMPreset preset, int numberOfDisparities)
        {
            return new CvStereoBMState(preset, numberOfDisparities);
        }
        #endregion
        #region CreateStereoGCState
#if LANG_JP
        /// <summary>
        /// グラフカットステレオマッチングアルゴリズムの構造体を作成する
        /// </summary>
        /// <param name="numberOfDisparities">視差数．視差の探索範囲は， state-&gt;minDisparity &lt;= disparity &lt; state-&gt;minDisparity + state-&gt;numberOfDisparities となる．</param>
        /// <param name="maxIters">繰り返し計算の最大数． 各繰り返しにおいて，すべての（あるいは，適度な数の）α拡張を行う． このアルゴリズムは，コスト関数全体を減少させるα拡張が見つからなかった場合は，そこで終了する．</param>
        /// <returns>グラフカットステレオマッチングアルゴリズムの構造体</returns>
#else
        /// <summary>
        /// Creates the state of graph cut-based stereo correspondence algorithm
        /// </summary>
        /// <param name="numberOfDisparities">The number of disparities. The disparity search range will be state-&gt;minDisparity ≤ disparity &lt; state-&gt;minDisparity + state-&gt;numberOfDisparities</param>
        /// <param name="maxIters">Maximum number of iterations. On each iteration all possible (or reasonable) alpha-expansions are tried. The algorithm may terminate earlier if it could not find an alpha-expansion that decreases the overall cost function value.</param>
        /// <returns>stereo correspondence structure</returns>
#endif
        public static CvStereoGCState CreateStereoGCState(int numberOfDisparities, int maxIters)
        {
            return new CvStereoGCState(numberOfDisparities, maxIters);
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region CreateStructuringElementEx
#if LANG_JP
        /// <summary>
        /// 膨張・収縮処理に用いる構造要素を生成する
        /// </summary>
        /// <param name="cols">構造要素の列数</param>
        /// <param name="rows">構造要素の行数</param>
        /// <param name="anchorX">構造要素の原点のx座標</param>
        /// <param name="anchorY">構造要素の原点のy座標</param>
        /// <param name="shape">構造要素の形状</param>
        /// <returns>構造要素</returns>
#else
        /// <summary>
        /// Allocates and fills the structure IplConvKernel, which can be used as a structuring element in the morphological operations.
        /// </summary>
        /// <param name="cols">Number of columns in the structuring element. </param>
        /// <param name="rows">Number of rows in the structuring element. </param>
        /// <param name="anchorX">Relative horizontal offset of the anchor point. </param>
        /// <param name="anchorY">Relative vertical offset of the anchor point. </param>
        /// <param name="shape">Shape of the structuring element.</param>
        /// <returns></returns>
#endif
        public static IplConvKernel CreateStructuringElementEx(int cols, int rows, int anchorX, int anchorY, ElementShape shape)
        {
            return new IplConvKernel(cols, rows, anchorX, anchorY, shape);
        }
#if LANG_JP
        /// <summary>
        /// 膨張・収縮処理に用いる構造要素を生成する
        /// </summary>
        /// <param name="cols">構造要素の列数</param>
        /// <param name="rows">構造要素の行数</param>
        /// <param name="anchorX">構造要素の原点のx座標</param>
        /// <param name="anchorY">構造要素の原点のy座標</param>
        /// <param name="shape">構造要素の形状</param>
        /// <param name="values">構造要素データへのポインタ。このパラメータは形状がCV_SHAPE_CUSTOMのときのみ有効</param>
        /// <returns>構造要素</returns>
#else
        /// <summary>
        /// Allocates and fills the structure IplConvKernel, which can be used as a structuring element in the morphological operations.
        /// </summary>
        /// <param name="cols">Number of columns in the structuring element. </param>
        /// <param name="rows">Number of rows in the structuring element. </param>
        /// <param name="anchorX">Relative horizontal offset of the anchor point. </param>
        /// <param name="anchorY">Relative vertical offset of the anchor point. </param>
        /// <param name="shape">Shape of the structuring element.</param>
        /// <param name="values">Pointer to the structuring element data, a plane array, representing row-by-row scanning of the element matrix. 
        /// Non-zero values indicate points that belong to the element. If the pointer is null, then all values are considered non-zero, 
        /// that is, the element is of a rectangular shape. This parameter is considered only if the shape is CV_SHAPE_CUSTOM . </param>
        /// <returns></returns>
#endif
        public static IplConvKernel CreateStructuringElementEx(int cols, int rows, int anchorX, int anchorY, ElementShape shape, int[,] values)
        {
            return new IplConvKernel(cols, rows, anchorX, anchorY, shape, values);
        }
        #endregion
        #region CreateSubdiv2D
#if LANG_JP
        /// <summary>
        /// CvSubdiv2Dを生成する。
        /// このあと、cvInitSubdivDelaunay2Dで初期化するべし
        /// </summary>
        /// <param name="subdivType"></param>
        /// <param name="headerSize"></param>
        /// <param name="vtxSize"></param>
        /// <param name="quadedgeSize"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates empty Delaunay triangulation.
        /// The users must initialize the returned value by cvInitSubdivDelaunay2D.
        /// </summary>
        /// <param name="subdivType"></param>
        /// <param name="headerSize"></param>
        /// <param name="vtxSize"></param>
        /// <param name="quadedgeSize"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
#endif
        public static CvSubdiv2D CreateSubdiv2D(SeqType subdivType, int headerSize, int vtxSize, int quadedgeSize, CvMemStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }
            IntPtr result = CvInvoke.cvCreateSubdiv2D(subdivType, headerSize, vtxSize, quadedgeSize, storage.CvPtr);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSubdiv2D(result);
        }
        #endregion
        #region CreateSubdivDelaunay2D
#if LANG_JP
        /// <summary>
        /// 空のドロネー三角形を作成する
        /// </summary>
        /// <param name="rect">細分割のために追加される全ての２次元点を包含する矩形．</param>
        /// <param name="storage">細分割のための領域．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates empty Delaunay triangulation
        /// </summary>
        /// <param name="rect">Rectangle that includes all the 2d points that are to be added to subdivision. </param>
        /// <param name="storage">Container for subdivision. </param>
        /// <returns></returns>
#endif
        public static CvSubdiv2D CreateSubdivDelaunay2D(CvRect rect, CvMemStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }
            return new CvSubdiv2D(rect, storage);
        }
        #endregion
        #region CreateTrackbar
#if LANG_JP
        /// <summary>
        /// 指定された名前と範囲のトラックバー（スライダ，レンジコントロールとも呼ばれる）を作成する．
        /// 作成されたトラックバーは，与えられたウィンドウの最上段に表示される.
        /// </summary>
        /// <param name="trackbar_name">トラックバーの名前</param>
        /// <param name="window_name">トラックバーの親ウィンドウの名前</param>
        /// <param name="value">ref of value</param>
        /// <param name="count">スライダの最大値．最小値は常に 0.</param>
        /// <param name="on_change">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the trackbar (a.k.a. slider or range control) with the specified name and range,
        /// assigns the variable to be syncronized with trackbar position and specifies callback function to be called on trackbar position change.
        /// The created trackbar is displayed on top of given window.
        /// </summary>
        /// <param name="trackbar_name">Name of created trackbar. </param>
        /// <param name="window_name">Name of the window which will e used as a parent for created trackbar. </param>
        /// <param name="value">Ref of int value</param>
        /// <param name="count">Maximal position of the slider. Minimal position is always 0. </param>
        /// <param name="on_change">Reference to the function to be called every time the slider changes the position.
        /// This function should be prototyped as void Foo(int);Can be null if callback is not required. </param>
        /// <returns></returns>
#endif
        public static int CreateTrackbar(string trackbar_name, string window_name, ref int value, int count, CvTrackbarCallback on_change)
        {
            //return CvDll.cvCreateTrackbar(trackbar_name, window_name, ref value, count, on_change);
            if (string.IsNullOrEmpty(trackbar_name))
                throw new ArgumentNullException("trackbar_name");
            if (string.IsNullOrEmpty(window_name))
                throw new ArgumentNullException("window_name");
            CvWindow window = CvWindow.GetWindowByName(window_name);
            if (window != null)
            {
                return CvInvoke.cvCreateTrackbar(trackbar_name, window_name, ref value, count, on_change);
            }
            return 0;
        }

#if LANG_JP
        /// <summary>
        /// 指定された名前と範囲のトラックバー（スライダ，レンジコントロールとも呼ばれる）を作成する．
        /// 作成されたトラックバーは，与えられたウィンドウの最上段に表示される.
        /// </summary>
        /// <param name="trackbar_name">トラックバーの名前</param>
        /// <param name="window_name">トラックバーの親ウィンドウの名前</param>
        /// <param name="value">スライダの初期位置</param>
        /// <param name="count">スライダの最大値．最小値は常に 0.</param>
        /// <param name="on_change">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the trackbar (a.k.a. slider or range control) with the specified name and range, 
        /// assigns the variable to be syncronized with trackbar position and specifies callback function to be called on trackbar position change. 
        /// The created trackbar is displayed on top of given window.
        /// </summary>
        /// <param name="trackbar_name">Name of created trackbar. </param>
        /// <param name="window_name">Name of the window which will e used as a parent for created trackbar. </param>
        /// <param name="value">Initial position of the slider.</param>
        /// <param name="count">Maximal position of the slider. Minimal position is always 0. </param>
        /// <param name="on_change">Reference to the function to be called every time the slider changes the position. 
        /// This function should be prototyped as void Foo(int);Can be null if callback is not required. </param>
        /// <returns></returns>
#endif
        public static int CreateTrackbar(string trackbar_name, string window_name, int value, int count, CvTrackbarCallback on_change)
        {
            //return CvDll.cvCreateTrackbar(trackbar_name, window_name, ref value, count, on_change);
            if (string.IsNullOrEmpty(trackbar_name))
                throw new ArgumentNullException("trackbar_name");
            if (string.IsNullOrEmpty(window_name))
                throw new ArgumentNullException("window_name");
            CvWindow window = CvWindow.GetWindowByName(window_name);
            if (window != null)
            {
                CvTrackbar trackbar = window.CreateTrackbar(trackbar_name, value, count, on_change);
                return trackbar.Result;
            }
            return 0;
        }

#if LANG_JP
        /// <summary>
        /// 指定された名前と範囲のトラックバー（スライダ，レンジコントロールとも呼ばれる）を作成する．
        /// 作成されたトラックバーは，与えられたウィンドウの最上段に表示される.
        /// </summary>
        /// <param name="trackbar_name">トラックバーの名前</param>
        /// <param name="window_name">トラックバーの親ウィンドウの名前</param>
        /// <param name="value">スライダの初期位置</param>
        /// <param name="count">スライダの最大値．最小値は常に 0.</param>
        /// <param name="on_change">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
        /// <param name="userdata"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the trackbar (a.k.a. slider or range control) with the specified name and range, 
        /// assigns the variable to be syncronized with trackbar position and specifies callback function to be called on trackbar position change. 
        /// The created trackbar is displayed on top of given window.
        /// </summary>
        /// <param name="trackbar_name">Name of created trackbar. </param>
        /// <param name="window_name">Name of the window which will e used as a parent for created trackbar. </param>
        /// <param name="value">Initial position of the slider.</param>
        /// <param name="count">Maximal position of the slider. Minimal position is always 0. </param>
        /// <param name="on_change">Reference to the function to be called every time the slider changes the position. 
        /// This function should be prototyped as void Foo(int);Can be null if callback is not required. </param>
        /// <param name="userdata"></param>
        /// <returns></returns>
#endif
        public static int CreateTrackbar2(string trackbar_name, string window_name, int value, int count, CvTrackbarCallback2 on_change, object userdata)
        {
            //return CvDll.cvCreateTrackbar(trackbar_name, window_name, ref value, count, on_change);
            if (string.IsNullOrEmpty(trackbar_name))
                throw new ArgumentNullException("trackbar_name");
            if (string.IsNullOrEmpty(window_name))
                throw new ArgumentNullException("window_name");
            CvWindow window = CvWindow.GetWindowByName(window_name);
            if (window != null)
            {
                CvTrackbar trackbar = window.CreateTrackbar2(trackbar_name, value, count, on_change, userdata);
                return trackbar.Result;
            }
            return 0;
        }
        #endregion
        #region CreateVideoWriter
#if LANG_JP
        /// <summary>
        /// ビデオライタを作成し、返す.
        /// </summary>
        /// <param name="filename">出力するビデオファイルの名前</param>
        /// <param name="fourcc">
        /// フレームを圧縮するためのコーデックを表す 4 文字．例えば，"PIM1" は，MPEG-1 コーデック， "MJPG" は，motion-jpeg コーデックである． 
        /// Win32 環境下では，null を渡すとダイアログから圧縮方法と圧縮のパラメータを選択できるようになる. 
        /// </param>
        /// <param name="fps">作成されたビデオストリームのフレームレート</param>
        /// <param name="frame_size">ビデオフレームのサイズ</param>
        /// <returns>CvVideoWriter</returns>
#else
        /// <summary>
        /// Creates video writer structure. 
        /// </summary>
        /// <param name="filename">Name of the output video file. </param>
        /// <param name="fourcc">4-character code of codec used to compress the frames. For example, "PIM1" is MPEG-1 codec, "MJPG" is motion-jpeg codec etc. 
        /// Under Win32 it is possible to pass null in order to choose compression method and additional compression parameters from dialog. </param>
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frame_size">Size of video frames. </param>
        /// <returns></returns>
#endif
        public static CvVideoWriter CreateVideoWriter(string filename, string fourcc, double fps, CvSize frame_size)
        {
            return new CvVideoWriter(filename, fourcc, fps, frame_size);
        }
#if LANG_JP
        /// <summary>
        /// ビデオライタを作成し、返す.
        /// </summary>
        /// <param name="filename">出力するビデオファイルの名前</param>
        /// <param name="fourcc">
        /// フレームを圧縮するためのコーデックを表す 4 文字．例えば，"PIM1" は，MPEG-1 コーデック， "MJPG" は，motion-jpeg コーデックである． 
        /// Win32 環境下では，null を渡すとダイアログから圧縮方法と圧縮のパラメータを選択できるようになる. 
        /// </param>
        /// <param name="fps">作成されたビデオストリームのフレームレート</param>
        /// <param name="frame_size">ビデオフレームのサイズ</param>
        /// <param name="is_color">trueの場合，エンコーダはカラーフレームとしてエンコードする． falseの場合，グレースケールフレームとして動作する（現在のところ，このフラグは Windows でのみ利用できる）．</param>
        /// <returns>CvVideoWriter</returns>
#else
        /// <summary>
        /// Creates video writer structure. 
        /// </summary>
        /// <param name="filename">Name of the output video file. </param>
        /// <param name="fourcc">4-character code of codec used to compress the frames. For example, "PIM1" is MPEG-1 codec, "MJPG" is motion-jpeg codec etc. 
        /// Under Win32 it is possible to pass null in order to choose compression method and additional compression parameters from dialog. </param>
        /// <param name="fps">Framerate of the created video stream. </param>
        /// <param name="frame_size">Size of video frames. </param>
        /// <param name="is_color">If it is true, the encoder will expect and encode color frames, otherwise it will work with grayscale frames (the flag is currently supported on Windows only). </param>
        /// <returns></returns>
#endif
        public static CvVideoWriter CreateVideoWriter(string filename, string fourcc, double fps, CvSize frame_size, bool is_color)
        {
            return new CvVideoWriter(filename, fourcc, fps, frame_size, is_color);
        }
        #endregion
        #region CrossProduct
#if LANG_JP
        /// <summary>
        /// 二つの3次元ベクトルの外積を計算する.
        /// dst = src1 × src2,  (dst1 = src12src23 - src13src22 , dst2 = src13src21 - src11src23 , dst3 = src11src22 - src12src21).
        /// </summary>
        /// <param name="src1">1番目の入力ベクトル</param>
        /// <param name="src2">2番目の入力ベクトル</param>
        /// <param name="dst">出力ベクトル</param>
#else
        /// <summary>
        /// Calculates cross product of two 3D vectors
        /// </summary>
        /// <param name="src1">The first source vector. </param>
        /// <param name="src2">The second source vector. </param>
        /// <param name="dst">The destination vector. </param>
#endif
        public static void CrossProduct(CvArr src1, CvArr src2, CvArr dst)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvCrossProduct(src1.CvPtr, src2.CvPtr, dst.CvPtr);
        }
        #endregion
        #region CvtColor
#if LANG_JP
        /// <summary>
        /// 入力画像の色空間を変換する
        /// </summary>
        /// <param name="src">入力画像. 8ビット(8u), 16ビット(16u), あるいは単精度浮動小数点型(32f).</param>
        /// <param name="dst">出力画像. 入力画像と同じデータタイプ. チャンネル数は違うこともある．</param>
        /// <param name="code">色空間の変換の方法</param>
#else
        /// <summary>
        /// Converts image from one color space to another.
        /// </summary>
        /// <param name="src">The source 8-bit (8u), 16-bit (16u) or single-precision floating-point (32f) image. </param>
        /// <param name="dst">The destination image of the same data type as the source one. The number of channels may be different. </param>
        /// <param name="code">Color conversion operation that can be specifed using CV_&lt;src_color_space&gt;2&lt;dst_color_space&gt; constants (see below). </param>
#endif
        public static void CvtColor(CvArr src, CvArr dst, ColorConversion code)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvCvtColor(src.CvPtr, dst.CvPtr, code);
        }
        #endregion
        #region CvtSeqToArray
#if LANG_JP
        /// <summary>
        /// シーケンスをメモリ内の連続した一つのブロックにコピーする
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seq">シーケンス</param>
        /// <param name="elements">十分に大きな領域を持つ出力配列</param>
        /// <returns>出力される配列. outされる引数 element と同じ値.</returns>
#else
        /// <summary>
        /// Copies sequence to one continuous block of memory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="elements">destination array that must be large enough. It should be a pointer to data, not a matrix header. </param>
        /// <returns></returns>
#endif
        public static T[] CvtSeqToArray<T>(CvSeq seq, out T[] elements) where T : struct
        {
            return CvtSeqToArray(seq, out elements, CvSlice.WholeSeq);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスをメモリ内の連続した一つのブロックにコピーする
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seq">シーケンス</param>
        /// <param name="elements">十分に大きな領域を持つ出力配列</param>
        /// <param name="slice">配列へコピーするシーケンス内の部分</param>
        /// <returns>出力される配列. outされる引数 element と同じ値.</returns>
#else
        /// <summary>
        /// Copies sequence to one continuous block of memory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="elements">destination array that must be large enough. It should be a pointer to data, not a matrix header. </param>
        /// <param name="slice">The sequence part to copy to the array. </param>
        /// <returns></returns>
#endif
        public static T[] CvtSeqToArray<T>(CvSeq seq, out T[] elements, CvSlice slice) where T : struct
        {
            if (seq == null)
                throw new ArgumentNullException("seq");

            elements = new T[seq.Total];

            //if (typeof(t).IsValueType)  // where t : struct
            {
                using (var elementsPtr = new ArrayAddress1<T>(elements))
                {
                    CvInvoke.cvCvtSeqToArray(seq.CvPtr, elementsPtr, slice);
                }
            }
            /*
            else  // CvSeq, CvMat, etc.
            {
                // IntPtrを取るコンストラクタをもたなければならない
                IntPtr[] ptrArray = new IntPtr[seq.Total];
                using (var ptr = new ArrayAddress1<IntPtr>(ptrArray))
                {
                    CvDll.cvCvtSeqToArray(seq.CvPtr, ptr, slice);
                }
                for (int i = 0; i < ptrArray.Length; i++)
                {
                    elements[i] = Util.ToObject<t>(ptrArray[i]);
                }
            }
            */
            return elements;
        }
        #endregion
    }
}