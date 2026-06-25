namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Vec4f&gt;
/// </summary>
public class VectorOfVec4f : StdVector<Vec4f>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfVec4f()
        : base(NativeMethods.vector_Vec4f_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfVec4f(IEnumerable<Vec4f> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<Vec4f> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_Vec4f_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_Vec4f_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_Vec4f_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_Vec4f_delete(ptr);
}