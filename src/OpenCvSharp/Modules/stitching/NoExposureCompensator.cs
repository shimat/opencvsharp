using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Stub exposure compensator which does nothing.
/// </summary>
public class NoExposureCompensator : ExposureCompensator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public NoExposureCompensator() : base(Create(), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_NoExposureCompensator_delete(h)))
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(NativeMethods.stitching_NoExposureCompensator_new(out var ptr));
        return ptr;
    }
}
