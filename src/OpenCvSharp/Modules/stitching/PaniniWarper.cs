using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Panini warper factory class.
/// </summary>
public class PaniniWarper : WarperCreator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public PaniniWarper(float a = 1, float b = 1) : base(Create(a, b), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_PaniniWarper_delete(h)))
    {
    }

    private static IntPtr Create(float a, float b)
    {
        NativeMethods.HandleException(NativeMethods.stitching_PaniniWarper_new(a, b, out var ptr));
        return ptr;
    }
}
