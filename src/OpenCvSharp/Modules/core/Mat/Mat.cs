﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// OpenCV C++ n-dimensional dense array class (cv::Mat)
    /// </summary>
    public partial class Mat : DisposableCvObject
    {
        #region Static Constructor 

        /// <summary>
        /// typeof(T) -> MatType
        /// </summary>
        protected static readonly Dictionary<Type, MatType> TypeMap;

        /// <summary>
        /// /
        /// </summary>
        static Mat()
        {
            TypeMap = new Dictionary<Type, MatType>
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

        #endregion

        #region Init & Disposal

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
        {
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
        /// Creates empty Mat
        /// </summary>
#endif
        public Mat()
        {
            ptr = NativeMethods.core_Mat_new1();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="m"></param>
        protected Mat(Mat m)
        {
            ptr = NativeMethods.core_Mat_new12(m.ptr);
        }

#if LANG_JP
/// <summary>
/// 画像ファイルから読み込んで初期化 (cv::imread)
/// </summary>
/// <param name="fileName">読み込まれる画像ファイル名</param>
/// <param name="flags">画像読み込みフラグ.</param>
#else
        /// <summary>
        /// Loads an image from a file. (cv::imread)
        /// </summary>
        /// <param name="fileName">Name of file to be loaded.</param>
        /// <param name="flags">Specifies color type of the loaded image</param>
#endif
        public Mat(string fileName, ImreadModes flags = ImreadModes.Color)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));

            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);

            ptr = NativeMethods.imgcodecs_imread(fileName, (int) flags);
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
        public Mat(int rows, int cols, MatType type)
        {
            ptr = NativeMethods.core_Mat_new2(rows, cols, type);
        }

#if LANG_JP
/// <summary>
/// 指定したサイズ・型の2次元の行列として初期化
/// </summary>
/// <param name="size">2次元配列のサイズ： Size(cols, rows) ． Size コンストラクタでは，行数と列数が逆順になっていることに注意してください．</param>
/// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
/// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
#else
        /// <summary>
        /// constructs 2D matrix of the specified size and type
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) . In the Size() constructor, 
        /// the number of rows and the number of columns go in the reverse order.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType.CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
#endif
        public Mat(Size size, MatType type)
        {
            ptr = NativeMethods.core_Mat_new2(size.Height, size.Width, type);
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
        /// constructs 2D matrix and fills it with the specified Scalar value.
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
#endif
        public Mat(int rows, int cols, MatType type, Scalar s)
        {
            ptr = NativeMethods.core_Mat_new3(rows, cols, type, s);
        }

#if LANG_JP
/// <summary>
/// 指定したサイズ・型の2次元の行列で、要素をスカラー値で埋めて初期化
/// </summary>
/// <param name="size"> 2 次元配列のサイズ： Size(cols, rows) ． Size() コンストラクタでは，行数と列数が逆順になっていることに注意してください．</param>
/// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
/// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
/// <param name="s">各行列要素を初期化するオプション値．初期化の後ですべての行列要素を特定の値にセットするには，
/// コンストラクタの後で，SetTo(Scalar value) メソッドを利用してください．</param>
#else
        /// <summary>
        /// constructs 2D matrix and fills it with the specified Scalar value.
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) . In the Size() constructor, 
        /// the number of rows and the number of columns go in the reverse order.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
