namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;int&gt;
/// </summary>
public class VectorOfInt32 : StdVector<int>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfInt32()
        : base(NativeMethods.vector_int32_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfInt32(nuint size)
        : base(NativeMethods.vector_int32_new2(size)) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfInt32(IEnumerable<int> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<int> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_int32_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_int32_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_int32_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_int32_delete(ptr);
}