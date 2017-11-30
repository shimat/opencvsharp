using System;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// std::vector&lt;cv::String&gt;
    /// </summary>
    public class VectorOfCvString : DisposableCvObject, IStdVector<string>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfCvString()
        {
            ptr = NativeMethods.vector_cvString_new1();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfCvString(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="size"></param>
        public VectorOfCvString(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_cvString_new2(new IntPtr(size));
        }

        /// <inheritdoc />
        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_cvString_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_cvString_getSize(ptr).ToInt32();
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
                var res = NativeMethods.vector_cvString_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public string[] ToArray()
        {
            int size = Size;
            if (size == 0)
                return new string[0];

            var ret = new string[size];
            for (int i = 0; i < size; i++)
            {
                unsafe
                {
                    sbyte* p = NativeMethods.vector_cvString_elemAt(ptr, i);
                    ret[i] = StringHelper.PtrToStringAnsi(p);
                }
            }
            GC.KeepAlive(this);
            return ret;
        }
    }
}
