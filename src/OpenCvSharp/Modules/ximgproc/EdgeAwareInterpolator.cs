using OpenCvSharp.Internal;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc;

/// <summary>
/// Sparse match interpolation algorithm based on modified locally-weighted affine estimator and
/// Fast Global Smoother as post-processing filter.
/// </summary>
public class EdgeAwareInterpolator : SparseMatchInterpolator
{
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private EdgeAwareInterpolator(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_EdgeAwareInterpolator_delete(p)))
    { }

    /// <summary>
    /// Factory method that creates an instance of the EdgeAwareInterpolator.
    /// </summary>
    /// <returns></returns>
    public static EdgeAwareInterpolator Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ximgproc_createEdgeAwareInterpolator(out var smartPtr));

        NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_EdgeAwareInterpolator_get(smartPtr, out var rawPtr));
        return new EdgeAwareInterpolator(smartPtr, rawPtr);
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
            NativeMethods.ximgproc_EdgeAwareInterpolator_setCostMap(Handle, costMap.CvPtr));

        GC.KeepAlive(costMap);
    }

    /// <summary>
    /// K is a number of nearest-neighbor matches considered, when fitting a locally affine model.
    /// Usually it should be around 128. However, lower values would make the interpolation
    /// noticeably faster.
    /// </summary>
    public int K
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeAwareInterpolator_getK(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeAwareInterpolator_setK(Handle, value));
        }
    }

    /// <summary>
    /// Sigma is a parameter defining how fast the weights decrease in the locally-weighted affine
    /// fitting. Higher values can help preserve fine details, lower values can help to get rid of
    /// noise in the output flow.
    /// </summary>
    public float Sigma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeAwareInterpolator_getSigma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeAwareInterpolator_setSigma(Handle, value));
        }
    }

    /// <summary>
    /// Lambda is a parameter defining the weight of the edge-aware term in geodesic distance, should
    /// be in the range of 0 to 1000.
    /// </summary>
    public float Lambda
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeAwareInterpolator_getLambda(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeAwareInterpolator_setLambda(Handle, value));
        }
    }

    /// <summary>
    /// Sets whether the fastGlobalSmootherFilter() post-processing is employed. It is turned on by default.
    /// </summary>
    public bool UsePostProcessing
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeAwareInterpolator_getUsePostProcessing(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeAwareInterpolator_setUsePostProcessing(Handle, value ? 1 : 0));
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
                NativeMethods.ximgproc_EdgeAwareInterpolator_getFGSLambda(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeAwareInterpolator_setFGSLambda(Handle, value));
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
                NativeMethods.ximgproc_EdgeAwareInterpolator_getFGSSigma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeAwareInterpolator_setFGSSigma(Handle, value));
        }
    }
}
