namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Rect&gt;
/// </summary>
public class VectorOfRect : StdVector<Rect>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfRect()
        : base(NativeMethods.vector_Rect_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfRect(nuint size)
        : base(NativeMethods.vector_Rect_new2(size)) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfRect(IEnumerable<Rect> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<Rect> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_Rect_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_Rect_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_Rect_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_Rect_delete(ptr);
}