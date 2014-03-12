using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
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
        /// <param name="value"></param>
        public static void CopyMakeBorder(InputArray src, OutputArray dst, int top, int bottom, int left, int right, BorderType borderType, Scalar? value = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            Scalar value0 = value.GetValueOrDefault(new Scalar());
            CppInvoke.imgproc_copyMakeBorder(src.CvPtr, dst.CvPtr, top, bottom, left, right, (int)borderType, value0);
            dst.Fix();
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
            CppInvoke.imgproc_medianBlur(src.CvPtr, dst.CvPtr, ksize);
            dst.Fix();
        }
        #endregion
        #region GaussianBlur
        /// <summary>
        /// Blurs an image using a Gaussian filter.
        /// </summary>
        /// <param name="src">input image; the image can have any number of channels, which are processed independently, 
        /// but the depth should be CV_8U, CV_16U, CV_16S, CV_32F or CV_64F.</param>
        /// <param name="dst">output image of the same size and type as src.</param>
        /// <param name="ksize">Gaussian kernel size. ksize.width and ksize.height can differ but they both must be positive and odd. 
        /// Or, they can be zero’s and then they are computed from sigma* .</param>
        /// <param name="sigmaX">Gaussian kernel standard deviation in X direction.</param>
        /// <param name="sigmaY">Gaussian kernel standard deviation in Y direction; if sigmaY is zero, it is set to be equal to sigmaX, 
        /// if both sigmas are zeros, they are computed from ksize.width and ksize.height, 
        /// respectively (see getGaussianKernel() for details); to fully control the result 
        /// regardless of possible future modifications of all this semantics, it is recommended to specify all of ksize, sigmaX, and sigmaY.</param>
        /// <param name="borderType">pixel extrapolation method</param>
        public static void GaussianBlur(InputArray src, OutputArray dst, Size ksize, double sigmaX, 
            double sigmaY = 0, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_GaussianBlur(src.CvPtr, dst.CvPtr, ksize, sigmaX, sigmaY, (int)borderType);
            dst.Fix();
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
            dst.Fix();
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
            dst.Fix();
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
        public static void BoxFilter(InputArray src, OutputArray dst, MatType ddepth, Size ksize)
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
        public static void BoxFilter(InputArray src, OutputArray dst, MatType ddepth, Size ksize, Point anchor, 
            bool normalize = true, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_boxFilter(src.CvPtr, dst.CvPtr, ddepth, ksize, anchor, normalize ? 1 : 0, (int)borderType);
            dst.Fix();
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
            dst.Fix();
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
        public static void Filter2D(InputArray src, OutputArray dst, MatType ddepth, InputArray kernel)
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
        public static void Filter2D(InputArray src, OutputArray dst, MatType ddepth,
	        InputArray kernel, Point anchor, double delta = 0, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (kernel == null)
                throw new ArgumentNullException("kernel");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            kernel.ThrowIfDisposed();
            CppInvoke.imgproc_filter2D(src.CvPtr, dst.CvPtr, ddepth, kernel.CvPtr, anchor, delta, (int)borderType);
            dst.Fix();
        }
        #endregion
        #region SepFilter2D
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ddepth"></param>
        /// <param name="kernelX"></param>
        /// <param name="kernelY"></param>
        public static void SepFilter2D(InputArray src, OutputArray dst, MatType ddepth, InputArray kernelX, InputArray kernelY)
        {
            SepFilter2D(src, dst, ddepth, kernelX, kernelY, new Point(-1, -1));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ddepth"></param>
        /// <param name="kernelX"></param>
        /// <param name="kernelY"></param>
        /// <param name="anchor"></param>
        /// <param name="delta"></param>
        /// <param name="borderType"></param>
        public static void SepFilter2D(InputArray src, OutputArray dst, MatType ddepth, InputArray kernelX, InputArray kernelY,
            Point anchor, double delta = 0, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (kernelX == null)
                throw new ArgumentNullException("kernelX");
            if (kernelY == null)
                throw new ArgumentNullException("kernelY");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            kernelX.ThrowIfDisposed();
            kernelY.ThrowIfDisposed();
            CppInvoke.imgproc_sepFilter2D(src.CvPtr, dst.CvPtr, ddepth, kernelX.CvPtr, kernelY.CvPtr, anchor, delta, (int)borderType);
            dst.Fix();
        }
        #endregion
        #region Sobel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ddepth"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="ksize"></param>
        /// <param name="scale"></param>
        /// <param name="delta"></param>
        /// <param name="borderType"></param>
        public static void Sobel(InputArray src, OutputArray dst, MatType ddepth, int dx, int dy, 
            int ksize = 3, double scale = 1, double delta = 0, BorderType borderType = BorderType.Default)        
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_Sobel(src.CvPtr, dst.CvPtr, ddepth, dx, dy, ksize, scale, delta, (int)borderType);
            dst.Fix();
        }
        #endregion
        #region Scharr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ddepth"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="scale"></param>
        /// <param name="delta"></param>
        /// <param name="borderType"></param>
        public static void Scharr(InputArray src, OutputArray dst, MatType ddepth, int dx, int dy, 
            double scale = 1, double delta = 0, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_Scharr(src.CvPtr, dst.CvPtr, ddepth, dx, dy, scale, delta, (int)borderType);
            dst.Fix();
        }
        #endregion
        #region Laplacian
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ddepth"></param>
        /// <param name="ksize"></param>
        /// <param name="scale"></param>
        /// <param name="delta"></param>
        /// <param name="borderType"></param>
        public static void Laplacian(InputArray src, OutputArray dst, MatType ddepth,
            int ksize = 1, double scale = 1, double delta = 0, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_Laplacian(src.CvPtr, dst.CvPtr, ddepth, ksize, scale, delta, (int)borderType);
            dst.Fix();
        }
        #endregion
        #region Canny
#if LANG_JP
        /// <summary>
        /// Cannyアルゴリズムを用いて，画像のエッジを検出します．
        /// </summary>
        /// <param name="src">8ビット，シングルチャンネルの入力画像</param>
        /// <param name="edges">出力されるエッジのマップ． image  と同じサイズ，同じ型</param>
        /// <param name="threshold1">ヒステリシスが存在する処理の，1番目の閾値</param>
        /// <param name="threshold2">ヒステリシスが存在する処理の，2番目の閾値</param>
        /// <param name="apertureSize">Sobelオペレータのアパーチャサイズ [既定値はApertureSize.Size3]</param>
        /// <param name="L2gradient">画像勾配の強度を求めるために，より精度の高い L2ノルムを利用するか，L1ノルムで十分（false）かを指定します. [既定値はfalse]</param>
#else
        /// <summary>
        /// Finds edges in an image using Canny algorithm.
        /// </summary>
        /// <param name="src">Single-channel 8-bit input image</param>
        /// <param name="edges">The output edge map. It will have the same size and the same type as image</param>
        /// <param name="threshold1">The first threshold for the hysteresis procedure</param>
        /// <param name="threshold2">The second threshold for the hysteresis procedure</param>
        /// <param name="apertureSize">Aperture size for the Sobel operator [By default this is ApertureSize.Size3]</param>
        /// <param name="L2gradient">Indicates, whether the more accurate L2 norm should be used to compute the image gradient magnitude (true), or a faster default L1 norm is enough (false). [By default this is false]</param>
#endif
        public static void Canny(InputArray src, OutputArray edges,
            double threshold1, double threshold2, int apertureSize = 3, bool L2gradient = false)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (edges == null)
                throw new ArgumentNullException("edges");
            src.ThrowIfDisposed();
            edges.ThrowIfNotReady();
            CppInvoke.imgproc_Canny(src.CvPtr, edges.CvPtr, threshold1, threshold2, apertureSize, L2gradient ? 1 : 0);
            edges.Fix();
        }
        #endregion
        #region Eigen2x2
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static float[,] Eigen2x2(float[,] a, int n)
        {
            if(a == null)
                throw new ArgumentNullException("a");
            if(a.GetLength(0) != 2 || a.GetLength(1) != 2)
                throw new ArgumentException("Dimension of 'a' != 2");
            float[,] e = new float[2,2];
            CppInvoke.imgproc_eigen2x2(a, e, n);
            return e;
        }
        #endregion
        #region CornerEigenValsAndVecs
        /// <summary>
        /// computes both eigenvalues and the eigenvectors of 2x2 derivative covariation matrix  at each pixel. The output is stored as 6-channel matrix.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="blockSize"></param>
        /// <param name="ksize"></param>
        /// <param name="borderType"></param>
        public static void CornerEigenValsAndVecs(InputArray src, OutputArray dst, int blockSize, int ksize,
            BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_cornerEigenValsAndVecs(src.CvPtr, dst.CvPtr, blockSize, ksize, (int)borderType);
            dst.Fix();
        }
        #endregion
        #region PreCornerDetect
        /// <summary>
        /// computes another complex cornerness criteria at each pixel
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="borderType"></param>
        public static void PreCornerDetect(InputArray src, OutputArray dst, int ksize,
            BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_preCornerDetect(src.CvPtr, dst.CvPtr, ksize, (int)borderType);
            dst.Fix();
        }
        #endregion
        #region CornerSubPix
        /// <summary>
        /// adjusts the corner locations with sub-pixel accuracy to maximize the certain cornerness criteria
        /// </summary>
        /// <param name="image"></param>
        /// <param name="inputCorners"></param>
        /// <param name="winSize"></param>
        /// <param name="zeroZone"></param>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public static Point2f[] CornerSubPix(InputArray image, IEnumerable<Point2f> inputCorners,
            Size winSize, Size zeroZone, CvTermCriteria criteria)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (inputCorners == null)
                throw new ArgumentNullException("inputCorners");
            image.ThrowIfDisposed();

            Point2f[] inputCornersSrc = Util.ToArray(inputCorners);
            Point2f[] inputCornersCopy = new Point2f[inputCornersSrc.Length];
            Array.Copy(inputCornersSrc, inputCornersCopy, inputCornersSrc.Length);
            using (StdVectorPoint2f vector = new StdVectorPoint2f(inputCornersCopy))
            {
                CppInvoke.imgproc_cornerSubPix(image.CvPtr, vector.CvPtr, winSize, zeroZone, criteria);
                return vector.ToArray();
            }
        }
        #endregion
        #region GoodFeaturesToTrack
        /// <summary>
        /// finds the strong enough corners where the cornerMinEigenVal() or cornerHarris() report the local maxima
        /// </summary>
        /// <param name="src"></param>
        /// <param name="maxCorners"></param>
        /// <param name="qualityLevel"></param>
        /// <param name="minDistance"></param>
        /// <param name="mask"></param>
        /// <param name="blockSize"></param>
        /// <param name="useHarrisDetector"></param>
        /// <param name="k"></param>
        public static Point2f[] GoodFeaturesToTrack(InputArray src, 
            int maxCorners, double qualityLevel, double minDistance,
            InputArray mask, int blockSize, bool useHarrisDetector, double k)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();

            using (StdVectorPoint2f vector = new StdVectorPoint2f())
            {
                IntPtr maskPtr = ToPtr(mask);
                CppInvoke.imgproc_goodFeaturesToTrack(src.CvPtr, vector.CvPtr, maxCorners, qualityLevel, 
                    minDistance, maskPtr, blockSize, useHarrisDetector ? 0 : 1, k);
                return vector.ToArray();
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
        #region MorphologyDefaultBorderValue
        /// <summary>
        /// Default borderValue for Dilate/Erode
        /// </summary>
        /// <returns></returns>
        public static Scalar MorphologyDefaultBorderValue()
        {
            return Scalar.All(double.MaxValue);
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
        public static void Dilate(InputArray src, OutputArray dst, InputArray element,
            Point? anchor = null, int iterations = 1, BorderType borderType = BorderType.Constant, Scalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            Point anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            Scalar borderValue0 = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());
            IntPtr elementPtr = ToPtr(element);
            CppInvoke.imgproc_dilate(src.CvPtr, dst.CvPtr, elementPtr, anchor0, iterations, (int)borderType, borderValue0);
            dst.Fix();
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
        public static void Erode(InputArray src, OutputArray dst, InputArray element,
            CvPoint? anchor = null, int iterations = 1, BorderType borderType = BorderType.Constant, CvScalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            Point anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            Scalar borderValue0 = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());
            IntPtr elementPtr = ToPtr(element);
            CppInvoke.imgproc_erode(src.CvPtr, dst.CvPtr, elementPtr, anchor0, iterations, (int)borderType, borderValue0);
            dst.Fix();
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
        public static void MorphologyEx(InputArray src, OutputArray dst, MorphologyOperation op, InputArray element,
            CvPoint? anchor = null, int iterations = 1, BorderType borderType = BorderType.Constant, CvScalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            CvPoint anchor0 = anchor.GetValueOrDefault(new CvPoint(-1, -1));
            CvScalar borderValue0 = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());
            IntPtr elementPtr = ToPtr(element);
            CppInvoke.imgproc_morphologyEx(src.CvPtr, dst.CvPtr, (int)op, elementPtr, anchor0, iterations, (int)borderType, borderValue0);
            dst.Fix();
        }
        #endregion
        #region Resize
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="dsize"></param>
        /// <param name="fx"></param>
        /// <param name="fy"></param>
        /// <param name="interpolation"></param>
        public static void Resize(InputArray src, OutputArray dst, Size dsize,
            double fx = 0, double fy = 0, Interpolation interpolation = Interpolation.Linear)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_resize(src.CvPtr, dst.CvPtr, dsize, fx, fy, (int)interpolation);
            dst.Fix();
        }
        #endregion
        #region WarpAffine
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="m"></param>
        /// <param name="dsize"></param>
        /// <param name="flags"></param>
        /// <param name="borderMode"></param>
        /// <param name="borderValue"></param>
        public static void WarpAffine(InputArray src, OutputArray dst, InputArray m, Size dsize,
            Interpolation flags = Interpolation.Linear, BorderType borderMode = BorderType.Constant, Scalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (m == null)
                throw new ArgumentNullException("m");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            m.ThrowIfDisposed();
            CvScalar borderValue0 = borderValue.GetValueOrDefault(CvScalar.ScalarAll(0));
            CppInvoke.imgproc_warpAffine(src.CvPtr, dst.CvPtr, m.CvPtr, dsize, (int)flags, (int)borderMode, borderValue0);
            dst.Fix();
        }
        #endregion
        #region WarpPerspective
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="m"></param>
        /// <param name="dsize"></param>
        /// <param name="flags"></param>
        /// <param name="borderMode"></param>
        /// <param name="borderValue"></param>
        public static void WarpPerspective(InputArray src, OutputArray dst, Mat m, Size dsize,
            Interpolation flags = Interpolation.Linear, BorderType borderMode = BorderType.Constant, Scalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (m == null)
                throw new ArgumentNullException("m");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            m.ThrowIfDisposed();
            CvScalar borderValue0 = borderValue.GetValueOrDefault(CvScalar.ScalarAll(0));
            CppInvoke.imgproc_warpPerspective(src.CvPtr, dst.CvPtr, m.CvPtr, dsize, (int)flags, (int)borderMode, borderValue0);
            dst.Fix();
        }
        #endregion
        #region Remap
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="map1"></param>
        /// <param name="map2"></param>
        /// <param name="interpolation"></param>
        /// <param name="borderMode"></param>
        /// <param name="borderValue"></param>
        public static void Remap(InputArray src, OutputArray dst, InputArray map1, InputArray map2,
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
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            map1.ThrowIfDisposed();
            map2.ThrowIfDisposed();
            CvScalar borderValue0 = borderValue.GetValueOrDefault(CvScalar.ScalarAll(0));
            CppInvoke.imgproc_remap(src.CvPtr, dst.CvPtr, map1.CvPtr, map2.CvPtr, (int)interpolation, (int)borderMode, borderValue0);
            dst.Fix();
        }
        #endregion
        #region ConvertMaps
        /// <summary>
        /// 
        /// </summary>
        /// <param name="map1"></param>
        /// <param name="map2"></param>
        /// <param name="dstmap1"></param>
        /// <param name="dstmap2"></param>
        /// <param name="dstmap1Type"></param>
        /// <param name="nnInterpolation"></param>
        public static void ConvertMaps(InputArray map1, InputArray map2, OutputArray dstmap1, OutputArray dstmap2, MatType dstmap1Type, bool nnInterpolation = false)
        {
            if (map1 == null)
                throw new ArgumentNullException("map1");
            if (map2 == null)
                throw new ArgumentNullException("map2");
            if (dstmap1 == null)
                throw new ArgumentNullException("dstmap1");
            if (dstmap2 == null)
                throw new ArgumentNullException("dstmap2");
            map1.ThrowIfDisposed();
            map2.ThrowIfDisposed();
            dstmap1.ThrowIfDisposed();
            dstmap2.ThrowIfDisposed();
            CppInvoke.imgproc_convertMaps(map1.CvPtr, map2.CvPtr, dstmap1.CvPtr, dstmap2.CvPtr, dstmap1Type, nnInterpolation ? 1 : 0);
            dstmap1.Fix();
            dstmap2.Fix();
        }
        #endregion

        #region GetRotationMatrix2D
        /// <summary>
        /// 
        /// </summary>
        /// <param name="center"></param>
        /// <param name="angle"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Mat GetRotationMatrix2D(Point2f center, double angle, double scale)
        {
            IntPtr ret = CppInvoke.imgproc_getRotationMatrix2D(center, angle, scale);
            return new Mat(ret);

        }
        #endregion
        #region InvertAffineTransform
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="im"></param>
        public static void InvertAffineTransform(InputArray m, OutputArray im)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            if (im == null)
                throw new ArgumentNullException("im");
            m.ThrowIfDisposed();
            im.ThrowIfNotReady();
            CppInvoke.imgproc_invertAffineTransform(m.CvPtr, im.CvPtr);
        }
        #endregion
        #region GetPerspectiveTransform
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        public static Mat GetPerspectiveTransform(IEnumerable<Point2f> src, IEnumerable<Point2f> dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            Point2f[] srcArray = Util.ToArray(src);
            Point2f[] dstArray = Util.ToArray(dst);
            IntPtr ret = CppInvoke.imgproc_getPerspectiveTransform(srcArray, dstArray);
            return new Mat(ret);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        public static Mat GetPerspectiveTransform(InputArray src, InputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            IntPtr ret = CppInvoke.imgproc_getPerspectiveTransform(src.CvPtr, dst.CvPtr);
            return new Mat(ret);
        }
        #endregion
        #region GetAffineTransform
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        public static Mat GetAffineTransform(IEnumerable<Point2f> src, IEnumerable<Point2f> dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            Point2f[] srcArray = Util.ToArray(src);
            Point2f[] dstArray = Util.ToArray(dst);
            IntPtr ret = CppInvoke.imgproc_getAffineTransform(srcArray, dstArray);
            return new Mat(ret);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        public static Mat GetAffineTransform(InputArray src, InputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            IntPtr ret = CppInvoke.imgproc_getAffineTransform(src.CvPtr, dst.CvPtr);
            return new Mat(ret);
        }
        #endregion
        #region GetRectSubPix
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="patchSize"></param>
        /// <param name="center"></param>
        /// <param name="patch"></param>
        /// <param name="patchType"></param>
        public static void GetRectSubPix(InputArray image, Size patchSize, Point2f center, OutputArray patch,
            int patchType = -1)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (patch == null)
                throw new ArgumentNullException("patch");
            image.ThrowIfDisposed();
            patch.ThrowIfNotReady();
            CppInvoke.imgproc_getRectSubPix(image.CvPtr, patchSize, center, patch.CvPtr, patchType);
            patch.Fix();
        }
        #endregion
        #region Integral
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="sum"></param>
        /// <param name="sdepth"></param>
        public static void Integral(InputArray src, OutputArray sum, int sdepth = -1)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (sum == null)
                throw new ArgumentNullException("sum");
            src.ThrowIfDisposed();
            sum.ThrowIfNotReady();
            CppInvoke.imgproc_integral(src.CvPtr, sum.CvPtr, sdepth);
            sum.Fix();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="sum"></param>
        /// <param name="sqsum"></param>
        /// <param name="sdepth"></param>
        public static void Integral(InputArray src, OutputArray sum, OutputArray sqsum, int sdepth = -1)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (sum == null)
                throw new ArgumentNullException("sum");
            if (sqsum == null)
                throw new ArgumentNullException("sqsum");
            src.ThrowIfDisposed();
            sum.ThrowIfNotReady();
            sqsum.ThrowIfNotReady();
            CppInvoke.imgproc_integral(src.CvPtr, sum.CvPtr, sqsum.CvPtr, sdepth);
            sum.Fix();
            sqsum.Fix();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="sum"></param>
        /// <param name="sqsum"></param>
        /// <param name="tilted"></param>
        /// <param name="sdepth"></param>
        public static void Integral(InputArray src, OutputArray sum, OutputArray sqsum, OutputArray tilted, int sdepth = -1)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (sum == null)
                throw new ArgumentNullException("sum");
            if (sqsum == null)
                throw new ArgumentNullException("sqsum");
            if (tilted == null)
                throw new ArgumentNullException("tilted");
            src.ThrowIfDisposed();
            sum.ThrowIfNotReady();
            sqsum.ThrowIfNotReady();
            tilted.ThrowIfNotReady();
            CppInvoke.imgproc_integral(src.CvPtr, sum.CvPtr, sqsum.CvPtr, tilted.CvPtr, sdepth);
            sum.Fix();
            sqsum.Fix();
            tilted.Fix();
        }
        #endregion
        #region Accumulate*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="mask"></param>
        public static void Accumulate(InputArray src, InputOutputArray dst, InputArray mask)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_accumulate(src.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="mask"></param>
        public static void AccumulateSquare(InputArray src, InputOutputArray dst, InputArray mask)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_accumulateSquare(src.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        /// <param name="mask"></param>
        public static void AccumulateProduct(InputArray src1, InputArray src2, InputOutputArray dst, InputArray mask)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_accumulateProduct(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="alpha"></param>
        /// <param name="mask"></param>
        public static void AccumulateWeighted(InputArray src, InputOutputArray dst, double alpha, InputArray mask)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_accumulateWeighted(src.CvPtr, dst.CvPtr, alpha, ToPtr(mask));
            dst.Fix();
        }
        #endregion
        #region PSNR
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
// ReSharper disable once InconsistentNaming
        public static double PSNR(InputArray src1, InputArray src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            return CppInvoke.imgproc_PSNR(src1.CvPtr, src2.CvPtr);
        }
        #endregion
        #region PhaseCorrelate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="window"></param>
        /// <returns></returns>
        public static Point2d PhaseCorrelate(InputArray src1, InputArray src2,
                                             InputArray window = null)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            return CppInvoke.imgproc_phaseCorrelate(src1.CvPtr, src2.CvPtr, ToPtr(window));
        }
        #endregion
        #region PhaseCorrelateRes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="window"></param>
        /// <returns></returns>
        public static Point2d PhaseCorrelateRes(InputArray src1, InputArray src2, InputArray window)
        {
            double response;
            return PhaseCorrelateRes(src1, src2, window, out response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="window"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public static Point2d PhaseCorrelateRes(InputArray src1, InputArray src2,
                                                InputArray window, out double response)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (window == null)
                throw new ArgumentNullException("src2");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            window.ThrowIfDisposed();
            return CppInvoke.imgproc_phaseCorrelateRes(src1.CvPtr, src2.CvPtr, window.CvPtr, out response);
        }
        #endregion
        #region CreateHanningWindow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="winSize"></param>
        /// <param name="type"></param>
        public static void CreateHanningWindow(OutputArray dst, Size winSize, int type)
        {
            if (dst == null)
                throw new ArgumentNullException("dst");
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_createHanningWindow(dst.CvPtr, winSize, type);
            dst.Fix();
        }
        #endregion
        #region Threshold
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="thresh"></param>
        /// <param name="maxval"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static double Threshold(InputArray src, OutputArray dst, double thresh, double maxval, ThresholdType type)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            double ret = CppInvoke.imgproc_threshold(src.CvPtr, dst.CvPtr, thresh, maxval, (int)type);
            dst.Fix();
            return ret;
        }
        #endregion
        #region AdaptiveThreshold
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="maxValue"></param>
        /// <param name="adaptiveMethod"></param>
        /// <param name="thresholdType"></param>
        /// <param name="blockSize"></param>
        /// <param name="c"></param>
        public static void AdaptiveThreshold(InputArray src, OutputArray dst,
            double maxValue, AdaptiveThresholdType adaptiveMethod, ThresholdType thresholdType, int blockSize, double c)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_adaptiveThreshold(src.CvPtr, dst.CvPtr, maxValue, (int)adaptiveMethod, (int)thresholdType, blockSize, c);
            dst.Fix();
        }
        #endregion
        #region PyrDown/Up
        /// <summary>
        /// smooths and downsamples the image
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="dstSize"></param>
        /// <param name="borderType"></param>
        public static void PyrDown(InputArray src, OutputArray dst,
            Size? dstSize = null, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            Size dstSize0 = dstSize.GetValueOrDefault(new Size());
            CppInvoke.imgproc_pyrDown(src.CvPtr, dst.CvPtr, dstSize0, (int)borderType);
            dst.Fix();
        }
        /// <summary>
        /// upsamples and smoothes the image
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="dstSize"></param>
        /// <param name="borderType"></param>
        public static void PyrUp(InputArray src, OutputArray dst,
            Size? dstSize = null, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            Size dstSize0 = dstSize.GetValueOrDefault(new Size());
            CppInvoke.imgproc_pyrUp(src.CvPtr, dst.CvPtr, dstSize0, (int)borderType);
            dst.Fix();
        }
        #endregion
        #region Undistort
        /// <summary>
        /// corrects lens distortion for the given camera matrix and distortion coefficients
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="cameraMatrix"></param>
        /// <param name="distCoeffs"></param>
        /// <param name="newCameraMatrix"></param>
        public static void Undistort(InputArray src, OutputArray dst,
            InputArray cameraMatrix,
            InputArray distCoeffs,
            InputArray newCameraMatrix = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (distCoeffs == null)
                throw new ArgumentNullException("distCoeffs");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            CppInvoke.imgproc_undistort(src.CvPtr, dst.CvPtr, cameraMatrix.CvPtr, distCoeffs.CvPtr, ToPtr(newCameraMatrix));
            dst.Fix();
        }
        #endregion
        #region InitUndistortRectifyMap
        /// <summary>
        /// initializes maps for cv::remap() to correct lens distortion and optionally rectify the image
        /// </summary>
        /// <param name="cameraMatrix"></param>
        /// <param name="distCoeffs"></param>
        /// <param name="r"></param>
        /// <param name="newCameraMatrix"></param>
        /// <param name="size"></param>
        /// <param name="m1Type"></param>
        /// <param name="map1"></param>
        /// <param name="map2"></param>
        public static void InitUndistortRectifyMap(InputArray cameraMatrix, InputArray distCoeffs,
            InputArray r, InputArray newCameraMatrix,
            Size size, MatType m1Type, OutputArray map1, OutputArray map2)
        {
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (distCoeffs == null)
                throw new ArgumentNullException("distCoeffs");
            if (r == null)
                throw new ArgumentNullException("r");
            if (newCameraMatrix == null)
                throw new ArgumentNullException("newCameraMatrix");
            if (map1 == null)
                throw new ArgumentNullException("map1");
            if (map2 == null)
                throw new ArgumentNullException("map2");
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            r.ThrowIfDisposed();
            newCameraMatrix.ThrowIfDisposed();
            map1.ThrowIfNotReady();
            map2.ThrowIfNotReady();
            CppInvoke.imgproc_initUndistortRectifyMap(
                cameraMatrix.CvPtr, distCoeffs.CvPtr, r.CvPtr, newCameraMatrix.CvPtr, size, m1Type, map1.CvPtr, map2.CvPtr);
            map1.Fix();
            map2.Fix();
        }
        #endregion
        #region InitWideAngleProjMap
        /// <summary>
        /// initializes maps for cv::remap() for wide-angle
        /// </summary>
        /// <param name="cameraMatrix"></param>
        /// <param name="distCoeffs"></param>
        /// <param name="imageSize"></param>
        /// <param name="destImageWidth"></param>
        /// <param name="m1Type"></param>
        /// <param name="map1"></param>
        /// <param name="map2"></param>
        /// <param name="projType"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static float InitWideAngleProjMap(InputArray cameraMatrix, InputArray distCoeffs,
            Size imageSize, int destImageWidth, MatType m1Type, OutputArray map1, OutputArray map2,
            ProjectionType projType, double alpha = 0)
        {
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (distCoeffs == null)
                throw new ArgumentNullException("distCoeffs");
            if (map1 == null)
                throw new ArgumentNullException("map1");
            if (map2 == null)
                throw new ArgumentNullException("map2");
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            map1.ThrowIfNotReady();
            map2.ThrowIfNotReady();
            float ret = CppInvoke.imgproc_initWideAngleProjMap(cameraMatrix.CvPtr, distCoeffs.CvPtr, imageSize,
                destImageWidth, m1Type, map1.CvPtr, map2.CvPtr, (int)projType, alpha);
            map1.Fix();
            map2.Fix();
            return ret;
        }
        #endregion
        #region GetDefaultNewCameraMatrix
        /// <summary>
        /// returns the default new camera matrix (by default it is the same as cameraMatrix unless centerPricipalPoint=true)
        /// </summary>
        /// <param name="cameraMatrix"></param>
        /// <param name="imgSize"></param>
        /// <param name="centerPrincipalPoint"></param>
        /// <returns></returns>
        public static Mat GetDefaultNewCameraMatrix(InputArray cameraMatrix,
            Size? imgSize = null, bool centerPrincipalPoint = false)
        {
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            cameraMatrix.ThrowIfDisposed();
            Size imgSize0 = imgSize.GetValueOrDefault(new Size());
            IntPtr matPtr = CppInvoke.imgproc_getDefaultNewCameraMatrix(cameraMatrix.CvPtr, imgSize0, centerPrincipalPoint ? 1 : 0);
            return new Mat(matPtr);
        }
        #endregion
        #region UndistortPoints
        /// <summary>
        /// returns points' coordinates after lens distortion correction
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="cameraMatrix"></param>
        /// <param name="distCoeffs"></param>
        /// <param name="r"></param>
        /// <param name="p"></param>
        public static void UndistortPoints(InputArray src, OutputArray dst,
            InputArray cameraMatrix, InputArray distCoeffs,
            InputArray r = null, InputArray p = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (distCoeffs == null)
                throw new ArgumentNullException("distCoeffs");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            CppInvoke.imgproc_undistortPoints(src.CvPtr, dst.CvPtr, cameraMatrix.CvPtr, distCoeffs.CvPtr, ToPtr(r), ToPtr(p));
            dst.Fix();
        }
        #endregion
        #region CalcHist
        /// <summary>
        /// computes the joint dense histogram for a set of images.
        /// </summary>
        /// <param name="images"></param>
        /// <param name="channels"></param>
        /// <param name="mask"></param>
        /// <param name="hist"></param>
        /// <param name="dims"></param>
        /// <param name="histSize"></param>
        /// <param name="ranges"></param>
        /// <param name="uniform"></param>
        /// <param name="accumulate"></param>
        public static void CalcHist(Mat[] images, 
            int[] channels, InputArray mask,
            OutputArray hist, int dims, int[] histSize,
            Rangef[] ranges, bool uniform = true, bool accumulate = false)
        {
            if (images == null)
                throw new ArgumentNullException("images");
            if (channels == null)
                throw new ArgumentNullException("channels");
            if (hist == null)
                throw new ArgumentNullException("hist");
            if (histSize == null)
                throw new ArgumentNullException("histSize");
            if (ranges == null)
                throw new ArgumentNullException("ranges");
            hist.ThrowIfNotReady();

            IntPtr[] imagesPtr = EnumerableEx.SelectPtrs(images);
            float[][] rangesFloat = EnumerableEx.SelectToArray(ranges, delegate(Rangef r)
            {
                return new float[2]{r.Start, r.End};
            });
            using (ArrayAddress2<float> rangesPtr = new ArrayAddress2<float>(rangesFloat))
            {
                CppInvoke.imgproc_calcHist1(imagesPtr, images.Length, channels, ToPtr(mask), hist.CvPtr, 
                    dims, histSize, rangesPtr, uniform ? 1 : 0, accumulate ? 1 : 0);
            }
            hist.Fix();
        }
        #endregion
        #region CalcBackProject
        /// <summary>
        /// computes the joint dense histogram for a set of images.
        /// </summary>
        /// <param name="images"></param>
        /// <param name="channels"></param>
        /// <param name="hist"></param>
        /// <param name="backProject"></param>
        /// <param name="ranges"></param>
        /// <param name="uniform"></param>
        public static void CalcBackProject(Mat[] images,
            int[] channels, InputArray hist, OutputArray backProject, 
            Rangef[] ranges, bool uniform = true)
        {
            if (images == null)
                throw new ArgumentNullException("images");
            if (channels == null)
                throw new ArgumentNullException("channels");
            if (hist == null)
                throw new ArgumentNullException("hist");
            if (backProject == null)
                throw new ArgumentNullException("backProject");
            if (ranges == null)
                throw new ArgumentNullException("ranges");
            hist.ThrowIfDisposed();
            backProject.ThrowIfNotReady();

            IntPtr[] imagesPtr = EnumerableEx.SelectPtrs(images);
            float[][] rangesFloat = EnumerableEx.SelectToArray(ranges, delegate(Rangef r)
            {
                return new float[2] { r.Start, r.End };
            });
            using (ArrayAddress2<float> rangesPtr = new ArrayAddress2<float>(rangesFloat))
            {
                CppInvoke.imgproc_calcBackProject(imagesPtr, images.Length, channels, hist.CvPtr,
                    backProject.CvPtr, rangesPtr, uniform ? 1 : 0);
            }
            backProject.Fix();
        }
        #endregion
        #region CompareHist
        /// <summary>
        /// compares two histograms stored in dense arrays
        /// </summary>
        /// <param name="h1">The first compared histogram</param>
        /// <param name="h2">The second compared histogram of the same size as h1</param>
        /// <param name="method">The comparison method</param>
        /// <returns></returns>
        public static double CompareHist(InputArray h1, InputArray h2, HistogramComparison method)
        {
            if (h1 == null)
                throw new ArgumentNullException("h1");
            if (h2 == null)
                throw new ArgumentNullException("h2");
            h1.ThrowIfDisposed();
            h2.ThrowIfDisposed();
            return CppInvoke.imgproc_compareHist1(h1.CvPtr, h2.CvPtr, (int)method);
        }
        #endregion
        #region EqualizeHist
        /// <summary>
        /// normalizes the grayscale image brightness and contrast by normalizing its histogram
        /// </summary>
        /// <param name="src">The source 8-bit single channel image</param>
        /// <param name="dst">The destination image; will have the same size and the same type as src</param>
        public static void EqualizeHist(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_equalizeHist(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }
        #endregion
        #region EMD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="signature1"></param>
        /// <param name="signature2"></param>
        /// <param name="distType"></param>
        /// <returns></returns>
        public static float EMD(InputArray signature1, InputArray signature2, DistanceType distType)
        {
            float lowerBound;
            return EMD(signature1, signature1, distType, null, out lowerBound, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="signature1"></param>
        /// <param name="signature2"></param>
        /// <param name="distType"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public static float EMD(InputArray signature1, InputArray signature2,
            DistanceType distType, InputArray cost)
        {
            float lowerBound;
            return EMD(signature1, signature1, distType, cost, out lowerBound, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="signature1"></param>
        /// <param name="signature2"></param>
        /// <param name="distType"></param>
        /// <param name="cost"></param>
        /// <param name="lowerBound"></param>
        /// <returns></returns>
        public static float EMD(InputArray signature1, InputArray signature2,
            DistanceType distType, InputArray cost, out float lowerBound)
        {
            return EMD(signature1, signature1, distType, cost, out lowerBound, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="signature1"></param>
        /// <param name="signature2"></param>
        /// <param name="distType"></param>
        /// <param name="cost"></param>
        /// <param name="lowerBound"></param>
        /// <param name="flow"></param>
        /// <returns></returns>
        public static float EMD(InputArray signature1, InputArray signature2,
            DistanceType distType, InputArray cost, out float lowerBound, OutputArray flow)
        {
            if (signature1 == null)
                throw new ArgumentNullException("signature1");
            if (signature2 == null)
                throw new ArgumentNullException("signature2");
            signature1.ThrowIfDisposed();
            signature2.ThrowIfDisposed();
            float ret = CppInvoke.imgproc_EMD(signature1.CvPtr, signature2.CvPtr, (int)distType, ToPtr(cost), out lowerBound, ToPtr(flow));
            if(flow != null)
                flow.Fix();
            return ret;
        }
        #endregion
        #region Watershed
        /// <summary>
        /// segments the image using watershed algorithm
        /// </summary>
        /// <param name="image"></param>
        /// <param name="markers"></param>
        public static void Watershed(InputArray image, InputOutputArray markers)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (markers == null)
                throw new ArgumentNullException("markers");
            image.ThrowIfDisposed();
            markers.ThrowIfNotReady();
            CppInvoke.imgproc_watershed(image.CvPtr, markers.CvPtr);
            markers.Fix();
        }
        #endregion
        #region PyrMeanShiftFiltering
        /// <summary>
        /// filters image using meanshift algorithm
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="sp"></param>
        /// <param name="sr"></param>
        /// <param name="maxLevel"></param>
        /// <param name="termcrit"></param>
        public static void PyrMeanShiftFiltering(InputArray src, OutputArray dst,
            double sp, double sr, int maxLevel = 1, TermCriteria? termcrit = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            TermCriteria termcrit0 = termcrit.GetValueOrDefault(
                new TermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 5, 1));
            CppInvoke.imgproc_pyrMeanShiftFiltering(src.CvPtr, dst.CvPtr, sp, sr, maxLevel, termcrit0);
            dst.Fix();
        }
        #endregion
        #region GrabCut
        /// <summary>
        /// segments the image using GrabCut algorithm
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <param name="rect"></param>
        /// <param name="bgdModel"></param>
        /// <param name="fgdModel"></param>
        /// <param name="iterCount"></param>
        /// <param name="mode"></param>
        public static void GrabCut(InputArray img, InputOutputArray mask, Rect rect,
                                   InputOutputArray bgdModel, InputOutputArray fgdModel,
                                   int iterCount, GrabCutFlag mode)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (mask == null)
                throw new ArgumentNullException("mask");
            if (bgdModel == null)
                throw new ArgumentNullException("bgdModel");
            if (fgdModel == null)
                throw new ArgumentNullException("fgdModel");
            img.ThrowIfDisposed();
            mask.ThrowIfNotReady();
            bgdModel.ThrowIfNotReady();
            fgdModel.ThrowIfNotReady();
            CppInvoke.imgproc_grabCut(img.CvPtr, mask.CvPtr, rect,
                bgdModel.CvPtr, fgdModel.CvPtr, iterCount, (int)mode);
            mask.Fix();
            bgdModel.Fix();
            fgdModel.Fix();
        }

        // ReSharper disable InconsistentNaming
        /// <summary>
        /// GrabCut mask value [background]
        /// </summary>
        public const int GC_BGD = 0;
        /// <summary>
        /// GrabCut mask value [foreground]
        /// </summary>
        public const int GC_FGD = 1;
        /// <summary>
        /// GrabCut mask value [most probably background]
        /// </summary>
        public const int GC_PR_BGD = 2;
        /// <summary>
        /// GrabCut mask value [most probably foreground]
        /// </summary>
        public const int GC_PR_FGD = 3; 
        // ReSharper restore InconsistentNaming
        #endregion
        #region DistanceTransform
        /// <summary>
        /// builds the discrete Voronoi diagram
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="labels"></param>
        /// <param name="distanceType"></param>
        /// <param name="maskSize"></param>
        /// <param name="labelType"></param>
        public static void DistanceTransformWithLabels(InputArray src,
                                                       OutputArray dst,
                                                       OutputArray labels,
                                                       DistanceType distanceType,
                                                       DistanceMaskSize maskSize,
                                                       DistTransformLabelType labelType = DistTransformLabelType.CComp)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (labels == null)
                throw new ArgumentNullException("labels");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            labels.ThrowIfNotReady();
            CppInvoke.imgproc_distanceTransformWithLabels(
                src.CvPtr, dst.CvPtr, labels.CvPtr, (int)distanceType, (int)maskSize, (int)labelType);
            dst.Fix();
            labels.Fix();
        }

        /// <summary>
        /// computes the distance transform map
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="distanceType"></param>
        /// <param name="maskSize"></param>
        public static void DistanceTransform(InputArray src,
                                             OutputArray dst,
                                             DistanceType distanceType,
                                             DistanceMaskSize maskSize)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_distanceTransform(
                src.CvPtr, dst.CvPtr, (int)distanceType, (int)maskSize);
            dst.Fix();
        }
        #endregion
        #region FloodFill
        /// <summary>
        /// fills the semi-uniform image region starting from the specified seed point
        /// </summary>
        /// <param name="image"></param>
        /// <param name="seedPoint"></param>
        /// <param name="newVal"></param>
        /// <returns></returns>
        public static int FloodFill(InputOutputArray image, Point seedPoint, Scalar newVal)
        {
            Rect rect;
            return FloodFill(image, seedPoint, newVal, out rect);
        }
        /// <summary>
        /// fills the semi-uniform image region starting from the specified seed point
        /// </summary>
        /// <param name="image"></param>
        /// <param name="seedPoint"></param>
        /// <param name="newVal"></param>
        /// <param name="rect"></param>
        /// <param name="loDiff"></param>
        /// <param name="upDiff"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static int FloodFill(InputOutputArray image,
                                    Point seedPoint, Scalar newVal, out Rect rect,
                                    Scalar? loDiff = null, Scalar? upDiff = null,
                                    FloodFillFlag flags = FloodFillFlag.Link4)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfNotReady();
            Scalar loDiff0 = loDiff.GetValueOrDefault(new Scalar());
            Scalar upDiff0 = upDiff.GetValueOrDefault(new Scalar());
            CvRect rect0;
            int ret = CppInvoke.imgproc_floodFill(image.CvPtr, seedPoint, newVal, out rect0,
                loDiff0, upDiff0, (int)flags);
            rect = rect0;
            image.Fix();
            return ret;
        }

        /// <summary>
        /// fills the semi-uniform image region and/or the mask starting from the specified seed point
        /// </summary>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        /// <param name="seedPoint"></param>
        /// <param name="newVal"></param>
        /// <returns></returns>
        public static int FloodFill(InputOutputArray image, InputOutputArray mask,
                                    Point seedPoint, Scalar newVal)
        {
            Rect rect;
            return FloodFill(image, mask, seedPoint, newVal, out rect);
        }
        /// <summary>
        /// fills the semi-uniform image region and/or the mask starting from the specified seed point
        /// </summary>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        /// <param name="seedPoint"></param>
        /// <param name="newVal"></param>
        /// <param name="rect"></param>
        /// <param name="loDiff"></param>
        /// <param name="upDiff"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static int FloodFill(InputOutputArray image, InputOutputArray mask,
                                    Point seedPoint, Scalar newVal, out Rect rect,
                                    Scalar? loDiff = null, Scalar? upDiff = null,
                                    FloodFillFlag flags = FloodFillFlag.Link4)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (mask == null)
                throw new ArgumentNullException("mask");
            image.ThrowIfNotReady();
            mask.ThrowIfNotReady();
            Scalar loDiff0 = loDiff.GetValueOrDefault(new Scalar());
            Scalar upDiff0 = upDiff.GetValueOrDefault(new Scalar());
            CvRect rect0;
            int ret = CppInvoke.imgproc_floodFill(image.CvPtr, mask.CvPtr, seedPoint, 
                newVal, out rect0, loDiff0, upDiff0, (int)flags);
            rect = rect0;
            image.Fix();
            mask.Fix();
            return ret;
        }
        #endregion
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
        public static void CvtColor(InputArray src, OutputArray dst, ColorConversion code, int dstCn = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            try
            {
                CppInvoke.imgproc_cvtColor(src.CvPtr, dst.CvPtr, (int)code, dstCn);
                dst.Fix();
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Moments
        /// <summary>
        /// computes moments of the rasterized shape or a vector of points
        /// </summary>
        /// <param name="array"></param>
        /// <param name="binaryImage"></param>
        /// <returns></returns>
        public static Moments Moments(InputArray array, bool binaryImage = false)
        {
            return new Moments(array, binaryImage);
        }
        #endregion
        #region MatchTemplate
        /// <summary>
        /// computes the proximity map for the raster template and the image where the template is searched for
        /// </summary>
        /// <param name="image"></param>
        /// <param name="templ"></param>
        /// <param name="result"></param>
        /// <param name="method"></param>
        public static void MatchTemplate(InputArray image, InputArray templ,
            OutputArray result, MatchTemplateMethod method)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (templ == null)
                throw new ArgumentNullException("templ");
            if (result == null)
                throw new ArgumentNullException("result");
            image.ThrowIfDisposed();
            templ.ThrowIfDisposed();
            result.ThrowIfNotReady();
            CppInvoke.imgproc_matchTemplate(image.CvPtr, templ.CvPtr, result.CvPtr, (int)method);
            result.Fix();
        }
        #endregion
        #region FindContours
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を検出します．
        /// </summary>
        /// <param name="image">入力画像，8ビット，シングルチャンネル．0以外のピクセルは 1として，0のピクセルは0のまま扱われます．
        /// また，この関数は，輪郭抽出処理中に入力画像 image の中身を書き換えます．</param>
        /// <param name="contours">検出された輪郭．各輪郭は，点のベクトルとして格納されます．</param>
        /// <param name="hierarchy">画像のトポロジーに関する情報を含む出力ベクトル．これは，輪郭数と同じ数の要素を持ちます．各輪郭 contours[i] に対して，
        /// 要素 hierarchy[i]のメンバにはそれぞれ，同じ階層レベルに存在する前後の輪郭，最初の子輪郭，および親輪郭の 
        /// contours インデックス（0 基準）がセットされます．また，輪郭 i において，前後，親，子の輪郭が存在しない場合，
        /// それに対応する hierarchy[i] の要素は，負の値になります．</param>
        /// <param name="mode">輪郭抽出モード</param>
        /// <param name="method">輪郭の近似手法</param>
        /// <param name="offset">オプションのオフセット．各輪郭点はこの値の分だけシフトします．これは，ROIの中で抽出された輪郭を，画像全体に対して位置づけて解析する場合に役立ちます．</param>
#else
        /// <summary>
        /// Finds contours in a binary image.
        /// </summary>
        /// <param name="image">Source, an 8-bit single-channel image. Non-zero pixels are treated as 1’s. 
        /// Zero pixels remain 0’s, so the image is treated as binary.
        /// The function modifies the image while extracting the contours.</param> 
        /// <param name="contours">Detected contours. Each contour is stored as a vector of points.</param>
        /// <param name="hierarchy">Optional output vector, containing information about the image topology. 
        /// It has as many elements as the number of contours. For each i-th contour contours[i], 
        /// the members of the elements hierarchy[i] are set to 0-based indices in contours of the next 
        /// and previous contours at the same hierarchical level, the first child contour and the parent contour, respectively. 
        /// If for the contour i there are no next, previous, parent, or nested contours, the corresponding elements of hierarchy[i] will be negative.</param>
        /// <param name="mode">Contour retrieval mode</param>
        /// <param name="method">Contour approximation method</param>
        /// <param name="offset"> Optional offset by which every contour point is shifted. 
        /// This is useful if the contours are extracted from the image ROI and then they should be analyzed in the whole image context.</param>
#endif
        public static void FindContours(InputOutputArray image, out Point[][] contours,
            out HiearchyIndex[] hierarchy, ContourRetrieval mode, ContourChain method, Point? offset = null)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfNotReady();

            CvPoint offset0 = offset.GetValueOrDefault(new Point());
            IntPtr contoursPtr, hierarchyPtr;
            CppInvoke.imgproc_findContours1_vector(image.CvPtr, out contoursPtr, out hierarchyPtr, (int)mode, (int)method, offset0);

            using (StdVectorVectorPoint contoursVec = new StdVectorVectorPoint(contoursPtr))
            using (StdVectorVec4i hierarchyVec = new StdVectorVec4i(hierarchyPtr))
            {
                contours = contoursVec.ToArray();
                Vec4i[] hierarchyOrg = hierarchyVec.ToArray();
                hierarchy = EnumerableEx.SelectToArray(hierarchyOrg, HiearchyIndex.FromVec4i);
            }
            image.Fix();
        }
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を検出します．
        /// </summary>
        /// <param name="image">入力画像，8ビット，シングルチャンネル．0以外のピクセルは 1として，0のピクセルは0のまま扱われます．
        /// また，この関数は，輪郭抽出処理中に入力画像 image の中身を書き換えます．</param>
        /// <param name="contours">検出された輪郭．各輪郭は，点のベクトルとして格納されます．</param>
        /// <param name="hierarchy">画像のトポロジーに関する情報を含む出力ベクトル．これは，輪郭数と同じ数の要素を持ちます．各輪郭 contours[i] に対して，
        /// 要素 hierarchy[i]のメンバにはそれぞれ，同じ階層レベルに存在する前後の輪郭，最初の子輪郭，および親輪郭の 
        /// contours インデックス（0 基準）がセットされます．また，輪郭 i において，前後，親，子の輪郭が存在しない場合，
        /// それに対応する hierarchy[i] の要素は，負の値になります．</param>
        /// <param name="mode">輪郭抽出モード</param>
        /// <param name="method">輪郭の近似手法</param>
        /// <param name="offset">オプションのオフセット．各輪郭点はこの値の分だけシフトします．これは，ROIの中で抽出された輪郭を，画像全体に対して位置づけて解析する場合に役立ちます．</param>
