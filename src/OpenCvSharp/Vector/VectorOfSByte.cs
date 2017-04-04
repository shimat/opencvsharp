using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfSByte : DisposableCvObject, IStdVector<sbyte>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfSByte()
        {
            ptr = NativeMethods.vector_char_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfSByte(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_char_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfSByte(IEnumerable<sbyte> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            sbyte[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_char_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_char_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get { return NativeMethods.vector_char_getSize(ptr).ToInt32(); }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return NativeMethods.vector_char_getPointer(ptr); }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public sbyte[] ToArray()
        {
            int size = Size;
            if (size == 0)
            {
                return new sbyte[0];
            }
            byte[] dst = new byte[size];
            Marshal.Copy(ElemPtr, dst, 0, dst.Length);
            return EnumerableEx.SelectToArray(dst, b => (sbyte)b);
        }
    }
}
