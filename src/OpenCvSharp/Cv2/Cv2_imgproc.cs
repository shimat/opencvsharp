using System;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp.Util;

// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo

namespace OpenCvSharp
{
    static partial class Cv2
    {
        /// <summary>
        /// Returns Gaussian filter coefficients.
        /// </summary>
        /// <param name="ksize">Aperture size. It should be odd and positive.</param>
        /// <param name="sigma">Gaussian standard deviation.
        /// If it is non-positive, it is computed from ksize as `sigma = 0.3*((ksize-1)*0.5 - 1) + 0.8`.</param>
        /// <param name="ktype">Type of filter coefficients. It can be CV_32F or CV_64F.</param>
        /// <returns></returns>
        public static Mat? GetGaussianKernel(int ksize, double sigma, MatType? ktype = null)
        {
            var ktype0 = ktype.GetValueOrDefault(MatType.CV_64F);
            NativeMethods.HandleException(
                NativeMethods.imgproc_getGaussianKernel(ksize, sigma, ktype0, out var ret));
            if (ret == IntPtr.Zero)
                return null;
            return new Mat(ret);
        }

        /// <summary>
        /// Returns filter coefficients for computing spatial image derivatives.
        /// </summary>
        /// <param name="kx">Output matrix of row filter coefficients. It has the type ktype.</param>
        /// <param name="ky">Output matrix of column filter coefficients. It has the type ktype.</param>
        /// <param name="dx">Derivative order in respect of x.</param>
        /// <param name="dy">Derivative order in respect of y.</param>
        /// <param name="ksize">Aperture size. It can be CV_SCHARR, 1, 3, 5, or 7.</param>
        /// <param name="normalize">Flag indicating whether to normalize (scale down) the filter coefficients or not.
        /// Theoretically, the coefficients should have the denominator \f$=2^{ksize*2-dx-dy-2}\f$. 
        /// If you are going to filter floating-point images, you are likely to use the normalized kernels.
        /// But if you compute derivatives of an 8-bit image, store the results in a 16-bit image, 
        /// and wish to preserve all the fractional bits, you may want to set normalize = false.</param>
        /// <param name="ktype">Type of filter coefficients. It can be CV_32f or CV_64F.</param>
        public static void GetDerivKernels(
            OutputArray kx, OutputArray ky, int dx, int dy, int ksize,
            bool normalize = false, MatType? ktype = null)
        {
            if (kx == null)
                throw new ArgumentNullException(nameof(kx));
            if (ky == null)
                throw new ArgumentNullException(nameof(ky));
            kx.ThrowIfNotReady();
            ky.ThrowIfNotReady();

            var ktype0 = ktype.GetValueOrDefault(MatType.CV_32F);
            NativeMethods.HandleException(
                NativeMethods.imgproc_getDerivKernels(
                    kx.CvPtr, ky.CvPtr, dx, dy, ksize, normalize ? 1 : 0, ktype0));
            GC.KeepAlive(kx);
            GC.KeepAlive(ky);
            kx.Fix();
            ky.Fix();
        }

        /// <summary>
        /// Returns Gabor filter coefficients. 
        /// </summary>
        /// <remarks>
        /// For more details about gabor filter equations and parameters, see: https://en.wikipedia.org/wiki/Gabor_filter
        /// </remarks>
        /// <param name="ksize">Size of the filter returned.</param>
        /// <param name="sigma">Standard deviation of the gaussian envelope.</param>
        /// <param name="theta">Orientation of the normal to the parallel stripes of a Gabor function.</param>
        /// <param name="lambd">Wavelength of the sinusoidal factor.</param>
        /// <param name="gamma">Spatial aspect ratio.</param>
        /// <param name="psi">Phase offset.</param>
        /// <param name="ktype">Type of filter coefficients. It can be CV_32F or CV_64F.</param>
        /// <returns></returns>
        public static Mat GetGaborKernel(Size ksize, double sigma, double theta, double lambd, double gamma, double psi, int ktype)
        {
            NativeMethods.HandleException(
                NativeMethods.imgproc_getGaborKernel(ksize, sigma, theta, lambd, gamma, psi, ktype, out var matPtr));
            return new Mat(matPtr);
        }

        /// <summary>
        /// Returns a structuring element of the specified size and shape for morphological operations.
        /// The function constructs and returns the structuring element that can be further passed to erode,
        /// dilate or morphologyEx.But you can also construct an arbitrary binary mask yourself and use it as the structuring element.
        /// </summary>
        /// <param name="shape">Element shape that could be one of MorphShapes</param>
        /// <param name="ksize">Size of the structuring element.</param>
        /// <returns></returns>
        public static Mat GetStructuringElement(MorphShapes shape, Size ksize)
        {
            return GetStructuringElement(shape, ksize, new Point(-1, -1));
        }

        /// <summary>
        /// Returns a structuring element of the specified size and shape for morphological operations.
        /// The function constructs and returns the structuring element that can be further passed to erode,
        /// dilate or morphologyEx.But you can also construct an arbitrary binary mask yourself and use it as the structuring element.
        /// </summary>
        /// <param name="shape">Element shape that could be one of MorphShapes</param>
        /// <param name="ksize">Size of the structuring element.</param>
        /// <param name="anchor">Anchor position within the element. The default value (−1,−1) means that the anchor is at the center.
        /// Note that only the shape of a cross-shaped element depends on the anchor position.
        /// In other cases the anchor just regulates how much the result of the morphological operation is shifted.</param>
        /// <returns></returns>
        public static Mat GetStructuringElement(MorphShapes shape, Size ksize, Point anchor)
        {
            NativeMethods.HandleException(
                NativeMethods.imgproc_getStructuringElement((int)shape, ksize, anchor, out var matPtr));
            return new Mat(matPtr);
        }

