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
}

/// <summary>
/// Semi-Global Stereo Matching
/// </summary>
public class StereoSGBM : StereoMatcher
{
    private Ptr? ptrObj;

    #region Init and Disposal

    /// <summary>
    /// constructor
    /// </summary>
    protected StereoSGBM(IntPtr ptr) : base(ptr)
    {
        ptrObj = new Ptr(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="minDisparity"></param>
    /// <param name="numDisparities"></param>
    /// <param name="blockSize"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="disp12MaxDiff"></param>
    /// <param name="preFilterCap"></param>
    /// <param name="uniquenessRatio"></param>
    /// <param name="speckleWindowSize"></param>
    /// <param name="speckleRange"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static StereoSGBM Create(
        int minDisparity, int numDisparities, int blockSize,
        int p1 = 0, int p2 = 0, int disp12MaxDiff = 0,
        int preFilterCap = 0, int uniquenessRatio = 0,
        int speckleWindowSize = 0, int speckleRange = 0,
        StereoSGBMMode mode = StereoSGBMMode.SGBM)
    {
        NativeMethods.HandleException(
            NativeMethods.calib3d_StereoSGBM_create(
                minDisparity, numDisparities, blockSize,
                p1, p2, disp12MaxDiff, preFilterCap, uniquenessRatio,
                speckleWindowSize, speckleRange, (int) mode, out var ptrObj));
        return new StereoSGBM(ptrObj);
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }

    #endregion

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
                NativeMethods.calib3d_StereoSGBM_getPreFilterCap(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoSGBM_setPreFilterCap(ptr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoSGBM_getUniquenessRatio(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoSGBM_setUniquenessRatio(ptr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoSGBM_getP1(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoSGBM_setP1(ptr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoSGBM_getP2(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoSGBM_setP2(ptr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoSGBM_getMode(ptr, out var ret));
            GC.KeepAlive(this);
            return (StereoSGBMMode)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoSGBM_setMode(ptr, (int)value));
            GC.KeepAlive(this);
        }
    }

    #endregion

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.calib3d_Ptr_StereoSGBM_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.calib3d_Ptr_StereoSGBM_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
