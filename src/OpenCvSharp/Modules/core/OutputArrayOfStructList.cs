using System;
using System.Collections.Generic;
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
            var matPtr = NativeMethods.core_OutputArray_getMat(ptr);
            GC.KeepAlive(this);
            using (var mat = new Mat(matPtr))
            {
                // 配列サイズ
                var size = mat.Rows * mat.Cols;
                // 配列にコピー
                var array = new T[size];
                using (var aa = new ArrayAddress1<T>(array))
                {
                    var elemSize = MarshalHelper.SizeOf<T>();
                    MemoryHelper.CopyMemory(aa.Pointer, mat.Data, size * elemSize);
                }
                // リストにコピー
                list.Clear();
                list.AddRange(array);
            }
        }
    }
}