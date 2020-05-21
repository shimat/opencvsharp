﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class VectorOfVec2f : DisposableCvObject, IStdVector<Vec2f>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfVec2f()
        {
            ptr = NativeMethods.vector_Vec2f_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfVec2f(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_Vec2f_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfVec2f(IEnumerable<Vec2f> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            var array = data.ToArray();
            ptr = NativeMethods.vector_Vec2f_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_Vec2f_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_Vec2f_getSize(ptr).ToInt32();
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get
            {
                var res = NativeMethods.vector_Vec2f_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Vec2f[] ToArray()
        {
            return ToArray<Vec2f>();
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <typeparam name="T">structure that has two float members (ex. CvLineSegmentPolar, CvPoint2D32f, PointF)</typeparam>
        /// <returns></returns>
        public T[] ToArray<T>() where T : unmanaged
        {
            var typeSize = Marshal.SizeOf<T>();
            if (typeSize != sizeof (float)*2)
                throw new OpenCvSharpException($"Unsupported type '{typeof(T)}'");

            var arySize = Size;
            if (arySize == 0)
            {
                return Array.Empty<T>();
            }
            else
            {
                var dst = new T[arySize];
                using (var dstPtr = new ArrayAddress1<T>(dst))
                {
                    MemoryHelper.CopyMemory(dstPtr.Pointer, ElemPtr, typeSize*dst.Length);
                }
                GC.KeepAlive(this); // ElemPtr is IntPtr to memory held by this object, so
                                    // make sure we are not disposed until finished with copy.
                return dst;
            }
        }
    }
}
