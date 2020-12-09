using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfVectorKeyPoint : DisposableCvObject, IStdVector<KeyPoint[]>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfVectorKeyPoint()
        {
            ptr = NativeMethods.vector_vector_KeyPoint_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfVectorKeyPoint(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_vector_KeyPoint_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        public VectorOfVectorKeyPoint(KeyPoint[][] values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            using (var aa = new ArrayAddress2<KeyPoint>(values))
            {
                ptr = NativeMethods.vector_vector_KeyPoint_new3(
                    aa.GetPointer(), aa.GetDim1Length(), aa.GetDim2Lengths());
            }
        }
        
        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_vector_KeyPoint_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int GetSize1()
        {
            var res = NativeMethods.vector_vector_KeyPoint_getSize1(ptr).ToInt32();
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size => GetSize1();

        /// <summary>
        /// vector[i].size()
        /// </summary>
        public IReadOnlyList<long> GetSize2()
        {
            var size1 = GetSize1();
            var size2Org = new IntPtr[size1];
            NativeMethods.vector_vector_KeyPoint_getSize2(ptr, size2Org);
            GC.KeepAlive(this);
            var size2 = new long[size1];
            for (var i = 0; i < size1; i++)
            {
                size2[i] = size2Org[i].ToInt64();
            }

            return size2;
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public KeyPoint[][] ToArray()
        {
            var size1 = GetSize1();
            if (size1 == 0)
                return Array.Empty<KeyPoint[]>();
            var size2 = GetSize2();

            var ret = new KeyPoint[size1][];
            for (var i = 0; i < size1; i++)
            {
                ret[i] = new KeyPoint[size2[i]];
            }
            using (var retPtr = new ArrayAddress2<KeyPoint>(ret))
            {
                NativeMethods.vector_vector_KeyPoint_copy(ptr, retPtr.GetPointer());
                GC.KeepAlive(this);
            }
            return ret;
        }
    }
}
