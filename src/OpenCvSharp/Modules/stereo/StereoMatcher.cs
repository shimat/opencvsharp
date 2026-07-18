using OpenCvSharp.Internal;

namespace OpenCvSharp;
// ReSharper disable InconsistentNaming
#pragma warning disable 1591

/// <summary>
/// The base class for stereo correspondence algorithms.
/// </summary>
public class StereoMatcher : Algorithm
{
    /// <summary>
    /// constructor
    /// </summary>
    protected StereoMatcher(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes.
    /// </summary>
    /// <param name="ptr"></param>
    internal static StereoMatcher FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid StereoMatcher pointer");

        NativeMethods.HandleException(NativeMethods.stereo_Ptr_StereoMatcher_get(ptr, out var rawPtr));
        return new GenericStereoMatcher(ptr, rawPtr);
    }

    /// <summary>
    /// Computes disparity map for the specified stereo pair
    /// </summary>
    /// <param name="left">Left 8-bit single-channel image.</param>
    /// <param name="right">Right image of the same size and the same type as the left one.</param>
    /// <param name="disparity">Output disparity map. It has the same size as the input images. Some algorithms, 
    /// like StereoBM or StereoSGBM compute 16-bit fixed-point disparity map(where each disparity value has 4 fractional bits), 
    /// whereas other algorithms output 32 - bit floating - point disparity map.</param>
    public virtual void Compute(InputArray left, InputArray right, OutputArray disparity)
    {
        NativeMethods.HandleException(
            NativeMethods.stereo_StereoMatcher_compute(Handle, left.Proxy, right.Proxy, disparity.Proxy));

        GC.KeepAlive(left.Source);
        GC.KeepAlive(right.Source);
    }

    /// <summary>
    /// Minimum possible disparity value. Normally, it is zero but sometimes rectification algorithms can
    /// shift images, so this parameter needs to be adjusted accordingly.
    /// </summary>
    public int MinDisparity
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoMatcher_getMinDisparity(Handle, out var ret));
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoMatcher_setMinDisparity(Handle, value));
        }
    }

    /// <summary>
    /// The disparity search range. For each pixel the algorithm will find the best disparity from 0
    /// (default minimum disparity) to NumDisparities. The search range can then be shifted by changing
    /// the minimum disparity.
    /// </summary>
    public int NumDisparities
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoMatcher_getNumDisparities(Handle, out var ret));
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoMatcher_setNumDisparities(Handle, value));
        }
    }

    /// <summary>
    /// The linear size of the blocks compared by the algorithm. The size should be odd (as the block is
    /// centered at the current pixel). Larger block size implies smoother, though less accurate disparity
    /// map. Smaller block size gives more detailed disparity map, but there is higher chance for the
    /// algorithm to find a wrong correspondence.
    /// </summary>
    public int BlockSize
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoMatcher_getBlockSize(Handle, out var ret));
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoMatcher_setBlockSize(Handle, value));
        }
    }

    /// <summary>
    /// Maximum size of smooth disparity regions to consider their noise speckles and invalidate. Set it to
    /// 0 to disable speckle filtering. Otherwise, set it somewhere in the 50-200 range.
    /// </summary>
    public int SpeckleWindowSize
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoMatcher_getSpeckleWindowSize(Handle, out var ret));
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoMatcher_setSpeckleWindowSize(Handle, value));
        }
    }

    /// <summary>
    /// Maximum disparity variation within each connected component. If you do speckle filtering, set the
    /// parameter to a positive value; it will be implicitly multiplied by 16. Normally, 1 or 2 is good
    /// enough.
    /// </summary>
    public int SpeckleRange
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoMatcher_getSpeckleRange(Handle, out var ret));
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoMatcher_setSpeckleRange(Handle, value));
        }
    }

    /// <summary>
    /// Maximum allowed difference (in integer pixel units) in the left-right disparity check. Set it to a
    /// non-positive value to disable the check.
    /// </summary>
    public int Disp12MaxDiff
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoMatcher_getDisp12MaxDiff(Handle, out var ret));
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoMatcher_setDisp12MaxDiff(Handle, value));
        }
    }

    private sealed class GenericStereoMatcher : StereoMatcher
    {
        public GenericStereoMatcher(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.stereo_Ptr_StereoMatcher_delete(p)))
        {
        }
    }
}
