using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591
#pragma warning disable 1685


namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// 拡張メソッドをコンパイルするのに必要となるExtensionAttributeの宣言
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ExtensionAttribute : Attribute
    {
    }
}


namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
#else
    /// <summary>
    /// 
    /// </summary>
#endif
    public static class CvCpp
    {
        #region Helper Method
        /// <summary>
        /// 引数がnullの時はIntPtr.Zeroに変換する
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static IntPtr ToPtr(ICvPtrHolder obj)
        {
            return (obj == null) ? IntPtr.Zero : obj.CvPtr;
        }
        #endregion

        #region cv
        #region Miscellaneous Functions
        /// <summary>
        /// Default borderValue for Dilate/Erode
        /// </summary>
        /// <returns></returns>
        public static CvScalar MorphologyDefaultBorderValue()
        {
            return CvScalar.ScalarAll(double.MaxValue);
        }
        #endregion

        #region Canny
#if LANG_JP
        /// <summary>
        /// Cannyアルゴリズムを用いて，画像のエッジを検出します．
        /// </summary>
        /// <param name="image">8ビット，シングルチャンネルの入力画像</param>
        /// <param name="edges">出力されるエッジのマップ． image  と同じサイズ，同じ型</param>
        /// <param name="threshold1">ヒステリシスが存在する処理の，1番目の閾値</param>
        /// <param name="threshold2">ヒステリシスが存在する処理の，2番目の閾値</param>
        /// <param name="apertureSize">Sobelオペレータのアパーチャサイズ [既定値はApertureSize.Size3]</param>
        /// <param name="L2gradient">画像勾配の強度を求めるために，より精度の高い L2ノルムを利用するか，L1ノルムで十分（false）かを指定します. [既定値はfalse]</param>
#else
        /// <summary>
        /// Finds edges in an image using Canny algorithm.
        /// </summary>
        /// <param name="image">Single-channel 8-bit input image</param>
        /// <param name="edges">The output edge map. It will have the same size and the same type as image</param>
        /// <param name="threshold1">The first threshold for the hysteresis procedure</param>
        /// <param name="threshold2">The second threshold for the hysteresis procedure</param>
        /// <param name="apertureSize">Aperture size for the Sobel operator [By default this is ApertureSize.Size3]</param>
        /// <param name="L2gradient">Indicates, whether the more accurate L2 norm should be used to compute the image gradient magnitude (true), or a faster default L1 norm is enough (false). [By default this is false]</param>
#endif
        public static void Canny(Mat image, Mat edges, double threshold1, double threshold2, ApertureSize apertureSize = ApertureSize.Size3, bool L2gradient = false)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (edges == null)
                throw new ArgumentNullException("edges");
            CppInvoke.cv_Canny(image.CvPtr, edges.CvPtr, threshold1, threshold2, apertureSize, L2gradient);
        }
        #endregion
        public static void ConvertMaps(Mat map1, Mat map2, Mat dstmap1, Mat dstmap2, MatrixType dstmap1type, bool nninterpolation = false)
        {
            if (map1 == null)
                throw new ArgumentNullException("map1");
            if (map2 == null)
                throw new ArgumentNullException("map2");
            if (dstmap1 == null)
                throw new ArgumentNullException("dstmap1");
            if (dstmap2 == null)
                throw new ArgumentNullException("dstmap2");

            CppInvoke.cv_convertMaps(map1.CvPtr, map2.CvPtr, dstmap1.CvPtr, dstmap2.CvPtr, dstmap1type, nninterpolation);
        }
        public static void CornerEigenValsAndVecs(Mat src, Mat dst, int blockSize, int ksize, BorderType borderType = BorderType.Constant)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            CppInvoke.cv_cornerEigenValsAndVecs(src.CvPtr, dst.CvPtr, blockSize, ksize, borderType);
        }
        public static void CornerHarris(Mat src, Mat dst, int blockSize, int ksize, double k, BorderType borderType = BorderType.Constant)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            CppInvoke.cv_cornerHarris(src.CvPtr, dst.CvPtr, blockSize, ksize, k, borderType);
        }
        public static CvPoint2D32f[] CornerSubPix(Mat image, CvSize winSize, CvSize zeroZone, CvTermCriteria criteria)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            using (StdVectorVec2f vec = new StdVectorVec2f())
            {
                CppInvoke.cv_cornerSubPix(image.CvPtr, vec.CvPtr, winSize, zeroZone, criteria);
                return vec.ToArray<CvPoint2D32f>();
            }
        }
        #region CvtColor
#if LANG_JP
        /// <summary>
        /// 画像の色空間を変換します．
        /// </summary>
        /// <param name="src">8ビット符号なし整数型，16ビット符号なし整数型，または単精度浮動小数型の入力画像</param>
        /// <param name="dst">src と同じサイズ，同じタイプの出力画像</param>
        /// <param name="code">色空間の変換コード．</param>
        /// <param name="dstCn">出力画像のチャンネル数．この値が 0 の場合，チャンネル数は src と code から自動的に求められます</param>
#else
        /// <summary>
        /// Converts image from one color space to another
        /// </summary>
        /// <param name="src">The source image, 8-bit unsigned, 16-bit unsigned or single-precision floating-point</param>
        /// <param name="dst">The destination image; will have the same size and the same depth as src</param>
        /// <param name="code">The color space conversion code</param>
        /// <param name="dstCn">The number of channels in the destination image; if the parameter is 0, the number of the channels will be derived automatically from src and the code</param>
#endif
        public static void CvtColor(Mat src, Mat dst, ColorConversion code, int dstCn = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CppInvoke.cv_cvtColor(src.CvPtr, dst.CvPtr, code, dstCn);
        }
        #endregion
        #region Dilate
