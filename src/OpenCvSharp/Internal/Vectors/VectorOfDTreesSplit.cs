using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using OpenCvSharp.ML;
using OpenCvSharp.Util;

namespace OpenCvSharp.Internal.Vectors
{
    /// <summary> 
    /// </summary>
    internal class VectorOfDTreesSplit : DisposableCvObject, IStdVector<DTrees.Split>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VectorOfDTreesSplit()
        {
            ptr = NativeMethods.vector_DTrees_Split_new1();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size"></param>
        public VectorOfDTreesSplit(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_DTrees_Split_new2(new IntPtr(size));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public VectorOfDTreesSplit(IEnumerable<DTrees.Split> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            var array = data.ToArray();
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
            get
            {
                var res = NativeMethods.vector_DTrees_Split_getSize(ptr).ToInt32();
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
                var res = NativeMethods.vector_DTrees_Split_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public DTrees.Split[] ToArray()
        {
            var size = Size;
            if (size == 0)
            {
                return Array.Empty<DTrees.Split>();
            }
            var dst = new DTrees.Split[size];
            using (var dstPtr = new ArrayAddress1<DTrees.Split>(dst))
            {
                long bytesToCopy = Marshal.SizeOf<DTrees.Split>() * dst.Length;
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
}
