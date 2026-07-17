using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Exposure compensator which tries to remove exposure related artifacts by adjusting image blocks.
/// Shared base for <see cref="BlocksGainCompensator"/> and <see cref="BlocksChannelsCompensator"/>;
/// it has no public constructor of its own (matching upstream OpenCV, which does not expose one either).
/// </summary>
public abstract class BlocksCompensator : ExposureCompensator
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="rawPtr"></param>
    private protected BlocksCompensator(IntPtr rawPtr) : base(rawPtr, static h =>
        NativeMethods.HandleException(NativeMethods.stitching_BlocksCompensator_delete(h)))
    {
    }

    /// <summary>
    /// Number of images fed to this compensator.
    /// </summary>
    public int NrFeeds
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_BlocksCompensator_getNrFeeds(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_BlocksCompensator_setNrFeeds(Handle, value));
        }
    }

    /// <summary>
    /// Similarity threshold used for masking similar image regions in the exposure compensation gain computation.
    /// </summary>
    public double SimilarityThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_BlocksCompensator_getSimilarityThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_BlocksCompensator_setSimilarityThreshold(Handle, value));
        }
    }

    /// <summary>
    /// Size, in pixels, of each block used for exposure compensation.
    /// </summary>
    public Size BlockSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_BlocksCompensator_getBlockSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_BlocksCompensator_setBlockSize(Handle, value.Width, value.Height));
        }
    }

    /// <summary>
    /// Number of filtering iterations applied to the gain map.
    /// </summary>
    public int NrGainsFilteringIterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_BlocksCompensator_getNrGainsFilteringIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_BlocksCompensator_setNrGainsFilteringIterations(Handle, value));
        }
    }
}
