using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;
using OpenCvSharp.ML;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    internal class VectorOfDTreesSplit : DisposableCvObject, IStdVector<DTrees.Split>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfDTreesSplit()
        {
            ptr = NativeMethods.vector_DTrees_Split_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfDTreesSplit(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfDTreesSplit(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_DTrees_Split_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfDTreesSplit(IEnumerable<DTrees.Split> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            DTrees.Split[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_DTrees_Split_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_DTrees_Split_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get { return NativeMethods.vector_DTrees_Split_getSize(ptr).ToInt32(); }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return NativeMethods.vector_DTrees_Split_getPointer(ptr); }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public DTrees.Split[] ToArray()
        {
            int size = Size;
            if (size == 0)
            {
                return new DTrees.Split[0];
            }
            var dst = new DTrees.Split[size];
            using (var dstPtr = new ArrayAddress1<DTrees.Split>(dst))
            {
                MemoryHelper.CopyMemory(dstPtr, ElemPtr, MarshalHelper.SizeOf<DTrees.Split>() * dst.Length);
            }
            return dst;
        }
    }
}
