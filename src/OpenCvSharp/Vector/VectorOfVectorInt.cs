using System;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfVectorInt : DisposableCvObject, IStdVector<int[]>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfVectorInt()
        {
            ptr = NativeMethods.vector_vector_int_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfVectorInt(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_vector_int_new2(new IntPtr(size));
        }
        
        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_vector_int_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size1
        {
            get { return NativeMethods.vector_vector_int_getSize1(ptr).ToInt32(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Size
        {
            get { return Size1; }
        }

        /// <summary>
        /// vector[i].size()
        /// </summary>
        public long[] Size2
        {
            get
            {
                int size1 = Size1;
                IntPtr[] size2Org = new IntPtr[size1];
                NativeMethods.vector_vector_int_getSize2(ptr, size2Org);
                long[] size2 = new long[size1];
                for (int i = 0; i < size1; i++)
                {
                    size2[i] = size2Org[i].ToInt64();
                }
                return size2;
            }
        }
        
        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return NativeMethods.vector_vector_int_getPointer(ptr); }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public int[][] ToArray()
        {
            int size1 = Size1;
            if (size1 == 0)
                return new int[0][];
            long[] size2 = Size2;

            var ret = new int[size1][];
            for (int i = 0; i < size1; i++)
            {
                ret[i] = new int[size2[i]];
            }
            using (var retPtr = new ArrayAddress2<int>(ret))
            {
                NativeMethods.vector_vector_int_copy(ptr, retPtr);
            }
            return ret;
        }
    }
}
