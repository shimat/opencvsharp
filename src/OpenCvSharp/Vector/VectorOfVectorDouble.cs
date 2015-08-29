using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    internal class VectorOfVectorDouble : DisposableCvObject, IStdVector<double[]>
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose

        /// <summary>
        /// 
        /// </summary>
        public VectorOfVectorDouble()
        {
            ptr = NativeMethods.vector_vector_double_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfVectorDouble(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = NativeMethods.vector_vector_double_new2(new IntPtr(size));
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (IsEnabledDispose)
                    {
                        NativeMethods.vector_vector_double_delete(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size1
        {
            get { return NativeMethods.vector_vector_double_getSize1(ptr).ToInt32(); }
        }

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
                NativeMethods.vector_vector_double_getSize2(ptr, size2Org);
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
            get { return NativeMethods.vector_vector_double_getPointer(ptr); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public double[][] ToArray()
        {
            int size1 = Size1;
            if (size1 == 0)
                return new double[0][];
            long[] size2 = Size2;

            var ret = new double[size1][];
            for (int i = 0; i < size1; i++)
            {
                ret[i] = new double[size2[i]];
            }
            using (var retPtr = new ArrayAddress2<double>(ret))
            {
                NativeMethods.vector_vector_double_copy(ptr, retPtr);
            }
            return ret;
        }

        #endregion
    }
}
