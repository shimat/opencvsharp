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
    /// Total number of distinct colors to maintain in histogram.
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
    /// The learning rate of the algorithm. It lies between 0.0 and 1.0. It determines how quickly
    /// features are "forgotten" from histograms.
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
    /// Number of frames used to initialize the background model.
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
    /// The parameter used for quantization of color-space. It is the number of discrete levels in
    /// each channel to be used in histograms.
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
    /// Prior probability that each individual pixel is a background pixel.
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
    /// Kernel radius used for morphological operations.
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
    /// Value of decision threshold. Decision value is the value above which a pixel is determined to be foreground.
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
    /// Status of background model update.
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
    /// Minimum value taken on by pixels in image sequence. Usually 0.
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
    /// Maximum value taken on by pixels in image sequence, e.g. 1.0 or 255.
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
