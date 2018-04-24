using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfRect2d : DisposableCvObject, IStdVector<Rect2d>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfRect2d()
        {
            ptr = NativeMethods.vector_Rect2d_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfRect2d(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_Rect2d_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfRect2d(IEnumerable<Rect2d> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            Rect2d[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_Rect2d_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_Rect2d_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_Rect2d_getSize(ptr).ToInt32();
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
                var res = NativeMethods.vector_Rect2d_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Rect2d[] ToArray()
        {
            int size = Size;
            if (size == 0)
            {
                return new Rect2d[0];
            }
            var dst = new Rect2d[size];
            using (var dstPtr = new ArrayAddress1<Rect2d>(dst))
            {
                MemoryHelper.CopyMemory(dstPtr, ElemPtr, Rect.SizeOf*dst.Length);
            }
            GC.KeepAlive(this); // ElemPtr is IntPtr to memory held by this object, so
                                // make sure we are not disposed until finished with copy.
            return dst;
        }
    }
}
