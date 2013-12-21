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
        #region IncRefData
#if LANG_JP
        /// <summary>
        /// 参照カウンタポインタが null ではない場合に， CvMat あるいは CvMatND のデータの参照カウンタをインクリメントし，新たなカウンタ値を返す．
        /// そうでない場合は 0 を返す． 
        /// </summary>
        /// <param name="arr">配列ヘッダ</param>
        /// <returns>新たなカウンタ値</returns>
#else
        /// <summary>
        /// Increments array data reference counter
        /// </summary>
        /// <param name="arr">Array header. </param>
        /// <returns>The function cvIncRefData increments CvMat or CvMatND data reference counter and returns the new counter value if the reference counter pointer is not NULL, otherwise it returns zero. </returns>
#endif
        public static int IncRefData(CvArr arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }

            int refcount = 0;
            unsafe
            {
                if (arr is CvMat)
                {
                    CvMat mat = (CvMat)arr;
                    if (mat.RefCount != IntPtr.Zero)
                        refcount = ++*(int*)mat.RefCount;
                }
                else if (arr is CvMatND)
                {
                    CvMatND mat = (CvMatND)arr;
                    if (mat.RefCount != IntPtr.Zero)
                        refcount = ++*(int*)mat.RefCount;
                }
            }
            return refcount;
        }
        #endregion
        #region InitFaceTracker
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imgGray"></param>
        /// <param name="pRects"></param>
        /// <returns></returns>
        public static CvFaceTracker InitFaceTracker(IplImage imgGray, CvRect[] pRects)
        {
            return new CvFaceTracker(imgGray, pRects);
        }
        #endregion
        #region InitFont
#if LANG_JP
        /// <summary>
        /// 文字描画関数に渡されるフォント構造体を初期化する
        /// </summary>
        /// <param name="font">この関数で初期化されるフォントクラス</param>
        /// <param name="fontFace">フォント名の識別子</param>
        /// <param name="hscale">幅の比率．1.0fにした場合，文字はそれぞれのフォントに依存する元々の幅で表示される． 0.5fにした場合, 文字は元々の半分の幅で表示される．</param>
        /// <param name="vscale">高さの比率．1.0fにした場合，文字はそれぞれのフォントに依存する元々の高さで表示される． 0.5fにした場合, 文字は元々の半分の高さで表示される．</param>
#else
        /// <summary>
        /// Initializes font structure
        /// </summary>
        /// <param name="font">font structure initialized by the function. </param>
        /// <param name="fontFace">Font name identifier. Only a subset of Hershey fonts are supported now.</param>
        /// <param name="hscale">Horizontal scale. If equal to 1.0f, the characters have the original width depending on the font type. If equal to 0.5f, the characters are of half the original width. </param>
        /// <param name="vscale">Vertical scale. If equal to 1.0f, the characters have the original height depending on the font type. If equal to 0.5f, the characters are of half the original height. </param>
#endif
        public static void InitFont(out CvFont font, FontFace fontFace, double hscale, double vscale)
        {
            font = new CvFont(fontFace, hscale, vscale);
        }
#if LANG_JP
        /// <summary>
        /// 文字描画関数に渡されるフォント構造体を初期化する
        /// </summary>
        /// <param name="font">この関数で初期化されるフォントクラス</param>
        /// <param name="fontFace">フォント名の識別子</param>
        /// <param name="hscale">幅の比率．1.0fにした場合，文字はそれぞれのフォントに依存する元々の幅で表示される． 0.5fにした場合, 文字は元々の半分の幅で表示される．</param>
        /// <param name="vscale">高さの比率．1.0fにした場合，文字はそれぞれのフォントに依存する元々の高さで表示される． 0.5fにした場合, 文字は元々の半分の高さで表示される．</param>
        /// <param name="shear">垂直線からの文字の相対的な角度．ゼロの場合は非イタリックフォントで，例えば，1.0fは≈45°を意味する．</param>
#else
        /// <summary>
        /// Initializes font structure
        /// </summary>
        /// <param name="font">font structure initialized by the function. </param>
        /// <param name="fontFace">Font name identifier. Only a subset of Hershey fonts are supported now.</param>
        /// <param name="hscale">Horizontal scale. If equal to 1.0f, the characters have the original width depending on the font type. If equal to 0.5f, the characters are of half the original width. </param>
        /// <param name="vscale">Vertical scale. If equal to 1.0f, the characters have the original height depending on the font type. If equal to 0.5f, the characters are of half the original height. </param>
        /// <param name="shear">Approximate tangent of the character slope relative to the vertical line. Zero value means a non-italic font, 1.0f means ≈45° slope, etc. thickness Thickness of lines composing letters outlines. The function cvLine is used for drawing letters. </param>
#endif
        public static void InitFont(out CvFont font, FontFace fontFace, double hscale, double vscale, double shear)
        {
            font = new CvFont(fontFace, hscale, vscale, shear);
        }
#if LANG_JP
        /// <summary>
        /// 文字描画関数に渡されるフォント構造体を初期化する
        /// </summary>
        /// <param name="font">この関数で初期化されるフォントクラス</param>
        /// <param name="fontFace">フォント名の識別子</param>
        /// <param name="hscale">幅の比率．1.0fにした場合，文字はそれぞれのフォントに依存する元々の幅で表示される． 0.5fにした場合, 文字は元々の半分の幅で表示される．</param>
        /// <param name="vscale">高さの比率．1.0fにした場合，文字はそれぞれのフォントに依存する元々の高さで表示される． 0.5fにした場合, 文字は元々の半分の高さで表示される．</param>
        /// <param name="shear">垂直線からの文字の相対的な角度．ゼロの場合は非イタリックフォントで，例えば，1.0fは≈45°を意味する．</param>
        /// <param name="thickness">文字の太さ．</param>
