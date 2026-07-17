using OpenCvSharp.Internal;

namespace OpenCvSharp.OptFlow;

/// <summary>
/// Fast dense optical flow computation based on robust local optical flow (RLOF) algorithms and
/// sparse-to-dense interpolation scheme.
/// </summary>
public class DenseRLOFOpticalFlow : DenseOpticalFlow
{
    private DenseRLOFOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.optflow_Ptr_DenseRLOFOpticalFlow_delete(p)))
    {
    }

    /// <summary>
    /// Creates an instance of optflow::DenseRLOFOpticalFlow.
    /// </summary>
    /// <param name="rlofParam">See <see cref="RLOFOpticalFlowParameter"/>. Uses the algorithm's defaults when null.</param>
    /// <param name="forwardBackwardThreshold">See <see cref="ForwardBackward"/>.</param>
    /// <param name="gridStep">See <see cref="GridStep"/>.</param>
    /// <param name="interpType">See <see cref="Interpolation"/>.</param>
    /// <param name="epicK">See <see cref="EpicK"/>.</param>
    /// <param name="epicSigma">See <see cref="EpicSigma"/>.</param>
    /// <param name="epicLambda">See <see cref="EpicLambda"/>.</param>
    /// <param name="ricSpSize">See <see cref="RicSpSize"/>.</param>
    /// <param name="ricSlicType">See <see cref="RicSlicType"/>.</param>
    /// <param name="usePostProc">See <see cref="UsePostProc"/>.</param>
    /// <param name="fgsLambda">See <see cref="FgsLambda"/>.</param>
    /// <param name="fgsSigma">See <see cref="FgsSigma"/>.</param>
    /// <param name="useVariationalRefinement">See <see cref="UseVariationalRefinement"/>.</param>
    /// <returns></returns>
    public static DenseRLOFOpticalFlow Create(
        RLOFOpticalFlowParameter? rlofParam = null,
        float forwardBackwardThreshold = 1.0f,
        Size? gridStep = null,
        InterpolationType interpType = InterpolationType.EPIC,
        int epicK = 128,
        float epicSigma = 0.05f,
        float epicLambda = 999.0f,
        int ricSpSize = 15,
        int ricSlicType = 100,
        bool usePostProc = true,
        float fgsLambda = 500.0f,
        float fgsSigma = 1.5f,
        bool useVariationalRefinement = false)
    {
        rlofParam?.ThrowIfDisposed();
        var actualGridStep = gridStep ?? new Size(6, 6);

        NativeMethods.HandleException(
            NativeMethods.optflow_DenseRLOFOpticalFlow_create(
                rlofParam?.SmartPtr ?? IntPtr.Zero, forwardBackwardThreshold, actualGridStep, (int)interpType,
                epicK, epicSigma, epicLambda, ricSpSize, ricSlicType,
                usePostProc ? 1 : 0, fgsLambda, fgsSigma, useVariationalRefinement ? 1 : 0,
                out var smartPtr));
        NativeMethods.HandleException(NativeMethods.optflow_Ptr_DenseRLOFOpticalFlow_get(smartPtr, out var rawPtr));
        GC.KeepAlive(rlofParam);
        return new DenseRLOFOpticalFlow(smartPtr, rawPtr);
    }

    /// <summary>
    /// Configuration of the RLOF algorithm.
    /// </summary>
    public RLOFOpticalFlowParameter RLOFOpticalFlowParameter
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.optflow_DenseRLOFOpticalFlow_getRLOFOpticalFlowParameter(Handle, out var smartPtr));
            NativeMethods.HandleException(
                NativeMethods.optflow_Ptr_RLOFOpticalFlowParameter_get(smartPtr, out var rawPtr));
            return RLOFOpticalFlowParameter.FromPtr(smartPtr, rawPtr);
        }
        set
        {
            ThrowIfDisposed();
            ArgumentNullException.ThrowIfNull(value);
            value.ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.optflow_DenseRLOFOpticalFlow_setRLOFOpticalFlowParameter(Handle, value.SmartPtr));
            GC.KeepAlive(value);
        }
    }

    /// <summary>
    /// Threshold for the forward backward confidence check.
    /// </summary>
    public float ForwardBackward
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_getForwardBackward(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_setForwardBackward(Handle, value));
        }
    }

    /// <summary>
    /// Size of the grid to spawn the motion vectors.
    /// </summary>
    public Size GridStep
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_getGridStep(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_setGridStep(Handle, value));
        }
    }

    /// <summary>
    /// Interpolation used to compute the dense optical flow.
    /// </summary>
    public InterpolationType Interpolation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_getInterpolation(Handle, out var ret));
            return (InterpolationType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_setInterpolation(Handle, (int)value));
        }
    }

    /// <summary>
    /// See ximgproc::EdgeAwareInterpolator's K value: number of nearest-neighbor matches considered
    /// when fitting a locally affine model.
    /// </summary>
    public int EpicK
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_getEPICK(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_setEPICK(Handle, value));
        }
    }

    /// <summary>
    /// See ximgproc::EdgeAwareInterpolator's sigma value.
    /// </summary>
    public float EpicSigma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_getEPICSigma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_setEPICSigma(Handle, value));
        }
    }

    /// <summary>
    /// See ximgproc::EdgeAwareInterpolator's lambda value.
    /// </summary>
    public float EpicLambda
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_getEPICLambda(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_setEPICLambda(Handle, value));
        }
    }

    /// <summary>
    /// See ximgproc::fastGlobalSmootherFilter's lambda parameter.
    /// </summary>
    public float FgsLambda
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_getFgsLambda(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_setFgsLambda(Handle, value));
        }
    }

    /// <summary>
    /// See ximgproc::fastGlobalSmootherFilter's sigma parameter.
    /// </summary>
    public float FgsSigma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_getFgsSigma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_setFgsSigma(Handle, value));
        }
    }

    /// <summary>
    /// Enables ximgproc::fastGlobalSmootherFilter post-processing.
    /// </summary>
    public bool UsePostProc
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_getUsePostProc(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_setUsePostProc(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Enables VariationalRefinement.
    /// </summary>
    public bool UseVariationalRefinement
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_getUseVariationalRefinement(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_setUseVariationalRefinement(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Approximate size of the superpixel used for oversegmentation, see ximgproc::RICInterpolator.
    /// </summary>
    public int RicSpSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_getRICSPSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_setRICSPSize(Handle, value));
        }
    }

    /// <summary>
    /// Superpixel algorithm variant used for oversegmentation (see ximgproc::SLICType: SLIC=100, SLICO=101, MSLIC=102).
    /// </summary>
    public int RicSlicType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_getRICSLICType(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_DenseRLOFOpticalFlow_setRICSLICType(Handle, value));
        }
    }
}
