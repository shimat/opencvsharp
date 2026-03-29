using OpenCvSharp.Internal;

namespace OpenCvSharp.Flann;

/// <summary>
/// the index will perform a linear, brute-force search.
/// </summary>
public class LinearIndexParams : IndexParams
{
    /// <summary>
    /// Constructor
    /// </summary>
    public LinearIndexParams()
        : base(Create(), static h => NativeMethods.flann_Ptr_LinearIndexParams_delete(h))
    {
    }

    private static IntPtr Create()
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_LinearIndexParams_new(out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(LinearIndexParams)}");
        return p;
    }
}
