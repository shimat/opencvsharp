/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Permissions;
using OpenCvSharp;

namespace OpenCvSharp.Gpu
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
    public static class CvGpu
    {

        /// <summary>
        /// 
        /// </summary>
        static CvGpu()
        {            
            GpuInvoke.TryPInvoke();
        }

        #region Properties
#if LANG_JP
        /// <summary>
        /// CudaによるGPUを使った処理が利用可能かどうかを返す.
        /// </summary>
#else
        /// <summary>
        /// Returns whether the library is compiled with Cuda.
        /// </summary>
#endif
        public static bool IsEnabled
        {
            get
            {
                return GpuInvoke.PInvokeSucceeded && CudaEnabledDeviceCount > 0;
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public static int CudaEnabledDeviceCount
        {
            get
            {
                return GpuInvoke.getCudaEnabledDeviceCount();
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public static int Device
        {
            get
            {
                return GpuInvoke.getDevice(); 
            }
            set
            {
                GpuInvoke.setDevice(value);
            }
        }
        #endregion

        #region Methods
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public static int GetCudaEnabledDeviceCount()
        {
            return GpuInvoke.getCudaEnabledDeviceCount();
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public static int GetDevice()
        {
            return GpuInvoke.getDevice();
        }
/*
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
#else
        /// <summary>
        /// 
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

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
#endif
        public static void SetDevice(int device)
        {
            GpuInvoke.setDevice(device);
        }
        #endregion
    }
}
