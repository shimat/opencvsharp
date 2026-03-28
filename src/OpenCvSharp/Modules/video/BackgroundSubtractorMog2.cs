using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// The Base Class for Background/Foreground Segmentation.
/// The class is only used to define the common interface for
/// the whole family of background/foreground segmentation algorithms.
/// </summary>
public class BackgroundSubtractorMOG2 : BackgroundSubtractor
{
    #region Init & Disposal

    /// <summary>
    /// Creates MOG2 Background Subtractor.
    /// </summary>
    /// <param name="history">Length of the history.</param>
    /// <param name="varThreshold">Threshold on the squared Mahalanobis distance between the pixel and the model
    /// to decide whether a pixel is well described by the background model. This parameter does not affect the background update.</param>
    /// <param name="detectShadows">If true, the algorithm will detect shadows and mark them. It decreases the speed a bit,
    /// so if you do not need this feature, set the parameter to false.</param>
    /// <returns></returns>
    public static BackgroundSubtractorMOG2 Create(
        int history = 500, double varThreshold = 16, bool detectShadows = true)
    {
        NativeMethods.HandleException(
            NativeMethods.video_createBackgroundSubtractorMOG2(
                history, varThreshold, detectShadows ? 1 : 0, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.video_Ptr_BackgroundSubtractorMOG2_get(smartPtr, out var rawPtr));
        return new BackgroundSubtractorMOG2(smartPtr, rawPtr);
    }

    private BackgroundSubtractorMOG2(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.video_Ptr_BackgroundSubtractorMOG2_delete(p)))
    { }
    #endregion

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
            NativeMethods.video_BackgroundSubtractorMOG2_apply(CvPtr, image.CvPtr, fgmask.CvPtr, learningRate));
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
            NativeMethods.video_BackgroundSubtractorMOG2_getBackgroundImage(CvPtr, backgroundImage.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(backgroundImage);
        backgroundImage.Fix();
    }

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
                NativeMethods.video_BackgroundSubtractorMOG2_getHistory(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_setHistory(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the number of gaussian components in the background model.
    /// </summary>
    public int NMixtures
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_getNMixtures(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_setNMixtures(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the "background ratio" parameter of the algorithm.
    /// If a foreground pixel keeps semi-constant value for about backgroundRatio\*history frames, it's
    /// considered background and added to the model as a center of a new component. It corresponds to TB
    /// parameter in the paper.
    /// </summary>
    public double BackgroundRatio
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_getBackgroundRatio(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_setBackgroundRatio(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the variance threshold for the pixel-model match.
    /// The main threshold on the squared Mahalanobis distance to decide if the sample is well described by
    /// the background model or not. Related to Cthr from the paper.
    /// </summary>
    public double VarThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_getVarThreshold(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_setVarThreshold(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the variance threshold for the pixel-model match used for new mixture component generation. 
    /// Threshold for the squared Mahalanobis distance that helps decide when a sample is close to the
    /// existing components (corresponds to Tg in the paper). If a pixel is not close to any component, it
    /// is considered foreground or added as a new component. 3 sigma =\> Tg=3\*3=9 is default. A smaller Tg
    /// value generates more components. A higher Tg value may result in a small number of components but they can grow too large.
    /// </summary>
    public double VarThresholdGen
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_getVarThresholdGen(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_setVarThresholdGen(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the initial variance of each gaussian component.
    /// </summary>
    public double VarInit
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_getVarInit(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_setVarInit(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double VarMin
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_getVarMin(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_setVarMin(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double VarMax
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_getVarMax(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_setVarMax(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the complexity reduction threshold.
    /// This parameter defines the number of samples needed to accept to prove the component exists. CT=0.05 
    /// is a default value for all the samples. By setting CT=0 you get an algorithm very similar to the standard Stauffer&amp;Grimson algorithm.
    /// </summary>
    public double ComplexityReductionThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_getComplexityReductionThreshold(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_setComplexityReductionThreshold(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the shadow detection flag.
    /// If true, the algorithm detects shadows and marks them. See createBackgroundSubtractorKNN for details.
    /// </summary>
    public bool DetectShadows
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_getDetectShadows(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_setDetectShadows(CvPtr, value ? 1 : 0));
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
                NativeMethods.video_BackgroundSubtractorMOG2_getShadowValue(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_setShadowValue(CvPtr, value));
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
                NativeMethods.video_BackgroundSubtractorMOG2_getShadowThreshold(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_BackgroundSubtractorMOG2_setShadowThreshold(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    #endregion
}
