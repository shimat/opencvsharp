using OpenCvSharp.Internal.Util;

namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
public class VectorOfVectorKeyPoint : DisposableCvObject, IStdVector<KeyPoint[]>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfVectorKeyPoint()
    {
        ptr = NativeMethods.vector_vector_KeyPoint_new1();
    }
        
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="values"></param>
    public VectorOfVectorKeyPoint(KeyPoint[][] values)
    {
        if (values is null)
            throw new ArgumentNullException(nameof(values));

        using var aa = new ArrayAddress2<KeyPoint>(values);
        ptr = NativeMethods.vector_vector_KeyPoint_new3(
            aa.GetPointer(), aa.GetDim1Length(), aa.GetDim2Lengths());
    }
        
    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_vector_KeyPoint_delete(ptr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int GetSize1()
    {
        var res = NativeMethods.vector_vector_KeyPoint_getSize1(ptr);
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
        NativeMethods.vector_vector_KeyPoint_getSize2(ptr, size2);
        GC.KeepAlive(this);
        return size2.Select(s => (long)s).ToArray();
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public KeyPoint[][] ToArray()
    {
        var size1 = GetSize1();
        if (size1 == 0)
            return Array.Empty<KeyPoint[]>();
        var size2 = GetSize2();

        var ret = new KeyPoint[size1][];
        for (var i = 0; i < size1; i++)
        {
            ret[i] = new KeyPoint[size2[i]];
        }

        using var retPtr = new ArrayAddress2<KeyPoint>(ret);
        NativeMethods.vector_vector_KeyPoint_copy(ptr, retPtr.GetPointer());
        GC.KeepAlive(this);
        return ret;
    }
}
