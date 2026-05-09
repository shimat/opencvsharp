using OpenCvSharp.Cuda;

namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
public class VectorOfGpuMat : CvObject, IStdVector<GpuMat>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfGpuMat()
    {
        var p = NativeMethods.vector_GpuMat_new1();
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfGpuMat(int size)
    {
        if (size < 0)
            throw new ArgumentOutOfRangeException(nameof(size));
        var p = NativeMethods.vector_GpuMat_new2((uint)size);
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mats"></param>
    public VectorOfGpuMat(IEnumerable<GpuMat> mats)
    {
        if (mats is null)
            throw new ArgumentNullException(nameof(mats));

        var matsArray = mats.ToArray();
        var matPointers = matsArray.Select(x => x.CvPtr).ToArray();

        var p = NativeMethods.vector_GpuMat_new3(
            matPointers,
            (uint)matPointers.Length);

        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));

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
        NativeMethods.vector_GpuMat_delete(CvPtr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_GpuMat_getSize(CvPtr);
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
            var res = NativeMethods.vector_GpuMat_getPointer(CvPtr);
            GC.KeepAlive(this);
            return res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public GpuMat[] ToArray()
    {
        return ToArray<GpuMat>();
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public T[] ToArray<T>()
        where T : GpuMat, new()
    {
        var size = Size;
        if (size == 0)
            return [];

        var dst = new T[size];
        var dstPtr = new IntPtr[size];
        for (var i = 0; i < size; i++)
        {
            var m = new T();
            dst[i] = m;
            dstPtr[i] = m.CvPtr;
        }
        NativeMethods.vector_GpuMat_assignToArray(CvPtr, dstPtr);
        GC.KeepAlive(this);

        return dst;
    }
}
