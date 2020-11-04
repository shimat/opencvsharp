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
        where T : unmanaged
    {
        private readonly List<T> list;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        internal OutputArrayOfStructList(List<T> list)
            : base(new Mat())
        {
            this.list = list ?? throw new ArgumentNullException(nameof(list));
        }

        /// <summary>
        /// 
        /// </summary>
        public override void AssignResult()
        {
            if (!IsReady())
                throw new NotSupportedException();

            // Matで結果取得
            NativeMethods.HandleException(
                NativeMethods.core_OutputArray_getMat(ptr, out var matPtr));
            GC.KeepAlive(this);
            using (var mat = new Mat(matPtr))
            {
                // 配列サイズ
                var size = mat.Rows * mat.Cols;
                // 配列にコピー
                var array = new T[size];
                using (var aa = new ArrayAddress1<T>(array))
                {
                    long bytesToCopy = Marshal.SizeOf<T>() * size;
                    unsafe
                    {
                        Buffer.MemoryCopy(mat.DataPointer, aa.Pointer.ToPointer(), bytesToCopy, bytesToCopy);
                    }
                }
                // リストにコピー
                list.Clear();
                list.AddRange(array);
            }
        }
    }
}