#if LANG_JP
        /// <summary>
        /// 指定の構造要素を用いて画像の膨張を行います．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">src と同じサイズ，同じ型の出力画像</param>
        /// <param name="element">膨張に用いられる構造要素． element=new Mat()  の場合， 3x3 の矩形構造要素が用いられます</param>
        /// <param name="anchor">構造要素内のアンカー位置．デフォルト値の (-1, -1) は，アンカーが構造要素の中心にあることを意味します</param>
        /// <param name="iterations">膨張が行われる回数. [既定値は1]</param>
        /// <param name="borderType">ピクセル外挿手法．[既定値はBorderType.Constant]</param>
        /// <param name="borderValue">定数境界モードで利用されるピクセル値．デフォルト値は特別な意味を持ちます．[既定値はCvCpp.MorphologyDefaultBorderValue()]</param>
#else
        /// <summary>
        /// Dilates an image by using a specific structuring element.
        /// </summary>
        /// <param name="src">The source image</param>
        /// <param name="dst">The destination image. It will have the same size and the same type as src</param>
        /// <param name="element">The structuring element used for dilation. If element=new Mat() , a 3x3 rectangular structuring element is used</param>
        /// <param name="anchor">Position of the anchor within the element. The default value (-1, -1) means that the anchor is at the element center</param>
        /// <param name="iterations">The number of times dilation is applied. [By default this is 1]</param>
        /// <param name="borderType">The pixel extrapolation method. [By default this is BorderType.Constant]</param>
        /// <param name="borderValue">The border value in case of a constant border. The default value has a special meaning. [By default this is CvCpp.MorphologyDefaultBorderValue()]</param>
#endif
        public static void Dilate(Mat src, Mat dst, Mat element,
            CvPoint? anchor = null, int iterations = 1, BorderType borderType = BorderType.Constant, CvScalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (element == null)
                throw new ArgumentNullException("kernel");

            CvPoint _anchor = anchor.GetValueOrDefault(new CvPoint(-1, -1));
            CvScalar _borderValue = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());

            CppInvoke.cv_dilate(src.CvPtr, dst.CvPtr, element.CvPtr, _anchor, iterations, borderType, _borderValue);
        }
        #endregion
        #region Erode
#if LANG_JP
        /// <summary>
        /// 指定の構造要素を用いて画像の収縮を行います．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">src と同じサイズ，同じ型の出力画像</param>
        /// <param name="element">収縮に用いられる構造要素． element=new Mat() の場合， 3x3 の矩形の構造要素が用いられます</param>
        /// <param name="anchor">構造要素内のアンカー位置．デフォルト値の (-1, -1) は，アンカーが構造要素の中心にあることを意味します</param>
        /// <param name="iterations">収縮が行われる回数. [既定値は1]</param>
        /// <param name="borderType">ピクセル外挿手法．[既定値はBorderType.Constant]</param>
        /// <param name="borderValue">定数境界モードで利用されるピクセル値．デフォルト値は特別な意味を持ちます．[既定値はCvCpp.MorphologyDefaultBorderValue()]</param>
#else
        /// <summary>
        /// Erodes an image by using a specific structuring element.
        /// </summary>
        /// <param name="src">The source image</param>
        /// <param name="dst">The destination image. It will have the same size and the same type as src</param>
        /// <param name="element">The structuring element used for dilation. If element=new Mat(), a 3x3 rectangular structuring element is used</param>
        /// <param name="anchor">Position of the anchor within the element. The default value (-1, -1) means that the anchor is at the element center</param>
        /// <param name="iterations">The number of times erosion is applied</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        /// <param name="borderValue">The border value in case of a constant border. The default value has a special meaning. [By default this is CvCpp.MorphologyDefaultBorderValue()]</param>
#endif
        public static void Erode(Mat src, Mat dst, Mat element,
            CvPoint? anchor = null, int iterations = 1, BorderType borderType = BorderType.Constant, CvScalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (element == null)
                throw new ArgumentNullException("kernel");

            CvPoint _anchor = anchor.GetValueOrDefault(new CvPoint(-1, -1));
            CvScalar _borderValue = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());

            CppInvoke.cv_erode(src.CvPtr, dst.CvPtr, element.CvPtr, _anchor, iterations, borderType, _borderValue);
        }
        static readonly CvPoint a = new CvPoint(-1, -1);
        #endregion
        #region HoughCircles
#if LANG_JP
        /// <summary>
        /// ハフ変換を用いて，グレースケール画像から円を検出します．
        /// </summary>
        /// <param name="image">8ビット，シングルチャンネル，グレースケールの入力画像></param>
        /// <param name="method">現在のところ，HoughCirclesMethod.Gradient メソッドのみが実装されている．</param>
        /// <param name="dp">画像分解能に対する投票分解能の比率の逆数．</param>
        /// <param name="minDist">検出される円の中心同士の最小距離．</param>
        /// <param name="param1">手法依存の1番目のパラメータ．[既定値は100]</param>
        /// <param name="param2">手法依存の2番目のパラメータ．[既定値は100]</param>
        /// <param name="minRadius">円の半径の最小値 [既定値は0]</param>
        /// <param name="maxRadius">円の半径の最大値 [既定値は0]</param>
        /// <returns>検出された円．各ベクトルは，3要素の浮動小数点型ベクトル (x, y, radius) としてエンコードされます</returns>
