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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator InputArray(Mat mat)
        {
            return Create(mat);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static implicit operator InputArray(MatExpr expr)
        {
            return Create(expr);
        }
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
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static InputArray Create(Mat mat)
        {
            return new InputArray(mat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static InputArray Create(MatExpr expr)
        {
            return new InputArray(expr);
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
            MatType type = EstimateType(typeof(T));
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
            MatType type = EstimateType(typeof(T));
            Mat mat = new Mat(rows, 1, type, array);
            return new InputArray(mat);
        }

        private static MatType EstimateType(Type t)
        {
            if(!t.IsValueType)
                throw new ArgumentException();

            TypeCode code = Type.GetTypeCode(t);
            switch (code)
            {
                case TypeCode.Byte:
                    return MatType.CV_8UC(1);
                case TypeCode.SByte:
                    return MatType.CV_8SC(1);
                case TypeCode.UInt16:
                    return MatType.CV_16UC(1);
                case TypeCode.Int16:
                case TypeCode.Char:
                    return MatType.CV_16SC(1);
                case TypeCode.UInt32:
                case TypeCode.Int32:
                    return MatType.CV_32SC(1);
                case TypeCode.Single:
                    return MatType.CV_32FC(1);
                case TypeCode.Double:
                    return MatType.CV_64FC(1);
                default:
                    int elemSize = Marshal.SizeOf(t);
                    return MatType.CV_8UC(elemSize);
            }
        }
        #endregion
    }
}
