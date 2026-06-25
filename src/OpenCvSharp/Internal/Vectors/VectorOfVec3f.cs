namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Vec3f&gt;
/// </summary>
public class VectorOfVec3f : StdVector<Vec3f>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfVec3f()
        : base(NativeMethods.vector_Vec3f_new1()) { }

    /// <inheritdoc />
    protected override nuint GetSizeNative(IntPtr ptr) => NativeMethods.vector_Vec3f_getSize(ptr);

    /// <inheritdoc />
    protected override IntPtr GetPointerNative(IntPtr ptr) => NativeMethods.vector_Vec3f_getPointer(ptr);

    /// <inheritdoc />
    protected override void DeleteNative(IntPtr ptr) => NativeMethods.vector_Vec3f_delete(ptr);
}