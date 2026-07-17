using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Compressed rectilinear portrait warper factory class.
/// </summary>
public class CompressedRectilinearPortraitWarper : WarperCreator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public CompressedRectilinearPortraitWarper(float a = 1, float b = 1) : base(Create(a, b), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_CompressedRectilinearPortraitWarper_delete(h)))
    {
    }

    private static IntPtr Create(float a, float b)
    {
        NativeMethods.HandleException(NativeMethods.stitching_CompressedRectilinearPortraitWarper_new(a, b, out var ptr));
        return ptr;
    }
}
