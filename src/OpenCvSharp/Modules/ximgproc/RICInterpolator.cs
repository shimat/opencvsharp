using OpenCvSharp.Internal;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc;

/// <summary>
/// Sparse match interpolation algorithm based on modified piecewise locally-weighted affine
/// estimator called Robust Interpolation method of Correspondences (RIC), and Variational and Fast
/// Global Smoother as post-processing filter. RICInterpolator is an extension of
/// EdgeAwareInterpolator; its main concept is a piece-wise affine model based on over-segmentation
/// via SLIC superpixel estimation, with an efficient propagation mechanism to estimate among the
/// piece-wise models.
/// </summary>
public class RICInterpolator : SparseMatchInterpolator
{
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private RICInterpolator(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_RICInterpolator_delete(p)))
    { }

    /// <summary>
    /// Factory method that creates an instance of the RICInterpolator.
    /// </summary>
    /// <returns></returns>
    public static RICInterpolator Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ximgproc_createRICInterpolator(out var smartPtr));

        NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_RICInterpolator_get(smartPtr, out var rawPtr));
        return new RICInterpolator(smartPtr, rawPtr);
    }

    /// <summary>
    /// Interface to provide a more elaborated cost map, i.e. edge map, for the edge-aware term.
    /// This implementation is based on a rather simple gradient-based edge map estimation. To use a
    /// more complex edge map estimator (e.g. StructuredEdgeDetection) that may lead to improved
    /// accuracies, the internal edge map estimation can be bypassed here.
    /// </summary>
    /// <param name="costMap">a type CV_32FC1 Mat is required.</param>
    public void SetCostMap(Mat costMap)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(costMap);
        costMap.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_RICInterpolator_setCostMap(Handle, costMap.CvPtr));

        GC.KeepAlive(costMap);
    }

    /// <summary>
    /// K is a number of nearest-neighbor matches considered, when fitting a locally affine model for
    /// a superpixel segment. Lower values would make the interpolation noticeably faster. The
    /// original implementation uses 32.
    /// </summary>
    public int K
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getK(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setK(Handle, value));
        }
    }

    /// <summary>
    /// The approximate size of the superpixel used for oversegmentation.
    /// </summary>
    public int SuperpixelSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getSuperpixelSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setSuperpixelSize(Handle, value));
        }
    }

    /// <summary>
    /// The number of nearest-neighbor matches for each superpixel considered, when fitting a locally
    /// affine model.
    /// </summary>
    public int SuperpixelNNCnt
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getSuperpixelNNCnt(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setSuperpixelNNCnt(Handle, value));
        }
    }

    /// <summary>
    /// Tunes the enforcement of the superpixel smoothness factor used for oversegmentation.
    /// </summary>
    public float SuperpixelRuler
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getSuperpixelRuler(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setSuperpixelRuler(Handle, value));
        }
    }

    /// <summary>
    /// Chooses the superpixel algorithm variant to use: SLIC (100) segments the image using a
    /// desired region size, SLICO (101) optimizes using an adaptive compactness factor, and MSLIC
    /// (102) optimizes using manifold methods resulting in more content-sensitive superpixels.
    /// </summary>
    public int SuperpixelMode
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getSuperpixelMode(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setSuperpixelMode(Handle, value));
        }
    }

    /// <summary>
    /// A global weight for transforming geodesic distance into weight.
    /// </summary>
    public float Alpha
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getAlpha(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setAlpha(Handle, value));
        }
    }

    /// <summary>
    /// The number of iterations for piece-wise affine model estimation.
    /// </summary>
    public int ModelIter
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getModelIter(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setModelIter(Handle, value));
        }
    }

    /// <summary>
    /// Whether additional refinement of the piece-wise affine models is employed.
    /// </summary>
    public bool RefineModels
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getRefineModels(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setRefineModels(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// A threshold to validate the predictions using a certain piece-wise affine model. If the
    /// prediction exceeds the threshold the translational model will be applied instead.
    /// </summary>
    public float MaxFlow
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getMaxFlow(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setMaxFlow(Handle, value));
        }
    }

    /// <summary>
    /// Whether the VariationalRefinement post-processing is employed.
    /// </summary>
    public bool UseVariationalRefinement
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getUseVariationalRefinement(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setUseVariationalRefinement(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Whether the fastGlobalSmootherFilter() post-processing is employed.
    /// </summary>
    public bool UseGlobalSmootherFilter
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getUseGlobalSmootherFilter(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setUseGlobalSmootherFilter(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// The respective fastGlobalSmootherFilter() lambda parameter.
    /// </summary>
    public float FGSLambda
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getFGSLambda(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setFGSLambda(Handle, value));
        }
    }

    /// <summary>
    /// The respective fastGlobalSmootherFilter() sigma parameter.
    /// </summary>
    public float FGSSigma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_getFGSSigma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RICInterpolator_setFGSSigma(Handle, value));
        }
    }
}
