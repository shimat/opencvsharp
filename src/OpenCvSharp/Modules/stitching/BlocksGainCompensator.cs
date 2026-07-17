using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Exposure compensator which tries to remove exposure related artifacts by adjusting image block intensities.
/// </summary>
public class BlocksGainCompensator : BlocksCompensator
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="blockWidth"></param>
    /// <param name="blockHeight"></param>
    /// <param name="nrFeeds"></param>
    public BlocksGainCompensator(int blockWidth = 32, int blockHeight = 32, int nrFeeds = 1)
        : base(Create(blockWidth, blockHeight, nrFeeds))
    {
    }

    private static IntPtr Create(int blockWidth, int blockHeight, int nrFeeds)
    {
        NativeMethods.HandleException(
            NativeMethods.stitching_BlocksGainCompensator_new(blockWidth, blockHeight, nrFeeds, out var ptr));
        return ptr;
    }
}
