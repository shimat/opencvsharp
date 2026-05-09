using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class CornernessCriteria : Algorithm
{
    protected CornernessCriteria(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_CornernessCriteria_delete(p)))
    {
    }

    /// <summary>
    /// Creates implementation for Harris cornerness criteria.
    /// </summary>
    public static CornernessCriteria CreateHarrisCorner(
        MatType srcType, int blockSize, int ksize, double k, BorderTypes borderType = BorderTypes.Reflect101)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createHarrisCorner((int)srcType, blockSize, ksize, k, (int)borderType, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_CornernessCriteria_get(smartPtr, out var rawPtr));

        return new CornernessCriteria(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates implementation for the minimum eigen value of a 2x2 derivative covariation matrix.
    /// </summary>
    /// <param name="srcType">Input image type.</param>
    /// <param name="blockSize">Neighborhood size.</param>
    /// <param name="ksize">Aperture parameter for the Sobel operator.</param>
    /// <param name="borderType">Pixel extrapolation method.</param>
    /// <returns></returns>
    public static CornernessCriteria CreateMinEigenValCorner(
        MatType srcType, int blockSize, int ksize, BorderTypes borderType = BorderTypes.Reflect101)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createMinEigenValCorner((int)srcType, blockSize, ksize, (int)borderType, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_CornernessCriteria_get(smartPtr, out var rawPtr));

        return new CornernessCriteria(smartPtr, rawPtr);
    }


    /// <summary>
    /// Computes the cornerness score map.
    /// </summary>
    /// <param name="src">Source image.</param>
    /// <param name="dst">Destination score map (CV_32FC1).</param>
    /// <param name="stream">Stream for the asynchronous version.</param>
    public virtual void Compute(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (src is null) 
            throw new ArgumentNullException(nameof(src));
        if (dst is null) 
            throw new ArgumentNullException(nameof(dst));

        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_CornernessCriteria_compute(RawPtr, src.CvPtr, dst.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

        dst.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(src);
    }
}
