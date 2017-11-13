using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfKeyPoint : DisposableCvObject, IStdVector<KeyPoint>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfKeyPoint()
        {
            ptr = NativeMethods.vector_KeyPoint_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfKeyPoint(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfKeyPoint(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_KeyPoint_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfKeyPoint(IEnumerable<KeyPoint> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            KeyPoint[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_KeyPoint_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_KeyPoint_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_KeyPoint_getSize(ptr).ToInt32();
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get
            {
                var res = NativeMethods.vector_KeyPoint_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public KeyPoint[] ToArray()
        {
            int size = Size;
            if (size == 0)
            {
                return new KeyPoint[0];
            }
            KeyPoint[] dst = new KeyPoint[size];
            using (var dstPtr = new ArrayAddress1<KeyPoint>(dst))
            {
                MemoryHelper.CopyMemory(dstPtr, ElemPtr, MarshalHelper.SizeOf<KeyPoint>() * dst.Length);
            }
            GC.KeepAlive(this); // ElemPtr is IntPtr to memory held by this object, so
                                // make sure we are not disposed until finished with copy.
            return dst;
        }
    }
}
