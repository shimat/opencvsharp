using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class BackgroundSubtractorMOG2 : OpenCvSharp.BackgroundSubtractorMOG2
{
    protected BackgroundSubtractorMOG2(IntPtr smartPtr, IntPtr rawPtr)
           : base(smartPtr, rawPtr) { }

    public static BackgroundSubtractorMOG2 Create(
        int history = 500, double varThreshold = 16, bool detectShadows = true)
    {
        NativeMethods.HandleException(NativeMethods.cuda_createBackgroundSubtractorMOG2(
            history, varThreshold, detectShadows ? 1 : 0, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG2_get(smartPtr, out IntPtr rawPtr));
        return new BackgroundSubtractorMOG2(smartPtr, rawPtr);
    }

    public virtual void Apply(
        OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.OutputArray fgmask,
        double learningRate = -1, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (image is null) throw new ArgumentNullException(nameof(image));
        if (fgmask is null) throw new ArgumentNullException(nameof(fgmask));
        image.ThrowIfDisposed(); fgmask.ThrowIfNotReady(); ThrowIfDisposed();

        NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG2_apply(
            RawPtr, image.CvPtr, fgmask.CvPtr, learningRate, stream?.CvPtr ?? IntPtr.Zero));

        fgmask.Fix(); GC.KeepAlive(this); GC.KeepAlive(image);
    }

    /// <summary>
    /// Updates the background model and computes the foreground mask using a known foreground mask.
    /// </summary>
    public virtual void Apply(
        OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.InputArray knownForegroundMask,
        OpenCvSharp.Cuda.OutputArray fgmask, double learningRate = -1, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (image is null) throw new ArgumentNullException(nameof(image));
        if (knownForegroundMask is null) throw new ArgumentNullException(nameof(knownForegroundMask));
        if (fgmask is null) throw new ArgumentNullException(nameof(fgmask));

        image.ThrowIfDisposed();
        knownForegroundMask.ThrowIfDisposed();
        fgmask.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_BackgroundSubtractorMOG2_apply_withMask(
                RawPtr, image.CvPtr, knownForegroundMask.CvPtr, fgmask.CvPtr, learningRate, stream?.CvPtr ?? IntPtr.Zero));

        fgmask.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(image);
        GC.KeepAlive(knownForegroundMask);
    }

    /// <summary>
    /// Computes a background image with Stream support.
    /// </summary>
    public virtual void GetBackgroundImage(OpenCvSharp.Cuda.OutputArray backgroundImage, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (backgroundImage is null) throw new ArgumentNullException(nameof(backgroundImage));
        backgroundImage.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_BackgroundSubtractorMOG2_getBackgroundImage(
                RawPtr, backgroundImage.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

        backgroundImage.Fix();
        GC.KeepAlive(this);
    }
}
