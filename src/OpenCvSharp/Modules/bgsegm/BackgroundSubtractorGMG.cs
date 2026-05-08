using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Background Subtractor module. Takes a series of images and returns a sequence of mask (8UC1)
/// images of the same size, where 255 indicates Foreground and 0 represents Background.
/// </summary>
public class BackgroundSubtractorGMG : BackgroundSubtractor
{
    /// <summary>
    /// Creates a GMG Background Subtractor
    /// </summary>
    /// <param name="initializationFrames">number of frames used to initialize the background models.</param>
    /// <param name="decisionThreshold">Threshold value, above which it is marked foreground, else background.</param>
    /// <returns></returns>
    public static BackgroundSubtractorGMG Create(
        int initializationFrames = 120, double decisionThreshold = 0.8)
    {
        NativeMethods.HandleException(
            NativeMethods.bgsegm_createBackgroundSubtractorGMG(
                initializationFrames, decisionThreshold, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.bgsegm_Ptr_BackgroundSubtractorGMG_get(smartPtr, out var rawPtr));
        return new BackgroundSubtractorGMG(smartPtr, rawPtr);
    }

    private BackgroundSubtractorGMG(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.bgsegm_Ptr_BackgroundSubtractorGMG_delete(p)))
    { }

    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public int MaxFeatures
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getMaxFeatures(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMaxFeatures(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double DefaultLearningRate
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int NumFrames
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getNumFrames(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setNumFrames(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int QuantizationLevels
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getQuantizationLevels(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setQuantizationLevels(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double BackgroundPrior
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getBackgroundPrior(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setBackgroundPrior(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int SmoothingRadius
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getSmoothingRadius(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setSmoothingRadius(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double DecisionThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getDecisionThreshold(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setDecisionThreshold(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool UpdateBackgroundModel
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel(RawPtr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double MinVal
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getMinVal(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMinVal(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double MaxVal
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getMaxVal(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMaxVal(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    #endregion
}