#else
        /// <summary>
        /// Finds contours in a binary image.
        /// </summary>
        /// <param name="image">Source, an 8-bit single-channel image. Non-zero pixels are treated as 1’s. 
        /// Zero pixels remain 0’s, so the image is treated as binary.
        /// The function modifies the image while extracting the contours.</param> 
        /// <param name="contours">Detected contours. Each contour is stored as a vector of points.</param>
        /// <param name="hierarchy">Optional output vector, containing information about the image topology. 
        /// It has as many elements as the number of contours. For each i-th contour contours[i], 
        /// the members of the elements hierarchy[i] are set to 0-based indices in contours of the next 
        /// and previous contours at the same hierarchical level, the first child contour and the parent contour, respectively. 
        /// If for the contour i there are no next, previous, parent, or nested contours, the corresponding elements of hierarchy[i] will be negative.</param>
        /// <param name="mode">Contour retrieval mode</param>
        /// <param name="method">Contour approximation method</param>
        /// <param name="offset"> Optional offset by which every contour point is shifted. 
        /// This is useful if the contours are extracted from the image ROI and then they should be analyzed in the whole image context.</param>
#endif
        public static void FindContours(InputOutputArray image, out Mat[] contours,
            OutputArray hierarchy, ContourRetrieval mode, ContourChain method, Point? offset = null)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (hierarchy == null)
                throw new ArgumentNullException("hierarchy");
            image.ThrowIfNotReady();
            hierarchy.ThrowIfNotReady();

            CvPoint offset0 = offset.GetValueOrDefault(new Point());
            IntPtr contoursPtr;
            CppInvoke.imgproc_findContours1_OutputArray(image.CvPtr, out contoursPtr, hierarchy.CvPtr, (int)mode, (int)method, offset0);

            using (StdVectorMat contoursVec = new StdVectorMat(contoursPtr))
            {
                contours = contoursVec.ToArray();
            }
            image.Fix();
            hierarchy.Fix();
        }