#else
        /// <summary>
        /// Finds circles in a grayscale image using a Hough transform.
        /// </summary>
        /// <param name="image">The 8-bit, single-channel, grayscale input image</param>
        /// <param name="method">Currently, the only implemented method is HoughCirclesMethod.Gradient</param>
        /// <param name="dp">The inverse ratio of the accumulator resolution to the image resolution. </param>
        /// <param name="minDist">Minimum distance between the centers of the detected circles. </param>
        /// <param name="param1">The first method-specific parameter. [By default this is 100]</param>
        /// <param name="param2">The second method-specific parameter. [By default this is 100]</param>
        /// <param name="minRadius">Minimum circle radius. [By default this is 0]</param>
        /// <param name="maxRadius">Maximum circle radius. [By default this is 0] </param>
        /// <returns>The output vector found circles. Each vector is encoded as 3-element floating-point vector (x, y, radius)</returns>
#endif
        public static CvCircleSegment[] HoughCircles(this Mat image, HoughCirclesMethod method, double dp, double minDist, double param1 = 100, double param2 = 100, int minRadius = 0, int maxRadius = 0)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            using (StdVectorVec3f vec = new StdVectorVec3f())
            {
                CppInvoke.cv_HoughCircles(image.CvPtr, vec.CvPtr, method, dp, minDist, param1, param2, minRadius, maxRadius);
                return vec.ToArray<CvCircleSegment>();
            }
        }
        #endregion
        #region HoughLines
#if LANG_JP
        /// <summary>
        /// 標準ハフ変換を用いて，2値画像から直線を検出します．
        /// </summary>
        /// <param name="image">8ビット，シングルチャンネルの2値入力画像．この画像は関数により書き換えられる可能性があります</param>
        /// <param name="rho">ピクセル単位で表される投票空間の距離分解能</param>
        /// <param name="theta">ラジアン単位で表される投票空間の角度分解能</param>
        /// <param name="threshold">投票の閾値パラメータ．十分な票（ &gt; threshold ）を得た直線のみが出力されます</param>
        /// <param name="srn">マルチスケールハフ変換において，距離分解能 rho  の除数となる値．[既定値は0]</param>
        /// <param name="stn">マルチスケールハフ変換において，角度分解能 theta  の除数となる値. [既定値は0]</param>
        /// <returns>検出された直線．各直線は，2要素のベクトル (rho, theta) で表現されます．
        /// rho は原点（画像の左上コーナー）からの距離， theta はラジアン単位で表される直線の回転角度です</returns>
#else
        /// <summary>
        /// Finds lines in a binary image using standard Hough transform.
        /// </summary>
        /// <param name="image">The 8-bit, single-channel, binary source image. The image may be modified by the function</param>
        /// <param name="rho">Distance resolution of the accumulator in pixels</param>
        /// <param name="theta">Angle resolution of the accumulator in radians</param>
        /// <param name="threshold">The accumulator threshold parameter. Only those lines are returned that get enough votes ( &gt; threshold )</param>
        /// <param name="srn">For the multi-scale Hough transform it is the divisor for the distance resolution rho. [By default this is 0]</param>
        /// <param name="stn">For the multi-scale Hough transform it is the divisor for the distance resolution theta. [By default this is 0]</param>
        /// <returns>The output vector of lines. Each line is represented by a two-element vector (rho, theta) . 
        /// rho is the distance from the coordinate origin (0,0) (top-left corner of the image) and theta is the line rotation angle in radians</returns>
#endif
        public static CvLineSegmentPolar[] HoughLines(this Mat image, double rho, double theta, int threshold, double srn = 0, double stn = 0)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            using (StdVectorVec2f vec = new StdVectorVec2f())
            {
                CppInvoke.cv_HoughLines(image.CvPtr, vec.CvPtr, rho, theta, threshold, srn, stn);
                return vec.ToArray<CvLineSegmentPolar>();
            }
        }
        #endregion
        #region HoughLinesP
#if LANG_JP
        /// <summary>
        /// 確率的ハフ変換を利用して，2値画像から線分を検出します．
        /// </summary>
        /// <param name="image">8ビット，シングルチャンネルの2値入力画像．この画像は関数により書き換えられる可能性があります</param>
        /// <param name="rho">ピクセル単位で表される投票空間の距離分解能</param>
        /// <param name="theta">ラジアン単位で表される投票空間の角度分解能</param>
        /// <param name="threshold">投票の閾値パラメータ．十分な票（ &gt; threshold ）を得た直線のみが出力されます</param>
        /// <param name="minLineLength">最小の線分長．これより短い線分は棄却されます. [既定値は0]</param>
        /// <param name="maxLineGap">2点が同一線分上にあると見なす場合に許容される最大距離. [既定値は0]</param>
        /// <returns>検出された線分．各線分は，4要素のベクトル (x1, y1, x2, y2) で表現されます．</returns>
#else
        /// <summary>
        /// Finds lines segments in a binary image using probabilistic Hough transform.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="rho">Distance resolution of the accumulator in pixels</param>
        /// <param name="theta">Angle resolution of the accumulator in radians</param>
        /// <param name="threshold">The accumulator threshold parameter. Only those lines are returned that get enough votes ( &gt; threshold )</param>
        /// <param name="minLineLength">The minimum line length. Line segments shorter than that will be rejected. [By default this is 0]</param>
        /// <param name="maxLineGap">The maximum allowed gap between points on the same line to link them. [By default this is 0]</param>
        /// <returns>The output lines. Each line is represented by a 4-element vector (x1, y1, x2, y2)</returns>
