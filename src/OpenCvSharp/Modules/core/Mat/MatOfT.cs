using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace OpenCvSharp
{
    /// <summary>
    /// Type-specific abstract matrix 
    /// </summary>
    /// <typeparam name="TElem">Element Type</typeparam>
    public class Mat<TElem> : Mat, ICollection<TElem> 
        where TElem : unmanaged
    {
        #region Static Constructor 

        private static readonly Dictionary<Type, MatType> typeMap;

        /// <summary>
        /// /
        /// </summary>
        static Mat()
        {
            typeMap = new Dictionary<Type, MatType>
            {
                [typeof(byte)] = MatType.CV_8UC1,
                [typeof(sbyte)] = MatType.CV_8SC1,
                [typeof(short)] = MatType.CV_16SC1,
                [typeof(char)] = MatType.CV_16UC1,
                [typeof(ushort)] = MatType.CV_16UC1,
                [typeof(int)] = MatType.CV_32SC1,
                [typeof(float)] = MatType.CV_32FC1,
                [typeof(double)] = MatType.CV_64FC1,

                [typeof(Vec2b)] = MatType.CV_8UC2,
                [typeof(Vec3b)] = MatType.CV_8UC3,
                [typeof(Vec4b)] = MatType.CV_8UC4,
                [typeof(Vec6b)] = MatType.CV_8UC(6),

                [typeof(Vec2s)] = MatType.CV_16SC2,
                [typeof(Vec3s)] = MatType.CV_16SC3,
                [typeof(Vec4s)] = MatType.CV_16SC4,
                [typeof(Vec6s)] = MatType.CV_16SC(6),

                [typeof(Vec2w)] = MatType.CV_16UC2,
                [typeof(Vec3w)] = MatType.CV_16UC3,
                [typeof(Vec4w)] = MatType.CV_16UC4,
                [typeof(Vec6w)] = MatType.CV_16UC(6),

                [typeof(Vec2i)] = MatType.CV_32SC2,
                [typeof(Vec3i)] = MatType.CV_32SC3,
                [typeof(Vec4i)] = MatType.CV_32SC4,
                [typeof(Vec6i)] = MatType.CV_32SC(6),

                [typeof(Vec2f)] = MatType.CV_32FC2,
                [typeof(Vec3f)] = MatType.CV_32FC3,
                [typeof(Vec4f)] = MatType.CV_32FC4,
                [typeof(Vec6f)] = MatType.CV_32FC(6),

                [typeof(Vec2d)] = MatType.CV_64FC2,
                [typeof(Vec3d)] = MatType.CV_64FC3,
                [typeof(Vec4d)] = MatType.CV_64FC4,
                [typeof(Vec6d)] = MatType.CV_64FC(6),

                [typeof(Point)] = MatType.CV_32SC2,
                [typeof(Point2f)] = MatType.CV_32FC2,
                [typeof(Point2d)] = MatType.CV_64FC2,

                [typeof(Point3i)] = MatType.CV_32SC3,
                [typeof(Point3f)] = MatType.CV_32FC3,
                [typeof(Point3d)] = MatType.CV_64FC3,

                [typeof(Size)] = MatType.CV_32SC2,
                [typeof(Size2f)] = MatType.CV_32FC2,
                [typeof(Size2d)] = MatType.CV_64FC2,

                [typeof(Rect)] = MatType.CV_32SC4,
                [typeof(Rect2f)] = MatType.CV_32FC4,
                [typeof(Rect2d)] = MatType.CV_64FC4,

                [typeof(DMatch)] = MatType.CV_32FC4,
            };           
        }

        private static MatType GetMatType()
        {
            var type = typeof(TElem);
            if (typeMap.TryGetValue(type, out var value))
                return value;
            throw new NotSupportedException($"Type parameter {type} is not supported by Mat<T>");            
        }

        #region FromArray
#if LANG_JP
        /// <summary>
        /// N x 1 の行列(ベクトル)として初期化し、指定した配列からデータをコピーする
        /// </summary>
        /// <param name="arr">この行列にコピーされるデータ</param>
#else
        /// <summary>
        /// Initializes as N x 1 matrix and copies array data to this
        /// </summary>
        /// <param name="arr">Source array data to be copied to this</param>
#endif
        public static Mat<TElem> FromArray(params TElem[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (arr.Length == 0)
                throw new ArgumentException("arr.Length == 0");

            int numElems = arr.Length/* / ThisChannels*/;
            var mat = new Mat<TElem>(numElems, 1);

            var methodInfo = typeof(Mat).GetMethod(
                "SetArray",
                BindingFlags.Public | BindingFlags.Instance,
                null,
                new[] { typeof(int), typeof(int), arr.GetType() },
                null);
            if (methodInfo == null)
                throw new NotSupportedException($"Invalid Mat type {typeof(TElem)}");
            methodInfo.Invoke(mat, new object[] { 0, 0, arr });

            return mat;
        }

#if LANG_JP
        /// <summary>
        /// M x N の行列として初期化し、指定した配列からデータをコピーする
        /// </summary>
        /// <param name="arr">この行列にコピーされるデータ</param>
#else
        /// <summary>
        /// Initializes as M x N matrix and copies array data to this
        /// </summary>
        /// <param name="arr">Source array data to be copied to this</param>
#endif
        public static Mat<TElem> FromArray(TElem[,] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (arr.Length == 0)
                throw new ArgumentException("arr.Length == 0");

            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            var mat = new Mat<TElem>(rows, cols);
            //mat.SetArray(0, 0, arr);

            var methodInfo = typeof(Mat).GetMethod(
                "SetArray",
                BindingFlags.Public | BindingFlags.Instance,
                null,
                new[] { typeof(int), typeof(int), arr.GetType() },
                null);
            if (methodInfo == null)
                throw new NotSupportedException($"Invalid Mat type {typeof(TElem)}");
            methodInfo.Invoke(mat, new object[] { 0, 0, arr });

            return mat;
        }
#if LANG_JP
        /// <summary>
        /// N x 1 の行列(ベクトル)として初期化し、指定した配列からデータをコピーする
        /// </summary>
        /// <param name="enumerable">この行列にコピーされるデータ</param>
#else
        /// <summary>
        /// Initializes as N x 1 matrix and copies array data to this
        /// </summary>
        /// <param name="enumerable">Source array data to be copied to this</param>
#endif
        public static Mat<TElem> FromArray(IEnumerable<TElem> enumerable)
        {
            return FromArray(OpenCvSharp.Util.EnumerableEx.ToArray(enumerable));
        }
        #endregion

        #endregion

        #region Init & Disposal

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
            : base()
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
        protected Mat(Size size)
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
        /// constucts 2D matrix and fills it with the specified Scalar value.
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
#endif
        protected Mat(int rows, int cols, Scalar s)
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
        /// constucts 2D matrix and fills it with the specified Scalar value.
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) . In the Size() constructor, 
        /// the number of rows and the number of columns go in the reverse order.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
#endif
        protected Mat(Size size, Scalar s)
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
        protected Mat(Mat<TElem> m, Range rowRange, Range? colRange = null)
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
        protected Mat(Mat<TElem> m, Rect roi)
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
        /// The external data is not automatically deallocated, so you should take care of it.</param>
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
        /// The external data is not automatically deallocated, so you should take care of it.</param>
        /// <param name="step">Number of bytes each matrix row occupies. The value should include the padding bytes at the end of each row, if any.
        /// If the parameter is missing (set to AUTO_STEP ), no padding is assumed and the actual step is calculated as cols*elemSize() .</param>
#endif
        protected Mat(int rows, int cols, Array data, long step = 0)
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
        /// The external data is not automatically deallocated, so you should take care of it.</param>
        /// <param name="steps">Array of ndims-1 steps in case of a multi-dimensional array (the last step is always set to the element size). 
        /// If not specified, the matrix is assumed to be continuous.</param>
#endif
        protected Mat(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
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
        /// The external data is not automatically deallocated, so you should take care of it.</param>
        /// <param name="steps">Array of ndims-1 steps in case of a multi-dimensional array (the last step is always set to the element size). 
        /// If not specified, the matrix is assumed to be continuous.</param>
#endif
        protected Mat(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
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
        protected Mat(IEnumerable<int> sizes)
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
        protected Mat(IEnumerable<int> sizes, Scalar s)
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
                get
                {
                    return *(TElem*)(ptr + (steps[0] * i0));
                }
                set
                {
                    *(TElem*)(ptr + (steps[0] * i0)) = value;
                }
            }

            /// <summary>
            /// 2-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <param name="i1">Index along the dimension 1</param>
            /// <returns>A value to the specified array element.</returns>
            public override TElem this[int i0, int i1]
            {
                get
                {
                    return *(TElem*)(ptr + (steps[0] * i0) + (steps[1] * i1));
                }
                set
                {
                    *(TElem*)(ptr + (steps[0] * i0) + (steps[1] * i1)) = value;
                }
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
                get
                {
                    return *(TElem*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                }
                set
                {
                    *(TElem*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2)) = value;
                }
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
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    return *(TElem*)(ptr + offset);
                }
                set
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
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
            Indexer indexer = new Indexer(this);

            int dims = Dims();
            if (dims == 2)
            {
                int rows = Rows;
                int cols = Cols;
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
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
        /// For non-generic IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Convert this mat to managed array
        /// </summary>
        /// <returns></returns>
        public TElem[] ToArray()
        {
            long numOfElems = Total();
            if (numOfElems == 0)
                return new TElem[0];
            TElem[] arr = new TElem[numOfElems];
            //GetArray(0, 0, arr);

            var methodInfo = typeof(Mat).GetMethod(
                "GetArray", 
                BindingFlags.Public | BindingFlags.Instance, 
                null,
                new[] {typeof(int), typeof(int), arr.GetType()},
                null);
            if (methodInfo == null)
                throw new NotSupportedException($"Invalid Mat type {typeof(TElem)}");
            methodInfo.Invoke(this, new object[] { 0, 0, arr });

            return arr;
        }

        /// <summary>
        /// Convert this mat to managed rectangular array
        /// </summary>
        /// <returns></returns>
        public TElem[,] ToRectangularArray()
        {
            if (Rows == 0 || Cols == 0)
                return new TElem[0, 0];
            TElem[,] arr = new TElem[Rows, Cols];
            //GetArray(0, 0, arr);

            var methodInfo = typeof(Mat).GetMethod(
                "GetArray",
                BindingFlags.Public | BindingFlags.Instance,
                null,
                new[] { typeof(int), typeof(int), arr.GetType() },
                null);
            if (methodInfo == null)
                throw new NotSupportedException($"Invalid Mat type {typeof(TElem)}");
            methodInfo.Invoke(this, new object[] { 0, 0, arr });

            return arr;
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
            using (Mat result = base.Clone())
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
            Mat result = base.Reshape(0, rows);
            return Wrap(result);
        }

        /// <summary>
        /// Changes the shape of a 2D matrix without copying the data.
        /// </summary>
        /// <param name="newDims">New number of rows. If the parameter is 0, the number of rows remains the same.</param>
        /// <returns></returns>
        public Mat<TElem> Reshape(params int[] newDims)
        {
            Mat result = base.Reshape(0, newDims);
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
            using (Mat result = base.T())
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
            Mat result = base.SubMat(rowStart, rowEnd, colStart, colEnd);
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
            Mat result = base.SubMat(ranges);
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
                Mat result = base[rowStart, rowEnd, colStart, colEnd];
                return Wrap(result);
            }
            set
            {
                base[rowStart, rowEnd, colStart, colEnd] = value;
            }
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
                Mat result = base[rowRange, colRange];
                return Wrap(result);
            }
            set
            {
                base[rowRange, colRange] = value;
            }
        }

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="roi">Extracted submatrix specified as a rectangle.</param>
        /// <returns></returns>
        public new Mat<TElem> this[Rect roi]
        {
            get
            {
                Mat result = base[roi];
                return Wrap(result);
            }
            set
            {
                base[roi] = value;
            }
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
                Mat result = base[ranges];
                return Wrap(result);
            }
            set
            {
                base[ranges] = value;
            }
        }
        #endregion

        #endregion

        #region ICollection<T>

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element(s)</param>
        public void Add(TElem value)
        {
            ThrowIfDisposed();

            var methodInfo = typeof(AddFunctions).GetMethod(
                "Run",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new[] { typeof(IntPtr), typeof(TElem) },
                null);
            if (methodInfo == null)
                throw new NotSupportedException($"Invalid argument type {typeof(TElem)}");
            methodInfo.Invoke(this, new object[] { ptr, value });

            GC.KeepAlive(this);
        }

        private static class AddFunctions
        {
            public static void Run(IntPtr ptr, byte v) => NativeMethods.core_Mat_push_back_uchar(ptr, v);
            public static void Run(IntPtr ptr, sbyte v) => NativeMethods.core_Mat_push_back_char(ptr, v);
            public static void Run(IntPtr ptr, ushort v) => NativeMethods.core_Mat_push_back_ushort(ptr, v);
            public static void Run(IntPtr ptr, short v) => NativeMethods.core_Mat_push_back_short(ptr, v);
            public static void Run(IntPtr ptr, int v) => NativeMethods.core_Mat_push_back_int(ptr, v);
            public static void Run(IntPtr ptr, float v) => NativeMethods.core_Mat_push_back_float(ptr, v);
            public static void Run(IntPtr ptr, double v) => NativeMethods.core_Mat_push_back_double(ptr, v);
            public static void Run(IntPtr ptr, Vec2b v) => NativeMethods.core_Mat_push_back_Vec2b(ptr, v);
            public static void Run(IntPtr ptr, Vec3b v) => NativeMethods.core_Mat_push_back_Vec3b(ptr, v);
            public static void Run(IntPtr ptr, Vec4b v) => NativeMethods.core_Mat_push_back_Vec4b(ptr, v);
            public static void Run(IntPtr ptr, Vec6b v) => NativeMethods.core_Mat_push_back_Vec6b(ptr, v);
            public static void Run(IntPtr ptr, Vec2w v) => NativeMethods.core_Mat_push_back_Vec2w(ptr, v);
            public static void Run(IntPtr ptr, Vec3w v) => NativeMethods.core_Mat_push_back_Vec3w(ptr, v);
            public static void Run(IntPtr ptr, Vec4w v) => NativeMethods.core_Mat_push_back_Vec4w(ptr, v);
            public static void Run(IntPtr ptr, Vec6w v) => NativeMethods.core_Mat_push_back_Vec6w(ptr, v);
            public static void Run(IntPtr ptr, Vec2s v) => NativeMethods.core_Mat_push_back_Vec2s(ptr, v);
            public static void Run(IntPtr ptr, Vec3s v) => NativeMethods.core_Mat_push_back_Vec3s(ptr, v);
            public static void Run(IntPtr ptr, Vec4s v) => NativeMethods.core_Mat_push_back_Vec4s(ptr, v);
            public static void Run(IntPtr ptr, Vec6s v) => NativeMethods.core_Mat_push_back_Vec6s(ptr, v);
            public static void Run(IntPtr ptr, Vec2i v) => NativeMethods.core_Mat_push_back_Vec2i(ptr, v);
            public static void Run(IntPtr ptr, Vec3i v) => NativeMethods.core_Mat_push_back_Vec3i(ptr, v);
            public static void Run(IntPtr ptr, Vec4i v) => NativeMethods.core_Mat_push_back_Vec4i(ptr, v);
            public static void Run(IntPtr ptr, Vec6i v) => NativeMethods.core_Mat_push_back_Vec6i(ptr, v);
            public static void Run(IntPtr ptr, Vec2f v) => NativeMethods.core_Mat_push_back_Vec2f(ptr, v);
            public static void Run(IntPtr ptr, Vec3f v) => NativeMethods.core_Mat_push_back_Vec3f(ptr, v);
            public static void Run(IntPtr ptr, Vec4f v) => NativeMethods.core_Mat_push_back_Vec4f(ptr, v);
            public static void Run(IntPtr ptr, Vec6f v) => NativeMethods.core_Mat_push_back_Vec6f(ptr, v);
            public static void Run(IntPtr ptr, Vec2d v) => NativeMethods.core_Mat_push_back_Vec2d(ptr, v);
            public static void Run(IntPtr ptr, Vec3d v) => NativeMethods.core_Mat_push_back_Vec3d(ptr, v);
            public static void Run(IntPtr ptr, Vec4d v) => NativeMethods.core_Mat_push_back_Vec4d(ptr, v);
            public static void Run(IntPtr ptr, Vec6d v) => NativeMethods.core_Mat_push_back_Vec6d(ptr, v);
            public static void Run(IntPtr ptr, Point v) => NativeMethods.core_Mat_push_back_Point(ptr, v);
            public static void Run(IntPtr ptr, Point2d v) => NativeMethods.core_Mat_push_back_Point2d(ptr, v);
            public static void Run(IntPtr ptr, Point2f v) => NativeMethods.core_Mat_push_back_Point2f(ptr, v);
            public static void Run(IntPtr ptr, Point3i v) => NativeMethods.core_Mat_push_back_Point3i(ptr, v);
            public static void Run(IntPtr ptr, Point3d v) => NativeMethods.core_Mat_push_back_Point3d(ptr, v);
            public static void Run(IntPtr ptr, Point3f v) => NativeMethods.core_Mat_push_back_Point3f(ptr, v);
            public static void Run(IntPtr ptr, Size v) => NativeMethods.core_Mat_push_back_Size(ptr, v);
            public static void Run(IntPtr ptr, Size2f v) => NativeMethods.core_Mat_push_back_Size2f(ptr, v);
            public static void Run(IntPtr ptr, Rect v) => NativeMethods.core_Mat_push_back_Rect(ptr, v);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the ICollection&lt;T&gt;.
        /// </summary>
        /// <param name="item">The object to remove from the ICollection&lt;T&gt;.</param>
        /// <returns> true if item was successfully removed from the ICollection&lt;T&gt; otherwise, false. 
        /// This method also returns false if item is not found in the original ICollection&lt;T&gt;. </returns>
        public bool Remove(TElem item)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Determines whether the ICollection&lt;T&gt; contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the ICollection&lt;T&gt;.</param>
        /// <returns> true if item is found in the ICollection&lt;T&gt; otherwise, false.</returns>
        public bool Contains(TElem item)
        {
            return IndexOf(item) >= 0;
        }

        /// <summary>
        /// Determines the index of a specific item in the list.
        /// </summary>
        /// <param name="item">The object to locate in the list. </param>
        /// <returns>The index of value if found in the list; otherwise, -1.</returns>
        public int IndexOf(TElem item)
        {
            TElem[] array = ToArray();
            return Array.IndexOf(array, item);
        }

        /// <summary>
        /// Removes all items from the ICollection&lt;T&gt;.
        /// </summary>
        public void Clear()
        {
            ThrowIfDisposed();
            NativeMethods.core_Mat_pop_back(ptr, new IntPtr(Total()));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Copies the elements of the ICollection&lt;T&gt; to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from ICollection&lt;T&gt;. 
        /// The Array must have zero-based indexing. </param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(TElem[] array, int arrayIndex)
        {
            ThrowIfDisposed();

            if (array == null)
                throw new ArgumentNullException(nameof(array));
            TElem[] result = ToArray();
            if (array.Length > result.Length + arrayIndex)
                throw new ArgumentException("Too short array.Length");
            Array.Copy(result, 0, array, arrayIndex, result.Length);
        }

        /// <summary>
        /// Returns the total number of matrix elements (Mat.total)
        /// </summary>
        /// <returns>Total number of list(Mat) elements</returns>
        public int Count
        {
            get
            {
                ThrowIfDisposed();
                var res = (int)NativeMethods.core_Mat_total(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the IList is read-only.
        /// </summary>
        /// <returns></returns>
        public bool IsReadOnly => false;

        #endregion
    }
}
