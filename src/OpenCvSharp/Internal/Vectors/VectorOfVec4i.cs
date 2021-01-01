using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class VectorOfVec4i : DisposableCvObject, IStdVector<Vec4i>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfVec4i()
        {
            ptr = NativeMethods.vector_Vec4i_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfVec4i(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_Vec4i_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfVec4i(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfVec4i(IEnumerable<Vec4i> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            var array = data.ToArray();
            ptr = NativeMethods.vector_Vec4i_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_Vec4i_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_Vec4i_getSize(ptr).ToInt32();
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
                var res = NativeMethods.vector_Vec4i_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Vec4i[] ToArray()
        {
            return ToArray<Vec4i>();
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <typeparam name="T">structure that has four int members (ex. CvLineSegmentPoint, CvRect)</typeparam>
        /// <returns></returns>
        public T[] ToArray<T>() where T : unmanaged
        {
            var typeSize = Marshal.SizeOf<T>();
            if (typeSize != sizeof (int)*4)
                throw new OpenCvSharpException($"Unsupported type '{typeof(T)}'");

            var arySize = Size;
            if (arySize == 0)
            {
                return Array.Empty<T>();
            }
            var dst = new T[arySize];
            using (var dstPtr = new ArrayAddress1<T>(dst))
            {
                long bytesToCopy = typeSize * dst.Length;
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
