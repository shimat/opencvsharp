namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;float&gt;
/// </summary>
public class VectorOfFloat : StdVector<float>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfFloat()
        : base(NativeMethods.vector_float_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfFloat(nuint size)
        : base(NativeMethods.vector_float_new2(size)) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfFloat(IEnumerable<float> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<float> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_float_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_float_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_float_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_float_delete(ptr);
}