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
                NativeMethods.bgsegm_BackgroundSubtractorMOG_getHistory(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setHistory(Handle, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorMOG_getNMixtures(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setNMixtures(Handle, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorMOG_getBackgroundRatio(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setBackgroundRatio(Handle, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorMOG_getNoiseSigma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setNoiseSigma(Handle, value));
        }
    }
}
