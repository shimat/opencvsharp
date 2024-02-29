using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
public class VectorOfRotatedRect : DisposableCvObject, IStdVector<RotatedRect>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfRotatedRect()
    {
        ptr = NativeMethods.vector_RotatedRect_new1();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfRotatedRect(nuint size)
    {
        if (size < 0)
            throw new ArgumentOutOfRangeException(nameof(size));
        ptr = NativeMethods.vector_RotatedRect_new2(size);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfRotatedRect(IEnumerable<RotatedRect> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        ptr = NativeMethods.vector_RotatedRect_new3(array, (nuint)array.Length);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_RotatedRect_delete(ptr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_RotatedRect_getSize(ptr);
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
            var res = NativeMethods.vector_RotatedRect_getPointer(ptr);
            GC.KeepAlive(this);
            return res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public RotatedRect[] ToArray()
    {
        var size = Size;
        if (size == 0)            
            return Array.Empty<RotatedRect>();
            
        var dst = new RotatedRect[size];
        using (var dstPtr = new ArrayAddress1<RotatedRect>(dst))
        {
            long bytesToCopy = Marshal.SizeOf<RotatedRect>() * dst.Length;
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