        /// <summary>
        /// Smoothes image using median filter
        /// </summary>
        /// <param name="src">The source 1-, 3- or 4-channel image. 
        /// When ksize is 3 or 5, the image depth should be CV_8U , CV_16U or CV_32F. 
        /// For larger aperture sizes it can only be CV_8U</param>
        /// <param name="dst">The destination array; will have the same size and the same type as src</param>
        /// <param name="ksize">The aperture linear size. It must be odd and more than 1, i.e. 3, 5, 7 ...</param>
        public static void MedianBlur(InputArray src, OutputArray dst, int ksize)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_medianBlur(src.CvPtr, dst.CvPtr, ksize));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

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
            double sigmaY = 0, BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_GaussianBlur(src.CvPtr, dst.CvPtr, ksize, sigmaX, sigmaY, borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Applies bilateral filter to the image
        /// </summary>
        /// <param name="src">The source 8-bit or floating-point, 1-channel or 3-channel image</param>
        /// <param name="dst">The destination image; will have the same size and the same type as src</param>
        /// <param name="d">The diameter of each pixel neighborhood, that is used during filtering. 
        /// If it is non-positive, it's computed from sigmaSpace</param>
        /// <param name="sigmaColor">Filter sigma in the color space. 
        /// Larger value of the parameter means that farther colors within the pixel neighborhood 
        /// will be mixed together, resulting in larger areas of semi-equal color</param>
        /// <param name="sigmaSpace">Filter sigma in the coordinate space. 
        /// Larger value of the parameter means that farther pixels will influence each other 
        /// (as long as their colors are close enough; see sigmaColor). Then d>0 , it specifies 
        /// the neighborhood size regardless of sigmaSpace, otherwise d is proportional to sigmaSpace</param>
        /// <param name="borderType"></param>
        public static void BilateralFilter(InputArray src, OutputArray dst, int d, double sigmaColor,
            double sigmaSpace, BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_bilateralFilter(src.CvPtr, dst.CvPtr, d, sigmaColor, sigmaSpace, borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Smoothes image using box filter
        /// </summary>
        /// <param name="src">The source image</param>
        /// <param name="dst">The destination image; will have the same size and the same type as src</param>
        /// <param name="ddepth"></param>
        /// <param name="ksize">The smoothing kernel size</param>
        /// <param name="anchor">The anchor point. The default value Point(-1,-1) means that the anchor is at the kernel center</param>
        /// <param name="normalize">Indicates, whether the kernel is normalized by its area or not</param>
        /// <param name="borderType">The border mode used to extrapolate pixels outside of the image</param>
        public static void BoxFilter(
            InputArray src, OutputArray dst, MatType ddepth, 
            Size ksize, Point? anchor = null, bool normalize = true,
            BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            var anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.HandleException(
                NativeMethods.imgproc_boxFilter(src.CvPtr, dst.CvPtr, ddepth, ksize, anchor0, normalize ? 1 : 0, borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Calculates the normalized sum of squares of the pixel values overlapping the filter.
        ///
        /// For every pixel f(x, y) in the source image, the function calculates the sum of squares of those neighboring
        /// pixel values which overlap the filter placed over the pixel f(x, y).
        ///
        /// The unnormalized square box filter can be useful in computing local image statistics such as the the local
        /// variance and standard deviation around the neighborhood of a pixel.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ddepth"></param>
        /// <param name="ksize"></param>
        /// <param name="anchor"></param>
        /// <param name="normalize"></param>
        /// <param name="borderType"></param>
        public static void SqrBoxFilter(
            InputArray src, OutputArray dst, int ddepth,
            Size ksize, Point? anchor = null, bool normalize = true,
            BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            var anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.HandleException(
                NativeMethods.imgproc_sqrBoxFilter(src.CvPtr, dst.CvPtr, ddepth, ksize, anchor0, normalize ? 1 : 0, borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Smoothes image using normalized box filter
        /// </summary>
        /// <param name="src">The source image</param>
        /// <param name="dst">The destination image; will have the same size and the same type as src</param>
        /// <param name="ksize">The smoothing kernel size</param>
        /// <param name="anchor">The anchor point. The default value Point(-1,-1) means that the anchor is at the kernel center</param>
        /// <param name="borderType">The border mode used to extrapolate pixels outside of the image</param>
        public static void Blur(
            InputArray src, OutputArray dst, Size ksize, 
            Point? anchor = null, BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            var anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.HandleException(
                NativeMethods.imgproc_blur(src.CvPtr, dst.CvPtr, ksize, anchor0, (int)borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Convolves an image with the kernel
        /// </summary>
        /// <param name="src">The source image</param>
        /// <param name="dst">The destination image. It will have the same size and the same number of channels as src</param>
        /// <param name="ddepth">The desired depth of the destination image. If it is negative, it will be the same as src.depth()</param>
        /// <param name="kernel">Convolution kernel (or rather a correlation kernel), 
        /// a single-channel floating point matrix. If you want to apply different kernels to 
        /// different channels, split the image into separate color planes using split() and process them individually</param>
        /// <param name="anchor">The anchor of the kernel that indicates the relative position of 
        /// a filtered point within the kernel. The anchor should lie within the kernel. 
        /// The special default value (-1,-1) means that the anchor is at the kernel center</param>
        /// <param name="delta">The optional value added to the filtered pixels before storing them in dst</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        public static void Filter2D(
            InputArray src, OutputArray dst, MatType ddepth,
            InputArray kernel, Point? anchor = null, double delta = 0, 
            BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (kernel == null)
                throw new ArgumentNullException(nameof(kernel));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            kernel.ThrowIfDisposed();

            var anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.HandleException(
                NativeMethods.imgproc_filter2D(src.CvPtr, dst.CvPtr, ddepth, kernel.CvPtr, anchor0, delta, (int)borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(kernel);
            dst.Fix();
        }
        
        /// <summary>
        /// Applies separable linear filter to an image
        /// </summary>
        /// <param name="src">The source image</param>
        /// <param name="dst">The destination image; will have the same size and the same number of channels as src</param>
        /// <param name="ddepth">The destination image depth</param>
        /// <param name="kernelX">The coefficients for filtering each row</param>
        /// <param name="kernelY">The coefficients for filtering each column</param>
        /// <param name="anchor">The anchor position within the kernel; The default value (-1, 1) means that the anchor is at the kernel center</param>
        /// <param name="delta">The value added to the filtered results before storing them</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        public static void SepFilter2D(
            InputArray src, OutputArray dst, MatType ddepth, InputArray kernelX, InputArray kernelY,
            Point? anchor = null, double delta = 0, 
            BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (kernelX == null)
                throw new ArgumentNullException(nameof(kernelX));
            if (kernelY == null)
                throw new ArgumentNullException(nameof(kernelY));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            kernelX.ThrowIfDisposed();
            kernelY.ThrowIfDisposed();
            
            var anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.HandleException(
                NativeMethods.imgproc_sepFilter2D(src.CvPtr, dst.CvPtr, ddepth,
                    kernelX.CvPtr, kernelY.CvPtr, anchor0, delta, (int) borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(kernelX);
            GC.KeepAlive(kernelY);
            dst.Fix();
        }

        /// <summary>
        /// Calculates the first, second, third or mixed image derivatives using an extended Sobel operator
        /// </summary>
        /// <param name="src">The source image</param>
        /// <param name="dst">The destination image; will have the same size and the same number of channels as src</param>
        /// <param name="ddepth">The destination image depth</param>
        /// <param name="xorder">Order of the derivative x</param>
        /// <param name="yorder">Order of the derivative y</param>
        /// <param name="ksize">Size of the extended Sobel kernel, must be 1, 3, 5 or 7</param>
        /// <param name="scale">The optional scale factor for the computed derivative values (by default, no scaling is applied</param>
        /// <param name="delta">The optional delta value, added to the results prior to storing them in dst</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        public static void Sobel(
            InputArray src, OutputArray dst, MatType ddepth, int xorder, int yorder, 
            int ksize = 3, double scale = 1, double delta = 0, 
            BorderTypes borderType = BorderTypes.Default)        
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_Sobel(src.CvPtr, dst.CvPtr, ddepth, xorder, yorder,
                    ksize, scale, delta, (int) borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Calculates the first order image derivative in both x and y using a Sobel operator
        /// </summary>
        /// <param name="src">input image.</param>
        /// <param name="dx">output image with first-order derivative in x.</param>
        /// <param name="dy">output image with first-order derivative in y.</param>
        /// <param name="ksize">size of Sobel kernel. It must be 3.</param>
        /// <param name="borderType">pixel extrapolation method</param>
        public static void SpatialGradient(
            InputArray src, OutputArray dx, OutputArray dy, int ksize = 3, BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dx == null)
                throw new ArgumentNullException(nameof(dx));
            if (dy == null)
                throw new ArgumentNullException(nameof(dy));
            src.ThrowIfDisposed();
            dx.ThrowIfNotReady();
            dy.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_spatialGradient(src.CvPtr, dx.CvPtr, dy.CvPtr, ksize, (int)borderType));

            GC.KeepAlive(src);
            dx.Fix();
            dy.Fix();
        }

        /// <summary>
        /// Calculates the first x- or y- image derivative using Scharr operator
        /// </summary>
        /// <param name="src">The source image</param>
        /// <param name="dst">The destination image; will have the same size and the same number of channels as src</param>
        /// <param name="ddepth">The destination image depth</param>
        /// <param name="xorder">Order of the derivative x</param>
        /// <param name="yorder">Order of the derivative y</param>
        /// <param name="scale">The optional scale factor for the computed derivative values (by default, no scaling is applie</param>
        /// <param name="delta">The optional delta value, added to the results prior to storing them in dst</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        public static void Scharr(
            InputArray src, OutputArray dst, MatType ddepth, int xorder, int yorder, 
            double scale = 1, double delta = 0, BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_Scharr(src.CvPtr, dst.CvPtr, ddepth, xorder, yorder,
                    scale, delta, (int) borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Calculates the Laplacian of an image
        /// </summary>
        /// <param name="src">Source image</param>
        /// <param name="dst">Destination image; will have the same size and the same number of channels as src</param>
        /// <param name="ddepth">The desired depth of the destination image</param>
        /// <param name="ksize">The aperture size used to compute the second-derivative filters</param>
        /// <param name="scale">The optional scale factor for the computed Laplacian values (by default, no scaling is applied</param>
        /// <param name="delta">The optional delta value, added to the results prior to storing them in dst</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        public static void Laplacian(
            InputArray src, OutputArray dst, MatType ddepth,
            int ksize = 1, double scale = 1, double delta = 0, 
            BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_Laplacian(src.CvPtr, dst.CvPtr, ddepth, ksize, scale, delta, (int) borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

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
                throw new ArgumentNullException(nameof(src));
            if (edges == null)
                throw new ArgumentNullException(nameof(edges));
            src.ThrowIfDisposed();
            edges.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_Canny1(src.CvPtr, edges.CvPtr, threshold1, threshold2, apertureSize, L2gradient ? 1 : 0));

            GC.KeepAlive(src);
            GC.KeepAlive(edges);
            edges.Fix();
        }

        /// <summary>
        /// Finds edges in an image using the Canny algorithm with custom image gradient.
        /// </summary>
        /// <param name="dx">16-bit x derivative of input image (CV_16SC1 or CV_16SC3).</param>
        /// <param name="dy">16-bit y derivative of input image (same type as dx).</param>
        /// <param name="edges">output edge map; single channels 8-bit image, which has the same size as image.</param>
        /// <param name="threshold1">first threshold for the hysteresis procedure.</param>
        /// <param name="threshold2">second threshold for the hysteresis procedure.</param>
        /// <param name="L2gradient">Indicates, whether the more accurate L2 norm should be used to compute the image gradient magnitude (true), or a faster default L1 norm is enough (false). [By default this is false]</param>
        public static void Canny(
            InputArray dx, InputArray dy, OutputArray edges,
            double threshold1, double threshold2,
            bool L2gradient = false)
        {
            if (dx == null)
                throw new ArgumentNullException(nameof(dx));
            if (dy == null)
                throw new ArgumentNullException(nameof(dy));
            if (edges == null)
                throw new ArgumentNullException(nameof(edges));
            dx.ThrowIfDisposed();
            dy.ThrowIfDisposed();
            edges.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_Canny2(
                    dx.CvPtr, dy.CvPtr, edges.CvPtr, threshold1, threshold2, L2gradient ? 1 : 0));

            GC.KeepAlive(dx);
            GC.KeepAlive(dy);
            edges.Fix();
        }

        /// <summary>
        /// Calculates the minimal eigenvalue of gradient matrices for corner detection.
        /// </summary>
        /// <param name="src">Input single-channel 8-bit or floating-point image.</param>
        /// <param name="dst">Image to store the minimal eigenvalues. It has the type CV_32FC1 and the same size as src .</param>
        /// <param name="blockSize">Neighborhood size (see the details on #cornerEigenValsAndVecs ).</param>
        /// <param name="ksize">Aperture parameter for the Sobel operator.</param>
        /// <param name="borderType">Pixel extrapolation method. See #BorderTypes. #BORDER_WRAP is not supported.</param>
        public static void CornerMinEigenVal(
            InputArray src,
            OutputArray dst,
            int blockSize, 
            int ksize = 3,
            BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_cornerMinEigenVal(src.CvPtr, dst.CvPtr, blockSize, ksize, (int) borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Harris corner detector.
        /// </summary>
        /// <param name="src">Input single-channel 8-bit or floating-point image.</param>
        /// <param name="dst">Image to store the Harris detector responses.
        /// It has the type CV_32FC1 and the same size as src.</param>
        /// <param name="blockSize">Neighborhood size (see the details on #cornerEigenValsAndVecs ).</param>
        /// <param name="ksize">Aperture parameter for the Sobel operator.</param>
        /// <param name="k">Harris detector free parameter. See the formula above.</param>
        /// <param name="borderType">Pixel extrapolation method. See #BorderTypes. #BORDER_WRAP is not supported.</param>
        public static void CornerHarris(
            InputArray src, 
            OutputArray dst, 
            int blockSize,
            int ksize,
            double k,
            BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_cornerHarris(src.CvPtr, dst.CvPtr, blockSize, ksize, k, (int)borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// computes both eigenvalues and the eigenvectors of 2x2 derivative covariation matrix  at each pixel. The output is stored as 6-channel matrix.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="blockSize"></param>
        /// <param name="ksize"></param>
        /// <param name="borderType"></param>
        public static void CornerEigenValsAndVecs(
            InputArray src, OutputArray dst, int blockSize, int ksize,
            BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_cornerEigenValsAndVecs(src.CvPtr, dst.CvPtr, blockSize, ksize, (int) borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// computes another complex cornerness criteria at each pixel
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="borderType"></param>
        public static void PreCornerDetect(
            InputArray src, OutputArray dst, int ksize, BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_preCornerDetect(src.CvPtr, dst.CvPtr, ksize, (int) borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// adjusts the corner locations with sub-pixel accuracy to maximize the certain cornerness criteria
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="inputCorners">Initial coordinates of the input corners and refined coordinates provided for output.</param>
        /// <param name="winSize">Half of the side length of the search window.</param>
        /// <param name="zeroZone">Half of the size of the dead region in the middle of the search zone 
        /// over which the summation in the formula below is not done. It is used sometimes to avoid possible singularities 
        /// of the autocorrelation matrix. The value of (-1,-1) indicates that there is no such a size.</param>
        /// <param name="criteria">Criteria for termination of the iterative process of corner refinement. 
        /// That is, the process of corner position refinement stops either after criteria.maxCount iterations 
        /// or when the corner position moves by less than criteria.epsilon on some iteration.</param>
        /// <returns></returns>
        public static Point2f[] CornerSubPix(InputArray image, IEnumerable<Point2f> inputCorners,
            Size winSize, Size zeroZone, TermCriteria criteria)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (inputCorners == null)
                throw new ArgumentNullException(nameof(inputCorners));
            image.ThrowIfDisposed();

            var inputCornersSrc = inputCorners.ToArray();
            var inputCornersCopy = new Point2f[inputCornersSrc.Length];
            Array.Copy(inputCornersSrc, inputCornersCopy, inputCornersSrc.Length);

            using var vector = new VectorOfPoint2f(inputCornersCopy);
            NativeMethods.HandleException(
                NativeMethods.imgproc_cornerSubPix(image.CvPtr, vector.CvPtr, winSize, zeroZone, criteria));
            GC.KeepAlive(image);
            return vector.ToArray();
        }

        /// <summary>
        /// finds the strong enough corners where the cornerMinEigenVal() or cornerHarris() report the local maxima
        /// </summary>
        /// <param name="src">Input 8-bit or floating-point 32-bit, single-channel image.</param>
        /// <param name="maxCorners">Maximum number of corners to return. If there are more corners than are found, 
        /// the strongest of them is returned.</param>
        /// <param name="qualityLevel">Parameter characterizing the minimal accepted quality of image corners. 
        /// The parameter value is multiplied by the best corner quality measure, which is the minimal eigenvalue 
        /// or the Harris function response (see cornerHarris() ). The corners with the quality measure less than 
        /// the product are rejected. For example, if the best corner has the quality measure = 1500, and the qualityLevel=0.01, 
        /// then all the corners with the quality measure less than 15 are rejected.</param>
        /// <param name="minDistance">Minimum possible Euclidean distance between the returned corners.</param>
        /// <param name="mask">Optional region of interest. If the image is not empty
        ///  (it needs to have the type CV_8UC1 and the same size as image ), it specifies the region 
        /// in which the corners are detected.</param>
        /// <param name="blockSize">Size of an average block for computing a derivative covariation matrix over each pixel neighborhood.</param>
        /// <param name="useHarrisDetector">Parameter indicating whether to use a Harris detector</param>
        /// <param name="k">Free parameter of the Harris detector.</param>
        /// <returns>Output vector of detected corners.</returns>
        public static Point2f[] GoodFeaturesToTrack(InputArray src, 
            int maxCorners, double qualityLevel, double minDistance,
            InputArray mask, int blockSize, bool useHarrisDetector, double k)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            using var vector = new VectorOfPoint2f();
            var maskPtr = ToPtr(mask);
            NativeMethods.HandleException(
                NativeMethods.imgproc_goodFeaturesToTrack(src.CvPtr, vector.CvPtr, maxCorners, qualityLevel,
                    minDistance, maskPtr, blockSize, useHarrisDetector ? 0 : 1, k));
            GC.KeepAlive(src);
            GC.KeepAlive(mask);
            return vector.ToArray();
        }

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
        public static LineSegmentPolar[] HoughLines(
            InputArray image, double rho, double theta, int threshold, 
            double srn = 0, double stn = 0)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            using var vec = new VectorOfVec2f();
            NativeMethods.HandleException(
                NativeMethods.imgproc_HoughLines(image.CvPtr, vec.CvPtr, rho, theta, threshold, srn, stn));
            GC.KeepAlive(image);
            return vec.ToArray<LineSegmentPolar>();
        }
        
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
        public static LineSegmentPoint[] HoughLinesP(
            InputArray image, double rho, double theta, int threshold, 
            double minLineLength = 0, double maxLineGap = 0)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();
            using var vec = new VectorOfVec4i();
            NativeMethods.HandleException(
                NativeMethods.imgproc_HoughLinesP(image.CvPtr, vec.CvPtr, rho, theta, threshold, minLineLength, maxLineGap));
            GC.KeepAlive(image);
            return vec.ToArray<LineSegmentPoint>();
        }

        /// <summary>
        /// Finds lines in a set of points using the standard Hough transform.
        /// The function finds lines in a set of points using a modification of the Hough transform.
        /// </summary>
        /// <param name="point">Input vector of points. Each vector must be encoded as a Point vector \f$(x,y)\f$. Type must be CV_32FC2 or CV_32SC2.</param>
        /// <param name="lines">Output vector of found lines. Each vector is encoded as a vector&lt;Vec3d&gt;</param>
        /// <param name="linesMax">Max count of hough lines.</param>
        /// <param name="threshold">Accumulator threshold parameter. Only those lines are returned that get enough votes</param>
        /// <param name="minRho">Minimum Distance value of the accumulator in pixels.</param>
        /// <param name="maxRho">Maximum Distance value of the accumulator in pixels.</param>
        /// <param name="rhoStep">Distance resolution of the accumulator in pixels.</param>
        /// <param name="minTheta">Minimum angle value of the accumulator in radians.</param>
        /// <param name="maxTheta">Maximum angle value of the accumulator in radians.</param>
        /// <param name="thetaStep">Angle resolution of the accumulator in radians.</param>
        public static void HoughLinesPointSet(
            InputArray point, OutputArray lines, int linesMax, int threshold,
            double minRho, double maxRho, double rhoStep,
            double minTheta, double maxTheta, double thetaStep)
        {
            if (point == null)
                throw new ArgumentNullException(nameof(point));
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));
            point.ThrowIfDisposed();
            lines.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_HoughLinesPointSet(
                    point.CvPtr, lines.CvPtr, linesMax, threshold, minRho, maxRho, rhoStep, minTheta, maxTheta, thetaStep));

            GC.KeepAlive(point);
            lines.Fix();
        }

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
        /// <param name="method">The available methods are HoughMethods.Gradient and HoughMethods.GradientAlt</param>
        /// <param name="dp">The inverse ratio of the accumulator resolution to the image resolution. </param>
        /// <param name="minDist">Minimum distance between the centers of the detected circles. </param>
        /// <param name="param1">The first method-specific parameter. [By default this is 100]</param>
        /// <param name="param2">The second method-specific parameter. [By default this is 100]</param>
        /// <param name="minRadius">Minimum circle radius. [By default this is 0]</param>
        /// <param name="maxRadius">Maximum circle radius. [By default this is 0] </param>
        /// <returns>The output vector found circles. Each vector is encoded as 3-element floating-point vector (x, y, radius)</returns>
#endif
        public static CircleSegment[] HoughCircles(
            InputArray image, HoughMethods method, double dp, double minDist, 
            double param1 = 100, double param2 = 100, int minRadius = 0, int maxRadius = 0)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();
            using var vec = new VectorOfVec3f();
            NativeMethods.HandleException(
                NativeMethods.imgproc_HoughCircles(image.CvPtr, vec.CvPtr, (int) method, dp, minDist, param1,
                    param2, minRadius, maxRadius));
            GC.KeepAlive(image);
            return vec.ToArray<CircleSegment>();
        }

        /// <summary>
        /// Default borderValue for Dilate/Erode
        /// </summary>
        /// <returns></returns>
        public static Scalar MorphologyDefaultBorderValue()
        {
            return Scalar.All(double.MaxValue);
        }

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
        public static void Dilate(
            InputArray src, OutputArray dst, InputArray? element,
            Point? anchor = null, int iterations = 1, 
            BorderTypes borderType = BorderTypes.Constant, Scalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            var anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            var borderValue0 = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());
            var elementPtr = ToPtr(element);
            NativeMethods.HandleException(
                NativeMethods.imgproc_dilate(src.CvPtr, dst.CvPtr, elementPtr, anchor0, iterations, (int) borderType, borderValue0));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(element);
            dst.Fix();
        }

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
        public static void Erode(
            InputArray src, OutputArray dst, InputArray? element,
            Point? anchor = null, int iterations = 1, 
            BorderTypes borderType = BorderTypes.Constant, Scalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            var anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            var borderValue0 = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());
            var elementPtr = ToPtr(element);
            NativeMethods.HandleException(
                NativeMethods.imgproc_erode(src.CvPtr, dst.CvPtr, elementPtr, anchor0, iterations, (int) borderType, borderValue0));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(element);
            dst.Fix();
        }

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
        public static void MorphologyEx(
            InputArray src, OutputArray dst, MorphTypes op, InputArray? element,
            Point? anchor = null, int iterations = 1, 
            BorderTypes borderType = BorderTypes.Constant, Scalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            element?.ThrowIfDisposed();

            var anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            var borderValue0 = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());
            var elementPtr = ToPtr(element);
            NativeMethods.HandleException(
                NativeMethods.imgproc_morphologyEx(src.CvPtr, dst.CvPtr, (int) op, elementPtr, anchor0, iterations,
                    (int) borderType, borderValue0));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(element);
            dst.Fix();
        }

        /// <summary>
        /// Resizes an image.
        /// </summary>
        /// <param name="src">input image.</param>
        /// <param name="dst">output image; it has the size dsize (when it is non-zero) or the size computed 
        /// from src.size(), fx, and fy; the type of dst is the same as of src.</param>
        /// <param name="dsize">output image size; if it equals zero, it is computed as: 
        /// dsize = Size(round(fx*src.cols), round(fy*src.rows))
        /// Either dsize or both fx and fy must be non-zero.</param>
        /// <param name="fx">scale factor along the horizontal axis; when it equals 0, 
        /// it is computed as: (double)dsize.width/src.cols</param>
        /// <param name="fy">scale factor along the vertical axis; when it equals 0, 
        /// it is computed as: (double)dsize.height/src.rows</param>
        /// <param name="interpolation">interpolation method</param>
        public static void Resize(InputArray src, OutputArray dst, Size dsize,
            double fx = 0, double fy = 0, InterpolationFlags interpolation = InterpolationFlags.Linear)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_resize(src.CvPtr, dst.CvPtr, dsize, fx, fy, (int) interpolation));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Applies an affine transformation to an image.
        /// </summary>
        /// <param name="src">input image.</param>
        /// <param name="dst">output image that has the size dsize and the same type as src.</param>
        /// <param name="m">2x3 transformation matrix.</param>
        /// <param name="dsize">size of the output image.</param>
        /// <param name="flags">combination of interpolation methods and the optional flag 
        /// WARP_INVERSE_MAP that means that M is the inverse transformation (dst -> src) .</param>
        /// <param name="borderMode">pixel extrapolation method; when borderMode=BORDER_TRANSPARENT, 
        /// it means that the pixels in the destination image corresponding to the "outliers" 
        /// in the source image are not modified by the function.</param>
        /// <param name="borderValue">value used in case of a constant border; by default, it is 0.</param>
        public static void WarpAffine(
            InputArray src, OutputArray dst, InputArray m, Size dsize,
            InterpolationFlags flags = InterpolationFlags.Linear, 
            BorderTypes borderMode = BorderTypes.Constant, Scalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            m.ThrowIfDisposed();

            var borderValue0 = borderValue.GetValueOrDefault(Scalar.All(0));
            NativeMethods.HandleException(
                NativeMethods.imgproc_warpAffine(src.CvPtr, dst.CvPtr, m.CvPtr, dsize, (int) flags, (int) borderMode, borderValue0));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(m);
            dst.Fix();
        }

#if LANG_JP
        /// <summary>
        /// 画像の透視変換を行います．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">サイズが dsize で src と同じタイプの出力画像</param>
        /// <param name="m">3x3 の変換行列</param>
        /// <param name="dsize">出力画像のサイズ</param>
        /// <param name="flags">補間手法</param>
        /// <param name="borderMode">ピクセル外挿手法．
        /// borderMode=BORDER_TRANSPARENT の場合，入力画像中の「はずれ値」に対応する
        /// 出力画像中のピクセルが，この関数では変更されないことを意味します</param>
        /// <param name="borderValue">定数境界モードで利用されるピクセル値．</param>
#else
        /// <summary>
        /// Applies a perspective transformation to an image.
        /// </summary>
        /// <param name="src">input image.</param>
        /// <param name="dst">output image that has the size dsize and the same type as src.</param>
        /// <param name="m">3x3 transformation matrix.</param>
        /// <param name="dsize">size of the output image.</param>
        /// <param name="flags">combination of interpolation methods (INTER_LINEAR or INTER_NEAREST) 
        /// and the optional flag WARP_INVERSE_MAP, that sets M as the inverse transformation (dst -> src).</param>
        /// <param name="borderMode">pixel extrapolation method (BORDER_CONSTANT or BORDER_REPLICATE).</param>
        /// <param name="borderValue">value used in case of a constant border; by default, it equals 0.</param>
#endif
        public static void WarpPerspective(
            InputArray src, OutputArray dst, InputArray m, Size dsize,
            InterpolationFlags flags = InterpolationFlags.Linear, 
            BorderTypes borderMode = BorderTypes.Constant, 
            Scalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            m.ThrowIfDisposed();

            var borderValue0 = borderValue.GetValueOrDefault(Scalar.All(0));
            NativeMethods.HandleException(
                NativeMethods.imgproc_warpPerspective_MisInputArray(
                    src.CvPtr, dst.CvPtr, m.CvPtr, dsize, (int) flags, (int) borderMode, borderValue0));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(m);
            dst.Fix();
        }

#if LANG_JP
        /// <summary>
        /// 画像の透視変換を行います．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">サイズが dsize で src と同じタイプの出力画像</param>
        /// <param name="m">3x3 の変換行列</param>
        /// <param name="dsize">出力画像のサイズ</param>
        /// <param name="flags">補間手法</param>
        /// <param name="borderMode">ピクセル外挿手法．
        /// borderMode=BORDER_TRANSPARENT の場合，入力画像中の「はずれ値」に対応する
        /// 出力画像中のピクセルが，この関数では変更されないことを意味します</param>
        /// <param name="borderValue">定数境界モードで利用されるピクセル値．</param>
#else
        /// <summary>
        /// Applies a perspective transformation to an image.
        /// </summary>
        /// <param name="src">input image.</param>
        /// <param name="dst">output image that has the size dsize and the same type as src.</param>
        /// <param name="m">3x3 transformation matrix.</param>
        /// <param name="dsize">size of the output image.</param>
        /// <param name="flags">combination of interpolation methods (INTER_LINEAR or INTER_NEAREST) 
        /// and the optional flag WARP_INVERSE_MAP, that sets M as the inverse transformation (dst -> src).</param>
        /// <param name="borderMode">pixel extrapolation method (BORDER_CONSTANT or BORDER_REPLICATE).</param>
        /// <param name="borderValue">value used in case of a constant border; by default, it equals 0.</param>
#endif
        public static void WarpPerspective(
            InputArray src, OutputArray dst, float[,] m, Size dsize,
            InterpolationFlags flags = InterpolationFlags.Linear, 
            BorderTypes borderMode = BorderTypes.Constant,
            Scalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            var borderValue0 = borderValue.GetValueOrDefault(Scalar.All(0));
            var mRow = m.GetLength(0);
            var mCol = m.GetLength(1);
            NativeMethods.HandleException(
                NativeMethods.imgproc_warpPerspective_MisArray(
                    src.CvPtr, dst.CvPtr, m, mRow, mCol, dsize, (int) flags, (int) borderMode, borderValue0));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Applies a generic geometrical transformation to an image.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image. It has the same size as map1 and the same type as src</param>
        /// <param name="map1">The first map of either (x,y) points or just x values having the type CV_16SC2, CV_32FC1, or CV_32FC2.</param>
        /// <param name="map2">The second map of y values having the type CV_16UC1, CV_32FC1, or none (empty map if map1 is (x,y) points), respectively.</param>
        /// <param name="interpolation">Interpolation method. The method INTER_AREA is not supported by this function.</param>
        /// <param name="borderMode">Pixel extrapolation method. When borderMode=BORDER_TRANSPARENT, 
        /// it means that the pixels in the destination image that corresponds to the "outliers" in 
        /// the source image are not modified by the function.</param>
        /// <param name="borderValue">Value used in case of a constant border. By default, it is 0.</param>
        public static void Remap(
            InputArray src, OutputArray dst, InputArray map1, InputArray map2,
            InterpolationFlags interpolation = InterpolationFlags.Linear, 
            BorderTypes borderMode = BorderTypes.Constant, Scalar? borderValue = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (map1 == null)
                throw new ArgumentNullException(nameof(map1));
            if (map2 == null)
                throw new ArgumentNullException(nameof(map2));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            map1.ThrowIfDisposed();
            map2.ThrowIfDisposed();

            var borderValue0 = borderValue.GetValueOrDefault(Scalar.All(0));
            NativeMethods.HandleException(
                NativeMethods.imgproc_remap(src.CvPtr, dst.CvPtr, map1.CvPtr, map2.CvPtr, (int) interpolation,
                    (int) borderMode, borderValue0));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
            GC.KeepAlive(map1);
            GC.KeepAlive(map2);
        }

        /// <summary>
        /// Converts image transformation maps from one representation to another.
        /// </summary>
        /// <param name="map1">The first input map of type CV_16SC2 , CV_32FC1 , or CV_32FC2 .</param>
        /// <param name="map2">The second input map of type CV_16UC1 , CV_32FC1 , or none (empty matrix), respectively.</param>
        /// <param name="dstmap1">The first output map that has the type dstmap1type and the same size as src.</param>
        /// <param name="dstmap2">The second output map.</param>
        /// <param name="dstmap1Type">Type of the first output map that should be CV_16SC2 , CV_32FC1 , or CV_32FC2 .</param>
        /// <param name="nnInterpolation">Flag indicating whether the fixed-point maps are used for the nearest-neighbor or for a more complex interpolation.</param>
        public static void ConvertMaps(InputArray map1, InputArray map2, OutputArray dstmap1, OutputArray dstmap2, MatType dstmap1Type, bool nnInterpolation = false)
        {
            if (map1 == null)
                throw new ArgumentNullException(nameof(map1));
            if (map2 == null)
                throw new ArgumentNullException(nameof(map2));
            if (dstmap1 == null)
                throw new ArgumentNullException(nameof(dstmap1));
            if (dstmap2 == null)
                throw new ArgumentNullException(nameof(dstmap2));
            map1.ThrowIfDisposed();
            map2.ThrowIfDisposed();
            dstmap1.ThrowIfDisposed();
            dstmap2.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_convertMaps(map1.CvPtr, map2.CvPtr, dstmap1.CvPtr, dstmap2.CvPtr, dstmap1Type,
                    nnInterpolation ? 1 : 0));

            GC.KeepAlive(map1);
            GC.KeepAlive(map2);
            GC.KeepAlive(dstmap1);
            GC.KeepAlive(dstmap2);
            dstmap1.Fix();
            dstmap2.Fix();
        }

        /// <summary>
        /// Calculates an affine matrix of 2D rotation.
        /// </summary>
        /// <param name="center">Center of the rotation in the source image.</param>
        /// <param name="angle">Rotation angle in degrees. Positive values mean counter-clockwise rotation (the coordinate origin is assumed to be the top-left corner).</param>
        /// <param name="scale">Isotropic scale factor.</param>
        /// <returns></returns>
        public static Mat GetRotationMatrix2D(Point2f center, double angle, double scale)
        {
            NativeMethods.HandleException(
                NativeMethods.imgproc_getRotationMatrix2D(center, angle, scale, out var retMat));
            return new Mat(retMat);
        }

        /// <summary>
        /// Inverts an affine transformation.
        /// </summary>
        /// <param name="m">Original affine transformation.</param>
        /// <param name="im">Output reverse affine transformation.</param>
        public static void InvertAffineTransform(InputArray m, OutputArray im)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            if (im == null)
                throw new ArgumentNullException(nameof(im));
            m.ThrowIfDisposed();
            im.ThrowIfNotReady();
            NativeMethods.HandleException(
                NativeMethods.imgproc_invertAffineTransform(m.CvPtr, im.CvPtr));
            GC.KeepAlive(m);
            GC.KeepAlive(im);
            im.Fix();
        }

        /// <summary>
        /// Calculates a perspective transform from four pairs of the corresponding points.
        /// The function calculates the 3×3 matrix of a perspective transform.
        /// </summary>
        /// <param name="src">Coordinates of quadrangle vertices in the source image.</param>
        /// <param name="dst">Coordinates of the corresponding quadrangle vertices in the destination image.</param>
        /// <returns></returns>
        public static Mat GetPerspectiveTransform(IEnumerable<Point2f> src, IEnumerable<Point2f> dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            var srcArray = src.ToArray();
            var dstArray = dst.ToArray();
            NativeMethods.HandleException(
                NativeMethods.imgproc_getPerspectiveTransform1(srcArray, dstArray, out var retMat));
            return new Mat(retMat);
        }

        /// <summary>
        /// Calculates a perspective transform from four pairs of the corresponding points.
        /// The function calculates the 3×3 matrix of a perspective transform.
        /// </summary>
        /// <param name="src">Coordinates of quadrangle vertices in the source image.</param>
        /// <param name="dst">Coordinates of the corresponding quadrangle vertices in the destination image.</param>
        /// <returns></returns>
        public static Mat GetPerspectiveTransform(InputArray src, InputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_getPerspectiveTransform2(src.CvPtr, dst.CvPtr, out var retMat));
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            return new Mat(retMat);
        }

        /// <summary>
        /// Calculates an affine transform from three pairs of the corresponding points.
        /// The function calculates the 2×3 matrix of an affine transform.
        /// </summary>
        /// <param name="src">Coordinates of triangle vertices in the source image.</param>
        /// <param name="dst">Coordinates of the corresponding triangle vertices in the destination image.</param>
        /// <returns></returns>
        public static Mat GetAffineTransform(IEnumerable<Point2f> src, IEnumerable<Point2f> dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            var srcArray = src.ToArray();
            var dstArray = dst.ToArray();
            NativeMethods.HandleException(
                NativeMethods.imgproc_getAffineTransform1(srcArray, dstArray, out var retMat));
            return new Mat(retMat);
        }

        /// <summary>
        /// Calculates an affine transform from three pairs of the corresponding points.
        /// The function calculates the 2×3 matrix of an affine transform.
        /// </summary>
        /// <param name="src">Coordinates of triangle vertices in the source image.</param>
        /// <param name="dst">Coordinates of the corresponding triangle vertices in the destination image.</param>
        /// <returns></returns>
        public static Mat GetAffineTransform(InputArray src, InputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_getAffineTransform2(src.CvPtr, dst.CvPtr, out var retMat));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            return new Mat(retMat);
        }

        /// <summary>
        /// Retrieves a pixel rectangle from an image with sub-pixel accuracy.
        /// </summary>
        /// <param name="image">Source image.</param>
        /// <param name="patchSize">Size of the extracted patch.</param>
        /// <param name="center">Floating point coordinates of the center of the extracted rectangle 
        /// within the source image. The center must be inside the image.</param>
        /// <param name="patch">Extracted patch that has the size patchSize and the same number of channels as src .</param>
        /// <param name="patchType">Depth of the extracted pixels. By default, they have the same depth as src.</param>
        public static void GetRectSubPix(InputArray image, Size patchSize, Point2f center, 
            OutputArray patch, int patchType = -1)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (patch == null)
                throw new ArgumentNullException(nameof(patch));
            image.ThrowIfDisposed();
            patch.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_getRectSubPix(image.CvPtr, patchSize, center, patch.CvPtr, patchType));

            GC.KeepAlive(image);
            GC.KeepAlive(patch);
            patch.Fix();
        }

        /// <summary>
        /// Remaps an image to log-polar space.
        /// </summary>
        /// <param name="src">Source image</param>
        /// <param name="dst">Destination image</param>
        /// <param name="center">The transformation center; where the output precision is maximal</param>
        /// <param name="m">Magnitude scale parameter.</param>
        /// <param name="flags">A combination of interpolation methods, see cv::InterpolationFlags</param>
        public static void LogPolar(
            InputArray src, OutputArray dst,
            Point2f center, double m, InterpolationFlags flags)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_logPolar(src.CvPtr, dst.CvPtr, center, m, (int) flags));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Remaps an image to polar space.
        /// </summary>
        /// <param name="src">Source image</param>
        /// <param name="dst">Destination image</param>
        /// <param name="center">The transformation center</param>
        /// <param name="maxRadius">Inverse magnitude scale parameter</param>
        /// <param name="flags">A combination of interpolation methods, see cv::InterpolationFlags</param>
        public static void LinearPolar(
            InputArray src, OutputArray dst,
            Point2f center, double maxRadius, InterpolationFlags flags)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_linearPolar(src.CvPtr, dst.CvPtr, center, maxRadius, (int) flags));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Remaps an image to polar or semilog-polar coordinates space.
        /// </summary>
        /// <remarks>
        /// -  The function can not operate in-place.
        /// -  To calculate magnitude and angle in degrees #cartToPolar is used internally thus angles are measured from 0 to 360 with accuracy about 0.3 degrees.
        /// -  This function uses #remap. Due to current implementation limitations the size of an input and output images should be less than 32767x32767.
        /// </remarks>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image. It will have same type as src.</param>
        /// <param name="dsize">The destination image size (see description for valid options).</param>
        /// <param name="center">The transformation center.</param>
        /// <param name="maxRadius">The radius of the bounding circle to transform. It determines the inverse magnitude scale parameter too.</param>
        /// <param name="interpolationFlags">interpolation methods.</param>
        /// <param name="warpPolarMode">interpolation methods.</param>
        public static void WarpPolar(
            InputArray src, OutputArray dst, Size dsize,
            Point2f center, double maxRadius, InterpolationFlags interpolationFlags, WarpPolarMode warpPolarMode)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            int flags = (int)interpolationFlags | (int)warpPolarMode;
            NativeMethods.HandleException(
                NativeMethods.imgproc_warpPolar(src.CvPtr, dst.CvPtr, dsize, center, maxRadius, flags));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Calculates the integral of an image.
        /// The function calculates one or more integral images for the source image.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="sum"></param>
        /// <param name="sdepth"></param>
        public static void Integral(InputArray src, OutputArray sum, int sdepth = -1)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (sum == null)
                throw new ArgumentNullException(nameof(sum));

