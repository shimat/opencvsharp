using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2fElem
    {
        /// <summary>
        /// 
        /// </summary>
        public float V1;
        /// <summary>
        /// 
        /// </summary>
        public float V2;
    }

    /// <summary>
    /// 
    /// </summary>
    public class StdVectorVec2f : DisposableCvObject, IStdVector
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose
        /// <summary>
        /// 
        /// </summary>
        public StdVectorVec2f()
        {
            ptr = CppInvoke.vector_cvVec2f_new1();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public StdVectorVec2f(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = CppInvoke.vector_cvVec2f_new2(new IntPtr(size));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public StdVectorVec2f(Vec2fElem[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            ptr = CppInvoke.vector_cvVec2f_new3(data, new IntPtr(data.Length));
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
                        CppInvoke.vector_cvVec2f_delete(ptr);
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
        public int Size
        {
            get { return CppInvoke.vector_cvVec2f_getSize(ptr).ToInt32(); }
        }
        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return CppInvoke.vector_cvVec2f_getPointer(ptr); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Vec2fElem[] ToArray()
        {
            return ToArray<Vec2fElem>();
        }
        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <typeparam name="T">structure that has two float members (ex. CvLineSegmentPolar, CvPoint2D32f, PointF)</typeparam>
        /// <returns></returns>
        public T[] ToArray<T>() where T : struct
        {
            int typeSize = Marshal.SizeOf(typeof(T));
            if (typeSize != sizeof(float) * 2)
            {
                throw new OpenCvSharpException();
            }

            int arySize = Size;
            if (arySize == 0)
            {
                return new T[0];
            }
            else
            {
                T[] dst = new T[arySize];
                using (ArrayAddress1<T> dstPtr = new ArrayAddress1<T>(dst))
                {
                    Util.CopyMemory(dstPtr, ElemPtr, typeSize * dst.Length);
                }
                return dst;
            }
        }
        #endregion
    }
}