#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を検出します．
        /// </summary>
        /// <param name="image">入力画像，8ビット，シングルチャンネル．0以外のピクセルは 1として，0のピクセルは0のまま扱われます．
        /// また，この関数は，輪郭抽出処理中に入力画像 image の中身を書き換えます．</param>
        /// <param name="contours">検出された輪郭．各輪郭は，点のベクトルとして格納されます．</param>
        /// <param name="mode">輪郭抽出モード</param>
        /// <param name="method">輪郭の近似手法</param>
        /// <param name="offset">オプションのオフセット．各輪郭点はこの値の分だけシフトします．これは，ROIの中で抽出された輪郭を，画像全体に対して位置づけて解析する場合に役立ちます．</param>
#else
        /// <summary>
        /// Finds contours in a binary image.
        /// </summary>
        /// <param name="image">Source, an 8-bit single-channel image. Non-zero pixels are treated as 1’s. 
        /// Zero pixels remain 0’s, so the image is treated as binary.
        /// The function modifies the image while extracting the contours.</param> 
        /// <param name="contours">Detected contours. Each contour is stored as a vector of points.</param>
        /// <param name="mode">Contour retrieval mode</param>
        /// <param name="method">Contour approximation method</param>
        /// <param name="offset"> Optional offset by which every contour point is shifted. 
        /// This is useful if the contours are extracted from the image ROI and then they should be analyzed in the whole image context.</param>
