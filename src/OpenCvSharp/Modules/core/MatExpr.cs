﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// Matrix expression
    /// </summary>
    public sealed partial class MatExpr : DisposableCvObject
    {
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
                throw new ArgumentNullException(nameof(mat));
            ptr = NativeMethods.core_MatExpr_new2(mat.CvPtr);
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.core_MatExpr_delete(ptr);
            base.DisposeUnmanaged();
        }

        #endregion

        #region Cast

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static implicit operator Mat(MatExpr self)
        {
            try
            {
                IntPtr retPtr = NativeMethods.core_MatExpr_toMat(self.ptr);
                GC.KeepAlive(self);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static MatExpr FromMat(Mat mat)
        {
            return new MatExpr(mat);
        }

        #endregion

        #region Operators
        #region Unary
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static MatExpr operator +(MatExpr e)
        {
            return e;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static MatExpr operator -(MatExpr e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorUnaryMinus_MatExpr(e.CvPtr);
                GC.KeepAlive(e);
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
        /// <returns></returns>
        public static MatExpr operator ~(MatExpr e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorUnaryNot_MatExpr(e.CvPtr);
                GC.KeepAlive(e);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region +
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static MatExpr operator +(MatExpr e, Mat m)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            e.ThrowIfDisposed();
            m.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorAdd_MatExprMat(e.CvPtr, m.CvPtr);
                GC.KeepAlive(e);
                GC.KeepAlive(m);
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
        public static MatExpr operator +(Mat m, MatExpr e)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            m.ThrowIfDisposed();
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorAdd_MatMatExpr(m.CvPtr, e.CvPtr);
                GC.KeepAlive(m);
                GC.KeepAlive(e);
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
        public static MatExpr operator +(MatExpr e, Scalar s)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorAdd_MatExprScalar(e.CvPtr, s);
                GC.KeepAlive(e);
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
        public static MatExpr operator +(Scalar s, MatExpr e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorAdd_ScalarMatExpr(s, e.CvPtr);
                GC.KeepAlive(e);
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
        public static MatExpr operator +(MatExpr e1, MatExpr e2)
        {
            if (e1 == null)
                throw new ArgumentNullException(nameof(e1));
            if (e2 == null)
                throw new ArgumentNullException(nameof(e2));
            e1.ThrowIfDisposed();
            e2.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorAdd_MatExprMatExpr(e1.CvPtr, e2.CvPtr);
                GC.KeepAlive(e1);
                GC.KeepAlive(e2);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region -
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static MatExpr operator -(MatExpr e, Mat m)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            e.ThrowIfDisposed();
            m.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorSubtract_MatExprMat(e.CvPtr, m.CvPtr);
                GC.KeepAlive(e);
                GC.KeepAlive(m);
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
        public static MatExpr operator -(Mat m, MatExpr e)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            m.ThrowIfDisposed();
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorSubtract_MatMatExpr(m.CvPtr, e.CvPtr);
                GC.KeepAlive(m);
                GC.KeepAlive(e);
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
        public static MatExpr operator -(MatExpr e, Scalar s)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorSubtract_MatExprScalar(e.CvPtr, s);
                GC.KeepAlive(e);
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
        public static MatExpr operator -(Scalar s, MatExpr e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorSubtract_ScalarMatExpr(s, e.CvPtr);
                GC.KeepAlive(e);
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
        public static MatExpr operator -(MatExpr e1, MatExpr e2)
        {
            if (e1 == null)
                throw new ArgumentNullException(nameof(e1));
            if (e2 == null)
                throw new ArgumentNullException(nameof(e2));
            e1.ThrowIfDisposed();
            e2.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorSubtract_MatExprMatExpr(e1.CvPtr, e2.CvPtr);
                GC.KeepAlive(e1);
                GC.KeepAlive(e2);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region *
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static MatExpr operator *(MatExpr e, Mat m)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            e.ThrowIfDisposed();
            m.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorMultiply_MatExprMat(e.CvPtr, m.CvPtr);
                GC.KeepAlive(e);
                GC.KeepAlive(m);
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
        public static MatExpr operator *(Mat m, MatExpr e)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            m.ThrowIfDisposed();
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorMultiply_MatMatExpr(m.CvPtr, e.CvPtr);
                GC.KeepAlive(m);
                GC.KeepAlive(e);
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
        public static MatExpr operator *(MatExpr e, double s)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorMultiply_MatExprDouble(e.CvPtr, s);
                GC.KeepAlive(e);
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
        public static MatExpr operator *(double s, MatExpr e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorMultiply_DoubleMatExpr(s, e.CvPtr);
                GC.KeepAlive(e);
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
        public static MatExpr operator *(MatExpr e1, MatExpr e2)
        {
            if (e1 == null)
                throw new ArgumentNullException(nameof(e1));
            if (e2 == null)
                throw new ArgumentNullException(nameof(e2));
            e1.ThrowIfDisposed();
            e2.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorMultiply_MatExprMatExpr(e1.CvPtr, e2.CvPtr);
                GC.KeepAlive(e1);
                GC.KeepAlive(e2);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region /
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static MatExpr operator /(MatExpr e, Mat m)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            e.ThrowIfDisposed();
            m.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorDivide_MatExprMat(e.CvPtr, m.CvPtr);
                GC.KeepAlive(e);
                GC.KeepAlive(m);
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
                throw new ArgumentNullException(nameof(m));
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            m.ThrowIfDisposed();
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorDivide_MatMatExpr(m.CvPtr, e.CvPtr);
                GC.KeepAlive(m);
                GC.KeepAlive(e);
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
                throw new ArgumentNullException(nameof(e));
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorDivide_MatExprDouble(e.CvPtr, s);
                GC.KeepAlive(e);
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
                throw new ArgumentNullException(nameof(e));
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorDivide_DoubleMatExpr(s, e.CvPtr);
                GC.KeepAlive(e);
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
                throw new ArgumentNullException(nameof(e1));
            if (e2 == null)
                throw new ArgumentNullException(nameof(e2));
            e1.ThrowIfDisposed();
            e2.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_operatorDivide_MatExprMatExpr(e1.CvPtr, e2.CvPtr);
                GC.KeepAlive(e1);
                GC.KeepAlive(e2);
                return new MatExpr(retPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #endregion

        #region Methods

        #region Indexers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowStart"></param>
        /// <param name="rowEnd"></param>
        /// <param name="colStart"></param>
        /// <param name="colEnd"></param>
        /// <returns></returns>
        public MatExpr this[int rowStart, int rowEnd, int colStart, int colEnd]
        {
            get
            {
                ThrowIfDisposed();
                return SubMat(rowStart, rowEnd, colStart, colEnd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        /// <returns></returns>
        public MatExpr this[Range rowRange, Range colRange]
        {
            get
            {
                ThrowIfDisposed();
                return SubMat(rowRange, colRange);
            }
            set
            {
                ThrowIfDisposed();
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                MatExpr subMatExpr = SubMat(rowRange, colRange);
                NativeMethods.core_Mat_assignment_FromMatExpr(subMatExpr.CvPtr, value.CvPtr);
                GC.KeepAlive(subMatExpr);
                GC.KeepAlive(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roi"></param>
        /// <returns></returns>
        public MatExpr this[Rect roi]
        {
            get
            {
                ThrowIfDisposed();
                return SubMat(roi);
            }
            set
            {
                ThrowIfDisposed();
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                MatExpr subMatExpr = SubMat(roi);
                NativeMethods.core_Mat_assignment_FromMatExpr(subMatExpr.CvPtr, value.CvPtr);
                GC.KeepAlive(subMatExpr);
                GC.KeepAlive(value);
            }
        }
        #endregion

        #region Col
        /// <summary>
        /// 
        /// </summary>
        public class ColIndexer : MatExprRowColIndexer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="parent"></param>
            protected internal ColIndexer(MatExpr parent)
                : base(parent)
            {
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            public override MatExpr this[int x]
            {
                get
                {
                    parent.ThrowIfDisposed();
                    IntPtr retPtr = NativeMethods.core_MatExpr_col(parent.CvPtr, x);
                    GC.KeepAlive(this);
                    return new MatExpr(retPtr);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ColIndexer Col
        {
            get { return col ??= new ColIndexer(this); }
        }
        private ColIndexer? col;
        #endregion
        #region Cross
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public Mat Cross(Mat m)
        {
            ThrowIfDisposed();
            m.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_MatExpr_cross(ptr, m.CvPtr);
                GC.KeepAlive(this);
                GC.KeepAlive(m);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Diag
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr Diag(int d = 0)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_MatExpr_diag2(ptr, d);
                GC.KeepAlive(this);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Dot
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public double Dot(Mat m)
        {
            ThrowIfDisposed();
            m.ThrowIfDisposed();
            try
            {
                var res = NativeMethods.core_MatExpr_dot(ptr, m.CvPtr);
                GC.KeepAlive(this);
                GC.KeepAlive(m);
                return res;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Inv
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public MatExpr Inv(DecompTypes method = DecompTypes.LU)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_MatExpr_inv2(ptr, (int)method);
                GC.KeepAlive(this);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Mul
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public MatExpr Mul(MatExpr e, double scale = 1.0)
        {
            ThrowIfDisposed();
            e.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_MatExpr_mul_toMatExpr(ptr, e.CvPtr, scale);
                GC.KeepAlive(this);
                GC.KeepAlive(e);
                MatExpr retVal = new MatExpr(retPtr);
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
        /// <param name="m"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public MatExpr Mul(Mat m, double scale = 1.0)
        {
            ThrowIfDisposed();
            m.ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_MatExpr_mul_toMat(ptr, m.CvPtr, scale);
                GC.KeepAlive(this);
                GC.KeepAlive(m);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Row
        /// <summary>
        /// 
        /// </summary>
        public class RowIndexer : MatExprRowColIndexer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="parent"></param>
            protected internal RowIndexer(MatExpr parent)
                : base(parent)
            {
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="y"></param>
            /// <returns></returns>
            public override MatExpr this[int y]
            {
                get 
                {
                    parent.ThrowIfDisposed();
                    IntPtr retPtr = NativeMethods.core_MatExpr_row(parent.CvPtr, y);
                    GC.KeepAlive(this);
                    return new MatExpr(retPtr);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public RowIndexer Row
        {
            get { return row ??= new RowIndexer(this); }
        }
        private RowIndexer? row;
        #endregion
        #region
        /// <summary>
        /// 
        /// </summary>
        public Size Size
        {
            get
            {
                ThrowIfDisposed();
                try
                {
                    var res = NativeMethods.core_MatExpr_size(ptr);
                    GC.KeepAlive(this);
                    return res;
                }
                catch (BadImageFormatException ex)
                {
                    throw PInvokeHelper.CreateException(ex);
                }
            }
        }
        #endregion
        #region SubMat
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowStart"></param>
        /// <param name="rowEnd"></param>
        /// <param name="colStart"></param>
        /// <param name="colEnd"></param>
        /// <returns></returns>
        public MatExpr SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_MatExpr_submat(ptr, rowStart, rowEnd, colStart, colEnd);
                GC.KeepAlive(this);
                MatExpr retVal = new MatExpr(retPtr);
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
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        /// <returns></returns>
        public MatExpr SubMat(Range rowRange, Range colRange)
        {
            return SubMat(rowRange.Start, rowRange.End, colRange.Start, colRange.End);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roi"></param>
        /// <returns></returns>
        public MatExpr SubMat(Rect roi)
        {
            return SubMat(roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);
        }
        #endregion
        #region T
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MatExpr T()
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = NativeMethods.core_MatExpr_t(ptr);
                GC.KeepAlive(this);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Type
        /// <summary>
        /// 
        /// </summary>
        public MatType Type
        {
            get
            {
                ThrowIfDisposed();
                try
                {
                    var res = (MatType)NativeMethods.core_MatExpr_type(ptr);
                    GC.KeepAlive(this);
                    return res;
                }
                catch (BadImageFormatException ex)
                {
                    throw PInvokeHelper.CreateException(ex);
                }
            }
        }
        #endregion

        #endregion
    }
}
