using System;
using System.Collections.Generic;
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
            return NativeMethods.cvFastArctan(y, x);
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
            NativeMethods.cvFillConvexPoly(img.CvPtr, pts, pts.Length, color, lineType, shift);
            KeepAlive(img);
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
                NativeMethods.cvFillPoly(img.CvPtr, ptsPtr.Pointer, npts, contours, color, lineType, shift);
            }
            KeepAlive(img);
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
            NativeMethods.cvFilter2D(src.CvPtr, dst.CvPtr, kernel.CvPtr, anchor);
            KeepAlive(src, dst, kernel);
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
                int result = NativeMethods.cvFindChessboardCorners(image.CvPtr, patternSize, cornersPtr, ref cornerCount, flags);
                KeepAlive(image);
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
            int result = NativeMethods.cvFindContours(image.CvPtr, storage.CvPtr, ref firstContourPtr, headerSize, mode, method, offset);

            if (firstContourPtr == IntPtr.Zero)
                firstContour = null;
            else if (method == ContourChain.Code)
                firstContour = new CvChain(firstContourPtr);
            else
                firstContour = new CvContour(firstContourPtr);
            
            KeepAlive(image, storage);
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

            NativeMethods.cvFindCornerSubPix(image.CvPtr, corners, count, win, zeroZone, criteria);
            KeepAlive(image);
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

            IntPtr result = NativeMethods.cvFindDominantPoints(contour.CvPtr, ToPtr(storage), method, parameter1, parameter2, parameter3, parameter4);
            KeepAlive(contour, storage);
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

            NativeMethods.cvFindExtrinsicCameraParams2(
                objectPoints.CvPtr, imagePoints.CvPtr, intrinsicMatrix.CvPtr, 
                ToPtr(distortionCoeffs), rotationVector.CvPtr, translationVector.CvPtr, useExtrinsicGuess);
            KeepAlive(objectPoints, imagePoints, intrinsicMatrix, distortionCoeffs, rotationVector, translationVector);
        }

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

            IntPtr ptr = NativeMethods.cvFindFace(image.CvPtr, storage.CvPtr);
            KeepAlive(image, storage);
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
            NativeMethods.cvFindFeatures(tr.CvPtr, desc.CvPtr, results.CvPtr, dist.CvPtr, k, emax);
            KeepAlive(tr, desc, results, dist);
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
            
            var ret = NativeMethods.cvFindFeaturesBoxed(tr.CvPtr, boundsMin.CvPtr, boundsMax.CvPtr, result.CvPtr);
            KeepAlive(tr, boundsMin, boundsMax, result);
            return ret;
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

            var ret = NativeMethods.cvFindFundamentalMat(
                    points1.CvPtr, points2.CvPtr, fundamentalMatrix.CvPtr, method, param1, param2, ToPtr(status));
            KeepAlive(points1, points2, fundamentalMatrix, status);
            return ret;
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
            IntPtr result = NativeMethods.cvFindGraphEdge(graph.CvPtr, startIdx, endIdx);
            KeepAlive(graph);
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
            
            IntPtr result = NativeMethods.cvFindGraphEdgeByPtr(graph.CvPtr, startVtx.CvPtr, endVtx.CvPtr);
            KeepAlive(graph, startVtx, endVtx);
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
            var ret = NativeMethods.cvFindHomography(
                    srcPoints.CvPtr, dstPoints.CvPtr, homography.CvPtr, method, ransacReprojThreshold, ToPtr(mask));
            KeepAlive(srcPoints, dstPoints, homography, mask);
            return ret;
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
            IntPtr result = NativeMethods.cvFindNearestPoint2D(subdiv.CvPtr, pt);
            KeepAlive(subdiv);
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
            IntPtr result = NativeMethods.cvFindNextContour(scanner.CvPtr);
            KeepAlive(scanner);
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
            NativeMethods.cvFindStereoCorrespondence(leftImage.CvPtr, rightImage.CvPtr, mode, depthImage.CvPtr, maxDisparity, param1, param2, param3, param4, param5);
            KeepAlive(leftImage, rightImage, depthImage);
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
            NativeMethods.cvFindStereoCorrespondenceBM(left.CvPtr, right.CvPtr, disparity.CvPtr, state.CvPtr);
            KeepAlive(left, right, disparity, state);
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
            NativeMethods.cvFindStereoCorrespondenceGC(left.CvPtr, right.CvPtr, dispLeft.CvPtr, dispRight.CvPtr, state.CvPtr, useDisparityGuess);
            KeepAlive(left, right, dispLeft, dispRight, state);
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
            IntPtr result = NativeMethods.cvFindType(typeName);
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
            IntPtr result = NativeMethods.cvFirstType();
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
            var ret = NativeMethods.cvFitEllipse2(points.CvPtr);
            KeepAlive(points);
            return ret;
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
                return NativeMethods.cvFitEllipse2(pointsMat.CvPtr);
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
            NativeMethods.cvFitLine(points.CvPtr, distType, param, reps, aeps, line);
            KeepAlive(points);
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
                NativeMethods.cvFitLine(pointsSeq.CvPtr, distType, param, reps, aeps, lineVals);
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
                NativeMethods.cvFitLine(pointsSeq.CvPtr, distType, param, reps, aeps, lineVals);
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
                NativeMethods.cvFitLine(pointsSeq.CvPtr, distType, param, reps, aeps, lineVals);
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
                throw new ArgumentNullException("src");

            NativeMethods.cvFlip(src.CvPtr, ToPtr(dst), flipMode);
            KeepAlive(src, dst);
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
        /// <param name="seedPoint">連結成分の開始点．シードピクセル． </param>
        /// <param name="newVal">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="image">Input 1- or 3-channel, 8-bit or floating-point image. It is modified by the function unless CV_FLOODFILL_MASK_ONLY flag is set. </param>
        /// <param name="seedPoint">The starting point. </param>
        /// <param name="newVal">New value of repainted domain pixels. </param>
