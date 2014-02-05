using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class OutputArray : InputArray
    {
        private bool disposed;
        private object obj;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal OutputArray(IntPtr ptr)
            : base(ptr)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal OutputArray(Mat mat)
        {
            if(mat == null)
                throw new ArgumentNullException("mat");
            try
            {
                ptr = CppInvoke.core_OutputArray_new_byMat(mat.CvPtr);
                obj = mat;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
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
                try
                {
                    if (disposing)
                    {
                    }
                    //Console.WriteLine("MatExpr disposed");
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

        public bool IsMat()
        {
            return obj is Mat;
        }
        public Mat GetMat()
        {
            return obj as Mat;
        }

        public void AssignResult()
        {
            if(obj == null)
                throw new NotSupportedException();

            if (IsMat())
            {
                Mat mat = GetMat();
                // 前のオブジェクトを削除
                CppInvoke.core_Mat_delete(mat.CvPtr);
                // OutputArrayからMatオブジェクトを取得
                IntPtr outMat = CppInvoke.core_OutputArray_getMat(ptr);
                // ポインタをセット
                mat.SetPtr(outMat);
            }
            else
            {
                throw new OpenCvSharpException("Not supported OutputArray-derived type");
            }
        }

        #endregion
    }
}
