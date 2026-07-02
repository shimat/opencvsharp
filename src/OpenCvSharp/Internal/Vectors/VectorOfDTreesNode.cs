using OpenCvSharp.ML;

namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
public class VectorOfDTreesNode : CvObject, IStdVector<DTrees.Node>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfDTreesNode()
    {
        var p = NativeMethods.vector_DTrees_Node_new1();
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
    }
        
    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_DTrees_Node_delete(CvPtr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_DTrees_Node_getSize(Handle);
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
            var res = NativeMethods.vector_DTrees_Node_getPointer(Handle);
            // Returns an interior pointer into this vector; keep it alive for the caller's dereference.
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
            return [];
        }
        unsafe
        {
            var dst = new ReadOnlySpan<DTrees.Node>((void*)ElemPtr, size).ToArray();
            // ElemPtr aliases memory held by this object; keep it alive until the copy completes.
            GC.KeepAlive(this);
            return dst;
        }
    }
}
