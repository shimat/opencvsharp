using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
// ReSharper disable once InconsistentNaming
public class VectorOfPoint2d : DisposableCvObject, IStdVector<Point2d>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfPoint2d()
    {
        ptr = NativeMethods.vector_Point2d_new1();
    }
        
    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_Point2d_delete(ptr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_Point2d_getSize(ptr);
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
            var res = NativeMethods.vector_Point2d_getPointer(ptr);
            GC.KeepAlive(this);
            return res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public Point2d[] ToArray()
    {
        var size = Size;
        if (size == 0)
        {
            return Array.Empty<Point2d>();
        }
        var dst = new Point2d[size];
        using (var dstPtr = new ArrayAddress1<Point2d>(dst))
        {
            long bytesToCopy = Marshal.SizeOf<Point2d>() * dst.Length;
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
