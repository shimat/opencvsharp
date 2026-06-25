namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Point&gt;
/// </summary>
public class VectorOfPoint : StdVector<Point>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfPoint()
        : base(NativeMethods.vector_Point2i_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfPoint(nuint size)
        : base(NativeMethods.vector_Point2i_new2(size)) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfPoint(IEnumerable<Point> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<Point> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_Point2i_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_Point2i_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_Point2i_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_Point2i_delete(ptr);
}