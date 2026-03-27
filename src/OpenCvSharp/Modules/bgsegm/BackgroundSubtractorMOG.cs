using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Gaussian Mixture-based Backbround/Foreground Segmentation Algorithm
/// </summary>
public class BackgroundSubtractorMOG : BackgroundSubtractor
{
    /// <summary>
    /// Creates mixture-of-gaussian background subtractor
    /// </summary>
    /// <param name="history">Length of the history.</param>
    /// <param name="nMixtures">Number of Gaussian mixtures.</param>
    /// <param name="backgroundRatio">Background ratio.</param>
    /// <param name="noiseSigma">Noise strength (standard deviation of the brightness or each color channel). 0 means some automatic value.</param>
    /// <returns></returns>
    public static BackgroundSubtractorMOG Create(
        int history = 200, int nMixtures = 5, double backgroundRatio = 0.7, double noiseSigma = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.bgsegm_createBackgroundSubtractorMOG(
                history, nMixtures, backgroundRatio, noiseSigma, out var ptr));
        return new BackgroundSubtractorMOG(ptr);
    }

    internal BackgroundSubtractorMOG(IntPtr p)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: true,
            releaseAction: h => NativeMethods.HandleException(NativeMethods.bgsegm_Ptr_BackgroundSubtractorMOG_delete(h))));
    }

    /// <inheritdoc />
    public override void Apply(InputArray image, OutputArray fgmask, double learningRate = -1)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (fgmask is null)
            throw new ArgumentNullException(nameof(fgmask));
        image.ThrowIfDisposed();
        fgmask.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.bgsegm_BackgroundSubtractorMOG_apply(ptr, image.CvPtr, fgmask.CvPtr, learningRate));
        fgmask.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(image);
        GC.KeepAlive(fgmask);
    }

    /// <inheritdoc />
    public override void GetBackgroundImage(OutputArray backgroundImage)
    {
        if (backgroundImage is null)
            throw new ArgumentNullException(nameof(backgroundImage));
        backgroundImage.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.bgsegm_BackgroundSubtractorMOG_getBackgroundImage(ptr, backgroundImage.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(backgroundImage);
        backgroundImage.Fix();
    }

    /// <summary>
    /// 
    /// </summary>
    public int History
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_getHistory(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setHistory(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int NMixtures
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_getNMixtures(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setNMixtures(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double BackgroundRatio
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_getBackgroundRatio(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setBackgroundRatio(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double NoiseSigma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_getNoiseSigma(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setNoiseSigma(ptr, value));
            GC.KeepAlive(this);
        }
    }
}
