using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Proxy datatype for passing Mat's and vector&lt;&gt;'s as input parameters
    /// </summary>
    public class InputArray : DisposableCvObject
    {
        private bool disposed;
        private Mat mat;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal InputArray(IntPtr ptr)
        {
            this.ptr = ptr;
            this.mat = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal InputArray(Mat mat)
        {
            if(mat == null)
                throw new ArgumentNullException("mat");
            this.ptr = CppInvoke.core_InputArray_new_byMat(mat.CvPtr);
            this.mat = mat;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expr"></param>
        internal InputArray(MatExpr expr)
        {
            if (expr == null)
                throw new ArgumentNullException("expr");
            this.ptr = CppInvoke.core_InputArray_new_byMatExpr(expr.CvPtr);
            this.mat = null;
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
                        CppInvoke.core_InputArray_delete(ptr);
                        ptr = IntPtr.Zero;
                    }
                    mat = null;
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Cast
        #region Mat
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator InputArray(Mat mat)
        {
            return FromMat(mat);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static InputArray FromMat(Mat mat)
        {
            return new InputArray(mat);
        }
        #endregion
        #region MatExpr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static implicit operator InputArray(MatExpr expr)
        {
            return FromMatExpr(expr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static InputArray FromMatExpr(MatExpr expr)
        {
            return new InputArray(expr);
        }
        #endregion
        #endregion

        #region Operators
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public InOutArrayKind Kind
        {
            get
            {
                ThrowIfDisposed();
                return (InOutArrayKind)CppInvoke.core_InputArray_kind(ptr);
            }
        }

        /// <summary>
        /// Creates a proxy class of the specified list
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static InputArray Create<T>(IEnumerable<T> enumerable)
            where T : struct
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            List<T> list = new List<T>(enumerable);
            return Create(list.ToArray());
        }

        /// <summary>
        /// Creates a proxy class of the specified list
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static InputArray Create<T>(T[] array)
            where T : struct 
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (array.Length == 0)
                throw new ArgumentException("array.Length == 0");

            int rows = array.Length;
            int depth = Marshal.SizeOf(typeof(T));
            MatType type = MatType.MakeType(depth, 1);
            Mat mat = new Mat(rows, 1, type, array);
            return new InputArray(mat);
        }

        /// <summary>
        /// Creates a proxy class of the specified list
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static InputArray Create<T>(T[,] array)
            where T : struct 
        {
            if (array == null)
                throw new ArgumentNullException("array");
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            if (rows == 0)
                throw new ArgumentException("array.GetLength(0) == 0");
            if (cols == 0)
                throw new ArgumentException("array.GetLength(1) == 0");
            int depth = Marshal.SizeOf(typeof(T));
            MatType type = MatType.MakeType(depth, 1);
            Mat mat = new Mat(rows, 1, type, array);
            return new InputArray(mat);
        }
        #endregion
    }
}
