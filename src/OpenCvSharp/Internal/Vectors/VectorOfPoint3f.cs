namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Point3f&gt;
/// </summary>
public class VectorOfPoint3f : StdVector<Point3f>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfPoint3f()
        : base(NativeMethods.vector_Point3f_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfPoint3f(nuint size)
        : base(NativeMethods.vector_Point3f_new2(size)) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfPoint3f(IEnumerable<Point3f> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<Point3f> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_Point3f_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_Point3f_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_Point3f_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_Point3f_delete(ptr);
}