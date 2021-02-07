using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp
{
    /// <summary>
    /// Type-specific abstract matrix 
    /// </summary>
    /// <typeparam name="TElem">Element Type</typeparam>
    public class Mat<TElem> : Mat
        where TElem : unmanaged
    {
        #region Init & Disposal

        private static MatType GetMatType()
        {
            var type = typeof(TElem);
            if (TypeMap.TryGetValue(type, out var value))
                return value;
            throw new NotSupportedException($"Type parameter {type} is not supported by Mat<T>");
        }

#if LANG_JP
        /// <summary>
        /// Creates empty Mat
        /// </summary>
#else
        /// <summary>
        /// Creates empty Mat
        /// </summary>
#endif
        public Mat()
            : this(0, 0)
        {
        }

#if LANG_JP
        /// <summary>
        /// OpenCVネイティブの cv::Mat* ポインタから初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Creates from native cv::Mat* pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public Mat(IntPtr ptr)
            : base(ptr)
        {
        }

#if LANG_JP
        /// <summary>
        /// Matオブジェクトから初期化 
        /// </summary>
        /// <param name="mat">Matオブジェクト</param>
#else
        /// <summary>
        /// Initializes by Mat object
        /// </summary>
        /// <param name="mat">Managed Mat object</param>
#endif
        public Mat(Mat mat)
            : base(mat)
        {
        }

#if LANG_JP
        /// <summary>
        /// 指定したサイズ・型の2次元の行列として初期化
        /// </summary>
        /// <param name="rows">2次元配列における行数．</param>
        /// <param name="cols">2次元配列における列数．</param>
#else
        /// <summary>
        /// constructs 2D matrix of the specified size and type
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
#endif
        public Mat(int rows, int cols)
            : base(rows, cols, GetMatType())
        {
        }

#if LANG_JP
        /// <summary>
        /// 指定したサイズ・型の2次元の行列として初期化
        /// </summary>
        /// <param name="size">2次元配列のサイズ： Size(cols, rows) ． Size コンストラクタでは，行数と列数が逆順になっていることに注意してください．</param>
#else
        /// <summary>
        /// constructs 2D matrix of the specified size and type
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) . In the Size() constructor, 
        /// the number of rows and the number of columns go in the reverse order.</param>
#endif
        public Mat(Size size)
            : base(size, GetMatType())
        {
        }

#if LANG_JP
        /// <summary>
        /// 指定したサイズ・型の2次元の行列で、要素をスカラー値で埋めて初期化
        /// </summary>
        /// <param name="rows">2次元配列における行数．</param>
        /// <param name="cols">2次元配列における列数．</param>
        /// <param name="s">各行列要素を初期化するオプション値．初期化の後ですべての行列要素を特定の値にセットするには，
        /// コンストラクタの後で，SetTo(Scalar value) メソッドを利用してください．</param>
#else
        /// <summary>
        /// constructs 2D matrix and fills it with the specified Scalar value.
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
#endif
        public Mat(int rows, int cols, Scalar s)
            : base(rows, cols, GetMatType(), s)
        {
        }

#if LANG_JP
        /// <summary>
        /// 指定したサイズ・型の2次元の行列で、要素をスカラー値で埋めて初期化
        /// </summary>
        /// <param name="size"> 2 次元配列のサイズ： Size(cols, rows) ． Size() コンストラクタでは，行数と列数が逆順になっていることに注意してください．</param>
        /// <param name="s">各行列要素を初期化するオプション値．初期化の後ですべての行列要素を特定の値にセットするには，
        /// コンストラクタの後で，SetTo(Scalar value) メソッドを利用してください．</param>
#else
        /// <summary>
        /// constructs 2D matrix and fills it with the specified Scalar value.
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) . In the Size() constructor, 
        /// the number of rows and the number of columns go in the reverse order.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
#endif
        public Mat(Size size, Scalar s)
            : base(size, GetMatType(), s)
        {
        }


