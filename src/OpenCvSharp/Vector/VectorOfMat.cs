using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfMat : DisposableCvObject, IStdVector<Mat>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfMat()
        {
            ptr = NativeMethods.vector_Mat_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfMat(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_Mat_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfMat(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mats"></param>
        public VectorOfMat(IEnumerable<Mat> mats)
        {
            if (mats == null)
                throw new ArgumentNullException(nameof(mats));

            var matPointers = EnumerableEx.SelectPtrs(mats);
            using (var matPointersPointer = new ArrayAddress1<IntPtr>(matPointers))
            {
                ptr = NativeMethods.vector_Mat_new3(
                    matPointersPointer.Pointer,
                    new IntPtr(matPointers.Length));
            }
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_Mat_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get { return NativeMethods.vector_Mat_getSize(ptr).ToInt32(); }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return NativeMethods.vector_Mat_getPointer(ptr); }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Mat[] ToArray()
        {
            return ToArray<Mat>();
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public T[] ToArray<T>()
            where T : Mat, new()
        {
            int size = Size;
            if (size == 0)
                return new T[0];

            T[] dst = new T[size];
            IntPtr[] dstPtr = new IntPtr[size];
            for (int i = 0; i < size; i++)
            {
                T m = new T();
                dst[i] = m;
                dstPtr[i] = m.CvPtr;
            }
            NativeMethods.vector_Mat_assignToArray(ptr, dstPtr);

            return dst;
        }

        /// <summary>
        /// 各要素の参照カウントを1追加する
        /// </summary>
        public void AddRef()
        {
            NativeMethods.vector_Mat_addref(ptr);
        }
    }
}
