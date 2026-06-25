namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Vec6d&gt;
/// </summary>
public class VectorOfVec6d : StdVector<Vec6d>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfVec6d()
        : base(NativeMethods.vector_Vec6d_new1()) { }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_Vec6d_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_Vec6d_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_Vec6d_delete(ptr);
}