#else
        /// <summary>
        /// Initializes font structure
        /// </summary>
        /// <param name="font">font structure initialized by the function. </param>
        /// <param name="fontFace">Font name identifier. Only a subset of Hershey fonts are supported now.</param>
        /// <param name="hscale">Horizontal scale. If equal to 1.0f, the characters have the original width depending on the font type. If equal to 0.5f, the characters are of half the original width. </param>
        /// <param name="vscale">Vertical scale. If equal to 1.0f, the characters have the original height depending on the font type. If equal to 0.5f, the characters are of half the original height. </param>
        /// <param name="shear">Approximate tangent of the character slope relative to the vertical line. Zero value means a non-italic font, 1.0f means ≈45° slope, etc. thickness Thickness of lines composing letters outlines. The function cvLine is used for drawing letters. </param>
        /// <param name="thickness">Thickness of the text strokes. </param>
#endif
        public static void InitFont(out CvFont font, FontFace fontFace, double hscale, double vscale, double shear, int thickness)
        {
            font = new CvFont(fontFace, hscale, vscale, shear, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 文字描画関数に渡されるフォント構造体を初期化する
        /// </summary>
        /// <param name="font">この関数で初期化されるフォントクラス</param>
        /// <param name="fontFace">フォント名の識別子</param>
        /// <param name="hscale">幅の比率．1.0fにした場合，文字はそれぞれのフォントに依存する元々の幅で表示される． 0.5fにした場合, 文字は元々の半分の幅で表示される．</param>
        /// <param name="vscale">高さの比率．1.0fにした場合，文字はそれぞれのフォントに依存する元々の高さで表示される． 0.5fにした場合, 文字は元々の半分の高さで表示される．</param>
        /// <param name="shear">垂直線からの文字の相対的な角度．ゼロの場合は非イタリックフォントで，例えば，1.0fは≈45°を意味する．</param>
        /// <param name="thickness">文字の太さ．</param>
        /// <param name="lineType">線の種類．</param>
#else
        /// <summary>
        /// Initializes font structure
        /// </summary>
        /// <param name="font">font structure initialized by the function. </param>
        /// <param name="fontFace">Font name identifier. Only a subset of Hershey fonts are supported now.</param>
        /// <param name="hscale">Horizontal scale. If equal to 1.0f, the characters have the original width depending on the font type. If equal to 0.5f, the characters are of half the original width. </param>
        /// <param name="vscale">Vertical scale. If equal to 1.0f, the characters have the original height depending on the font type. If equal to 0.5f, the characters are of half the original height. </param>
        /// <param name="shear">Approximate tangent of the character slope relative to the vertical line. Zero value means a non-italic font, 1.0f means ≈45° slope, etc. thickness Thickness of lines composing letters outlines. The function cvLine is used for drawing letters. </param>
        /// <param name="thickness">Thickness of the text strokes. </param>
        /// <param name="lineType">Type of the strokes, see cvLine description. </param>
#endif
        public static void InitFont(out CvFont font, FontFace fontFace, double hscale, double vscale, double shear, int thickness, LineType lineType)
        {
            font = new CvFont(fontFace, hscale, vscale, shear, thickness, lineType);
        }
        #endregion
        #region InitImageHeader
#if LANG_JP
        /// <summary>
        /// ユーザから渡された参照が指す, ユーザによって確保された画像のヘッダ構造体を初期化し，その参照を返す
        /// </summary>
        /// <param name="image">初期化される画像ヘッダ</param>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="depth">画像のカラーデプス</param>
        /// <param name="channels">チャンネル数</param>
        /// <returns>初期化された画像ヘッダ</returns>
#else
        /// <summary>
        /// Initializes allocated by user image header
        /// </summary>
        /// <param name="image">Image header to initialise. </param>
        /// <param name="size">Image width and height. </param>
        /// <param name="depth">Image depth. </param>
        /// <param name="channels">Number of channels. </param>
        /// <returns>Initialzed IplImage header</returns>
#endif
        public static IplImage InitImageHeader(out IplImage image, CvSize size, BitDepth depth, int channels)
        {
            return InitImageHeader(out image, size, depth, channels, ImageOrigin.TopLeft, 4);
        }
#if LANG_JP
        /// <summary>
        /// ユーザから渡された参照が指す, ユーザによって確保された画像のヘッダ構造体を初期化し，その参照を返す
        /// </summary>
        /// <param name="image">初期化される画像ヘッダ</param>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="depth">画像のカラーデプス</param>
        /// <param name="channels">チャンネル数</param>
        /// <param name="origin">初期化される画像ヘッダ</param>
        /// <returns>初期化された画像ヘッダ</returns>
#else
        /// <summary>
        /// Initializes allocated by user image header
        /// </summary>
        /// <param name="image">Image header to initialise. </param>
        /// <param name="size">Image width and height. </param>
        /// <param name="depth">Image depth. </param>
        /// <param name="channels">Number of channels. </param>
        /// <param name="origin">Origin of image</param>
        /// <returns>Initialzed IplImage header</returns>
#endif
        public static IplImage InitImageHeader(out IplImage image, CvSize size, BitDepth depth, int channels, ImageOrigin origin)
        {
            return InitImageHeader(out image, size, depth, channels, origin, 4);
        }
#if LANG_JP
        /// <summary>
        /// ユーザから渡された参照が指す, ユーザによって確保された画像のヘッダ構造体を初期化し，その参照を返す
        /// </summary>
        /// <param name="image">初期化される画像ヘッダ</param>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="depth">画像のカラーデプス</param>
        /// <param name="channels">チャンネル数</param>
        /// <param name="origin">初期化される画像ヘッダ</param>
        /// <param name="align">画像の行のアライメント，通常は4，あるいは 8 バイト．</param>
        /// <returns>初期化された画像ヘッダ</returns>
#else
        /// <summary>
        /// Initializes allocated by user image header
        /// </summary>
        /// <param name="image">Image header to initialise. </param>
        /// <param name="size">Image width and height. </param>
        /// <param name="depth">Image depth. </param>
        /// <param name="channels">Number of channels. </param>
        /// <param name="origin">Origin of image</param>
        /// <param name="align">Alignment for image rows, typically 4 or 8 bytes. </param>
        /// <returns>Initialzed IplImage header</returns>
#endif
        public static IplImage InitImageHeader(out IplImage image, CvSize size, BitDepth depth, int channels, ImageOrigin origin, int align)
        {
            image = new IplImage();
            CvInvoke.cvInitImageHeader(image.CvPtr, size, depth, channels, origin, align);
            return image;
        }
        #endregion
        #region InitIntrinsicParams2D
#if LANG_JP
        /// <summary>
        /// 3次元-2次元の対応点から，カメラの内部パラメータ行列を求めます
        /// </summary>
        /// <param name="objectPoints">物体上の座標点が結合された配列</param>
        /// <param name="imagePoints">物体上の座標の投影点が結合された配列</param>
        /// <param name="npoints">点の個数の配列</param>
        /// <param name="imageSize">ピクセル単位で表された画像サイズ．主点を初期化するために利用されます</param>
        /// <param name="cameraMatrix">出力されるカメラ行列</param>
#else
        /// <summary>
        /// Finds the initial camera matrix from the 3D-2D point correspondences
        /// </summary>
        /// <param name="objectPoints">The joint array of object points</param>
        /// <param name="imagePoints">The joint array of object point projections</param>
        /// <param name="npoints">The array of point counts</param>
        /// <param name="imageSize">The image size in pixels</param>
        /// <param name="cameraMatrix">The output camera matrix</param>
#endif
        public static void InitIntrinsicParams2D(CvMat objectPoints, CvMat imagePoints, CvMat npoints, CvSize imageSize, CvMat cameraMatrix)
        {
            InitIntrinsicParams2D(objectPoints, imagePoints, npoints, imageSize, cameraMatrix, 1.0);
        }
#if LANG_JP
        /// <summary>
        /// 3次元-2次元の対応点から，カメラの内部パラメータ行列を求めます
        /// </summary>
        /// <param name="objectPoints">物体上の座標点が結合された配列</param>
        /// <param name="imagePoints">物体上の座標の投影点が結合された配列</param>
        /// <param name="npoints">点の個数の配列</param>
        /// <param name="imageSize">ピクセル単位で表された画像サイズ．主点を初期化するために利用されます</param>
        /// <param name="cameraMatrix">出力されるカメラ行列</param>
        /// <param name="aspectRatio">これが0以下の場合， f_x と f_y は独立に推定されます．そうでない場合， f_x = f_y * aspectRatio となります</param>
#else
        /// <summary>
        /// Finds the initial camera matrix from the 3D-2D point correspondences
        /// </summary>
        /// <param name="objectPoints">The joint array of object points</param>
        /// <param name="imagePoints">The joint array of object point projections</param>
        /// <param name="npoints">The array of point counts</param>
        /// <param name="imageSize">The image size in pixels</param>
        /// <param name="cameraMatrix">The output camera matrix</param>
        /// <param name="aspectRatio">If it is zero or negative, both f_x and f_y are estimated independently. Otherwise f_x = f_y * aspectRatio</param>
#endif
        public static void InitIntrinsicParams2D(CvMat objectPoints, CvMat imagePoints, CvMat npoints, CvSize imageSize, CvMat cameraMatrix, double aspectRatio)
        {
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (imagePoints == null)
                throw new ArgumentNullException("imagePoints");
            if (npoints == null)
                throw new ArgumentNullException("npoints");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            CvInvoke.cvInitIntrinsicParams2D(objectPoints.CvPtr, imagePoints.CvPtr, npoints.CvPtr, imageSize, cameraMatrix.CvPtr, aspectRatio);
        }
        #endregion
        #region InitLineIterator
#if LANG_JP
        /// <summary>
        /// ラインイテレータを初期化する
        /// </summary>
        /// <param name="image">対象画像</param>
        /// <param name="pt1">線分の一つ目の端点</param>
        /// <param name="pt2">線分のニつ目の端点</param>
        /// <param name="lineIterator">ラインイテレータ状態構造体へのポインタ</param>
        /// <returns></returns> 
#else
        /// <summary>
        /// Initializes line iterator
        /// </summary>
        /// <param name="image">Image to sample the line from.  </param>
        /// <param name="pt1">First ending point of the line segment. </param>
        /// <param name="pt2">Second ending point of the line segment. </param>
        /// <param name="lineIterator">Line iterator state structure to be generated. </param>
        /// <returns>The function cvInitLineIterator initializes the line iterator and returns the number of pixels between two end points. Both points must be inside the image. After the iterator has been initialized, all the points on the raster line that connects the two ending points may be retrieved by successive calls of NextLinePoint point. The points on the line are calculated one by one using 4-connected or 8-connected Bresenham algorithm.</returns> 
#endif
        public static int InitLineIterator(CvArr image, CvPoint pt1, CvPoint pt2, out CvLineIterator lineIterator)
        {
            return InitLineIterator(image, pt1, pt2, out lineIterator, PixelConnectivity.Connectivity_8);
        }
#if LANG_JP
        /// <summary>
        /// ラインイテレータを初期化する
        /// </summary>
        /// <param name="image">対象画像</param>
        /// <param name="pt1">線分の一つ目の端点</param>
        /// <param name="pt2">線分のニつ目の端点</param>
        /// <param name="lineIterator">ラインイテレータ状態構造体へのポインタ</param>
        /// <param name="connectivity">走査した線分の接続性．4または8</param>
        /// <returns></returns> 
#else
        /// <summary>
        /// Initializes line iterator
        /// </summary>
        /// <param name="image">Image to sample the line from.  </param>
        /// <param name="pt1">First ending point of the line segment. </param>
        /// <param name="pt2">Second ending point of the line segment. </param>
        /// <param name="lineIterator">Line iterator state structure to be generated. </param>
        /// <param name="connectivity">The scanned line connectivity, 4 or 8. </param>
        /// <returns>The function cvInitLineIterator initializes the line iterator and returns the number of pixels between two end points. Both points must be inside the image. After the iterator has been initialized, all the points on the raster line that connects the two ending points may be retrieved by successive calls of NextLinePoint point. The points on the line are calculated one by one using 4-connected or 8-connected Bresenham algorithm.</returns> 
#endif
        public static int InitLineIterator(CvArr image, CvPoint pt1, CvPoint pt2, out CvLineIterator lineIterator, PixelConnectivity connectivity)
        {
            return InitLineIterator(image, pt1, pt2, out lineIterator, connectivity, false);
        }
#if LANG_JP
        /// <summary>
        /// ラインイテレータを初期化する
        /// </summary>
        /// <param name="image">対象画像</param>
        /// <param name="pt1">線分の一つ目の端点</param>
        /// <param name="pt2">線分のニつ目の端点</param>
        /// <param name="lineIterator">ラインイテレータ状態構造体へのポインタ</param>
        /// <param name="connectivity">走査した線分の接続性．4または8</param>
        /// <param name="leftToRight">pt1とpt2とは無関係に線分をいつも左から右に走査する(true)か， pt1からpt2への決まった方向で走査するか(false)を指定するフラグ. </param>
        /// <returns></returns> 
#else
        /// <summary>
        /// Initializes line iterator
        /// </summary>
        /// <param name="image">Image to sample the line from.  </param>
        /// <param name="pt1">First ending point of the line segment. </param>
        /// <param name="pt2">Second ending point of the line segment. </param>
        /// <param name="lineIterator">Line iterator state structure to be generated. </param>
        /// <param name="connectivity">The scanned line connectivity, 4 or 8. </param>
        /// <param name="leftToRight">The flag, indicating whether the line should be always scanned from the left-most point to the right-most out of pt1 and pt2 (left_to_right=true), or it is scanned in the specified order, from pt1 to pt2 (left_to_right=false). </param>
        /// <returns>The function cvInitLineIterator initializes the line iterator and returns the number of pixels between two end points. Both points must be inside the image. After the iterator has been initialized, all the points on the raster line that connects the two ending points may be retrieved by successive calls of NextLinePoint point. The points on the line are calculated one by one using 4-connected or 8-connected Bresenham algorithm.</returns> 
#endif
        public static int InitLineIterator(CvArr image, CvPoint pt1, CvPoint pt2, out CvLineIterator lineIterator, PixelConnectivity connectivity, bool leftToRight)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            lineIterator = new CvLineIterator(image, pt1, pt2, connectivity, leftToRight);
            return lineIterator.Count;
        }
        #endregion
        #region InitMatHeader
#if LANG_JP
        /// <summary>
        /// 既に確保された CvMat を初期化する．
        /// </summary>
        /// <param name="mat">初期化する行列のヘッダへの参照</param>
        /// <param name="rows">画像の幅と高さ</param>
        /// <param name="cols">画像のカラーデプス</param>
        /// <param name="type">チャンネル数</param>
        /// <returns>初期化された行列ヘッダ</returns>
#else
        /// <summary>
        /// Initializes matrix header.
        /// </summary>
        /// <param name="mat">Reference to the matrix header to be initialized. </param>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements. </param>
        /// <returns></returns>
#endif
        public static CvMat InitMatHeader(CvMat mat, int rows, int cols, MatrixType type)
        {
            return InitMatHeader<byte>(mat, rows, cols, type, null, CvConst.CV_AUTOSTEP);
        }
#if LANG_JP
        /// <summary>
        /// 既に確保された CvMat を初期化する．
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat">初期化する行列のヘッダへの参照</param>
        /// <param name="rows">画像の幅と高さ</param>
        /// <param name="cols">画像のカラーデプス</param>
        /// <param name="type">チャンネル数</param>
        /// <param name="data">行列のヘッダで指定されるデータ配列. 長さがrows*cols*channelsの1次元配列を指定する.</param>
        /// <returns>初期化された行列ヘッダ</returns>
#else
        /// <summary>
        /// Initializes matrix header.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat">Reference to the matrix header to be initialized. </param>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements. </param>
        /// <param name="data">Optional data pointer assigned to the matrix header. </param>
        /// <returns></returns>
#endif
        public static CvMat InitMatHeader<T>(CvMat mat, int rows, int cols, MatrixType type, T[] data) where T : struct
        {
            return InitMatHeader(mat, rows, cols, type, data, CvConst.CV_AUTOSTEP);
        }
#if LANG_JP
        /// <summary>
        /// 既に確保された CvMat を初期化する．
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat">初期化する行列のヘッダへの参照</param>
        /// <param name="rows">画像の幅と高さ</param>
        /// <param name="cols">画像のカラーデプス</param>
        /// <param name="type">チャンネル数</param>
        /// <param name="data">行列のヘッダで指定されるデータ配列. 長さがrows*cols*channelsの1次元配列を指定する.</param>
        /// <param name="step">割り当てられたデータの行長をバイト単位で表す．デフォルトでは，stepには可能な限り小さい値が用いられる．つまり，行列の連続する行間にギャップが存在しない．</param>
        /// <returns>初期化された行列ヘッダ</returns>
#else
        /// <summary>
        /// Initializes matrix header.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat">Reference to the matrix header to be initialized. </param>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements. </param>
        /// <param name="data">Optional data pointer assigned to the matrix header. </param>
        /// <param name="step">Full row width in bytes of the data assigned. By default, the minimal possible step is used, i.e., no gaps is assumed between subsequent rows of the matrix. </param>
        /// <returns></returns>
#endif
        public static CvMat InitMatHeader<T>(CvMat mat, int rows, int cols, MatrixType type, T[] data, int step) where T : struct
        {
            if (mat == null)
            {
                throw new ArgumentNullException("mat");
            }
            IntPtr result;
            if (data == null)
            {
                result = CvInvoke.cvInitMatHeader(mat.CvPtr, rows, cols, type, IntPtr.Zero, step);
            }
            else
            {
                using (var dataPtr = new ArrayAddress1<T>(data))
                {
                    result = CvInvoke.cvInitMatHeader(mat.CvPtr, rows, cols, type, dataPtr, step);
                }
            }
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvMat(result, false);
        }
        #endregion
        #region InitMatNDHeader
#if LANG_JP
        /// <summary>
        /// 多次元配列のヘッダを初期化する
        /// </summary>
        /// <param name="mat">初期化する配列のヘッダ</param>
        /// <param name="dims">配列の次元数</param>
        /// <param name="sizes">次元サイズの配列</param>
        /// <param name="type">配列要素の種類</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Initializes multi-dimensional array header.
        /// </summary>
        /// <param name="mat">Reference to the array header to be initialized. </param>
        /// <param name="dims">Number of array dimensions. </param>
        /// <param name="sizes">Array of dimension sizes. </param>
        /// <param name="type">Type of array elements. The same as for CvMat. </param>
        /// <returns></returns>
#endif
        public static CvMatND InitMatNDHeader(CvMatND mat, int dims, int[] sizes, MatrixType type)
        {
            return InitMatNDHeader<byte>(mat, dims, sizes, type, null);
        }
#if LANG_JP
        /// <summary>
        /// 多次元配列のヘッダを初期化する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat">初期化する配列のヘッダ</param>
        /// <param name="dims">配列の次元数</param>
        /// <param name="sizes">次元サイズの配列</param>
        /// <param name="type">配列要素の種類</param>
        /// <param name="data">行列のヘッダで指定されるデータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Initializes multi-dimensional array header.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat">Reference to the array header to be initialized. </param>
        /// <param name="dims">Number of array dimensions. </param>
        /// <param name="sizes">Array of dimension sizes. </param>
        /// <param name="type">Type of array elements. The same as for CvMat. </param>
        /// <param name="data">Optional data pointer assigned to the matrix header. </param>
        /// <returns></returns>
#endif
        public static CvMatND InitMatNDHeader<T>(CvMatND mat, int dims, int[] sizes, MatrixType type, T[] data) where T : struct
        {
            if (mat == null)
            {
                throw new ArgumentNullException("mat");
            }
            IntPtr result;
            if (data == null)
            {
                result = CvInvoke.cvInitMatNDHeader(mat.CvPtr, dims, sizes, type, IntPtr.Zero);
            }
            else
            {
                using (var dataPtr = new ArrayAddress1<T>(data))
                {
                    result = CvInvoke.cvInitMatNDHeader(mat.CvPtr, dims, sizes, type, dataPtr);
                }
            }
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvMatND(result, false);
        }
        #endregion
        #region InitSparseMatIterator
#if LANG_JP
        /// <summary>
        /// 疎な配列要素のイテレータを初期化する
        /// </summary>
        /// <param name="mat">入力配列</param>
        /// <param name="matIterator">初期化されるイテレータ</param>
        /// <returns>疎な配列の先頭要素</returns>
#else
        /// <summary>
        /// Initializes sparse array elements iterator
        /// </summary>
        /// <param name="mat">Input array</param>
        /// <param name="matIterator">Initialized iterator</param>
        /// <returns>the first sparse matrix element</returns>
#endif
        public static CvSparseNode InitSparseMatIterator(CvSparseMat mat, out CvSparseMatIterator matIterator)
        {
            if (mat == null)
            {
                throw new ArgumentNullException("mat");
            }
            matIterator = new CvSparseMatIterator();
            return matIterator.Init(mat);
        }
        #endregion
        #region InitSubdivDelaunay2D
#if LANG_JP
        /// <summary>
        /// CvSubdiv2Dの初期化
        /// </summary>
        /// <param name="subdiv"></param>
        /// <param name="rect"></param>
#else
        /// <summary>
        /// CvSubdiv2Dの初期化
        /// </summary>
        /// <param name="subdiv"></param>
        /// <param name="rect"></param>
#endif
        public static void InitSubdivDelaunay2D(CvSubdiv2D subdiv, CvRect rect)
        {
            if (subdiv == null)
            {
                throw new ArgumentNullException("subdiv");
            }
            CvInvoke.cvInitSubdivDelaunay2D(subdiv.CvPtr, rect);
        }
        #endregion
        #region InitTreeNodeIterator
#if LANG_JP
        /// <summary>
        /// ツリーノードのイテレータを初期化する
        /// </summary>
        /// <param name="treeIterator">初期化されるツリーのイテレータ</param>
        /// <param name="first">先頭ノード．ここから走査を開始する．</param>
        /// <param name="maxLevel">ツリー走査範囲の最大レベル（first ノードが第1レベルであると仮定する）．
        /// 例えば，1 はfirstと同じレベルのノードのみが処理されることを意味する， また，2はfirstと同じレベルのノードとその子ノードが処理される．</param>
#else
        /// <summary>
        /// Initializes tree node iterator
        /// </summary>
        /// <param name="treeIterator">Tree iterator initialized by the function. </param>
        /// <param name="first">The initial node to start traversing from. </param>
        /// <param name="maxLevel">The maximal level of the tree (first node assumed to be at the first level) to traverse up to. For example, 1 means that only nodes at the same level as first  should be visited, 2 means that the nodes on the same level as first and their direct children should be visited etc. </param>
#endif
        public static void InitTreeNodeIterator<T>(out CvTreeNodeIterator treeIterator, CvTreeNode<T> first, int maxLevel)
            where T : CvTreeNode<T>
        {
            if (first == null)
                throw new ArgumentNullException("first");
            
            treeIterator = new CvTreeNodeIterator();
            CvInvoke.cvInitTreeNodeIterator(treeIterator, first.CvPtr, maxLevel);
        }
        #endregion
        #region InitUndistortMap
#if LANG_JP
        /// <summary>
        /// 事前に歪み補正マップ（補正画像のすべてのピクセルについて，それぞれ対応する歪み画像のピクセル座標値をもつマップ）を計算する．
        /// その後，マップは入力画像および出力画像と共に，関数 cvRemap に渡すことができる． 
        /// </summary>
        /// <param name="intrinsicMatrix">カメラ内部行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">歪み係数ベクトル．4x1 または 1x4 [k1, k2, p1, p2]. </param>
        /// <param name="mapx">補正マップのx座標の出力配列</param>
        /// <param name="mapy">補正マップのy座標の出力配列</param>
#else
        /// <summary>
        /// Pre-computes the undistortion map - coordinates of the corresponding pixel in the distorted image for every pixel in the corrected image. 
        /// </summary>
        /// <param name="intrinsicMatrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. </param>
        /// <param name="mapx">The output array of x-coordinates of the map. </param>
        /// <param name="mapy">The output array of y-coordinates of the map. </param>
#endif
        public static void InitUndistortMap(CvMat intrinsicMatrix, CvMat distortionCoeffs, CvArr mapx, CvArr mapy)
        {
            if (intrinsicMatrix == null)
                throw new ArgumentNullException("intrinsicMatrix");
            if (distortionCoeffs == null)
                throw new ArgumentNullException("distortionCoeffs");
            if (mapx == null)
                throw new ArgumentNullException("mapx");
            if (mapy == null)
                throw new ArgumentNullException("mapy");
            CvInvoke.cvInitUndistortMap(intrinsicMatrix.CvPtr, distortionCoeffs.CvPtr, mapx.CvPtr, mapy.CvPtr);
        }
        #endregion
        #region InitUndistortRectifyMap
#if LANG_JP
        /// <summary>
        /// ステレオカメラの歪み補正＋平行化の変換マップの計算を行う
        /// </summary>
        /// <param name="cameraMatrix">カメラ行列 A=[fx 0 cx; 0 fy cy; 0 0 1]． </param>
        /// <param name="distCoeffs">歪み係数のベクトル，4x1, 1x4, 5x1, 1x5． </param>
        /// <param name="R">オブジェクト空間における平行化変換（3x3 行列）． cvStereoRectify で計算された値， R1 あるいは R2 が渡される．このパラメータが null の場合，単位行列が用いられる． </param>
        /// <param name="newCameraMatrix">新しいカメラ行列 A'=[fx' 0 cx'; 0 fy' cy'; 0 0 1]． </param>
        /// <param name="mapx">出力配列．マップの x-座標．</param>
        /// <param name="mapy">出力配列．マップの y-座標．</param>
#else
        /// <summary>
        /// Computes undistortion+rectification transformation map a head of stereo camera
        /// </summary>
        /// <param name="cameraMatrix">The camera matrix A=[fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distCoeffs">The vector of distortion coefficients, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="R">The rectification transformation in object space (3x3 matrix). R1 or R2, computed by cvStereoRectify can be passed here. If the parameter is null, the identity matrix is used. </param>
        /// <param name="newCameraMatrix">The new camera matrix A'=[fx' 0 cx'; 0 fy' cy'; 0 0 1]. </param>
        /// <param name="mapx">The output array of x-coordinates of the map. </param>
        /// <param name="mapy">The output array of y-coordinates of the map. </param>
#endif
        public static void InitUndistortRectifyMap(CvMat cameraMatrix, CvMat distCoeffs, CvMat R, CvMat newCameraMatrix, CvArr mapx, CvArr mapy)
        {
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (distCoeffs == null)
                throw new ArgumentNullException("distCoeffs");
            if (newCameraMatrix == null)
                throw new ArgumentNullException("newCameraMatrix");
            if (mapx == null)
                throw new ArgumentNullException("mapx");
            if (mapy == null)
                throw new ArgumentNullException("mapy");
            IntPtr Rptr = (R == null) ? IntPtr.Zero : R.CvPtr;
            CvInvoke.cvInitUndistortRectifyMap(cameraMatrix.CvPtr, distCoeffs.CvPtr, Rptr, newCameraMatrix.CvPtr, mapx.CvPtr, mapy.CvPtr);
        }
        #endregion
        #region Inpaint
#if LANG_JP
        /// <summary>
        /// 配列の要素値が他の二つの配列要素で表される範囲内に位置するかをチェックする
        /// </summary>
        /// <param name="src">入力画像（8ビット，1チャンネルあるいは3チャンネル）．</param>
        /// <param name="mask">修復マスク．8ビット，1チャンネル画像． 非0のピクセルが，修復の必要がある領域であることを示す．</param>
        /// <param name="dst">出力画像（入力画像と同じサイズ，同じタイプ）．</param>
        /// <param name="inpaintRange">修復されるピクセルの円状の隣接領域を示す半径</param>
        /// <param name="flags">修復方法</param>	
#else
        /// <summary>
        /// Inpaints the selected region in the image.
        /// </summary>
        /// <param name="src">The input 8-bit 1-channel or 3-channel image. </param>
        /// <param name="mask">The inpainting mask, 8-bit 1-channel image. Non-zero pixels indicate the area that needs to be inpainted. </param>
        /// <param name="dst">The output image of the same format and the same size as input. </param>
        /// <param name="inpaintRange">The radius of circlular neighborhood of each point inpainted that is considered by the algorithm. </param>
        /// <param name="flags">The inpainting method.</param>
#endif
        public static void Inpaint(CvArr src, CvArr mask, CvArr dst, double inpaintRange, InpaintMethod flags)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (mask == null)
                throw new ArgumentNullException("mask");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvInpaint(src.CvPtr, mask.CvPtr, dst.CvPtr, inpaintRange, flags);
        }
        #endregion
        #region InRange
