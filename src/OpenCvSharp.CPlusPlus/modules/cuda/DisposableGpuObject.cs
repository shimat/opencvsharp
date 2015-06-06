using System;

namespace OpenCvSharp.Gpu
{
    /// <summary>
    /// An abstract class in GPU module that implements DisposableCvObject
    /// </summary>
    abstract public class DisposableGpuObject : DisposableCvObject
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        protected DisposableGpuObject()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        protected DisposableGpuObject(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="isEnabledDispose"></param>
        protected DisposableGpuObject(bool isEnabledDispose)
            : base(isEnabledDispose)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose"></param>
        protected DisposableGpuObject(IntPtr ptr, bool isEnabledDispose)
            : base(ptr, isEnabledDispose)
        {
        }

        /// <summary>
        /// Checks whether the opencv_gpu*.dll includes CUDA support.
        /// </summary>
        protected void ThrowIfNotAvailable()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(GetType().Name);
            if (Cv2Gpu.GetCudaEnabledDeviceCount() < 1)
                throw new OpenCvSharpException("Your OpenCV DLL does not support GPU module.");

            if (!IsGpuCompatible)
                throw new OpenCvSharpException("The selected GPU device is not compatible.");
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool IsGpuCompatible
        {
            get
            {
                if (!isGpuAvailable.HasValue)
                {
                    isGpuAvailable = (Cv2Gpu.GetCudaEnabledDeviceCount() >= 1) &&
                                     new DeviceInfo(Cv2Gpu.GetDevice()).IsCompatible;
                }
                return isGpuAvailable.Value;
            }
        }

        private bool? isGpuAvailable = null;
    }
}