#endif
        public static void FindContours(InputOutputArray image, out Point[][] contours,
            ContourRetrieval mode, ContourChain method, Point? offset = null)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfNotReady();

            CvPoint offset0 = offset.GetValueOrDefault(new Point());
            IntPtr contoursPtr;
            CppInvoke.imgproc_findContours2_vector(image.CvPtr, out contoursPtr, (int)mode, (int)method, offset0);

            using (StdVectorVectorPoint contoursVec = new StdVectorVectorPoint(contoursPtr))
            {
                contours = contoursVec.ToArray();
            }

            image.Fix();
        }
#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を検出します．
        /// </summary>
        /// <param name="image">入力画像，8ビット，シングルチャンネル．0以外のピクセルは 1として，0のピクセルは0のまま扱われます．
        /// また，この関数は，輪郭抽出処理中に入力画像 image の中身を書き換えます．</param>
        /// <param name="contours">検出された輪郭．各輪郭は，点のベクトルとして格納されます．</param>
        /// <param name="mode">輪郭抽出モード</param>
        /// <param name="method">輪郭の近似手法</param>
        /// <param name="offset">オプションのオフセット．各輪郭点はこの値の分だけシフトします．これは，ROIの中で抽出された輪郭を，画像全体に対して位置づけて解析する場合に役立ちます．</param>
