#if ENABLED_CUDA

using System;
using System.Collections.Generic;
using OpenCvSharp.Cuda;

namespace OpenCvSharp
{
    static partial class Cv2
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
            return NativeMethods.cuda_getCudaEnabledDeviceCount();
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
            return NativeMethods.cuda_getDevice();
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
            return NativeMethods.cuda_getDevice();
        }

        /// <summary>
        /// Explicitly destroys and cleans up all resources associated with the current device in the current process.
        /// Any subsequent API call to this device will reinitialize the device.
        /// </summary>
        public static void ResetDevice()
        {
            ThrowIfGpuNotAvailable();
            NativeMethods.cuda_resetDevice();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public static void PrintCudaDeviceInfo(int device)
        {
            ThrowIfGpuNotAvailable();
            NativeMethods.cuda_printCudaDeviceInfo(device);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public static void PrintShortCudaDeviceInfo(int device)
        {
            ThrowIfGpuNotAvailable();
            NativeMethods.cuda_printShortCudaDeviceInfo(device);
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
                throw new ArgumentNullException(nameof(m));
            NativeMethods.cuda_registerPageLocked(m.CvPtr);
            GC.KeepAlive(m);
        }

        /// <summary>
        /// Unmaps the memory of matrix m, and makes it pageable again.
        /// </summary>
        /// <param name="m"></param>
        public static void UnregisterPageLocked(Mat m)
        {
            ThrowIfGpuNotAvailable();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.cuda_unregisterPageLocked(m.CvPtr);
            GC.KeepAlive(m);
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
                throw new ArgumentNullException(nameof(m));
            NativeMethods.cuda_createContinuous1(rows, cols, type, m.CvPtr);
            GC.KeepAlive(m);
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
            IntPtr ret = NativeMethods.cuda_createContinuous2(rows, cols, type);
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
                throw new ArgumentNullException(nameof(m));
            NativeMethods.cuda_ensureSizeIsEnough(rows, cols, type, m.CvPtr);
            GC.KeepAlive(m);
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

#endif