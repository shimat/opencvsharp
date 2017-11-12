using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfDMatch : DisposableCvObject, IStdVector<DMatch>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfDMatch()
        {
            ptr = NativeMethods.vector_DMatch_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfDMatch(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfDMatch(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_DMatch_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfDMatch(IEnumerable<DMatch> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            DMatch[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_DMatch_new3(array, new IntPtr(array.Length));
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
                var res = NativeMethods.vector_DMatch_getSize(ptr).ToInt32();
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
            int size = Size;
            if (size == 0)
            {
                return new DMatch[0];
            }
            DMatch[] dst = new DMatch[size];
            using (var dstPtr = new ArrayAddress1<DMatch>(dst))
            {
                MemoryHelper.CopyMemory(dstPtr, ElemPtr, MarshalHelper.SizeOf<DMatch>()*dst.Length);
            }
            GC.KeepAlive(this); // ElemPtr is IntPtr to memory held by this object, so
                                // make sure we are not disposed until finished with copy.
            return dst;
        }
    }
}
