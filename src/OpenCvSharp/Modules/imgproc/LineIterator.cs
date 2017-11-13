using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// Contrast Limited Adaptive Histogram Equalization
    /// </summary>
    public sealed class LineIterator : DisposableCvObject, IEnumerable<LineIterator.Pixel>
    {
        private readonly Mat img;
        private readonly Point pt1;
        private readonly Point pt2;
        private readonly PixelConnectivity connectivity;
        private readonly bool leftToRight;

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
                throw new ArgumentNullException(nameof(img));
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
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.imgproc_LineIterator_delete(ptr);
            base.DisposeUnmanaged();
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
                GC.KeepAlive(this);
                yield return new Pixel(pos, value);

                NativeMethods.imgproc_LineIterator_operatorPP(ptr);
                GC.KeepAlive(this);
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
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_LineIterator_ptr_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IntPtr Ptr0
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_LineIterator_ptr0_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Step
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_LineIterator_step_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ElemSize
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_LineIterator_elemSize_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Err
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_LineIterator_err_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_LineIterator_count_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MinusDelta
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_LineIterator_minusDelta_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PlusDelta
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_LineIterator_plusDelta_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MinusStep
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_LineIterator_minusStep_get(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PlusStep
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_LineIterator_plusStep_get(ptr);
                GC.KeepAlive(this);
                return res;
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
            public unsafe byte* ValuePointer { get; }

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
                return MarshalHelper.PtrToStructure<T>(Value);
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
