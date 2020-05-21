﻿using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfVectorPoint : DisposableCvObject, IStdVector<Point[]>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfVectorPoint()
        {
            ptr = NativeMethods.vector_vector_Point_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfVectorPoint(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfVectorPoint(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_vector_Point_new2(new IntPtr(size));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_vector_Point_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int GetSize1()
        {
            var res = NativeMethods.vector_vector_Point_getSize1(ptr).ToInt32();
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Size => GetSize1();

        /// <summary>
        /// vector.size()
        /// </summary>
        public IReadOnlyList<long> GetSize2()
        {
            var size1 = GetSize1();
            var size2Org = new IntPtr[size1];
            NativeMethods.vector_vector_Point_getSize2(ptr, size2Org);
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
        public Point[][] ToArray()
        {
            var size1 = GetSize1();
            if (size1 == 0)
                return Array.Empty<Point[]>();
            var size2 = GetSize2();

            var ret = new Point[size1][];
            for (var i = 0; i < size1; i++)
            {
                ret[i] = new Point[size2[i]];
            }
            using (var retPtr = new ArrayAddress2<Point>(ret))
            {
                NativeMethods.vector_vector_Point_copy(ptr, retPtr.GetPointer());
                GC.KeepAlive(this);
            }
            return ret;
        }
    }
}
