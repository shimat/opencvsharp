using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// A matrix whose element is cv::DMatch (cv::Mat_&lt;cv::Vec4f&gt;)
    /// </summary>
    public class MatOfDMatch : Mat<DMatch, MatOfDMatch>
    {
        private static readonly MatType ThisType = MatType.CV_32FC4;
        private const int ThisDepth = MatType.CV_32F; // int x 3, float x 1
        private const int ThisChannels = 4;

        #region Init

#if LANG_JP
        /// <summary>
        /// Creates empty Mat
        /// </summary>
#else
        /// <summary>
        /// Creates empty Mat
        /// </summary>
#endif
        public MatOfDMatch()
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
        public MatOfDMatch(IntPtr ptr)
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
        public MatOfDMatch(Mat mat)
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
        public MatOfDMatch(int rows, int cols)
            : base(rows, cols, ThisType)
        {
        }

#if LANG_JP
        /// <summary>
        /// 指定したサイズ・型の2次元の行列として初期化
        /// </summary>
        /// <param name="size">2次元配列のサイズ： Size(cols, rows) ． 
        /// Size コンストラクタでは，行数と列数が逆順になっていることに注意してください．</param>
#else
        /// <summary>
        /// constructs 2D matrix of the specified size and type
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) . In the Size() constructor, 
        /// the number of rows and the number of columns go in the reverse order.</param>
#endif
        public MatOfDMatch(Size size)
            : base(size, ThisType)
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
        public MatOfDMatch(int rows, int cols, DMatch s)
            : base(rows, cols, ThisType, (Scalar)s)
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
        public MatOfDMatch(Size size, DMatch s)
            : base(size, ThisType, (Scalar)s)
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
        public MatOfDMatch(MatOfDMatch m, Range rowRange, Range? colRange = null)
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
        public MatOfDMatch(MatOfDMatch m, params Range[] ranges)
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
        public MatOfDMatch(MatOfDMatch m, Rect roi)
            : base(m, roi)
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
        public MatOfDMatch(IEnumerable<int> sizes)
            : base(sizes, ThisType)
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
        public MatOfDMatch(IEnumerable<int> sizes, DMatch s)
            : base(sizes, ThisType, (Scalar)s)
        {
        }
        #endregion

        #region Indexer
        /// <summary>
        /// Matrix indexer
        /// </summary>
        public sealed unsafe class Indexer : MatIndexer<DMatch>
        {
            private readonly byte* ptr;

            internal Indexer(Mat parent)
                : base(parent)
            {
                this.ptr = (byte*)parent.Data.ToPointer();
            }
            /// <summary>
            /// 1-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <returns>A value to the specified array element.</returns>
            public override DMatch this[int i0]
            {
                get
                {
                    return (DMatch)(*(Vec4f*)(ptr + (steps[0] * i0)));
                }
                set
                {
                    *(Vec4f*)(ptr + (steps[0] * i0)) = (Vec4f)value;
                }
            }
            /// <summary>
            /// 2-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <param name="i1">Index along the dimension 1</param>
            /// <returns>A value to the specified array element.</returns>
            public override DMatch this[int i0, int i1]
            {
                get
                {
                    return (DMatch)(*(Vec4f*)(ptr + (steps[0] * i0) + (steps[1] * i1)));
                }
                set
                {
                    *(Vec4f*)(ptr + (steps[0] * i0) + (steps[1] * i1)) = (Vec4f)value;
                }
            }
            /// <summary>
            /// 3-dimensional indexer
            /// </summary>
            /// <param name="i0">Index along the dimension 0</param>
            /// <param name="i1">Index along the dimension 1</param>
            /// <param name="i2"> Index along the dimension 2</param>
            /// <returns>A value to the specified array element.</returns>
            public override DMatch this[int i0, int i1, int i2]
            {
                get
                {
                    return (DMatch)(*(Vec4f*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2)));
                }
                set
                {
                    *(Vec4f*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2)) = (Vec4f)value;
                }
            }
            /// <summary>
            /// n-dimensional indexer
            /// </summary>
            /// <param name="idx">Array of Mat::dims indices.</param>
            /// <returns>A value to the specified array element.</returns>
            public override DMatch this[params int[] idx]
            {
                get
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    return (DMatch)(*(Vec4f*)(ptr + offset));
                }
                set
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    *(Vec4f*)(ptr + offset) = (Vec4f)value;
                }
            }
        }
        /// <summary>
        /// Gets a type-specific indexer. The indexer has getters/setters to access each matrix element.
        /// </summary>
        /// <returns></returns>
        public override MatIndexer<DMatch> GetIndexer() 
        {
            return new Indexer(this);
        }
        #endregion

        #region FromArray
