namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;uchar&gt;
/// </summary>
public class VectorOfByte : StdVector<byte>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfByte()
        : base(NativeMethods.vector_uchar_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfByte(nuint size)
        : base(NativeMethods.vector_uchar_new2(size)) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfByte(IEnumerable<byte> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<byte> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_uchar_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_uchar_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_uchar_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_uchar_delete(ptr);
}