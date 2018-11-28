using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfRotatedRect : DisposableCvObject, IStdVector<RotatedRect>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfRotatedRect()
        {
            ptr = NativeMethods.vector_RotatedRect_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfRotatedRect(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_RotatedRect_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfRotatedRect(IEnumerable<RotatedRect> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            RotatedRect[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_RotatedRect_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_RotatedRect_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_RotatedRect_getSize(ptr).ToInt32();
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
                var res = NativeMethods.vector_RotatedRect_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public RotatedRect[] ToArray()
        {
            int size = Size;
            if (size == 0)            
                return new RotatedRect[0];
            
            var dst = new RotatedRect[size];
            using (var dstPtr = new ArrayAddress1<RotatedRect>(dst))
            {
                MemoryHelper.CopyMemory(dstPtr, ElemPtr, RotatedRect.SizeOf * dst.Length);
            }
            GC.KeepAlive(this); // ElemPtr is IntPtr to memory held by this object, so
                                // make sure we are not disposed until finished with copy.
            return dst;
        }
    }
}
