using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Base class for Super Resolution algorithms.
/// </summary>
public class SuperResolution : Algorithm
{
    private Ptr? detectorPtr;

    #region Init & Disposal

    /// <summary>
    /// Constructor
    /// </summary>
    protected SuperResolution()
    {
    }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes. 
    /// </summary>
    /// <param name="ptr"></param>
    internal static SuperResolution FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid FrameSource pointer");

        var ptrObj = new Ptr(ptr);
        var obj = new SuperResolution
        {
            detectorPtr = ptrObj,
            ptr = ptrObj.Get()
        };
        return obj;
    }

    /// <inheritdoc />
    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        detectorPtr?.Dispose();
        detectorPtr = null;
        base.DisposeManaged();
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
            NativeMethods.superres_SuperResolution_setInput(ptr, fs.CvPtr));
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
            NativeMethods.superres_SuperResolution_nextFrame(ptr, frame.CvPtr));
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
            NativeMethods.superres_SuperResolution_reset(ptr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Clear all inner buffers.
    /// </summary>
    public virtual void CollectGarbage()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.superres_SuperResolution_collectGarbage(ptr));
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
                NativeMethods.superres_SuperResolution_getScale(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setScale(ptr, value));
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
                NativeMethods.superres_SuperResolution_getIterations(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setIterations(ptr, value));
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
                NativeMethods.superres_SuperResolution_getTau(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setTau(ptr, value));
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
                NativeMethods.superres_SuperResolution_getLambda(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setLambda(ptr, value));
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
                NativeMethods.superres_SuperResolution_getAlpha(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setAlpha(ptr, value));
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
                NativeMethods.superres_SuperResolution_getKernelSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setKernelSize(ptr, value));
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
                NativeMethods.superres_SuperResolution_getBlurKernelSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setBlurKernelSize(ptr, value));
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
                NativeMethods.superres_SuperResolution_getBlurSigma(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setBlurSigma(ptr, value));
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
                NativeMethods.superres_SuperResolution_getTemporalAreaRadius(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.superres_SuperResolution_setTemporalAreaRadius(ptr, value));
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
            var res = NativeMethods.superres_SuperResolution_getOpticalFlow(ptr);
            GC.KeepAlive(this);
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.superres_SuperResolution_setOpticalFlow(ptr, value);
            GC.KeepAlive(this);
        }
    }
    */

    #endregion

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.superres_Ptr_SuperResolution_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.superres_Ptr_SuperResolution_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