#else
        /// <summary>
        /// Finds contours in a binary image.
        /// </summary>
        /// <param name="image">Source, an 8-bit single-channel image. Non-zero pixels are treated as 1’s. 
        /// Zero pixels remain 0’s, so the image is treated as binary.
        /// The function modifies the image while extracting the contours.</param> 
        /// <param name="contours">Detected contours. Each contour is stored as a vector of points.</param>
        /// <param name="mode">Contour retrieval mode</param>
        /// <param name="method">Contour approximation method</param>
        /// <param name="offset"> Optional offset by which every contour point is shifted. 
        /// This is useful if the contours are extracted from the image ROI and then they should be analyzed in the whole image context.</param>
#endif
        public static void FindContours(InputOutputArray image, out MatOfPoint[] contours,
            ContourRetrieval mode, ContourChain method, Point? offset = null)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfNotReady();

            CvPoint offset0 = offset.GetValueOrDefault(new Point());
            IntPtr contoursPtr;
            CppInvoke.imgproc_findContours2_OutputArray(image.CvPtr, out contoursPtr, (int)mode, (int)method, offset0);

            using (StdVectorMat contoursVec = new StdVectorMat(contoursPtr))
            {
                contours = contoursVec.ToArray<MatOfPoint>();
            }

            image.Fix();
        }
        #endregion
        #region DrawContours
