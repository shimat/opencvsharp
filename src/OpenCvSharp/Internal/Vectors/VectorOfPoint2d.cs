namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Point2d&gt;
/// </summary>
public class VectorOfPoint2d : StdVector<Point2d>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfPoint2d()
        : base(NativeMethods.vector_Point2d_new1()) { }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_Point2d_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_Point2d_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_Point2d_delete(ptr);
}