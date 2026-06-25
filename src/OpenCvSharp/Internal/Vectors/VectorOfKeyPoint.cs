namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::KeyPoint&gt;
/// </summary>
public class VectorOfKeyPoint : StdVector<KeyPoint>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfKeyPoint()
        : base(NativeMethods.vector_KeyPoint_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfKeyPoint(nuint size)
        : base(NativeMethods.vector_KeyPoint_new2(size)) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfKeyPoint(IEnumerable<KeyPoint> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<KeyPoint> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_KeyPoint_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_KeyPoint_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_KeyPoint_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_KeyPoint_delete(ptr);
}