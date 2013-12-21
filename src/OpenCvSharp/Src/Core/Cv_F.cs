/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region FastArctan
#if LANG_JP
        /// <summary>
        /// 入力された2次元ベクトルの角度を計算する．角度は度（degree）単位で扱われ，0°から360°の範囲で変化する．精度は ~0.1°．
        /// </summary>
        /// <param name="y">2次元ベクトルのy座標</param>
        /// <param name="x">2次元ベクトルのx座標</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates angle of 2D vector
        /// </summary>
        /// <param name="y">y-coordinate of 2D vector </param>
        /// <param name="x">x-coordinate of 2D vector </param>
        /// <returns></returns>
#endif
        public static float FastArctan(float y, float x)
        {
            return CvInvoke.cvFastArctan(y, x);
        }
        #endregion
        #region FillConvexPoly
#if LANG_JP
        /// <summary>
        /// 凸ポリゴンの内部を塗りつぶす．
        /// </summary>
        /// <param name="img">ポリゴンが描かれる画像</param>
        /// <param name="pts">一つのポリゴンへのポインタの配列</param>
        /// <param name="color">ポリゴンの色</param>
#else
        /// <summary>
        /// Fills convex polygon
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to a single polygon. </param>
        /// <param name="color">Polygon color. </param>
