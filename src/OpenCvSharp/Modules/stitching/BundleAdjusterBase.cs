using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Base class for all camera parameters refinement methods.
/// </summary>
public abstract class BundleAdjusterBase : Estimator
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ptr"></param>
    private protected BundleAdjusterBase(IntPtr ptr) : base(ptr)
    {
        InitSafeHandle(ptr);
    }

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.stitching_BundleAdjusterBase_delete(h))));
    }

    /// <summary>
    /// 3x3 8U mask, where 0 means don't refine the respective parameter, non-zero means refine it.
    /// </summary>
    public Mat RefinementMask
    {
        get
        {
            ThrowIfDisposed();
            var mask = new Mat();
            NativeMethods.HandleException(NativeMethods.stitching_BundleAdjusterBase_refinementMask(Handle, mask.CvPtr));
            return mask;
        }
        set
        {
            ThrowIfDisposed();
            ArgumentNullException.ThrowIfNull(value);
            NativeMethods.HandleException(NativeMethods.stitching_BundleAdjusterBase_setRefinementMask(Handle, value.CvPtr));
            GC.KeepAlive(value);
        }
    }

    /// <summary>
    /// Threshold to filter out poorly matched image pairs.
    /// </summary>
    public double ConfThresh
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_BundleAdjusterBase_confThresh(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_BundleAdjusterBase_setConfThresh(Handle, value));
        }
    }

    /// <summary>
    /// Levenberg-Marquardt algorithm termination criteria.
    /// </summary>
    public TermCriteria TermCriteria
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_BundleAdjusterBase_termCriteria(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.stitching_BundleAdjusterBase_setTermCriteria(Handle, value));
        }
    }
}
