using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp;

/// <summary>
/// Object that can compute the normals in an image.
/// It is an object as it can cache data for speed efficiency.
/// </summary>
public class RgbdNormals : CvPtrObject
{
    #region Init and Disposal

    /// <summary>
    /// Constructor used by the Ptr-factory pattern (cv::Ptr&lt;RgbdNormals&gt;*).
    /// </summary>
    /// <param name="smartPtr">cv::Ptr&lt;cv::RgbdNormals&gt;*</param>
    internal RgbdNormals(IntPtr smartPtr)
        : base(smartPtr, GetRawPtr(smartPtr),
            static p => NativeMethods.HandleException(NativeMethods.ptcloud_Ptr_RgbdNormals_delete(p)))
    {
    }

    private static IntPtr GetRawPtr(IntPtr smartPtr)
    {
        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(RgbdNormals)}");
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Ptr_RgbdNormals_get(smartPtr, out var rawPtr));
        if (rawPtr == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(RgbdNormals)}");
        return rawPtr;
    }

    /// <summary>
    /// Creates a new RgbdNormals object.
    /// </summary>
    /// <param name="rows">the number of rows of the depth image normals will be computed on.</param>
    /// <param name="cols">the number of cols of the depth image normals will be computed on.</param>
    /// <param name="depth">the depth of the normals (only CV_32F or CV_64F).</param>
    /// <param name="K">the calibration matrix to use.</param>
    /// <param name="windowSize">the window size to compute the normals: can only be 1, 3, 5 or 7.</param>
    /// <param name="diffThreshold">threshold in depth difference, used in LINEMOD algorithm.</param>
    /// <param name="method">one of the methods to use.</param>
    public static RgbdNormals Create(
        int rows = 0, int cols = 0, int depth = 0, InputArray? K = null, int windowSize = 5,
        float diffThreshold = 50f, RgbdNormalsMethod method = RgbdNormalsMethod.RGBD_NORMALS_METHOD_FALS)
    {
        K?.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_RgbdNormals_create(
                rows, cols, depth, K?.CvPtr ?? IntPtr.Zero, windowSize, diffThreshold, (int)method, out var p));
        GC.KeepAlive(K);
        return new RgbdNormals(p);
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    public void Release()
    {
        Dispose();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Given a set of 3d points in a depth image, compute the normals at each point.
    /// </summary>
    /// <param name="points">a rows x cols x 3 matrix of CV_32F/CV_64F or a rows x cols x 1 CV_16U.</param>
    /// <param name="normals">a rows x cols x 3 matrix.</param>
    public void Apply(InputArray points, OutputArray normals)
    {
        ThrowIfDisposed();
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        if (normals is null)
            throw new ArgumentNullException(nameof(normals));
        points.ThrowIfDisposed();
        normals.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_RgbdNormals_apply(RawPtr, points.CvPtr, normals.CvPtr));
        normals.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(points);
    }

    /// <summary>
    /// Prepares cached data required for calculation.
    /// If not called by the user, called automatically at first calculation.
    /// </summary>
    public void Cache()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_RgbdNormals_cache(RawPtr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Gets or sets the number of rows.
    /// </summary>
    public int Rows
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_RgbdNormals_getRows(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_RgbdNormals_setRows(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the number of cols.
    /// </summary>
    public int Cols
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_RgbdNormals_getCols(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_RgbdNormals_setCols(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets the window size.
    /// </summary>
    public int WindowSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_RgbdNormals_getWindowSize(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_RgbdNormals_setWindowSize(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets the depth of the normals.
    /// </summary>
    public int Depth
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_RgbdNormals_getDepth(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }

    /// <summary>
    /// Gets the calibration matrix.
    /// </summary>
    /// <param name="val">the output calibration matrix.</param>
    public void GetK(OutputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_RgbdNormals_getK(RawPtr, val.CvPtr));
        val.Fix();
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Sets the calibration matrix.
    /// </summary>
    /// <param name="val">the calibration matrix to use.</param>
    public void SetK(InputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_RgbdNormals_setK(RawPtr, val.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(val);
    }

    /// <summary>
    /// Gets the method used to compute the normals.
    /// </summary>
    public RgbdNormalsMethod GetMethod()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_RgbdNormals_getMethod(RawPtr, out var ret));
        GC.KeepAlive(this);
        return (RgbdNormalsMethod)ret;
    }

    #endregion
}
