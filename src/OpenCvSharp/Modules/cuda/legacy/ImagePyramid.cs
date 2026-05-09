using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Image pyramid implementation for CUDA.
    /// </summary>
    public class ImagePyramid : Algorithm
    {
        protected ImagePyramid(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_ImagePyramid_delete(p)))
        {
        }

        /// <summary>
        /// Creates an image pyramid.
        /// </summary>
        /// <param name="img">Source image.</param>
        /// <param name="nLayers">Number of layers. -1 means calculate automatically.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        /// <returns></returns>
        public static ImagePyramid Create(
            OpenCvSharp.Cuda.InputArray img, int nLayers = -1, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (img is null) throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_createImagePyramid(img.CvPtr, nLayers, stream?.CvPtr?? IntPtr.Zero, out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_ImagePyramid_get(smartPtr, out var rawPtr));

            return new ImagePyramid(smartPtr, rawPtr);
        }

        /// <summary>
        /// Gets a specific layer from the pyramid by its size.
        /// </summary>
        /// <param name="outImg">Destination image.</param>
        /// <param name="dsize">Size of the layer to fetch.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public virtual void GetLayer(
            OpenCvSharp.Cuda.OutputArray outImg, Size dsize, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (outImg is null) throw new ArgumentNullException(nameof(outImg));
            outImg.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_ImagePyramid_getLayer(RawPtr, outImg.CvPtr, dsize, stream?.CvPtr ?? IntPtr.Zero));

            outImg.Fix();
            GC.KeepAlive(this);
        }
    }
}