            src.ThrowIfDisposed();
            sum.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_integral1(src.CvPtr, sum.CvPtr, sdepth));

            GC.KeepAlive(src);
            GC.KeepAlive(sum);
            sum.Fix();
        }

        /// <summary>
        /// Calculates the integral of an image.
        /// The function calculates one or more integral images for the source image.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="sum"></param>
        /// <param name="sqsum"></param>
        /// <param name="sdepth"></param>
        public static void Integral(InputArray src, OutputArray sum, OutputArray sqsum, int sdepth = -1)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (sum == null)
                throw new ArgumentNullException(nameof(sum));
            if (sqsum == null)
                throw new ArgumentNullException(nameof(sqsum));
            src.ThrowIfDisposed();
            sum.ThrowIfNotReady();
            sqsum.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_integral2(src.CvPtr, sum.CvPtr, sqsum.CvPtr, sdepth));

            GC.KeepAlive(src);
            GC.KeepAlive(sum);
            GC.KeepAlive(sqsum);
            sum.Fix();
            sqsum.Fix();
        }

        /// <summary>
        /// Calculates the integral of an image.
        /// The function calculates one or more integral images for the source image.
        /// </summary>
        /// <param name="src">input image as W×H, 8-bit or floating-point (32f or 64f).</param>
        /// <param name="sum">integral image as (W+1)×(H+1) , 32-bit integer or floating-point (32f or 64f).</param>
        /// <param name="sqsum">integral image for squared pixel values; it is (W+1)×(H+1), double-precision floating-point (64f) array.</param>
        /// <param name="tilted">integral for the image rotated by 45 degrees; it is (W+1)×(H+1) array with the same data type as sum.</param>
        /// <param name="sdepth">desired depth of the integral and the tilted integral images, CV_32S, CV_32F, or CV_64F.</param>
        /// <param name="sqdepth">desired depth of the integral image of squared pixel values, CV_32F or CV_64F.</param>
        public static void Integral(InputArray src, OutputArray sum, OutputArray sqsum, OutputArray tilted, int sdepth = -1, int sqdepth = -1)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (sum == null)
                throw new ArgumentNullException(nameof(sum));
            if (sqsum == null)
                throw new ArgumentNullException(nameof(sqsum));
            if (tilted == null)
                throw new ArgumentNullException(nameof(tilted));
            src.ThrowIfDisposed();
            sum.ThrowIfNotReady();
            sqsum.ThrowIfNotReady();
            tilted.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_integral3(src.CvPtr, sum.CvPtr, sqsum.CvPtr, tilted.CvPtr, sdepth, sqdepth));

            GC.KeepAlive(src);
            GC.KeepAlive(sum);
            GC.KeepAlive(sqsum);
            GC.KeepAlive(tilted);
            sum.Fix();
            sqsum.Fix();
            tilted.Fix();
        }

        /// <summary>
        /// Adds an image to the accumulator.
        /// </summary>
        /// <param name="src">Input image as 1- or 3-channel, 8-bit or 32-bit floating point.</param>
        /// <param name="dst">Accumulator image with the same number of channels as input image, 32-bit or 64-bit floating-point.</param>
        /// <param name="mask">Optional operation mask.</param>
        public static void Accumulate(InputArray src, InputOutputArray dst, InputArray mask)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_accumulate(src.CvPtr, dst.CvPtr, ToPtr(mask)));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        /// <summary>
        /// Adds the square of a source image to the accumulator.
        /// </summary>
        /// <param name="src">Input image as 1- or 3-channel, 8-bit or 32-bit floating point.</param>
        /// <param name="dst">Accumulator image with the same number of channels as input image, 32-bit or 64-bit floating-point.</param>
        /// <param name="mask">Optional operation mask.</param>
        public static void AccumulateSquare(InputArray src, InputOutputArray dst, InputArray mask)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_accumulateSquare(src.CvPtr, dst.CvPtr, ToPtr(mask)));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        /// <summary>
        /// Adds the per-element product of two input images to the accumulator.
        /// </summary>
        /// <param name="src1">First input image, 1- or 3-channel, 8-bit or 32-bit floating point.</param>
        /// <param name="src2">Second input image of the same type and the same size as src1</param>
        /// <param name="dst">Accumulator with the same number of channels as input images, 32-bit or 64-bit floating-point.</param>
        /// <param name="mask">Optional operation mask.</param>
        public static void AccumulateProduct(InputArray src1, InputArray src2, InputOutputArray dst, InputArray mask)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_accumulateProduct(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask)));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        /// <summary>
        /// Updates a running average.
        /// </summary>
        /// <param name="src">Input image as 1- or 3-channel, 8-bit or 32-bit floating point.</param>
        /// <param name="dst">Accumulator image with the same number of channels as input image, 32-bit or 64-bit floating-point.</param>
        /// <param name="alpha">Weight of the input image.</param>
        /// <param name="mask">Optional operation mask.</param>
        public static void AccumulateWeighted(InputArray src, InputOutputArray dst, double alpha, InputArray mask)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_accumulateWeighted(src.CvPtr, dst.CvPtr, alpha, ToPtr(mask)));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
            dst.Fix();
        }
        
        /// <summary>
        /// The function is used to detect translational shifts that occur between two images.
        /// 
        /// The operation takes advantage of the Fourier shift theorem for detecting the translational shift in
        /// the frequency domain.It can be used for fast image registration as well as motion estimation.
        /// For more information please see http://en.wikipedia.org/wiki/Phase_correlation.
        /// 
        /// Calculates the cross-power spectrum of two supplied source arrays. The arrays are padded if needed with getOptimalDFTSize.
        /// </summary>
        /// <param name="src1">Source floating point array (CV_32FC1 or CV_64FC1)</param>
        /// <param name="src2">Source floating point array (CV_32FC1 or CV_64FC1)</param>
        /// <param name="window">Floating point array with windowing coefficients to reduce edge effects (optional).</param>
        /// <param name="response">Signal power within the 5x5 centroid around the peak, between 0 and 1 (optional).</param>
        /// <returns>detected phase shift(sub-pixel) between the two arrays.</returns>
        public static Point2d PhaseCorrelate(InputArray src1, InputArray src2,
                                                InputArray window, out double response)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (window == null)
                throw new ArgumentNullException(nameof(window));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            window.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_phaseCorrelate(src1.CvPtr, src2.CvPtr, window.CvPtr, out response, out var ret));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(window);
            return ret;
        }

        /// <summary>
        /// Computes a Hanning window coefficients in two dimensions.
        /// </summary>
        /// <param name="dst">Destination array to place Hann coefficients in</param>
        /// <param name="winSize">The window size specifications</param>
        /// <param name="type">Created array type</param>
        public static void CreateHanningWindow(InputOutputArray dst, Size winSize, MatType type)
        {
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_createHanningWindow(dst.CvPtr, winSize, type));

            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Applies a fixed-level threshold to each array element.
        /// </summary>
        /// <param name="src">input array (single-channel, 8-bit or 32-bit floating point).</param>
        /// <param name="dst">output array of the same size and type as src.</param>
        /// <param name="thresh">threshold value.</param>
        /// <param name="maxval">maximum value to use with the THRESH_BINARY and THRESH_BINARY_INV thresholding types.</param>
        /// <param name="type">thresholding type (see the details below).</param>
        /// <returns>the computed threshold value when type == OTSU</returns>
        public static double Threshold(InputArray src, OutputArray dst, double thresh, double maxval, ThresholdTypes type)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_threshold(src.CvPtr, dst.CvPtr, thresh, maxval, (int)type, out var ret));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
            return ret;
        }

        /// <summary>
        /// Applies an adaptive threshold to an array.
        /// </summary>
        /// <param name="src">Source 8-bit single-channel image.</param>
        /// <param name="dst">Destination image of the same size and the same type as src .</param>
        /// <param name="maxValue">Non-zero value assigned to the pixels for which the condition is satisfied. See the details below.</param>
        /// <param name="adaptiveMethod">Adaptive thresholding algorithm to use, ADAPTIVE_THRESH_MEAN_C or ADAPTIVE_THRESH_GAUSSIAN_C .</param>
        /// <param name="thresholdType">Thresholding type that must be either THRESH_BINARY or THRESH_BINARY_INV .</param>
        /// <param name="blockSize">Size of a pixel neighborhood that is used to calculate a threshold value for the pixel: 3, 5, 7, and so on.</param>
        /// <param name="c">Constant subtracted from the mean or weighted mean (see the details below). 
        /// Normally, it is positive but may be zero or negative as well.</param>
        public static void AdaptiveThreshold(InputArray src, OutputArray dst,
            double maxValue, AdaptiveThresholdTypes adaptiveMethod, ThresholdTypes thresholdType, int blockSize, double c)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_adaptiveThreshold(src.CvPtr, dst.CvPtr, maxValue, (int) adaptiveMethod, (int)thresholdType, blockSize, c));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Blurs an image and downsamples it.
        /// </summary>
        /// <param name="src">input image.</param>
        /// <param name="dst">output image; it has the specified size and the same type as src.</param>
        /// <param name="dstSize">size of the output image; by default, it is computed as Size((src.cols+1)/2</param>
        /// <param name="borderType"></param>
        public static void PyrDown(InputArray src, OutputArray dst,
            Size? dstSize = null, BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            var dstSize0 = dstSize.GetValueOrDefault(new Size());
            NativeMethods.HandleException(
                NativeMethods.imgproc_pyrDown(src.CvPtr, dst.CvPtr, dstSize0, (int) borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Upsamples an image and then blurs it.
        /// </summary>
        /// <param name="src">input image.</param>
        /// <param name="dst">output image. It has the specified size and the same type as src.</param>
        /// <param name="dstSize">size of the output image; by default, it is computed as Size(src.cols*2, (src.rows*2)</param>
        /// <param name="borderType"></param>
        public static void PyrUp(InputArray src, OutputArray dst,
            Size? dstSize = null, BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            var dstSize0 = dstSize.GetValueOrDefault(new Size());
            NativeMethods.HandleException(
                NativeMethods.imgproc_pyrUp(src.CvPtr, dst.CvPtr, dstSize0, (int)borderType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

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
            int[] channels, InputArray? mask,
            OutputArray hist, int dims, int[] histSize,
            Rangef[] ranges, bool uniform = true, bool accumulate = false)
        {
            if (ranges == null)
                throw new ArgumentNullException(nameof(ranges));
            var rangesFloat = ranges.Select(r => new [] {r.Start, r.End}).ToArray();
            CalcHist(images, channels, mask, hist, dims, 
                histSize, rangesFloat, uniform, accumulate);
        }

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
            int[] channels, InputArray? mask,
            OutputArray hist, int dims, int[] histSize,
            float[][] ranges, bool uniform = true, bool accumulate = false)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (channels == null)
                throw new ArgumentNullException(nameof(channels));
            if (hist == null)
                throw new ArgumentNullException(nameof(hist));
            if (histSize == null)
                throw new ArgumentNullException(nameof(histSize));
            if (ranges == null)
                throw new ArgumentNullException(nameof(ranges));
            hist.ThrowIfNotReady();

            var imagesPtr = images.Select(x => x.CvPtr).ToArray();
            using (var rangesPtr = new ArrayAddress2<float>(ranges))
            {
                NativeMethods.HandleException(
                    NativeMethods.imgproc_calcHist(
                        imagesPtr, images.Length, channels, ToPtr(mask), hist.CvPtr,
                        dims, histSize, rangesPtr.GetPointer(), uniform ? 1 : 0, accumulate ? 1 : 0));
            }
            GC.KeepAlive(images);
            GC.KeepAlive(mask);
            GC.KeepAlive(hist);
            hist.Fix();
        }

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
                throw new ArgumentNullException(nameof(images));
            if (channels == null)
                throw new ArgumentNullException(nameof(channels));
            if (hist == null)
                throw new ArgumentNullException(nameof(hist));
            if (backProject == null)
                throw new ArgumentNullException(nameof(backProject));
            if (ranges == null)
                throw new ArgumentNullException(nameof(ranges));
            hist.ThrowIfDisposed();
            backProject.ThrowIfNotReady();

            var imagesPtr =images.Select(x => x.CvPtr).ToArray();
            var rangesFloat = ranges.Select(r => new [] {r.Start, r.End}).ToArray();
            using (var rangesPtr = new ArrayAddress2<float>(rangesFloat))
            {
                NativeMethods.HandleException(
                    NativeMethods.imgproc_calcBackProject(imagesPtr, images.Length, channels, hist.CvPtr,
                        backProject.CvPtr, rangesPtr.GetPointer(), uniform ? 1 : 0));
            }
            GC.KeepAlive(images);
            GC.KeepAlive(hist);
            GC.KeepAlive(backProject);
            backProject.Fix();
        }

        /// <summary>
        /// compares two histograms stored in dense arrays
        /// </summary>
        /// <param name="h1">The first compared histogram</param>
        /// <param name="h2">The second compared histogram of the same size as h1</param>
        /// <param name="method">The comparison method</param>
        /// <returns></returns>
        public static double CompareHist(InputArray h1, InputArray h2, HistCompMethods method)
        {
            if (h1 == null)
                throw new ArgumentNullException(nameof(h1));
            if (h2 == null)
                throw new ArgumentNullException(nameof(h2));
            h1.ThrowIfDisposed();
            h2.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_compareHist(h1.CvPtr, h2.CvPtr, (int)method, out var ret));

            GC.KeepAlive(h1);
            GC.KeepAlive(h2);
            return ret;
        }

        /// <summary>
        /// normalizes the grayscale image brightness and contrast by normalizing its histogram
        /// </summary>
        /// <param name="src">The source 8-bit single channel image</param>
        /// <param name="dst">The destination image; will have the same size and the same type as src</param>
        public static void EqualizeHist(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_equalizeHist(src.CvPtr, dst.CvPtr));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Creates a predefined CLAHE object
        /// </summary>
        /// <param name="clipLimit"></param>
        /// <param name="tileGridSize"></param>
        /// <returns></returns>
        public static CLAHE CreateCLAHE(double clipLimit = 40.0, Size? tileGridSize = null)
        {
            return CLAHE.Create(clipLimit, tileGridSize);
        }

        /// <summary>
        /// Computes the "minimal work" distance between two weighted point configurations.
        ///
        /// The function computes the earth mover distance and/or a lower boundary of the distance between the
        /// two weighted point configurations.One of the applications described in @cite RubnerSept98,
        /// @cite Rubner2000 is multi-dimensional histogram comparison for image retrieval.EMD is a transportation
        /// problem that is solved using some modification of a simplex algorithm, thus the complexity is
        /// exponential in the worst case, though, on average it is much faster.In the case of a real metric
        /// the lower boundary can be calculated even faster (using linear-time algorithm) and it can be used
        /// to determine roughly whether the two signatures are far enough so that they cannot relate to the same object.
        /// </summary>
        /// <param name="signature1">First signature, a \f$\texttt{size1}\times \texttt{dims}+1\f$ floating-point matrix. 
        /// Each row stores the point weight followed by the point coordinates.The matrix is allowed to have
        /// a single column(weights only) if the user-defined cost matrix is used.The weights must be non-negative
        /// and have at least one non-zero value.</param>
        /// <param name="signature2">Second signature of the same format as signature1 , though the number of rows
        /// may be different.The total weights may be different.In this case an extra "dummy" point is added
        /// to either signature1 or signature2. The weights must be non-negative and have at least one non-zero value.</param>
        /// <param name="distType">Used metric.</param>
        /// <returns></returns>
        public static float EMD(InputArray signature1, InputArray signature2, DistanceTypes distType)
        {
            return EMD(signature1, signature2, distType, null, out _);
        }

        /// <summary>
        /// Computes the "minimal work" distance between two weighted point configurations.
        ///
        /// The function computes the earth mover distance and/or a lower boundary of the distance between the
        /// two weighted point configurations.One of the applications described in @cite RubnerSept98,
        /// @cite Rubner2000 is multi-dimensional histogram comparison for image retrieval.EMD is a transportation
        /// problem that is solved using some modification of a simplex algorithm, thus the complexity is
        /// exponential in the worst case, though, on average it is much faster.In the case of a real metric
        /// the lower boundary can be calculated even faster (using linear-time algorithm) and it can be used
        /// to determine roughly whether the two signatures are far enough so that they cannot relate to the same object.
        /// </summary>
        /// <param name="signature1">First signature, a \f$\texttt{size1}\times \texttt{dims}+1\f$ floating-point matrix. 
        /// Each row stores the point weight followed by the point coordinates.The matrix is allowed to have
        /// a single column(weights only) if the user-defined cost matrix is used.The weights must be non-negative
        /// and have at least one non-zero value.</param>
        /// <param name="signature2">Second signature of the same format as signature1 , though the number of rows
        /// may be different.The total weights may be different.In this case an extra "dummy" point is added
        /// to either signature1 or signature2. The weights must be non-negative and have at least one non-zero value.</param>
        /// <param name="distType">Used metric.</param>
        /// <param name="cost">User-defined size1 x size2 cost matrix. Also, if a cost matrix
        /// is used, lower boundary lowerBound cannot be calculated because it needs a metric function.</param>
        /// <returns></returns>
        public static float EMD(InputArray signature1, InputArray signature2,
            DistanceTypes distType, InputArray? cost)
        {
            return EMD(signature1, signature2, distType, cost, out _);
        }

        /// <summary>
        /// Computes the "minimal work" distance between two weighted point configurations.
        ///
        /// The function computes the earth mover distance and/or a lower boundary of the distance between the
        /// two weighted point configurations.One of the applications described in @cite RubnerSept98,
        /// @cite Rubner2000 is multi-dimensional histogram comparison for image retrieval.EMD is a transportation
        /// problem that is solved using some modification of a simplex algorithm, thus the complexity is
        /// exponential in the worst case, though, on average it is much faster.In the case of a real metric
        /// the lower boundary can be calculated even faster (using linear-time algorithm) and it can be used
        /// to determine roughly whether the two signatures are far enough so that they cannot relate to the same object.
        /// </summary>
        /// <param name="signature1">First signature, a \f$\texttt{size1}\times \texttt{dims}+1\f$ floating-point matrix. 
        /// Each row stores the point weight followed by the point coordinates.The matrix is allowed to have
        /// a single column(weights only) if the user-defined cost matrix is used.The weights must be non-negative
        /// and have at least one non-zero value.</param>
        /// <param name="signature2">Second signature of the same format as signature1 , though the number of rows
        /// may be different.The total weights may be different.In this case an extra "dummy" point is added
        /// to either signature1 or signature2. The weights must be non-negative and have at least one non-zero value.</param>
        /// <param name="distType">Used metric.</param>
        /// <param name="cost">User-defined size1 x size2 cost matrix. Also, if a cost matrix
        /// is used, lower boundary lowerBound cannot be calculated because it needs a metric function.</param>
        /// <param name="lowerBound">Optional input/output parameter: lower boundary of a distance between the two
        /// signatures that is a distance between mass centers.The lower boundary may not be calculated if
        /// the user-defined cost matrix is used, the total weights of point configurations are not equal, or
        /// if the signatures consist of weights only(the signature matrices have a single column). You ** must**
        /// initialize \*lowerBound.If the calculated distance between mass centers is greater or equal to
        /// \*lowerBound(it means that the signatures are far enough), the function does not calculate EMD.
        /// In any case \*lowerBound is set to the calculated distance between mass centers on return.
        /// Thus, if you want to calculate both distance between mass centers and EMD, \*lowerBound should be set to 0.</param>
        /// <param name="flow">Resultant size1 x size2 flow matrix: flow[i,j] is  a flow from i-th point of signature1
        /// to j-th point of signature2.</param>
        /// <returns></returns>
        public static float EMD(InputArray signature1, InputArray signature2,
            DistanceTypes distType, InputArray? cost, out float lowerBound, OutputArray? flow = null)
        {
            if (signature1 == null)
                throw new ArgumentNullException(nameof(signature1));
            if (signature2 == null)
                throw new ArgumentNullException(nameof(signature2));
            signature1.ThrowIfDisposed();
            signature2.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_EMD(
                    signature1.CvPtr, signature2.CvPtr, (int) distType, ToPtr(cost),
                    out lowerBound, ToPtr(flow), out var ret));

            GC.KeepAlive(signature1);
            GC.KeepAlive(signature2);
            GC.KeepAlive(cost);
            GC.KeepAlive(flow);
            flow?.Fix();
            return ret;
        }

        /// <summary>
        /// Performs a marker-based image segmentation using the watershed algorithm.
        /// </summary>
        /// <param name="image">Input 8-bit 3-channel image.</param>
        /// <param name="markers">Input/output 32-bit single-channel image (map) of markers. 
        /// It should have the same size as image.</param>
        public static void Watershed(InputArray image, InputOutputArray markers)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (markers == null)
                throw new ArgumentNullException(nameof(markers));
            image.ThrowIfDisposed();
            markers.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_watershed(image.CvPtr, markers.CvPtr));

            GC.KeepAlive(image);
            GC.KeepAlive(markers);
            markers.Fix();
        }

        /// <summary>
        /// Performs initial step of meanshift segmentation of an image.
        /// </summary>
        /// <param name="src">The source 8-bit, 3-channel image.</param>
        /// <param name="dst">The destination image of the same format and the same size as the source.</param>
        /// <param name="sp">The spatial window radius.</param>
        /// <param name="sr">The color window radius.</param>
        /// <param name="maxLevel">Maximum level of the pyramid for the segmentation.</param>
        /// <param name="termcrit">Termination criteria: when to stop meanshift iterations.</param>
        public static void PyrMeanShiftFiltering(InputArray src, OutputArray dst,
            double sp, double sr, int maxLevel = 1, TermCriteria? termcrit = null)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            var termcrit0 = termcrit.GetValueOrDefault(
                new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 5, 1));
            NativeMethods.HandleException(
                NativeMethods.imgproc_pyrMeanShiftFiltering(src.CvPtr, dst.CvPtr, sp, sr, maxLevel, termcrit0));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Segments the image using GrabCut algorithm
        /// </summary>
        /// <param name="img">Input 8-bit 3-channel image.</param>
        /// <param name="mask">Input/output 8-bit single-channel mask. 
        /// The mask is initialized by the function when mode is set to GC_INIT_WITH_RECT. 
        /// Its elements may have Cv2.GC_BGD / Cv2.GC_FGD / Cv2.GC_PR_BGD / Cv2.GC_PR_FGD</param>
        /// <param name="rect">ROI containing a segmented object. The pixels outside of the ROI are 
        /// marked as "obvious background". The parameter is only used when mode==GC_INIT_WITH_RECT.</param>
        /// <param name="bgdModel">Temporary array for the background model. Do not modify it while you are processing the same image.</param>
        /// <param name="fgdModel">Temporary arrays for the foreground model. Do not modify it while you are processing the same image.</param>
        /// <param name="iterCount">Number of iterations the algorithm should make before returning the result. 
        /// Note that the result can be refined with further calls with mode==GC_INIT_WITH_MASK or mode==GC_EVAL .</param>
        /// <param name="mode">Operation mode that could be one of GrabCutFlag value.</param>
        public static void GrabCut(InputArray img, InputOutputArray mask, Rect rect,
                                   InputOutputArray bgdModel, InputOutputArray fgdModel,
                                   int iterCount, GrabCutModes mode)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (mask == null)
                throw new ArgumentNullException(nameof(mask));
            if (bgdModel == null)
                throw new ArgumentNullException(nameof(bgdModel));
            if (fgdModel == null)
                throw new ArgumentNullException(nameof(fgdModel));
            img.ThrowIfDisposed();
            mask.ThrowIfNotReady();
            bgdModel.ThrowIfNotReady();
            fgdModel.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_grabCut(
                    img.CvPtr, mask.CvPtr, rect,
                    bgdModel.CvPtr, fgdModel.CvPtr, iterCount, (int) mode));

            GC.KeepAlive(img);
            GC.KeepAlive(mask);
            GC.KeepAlive(bgdModel);
            GC.KeepAlive(fgdModel);
            mask.Fix();
            bgdModel.Fix();
            fgdModel.Fix();
        }

        /// <summary>
        /// Calculates the distance to the closest zero pixel for each pixel of the source image.
        /// </summary>
        /// <param name="src">8-bit, single-channel (binary) source image.</param>
        /// <param name="dst">Output image with calculated distances. It is a 8-bit or 32-bit floating-point,
        /// single-channel image of the same size as src.</param>
        /// <param name="labels">Output 2D array of labels (the discrete Voronoi diagram). It has the type
        /// CV_32SC1 and the same size as src.</param>
        /// <param name="distanceType">Type of distance</param>
        /// <param name="maskSize">Size of the distance transform mask, see #DistanceTransformMasks.
        /// #DIST_MASK_PRECISE is not supported by this variant. In case of the #DIST_L1 or #DIST_C distance type,
        /// the parameter is forced to 3 because a 3x3 mask gives the same result as 5x5 or any larger aperture.</param>
        /// <param name="labelType">Type of the label array to build</param>
        public static void DistanceTransformWithLabels(InputArray src,
                                                       OutputArray dst,
                                                       OutputArray labels,
                                                       DistanceTypes distanceType,
                                                       DistanceMaskSize maskSize,
                                                       DistanceTransformLabelTypes labelType = DistanceTransformLabelTypes.CComp)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            labels.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_distanceTransformWithLabels(
                    src.CvPtr, dst.CvPtr, labels.CvPtr, (int) distanceType, (int) maskSize, (int) labelType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(labels);
            dst.Fix();
            labels.Fix();
        }

        /// <summary>
        /// computes the distance transform map
        /// </summary>
        /// <param name="src">8-bit, single-channel (binary) source image.</param>
        /// <param name="dst">Output image with calculated distances. It is a 8-bit or 32-bit floating-point,
        /// single-channel image of the same size as src.</param>
        /// <param name="distanceType">Type of distance</param>
        /// <param name="maskSize">Size of the distance transform mask, see #DistanceTransformMasks. In case of the
        /// #DIST_L1 or #DIST_C distance type, the parameter is forced to 3 because a 3x3 mask gives
        /// the same result as 5x5 or any larger aperture.</param>
        /// <param name="dstType">Type of output image. It can be MatType.CV_8U or MatType.CV_32F.
        /// Type CV_8U can be used only for  the first variant of the function and distanceType == #DIST_L1.</param>
        public static void DistanceTransform(InputArray src,
                                             OutputArray dst,
                                             DistanceTypes distanceType,
                                             DistanceMaskSize maskSize,
                                             int dstType = MatType.CV_32S)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_distanceTransform(src.CvPtr, dst.CvPtr, (int) distanceType, (int) maskSize, dstType));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Fills a connected component with the given color.
        /// </summary>
        /// <param name="image">Input/output 1- or 3-channel, 8-bit, or floating-point image. 
        /// It is modified by the function unless the FLOODFILL_MASK_ONLY flag is set in the 
        /// second variant of the function. See the details below.</param>
        /// <param name="seedPoint">Starting point.</param>
        /// <param name="newVal">New value of the repainted domain pixels.</param>
        /// <returns></returns>
        public static int FloodFill(InputOutputArray image, Point seedPoint, Scalar newVal)
        {
            return FloodFill(image, seedPoint, newVal, out _);
        }

        /// <summary>
        /// Fills a connected component with the given color.
        /// </summary>
        /// <param name="image">Input/output 1- or 3-channel, 8-bit, or floating-point image. 
        /// It is modified by the function unless the FLOODFILL_MASK_ONLY flag is set in the 
        /// second variant of the function. See the details below.</param>
        /// <param name="seedPoint">Starting point.</param>
        /// <param name="newVal">New value of the repainted domain pixels.</param>
        /// <param name="rect">Optional output parameter set by the function to the 
        /// minimum bounding rectangle of the repainted domain.</param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently 
        /// observed pixel and one of its neighbors belonging to the component, or a seed pixel 
        /// being added to the component.</param>
        /// <param name="upDiff">Maximal upper brightness/color difference between the currently 
        /// observed pixel and one of its neighbors belonging to the component, or a seed pixel 
        /// being added to the component.</param>
        /// <param name="flags">Operation flags. Lower bits contain a connectivity value, 
        /// 4 (default) or 8, used within the function. Connectivity determines which 
        /// neighbors of a pixel are considered. </param>
        /// <returns></returns>
        public static int FloodFill(InputOutputArray image,
                                    Point seedPoint, Scalar newVal, out Rect rect,
                                    Scalar? loDiff = null, Scalar? upDiff = null,
                                    FloodFillFlags flags = FloodFillFlags.Link4)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfNotReady();
            var loDiff0 = loDiff.GetValueOrDefault(new Scalar());
            var upDiff0 = upDiff.GetValueOrDefault(new Scalar());

            NativeMethods.HandleException(
                NativeMethods.imgproc_floodFill1(
                    image.CvPtr, seedPoint, newVal, out rect,
                    loDiff0, upDiff0, (int)flags, out var ret));

            GC.KeepAlive(image);
            image.Fix();
            return ret;
        }

        /// <summary>
        /// Fills a connected component with the given color.
        /// </summary>
        /// <param name="image">Input/output 1- or 3-channel, 8-bit, or floating-point image. 
        /// It is modified by the function unless the FLOODFILL_MASK_ONLY flag is set in the 
        /// second variant of the function. See the details below.</param>
        /// <param name="mask">(For the second function only) Operation mask that should be a single-channel 8-bit image, 
        /// 2 pixels wider and 2 pixels taller. The function uses and updates the mask, so you take responsibility of 
        /// initializing the mask content. Flood-filling cannot go across non-zero pixels in the mask. For example, 
        /// an edge detector output can be used as a mask to stop filling at edges. It is possible to use the same mask 
        /// in multiple calls to the function to make sure the filled area does not overlap.</param>
        /// <param name="seedPoint">Starting point.</param>
        /// <param name="newVal">New value of the repainted domain pixels.</param>
        /// <returns></returns>
        public static int FloodFill(InputOutputArray image, InputOutputArray mask,
                                    Point seedPoint, Scalar newVal)
        {
            return FloodFill(image, mask, seedPoint, newVal, out _);
        }

        /// <summary>
        /// Fills a connected component with the given color.
        /// </summary>
        /// <param name="image">Input/output 1- or 3-channel, 8-bit, or floating-point image. 
        /// It is modified by the function unless the FLOODFILL_MASK_ONLY flag is set in the 
        /// second variant of the function. See the details below.</param>
        /// <param name="mask">(For the second function only) Operation mask that should be a single-channel 8-bit image, 
        /// 2 pixels wider and 2 pixels taller. The function uses and updates the mask, so you take responsibility of 
        /// initializing the mask content. Flood-filling cannot go across non-zero pixels in the mask. For example, 
        /// an edge detector output can be used as a mask to stop filling at edges. It is possible to use the same mask 
        /// in multiple calls to the function to make sure the filled area does not overlap.</param>
        /// <param name="seedPoint">Starting point.</param>
        /// <param name="newVal">New value of the repainted domain pixels.</param>
        /// <param name="rect">Optional output parameter set by the function to the 
        /// minimum bounding rectangle of the repainted domain.</param>
        /// <param name="loDiff">Maximal lower brightness/color difference between the currently 
        /// observed pixel and one of its neighbors belonging to the component, or a seed pixel 
        /// being added to the component.</param>
        /// <param name="upDiff">Maximal upper brightness/color difference between the currently 
        /// observed pixel and one of its neighbors belonging to the component, or a seed pixel 
        /// being added to the component.</param>
        /// <param name="flags">Operation flags. Lower bits contain a connectivity value, 
        /// 4 (default) or 8, used within the function. Connectivity determines which 
        /// neighbors of a pixel are considered. </param>
        /// <returns></returns>
        public static int FloodFill(InputOutputArray image, InputOutputArray mask,
                                    Point seedPoint, Scalar newVal, out Rect rect,
                                    Scalar? loDiff = null, Scalar? upDiff = null,
                                    FloodFillFlags flags = FloodFillFlags.Link4)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (mask == null)
                throw new ArgumentNullException(nameof(mask));
            image.ThrowIfNotReady();
            mask.ThrowIfNotReady();
            var loDiff0 = loDiff.GetValueOrDefault(new Scalar());
            var upDiff0 = upDiff.GetValueOrDefault(new Scalar());

            NativeMethods.HandleException(
                NativeMethods.imgproc_floodFill2(
                    image.CvPtr, mask.CvPtr, seedPoint,
                    newVal, out rect, loDiff0, upDiff0, (int)flags, out var ret));

            GC.KeepAlive(image);
            GC.KeepAlive(mask);
            image.Fix();
            mask.Fix();
            return ret;
        }

        /// <summary>
        /// Performs linear blending of two images:
        /// dst(i,j) = weights1(i,j)*src1(i,j) + weights2(i,j)*src2(i,j)
        /// </summary>
        /// <param name="src1">It has a type of CV_8UC(n) or CV_32FC(n), where n is a positive integer.</param>
        /// <param name="src2">It has the same type and size as src1.</param>
        /// <param name="weights1">It has a type of CV_32FC1 and the same size with src1.</param>
        /// <param name="weights2">It has a type of CV_32FC1 and the same size with src1.</param>
        /// <param name="dst">It is created if it does not have the same size and type with src1.</param>
        public static void BlendLinear(InputArray src1, InputArray src2, InputArray weights1, InputArray weights2,
            OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (weights1 == null)
                throw new ArgumentNullException(nameof(weights1));
            if (weights2 == null)
                throw new ArgumentNullException(nameof(weights2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            weights1.ThrowIfDisposed();
            weights2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_blendLinear(src1.CvPtr, src2.CvPtr, weights1.CvPtr, weights2.CvPtr, dst.CvPtr));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(weights1);
            GC.KeepAlive(weights2);
            dst.Fix();
        }

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
        public static void CvtColor(InputArray src, OutputArray dst, ColorConversionCodes code, int dstCn = 0)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            
            NativeMethods.HandleException(
                NativeMethods.imgproc_cvtColor(src.CvPtr, dst.CvPtr, (int) code, dstCn));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Converts an image from one color space to another where the source image is stored in two planes.
        /// This function only supports YUV420 to RGB conversion as of now.
        /// </summary>
        /// <param name="src1">8-bit image (#CV_8U) of the Y plane.</param>
        /// <param name="src2">image containing interleaved U/V plane.</param>
        /// <param name="dst">output image.</param>
        /// <param name="code">Specifies the type of conversion. It can take any of the following values:
        /// - #COLOR_YUV2BGR_NV12
        /// - #COLOR_YUV2RGB_NV12
        /// - #COLOR_YUV2BGRA_NV12
        /// - #COLOR_YUV2RGBA_NV12
        /// - #COLOR_YUV2BGR_NV21
        /// - #COLOR_YUV2RGB_NV21
        /// - #COLOR_YUV2BGRA_NV21
        /// - #COLOR_YUV2RGBA_NV21</param>
        public static void CvtColorTwoPlane(InputArray src1, InputArray src2, OutputArray dst, ColorConversionCodes code)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1)); 
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_cvtColorTwoPlane(src1.CvPtr, src2.CvPtr, dst.CvPtr, (int)code));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// main function for all demosaicing processes
        /// </summary>
        /// <param name="src">input image: 8-bit unsigned or 16-bit unsigned.</param>
        /// <param name="dst">output image of the same size and depth as src.</param>
        /// <param name="code">Color space conversion code (see the description below).</param>
        /// <param name="dstCn">number of channels in the destination image; if the parameter is 0,
        /// the number of the channels is derived automatically from src and code.</param>
        /// <remarks>
        /// The function can do the following transformations:
        ///
        /// -   Demosaicing using bilinear interpolation
        /// 
        ///     #COLOR_BayerBG2BGR , #COLOR_BayerGB2BGR , #COLOR_BayerRG2BGR , #COLOR_BayerGR2BGR
        ///     #COLOR_BayerBG2GRAY , #COLOR_BayerGB2GRAY , #COLOR_BayerRG2GRAY , #COLOR_BayerGR2GRAY
        ///
        /// -   Demosaicing using Variable Number of Gradients.
        ///
        ///     #COLOR_BayerBG2BGR_VNG , #COLOR_BayerGB2BGR_VNG , #COLOR_BayerRG2BGR_VNG , #COLOR_BayerGR2BGR_VNG
        ///
        /// -   Edge-Aware Demosaicing.
        ///
        ///     #COLOR_BayerBG2BGR_EA , #COLOR_BayerGB2BGR_EA , #COLOR_BayerRG2BGR_EA , #COLOR_BayerGR2BGR_EA
        ///
        /// -   Demosaicing with alpha channel
        ///
        ///     # COLOR_BayerBG2BGRA , #COLOR_BayerGB2BGRA , #COLOR_BayerRG2BGRA , #COLOR_BayerGR2BGRA
        /// </remarks>
        public static void Demosaicing(InputArray src, OutputArray dst, ColorConversionCodes code, int dstCn = 0)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_demosaicing(src.CvPtr, dst.CvPtr, (int)code, dstCn));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Calculates all of the moments 
        /// up to the third order of a polygon or rasterized shape.
        /// </summary>
        /// <param name="array">A raster image (single-channel, 8-bit or floating-point 
        /// 2D array) or an array ( 1xN or Nx1 ) of 2D points ( Point or Point2f )</param>
        /// <param name="binaryImage">If it is true, then all the non-zero image pixels are treated as 1’s</param>
        /// <returns></returns>
        public static Moments Moments(InputArray array, bool binaryImage = false)
        {
            return new Moments(array, binaryImage);
        }
        
        /// <summary>
        /// Calculates all of the moments 
        /// up to the third order of a polygon or rasterized shape.
        /// </summary>
        /// <param name="array">A raster image (8-bit) 2D array</param>
        /// <param name="binaryImage">If it is true, then all the non-zero image pixels are treated as 1’s</param>
        /// <returns></returns>
        public static Moments Moments(byte[,] array, bool binaryImage = false)
        {
            return new Moments(array, binaryImage);
        }

        /// <summary>
        /// Calculates all of the moments 
        /// up to the third order of a polygon or rasterized shape.
        /// </summary>
        /// <param name="array">A raster image (floating-point) 2D array</param>
        /// <param name="binaryImage">If it is true, then all the non-zero image pixels are treated as 1’s</param>
        /// <returns></returns>
        public static Moments Moments(float[,] array, bool binaryImage = false)
        {
            return new Moments(array, binaryImage);
        }

        /// <summary>
        /// Calculates all of the moments 
        /// up to the third order of a polygon or rasterized shape.
        /// </summary>
        /// <param name="array">Array of 2D points</param>
        /// <param name="binaryImage">If it is true, then all the non-zero image pixels are treated as 1’s</param>
        /// <returns></returns>
        public static Moments Moments(IEnumerable<Point> array, bool binaryImage = false)
        {
            return new Moments(array, binaryImage);
        }

        /// <summary>
        /// Calculates all of the moments 
        /// up to the third order of a polygon or rasterized shape.
        /// </summary>
        /// <param name="array">Array of 2D points</param>
        /// <param name="binaryImage">If it is true, then all the non-zero image pixels are treated as 1’s</param>
        /// <returns></returns>
        public static Moments Moments(IEnumerable<Point2f> array, bool binaryImage = false)
        {
            return new Moments(array, binaryImage);
        }

        /// <summary>
        /// Computes the proximity map for the raster template and the image where the template is searched for
        /// </summary>
        /// <param name="image">Image where the search is running; should be 8-bit or 32-bit floating-point</param>
        /// <param name="templ">Searched template; must be not greater than the source image and have the same data type</param>
        /// <param name="result">A map of comparison results; will be single-channel 32-bit floating-point. 
        /// If image is WxH and templ is wxh then result will be (W-w+1) x (H-h+1).</param>
        /// <param name="method">Specifies the comparison method</param>
        /// <param name="mask">Mask of searched template. It must have the same datatype and size with templ. It is not set by default.</param>
        public static void MatchTemplate(
            InputArray image, 
            InputArray templ,
            OutputArray result,
            TemplateMatchModes method, 
            InputArray? mask = null)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (templ == null)
                throw new ArgumentNullException(nameof(templ));
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            image.ThrowIfDisposed();
            templ.ThrowIfDisposed();
            result.ThrowIfNotReady();
            mask?.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_matchTemplate(image.CvPtr, templ.CvPtr, result.CvPtr, (int) method, ToPtr(mask)));

            GC.KeepAlive(image);
            GC.KeepAlive(templ);
            GC.KeepAlive(result);
            result.Fix();
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// Computes the connected components labeled image of boolean image.
        ///
        /// image with 4 or 8 way connectivity - returns N, the total number of labels[0, N - 1] where 0
        /// represents the background label.ltype specifies the output label image type, an important
        /// consideration based on the total number of labels or alternatively the total number of pixels in
        /// the source image.ccltype specifies the connected components labeling algorithm to use, currently
        /// Grana (BBDT) and Wu's (SAUF) algorithms are supported, see the #ConnectedComponentsAlgorithmsTypes
        /// for details.Note that SAUF algorithm forces a row major ordering of labels while BBDT does not.
        /// This function uses parallel version of both Grana and Wu's algorithms if at least one allowed
        /// parallel framework is enabled and if the rows of the image are at least twice the number returned by #getNumberOfCPUs.
        /// </summary>
        /// <param name="image">the 8-bit single-channel image to be labeled</param>
        /// <param name="labels">destination labeled image</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <param name="ltype">output image label type. Currently CV_32S and CV_16U are supported.</param>
        /// <param name="ccltype">connected components algorithm type.</param>
        /// <returns></returns>
        public static int ConnectedComponentsWithAlgorithm(
            InputArray image, OutputArray labels, PixelConnectivity connectivity, MatType ltype, ConnectedComponentsAlgorithmsTypes ccltype)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            image.ThrowIfDisposed();
            labels.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_connectedComponentsWithAlgorithm(
                    image.CvPtr, labels.CvPtr, (int)connectivity, ltype, (int)ccltype, out var ret));

            GC.KeepAlive(image);
            GC.KeepAlive(labels);
            labels.Fix();
            return ret;
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="image">the image to be labeled</param>
        /// <param name="labels">destination labeled image</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <returns>The number of labels</returns>
        public static int ConnectedComponents(InputArray image, OutputArray labels,
            PixelConnectivity connectivity = PixelConnectivity.Connectivity8)
        {
            return ConnectedComponents(image, labels, connectivity, MatType.CV_32S);
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="image">the image to be labeled</param>
        /// <param name="labels">destination labeled image</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <param name="ltype">output image label type. Currently CV_32S and CV_16U are supported.</param>
        /// <returns>The number of labels</returns>
        public static int ConnectedComponents(InputArray image, OutputArray labels,
            PixelConnectivity connectivity, MatType ltype)
        {
            if (image == null) 
                throw new ArgumentNullException(nameof(image));
            if (labels == null) 
                throw new ArgumentNullException(nameof(labels));
            image.ThrowIfDisposed();
            labels.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_connectedComponents(
                    image.CvPtr, labels.CvPtr, (int)connectivity, ltype, out var ret));

            GC.KeepAlive(image);
            GC.KeepAlive(labels);
            labels.Fix();
            return ret;
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="image">the image to be labeled</param>
        /// <param name="labels">destination labeled rectangular array</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <returns>The number of labels</returns>
        public static int ConnectedComponents(InputArray image, out int[,] labels, PixelConnectivity connectivity)
        {
            using var labelsMat = new Mat<int>();
            var result = ConnectedComponents(image, labelsMat, connectivity, MatType.CV_32S);
            labels = labelsMat.ToRectangularArray();
            return result;
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image and also produces a statistics output for each label.
        ///
        /// image with 4 or 8 way connectivity - returns N, the total number of labels[0, N - 1] where 0
        /// represents the background label.ltype specifies the output label image type, an important
        /// consideration based on the total number of labels or alternatively the total number of pixels in
        /// the source image.ccltype specifies the connected components labeling algorithm to use, currently
        /// Grana's (BBDT) and Wu's (SAUF) algorithms are supported, see the #ConnectedComponentsAlgorithmsTypes
        /// for details.Note that SAUF algorithm forces a row major ordering of labels while BBDT does not.
        /// This function uses parallel version of both Grana and Wu's algorithms (statistics included) if at least one allowed
        /// parallel framework is enabled and if the rows of the image are at least twice the number returned by #getNumberOfCPUs.
        /// </summary>
        /// <param name="image">the 8-bit single-channel image to be labeled</param>
        /// <param name="labels">destination labeled image</param>
        /// <param name="stats">statistics output for each label, including the background label, see below for
        /// available statistics.Statistics are accessed via stats(label, COLUMN) where COLUMN is one of #ConnectedComponentsTypes. The data type is CV_32S.</param>
        /// <param name="centroids">centroid output for each label, including the background label. Centroids are
        /// accessed via centroids(label, 0) for x and centroids(label, 1) for y.The data type CV_64F.</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <param name="ltype">output image label type. Currently CV_32S and CV_16U are supported.</param>
        /// <param name="ccltype">connected components algorithm type.</param>
        /// <returns></returns>
        public static int ConnectedComponentsWithStatsWithAlgorithm(
            InputArray image,
            OutputArray labels,
            OutputArray stats, 
            OutputArray centroids,
            PixelConnectivity connectivity,
            MatType ltype, 
            ConnectedComponentsAlgorithmsTypes ccltype)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            if (stats == null)
                throw new ArgumentNullException(nameof(stats));
            if (centroids == null)
                throw new ArgumentNullException(nameof(centroids));
            image.ThrowIfDisposed();
            labels.ThrowIfNotReady();
            stats.ThrowIfNotReady();
            centroids.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_connectedComponentsWithStatsWithAlgorithm(
                    image.CvPtr, labels.CvPtr, stats.CvPtr, centroids.CvPtr, (int)connectivity, ltype, (int)ccltype, out var ret));

            GC.KeepAlive(image);
            GC.KeepAlive(labels);
            GC.KeepAlive(stats);
            GC.KeepAlive(centroids);
            labels.Fix();
            stats.Fix();
            centroids.Fix();
            return ret;
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="image">the image to be labeled</param>
        /// <param name="labels">destination labeled image</param>
        /// <param name="stats">statistics output for each label, including the background label, 
        /// see below for available statistics. Statistics are accessed via stats(label, COLUMN) 
        /// where COLUMN is one of cv::ConnectedComponentsTypes</param>
        /// <param name="centroids">floating point centroid (x,y) output for each label, 
        /// including the background label</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <returns></returns>
        public static int ConnectedComponentsWithStats(
            InputArray image, OutputArray labels,
            OutputArray stats, OutputArray centroids,
            PixelConnectivity connectivity = PixelConnectivity.Connectivity8)
        {
            return ConnectedComponentsWithStats(image, labels, stats, centroids, connectivity, MatType.CV_32S);
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="image">the image to be labeled</param>
        /// <param name="labels">destination labeled image</param>
        /// <param name="stats">statistics output for each label, including the background label, 
        /// see below for available statistics. Statistics are accessed via stats(label, COLUMN) 
        /// where COLUMN is one of cv::ConnectedComponentsTypes</param>
        /// <param name="centroids">floating point centroid (x,y) output for each label, 
        /// including the background label</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <param name="ltype">output image label type. Currently CV_32S and CV_16U are supported.</param>
        /// <returns></returns>
        public static int ConnectedComponentsWithStats(
            InputArray image, OutputArray labels,
            OutputArray stats, OutputArray centroids,
            PixelConnectivity connectivity,
            MatType ltype)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            if (stats == null)
                throw new ArgumentNullException(nameof(stats));
            if (centroids == null)
                throw new ArgumentNullException(nameof(centroids));
            image.ThrowIfDisposed();
            labels.ThrowIfNotReady();
            stats.ThrowIfNotReady();
            centroids.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_connectedComponentsWithStats(
                    image.CvPtr, labels.CvPtr, stats.CvPtr, centroids.CvPtr, (int) connectivity, ltype, out var ret));

            GC.KeepAlive(image);
            GC.KeepAlive(labels);
            GC.KeepAlive(stats);
            GC.KeepAlive(centroids);
            labels.Fix();
            stats.Fix();
            centroids.Fix();
            return ret;
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="image">the image to be labeled</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <param name="ccltype"></param>
        /// <returns></returns>
        public static ConnectedComponents ConnectedComponentsEx(
            InputArray image, 
            PixelConnectivity connectivity = PixelConnectivity.Connectivity8, 
            ConnectedComponentsAlgorithmsTypes ccltype = ConnectedComponentsAlgorithmsTypes.Default)
        {
            using var labelsMat = new Mat<int>();
            using var statsMat = new Mat<int>();
            using var centroidsMat = new Mat<double>();
            var nLabels = ConnectedComponentsWithStatsWithAlgorithm(
                image, labelsMat, statsMat, centroidsMat, connectivity, MatType.CV_32S, ccltype);
            var labels = labelsMat.ToRectangularArray();
            var stats = statsMat.ToRectangularArray();
            var centroids = centroidsMat.ToRectangularArray();

            var blobs = new ConnectedComponents.Blob[nLabels];
            for (var i = 0; i < nLabels; i++)
            {
                blobs[i] = new ConnectedComponents.Blob
                {
                    Label = i,
                    Left = stats[i, 0],
                    Top = stats[i, 1],
                    Width = stats[i, 2],
                    Height = stats[i, 3],
                    Area = stats[i, 4],
                    Centroid = new Point2d(centroids[i, 0], centroids[i, 1]),
                };
            }
            return new ConnectedComponents(blobs, labels, nLabels);
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
        public static void FindContours(InputArray image, out Point[][] contours,
            out HierarchyIndex[] hierarchy, RetrievalModes mode, ContourApproximationModes method, Point? offset = null)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            var offset0 = offset.GetValueOrDefault(new Point());
            NativeMethods.HandleException(
                NativeMethods.imgproc_findContours1_vector(image.CvPtr, out var contoursPtr, out var hierarchyPtr, (int)mode, (int)method, offset0));

            using (var contoursVec = new VectorOfVectorPoint(contoursPtr))
            {
                using var hierarchyVec = new VectorOfVec4i(hierarchyPtr);
                contours = contoursVec.ToArray();
                var hierarchyOrg = hierarchyVec.ToArray();
                hierarchy = hierarchyOrg.Select(HierarchyIndex.FromVec4i).ToArray();
            }

            GC.KeepAlive(image);
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
        public static void FindContours(InputArray image, out Mat[] contours,
            OutputArray hierarchy, RetrievalModes mode, ContourApproximationModes method, Point? offset = null)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (hierarchy == null)
                throw new ArgumentNullException(nameof(hierarchy));
            image.ThrowIfDisposed();
            hierarchy.ThrowIfNotReady();

            var offset0 = offset.GetValueOrDefault(new Point());
            NativeMethods.HandleException(
                NativeMethods.imgproc_findContours1_OutputArray(image.CvPtr, out var contoursPtr, hierarchy.CvPtr, (int) mode, (int) method, offset0));

            using (var contoursVec = new VectorOfMat(contoursPtr))
            {
                contours = contoursVec.ToArray();
            }

            hierarchy.Fix();
            GC.KeepAlive(image);
            GC.KeepAlive(hierarchy);
        }

#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を検出します．
        /// </summary>
        /// <param name="image">入力画像，8ビット，シングルチャンネル．0以外のピクセルは 1として，0のピクセルは0のまま扱われます．
        /// また，この関数は，輪郭抽出処理中に入力画像 image の中身を書き換えます．</param>
        /// <param name="mode">輪郭抽出モード</param>
        /// <param name="method">輪郭の近似手法</param>
        /// <param name="offset">オプションのオフセット．各輪郭点はこの値の分だけシフトします．これは，ROIの中で抽出された輪郭を，画像全体に対して位置づけて解析する場合に役立ちます．</param>
        /// <return>検出された輪郭．各輪郭は，点のベクトルとして格納されます．</return>
#else
        /// <summary>
        /// Finds contours in a binary image.
        /// </summary>
        /// <param name="image">Source, an 8-bit single-channel image. Non-zero pixels are treated as 1’s. 
        /// Zero pixels remain 0’s, so the image is treated as binary.
        /// The function modifies the image while extracting the contours.</param> 
        /// <param name="mode">Contour retrieval mode</param>
        /// <param name="method">Contour approximation method</param>
        /// <param name="offset"> Optional offset by which every contour point is shifted. 
        /// This is useful if the contours are extracted from the image ROI and then they should be analyzed in the whole image context.</param>
        /// <returns>Detected contours. Each contour is stored as a vector of points.</returns>
#endif
        public static Point[][] FindContoursAsArray(InputArray image,
            RetrievalModes mode, ContourApproximationModes method, Point? offset = null)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            var offset0 = offset.GetValueOrDefault(new Point());
            NativeMethods.HandleException(
                NativeMethods.imgproc_findContours2_vector(image.CvPtr, out var contoursPtr, (int) mode, (int) method, offset0));
            GC.KeepAlive(image);

            using var contoursVec = new VectorOfVectorPoint(contoursPtr);
            return contoursVec.ToArray();
        }