#endif
        public static CvLineSegmentPoint[] HoughLinesP(this Mat image, double rho, double theta, int threshold, double minLineLength = 0, double maxLineGap = 0)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            using (StdVectorVec4i vec = new StdVectorVec4i())
            {
                CppInvoke.cv_HoughLinesP(image.CvPtr, vec.CvPtr, rho, theta, threshold, minLineLength, maxLineGap);
                return vec.ToArray<CvLineSegmentPoint>();
            }
        }
        #endregion
        #region MorphologyEx
#if LANG_JP
        /// <summary>
        /// 高度なモルフォロジー変換を行います．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">src と同じサイズ，同じ型の出力画像</param>
        /// <param name="op">モルフォロジー演算の種類</param>
        /// <param name="element">構造要素</param>
        /// <param name="anchor">構造要素内のアンカー位置．デフォルト値の (-1, -1) は，アンカーが構造要素の中心にあることを意味します.</param>
        /// <param name="iterations">収縮と膨張が適用される回数. [既定値は1]</param>
        /// <param name="borderType">ピクセル外挿手法. [既定値はBorderType.Constant]</param>
        /// <param name="borderValue">定数境界モードで利用されるピクセル値．デフォルト値は特別な意味を持ちます． [既定値は CvCpp.MorphologyDefaultBorderValue()]</param>
#else
        /// <summary>
        /// Performs advanced morphological transformations
        /// </summary>
        /// <param name="src">Source image</param>
        /// <param name="dst">Destination image. It will have the same size and the same type as src</param>
        /// <param name="op">Type of morphological operation</param>
        /// <param name="element">Structuring element</param>
        /// <param name="anchor">Position of the anchor within the element. The default value (-1, -1) means that the anchor is at the element center</param>
        /// <param name="iterations">Number of times erosion and dilation are applied. [By default this is 1]</param>
        /// <param name="borderType">The pixel extrapolation method. [By default this is BorderType.Constant]</param>
        /// <param name="borderValue">The border value in case of a constant border. The default value has a special meaning. [By default this is CvCpp.MorphologyDefaultBorderValue()]</param>
#endif
        public static void MorphologyEx(Mat src, Mat dst, MorphologyOperation op, Mat element,
            CvPoint? anchor = null, int iterations = 1, BorderType borderType = BorderType.Constant, CvScalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (element == null)
                throw new ArgumentNullException("element");

            CvPoint _anchor = anchor.GetValueOrDefault(new CvPoint(-1, -1));
            CvScalar _borderValue = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());

            CppInvoke.cv_morphologyEx(src.CvPtr, dst.CvPtr, op, element.CvPtr, _anchor, iterations, borderType, _borderValue);
        }
        #endregion
        public static void PreCornerDetect(Mat src, Mat dst, int ksize, BorderType borderType = BorderType.Constant)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            CppInvoke.cv_preCornerDetect(src.CvPtr, dst.CvPtr, ksize, borderType);
        }
        public static void Remap(Mat src, Mat dst, Mat map1, Mat map2,
            Interpolation interpolation = Interpolation.Linear, BorderType borderMode = BorderType.Constant, CvScalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (map1 == null)
                throw new ArgumentNullException("map1");
            if (map2 == null)
                throw new ArgumentNullException("map2");

            CvScalar _borderValue = borderValue.GetValueOrDefault(CvScalar.ScalarAll(0));

            CppInvoke.cv_remap(src.CvPtr, dst.CvPtr, map1.CvPtr, map2.CvPtr, interpolation, borderMode, _borderValue);
        }
        public static void Resize(Mat src, Mat dst, CvSize dsize,
            double fx = 0, double fy = 0, Interpolation interpolation = Interpolation.Linear)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            CppInvoke.cv_resize(src.CvPtr, dst.CvPtr, dsize, fx, fy, interpolation);
        }
        public static void WarpAffine(Mat src, Mat dst, Mat M, CvSize dsize,
            Interpolation flags = Interpolation.Linear, BorderType borderMode = BorderType.Constant, CvScalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (M == null)
                throw new ArgumentNullException("M");

            CvScalar _borderValue = borderValue.GetValueOrDefault(CvScalar.ScalarAll(0));

            CppInvoke.cv_warpAffine(src.CvPtr, dst.CvPtr, M.CvPtr, dsize, flags, borderMode, _borderValue);
        }
        public static void WarpPerspective(Mat src, Mat dst, Mat M, CvSize dsize,
            Interpolation flags = Interpolation.Linear, BorderType borderMode = BorderType.Constant, CvScalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (M == null)
                throw new ArgumentNullException("M");

            CvScalar _borderValue = borderValue.GetValueOrDefault(CvScalar.ScalarAll(0));

            CppInvoke.cv_warpPerspective(src.CvPtr, dst.CvPtr, M.CvPtr, dsize, flags, borderMode, _borderValue);
        }


        public static void SolvePnP(Mat objectPoints, Mat imagePoints, Mat cameraMatrix, Mat distCoeffs, Mat rvec, Mat tvec, bool useExtrinsicGuess = false)
        {
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (imagePoints == null)
                throw new ArgumentNullException("imagePoints");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (distCoeffs == null)
                throw new ArgumentNullException("distCoeffs");
            if (rvec == null)
                throw new ArgumentNullException("rvec");
            if (tvec == null)
                throw new ArgumentNullException("tvec");

            CppInvoke.cv_solvePnP(objectPoints.CvPtr, imagePoints.CvPtr, cameraMatrix.CvPtr, distCoeffs.CvPtr, rvec.CvPtr, tvec.CvPtr, useExtrinsicGuess);
        }
        #endregion
        #region core
        #region Miscellaneous
        public static void setNumThreads(int nthreads)
        {
            CppInvoke.cv_setNumThreads(nthreads);
        }
        public static int getNumThreads()
        {
            return CppInvoke.cv_getNumThreads();
        }
        public static int getThreadNum()
        {
            return CppInvoke.cv_getThreadNum();
        }
        public static string getBuildInformation()
        {
            return CppInvoke.cv_getBuildInformation();
        }
        public static Int64 getTickCount()
        {
            return CppInvoke.cv_getTickCount();
        }
        public static double getTickFrequency()
        {
            return CppInvoke.cv_getTickFrequency();
        }
        public static Int64 getCPUTickCount()
        {
            return CppInvoke.cv_getCPUTickCount();
        }
        public static bool checkHardwareSupport(HardwareSupport feature)
        {
            return CppInvoke.cv_checkHardwareSupport(feature);
        }
        public static int getNumberOfCPUs()
        {
            return CppInvoke.cv_getNumberOfCPUs();
        }
        public static IntPtr fastMalloc(long bufSize)
        {
            return CppInvoke.cv_fastMalloc(new IntPtr(bufSize));
        }
        public static void fastFree(IntPtr ptr)
        {
            CppInvoke.cv_fastFree(ptr);
        }
        #endregion

        #region Abs
        public static void Abs(Mat src, Mat dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            CppInvoke.cv_abs1(src.CvPtr, dst.CvPtr);
        }
        #endregion
        #region Add