#if LANG_JP
        /// <summary>
        /// 他の行列の部分行列として初期化
        /// </summary>
        /// <param name="m">作成された行列に（全体的，部分的に）割り当てられる配列．
        /// これらのコンストラクタによってデータがコピーされる事はありません．
        /// 代わりに，データ m ，またはその部分配列を指し示すヘッダが作成され，
        /// 関連した参照カウンタがあれば，それがインクリメントされます．
        /// つまり，新しく作成された配列の内容を変更することで， m の対応する要素も
        /// 変更することになります．もし部分配列の独立したコピーが必要ならば，
        /// Mat.Clone() を利用してください．</param>
        /// <param name="rowRange">扱われる 行列の行の範囲．すべての行を扱う場合は，Range.All を利用してください．</param>
        /// <param name="colRange">扱われる 行列の列の範囲．すべての列を扱う場合は，Range.All を利用してください．</param>
#else
        /// <summary>
        /// creates a matrix header for a part of the bigger matrix
        /// </summary>
        /// <param name="m">Array that (as a whole or partly) is assigned to the constructed matrix. 
        /// No data is copied by these constructors. Instead, the header pointing to m data or its sub-array 
        /// is constructed and associated with it. The reference counter, if any, is incremented. 
        /// So, when you modify the matrix formed using such a constructor, you also modify the corresponding elements of m . 
        /// If you want to have an independent copy of the sub-array, use Mat::clone() .</param>
        /// <param name="rowRange">Range of the m rows to take. As usual, the range start is inclusive and the range end is exclusive. 
        /// Use Range.All to take all the rows.</param>
        /// <param name="colRange">Range of the m columns to take. Use Range.All to take all the columns.</param>
#endif
        public Mat(Mat<TElem> m, Range rowRange, Range? colRange = null)
            : base(m, rowRange, colRange)
        {
        }

#if LANG_JP
        /// <summary>
        /// 他の行列の部分行列として初期化
        /// </summary>
        /// <param name="m">作成された行列に（全体的，部分的に）割り当てられる配列．
        /// これらのコンストラクタによってデータがコピーされる事はありません．
        /// 代わりに，データ m ，またはその部分配列を指し示すヘッダが作成され，
        /// 関連した参照カウンタがあれば，それがインクリメントされます．
        /// つまり，新しく作成された配列の内容を変更することで， m の対応する要素も
        /// 変更することになります．もし部分配列の独立したコピーが必要ならば，
        /// Mat.Clone() を利用してください．</param>
        /// <param name="ranges">多次元行列の各次元毎の選択範囲を表す配列．</param>
#else
        /// <summary>
        /// creates a matrix header for a part of the bigger matrix
        /// </summary>
        /// <param name="m">Array that (as a whole or partly) is assigned to the constructed matrix. 
        /// No data is copied by these constructors. Instead, the header pointing to m data or its sub-array 
        /// is constructed and associated with it. The reference counter, if any, is incremented. 
        /// So, when you modify the matrix formed using such a constructor, you also modify the corresponding elements of m . 
        /// If you want to have an independent copy of the sub-array, use Mat.Clone() .</param>
        /// <param name="ranges">Array of selected ranges of m along each dimensionality.</param>
#endif
        protected Mat(Mat<TElem> m, params Range[] ranges)
            : base(m, ranges)
        {
        }

#if LANG_JP
        /// <summary>
        /// 他の行列の部分行列として初期化
        /// </summary>
        /// <param name="m">作成された行列に（全体的，部分的に）割り当てられる配列．
        /// これらのコンストラクタによってデータがコピーされる事はありません．
        /// 代わりに，データ m ，またはその部分配列を指し示すヘッダが作成され，
        /// 関連した参照カウンタがあれば，それがインクリメントされます．
        /// つまり，新しく作成された配列の内容を変更することで， m の対応する要素も
        /// 変更することになります．もし部分配列の独立したコピーが必要ならば，
        /// Mat.Clone() を利用してください．</param>
        /// <param name="roi">元の行列からくりぬかれる範囲. ROI[Region of interest].</param>
