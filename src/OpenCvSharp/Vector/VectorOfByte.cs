using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfByte : DisposableCvObject, IStdVector<byte>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfByte()
        {
            ptr = NativeMethods.vector_uchar_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfByte(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_uchar_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfByte(IEnumerable<byte> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            byte[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_uchar_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_uchar_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_uchar_getSize(ptr).ToInt32();
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
                var res = NativeMethods.vector_uchar_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public byte[] ToArray()
        {
            int size = Size;
            if (size == 0)
            {
                return new byte[0];
            }
            byte[] dst = new byte[size];
            Marshal.Copy(ElemPtr, dst, 0, dst.Length);
            GC.KeepAlive(this); // ElemPtr is IntPtr to memory held by this object, so
                                // make sure we are not disposed until finished with copy.
            return dst;
        }
    }
}
