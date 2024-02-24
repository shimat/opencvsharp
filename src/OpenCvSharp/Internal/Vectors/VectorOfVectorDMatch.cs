using OpenCvSharp.Internal.Util;

namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
public class VectorOfVectorDMatch : DisposableCvObject, IStdVector<DMatch[]>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfVectorDMatch()
    {
        ptr = NativeMethods.vector_vector_DMatch_new1();
    }
        
    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_vector_DMatch_delete(ptr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int GetSize1()
    {
        var res = NativeMethods.vector_vector_DMatch_getSize1(ptr);
        GC.KeepAlive(this);
        return (int)res;
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size => GetSize1();

    /// <summary>
    /// vector[i].size()
    /// </summary>
    public IReadOnlyList<long> GetSize2()
    {
        var size1 = GetSize1();
        var size2 = new nuint[size1];
        NativeMethods.vector_vector_DMatch_getSize2(ptr, size2);
        GC.KeepAlive(this);
        return size2.Select(s => (long)s).ToArray();
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public DMatch[][] ToArray()
    {
        var size1 = GetSize1();
        if (size1 == 0)
            return Array.Empty<DMatch[]>();
        var size2 = GetSize2();

        var ret = new DMatch[size1][];
        for (var i = 0; i < size1; i++)
        {
            ret[i] = new DMatch[size2[i]];
        }

        using var retPtr = new ArrayAddress2<DMatch>(ret);
        NativeMethods.vector_vector_DMatch_copy(ptr, retPtr.GetPointer());
        GC.KeepAlive(this);
        return ret;
    }
}