#endif
        public static void FillConvexPoly(CvArr img, CvPoint[] pts, CvScalar color)
        {
            FillConvexPoly(img, pts, color, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 凸ポリゴンの内部を塗りつぶす．
        /// </summary>
        /// <param name="img">ポリゴンが描かれる画像</param>
        /// <param name="pts">一つのポリゴンへのポインタの配列</param>
        /// <param name="color">ポリゴンの色</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Fills convex polygon
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to a single polygon. </param>
        /// <param name="color">Polygon color. </param>
        /// <param name="lineType">Type of the polygon boundaries.</param>
#endif
        public static void FillConvexPoly(CvArr img, CvPoint[] pts, CvScalar color, LineType lineType)
        {
            FillConvexPoly(img, pts, color, lineType, 0);
        }
#if LANG_JP
        /// <summary>
        /// 凸ポリゴンの内部を塗りつぶす．
        /// </summary>
        /// <param name="img">ポリゴンが描かれる画像</param>
        /// <param name="pts">一つのポリゴンへのポインタの配列</param>
        /// <param name="color">ポリゴンの色</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">頂点座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Fills convex polygon
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to a single polygon. </param>
        /// <param name="color">Polygon color. </param>
        /// <param name="lineType">Type of the polygon boundaries.</param>
        /// <param name="shift">Number of fractional bits in the vertex coordinates. </param>
#endif
        public static void FillConvexPoly(CvArr img, CvPoint[] pts, CvScalar color, LineType lineType, int shift)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (pts == null)
                throw new ArgumentNullException("pts");
            if (pts.Length == 0)
                throw new ArgumentException();
            CvInvoke.cvFillConvexPoly(img.CvPtr, pts, pts.Length, color, lineType, shift);
        }
        #endregion
        #region FillPoly
#if LANG_JP
        /// <summary>
        /// ポリゴン内部を塗りつぶす
        /// </summary>
        /// <param name="img">ポリゴンが描かれる画像．</param>
        /// <param name="pts">ポリゴンへのポインタ配列．</param>
        /// <param name="color">ポリゴンの色．</param>
#else
        /// <summary>
        /// Fills polygons interior
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to polygons. </param>
        /// <param name="color">Polygon color. </param>
#endif
        public static void FillPoly(CvArr img, CvPoint[][] pts, CvScalar color)
        {
            FillPoly(img, pts, color, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// ポリゴン内部を塗りつぶす
        /// </summary>
        /// <param name="img">ポリゴンが描かれる画像．</param>
        /// <param name="pts">ポリゴンへのポインタ配列．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">線の種類．</param>
#else
        /// <summary>
        /// Fills polygons interior
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to polygons. </param>
        /// <param name="color">Polygon color. </param>
        /// <param name="lineType">ype of the polygon boundaries.</param>
#endif
        public static void FillPoly(CvArr img, CvPoint[][] pts, CvScalar color, LineType lineType)
        {
            FillPoly(img, pts, color, lineType, 0);
        }
#if LANG_JP
        /// <summary>
        /// ポリゴン内部を塗りつぶす
        /// </summary>
        /// <param name="img">ポリゴンが描かれる画像．</param>
        /// <param name="pts">ポリゴンへのポインタ配列．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">線の種類．</param>
        /// <param name="shift">頂点座標の小数点以下の桁を表すビット数．</param>
#else
        /// <summary>
        /// Fills polygons interior
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to polygons. </param>
        /// <param name="color">Polygon color. </param>
        /// <param name="lineType">ype of the polygon boundaries.</param>
        /// <param name="shift">Number of fractional bits in the vertex coordinates. </param>
#endif
        public static void FillPoly(CvArr img, CvPoint[][] pts, CvScalar color, LineType lineType, int shift)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (pts == null)
                throw new ArgumentNullException("pts");

            // npts
            int contours = pts.Length;
            int[] npts = new int[contours];
            for (int i = 0; i < contours; i++)
            {
                if (pts[i] == null)
                {
                    throw new ArgumentNullException(string.Format("pts[{0}]", i));
                }
                npts[i] = pts[i].Length;
            }

            using (var ptsPtr = new ArrayAddress2<CvPoint>(pts))
            {
                CvInvoke.cvFillPoly(img.CvPtr, ptsPtr.Pointer, npts, contours, color, lineType, shift);
            }
        }
        #endregion
        #region Filter2D
#if LANG_JP
        /// <summary>
        /// 画像に線形フィルタを適用する
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="kernel">フィルタマスク．係数のシングルチャンネルの2次元浮動小数点型行列．</param>
#else
        /// <summary>
        /// Applies arbitrary linear filter to the image. In-place operation is supported. 
        /// When the aperture is partially outside the image, the function interpolates outlier pixel values from the nearest pixels that is inside the image. 
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image. </param>
        /// <param name="kernel">Convolution kernel, single-channel floating point matrix. If you want to apply different kernels to different channels, split the image using cvSplit into separate color planes and process them individually. </param>
#endif
        public static void Filter2D(CvArr src, CvArr dst, CvMat kernel)
        {
            Filter2D(src, dst, kernel, new CvPoint(-1, -1));
        }
#if LANG_JP
        /// <summary>
        /// 画像に線形フィルタを適用する
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="kernel">フィルタマスク．係数のシングルチャンネルの2次元浮動小数点型行列．</param>
        /// <param name="anchor">カーネルのアンカー．カーネルマスクでカバーされる隣接領域内における， フィルタ対象となるピクセルの相対位置を表す．</param>
#else
        /// <summary>
        /// Applies arbitrary linear filter to the image. In-place operation is supported. 
        /// When the aperture is partially outside the image, the function interpolates outlier pixel values from the nearest pixels that is inside the image. 
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image. </param>
        /// <param name="kernel">Convolution kernel, single-channel floating point matrix. If you want to apply different kernels to different channels, split the image using cvSplit into separate color planes and process them individually. </param>
        /// <param name="anchor">The anchor of the kernel that indicates the relative position of a filtered point within the kernel. The anchor shoud lie within the kernel. The special default value (-1,-1) means that it is at the kernel center. </param>
#endif
        public static void Filter2D(CvArr src, CvArr dst, CvMat kernel, CvPoint anchor)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (kernel == null)
                throw new ArgumentNullException("kernel");
            CvInvoke.cvFilter2D(src.CvPtr, dst.CvPtr, kernel.CvPtr, anchor);
        }
        #endregion
        #region FindChessboardCorners
#if LANG_JP
        /// <summary>
        /// 入力画像がチェスボードパターンであるかどうかを確認し，チェスボードの各コーナーの位置検出を試みる．
        /// </summary>
        /// <param name="image">入力のチェスボード画像．8ビットのグレースケールまたはカラー画像．</param>
        /// <param name="patternSize">チェスボードの行と列ごとのコーナーの数</param>
        /// <param name="corners">検出されたコーナーの配列. Length=pattern_size.Width*pattern_size.Height</param>
        /// <returns>すべてのコーナーが検出され，正しい順番（行順で，かつ各行は左から右に並ぶ）でそれらが配置されている場合には, true</returns>
#else
        /// <summary>
        /// Finds positions of internal corners of the chessboard
        /// </summary>
        /// <param name="image">Source chessboard view; it must be 8-bit grayscale or color image. </param>
        /// <param name="patternSize">The number of inner corners per chessboard row and column. </param>
        /// <param name="corners">The output array of corners detected. </param>
        /// <returns>returns true if all the corners have been found and they have been placed in a certain order (row by row, left to right in every row), otherwise, if the function fails to find all the corners or reorder them, it returns false. </returns>
#endif
        public static bool FindChessboardCorners(CvArr image, CvSize patternSize, out CvPoint2D32f[] corners)
        {
            int cornerCount;
            return FindChessboardCorners(image, patternSize, out corners, out cornerCount, ChessboardFlag.AdaptiveThresh | ChessboardFlag.NormalizeImage);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像がチェスボードパターンであるかどうかを確認し，チェスボードの各コーナーの位置検出を試みる．
        /// </summary>
        /// <param name="image">入力のチェスボード画像．8ビットのグレースケールまたはカラー画像．</param>
        /// <param name="patternSize">チェスボードの行と列ごとのコーナーの数</param>
        /// <param name="corners">検出されたコーナーの配列. Length=pattern_size.Width*pattern_size.Height</param>
        /// <param name="cornerCount">コーナーの数が出力される</param>
        /// <returns>すべてのコーナーが検出され，正しい順番（行順で，かつ各行は左から右に並ぶ）でそれらが配置されている場合には, true</returns>
#else
        /// <summary>
        /// Finds positions of internal corners of the chessboard
        /// </summary>
        /// <param name="image">Source chessboard view; it must be 8-bit grayscale or color image. </param>
        /// <param name="patternSize">The number of inner corners per chessboard row and column. </param>
        /// <param name="corners">The output array of corners detected. </param>
        /// <param name="cornerCount">The output corner counter. If it is not null, the function stores there the number of corners found. </param>
        /// <returns>returns true if all the corners have been found and they have been placed in a certain order (row by row, left to right in every row), otherwise, if the function fails to find all the corners or reorder them, it returns false. </returns>
#endif
        public static bool FindChessboardCorners(CvArr image, CvSize patternSize, out CvPoint2D32f[] corners, out int cornerCount)
        {
            return FindChessboardCorners(image, patternSize, out corners, out cornerCount, ChessboardFlag.AdaptiveThresh | ChessboardFlag.NormalizeImage);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像がチェスボードパターンであるかどうかを確認し，チェスボードの各コーナーの位置検出を試みる．
        /// </summary>
        /// <param name="image">入力のチェスボード画像．8ビットのグレースケールまたはカラー画像．</param>
        /// <param name="patternSize">チェスボードの行と列ごとのコーナーの数</param>
        /// <param name="corners">検出されたコーナーの配列. Length=pattern_size.Width*pattern_size.Height</param>
        /// <param name="cornerCount">コーナーの数が出力される</param>
        /// <param name="flags">処理フラグ</param>
        /// <returns>すべてのコーナーが検出され，正しい順番（行順で，かつ各行は左から右に並ぶ）でそれらが配置されている場合には, true</returns>
#else
        /// <summary>
        /// Finds positions of internal corners of the chessboard
        /// </summary>
        /// <param name="image">Source chessboard view; it must be 8-bit grayscale or color image. </param>
        /// <param name="patternSize">The number of inner corners per chessboard row and column. </param>
        /// <param name="corners">The output array of corners detected. </param>
        /// <param name="cornerCount">The output corner counter. If it is not null, the function stores there the number of corners found. </param>
        /// <param name="flags">Various operation flags</param>
        /// <returns>returns true if all the corners have been found and they have been placed in a certain order (row by row, left to right in every row), otherwise, if the function fails to find all the corners or reorder them, it returns false. </returns>
#endif
        public static bool FindChessboardCorners(CvArr image, CvSize patternSize, out CvPoint2D32f[] corners, out int cornerCount, ChessboardFlag flags)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            cornerCount = patternSize.Width * patternSize.Height;
            corners = new CvPoint2D32f[cornerCount];

            using (var cornersPtr = new ArrayAddress1<CvPoint2D32f>(corners))
            {
                int result = CvInvoke.cvFindChessboardCorners(image.CvPtr, patternSize, cornersPtr, ref cornerCount, flags);
                return result != 0;
            }
        }
        #endregion
        #region FindContours
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を見つける
        /// </summary>
        /// <param name="image">入力画像（8ビットシングルチャンネル）．値が0以外のピクセルは「1」，0のピクセルは「0」とする.</param>
        /// <param name="storage">抽出された輪郭を保存する領域</param>
        /// <param name="firstContour">出力パラメータ．一番外側の輪郭へのポインタが入っている．</param>
        /// <returns>抽出した輪郭の個数</returns>
#else
        /// <summary>
        /// Retrieves contours from the binary image and returns the number of retrieved contours.
        /// </summary>
        /// <param name="image">The source 8-bit single channel image. Non-zero pixels are treated as 1’s, zero pixels remain 0’s - that is image treated as binary. 
        /// To get such a binary image from grayscale, one may use cvThreshold, cvAdaptiveThreshold or cvCanny. The function modifies the source image content. </param>
        /// <param name="storage">Container of the retrieved contours. </param>
        /// <param name="firstContour">Output parameter, will contain the pointer to the first outer contour. </param>
        /// <returns>The number of retrieved contours.</returns>
#endif
        public static int FindContours(CvArr image, CvMemStorage storage, out CvSeq<CvPoint> firstContour)
        {
            return FindContours(image, storage, out firstContour, CvContour.SizeOf, ContourRetrieval.List, ContourChain.ApproxSimple, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を見つける
        /// </summary>
        /// <param name="image">入力画像（8ビットシングルチャンネル）．値が0以外のピクセルは「1」，0のピクセルは「0」とする.</param>
        /// <param name="storage">抽出された輪郭を保存する領域</param>
        /// <param name="firstContour">出力パラメータ．一番外側の輪郭へのポインタが入っている．</param>
        /// <param name="headerSize">シーケンスヘッダのサイズ．method=CV_CHAIN_CODEの場合，>=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)．</param>
        /// <returns>抽出した輪郭の個数</returns>
#else
        /// <summary>
        /// Retrieves contours from the binary image and returns the number of retrieved contours.
        /// </summary>
        /// <param name="image">The source 8-bit single channel image. Non-zero pixels are treated as 1’s, zero pixels remain 0’s - that is image treated as binary. 
        /// To get such a binary image from grayscale, one may use cvThreshold, cvAdaptiveThreshold or cvCanny. The function modifies the source image content. </param>
        /// <param name="storage">Container of the retrieved contours. </param>
        /// <param name="firstContour">Output parameter, will contain the pointer to the first outer contour. </param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <returns>The number of retrieved contours.</returns>
#endif
        public static int FindContours(CvArr image, CvMemStorage storage, out CvSeq<CvPoint> firstContour, int headerSize)
        {
            return FindContours(image, storage, out firstContour, headerSize, ContourRetrieval.List, ContourChain.ApproxSimple, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を見つける
        /// </summary>
        /// <param name="image">入力画像（8ビットシングルチャンネル）．値が0以外のピクセルは「1」，0のピクセルは「0」とする.</param>
        /// <param name="storage">抽出された輪郭を保存する領域</param>
        /// <param name="firstContour">出力パラメータ．一番外側の輪郭へのポインタが入っている．</param>
        /// <param name="headerSize">シーケンスヘッダのサイズ．method=CV_CHAIN_CODEの場合，>=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)．</param>
        /// <param name="mode">抽出モード </param>
        /// <returns>抽出した輪郭の個数</returns>
#else
        /// <summary>
        /// Retrieves contours from the binary image and returns the number of retrieved contours.
        /// </summary>
        /// <param name="image">The source 8-bit single channel image. Non-zero pixels are treated as 1’s, zero pixels remain 0’s - that is image treated as binary. 
        /// To get such a binary image from grayscale, one may use cvThreshold, cvAdaptiveThreshold or cvCanny. The function modifies the source image content. </param>
        /// <param name="storage">Container of the retrieved contours. </param>
        /// <param name="firstContour">Output parameter, will contain the pointer to the first outer contour. </param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode. </param>
        /// <returns>The number of retrieved contours.</returns>
#endif
        public static int FindContours(CvArr image, CvMemStorage storage, out CvSeq<CvPoint> firstContour, int headerSize, ContourRetrieval mode)
        {
            return FindContours(image, storage, out firstContour, headerSize, mode, ContourChain.ApproxSimple, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を見つける
        /// </summary>
        /// <param name="image">入力画像（8ビットシングルチャンネル）．値が0以外のピクセルは「1」，0のピクセルは「0」とする.</param>
        /// <param name="storage">抽出された輪郭を保存する領域</param>
        /// <param name="firstContour">出力パラメータ．一番外側の輪郭へのポインタが入っている．</param>
        /// <param name="headerSize">シーケンスヘッダのサイズ．method=CV_CHAIN_CODEの場合，>=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)．</param>
        /// <param name="mode">抽出モード </param>
        /// <param name="method">近似手法</param>
        /// <returns>抽出した輪郭の個数</returns>
#else
        /// <summary>
        /// Retrieves contours from the binary image and returns the number of retrieved contours.
        /// </summary>
        /// <param name="image">The source 8-bit single channel image. Non-zero pixels are treated as 1’s, zero pixels remain 0’s - that is image treated as binary. 
        /// To get such a binary image from grayscale, one may use cvThreshold, cvAdaptiveThreshold or cvCanny. The function modifies the source image content. </param>
        /// <param name="storage">Container of the retrieved contours. </param>
        /// <param name="firstContour">Output parameter, will contain the pointer to the first outer contour. </param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode. </param>
        /// <param name="method">Approximation method. </param>
        /// <returns>The number of retrieved contours.</returns>
#endif
        public static int FindContours(CvArr image, CvMemStorage storage, out CvSeq<CvPoint> firstContour, int headerSize, ContourRetrieval mode, ContourChain method)
        {
            return FindContours(image, storage, out firstContour, headerSize, mode, method, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を見つける
        /// </summary>
        /// <param name="image">入力画像（8ビットシングルチャンネル）．値が0以外のピクセルは「1」，0のピクセルは「0」とする.</param>
        /// <param name="storage">抽出された輪郭を保存する領域</param>
        /// <param name="firstContour">出力パラメータ．一番外側の輪郭へのポインタが入っている．</param>
        /// <param name="headerSize">シーケンスヘッダのサイズ．method=CV_CHAIN_CODEの場合，>=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)．</param>
        /// <param name="mode">抽出モード </param>
        /// <param name="method">近似手法</param>
        /// <param name="offset">オフセット．全ての輪郭点はこれによってシフトされる.</param>
        /// <returns>抽出した輪郭の個数</returns>
#else
        /// <summary>
        /// Retrieves contours from the binary image and returns the number of retrieved contours.
        /// </summary>
        /// <param name="image">The source 8-bit single channel image. Non-zero pixels are treated as 1’s, zero pixels remain 0’s - that is image treated as binary. 
        /// To get such a binary image from grayscale, one may use cvThreshold, cvAdaptiveThreshold or cvCanny. The function modifies the source image content. </param>
        /// <param name="storage">Container of the retrieved contours. </param>
        /// <param name="firstContour">Output parameter, will contain the pointer to the first outer contour. </param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode. </param>
        /// <param name="method">Approximation method. </param>
        /// <param name="offset">Offset, by which every contour point is shifted. This is useful if the contours are extracted from the image ROI and then they should be analyzed in the whole image context. </param>
        /// <returns>The number of retrieved contours.</returns>
#endif
        public static int FindContours(CvArr image, CvMemStorage storage, out CvSeq<CvPoint> firstContour, int headerSize, ContourRetrieval mode, ContourChain method, CvPoint offset)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (storage == null)
                throw new ArgumentNullException("storage");

            IntPtr firstContourPtr = IntPtr.Zero;
            int result = CvInvoke.cvFindContours(image.CvPtr, storage.CvPtr, ref firstContourPtr, headerSize, mode, method, offset);

            if (firstContourPtr == IntPtr.Zero)
                firstContour = null;
            else if (method == ContourChain.Code)
                firstContour = new CvChain(firstContourPtr);
            else
                firstContour = new CvContour(firstContourPtr);
            
            return result;
        }
        #endregion
        #region FindCornerSubPix
#if LANG_JP
        /// <summary>
        /// コーナー位置を高精度化する.
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="corners">コーナーの初期座標が入力され，高精度化された座標が出力される.</param>
        /// <param name="count">コーナーの数</param>
        /// <param name="win">検索ウィンドウの半分のサイズ．（例）win=(5,5) ならば 5*2+1 × 5*2+1 = 11 × 11 が探索ウィンドウして使われる.</param>
        /// <param name="zeroZone">総和を計算する際に含まれない，探索領域の中心に存在する総和対象外領域の半分のサイズ．この値は，自己相関行列において発生しうる特異点を避けるために用いられる． 値が (-1,-1) の場合は，そのようなサイズはないということを意味する</param>
        /// <param name="criteria">コーナー座標の高精度化のための繰り返し処理の終了条件．コーナー位置の高精度化の繰り返し処理は，規定回数に達するか，目標精度に達したときに終了する．</param>
#else
        /// <summary>
        /// Iterates to find the sub-pixel accurate location of corners, or radial saddle points.
        /// </summary>
        /// <param name="image">Input image. </param>
        /// <param name="corners">Initial coordinates of the input corners and refined coordinates on output. </param>
        /// <param name="count">Number of corners. </param>
        /// <param name="win">Half sizes of the search window.</param>
        /// <param name="zeroZone">Half size of the dead region in the middle of the search zone over which the summation in formulae below is not done. It is used sometimes to avoid possible singularities of the autocorrelation matrix. The value of (-1,-1) indicates that there is no such size. </param>
        /// <param name="criteria">Criteria for termination of the iterative process of corner refinement. That is, the process of corner position refinement stops either after certain number of iteration or when a required accuracy is achieved. The criteria may specify either of or both the maximum number of iteration and the required accuracy. </param>
#endif
        public static void FindCornerSubPix(CvArr image, CvPoint2D32f[] corners, int count, CvSize win, CvSize zeroZone, CvTermCriteria criteria)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (corners == null)
                throw new ArgumentNullException("corners");

            CvInvoke.cvFindCornerSubPix(image.CvPtr, corners, count, win, zeroZone, criteria);
        }
        #endregion
        #region FindDominantPoints
#if LANG_JP
        /// <summary>
        /// Finds high-curvature points of the contour
        /// </summary>
        /// <param name="contour">pointer to input contour object.</param>
        /// <param name="storage">memory storage</param>
        /// <param name="method"></param>
        /// <param name="parameter1">for IPAN algorithm - minimal distance</param>
        /// <param name="parameter2">for IPAN algorithm - maximal distance</param>
        /// <param name="parameter3">for IPAN algorithm - neighborhood distance (must be not greater than dmaximal distance)</param>
        /// <param name="parameter4">for IPAN algorithm - minimal distance</param>
        /// <returns>array of dominant points indices</returns>
#else
        /// <summary>
        /// Finds high-curvature points of the contour
        /// </summary>
        /// <param name="contour">pointer to input contour object.</param>
        /// <param name="storage">memory storage</param>
        /// <param name="method"></param>
        /// <param name="parameter1">for IPAN algorithm - minimal distance</param>
        /// <param name="parameter2">for IPAN algorithm - maximal distance</param>
        /// <param name="parameter3">for IPAN algorithm - neighborhood distance (must be not greater than dmaximal distance)</param>
        /// <param name="parameter4">for IPAN algorithm - maximal possible angle of curvature</param>
        /// <returns>array of dominant points indices</returns>
#endif
        public static CvSeq<int> FindDominantPoints(CvSeq contour, CvMemStorage storage, DominantsFlag method,
             double parameter1, double parameter2, double parameter3, double parameter4)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");

            IntPtr storagePtr = (storage == null) ? IntPtr.Zero : storage.CvPtr;

            IntPtr result = CvInvoke.cvFindDominantPoints(contour.CvPtr, storagePtr, method, parameter1, parameter2, parameter3, parameter4);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSeq<int>(result);
        }
        #endregion
        #region FindExtrinsicCameraParams2
#if LANG_JP
        /// <summary>
        /// 既知の内部パラメータを用いて，それぞれのビューにおける外部パラメータを推定する．
        /// 3次元のオブジェクトの点とそれに対応する２次元投影点が指定されなければならない．この関数も逆投影誤差の最小化を行う．
        /// </summary>
        /// <param name="objectPoints">オブジェクトの点の配列．3xNまたはNx3でNはビューにおける点の数．</param>
        /// <param name="imagePoints">対応する画像上の点の配列．2xNまたはNx2でNはビューにおける点の数．</param>
        /// <param name="intrinsicMatrix">カメラ内部行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">歪み係数のベクトル．4x1または1x4 [k1, k2, p1, p2]．nullの場合，歪み係数はすべて0 であるとする．</param>
        /// <param name="rotationVector">出力される 3x1 の回転ベクトル</param>
        /// <param name="translationVector">出力される 3x1 の並進ベクトル</param>
#else
        /// <summary>
        /// Finds extrinsic camera parameters for particular view
        /// </summary>
        /// <param name="objectPoints">The array of object points, 3xN or Nx3, where N is the number of points in the view. </param>
        /// <param name="imagePoints">The array of corresponding image points, 2xN or Nx2, where N is the number of points in the view. </param>
        /// <param name="intrinsicMatrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. If it is null, all distortion coefficients are considered 0's. </param>
        /// <param name="rotationVector">The output 3x1 or 1x3 rotation vector (compact representation of a rotation matrix, see cvRodrigues2). </param>
        /// <param name="translationVector">The output 3x1 or 1x3 translation vector. </param>
#endif
        public static void FindExtrinsicCameraParams2(CvMat objectPoints, CvMat imagePoints, CvMat intrinsicMatrix, CvMat distortionCoeffs, CvMat rotationVector, CvMat translationVector)
        {
            FindExtrinsicCameraParams2(objectPoints, imagePoints, intrinsicMatrix, distortionCoeffs, rotationVector, translationVector, false);
        }
#if LANG_JP
        /// <summary>
        /// 既知の内部パラメータを用いて，それぞれのビューにおける外部パラメータを推定する．
        /// 3次元のオブジェクトの点とそれに対応する２次元投影点が指定されなければならない．この関数も逆投影誤差の最小化を行う．
        /// </summary>
        /// <param name="objectPoints">オブジェクトの点の配列．3xNまたはNx3でNはビューにおける点の数．</param>
        /// <param name="imagePoints">対応する画像上の点の配列．2xNまたはNx2でNはビューにおける点の数．</param>
        /// <param name="intrinsicMatrix">カメラ内部行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">歪み係数のベクトル．4x1または1x4 [k1, k2, p1, p2]．nullの場合，歪み係数はすべて0 であるとする．</param>
        /// <param name="rotationVector">出力される 3x1 の回転ベクトル</param>
        /// <param name="translationVector">出力される 3x1 の並進ベクトル</param>
        /// <param name="useExtrinsicGuess"></param>
#else
        /// <summary>
        /// Finds extrinsic camera parameters for particular view
        /// </summary>
        /// <param name="objectPoints">The array of object points, 3xN or Nx3, where N is the number of points in the view. </param>
        /// <param name="imagePoints">The array of corresponding image points, 2xN or Nx2, where N is the number of points in the view. </param>
        /// <param name="intrinsicMatrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. If it is NULL, all distortion coefficients are considered 0's. </param>
        /// <param name="rotationVector">The output 3x1 or 1x3 rotation vector (compact representation of a rotation matrix, see cvRodrigues2). </param>
        /// <param name="translationVector">The output 3x1 or 1x3 translation vector. </param>
        /// <param name="useExtrinsicGuess"></param>
#endif
        public static void FindExtrinsicCameraParams2(CvMat objectPoints, CvMat imagePoints, CvMat intrinsicMatrix, CvMat distortionCoeffs, CvMat rotationVector, CvMat translationVector, bool useExtrinsicGuess)
        {
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (imagePoints == null)
                throw new ArgumentNullException("imagePoints");
            if (intrinsicMatrix == null)
                throw new ArgumentNullException("intrinsicMatrix");
            if (rotationVector == null)
                throw new ArgumentNullException("rotationVector");
            if (translationVector == null)
                throw new ArgumentNullException("translationVector");
            IntPtr distortionCoeffsPtr = ToPtr(distortionCoeffs);
            CvInvoke.cvFindExtrinsicCameraParams2(objectPoints.CvPtr, imagePoints.CvPtr, intrinsicMatrix.CvPtr, distortionCoeffsPtr, rotationVector.CvPtr, translationVector.CvPtr, useExtrinsicGuess);
        }

        #region C# Implementation
        // ReSharper disable InconsistentNaming
        // ReSharper disable TooWideLocalVariableScope
#if LANG_JP
        /// <summary>
        /// 既知の内部パラメータを用いて，それぞれのビューにおける外部パラメータを推定する．
        /// 3次元のオブジェクトの点とそれに対応する２次元投影点が指定されなければならない．この関数も逆投影誤差の最小化を行う．
        /// </summary>
        /// <param name="objectPoints">オブジェクトの点の配列．3xNまたはNx3でNはビューにおける点の数．</param>
        /// <param name="imagePoints">対応する画像上の点の配列．2xNまたはNx2でNはビューにおける点の数．</param>
        /// <param name="cameraMatrix">カメラ内部行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distCoeffs">歪み係数のベクトル．4x1または1x4 [k1, k2, p1, p2]．nullの場合，歪み係数はすべて0 であるとする．</param>
        /// <param name="rvec">出力される 3x1 の回転ベクトル</param>
        /// <param name="tvec">出力される 3x1 の並進ベクトル</param>
#else
        /// <summary>
        /// Finds extrinsic camera parameters for particular view
        /// </summary>
        /// <param name="objectPoints">The array of object points, 3xN or Nx3, where N is the number of points in the view. </param>
        /// <param name="imagePoints">The array of corresponding image points, 2xN or Nx2, where N is the number of points in the view. </param>
        /// <param name="cameraMatrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distCoeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. If it is NULL, all distortion coefficients are considered 0's. </param>
        /// <param name="rvec">The output 3x1 or 1x3 rotation vector (compact representation of a rotation matrix, see cvRodrigues2). </param>
        /// <param name="tvec">The output 3x1 or 1x3 translation vector. </param>
#endif
        public static void FindExtrinsicCameraParams2Cs(CvMat objectPoints, CvMat imagePoints, CvMat cameraMatrix, CvMat distCoeffs, CvMat rvec, CvMat tvec)
        {
            FindExtrinsicCameraParams2Cs(objectPoints, imagePoints, cameraMatrix, distCoeffs, rvec, tvec, false);
        }
#if LANG_JP
        /// <summary>
        /// 既知の内部パラメータを用いて，それぞれのビューにおける外部パラメータを推定する．
        /// 3次元のオブジェクトの点とそれに対応する２次元投影点が指定されなければならない．この関数も逆投影誤差の最小化を行う．
        /// </summary>
        /// <param name="objectPoints">オブジェクトの点の配列．3xNまたはNx3でNはビューにおける点の数．</param>
        /// <param name="imagePoints">対応する画像上の点の配列．2xNまたはNx2でNはビューにおける点の数．</param>
        /// <param name="cameraMatrix">カメラ内部行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distCoeffs">歪み係数のベクトル．4x1または1x4 [k1, k2, p1, p2]．nullの場合，歪み係数はすべて0 であるとする．</param>
        /// <param name="rvec">出力される 3x1 の回転ベクトル</param>
        /// <param name="tvec">出力される 3x1 の並進ベクトル</param>
        /// <param name="useExtrinsicGuess"></param>
#else
        /// <summary>
        /// Finds extrinsic camera parameters for particular view
        /// </summary>
        /// <param name="objectPoints">The array of object points, 3xN or Nx3, where N is the number of points in the view. </param>
        /// <param name="imagePoints">The array of corresponding image points, 2xN or Nx2, where N is the number of points in the view. </param>
        /// <param name="cameraMatrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distCoeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. If it is NULL, all distortion coefficients are considered 0's. </param>
        /// <param name="rvec">The output 3x1 or 1x3 rotation vector (compact representation of a rotation matrix, see cvRodrigues2). </param>
        /// <param name="tvec">The output 3x1 or 1x3 translation vector. </param>
        /// <param name="useExtrinsicGuess"></param>
#endif
        public static void FindExtrinsicCameraParams2Cs(CvMat objectPoints, CvMat imagePoints, CvMat cameraMatrix, CvMat distCoeffs, CvMat rvec, CvMat tvec, bool useExtrinsicGuess)
        {

            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (imagePoints == null)
                throw new ArgumentNullException("imagePoints");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (rvec == null)
                throw new ArgumentNullException("rvec");
            if (tvec == null)
                throw new ArgumentNullException("tvec");
            //IntPtr distCoeffsPtr = ToPtr(distCoeffs);

            unsafe
            {
                const int maxIter = 20;

                double[] ar = new double[9] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };

                double[] MM = new double[9],
                       U = new double[9],
                       V = new double[9],
                       W = new double[3];
                double* param = stackalloc double[6];

                CvMat matA = new CvMat(3, 3, MatrixType.F64C1);
                CvMat _Ar = new CvMat(3, 3, MatrixType.F64C1, ar);
                CvMat matR = new CvMat(3, 3, MatrixType.F64C1);
                CvMat _r = new CvMat(3, 1, MatrixType.F64C1, new IntPtr(param));
                CvMat _t = new CvMat(3, 1, MatrixType.F64C1, new IntPtr(param + 3));
                CvMat _Mc = new CvMat(1, 3, MatrixType.F64C1);
                CvMat _MM = new CvMat(3, 3, MatrixType.F64C1, MM);
                CvMat matU = new CvMat(3, 3, MatrixType.F64C1, U);
                CvMat matV = new CvMat(3, 3, MatrixType.F64C1, V);
                CvMat matW = new CvMat(3, 1, MatrixType.F64C1, W);
                CvMat _param = new CvMat(6, 1, MatrixType.F64C1, new IntPtr(param));

                CvMat _dpdr, _dpdt;


                if (!IS_MAT(objectPoints.CvPtr) ||
                    !IS_MAT(imagePoints.CvPtr) ||
                    !IS_MAT(cameraMatrix.CvPtr) ||
                    !IS_MAT(rvec.CvPtr) ||
                    !IS_MAT(tvec.CvPtr))
                {
                    throw new ArgumentException();
                }

                int count = Math.Max(objectPoints.Cols, objectPoints.Rows);
                CvMat matM = new CvMat(1, count, MatrixType.F64C3);
                CvMat _m = new CvMat(1, count, MatrixType.F64C2);

                ConvertPointsHomogeneous(objectPoints, matM);
                ConvertPointsHomogeneous(imagePoints, _m);
                Convert(cameraMatrix, matA);

                if (!((rvec.ElemType == MatrixType.F64C1 || rvec.ElemType == MatrixType.F32C1) &&
                    (rvec.Rows == 1 || rvec.Cols == 1) && rvec.Rows * rvec.Cols * rvec.ElemChannels == 3))
                {
                    throw new ArgumentException();
                }
                if (!((tvec.ElemType == MatrixType.F64C1 || tvec.ElemType == MatrixType.F32C1) &&
                    (tvec.Rows == 1 || tvec.Cols == 1) && tvec.Rows * tvec.Cols * tvec.ElemChannels == 3))
                {
                    throw new ArgumentException();
                }

                CvMat _mn = new CvMat(1, count, MatrixType.F64C2);
                CvMat _Mxy = new CvMat(1, count, MatrixType.F64C2);

                // normalize image points
                // (unapply the intrinsic matrix transformation and distortion)
                UndistortPoints_(_m, _mn, matA, distCoeffs, null, _Ar);

                if (useExtrinsicGuess)
                {
                    using (CvMat _r_temp = new CvMat(rvec.Rows, rvec.Cols, MatrixType.F64C1))
                    using (CvMat _t_temp = new CvMat(tvec.Rows, tvec.Cols, MatrixType.F64C1))
                    {
                        Convert(rvec, _r_temp);
                        Convert(tvec, _t_temp);
                        for (int i = 0; i < Math.Max(rvec.Rows, rvec.Cols); i++)
                        {
                            param[i] = _r_temp.GetReal1D(i);
                            param[i + 3] = _t_temp.GetReal1D(i);
                        }
                    }
                }
                else
                {
                    CvScalar Mc = Avg(matM);
                    _Mc[0] = Mc.Val0;
                    _Mc[1] = Mc.Val1;
                    _Mc[2] = Mc.Val2;
                    Reshape(matM, matM, 1, count);
                    MulTransposed(matM, _MM, true, _Mc);
                    SVD(_MM, matW, null, matV, SVDFlag.ModifyA | SVDFlag.V_T);

                    // initialize extrinsic parameters
                    if (W[2] / W[1] < 1e-3 || count < 4)
                    {
                        // a planar structure case (all M's lie in the same plane)
                        double[] h = new double[9];
                        CvMat R_transform = matV;
                        CvMat T_transform = new CvMat(3, 1, MatrixType.F64C1);
                        CvMat matH = new CvMat(3, 3, MatrixType.F64C1, h);
                        CvMat _h1, _h2, _h3;

                        if (V[2] * V[2] + V[5] * V[5] < 1e-10)
                            SetIdentity(R_transform);

                        if (Det(R_transform) < 0)
                            Scale(R_transform, R_transform, -1);

                        //GEMM(R_transform, _Mc, -1, null, 0, T_transform, GemmOperation.B_T);
                        for (int r = 0; r < 3; r++)
                        {                            
                            for (int c = 0; c < 1; c++)
                            {
                                double sum = 0;
                                for (int k = 0; k < 3; k++)
                                {
                                    sum += R_transform.GetReal2D(r, k) * _Mc.GetReal2D(c, k);
                                }
                                T_transform.SetReal2D(r, c, sum * -1);
                            }
                        }

                        for (int i = 0; i < count; i++)
                        {
                            double* Rp = R_transform.DataDouble;
                            double* Tp = T_transform.DataDouble;
                            double* src = matM.DataDouble + i * 3;
                            double* dst = _Mxy.DataDouble + i * 2;

                            dst[0] = Rp[0] * src[0] + Rp[1] * src[1] + Rp[2] * src[2] + Tp[0];
                            dst[1] = Rp[3] * src[0] + Rp[4] * src[1] + Rp[5] * src[2] + Tp[1];
                        }

                        FindHomography_(_Mxy, _mn, matH);

                        GetCol(matH, out _h1, 0);
                        GetCol(matH, out _h2, 0);
                        GetCol(matH, out _h3, 0);                        
                        _h2.DataDouble += 1;
                        _h3.DataDouble += 2;
                        double h1_norm = Math.Sqrt(h[0] * h[0] + h[3] * h[3] + h[6] * h[6]);
                        double h2_norm = Math.Sqrt(h[1] * h[1] + h[4] * h[4] + h[7] * h[7]);
                        Scale(_h1, _h1, 1.0 / h1_norm);
                        Scale(_h2, _h2, 1.0 / h2_norm);
                        Scale(_h3, _t, 2.0 / (h1_norm + h2_norm));                       
                        CrossProduct(_h1, _h2, _h3);

                        Rodrigues2_(matH, _r);
                        Rodrigues2_(_r, matH);
                        MatMulAdd(matH, T_transform, _t, _t);
                        MatMul(matH, R_transform, matR);
                        Rodrigues2_(matR, _r);
                    }
                    else
                    {
                        // non-planar structure. Use DLT method
                        double[] LL = new double[12 * 12],
                                 LW = new double[12],
                                 LV = new double[12 * 12];
                        CvMat _LL = new CvMat(12, 12, MatrixType.F64C1, LL);
                        CvMat _LW = new CvMat(12, 1, MatrixType.F64C1, LW);
                        CvMat _LV = new CvMat(12, 12, MatrixType.F64C1, LV);
                        CvMat _RR, _tt;
                        CvPoint3D64f* M = (CvPoint3D64f*)matM.DataDouble;
                        CvPoint2D64f* mn = (CvPoint2D64f*)_mn.DataDouble;

                        CvMat matL = new CvMat(2 * count, 12, MatrixType.F64C1);
                        double* L = matL.DataDouble;

                        for (int i = 0; i < count; i++, L += 24)
                        {
                            double x = -mn[i].X, y = -mn[i].Y;
                            L[0] = L[16] = M[i].X;
                            L[1] = L[17] = M[i].Y;
                            L[2] = L[18] = M[i].Z;
                            L[3] = L[19] = 1.0;
                            L[4] = L[5] = L[6] = L[7] = 0.0;
                            L[12] = L[13] = L[14] = L[15] = 0.0;
                            L[8] = x * M[i].X;
                            L[9] = x * M[i].Y;
                            L[10] = x * M[i].Z;
                            L[11] = x;
                            L[20] = y * M[i].X;
                            L[21] = y * M[i].Y;
                            L[22] = y * M[i].Z;
                            L[23] = y;
                        }

                        MulTransposed(matL, _LL, true);
                        SVD(_LL, _LW, null, _LV, SVDFlag.ModifyA | SVDFlag.V_T);
                        double[] LV12 = new double[12];
                        Array.Copy(LV, 11 * 12, LV12, 0, 12);
                        CvMat _RRt = new CvMat(3, 4, MatrixType.F64C1, LV12);
                        GetCols(_RRt, out _RR, 0, 3);
                        GetCol(_RRt, out _tt, 3);
                        if (Det(_RR) < 0)
                            Scale(_RRt, _RRt, -1);
                        double sc = Norm(_RR);
                        SVD(_RR, matW, matU, matV, SVDFlag.ModifyA | SVDFlag.U_T | SVDFlag.V_T);
                        GEMM(matU, matV, 1, null, 0, matR, GemmOperation.A_T);
                        Scale(_tt, _t, Norm(matR) / sc);
                        Rodrigues2_(matR, _r);
                    }
                }

                Cv.Reshape(matM, matM, 3, 1);
                Cv.Reshape(_mn, _mn, 2, 1);

                // refine extrinsic parameters using iterative algorithm
                CvLevMarq solver = new CvLevMarq(6, count * 2, new CvTermCriteria(maxIter, float.Epsilon), true);
                Copy(_param, solver.Param);

                /*
                Console.WriteLine("matM-----");
                for (int i = 0; i < matM.Rows * matM.Cols; i++)
                {
                    Console.WriteLine("{0}\t", matM[i].Val0);
                }
                Console.WriteLine("_mn-----");
                for (int i = 0; i < _mn.Rows * _mn.Cols; i++)
                {
                    Console.WriteLine(_mn[i].Val0);
                }
                Console.WriteLine("_param-----");
                for (int i = 0; i < _param.Rows * _param.Cols; i++)
                {
                    Console.WriteLine(_param[i].Val0);
                }*/

                for (; ; )
                {
                    CvMat matJ, _err, __param;
                    bool proceed = solver.Update(out __param, out matJ, out _err);
                    Copy(__param, _param);
                    if (!proceed || _err == null)
                        break;
                    Reshape(_err, _err, 2, 1);
                    if (matJ != null)
                    {
                        GetCols(matJ, out _dpdr, 0, 3);
                        GetCols(matJ, out _dpdt, 3, 6);
                        ProjectPoints2(matM, _r, _t, matA, distCoeffs,
                                          _err, _dpdr, _dpdt, null, null, null);
                    }
                    else
                    {
                        ProjectPoints2(matM, _r, _t, matA, distCoeffs, _err, null, null, null, null, null);
                    }
                    Sub(_err, _m, _err);
                    Reshape(_err, _err, 1, 2 * count);
                }
                Copy(solver.Param, _param);

                for (int i = 0; i < 3; i++)
                {
                    rvec.SetReal1D(i, param[i]);
                    tvec.SetReal1D(i, param[i + 3]);
                }
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_src"></param>
        /// <param name="_dst"></param>
        /// <param name="_cameraMatrix"></param>
        /// <param name="_distCoeffs"></param>
        /// <param name="matR"></param>
        /// <param name="matP"></param>
        internal unsafe static void UndistortPoints_(CvMat _src, CvMat _dst, CvMat _cameraMatrix, CvMat _distCoeffs, CvMat matR, CvMat matP)
        {
            double[,] A = new double[3, 3];
            double[,] RR = new double[3, 3];
            double[] k = new double[5] { 0, 0, 0, 0, 0 };
            CvMat matA = new CvMat(3, 3, MatrixType.F64C1, A), _Dk;
            CvMat _RR = new CvMat(3, 3, MatrixType.F64C1, RR);
            int iters = 1;

            /*
            CV_Assert( CV_IS_MAT(_src) && CV_IS_MAT(_dst) &&
                (_src->rows == 1 || _src->cols == 1) &&
                (_dst->rows == 1 || _dst->cols == 1) &&
                _src->cols + _src->rows - 1 == _dst->rows + _dst->cols - 1 &&
                (CV_MAT_TYPE(_src->type) == CV_32FC2 || CV_MAT_TYPE(_src->type) == CV_64FC2) &&
                (CV_MAT_TYPE(_dst->type) == CV_32FC2 || CV_MAT_TYPE(_dst->type) == CV_64FC2));

            */
            if (!(IS_MAT(_cameraMatrix.CvPtr) && _cameraMatrix.Rows == 3 && _cameraMatrix.Cols == 3))
            {
                throw new ArgumentException();
            }

            Convert(_cameraMatrix, matA);

            if (_distCoeffs != null)
            {
                /*
                CV_Assert( CV_IS_MAT(_distCoeffs) &&
                    (_distCoeffs->rows == 1 || _distCoeffs->cols == 1) &&
                    (_distCoeffs->rows*_distCoeffs->cols == 4 ||
                    _distCoeffs->rows*_distCoeffs->cols == 5) );*/

                _Dk = new CvMat(_distCoeffs.Rows, _distCoeffs.Cols, (MatrixType)MAKETYPE(CvConst.CV_64F, MAT_CN(_distCoeffs.Type)), k);

                Cv.Convert(_distCoeffs, _Dk);
                iters = 5;
            }

            if (matR != null)
            {
                if (!(IS_MAT(matR) && matR.Rows == 3 && matR.Cols == 3))
                {
                    throw new ArgumentException();
                }
                Convert(matR, _RR);
            }
            else
                SetIdentity(_RR);

            if (matP != null)
            {
                double[,] PP = new double[3, 3];
                CvMat _P3x3;
                CvMat _PP = new CvMat(3, 3, MatrixType.F64C1, PP);
                if (!(IS_MAT(matP) && matP.Rows == 3 && (matP.Cols == 3 || matP.Cols == 4)))
                {
                }
                GetCols(matP, out _P3x3, 0, 3);
                Convert(_P3x3, _PP);
                MatMul(_PP, _RR, _RR);
            }

            CvPoint2D32f* srcf = (CvPoint2D32f*)_src.DataByte;
            CvPoint2D64f* srcd = (CvPoint2D64f*)_src.DataByte;
            CvPoint2D32f* dstf = (CvPoint2D32f*)_dst.DataByte;
            CvPoint2D64f* dstd = (CvPoint2D64f*)_dst.DataByte;
            int stype = MAT_TYPE(_src.Type);
            int dtype = MAT_TYPE(_dst.Type);
            int sstep = _src.Rows == 1 ? 1 : _src.Step / ELEM_SIZE(stype);
            int dstep = _dst.Rows == 1 ? 1 : _dst.Step / ELEM_SIZE(dtype);

            int n = _src.Rows + _src.Cols - 1;

            double fx = A[0, 0];
            double fy = A[1, 1];
            double ifx = 1.0 / fx;
            double ify = 1.0 / fy;
            double cx = A[0, 2];
            double cy = A[1, 2];

            for (int i = 0; i < n; i++)
            {
                double x, y, x0, y0;
                if (stype == (int)MatrixType.F32C2)
                {
                    x = srcf[i * sstep].X;
                    y = srcf[i * sstep].Y;
                }
                else
                {
                    x = srcd[i * sstep].X;
                    y = srcd[i * sstep].Y;
                }

                x0 = x = (x - cx) * ifx;
                y0 = y = (y - cy) * ify;

                // compensate distortion iteratively
                for (int j = 0; j < iters; j++)
                {
                    double r2 = x * x + y * y;
                    double icdist = 1.0 / (1 + ((k[4] * r2 + k[1]) * r2 + k[0]) * r2);
                    double deltaX = 2 * k[2] * x * y + k[3] * (r2 + 2 * x * x);
                    double deltaY = k[2] * (r2 + 2 * y * y) + 2 * k[3] * x * y;
                    x = (x0 - deltaX) * icdist;
                    y = (y0 - deltaY) * icdist;
                }

                double xx = RR[0, 0] * x + RR[0, 1] * y + RR[0, 2];
                double yy = RR[1, 0] * x + RR[1, 1] * y + RR[1, 2];
                double ww = 1.0 / (RR[2, 0] * x + RR[2, 1] * y + RR[2, 2]);
                x = xx * ww;
                y = yy * ww;

                if (dtype == (int)MatrixType.F32C2)
                {
                    dstf[i * dstep].X = (float)x;
                    dstf[i * dstep].Y = (float)y;
                }
                else
                {
                    dstd[i * dstep].X = x;
                    dstd[i * dstep].Y = y;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectPoints"></param>
        /// <param name="imagePoints"></param>
        /// <param name="__H"></param>
        /// <returns></returns>
        internal static unsafe int FindHomography_(CvMat objectPoints, CvMat imagePoints, CvMat __H)
        {
            //const double confidence = 0.995;
            //const int maxIters = 2000;

            double[] H = new double[9];
            CvMat matH = new CvMat(3, 3, MatrixType.F64C1, H);

            if (!IS_MAT(imagePoints) || !IS_MAT(objectPoints))
            {
                throw new ArgumentException();
            }

            int count = Math.Max(imagePoints.Cols, imagePoints.Rows);
            if (count < 4)
            {
                throw new ArgumentException();
            }

            CvMat m = new CvMat(1, count, MatrixType.F64C2);
            ConvertPointsHomogeneous(imagePoints, m);

            CvMat M = new CvMat(1, count, MatrixType.F64C2);
            ConvertPointsHomogeneous(objectPoints, M);

            CvMat tempMask = null;
            if (count > 4)
            {
                tempMask = new CvMat(1, count, MatrixType.U8C1);
                Set(tempMask, CvScalar.ScalarAll(1.0));
            }

            CvHomographyEstimator estimator = new CvHomographyEstimator(Math.Min(count, 4));
            bool result = estimator.RunKernel(M, m, matH) > 0;

            if (result && count > 4)
            {
                icvCompressPoints((CvPoint2D64f*)M.DataByte, tempMask.DataByte, 1, count);
                count = icvCompressPoints((CvPoint2D64f*)m.DataByte, tempMask.DataByte, 1, count);
                M.Cols = m.Cols = count;
                estimator.Refine(M, m, matH, 10);
            }

            if (result)
                Convert(matH, __H);

            return result ? 1 : 0;
        }
        private static unsafe int icvCompressPoints( CvPoint2D64f* ptr, byte* mask, int mstep, int count )
        {
            int i, j;
            for( i = j = 0; i < count; i++ )
                if( mask[i*mstep] != 0 )
                {
                    if( i > j )
                        ptr[j] = ptr[i];
                    j++;
                }
            return j;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        internal static unsafe int Rodrigues2_(CvMat src, CvMat dst)
        {
            double[] J = new double[27];
            CvMat matJ = new CvMat(3, 9, MatrixType.F64C1, J);

            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            /*
            if( !CV_IS_MAT(src) )
                CV_Error( !src ? CV_StsNullPtr : CV_StsBadArg, "Input argument is not a valid matrix" );

            if( !CV_IS_MAT(dst) )
                CV_Error( !dst ? CV_StsNullPtr : CV_StsBadArg,
                "The first output argument is not a valid matrix" );
            */

            int depth = MAT_DEPTH(src.Type);
            int elem_size = ELEM_SIZE(depth);

            if (depth != CvConst.CV_32F && depth != CvConst.CV_64F)
                throw new ArgumentException("The matrices must have 32f or 64f data type");

            if (!ARE_DEPTHS_EQ(src, dst))
                throw new ArgumentException("All the matrices must have the same data type");

            if (src.Cols == 1 || src.Rows == 1)
            {
                double rx, ry, rz;
                int step = src.Rows > 1 ? src.Step / elem_size : 1;

                if (src.Rows + src.Cols * MAT_CN(src.Type) - 1 != 3)
                    throw new ArgumentException("Input matrix must be 1x3, 3x1 or 3x3");

                if (dst.Rows != 3 || dst.Cols != 3 || MAT_CN(dst.Type) != 1)
                    throw new ArgumentException("Output matrix must be 3x3, single-channel floating point matrix");

                if (depth == CvConst.CV_32F)
                {
                    rx = src.DataSingle[0];
                    ry = src.DataSingle[step];
                    rz = src.DataSingle[step * 2];
                }
                else
                {
                    rx = src.DataDouble[0];
                    ry = src.DataDouble[step];
                    rz = src.DataDouble[step * 2];
                }
                double theta = Math.Sqrt(rx * rx + ry * ry + rz * rz);

                if (theta < double.Epsilon)
                {
                    SetIdentity(dst);
                }
                else
                {
                    double[] I = { 1, 0, 0, 0, 1, 0, 0, 0, 1 };

                    double c = Math.Cos(theta);
                    double s = Math.Sin(theta);
                    double c1 = 1.0 - c;
                    double itheta = (theta != 0) ? 1.0 / theta : 0.0;

                    rx *= itheta; ry *= itheta; rz *= itheta;

                    double[] rrt = { rx * rx, rx * ry, rx * rz, rx * ry, ry * ry, ry * rz, rx * rz, ry * rz, rz * rz };
                    double[] _r_x_ = { 0, -rz, ry, rz, 0, -rx, -ry, rx, 0 };
                    double[] R = new double[9];
                    CvMat matR = new CvMat(3, 3, MatrixType.F64C1, R);

                    // R = cos(theta)*I + (1 - cos(theta))*r*rT + sin(theta)*[r_x]
                    // where [r_x] is [0 -rz ry; rz 0 -rx; -ry rx 0]
                    for (int k = 0; k < 9; k++)
                        R[k] = c * I[k] + c1 * rrt[k] + s * _r_x_[k];

                    Convert(matR, dst);

                }
            }
            else if (src.Cols == 3 && src.Rows == 3)
            {
                double[] R = new double[9],
                         U = new double[9],
                         V = new double[9],
                         W = new double[3];
                double rx, ry, rz;
                CvMat matR = new CvMat(3, 3, MatrixType.F64C1, R);
                CvMat matU = new CvMat(3, 3, MatrixType.F64C1, U);
                CvMat matV = new CvMat(3, 3, MatrixType.F64C1, V);
                CvMat matW = new CvMat(3, 1, MatrixType.F64C1, W);
                double theta, s, c;
                int step = dst.Rows > 1 ? dst.Step / elem_size : 1;

                if ((dst.Rows != 1 || dst.Cols * MAT_CN(dst.Type) != 3) &&
                    (dst.Rows != 3 || dst.Cols != 1 || MAT_CN(dst.Type) != 1))
                    throw new ArgumentException("Output matrix must be 1x3 or 3x1");

                Convert(src, matR);
                if (!CheckArr(matR, CheckArrFlag.Range | CheckArrFlag.Quiet, -100, 100))
                {
                    Zero(dst);
                    return 0;
                }

                SVD(matR, matW, matU, matV, SVDFlag.ModifyA | SVDFlag.U_T | SVDFlag.V_T);
                GEMM(matU, matV, 1, null, 0, matR, GemmOperation.A_T);

                rx = R[7] - R[5];
                ry = R[2] - R[6];
                rz = R[3] - R[1];

                s = Math.Sqrt((rx * rx + ry * ry + rz * rz) * 0.25);
                c = (R[0] + R[4] + R[8] - 1) * 0.5;
                c = c > 1.0 ? 1.0 : c < -1.0 ? -1.0 : c;
                theta = Math.Acos(c);

                if (s < 1e-5)
                {
                    double t;

                    if (c > 0)
                        rx = ry = rz = 0;
                    else
                    {
                        t = (R[0] + 1) * 0.5;
                        rx = Math.Sqrt(Math.Max(t, 0.0));
                        t = (R[4] + 1) * 0.5;
                        ry = Math.Sqrt(Math.Max(t, 0.0)) * (R[1] < 0 ? -1.0 : 1.0);
                        t = (R[8] + 1) * 0.5;
                        rz = Math.Sqrt(Math.Max(t, 0.0)) * (R[2] < 0 ? -1.0 : 1.0);
                        if (Math.Abs(rx) < Math.Abs(ry) && Math.Abs(rx) < Math.Abs(rz) && (R[5] > 0) != (ry * rz > 0))
                            rz = -rz;
                        theta /= Math.Sqrt(rx * rx + ry * ry + rz * rz);
                        rx *= theta;
                        ry *= theta;
                        rz *= theta;
                    }
                }
                else
                {
                    double vth = 1 / (2 * s);

                    vth *= theta;
                    rx *= vth; ry *= vth; rz *= vth;
                }

                if (depth == CvConst.CV_32F)
                {
                    dst.DataSingle[0] = (float)rx;
                    dst.DataSingle[step] = (float)ry;
                    dst.DataSingle[step * 2] = (float)rz;
                }
                else
                {
                    dst.DataDouble[0] = rx;
                    dst.DataDouble[step] = ry;
                    dst.DataDouble[step * 2] = rz;
                }
            }

            return 1;
        }
        // ReSharper restore InconsistentNaming
        // ReSharper restore TooWideLocalVariableScope
        #endregion
        #endregion
        #region FindFace
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public static CvSeq<CvFaceData> FindFace(IplImage image, CvMemStorage storage)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (storage == null)
                throw new ArgumentNullException("storage");

            IntPtr ptr = CvInvoke.cvFindFace(image.CvPtr, storage.CvPtr);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvSeq<CvFaceData>(ptr);
        }
        #endregion
        #region FindFeatures
#if LANG_JP
        /// <summary>
        /// 最適ビン優先（Best-Bin-First）探索を用いて，与えられたベクトルのおおよその k 近傍値を求める
        /// </summary>
        /// <param name="tr">参照ベクトルに対するk-d木インデックスへのポインタ．</param>
        /// <param name="desc">（行）ベクトルの m × d 行列．これらのベクトルの近傍値を探索する．</param>
        /// <param name="results">一致したベクトルの行インデックス （cvCreateFeatureTreeに引数として渡される行列を参照する） の集合．m × kの行列．k 近傍より遠い場合は，その列には -1 が入る．</param>
        /// <param name="dist">k 近傍値までの距離のm × k 行列.</param>
#else
        /// <summary>
        /// Finds approximate k nearest neighbors of given vectors using best-bin-first search.
        /// </summary>
        /// <param name="tr">pointer to kd-tree index of reference vectors. </param>
        /// <param name="desc">m x d matrix of (row-)vectors to find the nearest neighbors of. </param>
        /// <param name="results">m x k set of row indices of matching vectors (referring to matrix passed to cvCreateFeatureTree). Contains -1 in some columns if fewer than k neighbors found. </param>
        /// <param name="dist">m x k matrix of distances to k nearest neighbors. </param>
#endif
        public static void FindFeatures(CvFeatureTree tr, CvMat desc, CvMat results, CvMat dist)
        {
            FindFeatures(tr, desc, results, dist, 2, 20);
        }
#if LANG_JP
        /// <summary>
        /// 最適ビン優先（Best-Bin-First）探索を用いて，与えられたベクトルのおおよその k 近傍値を求める
        /// </summary>
        /// <param name="tr">参照ベクトルに対するk-d木インデックスへのポインタ．</param>
        /// <param name="desc">（行）ベクトルの m × d 行列．これらのベクトルの近傍値を探索する．</param>
        /// <param name="results">一致したベクトルの行インデックス （cvCreateFeatureTreeに引数として渡される行列を参照する） の集合．m × kの行列．k 近傍より遠い場合は，その列には -1 が入る．</param>
        /// <param name="dist">k 近傍値までの距離のm × k 行列.</param>
        /// <param name="k">検出される近傍の数．</param>
#else
        /// <summary>
        /// Finds approximate k nearest neighbors of given vectors using best-bin-first search.
        /// </summary>
        /// <param name="tr">pointer to kd-tree index of reference vectors. </param>
        /// <param name="desc">m x d matrix of (row-)vectors to find the nearest neighbors of. </param>
        /// <param name="results">m x k set of row indices of matching vectors (referring to matrix passed to cvCreateFeatureTree). Contains -1 in some columns if fewer than k neighbors found. </param>
        /// <param name="dist">m x k matrix of distances to k nearest neighbors. </param>
        /// <param name="k">The number of neighbors to find. </param>
#endif
        public static void FindFeatures(CvFeatureTree tr, CvMat desc, CvMat results, CvMat dist, int k)
        {
            FindFeatures(tr, desc, results, dist, k, 20);
        }
#if LANG_JP
        /// <summary>
        /// 最適ビン優先（Best-Bin-First）探索を用いて，与えられたベクトルのおおよその k 近傍値を求める
        /// </summary>
        /// <param name="tr">参照ベクトルに対するk-d木インデックスへのポインタ．</param>
        /// <param name="desc">（行）ベクトルの m × d 行列．これらのベクトルの近傍値を探索する．</param>
        /// <param name="results">一致したベクトルの行インデックス （cvCreateFeatureTreeに引数として渡される行列を参照する） の集合．m × kの行列．k 近傍より遠い場合は，その列には -1 が入る．</param>
        /// <param name="dist">k 近傍値までの距離のm × k 行列.</param>
        /// <param name="k">検出される近傍の数．</param>
        /// <param name="emax">探索する葉の最大数．</param>
#else
        /// <summary>
        /// Finds approximate k nearest neighbors of given vectors using best-bin-first search.
        /// </summary>
        /// <param name="tr">pointer to kd-tree index of reference vectors. </param>
        /// <param name="desc">m x d matrix of (row-)vectors to find the nearest neighbors of. </param>
        /// <param name="results">m x k set of row indices of matching vectors (referring to matrix passed to cvCreateFeatureTree). Contains -1 in some columns if fewer than k neighbors found. </param>
        /// <param name="dist">m x k matrix of distances to k nearest neighbors. </param>
        /// <param name="k">The number of neighbors to find. </param>
        /// <param name="emax">The maximum number of leaves to visit. </param>
#endif
        public static void FindFeatures(CvFeatureTree tr, CvMat desc, CvMat results, CvMat dist, int k, int emax)
        {
            if (tr == null)
                throw new ArgumentNullException("tr");
            if (desc == null)
                throw new ArgumentNullException("desc");
            if (results == null)
                throw new ArgumentNullException("results");
            if (dist == null)
                throw new ArgumentNullException("dist");
            CvInvoke.cvFindFeatures(tr.CvPtr, desc.CvPtr, results.CvPtr, dist.CvPtr, k, emax);
        }
        #endregion
        #region FindFeaturesBoxed
#if LANG_JP
        /// <summary>
        /// 与えられたk-d木上で直交領域探索を行う．
        /// </summary>
        /// <param name="tr">参照ベクトルに対するk-d木インデックスへのポインタ．</param>
        /// <param name="boundsMin">各次元の最小値を与える 1×d あるいは d×1 のベクトル（CV_32FC1 or CV_64FC1）</param>
        /// <param name="boundsMax">各次元の最大値を与える 1×d あるいは d×1 のベクトル（CV_32FC1 or CV_64FC1）</param>
        /// <param name="result">出力行インデックス（cvCreateFeatureTreeに引数として渡される行列を参照する） の 1×m あるいは m×1 のベクトル（CV_32SC1）</param>
        /// <returns>求められたベクトル数</returns>
#else
        /// <summary>
        /// Performs orthogonal range seaching on the given kd-tree.
        /// </summary>
        /// <param name="tr">Pointer to kd-tree index of reference vectors. </param>
        /// <param name="boundsMin">1 x d or d x 1 vector (CV_32FC1 or CV_64FC1) giving minimum value for each dimension. </param>
        /// <param name="boundsMax">1 x d or d x 1 vector (CV_32FC1 or CV_64FC1) giving maximum value for each dimension. </param>
        /// <param name="result">1 x m or m x 1 vector (CV_32SC1) to contain output row indices (referring to matrix passed to cvCreateFeatureTree). </param>
        /// <returns>the number of such vectors found. </returns>
#endif
        public static int FindFeaturesBoxed(CvFeatureTree tr, CvMat boundsMin, CvMat boundsMax, CvMat result)
        {
            if (tr == null)
                throw new ArgumentNullException("tr");
            if (boundsMin == null)
                throw new ArgumentNullException("boundsMin");
            if (boundsMax == null)
                throw new ArgumentNullException("boundsMax");
            if (result == null)
                throw new ArgumentNullException("result");
            return CvInvoke.cvFindFeaturesBoxed(tr.CvPtr, boundsMin.CvPtr, boundsMax.CvPtr, result.CvPtr);
        }
        #endregion
        #region FindFundamentalMat
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の点対応から基礎行列（F行列）を計算する
        /// </summary>
        /// <param name="points1">大きさが2xN, Nx2, 3xN，または Nx3 の1枚目の画像上の点の配列 (N は点の数)．マルチチャンネルで大きさ 1xN，または Nx1 の配 列も使用可能である． 点の座標は浮動小数点型で表される（単精度または倍精度）．</param>
        /// <param name="points2">2枚目の画像上の点の配列で point1とフォーマットやサイズは同じ．</param>
        /// <param name="fundamentalMatrix">出力される基礎行列．サイズは 3x3， または 9x3（7-point methodは3つの行列を返す）．</param>
        /// <returns>求めた基礎行列の数（1 または 3）．もし行列が求まらないときは0．</returns>
#else
        /// <summary>
        /// Calculates fundamental matrix from corresponding points in two images
        /// </summary>
        /// <param name="points1">Array of the first image points of 2xN, Nx2, 3xN or Nx3 size (where N is number of points). Multi-channel 1xN or Nx1 array is also acceptable. The point coordinates should be floating-point (single or double precision) </param>
        /// <param name="points2">Array of the second image points of the same size and format as points1</param>
        /// <param name="fundamentalMatrix">The output fundamental matrix or matrices. The size should be 3x3 or 9x3 (7-point method may return up to 3 matrices). </param>
        /// <returns></returns>
#endif
        public static int FindFundamentalMat(CvMat points1, CvMat points2, CvMat fundamentalMatrix)
        {
            return FindFundamentalMat(points1, points2, fundamentalMatrix, FundamentalMatMethod.Ransac, 3.0, 0.99, null);
        }
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の点対応から基礎行列（F行列）を計算する
        /// </summary>
        /// <param name="points1">大きさが2xN, Nx2, 3xN，または Nx3 の1枚目の画像上の点の配列 (N は点の数)．マルチチャンネルで大きさ 1xN，または Nx1 の配 列も使用可能である． 点の座標は浮動小数点型で表される（単精度または倍精度）．</param>
        /// <param name="points2">2枚目の画像上の点の配列で point1とフォーマットやサイズは同じ．</param>
        /// <param name="fundamentalMatrix">出力される基礎行列．サイズは 3x3， または 9x3（7-point methodは3つの行列を返す）．</param>
        /// <param name="method">基礎行列の計算手法</param>
        /// <returns>求めた基礎行列の数（1 または 3）．もし行列が求まらないときは0．</returns>
#else
        /// <summary>
        /// Calculates fundamental matrix from corresponding points in two images
        /// </summary>
        /// <param name="points1">Array of the first image points of 2xN, Nx2, 3xN or Nx3 size (where N is number of points). Multi-channel 1xN or Nx1 array is also acceptable. The point coordinates should be floating-point (single or double precision) </param>
        /// <param name="points2">Array of the second image points of the same size and format as points1</param>
        /// <param name="fundamentalMatrix">The output fundamental matrix or matrices. The size should be 3x3 or 9x3 (7-point method may return up to 3 matrices). </param>
        /// <param name="method">Method for computing the fundamental matrix </param>
        /// <returns></returns>
#endif
        public static int FindFundamentalMat(CvMat points1, CvMat points2, CvMat fundamentalMatrix, FundamentalMatMethod method)
        {
            return FindFundamentalMat(points1, points2, fundamentalMatrix, method, 3.0, 0.99, null);
        }
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の点対応から基礎行列（F行列）を計算する
        /// </summary>
        /// <param name="points1">大きさが2xN, Nx2, 3xN，または Nx3 の1枚目の画像上の点の配列 (N は点の数)．マルチチャンネルで大きさ 1xN，または Nx1 の配 列も使用可能である． 点の座標は浮動小数点型で表される（単精度または倍精度）．</param>
        /// <param name="points2">2枚目の画像上の点の配列で point1とフォーマットやサイズは同じ．</param>
        /// <param name="fundamentalMatrix">出力される基礎行列．サイズは 3x3， または 9x3（7-point methodは3つの行列を返す）．</param>
        /// <param name="method">基礎行列の計算手法</param>
        /// <param name="param1">RANSAC メソッドのときにのみ使用されるパラメータ．点からエピポーラ線までの最大距離（その距離を超えるものは外れ値であると判断し，それらを最終的な基礎行列の計算に使用しない）をピクセル単位で示す． 通常は 1~3 の値にセットされる． </param>
        /// <param name="param2">RANSAC または LMedSメソッドのときにのみ使用されるパラメータ． F行列の推定精度の信頼レベルを示す．</param>
        /// <returns>求めた基礎行列の数（1 または 3）．もし行列が求まらないときは0．</returns>
#else
        /// <summary>
        /// Calculates fundamental matrix from corresponding points in two images
        /// </summary>
        /// <param name="points1">Array of the first image points of 2xN, Nx2, 3xN or Nx3 size (where N is number of points). Multi-channel 1xN or Nx1 array is also acceptable. The point coordinates should be floating-point (single or double precision) </param>
        /// <param name="points2">Array of the second image points of the same size and format as points1</param>
        /// <param name="fundamentalMatrix">The output fundamental matrix or matrices. The size should be 3x3 or 9x3 (7-point method may return up to 3 matrices). </param>
        /// <param name="method">Method for computing the fundamental matrix </param>
        /// <param name="param1">The parameter is used for RANSAC method only. It is the maximum distance from point to epipolar line in pixels, beyond which the point is considered an outlier and is not used for computing the final fundamental matrix. Usually it is set somewhere from 1 to 3. </param>
        /// <param name="param2">The parameter is used for RANSAC or LMedS methods only. It denotes the desirable level of confidence of the fundamental matrix estimate. </param>
        /// <returns></returns>
#endif
        public static int FindFundamentalMat(CvMat points1, CvMat points2, CvMat fundamentalMatrix, FundamentalMatMethod method, double param1, double param2)
        {
            return FindFundamentalMat(points1, points2, fundamentalMatrix, method, param1, param2, null);
        }
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の点対応から基礎行列（F行列）を計算する
        /// </summary>
        /// <param name="points1">大きさが2xN, Nx2, 3xN，または Nx3 の1枚目の画像上の点の配列 (N は点の数)．マルチチャンネルで大きさ 1xN，または Nx1 の配 列も使用可能である． 点の座標は浮動小数点型で表される（単精度または倍精度）．</param>
        /// <param name="points2">2枚目の画像上の点の配列で point1とフォーマットやサイズは同じ．</param>
        /// <param name="fundamentalMatrix">出力される基礎行列．サイズは 3x3， または 9x3（7-point methodは3つの行列を返す）．</param>
        /// <param name="method">基礎行列の計算手法</param>
        /// <param name="param1">RANSAC メソッドのときにのみ使用されるパラメータ．点からエピポーラ線までの最大距離（その距離を超えるものは外れ値であると判断し，それらを最終的な基礎行列の計算に使用しない）をピクセル単位で示す． 通常は 1~3 の値にセットされる． </param>
        /// <param name="param2">RANSAC または LMedSメソッドのときにのみ使用されるパラメータ． F行列の推定精度の信頼レベルを示す．</param>
        /// <param name="status">N個の要素からなる出力配列． 各要素は，アウトライア（外れ値）に対しては 0，「インライア」，つまり推定されたエピポーラ幾何に良く適合する値， に対しては 1 にセットされる． この配列は RANSAC または LMedS のときのみ計算される．他の手法では，すべて 1 にセットされる.</param>
        /// <returns>求めた基礎行列の数（1 または 3）．もし行列が求まらないときは0．</returns>
#else
        /// <summary>
        /// Calculates fundamental matrix from corresponding points in two images
        /// </summary>
        /// <param name="points1">Array of the first image points of 2xN, Nx2, 3xN or Nx3 size (where N is number of points). Multi-channel 1xN or Nx1 array is also acceptable. The point coordinates should be floating-point (single or double precision) </param>
        /// <param name="points2">Array of the second image points of the same size and format as points1</param>
        /// <param name="fundamentalMatrix">The output fundamental matrix or matrices. The size should be 3x3 or 9x3 (7-point method may return up to 3 matrices). </param>
        /// <param name="method">Method for computing the fundamental matrix </param>
        /// <param name="param1">The parameter is used for RANSAC method only. It is the maximum distance from point to epipolar line in pixels, beyond which the point is considered an outlier and is not used for computing the final fundamental matrix. Usually it is set somewhere from 1 to 3. </param>
        /// <param name="param2">The parameter is used for RANSAC or LMedS methods only. It denotes the desirable level of confidence of the fundamental matrix estimate. </param>
        /// <param name="status">The optional output array of N elements, every element of which is set to 0 for outliers and to 1 for the "inliers", i.e. points that comply well with the estimated epipolar geometry. The array is computed only in RANSAC and LMedS methods. For other methods it is set to all 1’s. </param>
        /// <returns></returns>
#endif
        public static int FindFundamentalMat(CvMat points1, CvMat points2, CvMat fundamentalMatrix, FundamentalMatMethod method, double param1, double param2, CvMat status)
        {
            if (points1 == null)
                throw new ArgumentNullException("points1");
            if (points2 == null)
                throw new ArgumentNullException("points2");
            if (fundamentalMatrix == null)
                throw new ArgumentNullException("fundamentalMatrix");
            IntPtr statusPtr = (status == null) ? IntPtr.Zero : status.CvPtr;
            return CvInvoke.cvFindFundamentalMat(points1.CvPtr, points2.CvPtr, fundamentalMatrix.CvPtr, method, param1, param2, statusPtr);
        }
        #endregion
        #region FindGraphEdge
#if LANG_JP
        /// <summary>
        /// グラフから辺を検出する（インデックス指定）
        /// </summary>
        /// <param name="graph">グラフ． </param>
        /// <param name="startIdx">辺の始点を示す頂点のインデックス． </param>
        /// <param name="endIdx">辺の終点を示す頂点のインデックス．無向グラフの場合，順序はどちらでもよい． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds edge in graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="startIdx">Index of the starting vertex of the edge. </param>
        /// <param name="endIdx">Index of the ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <returns>The function cvFindGraphEdge finds the graph edge connecting two specified vertices and returns pointer to it or NULL if the edge does not exists.</returns>
#endif
        public static CvGraphEdge FindGraphEdge(CvGraph graph, int startIdx, int endIdx)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            IntPtr result = CvInvoke.cvFindGraphEdge(graph.CvPtr, startIdx, endIdx);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvGraphEdge(result); 
        }
#if LANG_JP
        /// <summary>
        /// グラフから辺を検出する（インデックス指定）
        /// </summary>
        /// <param name="graph">グラフ． </param>
        /// <param name="startIdx">辺の始点を示す頂点のインデックス． </param>
        /// <param name="endIdx">辺の終点を示す頂点のインデックス．無向グラフの場合，順序はどちらでもよい． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds edge in graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="startIdx">Index of the starting vertex of the edge. </param>
        /// <param name="endIdx">Index of the ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <returns>The function cvFindGraphEdge finds the graph edge connecting two specified vertices and returns pointer to it or NULL if the edge does not exists.</returns>
#endif
        public static CvGraphEdge GraphFindEdge(CvGraph graph, int startIdx, int endIdx)
        {
            return FindGraphEdge(graph, startIdx, endIdx);
        }
        #endregion
        #region FindGraphEdgeByPtr
#if LANG_JP
        /// <summary>
        /// グラフから辺を検出する（ポインタ指定）
        /// </summary>
        /// <param name="graph">グラフ． </param>
        /// <param name="startVtx">辺の始点を示す頂点へのポインタ． </param>
        /// <param name="endVtx">辺の終点を示す頂点へのポインタ．無向グラフの場合，順序はどちらでもよい． </param>
        /// <returns>指定した二つの頂点を接続する辺</returns>
#else
        /// <summary>
        /// Finds edge in graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="startVtx">Starting vertex of the edge. </param>
        /// <param name="endVtx">Ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <returns>The function cvFindGraphEdge finds the graph edge connecting two specified vertices and returns pointer to it or NULL if the edge does not exists.</returns>
#endif
        public static CvGraphEdge FindGraphEdgeByPtr(CvGraph graph, CvGraphVtx startVtx, CvGraphVtx endVtx)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");
            if (startVtx == null)
                throw new ArgumentNullException("startVtx");
            if (endVtx == null)
                throw new ArgumentNullException("endVtx");
            
            IntPtr result = CvInvoke.cvFindGraphEdgeByPtr(graph.CvPtr, startVtx.CvPtr, endVtx.CvPtr);
            if (result == IntPtr.Zero) 
                return null; 
            else 
                return new CvGraphEdge(result); 
        }
#if LANG_JP
        /// <summary>
        /// グラフから辺を検出する（ポインタ指定）
        /// </summary>
        /// <param name="graph">グラフ． </param>
        /// <param name="startVtx">辺の始点を示す頂点へのポインタ． </param>
        /// <param name="endVtx">辺の終点を示す頂点へのポインタ．無向グラフの場合，順序はどちらでもよい． </param>
        /// <returns>指定した二つの頂点を接続する辺</returns>
#else
        /// <summary>
        /// Finds edge in graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="startVtx">Starting vertex of the edge. </param>
        /// <param name="endVtx">Ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <returns>The function cvFindGraphEdge finds the graph edge connecting two specified vertices and returns pointer to it or NULL if the edge does not exists.</returns>
#endif
        public static CvGraphEdge GraphFindEdgeByPtr(CvGraph graph, CvGraphVtx startVtx, CvGraphVtx endVtx)
        {
            return FindGraphEdgeByPtr(graph, startVtx, endVtx);
        }
        #endregion
        #region FindHomography
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の射影変換を求める
        /// </summary>
        /// <param name="srcPoints">1枚目の画像上の座標． 2xN，Nx2，3xN または Nx3の配列 （後ろ二つは同次座標系表記である）．ここで N は点の数．</param>
        /// <param name="dstPoints">2枚目の画像上の座標． 2xN，Nx2，3xN または Nx3の配列 （後ろ二つは同次座標系表記である）．</param>
        /// <param name="homography">出力される3x3ホモグラフィ行列（平面射影変換行列）． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds perspective transformation between two planes
        /// </summary>
        /// <param name="srcPoints">Point coordinates in the original plane, 2xN, Nx2, 3xN or Nx3 array (the latter two are for representation in homogenious coordinates), where N is the number of points. </param>
        /// <param name="dstPoints">Point coordinates in the destination plane, 2xN, Nx2, 3xN or Nx3 array (the latter two are for representation in homogenious coordinates) </param>
        /// <param name="homography">Output 3x3 homography matrix. </param>
        /// <returns></returns>
#endif
        public static int FindHomography(CvMat srcPoints, CvMat dstPoints, CvMat homography)
        {
            return FindHomography(srcPoints, dstPoints, homography, HomographyMethod.Zero, 0, null);
        }
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の射影変換を求める
        /// </summary>
        /// <param name="srcPoints">1枚目の画像上の座標． 2xN，Nx2，3xN または Nx3の配列 （後ろ二つは同次座標系表記である）．ここで N は点の数．</param>
        /// <param name="dstPoints">2枚目の画像上の座標． 2xN，Nx2，3xN または Nx3の配列 （後ろ二つは同次座標系表記である）．</param>
        /// <param name="homography">出力される3x3ホモグラフィ行列（平面射影変換行列）． </param>
        /// <param name="method">ホモグラフィ行列を計算するための手法</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds perspective transformation between two planes
        /// </summary>
        /// <param name="srcPoints">Point coordinates in the original plane, 2xN, Nx2, 3xN or Nx3 array (the latter two are for representation in homogenious coordinates), where N is the number of points. </param>
        /// <param name="dstPoints">Point coordinates in the destination plane, 2xN, Nx2, 3xN or Nx3 array (the latter two are for representation in homogenious coordinates) </param>
        /// <param name="homography">Output 3x3 homography matrix. </param>
        /// <param name="method"></param>
        /// <returns></returns>
#endif
        public static int FindHomography(CvMat srcPoints, CvMat dstPoints, CvMat homography, HomographyMethod method)
        {
            return FindHomography(srcPoints, dstPoints, homography, method, 0, null);
        }
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の射影変換を求める
        /// </summary>
        /// <param name="srcPoints">1枚目の画像上の座標． 2xN，Nx2，3xN または Nx3の配列 （後ろ二つは同次座標系表記である）．ここで N は点の数．</param>
        /// <param name="dstPoints">2枚目の画像上の座標． 2xN，Nx2，3xN または Nx3の配列 （後ろ二つは同次座標系表記である）．</param>
        /// <param name="homography">出力される3x3ホモグラフィ行列（平面射影変換行列）． </param>
        /// <param name="method">ホモグラフィ行列を計算するための手法</param>
        /// <param name="ransacReprojThreshold">点のペアをインライア値として扱うために許容される，逆投影誤差の最大値．このパラメータは，CV_RANSAC が指定された場合にのみ利用される．例えば，dst_points がピクセル精度のピクセル座標である場合，このパラメータは，おおよそ 1〜3 にセットされるのが正しい． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds perspective transformation between two planes
        /// </summary>
        /// <param name="srcPoints">Point coordinates in the original plane, 2xN, Nx2, 3xN or Nx3 array (the latter two are for representation in homogenious coordinates), where N is the number of points. </param>
        /// <param name="dstPoints">Point coordinates in the destination plane, 2xN, Nx2, 3xN or Nx3 array (the latter two are for representation in homogenious coordinates) </param>
        /// <param name="homography">Output 3x3 homography matrix. </param>
        /// <param name="method"></param>
        /// <param name="ransacReprojThreshold"></param>
        /// <returns></returns>
#endif
        public static int FindHomography(CvMat srcPoints, CvMat dstPoints, CvMat homography, HomographyMethod method, double ransacReprojThreshold)
        {
            return FindHomography(srcPoints, dstPoints, homography, method, ransacReprojThreshold, null);
        }
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の射影変換を求める
        /// </summary>
        /// <param name="srcPoints">1枚目の画像上の座標． 2xN，Nx2，3xN または Nx3の配列 （後ろ二つは同次座標系表記である）．ここで N は点の数．</param>
        /// <param name="dstPoints">2枚目の画像上の座標． 2xN，Nx2，3xN または Nx3の配列 （後ろ二つは同次座標系表記である）．</param>
        /// <param name="homography">出力される3x3ホモグラフィ行列（平面射影変換行列）． </param>
        /// <param name="method">ホモグラフィ行列を計算するための手法</param>
        /// <param name="ransacReprojThreshold">点のペアをインライア値として扱うために許容される，逆投影誤差の最大値．このパラメータは，CV_RANSAC が指定された場合にのみ利用される．例えば，dst_points がピクセル精度のピクセル座標である場合，このパラメータは，おおよそ 1〜3 にセットされるのが正しい． </param>
        /// <param name="mask">オプション：ロバスト推定（CV_RANSAC， CV_LMEDS）で利用される出力マスク． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds perspective transformation between two planes
        /// </summary>
        /// <param name="srcPoints">Point coordinates in the original plane, 2xN, Nx2, 3xN or Nx3 array (the latter two are for representation in homogenious coordinates), where N is the number of points. </param>
        /// <param name="dstPoints">Point coordinates in the destination plane, 2xN, Nx2, 3xN or Nx3 array (the latter two are for representation in homogenious coordinates) </param>
        /// <param name="homography">Output 3x3 homography matrix. </param>
        /// <param name="method"></param>
        /// <param name="ransacReprojThreshold"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
#endif
        public static int FindHomography(CvMat srcPoints, CvMat dstPoints, CvMat homography, HomographyMethod method, double ransacReprojThreshold, CvMat mask)
        {
            if (srcPoints == null)
                throw new ArgumentNullException("srcPoints");
            if (dstPoints == null)
                throw new ArgumentNullException("dstPoints");
            if (homography == null)
                throw new ArgumentNullException("homography");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            return CvInvoke.cvFindHomography(srcPoints.CvPtr, dstPoints.CvPtr, homography.CvPtr, method, ransacReprojThreshold, maskPtr);
        }
        #endregion
        #region FindNearestPoint2D
#if LANG_JP
        /// <summary>
        /// 与えられた点に最も近い細分割の頂点を求める. 入力点を細分割内に配置するもう一つの関数である．
        /// この関数は入力された点に最も近い頂点を求める． 
        /// </summary>
        /// <param name="subdiv">ドロネー，または他の細分割</param>
        /// <param name="pt">入力点</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds the closest subdivision vertex to given point
        /// </summary>
        /// <param name="subdiv">Delaunay or another subdivision. </param>
        /// <param name="pt">Input point. </param>
        /// <returns></returns>
#endif
        public static CvSubdiv2DPoint FindNearestPoint2D(CvSubdiv2D subdiv, CvPoint2D32f pt)
        {
            if (subdiv == null)
            {
                throw new ArgumentNullException("subdiv");
            }
            IntPtr result = CvInvoke.cvFindNearestPoint2D(subdiv.CvPtr, pt);
            return new CvSubdiv2DPoint(result);
        }
        #endregion
        #region FindNextContour
#if LANG_JP
        /// <summary>
        /// 画像中の次の輪郭を検索する
        /// </summary>
        /// <param name="scanner">関数cvStartFindContoursで初期化された輪郭スキャナ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds next contour in the image
        /// </summary>
        /// <param name="scanner">Contour scanner initialized by The function cvStartFindContours </param>
#endif
        public static CvSeq<CvPoint> FindNextContour(CvContourScanner scanner)
        {
            if (scanner == null)
            {
                throw new ArgumentNullException("scanner");
            }
            IntPtr result = CvInvoke.cvFindNextContour(scanner.CvPtr);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSeq<CvPoint>(result);
        }
        #endregion
        #region FindStereoCorrespondence
#if LANG_JP
        /// <summary>
        /// ステレオペア間の視差を計算する
        /// </summary>
        /// <param name="leftImage">ステレオペアの左画像．8ビット，グレースケールの（傾きや位置などが）修正された画像．</param>
        /// <param name="rightImage">ステレオペアの右画像．8ビット，グレースケールの修正された画像．</param>
        /// <param name="mode">視差を計算するためのアルゴリズム（現在は，CV_DISPARITY_BIRCHFIELD のみをサポートしている）．</param>
        /// <param name="depthImage">結果のデプス画像．視差を表すようにスケーリングされた，8ビット，グレースケール画像． つまり，ゼロ視差（これは，カメラから非常に遠い場所の点にあたる）は 0 にマッピングされ，最大視差は 255 にマッピングされる．</param>
        /// <param name="maxDisparity">取りうる最大視差．オブジェクトがカメラに近ければ近い程，ここには大きな値が指定されるべきである． ただし，大きすぎる値は，処理速度を極端に低下させる．</param>
#else
        /// <summary>
        /// Calculates disparity for stereo-pair
        /// </summary>
        /// <param name="leftImage">Left image of stereo pair, rectified grayscale 8-bit image </param>
        /// <param name="rightImage">Right image of stereo pair, rectified grayscale 8-bit image </param>
        /// <param name="mode">Algorithm used to find a disparity (now only CV_DISPARITY_BIRCHFIELD is supported) </param>
        /// <param name="depthImage">Destination depth image, grayscale 8-bit image that codes the scaled disparity, so that the zero disparity (corresponding to the points that are very far from the cameras) maps to 0, maximum disparity maps to 255. </param>
        /// <param name="maxDisparity">Maximum possible disparity. The closer the objects to the cameras, the larger value should be specified here. Too big values slow down the process significantly. </param>
#endif
        public static void FindStereoCorrespondence(CvArr leftImage, CvArr rightImage, DisparityMode mode, CvArr depthImage, int maxDisparity)
        {
            const int p = CvConst.CV_UNDEF_SC_PARAM;
            FindStereoCorrespondence(leftImage, rightImage, mode, depthImage, maxDisparity, p, p, p, p, p);
        }
#if LANG_JP
        /// <summary>
        /// ステレオペア間の視差を計算する
        /// </summary>
        /// <param name="leftImage">ステレオペアの左画像．8ビット，グレースケールの（傾きや位置などが）修正された画像．</param>
        /// <param name="rightImage">ステレオペアの右画像．8ビット，グレースケールの修正された画像．</param>
        /// <param name="mode">視差を計算するためのアルゴリズム（現在は，CV_DISPARITY_BIRCHFIELD のみをサポートしている）．</param>
        /// <param name="depthImage">結果のデプス画像．視差を表すようにスケーリングされた，8ビット，グレースケール画像． つまり，ゼロ視差（これは，カメラから非常に遠い場所の点にあたる）は 0 にマッピングされ，最大視差は 255 にマッピングされる．</param>
        /// <param name="maxDisparity">取りうる最大視差．オブジェクトがカメラに近ければ近い程，ここには大きな値が指定されるべきである． ただし，大きすぎる値は，処理速度を極端に低下させる．</param>
        /// <param name="param1">アルゴリズムのパラメータ. オクルージョンペナルティ定数 など</param>
        /// <param name="param2">アルゴリズムのパラメータ. 一致報酬 など</param>
        /// <param name="param3">アルゴリズムのパラメータ. 高信頼度の領域（param3 以上の信頼性を持つ，隣接するピクセルの組）の定義 など</param>
        /// <param name="param4">アルゴリズムのパラメータ. 中信頼度の領域の定義 など</param>
        /// <param name="param5">アルゴリズムのパラメータ. 低信頼度の領域の定義 など</param>
#else
        /// <summary>
        /// Calculates disparity for stereo-pair
        /// </summary>
        /// <param name="leftImage">Left image of stereo pair, rectified grayscale 8-bit image </param>
        /// <param name="rightImage">Right image of stereo pair, rectified grayscale 8-bit image </param>
        /// <param name="mode">Algorithm used to find a disparity (now only CV_DISPARITY_BIRCHFIELD is supported) </param>
        /// <param name="depthImage">Destination depth image, grayscale 8-bit image that codes the scaled disparity, so that the zero disparity (corresponding to the points that are very far from the cameras) maps to 0, maximum disparity maps to 255. </param>
        /// <param name="maxDisparity">Maximum possible disparity. The closer the objects to the cameras, the larger value should be specified here. Too big values slow down the process significantly. </param>
        /// <param name="param1">Constant occlusion penalty, default=25</param>
        /// <param name="param2">Constant match reward, default=5</param>
        /// <param name="param3">Defines a highly reliable region (set of contiguous pixels whose reliability is at least param3), default=12</param>
        /// <param name="param4">Defines a moderately reliable region, default=15</param>
        /// <param name="param5">Defines a slightly reliable region, default=25</param>
#endif
        public static void FindStereoCorrespondence(CvArr leftImage, CvArr rightImage, DisparityMode mode, CvArr depthImage, int maxDisparity, double param1, double param2, double param3, double param4, double param5)
        {
            if (leftImage == null)
                throw new ArgumentNullException("leftImage");
            if (rightImage == null)
                throw new ArgumentNullException("rightImage");
            if (depthImage == null)
                throw new ArgumentNullException("depthImage");
            CvInvoke.cvFindStereoCorrespondence(leftImage.CvPtr, rightImage.CvPtr, mode, depthImage.CvPtr, maxDisparity, param1, param2, param3, param4, param5);
        }
        #endregion
        #region FindStereoCorrespondenceBM
        // ReSharper disable InconsistentNaming
#if LANG_JP
        /// <summary>
        /// ブロックマッチングアルゴリズムを用いて視差画像を計算する
        /// </summary>
        /// <param name="left">左画像．シングルチャンネル，8ビット．</param>
        /// <param name="right">右画像．左画像と同じサイズ，同じ種類．</param>
        /// <param name="disparity">出力の視差配列．シングルチャンネル，16ビット，符号有り整数，入力画像と同サイズ．各要素は，計算された視差であり，16倍されて整数値にまるめられる．</param>
        /// <param name="state">ステレオマッチング構造体．</param>
#else
        /// <summary>
        /// Computes the disparity map using block matching algorithm
        /// </summary>
        /// <param name="left">The left single-channel, 8-bit image. </param>
        /// <param name="right">The right image of the same size and the same type. </param>
        /// <param name="disparity">The output single-channel 16-bit signed disparity map of the same size as input images. Its elements will be the computed disparities, multiplied by 16 and rounded to integer's. </param>
        /// <param name="state">Stereo correspondence structure. </param>
#endif
        public static void FindStereoCorrespondenceBM(CvArr left, CvArr right, CvArr disparity, CvStereoBMState state)
        {
            if (left == null)
                throw new ArgumentNullException("left");
            if (right == null)
                throw new ArgumentNullException("right");
            if (disparity == null)
                throw new ArgumentNullException("disparity");
            if (state == null)
                throw new ArgumentNullException("state");
            CvInvoke.cvFindStereoCorrespondenceBM(left.CvPtr, right.CvPtr, disparity.CvPtr, state.CvPtr);
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region FindStereoCorrespondenceGC
        // ReSharper disable InconsistentNaming
#if LANG_JP
        /// <summary>
        /// グラフカットに基づくアルゴリズムにより視差画像を計算する
        /// </summary>
        /// <param name="left">左画像．シングルチャンネル，8ビット．</param>
        /// <param name="right">右画像．左画像と同じサイズ，同じ種類．</param>
        /// <param name="dispLeft">出力オプション：シングルチャンネル，16ビット，符号有り整数．入力画像と同じサイズの左視差画像． </param>
        /// <param name="dispRight">出力オプション：シングルチャンネル，16ビット，符号有り整数．入力画像と同じサイズの右視差画像． </param>
        /// <param name="state">ステレオマッチング構造体．</param>
#else
        /// <summary>
        /// Computes the disparity map using graph cut-based algorithm
        /// </summary>
        /// <param name="left">The left single-channel, 8-bit image. </param>
        /// <param name="right">The right image of the same size and the same type. </param>
        /// <param name="dispLeft">The optional output single-channel 16-bit signed left disparity map of the same size as input images. </param>
        /// <param name="dispRight">The optional output single-channel 16-bit signed right disparity map of the same size as input images. </param>
        /// <param name="state">Stereo correspondence structure. </param>
#endif
        public static void FindStereoCorrespondenceGC(CvArr left, CvArr right, CvArr dispLeft, CvArr dispRight, CvStereoGCState state)
        {
            FindStereoCorrespondenceGC(left, right, dispLeft, dispRight, state, false);
        }
#if LANG_JP
        /// <summary>
        /// グラフカットに基づくアルゴリズムにより視差画像を計算する
        /// </summary>
        /// <param name="left">左画像．シングルチャンネル，8ビット．</param>
        /// <param name="right">右画像．左画像と同じサイズ，同じ種類．</param>
        /// <param name="dispLeft">出力オプション：シングルチャンネル，16ビット，符号有り整数．入力画像と同じサイズの左視差画像． </param>
        /// <param name="dispRight">出力オプション：シングルチャンネル，16ビット，符号有り整数．入力画像と同じサイズの右視差画像． </param>
        /// <param name="state">ステレオマッチング構造体．</param>
        /// <param name="useDisparityGuess">このパラメータが 0 でない場合， あらかじめ定義された視差画像を用いて計算が開始される．つまり， dispLeft と dispRight が共に，妥当な視差画像である必要がある． そうでない場合は，（すべてのピクセルがオクルージョンとなっている）空の視差画像から開始される．</param>
#else
        /// <summary>
        /// Computes the disparity map using graph cut-based algorithm
        /// </summary>
        /// <param name="left">The left single-channel, 8-bit image. </param>
        /// <param name="right">The right image of the same size and the same type. </param>
        /// <param name="dispLeft">The optional output single-channel 16-bit signed left disparity map of the same size as input images. </param>
        /// <param name="dispRight">The optional output single-channel 16-bit signed right disparity map of the same size as input images. </param>
        /// <param name="state">Stereo correspondence structure. </param>
        /// <param name="useDisparityGuess">If the parameter is not zero, the algorithm will start with pre-defined disparity maps. Both dispLeft and dispRight should be valid disparity maps. Otherwise, the function starts with blank disparity maps (all pixels are marked as occlusions). </param>
#endif
        public static void FindStereoCorrespondenceGC(CvArr left, CvArr right, CvArr dispLeft, CvArr dispRight, CvStereoGCState state, bool useDisparityGuess)
        {
            if (left == null)
                throw new ArgumentNullException("left");
            if (right == null)
                throw new ArgumentNullException("right");
            if (dispLeft == null)
                throw new ArgumentNullException("dispLeft");
            if (dispRight == null)
                throw new ArgumentNullException("dispRight");
            if (state == null)
                throw new ArgumentNullException("state");
            CvInvoke.cvFindStereoCorrespondenceGC(left.CvPtr, right.CvPtr, dispLeft.CvPtr, dispRight.CvPtr, state.CvPtr, useDisparityGuess);
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region FindType
#if LANG_JP
        /// <summary>
        /// 名前から型を見つける
        /// </summary>
        /// <param name="typeName">型の名前</param>
        /// <returns>登録された型．nullの場合，指定した名前の型は存在しない．</returns>
#else
        /// <summary>
        /// Finds type by its name
        /// </summary>
        /// <param name="typeName">Type name. </param>
        /// <returns></returns>
#endif
        public static CvTypeInfo FindType(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                throw new ArgumentNullException("typeName");
            }
            IntPtr result = CvInvoke.cvFindType(typeName);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvTypeInfo(result);
        }
        #endregion
        #region FirstType
#if LANG_JP
        /// <summary>
        /// 型リストの先頭を返す
        /// </summary>
        /// <returns>登録されている型のリストの先頭のもの</returns>
#else
        /// <summary>
        /// Returns the beginning of type list
        /// </summary>
        /// <returns>the first type of the list of registered types. </returns>
#endif
        public static CvTypeInfo FirstType()
        {
            IntPtr result = CvInvoke.cvFirstType();
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvTypeInfo(result);
        }
        #endregion
        #region FitEllipse2
#if LANG_JP
        /// <summary>
        /// 2次元の点列に楕円をフィッティングする
        /// </summary>
        /// <param name="points">点のシーケンス，または配列</param>
        /// <returns>2次元の点列にフィットする最良の楕円</returns>
#else
        /// <summary>
        /// Fits ellipse to set of 2D points
        /// </summary>
        /// <param name="points">Array or sequence of the points.</param>
        /// <returns>ellipse that fits best (in least-squares sense) to a set of 2D points.</returns>
#endif
        public static CvBox2D FitEllipse2(CvArr points)
        {
            return CvInvoke.cvFitEllipse2(points.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 2次元の点列に楕円をフィッティングする
        /// </summary>
        /// <param name="points">点の配列</param>
        /// <returns>2次元の点列にフィットする最良の楕円</returns>
#else
        /// <summary>
        /// Fits ellipse to set of 2D points
        /// </summary>
        /// <param name="points">Array of the points.</param>
        /// <returns>ellipse that fits best (in least-squares sense) to a set of 2D points.</returns>
#endif
        public static CvBox2D FitEllipse2(IEnumerable<CvPoint2D32f> points)
        {
            if(points == null)
                throw new ArgumentNullException("points");

            CvPoint2D32f[] pointsArray = ToArray(points); // points.ToArray(); in .NET4
            using (CvMat pointsMat = new CvMat(pointsArray.Length, 1, MatrixType.F32C2, pointsArray, true))
            {
                return CvInvoke.cvFitEllipse2(pointsMat.CvPtr);
            }
        }
        #endregion
        #region FitLine
#if LANG_JP
        /// <summary>
        /// 2次元または3次元の点列に線をフィッティングする
        /// </summary>
        /// <param name="points">32ビット整数型または浮動小数点型の2次元または3次元の点の配列，またはシーケンス．</param>
        /// <param name="distType">フィッティングに使われる距離．</param>
        /// <param name="param">それぞれの距離関数における数値パラメータ（C）．0を指定した場合，最適な値が選択される．</param>
        /// <param name="reps">半径（座標原点と線の距離）と角度に対する精度．それぞれ0.01が初期値として適している．</param>
        /// <param name="aeps">半径（座標原点と線の距離）と角度に対する精度．それぞれ0.01が初期値として適している．</param>
        /// <param name="line">出力される線のパラメータ．2次元フィッティングの場合，四つの浮動小数点型数(vx, vy, x0, y0)の配列で，(vx, vy)は正規化された方向ベクトル，(x0, y0)は線上の点を意味する．3次元フィッティングの場合，(vx, vy, vz, x0, y0, z0)の六つの浮動小数点型数の配列で，(vx, vy, vz)は正規化された方向ベクトル，(x0, y0, z0)は線上の点を意味する．</param>
#else
        /// <summary>
        /// Fits line to 2D or 3D point set
        /// </summary>
        /// <param name="points">Sequence or array of 2D or 3D points with 32-bit integer or floating-point coordinates. </param>
        /// <param name="distType">The distance used for fitting (see the discussion). </param>
        /// <param name="param">Numerical parameter (C) for some types of distances, if 0 then some optimal value is chosen. </param>
        /// <param name="reps">Sufficient accuracy for radius (distance between the coordinate origin and the line) and angle, respectively, 0.01 would be a good defaults for both. </param>
        /// <param name="aeps">Sufficient accuracy for radius (distance between the coordinate origin and the line) and angle, respectively, 0.01 would be a good defaults for both. </param>
        /// <param name="line">The output line parameters. In case of 2d fitting it is array of 4 floats (vx, vy, x0, y0) where (vx, vy) is a normalized vector collinear to the line and (x0, y0) is some point on the line. In case of 3D fitting it is array of 6 floats (vx, vy, vz, x0, y0, z0) where (vx, vy, vz) is a normalized vector collinear to the line and (x0, y0, z0) is some point on the line. </param>
#endif
        public static void FitLine(CvArr points, DistanceType distType, double param, double reps, double aeps, float[] line)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            if (line == null)
                throw new ArgumentNullException("line");
            //line = new float[2 * points.ElemChannels]; // 4 or 6
            CvInvoke.cvFitLine(points.CvPtr, distType, param, reps, aeps, line);
        }

        #region FitLine2D
#if LANG_JP
        /// <summary>
        /// 2次元の点列に線をフィッティングする
        /// </summary>
        /// <param name="points">32ビット整数型の2次元の点の配列，またはシーケンス．</param>
        /// <param name="distType">フィッティングに使われる距離．</param>
        /// <param name="param">それぞれの距離関数における数値パラメータ（C）．0を指定した場合，最適な値が選択される．</param>
        /// <param name="reps">半径（座標原点と線の距離）と角度に対する精度．それぞれ0.01が初期値として適している．</param>
        /// <param name="aeps">半径（座標原点と線の距離）と角度に対する精度．それぞれ0.01が初期値として適している．</param>
        /// <returns>出力される線のパラメータ．(vx, vy)は正規化された方向ベクトル，(x0, y0)は線上の点を意味する．</returns>
#else
        /// <summary>
        /// Fits line to 2D point set
        /// </summary>
        /// <param name="points">Sequence or array of 2D points with 32-bit integer coordinates. </param>
        /// <param name="distType">The distance used for fitting (see the discussion). </param>
        /// <param name="param">Numerical parameter (C) for some types of distances, if 0 then some optimal value is chosen. </param>
        /// <param name="reps">Sufficient accuracy for radius (distance between the coordinate origin and the line) and angle, respectively, 0.01 would be a good defaults for both. </param>
        /// <param name="aeps">Sufficient accuracy for radius (distance between the coordinate origin and the line) and angle, respectively, 0.01 would be a good defaults for both. </param>
        /// <returns>The output line parameters. (vx, vy) is a normalized vector collinear to the line and 
        /// (x0, y0) is some point on the line. </returns>
#endif
        public static CvLine2D FitLine2D(IEnumerable<CvPoint> points, DistanceType distType, double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException("points");

            float[] lineVals = new float[4];
            using (CvMemStorage storage = new CvMemStorage(0))
            using (CvSeq<CvPoint> pointsSeq = CvSeq<CvPoint>.FromArray(points, SeqType.EltypeS32C2, storage))
            {
                CvInvoke.cvFitLine(pointsSeq.CvPtr, distType, param, reps, aeps, lineVals);
            }
            return new CvLine2D(lineVals);
        }
#if LANG_JP
        /// <summary>
        /// 2次元の点列に線をフィッティングする
        /// </summary>
        /// <param name="points">浮動小数点型の2次元の点の配列，またはシーケンス．</param>
        /// <param name="distType">フィッティングに使われる距離．</param>
        /// <param name="param">それぞれの距離関数における数値パラメータ（C）．0を指定した場合，最適な値が選択される．</param>
        /// <param name="reps">半径（座標原点と線の距離）と角度に対する精度．それぞれ0.01が初期値として適している．</param>
        /// <param name="aeps">半径（座標原点と線の距離）と角度に対する精度．それぞれ0.01が初期値として適している．</param>
        /// <returns>出力される線のパラメータ．(vx, vy)は正規化された方向ベクトル，(x0, y0)は線上の点を意味する．</returns>
#else
        /// <summary>
        /// Fits line to 2D point set
        /// </summary>
        /// <param name="points">Sequence or array of 2D points with floating-point coordinates. </param>
        /// <param name="distType">The distance used for fitting (see the discussion). </param>
        /// <param name="param">Numerical parameter (C) for some types of distances, if 0 then some optimal value is chosen. </param>
        /// <param name="reps">Sufficient accuracy for radius (distance between the coordinate origin and the line) and angle, respectively, 0.01 would be a good defaults for both. </param>
        /// <param name="aeps">Sufficient accuracy for radius (distance between the coordinate origin and the line) and angle, respectively, 0.01 would be a good defaults for both. </param>
        /// <returns>The output line parameters. (vx, vy) is a normalized vector collinear to the line and 
        /// (x0, y0) is some point on the line. </returns>
#endif
        public static CvLine2D FitLine2D(IEnumerable<CvPoint2D32f> points, DistanceType distType, double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException("points");

            float[] lineVals = new float[4];
            using (CvMemStorage storage = new CvMemStorage(0))
            using (CvSeq<CvPoint2D32f> pointsSeq = CvSeq<CvPoint2D32f>.FromArray(points, SeqType.EltypeF32C2, storage))
            {
                CvInvoke.cvFitLine(pointsSeq.CvPtr, distType, param, reps, aeps, lineVals);
            }
            return new CvLine2D(lineVals);
        }
        #endregion
        #region FitLine3D
#if LANG_JP
        /// <summary>
        /// 3次元の点列に線をフィッティングする
        /// </summary>
        /// <param name="points">浮動小数点型の3次元の点の配列，またはシーケンス．</param>
        /// <param name="distType">フィッティングに使われる距離．</param>
        /// <param name="param">それぞれの距離関数における数値パラメータ（C）．0を指定した場合，最適な値が選択される．</param>
        /// <param name="reps">半径（座標原点と線の距離）と角度に対する精度．それぞれ0.01が初期値として適している．</param>
        /// <param name="aeps">半径（座標原点と線の距離）と角度に対する精度．それぞれ0.01が初期値として適している．</param>
        /// <returns>出力される線のパラメータ．(vx, vy, vz)は正規化された方向ベクトル，(x0, y0, z0)は線上の点を意味する．</returns>
#else
        /// <summary>
        /// Fits line to 3D point set
        /// </summary>
        /// <param name="points">Sequence or array of 3D points with floating-point coordinates. </param>
        /// <param name="distType">The distance used for fitting (see the discussion). </param>
        /// <param name="param">Numerical parameter (C) for some types of distances, if 0 then some optimal value is chosen. </param>
        /// <param name="reps">Sufficient accuracy for radius (distance between the coordinate origin and the line) and angle, respectively, 0.01 would be a good defaults for both. </param>
        /// <param name="aeps">Sufficient accuracy for radius (distance between the coordinate origin and the line) and angle, respectively, 0.01 would be a good defaults for both. </param>
        /// <returns>The output line parameters. (vx, vy, vz) is a normalized vector collinear to the line and 
        /// (x0, y0, z0) is some point on the line. </returns>
#endif
        public static CvLine3D FitLine3D(IEnumerable<CvPoint3D32f> points, DistanceType distType, double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException("points");

            float[] lineVals = new float[6];
            using (CvMemStorage storage = new CvMemStorage(0))
            using (CvSeq<CvPoint3D32f> pointsSeq = CvSeq<CvPoint3D32f>.FromArray(points, SeqType.EltypeF32C3, storage))
            {
                CvInvoke.cvFitLine(pointsSeq.CvPtr, distType, param, reps, aeps, lineVals);
            }
            return new CvLine3D(lineVals);
        }
        #endregion
        #endregion
        #region Flip
#if LANG_JP
        /// <summary>
        /// 2次元配列を垂直，水平，または両軸で反転する
        /// </summary>
        /// <param name="src">入力配列（出力もここに格納される）</param>
#else
        /// <summary>
        /// Flip a 2D array around vertical, horizontal or both axises
        /// </summary>
        /// <param name="src">Source array. </param>
#endif
        public static void Flip(CvArr src)
        {
            Flip(src, null);
        }
#if LANG_JP
        /// <summary>
        /// 2次元配列を垂直，水平，または両軸で反転する
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列．もしnullであれば，反転はインプレースモードで行われる</param>
#else
        /// <summary>
        /// Flip a 2D array around vertical, horizontal or both axises
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. If dst = null the flipping is done in-place. </param>
#endif
        public static void Flip(CvArr src, CvArr dst)
        {
            Flip(src, dst, FlipMode.X);
        }
#if LANG_JP
        /// <summary>
        /// 2次元配列を垂直，水平，または両軸で反転する
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列．もしnullであれば，反転はインプレースモードで行われる</param>
        /// <param name="flipMode">配列の反転方法の指定</param>
#else
        /// <summary>
        /// Flip a 2D array around vertical, horizontal or both axises
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. If dst = null the flipping is done in-place. </param>
        /// <param name="flipMode">Specifies how to flip the array.</param>
#endif
        public static void Flip(CvArr src, CvArr dst, FlipMode flipMode)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            IntPtr dstPtr = (dst == null) ? IntPtr.Zero : dst.CvPtr;
            CvInvoke.cvFlip(src.CvPtr, dstPtr, flipMode);
        }
#if LANG_JP
        /// <summary>
        /// 2次元配列を垂直，水平，または両軸で反転する. cvFlipのエイリアス.
        /// </summary>
        /// <param name="src">入力配列（出力もここに格納される）</param>
#else
        /// <summary>
        /// Flip a 2D array around vertical, horizontal or both axises 
        /// </summary>
        /// <param name="src">Source array. </param>
#endif
        public static void Mirror(CvArr src)
        {
            Flip(src);
        }
#if LANG_JP
        /// <summary>
        /// 2次元配列を垂直，水平，または両軸で反転する. cvFlipのエイリアス.
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列．もしnullであれば，反転はインプレースモードで行われる</param>
#else
        /// <summary>
        /// Flip a 2D array around vertical, horizontal or both axises 
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. If dst = null the flipping is done in-place. </param>
#endif
        public static void Mirror(CvArr src, CvArr dst)
        {
            Flip(src, dst);
        }
#if LANG_JP
        /// <summary>
        /// 2次元配列を垂直，水平，または両軸で反転する. cvFlipのエイリアス.
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列．もしnullであれば，反転はインプレースモードで行われる</param>
        /// <param name="flipMode">配列の反転方法の指定</param>
#else
        /// <summary>
        /// Flip a 2D array around vertical, horizontal or both axises 
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst">Destination array. If dst = null the flipping is done in-place. </param>
        /// <param name="flipMode">Specifies how to flip the array.</param>
#endif
        public static void Mirror(CvArr src, CvArr dst, FlipMode flipMode)
        {
            Flip(src, dst, flipMode);
        }
        #endregion
        #region FloodFill
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="image">入力画像．1チャンネルあるいは3チャンネル，8ビットあるいは浮動小数点型．CV_FLOODFILL_MASK_ONLYフラグがセットされたとき以外は，データが書き換えられる．</param>
        /// <param name="seed_point">連結成分の開始点．シードピクセル． </param>
        /// <param name="new_val">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="image">Input 1- or 3-channel, 8-bit or floating-point image. It is modified by the function unless CV_FLOODFILL_MASK_ONLY flag is set. </param>
        /// <param name="seed_point">The starting point. </param>
        /// <param name="new_val">New value of repainted domain pixels. </param>
#endif
        public static void FloodFill(CvArr image, CvPoint seed_point, CvScalar new_val)
        {
            CvConnectedComp comp;
            FloodFill(image, seed_point, new_val, CvScalar.ScalarAll(0), CvScalar.ScalarAll(0), out comp, 4, null);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="image">入力画像．1チャンネルあるいは3チャンネル，8ビットあるいは浮動小数点型．CV_FLOODFILL_MASK_ONLYフラグがセットされたとき以外は，データが書き換えられる．</param>
        /// <param name="seed_point">連結成分の開始点．シードピクセル． </param>
        /// <param name="new_val">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="lo_diff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="image">Input 1- or 3-channel, 8-bit or floating-point image. It is modified by the function unless CV_FLOODFILL_MASK_ONLY flag is set. </param>
        /// <param name="seed_point">The starting point. </param>
        /// <param name="new_val">New value of repainted domain pixels. </param>
        /// <param name="lo_diff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
#endif
        public static void FloodFill(CvArr image, CvPoint seed_point, CvScalar new_val, CvScalar lo_diff)
        {
            CvConnectedComp comp;
            FloodFill(image, seed_point, new_val, lo_diff, CvScalar.ScalarAll(0), out comp, 4, null);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="image">入力画像．1チャンネルあるいは3チャンネル，8ビットあるいは浮動小数点型．CV_FLOODFILL_MASK_ONLYフラグがセットされたとき以外は，データが書き換えられる．</param>
        /// <param name="seed_point">連結成分の開始点．シードピクセル． </param>
        /// <param name="new_val">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="lo_diff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="up_diff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容上限値． 8ビットカラー画像のときは，パックされた値． </param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="image">Input 1- or 3-channel, 8-bit or floating-point image. It is modified by the function unless CV_FLOODFILL_MASK_ONLY flag is set. </param>
        /// <param name="seed_point">The starting point. </param>
        /// <param name="new_val">New value of repainted domain pixels. </param>
        /// <param name="lo_diff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="up_diff">Maximal upper brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
#endif
        public static void FloodFill(CvArr image, CvPoint seed_point, CvScalar new_val, CvScalar lo_diff, CvScalar up_diff)
        {
            CvConnectedComp comp;
            FloodFill(image, seed_point, new_val, lo_diff, up_diff, out comp, 4, null);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="image">入力画像．1チャンネルあるいは3チャンネル，8ビットあるいは浮動小数点型．CV_FLOODFILL_MASK_ONLYフラグがセットされたとき以外は，データが書き換えられる．</param>
        /// <param name="seed_point">連結成分の開始点．シードピクセル． </param>
        /// <param name="new_val">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="lo_diff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="up_diff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容上限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="comp">構造体へのポインタ．この関数は，塗りつぶされた領域の情報を構造体に代入する． </param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="image">Input 1- or 3-channel, 8-bit or floating-point image. It is modified by the function unless CV_FLOODFILL_MASK_ONLY flag is set. </param>
        /// <param name="seed_point">The starting point. </param>
        /// <param name="new_val">New value of repainted domain pixels. </param>
        /// <param name="lo_diff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="up_diff">Maximal upper brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="comp">Pointer to structure the function fills with the information about the repainted domain. </param>
#endif
        public static void FloodFill(CvArr image, CvPoint seed_point, CvScalar new_val, CvScalar lo_diff, CvScalar up_diff, out CvConnectedComp comp)
        {
            FloodFill(image, seed_point, new_val, lo_diff, up_diff, out comp, 4, null);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="image">入力画像．1チャンネルあるいは3チャンネル，8ビットあるいは浮動小数点型．CV_FLOODFILL_MASK_ONLYフラグがセットされたとき以外は，データが書き換えられる．</param>
        /// <param name="seed_point">連結成分の開始点．シードピクセル． </param>
        /// <param name="new_val">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="lo_diff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="up_diff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容上限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="comp">構造体へのポインタ．この関数は，塗りつぶされた領域の情報を構造体に代入する． </param>
        /// <param name="flags">操作フラグ．下位ビットは関数内で用いられる連結性に関する値4（デフォルト）または8が入っている． 
        /// 連結性は，どのピクセルを隣接ピクセルと見なすかを定義する．上位ビットは0，あるいはCv.FLOODFILL_FIXED_RANGE, Cv.FLOODFILL_MASK_ONLY との組み合わせである.</param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="image">Input 1- or 3-channel, 8-bit or floating-point image. It is modified by the function unless CV_FLOODFILL_MASK_ONLY flag is set. </param>
        /// <param name="seed_point">The starting point. </param>
        /// <param name="new_val">New value of repainted domain pixels. </param>
        /// <param name="lo_diff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="up_diff">Maximal upper brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="comp">Pointer to structure the function fills with the information about the repainted domain. </param>
        /// <param name="flags">The operation flags. Lower bits contain connectivity value, 4 (by default) or 8, used within the function. Connectivity determines which neighbors of a pixel are considered. Upper bits can be 0 or combination of the flags</param>
#endif
        public static void FloodFill(CvArr image, CvPoint seed_point, CvScalar new_val, CvScalar lo_diff, CvScalar up_diff, out CvConnectedComp comp, int flags)
        {
            FloodFill(image, seed_point, new_val, lo_diff, up_diff, out comp, flags, null);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="image">入力画像．1チャンネルあるいは3チャンネル，8ビットあるいは浮動小数点型．CV_FLOODFILL_MASK_ONLYフラグがセットされたとき以外は，データが書き換えられる．</param>
        /// <param name="seed_point">連結成分の開始点．シードピクセル． </param>
        /// <param name="new_val">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="lo_diff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="up_diff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容上限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="comp">構造体へのポインタ．この関数は，塗りつぶされた領域の情報を構造体に代入する． </param>
        /// <param name="flags">操作フラグ．下位ビットは関数内で用いられる連結性に関する値4（デフォルト）または8が入っている． 
        /// 連結性は，どのピクセルを隣接ピクセルと見なすかを定義する．上位ビットは0，あるいはCv.FLOODFILL_FIXED_RANGE, Cv.FLOODFILL_MASK_ONLY との組み合わせである.</param>
        /// <param name="mask">処理用マスク</param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="image">Input 1- or 3-channel, 8-bit or floating-point image. It is modified by the function unless CV_FLOODFILL_MASK_ONLY flag is set. </param>
        /// <param name="seed_point">The starting point. </param>
        /// <param name="new_val">New value of repainted domain pixels. </param>
        /// <param name="lo_diff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="up_diff">Maximal upper brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="comp">Pointer to structure the function fills with the information about the repainted domain. </param>
        /// <param name="flags">The operation flags. Lower bits contain connectivity value, 4 (by default) or 8, used within the function. Connectivity determines which neighbors of a pixel are considered. Upper bits can be 0 or combination of the flags</param>
        /// <param name="mask">Operation mask</param>
#endif
        public static void FloodFill(CvArr image, CvPoint seed_point, CvScalar new_val, CvScalar lo_diff, CvScalar up_diff, out CvConnectedComp comp, int flags, CvArr mask)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;

            comp = new CvConnectedComp();

            CvInvoke.cvFloodFill(image.CvPtr, seed_point, new_val, lo_diff, up_diff, comp.CvPtr, flags, maskPtr);
        }
        #endregion
        #region Floor
#if LANG_JP
        /// <summary>
        /// 引数より大きくない最大の整数値を返す.
        /// </summary>
        /// <param name="value">浮動小数点型の入力値</param>
        /// <returns>引数より大きくない最大の整数値</returns>]
#else
        /// <summary>
        /// Returns the maximum integer value that is not larger than the argument. 
        /// </summary>
        /// <param name="value">The input floating-point value </param>
        /// <returns></returns>
#endif
        public static int Floor(double value)
        {
            return (int)Math.Floor(value);
        }
        #endregion
        #region FlushSeqWriter
#if LANG_JP
        /// <summary>
        /// ライタの状態からシーケンスヘッダを更新する
        /// </summary>
        /// <param name="writer">ライタの状態．</param>
#else
        /// <summary>
        /// Updates sequence headers from the writer state
        /// </summary>
        /// <param name="writer">Writer state </param>
#endif
        public static void FlushSeqWriter(CvSeqWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            CvInvoke.cvFlushSeqWriter(writer.CvPtr);
        }
        #endregion
        #region FontQt
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画する際に利用されるフォントを作成します．
        /// </summary>
        /// <param name="nameFont">フォント名. 指定のフォントが見つからなければ，デフォルトフォントが利用されます．</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="nameFont">Name of the font. The name should match the name of a system font (such as ``Times’‘). If the font is not found, a default one will be used.</param>
#endif
        public static CvFontQt FontQt(string nameFont)
        {
            return new CvFontQt(nameFont);
        }
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画する際に利用されるフォントを作成します．
        /// </summary>
        /// <param name="nameFont">フォント名. 指定のフォントが見つからなければ，デフォルトフォントが利用されます．</param>
        /// <param name="pointSize">ォントサイズ．これが，未指定，または0以下の値の場合，フォンとのポイントサイズはシステム依存のデフォルト値にセットされます．通常は，12ポイントです．</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="nameFont">Name of the font. The name should match the name of a system font (such as ``Times’‘). If the font is not found, a default one will be used.</param>
        /// <param name="pointSize">Size of the font. If not specified, equal zero or negative, the point size of the font is set to a system-dependent default value. Generally, this is 12 points.</param>
#endif
        public static CvFontQt FontQt(string nameFont, int pointSize)
        {
            return new CvFontQt(nameFont, pointSize);
        }
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画する際に利用されるフォントを作成します．
        /// </summary>
        /// <param name="nameFont">フォント名. 指定のフォントが見つからなければ，デフォルトフォントが利用されます．</param>
        /// <param name="pointSize">ォントサイズ．これが，未指定，または0以下の値の場合，フォンとのポイントサイズはシステム依存のデフォルト値にセットされます．通常は，12ポイントです．</param>
        /// <param name="color">BGRA で表現されるフォントカラー．</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="nameFont">Name of the font. The name should match the name of a system font (such as ``Times’‘). If the font is not found, a default one will be used.</param>
        /// <param name="pointSize">Size of the font. If not specified, equal zero or negative, the point size of the font is set to a system-dependent default value. Generally, this is 12 points.</param>
        /// <param name="color">Color of the font in BGRA – A = 255 is fully transparent. Use the macro CV _ RGB for simplicity.</param>
#endif
        public static CvFontQt FontQt(string nameFont, int pointSize, CvScalar color)
        {
            return new CvFontQt(nameFont, pointSize, color);
        }
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画する際に利用されるフォントを作成します．
        /// </summary>
        /// <param name="nameFont">フォント名. 指定のフォントが見つからなければ，デフォルトフォントが利用されます．</param>
        /// <param name="pointSize">ォントサイズ．これが，未指定，または0以下の値の場合，フォンとのポイントサイズはシステム依存のデフォルト値にセットされます．通常は，12ポイントです．</param>
        /// <param name="color">BGRA で表現されるフォントカラー．</param>
        /// <param name="weight">フォントの太さ</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="nameFont">Name of the font. The name should match the name of a system font (such as ``Times’‘). If the font is not found, a default one will be used.</param>
        /// <param name="pointSize">Size of the font. If not specified, equal zero or negative, the point size of the font is set to a system-dependent default value. Generally, this is 12 points.</param>
        /// <param name="color">Color of the font in BGRA – A = 255 is fully transparent. Use the macro CV _ RGB for simplicity.</param>
        /// <param name="weight">The operation flags</param>
#endif
        public static CvFontQt FontQt(string nameFont, int pointSize, CvScalar color, FontWeight weight)
        {
            return new CvFontQt(nameFont, pointSize, color, weight);
        }
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画する際に利用されるフォントを作成します．
        /// </summary>
        /// <param name="nameFont">フォント名. 指定のフォントが見つからなければ，デフォルトフォントが利用されます．</param>
        /// <param name="pointSize">ォントサイズ．これが，未指定，または0以下の値の場合，フォンとのポイントサイズはシステム依存のデフォルト値にセットされます．通常は，12ポイントです．</param>
        /// <param name="color">BGRA で表現されるフォントカラー．</param>
        /// <param name="weight">フォントの太さ</param>
        /// <param name="style">処理フラグ</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="nameFont">Name of the font. The name should match the name of a system font (such as ``Times’‘). If the font is not found, a default one will be used.</param>
        /// <param name="pointSize">Size of the font. If not specified, equal zero or negative, the point size of the font is set to a system-dependent default value. Generally, this is 12 points.</param>
        /// <param name="color">Color of the font in BGRA – A = 255 is fully transparent. Use the macro CV _ RGB for simplicity.</param>
        /// <param name="weight">The operation flags</param>
        /// <param name="style">The operation flags</param>
#endif
        public static CvFontQt FontQt(string nameFont, int pointSize, CvScalar color, FontWeight weight, FontStyle style)
        {
            return new CvFontQt(nameFont, pointSize, color, weight, style);
        }
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画する際に利用されるフォントを作成します．
        /// </summary>
        /// <param name="nameFont">フォント名. 指定のフォントが見つからなければ，デフォルトフォントが利用されます．</param>
        /// <param name="pointSize">ォントサイズ．これが，未指定，または0以下の値の場合，フォンとのポイントサイズはシステム依存のデフォルト値にセットされます．通常は，12ポイントです．</param>
        /// <param name="color">BGRA で表現されるフォントカラー．</param>
        /// <param name="weight">フォントの太さ</param>
        /// <param name="style">処理フラグ</param>
        /// <param name="spacing">文字間のスペース．正負の値が利用できます．</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="nameFont">Name of the font. The name should match the name of a system font (such as ``Times’‘). If the font is not found, a default one will be used.</param>
        /// <param name="pointSize">Size of the font. If not specified, equal zero or negative, the point size of the font is set to a system-dependent default value. Generally, this is 12 points.</param>
        /// <param name="color">Color of the font in BGRA – A = 255 is fully transparent. Use the macro CV _ RGB for simplicity.</param>
        /// <param name="weight">The operation flags</param>
        /// <param name="style">The operation flags</param>
        /// <param name="spacing">Spacing between characters. Can be negative or positive.</param>
#endif
        public static CvFontQt FontQt(string nameFont, int pointSize, CvScalar color, FontWeight weight, FontStyle style, int spacing)
        {
            return new CvFontQt(nameFont, pointSize, color, weight, style, spacing);
        }
        #endregion
        #region Free
#if LANG_JP
        /// <summary>
        /// メモリバッファの領域を解放する
        /// </summary>
        /// <param name="ptr">解放する領域へのポインタのポインタ</param>
#else
        /// <summary>
        /// Deallocates memory buffer
        /// </summary>
        /// <param name="ptr">Double pointer to released buffer. </param>
#endif
        public static void Free(ref IntPtr ptr)
        {
            CvInvoke.cvFree_(ptr);
            ptr = IntPtr.Zero;
        }
        #endregion
    }
}