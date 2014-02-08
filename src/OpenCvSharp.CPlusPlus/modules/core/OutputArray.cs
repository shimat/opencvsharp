using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class OutputArray : InputArray
    {
        private bool disposed;
        private readonly object obj;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal OutputArray(Mat mat)
        {
            if(mat == null)
                throw new ArgumentNullException("mat");
            ptr = CppInvoke.core_OutputArray_new_byMat(mat.CvPtr);
            obj = mat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (ptr != IntPtr.Zero)
                    {
                        CppInvoke.core_OutputArray_delete(ptr);
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
        #endregion

        #region Casting
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator OutputArray(Mat mat)
        {
            return new OutputArray(mat);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static new OutputArray FromMat(Mat mat)
        {
            return new OutputArray(mat);
        }
        #endregion

        #region Operators
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMat()
        {
            return obj is Mat;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat GetMat()
        {
            return obj as Mat;
        }

        /// <summary>
        /// 
        /// </summary>
        public void AssignResult()
        {
            if(!IsReady())
                throw new NotSupportedException();

            // OutputArrayの実体が cv::Mat のとき
            if (IsMat())
            {
                Mat mat = GetMat();
                // OutputArrayからMatオブジェクトを取得
                IntPtr outMat = CppInvoke.core_OutputArray_getMat(ptr);
                // ポインタをセット
                //CppInvoke.core_Mat_assignment_FromMat(mat.CvPtr, outMat);
                CppInvoke.core_Mat_assignTo(outMat, mat.CvPtr);
                // OutputArrayから取り出したMatをdelete
                CppInvoke.core_Mat_delete(outMat);
            }
            else
            {
                throw new OpenCvSharpException("Not supported OutputArray-compatible type");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Fix()
        {
            AssignResult();
            Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsReady()
        {
            return
                ptr != IntPtr.Zero &&
                !disposed &&
                obj != null &&
                IsMat();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void ThrowIfNotReady()
        {
            if(!IsReady())
                throw new OpenCvSharpException("Invalid OutputArray");
        }

        #endregion
    }
}
