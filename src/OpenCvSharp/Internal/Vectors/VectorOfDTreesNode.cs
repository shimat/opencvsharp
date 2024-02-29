using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.ML;

namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
public class VectorOfDTreesNode : DisposableCvObject, IStdVector<DTrees.Node>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfDTreesNode()
    {
        ptr = NativeMethods.vector_DTrees_Node_new1();
    }
        
    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_DTrees_Node_delete(ptr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_DTrees_Node_getSize(ptr);
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
            var res = NativeMethods.vector_DTrees_Node_getPointer(ptr);
            GC.KeepAlive(this);
            return res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public DTrees.Node[] ToArray()
    {
        var size = Size;
        if (size == 0)
        {
            return Array.Empty<DTrees.Node>();
        }
        var dst = new DTrees.Node[size];
        using (var dstPtr = new ArrayAddress1<DTrees.Node>(dst))
        {
            long bytesToCopy = Marshal.SizeOf<DTrees.Node>() * dst.Length;
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