#else
        /// <summary>
        /// creates a matrix header for a part of the bigger matrix
        /// </summary>
        /// <param name="m">Array that (as a whole or partly) is assigned to the constructed matrix. 
        /// No data is copied by these constructors. Instead, the header pointing to m data or its sub-array 
        /// is constructed and associated with it. The reference counter, if any, is incremented. 
        /// So, when you modify the matrix formed using such a constructor, you also modify the corresponding elements of m . 
        /// If you want to have an independent copy of the sub-array, use Mat.Clone() .</param>
        /// <param name="roi">Region of interest.</param>
#endif
        public Mat(Mat<TElem> m, Rect roi)
            : base(m, roi)
        {
        }

#if LANG_JP
        /// <summary>
        /// 利用者が別に確保したデータで初期化
        /// </summary>
        /// <param name="rows">2次元配列における行数．</param>
        /// <param name="cols">2次元配列における列数．</param>
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
        /// <param name="data">Pointer to the user data. Matrix constructors that take data and step parameters do not allocate matrix data. 
        /// Instead, they just initialize the matrix header that points to the specified data, which means that no data is copied. 
        /// This operation is very efficient and can be used to process external data using OpenCV functions. 
        /// The external data is not automatically de-allocated, so you should take care of it.</param>
        /// <param name="step">Number of bytes each matrix row occupies. The value should include the padding bytes at the end of each row, if any.
        /// If the parameter is missing (set to AUTO_STEP ), no padding is assumed and the actual step is calculated as cols*elemSize() .</param>
#endif
        protected Mat(int rows, int cols, IntPtr data, long step = 0)
            : base(rows, cols, GetMatType(), data, step)
        {
        }

#if LANG_JP
        /// <summary>
        /// 利用者が別に確保したデータで初期化
        /// </summary>
        /// <param name="rows">2次元配列における行数．</param>
        /// <param name="cols">2次元配列における列数．</param>
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
        /// <param name="data">Pointer to the user data. Matrix constructors that take data and step parameters do not allocate matrix data. 
        /// Instead, they just initialize the matrix header that points to the specified data, which means that no data is copied. 
        /// This operation is very efficient and can be used to process external data using OpenCV functions. 
        /// The external data is not automatically de-allocated, so you should take care of it.</param>
        /// <param name="step">Number of bytes each matrix row occupies. The value should include the padding bytes at the end of each row, if any.
        /// If the parameter is missing (set to AUTO_STEP ), no padding is assumed and the actual step is calculated as cols*elemSize() .</param>
#endif
        public Mat(int rows, int cols, Array data, long step = 0)
            : base(rows, cols, GetMatType(), data, step)
        {
        }

#if LANG_JP
        /// <summary>
        /// 利用者が別に確保したデータで初期化
        /// </summary>
        /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
        /// <param name="data">ユーザデータへのポインタ． data と step パラメータを引数にとる
        /// 行列コンストラクタは，行列データ領域を確保しません．代わりに，指定のデータを指し示す
        /// 行列ヘッダを初期化します．つまり，データのコピーは行われません．
        /// この処理は，非常に効率的で，OpenCV の関数を利用して外部データを処理することができます．
        /// 外部データが自動的に解放されることはありませんので，ユーザが解放する必要があります．</param>
        /// <param name="steps">多次元配列における ndims-1 個のステップを表す配列
        /// （最後のステップは常に要素サイズになります）．これが指定されないと，
        /// 行列は連続したものとみなされます．</param>
#else
        /// <summary>
        /// constructor for matrix headers pointing to user-allocated data
        /// </summary>
        /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
        /// <param name="data">Pointer to the user data. Matrix constructors that take data and step parameters do not allocate matrix data. 
        /// Instead, they just initialize the matrix header that points to the specified data, which means that no data is copied. 
        /// This operation is very efficient and can be used to process external data using OpenCV functions. 
        /// The external data is not automatically de-allocated, so you should take care of it.</param>
        /// <param name="steps">Array of ndims-1 steps in case of a multi-dimensional array (the last step is always set to the element size). 
        /// If not specified, the matrix is assumed to be continuous.</param>
