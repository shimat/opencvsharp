#if ENABLED_CUDA

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Util;

namespace OpenCvSharp.Cuda
{
#if LANG_JP
    /// <summary>
    /// 参照カウンタを持つ，GPU メモリ用の基底ストレージクラス．
    /// </summary>
#else
    /// <summary>
    /// Smart pointer for GPU memory with reference counting. Its interface is mostly similar with cv::Mat.
    /// </summary>
#endif
    public class GpuMat : DisposableCvObject
    {
#region Init and Disposal

#if LANG_JP
    /// <summary>
    /// OpenCVネイティブの cv::gpu::GpuMat* ポインタから初期化
    /// </summary>
    /// <param name="ptr"></param>
#else
        /// <summary>
        /// Creates from native cv::gpu::GpuMat* pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public GpuMat(IntPtr ptr)
        {
            ThrowIfNotAvailable();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Native object address is NULL");
            this.ptr = ptr;
        }

#if LANG_JP
    /// <summary>
    /// 空の行列として初期化
    /// </summary>
#else
        /// <summary>
        /// Creates empty GpuMat
        /// </summary>
#endif
        public GpuMat()
        {
            ThrowIfNotAvailable();
            ptr = NativeMethods.cuda_GpuMat_new1();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
    /// <summary>
    /// 指定したサイズ・型の2次元の行列として初期化
    /// </summary>
    /// <param name="rows">2次元配列における行数．</param>
    /// <param name="cols">2次元配列における列数．</param>
    /// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
    /// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
#else
        /// <summary>
        /// constructs 2D matrix of the specified size and type
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
#endif
        public GpuMat(int rows, int cols, MatType type)
        {
            ThrowIfNotAvailable();
            if (rows <= 0)
                throw new ArgumentOutOfRangeException(nameof(rows));
            if (cols <= 0)
                throw new ArgumentOutOfRangeException(nameof(cols));
            ptr = NativeMethods.cuda_GpuMat_new2(rows, cols, type);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
    /// <summary>
    /// 利用者が別に確保したデータで初期化
    /// </summary>
    /// <param name="rows">2次元配列における行数．</param>
    /// <param name="cols">2次元配列における列数．</param>
    /// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
    /// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
    /// <param name="data">ユーザデータへのポインタ． data と step パラメータを引数にとる
    /// 行列コンストラクタは，行列データ領域を確保しません．代わりに，指定のデータを指し示す
    /// 行列ヘッダを初期化します．つまり，データのコピーは行われません．
    /// この処理は，非常に効率的で，OpenCV の関数を利用して外部データを処理することができます．
    /// 外部データが自動的に解放されることはありませんので，ユーザが解放する必要があります．</param>
    /// <param name="step">行列の各行が占めるバイト数を指定できます．
    /// この値は，各行の終端にパディングバイトが存在すれば，それも含みます．
    /// このパラメータが指定されない場合，パディングは存在しないとみなされ，
    /// 実際の step は cols*elemSize() として計算されます．</param>
#else
        /// <summary>
        /// constructor for matrix headers pointing to user-allocated data
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
        /// <param name="data">Pointer to the user data. Matrix constructors that take data and step parameters do not allocate matrix data. 
        /// Instead, they just initialize the matrix header that points to the specified data, which means that no data is copied. 
        /// This operation is very efficient and can be used to process external data using OpenCV functions. 
        /// The external data is not automatically deallocated, so you should take care of it.</param>
        /// <param name="step">Number of bytes each matrix row occupies. The value should include the padding bytes at the end of each row, if any.
        /// If the parameter is missing (set to AUTO_STEP ), no padding is assumed and the actual step is calculated as cols*elemSize() .</param>
#endif
        public GpuMat(int rows, int cols, MatType type, IntPtr data, long step)
        {
            ThrowIfNotAvailable();
            if (rows <= 0)
                throw new ArgumentOutOfRangeException(nameof(rows));
            if (cols <= 0)
                throw new ArgumentOutOfRangeException(nameof(cols));
            ptr = NativeMethods.cuda_GpuMat_new3(rows, cols, type, data, (ulong)step);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
    /// <summary>
    /// 指定したサイズ・型の2次元の行列として初期化
    /// </summary>
    /// <param name="size">2次元配列のサイズ： Size(cols, rows) </param>
    /// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
    /// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
#else
        /// <summary>
        /// constructs 2D matrix of the specified size and type
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) </param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType.CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
#endif
        public GpuMat(Size size, MatType type)
        {
            ThrowIfNotAvailable();
            ptr = NativeMethods.cuda_GpuMat_new6(size, type);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
    /// <summary>
    /// 利用者が別に確保したデータで初期化
    /// </summary>
    /// <param name="size">2次元配列のサイズ： Size(cols, rows)</param>
    /// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
    /// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
    /// <param name="data">ユーザデータへのポインタ． data と step パラメータを引数にとる
    /// 行列コンストラクタは，行列データ領域を確保しません．代わりに，指定のデータを指し示す
    /// 行列ヘッダを初期化します．つまり，データのコピーは行われません．
    /// この処理は，非常に効率的で，OpenCV の関数を利用して外部データを処理することができます．
    /// 外部データが自動的に解放されることはありませんので，ユーザが解放する必要があります．</param>
    /// <param name="step">行列の各行が占めるバイト数を指定できます．
    /// この値は，各行の終端にパディングバイトが存在すれば，それも含みます．
    /// このパラメータが指定されない場合，パディングは存在しないとみなされ，
    /// 実際の step は cols*elemSize() として計算されます．</param>
#else
        /// <summary>
        /// constructor for matrix headers pointing to user-allocated data
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) </param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
        /// <param name="data">Pointer to the user data. Matrix constructors that take data and step parameters do not allocate matrix data. 
        /// Instead, they just initialize the matrix header that points to the specified data, which means that no data is copied. 
        /// This operation is very efficient and can be used to process external data using OpenCV functions. 
        /// The external data is not automatically deallocated, so you should take care of it.</param>
        /// <param name="step">Number of bytes each matrix row occupies. The value should include the padding bytes at the end of each row, if any.
        /// If the parameter is missing (set to AUTO_STEP ), no padding is assumed and the actual step is calculated as cols*elemSize() .</param>
#endif
        public GpuMat(Size size, MatType type, IntPtr data, long step = 0)
        {
            ThrowIfNotAvailable();
            ptr = NativeMethods.cuda_GpuMat_new7(size, type, data, (ulong)step);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
    /// <summary>
    /// 他の行列のから初期化
    /// </summary>
    /// <param name="m">作成された行列に全体的割り当てられる配列．</param>
#else
        /// <summary>
        /// creates a matrix for other matrix
        /// </summary>
        /// <param name="m">Array that (as a whole) is assigned to the constructed matrix.</param>
#endif
        public GpuMat(Mat m)
        {
            ThrowIfNotAvailable();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            ptr = NativeMethods.cuda_GpuMat_new4(m.CvPtr);
            GC.KeepAlive(m);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
    /// <summary>
    /// 他のGpuMat初期化
    /// </summary>
    /// <param name="m">作成された行列に全体的割り当てられる配列．</param>
#else
        /// <summary>
        /// creates a matrix for other matrix
        /// </summary>
        /// <param name="m">GpuMat that (as a whole) is assigned to the constructed matrix.</param>
#endif
        public GpuMat(GpuMat m)
        {
            ThrowIfNotAvailable();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            ptr = NativeMethods.cuda_GpuMat_new5(m.CvPtr);
            GC.KeepAlive(m);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
    /// <summary>
    /// 指定したサイズ・型の2次元の行列で、要素をスカラー値で埋めて初期化
    /// </summary>
    /// <param name="rows">2次元配列における行数．</param>
    /// <param name="cols">2次元配列における列数．</param>
    /// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
    /// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
    /// <param name="s">各行列要素を初期化するオプション値．初期化の後ですべての行列要素を特定の値にセットするには，
    /// コンストラクタの後で，SetTo(Scalar value) メソッドを利用してください．</param>
#else
        /// <summary>
        /// constucts 2D matrix and fills it with the specified Scalar value.
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
#endif
        public GpuMat(int rows, int cols, MatType type, Scalar s)
        {
            ThrowIfNotAvailable();
            if (rows <= 0)
                throw new ArgumentOutOfRangeException(nameof(rows));
            if (cols <= 0)
                throw new ArgumentOutOfRangeException(nameof(cols));
            ptr = NativeMethods.cuda_GpuMat_new8(rows, cols, type, s);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
    /// <summary>
    /// 指定したサイズ・型の2次元の行列で、要素をスカラー値で埋めて初期化
    /// </summary>
    /// <param name="size"> 2 次元配列のサイズ： Size(cols, rows) </param>
    /// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
    /// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
    /// <param name="s">各行列要素を初期化するオプション値．初期化の後ですべての行列要素を特定の値にセットするには，
    /// コンストラクタの後で，SetTo(Scalar value) メソッドを利用してください．</param>
#else
        /// <summary>
        /// constucts 2D matrix and fills it with the specified Scalar value.
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) .</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
#endif
        public GpuMat(Size size, MatType type, Scalar s)
        {
            ThrowIfNotAvailable();
            ptr = NativeMethods.cuda_GpuMat_new11(size, type, s);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
    /// <summary>
    /// 他の行列の部分行列として初期化
    /// </summary>
    /// <param name="m">作成された行列に（全体的，部分的に）割り当てられる配列．</param>
    /// <param name="rowRange">扱われる 行列の行の範囲．すべての行を扱う場合は，Range.All を利用してください．</param>
    /// <param name="colRange">扱われる 行列の列の範囲．すべての列を扱う場合は，Range.All を利用してください．</param>
#else
        /// <summary>
        /// creates a matrix header for a part of the bigger matrix
        /// </summary>
        /// <param name="m">Array that (as a whole or partly) is assigned to the constructed matrix. </param>
        /// <param name="rowRange">Range of the m rows to take. As usual, the range start is inclusive and the range end is exclusive. 
        /// Use Range.All to take all the rows.</param>
        /// <param name="colRange">Range of the m columns to take. Use Range.All to take all the columns.</param>
#endif
        public GpuMat(GpuMat m, Range rowRange, Range colRange)
        {
            ThrowIfNotAvailable();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            ptr = NativeMethods.cuda_GpuMat_new9(m.CvPtr, rowRange, colRange);
            GC.KeepAlive(m);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
    /// <summary>
    /// 他の行列の部分行列として初期化
    /// </summary>
    /// <param name="m">作成された行列に（全体的，部分的に）割り当てられる配列．</param>
    /// <param name="roi">元の行列からくりぬかれる範囲. ROI[Region of interest].</param>
#else
        /// <summary>
        /// creates a matrix header for a part of the bigger matrix
        /// </summary>
        /// <param name="m">Array that (as a whole or partly) is assigned to the constructed matrix..</param>
        /// <param name="roi">Region of interest.</param>
#endif
        public GpuMat(GpuMat m, Rect roi)
        {
            ThrowIfNotAvailable();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            ptr = NativeMethods.cuda_GpuMat_new10(m.CvPtr, roi);
            GC.KeepAlive(m);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
#endif
        public void Release()
        {
            Dispose();
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.cuda_GpuMat_delete(ptr);
            base.DisposeUnmanaged();
        }
        
#endregion

#region Cast

        /// <summary>
        /// converts header to GpuMat
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static explicit operator GpuMat(Mat mat)
        {
            if (mat == null)
                return null;

            IntPtr ret = NativeMethods.cuda_GpuMat_opToGpuMat(mat.CvPtr);
            GC.KeepAlive(mat);
            return new GpuMat(ret);
        }

        /// <summary>
        /// converts header to Mat
        /// </summary>
        /// <param name="gpumat"></param>
        /// <returns></returns>
        public static implicit operator Mat(GpuMat gpumat)
        {
            if (gpumat == null)
                return null;

            IntPtr ret = NativeMethods.cuda_GpuMat_opToMat(gpumat.CvPtr);
            GC.KeepAlive(gpumat);
            return new Mat(ret);
        }
#endregion

#region Properties

        /// <summary>
        /// includes several bit-fields: 
        ///  1.the magic signature 
        ///  2.continuity flag 
        ///  3.depth 
        ///  4.number of channels
        /// </summary>
        public int Flags
        {
            get
            {
                ThrowIfDisposed();
                GC.KeepAlive(this);
                return NativeMethods.cuda_GpuMat_flags(ptr);
            }
        }

        /// <summary>
        /// the number of rows
        /// </summary>
        public int Rows
        {
            get 
            {
                ThrowIfDisposed();
                GC.KeepAlive(this);
                return NativeMethods.cuda_GpuMat_rows(ptr); 
            }
        }

        /// <summary>
        /// the number of columns
        /// </summary>
        public int Cols
        {
            get
            {
                ThrowIfDisposed();
                GC.KeepAlive(this);
                return NativeMethods.cuda_GpuMat_cols(ptr);
            }
        }

        /// <summary>
        /// the number of rows
        /// </summary>
        public int Height
        {
            get
            {
                ThrowIfDisposed();
                GC.KeepAlive(this);
                return NativeMethods.cuda_GpuMat_rows(ptr);
            }
        }

        /// <summary>
        /// the number of columns
        /// </summary>
        public int Width
        {
            get
            {
                ThrowIfDisposed();
                GC.KeepAlive(this);
                return NativeMethods.cuda_GpuMat_cols(ptr);
            }
        }

        /// <summary>
        /// pointer to the data
        /// </summary>
        public unsafe IntPtr Data
        {
            get
            {
                ThrowIfDisposed();
                GC.KeepAlive(this);
                return (IntPtr)NativeMethods.cuda_GpuMat_data(ptr);
            }
        }

        /// <summary>
        /// pointer to the reference counter;
        /// when matrix points to user-allocated data, the pointer is NULL
        /// </summary>
        public IntPtr RefCount
        {
            get
            {
                ThrowIfDisposed();
                GC.KeepAlive(this);
                return NativeMethods.cuda_GpuMat_refcount(ptr);
            }
        }

        /// <summary>
        /// helper fields used in locateROI and adjustROI
        /// </summary>
        public IntPtr DataStart
        {
            get
            {
                ThrowIfDisposed();
                GC.KeepAlive(this);
                return NativeMethods.cuda_GpuMat_datastart(ptr);
            }
        }

        /// <summary>
        /// helper fields used in locateROI and adjustROI
        /// </summary>
        public IntPtr DataEnd
        {
            get
            {
                ThrowIfDisposed();
                GC.KeepAlive(this);
                return NativeMethods.cuda_GpuMat_dataend(ptr);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int Bpp
        {
            get
            {
                return (int)Math.Pow(2, ((Depth() / 2) + 1) + 2);
            }
        }
#endregion

#region Indexers
#region Range Indexer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roi"></param>
        /// <returns></returns>
        public virtual GpuMat this[Rect roi]
        {
            get
            {
                IntPtr ret = NativeMethods.cuda_GpuMat_opRange1(ptr, roi);
                GC.KeepAlive(this);
                return new GpuMat(ret);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        /// <returns></returns>
        public virtual GpuMat this[Range rowRange, Range colRange]
        {
            get
            {
                IntPtr ret = NativeMethods.cuda_GpuMat_opRange2(ptr, rowRange, colRange);
                GC.KeepAlive(this);
                return new GpuMat(ret);
            }
        }

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="rowStart">Start row of the extracted submatrix. The upper boundary is not included.</param>
        /// <param name="rowEnd">End row of the extracted submatrix. The upper boundary is not included.</param>
        /// <param name="colStart">Start column of the extracted submatrix. The upper boundary is not included.</param>
        /// <param name="colEnd">End column of the extracted submatrix. The upper boundary is not included.</param>
        /// <returns></returns>
        public GpuMat this[int rowStart, int rowEnd, int colStart, int colEnd]
        {
            get
            {
                return this[new Range(rowStart, rowEnd), new Range(colStart, colEnd)];
            }
        }
#endregion

#region Element Indexer

        /// <summary>
        /// GpuMat Indexer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public sealed class Indexer<T> : GpuMatIndexer<T> where T : struct
        {
            private readonly long ptrVal;

            internal Indexer(GpuMat parent)
                : base(parent)
            {
                ptrVal = parent.Data.ToInt64();
            }

            /// <summary>
            /// 2-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <param name="i1">Index along the dimension 1</param>
            /// <returns>A value to the specified array element.</returns>
            public override T this[int i0, int i1]
            {
                get
                {
                    var p = new IntPtr(ptrVal + (step*i0) + (sizeOfT*i1));
                    return MarshalHelper.PtrToStructure<T>(p);
                }
                set
                {
                    var p = new IntPtr(ptrVal + (step*i0) + (sizeOfT*i1));
                    Marshal.StructureToPtr(value, p, false);
                }
            }
        }

        /// <summary>
        /// Gets a type-specific indexer. The indexer has getters/setters to access each matrix element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Indexer<T> GetGenericIndexer<T>() where T : struct
        {
            return new Indexer<T>(this);
        }

#endregion

#region Get/Set

        /// <summary>
        /// Returns a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <returns>A value to the specified array element.</returns>
        public T Get<T>(int i0, int i1) where T : struct
        {
            return new Indexer<T>(this)[i0, i1];
        }

        /// <summary>
        /// Returns a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <returns>A value to the specified array element.</returns>
        public T At<T>(int i0, int i1) where T : struct
        {
            return new Indexer<T>(this)[i0, i1];
        }

        /// <summary>
        /// Set a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <param name="value"></param>
        public void Set<T>(int i0, int i1, T value) where T : struct
        {
            (new Indexer<T>(this))[i0, i1] = value;
        }

#endregion
        
#region Col/ColRange

        /// <summary>
        /// returns a new matrix header for the specified column span
        /// </summary>
        /// <param name="startcol"></param>
        /// <param name="endcol"></param>
        /// <returns></returns>
        public GpuMat ColRange(int startcol, int endcol)
        {
            ThrowIfDisposed();
            IntPtr ret = NativeMethods.cuda_GpuMat_colRange(ptr, startcol, endcol);
            GC.KeepAlive(this);
            return new GpuMat(ret);
        }

        /// <summary>
        /// returns a new matrix header for the specified column span
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public GpuMat ColRange(Range r)
        {
            return ColRange(r.Start, r.End);
        }

        /// <summary>
        /// Mat column's indexer object
        /// </summary>
        public class ColIndexer : GpuMatRowColIndexer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="parent"></param>
            protected internal ColIndexer(GpuMat parent)
                : base(parent)
            {
            }

            /// <summary>
            /// Creates a matrix header for the specified matrix column.
            /// </summary>
            /// <param name="x">A 0-based column index.</param>
            /// <returns></returns>
            public override GpuMat this[int x]
            {
                get
                {
                    parent.ThrowIfDisposed();
                    IntPtr matPtr = NativeMethods.cuda_GpuMat_col(parent.ptr, x);
                    GC.KeepAlive(this);
                    return new GpuMat(matPtr);
                }
                set
                {
                    parent.ThrowIfDisposed();
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    value.ThrowIfDisposed();

                    var matPtr = NativeMethods.cuda_GpuMat_col(parent.ptr, x);
                    GC.KeepAlive(this);
                    var mat = new GpuMat(matPtr);
                    if (mat.Size() != value.Size())
                        throw new ArgumentException("Specified ROI != mat.Size()");
                    value.CopyTo(mat);
                }
            }

            /// <summary>
            /// Creates a matrix header for the specified column span.
            /// </summary>
            /// <param name="startCol">An inclusive 0-based start index of the column span.</param>
            /// <param name="endCol">An exclusive 0-based ending index of the column span.</param>
            /// <returns></returns>
            public override GpuMat this[int startCol, int endCol]
            {
                get
                {
                    parent.ThrowIfDisposed();
                    IntPtr matPtr = NativeMethods.cuda_GpuMat_colRange(parent.ptr, startCol, endCol);
                    GC.KeepAlive(this);
                    return new GpuMat(matPtr);
                }
                set
                {
                    parent.ThrowIfDisposed();
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    value.ThrowIfDisposed();

                    var colMatPtr = NativeMethods.cuda_GpuMat_colRange(parent.ptr, startCol, endCol);
                    GC.KeepAlive(this);
                    var colMat = new GpuMat(colMatPtr);
                    if (colMat.Size() != value.Size())
                        throw new ArgumentException("Specified ROI != mat.Size()");
                    value.CopyTo(colMat);
                }
            }
        }

        /// <summary>
        /// Indexer to access GpuMat column
        /// </summary>
        /// <returns></returns>
        public ColIndexer Col
        {
            get { return colIndexer ?? (colIndexer = new ColIndexer(this)); }
        }

        private ColIndexer colIndexer;

#endregion
#region Row/RowRange

        /// <summary>
        /// returns a new matrix header for the specified row span
        /// </summary>
        /// <param name="startrow"></param>
        /// <param name="endrow"></param>
        /// <returns></returns>
        public GpuMat RowRange(int startrow, int endrow)
        {
            ThrowIfDisposed();
            IntPtr ret = NativeMethods.cuda_GpuMat_rowRange(ptr, startrow, endrow);
            GC.KeepAlive(this);
            return new GpuMat(ret);
        }

        /// <summary>
        /// returns a new matrix header for the specified row span
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public GpuMat RowRange(Range r)
        {
            return RowRange(r.Start, r.End);
        }

        /// <summary>
        /// Mat row's indexer object
        /// </summary>
        public class RowIndexer : GpuMatRowColIndexer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="parent"></param>
            protected internal RowIndexer(GpuMat parent)
                : base(parent)
            {
            }

            /// <summary>
            /// Creates a matrix header for the specified matrix column.
            /// </summary>
            /// <param name="x">A 0-based column index.</param>
            /// <returns></returns>
            public override GpuMat this[int x]
            {
                get
                {
                    parent.ThrowIfDisposed();
                    var matPtr = NativeMethods.cuda_GpuMat_row(parent.ptr, x);
                    GC.KeepAlive(this);
                    return new GpuMat(matPtr);
                }
                set
                {
                    parent.ThrowIfDisposed();
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    value.ThrowIfDisposed();

                    var matPtr = NativeMethods.cuda_GpuMat_row(parent.ptr, x);
                    GC.KeepAlive(this);
                    var mat = new GpuMat(matPtr);
                    if (mat.Size() != value.Size())
                        throw new ArgumentException("Specified ROI != mat.Size()");
                    value.CopyTo(mat);
                }
            }

            /// <summary>
            /// Creates a matrix header for the specified column span.
            /// </summary>
            /// <param name="startCol">An inclusive 0-based start index of the column span.</param>
            /// <param name="endCol">An exclusive 0-based ending index of the column span.</param>
            /// <returns></returns>
            public override GpuMat this[int startCol, int endCol]
            {
                get
                {
                    parent.ThrowIfDisposed();
                    var matPtr = NativeMethods.cuda_GpuMat_rowRange(parent.ptr, startCol, endCol);
                    GC.KeepAlive(this);
                    return new GpuMat(matPtr);
                }
                set
                {
                    parent.ThrowIfDisposed();
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    value.ThrowIfDisposed();

                    var matPtr = NativeMethods.cuda_GpuMat_rowRange(parent.ptr, startCol, endCol);
                    GC.KeepAlive(this);
                    var mat = new GpuMat(matPtr);
                    if (mat.Size() != value.Size())
                        throw new ArgumentException("Specified ROI != mat.Size()");
                    value.CopyTo(mat);
                }
            }
        }

        /// <summary>
        /// Indexer to access GpuMat row
        /// </summary>
        /// <returns></returns>
        public RowIndexer Row
        {
            get { return rowIndexer ?? (rowIndexer = new RowIndexer(this)); }
        }

        private RowIndexer rowIndexer;

#endregion
#endregion

#region Public methods
        
        /// <summary>
        /// returns true iff the GpuMatrix data is continuous
        /// (i.e. when there are no gaps between successive rows).
        /// similar to CV_IS_GpuMat_CONT(cvGpuMat->type)
        /// </summary>
        /// <returns></returns>
        public bool IsContinuous()
        {
            ThrowIfDisposed();
            var res = NativeMethods.cuda_GpuMat_isContinuous(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns the number of matrix channels.
        /// </summary>
        /// <returns></returns>
        public int Channels()
        {
            ThrowIfDisposed();
            var res = NativeMethods.cuda_GpuMat_channels(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns the depth of a matrix element.
        /// </summary>
        /// <returns></returns>
        public int Depth()
        {
            ThrowIfDisposed();
            var res = NativeMethods.cuda_GpuMat_depth(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns the matrix element size in bytes.
        /// </summary>
        /// <returns></returns>
        public long ElemSize()
        {
            ThrowIfDisposed();
            var res = (long)NativeMethods.cuda_GpuMat_elemSize(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns the size of each matrix element channel in bytes.
        /// </summary>
        /// <returns></returns>
        public long ElemSize1()
        {
            ThrowIfDisposed();
            var res = (long)NativeMethods.cuda_GpuMat_elemSize1(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns a matrix size.
        /// </summary>
        /// <returns></returns>
        public Size Size()
        {
            ThrowIfDisposed();
            var res = NativeMethods.cuda_GpuMat_size(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// a distance between successive rows in bytes; includes the gap if any
        /// </summary>
        public long Step()
        {
            ThrowIfDisposed();
            var res = (long)NativeMethods.cuda_GpuMat_step(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns a normalized step.
        /// </summary>
        public long Step1()
        {
            ThrowIfDisposed();
            var res = (long)NativeMethods.cuda_GpuMat_step1(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns the type of a matrix element.
        /// </summary>
        /// <returns></returns>
        public MatType Type()
        {
            ThrowIfDisposed();
            var res = NativeMethods.cuda_GpuMat_type(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// returns true if GpuMatrix data is NULL
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            ThrowIfDisposed();
            var res = NativeMethods.cuda_GpuMat_empty(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Pefroms blocking upload data to GpuMat.
        /// </summary>
        /// <param name="m"></param>
        public void Upload(Mat m)
        {
            ThrowIfDisposed();
            NativeMethods.cuda_GpuMat_upload(ptr, m.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }

        /// <summary>
        /// Downloads data from device to host memory. Blocking calls.
        /// </summary>
        /// <param name="m"></param>
        public void Download(Mat m)
        {
            ThrowIfDisposed();
            NativeMethods.cuda_GpuMat_download(ptr, m.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }

        /// <summary>
        /// returns deep copy of the matrix, i.e. the data is copied
        /// </summary>
        /// <returns></returns>
        public GpuMat Clone()
        {
            ThrowIfDisposed();
            IntPtr ret = NativeMethods.cuda_GpuMat_clone(ptr);
            GC.KeepAlive(this);
            return new GpuMat(ret);
        }

        /// <summary>
        /// copies those matrix elements to "m"
        /// </summary>
        /// <param name="m"></param>
        public void CopyTo(GpuMat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.cuda_GpuMat_copyTo1(ptr, m.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }

        /// <summary>
        /// copies those matrix elements to "m" that are marked with non-zero mask elements.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="mask"></param>
        public void CopyTo(GpuMat m, GpuMat mask)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            if (mask == null)
                throw new ArgumentNullException(nameof(mask));
            NativeMethods.cuda_GpuMat_copyTo2(ptr, m.CvPtr, mask.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// converts matrix to another datatype with optional scalng. See cvConvertScale.
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="rtype"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <returns></returns>
        public void ConvertTo(GpuMat dst, MatType rtype, double alpha = 1, double beta = 0)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            NativeMethods.cuda_GpuMat_convertTo(ptr, dst.CvPtr, rtype, alpha, beta);
            GC.KeepAlive(this);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public void AssignTo(GpuMat m)
        {
            ThrowIfDisposed();
            NativeMethods.cuda_GpuMat_assignTo(ptr, m.CvPtr, -1);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="type"></param>
        public void AssignTo(GpuMat m, MatType type)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.cuda_GpuMat_assignTo(ptr, m.CvPtr, type);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }

        /// <summary>
        /// sets some of the matrix elements to s, according to the mask
        /// </summary>
        /// <param name="s"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public GpuMat SetTo(Scalar s, GpuMat mask = null)
        {
            ThrowIfDisposed();
            IntPtr ret = NativeMethods.cuda_GpuMat_setTo(ptr, s, Cv2.ToPtr(mask));
            GC.KeepAlive(this);
            GC.KeepAlive(mask);
            return new GpuMat(ret);
        }

        /// <summary>
        /// creates alternative matrix header for the same data, with different
        /// number of channels and/or different number of rows. see cvReshape.
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public GpuMat Reshape(int cn, int rows)
        {
            ThrowIfDisposed();
            IntPtr ret = NativeMethods.cuda_GpuMat_reshape(ptr, cn, rows);
            GC.KeepAlive(this);
            return new GpuMat(ret);
        }

        /// <summary>
        /// allocates new matrix data unless the matrix already has specified size and type.
        /// previous data is unreferenced if needed.
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type. </param>
        public void Create(int rows, int cols, MatType type)
        {
            ThrowIfDisposed();
            NativeMethods.cuda_GpuMat_create1(ptr, rows, cols, type);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// allocates new matrix data unless the matrix already has specified size and type.
        /// previous data is unreferenced if needed.
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) </param>
        /// <param name="type">Array type. </param>
        public void Create(Size size, MatType type)
        {
            ThrowIfDisposed();
            NativeMethods.cuda_GpuMat_create2(ptr, size, type);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// swaps with other smart pointer
        /// </summary>
        /// <param name="mat"></param>
        public void Swap(GpuMat mat)
        {
            ThrowIfDisposed();
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));
            NativeMethods.cuda_GpuMat_swap(ptr, mat.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(mat);
        }

        /// <summary>
        /// locates matrix header within a parent matrix.
        /// </summary>
        /// <param name="wholeSize"></param>
        /// <param name="ofs"></param>
        public void LocateROI(out Size wholeSize, out Point ofs)
        {
            ThrowIfDisposed();
            NativeMethods.cuda_GpuMat_locateROI(ptr, out wholeSize, out ofs);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// moves/resizes the current matrix ROI inside the parent matrix.
        /// </summary>
        /// <param name="dtop"></param>
        /// <param name="dbottom"></param>
        /// <param name="dleft"></param>
        /// <param name="dright"></param>
        /// <returns></returns>
        public GpuMat AdjustROI(int dtop, int dbottom, int dleft, int dright)
        {
            ThrowIfDisposed();
            IntPtr ret = NativeMethods.cuda_GpuMat_adjustROI(ptr, dtop, dbottom, dleft, dright);
            GC.KeepAlive(this);
            return new GpuMat(ret);
        }

        /// <summary>
        /// returns pointer to y-th row
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public unsafe byte* Ptr(int y = 0)
        {
            ThrowIfDisposed();
            var res = NativeMethods.cuda_GpuMat_ptr(ptr, y);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns a string that represents this Mat.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Mat [ " +
                   Rows + "*" + Cols + "*" + Type().ToString() +
                   ", IsContinuous=" + IsContinuous() +
                   ", Ptr=0x" + Convert.ToString(ptr.ToInt64(), 16) +
                   ", Data=0x" + Convert.ToString(Data.ToInt64(), 16) +
                   " ]";
        }

#endregion

        private void ThrowIfNotAvailable()
        {
            ThrowIfDisposed();
            if (Cv2.GetCudaEnabledDeviceCount() < 1)
                throw new OpenCvSharpException("GPU module cannot be used.");
        }
    }
}

#endif