#if LANG_JP
        /// <summary>
        /// 2値画像中の輪郭を検出します．
        /// </summary>
        /// <param name="image">入力画像，8ビット，シングルチャンネル．0以外のピクセルは 1として，0のピクセルは0のまま扱われます．
        /// また，この関数は，輪郭抽出処理中に入力画像 image の中身を書き換えます．</param>
        /// <param name="mode">輪郭抽出モード</param>
        /// <param name="method">輪郭の近似手法</param>
        /// <param name="offset">オプションのオフセット．各輪郭点はこの値の分だけシフトします．これは，ROIの中で抽出された輪郭を，画像全体に対して位置づけて解析する場合に役立ちます．</param>
        /// <return>検出された輪郭．各輪郭は，点のベクトルとして格納されます．</return>
#else
        /// <summary>
        /// Finds contours in a binary image.
        /// </summary>
        /// <param name="image">Source, an 8-bit single-channel image. Non-zero pixels are treated as 1’s. 
        /// Zero pixels remain 0’s, so the image is treated as binary.
        /// The function modifies the image while extracting the contours.</param> 
        /// <param name="mode">Contour retrieval mode</param>
        /// <param name="method">Contour approximation method</param>
        /// <param name="offset"> Optional offset by which every contour point is shifted. 
        /// This is useful if the contours are extracted from the image ROI and then they should be analyzed in the whole image context.</param>
        /// <returns>Detected contours. Each contour is stored as a vector of points.</returns>
