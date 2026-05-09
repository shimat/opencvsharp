using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Internal;


namespace OpenCvSharp;

public static partial class Cv2
{
    public static partial class Cuda
    {
        #region ConvertFp16
        /// <summary>
        /// Converts an array to half precision floating number.
        /// </summary>
        /// <remarks>
        /// OpenCV CUDA does NOT consistently use CV_16F for convertFp16 outputs across bindings
        /// </remarks>
        public static void ConvertFp16(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_convertFp16(src.CvPtr, dst.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region CreateContinuous

        /// <summary>
        /// Creates continuous GPU matrix
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type.</param>
        /// <param name="m"></param>
        public static void CreateContinuous(int rows, int cols, MatType type, OpenCvSharp.Cuda.OutputArray m)
        {
            ThrowIfGpuNotAvailable();
            if (m is null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.cuda_createContinuous1(rows, cols, (int)type, m.CvPtr);
            GC.KeepAlive(m);
        }

        /// <summary>
        /// Creates continuous GPU matrix
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type.</param>
        /// <returns></returns>
        public static OpenCvSharp.Cuda.OutputArray CreateContinuous(int rows, int cols, MatType type)
        {
            ThrowIfGpuNotAvailable();
            NativeMethods.HandleException(NativeMethods.cuda_createContinuous2(rows, cols, (int)type, out IntPtr ret));
            return new GpuMat(ret);
        }

        /// <summary>
        /// Creates continuous GPU matrix
        /// </summary>
        /// <param name="size">Number of rows and columns in a 2D array.</param>
        /// <param name="type">Array type.</param>
        /// <param name="m"></param>
        public static void CreateContinuous(Size size, MatType type, OpenCvSharp.Cuda.OutputArray m)
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
        public static OpenCvSharp.Cuda.OutputArray CreateContinuous(Size size, MatType type)
        {
            ThrowIfGpuNotAvailable();
            return CreateContinuous(size.Height, size.Width, type);
        }


        #endregion

        #region CreateGpuMatFromCudaMemory

        /// <summary>
        /// Creates a GpuMat from existing GPU memory without copying data.
        /// </summary>
        /// <remarks>
        /// GpuMat does NOT take ownership of this memory (it won't cudaFree it)
        /// </remarks>
        /// <param name="rows">Number of rows.</param>
        /// <param name="cols">Number of columns.</param>
        /// <param name="type">Matrix type (e.g., MatType.CV_8UC1).</param>
        /// <param name="cudaMemoryAddress">The device memory address (pointer to GPU RAM).</param>
        /// <param name="step">Row pitch in bytes. Use 0 for AUTO_STEP.</param>
        /// <returns>A GpuMat header wrapping the external memory.</returns>
        public static GpuMat CreateGpuMatFromCudaMemory(int rows, int cols, MatType type, IntPtr cudaMemoryAddress, ulong step = 0)
        {
            if (cudaMemoryAddress == IntPtr.Zero) 
                throw new ArgumentNullException(nameof(cudaMemoryAddress));

            NativeMethods.HandleException(
                NativeMethods.cuda_createGpuMatFromCudaMemory(rows, cols, type.Value, cudaMemoryAddress, (UIntPtr)step, out var ptr));

            return new GpuMat(ptr);
        }

        /// <summary>
        /// Creates a GpuMat from existing GPU memory without copying data.
        /// </summary>
        public static GpuMat CreateGpuMatFromCudaMemory(Size size, MatType type, IntPtr cudaMemoryAddress, ulong step = 0)
        {
            return CreateGpuMatFromCudaMemory(size.Height, size.Width, type, cudaMemoryAddress, step);
        }

        #endregion

        #region Device

        /// <summary>
        /// Checks whether the current device supports the given feature.
        /// </summary>
        /// <param name="featureSet">Feature set to check.</param>
        /// <returns>True if supported.</returns>
        public static bool DeviceSupports(FeatureSet featureSet)
        {
            ThrowIfGpuNotAvailable();

            NativeMethods.HandleException(
                NativeMethods.cuda_deviceSupports((int)featureSet, out var ret));

            return ret != 0;
        }

        /// <summary>
        /// Returns the number of installed CUDA-enabled devices.
        /// Use this function before any other GPU functions calls. 
        /// If OpenCV is compiled without GPU support, this function returns 0.
        /// </summary>
        /// <returns></returns>
        public static int GetCudaEnabledDeviceCount()
        {
            NativeMethods.HandleException(NativeMethods.cuda_getCudaEnabledDeviceCount(out int res));
            return res;
        }

        /// <summary>
        /// Returns the current device index set by SetDevice() or initialized by default.
        /// </summary>
        /// <returns></returns>
        public static int GetDevice()
        {
            ThrowIfGpuNotAvailable();
            NativeMethods.HandleException(NativeMethods.cuda_getDevice(out int res));
            return res;
        }

        /// <summary>
        /// Sets a device and initializes it for the current thread.
        /// </summary>
        /// <param name="device">System index of a GPU device starting with 0.</param>
        /// <returns></returns>
        public static int SetDevice(int device)
        {
            ThrowIfGpuNotAvailable();
            NativeMethods.HandleException(NativeMethods.cuda_getDevice(out int res));
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public static void PrintCudaDeviceInfo(int device)
        {
            ThrowIfGpuNotAvailable();
            NativeMethods.HandleException(NativeMethods.cuda_printCudaDeviceInfo(device));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public static void PrintShortCudaDeviceInfo(int device)
        {
            ThrowIfGpuNotAvailable();
            NativeMethods.HandleException(NativeMethods.cuda_printShortCudaDeviceInfo(device));
        }

        /// <summary>
        /// Explicitly destroys and cleans up all resources associated with the current device in the current process.
        /// Any subsequent API call to this device will reinitialize the device.
        /// </summary>
        public static void ResetDevice()
        {
            ThrowIfGpuNotAvailable();
            NativeMethods.HandleException(NativeMethods.cuda_resetDevice());
        }
        #endregion

        #region EnsureSizeIsEnough

        /// <summary>
        /// Ensures that size of the given matrix is not less than (rows, cols) size
        /// and matrix type is match specified one too
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type.</param>
        /// <param name="m"></param>
        public static void EnsureSizeIsEnough(int rows, int cols, MatType type, OpenCvSharp.Cuda.OutputArray m)
        {
            ThrowIfGpuNotAvailable();
            if (m is null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.cuda_ensureSizeIsEnough(rows, cols, (int)type, m.CvPtr);
            GC.KeepAlive(m);
        }

        /// <summary>
        /// Ensures that size of the given matrix is not less than (rows, cols) size
        /// and matrix type is match specified one too
        /// </summary>
        /// <param name="size">Number of rows and columns in a 2D array.</param>
        /// <param name="type">Array type.</param>
        /// <param name="m"></param>
        public static void EnsureSizeIsEnough(Size size, MatType type, OpenCvSharp.Cuda.OutputArray m)
        {
            ThrowIfGpuNotAvailable();
            EnsureSizeIsEnough(size.Height, size.Width, type, m);
        }

        #endregion

        #region pageLocked

        /// <summary>
        /// Page-locks the matrix m memory and maps it for the device(s)
        /// </summary>
        /// <param name="m"></param>
        public static void RegisterPageLocked(Mat m)
        {
            ThrowIfGpuNotAvailable();
            if (m is null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.HandleException(NativeMethods.cuda_registerPageLocked(m.CvPtr));
            GC.KeepAlive(m);
        }

        /// <summary>
        /// Unmaps the memory of matrix m, and makes it pageable again.
        /// </summary>
        /// <param name="m"></param>
        public static void UnregisterPageLocked(Mat m)
        {
            ThrowIfGpuNotAvailable();
            if (m is null)
                throw new ArgumentNullException(nameof(m));
           NativeMethods.HandleException(NativeMethods.cuda_unregisterPageLocked(m.CvPtr));
            GC.KeepAlive(m);
        }

        #endregion

        #region BufferPool
        /// <summary>
        /// Sets the parameters of the buffer pool for a specific device.
        /// </summary>
        /// <param name="deviceId">Device ID.</param>
        /// <param name="stackSize">Size of one stack in bytes.</param>
        /// <param name="stackCount">Number of stacks.</param>
        public static void SetBufferPoolConfig(int deviceId, ulong stackSize, int stackCount)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_setBufferPoolConfig(deviceId, (UIntPtr)stackSize, stackCount));
        }

        /// <summary>
        /// Enables or disables the buffer pool.
        /// This must be called before any Stream is created to take effect.
        /// </summary>
        /// <param name="on">True to enable, false to disable.</param>
        public static void SetBufferPoolUsage(bool on)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_setBufferPoolUsage(on ? 1 : 0));
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
