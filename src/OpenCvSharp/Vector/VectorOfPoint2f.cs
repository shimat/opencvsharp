using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfPoint2f : DisposableCvObject, IStdVector<Point2f>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfPoint2f()
        {
            ptr = NativeMethods.vector_Point2f_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfPoint2f(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfPoint2f(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_Point2f_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfPoint2f(IEnumerable<Point2f> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            Point2f[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_Point2f_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_Point2f_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_Point2f_getSize(ptr).ToInt32();
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
                var res = NativeMethods.vector_Point2f_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Point2f[] ToArray()
        {
            int size = Size;
            if (size == 0)
            {
                return new Point2f[0];
            }
            Point2f[] dst = new Point2f[size];
            using (var dstPtr = new ArrayAddress1<Point2f>(dst))
            {
                MemoryHelper.CopyMemory(dstPtr, ElemPtr, Point2f.SizeOf*dst.Length);
            }
            GC.KeepAlive(this); // ElemPtr is IntPtr to memory held by this object, so
                                // make sure we are not disposed until finished with copy.
            return dst;
        }
    }
}
