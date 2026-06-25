namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;double&gt;
/// </summary>
public class VectorOfDouble : StdVector<double>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfDouble()
        : base(NativeMethods.vector_double_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfDouble(nuint size)
        : base(NativeMethods.vector_double_new2(size)) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfDouble(IEnumerable<double> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<double> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_double_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_double_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_double_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_double_delete(ptr);
}