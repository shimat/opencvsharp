using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Affine transformation based estimator. This estimator uses pairwise transformations estimated by
/// the matcher to estimate the final transformation for each camera.
/// </summary>
public class AffineBasedEstimator : Estimator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public AffineBasedEstimator() : base(Create())
    {
        InitSafeHandle(CvPtr);
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_AffineBasedEstimator_new(out var ptr));
        return ptr;
    }

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.stitching_AffineBasedEstimator_delete(h))));
    }
}