#if LANG_JP
        /// <summary>
        /// 輪郭線，または内側が塗りつぶされた輪郭を描きます．
        /// </summary>
        /// <param name="image">出力画像</param>
        /// <param name="contours"> 入力される全輪郭．各輪郭は，点のベクトルとして格納されています．</param>
        /// <param name="contourIdx">描かれる輪郭を示します．これが負値の場合，すべての輪郭が描画されます．</param>
        /// <param name="color">輪郭の色．</param>
        /// <param name="thickness">輪郭線の太さ．これが負値の場合（例えば thickness=CV_FILLED ），輪郭の内側が塗りつぶされます．</param>
        /// <param name="lineType">線の連結性</param>
        /// <param name="hierarchy">階層に関するオプションの情報．これは，特定の輪郭だけを描画したい場合にのみ必要になります．</param>
        /// <param name="maxLevel">描画される輪郭の最大レベル．0ならば，指定された輪郭のみが描画されます．
        /// 1ならば，指定された輪郭と，それに入れ子になったすべての輪郭が描画されます．2ならば，指定された輪郭と，
        /// それに入れ子になったすべての輪郭，さらにそれに入れ子になったすべての輪郭が描画されます．このパラメータは， 
        /// hierarchy が有効な場合のみ考慮されます．</param>
        /// <param name="offset">輪郭をシフトするオプションパラメータ．指定された offset = (dx,dy) だけ，すべての描画輪郭がシフトされます．</param>
#else
        /// <summary>
        /// draws contours in the image
        /// </summary>
        /// <param name="image">Destination image.</param>
        /// <param name="contours">All the input contours. Each contour is stored as a point vector.</param>
        /// <param name="contourIdx">Parameter indicating a contour to draw. If it is negative, all the contours are drawn.</param>
        /// <param name="color">Color of the contours.</param>
        /// <param name="thickness">Thickness of lines the contours are drawn with. If it is negative (for example, thickness=CV_FILLED ), 
        /// the contour interiors are drawn.</param>
        /// <param name="lineType">Line connectivity. </param>
        /// <param name="hierarchy">Optional information about hierarchy. It is only needed if you want to draw only some of the contours</param>
        /// <param name="maxLevel">Maximal level for drawn contours. If it is 0, only the specified contour is drawn. 
        /// If it is 1, the function draws the contour(s) and all the nested contours. If it is 2, the function draws the contours, 
        /// all the nested contours, all the nested-to-nested contours, and so on. This parameter is only taken into account 
        /// when there is hierarchy available.</param>
        /// <param name="offset">Optional contour shift parameter. Shift all the drawn contours by the specified offset = (dx, dy)</param>
#endif
        public static void DrawContours(
            InputOutputArray image,
            IEnumerable<IEnumerable<Point>> contours,
            int contourIdx,
            Scalar color,
            int thickness = 1,
            LineType lineType = LineType.Link8,
            IEnumerable<HiearchyIndex> hierarchy = null,
            int maxLevel = Int32.MaxValue,
            Point? offset = null)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (contours == null)
                throw new ArgumentNullException("contours");
            image.ThrowIfNotReady();

            CvPoint offset0 = offset.GetValueOrDefault(new Point());
            Point[][] contoursArray = EnumerableEx.SelectToArray(contours, EnumerableEx.ToArray);
            int[] contourSize2 = EnumerableEx.SelectToArray(contoursArray, delegate(Point[] pts)
            {
                return pts.Length;
            });
            using (ArrayAddress2<Point> contoursPtr = new ArrayAddress2<Point>(contoursArray))
            {
                if (hierarchy == null)
                {
                    CppInvoke.imgproc_drawContours_vector(image.CvPtr, contoursPtr.Pointer, contoursArray.Length, contourSize2,
                        contourIdx, color, thickness, (int)lineType, IntPtr.Zero, 0, maxLevel, offset0);
                }
                else
                {
                    Vec4i[] hiearchyVecs = EnumerableEx.SelectToArray(hierarchy, delegate(HiearchyIndex hi)
                    {
                        return hi.ToVec4i();
                    });
                    CppInvoke.imgproc_drawContours_vector(image.CvPtr, contoursPtr.Pointer, contoursArray.Length, contourSize2,
                        contourIdx, color, thickness, (int)lineType, hiearchyVecs, hiearchyVecs.Length, maxLevel, offset0);
                }
            }

            image.Fix();
        }
#if LANG_JP
        /// <summary>
        /// 輪郭線，または内側が塗りつぶされた輪郭を描きます．
        /// </summary>
        /// <param name="image">出力画像</param>
        /// <param name="contours"> 入力される全輪郭．各輪郭は，点のベクトルとして格納されています．</param>
        /// <param name="contourIdx">描かれる輪郭を示します．これが負値の場合，すべての輪郭が描画されます．</param>
        /// <param name="color">輪郭の色．</param>
        /// <param name="thickness">輪郭線の太さ．これが負値の場合（例えば thickness=CV_FILLED ），輪郭の内側が塗りつぶされます．</param>
        /// <param name="lineType">線の連結性</param>
        /// <param name="hierarchy">階層に関するオプションの情報．これは，特定の輪郭だけを描画したい場合にのみ必要になります．</param>
        /// <param name="maxLevel">描画される輪郭の最大レベル．0ならば，指定された輪郭のみが描画されます．
        /// 1ならば，指定された輪郭と，それに入れ子になったすべての輪郭が描画されます．2ならば，指定された輪郭と，
        /// それに入れ子になったすべての輪郭，さらにそれに入れ子になったすべての輪郭が描画されます．このパラメータは， 
        /// hierarchy が有効な場合のみ考慮されます．</param>
        /// <param name="offset">輪郭をシフトするオプションパラメータ．指定された offset = (dx,dy) だけ，すべての描画輪郭がシフトされます．</param>
#else
        /// <summary>
        /// draws contours in the image
        /// </summary>
        /// <param name="image">Destination image.</param>
        /// <param name="contours">All the input contours. Each contour is stored as a point vector.</param>
        /// <param name="contourIdx">Parameter indicating a contour to draw. If it is negative, all the contours are drawn.</param>
        /// <param name="color">Color of the contours.</param>
        /// <param name="thickness">Thickness of lines the contours are drawn with. If it is negative (for example, thickness=CV_FILLED ), 
        /// the contour interiors are drawn.</param>
        /// <param name="lineType">Line connectivity. </param>
        /// <param name="hierarchy">Optional information about hierarchy. It is only needed if you want to draw only some of the contours</param>
        /// <param name="maxLevel">Maximal level for drawn contours. If it is 0, only the specified contour is drawn. 
        /// If it is 1, the function draws the contour(s) and all the nested contours. If it is 2, the function draws the contours, 
        /// all the nested contours, all the nested-to-nested contours, and so on. This parameter is only taken into account 
        /// when there is hierarchy available.</param>
        /// <param name="offset">Optional contour shift parameter. Shift all the drawn contours by the specified offset = (dx, dy)</param>
