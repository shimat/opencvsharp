using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 
    /// </summary>
    public class InputArray : DisposableCvObject
    {
        private bool disposed;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        protected InputArray()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal InputArray(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal InputArray(Mat mat)
        {
            if(mat == null)
                throw new ArgumentNullException("mat");
            try
            {
                ptr = CppInvoke.core_InputArray_new_byMat(mat.CvPtr);
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
                        CppInvoke.core_InputArray_delete(ptr);
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
        public static implicit operator InputArray(Mat mat)
        {
            return new InputArray(mat);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static InputArray FromMat(Mat mat)
        {
            return new InputArray(mat);
        }
        #endregion

        #region Operators
        #endregion

        #region Methods

        public InOutArrayKind Kind
        {
            get
            {
                ThrowIfDisposed();
                try
                {
                    return (InOutArrayKind)CppInvoke.core_InputArray_kind(ptr);
                }
                catch (BadImageFormatException ex)
                {
                    throw PInvokeHelper.CreateException(ex);
                }
            }
        }

        #endregion
    }
}
