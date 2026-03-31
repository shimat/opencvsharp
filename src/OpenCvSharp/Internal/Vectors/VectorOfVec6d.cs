using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp.Internal.Vectors;

/// <summary>
/// std::vector&lt;cv::Vec6d&gt;
/// </summary>
// ReSharper disable once InconsistentNaming
internal sealed class VectorOfVec6d : CvObject, IStdVector<Vec6d>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfVec6d()
    {
        var p = NativeMethods.vector_Vec6d_new1();
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_Vec6d_delete(CvPtr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_Vec6d_getSize(CvPtr);
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
            var res = NativeMethods.vector_Vec6d_getPointer(CvPtr);
            GC.KeepAlive(this);
            return res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    public Vec6d[] ToArray()
    {
        return ToArray<Vec6d>();
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <typeparam name="T">structure whose size equals sizeof(double)*6</typeparam>
    public T[] ToArray<T>() where T : unmanaged
    {
        var typeSize = Marshal.SizeOf<T>();
        if (typeSize != sizeof(double) * 6)
            throw new OpenCvSharpException($"Unsupported type '{typeof(T)}'");

        var arySize = Size;
        if (arySize == 0)
            return [];

        var dst = new T[arySize];
        using (var dstPtr = new ArrayAddress1<T>(dst))
        {
            long bytesToCopy = typeSize * dst.Length;
            unsafe
            {
                Buffer.MemoryCopy(ElemPtr.ToPointer(), dstPtr.Pointer.ToPointer(), bytesToCopy, bytesToCopy);
            }
        }
        GC.KeepAlive(this);
        return dst;
    }
}
