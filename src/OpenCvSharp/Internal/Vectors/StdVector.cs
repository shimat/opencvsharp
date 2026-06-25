using System.Runtime.CompilerServices;

namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// Base class for std::vector wrappers whose element type is an unmanaged
/// (blittable) value type. Provides the shared <see cref="Size"/>, <see cref="ElemPtr"/>,
/// <see cref="ToArray()"/> and disposal logic so that concrete <c>VectorOfXxx</c>
/// classes only need to wire the element-specific native entry points.
/// </summary>
/// <typeparam name="T">Unmanaged element type matching the native <c>std::vector</c> element.</typeparam>
public abstract class StdVector<T> : CvObject, IStdVector<T>
    where T : unmanaged
{
    /// <summary>
    /// Wraps a freshly created native <c>std::vector</c> pointer.
    /// </summary>
    /// <param name="ptr">Pointer returned by a native <c>vector_*_new*</c> call.</param>
    protected StdVector(IntPtr ptr)
        => SetSafeHandle(new OpenCvPtrSafeHandle(ptr, ownsHandle: false, releaseAction: null));

    /// <summary>
    /// Calls the element-specific native <c>vector_*_getSize</c>.
    /// </summary>
    protected abstract nuint GetSizeNative(IntPtr ptr);

    /// <summary>
    /// Calls the element-specific native <c>vector_*_getPointer</c>.
    /// </summary>
    protected abstract IntPtr GetPointerNative(IntPtr ptr);

    /// <summary>
    /// Calls the element-specific native <c>vector_*_delete</c>.
    /// </summary>
    protected abstract void DeleteNative(IntPtr ptr);

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        DeleteNative(CvPtr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = GetSizeNative(CvPtr);
            GC.KeepAlive(this);
            return (int)res;
        }
    }

    /// <summary>
    /// &amp;vector[0]
    /// </summary>
    public IntPtr ElemPtr
    {
        get
        {
            var res = GetPointerNative(CvPtr);
            GC.KeepAlive(this);
            return res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public virtual T[] ToArray() => ToArray<T>();

    /// <summary>
    /// Converts std::vector to a managed array, reinterpreting each element as
    /// <typeparamref name="TResult"/>. <typeparamref name="TResult"/> must have the
    /// same size as the native element type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="TResult">Destination element type (same byte size as <typeparamref name="T"/>).</typeparam>
    /// <returns></returns>
    public unsafe TResult[] ToArray<TResult>()
        where TResult : unmanaged
    {
        if (Unsafe.SizeOf<TResult>() != Unsafe.SizeOf<T>())
            throw new OpenCvSharpException($"Unsupported type '{typeof(TResult)}'");

        var size = Size;
        if (size == 0)
        {
            return [];
        }

        var dst = new TResult[size];
        new ReadOnlySpan<TResult>((void*)ElemPtr, size).CopyTo(dst);
        GC.KeepAlive(this); // ElemPtr points to memory held by this object, so
        // make sure we are not disposed until the copy has finished.
        return dst;
    }
}
