using System;
using System.Collections.Generic;
using OpenCvSharp.Gpu;

namespace OpenCvSharp
{
    /// <summary>
    /// Proxy datatype for passing Mat's and vector&lt;&gt;'s as input parameters
    /// </summary>
    public class InputArray : DisposableCvObject
    {
        private bool disposed;
        private object obj;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming
        public const int KIND_SHIFT = 16;
        public const int KIND_MASK = ~(0x8000 << KIND_SHIFT | 0x4000 << KIND_SHIFT) - (1 << KIND_SHIFT) + 1;
// ReSharper restore InconsistentNaming
#pragma warning restore 1591

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal InputArray(IntPtr ptr)
        {
            this.ptr = ptr;
            this.obj = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal InputArray(Mat mat)
        {
            if (mat == null)
                ptr = IntPtr.Zero;
            else
                ptr = NativeMethods.core_InputArray_new_byMat(mat.CvPtr);
            obj = mat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expr"></param>
        internal InputArray(MatExpr expr)
        {
            if (expr == null)
                ptr = IntPtr.Zero;
            else
                ptr = NativeMethods.core_InputArray_new_byMatExpr(expr.CvPtr);
            obj = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        internal InputArray(Scalar val)
        {
            ptr = NativeMethods.core_InputArray_new_byScalar(val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        internal InputArray(double val)
        {
            ptr = NativeMethods.core_InputArray_new_byDouble(val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal InputArray(GpuMat mat)
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            ptr = NativeMethods.core_InputArray_new_byGpuMat(mat.CvPtr);
            obj = mat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal InputArray(IEnumerable<Mat> mat)
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            using (var matVector = new VectorOfMat(mat))
            {
                ptr = NativeMethods.core_InputArray_new_byVectorOfMat(matVector.CvPtr);
            }
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
                        NativeMethods.core_InputArray_delete(ptr);
                        ptr = IntPtr.Zero;
                    }
                    obj = null;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static implicit operator InputArray(Scalar val)
        {
            return Create(val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static implicit operator InputArray(double val)
        {
            return Create(val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator InputArray(GpuMat mat)
        {
            return Create(mat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mats"></param>
        /// <returns></returns>
        public static explicit operator InputArray(List<Mat> mats)
        {
            return Create(mats);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mats"></param>
        /// <returns></returns>
        public static explicit operator InputArray(Mat[] mats)
        {
            return Create((IEnumerable<Mat>)mats);
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
                return (InOutArrayKind)NativeMethods.core_InputArray_kind(ptr);
            }
        }

        /// <summary>
        /// Creates a proxy class of the specified Mat
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static InputArray Create(Mat mat)
        {
            return new InputArray(mat);
        }

        /// <summary>
        /// Creates a proxy class of the specified MatExpr
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static InputArray Create(MatExpr expr)
        {
            return new InputArray(expr);
        }

        /// <summary>
        /// Creates a proxy class of the specified Scalar
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static InputArray Create(Scalar val)
        {
            return new InputArray(val);
        }

        /// <summary>
        /// Creates a proxy class of the specified double
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static InputArray Create(double val)
        {
            return new InputArray(val);
        }

        /// <summary>
        /// Creates a proxy class of the specified GpuMat
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static InputArray Create(GpuMat mat)
        {
            return new InputArray(mat);
        }

        /// <summary>
        /// Creates a proxy class of the specified array of Mat 
        /// </summary>
        /// <param name="matVector"></param>
        /// <returns></returns>
        public static InputArray Create(IEnumerable<Mat> matVector)
        {
            return new InputArray(matVector);
        }

        /// <summary>
        /// Creates a proxy class of the specified list
        /// </summary>
        /// <param name="enumerable">Array object</param>
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
        /// <param name="enumerable">Array object</param>
        /// <param name="type">Matrix depth and channels for converting array to cv::Mat</param>
        /// <returns></returns>
        public static InputArray Create<T>(IEnumerable<T> enumerable, MatType type)
            where T : struct
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            List<T> list = new List<T>(enumerable);
            return Create(list.ToArray(), type);
        }

        /// <summary>
        /// Creates a proxy class of the specified list
        /// </summary>
        /// <param name="array">Array object</param>
        /// <returns></returns>
        public static InputArray Create<T>(T[] array)
            where T : struct 
        {
            MatType type = EstimateType(typeof(T));
            return Create(array, type);
        }

        /// <summary>
        /// Creates a proxy class of the specified list
        /// </summary>
        /// <param name="array">Array object</param>
        /// <param name="type">Matrix depth and channels for converting array to cv::Mat</param>
        /// <returns></returns>
        public static InputArray Create<T>(T[] array, MatType type)
            where T : struct
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (array.Length == 0)
                throw new ArgumentException("array.Length == 0");

            int rows = array.Length;
            Mat mat = new Mat(rows, 1, type, array);
            return new InputArray(mat);
        }

        /// <summary>
        /// Creates a proxy class of the specified list
        /// </summary>
        /// <param name="array">Array object</param>
        /// <returns></returns>
        public static InputArray Create<T>(T[,] array)
            where T : struct 
        {
            MatType type = EstimateType(typeof(T));
            return Create(array, type);
        }

        /// <summary>
        /// Creates a proxy class of the specified list
        /// </summary>
        /// <param name="array">Array object</param>
        /// <param name="type">Matrix depth and channels for converting array to cv::Mat</param>
        /// <returns></returns>
        public static InputArray Create<T>(T[,] array, MatType type)
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
            Mat mat = new Mat(rows, cols, type, array);
            return new InputArray(mat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static MatType EstimateType(Type t)
        {
            if(!t.IsValueType)
                throw new ArgumentException();

            // Primitive types
            TypeCode code = Type.GetTypeCode(t);
            switch (code)
            {
                case TypeCode.Byte:
                    return MatType.CV_8UC1;
                case TypeCode.SByte:
                    return MatType.CV_8SC1;
                case TypeCode.UInt16:
                    return MatType.CV_16UC1;
                case TypeCode.Int16:
                case TypeCode.Char:
                    return MatType.CV_16SC1;
                case TypeCode.UInt32:
                case TypeCode.Int32:
                    return MatType.CV_32SC1;
                case TypeCode.Single:
                    return MatType.CV_32FC1;
                case TypeCode.Double:
                    return MatType.CV_64FC1;
            }
            // OpenCV struct types
            if (t == typeof(Point))
                return MatType.CV_32SC2;
            if (t == typeof(Point2f))
                return MatType.CV_32FC2;
            if (t == typeof(Point2d))
                return MatType.CV_64FC2;
            if (t == typeof(Point3i))
                return MatType.CV_32SC3;
            if (t == typeof(Point3f))
                return MatType.CV_32FC3;
            if (t == typeof(Point3d))
                return MatType.CV_32FC3;
            if (t == typeof(Range))
                return MatType.CV_32SC2;
            if (t == typeof(Rangef))
                return MatType.CV_32FC2;
            if (t == typeof(Rect))
                return MatType.CV_32SC4;
            if (t == typeof(Size))
                return MatType.CV_32SC2;
            if (t == typeof(Size2f))
                return MatType.CV_32FC2;

            if (t == typeof(Vec2b))
                return MatType.CV_8UC2;
            if (t == typeof(Vec3b))
                return MatType.CV_8UC3;
            if (t == typeof(Vec4b))
                return MatType.CV_8UC4;
            if (t == typeof(Vec6b))
                return MatType.CV_8UC(6);
            if (t == typeof(Vec2s))
                return MatType.CV_16SC2;
            if (t == typeof(Vec3s))
                return MatType.CV_16SC3;
            if (t == typeof(Vec4s))
                return MatType.CV_16SC4;
            if (t == typeof(Vec6s))
                return MatType.CV_16SC(6);
            if (t == typeof(Vec2w))
                return MatType.CV_16UC2;
            if (t == typeof(Vec3w))
                return MatType.CV_16UC3;
            if (t == typeof(Vec4w))
                return MatType.CV_16UC4;
            if (t == typeof(Vec6w))
                return MatType.CV_16UC(6);
            if (t == typeof(Vec2s))
                return MatType.CV_32SC2;
            if (t == typeof(Vec3s))
                return MatType.CV_32SC3;
            if (t == typeof(Vec4s))
                return MatType.CV_32SC4;
            if (t == typeof(Vec6s))
                return MatType.CV_32SC(6);
            if (t == typeof(Vec2f))
                return MatType.CV_32FC2;
            if (t == typeof(Vec3f))
                return MatType.CV_32FC3;
            if (t == typeof(Vec4f))
                return MatType.CV_32FC4;
            if (t == typeof(Vec6f))
                return MatType.CV_32FC(6);
            if (t == typeof(Vec2d))
                return MatType.CV_64FC2;
            if (t == typeof(Vec3d))
                return MatType.CV_64FC3;
            if (t == typeof(Vec4d))
                return MatType.CV_64FC4;
            if (t == typeof(Vec6d))
                return MatType.CV_64FC(6);

            throw new ArgumentException("Not supported value type for InputArray");
        }
        #endregion
    }
}
