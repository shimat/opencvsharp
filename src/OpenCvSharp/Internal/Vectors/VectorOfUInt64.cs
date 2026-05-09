using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal.Vectors
{
    public class VectorOfUInt64 : CvObject, IStdVector<ulong>
    {
        public VectorOfUInt64()
        {
            var p = NativeMethods.vector_uint64_new1();
            SetSafeHandle(new OpenCvPtrSafeHandle(p, true, h => NativeMethods.vector_uint64_delete(h)));
        }

        public int Size
        {
            get
            {
                var res = NativeMethods.vector_uint64_getSize(CvPtr);
                GC.KeepAlive(this);
                return (int)res;
            }
        }

        public IntPtr ElemPtr
        {
            get
            {
                var res = NativeMethods.vector_uint64_getPointer(CvPtr);
                GC.KeepAlive(this);
                return res;
            }
        }

        public ulong[] ToArray()
        {
            var size = Size;
            if (size == 0) return Array.Empty<ulong>();
            var dst = new ulong[size];
            // Marshal.Copy has no ulong overload, so we use long and cast
            Marshal.Copy(ElemPtr, (long[])(object)dst, 0, dst.Length);
            GC.KeepAlive(this);
            return dst;
        }
    }
}