#if LANG_JP
        /// <summary>
        /// 配列の要素値が他の二つの配列要素で表される範囲内に位置するかをチェックする
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="lower">下限値（その値を含む）を表す配列</param>
        /// <param name="upper">上限値（その値は含まない）を表す配列</param>
        /// <param name="dst">出力配列（タイプは8u または 8s）</param>
#else
        /// <summary>
        /// Checks that array elements lie between elements of two other arrays
        /// </summary>
        /// <param name="src">The first source array. </param>
        /// <param name="lower">The inclusive lower boundary array. </param>
        /// <param name="upper">The exclusive upper boundary array. </param>
        /// <param name="dst">The destination array, must have 8u or 8s type. </param>
#endif
        public static void InRange(CvArr src, CvArr lower, CvArr upper, CvArr dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (lower == null)
                throw new ArgumentNullException("lower");
            if (upper == null)
                throw new ArgumentNullException("upper");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvInRange(src.CvPtr, lower.CvPtr, upper.CvPtr, dst.CvPtr);
        }
        #endregion
        #region InRangeS
#if LANG_JP
        /// <summary>
        /// 配列の要素値が二つのスカラーの間に位置するかをチェックする
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="lower">下限値（その値を含む）</param>
        /// <param name="upper">上限値（その値は含まない）</param>
        /// <param name="dst">出力配列（タイプは8u または 8s）</param>
