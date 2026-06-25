namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::DMatch&gt;
/// </summary>
public class VectorOfDMatch : StdVector<DMatch>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfDMatch()
        : base(NativeMethods.vector_DMatch_new1()) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfDMatch(nuint size)
        : base(NativeMethods.vector_DMatch_new2(size)) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfDMatch(IEnumerable<DMatch> data)
        : base(New3(data)) { }

    private static IntPtr New3(IEnumerable<DMatch> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        return NativeMethods.vector_DMatch_new3(array, (nuint)array.Length);
    }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_DMatch_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_DMatch_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_DMatch_delete(ptr);
}