using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Compressed rectilinear warper factory class.
/// </summary>
public class CompressedRectilinearWarper : WarperCreator
{
    /// <summary>
    /// Constructor
    /// </summary>
    public CompressedRectilinearWarper(float a = 1, float b = 1) : base(Create(a, b), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_CompressedRectilinearWarper_delete(h)))
    {
    }

    private static IntPtr Create(float a, float b)
    {
        NativeMethods.HandleException(NativeMethods.stitching_CompressedRectilinearWarper_new(a, b, out var ptr));
        return ptr;
    }
}