#endif
        public static void DrawContours(
            InputOutputArray image,
            IEnumerable<Mat> contours,
            int contourIdx,
            Scalar color,
            int thickness = 1,
            LineType lineType = LineType.Link8,
            Mat hierarchy = null,
            int maxLevel = Int32.MaxValue,
            Point? offset = null)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (contours == null)
                throw new ArgumentNullException("contours");
            image.ThrowIfNotReady();

            CvPoint offset0 = offset.GetValueOrDefault(new Point());
            IntPtr[] contoursPtr = EnumerableEx.SelectPtrs(contours);
            CppInvoke.imgproc_drawContours_InputArray(image.CvPtr, contoursPtr, contoursPtr.Length,
                        contourIdx, color, thickness, (int)lineType, ToPtr(hierarchy), maxLevel, offset0);
            image.Fix();
        }
        #endregion
        #region ApproxPolyDP

        /// <summary>
        /// approximates contour or a curve using Douglas-Peucker algorithm
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="approxCurve"></param>
        /// <param name="epsilon"></param>
        /// <param name="closed"></param>
        /// <returns></returns>
        public static void ApproxPolyDP(InputArray curve, OutputArray approxCurve, double epsilon, bool closed)
        {
            if (curve == null)
                throw new ArgumentNullException("curve");
            if (approxCurve == null)
                throw new ArgumentNullException("approxCurve");
            curve.ThrowIfDisposed();
            approxCurve.ThrowIfNotReady();
            CppInvoke.imgproc_approxPolyDP_InputArray(curve.CvPtr, approxCurve.CvPtr, epsilon, closed ? 1 : 0);
            approxCurve.Fix();
        }
        /// <summary>
        /// approximates contour or a curve using Douglas-Peucker algorithm
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="epsilon"></param>
        /// <param name="closed"></param>
        /// <returns></returns>
        public static Point[] ApproxPolyDP(IEnumerable<Point> curve, double epsilon, bool closed)
        {
            if(curve == null)
                throw new ArgumentNullException("curve");
            Point[] curveArray = EnumerableEx.ToArray(curve);
            IntPtr approxCurvePtr;
            CppInvoke.imgproc_approxPolyDP_Point(curveArray, curveArray.Length, out approxCurvePtr, epsilon, closed ? 1 : 0);
            using (StdVectorPoint2i approxCurveVec = new StdVectorPoint2i(approxCurvePtr))
            {
                return approxCurveVec.ToArray();
            }
        }
        /// <summary>
        /// approximates contour or a curve using Douglas-Peucker algorithm
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="epsilon"></param>
        /// <param name="closed"></param>
        /// <returns></returns>
        public static Point2f[] ApproxPolyDP(IEnumerable<Point2f> curve, double epsilon, bool closed)
        {
            if (curve == null)
                throw new ArgumentNullException("curve");
            Point2f[] curveArray = EnumerableEx.ToArray(curve);
            IntPtr approxCurvePtr;
            CppInvoke.imgproc_approxPolyDP_Point2f(curveArray, curveArray.Length, out approxCurvePtr, epsilon, closed ? 1 : 0);
            using (StdVectorPoint2f approxCurveVec = new StdVectorPoint2f(approxCurvePtr))
            {
                return approxCurveVec.ToArray();
            }
        }
        #endregion
        #region ArcLength
        /// <summary>
        /// computes the contour perimeter (closed=true) or a curve length
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="closed"></param>
        /// <returns></returns>
        public static double ArcLength(InputArray curve, bool closed)
        {
            if (curve == null)
                throw new ArgumentNullException("curve");
            curve.ThrowIfDisposed();
            return CppInvoke.imgproc_arcLength_InputArray(curve.CvPtr, closed ? 1 : 0);
        }
        /// <summary>
        /// computes the contour perimeter (closed=true) or a curve length
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="closed"></param>
        /// <returns></returns>
        public static double ArcLength(IEnumerable<Point> curve, bool closed)
        {
            if (curve == null)
                throw new ArgumentNullException("curve");
            Point[] curveArray = EnumerableEx.ToArray(curve);
            return CppInvoke.imgproc_arcLength_Point(curveArray, curveArray.Length, closed ? 1 : 0);
        }
        /// <summary>
        /// computes the contour perimeter (closed=true) or a curve length
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="closed"></param>
        /// <returns></returns>
        public static double ArcLength(IEnumerable<Point2f> curve, bool closed)
        {
            if (curve == null)
                throw new ArgumentNullException("curve");
            Point2f[] curveArray = EnumerableEx.ToArray(curve);
            return CppInvoke.imgproc_arcLength_Point2f(curveArray, curveArray.Length, closed ? 1 : 0);
        }
        #endregion
        #region BoundingRect
        /// <summary>
        /// computes the bounding rectangle for a contour
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        public static Rect BoundingRect(InputArray curve)
        {
            if (curve == null)
                throw new ArgumentNullException("curve");
            curve.ThrowIfDisposed();
            return CppInvoke.imgproc_boundingRect_InputArray(curve.CvPtr);
        }
        /// <summary>
        /// computes the bounding rectangle for a contour
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        public static Rect BoundingRect(IEnumerable<Point> curve)
        {
            if (curve == null)
                throw new ArgumentNullException("curve");
            Point[] curveArray = EnumerableEx.ToArray(curve);
            return CppInvoke.imgproc_boundingRect_Point(curveArray, curveArray.Length);
        }
        /// <summary>
        /// computes the bounding rectangle for a contour
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        public static Rect BoundingRect(IEnumerable<Point2f> curve)
        {
            if (curve == null)
                throw new ArgumentNullException("curve");
            Point2f[] curveArray = EnumerableEx.ToArray(curve);
            return CppInvoke.imgproc_boundingRect_Point2f(curveArray, curveArray.Length);
        }
        #endregion
        #region ContourArea
        /// <summary>
        /// computes the contour area
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="oriented"></param>
        /// <returns></returns>
        public static double ContourArea(InputArray contour, bool oriented = false)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            contour.ThrowIfDisposed();
            return CppInvoke.imgproc_contourArea_InputArray(contour.CvPtr, oriented ? 1 : 0);
        }
        /// <summary>
        /// computes the contour area
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="oriented"></param>
        /// <returns></returns>
        public static double ContourArea(IEnumerable<Point> contour, bool oriented = false)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            Point[] contourArray = EnumerableEx.ToArray(contour);
            return CppInvoke.imgproc_contourArea_Point(contourArray, contourArray.Length, oriented ? 1 : 0);
        }
        /// <summary>
        /// computes the contour area
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="oriented"></param>
        /// <returns></returns>
        public static double ContourArea(IEnumerable<Point2f> contour, bool oriented = false)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            Point2f[] contourArray = EnumerableEx.ToArray(contour);
            return CppInvoke.imgproc_contourArea_Point2f(contourArray, contourArray.Length, oriented ? 1 : 0);
        }
        #endregion
        #region MinAreaRect
        /// <summary>
        /// computes the minimal rotated rectangle for a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static RotatedRect MinAreaRect(InputArray points)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            points.ThrowIfDisposed();
            return CppInvoke.imgproc_minAreaRect_InputArray(points.CvPtr);
        }
        /// <summary>
        /// computes the minimal rotated rectangle for a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static RotatedRect MinAreaRect(IEnumerable<Point> points)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point[] pointsArray = EnumerableEx.ToArray(points);
            return CppInvoke.imgproc_minAreaRect_Point(pointsArray, pointsArray.Length);
        }
        /// <summary>
        /// computes the minimal rotated rectangle for a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static RotatedRect MinAreaRect(IEnumerable<Point2f> points)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point2f[] pointsArray = EnumerableEx.ToArray(points);
            return CppInvoke.imgproc_minAreaRect_Point2f(pointsArray, pointsArray.Length);
        }
        #endregion
        #region MinEnclosingCircle
        /// <summary>
        /// computes the minimal enclosing circle for a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public static void MinEnclosingCircle(InputArray points, out Point2f center, out float radius)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            points.ThrowIfDisposed();
            CppInvoke.imgproc_minEnclosingCircle_InputArray(points.CvPtr, out center, out radius);
        }
        /// <summary>
        /// computes the minimal enclosing circle for a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public static void MinEnclosingCircle(IEnumerable<Point> points, out Point2f center, out float radius)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point[] pointsArray = EnumerableEx.ToArray(points);
            CppInvoke.imgproc_minEnclosingCircle_Point(pointsArray, pointsArray.Length, out center, out radius);
        }
        /// <summary>
        /// computes the minimal enclosing circle for a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public static void MinEnclosingCircle(IEnumerable<Point2f> points, out Point2f center, out float radius)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point2f[] pointsArray = EnumerableEx.ToArray(points);
            CppInvoke.imgproc_minEnclosingCircle_Point2f(pointsArray, pointsArray.Length, out center, out radius);
        }
        #endregion
        #region MatchShapes
        /// <summary>
        /// matches two contours using one of the available algorithms
        /// </summary>
        /// <param name="contour1"></param>
        /// <param name="contour2"></param>
        /// <param name="method"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static double MatchShapes(InputArray contour1, InputArray contour2, MatchShapesMethod method, double parameter = 0)
        {
            if (contour1 == null)
                throw new ArgumentNullException("contour1");
            if (contour2 == null)
                throw new ArgumentNullException("contour2");
            return CppInvoke.imgproc_matchShapes_InputArray(contour1.CvPtr, contour2.CvPtr, (int)method, parameter);
        }
        /// <summary>
        /// matches two contours using one of the available algorithms
        /// </summary>
        /// <param name="contour1"></param>
        /// <param name="contour2"></param>
        /// <param name="method"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static double MatchShapes(IEnumerable<Point> contour1, IEnumerable<Point> contour2,
            MatchShapesMethod method, double parameter = 0)
        {
            if (contour1 == null)
                throw new ArgumentNullException("contour1");
            if (contour2 == null)
                throw new ArgumentNullException("contour2");
            Point[] contour1Array = EnumerableEx.ToArray(contour1);
            Point[] contour2Array = EnumerableEx.ToArray(contour2);
            return CppInvoke.imgproc_matchShapes_Point(contour1Array, contour1Array.Length, 
                contour2Array, contour2Array.Length, (int)method, parameter);
        }
        #endregion
        #region ConvexHull
        /// <summary>
        /// computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="hull"></param>
        /// <param name="clockwise"></param>
        /// <param name="returnPoints"></param>
        /// <returns></returns>
        public static void ConvexHull(InputArray points, OutputArray hull, bool clockwise = false, bool returnPoints = true)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            if (hull == null)
                throw new ArgumentNullException("hull");
            points.ThrowIfDisposed();
            hull.ThrowIfNotReady();
            CppInvoke.imgproc_convexHull_InputArray(points.CvPtr, hull.CvPtr, clockwise ? 1 : 0, returnPoints ? 1 : 0);
            hull.Fix();
        }
        /// <summary>
        /// computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="clockwise"></param>
        /// <returns></returns>
        public static Point[] ConvexHull(IEnumerable<Point> points, bool clockwise = false)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point[] pointsArray = EnumerableEx.ToArray(points);
            IntPtr hullPtr;
            CppInvoke.imgproc_convexHull_Point_ReturnsPoints(pointsArray, pointsArray.Length, out hullPtr, clockwise ? 1 : 0);
            using (StdVectorPoint2i hullVec = new StdVectorPoint2i(hullPtr))
            {
                return hullVec.ToArray();
            }
        }
        /// <summary>
        /// computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="clockwise"></param>
        /// <returns></returns>
        public static Point2f[] ConvexHull(IEnumerable<Point2f> points, bool clockwise = false)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point2f[] pointsArray = EnumerableEx.ToArray(points);
            IntPtr hullPtr;
            CppInvoke.imgproc_convexHull_Point2f_ReturnsPoints(pointsArray, pointsArray.Length, out hullPtr,
                clockwise ? 1 : 0);
            using (StdVectorPoint2f hullVec = new StdVectorPoint2f(hullPtr))
            {
                return hullVec.ToArray();
            }
        }
        /// <summary>
        /// computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="clockwise"></param>
        /// <returns></returns>
        public static int[] ConvexHullIndices(IEnumerable<Point> points, bool clockwise = false)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point[] pointsArray = EnumerableEx.ToArray(points);
            IntPtr hullPtr;
            CppInvoke.imgproc_convexHull_Point_ReturnsIndices(pointsArray, pointsArray.Length, out hullPtr, clockwise ? 1 : 0);
            using (StdVectorInt32 hullVec = new StdVectorInt32(hullPtr))
            {
                return hullVec.ToArray();
            }
        }
        /// <summary>
        /// computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="clockwise"></param>
        /// <returns></returns>
        public static int[] ConvexHullIndices(IEnumerable<Point2f> points, bool clockwise = false)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point2f[] pointsArray = EnumerableEx.ToArray(points);
            IntPtr hullPtr;
            CppInvoke.imgproc_convexHull_Point2f_ReturnsIndices(pointsArray, pointsArray.Length, out hullPtr, clockwise ? 1 : 0);
            using (StdVectorInt32 hullVec = new StdVectorInt32(hullPtr))
            {
                return hullVec.ToArray();
            }
        }
        #endregion
        #region ConvexityDefects

        /// <summary>
        /// computes the contour convexity defects
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="convexHull"></param>
        /// <param name="convexityDefects"></param>
        /// <returns></returns>
        public static void ConvexityDefects(InputArray contour, InputArray convexHull, OutputArray convexityDefects)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            if (convexHull == null)
                throw new ArgumentNullException("convexHull");
            if (convexityDefects == null)
                throw new ArgumentNullException("convexityDefects");
            contour.ThrowIfDisposed();
            convexHull.ThrowIfDisposed();
            convexityDefects.ThrowIfNotReady();
            CppInvoke.imgproc_convexityDefects_InputArray(contour.CvPtr, convexHull.CvPtr, convexityDefects.CvPtr);
            convexityDefects.Fix();
        }
        /// <summary>
        /// computes the contour convexity defects
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="convexHull"></param>
        /// <returns></returns>
        public static Vec4i[] ConvexityDefects(IEnumerable<Point> contour, IEnumerable<int> convexHull)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            if (convexHull == null)
                throw new ArgumentNullException("convexHull");
            Point[] contourArray = EnumerableEx.ToArray(contour);
            int[] convexHullArray = EnumerableEx.ToArray(convexHull);
            IntPtr convexityDefectsPtr;
            CppInvoke.imgproc_convexityDefects_Point(contourArray, contourArray.Length,
                convexHullArray, convexHullArray.Length, out convexityDefectsPtr);

            using (StdVectorVec4i convexityDefects = new StdVectorVec4i(convexityDefectsPtr))
            {
                return convexityDefects.ToArray();
            }
        }
        /// <summary>
        /// computes the contour convexity defects
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="convexHull"></param>
        /// <returns></returns>
        public static Vec4i[] ConvexityDefects(IEnumerable<Point2f> contour, IEnumerable<int> convexHull)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            if (convexHull == null)
                throw new ArgumentNullException("convexHull");
            Point2f[] contourArray = EnumerableEx.ToArray(contour);
            int[] convexHullArray = EnumerableEx.ToArray(convexHull);
            IntPtr convexityDefectsPtr;
            CppInvoke.imgproc_convexityDefects_Point2f(contourArray, contourArray.Length,
                convexHullArray, convexHullArray.Length, out convexityDefectsPtr);

            using (StdVectorVec4i convexityDefects = new StdVectorVec4i(convexityDefectsPtr))
            {
                return convexityDefects.ToArray();
            }
        }
        #endregion
        #region IsContourConvex
        /// <summary>
        /// returns true if the contour is convex. Does not support contours with self-intersection
        /// </summary>
        /// <param name="contour"></param>
        /// <returns></returns>
        public static bool IsContourConvex(InputArray contour)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            contour.ThrowIfDisposed();
            int ret = CppInvoke.imgproc_isContourConvex_InputArray(contour.CvPtr);
            return ret != 0;
        }
        /// <summary>
        /// returns true if the contour is convex. Does not support contours with self-intersection
        /// </summary>
        /// <param name="contour"></param>
        /// <returns></returns>
        public static bool IsContourConvex(IEnumerable<Point> contour)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            Point[] contourArray = EnumerableEx.ToArray(contour);
            int ret = CppInvoke.imgproc_isContourConvex_Point(contourArray, contourArray.Length);
            return ret != 0;
        }
        /// <summary>
        /// returns true if the contour is convex. Does not support contours with self-intersection
        /// </summary>
        /// <param name="contour"></param>
        /// <returns></returns>
        public static bool IsContourConvex(IEnumerable<Point2f> contour)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            Point2f[] contourArray = EnumerableEx.ToArray(contour);
            int ret = CppInvoke.imgproc_isContourConvex_Point2f(contourArray, contourArray.Length);
            return ret != 0;
        }
        #endregion
        #region IntersectConvexConvex
        /// <summary>
        /// finds intersection of two convex polygons
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p12"></param>
        /// <param name="handleNested"></param>
        /// <returns></returns>
        public static float IntersectConvexConvex(InputArray p1, InputArray p2, OutputArray p12, bool handleNested = true)
        {
            if (p1 == null)
                throw new ArgumentNullException("p1");
            if (p2 == null)
                throw new ArgumentNullException("p2");
            if (p12 == null)
                throw new ArgumentNullException("p12");
            p1.ThrowIfDisposed();
            p2.ThrowIfDisposed();
            p12.ThrowIfNotReady();
            float ret = CppInvoke.imgproc_intersectConvexConvex_InputArray(p1.CvPtr, p2.CvPtr, p12.CvPtr, handleNested ? 1 : 0);
            p12.Fix();
            return ret;
        }
        /// <summary>
        /// finds intersection of two convex polygons
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p12"></param>
        /// <param name="handleNested"></param>
        /// <returns></returns>
        public static float IntersectConvexConvex(IEnumerable<Point> p1, IEnumerable<Point> p2,
            out Point[] p12, bool handleNested = true)
        {
            if (p1 == null)
                throw new ArgumentNullException("p1");
            if (p2 == null)
                throw new ArgumentNullException("p2");
            Point[] p1Array = EnumerableEx.ToArray(p1);
            Point[] p2Array = EnumerableEx.ToArray(p2);
            IntPtr p12Ptr;
            float ret = CppInvoke.imgproc_intersectConvexConvex_Point(p1Array, p1Array.Length, p2Array, p2Array.Length, 
                out p12Ptr, handleNested ? 1 : 0);

            using (StdVectorPoint2i p12Vec = new StdVectorPoint2i(p12Ptr))
            {
                p12 = p12Vec.ToArray();
            }

            return ret;
        }
        /// <summary>
        /// finds intersection of two convex polygons
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p12"></param>
        /// <param name="handleNested"></param>
        /// <returns></returns>
        public static float IntersectConvexConvex(IEnumerable<Point2f> p1, IEnumerable<Point2f> p2,
            out Point2f[] p12, bool handleNested = true)
        {
            if (p1 == null)
                throw new ArgumentNullException("p1");
            if (p2 == null)
                throw new ArgumentNullException("p2");
            Point2f[] p1Array = EnumerableEx.ToArray(p1);
            Point2f[] p2Array = EnumerableEx.ToArray(p2);
            IntPtr p12Ptr;
            float ret = CppInvoke.imgproc_intersectConvexConvex_Point2f(p1Array, p1Array.Length, p2Array, p2Array.Length,
                out p12Ptr, handleNested ? 1 : 0);

            using (StdVectorPoint2f p12Vec = new StdVectorPoint2f(p12Ptr))
            {
                p12 = p12Vec.ToArray();
            }

            return ret;
        }
        #endregion
        #region FitEllipse
        /// <summary>
        /// fits ellipse to the set of 2D points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static RotatedRect FitEllipse(InputArray points)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            points.ThrowIfDisposed();
            return CppInvoke.imgproc_fitEllipse_InputArray(points.CvPtr);
        }
        /// <summary>
        /// fits ellipse to the set of 2D points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static RotatedRect FitEllipse(IEnumerable<Point> points)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point[] pointsArray = EnumerableEx.ToArray(points);
            return CppInvoke.imgproc_fitEllipse_Point(pointsArray, pointsArray.Length);
        }
        /// <summary>
        /// fits ellipse to the set of 2D points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static RotatedRect FitEllipse(IEnumerable<Point2f> points)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point2f[] pointsArray = EnumerableEx.ToArray(points);
            return CppInvoke.imgproc_fitEllipse_Point2f(pointsArray, pointsArray.Length);
        }
        #endregion
        #region FitLine

        /// <summary>
        /// fits line to the set of 2D points using M-estimator algorithm
        /// </summary>
        /// <param name="points"></param>
        /// <param name="line"></param>
        /// <param name="distType"></param>
        /// <param name="param"></param>
        /// <param name="reps"></param>
        /// <param name="aeps"></param>
        /// <returns></returns>
        public static void FitLine(InputArray points, OutputArray line, DistanceType distType,
            double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            if (line == null)
                throw new ArgumentNullException("line");
            points.ThrowIfDisposed();
            line.ThrowIfNotReady();
            CppInvoke.imgproc_fitLine_InputArray(points.CvPtr, line.CvPtr, (int)distType, param, reps, aeps);
            line.Fix();
        }
        /// <summary>
        /// fits line to the set of 2D points using M-estimator algorithm
        /// </summary>
        /// <param name="points"></param>
        /// <param name="distType"></param>
        /// <param name="param"></param>
        /// <param name="reps"></param>
        /// <param name="aeps"></param>
        /// <returns></returns>
        public static CvLine2D FitLine(IEnumerable<Point> points, DistanceType distType,
            double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point[] pointsArray = EnumerableEx.ToArray(points);
            float[] line = new float[4];
            CppInvoke.imgproc_fitLine_Point(pointsArray, pointsArray.Length, line, (int)distType, param, reps, aeps);
            return new CvLine2D(line);
        }
        /// <summary>
        /// fits line to the set of 2D points using M-estimator algorithm
        /// </summary>
        /// <param name="points"></param>
        /// <param name="distType"></param>
        /// <param name="param"></param>
        /// <param name="reps"></param>
        /// <param name="aeps"></param>
        /// <returns></returns>
        public static CvLine2D FitLine(IEnumerable<Point2f> points, DistanceType distType,
            double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point2f[] pointsArray = EnumerableEx.ToArray(points);
            float[] line = new float[4];
            CppInvoke.imgproc_fitLine_Point2f(pointsArray, pointsArray.Length, line, (int)distType, param, reps, aeps);
            return new CvLine2D(line);
        }
        /// <summary>
        /// fits line to the set of 2D points using M-estimator algorithm
        /// </summary>
        /// <param name="points"></param>
        /// <param name="distType"></param>
        /// <param name="param"></param>
        /// <param name="reps"></param>
        /// <param name="aeps"></param>
        /// <returns></returns>
        public static CvLine3D FitLine(IEnumerable<Point3i> points, DistanceType distType,
            double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point3i[] pointsArray = EnumerableEx.ToArray(points);
            float[] line = new float[6];
            CppInvoke.imgproc_fitLine_Point3i(pointsArray, pointsArray.Length, line, (int)distType, param, reps, aeps);
            return new CvLine3D(line);
        }
        /// <summary>
        /// fits line to the set of 2D points using M-estimator algorithm
        /// </summary>
        /// <param name="points"></param>
        /// <param name="distType"></param>
        /// <param name="param"></param>
        /// <param name="reps"></param>
        /// <param name="aeps"></param>
        /// <returns></returns>
        public static CvLine3D FitLine(IEnumerable<Point3f> points, DistanceType distType,
            double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            Point3f[] pointsArray = EnumerableEx.ToArray(points);
            float[] line = new float[6];
            CppInvoke.imgproc_fitLine_Point3f(pointsArray, pointsArray.Length, line, (int)distType, param, reps, aeps);
            return new CvLine3D(line);
        }
        #endregion
        #region PointPolygonTest
        /// <summary>
        /// checks if the point is inside the contour. Optionally computes the signed distance from the point to the contour boundary
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="pt"></param>
        /// <param name="measureDist"></param>
        /// <returns></returns>
        public static double PointPolygonTest(InputArray contour, Point2f pt, bool measureDist)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            contour.ThrowIfDisposed();
            return CppInvoke.imgproc_pointPolygonTest_InputArray(contour.CvPtr, pt, measureDist ? 1 : 0);
        }
        /// <summary>
        /// checks if the point is inside the contour. Optionally computes the signed distance from the point to the contour boundary
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="pt"></param>
        /// <param name="measureDist"></param>
        /// <returns></returns>
        public static double PointPolygonTest(IEnumerable<Point> contour, Point2f pt, bool measureDist)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            Point[] contourArray = EnumerableEx.ToArray(contour);
            return CppInvoke.imgproc_pointPolygonTest_Point(contourArray, contourArray.Length, pt, measureDist ? 1 : 0);
        }
        /// <summary>
        /// checks if the point is inside the contour. Optionally computes the signed distance from the point to the contour boundary
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="pt"></param>
        /// <param name="measureDist"></param>
        /// <returns></returns>
        public static double PointPolygonTest(IEnumerable<Point2f> contour, Point2f pt, bool measureDist)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            Point2f[] contourArray = EnumerableEx.ToArray(contour);
            return CppInvoke.imgproc_pointPolygonTest_Point2f(contourArray, contourArray.Length, pt, measureDist ? 1 : 0);
        }
        #endregion
    }
}