#endif
        public static Mat<Point>[] FindContoursAsMat(InputArray image,
            RetrievalModes mode, ContourApproximationModes method, Point? offset = null)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            var offset0 = offset.GetValueOrDefault(new Point());
            NativeMethods.HandleException(
                NativeMethods.imgproc_findContours2_OutputArray(image.CvPtr, out var contoursPtr, (int)mode, (int)method, offset0));
            GC.KeepAlive(image);

            using var contoursVec = new VectorOfMat(contoursPtr);
            return contoursVec.ToArray<Mat<Point>>();
        }

        /// <summary>
        /// Approximates contour or a curve using Douglas-Peucker algorithm
        /// </summary>
        /// <param name="curve">The polygon or curve to approximate. 
        /// Must be 1 x N or N x 1 matrix of type CV_32SC2 or CV_32FC2.</param>
        /// <param name="approxCurve">The result of the approximation; 
        /// The type should match the type of the input curve</param>
        /// <param name="epsilon">Specifies the approximation accuracy. 
        /// This is the maximum distance between the original curve and its approximation.</param>
        /// <param name="closed">The result of the approximation; 
        /// The type should match the type of the input curve</param>
        public static void ApproxPolyDP(InputArray curve, OutputArray approxCurve, double epsilon, bool closed)
        {
            if (curve == null)
                throw new ArgumentNullException(nameof(curve));
            if (approxCurve == null)
                throw new ArgumentNullException(nameof(approxCurve));
            curve.ThrowIfDisposed();
            approxCurve.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_approxPolyDP_InputArray(curve.CvPtr, approxCurve.CvPtr, epsilon, closed ? 1 : 0));

            GC.KeepAlive(curve);
            GC.KeepAlive(approxCurve);
            approxCurve.Fix();
        }

        /// <summary>
        /// Approximates contour or a curve using Douglas-Peucker algorithm
        /// </summary>
        /// <param name="curve">The polygon or curve to approximate.</param>
        /// <param name="epsilon">Specifies the approximation accuracy. 
        /// This is the maximum distance between the original curve and its approximation.</param>
        /// <param name="closed">The result of the approximation; 
        /// The type should match the type of the input curve</param>
        /// <returns>The result of the approximation; 
        /// The type should match the type of the input curve</returns>
        public static Point[] ApproxPolyDP(IEnumerable<Point> curve, double epsilon, bool closed)
        {
            if(curve == null)
                throw new ArgumentNullException(nameof(curve));
            var curveArray = curve.ToArray();
            NativeMethods.HandleException(
                NativeMethods.imgproc_approxPolyDP_Point(
                    curveArray, curveArray.Length, out var approxCurvePtr, epsilon, closed ? 1 : 0));
            using var approxCurveVec = new VectorOfPoint(approxCurvePtr);
            return approxCurveVec.ToArray();
        }

        /// <summary>
        /// Approximates contour or a curve using Douglas-Peucker algorithm
        /// </summary>
        /// <param name="curve">The polygon or curve to approximate.</param>
        /// <param name="epsilon">Specifies the approximation accuracy. 
        /// This is the maximum distance between the original curve and its approximation.</param>
        /// <param name="closed">If true, the approximated curve is closed 
        /// (i.e. its first and last vertices are connected), otherwise it’s not</param>
        /// <returns>The result of the approximation; 
        /// The type should match the type of the input curve</returns>
        public static Point2f[] ApproxPolyDP(IEnumerable<Point2f> curve, double epsilon, bool closed)
        {
            if (curve == null)
                throw new ArgumentNullException(nameof(curve));
            var curveArray = curve.ToArray();
            NativeMethods.HandleException(
                NativeMethods.imgproc_approxPolyDP_Point2f(
                    curveArray, curveArray.Length, out var approxCurvePtr, epsilon, closed ? 1 : 0));
            using var approxCurveVec = new VectorOfPoint2f(approxCurvePtr);
            return approxCurveVec.ToArray();
        }

        /// <summary>
        /// Calculates a contour perimeter or a curve length.
        /// </summary>
        /// <param name="curve">The input vector of 2D points, represented by CV_32SC2 or CV_32FC2 matrix.</param>
        /// <param name="closed">Indicates, whether the curve is closed or not.</param>
        /// <returns></returns>
        public static double ArcLength(InputArray curve, bool closed)
        {
            if (curve == null)
                throw new ArgumentNullException(nameof(curve));
            curve.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_arcLength_InputArray(curve.CvPtr, closed ? 1 : 0, out var ret));
            GC.KeepAlive(curve);
            return ret;
        }

        /// <summary>
        /// Calculates a contour perimeter or a curve length.
        /// </summary>
        /// <param name="curve">The input vector of 2D points.</param>
        /// <param name="closed">Indicates, whether the curve is closed or not.</param>
        /// <returns></returns>
        public static double ArcLength(IEnumerable<Point> curve, bool closed)
        {
            if (curve == null)
                throw new ArgumentNullException(nameof(curve));
            var curveArray = curve.ToArray();
            
            NativeMethods.HandleException(
                NativeMethods.imgproc_arcLength_Point(curveArray, curveArray.Length, closed ? 1 : 0, out var ret));
            return ret;
        }

        /// <summary>
        /// Calculates a contour perimeter or a curve length.
        /// </summary>
        /// <param name="curve">The input vector of 2D points.</param>
        /// <param name="closed">Indicates, whether the curve is closed or not.</param>
        /// <returns></returns>
        public static double ArcLength(IEnumerable<Point2f> curve, bool closed)
        {
            if (curve == null)
                throw new ArgumentNullException(nameof(curve));
            var curveArray = curve.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_arcLength_Point2f(curveArray, curveArray.Length, closed ? 1 : 0, out var ret));
            return ret;
        }

        /// <summary>
        /// Calculates the up-right bounding rectangle of a point set.
        /// </summary>
        /// <param name="curve">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
        /// <returns>Minimal up-right bounding rectangle for the specified point set.</returns>
        public static Rect BoundingRect(InputArray curve)
        {
            if (curve == null)
                throw new ArgumentNullException(nameof(curve));
            curve.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_boundingRect_InputArray(curve.CvPtr, out var ret));
            GC.KeepAlive(curve);
            return ret;
        }

        /// <summary>
        /// Calculates the up-right bounding rectangle of a point set.
        /// </summary>
        /// <param name="curve">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
        /// <returns>Minimal up-right bounding rectangle for the specified point set.</returns>
        public static Rect BoundingRect(IEnumerable<Point> curve)
        {
            if (curve == null)
                throw new ArgumentNullException(nameof(curve));
            var curveArray = curve.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_boundingRect_Point(curveArray, curveArray.Length, out var ret));
            return ret;
        }

        /// <summary>
        /// Calculates the up-right bounding rectangle of a point set.
        /// </summary>
        /// <param name="curve">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
        /// <returns>Minimal up-right bounding rectangle for the specified point set.</returns>
        public static Rect BoundingRect(IEnumerable<Point2f> curve)
        {
            if (curve == null)
                throw new ArgumentNullException(nameof(curve));
            var curveArray = curve.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_boundingRect_Point2f(curveArray, curveArray.Length, out var ret));
            return ret;
        }
        
        /// <summary>
        /// Calculates the contour area
        /// </summary>
        /// <param name="contour">The contour vertices, represented by CV_32SC2 or CV_32FC2 matrix</param>
        /// <param name="oriented"></param>
        /// <returns></returns>
        public static double ContourArea(InputArray contour, bool oriented = false)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            contour.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_contourArea_InputArray(contour.CvPtr, oriented ? 1 : 0, out var ret));
            GC.KeepAlive(contour);
            return ret;
        }

        /// <summary>
        /// Calculates the contour area
        /// </summary>
        /// <param name="contour">The contour vertices, represented by CV_32SC2 or CV_32FC2 matrix</param>
        /// <param name="oriented"></param>
        /// <returns></returns>
        public static double ContourArea(IEnumerable<Point> contour, bool oriented = false)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            var contourArray = contour.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_contourArea_Point(contourArray, contourArray.Length, oriented ? 1 : 0, out var ret));
            return ret;
        }

        /// <summary>
        /// Calculates the contour area
        /// </summary>
        /// <param name="contour">The contour vertices, represented by CV_32SC2 or CV_32FC2 matrix</param>
        /// <param name="oriented"></param>
        /// <returns></returns>
        public static double ContourArea(IEnumerable<Point2f> contour, bool oriented = false)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            var contourArray = contour.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_contourArea_Point2f(contourArray, contourArray.Length, oriented ? 1 : 0, out var ret));
            return ret;
        }
        
        /// <summary>
        /// Finds the minimum area rotated rectangle enclosing a 2D point set.
        /// </summary>
        /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
        /// <returns></returns>
        public static RotatedRect MinAreaRect(InputArray points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            points.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_minAreaRect_InputArray(points.CvPtr, out var ret));
            GC.KeepAlive(points);
            return ret;
        }

        /// <summary>
        /// Finds the minimum area rotated rectangle enclosing a 2D point set.
        /// </summary>
        /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
        /// <returns></returns>
        public static RotatedRect MinAreaRect(IEnumerable<Point> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_minAreaRect_Point(pointsArray, pointsArray.Length, out var ret));
            return ret;
        }

        /// <summary>
        /// Finds the minimum area rotated rectangle enclosing a 2D point set.
        /// </summary>
        /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
        /// <returns></returns>
        public static RotatedRect MinAreaRect(IEnumerable<Point2f> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_minAreaRect_Point2f(pointsArray, pointsArray.Length, out var ret));
            return ret;
        }

        /// <summary>
        /// Finds the four vertices of a rotated rect. Useful to draw the rotated rectangle.
        ///
        /// The function finds the four vertices of a rotated rectangle.This function is useful to draw the 
        /// rectangle.In C++, instead of using this function, you can directly use RotatedRect::points method. Please
        /// visit the @ref tutorial_bounding_rotated_ellipses "tutorial on Creating Bounding rotated boxes and ellipses for contours" for more information.
        /// </summary>
        /// <param name="box">The input rotated rectangle. It may be the output of</param>
        /// <param name="points">The output array of four vertices of rectangles.</param>
        /// <returns></returns>
        public static void BoxPoints(RotatedRect box, OutputArray points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            points.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_boxPoints_OutputArray(box, points.CvPtr));
            points.Fix();
        }

        /// <summary>
        /// Finds the four vertices of a rotated rect. Useful to draw the rotated rectangle.
        ///
        /// The function finds the four vertices of a rotated rectangle.This function is useful to draw the 
        /// rectangle.In C++, instead of using this function, you can directly use RotatedRect::points method. Please
        /// visit the @ref tutorial_bounding_rotated_ellipses "tutorial on Creating Bounding rotated boxes and ellipses for contours" for more information.
        /// </summary>
        /// <param name="box">The input rotated rectangle. It may be the output of</param>
        /// <returns>The output array of four vertices of rectangles.</returns>
        public static Point2f[] BoxPoints(RotatedRect box)
        {
            var points = new Point2f[4];
            NativeMethods.HandleException(
                NativeMethods.imgproc_boxPoints_Point2f(box, points));
            return points;
        }

        /// <summary>
        /// Finds the minimum area circle enclosing a 2D point set.
        /// </summary>
        /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
        /// <param name="center">The output center of the circle</param>
        /// <param name="radius">The output radius of the circle</param>
        public static void MinEnclosingCircle(InputArray points, out Point2f center, out float radius)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            points.ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_minEnclosingCircle_InputArray(points.CvPtr, out center, out radius));
            GC.KeepAlive(points);
        }

        /// <summary>
        /// Finds the minimum area circle enclosing a 2D point set.
        /// </summary>
        /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
        /// <param name="center">The output center of the circle</param>
        /// <param name="radius">The output radius of the circle</param>
        public static void MinEnclosingCircle(IEnumerable<Point> points, out Point2f center, out float radius)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();
            NativeMethods.HandleException(
                NativeMethods.imgproc_minEnclosingCircle_Point(pointsArray, pointsArray.Length, out center, out radius));
        }

        /// <summary>
        /// Finds the minimum area circle enclosing a 2D point set.
        /// </summary>
        /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix.</param>
        /// <param name="center">The output center of the circle</param>
        /// <param name="radius">The output radius of the circle</param>
        public static void MinEnclosingCircle(IEnumerable<Point2f> points, out Point2f center, out float radius)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();
            NativeMethods.HandleException(
                NativeMethods.imgproc_minEnclosingCircle_Point2f(pointsArray, pointsArray.Length, out center, out radius));
        }

        /// <summary>
        /// Finds a triangle of minimum area enclosing a 2D point set and returns its area.
        /// </summary>
        /// <param name="points">Input vector of 2D points with depth CV_32S or CV_32F, stored in std::vector or Mat</param>
        /// <param name="triangle">Output vector of three 2D points defining the vertices of the triangle. The depth</param>
        /// <returns>Triangle area</returns>
        public static double MinEnclosingTriangle(InputArray points, OutputArray triangle)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            if (triangle == null)
                throw new ArgumentNullException(nameof(triangle));
            points.ThrowIfDisposed();
            triangle.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_minEnclosingTriangle_InputOutputArray(points.CvPtr, triangle.CvPtr, out var ret));

            GC.KeepAlive(points);
            triangle.Fix();
            return ret;
        }

        /// <summary>
        /// Finds a triangle of minimum area enclosing a 2D point set and returns its area.
        /// </summary>
        /// <param name="points">Input vector of 2D points with depth CV_32S or CV_32F, stored in std::vector or Mat</param>
        /// <param name="triangle">Output vector of three 2D points defining the vertices of the triangle. The depth</param>
        /// <returns>Triangle area</returns>
        public static double MinEnclosingTriangle(IEnumerable<Point> points, out Point2f[] triangle)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            if (points == null)
                throw new ArgumentNullException(nameof(points));

            var pointsArray = points.ToArray();
            using var triangleVec = new VectorOfPoint2f();
            NativeMethods.HandleException(
                NativeMethods.imgproc_minEnclosingTriangle_Point(
                    pointsArray, pointsArray.Length, triangleVec.CvPtr, out var ret));

            GC.KeepAlive(pointsArray);
            triangle = triangleVec.ToArray();
            return ret;
        }

        /// <summary>
        /// Finds a triangle of minimum area enclosing a 2D point set and returns its area.
        /// </summary>
        /// <param name="points">Input vector of 2D points with depth CV_32S or CV_32F, stored in std::vector or Mat</param>
        /// <param name="triangle">Output vector of three 2D points defining the vertices of the triangle. The depth</param>
        /// <returns>Triangle area</returns>
        public static double MinEnclosingTriangle(IEnumerable<Point2f> points, out Point2f[] triangle)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            if (points == null)
                throw new ArgumentNullException(nameof(points));

            var pointsArray = points.ToArray();
            using var triangleVec = new VectorOfPoint2f();
            NativeMethods.HandleException(
                NativeMethods.imgproc_minEnclosingTriangle_Point2f(
                    pointsArray, pointsArray.Length, triangleVec.CvPtr, out var ret));

            GC.KeepAlive(pointsArray);
            triangle = triangleVec.ToArray();
            return ret;
        }

        /// <summary>
        /// Compares two shapes.
        /// </summary>
        /// <param name="contour1">First contour or grayscale image.</param>
        /// <param name="contour2">Second contour or grayscale image.</param>
        /// <param name="method">Comparison method</param>
        /// <param name="parameter">Method-specific parameter (not supported now)</param>
        /// <returns></returns>
        public static double MatchShapes(InputArray contour1, InputArray contour2, ShapeMatchModes method, double parameter = 0)
        {
            if (contour1 == null)
                throw new ArgumentNullException(nameof(contour1));
            if (contour2 == null)
                throw new ArgumentNullException(nameof(contour2));

            NativeMethods.HandleException(
                NativeMethods.imgproc_matchShapes_InputArray(contour1.CvPtr, contour2.CvPtr, (int)method, parameter, out var ret));

            GC.KeepAlive(contour1);
            GC.KeepAlive(contour2);
            return ret;
        }

        /// <summary>
        /// Compares two shapes.
        /// </summary>
        /// <param name="contour1">First contour or grayscale image.</param>
        /// <param name="contour2">Second contour or grayscale image.</param>
        /// <param name="method">Comparison method</param>
        /// <param name="parameter">Method-specific parameter (not supported now)</param>
        /// <returns></returns>
        public static double MatchShapes(IEnumerable<Point> contour1, IEnumerable<Point> contour2,
            ShapeMatchModes method, double parameter = 0)
        {
            if (contour1 == null)
                throw new ArgumentNullException(nameof(contour1));
            if (contour2 == null)
                throw new ArgumentNullException(nameof(contour2));
            var contour1Array = contour1.ToArray();
            var contour2Array = contour2.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_matchShapes_Point(
                    contour1Array, contour1Array.Length,
                    contour2Array, contour2Array.Length, 
                    (int) method, parameter, out var ret));
            return ret;
        }

        /// <summary>
        /// Computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix</param>
        /// <param name="hull">The output convex hull. It is either a vector of points that form the 
        /// hull (must have the same type as the input points), or a vector of 0-based point 
        /// indices of the hull points in the original array (since the set of convex hull 
        /// points is a subset of the original point set).</param>
        /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
        /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
        /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
        /// and y axis is oriented downwards.</param>
        /// <param name="returnPoints"></param>
        public static void ConvexHull(InputArray points, OutputArray hull, bool clockwise = false, bool returnPoints = true)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            if (hull == null)
                throw new ArgumentNullException(nameof(hull));
            points.ThrowIfDisposed();
            hull.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_convexHull_InputArray(points.CvPtr, hull.CvPtr, clockwise ? 1 : 0, returnPoints ? 1 : 0));

            GC.KeepAlive(points);
            GC.KeepAlive(hull);
            hull.Fix();
        }

        /// <summary>
        /// Computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix</param>
        /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
        /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
        /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
        /// and y axis is oriented downwards.</param>
        /// <returns>The output convex hull. It is a vector of points that form 
        /// the hull (must have the same type as the input points).</returns>
        public static Point[] ConvexHull(IEnumerable<Point> points, bool clockwise = false)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();

            using var hullVec = new VectorOfPoint();
            NativeMethods.HandleException(
                NativeMethods.imgproc_convexHull_Point_ReturnsPoints(
                    pointsArray, pointsArray.Length, hullVec.CvPtr, clockwise ? 1 : 0));

            return hullVec.ToArray();
        }

        /// <summary>
        /// Computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix</param>
        /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
        /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
        /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
        /// and y axis is oriented downwards.</param>
        /// <returns>The output convex hull. It is a vector of points that form 
        /// the hull (must have the same type as the input points).</returns>
        public static Point2f[] ConvexHull(IEnumerable<Point2f> points, bool clockwise = false)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();

            using var hullVec = new VectorOfPoint2f();
            NativeMethods.HandleException(
                NativeMethods.imgproc_convexHull_Point2f_ReturnsPoints(
                    pointsArray, pointsArray.Length, hullVec.CvPtr, clockwise ? 1 : 0));
            return hullVec.ToArray();
        }

        /// <summary>
        /// Computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix</param>
        /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
        /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
        /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
        /// and y axis is oriented downwards.</param>
        /// <returns>The output convex hull. It is a vector of 0-based point indices of the 
        /// hull points in the original array (since the set of convex hull points is a subset of the original point set).</returns>
        public static int[] ConvexHullIndices(IEnumerable<Point> points, bool clockwise = false)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();

            using var hullVec = new VectorOfInt32();
            NativeMethods.HandleException(
                NativeMethods.imgproc_convexHull_Point_ReturnsIndices(
                    pointsArray, pointsArray.Length, hullVec.CvPtr, clockwise ? 1 : 0));
            return hullVec.ToArray();
        }

        /// <summary>
        /// Computes convex hull for a set of 2D points.
        /// </summary>
        /// <param name="points">The input 2D point set, represented by CV_32SC2 or CV_32FC2 matrix</param>
        /// <param name="clockwise">If true, the output convex hull will be oriented clockwise, 
        /// otherwise it will be oriented counter-clockwise. Here, the usual screen coordinate 
        /// system is assumed - the origin is at the top-left corner, x axis is oriented to the right, 
        /// and y axis is oriented downwards.</param>
        /// <returns>The output convex hull. It is a vector of 0-based point indices of the 
        /// hull points in the original array (since the set of convex hull points is a subset of the original point set).</returns>
        public static int[] ConvexHullIndices(IEnumerable<Point2f> points, bool clockwise = false)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();

            using var hullVec = new VectorOfInt32();
            NativeMethods.HandleException(
                NativeMethods.imgproc_convexHull_Point2f_ReturnsIndices(
                    pointsArray, pointsArray.Length, hullVec.CvPtr, clockwise ? 1 : 0));
            return hullVec.ToArray();
        }

        /// <summary>
        /// Computes the contour convexity defects
        /// </summary>
        /// <param name="contour">Input contour.</param>
        /// <param name="convexHull">Convex hull obtained using convexHull() that 
        /// should contain indices of the contour points that make the hull.</param>
        /// <param name="convexityDefects">
        /// The output vector of convexity defects. 
        /// Each convexity defect is represented as 4-element integer vector 
        /// (a.k.a. cv::Vec4i): (start_index, end_index, farthest_pt_index, fixpt_depth), 
        /// where indices are 0-based indices in the original contour of the convexity defect beginning, 
        /// end and the farthest point, and fixpt_depth is fixed-point approximation 
        /// (with 8 fractional bits) of the distance between the farthest contour point and the hull. 
        /// That is, to get the floating-point value of the depth will be fixpt_depth/256.0.
        /// </param>
        public static void ConvexityDefects(InputArray contour, InputArray convexHull, OutputArray convexityDefects)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            if (convexHull == null)
                throw new ArgumentNullException(nameof(convexHull));
            if (convexityDefects == null)
                throw new ArgumentNullException(nameof(convexityDefects));
            contour.ThrowIfDisposed();
            convexHull.ThrowIfDisposed();
            convexityDefects.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_convexityDefects_InputArray(contour.CvPtr, convexHull.CvPtr, convexityDefects.CvPtr));

            GC.KeepAlive(contour);
            GC.KeepAlive(convexHull);
            GC.KeepAlive(convexityDefects);
            convexityDefects.Fix();
        }

        /// <summary>
        /// Computes the contour convexity defects
        /// </summary>
        /// <param name="contour">Input contour.</param>
        /// <param name="convexHull">Convex hull obtained using convexHull() that 
        /// should contain indices of the contour points that make the hull.</param>
        /// <returns>The output vector of convexity defects. 
        /// Each convexity defect is represented as 4-element integer vector 
        /// (a.k.a. cv::Vec4i): (start_index, end_index, farthest_pt_index, fixpt_depth), 
        /// where indices are 0-based indices in the original contour of the convexity defect beginning, 
        /// end and the farthest point, and fixpt_depth is fixed-point approximation 
        /// (with 8 fractional bits) of the distance between the farthest contour point and the hull. 
        /// That is, to get the floating-point value of the depth will be fixpt_depth/256.0. </returns>
        public static Vec4i[] ConvexityDefects(IEnumerable<Point> contour, IEnumerable<int> convexHull)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            if (convexHull == null)
                throw new ArgumentNullException(nameof(convexHull));

            var contourArray = contour.ToArray();
            var convexHullArray = convexHull.ToArray();
            using var convexityDefectsVec = new VectorOfVec4i();
            NativeMethods.HandleException(
                NativeMethods.imgproc_convexityDefects_Point(
                    contourArray, contourArray.Length,
                    convexHullArray, convexHullArray.Length, convexityDefectsVec.CvPtr));

            return convexityDefectsVec.ToArray();
        }

        /// <summary>
        /// Computes the contour convexity defects
        /// </summary>
        /// <param name="contour">Input contour.</param>
        /// <param name="convexHull">Convex hull obtained using convexHull() that 
        /// should contain indices of the contour points that make the hull.</param>
        /// <returns>The output vector of convexity defects. 
        /// Each convexity defect is represented as 4-element integer vector 
        /// (a.k.a. cv::Vec4i): (start_index, end_index, farthest_pt_index, fixpt_depth), 
        /// where indices are 0-based indices in the original contour of the convexity defect beginning, 
        /// end and the farthest point, and fixpt_depth is fixed-point approximation 
        /// (with 8 fractional bits) of the distance between the farthest contour point and the hull. 
        /// That is, to get the floating-point value of the depth will be fixpt_depth/256.0. </returns>
        public static Vec4i[] ConvexityDefects(IEnumerable<Point2f> contour, IEnumerable<int> convexHull)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            if (convexHull == null)
                throw new ArgumentNullException(nameof(convexHull));

            var contourArray = contour.ToArray();
            var convexHullArray = convexHull.ToArray();
            using var convexityDefectsVec = new VectorOfVec4i();
            NativeMethods.HandleException(
                NativeMethods.imgproc_convexityDefects_Point2f(
                    contourArray, contourArray.Length,
                    convexHullArray, convexHullArray.Length, convexityDefectsVec.CvPtr));
            return convexityDefectsVec.ToArray();
        }

        /// <summary>
        /// returns true if the contour is convex. 
        /// Does not support contours with self-intersection
        /// </summary>
        /// <param name="contour">Input vector of 2D points</param>
        /// <returns></returns>
        public static bool IsContourConvex(InputArray contour)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            contour.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_isContourConvex_InputArray(contour.CvPtr, out var ret));

            GC.KeepAlive(contour);
            return ret != 0;
        }

        /// <summary>
        /// returns true if the contour is convex. 
        /// Does not support contours with self-intersection
        /// </summary>
        /// <param name="contour">Input vector of 2D points</param>
        /// <returns></returns>
        public static bool IsContourConvex(IEnumerable<Point> contour)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            var contourArray = contour.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_isContourConvex_Point(contourArray, contourArray.Length, out var ret));
            return ret != 0;
        }

        /// <summary>
        /// returns true if the contour is convex. D
        /// oes not support contours with self-intersection
        /// </summary>
        /// <param name="contour">Input vector of 2D points</param>
        /// <returns></returns>
        public static bool IsContourConvex(IEnumerable<Point2f> contour)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            var contourArray = contour.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_isContourConvex_Point2f(contourArray, contourArray.Length, out var ret));
            return ret != 0;
        }

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
                throw new ArgumentNullException(nameof(p1));
            if (p2 == null)
                throw new ArgumentNullException(nameof(p2));
            if (p12 == null)
                throw new ArgumentNullException(nameof(p12));
            p1.ThrowIfDisposed();
            p2.ThrowIfDisposed();
            p12.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_intersectConvexConvex_InputArray(
                    p1.CvPtr, p2.CvPtr, p12.CvPtr, handleNested ? 1 : 0, out var ret));

            GC.KeepAlive(p1);
            GC.KeepAlive(p2);
            GC.KeepAlive(p12);
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
                throw new ArgumentNullException(nameof(p1));
            if (p2 == null)
                throw new ArgumentNullException(nameof(p2));
            var p1Array = p1.ToArray();
            var p2Array = p2.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_intersectConvexConvex_Point(
                    p1Array, p1Array.Length, p2Array, p2Array.Length, out var p12Ptr, handleNested ? 1 : 0, out var ret));

            using (var p12Vec = new VectorOfPoint(p12Ptr))
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
                throw new ArgumentNullException(nameof(p1));
            if (p2 == null)
                throw new ArgumentNullException(nameof(p2));
            var p1Array = p1.ToArray();
            var p2Array = p2.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_intersectConvexConvex_Point2f(
                    p1Array, p1Array.Length, p2Array, p2Array.Length,
                    out var p12Ptr, handleNested ? 1 : 0, out var ret));

            using (var p12Vec = new VectorOfPoint2f(p12Ptr))
            {
                p12 = p12Vec.ToArray();
            }

            return ret;
        }

        /// <summary>
        /// Fits ellipse to the set of 2D points.
        /// </summary>
        /// <param name="points">Input 2D point set</param>
        /// <returns></returns>
        public static RotatedRect FitEllipse(InputArray points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            points.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_fitEllipse_InputArray(points.CvPtr, out var ret));

            GC.KeepAlive(points);
            return ret;
        }

        /// <summary>
        /// Fits ellipse to the set of 2D points.
        /// </summary>
        /// <param name="points">Input 2D point set</param>
        /// <returns></returns>
        public static RotatedRect FitEllipse(IEnumerable<Point> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_fitEllipse_Point(pointsArray, pointsArray.Length, out var ret));
            return ret;
        }

        /// <summary>
        /// Fits ellipse to the set of 2D points.
        /// </summary>
        /// <param name="points">Input 2D point set</param>
        /// <returns></returns>
        public static RotatedRect FitEllipse(IEnumerable<Point2f> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_fitEllipse_Point2f(pointsArray, pointsArray.Length, out var ret));
            return ret;
        }

        /// <summary>
        /// Fits an ellipse around a set of 2D points.
        /// 
        /// The function calculates the ellipse that fits a set of 2D points.
        /// It returns the rotated rectangle in which the ellipse is inscribed.
        /// The Approximate Mean Square(AMS) proposed by @cite Taubin1991 is used.
        /// </summary>
        /// <param name="points">Input 2D point set</param>
        /// <returns></returns>
        public static RotatedRect FitEllipseAMS(InputArray points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            points.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_fitEllipseAMS_InputArray(points.CvPtr, out var ret));

            GC.KeepAlive(points);
            return ret;
        }

        /// <summary>
        /// Fits an ellipse around a set of 2D points.
        /// 
        /// The function calculates the ellipse that fits a set of 2D points.
        /// It returns the rotated rectangle in which the ellipse is inscribed.
        /// The Approximate Mean Square(AMS) proposed by @cite Taubin1991 is used.
        /// </summary>
        /// <param name="points">Input 2D point set</param>
        /// <returns></returns>
        public static RotatedRect FitEllipseAMS(IEnumerable<Point> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_fitEllipseAMS_Point(pointsArray, pointsArray.Length, out var ret));
            return ret;
        }

        /// <summary>
        /// Fits an ellipse around a set of 2D points.
        /// 
        /// The function calculates the ellipse that fits a set of 2D points.
        /// It returns the rotated rectangle in which the ellipse is inscribed.
        /// The Approximate Mean Square(AMS) proposed by @cite Taubin1991 is used.
        /// </summary>
        /// <param name="points">Input 2D point set</param>
        /// <returns></returns>
        public static RotatedRect FitEllipseAMS(IEnumerable<Point2f> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_fitEllipseAMS_Point2f(pointsArray, pointsArray.Length, out var ret));
            return ret;
        }

        /// <summary>
        /// Fits an ellipse around a set of 2D points.
        ///
        /// The function calculates the ellipse that fits a set of 2D points.
        /// It returns the rotated rectangle in which the ellipse is inscribed.
        /// The Direct least square(Direct) method by @cite Fitzgibbon1999 is used.
        /// </summary>
        /// <param name="points">Input 2D point set</param>
        /// <returns></returns>
        public static RotatedRect FitEllipseDirect(InputArray points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            points.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_fitEllipseDirect_InputArray(points.CvPtr, out var ret));

            GC.KeepAlive(points);
            return ret;
        }

        /// <summary>
        /// Fits an ellipse around a set of 2D points.
        ///
        /// The function calculates the ellipse that fits a set of 2D points.
        /// It returns the rotated rectangle in which the ellipse is inscribed.
        /// The Direct least square(Direct) method by @cite Fitzgibbon1999 is used.
        /// </summary>
        /// <param name="points">Input 2D point set</param>
        /// <returns></returns>
        public static RotatedRect FitEllipseDirect(IEnumerable<Point> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_fitEllipseDirect_Point(pointsArray, pointsArray.Length, out var ret));
            return ret;
        }

        /// <summary>
        /// Fits an ellipse around a set of 2D points.
        ///
        /// The function calculates the ellipse that fits a set of 2D points.
        /// It returns the rotated rectangle in which the ellipse is inscribed.
        /// The Direct least square(Direct) method by @cite Fitzgibbon1999 is used.
        /// </summary>
        /// <param name="points">Input 2D point set</param>
        /// <returns></returns>
        public static RotatedRect FitEllipseDirect(IEnumerable<Point2f> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_fitEllipseDirect_Point2f(pointsArray, pointsArray.Length, out var ret));
            return ret;
        }
        
        /// <summary>
        /// Fits line to the set of 2D points using M-estimator algorithm
        /// </summary>
        /// <param name="points">Input vector of 2D or 3D points</param>
        /// <param name="line">Output line parameters. 
        /// In case of 2D fitting, it should be a vector of 4 elements 
        /// (like Vec4f) - (vx, vy, x0, y0), where (vx, vy) is a normalized vector 
        /// collinear to the line and (x0, y0) is a point on the line. 
        /// In case of 3D fitting, it should be a vector of 6 elements 
        /// (like Vec6f) - (vx, vy, vz, x0, y0, z0), where (vx, vy, vz) is a 
        /// normalized vector collinear to the line and (x0, y0, z0) is a point on the line.</param>
        /// <param name="distType">Distance used by the M-estimator</param>
        /// <param name="param">Numerical parameter ( C ) for some types of distances. 
        /// If it is 0, an optimal value is chosen.</param>
        /// <param name="reps">Sufficient accuracy for the radius 
        /// (distance between the coordinate origin and the line).</param>
        /// <param name="aeps">Sufficient accuracy for the angle. 
        /// 0.01 would be a good default value for reps and aeps.</param>
        public static void FitLine(InputArray points, OutputArray line, DistanceTypes distType,
            double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            if (line == null)
                throw new ArgumentNullException(nameof(line));
            points.ThrowIfDisposed();
            line.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_fitLine_InputArray(
                    points.CvPtr, line.CvPtr, (int) distType, param, reps, aeps));

            GC.KeepAlive(points);
            GC.KeepAlive(line);
            line.Fix();
        }

        /// <summary>
        /// Fits line to the set of 2D points using M-estimator algorithm
        /// </summary>
        /// <param name="points">Input vector of 2D or 3D points</param>
        /// <param name="distType">Distance used by the M-estimator</param>
        /// <param name="param">Numerical parameter ( C ) for some types of distances. 
        /// If it is 0, an optimal value is chosen.</param>
        /// <param name="reps">Sufficient accuracy for the radius 
        /// (distance between the coordinate origin and the line).</param>
        /// <param name="aeps">Sufficient accuracy for the angle. 
        /// 0.01 would be a good default value for reps and aeps.</param>
        /// <returns>Output line parameters.</returns>
        public static Line2D FitLine(IEnumerable<Point> points, DistanceTypes distType,
            double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();
            var line = new float[4];
            NativeMethods.HandleException(
                NativeMethods.imgproc_fitLine_Point(
                    pointsArray, pointsArray.Length, line, (int) distType, param, reps, aeps));
            return new Line2D(line);
        }

        /// <summary>
        /// Fits line to the set of 2D points using M-estimator algorithm
        /// </summary>
        /// <param name="points">Input vector of 2D or 3D points</param>
        /// <param name="distType">Distance used by the M-estimator</param>
        /// <param name="param">Numerical parameter ( C ) for some types of distances. 
        /// If it is 0, an optimal value is chosen.</param>
        /// <param name="reps">Sufficient accuracy for the radius 
        /// (distance between the coordinate origin and the line).</param>
        /// <param name="aeps">Sufficient accuracy for the angle. 
        /// 0.01 would be a good default value for reps and aeps.</param>
        /// <returns>Output line parameters.</returns>
        public static Line2D FitLine(IEnumerable<Point2f> points, DistanceTypes distType,
            double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();
            var line = new float[4];
            NativeMethods.HandleException(
                NativeMethods.imgproc_fitLine_Point2f(
                    pointsArray, pointsArray.Length, line, (int) distType, param, reps, aeps));
            return new Line2D(line);
        }

        /// <summary>
        /// Fits line to the set of 3D points using M-estimator algorithm
        /// </summary>
        /// <param name="points">Input vector of 2D or 3D points</param>
        /// <param name="distType">Distance used by the M-estimator</param>
        /// <param name="param">Numerical parameter ( C ) for some types of distances. 
        /// If it is 0, an optimal value is chosen.</param>
        /// <param name="reps">Sufficient accuracy for the radius 
        /// (distance between the coordinate origin and the line).</param>
        /// <param name="aeps">Sufficient accuracy for the angle. 
        /// 0.01 would be a good default value for reps and aeps.</param>
        /// <returns>Output line parameters.</returns>
        public static Line3D FitLine(IEnumerable<Point3i> points, DistanceTypes distType,
            double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();
            var line = new float[6];
            NativeMethods.HandleException(
                NativeMethods.imgproc_fitLine_Point3i(
                    pointsArray, pointsArray.Length, line, (int) distType, param, reps, aeps));
            return new Line3D(line);
        }

        /// <summary>
        /// Fits line to the set of 3D points using M-estimator algorithm
        /// </summary>
        /// <param name="points">Input vector of 2D or 3D points</param>
        /// <param name="distType">Distance used by the M-estimator</param>
        /// <param name="param">Numerical parameter ( C ) for some types of distances. 
        /// If it is 0, an optimal value is chosen.</param>
        /// <param name="reps">Sufficient accuracy for the radius 
        /// (distance between the coordinate origin and the line).</param>
        /// <param name="aeps">Sufficient accuracy for the angle. 
        /// 0.01 would be a good default value for reps and aeps.</param>
        /// <returns>Output line parameters.</returns>
        public static Line3D FitLine(IEnumerable<Point3f> points, DistanceTypes distType,
            double param, double reps, double aeps)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            var pointsArray = points.ToArray();
            var line = new float[6];
            NativeMethods.HandleException(
                NativeMethods.imgproc_fitLine_Point3f(
                    pointsArray, pointsArray.Length, line, (int) distType, param, reps, aeps));
            return new Line3D(line);
        }

        /// <summary>
        /// Checks if the point is inside the contour. Optionally computes the signed distance from the point to the contour boundary
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="pt"></param>
        /// <param name="measureDist"></param>
        /// <returns></returns>
        public static double PointPolygonTest(InputArray contour, Point2f pt, bool measureDist)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            contour.ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_pointPolygonTest_InputArray(
                    contour.CvPtr, pt, measureDist ? 1 : 0, out var ret));
            GC.KeepAlive(contour);
            return ret;
        }

        /// <summary>
        /// Checks if the point is inside the contour. Optionally computes the signed distance from the point to the contour boundary
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="pt"></param>
        /// <param name="measureDist"></param>
        /// <returns></returns>
        public static double PointPolygonTest(IEnumerable<Point> contour, Point2f pt, bool measureDist)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            var contourArray = contour.ToArray();
            NativeMethods.HandleException(
                NativeMethods.imgproc_pointPolygonTest_Point(
                    contourArray, contourArray.Length, pt, measureDist ? 1 : 0, out var ret));
            return ret;
        }

        /// <summary>
        /// Checks if the point is inside the contour. 
        /// Optionally computes the signed distance from the point to the contour boundary.
        /// </summary>
        /// <param name="contour">Input contour.</param>
        /// <param name="pt">Point tested against the contour.</param>
        /// <param name="measureDist">If true, the function estimates the signed distance 
        /// from the point to the nearest contour edge. Otherwise, the function only checks 
        /// if the point is inside a contour or not.</param>
        /// <returns>Positive (inside), negative (outside), or zero (on an edge) value.</returns>
        public static double PointPolygonTest(IEnumerable<Point2f> contour, Point2f pt, bool measureDist)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            var contourArray = contour.ToArray();
            NativeMethods.HandleException(
                NativeMethods.imgproc_pointPolygonTest_Point2f(
                    contourArray, contourArray.Length, pt, measureDist ? 1 : 0, out var ret));
            return ret;
        }

        /// <summary>
        /// Finds out if there is any intersection between two rotated rectangles.
        /// If there is then the vertices of the interesecting region are returned as well.
        /// Below are some examples of intersection configurations. 
        /// The hatched pattern indicates the intersecting region and the red 
        /// vertices are returned by the function.
        /// </summary>
        /// <param name="rect1">First rectangle</param>
        /// <param name="rect2">Second rectangle</param>
        /// <param name="intersectingRegion">
        /// The output array of the verticies of the intersecting region. 
        /// It returns at most 8 vertices.
        /// Stored as std::vector&lt;cv::Point2f&gt; or cv::Mat as Mx1 of type CV_32FC2.</param>
        /// <returns></returns>
        public static RectanglesIntersectTypes RotatedRectangleIntersection(
            RotatedRect rect1, RotatedRect rect2, OutputArray intersectingRegion)
        {
            if (intersectingRegion == null)
                throw new ArgumentNullException(nameof(intersectingRegion));
            intersectingRegion.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_rotatedRectangleIntersection_OutputArray(
                rect1, rect2, intersectingRegion.CvPtr, out var ret));

            GC.KeepAlive(intersectingRegion);
            intersectingRegion.Fix();

            return (RectanglesIntersectTypes)ret;
        }

        /// <summary>
        /// Finds out if there is any intersection between two rotated rectangles.
        /// If there is then the vertices of the interesecting region are returned as well.
        /// Below are some examples of intersection configurations. 
        /// The hatched pattern indicates the intersecting region and the red 
        /// vertices are returned by the function.
        /// </summary>
        /// <param name="rect1">First rectangle</param>
        /// <param name="rect2">Second rectangle</param>
        /// <param name="intersectingRegion">
        /// The output array of the verticies of the intersecting region. 
        /// It returns at most 8 vertices.</param>
        /// <returns></returns>
        public static RectanglesIntersectTypes RotatedRectangleIntersection(
            RotatedRect rect1, RotatedRect rect2, out Point2f[] intersectingRegion)
        {
            using var intersectingRegionVec = new VectorOfPoint2f();
            NativeMethods.HandleException(
                NativeMethods.imgproc_rotatedRectangleIntersection_vector(
                    rect1, rect2, intersectingRegionVec.CvPtr, out var ret));

            intersectingRegion = intersectingRegionVec.ToArray();
            return (RectanglesIntersectTypes) ret;
        }

        /// <summary>
        /// Applies a GNU Octave/MATLAB equivalent colormap on a given image.
        /// </summary>
        /// <param name="src">The source image, grayscale or colored of type CV_8UC1 or CV_8UC3.</param>
        /// <param name="dst">The result is the colormapped source image. Note: Mat::create is called on dst.</param>
        /// <param name="colormap">colormap The colormap to apply</param>
        public static void ApplyColorMap(InputArray src, OutputArray dst, ColormapTypes colormap)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_applyColorMap1(src.CvPtr, dst.CvPtr, (int) colormap));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }
        
        /// <summary>
        /// Applies a user colormap on a given image.
        /// </summary>
        /// <param name="src">The source image, grayscale or colored of type CV_8UC1 or CV_8UC3.</param>
        /// <param name="dst">The result is the colormapped source image. Note: Mat::create is called on dst.</param>
        /// <param name="userColor">The colormap to apply of type CV_8UC1 or CV_8UC3 and size 256</param>
        public static void ApplyColorMap(InputArray src, OutputArray dst, InputArray userColor)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (userColor == null)
                throw new ArgumentNullException(nameof(userColor));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            userColor.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_applyColorMap2(src.CvPtr, dst.CvPtr, userColor.CvPtr));

            GC.KeepAlive(src);
            dst.Fix();
            GC.KeepAlive(userColor);
        }

        #region Drawing

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
        /// <param name="thickness">線分の太さ. [既定値は1]</param>
        /// <param name="lineType">線分の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
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
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Line(InputOutputArray img, int pt1X, int pt1Y, int pt2X, int pt2Y, Scalar color,
            int thickness = 1, LineTypes lineType = LineTypes.Link8, int shift = 0)
        {
            Line(img, new Point(pt1X, pt1Y), new Point(pt2X, pt2Y), color, thickness, lineType, shift);
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
        /// <param name="lineType">線分の種類. [既定値はLineType.Link8]</param>
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
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Line(
            InputOutputArray img, Point pt1, Point pt2, Scalar color, int thickness = 1, 
            LineTypes lineType = LineTypes.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_line(img.CvPtr, pt1, pt2, color, thickness, (int) lineType, shift));

            img.Fix();
            GC.KeepAlive(img);
        }

        /// <summary>
        /// Draws a arrow segment pointing from the first point to the second one.
        /// The function arrowedLine draws an arrow between pt1 and pt2 points in the image. 
        /// See also cv::line.
        /// </summary>
        /// <param name="img">Image.</param>
        /// <param name="pt1">The point the arrow starts from.</param>
        /// <param name="pt2">The point the arrow points to.</param>
        /// <param name="color">Line color.</param>
        /// <param name="thickness">Line thickness.</param>
        /// <param name="lineType">Type of the line, see cv::LineTypes</param>
        /// <param name="shift">Number of fractional bits in the point coordinates.</param>
        /// <param name="tipLength">The length of the arrow tip in relation to the arrow length</param>
        public static void ArrowedLine(
            InputOutputArray img, 
            Point pt1, Point pt2, 
            Scalar color,
            int thickness = 1, 
            LineTypes lineType = LineTypes.Link8,
            int shift = 0, 
            double tipLength = 0.1)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_arrowedLine(
                    img.CvPtr, pt1, pt2, color, thickness, (int) lineType, shift, tipLength));

            GC.KeepAlive(img);
            img.Fix();
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
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
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
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(
            InputOutputArray img, Point pt1, Point pt2, Scalar color, int thickness = 1, 
            LineTypes lineType = LineTypes.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));

            NativeMethods.HandleException(
                NativeMethods.imgproc_rectangle_InputOutputArray_Point(
                    img.CvPtr, pt1, pt2, color, thickness, (int) lineType, shift));

            img.Fix();
            GC.KeepAlive(img);
        }
        
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle.
        /// Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(
            InputOutputArray img, Rect rect, Scalar color, int thickness = 1,
            LineTypes lineType = LineTypes.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));

            NativeMethods.HandleException(
                NativeMethods.imgproc_rectangle_InputOutputArray_Rect(
                    img.CvPtr, rect, color, thickness, (int) lineType, shift));
            img.Fix();
            GC.KeepAlive(img);
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle.
        /// Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(
            Mat img, Rect rect, Scalar color, int thickness = 1, LineTypes lineType = LineTypes.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));

            NativeMethods.HandleException(
                NativeMethods.imgproc_rectangle_Mat_Rect(img.CvPtr, rect, color, thickness, (int) lineType, shift));
            GC.KeepAlive(img);
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
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle.
        /// Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(
            Mat img, Point pt1, Point pt2, Scalar color, int thickness = 1,
            LineTypes lineType = LineTypes.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));

            NativeMethods.HandleException(
                NativeMethods.imgproc_rectangle_Mat_Point(img.CvPtr, pt1, pt2, color, thickness, (int)lineType, shift));
            GC.KeepAlive(img);
        }

