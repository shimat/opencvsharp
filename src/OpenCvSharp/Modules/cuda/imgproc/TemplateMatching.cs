using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Base class for CUDA template matching.
    /// </summary>
    public class TemplateMatching : Algorithm
    {
        protected TemplateMatching(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_TemplateMatching_delete(p)))
        {
        }

        /// <summary>
        /// Creates implementation for cuda::TemplateMatching.
        /// </summary>
        /// <param name="srcType">Input image type. CV_8UC1 and CV_32FC1 are supported.</param>
        /// <param name="method">Specifies the comparison method.</param>
        /// <param name="userBlockSize">An optional block size optimization.</param>
        /// <returns></returns>
        public static TemplateMatching Create(
            MatType srcType, TemplateMatchModes method, Size? userBlockSize = null)
        {
            Size blockSize = userBlockSize ?? new Size(0, 0);

            NativeMethods.HandleException(
                NativeMethods.cuda_createTemplateMatching((int)srcType, (int)method, blockSize, out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_TemplateMatching_get(smartPtr, out var rawPtr));

            return new TemplateMatching(smartPtr, rawPtr);
        }

        /// <summary>
        /// Computes a proximity map of the template and the image.
        /// </summary>
        /// <param name="image">Source image.</param>
        /// <param name="templ">Template image.</param>
        /// <param name="result">Map of comparison results (CV_32FC1). Result size is (W - w + 1) x (H - h + 1).</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public virtual void Match(
            OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.InputArray templ,
            OpenCvSharp.Cuda.OutputArray result, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (image is null) throw new ArgumentNullException(nameof(image));
            if (templ is null) throw new ArgumentNullException(nameof(templ));
            if (result is null) throw new ArgumentNullException(nameof(result));

            image.ThrowIfDisposed();
            templ.ThrowIfDisposed();
            result.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_TemplateMatching_match(RawPtr, image.CvPtr, templ.CvPtr, result.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

            result.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(templ);
        }
    }
}
