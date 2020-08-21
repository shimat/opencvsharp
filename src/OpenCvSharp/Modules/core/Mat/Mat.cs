using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// OpenCV C++ n-dimensional dense array class (cv::Mat)
    /// </summary>
    public partial class Mat : DisposableCvObject
    {
        #region Init & Disposal

        /// <summary>
        /// typeof(T) -> MatType
        /// </summary>
        protected static readonly IReadOnlyDictionary<Type, MatType> TypeMap = new Dictionary<Type, MatType>
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_new1(out ptr));
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="m"></param>
        protected Mat(Mat m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            m.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_Mat_new12(m.ptr, out ptr));
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("imread failed.");
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

            NativeMethods.HandleException(
                NativeMethods.imgcodecs_imread(fileName, (int) flags, out ptr));
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_new2(rows, cols, type, out ptr));
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_new2(size.Height, size.Width, type, out ptr));
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_new3(rows, cols, type, s, out ptr));
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_new3(size.Height, size.Width, type, s, out ptr));
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
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            m.ThrowIfDisposed();

            if (colRange.HasValue)
                NativeMethods.HandleException(NativeMethods.core_Mat_new4(m.ptr, rowRange, colRange.Value, out ptr));
            else
                NativeMethods.HandleException(NativeMethods.core_Mat_new5(m.ptr, rowRange, out ptr));
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
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            if (ranges == null)
                throw new ArgumentNullException(nameof(ranges));
            if (ranges.Length == 0)
                throw new ArgumentException("empty ranges", nameof(ranges));
            m.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_Mat_new6(m.ptr, ranges, out ptr));
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
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            m.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_Mat_new7(m.ptr, roi, out ptr));
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_new8(rows, cols, type, data, new IntPtr(step), out ptr));
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_new8(rows, cols, type,
                handle.AddrOfPinnedObject(), new IntPtr(step), out ptr));
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
            var sizesArray = sizes.ToArray();
            if (steps == null)
            {
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_new9(sizesArray.Length, sizesArray, type, data, IntPtr.Zero, out ptr));
            }
            else
            {
                var stepsArray = steps.Select(s => new IntPtr(s)).ToArray();
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_new9(sizesArray.Length, sizesArray, type, data, stepsArray, out ptr));
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
            var sizesArray = sizes.ToArray();
            if (steps == null)
            {
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_new9(sizesArray.Length, sizesArray,
                        type, handle.AddrOfPinnedObject(), IntPtr.Zero, out ptr));
            }
            else
            {
                var stepsArray = steps.Select(s => new IntPtr(s)).ToArray();
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_new9(sizesArray.Length, sizesArray,
                        type, handle.AddrOfPinnedObject(), stepsArray, out ptr));
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

            var sizesArray = sizes.ToArray();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_new10(sizesArray.Length, sizesArray, type, out ptr));
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
            var sizesArray = sizes.ToArray();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_new11(sizesArray.Length, sizesArray, type, s, out ptr));
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
            if (ptr != IntPtr.Zero && IsEnabledDispose)
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_delete(ptr));
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

            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);

            return FromImageData(memoryStream.ToArray(), mode);
        }

#if LANG_JP
        /// <summary>
        /// 画像データ(JPEG等の画像をメモリに展開したもの)からMatを生成する (cv::imdecode)
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

        /// <summary>
        /// Reads image from the specified buffer in memory.
        /// </summary>
        /// <param name="span">The input slice of bytes.</param>
        /// <param name="mode">The same flags as in imread</param>
        /// <returns></returns>
        public static Mat ImDecode(ReadOnlySpan<byte> span, ImreadModes mode = ImreadModes.Color)
        {
            return Cv2.ImDecode(span, mode);
        }

