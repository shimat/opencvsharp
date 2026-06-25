namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Vec2f&gt;
/// </summary>
public class VectorOfVec2f : StdVector<Vec2f>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfVec2f()
        : base(NativeMethods.vector_Vec2f_new1()) { }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_Vec2f_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_Vec2f_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_Vec2f_delete(ptr);
}