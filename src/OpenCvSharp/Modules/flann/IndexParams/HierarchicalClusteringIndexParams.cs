using OpenCvSharp.Internal;

namespace OpenCvSharp.Flann;

/// <summary>
///
/// </summary>
public class HierarchicalClusteringIndexParams : IndexParams
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="branching"></param>
    /// <param name="centersInit"></param>
    /// <param name="trees"></param>
    /// <param name="leafSize"></param>
    public HierarchicalClusteringIndexParams(
        int branching = 32, FlannCentersInit centersInit = FlannCentersInit.Random, int trees = 4, int leafSize = 100)
        : this(Create(branching, centersInit, trees, leafSize))
    {
    }

    private HierarchicalClusteringIndexParams((IntPtr smartPtr, IntPtr rawPtr) ptrs)
        : base(ptrs.smartPtr, ptrs.rawPtr,
            static h => NativeMethods.HandleException(NativeMethods.flann_Ptr_HierarchicalClusteringIndexParams_delete(h)))
    {
    }

    private static (IntPtr smartPtr, IntPtr rawPtr) Create(int branching, FlannCentersInit centersInit, int trees, int leafSize)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_HierarchicalClusteringIndexParams_new(branching, centersInit, trees, leafSize, out var smartPtr));
        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(HierarchicalClusteringIndexParams)}");
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_HierarchicalClusteringIndexParams_get(smartPtr, out var rawPtr));
        return (smartPtr, rawPtr);
    }
}