#if LANG_JP
        /// <summary>
        /// 画像データ(JPEG等の画像をメモリに展開したもの)からMatを生成する (cv::imdecode)
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

        /// <summary>
        /// Reads image from the specified buffer in memory.
        /// </summary>
        /// <param name="span">The input slice of bytes.</param>
        /// <param name="mode">The same flags as in imread</param>
        /// <returns></returns>
        public static Mat FromImageData(ReadOnlySpan<byte> span, ImreadModes mode = ImreadModes.Color)
        {
            return Cv2.ImDecode(span, mode);
        }

        #endregion

        #endregion

        #region Static

        /// <summary>
        /// Extracts a diagonal from a matrix, or creates a diagonal matrix.
        /// </summary>
        /// <param name="d">One-dimensional matrix that represents the main diagonal.</param>
        /// <returns></returns>
        public static Mat Diag(Mat d)
        {
            if (d is null)            
                throw new ArgumentNullException(nameof(d));            

            NativeMethods.HandleException(
                NativeMethods.core_Mat_diag_static(d.CvPtr, out var ret));
            GC.KeepAlive(d);
            var retVal = new Mat(ret);
            return retVal;
        }
        
        /// <summary>
        /// Returns a zero array of the specified size and type.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="cols">Number of columns.</param>
        /// <param name="type">Created matrix type.</param>
        /// <returns></returns>
        public static MatExpr Zeros(int rows, int cols, MatType type)
        {
            NativeMethods.HandleException(
                NativeMethods.core_Mat_zeros1(rows, cols, type, out var ret));
            var retVal = new MatExpr(ret);
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
        /// <param name="sizes"></param>
        /// <returns></returns>
        public static MatExpr Zeros(MatType type, params int[] sizes)
        {
            if (sizes == null)
                throw new ArgumentNullException(nameof(sizes));

            NativeMethods.HandleException(
                NativeMethods.core_Mat_zeros2(sizes.Length, sizes, type, out var ret));
            var retVal = new MatExpr(ret);
            return retVal;
        }
        
        /// <summary>
        /// Returns an array of all 1’s of the specified size and type.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="cols">Number of columns.</param>
        /// <param name="type">Created matrix type.</param>
        /// <returns></returns>
        public static MatExpr Ones(int rows, int cols, MatType type)
        {
            NativeMethods.HandleException(
                NativeMethods.core_Mat_ones1(rows, cols, type, out var ret));
            var retVal = new MatExpr(ret);
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

            NativeMethods.HandleException(
                NativeMethods.core_Mat_ones2(sizes.Length, sizes, type, out var ret));
            var retVal = new MatExpr(ret);
            return retVal;
        }
        
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_eye(rows, cols, type, out var ret));
            var retVal = new MatExpr(ret);
            return retVal;
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
        public static Mat<TElem> FromArray<TElem>(params TElem[] arr)
            where TElem : unmanaged
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (arr.Length == 0)
                throw new ArgumentException("arr.Length == 0");

            var numElems = arr.Length /* / ThisChannels*/;
            var mat = new Mat<TElem>(numElems, 1);
            if (!mat.SetArray(arr))
                throw new OpenCvSharpException("Failed to copy pixel data into cv::Mat");
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
        public static Mat<TElem> FromArray<TElem>(TElem[,] arr)
            where TElem : unmanaged
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (arr.Length == 0)
                throw new ArgumentException("arr.Length == 0");

            var rows = arr.GetLength(0);
            var cols = arr.GetLength(1);
            var mat = new Mat<TElem>(rows, cols);
            if (!mat.SetRectangularArray(arr))
                throw new OpenCvSharpException("Failed to copy pixel data into cv::Mat");
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
        public static Mat<TElem> FromArray<TElem>(IEnumerable<TElem> enumerable)
            where TElem : unmanaged
        {
            return FromArray(enumerable.ToArray());
        }

        #endregion

        #endregion

        #region Operators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static MatExpr operator -(Mat mat)
        {
            if (mat is null)            
                throw new ArgumentNullException(nameof(mat));            

            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorUnaryMinus(mat.CvPtr, out var ret));
            GC.KeepAlive(mat);
            return new MatExpr(ret);
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

            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorAdd_MatMat(a.CvPtr, b.CvPtr, out var ret));
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(ret);
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

            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorAdd_MatScalar(a.CvPtr, s, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorAdd_ScalarMat(s, a.CvPtr, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
        }

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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorSubtract_MatMat(a.CvPtr, b.CvPtr, out var ret));
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorSubtract_MatScalar(a.CvPtr, s, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorSubtract_ScalarMat(s, a.CvPtr, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
        }

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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorMultiply_MatMat(a.CvPtr, b.CvPtr, out var ret));
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorMultiply_MatDouble(a.CvPtr, s, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorMultiply_DoubleMat(s, a.CvPtr, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
        }

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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorDivide_MatMat(a.CvPtr, b.CvPtr, out var ret));
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorDivide_MatDouble(a.CvPtr, s, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorDivide_DoubleMat(s, a.CvPtr, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
        }

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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorAnd_MatMat(a.CvPtr, b.CvPtr, out var ret));
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorAnd_MatDouble(a.CvPtr, s, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorAnd_DoubleMat(s, a.CvPtr, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
        }

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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorOr_MatMat(a.CvPtr, b.CvPtr, out var ret));
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorOr_MatDouble(a.CvPtr, s, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorOr_DoubleMat(s, a.CvPtr, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
        }

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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorXor_MatMat(a.CvPtr, b.CvPtr, out var ret));
            GC.KeepAlive(a);
            GC.KeepAlive(b);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorXor_MatDouble(a.CvPtr, s, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorXor_DoubleMat(s, a.CvPtr, out var ret));
            GC.KeepAlive(a);
            return new MatExpr(ret);
        }

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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorNot(m.CvPtr, out var ret));
            GC.KeepAlive(m);
            return new MatExpr(ret);
        }

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

            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorLT_MatMat(ptr, m.CvPtr, out var ret));
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            return new MatExpr(ret);
        }

        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr LessThan(double d)
        {
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorLT_MatDouble(ptr, d, out var ret));
            GC.KeepAlive(this);
            return new MatExpr(ret);
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

            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorLE_MatMat(ptr, m.CvPtr, out var ret));
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            return new MatExpr(ret);
        }

        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr LessThanOrEqual(double d)
        {
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorLE_MatDouble(ptr, d, out var ret));
            GC.KeepAlive(this);
            return new MatExpr(ret);
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

            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorEQ_MatMat(ptr, m.CvPtr, out var ret));
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            return new MatExpr(ret);
        }

        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr Equals(double d)
        {
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorEQ_MatDouble(ptr, d, out var ret));
            GC.KeepAlive(this);
            return new MatExpr(ret);
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

            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorNE_MatMat(ptr, m.CvPtr, out var ret));
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            return new MatExpr(ret);
        }

        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr NotEquals(double d)
        {
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorNE_MatDouble(ptr, d, out var ret));
            GC.KeepAlive(this);
            return new MatExpr(ret);
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

            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorGT_MatMat(ptr, m.CvPtr, out var ret));
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            return new MatExpr(ret);
        }

        /// <summary>
        /// operator &gt;
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr GreaterThan(double d)
        {
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorGT_MatDouble(ptr, d, out var ret));
            GC.KeepAlive(this);
            return new MatExpr(ret);
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

            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorGE_MatMat(ptr, m.CvPtr, out var ret));
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            return new MatExpr(ret);
        }

        /// <summary>
        /// operator &gt;=
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public MatExpr GreaterThanOrEqual(double d)
        {
            NativeMethods.HandleException(
                NativeMethods.core_Mat_operatorGE_MatDouble(ptr, d, out var ret));
            GC.KeepAlive(this);
            return new MatExpr(ret);
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
                if (Dims != value.Dims)
                    throw new ArgumentException("Dimension mismatch");

                var sub = SubMat(rowStart, rowEnd, colStart, colEnd);
                if (sub.Size() != value.Size())
                    throw new ArgumentException("Specified ROI != mat.Size()");
                value.CopyTo(sub);
            }
        }

#if NETCOREAPP3_1 || NETSTANDARD2_1
        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="rowRange">Start and end row of the extracted submatrix. The upper boundary is not included. 
        /// To select all the rows, use Range.All().</param>
        /// <param name="colRange">Start and end column of the extracted submatrix. 
        /// The upper boundary is not included. To select all the columns, use Range.All().</param>
        /// <returns></returns>
        public Mat this[System.Range rowRange, System.Range colRange]
        {
            get => SubMat(rowRange, colRange);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                value.ThrowIfDisposed();
                //if (Type() != value.Type())
                //    throw new ArgumentException("Mat type mismatch");
                if (Dims != value.Dims)
                    throw new ArgumentException("Dimension mismatch");

                var sub = SubMat(rowRange, colRange);
                if (sub.Size() != value.Size())
                    throw new ArgumentException("Specified ROI != mat.Size()");
                value.CopyTo(sub);
            }
        }
