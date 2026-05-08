using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Base class for Super Resolution algorithms.
/// </summary>
public class SuperResolution : Algorithm
{
    #region Init & Disposal

    /// <summary>
    /// Constructor
    /// </summary>
    private SuperResolution(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.superres_Ptr_SuperResolution_delete(p)))
    { }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes. 
    /// </summary>
    /// <param name="ptr"></param>
    internal static SuperResolution FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid FrameSource pointer");

        NativeMethods.HandleException(NativeMethods.superres_Ptr_SuperResolution_get(ptr, out var rawPtr));
        return new SuperResolution(ptr, rawPtr);
    }

    /// <summary>
    /// Create Bilateral TV-L1 Super Resolution.
    /// </summary>
    /// <returns></returns>
    public static SuperResolution CreateBTVL1()
    {
        NativeMethods.HandleException(
            NativeMethods.superres_createSuperResolution_BTVL1(out var ptr));
        return FromPtr(ptr);
    }

    /// <summary>
    /// Create Bilateral TV-L1 Super Resolution.
    /// </summary>
    /// <returns></returns>
    public static SuperResolution CreateBTVL1_CUDA()
    {
        NativeMethods.HandleException(
            NativeMethods.superres_createSuperResolution_BTVL1_CUDA(out var ptr));
        return FromPtr(ptr);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Set input frame source for Super Resolution algorithm.
    /// </summary>
    /// <param name="fs">Input frame source</param>
    public virtual void SetInput(FrameSource fs)
    {
        ThrowIfDisposed();
        if (fs is null)
            throw new ArgumentNullException(nameof(fs));
        fs.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.superres_SuperResolution_setInput(RawPtr, fs.SmartPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(fs);
    }

    /// <summary>
    /// Process next frame from input and return output result.
    /// </summary>
    /// <param name="frame">Output result</param>
    public virtual void NextFrame(OutputArray frame)
    {
        ThrowIfDisposed();
        if (frame is null)
            throw new ArgumentNullException(nameof(frame));
        frame.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.superres_SuperResolution_nextFrame(RawPtr, frame.CvPtr));
        frame.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(frame);
    }
        
    /// <summary>
    /// </summary>
    public virtual void Reset()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.superres_SuperResolution_reset(RawPtr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Clear all inner buffers.
    /// </summary>
    public virtual void CollectGarbage()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.superres_SuperResolution_collectGarbage(RawPtr));
        GC.KeepAlive(this);
    }
        
    /// <summary>
    /// </summary>
    /// <param name="fs"></param>
    protected virtual void InitImpl(FrameSource fs)
    {
    }
        
    /// <summary>
    /// </summary>
    /// <param name="fs"></param>
    /// <param name="output"></param>
    protected virtual void ProcessImpl(FrameSource fs, OutputArray output)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Scale factor
    /// </summary>
    public int Scale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_getScale(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setScale(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Iterations count
    /// </summary>
    public int Iterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_getIterations(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setIterations(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Asymptotic value of steepest descent method
    /// </summary>
    public double Tau
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_getTau(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setTau(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Weight parameter to balance data term and smoothness term
    /// </summary>
    public double Lambda
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_getLambda(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setLambda(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Parameter of spacial distribution in Bilateral-TV
    /// </summary>
    public double Alpha
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_getAlpha(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setAlpha(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Kernel size of Bilateral-TV filter
    /// </summary>
    public int KernelSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_getKernelSize(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setKernelSize(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gaussian blur kernel size
    /// </summary>
    public int BlurKernelSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_getBlurKernelSize(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setBlurKernelSize(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gaussian blur sigma
    /// </summary>
    public double BlurSigma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_getBlurSigma(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setBlurSigma(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Radius of the temporal search area
    /// </summary>
    public int TemporalAreaRadius
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_getTemporalAreaRadius(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setTemporalAreaRadius(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    // TODO
    /*
    /// <summary>
    /// Dense optical flow algorithm
    /// </summary>
    public DenseOpticalFlowExt OpticalFlow
    {
        get
        {
            ThrowIfDisposed();
            var res = NativeMethods.superres_SuperResolution_getOpticalFlow(CvPtr);
            GC.KeepAlive(this);
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.superres_SuperResolution_setOpticalFlow(CvPtr, value);
            GC.KeepAlive(this);
        }
    }
    */

    #endregion

    }
