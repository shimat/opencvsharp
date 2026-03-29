using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// K nearest neigbours algorithm
/// </summary>
public class BackgroundSubtractorKNN : BackgroundSubtractor
{
    #region Init & Disposal

    /// <summary>
    /// Creates KNN Background Subtractor
    /// </summary>
    /// <param name="history">Length of the history.</param>
    /// <param name="dist2Threshold">Threshold on the squared distance between the pixel and the sample to decide
    /// whether a pixel is close to that sample. This parameter does not affect the background update.</param>
    /// <param name="detectShadows">If true, the algorithm will detect shadows and mark them. It decreases the
    /// speed a bit, so if you do not need this feature, set the parameter to false.</param>
    /// <returns></returns>
    public static BackgroundSubtractorKNN Create(
        int history = 500, double dist2Threshold = 400.0, bool detectShadows = true)
    {
        NativeMethods.HandleException(
            NativeMethods.video_createBackgroundSubtractorKNN(
                history, dist2Threshold, detectShadows ? 1 : 0, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.video_Ptr_BackgroundSubtractorKNN_get(smartPtr, out var rawPtr));
        return new BackgroundSubtractorKNN(smartPtr, rawPtr);
    }

    private BackgroundSubtractorKNN(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.video_Ptr_BackgroundSubtractorKNN_delete(p)))
    { }
    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the number of last frames that affect the background model.
    /// </summary>
    public int History
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_getHistory(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_setHistory(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the number of data samples in the background model
    /// </summary>
    public int NSamples
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_getNSamples(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_setNSamples(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the threshold on the squared distance between the pixel and the sample.
    /// The threshold on the squared distance between the pixel and the sample to decide whether a pixel is close to a data sample.
    /// </summary>
    public double Dist2Threshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_getDist2Threshold(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_setDist2Threshold(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Returns the number of neighbours, the k in the kNN.
    /// K is the number of samples that need to be within dist2Threshold in order to decide that that
    /// pixel is matching the kNN background model.
    /// </summary>
    public int KNNSamples
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_getkNNSamples(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_setkNNSamples(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Returns the shadow detection flag.
    /// If true, the algorithm detects shadows and marks them. See createBackgroundSubtractorKNN for details.
    /// </summary>
    public bool DetectShadows
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_getDetectShadows(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_setDetectShadows(RawPtr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the shadow value.
    /// Shadow value is the value used to mark shadows in the foreground mask. Default value is 127.
    /// Value 0 in the mask always means background, 255 means foreground.
    /// </summary>
    public int ShadowValue
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_getShadowValue(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_setShadowValue(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the shadow threshold.
    /// A shadow is detected if pixel is a darker version of the background. The shadow threshold (Tau in
    /// the paper) is a threshold defining how much darker the shadow can be. Tau= 0.5 means that if a pixel
    /// is more than twice darker then it is not shadow. See Prati, Mikic, Trivedi and Cucchiara,
    /// *Detecting Moving Shadows...*, IEEE PAMI,2003.
    /// </summary>
    public double ShadowThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_getShadowThreshold(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorKNN_setShadowThreshold(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    #endregion
}