#endif

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="rowRange">Start and end row of the extracted submatrix. The upper boundary is not included. 
        /// To select all the rows, use Range.All().</param>
        /// <param name="colRange">Start and end column of the extracted submatrix. 
        /// The upper boundary is not included. To select all the columns, use Range.All().</param>
        /// <returns></returns>
        public Mat this[OpenCvSharp.Range rowRange, OpenCvSharp.Range colRange]
        {
            get => SubMat(rowRange, colRange);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                value.ThrowIfDisposed();
                //if (Type() != value.Type())
                //    throw new ArgumentException("Mat type mismatch");
                if (Dims != value.Dims)
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
                if (Dims != value.Dims)
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

                var dims = Dims;
                if (dims != value.Dims)
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
        
        /// <summary>
        /// Creates a matrix header for the specified matrix column.
        /// </summary>
        /// <param name="x">A 0-based column index.</param>
        /// <returns></returns>
        public Mat Col(int x)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_col(ptr, x, out var matPtr));
            return new Mat(matPtr);
        }

        /// <summary>
        /// Creates a matrix header for the specified column span.
        /// </summary>
        /// <param name="startCol">An inclusive 0-based start index of the column span.</param>
        /// <param name="endCol"> An exclusive 0-based ending index of the column span.</param>
        /// <returns></returns>
        public Mat ColRange(int startCol, int endCol)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_colRange(ptr, startCol, endCol, out var matPtr));
            GC.KeepAlive(this);
            return new Mat(matPtr);
        }

        /// <summary>
        /// Creates a matrix header for the specified column span.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Mat ColRange(OpenCvSharp.Range range)
        {
            return ColRange(range.Start, range.End);
        }

#if NETCOREAPP3_1 || NETSTANDARD2_1
        /// <summary>
        /// Creates a matrix header for the specified column span.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Mat ColRange(System.Range range)
        {
            var (colStart, colLength) = range.GetOffsetAndLength(Cols);
            return ColRange(colStart, colStart + colLength);
        }
#endif

        /// <summary>
        /// Creates a matrix header for the specified matrix row.
        /// </summary>
        /// <param name="y">A 0-based row index.</param>
        /// <returns></returns>
        public Mat Row(int y)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_row(ptr, y, out var matPtr));
            return new Mat(matPtr);
        }

        /// <summary>
        /// Creates a matrix header for the specified row span.
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <returns></returns>
        public Mat RowRange(int startRow, int endRow)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_rowRange(ptr, startRow, endRow, out var matPtr));
            GC.KeepAlive(this);
            return new Mat(matPtr);
        }

        /// <summary>
        ///  Creates a matrix header for the specified row span.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Mat RowRange(OpenCvSharp.Range range)
        {
            return RowRange(range.Start, range.End);
        }

#if NETCOREAPP3_1 || NETSTANDARD2_1
        /// <summary>
        ///  Creates a matrix header for the specified row span.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Mat RowRange(System.Range range)
        {
            var (rowStart, rowLength) = range.GetOffsetAndLength(Rows);
            return RowRange(rowStart, rowStart + rowLength);
        }
