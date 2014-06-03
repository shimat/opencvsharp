using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// Locality Sensitive Hash (LSH) table
    /// </summary>
#else
    /// <summary>
    /// Locality Sensitive Hash (LSH) table
    /// </summary>
#endif
    public class CvLSH : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and disposal
        #region CreateLSH
        #region Constructor
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
#endif
        public CvLSH(IntPtr ops, int d)
            : this(ops, d, 10, 10, MatrixType.F64C1, 4, -1)
        {
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
#endif
        public CvLSH(IntPtr ops, int d, int l)
            : this(ops, d, l, 10, MatrixType.F64C1, 4, -1)
        {
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
#endif
        public CvLSH(IntPtr ops, int d, int l, int k)
            : this(ops, d, l, k, MatrixType.F64C1, 4, -1)
        {
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
#endif
        public CvLSH(IntPtr ops, int d, int l, int k, MatrixType type)
            : this(ops, d, l, k, type, 4, -1)
        {
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
#endif
        public CvLSH(IntPtr ops, int d, int l, int k, MatrixType type, double r)
            : this(ops, d, l, k, type, r, -1)
        {
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <param name="seed"></param>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <param name="seed"></param>
#endif
        public CvLSH(IntPtr ops, int d, int l, int k, MatrixType type, double r, Int64 seed)
        {
            ptr = NativeMethods.cvCreateLSH(ops, d, l, k, type, r, seed);
            if (ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvLSH");
            }
        }
        #endregion
        #region Static initializer
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateLSH(IntPtr ops, int d)
        {
            return Cv.CreateLSH(ops, d, 10, 10, MatrixType.F64C1, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateLSH(IntPtr ops, int d, int l)
        {
            return Cv.CreateLSH(ops, d, l, 10, MatrixType.F64C1, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateLSH(IntPtr ops, int d, int l, int k)
        {
            return Cv.CreateLSH(ops, d, l, k, MatrixType.F64C1, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateLSH(IntPtr ops, int d, int l, int k, MatrixType type)
        {
            return Cv.CreateLSH(ops, d, l, k, type, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateLSH(IntPtr ops, int d, int l, int k, MatrixType type, double r)
        {
            return Cv.CreateLSH(ops, d, l, k, type, r, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct a Locality Sensitive Hash (LSH) table, for indexing d-dimensional vectors of
        /// given type. Vectors will be hashed L times with k-dimensional p-stable (p=2) functions.
        /// </summary>
        /// <param name="ops">(not supported argument on OpenCvSharp)</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateLSH(IntPtr ops, int d, int l, int k, MatrixType type, double r, Int64 seed)
        {
            return Cv.CreateLSH(ops, d, l, k, type, r, seed);
        }
        #endregion
        #endregion
        #region CreateMemoryLSH
        #region Constructor
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
#endif
        public CvLSH(int d, int n)
            : this(d, n, 10, 10, MatrixType.F64C1, 4, -1)
        {
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
#endif
        public CvLSH(int d, int n, int l)
            : this(d, n, l, 10, MatrixType.F64C1, 4, -1)
        {
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
#endif
        public CvLSH(int d, int n, int l, int k)
            : this(d, n, l, k, MatrixType.F64C1, 4, -1)
        {
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
#endif
        public CvLSH(int d, int n, int l, int k, MatrixType type)
            : this(d, n, l, k, type, 4, -1)
        {
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
#endif
        public CvLSH(int d, int n, int l, int k, MatrixType type, double r)
            : this(d, n, l, k, type, r, -1)
        {
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <param name="seed"></param>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <param name="seed"></param>
#endif
        public CvLSH(int d, int n, int l, int k, MatrixType type, double r, Int64 seed)
        {
            ptr = NativeMethods.cvCreateMemoryLSH(d, n, l, k, type, r, seed);
            if (ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvLSH");
            }
        }
        #endregion
        #region Static initializer
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateMemoryLSH(int d, int n)
        {
            return Cv.CreateMemoryLSH(d, n, 10, 10, MatrixType.F64C1, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateMemoryLSH(int d, int n, int l)
        {
            return Cv.CreateMemoryLSH(d, n, l, 10, MatrixType.F64C1, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateMemoryLSH(int d, int n, int l, int k)
        {
            return Cv.CreateMemoryLSH(d, n, l, k, MatrixType.F64C1, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateMemoryLSH(int d, int n, int l, int k, MatrixType type)
        {
            return Cv.CreateMemoryLSH(d, n, l, k, type, 4, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateMemoryLSH(int d, int n, int l, int k, MatrixType type, double r)
        {
            return Cv.CreateMemoryLSH(d, n, l, k, type, r, -1);
        }
#if LANG_JP
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Construct in-memory LSH table, with n bins.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
#endif
        public static CvLSH CreateMemoryLSH(int d, int n, int l, int k, MatrixType type, double r, long seed)
        {
            return Cv.CreateMemoryLSH(d, n, l, k, type, r, seed);
        }
        #endregion
        #endregion

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvLSH*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">struct CvLSH*</param>
#endif
        public CvLSH(IntPtr ptr)
        {
            this.ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvLSH*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">struct CvLSH*</param>
#endif
        public static CvLSH FromPtr(IntPtr ptr)
        {
            return new CvLSH(ptr);
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
                        NativeMethods.cvReleaseLSH(ref ptr);
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

        #region Methods
        #region Add
#if LANG_JP
        /// <summary>
        /// Add vectors to the LSH structure, optionally returning indices.
        /// </summary>
        /// <param name="data"></param>
#else
        /// <summary>
        /// Add vectors to the LSH structure, optionally returning indices.
        /// </summary>
        /// <param name="data"></param>
#endif
        public void Add(CvMat data)
        {
            Cv.LSHAdd(this, data, null);
        }
#if LANG_JP
        /// <summary>
        /// Add vectors to the LSH structure, optionally returning indices.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="indices"></param>
#else
        /// <summary>
        /// Add vectors to the LSH structure, optionally returning indices.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="indices"></param>
#endif
        public void Add(CvMat data, CvMat indices)
        {
            Cv.LSHAdd(this, data, indices);
        }
        #endregion
        #region Query
#if LANG_JP
        /// <summary>
        /// Query the LSH n times for at most k nearest points; data is n x d,
        /// indices and dist are n x k. At most emax stored points will be accessed. 
        /// </summary>
        /// <param name="queryPoints"></param>
        /// <param name="indices"></param>
        /// <param name="dist"></param>
        /// <param name="k"></param>
        /// <param name="emax"></param>
#else
        /// <summary>
        /// Query the LSH n times for at most k nearest points; data is n x d,
        /// indices and dist are n x k. At most emax stored points will be accessed. 
        /// </summary>
        /// <param name="queryPoints"></param>
        /// <param name="indices"></param>
        /// <param name="dist"></param>
        /// <param name="k"></param>
        /// <param name="emax"></param>
#endif
        public void Query(CvMat queryPoints, CvMat indices, CvMat dist, int k, int emax)
        {
            Cv.LSHQuery(this, queryPoints, indices, dist, k, emax);
        }
        #endregion
        #region Release
#if LANG_JP
        /// <summary>
        /// Free the given LSH structure.
        /// </summary>
#else
        /// <summary>
        /// Free the given LSH structure.
        /// </summary>
#endif
        public void Release()
        {
            Dispose();
        }
        #endregion
        #region Remove
#if LANG_JP
        /// <summary>
        /// Remove vectors from LSH, as addressed by given indices.
        /// </summary>
        /// <param name="indices"></param>
#else
        /// <summary>
        /// Remove vectors from LSH, as addressed by given indices.
        /// </summary>
        /// <param name="indices"></param>
#endif
        public void Remove(CvMat indices)
        {
            Cv.LSHRemove(this, indices);
        }
        #endregion
        #region Size
#if LANG_JP
        /// <summary>
        /// Return the number of vectors in the LSH.
        /// </summary>
        /// <returns>number of vectors</returns>
#else
        /// <summary>
        /// Return the number of vectors in the LSH.
        /// </summary>
        /// <returns>number of vectors</returns>
#endif
        public uint Size
        {
            get
            {
                return Cv.LSHSize(this);
            }
        }
        #endregion        
        #endregion
    }
}
