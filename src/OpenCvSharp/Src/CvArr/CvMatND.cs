using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 多次元，多チャンネルの密な行列
    /// </summary>
#else
    /// <summary>
    /// Multi-dimensional dense multi-channel array
    /// </summary>
#endif
    public unsafe class CvMatND : CvArr, ICloneable
    {
        #region Fields
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;
        /// <summary>
        /// 
        /// </summary>
        private PointerAccessor1D_Byte _dataArrayByte;
        /// <summary>
        /// 
        /// </summary>
        private PointerAccessor1D_Int16 _dataArrayInt16;
        /// <summary>
        /// 
        /// </summary>
        private PointerAccessor1D_Int32 _dataArrayInt32;
        /// <summary>
        /// 
        /// </summary>
        private PointerAccessor1D_Single _dataArraySingle;
        /// <summary>
        /// 
        /// </summary>
        private PointerAccessor1D_Double _dataArrayDouble;
        #endregion

        #region Initialization and Disposal
#if LANG_JP
        /// <summary>
        /// 多次元の密な配列のヘッダとその内部データを確保する．
        /// </summary>
        /// <param name="dims">配列の次元数．CV_MAX_DIM（デフォルトでは32．ビルド時に変更される可能性もある）を超えてはいけない．</param>
        /// <param name="sizes">次元サイズの配列．</param>
        /// <param name="type">配列要素の種類．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates header for multi-dimensional dense array and the underlying data, and returns pointer to the created array.
        /// </summary>
        /// <param name="dims">Number of array dimensions. It must not exceed CV_MAX_DIM (=32 by default, though it may be changed at build time) </param>
        /// <param name="sizes">Array of dimension sizes. </param>
        /// <param name="type">Type of array elements.</param>
        /// <returns></returns>
#endif
        public CvMatND(int dims, int[] sizes, MatrixType type)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            
            ptr = NativeMethods.cvCreateMatND(dims, sizes, type);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvMat");
        }
#if LANG_JP
        /// <summary>
        /// 多次元の密な配列のヘッダとその内部データを確保する．
        /// </summary>
        /// <param name="dims">配列の次元数．CV_MAX_DIM（デフォルトでは32．ビルド時に変更される可能性もある）を超えてはいけない．</param>
        /// <param name="sizes">次元サイズの配列．</param>
        /// <param name="type">配列要素の種類．</param>
        /// <param name="data">行列のヘッダで指定されるデータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates header for multi-dimensional dense array and the underlying data, and returns pointer to the created array.
        /// </summary>
        /// <param name="dims">Number of array dimensions. It must not exceed CV_MAX_DIM (=32 by default, though it may be changed at build time) </param>
        /// <param name="sizes">Array of dimension sizes. </param>
        /// <param name="type">Type of array elements.</param>
        /// <param name="data">Optional data pointer assigned to the matrix header.</param>
        /// <returns></returns>
#endif
        public CvMatND(int dims, int[] sizes, MatrixType type, Array data)
            : this(dims, sizes, type)
        {
            GCHandle gch = AllocGCHandle(data);
            NativeMethods.cvInitMatNDHeader(CvPtr, dims, sizes, type, gch.AddrOfPinnedObject());
        }

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public CvMatND(IntPtr ptr)
            : this(ptr, true)
        {
        }
