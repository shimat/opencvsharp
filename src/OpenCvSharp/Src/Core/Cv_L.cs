/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region Laplace
#if LANG_JP
        /// <summary>
        /// Sobel演算子を用いて計算されたxとyの2次微分を加算することで，入力画像のラプラシアン（Laplacian）を計算する [aperture_size=3]
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Calculates Laplacian of the source image by summing second x- and y- derivatives calculated using Sobel operator.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
#endif
        public static void Laplace(CvArr src, CvArr dst)
        {
            Laplace(src, dst, ApertureSize.Size3);
        }
#if LANG_JP
        /// <summary>
        /// Sobel演算子を用いて計算されたxとyの2次微分を加算することで，入力画像のラプラシアン（Laplacian）を計算する
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="apertureSize">拡張Sobelカーネルのサイズ</param>
#else
        /// <summary>
        /// Calculates Laplacian of the source image by summing second x- and y- derivatives calculated using Sobel operator.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="apertureSize">Aperture size (it has the same meaning as in cvSobel). </param>
#endif
        public static void Laplace(CvArr src, CvArr dst, ApertureSize apertureSize)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvLaplace(src.CvPtr, dst.CvPtr, apertureSize);
        }
        #endregion
        #region LatentSvmDetectObjects
#if LANG_JP
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image"></param>
        /// <param name="detector"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image">image to detect objects in</param>
        /// <param name="detector">Latent SVM detector in internal representation</param>
        /// <param name="storage">memory storage to store the resultant sequence of the object candidate rectangles</param>
        /// <returns></returns>
#endif
        public static CvSeq<CvObjectDetection> LatentSvmDetectObjects(IplImage image, CvLatentSvmDetector detector, CvMemStorage storage)
        {
            return LatentSvmDetectObjects(image, detector, storage, 0.5f, -1);
        }
#if LANG_JP
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image"></param>
        /// <param name="detector"></param>
        /// <param name="storage"></param>
        /// <param name="overlapThreshold"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image">image to detect objects in</param>
        /// <param name="detector">Latent SVM detector in internal representation</param>
        /// <param name="storage">memory storage to store the resultant sequence of the object candidate rectangles</param>
        /// <param name="overlapThreshold">threshold for the non-maximum suppression algorithm 
        ///  = 0.5f [here will be the reference to original paper]</param>
        /// <returns></returns>
#endif
        public static CvSeq<CvObjectDetection> LatentSvmDetectObjects(IplImage image, CvLatentSvmDetector detector, CvMemStorage storage, float overlapThreshold)
        {
            return LatentSvmDetectObjects(image, detector, storage, overlapThreshold, -1);
        }
#if LANG_JP
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image"></param>
        /// <param name="detector"></param>
        /// <param name="storage"></param>
        /// <param name="overlapThreshold"></param>
        /// <param name="numThreads"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image">image to detect objects in</param>
        /// <param name="detector">Latent SVM detector in internal representation</param>
        /// <param name="storage">memory storage to store the resultant sequence of the object candidate rectangles</param>
        /// <param name="overlapThreshold">threshold for the non-maximum suppression algorithm 
        ///  = 0.5f [here will be the reference to original paper]</param>
        /// <param name="numThreads"></param>
        /// <returns></returns>
