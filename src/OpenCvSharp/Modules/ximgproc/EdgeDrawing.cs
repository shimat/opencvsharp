using System.Runtime.InteropServices;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.XImgProc;

/// <summary>
/// Parameters for EdgeDrawing algorithms.
/// </summary>
/// <remarks>
/// Instances can only be obtained via <see cref="EdgeDrawing.GetParams"/> or <see cref="Default"/>,
/// ensuring the values are always initialized from the native C++ defaults.
/// </remarks>
public sealed class EdgeDrawingParams
{
    internal EdgeDrawingParams(CvEdgeDrawingParams p)
    {
        PFmode                     = p.PFmode != 0;
        EdgeDetectionOperator      = (GradientOperator)p.EdgeDetectionOperator;
        GradientThresholdValue     = p.GradientThresholdValue;
        AnchorThresholdValue       = p.AnchorThresholdValue;
        ScanInterval               = p.ScanInterval;
        MinPathLength              = p.MinPathLength;
        Sigma                      = p.Sigma;
        SumFlag                    = p.SumFlag != 0;
        NFAValidation              = p.NFAValidation != 0;
        MinLineLength              = p.MinLineLength;
        MaxDistanceBetweenTwoLines = p.MaxDistanceBetweenTwoLines;
        LineFitErrorThreshold      = p.LineFitErrorThreshold;
        MaxErrorThreshold          = p.MaxErrorThreshold;
    }

    /// <summary>
    /// Returns a new instance initialized with the native library's default values for
    /// <c>EdgeDrawing::Params</c>. Always stays in sync with the C++ defaults.
    /// </summary>
    public static EdgeDrawingParams Default()
    {
        NativeMethods.HandleException(NativeMethods.ximgproc_EdgeDrawing_Params_default(out var p));
        return new EdgeDrawingParams(p);
    }

    internal CvEdgeDrawingParams ToNative() => new()
    {
        PFmode                     = PFmode ? 1 : 0,
        EdgeDetectionOperator      = (int)EdgeDetectionOperator,
        GradientThresholdValue     = GradientThresholdValue,
        AnchorThresholdValue       = AnchorThresholdValue,
        ScanInterval               = ScanInterval,
        MinPathLength              = MinPathLength,
        Sigma                      = Sigma,
        SumFlag                    = SumFlag ? 1 : 0,
        NFAValidation              = NFAValidation ? 1 : 0,
        MinLineLength              = MinLineLength,
        MaxDistanceBetweenTwoLines = MaxDistanceBetweenTwoLines,
        LineFitErrorThreshold      = LineFitErrorThreshold,
        MaxErrorThreshold          = MaxErrorThreshold,
    };

    /// <summary>Parameter Free mode. Default: false.</summary>
    public bool PFmode { get; set; }

    /// <summary>
    /// Gradient operator for edge detection. One of <see cref="GradientOperator"/>. Default: PREWITT.
    /// </summary>
    public GradientOperator EdgeDetectionOperator { get; set; }

    /// <summary>Gradient threshold between pixels used to build the gradient image. Default: 20.</summary>
    public int GradientThresholdValue { get; set; }

    /// <summary>Threshold for selecting anchor points. Default: 0.</summary>
    public int AnchorThresholdValue { get; set; }

    /// <summary>Scan interval. Default: 1.</summary>
    public int ScanInterval { get; set; }

    /// <summary>Minimum connected-pixel length to form an edge segment. Default: 10.</summary>
    public int MinPathLength { get; set; }

    /// <summary>Sigma for internal GaussianBlur. Default: 1.0.</summary>
    public float Sigma { get; set; }

    /// <summary>Default: false.</summary>
    public bool SumFlag { get; set; }

    /// <summary>
    /// Whether NFA (Number of False Alarms) validation is used for lines and ellipses. Default: true.
    /// </summary>
    public bool NFAValidation { get; set; }

    /// <summary>Minimum line length to detect.</summary>
    public int MinLineLength { get; set; }

    /// <summary>Default: 6.0.</summary>
    public double MaxDistanceBetweenTwoLines { get; set; }

    /// <summary>Default: 1.0.</summary>
    public double LineFitErrorThreshold { get; set; }

    /// <summary>Default: 1.3.</summary>
    public double MaxErrorThreshold { get; set; }
}