#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の和を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列．</param>
        /// <param name="mask">8ビット，シングルチャンネル配列のオプションの処理マスク．出力配列内の変更される要素を表します. [既定値はnull]</param>        
#else
        /// <summary>
        /// Computes the per-element sum of two arrays or an array and a scalar.
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
        /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
        /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is null]</param>
#endif
        public static void Add(Mat src1, Mat src2, Mat dst, Mat mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CppInvoke.cv_add1(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask));
        }
#if LANG_JP
        /// <summary>
        /// つの配列同士，あるいは配列とスカラの 要素毎の和を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="sc">2番目の入力パラメータであるスカラ</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列．</param>
        /// <param name="mask">8ビット，シングルチャンネル配列のオプションの処理マスク．出力配列内の変更される要素を表します. [既定値はnull]</param>
#else
        /// <summary>
        /// Computes the per-element sum of two arrays or an array and a scalar.
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="sc">Scalar; the second input parameter</param>
        /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
        /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is null]</param>
#endif
        public static void Add(Mat src1, CvScalar sc, Mat dst, Mat mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CppInvoke.cv_add2(src1.CvPtr, sc, dst.CvPtr, ToPtr(mask));
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
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．[既定値は1]</param>
        /// <param name="line_type">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center_x">X-coordinate of the center of the circle. </param>
        /// <param name="center_y">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="line_type">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public static void Circle(this Mat img, int center_x, int center_y, int radius, CvScalar color, int thickness = 1, LineType line_type = LineType.Link8, int shift = 1)
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
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．[既定値は1]</param>
        /// <param name="line_type">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="line_type">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public static void Circle(this Mat img, CvPoint center, int radius, CvScalar color, int thickness = 1, LineType line_type = LineType.Link8, int shift = 0)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            CvInvoke.cvCircle(img.ToIplImage().CvPtr, center, radius, color, thickness, line_type, shift);
        }
        #endregion
        #region ConvertScaleAbs
#if LANG_JP
        /// <summary>
        /// スケーリング後，絶対値を計算し，結果を結果を 8 ビットに変換します．
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="alpha">オプションのスケールファクタ. [既定値は1]</param>
        /// <param name="beta">スケーリングされた値に加えられるオプション値. [既定値は0]</param>
#else
        /// <summary>
        /// Scales, computes absolute values and converts the result to 8-bit.
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="dst">The destination array</param>
        /// <param name="alpha">The optional scale factor. [By default this is 1]</param>
        /// <param name="beta">The optional delta added to the scaled values. [By default this is 0]</param>
#endif
        public static void ConvertScaleAbs(Mat src, Mat dst, double alpha = 1, double beta = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CppInvoke.cv_convertScaleAbs(src.CvPtr, dst.CvPtr, alpha, beta);
        }
        #endregion
        #region CvarrToMat
#if LANG_JP
        /// <summary>
        /// CvMat・IplImage・CvMatND を cv::Matに変換する
        /// </summary>
        /// <param name="arr">入力配列の CvMat, IplImage, CvMatND</param>
        /// <param name="copyData">
        /// false(既定値)の場合、データはコピーされず、ヘッダのみが新たに作られる。
        /// trueの場合、データはすべてコピーされ、変換後はユーザは元の行列を解放しても構わない。[既定値はfalse]
        /// </param>
        /// <param name="allowND">
        /// true(既定値)の場合、入力のCvMatNDは可能ならばMatに変換される。
        /// もし不可能な場合、またはこのフラグがfalseであれば、このメソッドはエラーを通知する。[既定値はtrue]
        /// </param>
        /// <param name="coiMode">
        /// IplImageのCOIの取り扱いを指定するパラメータ。
        /// falseの場合、COIが設定されていたらエラーを通知する。
        /// trueの場合、エラーは通知せず、代わりに入力画像全体を表すヘッダを返し、ユーザにCOIの扱いを決めさせる。[既定値はfalse]
        /// </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Converts CvMat, IplImage or CvMatND to Mat.
        /// </summary>
        /// <param name="arr">The source CvMat, IplImage or CvMatND</param>
        /// <param name="copyData">
        /// When it is false (default value), no data is copied, only the new header is created. 
        /// The the parameter is true, all the data is copied, then user may deallocate the original array right after the conversion. [By default this is false]
        /// </param>
        /// <param name="allowND">
        /// When it is true (default value), then CvMatND is converted to Mat if it’s possible 
        /// (e.g. then the data is contiguous). If it’s not possible, or when the parameter is false, the function will report an error. [By default this is true]
        /// </param>
        /// <param name="coiMode">
        /// The parameter specifies how the IplImage COI (when set) is handled.
        /// * If coiMode=false, the function will report an error if COI is set.
        /// * If coiMode=true, the function will never report an error; instead it returns the header to the whole original image 
        /// and user will have to check and process COI manually, see extractImageCOI. [By default this is false]
        /// </param>
        /// <returns></returns>
