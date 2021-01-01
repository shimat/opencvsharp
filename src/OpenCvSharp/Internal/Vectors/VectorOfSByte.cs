using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

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
            var array = data.ToArray();
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
            get
            {
                var res = NativeMethods.vector_char_getSize(ptr).ToInt32();
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
                var res = NativeMethods.vector_char_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public sbyte[] ToArray()
        {
            var size = Size;
            if (size == 0)
            {
                return Array.Empty<sbyte>();
            }
            var dst = new byte[size];
            Marshal.Copy(ElemPtr, dst, 0, dst.Length);
            GC.KeepAlive(this); // ElemPtr is IntPtr to memory held by this object, so
                                // make sure we are not disposed until finished with copy.
            return dst.Select(b => (sbyte)b).ToArray();
        }
    }
}
