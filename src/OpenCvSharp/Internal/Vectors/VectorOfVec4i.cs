namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Vec4i&gt;
/// </summary>
public class VectorOfVec4i : StdVector<Vec4i>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfVec4i()
        : base(NativeMethods.vector_Vec4i_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfVec4i(IEnumerable<Vec4i> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<Vec4i> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_Vec4i_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_Vec4i_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_Vec4i_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_Vec4i_delete(ptr);
}