#else
        /// <summary>
        /// Checks that array elements lie between two scalars
        /// </summary>
        /// <param name="src">The first source array. </param>
        /// <param name="lower">The inclusive lower boundary. </param>
        /// <param name="upper">The exclusive upper boundary. </param>
        /// <param name="dst">The destination array, must have 8u or 8s type. </param>
#endif
        public static void InRangeS(CvArr src, CvScalar lower, CvScalar upper, CvArr dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvInRangeS(src.CvPtr, lower, upper, dst.CvPtr);
        }
        #endregion
        #region InsertNodeIntoTree
#if LANG_JP
        /// <summary>
        /// ツリーに新しいノードを追加する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node">挿入されるノード．</param>
        /// <param name="parent">ツリー内に既に存在している親ノード．</param>
        /// <param name="frame">トップレベルノード．parent と frame が同じである場合， nodeのv_prevフィールドには，parent ではなく，nullがセットされる．</param>
#else
        /// <summary>
        /// Adds new node to the tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node">The inserted node. </param>
        /// <param name="parent">The parent node that is already in the tree. </param>
        /// <param name="frame">The top level node. If parent and frame are the same, v_prev  field of node is set to null rather than parent. </param>
#endif
        public static void InsertNodeIntoTree<T>(CvTreeNode<T> node, CvTreeNode<T> parent, CvTreeNode<T> frame)
            where T : CvTreeNode<T>
        {
            if (node == null)
                throw new ArgumentNullException("node");
            if (parent == null)
                throw new ArgumentNullException("parent");
            if (frame == null)
                throw new ArgumentNullException("frame");
            CvInvoke.cvInsertNodeIntoTree(node.CvPtr, parent.CvPtr, frame.CvPtr);
        }
        #endregion
        #region Integral
