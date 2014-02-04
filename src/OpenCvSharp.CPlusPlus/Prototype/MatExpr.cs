using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MatExpr : DisposableCvObject
    {
        private bool disposed;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal MatExpr(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal MatExpr(Mat mat)
        {
            if(mat == null)
                throw new ArgumentNullException("mat");
            try
            {
                this.ptr = CppInvoke.core_MatExpr_new(mat.CvPtr);
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
                    CppInvoke.core_MatExpr_delete(ptr);
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
        /// <param name="self"></param>
        /// <returns></returns>
        public static implicit operator Mat(MatExpr self)
        {
            try
            {
                IntPtr retPtr = CppInvoke.core_MatExpr_toMat(self.ptr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat ToMat()
        {
            return (Mat)this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator MatExpr(Mat mat)
        {
            return new MatExpr(mat);
        }
        #endregion

        #region Operators

        public static MatExpr operator +(MatExpr e, Mat m) { throw new NotImplementedException(); }
        public static MatExpr operator +(Mat m, MatExpr e) { throw new NotImplementedException(); }
        public static MatExpr operator +(MatExpr e, Scalar s) { throw new NotImplementedException(); }
        public static MatExpr operator +(Scalar s, MatExpr e) { throw new NotImplementedException(); }
        public static MatExpr operator +(MatExpr e1, MatExpr e2) { throw new NotImplementedException(); }

        public static MatExpr operator -(MatExpr e, Mat m) { throw new NotImplementedException(); }
        public static MatExpr operator -(Mat m, MatExpr e) { throw new NotImplementedException(); }
        public static MatExpr operator -(MatExpr e, Scalar s) { throw new NotImplementedException(); }
        public static MatExpr operator -(Scalar s, MatExpr e) { throw new NotImplementedException(); }
        public static MatExpr operator -(MatExpr e1, MatExpr e2) { throw new NotImplementedException(); }

        public static MatExpr operator -(MatExpr e) { throw new NotImplementedException(); }

        public static MatExpr operator *(MatExpr e, Mat m) { throw new NotImplementedException(); }
        public static MatExpr operator *(Mat m, MatExpr e) { throw new NotImplementedException(); }
        public static MatExpr operator *(MatExpr e, double s) { throw new NotImplementedException(); }
        public static MatExpr operator *(double s, MatExpr e) { throw new NotImplementedException(); }
        public static MatExpr operator *(MatExpr e1, MatExpr e2) { throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static MatExpr operator /(MatExpr e, Mat m)
        {
            if (e == null)
                throw new ArgumentNullException("e");
            if (m == null)
                throw new ArgumentNullException("m");
            e.ThrowIfDisposed();
            m.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorDivide_MatExprMat(e.CvPtr, m.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static MatExpr operator /(Mat m, MatExpr e)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            if (e == null)
                throw new ArgumentNullException("e");
            m.ThrowIfDisposed();
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorDivide_MatMatExpr(m.CvPtr, e.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator /(MatExpr e, double s)
        {
            if (e == null)
                throw new ArgumentNullException("e");
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorDivide_MatExprDouble(e.CvPtr, s);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static MatExpr operator /(double s, MatExpr e)
        {
            if (e == null)
                throw new ArgumentNullException("e");
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorDivide_DoubleMatExpr(s, e.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static MatExpr operator /(MatExpr e1, MatExpr e2)
        {
            if (e1 == null)
                throw new ArgumentNullException("e1");
            if (e2 == null)
                throw new ArgumentNullException("e2");
            e1.ThrowIfDisposed();
            e2.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_operatorDivide_MatExprMatExpr(e1.CvPtr, e2.CvPtr);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
    }
}
