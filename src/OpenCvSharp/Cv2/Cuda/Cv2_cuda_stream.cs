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
        #region WrapStream

        /// <summary>
        /// Creates a Stream object from an existing CUDA Runtime API stream handle (cudaStream_t).
        /// </summary>
        /// <param name="cudaStreamAddress">The memory address of the existing cudaStream_t.</param>
        /// <returns>A new OpenCV CUDA Stream object.</returns>
        public static OpenCvSharp.Cuda.Stream WrapStream(IntPtr cudaStreamAddress)
        {
            if (cudaStreamAddress == IntPtr.Zero)
                throw new ArgumentNullException(nameof(cudaStreamAddress));

            NativeMethods.HandleException(
                NativeMethods.cuda_wrapStream(cudaStreamAddress, out var ptr));

            // Assuming your Stream class has a constructor that takes a native pointer
            return new OpenCvSharp.Cuda.Stream(ptr);
        }

        #endregion
    }
}
