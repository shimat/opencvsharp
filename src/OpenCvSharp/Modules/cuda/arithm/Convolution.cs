using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class Convolution : Algorithm
{
    protected Convolution(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr,p=> NativeMethods.HandleException(NativeMethods.cuda_Convolution_delete(p)))
    {
    }

    /// <summary>
    /// Creates implementation for cuda::Convolution.
    /// </summary>
    /// <param name="userBlockSize">Block size used for FFT. Default is Size(0,0) for automatic choice.</param>
    public static Convolution Create(Size? userBlockSize = null)
    {
        Size sz = userBlockSize ?? new Size(0, 0);

        NativeMethods.HandleException(NativeMethods.cuda_createConvolution(sz, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.cuda_Convolution_get(smartPtr, out IntPtr rawPtr));

        return new Convolution(smartPtr, rawPtr);
    }

    /// <summary>
    /// Computes the convolution of two images.
    /// </summary>
    /// <param name="image">Source image. Only CV_32FC1 images are supported.</param>
    /// <param name="templ">Convolution kernel. Only CV_32FC1 images are supported.</param>
    /// <param name="result">Destination image.</param>
    /// <param name="conj">Whether to conjugate the second argument or not.</param>
    /// <param name="stream">Stream for the asynchronous version.</param>
    public virtual void Convolve(
        OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.InputArray templ,
        OpenCvSharp.Cuda.OutputArray result, bool conj = false, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (image is null) throw new ArgumentNullException(nameof(image));
        if (templ is null) throw new ArgumentNullException(nameof(templ));
        if (result is null) throw new ArgumentNullException(nameof(result));

        image.ThrowIfDisposed();
        templ.ThrowIfDisposed();
        result.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_Convolution_convolve(
                RawPtr, image.CvPtr, templ.CvPtr, result.CvPtr, conj ? 1 : 0, stream?.CvPtr ?? IntPtr.Zero));

        result.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(image);
        GC.KeepAlive(templ);
    }
}
