#if ENABLED_CUDA

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Gives information about the given GPU
    /// </summary>
    public sealed class DeviceInfo : DisposableGpuObject
    {
        /// <summary>
        /// Creates DeviceInfo object for the current GPU
        /// </summary>
        public DeviceInfo()
        {
            Cv2.ThrowIfGpuNotAvailable();
            ptr = NativeMethods.cuda_DeviceInfo_new1();
        }

        /// <summary>
        /// Creates DeviceInfo object for the given GPU
        /// </summary>
        /// <param name="deviceId"></param>
        public DeviceInfo(int deviceId)
        {
            Cv2.ThrowIfGpuNotAvailable();
            ptr = NativeMethods.cuda_DeviceInfo_new2(deviceId);
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.cuda_DeviceInfo_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// 
        /// </summary>
        public int DeviceId
        {
            get
            {
                var res = NativeMethods.cuda_DeviceInfo_deviceID(ptr);
                GC.KeepAlive(this);
                return res;
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
                NativeMethods.cuda_DeviceInfo_name(ptr, buf, buf.Capacity);
                GC.KeepAlive(this);
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
                var res = NativeMethods.cuda_DeviceInfo_majorVersion(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Return compute capability versions
        /// </summary>
        public int MinorVersion
        {
            get
            {
                var res = NativeMethods.cuda_DeviceInfo_minorVersion(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MultiProcessorCount
        {
            get
            {
                var res = NativeMethods.cuda_DeviceInfo_multiProcessorCount(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public long SharedMemPerBlock
        {
            get
            {
                var res = (long)NativeMethods.cuda_DeviceInfo_sharedMemPerBlock(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void QueryMemory(out long totalMemory, out long freeMemory)
        {
            ulong t, f;
            NativeMethods.cuda_DeviceInfo_queryMemory(ptr, out t, out f);
            GC.KeepAlive(this);
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
                var res = (long)NativeMethods.cuda_DeviceInfo_freeMemory(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public long TotalMemory
        {
            get
            {
                var res = (long)NativeMethods.cuda_DeviceInfo_totalMemory(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Checks whether device supports the given feature
        /// </summary>
        /// <param name="featureSet"></param>
        /// <returns></returns>
        public bool Supports(FeatureSet featureSet)
        {
            var res = NativeMethods.cuda_DeviceInfo_supports(ptr, (int)featureSet) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Checks whether the GPU module can be run on the given device
        /// </summary>
        /// <returns></returns>
        public bool IsCompatible
        {
            get
            {
                var res = NativeMethods.cuda_DeviceInfo_isCompatible(ptr) != 0;
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanMapHostMemory
        {
            get
            {
                var res =  NativeMethods.cuda_DeviceInfo_canMapHostMemory(ptr) != 0;
                GC.KeepAlive(this);
                return res;
            }
        }
    }
}

#endif
