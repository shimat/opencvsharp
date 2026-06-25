namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Point2f&gt;
/// </summary>
public class VectorOfPoint2f : StdVector<Point2f>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfPoint2f()
        : base(NativeMethods.vector_Point2f_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfPoint2f(nuint size)
        : base(NativeMethods.vector_Point2f_new2(size)) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfPoint2f(IEnumerable<Point2f> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<Point2f> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_Point2f_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_Point2f_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_Point2f_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_Point2f_delete(ptr);
}