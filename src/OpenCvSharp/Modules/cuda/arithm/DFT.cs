using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class DFT : Algorithm
{
    protected DFT(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p=> NativeMethods.HandleException( NativeMethods.cuda_DFT_delete(p)))
    {
    }

    /// <summary>
    /// Creates implementation for cuda::DFT.
    /// </summary>
    /// <param name="dftSize">Size of the transform.</param>
    /// <param name="flags">Transformation flags (e.g. DftFlags.ComplexOutput).</param>
    public static DFT Create(Size dftSize, DftFlags flags)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createDFT(dftSize, (int)flags, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.cuda_DFT_get(smartPtr, out IntPtr rawPtr));

        return new DFT(smartPtr, rawPtr);
    }

    /// <summary>
    /// Computes a discrete Fourier transform of 1D or 2D array.
    /// </summary>
    /// <param name="src">Source array. Only CV_32FC1 and CV_32FC2 are supported.</param>
    /// <param name="dst">Destination array.</param>
    /// <param name="stream">Stream for the asynchronous version.</param>
    public virtual void Compute(
        OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (src is null) throw new ArgumentNullException(nameof(src));
        if (dst is null) throw new ArgumentNullException(nameof(dst));

        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_DFT_compute(RawPtr, src.CvPtr, dst.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

        dst.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(src);
    }
}