#if LANG_JP
        /// <summary>
        /// 任意の矩形領域の画素値の総和を計算する
        /// </summary>
        /// <param name="image">入力画像，W×H，8ビットあるいは浮動小数点(32fか64f)画像．</param>
        /// <param name="sum">インテグラルイメージ（integral image），W+1×H+1，32ビット整数型あるいは倍精度浮動小数点型（64f）． </param>
#else
        /// <summary>
        /// Calculates integral images.
        /// </summary>
        /// <param name="image">The source image, WxH, 8-bit or floating-point (32f or 64f) image. </param>
        /// <param name="sum">The integral image, W+1xH+1, 32-bit integer or double precision floating-point (64f). </param>
#endif
        public static void Integral(CvArr image, CvArr sum)
        {
            Integral(image, sum, null, null);
        }
#if LANG_JP
        /// <summary>
        /// 任意の矩形領域の画素値の総和を計算する
        /// </summary>
        /// <param name="image">入力画像，W×H，8ビットあるいは浮動小数点(32fか64f)画像．</param>
        /// <param name="sum">インテグラルイメージ（integral image），W+1×H+1，32ビット整数型あるいは倍精度浮動小数点型（64f）． </param>
        /// <param name="sqsum">オプション：各ピクセル値を2乗したインテグラルイメージ，W+1×H+1，倍精度浮動小数点型（64f）． </param>
