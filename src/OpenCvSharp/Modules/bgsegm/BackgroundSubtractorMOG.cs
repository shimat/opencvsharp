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
                history, nMixtures, backgroundRatio, noiseSigma, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.bgsegm_Ptr_BackgroundSubtractorMOG_get(smartPtr, out var rawPtr));
        return new BackgroundSubtractorMOG(smartPtr, rawPtr);
    }

    private BackgroundSubtractorMOG(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.bgsegm_Ptr_BackgroundSubtractorMOG_delete(p)))
    { }

    /// <summary>
    /// 
    /// </summary>
    public int History
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_getHistory(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setHistory(CvPtr, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorMOG_getNMixtures(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setNMixtures(CvPtr, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorMOG_getBackgroundRatio(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setBackgroundRatio(CvPtr, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorMOG_getNoiseSigma(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setNoiseSigma(CvPtr, value));
            GC.KeepAlive(this);
        }
    }
}
