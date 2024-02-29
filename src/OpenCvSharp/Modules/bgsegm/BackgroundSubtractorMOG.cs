using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Gaussian Mixture-based Backbround/Foreground Segmentation Algorithm
/// </summary>
public class BackgroundSubtractorMOG : BackgroundSubtractor
{
    /// <summary>
    /// cv::Ptr&lt;T&gt;
    /// </summary>
    private Ptr? objectPtr;

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

    internal BackgroundSubtractorMOG(IntPtr ptr)
    {
        objectPtr = new Ptr(ptr);
        this.ptr = objectPtr.Get(); 
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        objectPtr?.Dispose();
        objectPtr = null;
        base.DisposeManaged();
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

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.bgsegm_Ptr_BackgroundSubtractorMOG_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.bgsegm_Ptr_BackgroundSubtractorMOG_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
