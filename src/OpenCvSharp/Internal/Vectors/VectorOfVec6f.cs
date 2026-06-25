namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Vec6f&gt;
/// </summary>
public class VectorOfVec6f : StdVector<Vec6f>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfVec6f()
        : base(NativeMethods.vector_Vec6f_new1()) { }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_Vec6f_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_Vec6f_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_Vec6f_delete(ptr);
}