#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="centerX">円の中心のx座標</param>
        /// <param name="centerY">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．[既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="lineType">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public static void Circle(InputOutputArray img, int centerX, int centerY, int radius, Scalar color,
            int thickness = 1, LineTypes lineType = LineTypes.Link8, int shift = 0)
        {
            Circle(img, new Point(centerX, centerY), radius, color, thickness, lineType, shift);
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
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
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
        /// <param name="lineType">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public static void Circle(InputOutputArray img, Point center, int radius, Scalar color,
            int thickness = 1, LineTypes lineType = LineTypes.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_circle(img.CvPtr, center, radius, color, thickness, (int) lineType, shift));
            img.Fix();
            GC.KeepAlive(img);
        }

#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描画される画像</param>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="startAngle">楕円弧の開始角度</param>
        /// <param name="endAngle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
        /// <param name="thickness">楕円弧の線の幅 [既定値は1]</param>
        /// <param name="lineType">楕円弧の線の種類 [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と軸の長さの小数点以下の桁を表すビット数 [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="startAngle">Starting angle of the elliptic arc. </param>
        /// <param name="endAngle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse arc. [By default this is 1]</param>
        /// <param name="lineType">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and axes' values. [By default this is 0]</param>
#endif
        public static void Ellipse(
            InputOutputArray img, Point center, Size axes, double angle, double startAngle, double endAngle, Scalar color,
            int thickness = 1, LineTypes lineType = LineTypes.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.imgproc_ellipse1(
                    img.CvPtr, center, axes, angle, startAngle, endAngle, color, thickness, (int) lineType, shift));

            img.Fix();
            GC.KeepAlive(img);
        }

