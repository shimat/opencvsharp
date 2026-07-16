using OpenCvSharp.Internal;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc;

/// <summary>
/// Main interface for all disparity map filters.
/// </summary>
public abstract class DisparityFilter : Algorithm
{
    /// <inheritdoc />
    protected DisparityFilter(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Apply filtering to the disparity map.
    /// </summary>
    /// <param name="disparityMapLeft">disparity map of the left view, 1 channel, CV_16S type. Implicitly assumes
    /// that disparity values are scaled by 16 (one-pixel disparity corresponds to the value of 16 in the
    /// disparity map). Disparity map can have any resolution, it will be automatically resized to fit
    /// leftView resolution.</param>
    /// <param name="leftView">left view of the original stereo-pair to guide the filtering process, 8-bit
    /// single-channel or three-channel image.</param>
    /// <param name="filteredDisparityMap">output disparity map, single-channel CV_16S type,
    /// with disparity values scaled by 16.</param>
    /// <param name="disparityMapRight">optional argument, some implementations might also use the disparity
    /// map of the right view to compute confidence maps. If provided, it must be a single-channel CV_16S
    /// matrix. Disparity values are expected to be scaled by 16 (one-pixel disparity corresponds to the
    /// value of 16).</param>
    /// <param name="roi">region of the disparity map to filter. Optional, usually it should be set automatically.</param>
    /// <param name="rightView">optional argument, some implementations might also use the right view of the
    /// original stereo-pair.</param>
    public virtual void Filter(
        InputArray disparityMapLeft, InputArray leftView, OutputArray filteredDisparityMap,
        InputArray disparityMapRight = default, Rect roi = default, InputArray rightView = default)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_DisparityFilter_filter(
                Handle, disparityMapLeft.Proxy, leftView.Proxy, filteredDisparityMap.Proxy,
                disparityMapRight.Proxy, roi, rightView.Proxy));

        GC.KeepAlive(disparityMapLeft.Source);
        GC.KeepAlive(leftView.Source);
        GC.KeepAlive(filteredDisparityMap.Source);
        GC.KeepAlive(disparityMapRight.Source);
        GC.KeepAlive(rightView.Source);
    }
}
