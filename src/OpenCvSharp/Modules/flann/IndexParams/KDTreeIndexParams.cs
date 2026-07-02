using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Flann;

/// <summary>
/// When passing an object of this type the index constructed will consist of a set
/// of randomized kd-trees which will be searched in parallel.
/// </summary>
public class KDTreeIndexParams : IndexParams
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="trees">The number of parallel kd-trees to use. Good values are in the range [1..16]</param>
    public KDTreeIndexParams(int trees = 4)
        : this(Create(trees))
    {
    }

    private KDTreeIndexParams((IntPtr smartPtr, IntPtr rawPtr) ptrs)
        : base(ptrs.smartPtr, ptrs.rawPtr,
            static h => NativeMethods.HandleException(NativeMethods.flann_Ptr_KDTreeIndexParams_delete(h)))
    {
    }

    private static (IntPtr smartPtr, IntPtr rawPtr) Create(int trees)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_KDTreeIndexParams_new(trees, out var smartPtr));
        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(KDTreeIndexParams)}");
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_KDTreeIndexParams_get(smartPtr, out var rawPtr));
        return (smartPtr, rawPtr);
    }
}
