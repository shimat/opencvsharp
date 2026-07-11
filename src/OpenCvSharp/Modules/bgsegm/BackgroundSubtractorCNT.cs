using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Background subtraction based on counting.
/// About as fast as MOG2 on a high end system. More than twice faster than MOG2 on cheap hardware
/// (benchmarked on Raspberry Pi3).
/// </summary>
public class BackgroundSubtractorCNT : BackgroundSubtractor
{
    /// <summary>
    /// Creates a CNT Background Subtractor
    /// </summary>
    /// <param name="minPixelStability">number of frames with same pixel color to consider stable</param>
    /// <param name="useHistory">determines if we're giving a pixel credit for being stable for a long time</param>
    /// <param name="maxPixelStability">maximum allowed credit for a pixel in history</param>
    /// <param name="isParallel">determines if we're parallelizing the algorithm</param>
    /// <returns></returns>
    public static BackgroundSubtractorCNT Create(
        int minPixelStability = 15, bool useHistory = true, int maxPixelStability = 15 * 60, bool isParallel = true)
    {
        NativeMethods.HandleException(
            NativeMethods.bgsegm_createBackgroundSubtractorCNT(
                minPixelStability, useHistory ? 1 : 0, maxPixelStability, isParallel ? 1 : 0, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.bgsegm_Ptr_BackgroundSubtractorCNT_get(smartPtr, out var rawPtr));
        return new BackgroundSubtractorCNT(smartPtr, rawPtr);
    }

    private BackgroundSubtractorCNT(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.bgsegm_Ptr_BackgroundSubtractorCNT_delete(p)))
    { }

    /// <summary>
    /// Number of frames with same pixel color to consider stable.
    /// </summary>
    public int MinPixelStability
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorCNT_getMinPixelStability(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorCNT_setMinPixelStability(Handle, value));
        }
    }

    /// <summary>
    /// Maximum allowed credit for a pixel in history.
    /// </summary>
    public int MaxPixelStability
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorCNT_getMaxPixelStability(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorCNT_setMaxPixelStability(Handle, value));
        }
    }

    /// <summary>
    /// Whether we're giving a pixel credit for being stable for a long time.
    /// </summary>
    public bool UseHistory
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorCNT_getUseHistory(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorCNT_setUseHistory(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Whether we're parallelizing the algorithm.
    /// </summary>
    public bool IsParallel
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorCNT_getIsParallel(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.bgsegm_BackgroundSubtractorCNT_setIsParallel(Handle, value ? 1 : 0));
        }
    }
}
