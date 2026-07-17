using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Homography based rotation estimator.
/// </summary>
public class HomographyBasedEstimator : Estimator
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="isFocalsEstimated"></param>
    public HomographyBasedEstimator(bool isFocalsEstimated = false) : base(Create(isFocalsEstimated))
    {
        InitSafeHandle(CvPtr);
    }

    private static IntPtr Create(bool isFocalsEstimated)
    {
        NativeMethods.HandleException(
            NativeMethods.stitching_HomographyBasedEstimator_new(isFocalsEstimated ? 1 : 0, out var ptr));
        return ptr;
    }

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.stitching_HomographyBasedEstimator_delete(h))));
    }
}
