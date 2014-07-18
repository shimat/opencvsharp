using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Gpu
{
    /// <summary>
    /// Gives information about the given GPU
    /// </summary>
    public sealed class DeviceInfo : DisposableGpuObject
    {
        private bool disposed;

        /// <summary>
        /// Creates DeviceInfo object for the current GPU
        /// </summary>
        public DeviceInfo()
        {
            Cv2Gpu.ThrowIfGpuNotAvailable();
            ptr = NativeMethods.gpu_DeviceInfo_new1();
        }

        /// <summary>
        /// Creates DeviceInfo object for the given GPU
        /// </summary>
        /// <param name="deviceId"></param>
        public DeviceInfo(int deviceId)
        {
            Cv2Gpu.ThrowIfGpuNotAvailable();
            ptr = NativeMethods.gpu_DeviceInfo_new2(deviceId);
        }

        /// <summary>
        /// Releases the resources
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
                if(ptr != IntPtr.Zero)
                    NativeMethods.gpu_DeviceInfo_delete(ptr);

                ptr = IntPtr.Zero;
                disposed = true;
            }

            base.Dispose(disposing);
        }


        /// <summary>
        /// 
        /// </summary>
        public int DeviceId
        {
            get
            {
                return NativeMethods.gpu_DeviceInfo_deviceID(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                var buf = new StringBuilder(1 << 16);
                NativeMethods.gpu_DeviceInfo_name(ptr, buf, buf.Capacity);
                return buf.ToString();
            }
        }

        /// <summary>
        /// Return compute capability versions
        /// </summary>
        public int MajorVersion
        {
            get
            {
                return NativeMethods.gpu_DeviceInfo_majorVersion(ptr);
            }
        }

        /// <summary>
        /// Return compute capability versions
        /// </summary>
        public int MinorVersion
        {
            get
            {
                return NativeMethods.gpu_DeviceInfo_minorVersion(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MultiProcessorCount
        {
            get
            {
                return NativeMethods.gpu_DeviceInfo_multiProcessorCount(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public long SharedMemPerBlock
        {
            get
            {
                return (long)NativeMethods.gpu_DeviceInfo_sharedMemPerBlock(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void QueryMemory(out long totalMemory, out long freeMemory)
        {
            ulong t, f;
            NativeMethods.gpu_DeviceInfo_queryMemory(ptr, out t, out f);
            totalMemory = (long)t;
            freeMemory = (long)f;
        }

        /// <summary>
        /// 
        /// </summary>
        public long FreeMemory
        {
            get
            {
                return (long)NativeMethods.gpu_DeviceInfo_freeMemory(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public long TotalMemory
        {
            get
            {
                return (long)NativeMethods.gpu_DeviceInfo_totalMemory(ptr);
            }
        }

        /// <summary>
        /// Checks whether device supports the given feature
        /// </summary>
        /// <param name="featureSet"></param>
        /// <returns></returns>
        public bool Supports(FeatureSet featureSet)
        {
            return NativeMethods.gpu_DeviceInfo_supports(ptr, (int)featureSet) != 0;
        }

        /// <summary>
        /// Checks whether the GPU module can be run on the given device
        /// </summary>
        /// <returns></returns>
        public bool IsCompatible
        {
            get
            {
                return NativeMethods.gpu_DeviceInfo_isCompatible(ptr) != 0;
            }
        }

    }
}