#endif
        public static Mat CvarrToMat(CvArr arr, bool copyData = false, bool allowND = true, bool coiMode = false)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            Mat mat = new Mat();
            CppInvoke.cv_cvarrToMat(arr.CvPtr, copyData, allowND, coiMode ? 1 : 0, mat.CvPtr);
            return mat;
        }
        #endregion
        #region Divide
#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の商を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src2 と同じサイズ，同じ型である出力配列</param>
        /// <param name="scale">スケールファクタ [既定値は1]</param>
#else
        /// <summary>
        /// Performs per-element division of two arrays or a scalar by an array.
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array; should have the same size and same type as src1</param>
        /// <param name="dst">The destination array; will have the same size and same type as src2</param>
        /// <param name="scale">Scale factor [By default this is 1]</param>
#endif
        public static void Divide(Mat src1, Mat src2, Mat dst, double scale = 1)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CppInvoke.cv_divide1(src1.CvPtr, src2.CvPtr, dst.CvPtr, scale);
        }
#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の商を求めます．
        /// </summary>
        /// <param name="scale">スケールファクタ</param>
        /// <param name="src">1番目の入力配列</param>
        /// <param name="dst">src2 と同じサイズ，同じ型である出力配列</param>
#else
        /// <summary>
        /// Performs per-element division of two arrays or a scalar by an array.
        /// </summary>
        /// <param name="scale">Scale factor</param>
        /// <param name="src">The first source array</param>
        /// <param name="dst">The destination array; will have the same size and same type as src2</param>
#endif
        public static void Divide(double scale, Mat src, Mat dst)
        {
            if (src == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CppInvoke.cv_divide2(scale, src.CvPtr, dst.CvPtr);
        }
        #endregion
        #region Ellipse
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描画される画像</param>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="start_angle">楕円弧の開始角度</param>
        /// <param name="end_angle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
        /// <param name="thickness">楕円弧の線の幅 [既定値は1]</param>
        /// <param name="line_type">楕円弧の線の種類 [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と軸の長さの小数点以下の桁を表すビット数 [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="start_angle">Starting angle of the elliptic arc. </param>
        /// <param name="end_angle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse arc. [By default this is 1]</param>
        /// <param name="line_type">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and axes' values. [By default this is 0]</param>
#endif
        public static void Ellipse(this Mat img, CvPoint center, CvSize axes, double angle, double start_angle, double end_angle, CvScalar color,
            int thickness = 1, LineType line_type = LineType.Link8, int shift = 0)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            CvInvoke.cvEllipse(img.ToIplImage().CvPtr, center, axes, angle, start_angle, end_angle, color, thickness, line_type, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描かれる画像．</param>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
        /// <param name="thickness">楕円境界線の幅．[既定値は1]</param>
        /// <param name="line_type">楕円境界線の種類．[既定値はLineType.Link8]</param>
        /// <param name="shift">矩形領域の頂点座標の小数点以下の桁を表すビット数．[既定値は0]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. [By default this is 1]</param>
        /// <param name="line_type">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the box vertex coordinates. [By default this is 0]</param>
#endif
        public static void Ellipse(this Mat img, CvBox2D box, CvScalar color, int thickness = 1, LineType line_type = LineType.Link8, int shift = 0)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }

            CvSize axes = new CvSize
            {
                Width = (int)Math.Round(box.Size.Height * 0.5),
                Height = (int)Math.Round(box.Size.Width * 0.5)
            };
            Ellipse(img, box.Center, axes, box.Angle, 0, 360, color, thickness, line_type, shift);
        }
        #endregion
        #region ExtractImageCOI
#if LANG_JP
        /// <summary>
        /// 選択されたチャンネルの画像を取り出す
        /// </summary>
        /// <param name="arr">入力配列. CvMat または IplImage の参照.</param>
        /// <param name="coiimg">出力行列. 1チャンネルで, 入力配列srcと同じサイズ・ビット深度を持つ.</param>
        /// <param name="coi">0以上の場合, 指定されたチャンネルについて取り出される。
        /// 0未満の場合, 入力配列srcがIplImageでCOIが指定されていれば, そのCOIについて取り出される. [既定値は-1]</param>
#else
        /// <summary>
        /// Extract the selected image channel
        /// </summary>
        /// <param name="arr">The source array. It should be a pointer to CvMat or IplImage</param>
        /// <param name="coiimg">The destination array; will have single-channel, and the same size and the same depth as src</param>
        /// <param name="coi">If the parameter is &gt;=0, it specifies the channel to extract; 
        /// If it is &lt;0, src must be a pointer to IplImage with valid COI set - then the selected COI is extracted. [By default this is -1]</param>
#endif
        public static void ExtractImageCOI(CvArr arr, Mat coiimg, int coi = -1)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            if (coiimg == null)
                throw new ArgumentNullException("coiimg");
            CppInvoke.cv_extractImageCOI(arr.CvPtr, coiimg.CvPtr, coi);
        }
        #endregion
        #region InsertImageCOI
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coiimg"></param>
        /// <param name="arr"></param>
        /// <param name="coi">[既定値は-1]</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coiimg"></param>
        /// <param name="arr"></param>
        /// <param name="coi">[By default this is -1]</param>
