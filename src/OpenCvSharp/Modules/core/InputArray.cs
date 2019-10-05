using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
#if ENABLED_CUDA
using OpenCvSharp.Cuda;
#endif

namespace OpenCvSharp
{
    /// <summary>
    /// Proxy datatype for passing Mat's and vector&lt;&gt;'s as input parameters
    /// </summary>
    public class InputArray : DisposableCvObject
    {
        enum HandleKind
        {
            Unknown,
            Mat,
            Scalar,
            Double,
        }

        private object obj;
        private readonly IntPtr handle;
        private readonly HandleKind handleKind;

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
            obj = null;
            handleKind = HandleKind.Unknown;
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
            GC.KeepAlive(mat);
            obj = mat;
            handleKind = HandleKind.Mat;
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
            GC.KeepAlive(expr);
            obj = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        internal InputArray(Scalar val)
        {
            ptr = NativeMethods.core_InputArray_new_byScalar(val, out handle);
            handleKind = HandleKind.Scalar;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        internal InputArray(double val)
        {
            handle = Marshal.AllocHGlobal(sizeof(double));
            Marshal.StructureToPtr(val, handle, false);
            ptr = NativeMethods.core_InputArray_new_byDouble(handle);
            handleKind = HandleKind.Double;
        }

#if ENABLED_CUDA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal InputArray(GpuMat mat)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));
            ptr = NativeMethods.core_InputArray_new_byGpuMat(mat.CvPtr);
            GC.KeepAlive(mat);
            obj = mat;
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal InputArray(IEnumerable<Mat> mat)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));
            using (var matVector = new VectorOfMat(mat))
            {
                ptr = NativeMethods.core_InputArray_new_byVectorOfMat(matVector.CvPtr);
            }
            obj = mat;
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            switch (handleKind)
            {
                case HandleKind.Scalar:
                    NativeMethods.core_InputArray_delete_withScalar(ptr, handle);
                    break;
                case HandleKind.Double:
                    Marshal.FreeHGlobal(handle);
                    goto default;
                default:
                    NativeMethods.core_InputArray_delete(ptr);
                    break;
            }
           
            base.DisposeUnmanaged();
        }

        #endregion

        #region Create

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

#if ENABLED_CUDA
        /// <summary>
        /// Creates a proxy class of the specified GpuMat
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static InputArray Create(GpuMat mat)
        {
            return new InputArray(mat);
        }
#endif

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
                throw new ArgumentNullException(nameof(enumerable));
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
                throw new ArgumentNullException(nameof(enumerable));
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
                throw new ArgumentNullException(nameof(array));
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
                throw new ArgumentNullException(nameof(array));
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
#if NET20 || NET40
            if (!t.IsValueType)
#else
            if (!t.GetTypeInfo().IsValueType)
#endif
                throw new ArgumentException();

            // Primitive types
#if false
            if (t == typeof(byte))
                return MatType.CV_8UC1;
            if (t == typeof(sbyte))
                return MatType.CV_8SC1;
            if (t == typeof(ushort) || t == typeof(char))
                return MatType.CV_16UC1;
            if (t == typeof(short))
                return MatType.CV_16SC1;
            if (t == typeof(int) || t == typeof(uint))
                return MatType.CV_32SC1;
            if (t == typeof(float))
                return MatType.CV_32FC1;
            if (t == typeof(double))
                return MatType.CV_64FC1;
#else
            var code = System.Type.GetTypeCode(t);
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
#endif

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
            if (t == typeof(Vec2i))
                return MatType.CV_32SC2;
            if (t == typeof(Vec3i))
                return MatType.CV_32SC3;
            if (t == typeof(Vec4i))
                return MatType.CV_32SC4;
            if (t == typeof(Vec6i))
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

#if ENABLED_CUDA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator InputArray(GpuMat mat)
        {
            return Create(mat);
        }