#if LANG_JP
        /// <summary>
        /// ポインタと自動解放の可否を指定して初期化
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose"></param>
#else
        /// <summary>
        /// Initializes by native pointer
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose">If true, this matrix will be disposed by GC automatically.</param>
#endif
        internal CvMatND(IntPtr ptr, bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            this.ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// sizeof(CvMat)の分のメモリの割り当てだけ行って初期化
        /// </summary>
#else
        /// <summary>
        /// Allocates memory
        /// </summary>
#endif
        public CvMatND()
            : this(true)
        {
        }
#if LANG_JP
        /// <summary>
        /// sizeof(CvMatND)の分のメモリの割り当てだけ行って、GC禁止設定で初期化
        /// </summary>
        /// <param name="isEnabledDispose">trueならGC有効</param>
#else
        /// <summary>
        /// Allocates memory
        /// </summary>
        /// <param name="isEnabledDispose">If true, this matrix will be disposed by GC automatically.</param>
#endif
        internal CvMatND(bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            ptr = AllocMemory(SizeOf);
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        NativeMethods.cvReleaseMat(ref ptr);
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

        #region Operators
#if LANG_JP
        /// <summary>
        /// 行列の単項+演算子
        /// </summary>
        /// <param name="a">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <param name="a">matrix</param>
        /// <returns></returns>
#endif
        public static CvMatND operator +(CvMatND a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            return a.Clone();
        }
#if LANG_JP
        /// <summary>
        /// 行列の単項-演算子
        /// </summary>
        /// <param name="a">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Unary negation operator
        /// </summary>
        /// <param name="a">matrix</param>
        /// <returns></returns>
#endif
        public static CvMatND operator -(CvMatND a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMatND result = a.Clone();
            Cv.AddWeighted(a, -1, a, 0, 0, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列の単項not演算子
        /// </summary>
        /// <param name="a">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Logical nagation operator
        /// </summary>
        /// <param name="a">matrix</param>
        /// <returns></returns>
#endif
        public static CvMatND operator ~(CvMatND a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMatND result = a.Clone();
            Cv.Not(a, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列と行列の加算演算子。cvAddにより加算する。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Binary plus operator (cvAdd)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static CvMatND operator +(CvMatND a, CvMatND b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvMatND result = a.Clone();
            Cv.Add(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーの加算演算子。cvAddSにより加算する。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Binary plus operator (cvAddS)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static CvMatND operator +(CvMatND a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMatND result = a.Clone();
            Cv.AddS(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列と行列の減算演算子。cvSubにより減算する。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Binary negation operator (cvSub)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static CvMatND operator -(CvMatND a, CvMatND b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvMatND result = a.Clone();
            Cv.Sub(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーの減算演算子。cvSubSにより加算する。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Binary negation operator (cvSub)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static CvMatND operator -(CvMatND a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMatND result = a.Clone();
            Cv.SubS(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列と行列の乗算演算子。cvMatMulにより乗算する。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Multiplicative operator (cvMatMul)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static CvMatND operator *(CvMatND a, CvMatND b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvMatND result = a.Clone();
            Cv.MatMul(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーの乗算演算子。aの要素ごとにbをかけた結果をcvAddWeightedにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Multiplicative operator (cvAddWeighted)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static CvMatND operator *(CvMatND a, Double b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMatND result = a.Clone();
            Cv.AddWeighted(a, b, a, 0, 0, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーの除算演算子。aの要素ごとにbで割った結果をcvAddWeightedにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Division operator (cvAddWeighted)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static CvMatND operator /(CvMatND a, double b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == 0)
                throw new DivideByZeroException();

            CvMatND result = a.Clone();
            Cv.AddWeighted(a, 1.0 / b, a, 0, 0, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列と行列のand演算子。cvAndにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bitwise AND operator (cvAnd)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static CvMatND operator &(CvMatND a, CvMatND b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvMatND result = a.Clone();
            Cv.And(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーのand演算子。cvAndSにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bitwise AND operator (cvAndS)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static CvMatND operator &(CvMatND a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMatND result = a.Clone();
            Cv.AndS(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列と行列のor演算子。cvOrにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bitwise OR operator (cvOr)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static CvMatND operator |(CvMatND a, CvMatND b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvMatND result = a.Clone();
            Cv.Or(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーのor演算子。cvOrSにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bitwise OR operator (cvOrS)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static CvMatND operator |(CvMatND a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMatND result = a.Clone();
            Cv.OrS(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列と行列のxor演算子。cvXorにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bitwise XOR operator (cvXor)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static CvMatND operator ^(CvMatND a, CvMatND b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvMatND result = a.Clone();
            Cv.Xor(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーのxor演算子。cvXorSにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bitwise XOR operator (cvXorS)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static CvMatND operator ^(CvMatND a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMatND result = a.Clone();
            Cv.XorS(a, b, result);
            return result;
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvMatND)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvMatND));

#if LANG_JP
        /// <summary>
        /// 配列の次元数を取得する
        /// </summary>
#else
        /// <summary>
        /// Get number of dimensions of the array
        /// </summary>
#endif
        new public int Dims
        {
            get
            {
                return ((WCvMatND*)ptr)->dims;
            }
        }
#if LANG_JP
        /// <summary>
        /// CvMatND シグネチャ (CV_MAT_MAGIC_VAL)．要素の型とフラグ 
        /// </summary>
#else
        /// <summary>
        /// CvMatND signature (CV_MATND_MAGIC_VAL), element type and flags
        /// </summary>
#endif
        public int Type
        {
            get
            {
                return ((WCvMatND*)ptr)->type;
            }
        }
#if LANG_JP
		/// <summary>
		/// 
		/// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public IntPtr RefCount
        {
            get
            {
                return new IntPtr(((WCvMatND*)ptr)->refcount);
            }
            internal set
            {
                ((WCvMatND*)ptr)->refcount = (int*)value;
            }
        }
#if LANG_JP
        /// <summary>
        /// 各次元での（要素数，要素間のバイト距離）の組
        /// </summary>
#else
        /// <summary>
        /// Pairs (number of elements, distance between elements in bytes) for every dimension
        /// </summary>
#endif
        public Dimension[] Dim
        {
            get 
            {
                Dimension[] result = new Dimension[CvConst.CV_MAX_DIM];
                int* dim = ((WCvMatND*)ptr)->dim;
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = new Dimension
                    {
                        Size = dim[i * 2 + 0],
                        Step = dim[i * 2 + 1]
                    };
                }
                return result;
            }
        }
#if LANG_JP
        /// <summary>
        /// 各次元での（要素数，要素間のバイト距離）の組
        /// </summary>
#else
        /// <summary>
        /// Pairs (number of elements, distance between elements in bytes) for every dimension
        /// </summary>
#endif
        [StructLayout(LayoutKind.Sequential)]
        public struct Dimension
        {
            /// <summary></summary>
            public int Size;
            /// <summary></summary>
            public int Step;
        }

        #region Matrix Data
#if LANG_JP
        /// <summary>
		/// 行列データへのポインタ.
		/// 実際に格納しているデータ型に応じて適宜byte*やdouble*等にキャストして利用する。
        /// </summary>
#else
        /// <summary>
        /// Data pointer
        /// </summary>
#endif
        public IntPtr Data
        {
            get
            {
                return new IntPtr(((WCvMatND*)ptr)->data);
            }
            internal set
            {
                ((WCvMatND*)ptr)->data = value.ToPointer();
            }
        }
#if LANG_JP
        /// <summary>
		/// 行列データへのByte型ポインタ.
		/// </summary>
#else
        /// <summary>
        /// Data pointer as byte*
        /// </summary>
#endif
        public byte* DataByte
        {
            get
            {
                return (byte*)(((WCvMatND*)ptr)->data);
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのInt16(short)型ポインタ.
        /// </summary>
#else
        /// <summary>
        /// Data pointer as short*
        /// </summary>
#endif
        public short* DataInt16
        {
            get
            {
                return (short*)(((WCvMatND*)ptr)->data);
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのInt32(int)型ポインタ.
        /// </summary>
#else
        /// <summary>
        /// Data pointer as int*
        /// </summary>
#endif
        public int* DataInt32
        {
            get
            {
                return (int*)(((WCvMatND*)ptr)->data);
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのSingle(float)型ポインタ.
        /// </summary>
#else
        /// <summary>
        /// Data pointer as float*
        /// </summary>
#endif
        public float* DataSingle
        {
            get
            {
                return (float*)(((WCvMatND*)ptr)->data);
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのDouble型ポインタ.
        /// </summary>
#else
        /// <summary>
        /// Data pointer as double*
        /// </summary>
#endif
        public double* DataDouble
        {
            get
            {
                return (double*)(((WCvMatND*)ptr)->data);
            }
        }
#if LANG_JP
        /// <summary>
		/// 行列データへのByte型ポインタ. 配列のようにアクセス可能.
        /// </summary>
#else
        /// <summary>
        /// Data pointer(byte*) which can be accessed without unsafe code.
        /// </summary>
#endif
        public PointerAccessor1D_Byte DataArrayByte
        {
            get
            {                
                if (_dataArrayByte == null)
                {
                    byte* p = (byte*)(((WCvMatND*)ptr)->data);
                    _dataArrayByte = new PointerAccessor1D_Byte(p);
                }
                return _dataArrayByte;
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのInt16(short)型ポインタ. 配列のようにアクセス可能.
        /// </summary>
#else
        /// <summary>
        /// Data pointer(short*) which can be accessed without unsafe code.
        /// </summary>
#endif
        public PointerAccessor1D_Int16 DataArrayInt16
        {
            get
            {
                if (_dataArrayInt16 == null)
                {
                    short* p = (short*)(((WCvMatND*)ptr)->data);
                    _dataArrayInt16 = new PointerAccessor1D_Int16(p);
                }
                return _dataArrayInt16;
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのInt32(int)型ポインタ. 配列のようにアクセス可能.
        /// </summary>
#else
        /// <summary>
        /// Data pointer(int*) which can be accessed without unsafe code.
        /// </summary>
#endif
        public PointerAccessor1D_Int32 DataArrayInt32
        {
            get
            {
                if (_dataArrayInt32 == null)
                {
                    int* p = (int*)(((WCvMatND*)ptr)->data);
                    _dataArrayInt32 = new PointerAccessor1D_Int32(p);
                }
                return _dataArrayInt32;
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのSingle(float)型ポインタ. 配列のようにアクセス可能.
        /// </summary>
#else
        /// <summary>
        /// Data pointer(float*) which can be accessed without unsafe code.
        /// </summary>
#endif
        public PointerAccessor1D_Single DataArraySingle
        {
            get
            {
                if (_dataArraySingle == null)
                {
                    float* p = (float*)(((WCvMatND*)ptr)->data);
                    _dataArraySingle = new PointerAccessor1D_Single(p);
                }
                return _dataArraySingle;
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのDouble型ポインタ. 配列のようにアクセス可能.
        /// </summary>
#else
        /// <summary>
        /// Data pointer(double*) which can be accessed without unsafe code.
        /// </summary>
#endif
        public PointerAccessor1D_Double DataArrayDouble
        {
            get
            {
                if (_dataArrayDouble == null)
                {
                    double* p = (double*)(((WCvMatND*)ptr)->data);
                    _dataArrayDouble = new PointerAccessor1D_Double(p);
                }
                return _dataArrayDouble;
            }
        }
        #endregion
        #endregion

        #region Methods
        #region Clone
#if LANG_JP
        /// <summary>
        /// 多次元配列の完全なコピーを作成する
        /// </summary>
        /// <returns>コピーされた行列</returns>
#else
        /// <summary>
        /// Creates full copy of multi-dimensional array
        /// </summary>
        /// <returns>a copy of input array</returns>
#endif
        public CvMatND Clone()
        {
            return Cv.CloneMatND(this);
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
        #region InitMatNDHeader
#if LANG_JP
        /// <summary>
        /// 多次元配列のヘッダを初期化する
        /// </summary>
        /// <param name="dims">配列の次元数</param>
        /// <param name="sizes">次元サイズの配列</param>
        /// <param name="type">配列要素の種類</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Initializes multi-dimensional array header.
        /// </summary>
        /// <param name="dims">Number of array dimensions. </param>
        /// <param name="sizes">Array of dimension sizes. </param>
        /// <param name="type">Type of array elements. The same as for CvMat. </param>
        /// <returns></returns>
#endif
        public CvMatND InitMatNDHeader(int dims, int[] sizes, MatrixType type)
        {
            return Cv.InitMatNDHeader(this, dims, sizes, type);
        }
#if LANG_JP
        /// <summary>
        /// 多次元配列のヘッダを初期化する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dims">配列の次元数</param>
        /// <param name="sizes">次元サイズの配列</param>
        /// <param name="type">配列要素の種類</param>
        /// <param name="data">行列のヘッダで指定されるデータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Initializes multi-dimensional array header.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dims">Number of array dimensions. </param>
        /// <param name="sizes">Array of dimension sizes. </param>
        /// <param name="type">Type of array elements. The same as for CvMat. </param>
        /// <param name="data">Optional data pointer assigned to the matrix header. </param>
        /// <returns></returns>
#endif
        public CvMatND InitMatNDHeader<T>(int dims, int[] sizes, MatrixType type, T[] data) where T : struct
        {
            return Cv.InitMatNDHeader(this, dims, sizes, type, data);
        }
        #endregion
        #endregion

    }
}
