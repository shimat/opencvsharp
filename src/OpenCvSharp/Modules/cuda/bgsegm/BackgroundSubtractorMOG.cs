using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class BackgroundSubtractorMOG : BackgroundSubtractor
{
    protected BackgroundSubtractorMOG(IntPtr smartPtr, IntPtr rawPtr)
           : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG_delete(p))) { }

    public static BackgroundSubtractorMOG Create(
          int history = 200, int nmixtures = 5, double backgroundRatio = 0.7, double noiseSigma = 0)
    {
        NativeMethods.HandleException(NativeMethods.cuda_createBackgroundSubtractorMOG(
            history, nmixtures, backgroundRatio, noiseSigma, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG_get(smartPtr, out IntPtr rawPtr));
        return new BackgroundSubtractorMOG(smartPtr, rawPtr);
    }

    public virtual void Apply(
            OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.OutputArray fgmask,
            double learningRate = -1, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (image is null) throw new ArgumentNullException(nameof(image));
        if (fgmask is null) throw new ArgumentNullException(nameof(fgmask));
        image.ThrowIfDisposed(); fgmask.ThrowIfNotReady(); ThrowIfDisposed();

        NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG_apply(
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
            NativeMethods.cuda_BackgroundSubtractorMOG_apply_withMask(
                RawPtr, image.CvPtr, knownForegroundMask.CvPtr, fgmask.CvPtr, learningRate,stream?.CvPtr??IntPtr.Zero));

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
            NativeMethods.cuda_BackgroundSubtractorMOG_getBackgroundImage(
                RawPtr, backgroundImage.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

        backgroundImage.Fix();
        GC.KeepAlive(this);
    }

    public double BackgroundRatio
    {
        get { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG_getBackgroundRatio(RawPtr, out double val)); GC.KeepAlive(this); return val; }
        set { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG_setBackgroundRatio(RawPtr, value)); GC.KeepAlive(this); }
    }

    public int History
    {
        get { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG_getHistory(RawPtr, out int val)); GC.KeepAlive(this); return val; }
        set { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG_setHistory(RawPtr, value)); GC.KeepAlive(this); }
    }

    public int NMixtures
    {
        get { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG_getNMixtures(RawPtr, out int val)); GC.KeepAlive(this); return val; }
        set { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG_setNMixtures(RawPtr, value)); GC.KeepAlive(this); }
    }

    public double NoiseSigma
    {
        get { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG_getNoiseSigma(RawPtr, out double val)); GC.KeepAlive(this); return val; }
        set { ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_BackgroundSubtractorMOG_setNoiseSigma(RawPtr, value)); GC.KeepAlive(this); }
    }
}