#else
        /// <summary>
        /// Calculates integral images.
        /// </summary>
        /// <param name="image">The source image, WxH, 8-bit or floating-point (32f or 64f) image. </param>
        /// <param name="sum">The integral image, W+1xH+1, 32-bit integer or double precision floating-point (64f). </param>
        /// <param name="sqsum">The integral image for squared pixel values, W+1xH+1, double precision floating-point (64f). </param>
#endif
        public static void Integral(CvArr image, CvArr sum, CvArr sqsum)
        {
            Integral(image, sum, sqsum, null);
        }
#if LANG_JP
        /// <summary>
        /// 任意の矩形領域の画素値の総和を計算する
        /// </summary>
        /// <param name="image">入力画像，W×H，8ビットあるいは浮動小数点(32fか64f)画像．</param>
        /// <param name="sum">インテグラルイメージ（integral image），W+1×H+1，32ビット整数型あるいは倍精度浮動小数点型（64f）． </param>
        /// <param name="sqsum">オプション：各ピクセル値を2乗したインテグラルイメージ，W+1×H+1，倍精度浮動小数点型（64f）． </param>
        /// <param name="tiltedSum">オプション：45度回転させた入力画像のインテグラルイメージ，W+1×H+1，sumと同じデータフォーマット．</param>
