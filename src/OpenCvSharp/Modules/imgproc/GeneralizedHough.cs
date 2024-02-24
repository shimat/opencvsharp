using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// finds arbitrary template in the grayscale image using Generalized Hough Transform
/// </summary>
public abstract class GeneralizedHough : Algorithm
{
    /// <summary>
    /// Canny low threshold.
    /// </summary>
    /// <returns></returns>
    public int CannyLowThresh
    {
        get
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_getCannyLowThresh(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setCannyLowThresh(ptr, value));
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
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_getCannyHighThresh(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setCannyHighThresh(ptr, value));
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
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_getMinDist(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setMinDist(ptr, value));
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
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_getDp(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setDp(ptr, value));
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
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_getMaxBufferSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHough_setMaxBufferSize(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// set template to search
    /// </summary>
    /// <param name="templ"></param>
    /// <param name="templCenter"></param>
    public void SetTemplate(InputArray templ, Point? templCenter = null)
    {
        if (ptr == IntPtr.Zero)
            throw new ObjectDisposedException(GetType().Name);
        if (templ is null)
            throw new ArgumentNullException(nameof(templ));
        templ.ThrowIfDisposed();
        var templCenterValue = templCenter.GetValueOrDefault(new Point(-1, -1));

        NativeMethods.HandleException(
            NativeMethods.imgproc_GeneralizedHough_setTemplate1(ptr, templ.CvPtr, templCenterValue));
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
    public virtual void SetTemplate(InputArray edges, InputArray dx, InputArray dy, Point? templCenter = null)
    {
        if (ptr == IntPtr.Zero)
            throw new ObjectDisposedException(GetType().Name);
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
                ptr, edges.CvPtr, dx.CvPtr, dy.CvPtr, templCenterValue));

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
        InputArray image, OutputArray positions, OutputArray? votes = null)
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
                ptr, image.CvPtr, positions.CvPtr, Cv2.ToPtr(votes)));

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
        InputArray edges, InputArray dx, InputArray dy, OutputArray positions, OutputArray? votes = null)
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
                ptr, edges.CvPtr, dx.CvPtr, dy.CvPtr, positions.CvPtr, Cv2.ToPtr(votes)));

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
