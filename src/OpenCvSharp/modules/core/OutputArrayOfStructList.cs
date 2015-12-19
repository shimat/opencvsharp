using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// Proxy datatype for passing Mat's and List&lt;&gt;'s as output parameters
    /// </summary>
    public sealed class OutputArrayOfStructList<T> : OutputArray
        where T : struct
    {
        private bool disposed;
        private List<T> list;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        internal OutputArrayOfStructList(List<T> list)
            : base(new Mat())
        {
            if (list == null)
                throw new ArgumentNullException("list");
            this.list = list;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void AssignResult()
        {
            if (!IsReady())
                throw new NotSupportedException();

            // Matで結果取得
            IntPtr matPtr = NativeMethods.core_OutputArray_getMat(ptr);
            using (Mat mat = new Mat(matPtr))
            {
                // 配列サイズ
                int size = mat.Rows * mat.Cols;
                // 配列にコピー
                T[] array = new T[size];
                using (ArrayAddress1<T> aa = new ArrayAddress1<T>(array))
                {
                    int elemSize = Marshal.SizeOf(typeof(T));
                    Utility.CopyMemory(aa.Pointer, mat.Data, size * elemSize);
                }
                // リストにコピー
                list.Clear();
                list.AddRange(array);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                list = null;
                disposed = true;
                base.Dispose(disposing);
            }
        }
    }
}