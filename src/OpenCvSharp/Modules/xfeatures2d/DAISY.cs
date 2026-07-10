using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Class implementing the DAISY descriptor.
/// </summary>
public class DAISY : Feature2D
{
    /// <summary>
    ///
    /// </summary>
    private DAISY(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_DAISY_delete(p)))
    { }

    /// <summary>
    /// Creates the DAISY descriptor.
    /// </summary>
    /// <param name="radius">Radius of the descriptor at the initial scale.</param>
    /// <param name="qRadius">Amount of radial range division quantity.</param>
    /// <param name="qTheta">Amount of angular range division quantity.</param>
    /// <param name="qHist">Amount of gradient orientations range division quantity.</param>
    /// <param name="norm">Descriptors normalization type.</param>
    /// <param name="h">Optional 3x3 homography matrix used to warp the grid of daisy but sampling
    /// keypoints remains unwarped on image.</param>
    /// <param name="interpolation">Switch to disable interpolation for speed improvement at minor
    /// quality loss.</param>
    /// <param name="useOrientation">Sample patterns using keypoints orientation, disabled by default.</param>
    public static DAISY Create(
        float radius = 15, int qRadius = 3, int qTheta = 8, int qHist = 8,
        DAISYNormalizationType norm = DAISYNormalizationType.None, InputArray h = default,
        bool interpolation = true, bool useOrientation = false)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_DAISY_create(
                radius, qRadius, qTheta, qHist, (int)norm, h.Proxy,
                interpolation ? 1 : 0, useOrientation ? 1 : 0, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_DAISY_get(ptr, out var rawPtr));
        GC.KeepAlive(h.Source);
        return new DAISY(ptr, rawPtr);
    }

    /// <summary>
    /// Radius of the descriptor at the initial scale.
    /// </summary>
    public float Radius
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_getRadius(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_setRadius(Handle, value));
        }
    }

    /// <summary>
    /// Amount of radial range division quantity.
    /// </summary>
    public int QRadius
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_getQRadius(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_setQRadius(Handle, value));
        }
    }

    /// <summary>
    /// Amount of angular range division quantity.
    /// </summary>
    public int QTheta
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_getQTheta(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_setQTheta(Handle, value));
        }
    }

    /// <summary>
    /// Amount of gradient orientations range division quantity.
    /// </summary>
    public int QHist
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_getQHist(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_setQHist(Handle, value));
        }
    }

    /// <summary>
    /// Descriptors normalization type.
    /// </summary>
    public DAISYNormalizationType Norm
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_getNorm(Handle, out var ret));
            return (DAISYNormalizationType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_setNorm(Handle, (int)value));
        }
    }

    /// <summary>
    /// Optional 3x3 homography matrix used to warp the grid of daisy but sampling keypoints
    /// remains unwarped on image.
    /// </summary>
    public Mat H
    {
        get
        {
            ThrowIfDisposed();
            var ret = new Mat();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_getH(Handle, ret.CvPtr));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            ArgumentNullException.ThrowIfNull(value);
            InputArray h = value;
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_setH(Handle, h.Proxy));
            GC.KeepAlive(value);
        }
    }

    /// <summary>
    /// Switch to disable interpolation for speed improvement at minor quality loss.
    /// </summary>
    public bool Interpolation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_getInterpolation(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_setInterpolation(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Sample patterns using keypoints orientation, disabled by default.
    /// </summary>
    public bool UseOrientation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_getUseOrientation(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_DAISY_setUseOrientation(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Computes the descriptor for every pixel within the given region of interest.
    /// </summary>
    /// <remarks>
    /// OpenCV's native implementation indexes the output buffer using absolute image
    /// coordinates even though the buffer is only sized <c>roi.Width * roi.Height</c> rows,
    /// so it overflows unless <paramref name="roi"/> covers the entire image
    /// (<c>roi.X == 0 &amp;&amp; roi.Y == 0 &amp;&amp; roi.Width == image.Cols &amp;&amp; roi.Height == image.Rows</c>).
    /// </remarks>
    /// <param name="image">Image to extract descriptors from.</param>
    /// <param name="roi">Region of interest within the image.</param>
    /// <param name="descriptors">Resulted descriptors array for the roi image pixels.</param>
    public void Compute(InputArray image, Rect roi, OutputArray descriptors)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_DAISY_compute_roi(Handle, image.Proxy, roi, descriptors.Proxy));
        GC.KeepAlive(image.Source);
        GC.KeepAlive(descriptors.Source);
    }

    /// <summary>
    /// Computes the descriptor for every pixel in the image.
    /// </summary>
    /// <param name="image">Image to extract descriptors from.</param>
    /// <param name="descriptors">Resulted descriptors array for all image pixels.</param>
    public void Compute(InputArray image, OutputArray descriptors)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_DAISY_compute_dense(Handle, image.Proxy, descriptors.Proxy));
        GC.KeepAlive(image.Source);
        GC.KeepAlive(descriptors.Source);
    }

    /// <summary>
    /// Retrieves the descriptor at the given position and orientation.
    /// </summary>
    /// <param name="y">Position y on image.</param>
    /// <param name="x">Position x on image.</param>
    /// <param name="orientation">Orientation on image (0-360).</param>
    /// <returns>The computed descriptor.</returns>
    public float[] GetDescriptor(double y, double x, int orientation)
    {
        ThrowIfDisposed();
        var descriptor = new float[DescriptorSize];
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_DAISY_GetDescriptor1(Handle, y, x, orientation, descriptor));
        return descriptor;
    }

    /// <summary>
    /// Retrieves the descriptor at the given position and orientation, using a homography matrix
    /// for the warped grid.
    /// </summary>
    /// <param name="y">Position y on image.</param>
    /// <param name="x">Position x on image.</param>
    /// <param name="orientation">Orientation on image (0-360).</param>
    /// <param name="h">Homography matrix for warped grid (row-major, 9 elements).</param>
    /// <param name="descriptor">The computed descriptor.</param>
    /// <returns>false if the descriptor could not be computed (e.g. it falls outside the image), true otherwise.</returns>
    public bool GetDescriptor(double y, double x, int orientation, double[] h, out float[] descriptor)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(h);
        if (h.Length != 9)
            throw new ArgumentException("h must have 9 elements (a 3x3 homography matrix).", nameof(h));

        descriptor = new float[DescriptorSize];
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_DAISY_GetDescriptor2(Handle, y, x, orientation, descriptor, h, out var ret));
        return ret != 0;
    }

    /// <summary>
    /// Retrieves the unnormalized descriptor at the given position and orientation.
    /// </summary>
    /// <param name="y">Position y on image.</param>
    /// <param name="x">Position x on image.</param>
    /// <param name="orientation">Orientation on image (0-360).</param>
    /// <returns>The computed descriptor.</returns>
    public float[] GetUnnormalizedDescriptor(double y, double x, int orientation)
    {
        ThrowIfDisposed();
        var descriptor = new float[DescriptorSize];
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_DAISY_GetUnnormalizedDescriptor1(Handle, y, x, orientation, descriptor));
        return descriptor;
    }

    /// <summary>
    /// Retrieves the unnormalized descriptor at the given position and orientation, using a
    /// homography matrix for the warped grid.
    /// </summary>
    /// <param name="y">Position y on image.</param>
    /// <param name="x">Position x on image.</param>
    /// <param name="orientation">Orientation on image (0-360).</param>
    /// <param name="h">Homography matrix for warped grid (row-major, 9 elements).</param>
    /// <param name="descriptor">The computed descriptor.</param>
    /// <returns>false if the descriptor could not be computed (e.g. it falls outside the image), true otherwise.</returns>
    public bool GetUnnormalizedDescriptor(double y, double x, int orientation, double[] h, out float[] descriptor)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(h);
        if (h.Length != 9)
            throw new ArgumentException("h must have 9 elements (a 3x3 homography matrix).", nameof(h));

        descriptor = new float[DescriptorSize];
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_DAISY_GetUnnormalizedDescriptor2(Handle, y, x, orientation, descriptor, h, out var ret));
        return ret != 0;
    }
}
