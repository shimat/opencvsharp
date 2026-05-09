using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

/// <summary>
/// Copy of Cpu GeneralizedHough, but only accept gpu frames. 
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
                NativeMethods.imgproc_GeneralizedHough_getCannyLowThresh(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setCannyLowThresh(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.imgproc_GeneralizedHough_getCannyHighThresh(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setCannyHighThresh(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.imgproc_GeneralizedHough_getMinDist(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setMinDist(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.imgproc_GeneralizedHough_getDp(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setDp(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.imgproc_GeneralizedHough_getMaxBufferSize(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setMaxBufferSize(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// set template to search
    /// </summary>
    /// <param name="templ"></param>
    /// <param name="templCenter"></param>
    public void SetTemplate(OpenCvSharp.Cuda.InputArray templ, Point? templCenter = null)
    {
        ThrowIfDisposed();
        if (templ is null)
            throw new ArgumentNullException(nameof(templ));
        templ.ThrowIfDisposed();
        var templCenterValue = templCenter.GetValueOrDefault(new Point(-1, -1));

        NativeMethods.HandleException(
            NativeMethods.imgproc_GeneralizedHough_setTemplate1(RawPtr, templ.CvPtr, templCenterValue));
        GC.KeepAlive(this);
        GC.KeepAlive(templ);
    }

    /// <summary>
    /// set template to search
    /// </summary>
    /// <param name="edges"></param>
    /// <param name="dx"></param>
    /// <param name="dy"></param>
    /// <param name="templCenter"></param>
    public virtual void SetTemplate(OpenCvSharp.Cuda.InputArray edges, OpenCvSharp.Cuda.InputArray dx, OpenCvSharp.Cuda.InputArray dy, Point? templCenter = null)
    {
        ThrowIfDisposed();
        if (edges is null)
            throw new ArgumentNullException(nameof(edges));
        if (dx is null)
            throw new ArgumentNullException(nameof(dx));
        if (dy is null)
            throw new ArgumentNullException(nameof(dy));
        edges.ThrowIfDisposed();
        dx.ThrowIfDisposed();
        dy.ThrowIfDisposed();
        var templCenterValue = templCenter.GetValueOrDefault(new Point(-1, -1));

        NativeMethods.HandleException(
            NativeMethods.imgproc_GeneralizedHough_setTemplate2(
                RawPtr, edges.CvPtr, dx.CvPtr, dy.CvPtr, templCenterValue));

        GC.KeepAlive(this);
        GC.KeepAlive(edges);
        GC.KeepAlive(dx);
        GC.KeepAlive(dy);
    }

    /// <summary>
    /// find template on image
    /// </summary>
    /// <param name="image"></param>
    /// <param name="positions"></param>
    /// <param name="votes"></param>
    public virtual void Detect(
        OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.OutputArray positions, OpenCvSharp.Cuda.OutputArray? votes = null)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (positions is null)
            throw new ArgumentNullException(nameof(positions));
        image.ThrowIfDisposed();
        positions.ThrowIfNotReady();
        votes?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.imgproc_GeneralizedHough_detect1(
                RawPtr, image.CvPtr, positions.CvPtr, Cv2.ToPtr(votes)));

        GC.KeepAlive(this);
        GC.KeepAlive(image);
        GC.KeepAlive(positions);
        GC.KeepAlive(votes);
        positions.Fix();
        votes?.Fix();
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
        OpenCvSharp.Cuda.InputArray edges, OpenCvSharp.Cuda.InputArray dx, OpenCvSharp.Cuda.InputArray dy, OpenCvSharp.Cuda.OutputArray positions, OpenCvSharp.Cuda.OutputArray? votes = null)
    {
        if (edges is null)
            throw new ArgumentNullException(nameof(edges));
        if (dx is null)
            throw new ArgumentNullException(nameof(dx));
        if (dy is null)
            throw new ArgumentNullException(nameof(dy));
        if (positions is null)
            throw new ArgumentNullException(nameof(positions));
        edges.ThrowIfDisposed();
        dx.ThrowIfDisposed();
        dy.ThrowIfDisposed();
        positions.ThrowIfNotReady();
        votes?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.imgproc_GeneralizedHough_detect2(
                RawPtr, edges.CvPtr, dx.CvPtr, dy.CvPtr, positions.CvPtr, Cv2.ToPtr(votes)));

        GC.KeepAlive(this);
        GC.KeepAlive(edges);
        GC.KeepAlive(dx);
        GC.KeepAlive(dy);
        GC.KeepAlive(positions);
        GC.KeepAlive(votes);
        positions.Fix();
        votes?.Fix();
    }
}
