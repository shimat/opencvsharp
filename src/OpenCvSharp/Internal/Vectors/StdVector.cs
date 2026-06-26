using System.Runtime.CompilerServices;

namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// Generic wrapper over a native <c>std::vector</c> whose element type is an unmanaged
/// (blittable) value type. A single <see cref="StdVector{T}"/> replaces the former
/// hand-written <c>VectorOfXxx</c> classes.
/// </summary>
/// <remarks>
/// The element-specific native entry points are selected by <c>typeof(T)</c> comparisons.
/// Because <typeparamref name="T"/> is always a value type, the JIT specializes each closed
/// generic (e.g. <c>StdVector&lt;int&gt;</c>) and folds those comparisons into compile-time
/// constants, so the dispatch collapses to a single direct P/Invoke call with no delegate
/// indirection and no per-call branching.
/// </remarks>
/// <typeparam name="T">Unmanaged element type matching the native <c>std::vector</c> element.</typeparam>
public class StdVector<T> : CvObject, IStdVector<T>
    where T : unmanaged
{
    /// <summary>
    /// Creates an empty vector.
    /// </summary>
    public StdVector()
        : this(New1()) { }

    /// <summary>
    /// Creates a vector pre-sized to <paramref name="size"/> default-initialized elements.
    /// </summary>
    public StdVector(nuint size)
        : this(New2(size)) { }

    /// <summary>
    /// Creates a vector populated from <paramref name="data"/>.
    /// </summary>
    public StdVector(IEnumerable<T> data)
        : this(New3FromEnumerable(data)) { }

    /// <summary>
    /// Wraps an existing native <c>std::vector</c> pointer.
    /// </summary>
    protected StdVector(IntPtr ptr)
        => SetSafeHandle(new OpenCvPtrSafeHandle(ptr, ownsHandle: false, releaseAction: null));

    private static IntPtr New3FromEnumerable(IEnumerable<T> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data as T[] ?? data.ToArray();
        return New3(array, (nuint)array.Length);
    }

    private static NotSupportedException Unsupported()
        => new($"StdVector<{typeof(T)}> is not supported.");

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        Delete(CvPtr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = GetSize(CvPtr);
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
            var res = GetPointer(CvPtr);
            GC.KeepAlive(this);
            return res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    public virtual T[] ToArray() => ToArray<T>();

    /// <summary>
    /// Converts std::vector to a managed array, reinterpreting each element as
    /// <typeparamref name="TResult"/> (which must have the same byte size as <typeparamref name="T"/>).
    /// </summary>
    public unsafe TResult[] ToArray<TResult>()
        where TResult : unmanaged
    {
        if (Unsafe.SizeOf<TResult>() != Unsafe.SizeOf<T>())
            throw new OpenCvSharpException($"Unsupported type '{typeof(TResult)}'");

        var size = Size;
        if (size == 0)
            return [];

        var dst = new TResult[size];
        new ReadOnlySpan<TResult>((void*)ElemPtr, size).CopyTo(dst);
        GC.KeepAlive(this);
        return dst;
    }

    // --- element-specific native dispatch (folded per specialization by the JIT) ---

    private static IntPtr New1()
    {
        if (typeof(T) == typeof(byte)) return NativeMethods.vector_uchar_new1();
        if (typeof(T) == typeof(int)) return NativeMethods.vector_int32_new1();
        if (typeof(T) == typeof(float)) return NativeMethods.vector_float_new1();
        if (typeof(T) == typeof(double)) return NativeMethods.vector_double_new1();
        if (typeof(T) == typeof(Point)) return NativeMethods.vector_Point2i_new1();
        if (typeof(T) == typeof(Point2f)) return NativeMethods.vector_Point2f_new1();
        if (typeof(T) == typeof(Point2d)) return NativeMethods.vector_Point2d_new1();
        if (typeof(T) == typeof(Point3f)) return NativeMethods.vector_Point3f_new1();
        if (typeof(T) == typeof(Rect)) return NativeMethods.vector_Rect_new1();
        if (typeof(T) == typeof(Rect2d)) return NativeMethods.vector_Rect2d_new1();
        if (typeof(T) == typeof(RotatedRect)) return NativeMethods.vector_RotatedRect_new1();
        if (typeof(T) == typeof(KeyPoint)) return NativeMethods.vector_KeyPoint_new1();
        if (typeof(T) == typeof(DMatch)) return NativeMethods.vector_DMatch_new1();
        if (typeof(T) == typeof(Vec2f)) return NativeMethods.vector_Vec2f_new1();
        if (typeof(T) == typeof(Vec3f)) return NativeMethods.vector_Vec3f_new1();
        if (typeof(T) == typeof(Vec4f)) return NativeMethods.vector_Vec4f_new1();
        if (typeof(T) == typeof(Vec4i)) return NativeMethods.vector_Vec4i_new1();
        if (typeof(T) == typeof(Vec6f)) return NativeMethods.vector_Vec6f_new1();
        if (typeof(T) == typeof(Vec6d)) return NativeMethods.vector_Vec6d_new1();
        throw Unsupported();
    }

    private static IntPtr New2(nuint size)
    {
        if (typeof(T) == typeof(byte)) return NativeMethods.vector_uchar_new2(size);
        if (typeof(T) == typeof(int)) return NativeMethods.vector_int32_new2(size);
        if (typeof(T) == typeof(float)) return NativeMethods.vector_float_new2(size);
        if (typeof(T) == typeof(double)) return NativeMethods.vector_double_new2(size);
        if (typeof(T) == typeof(Point)) return NativeMethods.vector_Point2i_new2(size);
        if (typeof(T) == typeof(Point2f)) return NativeMethods.vector_Point2f_new2(size);
        if (typeof(T) == typeof(Point3f)) return NativeMethods.vector_Point3f_new2(size);
        if (typeof(T) == typeof(Rect)) return NativeMethods.vector_Rect_new2(size);
        if (typeof(T) == typeof(Rect2d)) return NativeMethods.vector_Rect2d_new2(size);
        if (typeof(T) == typeof(RotatedRect)) return NativeMethods.vector_RotatedRect_new2(size);
        if (typeof(T) == typeof(KeyPoint)) return NativeMethods.vector_KeyPoint_new2(size);
        if (typeof(T) == typeof(DMatch)) return NativeMethods.vector_DMatch_new2(size);
        throw new NotSupportedException($"std::vector<{typeof(T)}> has no sized constructor.");
    }

    private static IntPtr New3(T[] data, nuint length)
    {
        if (typeof(T) == typeof(byte)) return NativeMethods.vector_uchar_new3((byte[])(object)data, length);
        if (typeof(T) == typeof(int)) return NativeMethods.vector_int32_new3((int[])(object)data, length);
        if (typeof(T) == typeof(float)) return NativeMethods.vector_float_new3((float[])(object)data, length);
        if (typeof(T) == typeof(double)) return NativeMethods.vector_double_new3((double[])(object)data, length);
        if (typeof(T) == typeof(Point)) return NativeMethods.vector_Point2i_new3((Point[])(object)data, length);
        if (typeof(T) == typeof(Point2f)) return NativeMethods.vector_Point2f_new3((Point2f[])(object)data, length);
        if (typeof(T) == typeof(Point3f)) return NativeMethods.vector_Point3f_new3((Point3f[])(object)data, length);
        if (typeof(T) == typeof(Rect)) return NativeMethods.vector_Rect_new3((Rect[])(object)data, length);
        if (typeof(T) == typeof(Rect2d)) return NativeMethods.vector_Rect2d_new3((Rect2d[])(object)data, length);
        if (typeof(T) == typeof(RotatedRect)) return NativeMethods.vector_RotatedRect_new3((RotatedRect[])(object)data, length);
        if (typeof(T) == typeof(KeyPoint)) return NativeMethods.vector_KeyPoint_new3((KeyPoint[])(object)data, length);
        if (typeof(T) == typeof(DMatch)) return NativeMethods.vector_DMatch_new3((DMatch[])(object)data, length);
        if (typeof(T) == typeof(Vec4f)) return NativeMethods.vector_Vec4f_new3((Vec4f[])(object)data, length);
        if (typeof(T) == typeof(Vec4i)) return NativeMethods.vector_Vec4i_new3((Vec4i[])(object)data, length);
        throw new NotSupportedException($"std::vector<{typeof(T)}> cannot be constructed from data.");
    }

    private static nuint GetSize(IntPtr ptr)
    {
        if (typeof(T) == typeof(byte)) return NativeMethods.vector_uchar_getSize(ptr);
        if (typeof(T) == typeof(int)) return NativeMethods.vector_int32_getSize(ptr);
        if (typeof(T) == typeof(float)) return NativeMethods.vector_float_getSize(ptr);
        if (typeof(T) == typeof(double)) return NativeMethods.vector_double_getSize(ptr);
        if (typeof(T) == typeof(Point)) return NativeMethods.vector_Point2i_getSize(ptr);
        if (typeof(T) == typeof(Point2f)) return NativeMethods.vector_Point2f_getSize(ptr);
        if (typeof(T) == typeof(Point2d)) return NativeMethods.vector_Point2d_getSize(ptr);
        if (typeof(T) == typeof(Point3f)) return NativeMethods.vector_Point3f_getSize(ptr);
        if (typeof(T) == typeof(Rect)) return NativeMethods.vector_Rect_getSize(ptr);
        if (typeof(T) == typeof(Rect2d)) return NativeMethods.vector_Rect2d_getSize(ptr);
        if (typeof(T) == typeof(RotatedRect)) return NativeMethods.vector_RotatedRect_getSize(ptr);
        if (typeof(T) == typeof(KeyPoint)) return NativeMethods.vector_KeyPoint_getSize(ptr);
        if (typeof(T) == typeof(DMatch)) return NativeMethods.vector_DMatch_getSize(ptr);
        if (typeof(T) == typeof(Vec2f)) return NativeMethods.vector_Vec2f_getSize(ptr);
        if (typeof(T) == typeof(Vec3f)) return NativeMethods.vector_Vec3f_getSize(ptr);
        if (typeof(T) == typeof(Vec4f)) return NativeMethods.vector_Vec4f_getSize(ptr);
        if (typeof(T) == typeof(Vec4i)) return NativeMethods.vector_Vec4i_getSize(ptr);
        if (typeof(T) == typeof(Vec6f)) return NativeMethods.vector_Vec6f_getSize(ptr);
        if (typeof(T) == typeof(Vec6d)) return NativeMethods.vector_Vec6d_getSize(ptr);
        throw Unsupported();
    }

    private static IntPtr GetPointer(IntPtr ptr)
    {
        if (typeof(T) == typeof(byte)) return NativeMethods.vector_uchar_getPointer(ptr);
        if (typeof(T) == typeof(int)) return NativeMethods.vector_int32_getPointer(ptr);
        if (typeof(T) == typeof(float)) return NativeMethods.vector_float_getPointer(ptr);
        if (typeof(T) == typeof(double)) return NativeMethods.vector_double_getPointer(ptr);
        if (typeof(T) == typeof(Point)) return NativeMethods.vector_Point2i_getPointer(ptr);
        if (typeof(T) == typeof(Point2f)) return NativeMethods.vector_Point2f_getPointer(ptr);
        if (typeof(T) == typeof(Point2d)) return NativeMethods.vector_Point2d_getPointer(ptr);
        if (typeof(T) == typeof(Point3f)) return NativeMethods.vector_Point3f_getPointer(ptr);
        if (typeof(T) == typeof(Rect)) return NativeMethods.vector_Rect_getPointer(ptr);
        if (typeof(T) == typeof(Rect2d)) return NativeMethods.vector_Rect2d_getPointer(ptr);
        if (typeof(T) == typeof(RotatedRect)) return NativeMethods.vector_RotatedRect_getPointer(ptr);
        if (typeof(T) == typeof(KeyPoint)) return NativeMethods.vector_KeyPoint_getPointer(ptr);
        if (typeof(T) == typeof(DMatch)) return NativeMethods.vector_DMatch_getPointer(ptr);
        if (typeof(T) == typeof(Vec2f)) return NativeMethods.vector_Vec2f_getPointer(ptr);
        if (typeof(T) == typeof(Vec3f)) return NativeMethods.vector_Vec3f_getPointer(ptr);
        if (typeof(T) == typeof(Vec4f)) return NativeMethods.vector_Vec4f_getPointer(ptr);
        if (typeof(T) == typeof(Vec4i)) return NativeMethods.vector_Vec4i_getPointer(ptr);
        if (typeof(T) == typeof(Vec6f)) return NativeMethods.vector_Vec6f_getPointer(ptr);
        if (typeof(T) == typeof(Vec6d)) return NativeMethods.vector_Vec6d_getPointer(ptr);
        throw Unsupported();
    }

    private static void Delete(IntPtr ptr)
    {
        if (typeof(T) == typeof(byte)) { NativeMethods.vector_uchar_delete(ptr); return; }
        if (typeof(T) == typeof(int)) { NativeMethods.vector_int32_delete(ptr); return; }
        if (typeof(T) == typeof(float)) { NativeMethods.vector_float_delete(ptr); return; }
        if (typeof(T) == typeof(double)) { NativeMethods.vector_double_delete(ptr); return; }
        if (typeof(T) == typeof(Point)) { NativeMethods.vector_Point2i_delete(ptr); return; }
        if (typeof(T) == typeof(Point2f)) { NativeMethods.vector_Point2f_delete(ptr); return; }
        if (typeof(T) == typeof(Point2d)) { NativeMethods.vector_Point2d_delete(ptr); return; }
        if (typeof(T) == typeof(Point3f)) { NativeMethods.vector_Point3f_delete(ptr); return; }
        if (typeof(T) == typeof(Rect)) { NativeMethods.vector_Rect_delete(ptr); return; }
        if (typeof(T) == typeof(Rect2d)) { NativeMethods.vector_Rect2d_delete(ptr); return; }
        if (typeof(T) == typeof(RotatedRect)) { NativeMethods.vector_RotatedRect_delete(ptr); return; }
        if (typeof(T) == typeof(KeyPoint)) { NativeMethods.vector_KeyPoint_delete(ptr); return; }
        if (typeof(T) == typeof(DMatch)) { NativeMethods.vector_DMatch_delete(ptr); return; }
        if (typeof(T) == typeof(Vec2f)) { NativeMethods.vector_Vec2f_delete(ptr); return; }
        if (typeof(T) == typeof(Vec3f)) { NativeMethods.vector_Vec3f_delete(ptr); return; }
        if (typeof(T) == typeof(Vec4f)) { NativeMethods.vector_Vec4f_delete(ptr); return; }
        if (typeof(T) == typeof(Vec4i)) { NativeMethods.vector_Vec4i_delete(ptr); return; }
        if (typeof(T) == typeof(Vec6f)) { NativeMethods.vector_Vec6f_delete(ptr); return; }
        if (typeof(T) == typeof(Vec6d)) { NativeMethods.vector_Vec6d_delete(ptr); return; }
        throw Unsupported();
    }
}