#endif
        public static void InsertImageCOI(Mat coiimg, CvArr arr, int coi = -1)
        {
            if (coiimg == null)
                throw new ArgumentNullException("coiimg");
            if (arr == null)
                throw new ArgumentNullException("arr");
            CppInvoke.cv_insertImageCOI(coiimg.CvPtr, arr.CvPtr, coi);
        }
        #endregion
        #region Line
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1_x">線分の1番目の端点x</param>
        /// <param name="pt1_y">線分の1番目の端点y</param>
        /// <param name="pt2_x">線分の2番目の端点x</param>
        /// <param name="pt2_y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ. [既定値は1]</param>
        /// <param name="line_type">線分の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1_x">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1_y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2_x">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2_y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="line_type">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Line(this Mat img, int pt1_x, int pt1_y, int pt2_x, int pt2_y, CvScalar color, int thickness = 1, LineType line_type = LineType.Link8, int shift = 0)
        {
            Line(img, new CvPoint(pt1_x, pt1_y), new CvPoint(pt2_x, pt2_y), color, thickness, line_type, shift);
        }

#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ. [既定値は1]</param>
        /// <param name="line_type">線分の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="line_type">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Line(this Mat img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness = 1, LineType line_type = LineType.Link8, int shift = 0)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            CvInvoke.cvLine(img.ToIplImage().CvPtr, pt1, pt2, color, thickness, line_type, shift);
        }
        #endregion
        #region Multiply
#if LANG_JP
        /// <summary>
        /// 2つの配列同士の，要素毎のスケーリングされた積を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列</param>
        /// <param name="scale">オプションであるスケールファクタ. [既定値は1]</param>
#else
        /// <summary>
        /// Calculates the per-element scaled product of two arrays
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array of the same size and the same type as src1</param>
        /// <param name="dst">The destination array; will have the same size and the same type as src1</param>
        /// <param name="scale">The optional scale factor. [By default this is 1]</param>
#endif
        public static void Multiply(Mat src1, Mat src2, Mat dst, double scale = 1)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CppInvoke.cv_multiply(src1.CvPtr, src2.CvPtr, dst.CvPtr, scale);
        }
        #endregion
        #region Rectangle
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1_x">矩形の一つの頂点のx座標</param>
        /// <param name="pt1_y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2_x">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2_y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる．[既定値は1]</param>
        /// <param name="line_type">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1_x">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1_y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2_x">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2_y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="line_type">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(this Mat img, int pt1_x, int pt1_y, int pt2_x, int pt2_y, CvScalar color, int thickness = 1, LineType line_type = LineType.Link8, int shift = 0)
        {
            Rectangle(img, new CvPoint(pt1_x, pt1_y), new CvPoint(pt2_x, pt2_y), color, thickness, line_type, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="line_type">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="line_type">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(this Mat img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness = 1, LineType line_type = LineType.Link8, int shift = 0)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            CvInvoke.cvRectangle(img.ToIplImage().CvPtr, pt1, pt2, color, thickness, line_type, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="line_type">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="line_type">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(this Mat img, CvRect rect, CvScalar color, int thickness = 1, LineType line_type = LineType.Link8, int shift = 0)
        {
            Rectangle(img, new CvPoint(rect.X, rect.Y), new CvPoint(rect.X + rect.Width, rect.Y + rect.Height), color, thickness, line_type, shift);
        }
        #endregion
        #region Subtract
#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の差を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列．</param>
        /// <param name="mask">オプション．8ビット，シングルチャンネル配列の処理マスク．出力配列内の変更される要素を表します. [既定値はnull]</param>
#else
        /// <summary>
        /// Calculates per-element difference between two arrays or array and a scalar
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
        /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
        /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is null]</param>
#endif
        public static void Subtract(Mat src1, Mat src2, Mat dst, Mat mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CppInvoke.cv_subtract1(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask));
        }

#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の差を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="sc">スカラ．1番目または2番目の入力パラメータ</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列．</param>
        /// <param name="mask">オプション．8ビット，シングルチャンネル配列の処理マスク．出力配列内の変更される要素を表します. [既定値はnull]</param>
#else
        /// <summary>
        /// Calculates per-element difference between two arrays or array and a scalar
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="sc">Scalar; the first or the second input parameter</param>
        /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
        /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is null]</param>
#endif
        public static void Subtract(Mat src1, CvScalar sc, Mat dst, Mat mask = null)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CppInvoke.cv_subtract2(src1.CvPtr, sc, dst.CvPtr, ToPtr(mask));
        }

#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の差を求めます．
        /// </summary>
        /// <param name="sc">スカラ．1番目または2番目の入力パラメータ</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列．</param>
        /// <param name="mask">オプション．8ビット，シングルチャンネル配列の処理マスク．出力配列内の変更される要素を表します. [既定値はnull]</param>
#else
        /// <summary>
        /// Calculates per-element difference between two arrays or array and a scalar
        /// </summary>
        /// <param name="sc">Scalar; the first or the second input parameter</param>
        /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
        /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
        /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is null]</param>
