using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 多次元，多チャンネルの疎な行列
    /// </summary>
#else
    /// <summary>
    /// Multi-dimensional sparse multi-channel array
    /// </summary>
#endif
    public unsafe class CvSparseMat : CvArr, ICloneable
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">CvSparseMat*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">CvSparseMat*</param>
#endif
        public CvSparseMat(IntPtr ptr)
            : this(ptr, true)
        {
        }
        /// <summary>
        /// ポインタと自動解放の可否を指定して初期化
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose"></param>
        internal CvSparseMat(IntPtr ptr, bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            this.ptr = ptr;
        }

#if LANG_JP
        /// <summary>
        /// 疎な配列を作成する (cvCreateSparseMat).
        /// </summary>
        /// <param name="dims">配列の次元数．密な行列とは逆に，次元数は実質的には無制限である（2^16 まで）．</param>
        /// <param name="sizes">次元サイズの配列．</param>
        /// <param name="type">配列要素の種類.</param>
#else
        /// <summary>
        /// Creates sparse array (cvCreateSparseMat).
        /// </summary>
        /// <param name="dims">Number of array dimensions. As opposite to the dense matrix, the number of dimensions is practically unlimited (up to 2^16). </param>
        /// <param name="sizes">Array of dimension sizes. </param>
        /// <param name="type">Type of array elements.</param>
#endif
        public CvSparseMat(int dims, int[] sizes, MatrixType type)
            : base(true)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            
            IntPtr p = NativeMethods.cvCreateSparseMat(dims, sizes, type);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvSparseMat");
            
            ptr = p;
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
                        NativeMethods.cvReleaseSparseMat(ref ptr);
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
        public static CvSparseMat operator +(CvSparseMat a)
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
        public static CvSparseMat operator -(CvSparseMat a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator ~(CvSparseMat a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator +(CvSparseMat a, CvSparseMat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator +(CvSparseMat a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator -(CvSparseMat a, CvSparseMat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator -(CvSparseMat a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator *(CvSparseMat a, CvSparseMat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator *(CvSparseMat a, Double b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator /(CvSparseMat a, double b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator &(CvSparseMat a, CvSparseMat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator &(CvSparseMat a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator |(CvSparseMat a, CvSparseMat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator |(CvSparseMat a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator ^(CvSparseMat a, CvSparseMat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvSparseMat result = a.Clone();
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
        public static CvSparseMat operator ^(CvSparseMat a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvSparseMat result = a.Clone();
            Cv.XorS(a, b, result);
            return result;
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvSparseMat)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSparseMat));


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
                return ((WCvSparseMat*)ptr)->dims;
            }
        }
#if LANG_JP
        /// <summary>
        /// CvMat シグネチャ (CV_MAT_MAGIC_VAL)．要素の型とフラグ 
        /// </summary>
#else
        /// <summary>
        /// CvSparseMat signature (CV_SPARSE_MAT_MAGIC_VAL), element type and flags
        /// </summary>
#endif
        public int Type
        {
            get
            {
                return ((WCvSparseMat*)ptr)->type;
            }
        }
#if LANG_JP
        /// <summary>
        /// ハッシュテーブルのサイズを取得する
        /// </summary>
#else
        /// <summary>
        /// Size of hashtable
        /// </summary>
#endif
        public int HashSize
        {
            get
            {
                return ((WCvSparseMat*)ptr)->hashsize;
            }
        }
#if LANG_JP
        /// <summary>
        /// ハッシュテーブル
        /// </summary>
#else
        /// <summary>
        /// hashtable: each entry has a list of nodes having the same "hashvalue modulo hashsize"
        /// </summary>
#endif
        public IntPtr HashTable
        {
            get
            {
                return new IntPtr(((WCvSparseMat*)ptr)->hashtable);
            }
        }
#if LANG_JP
        /// <summary>
        /// ハッシュテーブルノードの保存領域（プール）を取得する
        /// </summary>
#else
        /// <summary>
        /// A pool of hashtable nodes
        /// </summary>
#endif
        public IntPtr Heap
        {
            get
            {
                return new IntPtr(((WCvSparseMat*)ptr)->heap);
            }
        }
#if LANG_JP
        /// <summary>
        /// 配列ノードのインデックスのオフセット（バイト単位）を取得する 
        /// </summary>
#else
        /// <summary>
        /// Index offset in bytes for the array nodes
        /// </summary>
#endif
        public int IdxOffset
        {
            get
            {
                return ((WCvSparseMat*)ptr)->idxoffset;
            }
        }
#if LANG_JP
        /// <summary>
        /// 配列ノードの値のオフセット（バイト単位）を取得する
        /// </summary>
#else
        /// <summary>
        /// Value offset in bytes for the array nodes
        /// </summary>
#endif
        public int ValOffset
        {
            get
            {
                return ((WCvSparseMat*)ptr)->valoffset;
            }
        }
#if LANG_JP
        /// <summary>
        /// 配列ノードの値のオフセット（バイト単位）を取得する
        /// </summary>
#else
        /// <summary>
        /// Arr of dimension sizes
        /// </summary>
#endif
        public int[] Size
        {
            get
            {
                int[] dst = new int[CvConst.CV_MAX_DIM];
                IntPtr src = new IntPtr(((WCvSparseMat*)ptr)->size);
                Marshal.Copy(src, dst, 0, dst.Length);
                return dst;
            }
        }
        #endregion

        #region Methods
        #region Clone
#if LANG_JP
        /// <summary>
        /// 疎な配列の完全なコピーを作成する
        /// </summary>
        /// <returns>コピーされた行列</returns>
#else
        /// <summary>
        /// Creates full copy of sparse array
        /// </summary>
        /// <returns>a copy of input array</returns>
#endif
        public CvSparseMat Clone()
        {
            return Cv.CloneSparseMat(this);
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
        #region NodeIdx
#if LANG_JP
        /// <summary>
        /// CV_NODE_IDX
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// CV_NODE_IDX
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
#endif
        public PointerAccessor1D_Int32 NodeIdx(CvSparseNode node)
        {
            return Cv.NODE_IDX(this, node);
        }
        #endregion
        #region NodeVal
#if LANG_JP
        /// <summary>
        /// CV_NODE_VAL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// CV_NODE_VAL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <returns></returns>
#endif
        public T NodeVal<T>(CvSparseNode node) where T : struct
        {
            return Cv.NODE_VAL<T>(this, node);
        }
        #endregion
        #endregion
    }

}