#endif

        /// <summary>
        /// Single-column matrix that forms a diagonal matrix or index of the diagonal, with the following values:
        /// </summary>
        /// <param name="d">Single-column matrix that forms a diagonal matrix or index of the diagonal, with the following values:</param>
        /// <returns></returns>
        public Mat Diag(MatDiagType d = MatDiagType.Main)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_diag(ptr, (int)d, out var ret));
            GC.KeepAlive(this);
            var retVal = new Mat(ret);
            return retVal;
        }

        /// <summary>
        /// Creates a full copy of the matrix.
        /// </summary>
        /// <returns></returns>
        public Mat Clone()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_clone(ptr, out var ret));
            GC.KeepAlive(this);
            var retVal = new Mat(ret);
            return retVal;
        }

        /// <summary>
        /// Returns the partial Mat of the specified Mat
        /// </summary>
        /// <param name="roi"></param>
        /// <returns></returns>
        public Mat Clone(Rect roi)
        {
            using var part = new Mat(this, roi);
            return part.Clone();
        }

        /// <summary>
        /// Copies the matrix to another one.
        /// </summary>
        /// <param name="m">Destination matrix. If it does not have a proper size or type before the operation, it is reallocated.</param>
        /// <param name="mask">Operation mask. Its non-zero elements indicate which matrix elements need to be copied.</param>
        public void CopyTo(OutputArray m, InputArray? mask = null)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            m.ThrowIfNotReady();
            mask?.ThrowIfDisposed();

            if (mask == null)
            {
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_copyTo1(ptr, m.CvPtr));
            }
            else
            {
                var maskPtr = Cv2.ToPtr(mask);
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_copyTo2(ptr, m.CvPtr, maskPtr));
            }

            GC.KeepAlive(this);
            m.Fix();
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// Copies the matrix to another one.
        /// </summary>
        /// <param name="m">Destination matrix. If it does not have a proper size or type before the operation, it is reallocated.</param>
        /// <param name="mask">Operation mask. Its non-zero elements indicate which matrix elements need to be copied.</param>
        public void CopyTo(Mat m, InputArray? mask = null)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            m.ThrowIfDisposed();
            mask?.ThrowIfDisposed();

            if (mask == null)
            {
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_copyTo_toMat1(ptr, m.CvPtr));
            }
            else
            {
                var maskPtr = Cv2.ToPtr(mask);
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_copyTo_toMat2(ptr, m.CvPtr, maskPtr));
            }

            GC.KeepAlive(this);
            GC.KeepAlive(m);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// Converts an array to another data type with optional scaling.
        /// </summary>
        /// <param name="m">output matrix; if it does not have a proper size or type before the operation, it is reallocated.</param>
        /// <param name="rtype">desired output matrix type or, rather, the depth since the number of channels are the same as the input has; 
        /// if rtype is negative, the output matrix will have the same type as the input.</param>
        /// <param name="alpha">optional scale factor.</param>
        /// <param name="beta">optional delta added to the scaled values.</param>
        public void ConvertTo(OutputArray m, MatType rtype, double alpha = 1, double beta = 0)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            m.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.core_Mat_convertTo(ptr, m.CvPtr, rtype, alpha, beta));

            GC.KeepAlive(this);
            m.Fix();
        }
        
        /// <summary>
        /// Provides a functional form of convertTo.
        /// </summary>
        /// <param name="m">Destination array.</param>
        /// <param name="type">Desired destination array depth (or -1 if it should be the same as the source type).</param>
        public void AssignTo(Mat m, MatType? type = null)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            NativeMethods.HandleException(
                NativeMethods.core_Mat_assignTo(ptr, m.CvPtr, type ?? -1));

            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }
        
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_setTo_Scalar(ptr, value, maskPtr));

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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_setTo_InputArray(ptr, value.CvPtr, maskPtr));

            GC.KeepAlive(this);
            GC.KeepAlive(value);
            GC.KeepAlive(mask);
            return this;
        }
        
        /// <summary>
        /// Changes the shape and/or the number of channels of a 2D matrix without copying the data.
        /// </summary>
        /// <param name="cn">New number of channels. If the parameter is 0, the number of channels remains the same.</param>
        /// <param name="rows">New number of rows. If the parameter is 0, the number of rows remains the same.</param>
        /// <returns></returns>
        public Mat Reshape(int cn, int rows = 0)
        {
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_Mat_reshape1(ptr, cn, rows, out var ret));

            GC.KeepAlive(this);
            var retVal = new Mat(ret);
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

            NativeMethods.HandleException(
                NativeMethods.core_Mat_reshape2(ptr, cn, newDims.Length, newDims, out var ret));

            GC.KeepAlive(this);
            var retVal = new Mat(ret);
            return retVal;
        }
        
        /// <summary>
        /// Transposes a matrix.
        /// </summary>
        /// <returns></returns>
        public MatExpr T()
        {
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_Mat_t(ptr, out var ret));

            GC.KeepAlive(this);
            var retVal = new MatExpr(ret);
            return retVal;
        }
        
        /// <summary>
        /// Inverses a matrix.
        /// </summary>
        /// <param name="method">Matrix inversion method</param>
        /// <returns></returns>
        public MatExpr Inv(DecompTypes method = DecompTypes.LU)
        {
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_Mat_inv(ptr, (int) method, out var ret));

            GC.KeepAlive(this);
            var retVal = new MatExpr(ret);
            return retVal;
        }
        
        /// <summary>
        /// Performs an element-wise multiplication or division of the two matrices.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public MatExpr Mul(InputArray m, double scale = 1)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            m.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_Mat_mul(ptr, m.CvPtr, scale, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(m);
            var retVal = new MatExpr(ret);
            return retVal;
        }

        /// <summary>
        /// Computes a cross-product of two 3-element vectors.
        /// </summary>
        /// <param name="m">Another cross-product operand.</param>
        /// <returns></returns>
        public Mat Cross(InputArray m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            m.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_Mat_cross(ptr, m.CvPtr, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(m);
            var retVal = new Mat(ret);
            return retVal;
        }
        
        /// <summary>
        /// Computes a dot-product of two vectors.
        /// </summary>
        /// <param name="m">another dot-product operand.</param>
        /// <returns></returns>
        public double Dot(InputArray m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            m.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_Mat_dot(ptr, m.CvPtr, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(m);
            return ret;
        }
        
        /// <summary>
        /// Allocates new array data if needed.
        /// </summary>
        /// <param name="rows">New number of rows.</param>
        /// <param name="cols">New number of columns.</param>
        /// <param name="type">New matrix type.</param>
        public void Create(int rows, int cols, MatType type)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_create1(ptr, rows, cols, type));
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_create2(ptr, sizes.Length, sizes, type));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Reserves space for the certain number of rows.
        ///
        /// The method reserves space for sz rows. If the matrix already has enough space to store sz rows,
        /// nothing happens. If the matrix is reallocated, the first Mat::rows rows are preserved. The method
        /// emulates the corresponding method of the STL vector class.
        /// </summary>
        /// <param name="sz">Number of rows.</param>
        public void Reserve(int sz)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_reserve(ptr, new IntPtr(sz)));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Reserves space for the certain number of bytes.
        ///
        /// The method reserves space for sz bytes. If the matrix already has enough space to store sz bytes,
        /// nothing happens. If matrix has to be reallocated its previous content could be lost.
        /// </summary>
        /// <param name="sz">Number of bytes.</param>
        public void ReserveBuffer(int sz)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_reserveBuffer(ptr, new IntPtr(sz)));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Changes the number of matrix rows.
        /// </summary>
        /// <param name="sz">New number of rows.</param>
        public void Resize(int sz)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_resize1(ptr, new IntPtr(sz)));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Changes the number of matrix rows.
        /// </summary>
        /// <param name="sz">New number of rows.</param>
        /// <param name="s">Value assigned to the newly added elements.</param>
        public void Resize(int sz, Scalar s)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_resize2(ptr, new IntPtr(sz), s));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// removes several hyper-planes from bottom of the matrix (Mat.pop_back)
        /// </summary>
        /// <param name="nElems"></param>
        public void PopBack(int nElems = 1)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_pop_back(ptr, new IntPtr(nElems)));
            GC.KeepAlive(this);
        }
        
        #region PushBack
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(byte value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_uchar(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(sbyte value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_char(ptr, value));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(ushort value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_ushort(ptr, value));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(short value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_short(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(int value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_int(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(float value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_float(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(double value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_double(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec2b value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec2b(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec3b value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec3b(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec4b value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec4b(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec6b value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec6b(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec2w value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec2w(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec3w value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec3w(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec4w value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec4w(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec6w value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec6w(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec2s value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec2s(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec3s value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec3s(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec4s value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec4s(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec6s value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec6s(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec2i value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec2i(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec3i value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec3i(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec4i value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec4i(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec6i value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec6i(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec2f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec2f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec3f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec3f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec4f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec4f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec6f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec6f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec2d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec2d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec3d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec3d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec4d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec4d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Vec6d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec6d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Point value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Point(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Point2d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Point2d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Point2f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Point2f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Point3i value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Point3i(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Point3d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Point3d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Point3f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Point3f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Size value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Size(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Size2d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Size2d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Size2f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Size2f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Rect value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Rect(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Rect2d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Rect2d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void Add(Rect2f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Rect2f(ptr, value));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(byte value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_uchar(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(sbyte value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_char(ptr, value));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(ushort value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_ushort(ptr, value));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(short value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_short(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(int value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_int(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(float value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_float(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(double value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_double(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec2b value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec2b(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec3b value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec3b(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec4b value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec4b(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec6b value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec6b(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec2w value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec2w(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec3w value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec3w(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec4w value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec4w(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec6w value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec6w(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec2s value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec2s(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec3s value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec3s(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec4s value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec4s(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec6s value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec6s(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec2i value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec2i(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec3i value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec3i(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec4i value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec4i(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec6i value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec6i(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec2f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec2f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec3f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec3f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec4f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec4f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec6f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec6f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec2d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec2d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec3d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec3d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec4d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec4d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Vec6d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Vec6d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Point value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Point(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Point2d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Point2d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Point2f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Point2f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Point3i value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Point3i(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Point3d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Point3d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Point3f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Point3f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Size value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Size(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Size2d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Size2d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Size2f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Size2f(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Rect value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Rect(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Rect2d value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Rect2d(ptr, value));
            GC.KeepAlive(this);
        }
        
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element</param>
        public void PushBack(Rect2f value)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.core_Mat_push_back_Rect2f(ptr, value));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat.push_back)
        /// </summary>
        /// <param name="m">Added line(s)</param>
        public void Add(Mat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            m.ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_push_back_Mat(ptr, m.CvPtr));
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

        /// <summary>
        /// Locates the matrix header within a parent matrix.
        /// </summary>
        /// <param name="wholeSize">Output parameter that contains the size of the whole matrix containing *this as a part.</param>
        /// <param name="ofs">Output parameter that contains an offset of *this inside the whole matrix.</param>
        // ReSharper disable once InconsistentNaming
        public void LocateROI(out Size wholeSize, out Point ofs)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_locateROI(ptr, out wholeSize, out ofs));
            GC.KeepAlive(this);
        }

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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_adjustROI(ptr, dtop, dbottom, dleft, dright, out var ret));
            GC.KeepAlive(this);
            var retVal = new Mat(ret);
            return retVal;
        }
        
        /// <summary>
        /// Extracts a rectangular submatrix.
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_subMat1(ptr, rowStart, rowEnd, colStart, colEnd, out var ret));
            GC.KeepAlive(this);
            var retVal = new Mat(ret);
            return retVal;
        }

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="rowRange">Start and end row of the extracted submatrix. The upper boundary is not included.
        /// To select all the rows, use Range::all().</param>
        /// <param name="colRange">Start and end column of the extracted submatrix. The upper boundary is not included.
        /// To select all the columns, use Range::all().</param>
        /// <returns></returns>
        public Mat SubMat(OpenCvSharp.Range rowRange, OpenCvSharp.Range colRange)
        {
            return SubMat(rowRange.Start, rowRange.End, colRange.Start, colRange.End);
        }

#if NETCOREAPP3_1 || NETSTANDARD2_1
        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="rowRange">Start and end row of the extracted submatrix. The upper boundary is not included.
        /// To select all the rows, use Range::all().</param>
        /// <param name="colRange">Start and end column of the extracted submatrix. The upper boundary is not included.
        /// To select all the columns, use Range::all().</param>
        /// <returns></returns>
        public Mat SubMat(System.Range rowRange, System.Range colRange)
        {
            var (rowStart, rowLength) = rowRange.GetOffsetAndLength(Rows);
            var (colStart, colLength) = colRange.GetOffsetAndLength(Cols);
            return SubMat(rowStart, rowStart + rowLength, colStart, colStart + colLength);
        }
#endif

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="roi">Extracted submatrix specified as a rectangle.</param>
        /// <returns></returns>
        public Mat SubMat(Rect roi)
        {
            return SubMat(roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);
        }

        /// <summary>
        /// Extracts a rectangular submatrix.
        /// </summary>
        /// <param name="ranges">Array of selected ranges along each array dimension.</param>
        /// <returns></returns>
        public Mat SubMat(params Range[] ranges)
        {
            if (ranges == null)
                throw new ArgumentNullException(nameof(ranges));
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_Mat_subMat2(ptr, ranges.Length, ranges, out var ret));
            var retVal = new Mat(ret);
            GC.KeepAlive(this);
            return retVal;
        }

        /// <summary>
        /// Reports whether the matrix is continuous or not.
        /// </summary>
        /// <returns></returns>
        public bool IsContinuous()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_isContinuous(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        
        /// <summary>
        /// Returns whether this matrix is a part of other matrix or not.
        /// </summary>
        /// <returns></returns>
        public bool IsSubmatrix()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_isSubmatrix(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// Returns the matrix element size in bytes.
        /// </summary>
        /// <returns></returns>
        public int ElemSize()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_elemSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret.ToInt32();
        }

        /// <summary>
        /// Returns the size of each matrix element channel in bytes.
        /// </summary>
        /// <returns></returns>
        public int ElemSize1()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_elemSize1(ptr, out var ret));
            GC.KeepAlive(this);
            return ret.ToInt32();
        }
        
        /// <summary>
        /// Returns the type of a matrix element.
        /// </summary>
        /// <returns></returns>
        public MatType Type()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_type(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// Returns the depth of a matrix element.
        /// </summary>
        /// <returns></returns>
        public int Depth()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_depth(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// Returns the number of matrix channels.
        /// </summary>
        /// <returns></returns>
        public int Channels()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_channels(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        
        /// <summary>
        /// Returns a normalized step.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Step1(int i = 0)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_step1(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret.ToInt64();
        }
        
        /// <summary>
        /// Returns true if the array has no elements.
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_empty(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        
        /// <summary>
        /// Returns the total number of array elements.
        /// </summary>
        /// <returns></returns>
        public long Total()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_total1(ptr, out var ret));
            GC.KeepAlive(this);
            return ret.ToInt64();
        }

        /// <summary>
        /// Returns the total number of array elements.
        /// The method returns the number of elements within a certain sub-array slice with startDim &lt;= dim &lt; endDim
        /// </summary>
        /// <param name="startDim"></param>
        /// <param name="endDim"></param>
        /// <returns></returns>
        public long Total(int startDim, int endDim = int.MaxValue)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_total2(ptr, startDim, endDim, out var ret));
            GC.KeepAlive(this);
            return ret.ToInt64();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemChannels">Number of channels or number of columns the matrix should have.
        /// For a 2-D matrix, when the matrix has only 1 column, then it should have
        /// elemChannels channels; When the matrix has only 1 channel,
        /// then it should have elemChannels columns. For a 3-D matrix, it should have only one channel.
        /// Furthermore, if the number of planes is not one, then the number of rows within every
        /// plane has to be 1; if the number of rows within every plane is not 1,
        /// then the number of planes has to be 1.</param>
        /// <param name="depth">The depth the matrix should have. Set it to -1 when any depth is fine.</param>
        /// <param name="requireContinuous">Set it to true to require the matrix to be continuous</param>
        /// <returns>-1 if the requirement is not satisfied.
        /// Otherwise, it returns the number of elements in the matrix. Note that an element may have multiple channels.</returns>
        public int CheckVector(int elemChannels, int depth = -1, bool requireContinuous = true)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_checkVector(
                    ptr, elemChannels, depth, requireContinuous ? 1 : 0, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

#pragma warning disable CA1720 // Identifiers should not contain type names

        /// <summary>
        /// Returns a pointer to the specified matrix row.
        /// </summary>
        /// <param name="i0">Index along the dimension 0</param>
        /// <returns></returns>
        public IntPtr Ptr(int i0)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_ptr1d(ptr, i0, out var ret));
            GC.KeepAlive(this);
            return ret;
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_ptr2d(ptr, i0, i1, out var ret));
            GC.KeepAlive(this);
            return ret;
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
            NativeMethods.HandleException(
                NativeMethods.core_Mat_ptr3d(ptr, i0, i1, i2, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// Returns a pointer to the specified matrix element.
        /// </summary>
        /// <param name="idx">Array of Mat::dims indices.</param>
        /// <returns></returns>
        public IntPtr Ptr(params int[] idx)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_ptrnd(ptr, idx, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        
#pragma warning restore CA1720 // Identifiers should not contain type names

        /// <summary>
        /// includes several bit-fields:
        /// - the magic signature
        /// - continuity flag
        /// - depth
        /// - number of channels
        /// </summary>
        public int Flags
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_flags(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// the array dimensionality, >= 2
        /// </summary>
        public int Dims
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_dims(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }
        
        /// <summary>
        /// the number of rows or -1 when the array has more than 2 dimensions
        /// </summary>
        public int Rows
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_rows(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// the number of rows or -1 when the array has more than 2 dimensions
        /// </summary>
        /// <returns></returns>
        public int Height => Rows;

        /// <summary>
        /// the number of columns or -1 when the array has more than 2 dimensions
        /// </summary>
        /// <returns></returns>
        public int Cols
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_cols(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// the number of columns or -1 when the array has more than 2 dimensions
        /// </summary>
        /// <returns></returns>
        public int Width => Cols;

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
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_data(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
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
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_datastart(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
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
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_dataend(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
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
                NativeMethods.HandleException(
                    NativeMethods.core_Mat_datalimit(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Returns a matrix size.
        /// </summary>
        /// <returns></returns>
        public Size Size()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_size(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// Returns a matrix size.
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        public int Size(int dim)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_sizeAt(ptr, dim, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        
        /// <summary>
        /// Returns number of bytes each matrix row occupies.
        /// </summary>
        /// <returns></returns>
        public long Step()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_step(ptr, out var ret));
            GC.KeepAlive(this);
            return ret.ToInt64();
        }

        /// <summary>
        /// Returns number of bytes each matrix row occupies.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Step(int i)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Mat_stepAt(ptr, i, out var ret));
            GC.KeepAlive(this);
            return ret.ToInt64();
        }

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
                    return Marshal.PtrToStructure<T>(p);
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
                    return Marshal.PtrToStructure<T>(p);
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
                    return Marshal.PtrToStructure<T>(p);
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
                    return Marshal.PtrToStructure<T>(p);
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
            var p = Ptr(i0);
            return Marshal.PtrToStructure<T>(p);
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
            var p = Ptr(i0, i1);
            return Marshal.PtrToStructure<T>(p);
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
            var p = Ptr(i0, i1, i2);
            return Marshal.PtrToStructure<T>(p);
        }

        /// <summary>
        /// Returns a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="idx">Array of Mat::dims indices.</param>
        /// <returns>A value to the specified array element.</returns>
        public T Get<T>(params int[] idx) where T : struct
        {
            var p = Ptr(idx);
            return Marshal.PtrToStructure<T>(p);
        }

        /// <summary>
        /// Returns a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0">Index along the dimension 0</param>
        /// <returns>A value to the specified array element.</returns>
        public unsafe ref T At<T>(int i0) where T : unmanaged
        {
            var p = Ptr(i0);
            return ref Unsafe.AsRef<T>(p.ToPointer());
        }

        /// <summary>
        /// Returns a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <returns>A value to the specified array element.</returns>
        public unsafe ref T At<T>(int i0, int i1) where T : unmanaged
        {
            var p = Ptr(i0, i1);
            return ref Unsafe.AsRef<T>(p.ToPointer());
        }

        /// <summary>
        /// Returns a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <param name="i2">Index along the dimension 2</param>
        /// <returns>A value to the specified array element.</returns>
        public unsafe ref T At<T>(int i0, int i1, int i2) where T : unmanaged
        {
            var p = Ptr(i0, i1, i2);
            return ref Unsafe.AsRef<T>(p.ToPointer());
        }

        /// <summary>
        /// Returns a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="idx">Array of Mat::dims indices.</param>
        /// <returns>A value to the specified array element.</returns>
        public unsafe ref T At<T>(params int[] idx) where T : unmanaged
        {
            var p = Ptr(idx);
            return ref Unsafe.AsRef<T>(p.ToPointer());
        }

        /// <summary>
        /// Set a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="value"></param>
        public void Set<T>(int i0, T value) where T : struct
        {
            var p = Ptr(i0);
            Marshal.StructureToPtr(value, p, false);
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
            var p = Ptr(i0, i1);
            Marshal.StructureToPtr(value, p, false);
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
            var p = Ptr(i0, i1, i2);
            Marshal.StructureToPtr(value, p, false);
        }

        /// <summary>
        /// Set a value to the specified array element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="idx">Array of Mat::dims indices.</param>
        /// <param name="value"></param>
        public void Set<T>(int[] idx, T value) where T : struct
        {
            var p = Ptr(idx);
            Marshal.StructureToPtr(value, p, false);
        }

        #endregion
        
        #region Get/SetArray

        private static readonly Dictionary<Type, int> dataDimensionMap = new Dictionary<Type, int>
        {
            {typeof(byte), 1},
            {typeof(sbyte), 1},
            {typeof(short), 1},
            {typeof(ushort), 1},
            {typeof(int), 1},
            {typeof(float), 1},
            {typeof(double), 1},
            {typeof(Point), 2},
            {typeof(Point2f), 2},
            {typeof(Point2d), 2},
            {typeof(Point3i), 3},
            {typeof(Point3f), 3},
            {typeof(Point3d), 3},
            {typeof(Size), 2},
            {typeof(Size2f), 2},
            {typeof(Size2d), 2},
            {typeof(Rect), 4},
            {typeof(Rect2f), 4},
            {typeof(Rect2d), 4},
            //{typeof(DMatch), 4},
            {typeof(Vec2b), 2},
            {typeof(Vec2s), 2},
            {typeof(Vec2w), 2},
            {typeof(Vec2i), 2},
            {typeof(Vec2f), 2},
            {typeof(Vec2d), 2},
            {typeof(Vec3b), 3},
            {typeof(Vec3s), 3},
            {typeof(Vec3w), 3},
            {typeof(Vec3i), 3},
            {typeof(Vec3f), 3},
            {typeof(Vec3d), 3},
            {typeof(Vec4b), 4},
            {typeof(Vec4s), 4},
            {typeof(Vec4w), 4},
            {typeof(Vec4i), 4},
            {typeof(Vec4f), 4},
            {typeof(Vec4d), 4},
            {typeof(Vec6b), 6},
            {typeof(Vec6s), 6},
            {typeof(Vec6w), 6},
            {typeof(Vec6i), 6},
            {typeof(Vec6f), 6},
            {typeof(Vec6d), 6},
        };
        
        private static readonly Dictionary<Type, MatType[]> acceptableTypesMap = new Dictionary<Type, MatType[]>
        {
            {typeof(byte), new[]{MatType.CV_8SC1, MatType.CV_8UC1}},
            {typeof(sbyte), new[]{MatType.CV_8SC1, MatType.CV_8UC1}},
            {typeof(short), new[]{MatType.CV_16SC1, MatType.CV_16UC1}},
            {typeof(ushort), new[]{MatType.CV_16SC1, MatType.CV_16UC1}},
            {typeof(int), new[]{MatType.CV_32SC1}},
            {typeof(float), new[]{MatType.CV_32FC1}},
            {typeof(double), new[]{MatType.CV_64FC1}},
            {typeof(Point), new[]{MatType.CV_32SC2}},
            {typeof(Point2f), new[]{MatType.CV_32FC2}},
            {typeof(Point2d), new[]{MatType.CV_64FC2}},
            {typeof(Point3i), new[]{MatType.CV_32SC3}},
            {typeof(Point3f), new[]{MatType.CV_32FC3}},
            {typeof(Point3d), new[]{MatType.CV_64FC3}},
            {typeof(Size), new[]{MatType.CV_32SC2}},
            {typeof(Size2f), new[]{MatType.CV_32FC2}},
            {typeof(Size2d), new[]{MatType.CV_64FC2}},
            {typeof(Rect), new[]{MatType.CV_32SC4}},
            {typeof(Rect2f), new[]{MatType.CV_32FC4}},
            {typeof(Rect2d), new[]{MatType.CV_64FC4}},
            //{typeof(DMatch), new[]{MatType.CV_32FC4}},
            {typeof(Vec2b), new[]{MatType.CV_8UC2}},
            {typeof(Vec2s), new[]{MatType.CV_16SC2}},
            {typeof(Vec2w), new[]{MatType.CV_16UC2}},
            {typeof(Vec2i), new[]{MatType.CV_32SC2}},
            {typeof(Vec2f), new[]{MatType.CV_32FC2}},
            {typeof(Vec2d), new[]{MatType.CV_64FC2}},
            {typeof(Vec3b), new[]{MatType.CV_8UC3}},
            {typeof(Vec3s), new[]{MatType.CV_16SC3}},
            {typeof(Vec3w), new[]{MatType.CV_16UC3}},
            {typeof(Vec3i), new[]{MatType.CV_32SC3}},
            {typeof(Vec3f), new[]{MatType.CV_32FC3}},
            {typeof(Vec3d), new[]{MatType.CV_64FC3}},
            {typeof(Vec4b), new[]{MatType.CV_8UC4}},
            {typeof(Vec4s), new[]{MatType.CV_16SC4}},
            {typeof(Vec4w), new[]{MatType.CV_16UC4}},
            {typeof(Vec4i), new[]{MatType.CV_32SC4}},
            {typeof(Vec4f), new[]{MatType.CV_32FC4}},
            {typeof(Vec4d), new[]{MatType.CV_64FC4}},
            {typeof(Vec6b), new[]{MatType.CV_8UC(6)}},
            {typeof(Vec6s), new[]{MatType.CV_16SC(6)}},
            {typeof(Vec6w), new[]{MatType.CV_16UC(6)}},
            {typeof(Vec6i), new[]{MatType.CV_32SC(6)}},
            {typeof(Vec6f), new[]{MatType.CV_32FC(6)}},
            {typeof(Vec6d), new[]{MatType.CV_64FC(6)}},
        };

        private void CheckArgumentsForConvert<T>(Array data)
            where T : unmanaged
        {
            ThrowIfDisposed();

            if (data == null)
                throw new ArgumentNullException(nameof(data));

            if (!dataDimensionMap.TryGetValue(typeof(T), out var dataDimension))
                throw new ArgumentException($"Type argument {typeof(T)} is not supported");
            if (!acceptableTypesMap.TryGetValue(typeof(T), out var acceptableTypes))
                throw new ArgumentException($"Type argument {typeof(T)} is not supported");

            var t = Type();
            if ((data.Length * dataDimension) % t.Channels != 0)
                throw new OpenCvSharpException(
                    $"Provided data element number ({data.Length}) should be multiple of the Mat channels count ({t.Channels})");

            if (acceptableTypes != null && acceptableTypes.Length > 0)
            {
                var isValidDepth = acceptableTypes.Any(type => type == t);
                if (!isValidDepth)
                    throw new OpenCvSharpException("Mat data type is not compatible: " + t);
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="data">Primitive or Vec array to be copied</param>
        /// <returns>Length of copied bytes</returns>
        /// <example>
        /// using var m1 = new Mat(1, 1, MatType.CV_8UC1);
        /// m1.GetArray(out byte[] array);
        ///
        /// using var m2 = new Mat(1, 1, MatType.CV_32SC1);
        /// m2.GetArray(out int[] array);
        ///
        /// using var m3 = new Mat(1, 1, MatType.CV_8UC(6));
        /// m3.GetArray(out Vec6b[] array);
        ///
        /// using var m4 = new Mat(1, 1, MatType.CV_64FC4);
        /// m4.GetArray(out Vec4d[] array);
        /// </example>
        [Pure]
        public bool GetArray<T>(out T[] data)
            where T : unmanaged
        {
            data = new T[(long)Rows * Cols];

            CheckArgumentsForConvert<T>(data);

            unsafe
            {
                fixed (T* pData = data)
                {
                    NativeMethods.HandleException(
                        NativeMethods.core_Mat_getMatData(ptr, (byte*)pData, out var success));
                    GC.KeepAlive(this);
                    return success != 0;
                }
            }
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="data">Primitive or Vec array to be copied</param>
        /// <returns>Length of copied bytes</returns>
        /// <example>
        /// using var m1 = new Mat(1, 1, MatType.CV_8UC1);
        /// m1.GetRectangularArray(out byte[,] array);
        ///
        /// using var m2 = new Mat(1, 1, MatType.CV_32SC1);
        /// m2.GetRectangularArray(out int[,] array);
        ///
        /// using var m3 = new Mat(1, 1, MatType.CV_8UC(6));
        /// m3.GetRectangularArray(out Vec6b[,] array);
        ///
        /// using var m4 = new Mat(1, 1, MatType.CV_64FC4);
        /// m4.GetRectangularArray(out Vec4d[,] array);
        /// </example>
        [Pure]
        public bool GetRectangularArray<T>(out T[,] data)
            where T : unmanaged
        {
            data = new T[Rows, Cols];

            CheckArgumentsForConvert<T>(data);

            unsafe
            {
                fixed (T* pData = data)
                {
                    NativeMethods.HandleException(
                        NativeMethods.core_Mat_getMatData(ptr, (byte*)pData, out var success));
                    GC.KeepAlive(this);
                    return success != 0;
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="data">Primitive or Vec array to be copied</param>
        /// <returns>Length of copied bytes</returns>
        public bool SetArray<T>(T[] data)
            where T : unmanaged
        {
            CheckArgumentsForConvert<T>(data);

            unsafe
            {
                fixed (T* pData = data)
                {
                    NativeMethods.HandleException(
                        NativeMethods.core_Mat_setMatData(ptr, (byte*)pData, out var success));
                    GC.KeepAlive(this);
                    return success != 0;
                }
            }
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="data">Primitive or Vec array to be copied</param>
        /// <returns>Length of copied bytes</returns>
        public bool SetRectangularArray<T>(T[,] data)
            where T : unmanaged
        {
            CheckArgumentsForConvert<T>(data);

            unsafe
            {
                fixed (T* pData = data)
                {
                    NativeMethods.HandleException(
                        NativeMethods.core_Mat_setMatData(ptr, (byte*)pData, out var success));
                    GC.KeepAlive(this);
                    return success != 0;
                }
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Mat Alignment(int n = 4)
        {
            var newCols = Cv2.AlignSize(Cols, n);
            using var pMat = new Mat(Rows, newCols, Type());
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
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsByte(MatForeachFunctionByte operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(
                NativeMethods.core_Mat_forEach_uchar(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec2b(MatForeachFunctionVec2b operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(
                NativeMethods.core_Mat_forEach_Vec2b(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec3b(MatForeachFunctionVec3b operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(
                NativeMethods.core_Mat_forEach_Vec3b(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec4b(MatForeachFunctionVec4b operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException( 
                NativeMethods.core_Mat_forEach_Vec4b(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec6b(MatForeachFunctionVec6b operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(
                NativeMethods.core_Mat_forEach_Vec6b(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsInt16(MatForeachFunctionInt16 operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException( 
                NativeMethods.core_Mat_forEach_short(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec2s(MatForeachFunctionVec2s operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException( 
                NativeMethods.core_Mat_forEach_Vec2s(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec3s(MatForeachFunctionVec3s operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(  
                NativeMethods.core_Mat_forEach_Vec3s(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec4s(MatForeachFunctionVec4s operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(   
                NativeMethods.core_Mat_forEach_Vec4s(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec6s(MatForeachFunctionVec6s operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(  
                NativeMethods.core_Mat_forEach_Vec6s(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsInt32(MatForeachFunctionInt32 operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(
                NativeMethods.core_Mat_forEach_int(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec2i(MatForeachFunctionVec2i operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException( 
                NativeMethods.core_Mat_forEach_Vec2i(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec3i(MatForeachFunctionVec3i operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(
                NativeMethods.core_Mat_forEach_Vec3i(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec4i(MatForeachFunctionVec4i operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException( 
                NativeMethods.core_Mat_forEach_Vec4i(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec6i(MatForeachFunctionVec6i operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(  
                NativeMethods.core_Mat_forEach_Vec6i(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsFloat(MatForeachFunctionFloat operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(  
                NativeMethods.core_Mat_forEach_float(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec2f(MatForeachFunctionVec2f operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException( 
                NativeMethods.core_Mat_forEach_Vec2f(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec3f(MatForeachFunctionVec3f operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(  
                NativeMethods.core_Mat_forEach_Vec3f(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec4f(MatForeachFunctionVec4f operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(  
                NativeMethods.core_Mat_forEach_Vec4f(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec6f(MatForeachFunctionVec6f operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException( 
                NativeMethods.core_Mat_forEach_Vec6f(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }


        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsDouble(MatForeachFunctionDouble operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException( 
                NativeMethods.core_Mat_forEach_double(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec2d(MatForeachFunctionVec2d operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(  
                NativeMethods.core_Mat_forEach_Vec2d(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec3d(MatForeachFunctionVec3d operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(  
                NativeMethods.core_Mat_forEach_Vec3d(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec4d(MatForeachFunctionVec4d operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException( 
                NativeMethods.core_Mat_forEach_Vec4d(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

        /// <summary>
        /// Runs the given functor over all matrix elements in parallel.
        /// </summary>
        /// <param name="operation"></param>
        public void ForEachAsVec6d(MatForeachFunctionVec6d operation)
        {
            ThrowIfDisposed();
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            NativeMethods.HandleException(
                NativeMethods.core_Mat_forEach_Vec6d(ptr, operation));
            GC.KeepAlive(this);
            GC.KeepAlive(operation);
        }

// ReSharper restore InconsistentNaming

        #endregion

        #endregion
    }
}
