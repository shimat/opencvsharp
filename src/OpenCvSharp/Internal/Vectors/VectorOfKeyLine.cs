#if false

namespace OpenCvSharp.Internal.Vectors
{
    /// <summary> 
    /// </summary>
    public class VectorOfKeyLine : DisposableCvObject, IStdVector<KeyLine>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VectorOfKeyLine()
        {
            ptr = NativeMethods.vector_KeyLine_new1();
        }
        
        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_KeyLine_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_KeyLine_getSize(ptr);
                GC.KeepAlive(this);
                return (int)res;
            }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get
            {
                var res = NativeMethods.vector_KeyLine_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public KeyLine[] ToArray()
        {
            var size = Size;
            if (size == 0)
            {
                return Array.Empty<KeyLine>();
            }
            var dst = new KeyLine[size];
            using (var dstPtr = new ArrayAddress1<KeyLine>(dst))
            {
                long bytesToCopy = Marshal.SizeOf<KeyLine>() * dst.Length;
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

#endif
