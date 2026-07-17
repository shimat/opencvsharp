using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Panini portrait warper factory class.
/// </summary>
public class PaniniPortraitWarper : WarperCreator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public PaniniPortraitWarper(float a = 1, float b = 1) : base(Create(a, b), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_PaniniPortraitWarper_delete(h)))
    {
    }

    private static IntPtr Create(float a, float b)
    {
        NativeMethods.HandleException(NativeMethods.stitching_PaniniPortraitWarper_new(a, b, out var ptr));
        return ptr;
    }
}
