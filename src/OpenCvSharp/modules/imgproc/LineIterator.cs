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

        private Mat img;
        private Point pt1;
        private Point pt2;
        private PixelConnectivity connectivity;
        private bool leftToRight;

        /// <summary>
        /// Constructor
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
            this.img = img;
            this.pt1 = pt1;
            this.pt2 = pt2;
            this.connectivity = connectivity;
            this.leftToRight = leftToRight;
        }

        /// <summary>
        /// Intializes the iterator
        /// </summary>
        /// <returns></returns>
        private void Initialize()
        {
            if (ptr != IntPtr.Zero)
                throw new OpenCvSharpException("invalid state");
            img.ThrowIfDisposed();

            ptr = NativeMethods.imgproc_LineIterator_new(
                img.CvPtr, pt1, pt2, (int)connectivity, leftToRight ? 1 : 0);
            disposed = false;
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
            //if (disposed)
            //    throw new ObjectDisposedException(GetType().Name);
            Dispose();
            Initialize();

            int count = NativeMethods.imgproc_LineIterator_count_get(ptr);
            for (int i = 0; i < count; i++)
            {
                Point pos = NativeMethods.imgproc_LineIterator_pos(ptr);
                IntPtr value = NativeMethods.imgproc_LineIterator_operatorEntity(ptr);
                yield return new Pixel(pos, value);

                NativeMethods.imgproc_LineIterator_operatorPP(ptr);
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

        /// <summary>
        /// 
        /// </summary>
        public IntPtr Ptr0
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_LineIterator_ptr0_get(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Step
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_LineIterator_step_get(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ElemSize
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_LineIterator_elemSize_get(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Err
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_LineIterator_err_get(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_LineIterator_count_get(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MinusDelta
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_LineIterator_minusDelta_get(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PlusDelta
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_LineIterator_plusDelta_get(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MinusStep
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_LineIterator_minusStep_get(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PlusStep
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_LineIterator_plusStep_get(ptr);
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
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="value"></param>
            /// <returns></returns>
            public void SetValue<T>(T value) where T : struct
            {
                Marshal.StructureToPtr(value, Value, false);
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