#else
        /// <summary>
        /// Calculates integral images.
        /// </summary>
        /// <param name="image">The source image, WxH, 8-bit or floating-point (32f or 64f) image. </param>
        /// <param name="sum">The integral image, W+1xH+1, 32-bit integer or double precision floating-point (64f). </param>
        /// <param name="sqsum">The integral image for squared pixel values, W+1xH+1, double precision floating-point (64f). </param>
        /// <param name="tiltedSum">The integral for the image rotated by 45 degrees, W+1xH+1, the same data type as sum. </param>
#endif
        public static void Integral(CvArr image, CvArr sum, CvArr sqsum, CvArr tiltedSum)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (sum == null)
                throw new ArgumentNullException("sum");
            IntPtr sqsumPtr = (sqsum == null) ? IntPtr.Zero : sqsum.CvPtr;
            IntPtr tiltedSumPtr = (tiltedSum == null) ? IntPtr.Zero : tiltedSum.CvPtr;
            CvInvoke.cvIntegral(image.CvPtr, sum.CvPtr, sqsumPtr, tiltedSumPtr);
        }
        #endregion
        #region Invert
#if LANG_JP
        /// <summary>
        /// 逆行列または擬似逆行列を求める.
        /// </summary>
        /// <param name="src">入力行列</param>
        /// <param name="dst">出力行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds inverse or pseudo-inverse of matrix
        /// </summary>
        /// <param name="src">The source matrix. </param>
        /// <param name="dst">The destination matrix. </param>
        /// <returns>In case of LU method the function returns src1 determinant (src1 must be square). 
        /// If it is 0, the matrix is not inverted and src2 is filled with zeros.
        /// In case of SVD methods the function returns the inverted condition number of src1</returns>
