using System;
using System.Collections.Generic;

namespace OpenCvSharp
{
    /// <summary>
    /// Proxy datatype for passing Mat's and List&lt;&gt;'s as output parameters
    /// </summary>
    public sealed class OutputArrayOfMatList : OutputArray
    {
        private bool disposed;
        private List<Mat> list;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        internal OutputArrayOfMatList(List<Mat> list)
            : base(list)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            this.list = list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Mat> GetVectorOfMat()
        {
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void AssignResult()
        {
            if (!IsReady())
                throw new NotSupportedException();

            // Matで結果取得
            using (var vectorOfMat = new VectorOfMat())
            {
                NativeMethods.core_OutputArray_getVectorOfMat(ptr, vectorOfMat.CvPtr);
                list.Clear();
                list.AddRange(vectorOfMat.ToArray());
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