#endif
        public Mat(IEnumerable<int> sizes, IntPtr data, IEnumerable<long>? steps = null)
            : base(sizes, GetMatType(), data, steps)
        {
        }

#if LANG_JP
        /// <summary>
        /// 利用者が別に確保したデータで初期化
        /// </summary>
        /// <param name="sizes">n-次元配列の形状を表す，整数型の配列．</param>
        /// <param name="data">ユーザデータへのポインタ． data と step パラメータを引数にとる
        /// 行列コンストラクタは，行列データ領域を確保しません．代わりに，指定のデータを指し示す
        /// 行列ヘッダを初期化します．つまり，データのコピーは行われません．
        /// この処理は，非常に効率的で，OpenCV の関数を利用して外部データを処理することができます．
        /// 外部データが自動的に解放されることはありませんので，ユーザが解放する必要があります．</param>
        /// <param name="steps">多次元配列における ndims-1 個のステップを表す配列
        /// （最後のステップは常に要素サイズになります）．これが指定されないと，
        /// 行列は連続したものとみなされます．</param>
#else
        /// <summary>
        /// constructor for matrix headers pointing to user-allocated data
        /// </summary>
        /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
        /// <param name="data">Pointer to the user data. Matrix constructors that take data and step parameters do not allocate matrix data. 
        /// Instead, they just initialize the matrix header that points to the specified data, which means that no data is copied. 
        /// This operation is very efficient and can be used to process external data using OpenCV functions. 
        /// The external data is not automatically de-allocated, so you should take care of it.</param>
        /// <param name="steps">Array of ndims-1 steps in case of a multi-dimensional array (the last step is always set to the element size). 
        /// If not specified, the matrix is assumed to be continuous.</param>
#endif
        public Mat(IEnumerable<int> sizes, Array data, IEnumerable<long>? steps = null)
            : base(sizes, GetMatType(), data, steps)
        {
        }

#if LANG_JP
        /// <summary>
        /// N次元行列として初期化
        /// </summary>
        /// <param name="sizes">n-次元配列の形状を表す，整数型の配列．</param>
#else
        /// <summary>
        /// constructs n-dimensional matrix
        /// </summary>
        /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
#endif
        public Mat(IEnumerable<int> sizes)
            : base(sizes, GetMatType())
        {
        }

#if LANG_JP
        /// <summary>
        /// N次元行列として初期化
        /// </summary>
        /// <param name="sizes">n-次元配列の形状を表す，整数型の配列．</param>
        /// <param name="s">各行列要素を初期化するオプション値．初期化の後ですべての行列要素を特定の値にセットするには，
        /// コンストラクタの後で，SetTo(Scalar value) メソッドを利用してください．</param>
#else
        /// <summary>
        /// constructs n-dimensional matrix
        /// </summary>
        /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
