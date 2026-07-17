using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Class used for calculating a sparse optical flow.
/// The class can calculate an optical flow for a sparse feature set using the iterative
/// Lucas-Kanade method with pyramids.
/// </summary>
public class SparsePyrLKOpticalFlow : SparseOpticalFlow
{
    private SparsePyrLKOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.video_Ptr_SparsePyrLKOpticalFlow_delete(p)))
    { }

    /// <summary>
    /// Creates an instance of SparsePyrLKOpticalFlow
    /// </summary>
    /// <param name="winSize"></param>
    /// <param name="maxLevel"></param>
    /// <param name="criteria"></param>
    /// <param name="flags"></param>
    /// <param name="minEigThreshold"></param>
    /// <returns></returns>
    public static SparsePyrLKOpticalFlow Create(
        Size? winSize = null,
        int maxLevel = 3,
        TermCriteria? criteria = null,
        int flags = 0,
        double minEigThreshold = 1e-4)
    {
        var winSize0 = winSize.GetValueOrDefault(new Size(21, 21));
        var criteria0 = criteria.GetValueOrDefault(TermCriteria.Both(30, 0.01));

        NativeMethods.HandleException(
            NativeMethods.video_SparsePyrLKOpticalFlow_create(winSize0, maxLevel, criteria0, flags, minEigThreshold, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.video_Ptr_SparsePyrLKOpticalFlow_get(smartPtr, out var rawPtr));
        return new SparsePyrLKOpticalFlow(smartPtr, rawPtr);
    }

    /// <summary>
    /// size of the search window at each pyramid level
    /// </summary>
    public Size WinSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_SparsePyrLKOpticalFlow_getWinSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_SparsePyrLKOpticalFlow_setWinSize(Handle, value));
        }
    }

    /// <summary>
    /// 0-based maximal pyramid level number
    /// </summary>
    public int MaxLevel
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_SparsePyrLKOpticalFlow_getMaxLevel(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_SparsePyrLKOpticalFlow_setMaxLevel(Handle, value));
        }
    }

    /// <summary>
    /// termination criteria of the iterative search algorithm
    /// </summary>
    public TermCriteria TermCriteria
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_SparsePyrLKOpticalFlow_getTermCriteria(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_SparsePyrLKOpticalFlow_setTermCriteria(Handle, value));
        }
    }

    /// <summary>
    /// operation flags
    /// </summary>
    public int Flags
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_SparsePyrLKOpticalFlow_getFlags(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_SparsePyrLKOpticalFlow_setFlags(Handle, value));
        }
    }

    /// <summary>
    /// the algorithm calculates the minimum eigenvalue of a 2x2 normal matrix of optical flow equations
    /// </summary>
    public double MinEigThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_SparsePyrLKOpticalFlow_getMinEigThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_SparsePyrLKOpticalFlow_setMinEigThreshold(Handle, value));
        }
    }
}
