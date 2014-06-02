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

/*
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
#else
        /// <summary>
        /// 現在のデバイスインデックスを返します．
        /// これは，{gpu::getDevice} によって設定された，またはデフォルトで初期化されたデバイスです．
        /// </summary>
        /// <param name="device"></param>
#endif
        public static string GetDeviceName(int device)
        {
            StringBuilder buffer = new StringBuilder(256);
            GpuInvoke.getDeviceName(device, buffer);
            return buffer.ToString();
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="major"></param>
        /// <param name="minor"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="major"></param>
        /// <param name="minor"></param>
#endif
        public static void GetComputeCapability(int device, out int major, out int minor)
        {
            GpuInvoke.getComputeCapability(device, out major, out minor);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
       /// <param name="free"></param>
        /// <param name="total"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="free"></param>
        /// <param name="total"></param>
#endif
        public static void GetGpuMemInfo(out ulong free, out ulong total)
        {
            GpuInvoke.getGpuMemInfo(out free, out total);
        }


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
#endif
        public static bool HasNativeDoubleSupport(int device)
        {
            return GpuInvoke.hasNativeDoubleSupport(device) != 0;
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
#endif
        public static bool HasAtomicsSupport(int device)
        {
            return GpuInvoke.hasAtomicsSupport(device) != 0;
        }
*/

        #endregion
    }
}
