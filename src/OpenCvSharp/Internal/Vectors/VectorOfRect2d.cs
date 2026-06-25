namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Rect2d&gt;
/// </summary>
public class VectorOfRect2d : StdVector<Rect2d>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfRect2d()
        : base(NativeMethods.vector_Rect2d_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfRect2d(nuint size)
        : base(NativeMethods.vector_Rect2d_new2(size)) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfRect2d(IEnumerable<Rect2d> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<Rect2d> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_Rect2d_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_Rect2d_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_Rect2d_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_Rect2d_delete(ptr);
}