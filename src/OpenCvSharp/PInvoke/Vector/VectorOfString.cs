using System;
using System.Text;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfString : DisposableCvObject, IStdVector<string?>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfString()
        {
            ptr = NativeMethods.vector_string_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfString(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfString(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_string_new2(new IntPtr(size));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_string_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_string_getSize(ptr).ToInt32();
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public string?[] ToArray()
        {
            var size = Size;
            if (size == 0)
                return Array.Empty<string>();

            var ret = new string?[size];
            var cStringPointers = new IntPtr[size];
            var stringLengths = new int[size];

            NativeMethods.vector_string_getElements(ptr, cStringPointers, stringLengths);

            for (var i = 0; i < size; i++)
            {
                unsafe
                {
                    ret[i] = Encoding.UTF8.GetString((byte*) cStringPointers[i], stringLengths[i]);
                }
            }

            GC.KeepAlive(cStringPointers);
            GC.KeepAlive(stringLengths);
            GC.KeepAlive(this);
            return ret;
        }
    }
}
