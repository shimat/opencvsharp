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
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getMaxFeatures(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMaxFeatures(Handle, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate(Handle, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getNumFrames(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setNumFrames(Handle, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getQuantizationLevels(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setQuantizationLevels(Handle, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getBackgroundPrior(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setBackgroundPrior(Handle, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getSmoothingRadius(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setSmoothingRadius(Handle, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getDecisionThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setDecisionThreshold(Handle, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel(Handle, value ? 1 : 0));
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
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getMinVal(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMinVal(Handle, value));
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
                NativeMethods.bgsegm_BackgroundSubtractorGMG_getMaxVal(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMaxVal(Handle, value));
        }
    }

    #endregion
}
