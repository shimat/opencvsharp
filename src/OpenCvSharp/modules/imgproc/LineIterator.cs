using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// Contrast Limited Adaptive Histogram Equalization
    /// </summary>
    public sealed class LineIterator : DisposableCvObject, IEnumerable<LineIterator.Pixel>
    {
        private bool disposed;

        /// <summary>
        /// Intializes the iterator
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <param name="connectivity"></param>
        /// <param name="leftToRight"></param>
        /// <returns></returns>
        public LineIterator(
            Mat img,
            Point pt1,
            Point pt2,
            PixelConnectivity connectivity = PixelConnectivity.Connectivity8,
            bool leftToRight = false)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            ptr = NativeMethods.imgproc_LineIterator_new(
                img.CvPtr, pt1, pt2, (int)connectivity, leftToRight ? 1 : 0);
        }

#if LANG_JP
    /// <summary>
    /// リソースの解放
    /// </summary>
    /// <param name="disposing">
    /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
    /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
    ///</param>
#else
        /// <summary>
        /// Releases the resources
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    // releases managed resources
                    if (disposing)
                    {
                    }
                    // releases unmanaged resources
                    if (IsEnabledDispose)
                    {
                        if (ptr != IntPtr.Zero)
                            NativeMethods.imgproc_LineIterator_delete(ptr);
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Pixel> GetEnumerator()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

            int count = NativeMethods.imgproc_LineIterator_count_get(ptr);
            for (int i = 0; i < count; i++)
            {
                Point pos = NativeMethods.imgproc_LineIterator_pos(ptr);
                IntPtr value = NativeMethods.imgproc_LineIterator_operatorEntity(ptr);
                yield return new Pixel(pos, value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public IntPtr Ptr 
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_LineIterator_ptr_get(ptr);
            } 
        }

        #endregion

        /// <summary>
        /// LineIterator pixel data
        /// </summary>
        public class Pixel
        {
            /// <summary>
            /// 
            /// </summary>
            public unsafe byte* ValuePointer { get; private set; }

            /// <summary>
            /// 
            /// </summary>
            public Point Pos { get; private set; }

            /// <summary>
            /// 
            /// </summary>
            public IntPtr Value
            {
                get
                {
                    unsafe
                    {
                        return new IntPtr(ValuePointer);
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public T GetValue<T>() where T : struct
            {
                return (T)Marshal.PtrToStructure(Value, typeof (T));
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="pos"></param>
            /// <param name="value"></param>
            internal unsafe Pixel(Point pos, IntPtr value)
            {
                Pos = pos;
                ValuePointer = (byte*)value.ToPointer();
            }
        }
    }
}