#endif

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

        #region Methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Mat GetMat(int i = -1)
        {
            ThrowIfDisposed();
            IntPtr result = NativeMethods.core_InputArray_getMat(ptr, i);
            GC.KeepAlive(this);
            return new Mat(result);
        }

        //public Mat getMat_(int idx = -1) { }
        //public UMat getUMat(int idx = -1) const;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat[] GetMatVector()
        {
            ThrowIfDisposed();
            using (var vec = new VectorOfMat())
            {
                NativeMethods.core_InputArray_getMatVector(ptr, vec.CvPtr);
                GC.KeepAlive(this);
                return vec.ToArray();
            }
        }

        //public void getUMatVector(std::vector<UMat>& umv) { }

#if ENABLED_CUDA
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GpuMat[] GetGpuMatVector()
        {
            ThrowIfDisposed();
            /*using (var vec = new VectorOfGpuMat())
            {
                NativeMethods.core_InputArray_getMatVector(ptr, vec.CvPtr);
                return vec.ToArray();
            }*/
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GpuMat GetGpuMat()
        {
            ThrowIfDisposed();
            IntPtr result = NativeMethods.core_InputArray_getGpuMat(ptr);
            GC.KeepAlive(this);
            return new GpuMat(result);
        }
#endif

        //public ogl::Buffer getOGlBuffer() const;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetFlags()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_getFlags(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IntPtr GetObj()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_getObj(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Size GetSz()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_getSz(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        public InOutArrayKind Kind()
        {
            ThrowIfDisposed();
            var res = (InOutArrayKind)NativeMethods.core_InputArray_kind(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Dims(int i = -1)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_dims(ptr, i);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Cols(int i = -1)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_cols(ptr, i);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Rows(int i = -1)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_rows(ptr, i);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Size Size(int i = -1)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_size(ptr, i);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sz"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public int SizeND(int[] sz, int i = -1)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_sizend(ptr, sz, i);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool SameSize(InputArray arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            arr.ThrowIfDisposed();
            ThrowIfDisposed();
            int result = NativeMethods.core_InputArray_sameSize(ptr, arr.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(arr);
            return result != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Total(int i = -1)
        {
            ThrowIfDisposed();
            IntPtr result = NativeMethods.core_InputArray_total(ptr, i);
            GC.KeepAlive(this);
            return result.ToInt64();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Type(int i = -1)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_type(ptr, i);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Depth(int i = -1)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_depth(ptr, i);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Channels(int i = -1)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_channels(ptr, i);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool IsContinuous(int i = -1)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_isContinuous(ptr, i) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool IsSubmatrix(int i = -1)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_isSubmatrix(ptr, i) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_empty(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public void CopyTo(OutputArray arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            arr.ThrowIfNotReady();
            ThrowIfDisposed();
            NativeMethods.core_InputArray_copyTo1(ptr, arr.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(arr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="mask"></param>
        public void CopyTo(OutputArray arr, InputArray mask)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (mask == null)
                throw new ArgumentNullException(nameof(mask));
            arr.ThrowIfNotReady();
            mask.ThrowIfDisposed();
            ThrowIfDisposed();
            NativeMethods.core_InputArray_copyTo2(ptr, arr.CvPtr, mask.CvPtr);
            arr.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(arr);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Offset(int i = -1)
        {
            ThrowIfDisposed();
            IntPtr result = NativeMethods.core_InputArray_offset(ptr, i);
            GC.KeepAlive(this);
            return result.ToInt64();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Step(int i = -1)
        {
            ThrowIfDisposed();
            IntPtr result = NativeMethods.core_InputArray_step(ptr, i);
            GC.KeepAlive(this);
            return result.ToInt64();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMat()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_isMat(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsUMat()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_isUMat(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMatVector()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_isMatVector(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsUMatVector()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_isUMatVector(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMatx()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_isMatx(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsVector()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_isVector(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsGpuMatVector()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_InputArray_isGpuMatVector(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        #endregion
    }
}