#endif
        public Mat(Size size, MatType type, Scalar s)
        {
            ptr = NativeMethods.core_Mat_new3(size.Height, size.Width, type, s);
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
        public Mat(Mat m, Range rowRange, Range? colRange = null)
        {
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (colRange.HasValue)
                ptr = NativeMethods.core_Mat_new4(m.ptr, rowRange, colRange.Value);
            else
                ptr = NativeMethods.core_Mat_new5(m.ptr, rowRange);
            GC.KeepAlive(m);
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
        public Mat(Mat m, params Range[] ranges)
        {
            if (ranges == null)
                throw new ArgumentNullException(nameof(ranges));
            if (ranges.Length == 0)
                throw new ArgumentException("empty ranges", nameof(ranges));

            ptr = NativeMethods.core_Mat_new6(m.ptr, ranges);
            GC.KeepAlive(m);
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
        public Mat(Mat m, Rect roi)
        {
            ptr = NativeMethods.core_Mat_new7(m.ptr, roi);
            GC.KeepAlive(m);
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
        /// The external data is not automatically de-allocated, so you should take care of it.</param>
        /// <param name="step">Number of bytes each matrix row occupies. The value should include the padding bytes at the end of each row, if any.
        /// If the parameter is missing (set to AUTO_STEP ), no padding is assumed and the actual step is calculated as cols*elemSize() .</param>
#endif
        public Mat(int rows, int cols, MatType type, IntPtr data, long step = 0)
        {
            ptr = NativeMethods.core_Mat_new8(rows, cols, type, data, new IntPtr(step));
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
        /// The external data is not automatically de-allocated, so you should take care of it.</param>
        /// <param name="step">Number of bytes each matrix row occupies. The value should include the padding bytes at the end of each row, if any.
        /// If the parameter is missing (set to AUTO_STEP ), no padding is assumed and the actual step is calculated as cols*elemSize() .</param>
#endif
        public Mat(int rows, int cols, MatType type, Array data, long step = 0)
        {
            var handle = AllocGCHandle(data);
            ptr = NativeMethods.core_Mat_new8(rows, cols, type,
                handle.AddrOfPinnedObject(), new IntPtr(step));
        }

#if LANG_JP
/// <summary>
/// 利用者が別に確保したデータで初期化
/// </summary>
/// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
/// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
/// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
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
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
        /// <param name="data">Pointer to the user data. Matrix constructors that take data and step parameters do not allocate matrix data. 
        /// Instead, they just initialize the matrix header that points to the specified data, which means that no data is copied. 
        /// This operation is very efficient and can be used to process external data using OpenCV functions. 
        /// The external data is not automatically de-allocated, so you should take care of it.</param>
        /// <param name="steps">Array of ndims-1 steps in case of a multi-dimensional array (the last step is always set to the element size). 
        /// If not specified, the matrix is assumed to be continuous.</param>
#endif
        public Mat(IEnumerable<int> sizes, MatType type, IntPtr data, IEnumerable<long>? steps = null)
        {
            if (sizes == null)
                throw new ArgumentNullException(nameof(sizes));
            if (data == IntPtr.Zero)
                throw new ArgumentNullException(nameof(data));
            var sizesArray = EnumerableEx.ToArray(sizes);
            if (steps == null)
            {
                ptr = NativeMethods.core_Mat_new9(sizesArray.Length, sizesArray, type, data, IntPtr.Zero);
            }
            else
            {
                var stepsArray = EnumerableEx.SelectToArray(steps, s => new IntPtr(s));
                ptr = NativeMethods.core_Mat_new9(sizesArray.Length, sizesArray, type, data, stepsArray);
            }
        }

#if LANG_JP
/// <summary>
/// 利用者が別に確保したデータで初期化
/// </summary>
/// <param name="sizes">n-次元配列の形状を表す，整数型の配列．</param>
/// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
/// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
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
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
        /// <param name="data">Pointer to the user data. Matrix constructors that take data and step parameters do not allocate matrix data. 
        /// Instead, they just initialize the matrix header that points to the specified data, which means that no data is copied. 
        /// This operation is very efficient and can be used to process external data using OpenCV functions. 
        /// The external data is not automatically de-allocated, so you should take care of it.</param>
        /// <param name="steps">Array of ndims-1 steps in case of a multi-dimensional array (the last step is always set to the element size). 
        /// If not specified, the matrix is assumed to be continuous.</param>
#endif
        public Mat(IEnumerable<int> sizes, MatType type, Array data, IEnumerable<long>? steps = null)
        {
            if (sizes == null)
                throw new ArgumentNullException(nameof(sizes));
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var handle = AllocGCHandle(data);
            var sizesArray = EnumerableEx.ToArray(sizes);
            if (steps == null)
            {
                ptr = NativeMethods.core_Mat_new9(sizesArray.Length, sizesArray,
                    type, handle.AddrOfPinnedObject(), IntPtr.Zero);
            }
            else
            {
                var stepsArray = EnumerableEx.SelectToArray(steps, s => new IntPtr(s));
                ptr = NativeMethods.core_Mat_new9(sizesArray.Length, sizesArray,
                    type, handle.AddrOfPinnedObject(), stepsArray);
            }
        }

#if LANG_JP
/// <summary>
/// N次元行列として初期化
/// </summary>
/// <param name="sizes">n-次元配列の形状を表す，整数型の配列．</param>
/// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
/// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
#else
        /// <summary>
        /// constructs n-dimensional matrix
        /// </summary>
        /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
#endif
        public Mat(IEnumerable<int> sizes, MatType type)
        {
            if (sizes == null)
                throw new ArgumentNullException(nameof(sizes));

            var sizesArray = EnumerableEx.ToArray(sizes);
            ptr = NativeMethods.core_Mat_new10(sizesArray.Length, sizesArray, type);
        }

#if LANG_JP
/// <summary>
/// N次元行列として初期化
/// </summary>
/// <param name="sizes">n-次元配列の形状を表す，整数型の配列．</param>
/// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
/// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
/// <param name="s">各行列要素を初期化するオプション値．初期化の後ですべての行列要素を特定の値にセットするには，
/// コンストラクタの後で，SetTo(Scalar value) メソッドを利用してください．</param>
#else
        /// <summary>
        /// constructs n-dimensional matrix
        /// </summary>
        /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
#endif
        public Mat(IEnumerable<int> sizes, MatType type, Scalar s)
        {
            if (sizes == null)
                throw new ArgumentNullException(nameof(sizes));
            var sizesArray = EnumerableEx.ToArray(sizes);
            ptr = NativeMethods.core_Mat_new11(sizesArray.Length, sizesArray, type, s);
        }

#if LANG_JP
/// <summary>
/// リソースの解放
/// </summary>
#else
        /// <summary>
        /// Releases the resources
        /// </summary>
#endif
        public void Release()
        {
            Dispose();
        }

        /// <inheritdoc />
        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            if (ptr != IntPtr.Zero)
                NativeMethods.core_Mat_delete(ptr);
            base.DisposeUnmanaged();
        }

        #region Static Initializers

#if LANG_JP
        /// <summary>
        /// System.IO.StreamのインスタンスからMatを生成する
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the Mat instance from System.IO.Stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#endif
        public static Mat FromStream(Stream stream, ImreadModes mode)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (stream.Length > int.MaxValue)
                throw new ArgumentException("Not supported stream (too long)");

            var buf = new byte[stream.Length];
            var currentPosition = stream.Position;
            try
            {
                stream.Position = 0;
                var count = 0;
                while (count < stream.Length)
                {
                    var bytesRead = stream.Read(buf, count, buf.Length - count);
                    if (bytesRead == 0)
                    {
                        break;
                    }

                    count += bytesRead;
                }
            }
            finally
            {
                stream.Position = currentPosition;
            }

            return FromImageData(buf, mode);
        }

#if LANG_JP
/// <summary>
/// 画像データ(JPEG等の画像をメモリに展開したもの)からMatを生成する (cv::decode)
/// </summary>
/// <param name="imageBytes"></param>
/// <param name="mode"></param>
/// <returns></returns>
#else
        /// <summary>
        /// Creates the Mat instance from image data (using cv::decode) 
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#endif
        public static Mat ImDecode(byte[] imageBytes, ImreadModes mode = ImreadModes.Color)
        {
            if (imageBytes == null)
                throw new ArgumentNullException(nameof(imageBytes));
            return Cv2.ImDecode(imageBytes, mode);
        }

#if LANG_JP
/// <summary>
/// 画像データ(JPEG等の画像をメモリに展開したもの)からMatを生成する (cv::decode)
/// </summary>
/// <param name="imageBytes"></param>
/// <param name="mode"></param>
/// <returns></returns>
#else
        /// <summary>
        /// Creates the Mat instance from image data (using cv::decode) 
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#endif
        public static Mat FromImageData(byte[] imageBytes, ImreadModes mode = ImreadModes.Color)
        {
            return ImDecode(imageBytes, mode);
        }

        #endregion

        #endregion

        #region Static

        /// <summary>
        /// sizeof(cv::Mat)
        /// </summary>
        public static readonly int SizeOf = (int) NativeMethods.core_Mat_sizeof();

        #region Diag

        /// <summary>
        /// Extracts a diagonal from a matrix, or creates a diagonal matrix.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Mat Diag(Mat d)
        {
            var retPtr = NativeMethods.core_Mat_diag3(d.CvPtr);
            GC.KeepAlive(d);
            var retVal = new Mat(retPtr);
            return retVal;
        }

        #endregion

        #region Eye

        /// <summary>
        /// Returns an identity matrix of the specified size and type.
        /// </summary>
        /// <param name="size">Alternative to the matrix size specification Size(cols, rows) .</param>
        /// <param name="type">Created matrix type.</param>
        /// <returns></returns>
        public static MatExpr Eye(Size size, MatType type)
        {
            return Eye(size.Height, size.Width, type);
        }

        /// <summary>
        /// Returns an identity matrix of the specified size and type.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="cols">Number of columns.</param>
        /// <param name="type">Created matrix type.</param>
        /// <returns></returns>
        public static MatExpr Eye(int rows, int cols, MatType type)
        {
            var retPtr = NativeMethods.core_Mat_eye(rows, cols, type);
            var retVal = new MatExpr(retPtr);
            return retVal;
        }

        #endregion

        #region Ones

        /// <summary>
        /// Returns an array of all 1’s of the specified size and type.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="cols">Number of columns.</param>
        /// <param name="type">Created matrix type.</param>
        /// <returns></returns>
        public static MatExpr Ones(int rows, int cols, MatType type)
        {
            var retPtr = NativeMethods.core_Mat_ones1(rows, cols, type);
            var retVal = new MatExpr(retPtr);
            return retVal;
        }

        /// <summary>
        /// Returns an array of all 1’s of the specified size and type.
        /// </summary>
        /// <param name="size">Alternative to the matrix size specification Size(cols, rows) .</param>
        /// <param name="type">Created matrix type.</param>
        /// <returns></returns>
        public static MatExpr Ones(Size size, MatType type)
        {
            return Ones(size.Height, size.Width, type);
        }

        /// <summary>
        /// Returns an array of all 1’s of the specified size and type.
        /// </summary>
        /// <param name="type">Created matrix type.</param>
        /// <param name="sizes">Array of integers specifying the array shape.</param>
        /// <returns></returns>
        public static MatExpr Ones(MatType type, params int[] sizes)
        {
            if (sizes == null)
                throw new ArgumentNullException(nameof(sizes));

            var retPtr = NativeMethods.core_Mat_ones2(sizes.Length, sizes, type);
            var retVal = new MatExpr(retPtr);
            return retVal;
        }

        #endregion

        #region Zeros

        /// <summary>
        /// Returns a zero array of the specified size and type.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="cols">Number of columns.</param>
        /// <param name="type">Created matrix type.</param>
        /// <returns></returns>
        public static MatExpr Zeros(int rows, int cols, MatType type)
        {
            var retPtr = NativeMethods.core_Mat_zeros1(rows, cols, type);
            var retVal = new MatExpr(retPtr);
            return retVal;
        }

        /// <summary>
        /// Returns a zero array of the specified size and type.
        /// </summary>
        /// <param name="size">Alternative to the matrix size specification Size(cols, rows) .</param>
        /// <param name="type">Created matrix type.</param>
        /// <returns></returns>
        public static MatExpr Zeros(Size size, MatType type)
        {
            return Zeros(size.Height, size.Width, type);
        }

        /// <summary>
        /// Returns a zero array of the specified size and type.
        /// </summary>
        /// <param name="type">Created matrix type.</param>
        /// <param name="cols"></param>
        /// <param name="sizes"></param>
        /// <returns></returns>
        public static MatExpr Zeros(MatType type, int cols, params int[] sizes)
        {
            if (sizes == null)
                throw new ArgumentNullException(nameof(sizes));

            var retPtr = NativeMethods.core_Mat_zeros2(sizes.Length, sizes, type);
            var retVal = new MatExpr(retPtr);
            return retVal;
        }

        #endregion

        #endregion

        #region Operators

        #region Unary

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static MatExpr operator -(Mat mat)
        {
            var expr = NativeMethods.core_Mat_operatorUnaryMinus(mat.CvPtr);
            GC.KeepAlive(mat);
            return new MatExpr(expr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static Mat operator +(Mat mat)
        {
            return mat;
        }

        #endregion

        #region Binary

        #region +

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator +(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();

            var retPtr = NativeMethods.core_Mat_operatorAdd_MatMat(a.CvPtr, b.CvPtr);
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator +(Mat a, Scalar s)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();

            var retPtr = NativeMethods.core_Mat_operatorAdd_MatScalar(a.CvPtr, s);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator +(Scalar s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorAdd_ScalarMat(s, a.CvPtr);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        #endregion

        #region -

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator -(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorSubtract_MatMat(a.CvPtr, b.CvPtr);
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator -(Mat a, Scalar s)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorSubtract_MatScalar(a.CvPtr, s);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator -(Scalar s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorSubtract_ScalarMat(s, a.CvPtr);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        #endregion

        #region *

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator *(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorMultiply_MatMat(a.CvPtr, b.CvPtr);
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator *(Mat a, double s)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorMultiply_MatDouble(a.CvPtr, s);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator *(double s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorMultiply_DoubleMat(s, a.CvPtr);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        #endregion

        #region /

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator /(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorDivide_MatMat(a.CvPtr, b.CvPtr);
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator /(Mat a, double s)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorDivide_MatDouble(a.CvPtr, s);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator /(double s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorDivide_DoubleMat(s, a.CvPtr);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        #endregion

        #region And

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator &(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorAnd_MatMat(a.CvPtr, b.CvPtr);
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator &(Mat a, double s)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorAnd_MatDouble(a.CvPtr, s);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator &(double s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorAnd_DoubleMat(s, a.CvPtr);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        #endregion

        #region Or

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator |(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorOr_MatMat(a.CvPtr, b.CvPtr);
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator |(Mat a, double s)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorOr_MatDouble(a.CvPtr, s);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator |(double s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorOr_DoubleMat(s, a.CvPtr);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        #endregion

        #region Xor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MatExpr operator ^(Mat a, Mat b)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorXor_MatMat(a.CvPtr, b.CvPtr);
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MatExpr operator ^(Mat a, double s)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorXor_MatDouble(a.CvPtr, s);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MatExpr operator ^(double s, Mat a)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            a.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorXor_DoubleMat(s, a.CvPtr);
            GC.KeepAlive(a);
            return new MatExpr(retPtr);
        }

        #endregion

        #region Not

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static MatExpr operator ~(Mat m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            m.ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_operatorNot(m.CvPtr);
            GC.KeepAlive(m);
            return new MatExpr(retPtr);
        }

        #endregion

        #endregion

        #endregion

        #region Comparison

        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public MatExpr LessThan(Mat m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            var expr = NativeMethods.core_Mat_operatorLT_MatMat(ptr, m.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            var ret = new MatExpr(expr);
            return ret;
        }

        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr LessThan(double d)
        {
            var expr = NativeMethods.core_Mat_operatorLT_MatDouble(ptr, d);
            GC.KeepAlive(this);
            var ret = new MatExpr(expr);
            return ret;
        }

        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public MatExpr LessThanOrEqual(Mat m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            var expr = NativeMethods.core_Mat_operatorLE_MatMat(ptr, m.CvPtr);
            GC.KeepAlive(this);
            var ret = new MatExpr(expr);

            GC.KeepAlive(m);
            return ret;
        }

        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr LessThanOrEqual(double d)
        {
            var expr = NativeMethods.core_Mat_operatorLE_MatDouble(ptr, d);
            GC.KeepAlive(this);
            var ret = new MatExpr(expr);

            return ret;
        }

        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public MatExpr Equals(Mat m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            var expr = NativeMethods.core_Mat_operatorEQ_MatMat(ptr, m.CvPtr);
            GC.KeepAlive(this);
            var ret = new MatExpr(expr);

            GC.KeepAlive(m);
            return ret;
        }

        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr Equals(double d)
        {
            var expr = NativeMethods.core_Mat_operatorEQ_MatDouble(ptr, d);
            GC.KeepAlive(this);
            var ret = new MatExpr(expr);

            return ret;
        }

        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public MatExpr NotEquals(Mat m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            var expr = NativeMethods.core_Mat_operatorNE_MatMat(ptr, m.CvPtr);
            GC.KeepAlive(this);
            var ret = new MatExpr(expr);

            GC.KeepAlive(m);
            return ret;
        }

        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr NotEquals(double d)
        {
            var expr = NativeMethods.core_Mat_operatorNE_MatDouble(ptr, d);
            GC.KeepAlive(this);
            var ret = new MatExpr(expr);

            return ret;
        }

        /// <summary>
        /// operator &gt;
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public MatExpr GreaterThan(Mat m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            var expr = NativeMethods.core_Mat_operatorGT_MatMat(ptr, m.CvPtr);
            GC.KeepAlive(this);
            var ret = new MatExpr(expr);

            GC.KeepAlive(m);
            return ret;
        }

        /// <summary>
        /// operator &gt;
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr GreaterThan(double d)
        {
            var expr = NativeMethods.core_Mat_operatorGT_MatDouble(ptr, d);
            GC.KeepAlive(this);
            var ret = new MatExpr(expr);

            return ret;
        }

        /// <summary>
        /// operator &gt;=
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public MatExpr GreaterThanOrEqual(Mat m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            var expr = NativeMethods.core_Mat_operatorGE_MatMat(ptr, m.CvPtr);
            GC.KeepAlive(this);
            var ret = new MatExpr(expr);

            GC.KeepAlive(m);
            return ret;
        }

        /// <summary>
        /// operator &gt;=
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr GreaterThanOrEqual(double d)
        {
            var expr = NativeMethods.core_Mat_operatorGE_MatDouble(ptr, d);
            GC.KeepAlive(this);
            var ret = new MatExpr(expr);

            return ret;
        }

        #endregion

        #region Public Methods

        #region Mat Indexers

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="rowStart">Start row of the extracted submatrix. The upper boundary is not included.</param>
        /// <param name="rowEnd">End row of the extracted submatrix. The upper boundary is not included.</param>
        /// <param name="colStart">Start column of the extracted submatrix. The upper boundary is not included.</param>
        /// <param name="colEnd">End column of the extracted submatrix. The upper boundary is not included.</param>
        /// <returns></returns>
        public Mat this[int rowStart, int rowEnd, int colStart, int colEnd]
        {
            get => SubMat(rowStart, rowEnd, colStart, colEnd);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                value.ThrowIfDisposed();
                //if (Type() != value.Type())
                //    throw new ArgumentException("Mat type mismatch");
                if (Dims() != value.Dims())
                    throw new ArgumentException("Dimension mismatch");

                var sub = SubMat(rowStart, rowEnd, colStart, colEnd);
                if (sub.Size() != value.Size())
                    throw new ArgumentException("Specified ROI != mat.Size()");
                value.CopyTo(sub);
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
        public Mat this[Range rowRange, Range colRange]
        {
            get => SubMat(rowRange, colRange);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                value.ThrowIfDisposed();
                //if (Type() != value.Type())
                //    throw new ArgumentException("Mat type mismatch");
                if (Dims() != value.Dims())
                    throw new ArgumentException("Dimension mismatch");

                var sub = SubMat(rowRange, colRange);
                if (sub.Size() != value.Size())
                    throw new ArgumentException("Specified ROI != mat.Size()");
                value.CopyTo(sub);
            }
        }

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="roi">Extracted submatrix specified as a rectangle.</param>
        /// <returns></returns>
        public Mat this[Rect roi]
        {
            get => SubMat(roi);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                value.ThrowIfDisposed();
                //if (Type() != value.Type())
                //    throw new ArgumentException("Mat type mismatch");
                if (Dims() != value.Dims())
                    throw new ArgumentException("Dimension mismatch");

                if (roi.Size != value.Size())
                    throw new ArgumentException("Specified ROI != mat.Size()");
                var sub = SubMat(roi);
                value.CopyTo(sub);
            }
        }

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="ranges">Array of selected ranges along each array dimension.</param>
        /// <returns></returns>
        public Mat this[params Range[] ranges]
        {
            get => SubMat(ranges);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                value.ThrowIfDisposed();
                //if (Type() != value.Type())
                //    throw new ArgumentException("Mat type mismatch");

                var sub = SubMat(ranges);

                var dims = Dims();
                if (dims != value.Dims())
                    throw new ArgumentException("Dimension mismatch");
                for (var i = 0; i < dims; i++)
                {
                    if (sub.Size(i) != value.Size(i))
                        throw new ArgumentException("Size mismatch at dimension " + i);
                }

                value.CopyTo(sub);
            }
        }

        #endregion

        #region MatExpr Indexers

        #region SubMat

        /// <summary>
        /// 
        /// </summary>
        public class MatExprIndexer : MatExprRangeIndexer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="parent"></param>
            protected internal MatExprIndexer(Mat parent)
                : base(parent)
            {
            }

            /// <summary>
            /// Extracts a rectangular submatrix.
            /// </summary>
            /// <param name="rowStart">Start row of the extracted submatrix. The upper boundary is not included.</param>
            /// <param name="rowEnd">End row of the extracted submatrix. The upper boundary is not included.</param>
            /// <param name="colStart">Start column of the extracted submatrix. The upper boundary is not included.</param>
            /// <param name="colEnd">End column of the extracted submatrix. The upper boundary is not included.</param>
            /// <returns></returns>
            public override MatExpr this[int rowStart, int rowEnd, int colStart, int colEnd]
            {
                get => Parent.SubMat(rowStart, rowEnd, colStart, colEnd);
                set
                {
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    using var submat = Parent.SubMat(rowStart, rowEnd, colStart, colEnd);
                    NativeMethods.core_Mat_assignment_FromMatExpr(submat.CvPtr, value.CvPtr);
                    GC.KeepAlive(submat);
                    GC.KeepAlive(value);
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
            public override MatExpr this[Range rowRange, Range colRange]
            {
                get => Parent.SubMat(rowRange, colRange);
                set
                {
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    using var submat = Parent.SubMat(rowRange, colRange);
                    NativeMethods.core_Mat_assignment_FromMatExpr(submat.CvPtr, value.CvPtr);
                    GC.KeepAlive(submat);
                    GC.KeepAlive(value);
                }
            }

            /// <summary>
            /// Extracts a rectangular submatrix.
            /// </summary>
            /// <param name="roi">Extracted submatrix specified as a rectangle.</param>
            /// <returns></returns>
            public override MatExpr this[Rect roi]
            {
                get => Parent.SubMat(roi);
                set
                {
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    using var submat = Parent.SubMat(roi);
                    NativeMethods.core_Mat_assignment_FromMatExpr(submat.CvPtr, value.CvPtr);
                    GC.KeepAlive(submat);
                    GC.KeepAlive(value);
                }
            }

            /// <summary>
            /// Extracts a rectangular submatrix.
            /// </summary>
            /// <param name="ranges">Array of selected ranges along each array dimension.</param>
            /// <returns></returns>
            public override MatExpr this[params Range[] ranges]
            {
                get => Parent.SubMat(ranges);
                set
                {
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    using var submat = Parent.SubMat(ranges);
                    NativeMethods.core_Mat_assignment_FromMatExpr(submat.CvPtr, value.CvPtr);
                    GC.KeepAlive(submat);
                    GC.KeepAlive(value);
                }
            }
        }

        /// <summary>
        /// Indexer to access partial Mat as MatExpr
        /// </summary>
        /// <returns></returns>
        public MatExprIndexer Expr
        {
            get { return matExprIndexer ??= new MatExprIndexer(this); }
        }

        private MatExprIndexer? matExprIndexer;

        #endregion

        #region ColExpr

        /// <summary>
        /// Mat column's indexer object
        /// </summary>
        public class ColExprIndexer : MatRowColExprIndexer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="parent"></param>
            protected internal ColExprIndexer(Mat parent)
                : base(parent)
            {
            }

            /// <summary>
            /// Creates a matrix header for the specified matrix column.
            /// </summary>
            /// <param name="x">A 0-based column index.</param>
            /// <returns></returns>
            public override MatExpr this[int x]
            {
                get
                {
                    Parent.ThrowIfDisposed();
                    var matExprPtr = NativeMethods.core_Mat_col_toMatExpr(Parent.ptr, x);
                    GC.KeepAlive(this);
                    var matExpr = new MatExpr(matExprPtr);
                    return matExpr;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    Parent.ThrowIfDisposed();
                    var colMatPtr = NativeMethods.core_Mat_col_toMat(Parent.ptr, x);
                    NativeMethods.core_Mat_assignment_FromMatExpr(colMatPtr, value.CvPtr);
                    NativeMethods.core_Mat_delete(colMatPtr);
                    GC.KeepAlive(this);
                    GC.KeepAlive(value);
                }
            }

            /// <summary>
            /// Creates a matrix header for the specified column span.
            /// </summary>
            /// <param name="startCol">An inclusive 0-based start index of the column span.</param>
            /// <param name="endCol">An exclusive 0-based ending index of the column span.</param>
            /// <returns></returns>
            public override MatExpr this[int startCol, int endCol]
            {
                get
                {
                    Parent.ThrowIfDisposed();
                    var matExprPtr = NativeMethods.core_Mat_colRange_toMatExpr(Parent.ptr, startCol, endCol);
                    GC.KeepAlive(this);
                    var matExpr = new MatExpr(matExprPtr);
                    return matExpr;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    Parent.ThrowIfDisposed();
                    var colMatPtr = NativeMethods.core_Mat_colRange_toMat(Parent.ptr, startCol, endCol);
                    GC.KeepAlive(this);
                    NativeMethods.core_Mat_assignment_FromMatExpr(colMatPtr, value.CvPtr);
                    GC.KeepAlive(value);
                    NativeMethods.core_Mat_delete(colMatPtr);
                }
            }
        }

        /// <summary>
        /// Indexer to access Mat column as MatExpr
        /// </summary>
        /// <returns></returns>
        public ColExprIndexer ColExpr
        {
            get { return colExprIndexer ??= new ColExprIndexer(this); }
        }

        private ColExprIndexer? colExprIndexer;

        #endregion

        #region RowExpr

        /// <summary>
        /// Mat row's indexer object
        /// </summary>
        public class RowExprIndexer : MatRowColExprIndexer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="parent"></param>
            protected internal RowExprIndexer(Mat parent)
                : base(parent)
            {
            }

            /// <summary>
            /// Creates a matrix header for the specified matrix row. [Mat::row]
            /// </summary>
            /// <param name="y">A 0-based row index.</param>
            /// <returns></returns>
            public override MatExpr this[int y]
            {
                get
                {
                    Parent.ThrowIfDisposed();
                    var matExprPtr = NativeMethods.core_Mat_row_toMatExpr(Parent.ptr, y);
                    GC.KeepAlive(this);
                    var matExpr = new MatExpr(matExprPtr);
                    return matExpr;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    Parent.ThrowIfDisposed();
                    var rowMatPtr = NativeMethods.core_Mat_row_toMat(Parent.ptr, y);
                    GC.KeepAlive(this);
                    NativeMethods.core_Mat_assignment_FromMatExpr(rowMatPtr, value.CvPtr);
                    GC.KeepAlive(value);
                    NativeMethods.core_Mat_delete(rowMatPtr);
                }
            }

            /// <summary>
            /// Creates a matrix header for the specified row span. (Mat::rowRange)
            /// </summary>
            /// <param name="startRow">An inclusive 0-based start index of the row span.</param>
            /// <param name="endRow">An exclusive 0-based ending index of the row span.</param>
            /// <returns></returns>
            public override MatExpr this[int startRow, int endRow]
            {
                get
                {
                    Parent.ThrowIfDisposed();
                    var matExprPtr = NativeMethods.core_Mat_rowRange_toMatExpr(Parent.ptr, startRow, endRow);
                    GC.KeepAlive(this);
                    var matExpr = new MatExpr(matExprPtr);
                    return matExpr;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    Parent.ThrowIfDisposed();
                    var rowMatPtr = NativeMethods.core_Mat_rowRange_toMat(Parent.ptr, startRow, endRow);
                    GC.KeepAlive(this);
                    NativeMethods.core_Mat_assignment_FromMatExpr(rowMatPtr, value.CvPtr);
                    GC.KeepAlive(value);
                    NativeMethods.core_Mat_delete(rowMatPtr);
                }
            }
        }

        /// <summary>
        /// Indexer to access Mat row as MatExpr
        /// </summary>
        /// <returns></returns>
        public RowExprIndexer RowExpr
        {
            get { return rowExprIndexer ??= new RowExprIndexer(this); }
        }

        private RowExprIndexer? rowExprIndexer;

        #endregion

        #endregion

        #region AdjustROI

        /// <summary>
        /// Adjusts a submatrix size and position within the parent matrix.
        /// </summary>
        /// <param name="dtop">Shift of the top submatrix boundary upwards.</param>
        /// <param name="dbottom">Shift of the bottom submatrix boundary downwards.</param>
        /// <param name="dleft">Shift of the left submatrix boundary to the left.</param>
        /// <param name="dright">Shift of the right submatrix boundary to the right.</param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public Mat AdjustROI(int dtop, int dbottom, int dleft, int dright)
        {
            ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_adjustROI(ptr, dtop, dbottom, dleft, dright);
            GC.KeepAlive(this);
            var retVal = new Mat(retPtr);
            return retVal;
        }

        #endregion

        #region AssignTo

        /// <summary>
        /// Provides a functional form of convertTo.
        /// </summary>
        /// <param name="m">Destination array.</param>
        /// <param name="type">Desired destination array depth (or -1 if it should be the same as the source type).</param>
        public void AssignTo(Mat m, MatType type)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.core_Mat_assignTo2(ptr, m.CvPtr, type);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }

        /// <summary>
        /// Provides a functional form of convertTo.
        /// </summary>
        /// <param name="m">Destination array.</param>
        public void AssignTo(Mat m)
        {
            NativeMethods.core_Mat_assignTo1(ptr, m.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }

        #endregion

        #region Channels

        /// <summary>
        /// Returns the number of matrix channels.
        /// </summary>
        /// <returns></returns>
        public int Channels()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_channels(ptr);
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region CheckVector

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemChannels"></param>
        /// <returns></returns>
        public int CheckVector(int elemChannels)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_checkVector1(ptr, elemChannels);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemChannels"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public int CheckVector(int elemChannels, int depth)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_checkVector2(ptr, elemChannels, depth);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemChannels"></param>
        /// <param name="depth"></param>
        /// <param name="requireContinuous"></param>
        /// <returns></returns>
        public int CheckVector(int elemChannels, int depth, bool requireContinuous)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_checkVector3(
                ptr, elemChannels, depth, requireContinuous ? 1 : 0);
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region Clone

        /// <summary>
        /// Creates a full copy of the matrix.
        /// </summary>
        /// <returns></returns>
        public Mat Clone()
        {
            ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_clone(ptr);
            GC.KeepAlive(this);
            var retVal = new Mat(retPtr);
            return retVal;
        }

        /// <summary>
        /// Returns the partial Mat of the specified Mat
        /// </summary>
        /// <param name="roi"></param>
        /// <returns></returns>
        public Mat Clone(Rect roi)
        {
            using (var part = new Mat(this, roi))
            {
                return part.Clone();
            }
        }

        #endregion

        #region Cols

        /// <summary>
        /// the number of columns or -1 when the array has more than 2 dimensions
        /// </summary>
        /// <returns></returns>
        public int Cols
        {
            get
            {
                //行列データが新たに確保された場合に対応できない。
                //if (colsVal == int.MinValue)
                //{
                //    colsVal = NativeMethods.core_Mat_cols(ptr);
                //}
                //return colsVal;
                var res = NativeMethods.core_Mat_cols(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// the number of columns or -1 when the array has more than 2 dimensions
        /// </summary>
        /// <returns></returns>
        public int Width
        {
            get
            {
                //if (colsVal == int.MinValue)
                //{
                //    colsVal = Cols;
                //}
                //return colsVal;
                var res = NativeMethods.core_Mat_cols(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        //private int colsVal = int.MinValue;

        #endregion

        #region Dims

        /// <summary>
        /// the array dimensionality, >= 2
        /// </summary>
        public int Dims()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_dims(ptr);
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region ConvertTo

        /// <summary>
        /// Converts an array to another data type with optional scaling.
        /// </summary>
        /// <param name="m">output matrix; if it does not have a proper size or type before the operation, it is reallocated.</param>
        /// <param name="rtype">desired output matrix type or, rather, the depth since the number of channels are the same as the input has; 
        /// if rtype is negative, the output matrix will have the same type as the input.</param>
        /// <param name="alpha">optional scale factor.</param>
        /// <param name="beta">optional delta added to the scaled values.</param>
        public void ConvertTo(Mat m, MatType rtype, double alpha = 1, double beta = 0)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.core_Mat_convertTo(ptr, m.CvPtr, rtype, alpha, beta);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }

        #endregion

        #region CopyTo

        /// <summary>
        /// Copies the matrix to another one.
        /// </summary>
        /// <param name="m">Destination matrix. If it does not have a proper size or type before the operation, it is reallocated.</param>
        public void CopyTo(Mat m)
        {
            CopyTo(m, null);
        }

        /// <summary>
        /// Copies the matrix to another one.
        /// </summary>
        /// <param name="m">Destination matrix. If it does not have a proper size or type before the operation, it is reallocated.</param>
        /// <param name="mask">Operation mask. Its non-zero elements indicate which matrix elements need to be copied.</param>
        public void CopyTo(Mat m, Mat? mask)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            var maskPtr = Cv2.ToPtr(mask);
            NativeMethods.core_Mat_copyTo(ptr, m.CvPtr, maskPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            GC.KeepAlive(mask);
        }

        #endregion

        #region Create

        /// <summary>
        /// Allocates new array data if needed.
        /// </summary>
        /// <param name="rows">New number of rows.</param>
        /// <param name="cols">New number of columns.</param>
        /// <param name="type">New matrix type.</param>
        public void Create(int rows, int cols, MatType type)
        {
            ThrowIfDisposed();
            NativeMethods.core_Mat_create1(ptr, rows, cols, type);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Allocates new array data if needed.
        /// </summary>
        /// <param name="size">Alternative new matrix size specification: Size(cols, rows)</param>
        /// <param name="type">New matrix type.</param>
        public void Create(Size size, MatType type)
        {
            Create(size.Height, size.Width, type);
        }

        /// <summary>
        /// Allocates new array data if needed.
        /// </summary>
        /// <param name="sizes">Array of integers specifying a new array shape.</param>
        /// <param name="type">New matrix type.</param>
        public void Create(MatType type, params int[] sizes)
        {
            if (sizes == null)
                throw new ArgumentNullException(nameof(sizes));
            if (sizes.Length < 2)
                throw new ArgumentException("sizes.Length < 2");
            NativeMethods.core_Mat_create2(ptr, sizes.Length, sizes, type);
            GC.KeepAlive(this);
        }

        #endregion

        #region Cross

        /// <summary>
        /// Computes a cross-product of two 3-element vectors.
        /// </summary>
        /// <param name="m">Another cross-product operand.</param>
        /// <returns></returns>
        public Mat Cross(Mat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            var retPtr = NativeMethods.core_Mat_cross(ptr, m.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            var retVal = new Mat(retPtr);
            return retVal;
        }

        #endregion

        #region Data

        /// <summary>
        /// pointer to the data
        /// </summary>
        public IntPtr Data
        {
            get
            {
                unsafe
                {
                    return new IntPtr(DataPointer);
                }
            }
        }

        /// <summary>
        /// unsafe pointer to the data
        /// </summary>
        public unsafe byte* DataPointer
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.core_Mat_data(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// The pointer that is possible to compute a relative sub-array position in the main container array using locateROI()
        /// </summary>
        public IntPtr DataStart
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.core_Mat_datastart(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// The pointer that is possible to compute a relative sub-array position in the main container array using locateROI()
        /// </summary>
        public IntPtr DataEnd
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.core_Mat_dataend(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// The pointer that is possible to compute a relative sub-array position in the main container array using locateROI()
        /// </summary>
        public IntPtr DataLimit
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.core_Mat_datalimit(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        #endregion

        #region Depth

        /// <summary>
        /// Returns the depth of a matrix element.
        /// </summary>
        /// <returns></returns>
        public int Depth()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_depth(ptr);
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region Diag

        /// <summary>
        /// Single-column matrix that forms a diagonal matrix or index of the diagonal, with the following values:
        /// </summary>
        /// <param name="d">Single-column matrix that forms a diagonal matrix or index of the diagonal, with the following values:</param>
        /// <returns></returns>
        public Mat Diag(MatDiagType d = MatDiagType.Main)
        {
            ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_diag2(ptr, (int) d);
            GC.KeepAlive(this);
            var retVal = new Mat(retPtr);
            return retVal;
        }

        #endregion

        #region Dot

        /// <summary>
        /// Computes a dot-product of two vectors.
        /// </summary>
        /// <param name="m">another dot-product operand.</param>
        /// <returns></returns>
        public double Dot(Mat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            var res = NativeMethods.core_Mat_dot(ptr, m.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            return res;
        }

        #endregion

        #region ElemSize

        /// <summary>
        /// Returns the matrix element size in bytes.
        /// </summary>
        /// <returns></returns>
        public int ElemSize()
        {
            ThrowIfDisposed();
            var res = (int) NativeMethods.core_Mat_elemSize(ptr);
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region ElemSize1

        /// <summary>
        /// Returns the size of each matrix element channel in bytes.
        /// </summary>
        /// <returns></returns>
        public int ElemSize1()
        {
            ThrowIfDisposed();
            var res = (int) NativeMethods.core_Mat_elemSize1(ptr);
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region Empty

        /// <summary>
        /// Returns true if the array has no elements.
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_empty(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region Inv

        /// <summary>
        /// Inverses a matrix.
        /// </summary>
        /// <param name="method">Matrix inversion method</param>
        /// <returns></returns>
        public Mat Inv(DecompTypes method = DecompTypes.LU)
        {
            ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_inv2(ptr, (int) method);
            GC.KeepAlive(this);
            var retVal = new Mat(retPtr);
            return retVal;
        }

        #endregion

        #region IsContinuous

        /// <summary>
        /// Reports whether the matrix is continuous or not.
        /// </summary>
        /// <returns></returns>
        public bool IsContinuous()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_isContinuous(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region IsSubmatrix

        /// <summary>
        /// Returns whether this matrix is a part of other matrix or not.
        /// </summary>
        /// <returns></returns>
        public bool IsSubmatrix()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_isSubmatrix(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region LocateROI

        /// <summary>
        /// Locates the matrix header within a parent matrix.
        /// </summary>
        /// <param name="wholeSize">Output parameter that contains the size of the whole matrix containing *this as a part.</param>
        /// <param name="ofs">Output parameter that contains an offset of *this inside the whole matrix.</param>
        // ReSharper disable once InconsistentNaming
        public void LocateROI(out Size wholeSize, out Point ofs)
        {
            ThrowIfDisposed();
            NativeMethods.core_Mat_locateROI(ptr, out wholeSize, out ofs);
            GC.KeepAlive(this);
        }

        #endregion

        #region Mul

        /// <summary>
        /// Performs an element-wise multiplication or division of the two matrices.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public MatExpr Mul(Mat m, double scale = 1)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException();
            var mPtr = m.CvPtr;
            var retPtr = NativeMethods.core_Mat_mul2(ptr, mPtr, scale);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            var retVal = new MatExpr(retPtr);
            return retVal;
        }

        #endregion

        #region Reshape

        /// <summary>
        /// Changes the shape and/or the number of channels of a 2D matrix without copying the data.
        /// </summary>
        /// <param name="cn">New number of channels. If the parameter is 0, the number of channels remains the same.</param>
        /// <param name="rows">New number of rows. If the parameter is 0, the number of rows remains the same.</param>
        /// <returns></returns>
        public Mat Reshape(int cn, int rows = 0)
        {
            ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_reshape2(ptr, cn, rows);
            GC.KeepAlive(this);
            var retVal = new Mat(retPtr);
            return retVal;
        }

        /// <summary>
        /// Changes the shape and/or the number of channels of a 2D matrix without copying the data.
        /// </summary>
        /// <param name="cn">New number of channels. If the parameter is 0, the number of channels remains the same.</param>
        /// <param name="newDims">New number of rows. If the parameter is 0, the number of rows remains the same.</param>
        /// <returns></returns>
        public Mat Reshape(int cn, params int[] newDims)
        {
            ThrowIfDisposed();
            if (newDims == null)
                throw new ArgumentNullException(nameof(newDims));
            var retPtr = NativeMethods.core_Mat_reshape3(ptr, cn, newDims.Length, newDims);
            GC.KeepAlive(this);
            var retVal = new Mat(retPtr);
            return retVal;
        }

        #endregion

        #region Rows

        /// <summary>
        /// the number of rows or -1 when the array has more than 2 dimensions
        /// </summary>
        public int Rows
        {
            get
            {
                //if (rowsVal == int.MinValue)
                //{
                //    rowsVal = NativeMethods.core_Mat_rows(ptr);
                //}
                //return rowsVal;
                var res = NativeMethods.core_Mat_rows(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// the number of rows or -1 when the array has more than 2 dimensions
        /// </summary>
        /// <returns></returns>
        public int Height
        {
            get
            {
                //if (rowsVal == int.MinValue)
                //{
                //    rowsVal = Rows;
                //}
                //return rowsVal;
                var res = NativeMethods.core_Mat_rows(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        //private int rowsVal = int.MinValue;

        #endregion

        #region SetTo

        /// <summary>
        /// Sets all or some of the array elements to the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public Mat SetTo(Scalar value, Mat? mask = null)
        {
            ThrowIfDisposed();
            var maskPtr = Cv2.ToPtr(mask);

            NativeMethods.core_Mat_setTo_Scalar(ptr, value, maskPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(mask);
            return this;
        }

        /// <summary>
        /// Sets all or some of the array elements to the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public Mat SetTo(InputArray value, Mat? mask = null)
        {
            ThrowIfDisposed();
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();
            var maskPtr = Cv2.ToPtr(mask);

            NativeMethods.core_Mat_setTo_InputArray(ptr, value.CvPtr, maskPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(value);
            GC.KeepAlive(mask);
            return this;
        }

        #endregion

        #region Size

        /// <summary>
        /// Returns a matrix size.
        /// </summary>
        /// <returns></returns>
        public Size Size()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_size(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns a matrix size.
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        public int Size(int dim)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_sizeAt(ptr, dim);
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region Step

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long Step()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_step(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Step(int i)
        {
            ThrowIfDisposed();
            var res = (long) NativeMethods.core_Mat_stepAt(ptr, i);
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region Step1

        /// <summary>
        /// Returns a normalized step.
        /// </summary>
        /// <returns></returns>
        public long Step1()
        {
            ThrowIfDisposed();
            var res = (long) NativeMethods.core_Mat_step11(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns a normalized step.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Step1(int i)
        {
            ThrowIfDisposed();
            var res = (long) NativeMethods.core_Mat_step12(ptr, i);
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region T

        /// <summary>
        /// Transposes a matrix.
        /// </summary>
        /// <returns></returns>
        public Mat T()
        {
            ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_t(ptr);
            GC.KeepAlive(this);
            var retVal = new Mat(retPtr);
            return retVal;
        }

        #endregion

        #region Total

        /// <summary>
        /// Returns the total number of array elements.
        /// </summary>
        /// <returns></returns>
        public long Total()
        {
            ThrowIfDisposed();
            var res = (long) NativeMethods.core_Mat_total(ptr);
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region Type

        /// <summary>
        /// Returns the type of a matrix element.
        /// </summary>
        /// <returns></returns>
        public MatType Type()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_type(ptr);
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region ToString

        /// <summary>
        /// Returns a string that represents this Mat.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Mat [ " +
                   Rows + "*" + Cols + "*" + Type().ToString() +
                   ", IsContinuous=" + IsContinuous() + ", IsSubmatrix=" + IsSubmatrix() +
                   ", Ptr=0x" + Convert.ToString(ptr.ToInt64(), 16) +
                   ", Data=0x" + Convert.ToString(Data.ToInt64(), 16) +
                   " ]";
        }

        #endregion

        #region Dump

        /// <summary>
        /// Returns a string that represents each element value of Mat.
        /// This method corresponds to std::ostream &lt;&lt; Mat
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string? Dump(FormatType format = FormatType.Default)
        {
            ThrowIfDisposed();
            return Cv2.Format(this, format);
        }

        #endregion

        #region EmptyClone

#if LANG_JP
/// <summary>
/// このMatと同じサイズ・ビット深度・チャネル数を持つ
/// Matオブジェクトを新たに作成し、返す
/// </summary>
/// <returns>コピーされた画像</returns>
#else
        /// <summary>
        /// Makes a Mat that have the same size, depth and channels as this image
        /// </summary>
        /// <returns></returns>
#endif
        public Mat EmptyClone()
        {
            return new Mat(Size(), Type());
        }

        #endregion

        #region Ptr

        /// <summary>
        /// Returns a pointer to the specified matrix row.
        /// </summary>
        /// <param name="i0">Index along the dimension 0</param>
        /// <returns></returns>
        public IntPtr Ptr(int i0)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_ptr1d(ptr, i0);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns a pointer to the specified matrix element.
        /// </summary>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <returns></returns>
        public IntPtr Ptr(int i0, int i1)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_ptr2d(ptr, i0, i1);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns a pointer to the specified matrix element.
        /// </summary>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <param name="i2">Index along the dimension 2</param>
        /// <returns></returns>
        public IntPtr Ptr(int i0, int i1, int i2)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_ptr3d(ptr, i0, i1, i2);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns a pointer to the specified matrix element.
        /// </summary>
        /// <param name="idx">Array of Mat::dims indices.</param>
        /// <returns></returns>
        public IntPtr Ptr(params int[] idx)
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_Mat_ptrnd(ptr, idx);
            GC.KeepAlive(this);
            return res;
        }

        #endregion

        #region Element Indexer

        /// <summary>
        /// Gets a type-specific indexer. The indexer has getters/setters to access each matrix element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Indexer<T> GetGenericIndexer<T>() where T : struct
        {
            return new Indexer<T>(this);
        }

        /// <summary>
        /// Gets a type-specific unsafe indexer. The indexer has getters/setters to access each matrix element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public UnsafeIndexer<T> GetUnsafeGenericIndexer<T>() where T : unmanaged
        {
            return new UnsafeIndexer<T>(this);
        }

        /// <summary>
        /// Mat Indexer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public sealed class Indexer<T> : MatIndexer<T> where T : struct
        {
            private readonly long ptrVal;

            internal Indexer(Mat parent)
                : base(parent)
            {
                ptrVal = parent.Data.ToInt64();
            }

            /// <summary>
            /// 1-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <returns>A value to the specified array element.</returns>
            public override T this[int i0]
            {
                get
                {
                    var p = new IntPtr(ptrVal + (Steps[0] * i0));
                    return MarshalHelper.PtrToStructure<T>(p);
                }
                set
                {
                    var p = new IntPtr(ptrVal + (Steps[0] * i0));
                    Marshal.StructureToPtr(value, p, false);
                }
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
                    var p = new IntPtr(ptrVal + (Steps[0] * i0) + (Steps[1] * i1));
                    return MarshalHelper.PtrToStructure<T>(p);
                }
                set
                {
                    var p = new IntPtr(ptrVal + (Steps[0] * i0) + (Steps[1] * i1));
                    Marshal.StructureToPtr(value, p, false);
                }
            }

            /// <summary>
            /// 3-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <param name="i1">Index along the dimension 1</param>
            /// <param name="i2"> Index along the dimension 2</param>
            /// <returns>A value to the specified array element.</returns>
            public override T this[int i0, int i1, int i2]
            {
                get
                {
                    var p = new IntPtr(ptrVal + (Steps[0] * i0) + (Steps[1] * i1) + (Steps[2] * i2));
                    return MarshalHelper.PtrToStructure<T>(p);
                }
                set
                {
                    var p = new IntPtr(ptrVal + (Steps[0] * i0) + (Steps[1] * i1) + (Steps[2] * i2));
                    Marshal.StructureToPtr(value, p, false);
                }
            }

            /// <summary>
            /// n-dimensional indexer
            /// </summary>
            /// <param name="idx">Array of Mat::dims indices.</param>
            /// <returns>A value to the specified array element.</returns>
            public override T this[params int[] idx]
            {
                get
                {
                    long offset = 0;
                    for (var i = 0; i < idx.Length; i++)
                    {
                        offset += Steps[i] * idx[i];
                    }

                    var p = new IntPtr(ptrVal + offset);
                    return MarshalHelper.PtrToStructure<T>(p);
                }
                set
                {
                    long offset = 0;
                    for (var i = 0; i < idx.Length; i++)
                    {
                        offset += Steps[i] * idx[i];
                    }

                    var p = new IntPtr(ptrVal + offset);
                    Marshal.StructureToPtr(value, p, false);
                }
            }
        }

        /// <summary>
        /// Mat Indexer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public sealed class UnsafeIndexer<T> : MatIndexer<T> where T : unmanaged
        {
            private readonly long ptrVal;

            internal UnsafeIndexer(Mat parent)
                : base(parent)
            {
                ptrVal = parent.Data.ToInt64();
            }

            /// <summary>
            /// 1-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <returns>A value to the specified array element.</returns>
            public override unsafe T this[int i0]
            {
                get
                {
                    var p = (T*) (ptrVal + (Steps[0] * i0));
                    return *p;
                }
                set
                {
                    var p = (T*) (ptrVal + (Steps[0] * i0));
                    *p = value;
                }
            }

            /// <summary>
            /// 2-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <param name="i1">Index along the dimension 1</param>
            /// <returns>A value to the specified array element.</returns>
            public override unsafe T this[int i0, int i1]
            {
                get
                {
                    var p = (T*) (ptrVal + (Steps[0] * i0) + (Steps[1] * i1));
                    return *p;
                }
                set
                {
                    var p = (T*) (ptrVal + (Steps[0] * i0) + (Steps[1] * i1));
                    *p = value;
                }
            }

            /// <summary>
            /// 3-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <param name="i1">Index along the dimension 1</param>
            /// <param name="i2"> Index along the dimension 2</param>
            /// <returns>A value to the specified array element.</returns>
            public override unsafe T this[int i0, int i1, int i2]
            {
                get
                {
                    var p = (T*) (ptrVal + (Steps[0] * i0) + (Steps[1] * i1) + (Steps[2] * i2));
                    return *p;
                }
                set
                {
                    var p = (T*) (ptrVal + (Steps[0] * i0) + (Steps[1] * i1) + (Steps[2] * i2));
                    *p = value;
                }
            }

            /// <summary>
            /// n-dimensional indexer
            /// </summary>
            /// <param name="idx">Array of Mat::dims indices.</param>
            /// <returns>A value to the specified array element.</returns>
            public override unsafe T this[params int[] idx]
            {
                get
                {
                    long offset = 0;
                    for (var i = 0; i < idx.Length; i++)
                    {
                        offset += Steps[i] * idx[i];
                    }

                    var p = (T*) (ptrVal + offset);
                    return *p;
                }
                set
                {
                    long offset = 0;
                    for (var i = 0; i < idx.Length; i++)
                    {
                        offset += Steps[i] * idx[i];
                    }

                    var p = (T*) (ptrVal + offset);
                    *p = value;
                }
            }
        }

        #endregion

        #region Get/Set

        /// <summary>
        /// Returns a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0">Index along the dimension 0</param>
        /// <returns>A value to the specified array element.</returns>
        public T Get<T>(int i0) where T : struct
        {
            return new Indexer<T>(this)[i0];
        }

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
        /// <param name="i2">Index along the dimension 2</param>
        /// <returns>A value to the specified array element.</returns>
        public T Get<T>(int i0, int i1, int i2) where T : struct
        {
            return new Indexer<T>(this)[i0, i1, i2];
        }

        /// <summary>
        /// Returns a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="idx">Array of Mat::dims indices.</param>
        /// <returns>A value to the specified array element.</returns>
        public T Get<T>(params int[] idx) where T : struct
        {
            return new Indexer<T>(this)[idx];
        }

        /// <summary>
        /// Returns a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0">Index along the dimension 0</param>
        /// <returns>A value to the specified array element.</returns>
        public T At<T>(int i0) where T : struct
        {
            return new Indexer<T>(this)[i0];
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
        /// Returns a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <param name="i2">Index along the dimension 2</param>
        /// <returns>A value to the specified array element.</returns>
        public T At<T>(int i0, int i1, int i2) where T : struct
        {
            return new Indexer<T>(this)[i0, i1, i2];
        }

        /// <summary>
        /// Returns a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="idx">Array of Mat::dims indices.</param>
        /// <returns>A value to the specified array element.</returns>
        public T At<T>(params int[] idx) where T : struct
        {
            return new Indexer<T>(this)[idx];
        }


        /// <summary>
        /// Set a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="value"></param>
        public void Set<T>(int i0, T value) where T : struct
        {
            (new Indexer<T>(this))[i0] = value;
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

        /// <summary>
        /// Set a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <param name="i2">Index along the dimension 2</param>
        /// <param name="value"></param>
        public void Set<T>(int i0, int i1, int i2, T value) where T : struct
        {
            (new Indexer<T>(this)[i0, i1, i2]) = value;
        }

        /// <summary>
        /// Set a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="idx">Array of Mat::dims indices.</param>
        /// <param name="value"></param>
        public void Set<T>(int[] idx, T value) where T : struct
        {
            (new Indexer<T>(this)[idx]) = value;
        }

        #endregion

        #region Col/ColRange

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Mat Col(int x)
        {
            ThrowIfDisposed();
            IntPtr matPtr = NativeMethods.core_Mat_col_toMat(ptr, x);
            return new Mat(matPtr);
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startCol"></param>
        /// <param name="endCol"></param>
        /// <returns></returns>
        public Mat ColRange(int startCol, int endCol)
        {
            ThrowIfDisposed();
            var matPtr = NativeMethods.core_Mat_colRange_toMat(ptr, startCol, endCol);
            GC.KeepAlive(this);
            return new Mat(matPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Mat ColRange(Range range)
        {
            return ColRange(range.Start, range.End);
        }


        /// <summary>
        /// Mat column's indexer object
        /// </summary>
        public class ColIndexer : MatRowColIndexer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="parent"></param>
            protected internal ColIndexer(Mat parent)
                : base(parent)
            {
            }

            /// <summary>
            /// Creates a matrix header for the specified matrix column.
            /// </summary>
            /// <param name="x">A 0-based column index.</param>
            /// <returns></returns>
            public override Mat this[int x]
            {
                get
                {
                    Parent.ThrowIfDisposed();
                    var matPtr = NativeMethods.core_Mat_col_toMat(Parent.ptr, x);
                    GC.KeepAlive(this);
                    var mat = new Mat(matPtr);
                    return mat;
                }
                set
                {
                    Parent.ThrowIfDisposed();
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    value.ThrowIfDisposed();
                    if (Parent.Dims() != value.Dims())
                        throw new ArgumentException("Dimension mismatch");

                    var matPtr = NativeMethods.core_Mat_col_toMat(Parent.ptr, x);
                    GC.KeepAlive(this);
                    var mat = new Mat(matPtr);
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
            public override Mat this[int startCol, int endCol]
            {
                get
                {
                    Parent.ThrowIfDisposed();
                    var matPtr = NativeMethods.core_Mat_colRange_toMat(Parent.ptr, startCol, endCol);
                    GC.KeepAlive(this);
                    var mat = new Mat(matPtr);
                    return mat;
                }
                set
                {
                    Parent.ThrowIfDisposed();
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    value.ThrowIfDisposed();
                    if (Parent.Dims() != value.Dims())
                        throw new ArgumentException("Dimension mismatch");

                    var colMatPtr = NativeMethods.core_Mat_colRange_toMat(Parent.ptr, startCol, endCol);
                    GC.KeepAlive(this);
                    var colMat = new Mat(colMatPtr);
                    if (colMat.Size() != value.Size())
                        throw new ArgumentException("Specified ROI != mat.Size()");
                    value.CopyTo(colMat);
                }
            }
        }

        /// <summary>
        /// Indexer to access Mat column as Mat
        /// </summary>
        /// <returns></returns>
        public ColIndexer Col
        {
            get { return colIndexer ??= new ColIndexer(this); }
        }

        private ColIndexer? colIndexer;

        #endregion

        #region Row/RowRange

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public Mat Row(int y)
        {
            ThrowIfDisposed();
            IntPtr matPtr = NativeMethods.core_Mat_row_toMat(ptr, y);
            return new Mat(matPtr);
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <returns></returns>
        public Mat RowRange(int startRow, int endRow)
        {
            ThrowIfDisposed();
            var matPtr = NativeMethods.core_Mat_rowRange_toMat(ptr, startRow, endRow);
            GC.KeepAlive(this);
            return new Mat(matPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Mat RowRange(Range range)
        {
            return RowRange(range.Start, range.End);
        }

        /// <summary>
        /// Mat row's indexer object
        /// </summary>
        public class RowIndexer : MatRowColIndexer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="parent"></param>
            protected internal RowIndexer(Mat parent)
                : base(parent)
            {
            }

            /// <summary>
            /// Creates a matrix header for the specified matrix row.
            /// </summary>
            /// <param name="x">A 0-based row index.</param>
            /// <returns></returns>
            public override Mat this[int x]
            {
                get
                {
                    Parent.ThrowIfDisposed();
                    var matPtr = NativeMethods.core_Mat_row_toMat(Parent.ptr, x);
                    GC.KeepAlive(this);
                    var mat = new Mat(matPtr);
                    return mat;
                }
                set
                {
                    Parent.ThrowIfDisposed();
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    value.ThrowIfDisposed();
                    if (Parent.Dims() != value.Dims())
                        throw new ArgumentException("Dimension mismatch");

                    var matPtr = NativeMethods.core_Mat_row_toMat(Parent.ptr, x);
                    GC.KeepAlive(this);
                    var mat = new Mat(matPtr);
                    if (mat.Size() != value.Size())
                        throw new ArgumentException("Specified ROI != mat.Size()");
                    value.CopyTo(mat);
                }
            }

            /// <summary>
            /// Creates a matrix header for the specified row span.
            /// </summary>
            /// <param name="startRow">An inclusive 0-based start index of the row span.</param>
            /// <param name="endRow">An exclusive 0-based ending index of the row span.</param>
            /// <returns></returns>
            public override Mat this[int startRow, int endRow]
            {
                get
                {
                    Parent.ThrowIfDisposed();
                    // todo: rsb - is this row or col range?
                    var matPtr = NativeMethods.core_Mat_rowRange_toMat(Parent.ptr, startRow, endRow);
                    GC.KeepAlive(this);
                    var mat = new Mat(matPtr);
                    return mat;
                }
                set
                {
                    Parent.ThrowIfDisposed();
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                    value.ThrowIfDisposed();
                    if (Parent.Dims() != value.Dims())
                        throw new ArgumentException("Dimension mismatch");

                    var matPtr = NativeMethods.core_Mat_rowRange_toMat(Parent.ptr, startRow, endRow);
                    GC.KeepAlive(this);
                    var mat = new Mat(matPtr);
                    if (mat.Size() != value.Size())
                        throw new ArgumentException("Specified ROI != mat.Size()");
                    value.CopyTo(mat);
                }
            }
        }

        /// <summary>
        /// Indexer to access Mat row as Mat
        /// </summary>
        /// <returns></returns>
        public RowIndexer Row
        {
            get { return rowIndexer ??= new RowIndexer(this); }
        }

        private RowIndexer? rowIndexer;

        #endregion

        #region SubMat

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowStart"></param>
        /// <param name="rowEnd"></param>
        /// <param name="colStart"></param>
        /// <param name="colEnd"></param>
        /// <returns></returns>
        public Mat SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
        {
            if (rowStart >= rowEnd)
                throw new ArgumentException("rowStart >= rowEnd");
            if (colStart >= colEnd)
                throw new ArgumentException("colStart >= colEnd");

            ThrowIfDisposed();
            var retPtr = NativeMethods.core_Mat_subMat1(ptr, rowStart, rowEnd, colStart, colEnd);
            GC.KeepAlive(this);
            var retVal = new Mat(retPtr);
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        /// <returns></returns>
        public Mat SubMat(Range rowRange, Range colRange)
        {
            return SubMat(rowRange.Start, rowRange.End, colRange.Start, colRange.End);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roi"></param>
        /// <returns></returns>
        public Mat SubMat(Rect roi)
        {
            return SubMat(roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ranges"></param>
        /// <returns></returns>
        public Mat SubMat(params Range[] ranges)
        {
            throw new NotImplementedException();
            /*
            if (ranges == null)
                throw new ArgumentNullException();

            ThrowIfDisposed();
            CvSlice[] slices = new CvSlice[ranges.Length];
            for (int i = 0; i < ranges.Length; i++)
            {
                slices[i] = ranges[i];
            }

            IntPtr retPtr = NativeMethods.core_Mat_subMat1(ptr, ranges.Length, ranges);
            Mat retVal = new Mat(retPtr);
            return retVal;*/
        }

        #endregion

        #region GetArray

        /*
        private void CheckArgumentsForConvert(int row, int col, Array data,
            MatType[] acceptableTypes)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException(nameof(row));
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException(nameof(col));
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);

            if (acceptableTypes != null && acceptableTypes.Length > 0)
            {
                bool isValidDepth = EnumerableEx.Any(acceptableTypes, type => type == t);
                if (!isValidDepth)
                    throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            }
        }
        */

        private void CheckArgumentsForConvert(int row, int col, Array data, int dataDimension,
            MatType[]? acceptableTypes)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException(nameof(row));
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException(nameof(col));
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var t = Type();
            if ((data.Length * dataDimension) % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);

            if (acceptableTypes != null && acceptableTypes.Length > 0)
            {
                var isValidDepth = EnumerableEx.Any(acceptableTypes, type => type == t);
                if (!isValidDepth)
                    throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, byte[] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_8SC1, MatType.CV_8UC1});
            unsafe
            {
                fixed (byte* pData = data)
                {
                    NativeMethods.core_Mat_nGetB(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, byte[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_8SC1, MatType.CV_8UC1});
            unsafe
            {
                fixed (byte* pData = data)
                {
                    NativeMethods.core_Mat_nGetB(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, short[] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_16SC1, MatType.CV_16UC1});
            unsafe
            {
                fixed (short* pData = data)
                {
                    NativeMethods.core_Mat_nGetS(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, short[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_16SC1, MatType.CV_16UC1});
            unsafe
            {
                fixed (short* pData = data)
                {
                    NativeMethods.core_Mat_nGetS(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, ushort[] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_16SC1, MatType.CV_16UC1});
            unsafe
            {
                fixed (ushort* pData = data)
                {
                    NativeMethods.core_Mat_nGetS(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, ushort[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_16SC1, MatType.CV_16UC1});
            unsafe
            {
                fixed (ushort* pData = data)
                {
                    NativeMethods.core_Mat_nGetS(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, int[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32S, null);
            unsafe
            {
                fixed (int* pData = data)
                {
                    NativeMethods.core_Mat_nGetI(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, int[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_32SC1});
            unsafe
            {
                fixed (int* pData = data)
                {
                    NativeMethods.core_Mat_nGetI(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, float[] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_32FC1});
            unsafe
            {
                fixed (float* pData = data)
                {
                    NativeMethods.core_Mat_nGetF(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, float[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_32FC1});
            unsafe
            {
                fixed (float* pData = data)
                {
                    NativeMethods.core_Mat_nGetF(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, double[] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_64FC1});
            unsafe
            {
                fixed (double* pData = data)
                {
                    NativeMethods.core_Mat_nGetD(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, double[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_64FC1});
            unsafe
            {
                fixed (double* pData = data)
                {
                    NativeMethods.core_Mat_nGetD(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public double[] GetArray(int row, int col)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException(nameof(row));
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException(nameof(col));

            var ret = new double[Channels()];
            unsafe
            {
                fixed (double* pData = ret)
                {
                    NativeMethods.core_Mat_nGetD(ptr, row, col, pData, ret.Length);
                    GC.KeepAlive(this);
                    return ret;
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec3b[] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_8UC3});
            unsafe
            {
                fixed (Vec3b* pData = data)
                {
                    NativeMethods.core_Mat_nGetVec3b(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec3b[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_8UC3});
            unsafe
            {
                fixed (Vec3b* pData = data)
                {
                    NativeMethods.core_Mat_nGetVec3b(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec3d[] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_64FC3});
            unsafe
            {
                fixed (Vec3d* pData = data)
                {
                    NativeMethods.core_Mat_nGetVec3d(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec3d[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_64FC3});
            unsafe
            {
                fixed (Vec3d* pData = data)
                {
                    NativeMethods.core_Mat_nGetVec3d(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec4f[] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, new[] {MatType.CV_32FC4});
            unsafe
            {
                fixed (Vec4f* pData = data)
                {
                    NativeMethods.core_Mat_nGetVec4f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec4f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, new[] {MatType.CV_32FC4});
            unsafe
            {
                fixed (Vec4f* pData = data)
                {
                    NativeMethods.core_Mat_nGetVec4f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec6f[] data)
        {
            CheckArgumentsForConvert(row, col, data, 6, new[] {MatType.CV_32FC(6)});
            unsafe
            {
                fixed (Vec6f* pData = data)
                {
                    NativeMethods.core_Mat_nGetVec6f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec6f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 6, new[] {MatType.CV_32FC(6)});
            unsafe
            {
                fixed (Vec6f* pData = data)
                {
                    NativeMethods.core_Mat_nGetVec6f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec4i[] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, new[] {MatType.CV_32SC4});
            unsafe
            {
                fixed (Vec4i* pData = data)
                {
                    NativeMethods.core_Mat_nGetVec4i(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec4i[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, new[] {MatType.CV_32SC4});
            unsafe
            {
                fixed (Vec4i* pData = data)
                {
                    NativeMethods.core_Mat_nGetVec4i(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point[] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_32SC2});
            unsafe
            {
                fixed (Point* pData = data)
                {
                    NativeMethods.core_Mat_nGetPoint(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_32SC2});
            unsafe
            {
                fixed (Point* pData = data)
                {
                    NativeMethods.core_Mat_nGetPoint(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point2f[] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_32FC2});
            unsafe
            {
                fixed (Point2f* pData = data)
                {
                    NativeMethods.core_Mat_nGetPoint2f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point2f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_32FC2});
            unsafe
            {
                fixed (Point2f* pData = data)
                {
                    NativeMethods.core_Mat_nGetPoint2f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point2d[] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_64FC2});
            unsafe
            {
                fixed (Point2d* pData = data)
                {
                    NativeMethods.core_Mat_nGetPoint2d(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point2d[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_64FC2});
            unsafe
            {
                fixed (Point2d* pData = data)
                {
                    NativeMethods.core_Mat_nGetPoint2d(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point3i[] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_32SC3});
            unsafe
            {
                fixed (Point3i* pData = data)
                {
                    NativeMethods.core_Mat_nGetPoint3i(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point3i[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_32SC3});
            unsafe
            {
                fixed (Point3i* pData = data)
                {
                    NativeMethods.core_Mat_nGetPoint3i(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }


        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point3f[] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_32FC3});
            unsafe
            {
                fixed (Point3f* pData = data)
                {
                    NativeMethods.core_Mat_nGetPoint3f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point3f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_32FC3});
            unsafe
            {
                fixed (Point3f* pData = data)
                {
                    NativeMethods.core_Mat_nGetPoint3f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point3d[] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_64FC3});
            unsafe
            {
                fixed (Point3d* pData = data)
                {
                    NativeMethods.core_Mat_nGetPoint3d(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point3d[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_64FC3});
            unsafe
            {
                fixed (Point3d* pData = data)
                {
                    NativeMethods.core_Mat_nGetPoint3d(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Rect[] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, new[] {MatType.CV_32SC4});
            unsafe
            {
                fixed (Rect* pData = data)
                {
                    NativeMethods.core_Mat_nGetRect(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Rect[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, new[] {MatType.CV_32SC4});
            unsafe
            {
                fixed (Rect* pData = data)
                {
                    NativeMethods.core_Mat_nGetRect(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, DMatch[] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, null);
            unsafe
            {
                var dataV = new Vec4f[data.Length];
                fixed (Vec4f* pData = dataV)
                {
                    NativeMethods.core_Mat_nGetVec4f(ptr, row, col, pData, dataV.Length);
                    GC.KeepAlive(this);
                    for (var i = 0; i < data.Length; i++)
                    {
                        data[i] = (DMatch) dataV[i];
                    }
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, DMatch[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, null);
            var dim0 = data.GetLength(0);
            var dim1 = data.GetLength(1);
            unsafe
            {
                var dataV = new Vec4f[dim0, dim1];
                fixed (Vec4f* pData = dataV)
                {
                    NativeMethods.core_Mat_nGetVec4f(ptr, row, col, pData, dataV.Length);
                    GC.KeepAlive(this);
                    for (var i = 0; i < dim0; i++)
                    {
                        for (var j = 0; j < dim1; j++)
                        {
                            data[i, j] = (DMatch) dataV[i, j];
                        }
                    }
                }
            }
        }

        #endregion

        #region SetArray

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, byte[] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_8UC1});
            unsafe
            {
                fixed (byte* pData = data)
                {
                    NativeMethods.core_Mat_nSetB(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, byte[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_8UC1});
            unsafe
            {
                fixed (byte* pData = data)
                {
                    NativeMethods.core_Mat_nSetB(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, short[] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_16SC1, MatType.CV_16UC1});
            unsafe
            {
                fixed (short* pData = data)
                {
                    NativeMethods.core_Mat_nSetS(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, short[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_16SC1, MatType.CV_16UC1});
            unsafe
            {
                fixed (short* pData = data)
                {
                    NativeMethods.core_Mat_nSetS(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, ushort[] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_16SC1, MatType.CV_16UC1});
            unsafe
            {
                fixed (ushort* pData = data)
                {
                    NativeMethods.core_Mat_nSetS(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, ushort[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_16SC1, MatType.CV_16UC1});
            unsafe
            {
                fixed (ushort* pData = data)
                {
                    NativeMethods.core_Mat_nSetS(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, int[] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_32SC1});
            unsafe
            {
                fixed (int* pData = data)
                {
                    NativeMethods.core_Mat_nSetI(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, int[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_32SC1});
            unsafe
            {
                fixed (int* pData = data)
                {
                    NativeMethods.core_Mat_nSetI(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, float[] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_32FC1});
            unsafe
            {
                fixed (float* pData = data)
                {
                    NativeMethods.core_Mat_nSetF(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, float[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_32FC1});
            unsafe
            {
                fixed (float* pData = data)
                {
                    NativeMethods.core_Mat_nSetF(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, double[] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_64FC1});
            unsafe
            {
                fixed (double* pData = data)
                {
                    NativeMethods.core_Mat_nSetD(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, double[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 1, new[] {MatType.CV_64FC1});
            unsafe
            {
                fixed (double* pData = data)
                {
                    NativeMethods.core_Mat_nSetD(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec3b[] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_8UC3});
            unsafe
            {
                fixed (Vec3b* pData = data)
                {
                    NativeMethods.core_Mat_nSetVec3b(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec3b[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_8UC3});
            unsafe
            {
                fixed (Vec3b* pData = data)
                {
                    NativeMethods.core_Mat_nSetVec3b(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec3d[] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_64FC3});
            unsafe
            {
                fixed (Vec3d* pData = data)
                {
                    NativeMethods.core_Mat_nSetVec3d(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec3d[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_64FC3});
            unsafe
            {
                fixed (Vec3d* pData = data)
                {
                    NativeMethods.core_Mat_nSetVec3d(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec4f[] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, new[] {MatType.CV_32FC4});
            unsafe
            {
                fixed (Vec4f* pData = data)
                {
                    NativeMethods.core_Mat_nSetVec4f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec4f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, new[] {MatType.CV_32FC4});
            unsafe
            {
                fixed (Vec4f* pData = data)
                {
                    NativeMethods.core_Mat_nSetVec4f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec6f[] data)
        {
            CheckArgumentsForConvert(row, col, data, 6, new[] {MatType.CV_32FC(6)});
            unsafe
            {
                fixed (Vec6f* pData = data)
                {
                    NativeMethods.core_Mat_nSetVec6f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec6f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 6, new[] {MatType.CV_32FC(6)});
            unsafe
            {
                fixed (Vec6f* pData = data)
                {
                    NativeMethods.core_Mat_nSetVec6f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec4i[] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, new[] {MatType.CV_32SC4});
            unsafe
            {
                fixed (Vec4i* pData = data)
                {
                    NativeMethods.core_Mat_nSetVec4i(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec4i[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_32SC4});
            unsafe
            {
                fixed (Vec4i* pData = data)
                {
                    NativeMethods.core_Mat_nSetVec4i(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point[] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_32SC2});
            unsafe
            {
                fixed (Point* pData = data)
                {
                    NativeMethods.core_Mat_nSetPoint(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_32SC2});
            unsafe
            {
                fixed (Point* pData = data)
                {
                    NativeMethods.core_Mat_nSetPoint(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point2f[] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_32FC2});
            unsafe
            {
                fixed (Point2f* pData = data)
                {
                    NativeMethods.core_Mat_nSetPoint2f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point2f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_32FC2});
            unsafe
            {
                fixed (Point2f* pData = data)
                {
                    NativeMethods.core_Mat_nSetPoint2f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point2d[] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_64FC2});
            unsafe
            {
                fixed (Point2d* pData = data)
                {
                    NativeMethods.core_Mat_nSetPoint2d(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point2d[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 2, new[] {MatType.CV_64FC2});
            unsafe
            {
                fixed (Point2d* pData = data)
                {
                    NativeMethods.core_Mat_nSetPoint2d(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point3i[] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_32SC3});
            unsafe
            {
                fixed (Point3i* pData = data)
                {
                    NativeMethods.core_Mat_nSetPoint3i(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point3i[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_32SC3});
            unsafe
            {
                fixed (Point3i* pData = data)
                {
                    NativeMethods.core_Mat_nSetPoint3i(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point3f[] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_32FC3});
            unsafe
            {
                fixed (Point3f* pData = data)
                {
                    NativeMethods.core_Mat_nSetPoint3f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point3f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_32FC3});
            unsafe
            {
                fixed (Point3f* pData = data)
                {
                    NativeMethods.core_Mat_nSetPoint3f(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point3d[] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_64FC3});
            unsafe
            {
                fixed (Point3d* pData = data)
                {
                    NativeMethods.core_Mat_nSetPoint3d(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point3d[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 3, new[] {MatType.CV_64FC3});
            unsafe
            {
                fixed (Point3d* pData = data)
                {
                    NativeMethods.core_Mat_nSetPoint3d(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Rect[] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, new[] {MatType.CV_32SC4});
            unsafe
            {
                fixed (Rect* pData = data)
                {
                    NativeMethods.core_Mat_nSetRect(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Rect[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, new[] {MatType.CV_32SC4});
            unsafe
            {
                fixed (Rect* pData = data)
                {
                    NativeMethods.core_Mat_nSetRect(ptr, row, col, pData, data.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, DMatch[] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, null);
            var dataV = EnumerableEx.SelectToArray(data, d => (Vec4f) d);
            unsafe
            {
                fixed (Vec4f* pData = dataV)
                {
                    NativeMethods.core_Mat_nSetVec4f(ptr, row, col, pData, dataV.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, DMatch[,] data)
        {
            CheckArgumentsForConvert(row, col, data, 4, null);
            var dataV = EnumerableEx.SelectToArray(data, (DMatch d) => (Vec4f) d);
            unsafe
            {
                fixed (Vec4f* pData = dataV)
                {
                    NativeMethods.core_Mat_nSetVec4f(ptr, row, col, pData, dataV.Length);
                    GC.KeepAlive(this);
                }
            }
        }

        #endregion

        #region Reserve

        /// <summary>
        /// reserves enough space to fit sz hyper-planes
        /// </summary>
        /// <param name="sz"></param>
        public void Reserve(long sz)
        {
            ThrowIfDisposed();
            NativeMethods.core_Mat_reserve(ptr, new IntPtr(sz));
            GC.KeepAlive(this);
        }

        #endregion

        #region Resize

        /// <summary>
        /// resizes matrix to the specified number of hyper-planes
        /// </summary>
        /// <param name="sz"></param>
        public void Resize(long sz)
        {
            ThrowIfDisposed();
            NativeMethods.core_Mat_resize1(ptr, new IntPtr(sz));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// resizes matrix to the specified number of hyper-planes; initializes the newly added elements
        /// </summary>
        /// <param name="sz"></param>
        /// <param name="s"></param>
        public void Resize(long sz, Scalar s)
        {
            ThrowIfDisposed();
            NativeMethods.core_Mat_resize2(ptr, new IntPtr(sz), s);
            GC.KeepAlive(this);
        }

        #endregion

        #region PushBack

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat.push_back)
        /// </summary>
        /// <param name="m">Added line(s)</param>
        public void Add(Mat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException();
            m.ThrowIfDisposed();
            NativeMethods.core_Mat_push_back_Mat(ptr, m.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat.push_back)
        /// </summary>
        /// <param name="m">Added line(s)</param>
        public void PushBack(Mat m)
        {
            Add(m);
        }

        #endregion

        #region PopBack

        /// <summary>
        /// removes several hyper-planes from bottom of the matrix (Mat.pop_back)
        /// </summary>
        /// <param name="nElems"></param>
        public void PopBack(long nElems = 1)
        {
            ThrowIfDisposed();
            NativeMethods.core_Mat_pop_back(ptr, new IntPtr(nElems));
            GC.KeepAlive(this);
        }

        #endregion

        #region To*

        /// <summary>
        /// Encodes an image into a memory buffer.
        /// </summary>
        /// <param name="ext">Encodes an image into a memory buffer.</param>
        /// <param name="prms">Format-specific parameters.</param>
        /// <returns></returns>
        public byte[] ToBytes(string ext = ".png", int[]? prms = null)
        {
            return ImEncode(ext, prms);
        }

        /// <summary>
        /// Encodes an image into a memory buffer.
        /// </summary>
        /// <param name="ext">Encodes an image into a memory buffer.</param>
        /// <param name="prms">Format-specific parameters.</param>
        /// <returns></returns>
        public byte[] ToBytes(string ext = ".png", params ImageEncodingParam[] prms)
        {
            return ImEncode(ext, prms);
        }

        /// <summary>
        /// Converts Mat to System.IO.MemoryStream
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public MemoryStream ToMemoryStream(string ext = ".png", params ImageEncodingParam[] prms)
        {
            return new MemoryStream(ToBytes(ext, prms));
        }

        /// <summary>
        /// Writes image data encoded from this Mat to System.IO.Stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="ext"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public void WriteToStream(Stream stream, string ext = ".png", params ImageEncodingParam[] prms)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            var imageBytes = ToBytes(ext, prms);
            stream.Write(imageBytes, 0, imageBytes.Length);
        }

        #endregion

        #region DrawMarker

#pragma warning disable 1591

        public void DrawMarker(
            int x, int y, Scalar color,
            MarkerStyle style = MarkerStyle.Cross,
            int size = 10,
            LineTypes lineType = LineTypes.Link8,
            int thickness = 1)
        {
            var r = size / 2;

            switch (style)
            {
                case MarkerStyle.CircleLine:
                    Circle(x, y, r, color, thickness, lineType);
                    break;
                case MarkerStyle.CircleFilled:
                    Circle(x, y, r, color, -1, lineType);
                    break;
                case MarkerStyle.Cross:
                    Line(x, y - r, x, y + r, color, thickness, lineType);
                    Line(x - r, y, x + r, y, color, thickness, lineType);
                    break;
                case MarkerStyle.TiltedCross:
                    Line(x - r, y - r, x + r, y + r, color, thickness, lineType);
                    Line(x + r, y - r, x - r, y + r, color, thickness, lineType);
                    break;
                case MarkerStyle.CircleAndCross:
                    Circle(x, y, r, color, thickness, lineType);
                    Line(x, y - r, x, y + r, color, thickness, lineType);
                    Line(x - r, y, x + r, y, color, thickness, lineType);
                    break;
                case MarkerStyle.CircleAndTiltedCross:
                    Circle(x, y, r, color, thickness, lineType);
                    Line(x - r, y - r, x + r, y + r, color, thickness, lineType);
                    Line(x + r, y - r, x - r, y + r, color, thickness, lineType);
                    break;
                case MarkerStyle.DiamondLine:
                case MarkerStyle.DiamondFilled:
                {
                    var r2 = (int) (size * Math.Sqrt(2) / 2.0);
                    Point[] pts =
                    {
                        new Point(x, y - r2),
                        new Point(x + r2, y),
                        new Point(x, y + r2),
                        new Point(x - r2, y)
                    };
                    switch (style)
                    {
                        case MarkerStyle.DiamondLine:
                            Polylines(new[] {pts}, true, color, thickness, lineType);
                            break;
                        case MarkerStyle.DiamondFilled:
                            FillConvexPoly(pts, color, lineType);
                            break;
                    }

                }
                    break;
                case MarkerStyle.SquareLine:
                case MarkerStyle.SquareFilled:
                {
                    Point[] pts =
                    {
                        new Point(x - r, y - r),
                        new Point(x + r, y - r),
                        new Point(x + r, y + r),
                        new Point(x - r, y + r)
                    };
                    switch (style)
                    {
                        case MarkerStyle.SquareLine:
                            Polylines(new[] {pts}, true, color, thickness, lineType);
                            break;
                        case MarkerStyle.SquareFilled:
                            FillConvexPoly(pts, color, lineType);
                            break;
                    }
                }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
#pragma warning restore 1591

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Mat Alignment(int n = 4)
        {
            var newCols = Cv2.AlignSize(Cols, n);
            var pMat = new Mat(Rows, newCols, Type());
            var roiMat = new Mat(pMat, new Rect(0, 0, Cols, Rows));
            CopyTo(roiMat);
            return roiMat;
        }

        /// <summary>
        /// Creates type-specific Mat instance from this.
        /// </summary>
        /// <typeparam name="TMat"></typeparam>
        /// <returns></returns>
        public TMat Cast<TMat>()
            where TMat : Mat
        {
            var type = typeof(TMat);

            var obj = Activator.CreateInstance(type, this);
            if (obj is TMat mat)
                return mat;

            throw new NotSupportedException($"Failed to convert Mat to {typeof(TMat).Name}");
        }

        #region ForEach

// ReSharper disable InconsistentNaming

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsByte(MatForeachFunctionByte operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_uchar(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec2b(MatForeachFunctionVec2b operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec2b(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec3b(MatForeachFunctionVec3b operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec3b(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec4b(MatForeachFunctionVec4b operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec4b(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec6b(MatForeachFunctionVec6b operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec6b(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsInt16(MatForeachFunctionInt16 operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_short(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec2s(MatForeachFunctionVec2s operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec2s(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec3s(MatForeachFunctionVec3s operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec3s(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec4s(MatForeachFunctionVec4s operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec4s(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec6s(MatForeachFunctionVec6s operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec6s(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsInt32(MatForeachFunctionInt32 operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_int(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec2i(MatForeachFunctionVec2i operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec2i(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec3i(MatForeachFunctionVec3i operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec3i(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec4i(MatForeachFunctionVec4i operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec4i(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec6i(MatForeachFunctionVec6i operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec6i(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsFloat(MatForeachFunctionFloat operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_float(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec2f(MatForeachFunctionVec2f operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec2f(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec3f(MatForeachFunctionVec3f operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec3f(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec4f(MatForeachFunctionVec4f operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec4f(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec6f(MatForeachFunctionVec6f operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec6f(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsDouble(MatForeachFunctionDouble operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_double(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec2d(MatForeachFunctionVec2d operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec2d(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec3d(MatForeachFunctionVec3d operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec3d(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec4d(MatForeachFunctionVec4d operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec4d(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec6d(MatForeachFunctionVec6d operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.core_Mat_forEach_Vec6d(ptr, operation);
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

// ReSharper restore InconsistentNaming

        #endregion

        #endregion
    }
}
