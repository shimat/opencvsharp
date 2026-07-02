using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// finds arbitrary template in the grayscale image using Generalized Hough Transform
/// </summary>
public abstract class GeneralizedHough : Algorithm
{
    /// <summary>
    /// 
    /// </summary>
    protected GeneralizedHough(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Canny low threshold.
    /// </summary>
    /// <returns></returns>
    public int CannyLowThresh
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_getCannyLowThresh(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setCannyLowThresh(Handle, value));
        }
    }

    /// <summary>
    /// Canny high threshold.
    /// </summary>
    /// <returns></returns>
    public int CannyHighThresh
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_getCannyHighThresh(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setCannyHighThresh(Handle, value));
        }
    }

    /// <summary>
    /// Minimum distance between the centers of the detected objects.
    /// </summary>
    /// <returns></returns>
    public double MinDist
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_getMinDist(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setMinDist(Handle, value));
        }
    }

    /// <summary>
    /// Inverse ratio of the accumulator resolution to the image resolution.
    /// </summary>
    /// <returns></returns>
    public double Dp
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_getDp(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setDp(Handle, value));
        }
    }

    /// <summary>
    /// Maximal size of inner buffers.
    /// </summary>
    /// <returns></returns>
    public int MaxBufferSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_getMaxBufferSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setMaxBufferSize(Handle, value));
        }
    }

    /// <summary>
    /// set template to search
    /// </summary>
    /// <param name="templ"></param>
    /// <param name="templCenter"></param>
    public void SetTemplate(InputArray templ, Point? templCenter = null)
    {
        ThrowIfDisposed();
        var templCenterValue = templCenter.GetValueOrDefault(new Point(-1, -1));

        NativeMethods.HandleException(
            NativeMethods.imgproc_GeneralizedHough_setTemplate1(Handle, templ.Proxy, templCenterValue));
        GC.KeepAlive(templ.Source);
    }

    /// <summary>
    /// set template to search
    /// </summary>
    /// <param name="edges"></param>
    /// <param name="dx"></param>
    /// <param name="dy"></param>
    /// <param name="templCenter"></param>
    public virtual void SetTemplate(InputArray edges, InputArray dx, InputArray dy, Point? templCenter = null)
    {
        ThrowIfDisposed();
        var templCenterValue = templCenter.GetValueOrDefault(new Point(-1, -1));

        NativeMethods.HandleException(
            NativeMethods.imgproc_GeneralizedHough_setTemplate2(
                Handle, edges.Proxy, dx.Proxy, dy.Proxy, templCenterValue));

        GC.KeepAlive(edges.Source);
        GC.KeepAlive(dx.Source);
        GC.KeepAlive(dy.Source);
    }

    /// <summary>
    /// find template on image
    /// </summary>
    /// <param name="image"></param>
    /// <param name="positions"></param>
    /// <param name="votes"></param>
    public virtual void Detect(
        InputArray image, OutputArray positions, OutputArray votes = default)
    {
        NativeMethods.HandleException(
            NativeMethods.imgproc_GeneralizedHough_detect1(
                Handle, image.Proxy, positions.Proxy, votes.Proxy));

        GC.KeepAlive(image.Source);
        GC.KeepAlive(positions.Source);
        GC.KeepAlive(votes.Source);
    }

    /// <summary>
    /// find template on image
    /// </summary>
    /// <param name="edges"></param>
    /// <param name="dx"></param>
    /// <param name="dy"></param>
    /// <param name="positions"></param>
    /// <param name="votes"></param>
    public virtual void Detect(
        InputArray edges, InputArray dx, InputArray dy, OutputArray positions, OutputArray votes = default)
    {
        NativeMethods.HandleException(
            NativeMethods.imgproc_GeneralizedHough_detect2(
                Handle, edges.Proxy, dx.Proxy, dy.Proxy, positions.Proxy, votes.Proxy));

        GC.KeepAlive(edges.Source);
        GC.KeepAlive(dx.Source);
        GC.KeepAlive(dy.Source);
        GC.KeepAlive(positions.Source);
        GC.KeepAlive(votes.Source);
    }
}
