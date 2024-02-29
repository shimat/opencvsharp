namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
public class VectorOfMat : DisposableCvObject, IStdVector<Mat>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfMat()
    {
        ptr = NativeMethods.vector_Mat_new1();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfMat(int size)
    {
        if (size < 0)
            throw new ArgumentOutOfRangeException(nameof(size));
        ptr = NativeMethods.vector_Mat_new2((uint)size);
    }
        
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mats"></param>
    public VectorOfMat(IEnumerable<Mat> mats)
    {
        if (mats is null)
            throw new ArgumentNullException(nameof(mats));

        var matsArray = mats.ToArray();
        var matPointers = matsArray.Select(x => x.CvPtr).ToArray();

        ptr = NativeMethods.vector_Mat_new3(
            matPointers,
            (uint) matPointers.Length);

        GC.KeepAlive(matPointers);
        GC.KeepAlive(mats); // todo: rsb - should probably generate Mat[] and then get CvPtrs
        foreach (var m in matsArray)
        {
            GC.KeepAlive(m);
        }
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_Mat_delete(ptr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_Mat_getSize(ptr);
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
            var res = NativeMethods.vector_Mat_getPointer(ptr);
            GC.KeepAlive(this);
            return res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public Mat[] ToArray()
    {
        return ToArray<Mat>();
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public T[] ToArray<T>()
        where T : Mat, new()
    {
        var size = Size;
        if (size == 0)
            return Array.Empty<T>();

        var dst = new T[size];
        var dstPtr = new IntPtr[size];
        for (var i = 0; i < size; i++)
        {
            var m = new T();
            dst[i] = m;
            dstPtr[i] = m.CvPtr;
        }
        NativeMethods.vector_Mat_assignToArray(ptr, dstPtr);
        GC.KeepAlive(this);

        return dst;
    }
}
