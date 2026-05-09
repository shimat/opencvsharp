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
        #region fastNlMeansDenoising
        /// <summary>
        /// Perform image denoising using Non-local Means Denoising algorithm.
        /// </summary>
        /// <param name="src">Input 8-bit single-channel image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="h">Filter strength.</param>
        /// <param name="searchWindow">Size in pixels of window that is used to compute weights for pixel.</param>
        /// <param name="blockSize">Size in pixels of template patch that is used to compute weights.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void FastNlMeansDenoising(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst,
            float h, int searchWindow = 21, int blockSize = 7, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_fastNlMeansDenoising(src.CvPtr, dst.CvPtr, h, searchWindow, blockSize, ToPtr(stream)));

            dst.Fix();
            GC.KeepAlive(src);
        }

        /// <summary>
        /// Modification of fastNlMeansDenoising function for colored images.
        /// </summary>
        /// <param name="src">Input 8-bit 3-channel image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="hLuminance">Parameter regulating filter strength for luminance component.</param>
        /// <param name="photoRender">The same as hLuminance but for color components.</param>
        /// <param name="searchWindow">Size in pixels of window that is used to compute weights for pixel.</param>
        /// <param name="blockSize">Size in pixels of template patch that is used to compute weights.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void FastNlMeansDenoisingColored(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst,
            float hLuminance, float photoRender, int searchWindow = 21, int blockSize = 7, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_fastNlMeansDenoisingColored(src.CvPtr, dst.CvPtr, hLuminance, photoRender, searchWindow, blockSize, ToPtr(stream)));

            dst.Fix();
            GC.KeepAlive(src);
        }
        #endregion
    }
}
