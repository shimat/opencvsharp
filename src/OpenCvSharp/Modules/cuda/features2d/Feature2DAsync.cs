using System;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Abstract base class for CUDA-accelerated 2D feature detectors and descriptor extractors.
    /// </summary>
    public abstract class Feature2DAsync : Algorithm
    {
        protected Feature2DAsync(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> deleteAction)
            : base(smartPtr, rawPtr, deleteAction)
        {
        }

        /// <summary>
        /// Detects keypoints in an image asynchronously.
        /// </summary>
        public virtual void DetectAsync(OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.OutputArray keypoints, OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (image is null) throw new ArgumentNullException(nameof(image));
            if (keypoints is null) throw new ArgumentNullException(nameof(keypoints));
            image.ThrowIfDisposed();
            keypoints.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_Feature2DAsync_detectAsync(
                    RawPtr, image.CvPtr, keypoints.CvPtr, mask?.CvPtr ?? IntPtr.Zero, stream?.CvPtr ?? IntPtr.Zero));

            keypoints.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// Computes descriptors for a set of keypoints asynchronously.
        /// </summary>
        public virtual void ComputeAsync(
            OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.InputArray keypoints,
            OpenCvSharp.Cuda.OutputArray descriptors, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (image is null) throw new ArgumentNullException(nameof(image));
            if (keypoints is null) throw new ArgumentNullException(nameof(keypoints));
            if (descriptors is null) throw new ArgumentNullException(nameof(descriptors));
            image.ThrowIfDisposed();
            keypoints.ThrowIfDisposed();
            descriptors.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_Feature2DAsync_computeAsync(
                    RawPtr, image.CvPtr, keypoints.CvPtr, descriptors.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

            descriptors.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(keypoints);
        }

        /// <summary>
        /// Detects keypoints and computes their descriptors asynchronously.
        /// </summary>
        public virtual void DetectAndComputeAsync(
            OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.InputArray? mask,
            OpenCvSharp.Cuda.OutputArray keypoints, OpenCvSharp.Cuda.OutputArray descriptors,
            bool useProvidedKeypoints = false, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (image is null) throw new ArgumentNullException(nameof(image));
            if (keypoints is null) throw new ArgumentNullException(nameof(keypoints));
            if (descriptors is null) throw new ArgumentNullException(nameof(descriptors));
            image.ThrowIfDisposed();
            keypoints.ThrowIfNotReady();
            descriptors.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_Feature2DAsync_detectAndComputeAsync(
                    RawPtr, image.CvPtr, mask?.CvPtr ?? IntPtr.Zero, keypoints.CvPtr, descriptors.CvPtr,
                    useProvidedKeypoints ? 1 : 0, stream?.CvPtr ?? IntPtr.Zero));

            keypoints.Fix();
            descriptors.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// Converts keypoints array from internal representation (GpuMat) to standard C# array.
        /// </summary>
        public virtual KeyPoint[] Convert(OpenCvSharp.Cuda.InputArray gpuKeypoints)
        {
            if (gpuKeypoints is null) throw new ArgumentNullException(nameof(gpuKeypoints));
            gpuKeypoints.ThrowIfDisposed();
            ThrowIfDisposed();

            using var keypointsVec = new VectorOfKeyPoint();

            NativeMethods.HandleException(
                NativeMethods.cuda_Feature2DAsync_convert(RawPtr, gpuKeypoints.CvPtr, keypointsVec.CvPtr));

            GC.KeepAlive(this);
            GC.KeepAlive(gpuKeypoints);

            return keypointsVec.ToArray();
        }
    }
}
