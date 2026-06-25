namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::RotatedRect&gt;
/// </summary>
public class VectorOfRotatedRect : StdVector<RotatedRect>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfRotatedRect()
        : base(NativeMethods.vector_RotatedRect_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfRotatedRect(nuint size)
        : base(NativeMethods.vector_RotatedRect_new2(size)) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfRotatedRect(IEnumerable<RotatedRect> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<RotatedRect> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_RotatedRect_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_RotatedRect_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_RotatedRect_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_RotatedRect_delete(ptr);
}