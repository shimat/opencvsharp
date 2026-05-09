using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;
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
    /// Computes disparity map for the specified stereo pair.
    /// </summary>
    /// <param name="left">Left 8-bit single-channel image.</param>
    /// <param name="right">Right image of the same size and the same type as the left one.</param>
    /// <param name="disparity">Output disparity map.</param>
    /// <param name="stream">Stream for the asynchronous version.</param>
    public virtual void Compute(
        OpenCvSharp.Cuda.InputArray left,
        OpenCvSharp.Cuda.InputArray right,
        OpenCvSharp.Cuda.OutputArray disparity)
    {
        if (left == null) throw new ArgumentNullException(nameof(left));
        if (right == null) throw new ArgumentNullException(nameof(right));
        if (disparity == null) throw new ArgumentNullException(nameof(disparity));

        left.ThrowIfDisposed();
        right.ThrowIfDisposed();
        disparity.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.calib3d_StereoMatcher_compute(
                RawPtr, left.CvPtr, right.CvPtr, disparity.CvPtr));

        disparity.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(left);
        GC.KeepAlive(right);

    }

    /// <summary>
    /// 
    /// </summary>
    public int MinDisparity
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoMatcher_getMinDisparity(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoMatcher_setMinDisparity(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoMatcher_getNumDisparities(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoMatcher_setNumDisparities(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoMatcher_getBlockSize(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoMatcher_setBlockSize(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoMatcher_getSpeckleWindowSize(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoMatcher_setSpeckleWindowSize(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoMatcher_getSpeckleRange(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoMatcher_setSpeckleRange(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoMatcher_getDisp12MaxDiff(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoMatcher_setDisp12MaxDiff(RawPtr, value));
            GC.KeepAlive(this);
        }
    }
}
