namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// </summary>
public class VectorOfMatchQuasiDense : CvObject, IStdVector<MatchQuasiDense>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfMatchQuasiDense()
    {
        var p = NativeMethods.vector_MatchQuasiDense_new1();
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Creates a vector populated with matches.
    /// </summary>
    public unsafe VectorOfMatchQuasiDense(IEnumerable<MatchQuasiDense> matches)
    {
        ArgumentNullException.ThrowIfNull(matches);
        var data = matches.ToArray();
        fixed (MatchQuasiDense* pointer = data)
        {
            var p = NativeMethods.vector_MatchQuasiDense_new2(pointer, (nuint)data.Length);
            SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
        }
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_MatchQuasiDense_delete(CvPtr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_MatchQuasiDense_getSize(Handle);
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
            var res = NativeMethods.vector_MatchQuasiDense_getPointer(Handle);
            GC.KeepAlive(this);
            return res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public MatchQuasiDense[] ToArray()
    {
        var size = Size;
        if (size == 0)
        {
            return [];
        }
        unsafe
        {
            var dst = new ReadOnlySpan<MatchQuasiDense>((void*)ElemPtr, size).ToArray();
            // ElemPtr aliases memory held by this object; keep it alive until the copy completes.
            GC.KeepAlive(this);
            return dst;
        }
    }
}
