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
        : this(Create())
    {
    }

    private LinearIndexParams((IntPtr smartPtr, IntPtr rawPtr) ptrs)
        : base(ptrs.smartPtr, ptrs.rawPtr,
            static h => NativeMethods.HandleException(NativeMethods.flann_Ptr_LinearIndexParams_delete(h)))
    {
    }

    private static (IntPtr smartPtr, IntPtr rawPtr) Create()
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_LinearIndexParams_new(out var smartPtr));
        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(LinearIndexParams)}");
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_LinearIndexParams_get(smartPtr, out var rawPtr));
        return (smartPtr, rawPtr);
    }
}
