using System.Text;

namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
public class VectorOfString : CvObject, IStdVector<string?>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfString()
    {
        var p = NativeMethods.vector_string_new1();
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfString(int size)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(size);
        var p = NativeMethods.vector_string_new2((nuint)size);
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Creates a vector populated from <paramref name="data"/>.
    /// </summary>
    /// <param name="data"></param>
    public VectorOfString(IEnumerable<string> data)
    {
        ArgumentNullException.ThrowIfNull(data);
        var p = NativeMethods.vector_string_new1();
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
        foreach (var s in data)
        {
            if (s is null)
                throw new ArgumentException("Collection must not contain null elements.", nameof(data));
            NativeMethods.vector_string_pushBack(Handle, s);
        }
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_string_delete(CvPtr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_string_getSize(Handle);
            return (int)res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public string[] ToArray()
    {
        var size = Size;
        if (size == 0)
            return [];

        var ret = new string[size];
        var cStringPointers = new IntPtr[size];
        var stringLengths = new int[size];

        NativeMethods.vector_string_getElements(Handle, cStringPointers, stringLengths);

        for (var i = 0; i < size; i++)
        {
            unsafe
            {
                ret[i] = Encoding.UTF8.GetString((byte*) cStringPointers[i], stringLengths[i]);
            }
        }

        GC.KeepAlive(cStringPointers);
        GC.KeepAlive(stringLengths);
        // cStringPointers alias native memory held by this vector and were just dereferenced above.
        GC.KeepAlive(this);
        return ret;
    }
}