#endif
        public static double Invert(CvArr src, CvArr dst)
        {
            return Invert(src, dst, InvertMethod.LU);
        }
#if LANG_JP
        /// <summary>
        /// 逆行列または擬似逆行列を求める.
        /// </summary>
        /// <param name="src">入力行列</param>
        /// <param name="dst">出力行列</param>
        /// <param name="method">逆行列を求める手法</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds inverse or pseudo-inverse of matrix
        /// </summary>
        /// <param name="src">The source matrix. </param>
        /// <param name="dst">The destination matrix. </param>
        /// <param name="method">Inversion method</param>
        /// <returns>In case of LU method the function returns src1 determinant (src1 must be square). 
        /// If it is 0, the matrix is not inverted and src2 is filled with zeros.
        /// In case of SVD methods the function returns the inverted condition number of src1</returns>
#endif
        public static double Invert(CvArr src, CvArr dst, InvertMethod method)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            return CvInvoke.cvInvert(src.CvPtr, dst.CvPtr, method);
        }
#if LANG_JP
        /// <summary>
        /// 逆行列または擬似逆行列を求める. Invertのエイリアス.
        /// </summary>
        /// <param name="src">入力行列</param>
        /// <param name="dst">出力行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds inverse or pseudo-inverse of matrix
        /// </summary>
        /// <param name="src">The source matrix. </param>
        /// <param name="dst">The destination matrix. </param>
        /// <returns>In case of LU method the function returns src1 determinant (src1 must be square). 
        /// If it is 0, the matrix is not inverted and src2 is filled with zeros.
        /// In case of SVD methods the function returns the inverted condition number of src1</returns>
#endif
        public static double Inv(CvArr src, CvArr dst)
        {
            return Invert(src, dst);
        }
#if LANG_JP
        /// <summary>
        /// 逆行列または擬似逆行列を求める. Invertのエイリアス.
        /// </summary>
        /// <param name="src">入力行列</param>
        /// <param name="dst">出力行列</param>
        /// <param name="method">逆行列を求める手法</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds inverse or pseudo-inverse of matrix
        /// </summary>
        /// <param name="src">The source matrix. </param>
        /// <param name="dst">The destination matrix. </param>
        /// <param name="method">Inversion method</param>
        /// <returns>In case of LU method the function returns src1 determinant (src1 must be square). 
        /// If it is 0, the matrix is not inverted and src2 is filled with zeros.
        /// In case of SVD methods the function returns the inverted condition number of src1</returns>
#endif
        public static double Inv(CvArr src, CvArr dst, InvertMethod method)
        {
            return Invert(src, dst, method);
        }
        #endregion
        #region InvSqrt
#if LANG_JP
        /// <summary>
        /// 引数の平方根の逆数を計算する．
        /// これは，通常，1./sqrt(value)を計算するよりも高速である．
        /// 引数が0または負の値のとき，結果は求まらない．また，特別な値（±Inf, NaN）は扱うことができない．
        /// </summary>
        /// <param name="value">浮動小数点型の入力値</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates inverse square root
        /// </summary>
        /// <param name="value">The input floating-point value </param>
        /// <returns></returns>
#endif
        public static float InvSqrt(float value)
        {
            return (float)(1.0 / Math.Sqrt(value));
        }
        #endregion
        #region IplDepth
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
#endif
        public static BitDepth IplDepth( int type )
        {
            int depth = MAT_DEPTH(type);
            return (BitDepth)(ELEM_SIZE1(depth) * 8 | (int)(depth == CvConst.CV_8S || depth == CvConst.CV_16S || depth == CvConst.CV_32S ? CvConst.IPL_DEPTH_SIGN : 0));
        }
        #endregion
        #region IsInf
#if LANG_JP
        /// <summary>
        /// 引数が±無限大（IEEE754 standard に定義されている）であればtrueを返し，その他の場合はfalseを返す．
        /// </summary>
        /// <param name="value">浮動小数点型の入力値</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Determines if the argument is Infinity
        /// </summary>
        /// <param name="value">The input floating-point value </param>
        /// <returns></returns>
#endif
        public static bool IsInf(double value)
        {
            Cv64suf ieee754;
            ieee754.u = 0;
            ieee754.f = value;
            return ((uint)(ieee754.u >> 32) & 0x7fffffff) == 0x7ff00000 && (uint)ieee754.u == 0;
        }
        #endregion
        #region IsNaN
#if LANG_JP
        /// <summary>
        /// 引数が数値（IEEE754 standard に定義されている）でなければtrueを返し，その他の場合はfalseを返す．
        /// </summary>
        /// <param name="value">浮動小数点型の入力値</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Determines if the argument is Not A Number
        /// </summary>
        /// <param name="value">The input floating-point value </param>
        /// <returns></returns>
#endif
        public static bool IsNaN(double value)
        {
            Cv64suf ieee754;
            ieee754.u = 0;
            ieee754.f = value;
            return ((uint)(ieee754.u >> 32) & 0x7fffffff) + (((uint)ieee754.u != 0) ? 1 : 0) > 0x7ff00000;
        }
        #endregion
    }
}