#if LANG_JP
        /// <summary>
        /// N x 1 の行列(ベクトル)として初期化し、指定した配列からデータをコピーする
        /// </summary>
        /// <param name="arr">この行列にコピーされるデータ</param>
#else
        /// <summary>
        /// Initializes as N x 1 matrix and copys array data to this
        /// </summary>
        /// <param name="arr">Source array data to be copied to this</param>
#endif
        public static MatOfDMatch FromArray(params DMatch[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (arr.Length == 0)
                throw new ArgumentException("arr.Length == 0");

            int numElems = arr.Length/* / ThisChannels*/;
            var mat = new MatOfDMatch(numElems, 1);
            mat.SetArray(0, 0, arr);
            return mat;
        }
#if LANG_JP
        /// <summary>
        /// M x N の行列として初期化し、指定した配列からデータをコピーする
        /// </summary>
        /// <param name="arr">この行列にコピーされるデータ</param>
#else
        /// <summary>
        /// Initializes as M x N matrix and copys array data to this
        /// </summary>
        /// <param name="arr">Source array data to be copied to this</param>
#endif
        public static MatOfDMatch FromArray(DMatch[,] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (arr.Length == 0)
                throw new ArgumentException("arr.Length == 0");

            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            var mat = new MatOfDMatch(rows, cols);
            mat.SetArray(0, 0, arr);
            return mat;
        }
#if LANG_JP
        /// <summary>
        /// N x 1 の行列(ベクトル)として初期化し、指定した配列からデータをコピーする
        /// </summary>
        /// <param name="enumerable">この行列にコピーされるデータ</param>
#else
        /// <summary>
        /// Initializes as N x 1 matrix and copys array data to this
        /// </summary>
        /// <param name="enumerable">Source array data to be copied to this</param>
#endif
        public static MatOfDMatch FromArray(IEnumerable<DMatch> enumerable)
        {
            return FromArray(EnumerableEx.ToArray(enumerable));
        }
        #endregion

        #region ToArray
        /// <summary>
        /// Convert this mat to managed array
        /// </summary>
        /// <returns></returns>
        public override DMatch[] ToArray()
        {
            long numOfElems = (long)Total();
            if (numOfElems == 0)
                return new DMatch[0];
            DMatch[] arr = new DMatch[numOfElems];
            GetArray(0, 0, arr);
            return arr;
        }
        /// <summary>
        /// Convert this mat to managed rectangular array
        /// </summary>
        /// <returns></returns>
        public override DMatch[,] ToRectangularArray()
        {
            if (Rows == 0 || Cols == 0)
                return new DMatch[0, 0];
            DMatch[,] arr = new DMatch[Rows, Cols];
            GetArray(0, 0, arr);
            return arr;
        }
        #endregion

        #region GetEnumerator
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<DMatch> GetEnumerator()
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
        #endregion

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element(s)</param>
        public override void Add(DMatch value)
        {
            ThrowIfDisposed();
            NativeMethods.core_Mat_push_back_Vec4f(ptr, (Vec4f)value);
        }
    }
}