#endif
        public static void Subtract(CvScalar sc, Mat src2, Mat dst, Mat mask)
        {
            if (src2 == null)
                throw new ArgumentNullException("src1");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CppInvoke.cv_subtract3(sc, src2.CvPtr, dst.CvPtr, ToPtr(mask));
        }
        #endregion       
        #endregion
        #region highgui
        /// <summary>
        /// Creates a window.
        /// </summary>
        /// <param name="winname">Name of the window in the window caption that may be used as a window identifier.</param>
        /// <param name="flags">
        /// Flags of the window. Currently the only supported flag is CV WINDOW AUTOSIZE. If this is set, 
        /// the window size is automatically adjusted to fit the displayed image (see imshow ), and the user can not change the window size manually.
        /// </param>
        public static void NamedWindow(string winname, WindowMode flags = WindowMode.None)
        {
            if (string.IsNullOrEmpty(winname))
                throw new ArgumentNullException("winname");
            CppInvoke.cv_namedWindow(winname, flags);
        }
        /// <summary>
        /// Displays the image in the specified window
        /// </summary>
        /// <param name="winname">Name of the window.</param>
        /// <param name="mat">Image to be shown.</param>
        public static void ImShow(string winname, Mat mat)
        {
            if (string.IsNullOrEmpty(winname))
                throw new ArgumentNullException("winname");
            if (mat == null)
                throw new ArgumentNullException("mat");
            CppInvoke.cv_imshow(winname, mat.CvPtr);
        }
        /// <summary>
        /// Loads an image from a file.
        /// </summary>
        /// <param name="filename">Name of file to be loaded.</param>
        /// <param name="flags">Specifies color type of the loaded image</param>
        /// <returns></returns>
        public static Mat ImRead(string filename, LoadMode flags)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            Mat result = new Mat();
            CppInvoke.cv_imread(filename, flags, result.CvPtr);
            return result;
        }
        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="img"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public static bool ImWrite(string filename, Mat img, int[] prms = null)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            if (img == null)
                throw new ArgumentNullException("img");
            if (prms == null)
                prms = new int[0];
            return CppInvoke.cv_imwrite(filename, img.CvPtr, prms, prms.Length);
        }
        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="img"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public static bool ImWrite(string filename, Mat img, params ImageEncodingParam[] prms)
        {
            if (prms != null)
            {
                List<int> p = new List<int>();
                foreach (ImageEncodingParam item in prms)
                {
                    p.Add((int)item.EncodingID);
                    p.Add(item.Value);
                }
                return ImWrite(filename, img, p.ToArray());
            }
            else
            {
                return ImWrite(filename, img, (int[])null);
            }
        }
        /// <summary>
        /// Reads image from the specified buffer in memory.
        /// </summary>
        /// <param name="buf">The input array of vector of bytes.</param>
        /// <param name="flags">The same flags as in imread</param>
        /// <returns></returns>
        public static Mat ImDecode(Mat buf, LoadMode flags)
        {
            if (buf == null)
                throw new ArgumentNullException("buf");
            Mat result = new Mat();
            CppInvoke.cv_imdecode(buf.CvPtr, flags, result.CvPtr);
            return result;
        }
        /// <summary>
        /// Compresses the image and stores it in the memory buffer
        /// </summary>
        /// <param name="ext">The file extension that defines the output format</param>
        /// <param name="img">The image to be written</param>
        /// <param name="buf"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public static bool ImEncode(string ext, Mat img, out byte[] buf, int[] prms = null)
        {
            if (string.IsNullOrEmpty(ext))
                throw new ArgumentNullException("ext");
            if (img == null)
                throw new ArgumentNullException("img");
            if (prms == null)
                prms = new int[0];

            // vector<uchar>のサイズをもとにマネージ配列を作り、
            // vector<uchar>の先頭アドレスからコピー
            using (StdVectorByte bufVec = new StdVectorByte())
            {
                bool result = CppInvoke.cv_imencode(ext, img.CvPtr, bufVec.CvPtr, prms, prms.Length);
                buf = bufVec.ToArray();
                return result;
            }
        }
        /// <summary>
        /// Compresses the image and stores it in the memory buffer
        /// </summary>
        /// <param name="ext">The file extension that defines the output format</param>
        /// <param name="img">The image to be written</param>
        /// <param name="buf"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public static bool ImEncode(string ext, Mat img, out byte[] buf, params ImageEncodingParam[] prms)
        {
            if (prms != null)
            {
                List<int> p = new List<int>();
                foreach (ImageEncodingParam item in prms)
                {
                    p.Add((int)item.EncodingID);
                    p.Add(item.Value);
                }
                return ImEncode(ext, img, out buf, p.ToArray());
            }
            else
            {
                return ImEncode(ext, img, out buf, (int[])null);
            }
        }

        /// <summary>
        /// Waits for a pressed key.
        /// </summary>
        /// <param name="delay">Delay in milliseconds. 0 is the special value that means ”forever”</param>
        /// <returns>Returns the code of the pressed key or -1 if no key was pressed before the specified time had elapsed.</returns>
        public static int WaitKey(int delay = 0)
        {
            return CppInvoke.cv_waitKey(delay);
        }
        #endregion
        #region cvaux
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="keypoints"></param>
        /// <param name="threshold"></param>
        /// <param name="nonmax_supression"></param>
        public static void FAST(Mat image, out KeyPoint[] keypoints, int threshold, bool nonmax_supression = true)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            using (StdVectorKeyPoint kp = new StdVectorKeyPoint())
            {
                CppInvoke.cv_FAST(image.CvPtr, kp.CvPtr, threshold, nonmax_supression);
                keypoints = kp.ToArray();
            }
        }
        #endregion
        #region nonfree
#if LANG_JP
        /// <summary>
        /// この関数を、SIFT/SURF等のnonfreeの機能を使用する前に呼び出してください
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// You need to call this method before using SIFT/SURF functions.
        /// </summary>
        /// <returns></returns>
#endif
        public static bool InitModule_NonFree()
        {
            return CppInvoke.cv_initModule_nonfree();
        }
        #endregion
    }
}
