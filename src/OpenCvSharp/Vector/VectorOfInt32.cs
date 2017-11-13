using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfInt32 : DisposableCvObject, IStdVector<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfInt32()
        {
            ptr = NativeMethods.vector_int32_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfInt32(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_int32_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        public VectorOfInt32(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfInt32(IEnumerable<int> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            int[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_int32_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_int32_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_int32_getSize(ptr).ToInt32();
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
                var res = NativeMethods.vector_int32_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public int[] ToArray()
        {
            int size = Size;
            if (size == 0)
            {
                return new int[0];
            }
            int[] dst = new int[size];
            Marshal.Copy(ElemPtr, dst, 0, dst.Length);
            GC.KeepAlive(this); // ElemPtr is IntPtr to memory held by this object, so
                                // make sure we are not disposed until finished with copy.
            return dst;
        }
    }
}
