﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp.Internal.Vectors;

/// <summary> 
/// </summary>
public class VectorOfDMatch : DisposableCvObject, IStdVector<DMatch>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public VectorOfDMatch()
    {
        ptr = NativeMethods.vector_DMatch_new1();
    }
        
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="size"></param>
    public VectorOfDMatch(nuint size)
    {
        if (size < 0)
            throw new ArgumentOutOfRangeException(nameof(size));
        ptr = NativeMethods.vector_DMatch_new2(size);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public VectorOfDMatch(IEnumerable<DMatch> data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        var array = data.ToArray();
        ptr = NativeMethods.vector_DMatch_new3(array, (nuint)array.Length);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.vector_DMatch_delete(ptr);
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// vector.size()
    /// </summary>
    public int Size
    {
        get
        {
            var res = NativeMethods.vector_DMatch_getSize(ptr);
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
            var res = NativeMethods.vector_DMatch_getPointer(ptr);
            GC.KeepAlive(this);
            return res;
        }
    }

    /// <summary>
    /// Converts std::vector to managed array
    /// </summary>
    /// <returns></returns>
    public DMatch[] ToArray()
    {
        var size = Size;
        if (size == 0)
        {
            return Array.Empty<DMatch>();
        }
        var dst = new DMatch[size];
        using (var dstPtr = new ArrayAddress1<DMatch>(dst))
        {
            long bytesToCopy = Marshal.SizeOf<DMatch>() * dst.Length;
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
