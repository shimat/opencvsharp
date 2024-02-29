using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
public class VectorOfKeyPoint : DisposableCvObject, IStdVector<KeyPoint>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfKeyPoint()
    {
        ptr = NativeMethods.vector_KeyPoint_new1();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfKeyPoint(nuint size)
    {
        if (size < 0)
            throw new ArgumentOutOfRangeException(nameof(size));
        ptr = NativeMethods.vector_KeyPoint_new2(size);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfKeyPoint(IEnumerable<KeyPoint> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        ptr = NativeMethods.vector_KeyPoint_new3(array, (nuint)array.Length);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_KeyPoint_delete(ptr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_KeyPoint_getSize(ptr);
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
            var res = NativeMethods.vector_KeyPoint_getPointer(ptr);
            GC.KeepAlive(this);
            return res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public KeyPoint[] ToArray()
    {
        var size = Size;
        if (size == 0)
        {
            return Array.Empty<KeyPoint>();
        }
        var dst = new KeyPoint[size];
        using (var dstPtr = new ArrayAddress1<KeyPoint>(dst))
        {
            long bytesToCopy = Marshal.SizeOf<KeyPoint>() * dst.Length;
            unsafe
            {
                Buffer.MemoryCopy(ElemPtr.ToPointer(), dstPtr.Pointer.ToPointer(), bytesToCopy, bytesToCopy);
            }
        }
        GC.KeepAlive(this); // ElemPtr is IntPtr to memory held by this object, so
        // make sure we are not disposed until finished with copy.
        return dst;
    }
}