#endif
        public static void FloodFill(CvArr image, CvPoint seedPoint, CvScalar newVal)
        {
            CvConnectedComp comp;
            FloodFill(image, seedPoint, newVal, CvScalar.ScalarAll(0), CvScalar.ScalarAll(0), 
                out comp, FloodFillFlag.Link4, null);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="image">入力画像．1チャンネルあるいは3チャンネル，8ビットあるいは浮動小数点型．CV_FLOODFILL_MASK_ONLYフラグがセットされたとき以外は，データが書き換えられる．</param>
        /// <param name="seedPoint">連結成分の開始点．シードピクセル． </param>
        /// <param name="newVal">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="loDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="image">Input 1- or 3-channel, 8-bit or floating-point image. It is modified by the function unless CV_FLOODFILL_MASK_ONLY flag is set. </param>
        /// <param name="seedPoint">The starting point. </param>
        /// <param name="newVal">New value of repainted domain pixels. </param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
#endif
        public static void FloodFill(CvArr image, CvPoint seedPoint, CvScalar newVal, CvScalar loDiff)
        {
            CvConnectedComp comp;
            FloodFill(image, seedPoint, newVal, loDiff, CvScalar.ScalarAll(0), 
                out comp, FloodFillFlag.Link4, null);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="image">入力画像．1チャンネルあるいは3チャンネル，8ビットあるいは浮動小数点型．CV_FLOODFILL_MASK_ONLYフラグがセットされたとき以外は，データが書き換えられる．</param>
        /// <param name="seedPoint">連結成分の開始点．シードピクセル． </param>
        /// <param name="newVal">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="loDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="upDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容上限値． 8ビットカラー画像のときは，パックされた値． </param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="image">Input 1- or 3-channel, 8-bit or floating-point image. It is modified by the function unless CV_FLOODFILL_MASK_ONLY flag is set. </param>
        /// <param name="seedPoint">The starting point. </param>
        /// <param name="newVal">New value of repainted domain pixels. </param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="upDiff">Maximal upper brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
#endif
        public static void FloodFill(CvArr image, CvPoint seedPoint, CvScalar newVal, 
            CvScalar loDiff, CvScalar upDiff)
        {
            CvConnectedComp comp;
            FloodFill(image, seedPoint, newVal, loDiff, upDiff, out comp, FloodFillFlag.Link4, null);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="image">入力画像．1チャンネルあるいは3チャンネル，8ビットあるいは浮動小数点型．CV_FLOODFILL_MASK_ONLYフラグがセットされたとき以外は，データが書き換えられる．</param>
        /// <param name="seedPoint">連結成分の開始点．シードピクセル． </param>
        /// <param name="newVal">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="loDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="upDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容上限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="comp">構造体へのポインタ．この関数は，塗りつぶされた領域の情報を構造体に代入する． </param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="image">Input 1- or 3-channel, 8-bit or floating-point image. It is modified by the function unless CV_FLOODFILL_MASK_ONLY flag is set. </param>
        /// <param name="seedPoint">The starting point. </param>
        /// <param name="newVal">New value of repainted domain pixels. </param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="upDiff">Maximal upper brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="comp">Pointer to structure the function fills with the information about the repainted domain. </param>
#endif
        public static void FloodFill(CvArr image, CvPoint seedPoint, CvScalar newVal, 
            CvScalar loDiff, CvScalar upDiff, out CvConnectedComp comp)
        {
            FloodFill(image, seedPoint, newVal, loDiff, upDiff, out comp, FloodFillFlag.Link4, null);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="image">入力画像．1チャンネルあるいは3チャンネル，8ビットあるいは浮動小数点型．CV_FLOODFILL_MASK_ONLYフラグがセットされたとき以外は，データが書き換えられる．</param>
        /// <param name="seedPoint">連結成分の開始点．シードピクセル． </param>
        /// <param name="newVal">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="loDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="upDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容上限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="comp">構造体へのポインタ．この関数は，塗りつぶされた領域の情報を構造体に代入する． </param>
        /// <param name="flags">操作フラグ．下位ビットは関数内で用いられる連結性に関する値4（デフォルト）または8が入っている． 
        /// 連結性は，どのピクセルを隣接ピクセルと見なすかを定義する．上位ビットは0，あるいはCv.FLOODFILL_FIXED_RANGE, Cv.FLOODFILL_MASK_ONLY との組み合わせである.</param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="image">Input 1- or 3-channel, 8-bit or floating-point image. It is modified by the function unless CV_FLOODFILL_MASK_ONLY flag is set. </param>
        /// <param name="seedPoint">The starting point. </param>
        /// <param name="newVal">New value of repainted domain pixels. </param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="upDiff">Maximal upper brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="comp">Pointer to structure the function fills with the information about the repainted domain. </param>
        /// <param name="flags">The operation flags. Lower bits contain connectivity value, 4 (by default) or 8, used within the function. Connectivity determines which neighbors of a pixel are considered. Upper bits can be 0 or combination of the flags</param>
#endif
        public static void FloodFill(CvArr image, CvPoint seedPoint, CvScalar newVal, 
            CvScalar loDiff, CvScalar upDiff, out CvConnectedComp comp, FloodFillFlag flags)
        {
            FloodFill(image, seedPoint, newVal, loDiff, upDiff, out comp, flags, null);
        }
#if LANG_JP
        /// <summary>
        /// 連結成分を指定した色で塗りつぶす
        /// </summary>
        /// <param name="image">入力画像．1チャンネルあるいは3チャンネル，8ビットあるいは浮動小数点型．CV_FLOODFILL_MASK_ONLYフラグがセットされたとき以外は，データが書き換えられる．</param>
        /// <param name="seedPoint">連結成分の開始点．シードピクセル． </param>
        /// <param name="newVal">塗りつぶされる領域の新しいピクセル値（塗りつぶす値）．</param>
        /// <param name="loDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容下限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="upDiff">現在の観測対象ピクセルと，その連結成分に属する隣接ピクセル， またはそのピクセルを連結成分に追加するためのシードピクセルとの，輝度値/色の差（違い）の許容上限値． 8ビットカラー画像のときは，パックされた値． </param>
        /// <param name="comp">構造体へのポインタ．この関数は，塗りつぶされた領域の情報を構造体に代入する． </param>
        /// <param name="flags">操作フラグ．下位ビットは関数内で用いられる連結性に関する値4（デフォルト）または8が入っている． 
        /// 連結性は，どのピクセルを隣接ピクセルと見なすかを定義する．上位ビットは0，あるいはCv.FLOODFILL_FIXED_RANGE, Cv.FLOODFILL_MASK_ONLY との組み合わせである.</param>
        /// <param name="mask">処理用マスク</param>
#else
        /// <summary>
        /// Fills a connected component with given color.
        /// </summary>
        /// <param name="image">Input 1- or 3-channel, 8-bit or floating-point image. It is modified by the function unless CV_FLOODFILL_MASK_ONLY flag is set. </param>
        /// <param name="seedPoint">The starting point. </param>
        /// <param name="newVal">New value of repainted domain pixels. </param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="upDiff">Maximal upper brightness/color difference between the currently observed pixel and one of its neighbor belong to the component or seed pixel to add the pixel to component. In case of 8-bit color images it is packed value. </param>
        /// <param name="comp">Pointer to structure the function fills with the information about the repainted domain. </param>
        /// <param name="flags">The operation flags. Lower bits contain connectivity value, 4 (by default) or 8, used within the function. Connectivity determines which neighbors of a pixel are considered. Upper bits can be 0 or combination of the flags</param>
        /// <param name="mask">Operation mask</param>
#endif
        public static void FloodFill(CvArr image, CvPoint seedPoint, CvScalar newVal, 
            CvScalar loDiff, CvScalar upDiff, out CvConnectedComp comp, FloodFillFlag flags, CvArr mask)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            comp = new CvConnectedComp();
            NativeMethods.cvFloodFill(image.CvPtr, seedPoint, newVal, loDiff, upDiff, comp.CvPtr, (int)flags, ToPtr(mask));
            KeepAlive(image, comp, mask);
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
                throw new ArgumentNullException("writer");
            
            NativeMethods.cvFlushSeqWriter(writer.CvPtr);
            KeepAlive(writer);
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
            NativeMethods.cvFree_(ptr);
            ptr = IntPtr.Zero;
        }
        #endregion
    }
}