using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
// ReSharper disable once InconsistentNaming
internal class VectorOfVec6f : DisposableCvObject, IStdVector<Vec6f>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfVec6f()
    {
        ptr = NativeMethods.vector_Vec6f_new1();
    }
        
    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_Vec6f_delete(ptr);
        base.DisposeUnmanaged();
    }
        
    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_Vec6f_getSize(ptr);
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
            var res = NativeMethods.vector_Vec6f_getPointer(ptr);
            GC.KeepAlive(this);
            return res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public Vec6f[] ToArray()
    {
        return ToArray<Vec6f>();
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <typeparam name="T">structure that has four int members (ex. CvLineSegmentPoint, CvRect)</typeparam>
    /// <returns></returns>
    public T[] ToArray<T>() where T : unmanaged
    {
        var typeSize = Marshal.SizeOf<T>();
        if (typeSize != sizeof (float)*6)
            throw new OpenCvSharpException($"Unsupported type '{typeof(T)}'");

        var arySize = Size;
        if (arySize == 0)
        {
            return Array.Empty<T>();
        }
        var dst = new T[arySize];
        using (var dstPtr = new ArrayAddress1<T>(dst))
        {
            long bytesToCopy = typeSize * dst.Length;
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