#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描かれる画像．</param>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
        /// <param name="thickness">楕円境界線の幅．[既定値は1]</param>
        /// <param name="lineType">楕円境界線の種類．[既定値はLineType.Link8]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. [By default this is 1]</param>
        /// <param name="lineType">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
#endif
        public static void Ellipse(InputOutputArray img, RotatedRect box, Scalar color,
            int thickness = 1, LineTypes lineType = LineTypes.Link8)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_ellipse2(img.CvPtr, box, color, thickness, (int) lineType));
            img.Fix();
            GC.KeepAlive(img);
        }

        /// <summary>
        /// Draws a marker on a predefined position in an image.
        ///
        /// The function cv::drawMarker draws a marker on a given position in the image.For the moment several
        /// marker types are supported, see #MarkerTypes for more information.
        /// </summary>
        /// <param name="img">Image.</param>
        /// <param name="position">The point where the crosshair is positioned.</param>
        /// <param name="color">Line color.</param>
        /// <param name="markerType">The specific type of marker you want to use.</param>
        /// <param name="markerSize">The length of the marker axis [default = 20 pixels]</param>
        /// <param name="thickness">Line thickness.</param>
        /// <param name="lineType">Type of the line.</param>
        public static void DrawMarker(
            InputOutputArray img, Point position, Scalar color,
            MarkerTypes markerType = MarkerTypes.Cross, int markerSize = 20, int thickness = 1, LineTypes lineType = LineTypes.Link8)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_drawMarker(
                    img.CvPtr, position, color, (int)markerType, markerSize, thickness, (int)lineType));

            img.Fix();
            GC.KeepAlive(img);
        }

