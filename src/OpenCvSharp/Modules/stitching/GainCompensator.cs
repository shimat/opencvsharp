using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Exposure compensator which tries to remove exposure related artifacts by adjusting image intensities.
/// </summary>
public class GainCompensator : ExposureCompensator
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="nrFeeds"></param>
    public GainCompensator(int nrFeeds = 1) : base(Create(nrFeeds), static h =>
        NativeMethods.HandleException(NativeMethods.stitching_GainCompensator_delete(h)))
    {
    }

    private static IntPtr Create(int nrFeeds)
    {
        NativeMethods.HandleException(NativeMethods.stitching_GainCompensator_new(nrFeeds, out var ptr));
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
            NativeMethods.HandleException(NativeMethods.stitching_GainCompensator_getNrFeeds(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_GainCompensator_setNrFeeds(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.stitching_GainCompensator_getSimilarityThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_GainCompensator_setSimilarityThreshold(Handle, value));
        }
    }
}
