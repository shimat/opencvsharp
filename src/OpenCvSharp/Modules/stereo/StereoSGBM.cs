using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
#pragma warning disable 1591

namespace OpenCvSharp;

/// <summary>
/// 
/// </summary>
public enum StereoSGBMMode
{
    SGBM = 0,
    HH   = 1,
    SGBM3Way = 2,
    HH4 = 3,
}

/// <summary>
/// Semi-Global Stereo Matching
/// </summary>
public class StereoSGBM : StereoMatcher
{
    private StereoSGBM(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.stereo_Ptr_StereoSGBM_delete(p)))
    { }

    /// <summary>
    /// Creates StereoSGBM object. Using the default parameters, only <paramref name="numDisparities"/> needs
    /// to be set at minimum; every other parameter can be set to a custom value as needed.
    /// </summary>
    /// <param name="minDisparity">Minimum possible disparity value. Normally, it is zero but sometimes
    /// rectification algorithms can shift images, so this parameter needs to be adjusted accordingly.</param>
    /// <param name="numDisparities">Maximum disparity minus minimum disparity. The value is always greater
    /// than zero. In the current implementation, this parameter must be divisible by 16.</param>
    /// <param name="blockSize">Matched block size. It must be an odd number &gt;=1. Normally, it should be
    /// somewhere in the 3..11 range.</param>
    /// <param name="p1">The first parameter controlling the disparity smoothness. See <paramref name="p2"/>.</param>
    /// <param name="p2">The second parameter controlling the disparity smoothness. The larger the values
    /// are, the smoother the disparity is. P1 is the penalty on the disparity change by plus or minus 1
    /// between neighbor pixels. P2 is the penalty on the disparity change by more than 1 between neighbor
    /// pixels. The algorithm requires P2 &gt; P1.</param>
    /// <param name="disp12MaxDiff">Maximum allowed difference (in integer pixel units) in the left-right
    /// disparity check. Set it to a non-positive value to disable the check.</param>
    /// <param name="preFilterCap">Truncation value for the prefiltered image pixels. The algorithm first
    /// computes x-derivative at each pixel and clips its value by [-preFilterCap, preFilterCap] interval.
    /// The result values are passed to the Birchfield-Tomasi pixel cost function.</param>
    /// <param name="uniquenessRatio">Margin in percentage by which the best (minimum) computed cost
    /// function value should "win" the second best value to consider the found match correct. Normally, a
    /// value within the 5-15 range is good enough.</param>
    /// <param name="speckleWindowSize">Maximum size of smooth disparity regions to consider their noise
    /// speckles and invalidate. Set it to 0 to disable speckle filtering. Otherwise, set it somewhere in
    /// the 50-200 range.</param>
    /// <param name="speckleRange">Maximum disparity variation within each connected component. If you do
    /// speckle filtering, set the parameter to a positive value, it will be implicitly multiplied by 16.
    /// Normally, 1 or 2 is good enough.</param>
    /// <param name="mode">Set it to <see cref="StereoSGBMMode.HH"/> to run the full-scale two-pass dynamic
    /// programming algorithm. It will consume a large amount of memory for large images. By default, the
    /// single-pass 5-direction variant is used.</param>
    /// <returns>A new StereoSGBM instance.</returns>
    public static StereoSGBM Create(
        int minDisparity, int numDisparities, int blockSize,
        int p1 = 0, int p2 = 0, int disp12MaxDiff = 0,
        int preFilterCap = 0, int uniquenessRatio = 0,
        int speckleWindowSize = 0, int speckleRange = 0,
        StereoSGBMMode mode = StereoSGBMMode.SGBM)
    {
        NativeMethods.HandleException(
            NativeMethods.stereo_StereoSGBM_create(
                minDisparity, numDisparities, blockSize,
                p1, p2, disp12MaxDiff, preFilterCap, uniquenessRatio,
                speckleWindowSize, speckleRange, (int) mode, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.stereo_Ptr_StereoSGBM_get(smartPtr, out var rawPtr));
        return new StereoSGBM(smartPtr, rawPtr);
    }

    #region Properties

    /// <summary>
    /// Truncation value for the prefiltered image pixels. The algorithm first
    /// computes x-derivative at each pixel and clips its value by [-preFilterCap, preFilterCap] interval.
    /// The result values are passed to the Birchfield-Tomasi pixel cost function.
    /// </summary>
    public int PreFilterCap
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoSGBM_getPreFilterCap(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoSGBM_setPreFilterCap(Handle, value));
        }
    }

    /// <summary>
    /// Margin in percentage by which the best (minimum) computed cost function
    /// value should "win" the second best value to consider the found match correct. Normally, a value
    /// within the 5-15 range is good enough.
    /// </summary>
    public int UniquenessRatio
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoSGBM_getUniquenessRatio(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoSGBM_setUniquenessRatio(Handle, value));
        }
    }

    /// <summary>
    /// The first parameter controlling the disparity smoothness. See P2 description.
    /// </summary>
    public int P1
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoSGBM_getP1(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoSGBM_setP1(Handle, value));
        }
    }

    /// <summary>
    /// The second parameter controlling the disparity smoothness. The larger the values are,
    /// the smoother the disparity is. P1 is the penalty on the disparity change by plus or minus 1
    /// between neighbor pixels. P2 is the penalty on the disparity change by more than 1 between neighbor
    /// pixels. The algorithm requires P2 \> P1 . See stereo_match.cpp sample where some reasonably good
    /// P1 and P2 values are shown (like 8\*number_of_image_channels\*SADWindowSize\*SADWindowSize and
    /// 32\*number_of_image_channels\*SADWindowSize\*SADWindowSize , respectively).
    /// </summary>
    public int P2
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoSGBM_getP2(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoSGBM_setP2(Handle, value));
        }
    }

    /// <summary>
    /// Set it to StereoSGBM::MODE_HH to run the full-scale two-pass dynamic programming
    /// algorithm. It will consume O(W\*H\*numDisparities) bytes, which is large for 640x480 stereo and
    /// huge for HD-size pictures. By default, it is set to false .
    /// </summary>
    public StereoSGBMMode Mode
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoSGBM_getMode(Handle, out var ret));
            return (StereoSGBMMode)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoSGBM_setMode(Handle, (int)value));
        }
    }

    #endregion

    }
