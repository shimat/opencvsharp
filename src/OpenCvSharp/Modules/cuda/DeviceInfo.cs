#if ENABLED_CUDA

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Internal;

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
            Cv2.Cuda.ThrowIfGpuNotAvailable();
            NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_new1(out IntPtr p));
            InitSafeHandle(p);
        }

        /// <summary>
        /// Creates DeviceInfo object for the given GPU
        /// </summary>
        /// <param name="deviceId"></param>
        public DeviceInfo(int deviceId)
        {
            Cv2.Cuda.ThrowIfGpuNotAvailable();
            NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_new2(deviceId, out IntPtr p));
            InitSafeHandle(p);
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>

        private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
        {
            SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
                static h => NativeMethods.cuda_DeviceInfo_delete(h)));
        }

        /// <summary>
        /// Returns the number of asynchronous engines.
        /// </summary>
        public int AsyncEngineCount
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_asyncEngineCount(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
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
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_canMapHostMemory(CvPtr, out int res));
                GC.KeepAlive(this);
                return res != 0;
            }
        }

        /// <summary>
        /// clock frequency in kilohertz.
        /// </summary>
        public int ClockRate
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_clockRate(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Gets the compute mode of the device.
        /// </summary>
        public ComputeMode ComputeMode
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_computeMode(ptr, out var ret));
                GC.KeepAlive(this);
                return (ComputeMode)ret;
            }
        }

        /// <summary>
        /// returns true if the device can possibly execute multiple kernels concurrently.
        /// </summary>
        public bool ConcurrentKernels
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_concurrentKernels(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns system index of the CUDA device starting with 0.
        /// </summary>
        public int DeviceID
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_deviceID(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Returns true if the device has ECC (Error Correction Code) support enabled.
        /// Typically only found on Tesla and some Quadro cards.
        /// </summary>
        public bool ECCEnabled
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_ECCEnabled(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns the amount of free memory on the device in bytes.
        /// </summary>
        public ulong FreeMemory
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_freeMemory(ptr, out var ret));
                GC.KeepAlive(this);
                return (ulong)ret;
            }
        }

        /// <summary>
        /// Returns true if the device is an integrated GPU (shares system memory).
        /// Returns false for discrete (dedicated) GPUs.
        /// </summary>
        public bool Integrated
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_integrated(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
        }

        /// <summary>
        /// Checks if the CUDA module and device are compatible.
        /// This checks if the GPU compute capability is supported by the OpenCV binary.
        /// </summary>
        public bool IsCompatible
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_isCompatible(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns true if there is a run time limit on kernels. 
        /// Usually true if the GPU is also driving a display (Windows TDR).
        /// </summary>
        public bool KernelExecTimeoutEnabled
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_kernelExecTimeoutEnabled(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
        }

        /// <summary>
        /// The size of the L2 cache in bytes.
        /// </summary>
        public int L2CacheSize
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_l2CacheSize(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// The major compute capability version. (e.g. '8' for Ampere).
        /// </summary>
        public int MajorVersion
        {
            get
            {
                ThrowIfNotAvailable();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_majorVersion(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// The maximum size of each dimension of a grid.
        /// </summary>
        public Vec3i MaxGridSize
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_maxGridSize(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Maximum 1D surface size.
        /// </summary>
        public int MaxSurface1D
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxSurface1D(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Maximum 1D layered surface dimensions. (width, layers)
        /// </summary>
        public Vec2i MaxSurface1DLayered
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxSurface1DLayered(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Maximum 2D surface dimensions. (width, height)
        /// </summary>
        public Vec2i MaxSurface2D
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxSurface2D(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Maximum 2D layered surface dimensions. (width, height, layers)
        /// </summary>
        public Vec3i MaxSurface2DLayered
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxSurface2DLayered(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Maximum 3D surface dimensions. (width, height, depth)
        /// </summary>
        public Vec3i MaxSurface3D
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxSurface3D(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Maximum Cubemap surface dimensions.
        /// </summary>
        public int MaxSurfaceCubemap
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxSurfaceCubemap(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Maximum Cubemap layered surface dimensions. (width, layers)
        /// </summary>
        public Vec2i MaxSurfaceCubemapLayered
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxSurfaceCubemapLayered(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// maximum 1D texture size
        /// </summary>
        public int MaxTexture1D
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxTexture1D(ptr, out var ret)); 
                GC.KeepAlive(this); 
                return ret; 
            }
        }

        /// <summary>
        /// maximum 1D layered texture dimensions
        /// </summary>
        public Vec2i MaxTexture1DLayered
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxTexture1DLayered(ptr, out var ret)); 
                GC.KeepAlive(this); 
                return ret; 
            }
        }

        /// <summary>
        /// maximum size for 1D textures bound to linear memory 
        /// </summary>
        public int MaxTexture1DLinear
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxTexture1DLinear(ptr, out var ret)); 
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// maximum 1D mipmapped texture size
        /// </summary>
        public int MaxTexture1DMipmap
        {
            get
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxTexture1DMipmap(ptr, out var ret));
                GC.KeepAlive(this); 
                return ret; 
            }
        }

        /// <summary>
        /// maximum 2D texture dimensions
        /// </summary>
        public Vec2i MaxTexture2D
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxTexture2D(ptr, out var ret)); 
                GC.KeepAlive(this); 
                return ret; 
            }
        }

        /// <summary>
        /// maximum 2D texture dimensions if texture gather operations have to be performed
        /// </summary>
        public Vec2i MaxTexture2DGather
        {
            get 
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxTexture2DGather(ptr, out var ret)); 
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// maximum 2D layered texture dimensions
        /// </summary>
        public Vec3i MaxTexture2DLayered
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxTexture2DLayered(ptr, out var ret)); 
                GC.KeepAlive(this); 
                return ret; 
            }
        }

        /// <summary>
        /// maximum dimensions (width, height, pitch) for 2D textures bound to pitched memory
        /// </summary>
        public Vec3i MaxTexture2DLinear
        {
            get { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxTexture2DLinear(ptr, out var ret)); 
                GC.KeepAlive(this); 
                return ret; 
            }
        }

        /// <summary>
        /// maximum 2D mipmapped texture dimensions
        /// </summary>
        public Vec2i MaxTexture2DMipmap
        {
            get { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxTexture2DMipmap(ptr, out var ret)); 
                GC.KeepAlive(this); 
                return ret; 
            }
        }

        /// <summary>
        /// maximum 3D texture dimensions
        /// </summary>
        public Vec3i MaxTexture3D
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxTexture3D(ptr, out var ret)); 
                GC.KeepAlive(this); 
                return ret; 
            }
        }

        /// <summary>
        /// Maximum Cubemap texture dimensions.
        /// </summary>
        public int MaxTextureCubemap
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxTextureCubemap(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Maximum Cubemap layered texture dimensions. (width, layers)
        /// </summary>
        public Vec2i MaxTextureCubemapLayered
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxTextureCubemapLayered(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Maximum size of each dimension of a block (X, Y, Z).
        /// </summary>
        public Vec3i MaxThreadsDim
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxThreadsDim(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Maximum number of threads per block.
        /// </summary>
        public int MaxThreadsPerBlock
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxThreadsPerBlock(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Maximum number of resident threads per multiprocessor.
        /// </summary>
        public int MaxThreadsPerMultiProcessor
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_maxThreadsPerMultiProcessor(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Global memory bus width in bits.
        /// </summary>
        public int MemoryBusWidth
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_memoryBusWidth(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Peak memory clock frequency in kilohertz.
        /// </summary>
        public int MemoryClockRate
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_memoryClockRate(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Maximum pitch in bytes allowed by memory copies.
        /// </summary>
        public ulong MemPitch
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_memPitch(ptr, out var ret));
                GC.KeepAlive(this);
                return (ulong)ret;
            }
        }

        /// <summary>
        /// Minor compute capability version. (e.g. '6' for Compute 8.6).
        /// </summary>
        public int MinorVersion
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_minorVersion(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Number of Multiprocessors (SMs) on the device.
        /// </summary>
        public int MultiProcessorCount
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_multiProcessorCount(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// ASCII string identifying the device (e.g., "NVIDIA GeForce RTX 3080").
        /// </summary>
        public string Name
        {
            get
            {
                var buf = new StringBuilder(1 << 16);
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_name(CvPtr, buf, buf.Capacity));
                GC.KeepAlive(this);
                return buf.ToString();
            }
        }

        /// <summary>
        /// PCI bus ID of the device.
        /// </summary>
        public int PciBusID
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_pciBusID(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// PCI device ID of the device.
        /// </summary>
        public int PciDeviceID
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_pciDeviceID(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// PCI domain ID of the device.
        /// </summary>
        public int PciDomainID
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_pciDomainID(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Gets the total and free device memory in bytes.
        /// </summary>
        /// <param name="totalMemory">Total memory available on the device.</param>
        /// <param name="freeMemory">Currently free memory on the device.</param>
        public void QueryMemory(out long totalMemory, out long freeMemory)
        {
            ulong t, f;
            NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_queryMemory(CvPtr, out t, out f));
            GC.KeepAlive(this);
            totalMemory = (long)t;
            freeMemory = (long)f;
        }

        /// <summary>
        /// The number of 32-bit registers available per block.
        /// </summary>
        public int RegsPerBlock
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_regsPerBlock(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// The amount of shared memory available per block in bytes.
        /// </summary>
        public ulong SharedMemPerBlock
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_sharedMemPerBlock(CvPtr, out ulong res));
                GC.KeepAlive(this);
                return (ulong)res;
            }
        }

        /// <summary>
        /// Checks whether the device supports the given feature.
        /// </summary>
        /// <param name="featureSet">The feature set to check.</param>
        /// <returns>True if supported.</returns>
        public bool Supports(FeatureSet featureSet)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_supports(CvPtr, (int)featureSet, out int res));
            GC.KeepAlive(this);
            return res != 0;
        }

        /// <summary>
        /// Alignment requirements for surfaces.
        /// </summary>
        public ulong SurfaceAlignment
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_surfaceAlignment(ptr, out var ret));
                GC.KeepAlive(this);
                return (ulong)ret;
            }
        }

        /// <summary>
        /// Returns true if the device is a Tesla device using the TCC (NVIDIA Tesla Compute Cluster) driver.
        /// Returns false for devices using the WDDM (Windows Display Driver Model) driver.
        /// </summary>
        public bool TccDriver
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_tccDriver(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
        }

        /// <summary>
        /// Alignment requirement for textures. 
        /// Base addresses that are texture-aligned can be accessed more efficiently.
        /// </summary>
        public ulong TextureAlignment
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_textureAlignment(ptr, out var ret));
                GC.KeepAlive(this);
                return (ulong)ret;
            }
        }

        /// <summary>
        /// Pitch alignment requirement for texture references bound to pitched memory.
        /// </summary>
        public ulong TexturePitchAlignment
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_texturePitchAlignment(ptr, out var ret));
                GC.KeepAlive(this);
                return (ulong)ret;
            }
        }


        /// <summary>
        /// Constant memory available on the device in bytes. Typically 64 KB.
        /// </summary>
        public long TotalConstMem
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_totalConstMem(ptr, out long ret));
                GC.KeepAlive(this);
                return (long)ret;
            }
        }

        /// <summary>
        /// Global memory available on the device in bytes (Total VRAM).
        /// </summary>
        public long TotalGlobalMem
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_totalGlobalMem(ptr, out long ret));
                GC.KeepAlive(this);
                return (long)ret;
            }
        }

        /// <summary>
        /// Total memory available on the device in bytes.
        /// </summary>
        public long TotalMemory
        {
            get
            {
                NativeMethods.HandleException(NativeMethods.cuda_DeviceInfo_totalMemory(CvPtr, out long res));
                GC.KeepAlive(this);
                return (long)res;
            }
        }

        /// <summary>
        /// Returns true if the device shares a unified address space with the host.
        /// </summary>
        public bool UnifiedAddressing
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_unifiedAddressing(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
        }

        /// <summary>
        /// The warp size in threads. This is fixed at 32 for all current NVIDIA architectures.
        /// </summary>
        public int WarpSize
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_DeviceInfo_warpSize(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }


















    }
}

#endif
