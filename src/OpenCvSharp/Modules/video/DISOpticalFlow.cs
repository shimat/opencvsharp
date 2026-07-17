using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// DIS optical flow algorithm.
/// This class implements the Dense Inverse Search (DIS) optical flow algorithm. Includes three
/// presets with preselected parameters to provide reasonable trade-off between speed and quality.
/// </summary>
public class DISOpticalFlow : DenseOpticalFlow
{
    private DISOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.video_Ptr_DISOpticalFlow_delete(p)))
    { }

    /// <summary>
    /// Creates an instance of DISOpticalFlow
    /// </summary>
    /// <param name="preset">one of PRESET_ULTRAFAST, PRESET_FAST and PRESET_MEDIUM</param>
    /// <returns></returns>
    public static DISOpticalFlow Create(DISOpticalFlowPresetTypes preset = DISOpticalFlowPresetTypes.Fast)
    {
        NativeMethods.HandleException(
            NativeMethods.video_DISOpticalFlow_create((int)preset, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.video_Ptr_DISOpticalFlow_get(smartPtr, out var rawPtr));
        return new DISOpticalFlow(smartPtr, rawPtr);
    }

    /// <summary>
    /// Finest level of the Gaussian pyramid on which the flow is computed (zero level corresponds
    /// to the original image resolution). The final flow is obtained by bilinear upscaling.
    /// </summary>
    public int FinestScale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_getFinestScale(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_setFinestScale(Handle, value));
        }
    }

    /// <summary>
    /// Coarsest level of the Gaussian pyramid on which the flow is computed. If set to -1, the
    /// auto-computed coarsest scale will be used.
    /// </summary>
    public int CoarsestScale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_getCoarsestScale(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_setCoarsestScale(Handle, value));
        }
    }

    /// <summary>
    /// Size of an image patch for matching (in pixels). Normally, default 8x8 patches work well
    /// enough in most cases.
    /// </summary>
    public int PatchSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_getPatchSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_setPatchSize(Handle, value));
        }
    }

    /// <summary>
    /// Stride between neighbor patches. Must be less than patch size. Lower values correspond to
    /// higher flow quality.
    /// </summary>
    public int PatchStride
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_getPatchStride(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_setPatchStride(Handle, value));
        }
    }

    /// <summary>
    /// Maximum number of gradient descent iterations in the patch inverse search stage. Higher
    /// values may improve quality in some cases.
    /// </summary>
    public int GradientDescentIterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_getGradientDescentIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_setGradientDescentIterations(Handle, value));
        }
    }

    /// <summary>
    /// Number of fixed point iterations of variational refinement per scale. Set to zero to disable
    /// variational refinement completely. Higher values will typically result in more smooth and
    /// high-quality flow.
    /// </summary>
    public int VariationalRefinementIterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_getVariationalRefinementIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_setVariationalRefinementIterations(Handle, value));
        }
    }

    /// <summary>
    /// Weight of the smoothness term
    /// </summary>
    public float VariationalRefinementAlpha
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_getVariationalRefinementAlpha(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_setVariationalRefinementAlpha(Handle, value));
        }
    }

    /// <summary>
    /// Weight of the color constancy term
    /// </summary>
    public float VariationalRefinementDelta
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_getVariationalRefinementDelta(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_setVariationalRefinementDelta(Handle, value));
        }
    }

    /// <summary>
    /// Weight of the gradient constancy term
    /// </summary>
    public float VariationalRefinementGamma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_getVariationalRefinementGamma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_setVariationalRefinementGamma(Handle, value));
        }
    }

    /// <summary>
    /// Norm value shift for robust penalizer
    /// </summary>
    public float VariationalRefinementEpsilon
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_getVariationalRefinementEpsilon(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_setVariationalRefinementEpsilon(Handle, value));
        }
    }

    /// <summary>
    /// Whether to use mean-normalization of patches when computing patch distance. It is turned on
    /// by default as it typically provides a noticeable quality boost because of increased
    /// robustness to illumination variations. Turn it off if you are certain that your sequence
    /// doesn't contain any changes in illumination.
    /// </summary>
    public bool UseMeanNormalization
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_getUseMeanNormalization(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_setUseMeanNormalization(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Whether to use spatial propagation of good optical flow vectors. This option is turned on by
    /// default, as it tends to work better on average and can sometimes help recover from major
    /// errors introduced by the coarse-to-fine scheme employed by the DIS optical flow algorithm.
    /// Turning this option off can make the output flow field a bit smoother, however.
    /// </summary>
    public bool UseSpatialPropagation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_getUseSpatialPropagation(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_DISOpticalFlow_setUseSpatialPropagation(Handle, value ? 1 : 0));
        }
    }
}
