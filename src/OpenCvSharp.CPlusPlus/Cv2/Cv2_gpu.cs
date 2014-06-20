using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
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
            return NativeMethods.gpu_getDevice();
        }

        /// <summary>
        /// Explicitly destroys and cleans up all resources associated with the current device in the current process.
        /// Any subsequent API call to this device will reinitialize the device.
        /// </summary>
        public static void ResetDevice()
        {
            NativeMethods.gpu_resetDevice();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public static void PrintCudaDeviceInfo(int device)
        {
            NativeMethods.gpu_printCudaDeviceInfo(device);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public static void PrintShortCudaDeviceInfo(int device)
        {
            NativeMethods.gpu_printShortCudaDeviceInfo(device);
        }

        #endregion
    }
}
