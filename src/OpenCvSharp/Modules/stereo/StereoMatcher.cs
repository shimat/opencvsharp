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
    /// Computes disparity map for the specified stereo pair
    /// </summary>
    /// <param name="left">Left 8-bit single-channel image.</param>
    /// <param name="right">Right image of the same size and the same type as the left one.</param>
    /// <param name="disparity">Output disparity map. It has the same size as the input images. Some algorithms, 
    /// like StereoBM or StereoSGBM compute 16-bit fixed-point disparity map(where each disparity value has 4 fractional bits), 
    /// whereas other algorithms output 32 - bit floating - point disparity map.</param>
    public virtual void Compute(InputArray left, InputArray right, OutputArray disparity)
    {
        if (left is null)
            throw new ArgumentNullException(nameof(left));
        if (right is null)
            throw new ArgumentNullException(nameof(right));
        if (disparity is null)
            throw new ArgumentNullException(nameof(disparity));
        left.ThrowIfDisposed();
        right.ThrowIfDisposed();
        disparity.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.stereo_StereoMatcher_compute(Handle, left.CvPtr, right.CvPtr, disparity.CvPtr));

        GC.KeepAlive(left);
        GC.KeepAlive(right);
        disparity.Fix();
    }

    /// <summary>
    /// 
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
    /// 
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
    /// 
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
    /// 
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
    /// 
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
    /// 
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
}
