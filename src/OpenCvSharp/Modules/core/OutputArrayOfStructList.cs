using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// Proxy datatype for passing Mat's and List&lt;&gt;'s as output parameters
    /// </summary>
    public sealed class OutputArrayOfStructList<T> : OutputArray
        where T : struct
    {
        private List<T> list;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        internal OutputArrayOfStructList(List<T> list)
            : base(new Mat())
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
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
                    int elemSize = MarshalHelper.SizeOf<T>();
                    MemoryHelper.CopyMemory(aa.Pointer, mat.Data, size * elemSize);
                }
                // リストにコピー
                list.Clear();
                list.AddRange(array);
            }
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            list = null;
            base.DisposeManaged();
        }
    }
}