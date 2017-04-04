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
    public class VectorOfDTreesNode : DisposableCvObject, IStdVector<DTrees.Node>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfDTreesNode()
        {
            ptr = NativeMethods.vector_DTrees_Node_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfDTreesNode(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfDTreesNode(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_DTrees_Node_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfDTreesNode(IEnumerable<DTrees.Node> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            DTrees.Node[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_DTrees_Node_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_DTrees_Node_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get { return NativeMethods.vector_DTrees_Node_getSize(ptr).ToInt32(); }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return NativeMethods.vector_DTrees_Node_getPointer(ptr); }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public DTrees.Node[] ToArray()
        {
            int size = Size;
            if (size == 0)
            {
                return new DTrees.Node[0];
            }
            var dst = new DTrees.Node[size];
            using (var dstPtr = new ArrayAddress1<DTrees.Node>(dst))
            {
                MemoryHelper.CopyMemory(dstPtr, ElemPtr, MarshalHelper.SizeOf<DTrees.Node>() * dst.Length);
            }
            return dst;
        }
    }
}