#endif
        public Mat(IEnumerable<int> sizes, Scalar s)
            : base(sizes, GetMatType(), s)
        {
        }

        #endregion

        #region Indexer

        /// <summary>
        /// Matrix indexer
        /// </summary>
        public sealed unsafe class Indexer : MatIndexer<TElem>
        {
            private readonly byte* ptr;

            internal Indexer(Mat parent)
                : base(parent)
            {
                ptr = (byte*)parent.Data.ToPointer();
            }

            /// <summary>
            /// 1-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <returns>A value to the specified array element.</returns>
            public override TElem this[int i0]
            {
                get => *(TElem*)(ptr + (Steps[0] * i0));
                set => *(TElem*)(ptr + (Steps[0] * i0)) = value;
            }

            /// <summary>
            /// 2-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <param name="i1">Index along the dimension 1</param>
            /// <returns>A value to the specified array element.</returns>
            public override TElem this[int i0, int i1]
            {
                get => *(TElem*)(ptr + (Steps[0] * i0) + (Steps[1] * i1));
                set => *(TElem*)(ptr + (Steps[0] * i0) + (Steps[1] * i1)) = value;
            }

            /// <summary>
            /// 3-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <param name="i1">Index along the dimension 1</param>
            /// <param name="i2"> Index along the dimension 2</param>
            /// <returns>A value to the specified array element.</returns>
            public override TElem this[int i0, int i1, int i2]
            {
                get => *(TElem*)(ptr + (Steps[0] * i0) + (Steps[1] * i1) + (Steps[2] * i2));
                set => *(TElem*)(ptr + (Steps[0] * i0) + (Steps[1] * i1) + (Steps[2] * i2)) = value;
            }

            /// <summary>
            /// n-dimensional indexer
            /// </summary>
            /// <param name="idx">Array of Mat::dims indices.</param>
            /// <returns>A value to the specified array element.</returns>
            public override TElem this[params int[] idx]
            {
                get
                {
                    long offset = 0;
                    for (var i = 0; i < idx.Length; i++)
                    {
                        offset += Steps[i] * idx[i];
                    }
                    return *(TElem*)(ptr + offset);
                }
                set
                {
                    long offset = 0;
                    for (var i = 0; i < idx.Length; i++)
                    {
                        offset += Steps[i] * idx[i];
                    }
                    *(TElem*)(ptr + offset) = value;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a type-specific indexer. The indexer has getters/setters to access each matrix element.
        /// </summary>
        /// <returns></returns>
        public MatIndexer<TElem> GetIndexer()
        {
            return new Indexer(this);
        }

        /// <summary>
        /// Gets read-only enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TElem> GetEnumerator()
        {
            ThrowIfDisposed();
            var indexer = new Indexer(this);

            var dims = Dims;
            if (dims == 2)
            {
                var rows = Rows;
                var cols = Cols;
                for (var r = 0; r < rows; r++)
                {
                    for (var c = 0; c < cols; c++)
                    {
                        yield return indexer[r, c];
                    }
                }
            }
            else
            {
                throw new NotImplementedException("GetEnumerator supports only 2-dimensional Mat");
            }
        }
        
        /// <summary>
        /// Convert this mat to managed array
        /// </summary>
        /// <returns></returns>
        public TElem[] ToArray()
        {
            if (Rows == 0 || Cols == 0)
                return Array.Empty<TElem>();

            if (!GetArray(out TElem[] array))
                throw new OpenCvSharpException("Failed to copy pixel data into managed array");

            return array;
        }

        /// <summary>
        /// Convert this mat to managed rectangular array
        /// </summary>
        /// <returns></returns>
        public TElem[,] ToRectangularArray()
        {
            if (Rows == 0 || Cols == 0)
                return new TElem[0, 0];

            if (!GetRectangularArray(out TElem[,] array))
                throw new OpenCvSharpException("Failed to copy pixel data into managed array");

            return array;
        }

#endregion

        #region Mat Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        protected Mat<TElem> Wrap(Mat mat)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));

            var ret = new Mat<TElem>();
            mat.AssignTo(ret);
            return ret;
        }
        
#region Clone

        /// <summary>
        /// Creates a full copy of the matrix.
        /// </summary>
        /// <returns></returns>
        public new Mat<TElem> Clone()
        {
            using (var result = base.Clone())
            {
                return Wrap(result);
            }
        }

#endregion
#region Reshape

        /// <summary>
        /// Changes the shape of channels of a 2D matrix without copying the data.
        /// </summary>
        /// <param name="rows">New number of rows. If the parameter is 0, the number of rows remains the same.</param>
        /// <returns></returns>
        public Mat<TElem> Reshape(int rows)
        {
#pragma warning disable CA2000 
            var result = base.Reshape(0, rows);
#pragma warning restore CA2000 
            return Wrap(result);
        }

        /// <summary>
        /// Changes the shape of a 2D matrix without copying the data.
        /// </summary>
        /// <param name="newDims">New number of rows. If the parameter is 0, the number of rows remains the same.</param>
        /// <returns></returns>
        public Mat<TElem> Reshape(params int[] newDims)
        {
#pragma warning disable CA2000 
            var result = base.Reshape(0, newDims);
#pragma warning restore CA2000
            return Wrap(result);
        }

#endregion
#region T

        /// <summary>
        /// Transposes a matrix.
        /// </summary>
        /// <returns></returns>
        public new Mat<TElem> T()
        {
            using (var result = base.T())
            {
                return Wrap(result);
            }
        }

#endregion

#region SubMat
        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="rowStart">Start row of the extracted submatrix. The upper boundary is not included.</param>
        /// <param name="rowEnd">End row of the extracted submatrix. The upper boundary is not included.</param>
        /// <param name="colStart">Start column of the extracted submatrix. The upper boundary is not included.</param>
        /// <param name="colEnd">End column of the extracted submatrix. The upper boundary is not included.</param>
        /// <returns></returns>
        public new Mat<TElem> SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
        {
#pragma warning disable CA2000 
            var result = base.SubMat(rowStart, rowEnd, colStart, colEnd);
#pragma warning restore CA2000 
            return Wrap(result);
        }

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="rowRange">Start and end row of the extracted submatrix. The upper boundary is not included. 
        /// To select all the rows, use Range.All().</param>
        /// <param name="colRange">Start and end column of the extracted submatrix. 
        /// The upper boundary is not included. To select all the columns, use Range.All().</param>
        /// <returns></returns>
        public new Mat<TElem> SubMat(Range rowRange, Range colRange)
        {
            return SubMat(rowRange.Start, rowRange.End, colRange.Start, colRange.End);
        }
        
        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="roi">Extracted submatrix specified as a rectangle.</param>
        /// <returns></returns>
        public new Mat<TElem> SubMat(Rect roi)
        {
            return SubMat(roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);
        }

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="ranges">Array of selected ranges along each array dimension.</param>
        /// <returns></returns>
        public new Mat<TElem> SubMat(params Range[] ranges)
        {
#pragma warning disable CA2000 
            var result = base.SubMat(ranges);
#pragma warning restore CA2000 
            return Wrap(result);
        }

#endregion
#region Mat Indexers
        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="rowStart">Start row of the extracted submatrix. The upper boundary is not included.</param>
        /// <param name="rowEnd">End row of the extracted submatrix. The upper boundary is not included.</param>
        /// <param name="colStart">Start column of the extracted submatrix. The upper boundary is not included.</param>
        /// <param name="colEnd">End column of the extracted submatrix. The upper boundary is not included.</param>
        /// <returns></returns>
        public new Mat<TElem> this[int rowStart, int rowEnd, int colStart, int colEnd]
        {
            get
            {
                var result = base[rowStart, rowEnd, colStart, colEnd];
                return Wrap(result);
            }
            set => base[rowStart, rowEnd, colStart, colEnd] = value;
        }

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="rowRange">Start and end row of the extracted submatrix. The upper boundary is not included. 
        /// To select all the rows, use Range.All().</param>
        /// <param name="colRange">Start and end column of the extracted submatrix. 
        /// The upper boundary is not included. To select all the columns, use Range.All().</param>
        /// <returns></returns>
        public new Mat<TElem> this[Range rowRange, Range colRange]
        {
            get
            {
                var result = base[rowRange, colRange];
                return Wrap(result);
            }
            set => base[rowRange, colRange] = value;
        }

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="roi">Extracted submatrix specified as a rectangle.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1043: Use integral or string argument for indexers")]
        public new Mat<TElem> this[Rect roi]
        {
            get
            {
                var result = base[roi];
                return Wrap(result);
            }
            set => base[roi] = value;
        }

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="ranges">Array of selected ranges along each array dimension.</param>
        /// <returns></returns>
        public new Mat<TElem> this[params Range[] ranges]
        {
            get
            {
                var result = base[ranges];
                return Wrap(result);
            }
            set => base[ranges] = value;
        }
#endregion

#endregion
    }
}