/// <summary>
/// Class implementing the ED (EdgeDrawing), EDLines, EDPF, EDCircles and ColorED algorithms.
/// </summary>
public class EdgeDrawing : Algorithm
{
    private EdgeDrawing(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_EdgeDrawing_delete(p)))
    { }

    /// <summary>
    /// Creates a smart pointer to an EdgeDrawing object and initializes it.
    /// </summary>
    /// <returns>EdgeDrawing instance</returns>
    public static EdgeDrawing Create()
    {
        NativeMethods.HandleException(NativeMethods.ximgproc_createEdgeDrawing(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_EdgeDrawing_get(smartPtr, out var rawPtr));
        return new EdgeDrawing(smartPtr, rawPtr);
    }

    /// <summary>
    /// Detects edges in a grayscale or color image and prepares them to detect lines and ellipses.
    /// </summary>
    /// <param name="src">8-bit, single-channel (CV_8UC1) or color (CV_8UC3, CV_8UC4) input image.</param>
    public virtual void DetectEdges(InputArray src)
    {
        ThrowIfDisposed();
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        src.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeDrawing_detectEdges(RawPtr, src.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(src);
    }

    /// <summary>
    /// Returns the edge image prepared by <see cref="DetectEdges"/>.
    /// </summary>
    /// <param name="dst">8-bit, single-channel output image.</param>
    public virtual void GetEdgeImage(OutputArray dst)
    {
        ThrowIfDisposed();
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        dst.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeDrawing_getEdgeImage(RawPtr, dst.CvPtr));
        GC.KeepAlive(this);
        dst.Fix();
    }

    /// <summary>
    /// Returns the gradient image prepared by <see cref="DetectEdges"/>.
    /// </summary>
    /// <param name="dst">16-bit, single-channel output image.</param>
    public virtual void GetGradientImage(OutputArray dst)
    {
        ThrowIfDisposed();
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        dst.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeDrawing_getGradientImage(RawPtr, dst.CvPtr));
        GC.KeepAlive(this);
        dst.Fix();
    }

    /// <summary>
    /// Returns detected edge segments. Call <see cref="DetectEdges"/> first.
    /// </summary>
    /// <returns>Jagged array of edge segment points.</returns>
    public virtual Point[][] GetSegments()
    {
        ThrowIfDisposed();

        using var segments = new VectorOfVectorPoint();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeDrawing_getSegments(RawPtr, segments.CvPtr));
        GC.KeepAlive(this);
        return segments.ToArray();
    }

    /// <summary>
    /// Returns for each line found in <see cref="DetectLines(OutputArray)"/> its edge segment index in
    /// <see cref="GetSegments"/>.
    /// </summary>
    /// <returns>Edge segment indices of detected lines.</returns>
    public virtual int[] GetSegmentIndicesOfLines()
    {
        ThrowIfDisposed();

        using var indices = new VectorOfInt32();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeDrawing_getSegmentIndicesOfLines(RawPtr, indices.CvPtr));
        GC.KeepAlive(this);
        return indices.ToArray();
    }

    /// <summary>
    /// Detects lines and writes them into an OutputArray.
    /// Call <see cref="DetectEdges"/> before calling this function.
    /// </summary>
    /// <param name="lines">Output Vec4f array: start point (x1,y1) and end point (x2,y2) of each line.</param>
    public virtual void DetectLines(OutputArray lines)
    {
        ThrowIfDisposed();
        if (lines is null)
            throw new ArgumentNullException(nameof(lines));
        lines.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeDrawing_detectLines(RawPtr, lines.CvPtr));
        GC.KeepAlive(this);
        lines.Fix();
    }

    /// <summary>
    /// Detects lines and returns them as a managed array.
    /// Call <see cref="DetectEdges"/> before calling this function.
    /// </summary>
    /// <returns>Vec4f array: start point (x1,y1) and end point (x2,y2) of each line.</returns>
    public virtual Vec4f[] DetectLines()
    {
        ThrowIfDisposed();

        using var lines = new VectorOfVec4f();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeDrawing_detectLines_vector(RawPtr, lines.CvPtr));
        GC.KeepAlive(this);
        return lines.ToArray();
    }

    /// <summary>
    /// Detects circles and ellipses and writes them into an OutputArray.
    /// Call <see cref="DetectEdges"/> before calling this function.
    /// </summary>
    /// <param name="ellipses">
    /// Output Vec6d array: center point and perimeter for circles;
    /// center point, axes and angle for ellipses.
    /// </param>
    public virtual void DetectEllipses(OutputArray ellipses)
    {
        ThrowIfDisposed();
        if (ellipses is null)
            throw new ArgumentNullException(nameof(ellipses));
        ellipses.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeDrawing_detectEllipses(RawPtr, ellipses.CvPtr));
        GC.KeepAlive(this);
        ellipses.Fix();
    }

    /// <summary>
    /// Detects circles and ellipses and returns them as a managed array.
    /// Call <see cref="DetectEdges"/> before calling this function.
    /// </summary>
    /// <returns>
    /// Vec6d array: center point and perimeter for circles;
    /// center point, axes and angle for ellipses.
    /// </returns>
    public virtual Vec6d[] DetectEllipses()
    {
        ThrowIfDisposed();

        using var ellipses = new VectorOfVec6d();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeDrawing_detectEllipses_vector(RawPtr, ellipses.CvPtr));
        GC.KeepAlive(this);
        return ellipses.ToArray();
    }

    /// <summary>
    /// Returns the current algorithm parameters.
    /// </summary>
    public virtual EdgeDrawingParams GetParams()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeDrawing_getParams(RawPtr, out var p));
        GC.KeepAlive(this);
        return new EdgeDrawingParams(p);
    }

    /// <summary>
    /// Sets algorithm parameters.
    /// </summary>
    /// <param name="parameters">Parameters to apply.</param>
    public virtual void SetParams(EdgeDrawingParams parameters)
    {
        ThrowIfDisposed();
        if (parameters is null)
            throw new ArgumentNullException(nameof(parameters));

        var native = parameters.ToNative();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeDrawing_setParams(RawPtr, ref native));
        GC.KeepAlive(this);
    }
}
