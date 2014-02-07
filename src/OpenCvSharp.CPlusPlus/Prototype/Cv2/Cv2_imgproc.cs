using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Cv2
    {
        #region GetGaborKernel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ksize"></param>
        /// <param name="sigma"></param>
        /// <param name="theta"></param>
        /// <param name="lambd"></param>
        /// <param name="gamma"></param>
        /// <param name="psi"></param>
        /// <param name="ktype"></param>
        /// <returns></returns>
        public static Mat GetGaborKernel(Size ksize, double sigma, double theta, double lambd, double gamma, double psi, int ktype)
        {
            IntPtr matPtr = CppInvoke.imgproc_getGaborKernel(ksize, sigma, theta, lambd, gamma, psi, ktype);
            return new Mat(matPtr);
        }
        #endregion
        #region GetStructuringElement
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="ksize"></param>
        /// <returns></returns>
        public static Mat GetStructuringElement(StructuringElementShape shape, Size ksize)
        {
            return GetStructuringElement(shape, ksize, new Point(-1, -1));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="ksize"></param>
        /// <param name="anchor"></param>
        /// <returns></returns>
        public static Mat GetStructuringElement(StructuringElementShape shape, Size ksize, Point anchor)
        {
            IntPtr matPtr = CppInvoke.imgproc_getStructuringElement((int)shape, ksize, anchor);
            return new Mat(matPtr);
        }
        #endregion
        #region CvtColor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="code"></param>
        /// <param name="dstCn"></param>
        public static void CvtColor(InputArray src, OutputArray dst, int code, int dstCn = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            try
            {
                CppInvoke.imgproc_cvtColor(src.CvPtr, dst.CvPtr, code, dstCn);
                dst.AssignResultAndDispose();
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region CopyMakeBorder
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="borderType"></param>
        public static void CopyMakeBorder(InputArray src, OutputArray dst, int top, int bottom, int left, int right, BorderType borderType)
        {
            CopyMakeBorder(src, dst, top, bottom, left, right, borderType, new Scalar());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="borderType"></param>
        /// <param name="value"></param>
        public static void CopyMakeBorder(InputArray src, OutputArray dst, int top, int bottom, int left, int right, BorderType borderType, Scalar value)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            try
            {
                CppInvoke.imgproc_copyMakeBorder(src.CvPtr, dst.CvPtr, top, bottom, left, right, (int)borderType, value);
                dst.AssignResultAndDispose();
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region MedianBlur
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        public static void MedianBlur(InputArray src, OutputArray dst, int ksize)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            try
            {
                CppInvoke.imgproc_medianBlur(src.CvPtr, dst.CvPtr, ksize);
                dst.AssignResultAndDispose();
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region GaussianBlur
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="sigmaX"></param>
        /// <param name="sigmaY"></param>
        /// <param name="borderType"></param>
        public static void GaussianBlur(InputArray src, OutputArray dst, Size ksize, double sigmaX, 
            double sigmaY = 0, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            try
            {
                CppInvoke.imgproc_GaussianBlur(src.CvPtr, dst.CvPtr, ksize, sigmaX, sigmaY, (int)borderType);
                dst.AssignResultAndDispose();
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region BilateralFilter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="d"></param>
        /// <param name="sigmaColor"></param>
        /// <param name="sigmaSpace"></param>
        /// <param name="borderType"></param>
        public static void BilateralFilter(InputArray src, OutputArray dst, int d, double sigmaColor, double sigmaSpace, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_bilateralFilter(src.CvPtr, dst.CvPtr, d, sigmaColor, sigmaSpace, (int)borderType);
            dst.AssignResultAndDispose();
        }
        #endregion
        #region AdaptiveBilateralFilter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="sigmaSpace"></param>
        public static void AdaptiveBilateralFilter(InputArray src, OutputArray dst, Size ksize, double sigmaSpace)
        {
            AdaptiveBilateralFilter(src, dst, ksize, sigmaSpace, 20.0, new Point(-1, -1), BorderType.Default);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="sigmaSpace"></param>
        /// <param name="maxSigmaColor"></param>
        public static void AdaptiveBilateralFilter(InputArray src, OutputArray dst, Size ksize, double sigmaSpace, double maxSigmaColor)
        {
            AdaptiveBilateralFilter(src, dst, ksize, sigmaSpace, maxSigmaColor, new Point(-1, -1), BorderType.Default);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="sigmaSpace"></param>
        /// <param name="maxSigmaColor"></param>
        /// <param name="anchor"></param>
        public static void AdaptiveBilateralFilter(InputArray src, OutputArray dst, Size ksize, double sigmaSpace, double maxSigmaColor, Point anchor)
        {
            AdaptiveBilateralFilter(src, dst, ksize, sigmaSpace, maxSigmaColor, anchor, BorderType.Default);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="sigmaSpace"></param>
        /// <param name="maxSigmaColor"></param>
        /// <param name="anchor"></param>
        /// <param name="borderType"></param>
        public static void AdaptiveBilateralFilter(InputArray src, OutputArray dst, Size ksize,
            double sigmaSpace, double maxSigmaColor, Point anchor, BorderType borderType)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_adaptiveBilateralFilter(src.CvPtr, dst.CvPtr, ksize, sigmaSpace, maxSigmaColor, anchor, (int)borderType);
            dst.AssignResultAndDispose();
        }
        #endregion
        #region BoxFilter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ddepth"></param>
        /// <param name="ksize"></param>
        public static void BoxFilter(InputArray src, OutputArray dst, int ddepth, Size ksize)
        {
            BoxFilter(src, dst, ddepth, ksize, new Point(-1, -1));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ddepth"></param>
        /// <param name="ksize"></param>
        /// <param name="anchor"></param>
        /// <param name="normalize"></param>
        /// <param name="borderType"></param>
        public static void BoxFilter(InputArray src, OutputArray dst, int ddepth, Size ksize, Point anchor, 
            bool normalize = true, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_boxFilter(src.CvPtr, dst.CvPtr, ddepth, ksize, anchor, normalize ? 1 : 0, (int)borderType);
            dst.AssignResultAndDispose();
        }
        #endregion
        #region Blur
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        public static void Blur(InputArray src, OutputArray dst, Size ksize)
        {
            Blur(src, dst, ksize, new Point(-1, -1));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="anchor"></param>
        /// <param name="borderType"></param>
        public static void Blur(InputArray src, OutputArray dst, Size ksize, Point anchor, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_blur(src.CvPtr, dst.CvPtr, ksize, anchor, (int)borderType);
        }
        #endregion
        #region Filter2D
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ddepth"></param>
        /// <param name="kernel"></param>
        public static void Filter2D(InputArray src, OutputArray dst, int ddepth, InputArray kernel)
        {
            Filter2D(src, dst, ddepth, kernel, new Point(-1, -1));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ddepth"></param>
        /// <param name="kernel"></param>
        /// <param name="anchor"></param>
        /// <param name="delta"></param>
        /// <param name="borderType"></param>
        public static void Filter2D(InputArray src, OutputArray dst, int ddepth,
	        InputArray kernel, Point anchor, double delta = 0, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            IntPtr kernelPtr = DisposableCvObject.GetCvPtr(kernel);
            CppInvoke.imgproc_filter2D(src.CvPtr, dst.CvPtr, ddepth, kernelPtr, anchor, delta, (int)borderType);
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
        public static CvLineSegmentPolar[] HoughLines(InputArray image, double rho, double theta, int threshold, 
            double srn = 0, double stn = 0)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            using (StdVectorVec2f vec = new StdVectorVec2f())
            {
                CppInvoke.imgproc_HoughLines(image.CvPtr, vec.CvPtr, rho, theta, threshold, srn, stn);
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
        public static CvLineSegmentPoint[] HoughLinesP(InputArray image, double rho, double theta, int threshold, 
            double minLineLength = 0, double maxLineGap = 0)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();
            using (StdVectorVec4i vec = new StdVectorVec4i())
            {
                CppInvoke.imgproc_HoughLinesP(image.CvPtr, vec.CvPtr, rho, theta, threshold, minLineLength, maxLineGap);
                return vec.ToArray<CvLineSegmentPoint>();
            }
        }
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
        public static CvCircleSegment[] HoughCircles(InputArray image, HoughCirclesMethod method, double dp, double minDist, 
            double param1 = 100, double param2 = 100, int minRadius = 0, int maxRadius = 0)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();
            using (StdVectorVec3f vec = new StdVectorVec3f())
            {
                CppInvoke.imgproc_HoughCircles(image.CvPtr, vec.CvPtr, (int)method, dp, minDist, param1, param2, minRadius, maxRadius);
                return vec.ToArray<CvCircleSegment>();
            }
        }
        #endregion
    }
}