#if LANG_JP
        /// <summary>
        /// 塗りつぶされた凸ポリゴンを描きます．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pts">ポリゴンの頂点．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">ポリゴンの枠線の種類，</param>
        /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
#else
        /// <summary>
        /// Fills a convex polygon.
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="pts">The polygon vertices</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
#endif
        public static void FillConvexPoly(Mat img, IEnumerable<Point> pts, Scalar color,
            LineTypes lineType = LineTypes.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();

            var ptsArray = pts.ToArray();
            NativeMethods.HandleException(
                NativeMethods.imgproc_fillConvexPoly_Mat(
                    img.CvPtr, ptsArray, ptsArray.Length, color, (int) lineType, shift));
            GC.KeepAlive(img);
        }

#if LANG_JP
        /// <summary>
        /// 塗りつぶされた凸ポリゴンを描きます．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pts">ポリゴンの頂点．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">ポリゴンの枠線の種類，</param>
        /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
#else
        /// <summary>
        /// Fills a convex polygon.
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="pts">The polygon vertices</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
#endif
        public static void FillConvexPoly(InputOutputArray img, InputArray pts, Scalar color,
            LineTypes lineType = LineTypes.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (pts == null) 
                throw new ArgumentNullException(nameof(pts));
            img.ThrowIfDisposed();
            pts.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_fillConvexPoly_InputOutputArray(
                    img.CvPtr, pts.CvPtr, color, (int) lineType, shift));
            GC.KeepAlive(img);
            GC.KeepAlive(pts);
        }

#if LANG_JP
        /// <summary>
        /// 1つ，または複数のポリゴンで区切られた領域を塗りつぶします．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pts">ポリゴンの配列．各要素は，点の配列で表現されます．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">ポリゴンの枠線の種類，</param>
        /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
        /// <param name="offset"></param>
#else
        /// <summary>
        /// Fills the area bounded by one or more polygons
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="pts">Array of polygons, each represented as an array of points</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
        /// <param name="offset"></param>
#endif
        public static void FillPoly(
            Mat img, IEnumerable<IEnumerable<Point>> pts, Scalar color,
            LineTypes lineType = LineTypes.Link8, int shift = 0, Point? offset = null)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (pts == null)
                throw new ArgumentNullException(nameof(pts));

            img.ThrowIfDisposed();
            var offset0 = offset.GetValueOrDefault(new Point());

            var ptsList = new List<Point[]>();
            var nptsList = new List<int>();
            foreach (var pts1 in pts)
            {
                var pts1Arr = pts1.ToArray();
                ptsList.Add(pts1Arr);
                nptsList.Add(pts1Arr.Length);
            }
            var ptsArr = ptsList.ToArray();
            var npts = nptsList.ToArray();
            var ncontours = ptsArr.Length;
            using (var ptsPtr = new ArrayAddress2<Point>(ptsArr))
            {
                NativeMethods.HandleException(
                    NativeMethods.imgproc_fillPoly_Mat(
                        img.CvPtr, ptsPtr.GetPointer(), npts, ncontours, color, (int) lineType, shift, offset0));
            }
            GC.KeepAlive(img);
        }

#if LANG_JP
        /// <summary>
        /// 1つ，または複数のポリゴンで区切られた領域を塗りつぶします．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pts">ポリゴンの配列．各要素は，点の配列で表現されます．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">ポリゴンの枠線の種類，</param>
        /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
        /// <param name="offset"></param>
#else
        /// <summary>
        /// Fills the area bounded by one or more polygons
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="pts">Array of polygons, each represented as an array of points</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
        /// <param name="offset"></param>
#endif
        public static void FillPoly(
            InputOutputArray img, InputArray pts, Scalar color,
            LineTypes lineType = LineTypes.Link8, int shift = 0, Point? offset = null)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (pts == null) 
                throw new ArgumentNullException(nameof(pts));
            img.ThrowIfDisposed();
            pts.ThrowIfDisposed();
            var offset0 = offset.GetValueOrDefault(new Point());

            NativeMethods.HandleException(
                NativeMethods.imgproc_fillPoly_InputOutputArray(
                    img.CvPtr, pts.CvPtr, color, (int) lineType, shift, offset0));
            GC.KeepAlive(img);
            GC.KeepAlive(pts);
            img.Fix();
        }

        /// <summary>
        /// draws one or more polygonal curves
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pts"></param>
        /// <param name="isClosed"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        /// <param name="lineType"></param>
        /// <param name="shift"></param>
        public static void Polylines(
            Mat img,
            IEnumerable<IEnumerable<Point>> pts, 
            bool isClosed,
            Scalar color,
            int thickness = 1,
            LineTypes lineType = LineTypes.Link8, 
            int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (pts == null)
                throw new ArgumentNullException(nameof(pts));
            img.ThrowIfDisposed();

            var ptsList = new List<Point[]>();
            var nptsList = new List<int>();
            foreach (var pts1 in pts)
            {
                var pts1Arr = pts1.ToArray();
                ptsList.Add(pts1Arr);
                nptsList.Add(pts1Arr.Length);
            }
            var ptsArr = ptsList.ToArray();
            var npts = nptsList.ToArray();
            var ncontours = ptsArr.Length;
            using var ptsPtr = new ArrayAddress2<Point>(ptsArr);

            NativeMethods.HandleException(
                NativeMethods.imgproc_polylines_Mat(
                    img.CvPtr, ptsPtr.GetPointer(), npts, ncontours, isClosed ? 1 : 0, color, thickness, (int) lineType, shift));
            GC.KeepAlive(img);
        }

        /// <summary>
        /// draws one or more polygonal curves
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pts"></param>
        /// <param name="isClosed"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        /// <param name="lineType"></param>
        /// <param name="shift"></param>
        public static void Polylines(
            InputOutputArray img, InputArray pts, bool isClosed, Scalar color,
            int thickness = 1, LineTypes lineType = LineTypes.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (pts == null)
                throw new ArgumentNullException(nameof(pts));
            img.ThrowIfDisposed();
            pts.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_polylines_InputOutputArray(
                    img.CvPtr, pts.CvPtr, isClosed ? 1 : 0, color, thickness, (int) lineType, shift));
            GC.KeepAlive(img);
            img.Fix();
            GC.KeepAlive(pts);
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
            IEnumerable<IEnumerable<Point>> contours,
            int contourIdx,
            Scalar color,
            int thickness = 1,
            LineTypes lineType = LineTypes.Link8,
            IEnumerable<HierarchyIndex>? hierarchy = null,
            int maxLevel = int.MaxValue,
            Point? offset = null)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (contours == null)
                throw new ArgumentNullException(nameof(contours));
            image.ThrowIfNotReady();

            var offset0 = offset.GetValueOrDefault(new Point());
            var contoursArray = contours.Select(c => c.ToArray()).ToArray();
            var contourSize2 = contoursArray.Select(pts => pts.Length).ToArray();
            using (var contoursPtr = new ArrayAddress2<Point>(contoursArray))
            {
                if (hierarchy == null)
                {
                    NativeMethods.HandleException(
                        NativeMethods.imgproc_drawContours_vector(
                            image.CvPtr, contoursPtr.GetPointer(), contoursArray.Length, contourSize2,
                            contourIdx, color, thickness, (int) lineType, IntPtr.Zero, 0, maxLevel, offset0));
                }
                else
                {
                    var hierarchyVecs = hierarchy.Select(hi => hi.ToVec4i()).ToArray();
                    NativeMethods.HandleException(
                        NativeMethods.imgproc_drawContours_vector(
                            image.CvPtr, contoursPtr.GetPointer(), contoursArray.Length, contourSize2,
                            contourIdx, color, thickness, (int) lineType, hierarchyVecs, hierarchyVecs.Length, maxLevel, offset0));
                }
            }
            GC.KeepAlive(image);
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
            LineTypes lineType = LineTypes.Link8,
            Mat? hierarchy = null,
            int maxLevel = int.MaxValue,
            Point? offset = null)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (contours == null)
                throw new ArgumentNullException(nameof(contours));
            image.ThrowIfNotReady();

            var offset0 = offset.GetValueOrDefault(new Point());
            var contoursPtr = contours.Select(x => x.CvPtr).ToArray();

            NativeMethods.HandleException(
                NativeMethods.imgproc_drawContours_InputArray(
                    image.CvPtr, contoursPtr, contoursPtr.Length,
                    contourIdx, color, thickness, (int) lineType, ToPtr(hierarchy), maxLevel, offset0));
            image.Fix();
            GC.KeepAlive(image);
            GC.KeepAlive(contours);
            GC.KeepAlive(hierarchy);
        }

#if LANG_JP
        /// <summary>
        /// 線分が画像矩形内に収まるように切り詰めます．
        /// </summary>
        /// <param name="imgSize">画像サイズ．</param>
        /// <param name="pt1">線分の1番目の端点．</param>
        /// <param name="pt2">線分の2番目の端点．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Clips the line against the image rectangle
        /// </summary>
        /// <param name="imgSize">The image size</param>
        /// <param name="pt1">The first line point</param>
        /// <param name="pt2">The second line point</param>
        /// <returns></returns>
#endif
        public static bool ClipLine(Size imgSize, ref Point pt1, ref Point pt2)
        {
            NativeMethods.HandleException(
                NativeMethods.imgproc_clipLine1(imgSize, ref pt1, ref pt2, out var ret));
            return ret != 0;
        }

#if LANG_JP
        /// <summary>
        /// 線分が画像矩形内に収まるように切り詰めます．
        /// </summary>
        /// <param name="imgRect">画像矩形．</param>
        /// <param name="pt1">線分の1番目の端点．</param>
        /// <param name="pt2">線分の2番目の端点．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Clips the line against the image rectangle
        /// </summary>
        /// <param name="imgRect">sThe image rectangle</param>
        /// <param name="pt1">The first line point</param>
        /// <param name="pt2">The second line point</param>
        /// <returns></returns>
#endif
        public static bool ClipLine(Rect imgRect, ref Point pt1, ref Point pt2)
        {
            NativeMethods.HandleException(
                NativeMethods.imgproc_clipLine2(imgRect, ref pt1, ref pt2, out var ret));
            return ret != 0;
        }

        /// <summary>
        /// Approximates an elliptic arc with a polyline.
        /// The function ellipse2Poly computes the vertices of a polyline that 
        /// approximates the specified elliptic arc. It is used by cv::ellipse.
        /// </summary>
        /// <param name="center">Center of the arc.</param>
        /// <param name="axes">Half of the size of the ellipse main axes. See the ellipse for details.</param>
        /// <param name="angle">Rotation angle of the ellipse in degrees. See the ellipse for details.</param>
        /// <param name="arcStart">Starting angle of the elliptic arc in degrees.</param>
        /// <param name="arcEnd">Ending angle of the elliptic arc in degrees.</param>
        /// <param name="delta">Angle between the subsequent polyline vertices. It defines the approximation</param>
        /// <returns>Output vector of polyline vertices.</returns>
        public static Point[] Ellipse2Poly(Point center, Size axes, int angle,
            int arcStart, int arcEnd, int delta)
        {
            using var vec = new VectorOfPoint();
            NativeMethods.HandleException(
                NativeMethods.imgproc_ellipse2Poly_int(center, axes, angle, arcStart, arcEnd, delta, vec.CvPtr));
            return vec.ToArray();
        }

        /// <summary>
        /// Approximates an elliptic arc with a polyline.
        /// The function ellipse2Poly computes the vertices of a polyline that 
        /// approximates the specified elliptic arc. It is used by cv::ellipse.
        /// </summary>
        /// <param name="center">Center of the arc.</param>
        /// <param name="axes">Half of the size of the ellipse main axes. See the ellipse for details.</param>
        /// <param name="angle">Rotation angle of the ellipse in degrees. See the ellipse for details.</param>
        /// <param name="arcStart">Starting angle of the elliptic arc in degrees.</param>
        /// <param name="arcEnd">Ending angle of the elliptic arc in degrees.</param>
        /// <param name="delta">Angle between the subsequent polyline vertices. It defines the approximation</param>
        /// <returns>Output vector of polyline vertices.</returns>
        public static Point2d[] Ellipse2Poly(Point2d center, Size2d axes, int angle,
            int arcStart, int arcEnd, int delta)
        {
            using var vec = new VectorOfPoint2d();
            NativeMethods.HandleException(
                NativeMethods.imgproc_ellipse2Poly_double(center, axes, angle, arcStart, arcEnd, delta, vec.CvPtr));
            return vec.ToArray();
        }

        /// <summary>
        /// renders text string in the image
        /// </summary>
        /// <param name="img">Image.</param>
        /// <param name="text">Text string to be drawn.</param>
        /// <param name="org">Bottom-left corner of the text string in the image.</param>
        /// <param name="fontFace">Font type, see #HersheyFonts.</param>
        /// <param name="fontScale">Font scale factor that is multiplied by the font-specific base size.</param>
        /// <param name="color">Text color.</param>
        /// <param name="thickness">Thickness of the lines used to draw a text.</param>
        /// <param name="lineType">Line type. See #LineTypes</param>
        /// <param name="bottomLeftOrigin">When true, the image data origin is at the bottom-left corner.
        /// Otherwise, it is at the top-left corner.</param>
        public static void PutText(InputOutputArray img, string text, Point org,
            HersheyFonts fontFace, double fontScale, Scalar color,
            int thickness = 1, LineTypes lineType = LineTypes.Link8, bool bottomLeftOrigin = false)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(text);
            img.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgproc_putText(img.CvPtr, text, org, (int) fontFace, fontScale, color,
                    thickness, (int) lineType, bottomLeftOrigin ? 1 : 0));

            img.Fix();
            GC.KeepAlive(img);
        }

        /// <summary>
        /// returns bounding box of the text string
        /// </summary>
        /// <param name="text">Input text string.</param>
        /// <param name="fontFace">Font to use, see #HersheyFonts.</param>
        /// <param name="fontScale">Font scale factor that is multiplied by the font-specific base size.</param>
        /// <param name="thickness">Thickness of lines used to render the text. See #putText for details.</param>
        /// <param name="baseLine">baseLine y-coordinate of the baseline relative to the bottom-most text</param>
        /// <returns>The size of a box that contains the specified text.</returns>
        public static Size GetTextSize(string text, HersheyFonts fontFace,
            double fontScale, int thickness, out int baseLine)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(text);

            NativeMethods.HandleException(
                NativeMethods.imgproc_getTextSize(text, (int)fontFace, fontScale, thickness, out baseLine, out var ret));
            return ret;
        }

        /// <summary>
        /// Calculates the font-specific size to use to achieve a given height in pixels.
        /// </summary>
        /// <param name="fontFace">Font to use, see cv::HersheyFonts.</param>
        /// <param name="pixelHeight">Pixel height to compute the fontScale for</param>
        /// <param name="thickness">Thickness of lines used to render the text.See putText for details.</param>
        /// <returns>The fontSize to use for cv::putText</returns>
        public static double GetFontScaleFromHeight(HersheyFonts fontFace, int pixelHeight, int thickness = 1)
        {
            NativeMethods.HandleException(
                NativeMethods.imgproc_getFontScaleFromHeight((int)fontFace, pixelHeight, thickness, out var ret));
            return ret;
        }

        #endregion
    }
}
