using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class CornersDetector : Algorithm
{
    protected CornersDetector(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_CornersDetector_delete(p)))
    {
    }

    /// <summary>
    /// Creates implementation for cuda::CornersDetector.
    /// </summary>
    public static CornersDetector Create(
        MatType srcType, int maxCorners = 1000, double qualityLevel = 0.01,
        double minDistance = 0.0, int blockSize = 3, bool useHarrisDetector = false, double harrisK = 0.04)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createGoodFeaturesToTrackDetector(
                (int)srcType, maxCorners, qualityLevel, minDistance, blockSize,
                useHarrisDetector ? 1 : 0, harrisK, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_CornersDetector_get(smartPtr, out var rawPtr));

        return new CornersDetector(smartPtr, rawPtr);
    }

    /// <summary>
    /// Determines strong corners on an image.
    /// </summary>
    /// <param name="image">Input 8-bit or floating-point 32-bit, single-channel image.</param>
    /// <param name="corners">Output vector of detected corners (CV_32FC2 matrix).</param>
    /// <param name="mask">Optional region of interest.</param>
    /// <param name="stream">Stream for the asynchronous version.</param>
    public virtual void Detect(
        OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.OutputArray corners,
        OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (image is null) throw new ArgumentNullException(nameof(image));
        if (corners is null) throw new ArgumentNullException(nameof(corners));

        image.ThrowIfDisposed();
        corners.ThrowIfNotReady();
        ThrowIfDisposed();

        IntPtr maskPtr = mask?.CvPtr ?? IntPtr.Zero;

        NativeMethods.HandleException(
            NativeMethods.cuda_CornersDetector_detect(
                RawPtr, image.CvPtr, corners.CvPtr, maskPtr, stream?.CvPtr ?? IntPtr.Zero));

        corners.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(image);
        if (mask != null) GC.KeepAlive(mask);
    }

    public int MaxCorners
    {
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_CornersDetector_setMaxCorners(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    public double MinDistance
    {
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_CornersDetector_setMinDistance(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

}
