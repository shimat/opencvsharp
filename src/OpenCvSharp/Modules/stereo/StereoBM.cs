using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Semi-Global Stereo Matching
/// </summary>
public class StereoBM : StereoMatcher
{
    #region Init and Disposal

    /// <summary>
    /// constructor
    /// </summary>
    private StereoBM(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.stereo_Ptr_StereoBM_delete(p)))
    { }

    /// <summary>
    /// Creates StereoBM object. You can then call Compute() to compute disparity for a specific stereo pair.
    /// </summary>
    /// <param name="numDisparities">the disparity search range. For each pixel algorithm will find the best
    /// disparity from 0 (default minimum disparity) to numDisparities. The search range can then be
    /// shifted by changing the minimum disparity.</param>
    /// <param name="blockSize">the linear size of the blocks compared by the algorithm. The size should be odd
    /// (as the block is centered at the current pixel). Larger block size implies smoother, though less
    /// accurate disparity map. Smaller block size gives more detailed disparity map, but there is higher
    /// chance for algorithm to find a wrong correspondence.</param>
    /// <returns>A new StereoBM instance.</returns>
    public static StereoBM Create(int numDisparities = 0, int blockSize = 21)
    {
        NativeMethods.HandleException(
            NativeMethods.stereo_StereoBM_create(numDisparities, blockSize, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.stereo_Ptr_StereoBM_get(smartPtr, out var rawPtr));
        return new StereoBM(smartPtr, rawPtr);
    }

    #endregion

    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public int PreFilterType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getPreFilterType(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setPreFilterType(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int PreFilterSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getPreFilterSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setPreFilterSize(Handle, value));
        }
    }

    /// <summary>
    /// Truncation value for the prefiltered image pixels. The algorithm first computes x-derivative at each
    /// pixel and clips its value by [-preFilterCap, preFilterCap] interval. The result values are passed to
    /// the Birchfield-Tomasi pixel cost function.
    /// </summary>
    public int PreFilterCap
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getPreFilterCap(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setPreFilterCap(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int TextureThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getTextureThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setTextureThreshold(Handle, value));
        }
    }

    /// <summary>
    /// Margin in percentage by which the best (minimum) computed cost function value should "win" the
    /// second best value to consider the found match correct. Normally, a value within the 5-15 range is
    /// good enough.
    /// </summary>
    public int UniquenessRatio
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getUniquenessRatio(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setUniquenessRatio(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int SmallerBlockSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getSmallerBlockSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setSmallerBlockSize(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Rect ROI1
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getROI1(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setROI1(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Rect ROI2
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getROI2(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setROI2(Handle, value));
        }
    }

    #endregion

    }
