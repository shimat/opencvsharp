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
