using OpenCvSharp.Internal;

namespace OpenCvSharp.OptFlow;

/// <summary>
/// Stores and sets up the parameters of the robust local optical flow (RLOF) algorithm.
/// </summary>
public class RLOFOpticalFlowParameter : CvPtrObject
{
    private RLOFOpticalFlowParameter((IntPtr smartPtr, IntPtr rawPtr) ptrs)
        : base(ptrs.smartPtr, ptrs.rawPtr,
            static h => NativeMethods.HandleException(NativeMethods.optflow_Ptr_RLOFOpticalFlowParameter_delete(h)))
    {
    }

    /// <summary>
    /// Creates a new set of RLOF parameters, initialized to the algorithm's defaults.
    /// </summary>
    public RLOFOpticalFlowParameter()
        : this(Create())
    {
    }

    private static (IntPtr smartPtr, IntPtr rawPtr) Create()
    {
        NativeMethods.HandleException(
            NativeMethods.optflow_RLOFOpticalFlowParameter_create(out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.optflow_Ptr_RLOFOpticalFlowParameter_get(smartPtr, out var rawPtr));
        return (smartPtr, rawPtr);
    }

    /// <summary>
    /// Wraps an already-created native <c>cv::Ptr&lt;cv::optflow::RLOFOpticalFlowParameter&gt;</c>
    /// (e.g. a clone obtained from <c>DenseRLOFOpticalFlow::getRLOFOpticalFlowParameter</c>) as a managed instance.
    /// </summary>
    internal static RLOFOpticalFlowParameter FromPtr(IntPtr smartPtr, IntPtr rawPtr) => new((smartPtr, rawPtr));

    /// <summary>
    /// Enables the M-estimator by setting the norm sigma parameters to (3.2, 7.0), or disables it
    /// (least-square estimator, faster but less robust against outliers in the support region).
    /// </summary>
    /// <param name="val">If true, the M-estimator is used. If false, the least-square estimator is used.</param>
    public void SetUseMEstimator(bool val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.optflow_RLOFOpticalFlowParameter_setUseMEstimator(Handle, val ? 1 : 0));
    }

    /// <summary>
    /// Iterative refinement strategy.
    /// </summary>
    public SolverType SolverType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getSolverType(Handle, out var ret));
            return (SolverType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setSolverType(Handle, (int)value));
        }
    }

    /// <summary>
    /// Support region shape extraction / shrinking strategy.
    /// </summary>
    public SupportRegionType SupportRegionType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getSupportRegionType(Handle, out var ret));
            return (SupportRegionType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setSupportRegionType(Handle, (int)value));
        }
    }

    /// <summary>
    /// Sigma parameter of the shrunk Hampel norm. If set to float.MaxValue the least-square
    /// estimator is used instead of the M-estimator.
    /// </summary>
    public float NormSigma0
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getNormSigma0(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setNormSigma0(Handle, value));
        }
    }

    /// <summary>
    /// Sigma parameter of the shrunk Hampel norm. If set to float.MaxValue the least-square
    /// estimator is used instead of the M-estimator.
    /// </summary>
    public float NormSigma1
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getNormSigma1(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setNormSigma1(Handle, value));
        }
    }

    /// <summary>
    /// Minimal window size of the support region. Only used if <see cref="SupportRegionType"/> is <see cref="OptFlow.SupportRegionType.Cross"/>.
    /// </summary>
    public int SmallWinSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getSmallWinSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setSmallWinSize(Handle, value));
        }
    }

    /// <summary>
    /// Maximal window size of the support region. If <see cref="SupportRegionType"/> is <see cref="OptFlow.SupportRegionType.Fixed"/>
    /// this gives the exact support region size.
    /// </summary>
    public int LargeWinSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getLargeWinSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setLargeWinSize(Handle, value));
        }
    }

    /// <summary>
    /// Color similarity threshold used by cross-based segmentation. Only used if <see cref="SupportRegionType"/> is
    /// <see cref="OptFlow.SupportRegionType.Cross"/>.
    /// </summary>
    public int CrossSegmentationThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getCrossSegmentationThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setCrossSegmentationThreshold(Handle, value));
        }
    }

    /// <summary>
    /// Maximal number of pyramid levels used.
    /// </summary>
    public int MaxLevel
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getMaxLevel(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setMaxLevel(Handle, value));
        }
    }

    /// <summary>
    /// Use the next point list as initial values.
    /// </summary>
    public bool UseInitialFlow
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getUseInitialFlow(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setUseInitialFlow(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Use the Gennert and Negahdaripour illumination model instead of the intensity brightness constraint.
    /// </summary>
    public bool UseIlluminationModel
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getUseIlluminationModel(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setUseIlluminationModel(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Use global motion prior initialization for the iterative refinement.
    /// </summary>
    public bool UseGlobalMotionPrior
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getUseGlobalMotionPrior(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setUseGlobalMotionPrior(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Number of maximal iterations used for the iterative refinement.
    /// </summary>
    public int MaxIteration
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getMaxIteration(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setMaxIteration(Handle, value));
        }
    }

    /// <summary>
    /// Threshold for the minimal eigenvalue of the gradient matrix, defining when to abort the iterative refinement.
    /// </summary>
    public float MinEigenValue
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getMinEigenValue(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setMinEigenValue(Handle, value));
        }
    }

    /// <summary>
    /// Reprojection threshold (n-th percentile of the motion vectors magnitude, [0 .. 100]) used by the
    /// RANSAC homography estimation for the global motion prior.
    /// </summary>
    public float GlobalMotionRansacThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_getGlobalMotionRansacThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_RLOFOpticalFlowParameter_setGlobalMotionRansacThreshold(Handle, value));
        }
    }
}
