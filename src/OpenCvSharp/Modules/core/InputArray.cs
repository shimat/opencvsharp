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
    /// Proxy data type for passing Mat's and vector&lt;&gt;'s as input parameters
    /// </summary>
    public class InputArray : DisposableCvObject
    {
        enum HandleKind
        {
            Unknown,
            Mat,
            Scalar,
            Double,
            Vec
        }

        private object? obj;
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
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        internal InputArray(IntPtr ptr)
        {
            this.ptr = ptr;
            obj = null;
            handleKind = HandleKind.Unknown;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mat"></param>
        // ReSharper disable once SuggestBaseTypeForParameter
        internal InputArray(Mat? mat)
        {
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (mat == null)
                ptr = IntPtr.Zero;
            else
                NativeMethods.HandleException(
                    NativeMethods.core_InputArray_new_byMat(mat.CvPtr, out ptr));
            GC.KeepAlive(mat);
            obj = mat;
            handleKind = HandleKind.Mat;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="expr"></param>
        // ReSharper disable once SuggestBaseTypeForParameter
        internal InputArray(MatExpr? expr)
        {
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (expr == null)
                ptr = IntPtr.Zero;
            else
                NativeMethods.HandleException(
                    NativeMethods.core_InputArray_new_byMatExpr(expr.CvPtr, out ptr));
            GC.KeepAlive(expr);
            obj = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val"></param>
        internal InputArray(Scalar val)
        {
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_new_byScalar(val, out handle, out ptr));
            handleKind = HandleKind.Scalar;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val"></param>
        internal InputArray(double val)
        {
            handle = Marshal.AllocHGlobal(sizeof(double));
            Marshal.StructureToPtr(val, handle, false);
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_new_byDouble(handle, out ptr));
            handleKind = HandleKind.Double;
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vec"></param>
        internal InputArray(byte[] vec)
        {
            if (vec == null) 
                throw new ArgumentNullException(nameof(vec));
            if (vec.Length == 0) 
                throw new ArgumentException("Empty array.", nameof(vec));

            var gch = GCHandle.Alloc(vec, GCHandleType.Pinned);
            handle = GCHandle.ToIntPtr(gch);

            NativeMethods.HandleException(
                NativeMethods.core_InputArray_new_byVecb(gch.AddrOfPinnedObject(), vec.Length, out ptr));
            handleKind = HandleKind.Vec;
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vec"></param>
        internal InputArray(short[] vec)
        {
            if (vec == null) 
                throw new ArgumentNullException(nameof(vec));
            if (vec.Length == 0) 
                throw new ArgumentException("Empty array.", nameof(vec));

            var gch = GCHandle.Alloc(vec, GCHandleType.Pinned);
            handle = GCHandle.ToIntPtr(gch);

            NativeMethods.HandleException(
                NativeMethods.core_InputArray_new_byVecs(gch.AddrOfPinnedObject(), vec.Length, out ptr));
            handleKind = HandleKind.Vec;
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vec"></param>
        internal InputArray(ushort[] vec)
        {
            if (vec == null) 
                throw new ArgumentNullException(nameof(vec));
            if (vec.Length == 0) 
                throw new ArgumentException("Empty array.", nameof(vec));

            var gch = GCHandle.Alloc(vec, GCHandleType.Pinned);
            handle = GCHandle.ToIntPtr(gch);

            NativeMethods.HandleException(
                NativeMethods.core_InputArray_new_byVecw(gch.AddrOfPinnedObject(), vec.Length, out ptr));
            handleKind = HandleKind.Vec;
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vec"></param>
        internal InputArray(int[] vec)
        {
            if (vec == null) 
                throw new ArgumentNullException(nameof(vec));
            if (vec.Length == 0) 
                throw new ArgumentException("Empty array.", nameof(vec));

            var gch = GCHandle.Alloc(vec, GCHandleType.Pinned);
            handle = GCHandle.ToIntPtr(gch);

            NativeMethods.HandleException(
                NativeMethods.core_InputArray_new_byVeci(gch.AddrOfPinnedObject(), vec.Length, out ptr));
            handleKind = HandleKind.Vec;
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vec"></param>
        internal InputArray(float[] vec)
        {
            if (vec == null) 
                throw new ArgumentNullException(nameof(vec));
            if (vec.Length == 0) 
                throw new ArgumentException("Empty array.", nameof(vec));

            var gch = GCHandle.Alloc(vec, GCHandleType.Pinned);
            handle = GCHandle.ToIntPtr(gch);

            NativeMethods.HandleException(
                NativeMethods.core_InputArray_new_byVecf(gch.AddrOfPinnedObject(), vec.Length, out ptr));
            handleKind = HandleKind.Vec;
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vec"></param>
        internal InputArray(double[] vec)
        {
            if (vec == null) 
                throw new ArgumentNullException(nameof(vec));
            if (vec.Length == 0) 
                throw new ArgumentException("Empty array.", nameof(vec));

            var gch = GCHandle.Alloc(vec, GCHandleType.Pinned);
            handle = GCHandle.ToIntPtr(gch);

            NativeMethods.HandleException(
                NativeMethods.core_InputArray_new_byVecd(gch.AddrOfPinnedObject(), vec.Length, out ptr));
            handleKind = HandleKind.Vec;
        }

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
                NativeMethods.HandleException(
                    NativeMethods.core_InputArray_new_byVectorOfMat(matVector.CvPtr, out ptr));
            }
            obj = mat;
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            GC.KeepAlive(obj);
            obj = null;
            base.DisposeManaged();
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            switch (handleKind)
            {
                case HandleKind.Scalar:
                    NativeMethods.HandleException(
                        NativeMethods.core_InputArray_delete_withScalar(ptr, handle));
                    break;
                case HandleKind.Double:
                    Marshal.FreeHGlobal(handle);
                    goto default;
                case HandleKind.Vec:
                    var gch = GCHandle.FromIntPtr(handle);
                    if (gch.IsAllocated)
                        gch.Free();
                    goto default;
                default:
                    NativeMethods.HandleException(
                        NativeMethods.core_InputArray_delete(ptr));
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
            var list = new List<T>(enumerable);
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
            var list = new List<T>(enumerable);
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
            var type = EstimateType(typeof(T));
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

            var rows = array.Length;
            var mat = new Mat(rows, 1, type, array);
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
            var type = EstimateType(typeof(T));
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
            var rows = array.GetLength(0);
            var cols = array.GetLength(1);
            if (rows == 0)
                throw new ArgumentException("array.GetLength(0) == 0");
            if (cols == 0)
                throw new ArgumentException("array.GetLength(1) == 0");
            var mat = new Mat(rows, cols, type, array);
            return new InputArray(mat);
        }

        /// <summary>
        /// Creates a proxy class of the specified Vec*b
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static InputArray Create(IVec vec)
        {
            if (vec == null)
                throw new ArgumentNullException(nameof(vec));

            return vec switch
            {
                Vec2b v => new InputArray(new[] { v.Item0, v.Item1 }),
                Vec3b v => new InputArray(new[] { v.Item0, v.Item1, v.Item2 }),
                Vec4b v => new InputArray(new[] { v.Item0, v.Item1, v.Item2, v.Item3 }),
                Vec6b v => new InputArray(new[] { v.Item0, v.Item1, v.Item2, v.Item3, v.Item4, v.Item5 }),
                Vec2s v => new InputArray(new[] { v.Item0, v.Item1 }),
                Vec3s v => new InputArray(new[] { v.Item0, v.Item1, v.Item2 }),
                Vec4s v => new InputArray(new[] { v.Item0, v.Item1, v.Item2, v.Item3 }),
                Vec6s v => new InputArray(new[] { v.Item0, v.Item1, v.Item2, v.Item3, v.Item4, v.Item5 }),
                Vec2w v => new InputArray(new[] { v.Item0, v.Item1 }),
                Vec3w v => new InputArray(new[] { v.Item0, v.Item1, v.Item2 }),
                Vec4w v => new InputArray(new[] { v.Item0, v.Item1, v.Item2, v.Item3 }),
                Vec6w v => new InputArray(new[] { v.Item0, v.Item1, v.Item2, v.Item3, v.Item4, v.Item5 }),
                Vec2i v => new InputArray(new[] { v.Item0, v.Item1 }),
                Vec3i v => new InputArray(new[] { v.Item0, v.Item1, v.Item2 }),
                Vec4i v => new InputArray(new[] { v.Item0, v.Item1, v.Item2, v.Item3 }),
                Vec6i v => new InputArray(new[] { v.Item0, v.Item1, v.Item2, v.Item3, v.Item4, v.Item5 }),
                Vec2f v => new InputArray(new[] { v.Item0, v.Item1 }),
                Vec3f v => new InputArray(new[] { v.Item0, v.Item1, v.Item2 }),
                Vec4f v => new InputArray(new[] { v.Item0, v.Item1, v.Item2, v.Item3 }),
                Vec6f v => new InputArray(new[] { v.Item0, v.Item1, v.Item2, v.Item3, v.Item4, v.Item5 }),
                Vec2d v => new InputArray(new[] { v.Item0, v.Item1}),
                Vec3d v => new InputArray(new[] { v.Item0, v.Item1, v.Item2}),
                Vec4d v => new InputArray(new[] { v.Item0, v.Item1, v.Item2, v.Item3}),
                Vec6d v => new InputArray(new[] { v.Item0, v.Item1, v.Item2, v.Item3, v.Item4, v.Item5}),
                _ => throw new ArgumentException($"Not supported type: '{vec.GetType().Name}'", nameof(vec))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static MatType EstimateType(Type t)
        {
#if NET40
            if (!t.IsValueType)
#else
            if (!t.GetTypeInfo().IsValueType)
#endif
                throw new ArgumentException("Reference type is not supported.");

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
            return Create(mats);
        }
        
#pragma warning disable 1591
        public static implicit operator InputArray(Vec2b vec) { return Create(vec); }
        public static implicit operator InputArray(Vec3b vec) { return Create(vec); }
        public static implicit operator InputArray(Vec4b vec) { return Create(vec); }
        public static implicit operator InputArray(Vec6b vec) { return Create(vec); }
        public static implicit operator InputArray(Vec2s vec) { return Create(vec); }
        public static implicit operator InputArray(Vec3s vec) { return Create(vec); }
        public static implicit operator InputArray(Vec4s vec) { return Create(vec); }
        public static implicit operator InputArray(Vec6s vec) { return Create(vec); }
        public static implicit operator InputArray(Vec2w vec) { return Create(vec); }
        public static implicit operator InputArray(Vec3w vec) { return Create(vec); }
        public static implicit operator InputArray(Vec4w vec) { return Create(vec); }
        public static implicit operator InputArray(Vec6w vec) { return Create(vec); }
        public static implicit operator InputArray(Vec2i vec) { return Create(vec); }
        public static implicit operator InputArray(Vec3i vec) { return Create(vec); }
        public static implicit operator InputArray(Vec4i vec) { return Create(vec); }
        public static implicit operator InputArray(Vec6i vec) { return Create(vec); }
        public static implicit operator InputArray(Vec2f vec) { return Create(vec); }
        public static implicit operator InputArray(Vec3f vec) { return Create(vec); }
        public static implicit operator InputArray(Vec4f vec) { return Create(vec); }
        public static implicit operator InputArray(Vec6f vec) { return Create(vec); }
        public static implicit operator InputArray(Vec2d vec) { return Create(vec); }
        public static implicit operator InputArray(Vec3d vec) { return Create(vec); }
        public static implicit operator InputArray(Vec4d vec) { return Create(vec); }
        public static implicit operator InputArray(Vec6d vec) { return Create(vec); }
#pragma warning restore 1591

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
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_getMat(ptr, i, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat[] GetMatVector()
        {
            ThrowIfDisposed();
            using var vec = new VectorOfMat();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_getMatVector(ptr, vec.CvPtr));
            GC.KeepAlive(this);
            return vec.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetFlags()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_getFlags(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IntPtr GetObj()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_getObj(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Size GetSz()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_getSz(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        public InOutArrayKind Kind()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_kind(ptr, out var ret));
            GC.KeepAlive(this);
            return (InOutArrayKind)ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Dims(int i = -1)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_dims(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Cols(int i = -1)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_cols(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Rows(int i = -1)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_rows(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Size Size(int i = -1)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_size(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret;
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
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_sizend(ptr, sz, i, out var ret));
            GC.KeepAlive(this);
            return ret;
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
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_sameSize(ptr, arr.CvPtr, out var ret));
            GC.KeepAlive(this);
            GC.KeepAlive(arr);
            return ret != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Total(int i = -1)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_total(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret.ToInt64();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Type(int i = -1)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_type(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Depth(int i = -1)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_depth(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Channels(int i = -1)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_channels(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool IsContinuous(int i = -1)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_isContinuous(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool IsSubmatrix(int i = -1)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_isSubmatrix(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        ///
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_empty(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
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

            NativeMethods.HandleException(
                NativeMethods.core_InputArray_copyTo1(ptr, arr.CvPtr));

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

            NativeMethods.HandleException(
                NativeMethods.core_InputArray_copyTo2(ptr, arr.CvPtr, mask.CvPtr));

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
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_offset(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret.ToInt64();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Step(int i = -1)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_step(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret.ToInt64();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMat()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_isMat(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsUMat()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_isUMat(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMatVector()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_isMatVector(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsUMatVector()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_isUMatVector(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMatx()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_isMatx(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsVector()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_isVector(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsGpuMatVector()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_InputArray_isGpuMatVector(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        #endregion
    }
}
