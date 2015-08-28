using System;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    internal class VectorOfVectorPoint : DisposableCvObject, IStdVector<Point[]>
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose

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
                throw new ArgumentOutOfRangeException("size");
            ptr = NativeMethods.vector_vector_Point_new2(new IntPtr(size));
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
                        NativeMethods.vector_vector_Point_delete(ptr);
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
            get { return NativeMethods.vector_vector_Point_getSize1(ptr).ToInt32(); }
        }

        public int Size
        {
            get { return Size1; }
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public long[] Size2
        {
            get
            {
                int size1 = Size1;
                IntPtr[] size2Org = new IntPtr[size1];
                NativeMethods.vector_vector_Point_getSize2(ptr, size2Org);
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
            get { return NativeMethods.vector_vector_Point_getPointer(ptr); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Point[][] ToArray()
        {
            int size1 = Size1;
            if (size1 == 0)
                return new Point[0][];
            long[] size2 = Size2;

            Point[][] ret = new Point[size1][];
            for (int i = 0; i < size1; i++)
            {
                ret[i] = new Point[size2[i]];
            }
            using (ArrayAddress2<Point> retPtr = new ArrayAddress2<Point>(ret))
            {
                NativeMethods.vector_vector_Point_copy(ptr, retPtr);
            }
            return ret;
        }

        #endregion
    }
}
