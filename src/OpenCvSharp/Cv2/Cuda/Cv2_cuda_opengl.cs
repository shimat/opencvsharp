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
        #region OpenGL Device
        /// <summary>
        /// Sets a CUDA device and initializes it for the current thread with OpenGL interoperability.
        /// This must be called before any other CUDA calls on the current thread.
        /// </summary>
        /// <param name="device">Device ID.</param>
        public static void SetGlDevice(int device = 0)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_setGlDevice(device));
        }

        #endregion
    }
}