#endif
        public static CvSeq<CvObjectDetection> LatentSvmDetectObjects(IplImage image, CvLatentSvmDetector detector, CvMemStorage storage, float overlapThreshold, int numThreads)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (detector == null)
                throw new ArgumentNullException("detector");
            if (storage == null)
                throw new ArgumentNullException("storage");

            IntPtr p = CvInvoke.cvLatentSvmDetectObjects(image.CvPtr, detector.CvPtr, storage.CvPtr, overlapThreshold, numThreads);
            if (p == IntPtr.Zero)
                return null;
            else
                return new CvSeq<CvObjectDetection>(p);
        }
        #endregion
        #region Line
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
#endif
        public static void Line(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color)
        {
            Line(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
#endif
        public static void Line(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness)
        {
            Line(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
#endif
        public static void Line(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType)
        {
            Line(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public static void Line(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Line(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
#endif
        public static void Line(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color)
        {
            Line(img, pt1, pt2, color, 1, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
#endif
        public static void Line(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness)
        {
            Line(img, pt1, pt2, color, thickness, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
#endif
        public static void Line(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType)
        {
            Line(img, pt1, pt2, color, thickness, lineType, 0);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public static void Line(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType, int shift)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            
            CvInvoke.cvLine(img.CvPtr, pt1, pt2, color, thickness, lineType, shift);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
#endif
        public static void DrawLine(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color)
        {
            Line(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
#endif
        public static void DrawLine(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness)
        {
            Line(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
#endif
        public static void DrawLine(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType)
        {
            Line(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public static void DrawLine(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Line(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
#endif
        public static void DrawLine(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color)
        {
            Line(img, pt1, pt2, color, 1, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
#endif
        public static void DrawLine(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness)
        {
            Line(img, pt1, pt2, color, thickness, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
#endif
        public static void DrawLine(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType)
        {
            Line(img, pt1, pt2, color, thickness, lineType, 0);
        }
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ</param>
        /// <param name="lineType">線分の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. </param>
        /// <param name="lineType">Type of the line.</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public static void DrawLine(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Line(img, pt1, pt2, color, thickness, lineType, shift);
        }
        #endregion
        #region LinearPolar
#if LANG_JP
        /// <summary>
        /// Performs forward or inverse linear-polar image transform
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="center"></param>
        /// <param name="maxRadius"></param>
#else
        /// <summary>
        /// Performs forward or inverse linear-polar image transform
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="center"></param>
        /// <param name="maxRadius"></param>
#endif
        public static void LinearPolar(CvArr src, CvArr dst, CvPoint2D32f center, double maxRadius)
        {
            LinearPolar(src, dst, center, maxRadius, Interpolation.Linear | Interpolation.FillOutliers);
        }
#if LANG_JP
        /// <summary>
        /// Performs forward or inverse linear-polar image transform
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="center"></param>
        /// <param name="maxRadius"></param>
        /// <param name="flags"></param>
#else
        /// <summary>
        /// Performs forward or inverse linear-polar image transform
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="center"></param>
        /// <param name="maxRadius"></param>
        /// <param name="flags"></param>
#endif
        public static void LinearPolar(CvArr src, CvArr dst, CvPoint2D32f center, double maxRadius, Interpolation flags)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            CvInvoke.cvLinearPolar(src.CvPtr, dst.CvPtr, center, maxRadius, flags);
        }
        #endregion
        #region Load
#if LANG_JP
         /// <summary>
        /// オブジェクトをファイルから読み込む
        /// </summary>
        /// <typeparam name="T">読み込むオブジェクトの型</typeparam>
        /// <param name="filename">ファイル名</param>
        /// <returns>読み込んだオブジェクト</returns>
#else
        /// <summary>
        /// Loads object from file
        /// </summary>
        /// <typeparam name="T">Object type to load</typeparam>
        /// <param name="filename">File name. </param>
        /// <returns>The function cvLoad loads object from file.</returns>
#endif     
        public static T Load<T>(string filename) where T : ICvPtrHolder
        {
            string realName;
            return Load<T>(filename, null, null, out realName);
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルから読み込む
        /// </summary>
        /// <typeparam name="T">読み込むオブジェクトの型</typeparam>
        /// <param name="filename">ファイル名</param>
        /// <param name="memstorage">CvSeqやCvGraph  などの動的構造体のためのメモリストレージ．行列や画像には用いられない．</param>
        /// <returns>読み込んだオブジェクト</returns>
#else
        /// <summary>
        /// Loads object from file
        /// </summary>
        /// <typeparam name="T">Object type to load</typeparam>
        /// <param name="filename">File name. </param>
        /// <param name="memstorage">Memory storage for dynamic structures, such as CvSeq  or CvGraph. It is not used for matrices or images. </param>
        /// <returns>The function cvLoad loads object from file.</returns>
#endif     
        public static T Load<T>(string filename, CvMemStorage memstorage) where T : ICvPtrHolder
        {
            string realName;
            return Load<T>(filename, memstorage, null, out realName);
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルから読み込む
        /// </summary>
        /// <typeparam name="T">読み込むオブジェクトの型</typeparam>
        /// <param name="filename">ファイル名</param>
        /// <param name="memstorage">CvSeqやCvGraph  などの動的構造体のためのメモリストレージ．行列や画像には用いられない．</param>
        /// <param name="name">オブジェクト名（オプション）．nullの場合，ファイルストレージにある最初のトップレベルオブジェクトが読み込まれる． </param>
        /// <returns>読み込んだオブジェクト</returns>
#else
        /// <summary>
        /// Loads object from file
        /// </summary>
        /// <typeparam name="T">Object type to load</typeparam>
        /// <param name="filename">File name. </param>
        /// <param name="memstorage">Memory storage for dynamic structures, such as CvSeq  or CvGraph. It is not used for matrices or images. </param>
        /// <param name="name">Optional object name. If it is NULL, the first top-level object in the storage will be loaded. </param>
        /// <returns>The function cvLoad loads object from file.</returns>
#endif 
        public static T Load<T>(string filename, CvMemStorage memstorage, string name) where T : ICvPtrHolder
        {
            string realName;
            return Load<T>(filename, memstorage, name, out realName);
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルから読み込む
        /// </summary>
        /// <typeparam name="T">読み込むオブジェクトの型</typeparam>
        /// <param name="filename">ファイル名</param>
        /// <param name="memstorage">CvSeqやCvGraphなどの動的構造体のためのメモリストレージ．行列や画像には用いられない．</param>
        /// <param name="name">オブジェクト名（オプション）．nullの場合，ファイルストレージにある最初のトップレベルオブジェクトが読み込まれる． </param>
        /// <param name="realName">読み込まれたオブジェクトの名前が代入される出力パラメータ（オプション）name=nullの場合に役立つ． </param>
        /// <returns>読み込んだオブジェクト</returns>
#else
        /// <summary>
        /// Loads object from file
        /// </summary>
        /// <typeparam name="T">Object type to load</typeparam>
        /// <param name="filename">File name. </param>
        /// <param name="memstorage">Memory storage for dynamic structures, such as CvSeq  or CvGraph. It is not used for matrices or images. </param>
        /// <param name="name">Optional object name. If it is NULL, the first top-level object in the storage will be loaded. </param>
        /// <param name="realName">Optional output parameter that will contain name of the loaded object (useful if name=NULL).  </param>
        /// <returns>The function cvLoad loads object from file.</returns>
#endif
        public static T Load<T>(string filename, CvMemStorage memstorage, string name, out string realName) where T : ICvPtrHolder
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            if (!File.Exists(filename))
                throw new FileNotFoundException("", filename);

            IntPtr memstoragePtr = (memstorage == null) ? IntPtr.Zero : memstorage.CvPtr;
            StringBuilder realNameSb = new StringBuilder(1024);
            IntPtr result = CvInvoke.cvLoad(filename, memstoragePtr, name, realNameSb);
            realName = realNameSb.ToString();
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
        #region LoadHaarClassifierCascade
#if LANG_JP
        /// <summary>
        /// ファイルまたはOpenCV 内に組み込まれた分類器データベースから，学習されたカスケード分類器を読み込む 
        /// </summary>
        /// <param name="directory">学習されたカスケード分類器の記述を含むディレクトリ名． </param>
        /// <param name="origWindowSize">オブジェクトのオリジナルサイズ（カスケード分類器はこのサイズに合わせて学習される）． これはカスケード分類器内に保存されないので，別に指定する必要がある事に注意． </param>
        /// <returns></returns>
        /// <remarks>この関数は，もはやサポートされない．現在では，オブジェクト検出分類器はディレクトリではなく XML/YAML ファイルに保存される． カスケードをファイルから読み込むためには，関数 cvLoad を用いる．</remarks>
#else
        /// <summary>
        /// Loads a trained cascade classifier from file or the classifier database embedded in OpenCV
        /// </summary>
        /// <param name="directory">Name of directory containing the description of a trained cascade classifier. </param>
        /// <param name="origWindowSize">Original size of objects the cascade has been trained on. Note that it is not stored in the cascade and therefore must be specified separately. </param>
        /// <returns></returns>
        /// <remarks>The function is obsolete. Nowadays object detection classifiers are stored in XML or YAML files, rather than in directories. To load cascade from a file, use cvLoad function. </remarks>
#endif
        [Obsolete]
        public static CvHaarClassifierCascade LoadHaarClassifierCascade(string directory, CvSize origWindowSize)
        {
            return CvHaarClassifierCascade.FromDirectory(directory, origWindowSize);
        }
        #endregion
        #region LoadImage
#if LANG_JP
        /// <summary>
        /// 指定されたファイルから画像を読み込み，その画像の参照を返す
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <returns>画像への参照</returns>
#else
        /// <summary>
        /// Loads an image from the specified file and returns the reference to the loaded image. 
        /// </summary>
        /// <param name="filename">Name of file to be loaded. </param>
        /// <returns>the reference to the loaded image. </returns>
#endif
        public static IplImage LoadImage(string filename)
        {
            return LoadImage(filename, LoadMode.Color);
        }
#if LANG_JP
        /// <summary>
        /// 指定されたファイルから画像を読み込み，その画像の参照を返す
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <param name="flags">読み込む画像がカラー/グレースケールのどちらか，とビット深度を指定する</param>
        /// <returns>画像への参照</returns>
#else
        /// <summary>
        /// Loads an image from the specified file and returns the reference to the loaded image. 
        /// </summary>
        /// <param name="filename">Name of file to be loaded. </param>
        /// <param name="flags">Specifies colorness and Depth of the loaded image.</param>
        /// <returns>the reference to the loaded image. </returns>
#endif
        public static IplImage LoadImage(string filename, LoadMode flags)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            if (!File.Exists(filename))
                throw new FileNotFoundException("", filename);
            IntPtr ptr = CvInvoke.cvLoadImage(filename, flags);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new IplImage(ptr);
        }
        #endregion
        #region LoadImageM
#if LANG_JP
        /// <summary>
        /// 指定されたファイルから画像を読み込み，その画像の参照をCvMat形式で返す
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <returns>画像への参照</returns>
#else
        /// <summary>
        /// Loads an image from the specified file and returns the reference to the loaded image as CvMat. 
        /// </summary>
        /// <param name="filename">Name of file to be loaded. </param>
        /// <returns>the reference to the loaded image. </returns>
#endif
        public static CvMat LoadImageM(string filename)
        {
            return LoadImageM(filename, LoadMode.Color);
        }
#if LANG_JP
        /// <summary>
        /// 指定されたファイルから画像を読み込み，その画像の参照をCvMat形式で返す
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <param name="flags">読み込む画像がカラー/グレースケールのどちらか，とビット深度を指定する</param>
        /// <returns>画像への参照</returns>
#else
        /// <summary>
        /// Loads an image from the specified file and returns the reference to the loaded image as CvMat. 
        /// </summary>
        /// <param name="filename">Name of file to be loaded. </param>
        /// <param name="flags">Specifies colorness and Depth of the loaded image.</param>
        /// <returns>the reference to the loaded image. </returns>
#endif
        public static CvMat LoadImageM(string filename, LoadMode flags)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            if (!File.Exists(filename))
                throw new FileNotFoundException("", filename);
            IntPtr ptr = CvInvoke.cvLoadImageM(filename, flags);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvMat(ptr);
        }
        #endregion
        #region LoadLatentSvmDetector
#if LANG_JP
        /// <summary>
        /// load trained detector from a file
        /// </summary>
        /// <param name="filename">Name of file to be loaded. </param>
        /// <returns></returns>
#else
        /// <summary>
        /// load trained detector from a file
        /// </summary>
        /// <param name="filename">Name of file to be loaded. </param>
        /// <returns></returns>
#endif
        public static CvLatentSvmDetector LoadLatentSvmDetector(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            if (!File.Exists(filename))
                throw new FileNotFoundException("", filename);
            IntPtr ptr = CvInvoke.cvLoadLatentSvmDetector(filename);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvLatentSvmDetector(ptr);
        }
        #endregion
        #region LoadWindowParameters
#if LANG_JP
        /// <summary>
        /// ウィンドウのパラメータを読み込みます．
        /// </summary>
        /// <param name="name">ウィンドウの名前</param>
#else
        /// <summary>
        /// Load parameters of the window.
        /// </summary>
        /// <param name="name">Name of the window</param>
#endif
        public static void LoadWindowParameters(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            CvInvoke.cvLoadWindowParameters(name);
        }
        #endregion
        #region Log
#if LANG_JP
        /// <summary>
        /// すべての配列要素の絶対値の自然対数を計算する
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列．倍精度の浮動小数点型（double），または入力配列と同じタイプでなければならない．</param>
#else
        /// <summary>
        /// Calculates natural logarithm of every array element absolute value
        /// </summary>
        /// <param name="src">The source array. </param>
        /// <param name="dst">The destination array, it should have double type or the same type as the source. </param>
#endif
        public static void Log(CvArr src, CvArr dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvLog(src.CvPtr, dst.CvPtr);
        }
        #endregion
        #region LogPolar
#if LANG_JP
        /// <summary>
        /// 画像を対数極座標（Log-Polar）空間に再マッピングする.
        /// この関数は人間の網膜をモデル化したものであり，オブジェクトトラッキング等のための高速なスケーリングと，
        /// 回転に不変なテンプレートマッチングに用いることができる．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="center">出力精度が最大となるような変換の中心座標</param>
        /// <param name="M">スケーリング係数の大きさ</param>
#else
        /// <summary>
        /// Remaps image to log-polar space.
        /// The function emulates the human "foveal" vision and can be used for fast scale and rotation-invariant template matching, for object tracking etc.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="center">The transformation center, where the output precision is maximal. </param>
        /// <param name="M">Magnitude scale parameter. See below. </param>
#endif
        public static void LogPolar(CvArr src, CvArr dst, CvPoint2D32f center, double M)
        {
            LogPolar(src, dst, center, M, Interpolation.Linear | Interpolation.FillOutliers);
        }
#if LANG_JP
        /// <summary>
        /// 画像を対数極座標（Log-Polar）空間に再マッピングする. 
        /// この関数は人間の網膜をモデル化したものであり，オブジェクトトラッキング等のための高速なスケーリングと，
        /// 回転に不変なテンプレートマッチングに用いることができる．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="center">出力精度が最大となるような変換の中心座標</param>
        /// <param name="M">スケーリング係数の大きさ</param>
        /// <param name="flags">補間方法</param>
#else
        /// <summary>
        /// Remaps image to log-polar space.
        /// The function emulates the human "foveal" vision and can be used for fast scale and rotation-invariant template matching, for object tracking etc.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="center">The transformation center, where the output precision is maximal. </param>
        /// <param name="M">Magnitude scale parameter. See below. </param>
        /// <param name="flags">A combination of interpolation method and the optional flags.</param>
#endif
        public static void LogPolar(CvArr src, CvArr dst, CvPoint2D32f center, double M, Interpolation flags)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvLogPolar(src.CvPtr, dst.CvPtr, center, M, flags);
        }
        #endregion
        #region LSHAdd
#if LANG_JP
        /// <summary>
        /// Add vectors to the LSH structure, optionally returning indices.
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="data"></param>
#else
        /// <summary>
        /// Add vectors to the LSH structure, optionally returning indices.
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="data"></param>
#endif
        public static void LSHAdd(CvLSH lsh, CvMat data)
        {
            LSHAdd(lsh, data, null);
        }
#if LANG_JP
        /// <summary>
        /// Add vectors to the LSH structure, optionally returning indices.
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="data"></param>
        /// <param name="indices"></param>
#else
        /// <summary>
        /// Add vectors to the LSH structure, optionally returning indices.
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="data"></param>
        /// <param name="indices"></param>
#endif
        public static void LSHAdd(CvLSH lsh, CvMat data, CvMat indices)
        {
            if (lsh == null)
            {
                throw new ArgumentNullException("lsh");
            }
            IntPtr indicesPtr = (indices == null) ? IntPtr.Zero : indices.CvPtr;

            CvInvoke.cvLSHAdd(lsh.CvPtr, data.CvPtr, indicesPtr);
        }
        #endregion
        #region LSHQuery
#if LANG_JP
        /// <summary>
        /// Query the LSH n times for at most k nearest points; data is n x d,
        /// indices and dist are n x k. At most emax stored points will be accessed. 
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="queryPoints"></param>
        /// <param name="indices"></param>
        /// <param name="dist"></param>
        /// <param name="k"></param>
        /// <param name="emax"></param>
#else
        /// <summary>
        /// Query the LSH n times for at most k nearest points; data is n x d,
        /// indices and dist are n x k. At most emax stored points will be accessed. 
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="queryPoints"></param>
        /// <param name="indices"></param>
        /// <param name="dist"></param>
        /// <param name="k"></param>
        /// <param name="emax"></param>
#endif
        public static void LSHQuery(CvLSH lsh, CvMat queryPoints, CvMat indices, CvMat dist, int k, int emax)
        {
            if (lsh == null)
                throw new ArgumentNullException("lsh");
            if (queryPoints == null)
                throw new ArgumentNullException("queryPoints");
            if (indices == null)
                throw new ArgumentNullException("indices");
            if (dist == null)
                throw new ArgumentNullException("dist");
            CvInvoke.cvLSHQuery(lsh.CvPtr, queryPoints.CvPtr, indices.CvPtr, dist.CvPtr, k, emax);
        }
        #endregion
        #region LSHRemove
#if LANG_JP
        /// <summary>
        /// Remove vectors from LSH, as addressed by given indices.
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="indices"></param>
#else
        /// <summary>
        /// Remove vectors from LSH, as addressed by given indices.
        /// </summary>
        /// <param name="lsh"></param>
        /// <param name="indices"></param>
#endif
        public static void LSHRemove(CvLSH lsh, CvMat indices)
        {
            if (lsh == null)
                throw new ArgumentNullException("lsh");
            if (indices == null)
                throw new ArgumentNullException("indices");

            CvInvoke.cvLSHRemove(lsh.CvPtr, indices.CvPtr);
        }
        #endregion
        #region LSHSize
#if LANG_JP
        /// <summary>
        /// Return the number of vectors in the LSH.
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns>number of vectors</returns>
#else
        /// <summary>
        /// Return the number of vectors in the LSH.
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns>number of vectors</returns>
#endif
        public static uint LSHSize(CvLSH lsh)
        {
            if (lsh == null)
            {
                throw new ArgumentNullException("lsh");
            }
            return CvInvoke.LSHSize(lsh.CvPtr);
        }
        #endregion
        #region LUT
#if LANG_JP
        /// <summary>
        /// 出力配列の各要素値をルックアップテーブルを用いて決定する．
        /// </summary>
        /// <param name="src">入力配列（各要素は8ビットデータ）．</param>
        /// <param name="dst">出力配列（任意のデプス，入力配列と同じチャンネル数）．</param>
        /// <param name="lut">要素数が256であるルックアップテーブル（出力配列と同じデプスでなければならない）．マルチチャンネルの入力/出力配列の場合，テーブルはシングルチャンネル（この場合すべてのチャンネル対して，同じテーブルを使う）か，入力/出力配列と同じチャンネル数でなければならない．</param>
#else
        /// <summary>
        /// Performs look-up table transform of array
        /// </summary>
        /// <param name="src">Source array of 8-bit elements. </param>
        /// <param name="dst">Destination array of arbitrary depth and of the same number of channels as the source array. </param>
        /// <param name="lut">Look-up table of 256 elements; should have the same depth as the destination array. In case of multi-channel source and destination arrays, the table should either have a single-channel (in this case the same table is used for all channels), or the same number of channels as the source/destination array. </param>
#endif
        public static void LUT(CvArr src, CvArr dst, CvArr lut)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (lut == null)
                throw new ArgumentNullException("lut");
            CvInvoke.cvLUT(src.CvPtr, dst.CvPtr, lut.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 出力配列の各要素値をルックアップテーブルを用いて決定する．ルックアップテーブルが配列で指定できる簡易バージョン.
        /// </summary>
        /// <param name="src">入力配列（各要素は8ビットデータ）</param>
        /// <param name="dst">出力配列（任意のデプス，入力配列と同じチャンネル数）</param>
        /// <param name="lut">要素数が256であるルックアップテーブル</param>
#else
        /// <summary>
        /// Performs look-up table transform of array
        /// </summary>
        /// <param name="src">Source array of 8-bit elements. </param>
        /// <param name="dst">Destination array of arbitrary depth and of the same number of channels as the source array. </param>
        /// <param name="lut">Look-up table of 256 elements; should have the same depth as the destination array. </param>
#endif
        public static void LUT(CvArr src, CvArr dst, byte[] lut)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (lut == null)
                throw new ArgumentNullException("lut");
            if (lut.Length != 256)
                throw new ArgumentOutOfRangeException("lut", "lut.Length must be 256");

            using (CvMat lutMat = new CvMat(256, 1, MatrixType.U8C1, lut))
            {
                CvInvoke.cvLUT(src.CvPtr, dst.CvPtr, lutMat.CvPtr);
            }
        }
#if LANG_JP
        /// <summary>
        /// 出力配列の各要素値をルックアップテーブルを用いて決定する．ルックアップテーブルが配列で指定できる簡易バージョン.
        /// </summary>
        /// <param name="src">入力配列（各要素は8ビットデータ）</param>
        /// <param name="dst">出力配列（任意のデプス，入力配列と同じチャンネル数）</param>
        /// <param name="lut">要素数が256であるルックアップテーブル</param>
#else
        /// <summary>
        /// Performs look-up table transform of array
        /// </summary>
        /// <param name="src">Source array of 8-bit elements. </param>
        /// <param name="dst">Destination array of arbitrary depth and of the same number of channels as the source array. </param>
        /// <param name="lut">Look-up table of 256 elements; should have the same depth as the destination array. </param>
#endif
        public static void LUT(CvArr src, CvArr dst, short[] lut)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (lut == null)
                throw new ArgumentNullException("lut");
            if (lut.Length != 256)
                throw new ArgumentOutOfRangeException("lut", "lut.Length must be 256");

            using (CvMat lutMat = new CvMat(256, 1, MatrixType.S16C1, lut))
            {
                CvInvoke.cvLUT(src.CvPtr, dst.CvPtr, lutMat.CvPtr);
            }
        }
#if LANG_JP
        /// <summary>
        /// 出力配列の各要素値をルックアップテーブルを用いて決定する．ルックアップテーブルが配列で指定できる簡易バージョン.
        /// </summary>
        /// <param name="src">入力配列（各要素は8ビットデータ）</param>
        /// <param name="dst">出力配列（任意のデプス，入力配列と同じチャンネル数）</param>
        /// <param name="lut">要素数が256であるルックアップテーブル</param>
#else
        /// <summary>
        /// Performs look-up table transform of array
        /// </summary>
        /// <param name="src">Source array of 8-bit elements. </param>
        /// <param name="dst">Destination array of arbitrary depth and of the same number of channels as the source array. </param>
        /// <param name="lut">Look-up table of 256 elements; should have the same depth as the destination array. </param>
#endif
        public static void LUT(CvArr src, CvArr dst, int[] lut)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (lut == null)
                throw new ArgumentNullException("lut");
            if (lut.Length != 256)
                throw new ArgumentOutOfRangeException("lut", "lut.Length must be 256");

            using (CvMat lutMat = new CvMat(256, 1, MatrixType.S32C1, lut))
            {
                CvInvoke.cvLUT(src.CvPtr, dst.CvPtr, lutMat.CvPtr);
            }
        }
#if LANG_JP
        /// <summary>
        /// 出力配列の各要素値をルックアップテーブルを用いて決定する．ルックアップテーブルが配列で指定できる簡易バージョン.
        /// </summary>
        /// <param name="src">入力配列（各要素は8ビットデータ）</param>
        /// <param name="dst">出力配列（任意のデプス，入力配列と同じチャンネル数）</param>
        /// <param name="lut">要素数が256であるルックアップテーブル</param>
#else
        /// <summary>
        /// Performs look-up table transform of array
        /// </summary>
        /// <param name="src">Source array of 8-bit elements. </param>
        /// <param name="dst">Destination array of arbitrary depth and of the same number of channels as the source array. </param>
        /// <param name="lut">Look-up table of 256 elements; should have the same depth as the destination array. </param>
#endif
        public static void LUT(CvArr src, CvArr dst, float[] lut)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (lut == null)
                throw new ArgumentNullException("lut");
            if (lut.Length != 256)
                throw new ArgumentOutOfRangeException("lut", "lut.Length must be 256");

            using (CvMat lutMat = new CvMat(256, 1, MatrixType.F32C1, lut))
            {
                CvInvoke.cvLUT(src.CvPtr, dst.CvPtr, lutMat.CvPtr);
            }
        }
#if LANG_JP
        /// <summary>
        /// 出力配列の各要素値をルックアップテーブルを用いて決定する．ルックアップテーブルが配列で指定できる簡易バージョン.
        /// </summary>
        /// <param name="src">入力配列（各要素は8ビットデータ）</param>
        /// <param name="dst">出力配列（任意のデプス，入力配列と同じチャンネル数）</param>
        /// <param name="lut">要素数が256であるルックアップテーブル</param>
#else
        /// <summary>
        /// Performs look-up table transform of array
        /// </summary>
        /// <param name="src">Source array of 8-bit elements. </param>
        /// <param name="dst">Destination array of arbitrary depth and of the same number of channels as the source array. </param>
        /// <param name="lut">Look-up table of 256 elements; should have the same depth as the destination array. </param>
#endif
        public static void LUT(CvArr src, CvArr dst, double[] lut)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (lut == null)
                throw new ArgumentNullException("lut");
            if (lut.Length != 256)
                throw new ArgumentOutOfRangeException("lut", "lut.Length must be 256");

            using (CvMat lutMat = new CvMat(256, 1, MatrixType.F64C1, lut))
            {
                CvInvoke.cvLUT(src.CvPtr, dst.CvPtr, lutMat.CvPtr);
            }
        }
        #endregion
    }
}
