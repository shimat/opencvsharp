using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Exposure compensator which tries to remove exposure related artifacts by adjusting image intensities
/// on each channel independently.
/// </summary>
public class ChannelsCompensator : ExposureCompensator
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="nrFeeds"></param>
    public ChannelsCompensator(int nrFeeds = 1) : base(Create(nrFeeds), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_ChannelsCompensator_delete(h)))
    {
    }

    private static IntPtr Create(int nrFeeds)
    {
        NativeMethods.HandleException(NativeMethods.stitching_ChannelsCompensator_new(nrFeeds, out var ptr));
        return ptr;
    }

    /// <summary>
    /// Number of images fed to this compensator.
    /// </summary>
    public int NrFeeds
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_ChannelsCompensator_getNrFeeds(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_ChannelsCompensator_setNrFeeds(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.stitching_ChannelsCompensator_getSimilarityThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_ChannelsCompensator_setSimilarityThreshold(Handle, value));
        }
    }
}
