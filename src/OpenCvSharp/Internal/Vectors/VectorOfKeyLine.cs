using OpenCvSharp.LineDescriptor;

namespace OpenCvSharp.Internal.Vectors
{
    /// <summary>
    /// </summary>
    public class VectorOfKeyLine : CvObject, IStdVector<KeyLine>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VectorOfKeyLine()
        {
            var p = NativeMethods.vector_KeyLine_new1();
            SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
        }
        
        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_KeyLine_delete(CvPtr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_KeyLine_getSize(Handle);
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
                var res = NativeMethods.vector_KeyLine_getPointer(Handle);
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
            unsafe
            {
                var dst = new ReadOnlySpan<KeyLine>((void*)ElemPtr, size).ToArray();
                // ElemPtr aliases memory held by this object; keep it alive until the copy completes.
                GC.KeepAlive(this);
                return dst;
            }
        }
    }
}
