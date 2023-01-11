#if false

namespace OpenCvSharp.Internal.Vectors
{
    /// <summary> 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class VectorOfVectorKeyLine : DisposableCvObject, IStdVector<KeyLine[]>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VectorOfVectorKeyLine()
        {
            ptr = NativeMethods.vector_vector_KeyLine_new1();
        }
        
        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_vector_KeyLine_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int GetSize1()
        {
            var res = NativeMethods.vector_vector_KeyLine_getSize1(ptr);
            GC.KeepAlive(this);
            return (int)res;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Size => GetSize1();

        /// <summary>
        /// vector[i].size()
        /// </summary>
        public IReadOnlyList<long> GetSize2()
        {
            var size1 = GetSize1();
            var size2 = new nuint[size1];
            NativeMethods.vector_vector_KeyLine_getSize2(ptr, size2);
            GC.KeepAlive(this);
            return size2.Select(s => (long)s).ToArray();
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public KeyLine[][] ToArray()
        {
            var size1 = GetSize1();
            if (size1 == 0)
                return Array.Empty<KeyLine[]>();
            var size2 = GetSize2();

            var ret = new KeyLine[size1][];
            for (var i = 0; i < size1; i++)
            {
                ret[i] = new KeyLine[size2[i]];
            }

            using var retPtr = new ArrayAddress2<KeyLine>(ret);
            NativeMethods.vector_vector_KeyLine_copy(ptr, retPtr.GetPointer());
            GC.KeepAlive(this);
            return ret;
        }
    }
}

#endif
