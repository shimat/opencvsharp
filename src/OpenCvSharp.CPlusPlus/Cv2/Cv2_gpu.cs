using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Gpu
{
    /// <summary>
    /// Functions of OpenCV GPU module
    /// </summary>
    public static class Cv2Gpu
    {
        #region Hardware

#if LANG_JP
    /// <summary>
    /// CUDAを利用可能なデバイスの個数を返します．
    /// 最初のGPU関数呼び出しよりも前に利用しなければいけません．
    /// OpenCVがGPUサポートなしでコンパイルされていれば，この関数は0を返します．
    /// </summary>
    /// <returns></returns>
#else
        /// <summary>
        /// Returns the number of installed CUDA-enabled devices.
        /// Use this function before any other GPU functions calls. 
        /// If OpenCV is compiled without GPU support, this function returns 0.
        /// </summary>
        /// <returns></returns>
#endif
        public static int GetCudaEnabledDeviceCount()
        {
            return NativeMethods.gpu_getCudaEnabledDeviceCount();
        }

#if LANG_JP
    /// <summary>
    /// 現在のデバイスインデックスを返します．
    /// これは，SetDevice によって設定された，またはデフォルトで初期化されたデバイスです．
    /// </summary>
    /// <returns></returns>
#else
        /// <summary>
        /// Returns the current device index set by SetDevice() or initialized by default.
        /// </summary>
        /// <returns></returns>
#endif
        public static int GetDevice()
        {
            ThrowIfGpuNotAvailable();
            return NativeMethods.gpu_getDevice();
        }

#if LANG_JP
    /// <summary>
    /// 現在のスレッドでデバイスを設定し，それを初期化します．
    /// この関数呼び出しを省略することもできますが，その場合，
    /// 最初に GPU が利用される際にデフォルトデバイスが初期化されます．
    /// </summary>
    /// <param name="device">0からはじまる，GPUデバイスのインデックス．</param>
    /// <returns></returns>
#else
        /// <summary>
        /// Sets a device and initializes it for the current thread.
        /// </summary>
        /// <param name="device">System index of a GPU device starting with 0.</param>
        /// <returns></returns>
#endif
        public static int SetDevice(int device)
        {
            ThrowIfGpuNotAvailable();
            return NativeMethods.gpu_getDevice();
        }

        /// <summary>
        /// Explicitly destroys and cleans up all resources associated with the current device in the current process.
        /// Any subsequent API call to this device will reinitialize the device.
        /// </summary>
        public static void ResetDevice()
        {
            ThrowIfGpuNotAvailable();
            NativeMethods.gpu_resetDevice();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public static void PrintCudaDeviceInfo(int device)
        {
            ThrowIfGpuNotAvailable();
            NativeMethods.gpu_printCudaDeviceInfo(device);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public static void PrintShortCudaDeviceInfo(int device)
        {
            ThrowIfGpuNotAvailable();
            NativeMethods.gpu_printShortCudaDeviceInfo(device);
        }

        #endregion

        #region CudaMem

        /// <summary>
        /// Page-locks the matrix m memory and maps it for the device(s)
        /// </summary>
        /// <param name="m"></param>
        public static void RegisterPageLocked(Mat m)
        {
            ThrowIfGpuNotAvailable();
            if (m == null)
                throw new ArgumentNullException("m");
            NativeMethods.gpu_registerPageLocked(m.CvPtr);
        }

        /// <summary>
        /// Unmaps the memory of matrix m, and makes it pageable again.
        /// </summary>
        /// <param name="m"></param>
        public static void UnregisterPageLocked(Mat m)
        {
            ThrowIfGpuNotAvailable();
            if (m == null)
                throw new ArgumentNullException("m");
            NativeMethods.gpu_unregisterPageLocked(m.CvPtr);
        }

        #endregion

        #region GpuMat

        /// <summary>
        /// Creates continuous GPU matrix
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type.</param>
        /// <param name="m"></param>
        public static void CreateContinuous(int rows, int cols, MatType type, GpuMat m)
        {
            ThrowIfGpuNotAvailable();
            if (m == null)
                throw new ArgumentNullException("m");
            NativeMethods.gpu_createContinuous1(rows, cols, type, m.CvPtr);
        }

        /// <summary>
        /// Creates continuous GPU matrix
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type.</param>
        /// <returns></returns>
        public static GpuMat CreateContinuous(int rows, int cols, MatType type)
        {
            ThrowIfGpuNotAvailable();
            IntPtr ret = NativeMethods.gpu_createContinuous2(rows, cols, type);
            return new GpuMat(ret);
        }

        /// <summary>
        /// Creates continuous GPU matrix
        /// </summary>
        /// <param name="size">Number of rows and columns in a 2D array.</param>
        /// <param name="type">Array type.</param>
        /// <param name="m"></param>
        public static void CreateContinuous(Size size, MatType type, GpuMat m)
        {
            ThrowIfGpuNotAvailable();
            CreateContinuous(size.Height, size.Width, type, m);
        }

        /// <summary>
        /// Creates continuous GPU matrix
        /// </summary>
        /// <param name="size">Number of rows and columns in a 2D array.</param>
        /// <param name="type">Array type.</param>
        /// <returns></returns>
        public static GpuMat CreateContinuous(Size size, MatType type)
        {
            ThrowIfGpuNotAvailable();
            return CreateContinuous(size.Height, size.Width, type);
        }

        /// <summary>
        /// Ensures that size of the given matrix is not less than (rows, cols) size
        /// and matrix type is match specified one too
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type.</param>
        /// <param name="m"></param>
        public static void EnsureSizeIsEnough(int rows, int cols, MatType type, GpuMat m)
        {
            ThrowIfGpuNotAvailable();
            if (m == null)
                throw new ArgumentNullException("m");
            NativeMethods.gpu_ensureSizeIsEnough(rows, cols, type, m.CvPtr);
        }

        /// <summary>
        /// Ensures that size of the given matrix is not less than (rows, cols) size
        /// and matrix type is match specified one too
        /// </summary>
        /// <param name="size">Number of rows and columns in a 2D array.</param>
        /// <param name="type">Array type.</param>
        /// <param name="m"></param>
        public static void EnsureSizeIsEnough(Size size, MatType type, GpuMat m)
        {
            ThrowIfGpuNotAvailable();
            EnsureSizeIsEnough(size.Height, size.Width, type, m);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type.</param>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static GpuMat AllocMatFromBuf(int rows, int cols, MatType type, GpuMat mat)
        {
            ThrowIfGpuNotAvailable();
            if (mat == null)
                throw new ArgumentNullException("mat");
            IntPtr ret = NativeMethods.gpu_allocMatFromBuf(rows, cols, type, mat.CvPtr);
            return new GpuMat(ret);
        }

        #endregion

        #region Functions
        #region Filter Engine
        
        /// <summary>
        /// Smooths the image using the normalized box filter.
        /// </summary>
        /// <param name="src">Input image. CV_8UC1 and CV_8UC4 source types are supported.</param>
        /// <param name="dst">Output image type. The size and type is the same as src.</param>
        /// <param name="ddepth">Output image depth. If -1, the output image has the same depth as the input one. 
        /// The only values allowed here are CV_8U and -1.</param>
        /// <param name="ksize">Kernel size.</param>
        /// <param name="anchor">Anchor point. The default value Point(-1, -1) means that 
        /// the anchor is at the kernel center.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void BoxFilter(
            GpuMat src, GpuMat dst, int ddepth, Size ksize, Point? anchor,
            Stream stream = null)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            Point anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.gpu_boxFilter(src.CvPtr, dst.CvPtr, ddepth, ksize, anchor0, Cv2.ToPtr(stream));
        }

        /// <summary>
        /// Acts as a synonym for the normalized box filter.
        /// </summary>
        /// <param name="src">Input image. CV_8UC1 and CV_8UC4 source types are supported.</param>
        /// <param name="dst">Output image type. The size and type is the same as src.</param>
        /// <param name="ksize">Kernel size.</param>
        /// <param name="anchor">Anchor point. The default value Point(-1, -1) means that 
        /// the anchor is at the kernel center.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Blur(GpuMat src, GpuMat dst, Size ksize, Point? anchor, Stream stream = null)
        {
            BoxFilter(src, dst, -1, ksize, anchor, stream);
        }

        /// <summary>
        /// Erodes an image by using a specific structuring element.
        /// </summary>
        /// <param name="src">Source image. Only CV_8UC1 and CV_8UC4 types are supported.</param>
        /// <param name="dst">Destination image with the same size and type as src.</param>
        /// <param name="kernel">Structuring element used for erosion. If kernel=Mat(), 
        /// a 3x3 rectangular structuring element is used.</param>
        /// <param name="anchor">Position of an anchor within the element. 
        /// The default value (-1, -1) means that the anchor is at the element center.</param>
        /// <param name="iterations">Number of times erosion to be applied.</param>
        public static void Erode(
            GpuMat src, GpuMat dst, Mat kernel, Point? anchor = null, int iterations = 1)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (kernel == null)
                throw new ArgumentNullException("kernel");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            kernel.ThrowIfDisposed();

            Point anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.gpu_erode1(src.CvPtr, dst.CvPtr, kernel.CvPtr, anchor0, iterations);
        }

        /// <summary>
        /// Erodes an image by using a specific structuring element.
        /// </summary>
        /// <param name="src">Source image. Only CV_8UC1 and CV_8UC4 types are supported.</param>
        /// <param name="dst">Destination image with the same size and type as src.</param>
        /// <param name="kernel">Structuring element used for erosion. If kernel=Mat(), 
        /// a 3x3 rectangular structuring element is used.</param>
        /// <param name="buf"></param>
        /// <param name="anchor">Position of an anchor within the element. 
        /// The default value (-1, -1) means that the anchor is at the element center.</param>
        /// <param name="iterations">Number of times erosion to be applied.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Erode(
            GpuMat src, GpuMat dst, Mat kernel, GpuMat buf,
            Point? anchor = null, int iterations = 1, Stream stream = null)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (kernel == null)
                throw new ArgumentNullException("kernel");
            if (buf == null)
                throw new ArgumentNullException("buf");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            kernel.ThrowIfDisposed();
            buf.ThrowIfDisposed();

            Point anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.gpu_erode2(src.CvPtr, dst.CvPtr, kernel.CvPtr,
                buf.CvPtr, anchor0, iterations, Cv2.ToPtr(stream));
        }

        /// <summary>
        /// Dilates an image by using a specific structuring element.
        /// </summary>
        /// <param name="src">Source image. Only CV_8UC1 and CV_8UC4 types are supported.</param>
        /// <param name="dst">Destination image with the same size and type as src.</param>
        /// <param name="kernel">Structuring element used for erosion. If kernel=Mat(), 
        /// a 3x3 rectangular structuring element is used.</param>
        /// <param name="anchor">Position of an anchor within the element. 
        /// The default value (-1, -1) means that the anchor is at the element center.</param>
        /// <param name="iterations">Number of times erosion to be applied.</param>
        public static void Dilate(
            GpuMat src, GpuMat dst, Mat kernel, Point? anchor = null, int iterations = 1)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (kernel == null)
                throw new ArgumentNullException("kernel");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            kernel.ThrowIfDisposed();

            Point anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.gpu_dilate1(src.CvPtr, dst.CvPtr, kernel.CvPtr, anchor0, iterations);
        }

        /// <summary>
        /// Dilates an image by using a specific structuring element.
        /// </summary>
        /// <param name="src">Source image. Only CV_8UC1 and CV_8UC4 types are supported.</param>
        /// <param name="dst">Destination image with the same size and type as src.</param>
        /// <param name="kernel">Structuring element used for erosion. If kernel=Mat(), 
        /// a 3x3 rectangular structuring element is used.</param>
        /// <param name="buf"></param>
        /// <param name="anchor">Position of an anchor within the element. 
        /// The default value (-1, -1) means that the anchor is at the element center.</param>
        /// <param name="iterations">Number of times erosion to be applied.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Dilate(
            GpuMat src, GpuMat dst, Mat kernel, GpuMat buf,
            Point? anchor, int iterations = 1, Stream stream = null)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (kernel == null)
                throw new ArgumentNullException("kernel");
            if (buf == null)
                throw new ArgumentNullException("buf");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            kernel.ThrowIfDisposed();
            buf.ThrowIfDisposed();

            Point anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.gpu_dilate2(src.CvPtr, dst.CvPtr, kernel.CvPtr,
                buf.CvPtr, anchor0, iterations, Cv2.ToPtr(stream));
        }

        /// <summary>
        /// Applies an advanced morphological operation to an image.
        /// </summary>
        /// <param name="src">Source image. CV_8UC1 and CV_8UC4 source types are supported.</param>
        /// <param name="dst">Destination image with the same size and type as src.</param>
        /// <param name="op">Type of morphological operation</param>
        /// <param name="kernel">Structuring element.</param>
        /// <param name="anchor">Position of an anchor within the element. 
        /// The default value Point(-1, -1) means that the anchor is at the element center.</param>
        /// <param name="iterations">Number of times erosion and dilation to be applied.</param>
        public static void MorphologyEx(
            GpuMat src, GpuMat dst, MorphologyOperation op, Mat kernel, Point? anchor = null, int iterations = 1)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (kernel == null)
                throw new ArgumentNullException("kernel");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            kernel.ThrowIfDisposed();

            Point anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.gpu_morphologyEx1(src.CvPtr, dst.CvPtr, (int)op, kernel.CvPtr, anchor0, iterations);
        }

        /// <summary>
        /// Applies an advanced morphological operation to an image.
        /// </summary>
        /// <param name="src">Source image. CV_8UC1 and CV_8UC4 source types are supported.</param>
        /// <param name="dst">Destination image with the same size and type as src.</param>
        /// <param name="op">Type of morphological operation</param>
        /// <param name="kernel">Structuring element.</param>
        /// <param name="buf1"></param>
        /// <param name="buf2"></param>
        /// <param name="anchor">Position of an anchor within the element. 
        /// The default value Point(-1, -1) means that the anchor is at the element center.</param>
        /// <param name="iterations">Number of times erosion and dilation to be applied.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void MorphologyEx(
            GpuMat src, GpuMat dst, MorphologyOperation op, Mat kernel, GpuMat buf1, GpuMat buf2,
            Point? anchor = null, int iterations = 1, Stream stream = null)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (kernel == null)
                throw new ArgumentNullException("kernel");
            if (buf1 == null)
                throw new ArgumentNullException("buf1");
            if (buf2 == null)
                throw new ArgumentNullException("buf2");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            kernel.ThrowIfDisposed();
            buf1.ThrowIfDisposed();
            buf2.ThrowIfDisposed();

            Point anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.gpu_morphologyEx2(src.CvPtr, dst.CvPtr, (int)op, kernel.CvPtr,
                buf1.CvPtr, buf2.CvPtr, anchor0, iterations, Cv2.ToPtr(stream));
        }

        /// <summary>
        /// Applies the non-separable 2D linear filter to an image.
        /// </summary>
        /// <param name="src">Source image. Supports CV_8U, CV_16U and CV_32F one and four channel image.</param>
        /// <param name="dst">Destination image. The size and the number of channels is the same as src.</param>
        /// <param name="ddepth">Desired depth of the destination image. If it is negative, it is the same as src.depth(). 
        /// It supports only the same depth as the source image depth.</param>
        /// <param name="kernel">2D array of filter coefficients.</param>
        /// <param name="anchor">Anchor of the kernel that indicates the relative position of 
        /// a filtered point within the kernel. The anchor resides within the kernel. 
        /// The special default value (-1,-1) means that the anchor is at the kernel center.</param>
        /// <param name="borderType">Pixel extrapolation method.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Filter2D(
            GpuMat src, GpuMat dst, int ddepth, Mat kernel, Point? anchor,
            BorderType borderType = BorderType.Default, Stream stream = null)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (kernel == null)
                throw new ArgumentNullException("kernel");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            kernel.ThrowIfDisposed();

            Point anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.gpu_filter2D(src.CvPtr, dst.CvPtr, ddepth, kernel.CvPtr,
                anchor0, (int)borderType, Cv2.ToPtr(stream));
        }

        /// <summary>
        /// Applies a separable 2D linear filter to an image.
        /// </summary>
        /// <param name="src">Source image. 
        /// CV_8UC1, CV_8UC4, CV_16SC1, CV_16SC2, CV_32SC1, CV_32FC1 source types are supported.</param>
        /// <param name="dst">Destination image with the same size and number of channels as src.</param>
        /// <param name="ddepth">Destination image depth. CV_8U, CV_16S, CV_32S, and CV_32F are supported.</param>
        /// <param name="kernelX">Horizontal filter coefficients.</param>
        /// <param name="kernelY">Vertical filter coefficients.</param>
        /// <param name="anchor">Anchor position within the kernel. 
        /// The default value (-1, 1) means that the anchor is at the kernel center.</param>
        /// <param name="rowBorderType">Pixel extrapolation method in the vertical direction.</param>
        /// <param name="columnBorderType">Pixel extrapolation method in the horizontal direction.</param>
        public static void SepFilter2D(
            GpuMat src, GpuMat dst, int ddepth, Mat kernelX, Mat kernelY,
            Point? anchor = null, BorderType rowBorderType = BorderType.Default, 
            BorderType columnBorderType = BorderType.Auto)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (kernelX == null)
                throw new ArgumentNullException("kernelX");
            if (kernelY == null)
                throw new ArgumentNullException("kernelY");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            kernelX.ThrowIfDisposed();
            kernelY.ThrowIfDisposed();

            Point anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.gpu_sepFilter2D1(
                src.CvPtr, dst.CvPtr, ddepth, kernelX.CvPtr, kernelY.CvPtr,
                anchor0, (int)rowBorderType, (int)columnBorderType);
        }

        /// <summary>
        /// Applies a separable 2D linear filter to an image.
        /// </summary>
        /// <param name="src">Source image. 
        /// CV_8UC1, CV_8UC4, CV_16SC1, CV_16SC2, CV_32SC1, CV_32FC1 source types are supported.</param>
        /// <param name="dst">Destination image with the same size and number of channels as src.</param>
        /// <param name="ddepth">Destination image depth. CV_8U, CV_16S, CV_32S, and CV_32F are supported.</param>
        /// <param name="kernelX">Horizontal filter coefficients.</param>
        /// <param name="kernelY">Vertical filter coefficients.</param>
        /// <param name="buf"></param>
        /// <param name="anchor">Anchor position within the kernel. 
        /// The default value (-1, 1) means that the anchor is at the kernel center.</param>
        /// <param name="rowBorderType">Pixel extrapolation method in the vertical direction.</param>
        /// <param name="columnBorderType">Pixel extrapolation method in the horizontal direction.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void SepFilter2D(
            GpuMat src, GpuMat dst, int ddepth, Mat kernelX, Mat kernelY, GpuMat buf,
            Point? anchor = null, BorderType rowBorderType = BorderType.Default, 
            BorderType columnBorderType = BorderType.Auto, Stream stream = null)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (kernelX == null)
                throw new ArgumentNullException("kernelX");
            if (kernelY == null)
                throw new ArgumentNullException("kernelY");
            if (buf == null)
                throw new ArgumentNullException("buf");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            kernelX.ThrowIfDisposed();
            kernelY.ThrowIfDisposed();
            buf.ThrowIfDisposed();

            Point anchor0 = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.gpu_sepFilter2D2(
                src.CvPtr, dst.CvPtr, ddepth, kernelX.CvPtr, kernelY.CvPtr, buf.CvPtr, 
                anchor0, (int)rowBorderType, (int)columnBorderType, Cv2.ToPtr(stream));
        }

        /// <summary>
        /// Applies the generalized Sobel operator to an image.
        /// </summary>
        /// <param name="src">Source image. 
        /// CV_8UC1, CV_8UC4, CV_16SC1, CV_16SC2, CV_16SC3, CV_32SC1, CV_32FC1 source types are supported.</param>
        /// <param name="dst">Destination image with the same size and number of channels as source image.</param>
        /// <param name="ddepth">Destination image depth. CV_8U, CV_16S, CV_32S, and CV_32F are supported.</param>
        /// <param name="dx">Derivative order in respect of x.</param>
        /// <param name="dy">Derivative order in respect of y.</param>
        /// <param name="ksize">Size of the extended Sobel kernel. Possible values are 1, 3, 5 or 7.</param>
        /// <param name="scale">Optional scale factor for the computed derivative values. By default, no scaling is applied.</param>
        /// <param name="rowBorderType">Pixel extrapolation method in the vertical direction.</param>
        /// <param name="columnBorderType">Pixel extrapolation method in the horizontal direction.</param>
        public static void Sobel(GpuMat src, GpuMat dst, int ddepth, int dx, int dy, int ksize = 3, double scale = 1,
            BorderType rowBorderType = BorderType.Default, BorderType columnBorderType = BorderType.Auto)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.gpu_Sobel1(
                src.CvPtr, dst.CvPtr, ddepth, dx, dy, ksize, scale,
                (int)rowBorderType, (int)columnBorderType);
        }

        /// <summary>
        /// Applies the generalized Sobel operator to an image.
        /// </summary>
        /// <param name="src">Source image. 
        /// CV_8UC1, CV_8UC4, CV_16SC1, CV_16SC2, CV_16SC3, CV_32SC1, CV_32FC1 source types are supported.</param>
        /// <param name="dst">Destination image with the same size and number of channels as source image.</param>
        /// <param name="ddepth">Destination image depth. CV_8U, CV_16S, CV_32S, and CV_32F are supported.</param>
        /// <param name="dx">Derivative order in respect of x.</param>
        /// <param name="dy">Derivative order in respect of y.</param>
        /// <param name="buf"></param>
        /// <param name="ksize">Size of the extended Sobel kernel. Possible values are 1, 3, 5 or 7.</param>
        /// <param name="scale">Optional scale factor for the computed derivative values. By default, no scaling is applied.</param>
        /// <param name="rowBorderType">Pixel extrapolation method in the vertical direction.</param>
        /// <param name="columnBorderType">Pixel extrapolation method in the horizontal direction.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Sobel(
            GpuMat src, GpuMat dst, int ddepth, int dx, int dy, GpuMat buf, int ksize = 3,
            double scale = 1, BorderType rowBorderType = BorderType.Default, 
            BorderType columnBorderType = BorderType.Auto, Stream stream = null)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (buf == null)
                throw new ArgumentNullException("buf");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            buf.ThrowIfDisposed();

            NativeMethods.gpu_Sobel2(
                src.CvPtr, dst.CvPtr, ddepth, dx, dy, buf.CvPtr, ksize, scale,
                (int)rowBorderType, (int)columnBorderType, Cv2.ToPtr(stream));
        }

        /// <summary>
        /// Calculates the first x- or y- image derivative using the Scharr operator.
        /// </summary>
        /// <param name="src">Source image. 
        /// CV_8UC1, CV_8UC4, CV_16SC1, CV_16SC2, CV_16SC3, CV_32SC1, CV_32FC1 source types are supported.</param>
        /// <param name="dst">Destination image with the same size and number of channels as source image.</param>
        /// <param name="ddepth">Destination image depth. CV_8U, CV_16S, CV_32S, and CV_32F are supported.</param>
        /// <param name="dx">Derivative order in respect of x.</param>
        /// <param name="dy">Derivative order in respect of y.</param>
        /// <param name="scale">Optional scale factor for the computed derivative values. By default, no scaling is applied.</param>
        /// <param name="rowBorderType">Pixel extrapolation method in the vertical direction.</param>
        /// <param name="columnBorderType">Pixel extrapolation method in the horizontal direction.</param>
        public static void Scharr(
            GpuMat src, GpuMat dst, int ddepth, int dx, int dy, double scale = 1,
            BorderType rowBorderType = BorderType.Default,
            BorderType columnBorderType = BorderType.Auto)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.gpu_Scharr1(
                src.CvPtr, dst.CvPtr, ddepth, dx, dy, scale,
                (int)rowBorderType, (int)columnBorderType);
        }

        /// <summary>
        /// Calculates the first x- or y- image derivative using the Scharr operator.
        /// </summary>
        /// <param name="src">Source image. 
        /// CV_8UC1, CV_8UC4, CV_16SC1, CV_16SC2, CV_16SC3, CV_32SC1, CV_32FC1 source types are supported.</param>
        /// <param name="dst">Destination image with the same size and number of channels as source image.</param>
        /// <param name="ddepth">Destination image depth. CV_8U, CV_16S, CV_32S, and CV_32F are supported.</param>
        /// <param name="dx">Derivative order in respect of x.</param>
        /// <param name="dy">Derivative order in respect of y.</param>
        /// <param name="buf"></param>
        /// <param name="scale">Optional scale factor for the computed derivative values. By default, no scaling is applied.</param>
        /// <param name="rowBorderType">Pixel extrapolation method in the vertical direction.</param>
        /// <param name="columnBorderType">Pixel extrapolation method in the horizontal direction.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Scharr(
            GpuMat src, GpuMat dst, int ddepth, int dx, int dy, GpuMat buf, double scale = 1,
            BorderType rowBorderType = BorderType.Default, BorderType columnBorderType = BorderType.Auto,
            Stream stream = null)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (buf == null)
                throw new ArgumentNullException("buf");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            buf.ThrowIfDisposed();

            NativeMethods.gpu_Scharr2(
                src.CvPtr, dst.CvPtr, ddepth, dx, dy, buf.CvPtr, scale,
                (int)rowBorderType, (int)columnBorderType, Cv2.ToPtr(stream));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="sigma1"></param>
        /// <param name="sigma2"></param>
        /// <param name="rowBorderType"></param>
        /// <param name="columnBorderType"></param>
        public static void GaussianBlur(
            GpuMat src, GpuMat dst, Size ksize, double sigma1, double sigma2 = 0,
            BorderType rowBorderType = BorderType.Default, BorderType columnBorderType = BorderType.Auto)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.gpu_GaussianBlur1(
                src.CvPtr, dst.CvPtr, ksize, sigma1, sigma2, 
                (int)rowBorderType, (int)columnBorderType);
        }

        /// <summary>
        /// Smooths an image using the Gaussian filter.
        /// </summary>
        /// <param name="src">Source image. 
        /// CV_8UC1, CV_8UC4, CV_16SC1, CV_16SC2, CV_16SC3, CV_32SC1, CV_32FC1 source types are supported.</param>
        /// <param name="dst">Destination image with the same size and type as src.</param>
        /// <param name="ksize">Gaussian kernel size. ksize.Width and ksize.Height can differ 
        /// but they both must be positive and odd. If they are zeros, 
        /// they are computed from sigma1 and sigma2 .</param>
        /// <param name="buf"></param>
        /// <param name="sigma1">Gaussian kernel standard deviation in X direction.</param>
        /// <param name="sigma2">Gaussian kernel standard deviation in Y direction. 
        /// If sigma2 is zero, it is set to be equal to sigma1 . If they are both zeros, 
        /// they are computed from ksize.Width and ksize.Height, respectively.
        /// To fully control the result regardless of possible future modification of all 
        /// this semantics, you are recommended to specify all of ksize, sigma1, and sigma2.</param>
        /// <param name="rowBorderType">Pixel extrapolation method in the vertical direction.</param>
        /// <param name="columnBorderType">Pixel extrapolation method in the horizontal direction.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void GaussianBlur(
            GpuMat src, GpuMat dst, Size ksize, GpuMat buf, double sigma1, double sigma2 = 0,
            BorderType rowBorderType = BorderType.Default, BorderType columnBorderType = BorderType.Auto,
            Stream stream = null)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (buf == null)
                throw new ArgumentNullException("buf");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            buf.ThrowIfDisposed();

            NativeMethods.gpu_GaussianBlur2(
                src.CvPtr, dst.CvPtr, ksize, buf.CvPtr, sigma1, sigma2,
                (int)rowBorderType, (int)columnBorderType, Cv2.ToPtr(stream));
        }

        /// <summary>
        /// Applies the Laplacian operator to an image.
        /// </summary>
        /// <param name="src">Source image. CV_8UC1 and CV_8UC4 source types are supported.</param>
        /// <param name="dst">Destination image. The size and number of channels is the same as src.</param>
        /// <param name="ddepth">Desired depth of the destination image. It supports only the same depth as the source image depth.</param>
        /// <param name="ksize">Aperture size used to compute the second-derivative filters. 
        /// It must be positive and odd. Only ksize = 1 and ksize = 3 are supported.</param>
        /// <param name="scale">Optional scale factor for the computed Laplacian values.</param>
        /// <param name="borderType">Pixel extrapolation method.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Laplacian(
            GpuMat src, GpuMat dst, int ddepth, int ksize = 1, double scale = 1,
            BorderType borderType = BorderType.Default, Stream stream = null)
        {
            ThrowIfGpuNotAvailable();
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.gpu_Laplacian(
                src.CvPtr, dst.CvPtr, ddepth, ksize, scale, (int)borderType, Cv2.ToPtr(stream));
        }

        #endregion

        /// <summary>
        /// Finds global minimum and maximum array elements and returns their values with locations
        /// </summary>
        /// <param name="src">Single-channel source image.</param>
        /// <param name="minVal">Pointer to the returned minimum value.</param>
        /// <param name="maxVal">Pointer to the returned maximum value.</param>
        /// <param name="minLoc">Pointer to the returned minimum location.</param>
        /// <param name="maxLoc">Pointer to the returned maximum location.</param>
        /// <param name="mask">Optional mask to select a sub-matrix.</param>
        public static void MinMaxLoc(
            GpuMat src, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc,
            GpuMat mask = null)
        {
            ThrowIfGpuNotAvailable();
            if (src == null) 
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            NativeMethods.gpu_minMaxLoc1(
                src.CvPtr, out minVal, out maxVal, out minLoc, out maxLoc, Cv2.ToPtr(mask));
        }

        /// <summary>
        /// Finds global minimum and maximum array elements and returns their values with locations
        /// </summary>
        /// <param name="src">Single-channel source image.</param>
        /// <param name="minVal">Pointer to the returned minimum value.</param>
        /// <param name="maxVal">Pointer to the returned maximum value.</param>
        /// <param name="minLoc">Pointer to the returned minimum location.</param>
        /// <param name="maxLoc">Pointer to the returned maximum location.</param>
        /// <param name="mask">Optional mask to select a sub-matrix.</param>
        /// <param name="valbuf">Optional values buffer to avoid extra memory allocations. 
        /// It is resized automatically.</param>
        /// <param name="locbuf">Optional locations buffer to avoid extra memory allocations. 
        /// It is resized automatically.</param>
        public static void MinMaxLoc(
            GpuMat src, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc,
            GpuMat mask, GpuMat valbuf, GpuMat locbuf)
        {
            ThrowIfGpuNotAvailable();
            if (src == null) 
                throw new ArgumentNullException("src");
            if (valbuf == null)
                throw new ArgumentNullException("valbuf");
            if (locbuf == null)
                throw new ArgumentNullException("locbuf");
            src.ThrowIfDisposed();
            valbuf.ThrowIfDisposed();
            locbuf.ThrowIfDisposed();
            NativeMethods.gpu_minMaxLoc2(
                src.CvPtr, out minVal, out maxVal, out minLoc, out maxLoc, Cv2.ToPtr(mask),
                valbuf.CvPtr, locbuf.CvPtr);
        }

        /// <summary>
        /// Computes a proximity map for a raster template and an image where the template is searched for.
        /// </summary>
        /// <param name="image">Source image. CV_32F and CV_8U depth images (1..4 channels) are supported for now.</param>
        /// <param name="templ">Template image with the size and type the same as image.</param>
        /// <param name="result">Map containing comparison results (CV_32FC1). If image is W x H and templ is w x h, then result must be W-w+1 x H-h+1.</param>
        /// <param name="method">Specifies the way to compare the template with the image.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void MatchTemplate(
            GpuMat image, GpuMat templ, GpuMat result, MatchTemplateMethod method,
            Stream stream = null)
        {
            ThrowIfGpuNotAvailable();
            if (image == null)
                throw new ArgumentNullException("image");
            if (templ == null)
                throw new ArgumentNullException("templ");
            if (result == null)
                throw new ArgumentNullException("result");
            image.ThrowIfDisposed();
            templ.ThrowIfDisposed();
            result.ThrowIfDisposed();
            NativeMethods.gpu_matchTemplate1(
                image.CvPtr, templ.CvPtr, result.CvPtr, (int)method, Cv2.ToPtr(stream));
        }

/*
/// <summary>
/// computes the proximity map for the raster template and the image where the template is searched for
/// </summary>
/// <param name="image"></param>
/// <param name="templ"></param>
/// <param name="result"></param>
/// <param name="method"></param>
/// <param name="buf"></param>
/// <param name="stream"></param>
public static void MatchTemplate(
    GpuMat image, GpuMat templ, GpuMat result, MatchTemplateMethod method,
    MatchTemplateBuf buf, Stream stream = null)
{
            
}*/

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public static void ThrowIfGpuNotAvailable()
        {
            if (GetCudaEnabledDeviceCount() < 1)
                throw new OpenCvSharpException("GPU module cannot be used.");
        }
    }
}
