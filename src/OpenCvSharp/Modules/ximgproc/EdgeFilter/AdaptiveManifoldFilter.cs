using OpenCvSharp.Internal;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc;

/// <summary>
/// Interface for Adaptive Manifold Filter realizations.
///
/// Below listed optional parameters which may be set up with Algorithm::set function.
/// -   member double sigma_s = 16.0
/// Spatial standard deviation.
/// -   member double sigma_r = 0.2
/// Color space standard deviation.
/// -   member int tree_height = -1
/// Height of the manifold tree (default = -1 : automatically computed).
/// -   member int num_pca_iterations = 1
/// Number of iterations to computed the eigenvector.
/// -   member bool adjust_outliers = false
/// Specify adjust outliers using Eq. 9 or not.
/// -   member bool use_RNG = true
/// Specify use random number generator to compute eigenvector or not.
/// </summary>
// ReSharper disable once InconsistentNaming
public class AdaptiveManifoldFilter : Algorithm
{

    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private AdaptiveManifoldFilter(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_AdaptiveManifoldFilter_delete(p)))
    { }

    /// <summary>
    /// Factory method, create instance of AdaptiveManifoldFilter and produce some initialization routines.
    /// </summary>
    /// <param name="sigmaS">spatial standard deviation.</param>
    /// <param name="sigmaR">color space standard deviation, it is similar to the sigma in the color space into
    /// bilateralFilter.</param>
    /// <param name="adjustOutliers">optional, specify perform outliers adjust operation or not, (Eq. 9) in the
    /// original paper.</param>
    /// <returns></returns>
    public static AdaptiveManifoldFilter Create(
        double sigmaS, double sigmaR, bool adjustOutliers = false)
    {
        NativeMethods.HandleException(
            NativeMethods.ximgproc_createAMFilter(
                sigmaS, sigmaR, adjustOutliers ? 1 : 0, out var smartPtr));
            
        NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_AdaptiveManifoldFilter_get(smartPtr, out var rawPtr));
        return new AdaptiveManifoldFilter(smartPtr, rawPtr);
    }
        
    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public double SigmaS
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_getSigmaS(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_setSigmaS(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double SigmaR
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_getSigmaR(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_setSigmaR(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int TreeHeight
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_getTreeHeight(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_setTreeHeight(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int PCAIterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_getPCAIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_setPCAIterations(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool AdjustOutliers
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_getAdjustOutliers(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_setAdjustOutliers(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool UseRNG
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_getUseRNG(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_AdaptiveManifoldFilter_setUseRNG(Handle, value ? 1 : 0));
        }
    }

    #endregion

    /// <summary>
    /// Apply high-dimensional filtering using adaptive manifolds.
    /// </summary>
    /// <param name="src">filtering image with any numbers of channels.</param>
    /// <param name="dst">output image.</param>
    /// <param name="joint">optional joint (also called as guided) image with any numbers of channels.</param>
    public virtual void Filter(InputArray src, OutputArray dst, InputArray? joint = null)
    {
        ThrowIfDisposed();
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();
        joint?.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_AdaptiveManifoldFilter_filter(
                Handle, src.CvPtr, dst.CvPtr, joint?.CvPtr ?? IntPtr.Zero));

        GC.KeepAlive(src);
        dst.Fix();
        GC.KeepAlive(joint);
    }
}
