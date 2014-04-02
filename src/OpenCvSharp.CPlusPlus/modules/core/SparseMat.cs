using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Sparse matrix class.
    /// </summary>
    public class SparseMat : DisposableCvObject, ICloneable
    {
        private bool disposed;

        #region Init & Disposal

#if LANG_JP
        /// <summary>
        /// OpenCVネイティブの cv::SparseMat* ポインタから初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Creates from native cv::SparseMat* pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public SparseMat(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Native object address is NULL");
            this.ptr = ptr;

            //if (initialAlloc)
            //    NotifyMemoryPressure(MemorySize());
            NotifyMemoryPressure(SizeOf);
        }

#if LANG_JP
        /// <summary>
        /// 空の疎行列として初期化
        /// </summary>
#else
        /// <summary>
        /// Creates empty SparseMat
        /// </summary>
#endif
        public SparseMat()
        {
            ptr = NativeMethods.core_SparseMat_new1();
            NotifyMemoryPressure(SizeOf);
        }


#if LANG_JP
        /// <summary>
        /// N次元疎行列として初期化
        /// </summary>
        /// <param name="sizes">n-次元配列の形状を表す，整数型の配列．</param>
        /// <param name="type">配列の型．1-4 チャンネルの行列を作成するには MatType.CV_8UC1, ..., CV_64FC4 を，
        /// マルチチャンネルの行列を作成するには，MatType.CV_8UC(n), ..., CV_64FC(n) を利用してください．</param>
#else
        /// <summary>
        /// constructs n-dimensional sparse matrix
        /// </summary>
        /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
#endif
        public SparseMat(IEnumerable<int> sizes, MatType type)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");

            int[] sizesArray = EnumerableEx.ToArray(sizes);
            ptr = NativeMethods.core_SparseMat_new2(sizesArray.Length, sizesArray, type);
        }

#if LANG_JP
        /// <summary>
        /// cv::Matデータから初期化
        /// </summary>
        /// <param name="m">cv::Matオブジェクトへの参照．</param>
#else
        /// <summary>
        /// converts old-style CvMat to the new matrix; the data is not copied by default
        /// </summary>
        /// <param name="m">cv::Mat object</param>
#endif
        public SparseMat(Mat m)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            m.ThrowIfDisposed();
            ptr = NativeMethods.core_SparseMat_new3(m.CvPtr);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
            NotifyMemoryPressure(SizeOf);
        }

#if LANG_JP
        /// <summary>
        /// CvSparseMatデータから初期化
        /// </summary>
        /// <param name="m">CvSparseMat 行列構造体へのポインタ．</param>
#else
        /// <summary>
        /// converts old-style CvSparseMat to the new matrix; the data is not copied by default
        /// </summary>
        /// <param name="m">Old style CvSparseMat object</param>
#endif
        public SparseMat(CvSparseMat m)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            m.ThrowIfDisposed();
            ptr = NativeMethods.core_SparseMat_new4(m.CvPtr);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
            NotifyMemoryPressure(SizeOf);
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
        /// Releases the resources
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
                    // releases managed resources
                    if (disposing)
                    {
                    }
                    // releases unmanaged resources
                    if (IsEnabledDispose)
                    {
                        if (ptr != IntPtr.Zero)
                        {
                            NativeMethods.core_SparseMat_delete(ptr);
                        }
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }


        #region Static Initializers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static SparseMat FromMat(Mat mat)
        {
            return new SparseMat(mat);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static SparseMat FromCvSparseMat(CvSparseMat mat)
        {
            return new SparseMat(mat);
        }

        #endregion

        #endregion

        #region Static
        /// <summary>
        /// sizeof(cv::Mat)
        /// </summary>
        public static readonly int SizeOf = (int)NativeMethods.core_SparseMat_sizeof();

        #endregion

        #region Operators

        /// <summary>
        /// Creates the CvMat clone instance for the matrix.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator CvSparseMat(SparseMat self)
        {
            return self.ToCvSparseMat();
        }
        /// <summary>
        /// Creates the CvMat header or clone instance for the matrix.
        /// </summary>
        /// <returns></returns>
        public CvSparseMat ToCvSparseMat()
        {
            ThrowIfDisposed();

            IntPtr p = NativeMethods.core_SparseMat_operator_CvSparseMat(ptr);
            return new CvSparseMat(p);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Assignment operator. This is O(1) operation, i.e. no data is copied
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public SparseMat AssignFrom(SparseMat m)
        {
            ThrowIfDisposed();
            if(m == null)
                throw new ArgumentNullException("m");
            NativeMethods.core_SparseMat_operatorAssign_SparseMat(ptr, m.CvPtr);
            return this;
        }

        /// <summary>
        /// Assignment operator. equivalent to the corresponding constructor.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public SparseMat AssignFrom(Mat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            NativeMethods.core_SparseMat_operatorAssign_Mat(ptr, m.CvPtr);
            return this;
        }
        
        /// <summary>
        /// creates full copy of the matrix
        /// </summary>
        /// <returns></returns>
        public SparseMat Clone()
        {
            ThrowIfDisposed();
            IntPtr p = NativeMethods.core_SparseMat_clone(ptr);
            return new SparseMat(p);
        }
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// copies all the data to the destination matrix. All the previous content of m is erased.
        /// </summary>
        /// <param name="m"></param>
        public void CopyTo(SparseMat m)
        {
            ThrowIfDisposed();
            NativeMethods.core_SparseMat_copyTo_SparseMat(ptr, m.CvPtr);
        }
        /// <summary>
        /// converts sparse matrix to dense matrix.
        /// </summary>
        /// <param name="m"></param>
        public void CopyTo(Mat m)
        {
            ThrowIfDisposed();
            NativeMethods.core_SparseMat_copyTo_Mat(ptr, m.CvPtr);
        }

        /// <summary>
        /// multiplies all the matrix elements by the specified scale factor alpha and converts the results to the specified data type
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rtype"></param>
        /// <param name="alpha"></param>
        public void ConvertTo(SparseMat m, int rtype, double alpha = 1)
        {
            ThrowIfDisposed();
            NativeMethods.core_SparseMat_convertTo_SparseMat(ptr, m.CvPtr, rtype, alpha);
        }

        /// <summary>
        /// converts sparse matrix to dense n-dim matrix with optional type conversion and scaling.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rtype">The output matrix data type. When it is =-1, the output array will have the same data type as (*this)</param>
        /// <param name="alpha">The scale factor</param>
        /// <param name="beta">The optional delta added to the scaled values before the conversion</param>
        public void ConvertTo(Mat m, int rtype, double alpha = 1, double beta = 0)
        {
            ThrowIfDisposed();
            NativeMethods.core_SparseMat_convertTo_SparseMat(ptr, m.CvPtr, rtype, alpha);
        }

        /// <summary>
        /// not used now
        /// </summary>
        /// <param name="m"></param>
        /// <param name="type"></param>
        public void AssignTo(SparseMat m, int type = -1)
        {

        }


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
            get
            {
                return SubMat(rowStart, rowEnd, colStart, colEnd);
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                value.ThrowIfDisposed();
                //if (Type() != value.Type())
                //    throw new ArgumentException("Mat type mismatch");
                if (Dims != value.Dims)
                    throw new ArgumentException("Dimension mismatch");

                Mat sub = SubMat(rowStart, rowEnd, colStart, colEnd);
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
            get
            {
                return SubMat(rowRange, colRange);
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                value.ThrowIfDisposed();
                //if (Type() != value.Type())
                //    throw new ArgumentException("Mat type mismatch");
                if (Dims != value.Dims)
                    throw new ArgumentException("Dimension mismatch");

                Mat sub = SubMat(rowRange, colRange);
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
            get
            {
                return SubMat(roi);
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                value.ThrowIfDisposed();
                //if (Type() != value.Type())
                //    throw new ArgumentException("Mat type mismatch");
                if (Dims != value.Dims)
                    throw new ArgumentException("Dimension mismatch");

                if (roi.Size != value.Size())
                    throw new ArgumentException("Specified ROI != mat.Size()");
                Mat sub = SubMat(roi);
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
            get
            {
                return SubMat(ranges);
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                value.ThrowIfDisposed();
                //if (Type() != value.Type())
                //    throw new ArgumentException("Mat type mismatch");

                Mat sub = SubMat(ranges);

                int dims = Dims;
                if (dims != value.Dims)
                    throw new ArgumentException("Dimension mismatch");
                for (int i = 0; i < dims; i++)
                {
                    if (sub.Size(i) != value.Size(i))
                        throw new ArgumentException("Size mismatch at dimension " + i);
                }

                value.CopyTo(sub);
            }
        }
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
        public Mat AdjustROI(int dtop, int dbottom, int dleft, int dright)
        {
            ThrowIfDisposed();
            IntPtr retPtr = NativeMethods.core_Mat_adjustROI(ptr, dtop, dbottom, dleft, dright);
            Mat retVal = new Mat(retPtr);
            return retVal;
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
            return NativeMethods.core_Mat_channels(ptr);
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
            return NativeMethods.core_Mat_checkVector(ptr, elemChannels);
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
            return NativeMethods.core_Mat_checkVector(ptr, elemChannels, depth);
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
            return NativeMethods.core_Mat_checkVector(
                    ptr, elemChannels, depth, requireContinuous ? 1 : 0);
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
                if (colsVal == int.MinValue)
                {
                    colsVal = NativeMethods.core_Mat_cols(ptr);
                }
                return colsVal;
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
                if (colsVal == int.MinValue)
                {
                    colsVal = Cols;
                }
                return colsVal;
            }
        }

        private int colsVal = int.MinValue;

        #endregion
        #region Dims

        /// <summary>
        /// the array dimensionality, >= 2
        /// </summary>
        public int Dims
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.core_Mat_dims(ptr);
            }
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
                throw new ArgumentNullException("m");
            NativeMethods.core_Mat_convertTo(ptr, m.CvPtr, rtype, alpha, beta);
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
            NativeMethods.core_Mat_create(ptr, rows, cols, type);
        }

        /// <summary>
        /// Allocates new array data if needed.
        /// </summary>
        /// <param name="size">Alternative new matrix size specification: Size(cols, rows)</param>
        /// <param name="type">New matrix type.</param>
        public void Create(Size size, MatType type)
        {
            Create(size.Width, size.Height, type);
        }

        /// <summary>
        /// Allocates new array data if needed.
        /// </summary>
        /// <param name="sizes">Array of integers specifying a new array shape.</param>
        /// <param name="type">New matrix type.</param>
        public void Create(MatType type, params int[] sizes)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            if (sizes.Length < 2)
                throw new ArgumentException("sizes.Length < 2");
            NativeMethods.core_Mat_create(ptr, sizes.Length, sizes, type);
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
                throw new ArgumentNullException("m");
            IntPtr retPtr = NativeMethods.core_Mat_cross(ptr, m.CvPtr);
            Mat retVal = new Mat(retPtr);
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
                return NativeMethods.core_Mat_data(ptr);
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
                return NativeMethods.core_Mat_datastart(ptr);
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
                return NativeMethods.core_Mat_dataend(ptr);
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
                return NativeMethods.core_Mat_datalimit(ptr);
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
            return NativeMethods.core_Mat_depth(ptr);
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
            IntPtr retPtr = NativeMethods.core_Mat_diag(ptr, (int)d);
            Mat retVal = new Mat(retPtr);
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
                throw new ArgumentNullException("m");
            return NativeMethods.core_Mat_dot(ptr, m.CvPtr);
        }

        #endregion
        #region ElemSize

        /// <summary>
        /// Returns the matrix element size in bytes.
        /// </summary>
        /// <returns></returns>
        public long ElemSize()
        {
            ThrowIfDisposed();
            return (long)NativeMethods.core_Mat_elemSize(ptr);
        }

        #endregion
        #region ElemSize1

        /// <summary>
        /// Returns the size of each matrix element channel in bytes.
        /// </summary>
        /// <returns></returns>
        public long ElemSize1()
        {
            ThrowIfDisposed();
            return (long)NativeMethods.core_Mat_elemSize1(ptr);
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
            return NativeMethods.core_Mat_empty(ptr) != 0;
        }

        #endregion
        #region Inv

        /// <summary>
        /// Inverses a matrix.
        /// </summary>
        /// <param name="method">Matrix inversion method</param>
        /// <returns></returns>
        public Mat Inv(MatrixDecomposition method = MatrixDecomposition.LU)
        {
            ThrowIfDisposed();
            IntPtr retPtr = NativeMethods.core_Mat_inv(ptr, (int)method);
            Mat retVal = new Mat(retPtr);
            return retVal;
        }

        #endregion

        #region LocateROI

        /// <summary>
        /// Locates the matrix header within a parent matrix.
        /// </summary>
        /// <param name="wholeSize">Output parameter that contains the size of the whole matrix containing *this as a part.</param>
        /// <param name="ofs">Output parameter that contains an offset of *this inside the whole matrix.</param>
        public void LocateROI(out Size wholeSize, out Point ofs)
        {
            ThrowIfDisposed();
            CvSize wholeSize2;
            CvPoint ofs2;
            NativeMethods.core_Mat_locateROI(ptr, out wholeSize2, out ofs2);
            wholeSize = wholeSize2;
            ofs = ofs2;
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
            IntPtr mPtr = m.CvPtr;
            IntPtr retPtr = NativeMethods.core_Mat_mul(ptr, mPtr, scale);
            MatExpr retVal = new MatExpr(retPtr);
            return retVal;
        }

        #endregion
        #region Refcount

        /// <summary>
        /// pointer to the reference counter;
        /// when matrix points to user-allocated data, the pointer is NULL
        /// </summary>
        /// <returns>pointer to the reference counter</returns>
        public IntPtr Refcount
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.core_Mat_refcount(ptr);
            }
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
            IntPtr retPtr = NativeMethods.core_Mat_reshape(ptr, cn, rows);
            Mat retVal = new Mat(retPtr);
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
                throw new ArgumentNullException("newDims");
            IntPtr retPtr = NativeMethods.core_Mat_reshape(ptr, cn, newDims.Length, newDims);
            Mat retVal = new Mat(retPtr);
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
                if (rowsVal == int.MinValue)
                {
                    rowsVal = NativeMethods.core_Mat_rows(ptr);
                }
                return rowsVal;
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
                if (rowsVal == int.MinValue)
                {
                    rowsVal = Rows;
                }
                return rowsVal;
            }
        }

        private int rowsVal = int.MinValue;

        #endregion
        #region SetTo

        /// <summary>
        /// Sets all or some of the array elements to the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public Mat SetTo(Scalar value, InputArray mask = null)
        {
            ThrowIfDisposed();
            IntPtr maskPtr = Cv2.ToPtr(mask);
            IntPtr retPtr = NativeMethods.core_Mat_setTo(ptr, value, maskPtr);
            Mat retVal = new Mat(retPtr);
            return retVal;
        }

        /// <summary>
        /// Sets all or some of the array elements to the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public Mat SetTo(InputArray value, InputArray mask = null)
        {
            ThrowIfDisposed();
            if (value == null)
                throw new ArgumentNullException("value");
            value.ThrowIfDisposed();
            IntPtr maskPtr = Cv2.ToPtr(mask);
            IntPtr retPtr = NativeMethods.core_Mat_setTo(ptr, value.CvPtr, maskPtr);
            Mat retVal = new Mat(retPtr);
            return retVal;
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
            return NativeMethods.core_Mat_size(ptr);
        }

        /// <summary>
        /// Returns a matrix size.
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        public int Size(int dim)
        {
            ThrowIfDisposed();
            return NativeMethods.core_Mat_sizeAt(ptr, dim);
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
            return NativeMethods.core_Mat_step(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Step(int i)
        {
            ThrowIfDisposed();
            return (long)NativeMethods.core_Mat_stepAt(ptr, i);
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
            return (long)NativeMethods.core_Mat_step1(ptr);
        }

        /// <summary>
        /// Returns a normalized step.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Step1(int i)
        {
            ThrowIfDisposed();
            return (long)NativeMethods.core_Mat_step1(ptr, i);
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
            IntPtr retPtr = NativeMethods.core_Mat_t(ptr);
            Mat retVal = new Mat(retPtr);
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
            return (long)NativeMethods.core_Mat_total(ptr);
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
            return NativeMethods.core_Mat_type(ptr);
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
        public string Dump(DumpFormat format = DumpFormat.Default)
        {
            ThrowIfDisposed();
            string formatStr = GetDumpFormatString(format);
            unsafe
            {
                sbyte* buf = null;
                try
                {
                    buf = NativeMethods.core_Mat_dump(ptr, formatStr);
                    return new string(buf);
                }
                finally
                {
                    if (buf != null)
                        NativeMethods.core_Mat_dump_delete(buf);
                }
            }
        }

        private static string GetDumpFormatString(DumpFormat format)
        {
            if (format == DumpFormat.Default)
                return null;

            string name = Enum.GetName(typeof(DumpFormat), format);
            if(name == null)
                throw new ArgumentException();
            return name.ToLower();
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

        #region Ptr*D

        /// <summary>
        /// Returns a pointer to the specified matrix row.
        /// </summary>
        /// <param name="i0">Index along the dimension 0</param>
        /// <returns></returns>
        public IntPtr Ptr(int i0)
        {
            ThrowIfDisposed();
            return NativeMethods.core_Mat_ptr1d(ptr, i0);
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
            return NativeMethods.core_Mat_ptr2d(ptr, i0, i1);
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
            return NativeMethods.core_Mat_ptr3d(ptr, i0, i1, i2);
        }

        /// <summary>
        /// Returns a pointer to the specified matrix element.
        /// </summary>
        /// <param name="idx">Array of Mat::dims indices.</param>
        /// <returns></returns>
        public IntPtr Ptr(params int[] idx)
        {
            ThrowIfDisposed();
            return NativeMethods.core_Mat_ptrnd(ptr, idx);
        }

        #endregion
        #region Element Indexer

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
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0));
                    return (T)Marshal.PtrToStructure(p, typeof(T));
                }
                set
                {
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0));
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
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0) + (steps[1] * i1));
                    return (T)Marshal.PtrToStructure(p, typeof(T));
                }
                set
                {
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0) + (steps[1] * i1));
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
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                    return (T)Marshal.PtrToStructure(p, typeof (T));
                }
                set
                {
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
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
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    IntPtr p = new IntPtr(ptrVal + offset);
                    return (T)Marshal.PtrToStructure(p, typeof (T));
                }
                set
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    IntPtr p = new IntPtr(ptrVal + offset);
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
            IntPtr matPtr = NativeMethods.core_Mat_colRange_toMat(ptr, startCol, endCol);
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
                    parent.ThrowIfDisposed();
                    IntPtr matPtr = NativeMethods.core_Mat_col_toMat(parent.ptr, x);
                    Mat mat = new Mat(matPtr);
                    return mat;
                }
                set
                {
                    parent.ThrowIfDisposed();
                    if (value == null)
                        throw new ArgumentNullException("value");
                    value.ThrowIfDisposed();
                    if (parent.Dims != value.Dims)
                        throw new ArgumentException("Dimension mismatch");

                    IntPtr matPtr = NativeMethods.core_Mat_col_toMat(parent.ptr, x);
                    Mat mat = new Mat(matPtr);
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
                    parent.ThrowIfDisposed();
                    IntPtr matPtr = NativeMethods.core_Mat_colRange_toMat(parent.ptr, startCol, endCol);
                    Mat mat = new Mat(matPtr);
                    return mat;
                }
                set
                {
                    parent.ThrowIfDisposed();
                    if (value == null)
                        throw new ArgumentNullException("value");
                    value.ThrowIfDisposed();
                    if (parent.Dims != value.Dims)
                        throw new ArgumentException("Dimension mismatch");

                    IntPtr colMatPtr = NativeMethods.core_Mat_colRange_toMat(parent.ptr, startCol, endCol);
                    Mat colMat = new Mat(colMatPtr);
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
            get { return colIndexer ?? (colIndexer = new ColIndexer(this)); }
        }
        private ColIndexer colIndexer;

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
            IntPtr matPtr = NativeMethods.core_Mat_rowRange_toMat(ptr, startRow, endRow);
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
            /// Creates a matrix header for the specified matrix column.
            /// </summary>
            /// <param name="x">A 0-based column index.</param>
            /// <returns></returns>
            public override Mat this[int x]
            {
                get
                {
                    parent.ThrowIfDisposed();
                    IntPtr matPtr = NativeMethods.core_Mat_row_toMat(parent.ptr, x);
                    Mat mat = new Mat(matPtr);
                    return mat;
                }
                set
                {
                    parent.ThrowIfDisposed();
                    if (value == null)
                        throw new ArgumentNullException("value");
                    value.ThrowIfDisposed();
                    if (parent.Dims != value.Dims)
                        throw new ArgumentException("Dimension mismatch");

                    IntPtr matPtr = NativeMethods.core_Mat_row_toMat(parent.ptr, x);
                    Mat mat = new Mat(matPtr);
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
                    parent.ThrowIfDisposed();
                    IntPtr matPtr = NativeMethods.core_Mat_rowRange_toMat(parent.ptr, startCol, endCol);
                    Mat mat = new Mat(matPtr);
                    return mat;
                }
                set
                {
                    parent.ThrowIfDisposed();
                    if (value == null)
                        throw new ArgumentNullException("value");
                    value.ThrowIfDisposed();
                    if (parent.Dims != value.Dims)
                        throw new ArgumentException("Dimension mismatch");

                    IntPtr matPtr = NativeMethods.core_Mat_rowRange_toMat(parent.ptr, startCol, endCol);
                    Mat mat = new Mat(matPtr);
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
            get { return rowIndexer ?? (rowIndexer = new RowIndexer(this)); }
        }
        private RowIndexer rowIndexer;

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
            IntPtr retPtr = NativeMethods.core_Mat_subMat(ptr, rowStart, rowEnd, colStart, colEnd);
            Mat retVal = new Mat(retPtr);
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
            if (ranges == null)
                throw new ArgumentNullException();

            ThrowIfDisposed();
            CvSlice[] slices = new CvSlice[ranges.Length];
            for (int i = 0; i < ranges.Length; i++)
            {
                slices[i] = ranges[i];
            }

            IntPtr retPtr = NativeMethods.core_Mat_subMat(ptr, slices.Length, slices);
            Mat retVal = new Mat(retPtr);
            return retVal;
        }

        #endregion
        #region GetArray

        private void CheckArgumentsForConvert(int row, int col, Array data, 
            params MatType[] acceptableTypes)
        {
            ThrowIfDisposed();
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");
            if (data == null)
                throw new ArgumentNullException("data");

            MatType t = Type();
            if (data == null || data.Length % t.Channels != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    data.Length, t.Channels);

            if (acceptableTypes != null && acceptableTypes.Length > 0)
            {
                bool isValidDepth = EnumerableEx.Any(acceptableTypes, delegate(MatType type)
                    {
                        return type == t;
                    });
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
            CheckArgumentsForConvert(row, col, data, MatType.CV_8S, MatType.CV_8U);
            NativeMethods.core_Mat_nGetB(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, byte[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_8S, MatType.CV_8U);
            NativeMethods.core_Mat_nGetB(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, short[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_16S, MatType.CV_16U);
            NativeMethods.core_Mat_nGetS(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, short[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_16S, MatType.CV_16U);
            NativeMethods.core_Mat_nGetS(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, ushort[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_16S, MatType.CV_16U);
            NativeMethods.core_Mat_nGetS(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, ushort[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_16S, MatType.CV_16U);
            NativeMethods.core_Mat_nGetS(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, int[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32S);
            NativeMethods.core_Mat_nGetI(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, int[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32S);
            NativeMethods.core_Mat_nGetI(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, float[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32F);
            NativeMethods.core_Mat_nGetF(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, float[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32F);
            NativeMethods.core_Mat_nGetF(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, double[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64F);
            NativeMethods.core_Mat_nGetD(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, double[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64F);
            NativeMethods.core_Mat_nGetD(ptr, row, col, data, data.Length);
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
                throw new ArgumentOutOfRangeException("row");
            if (col < 0 || col >= Cols)
                throw new ArgumentOutOfRangeException("col");

            double[] ret = new double[Channels()];
            NativeMethods.core_Mat_nGetD(ptr, row, col, ret, ret.Length);
            return ret;
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec3b[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_8UC3);
            NativeMethods.core_Mat_nGetVec3b(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec3b[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_8UC3);
            NativeMethods.core_Mat_nGetVec3b(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec3d[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
            NativeMethods.core_Mat_nGetVec3d(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec3d[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
            NativeMethods.core_Mat_nGetVec3d(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec4f[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC4);
            NativeMethods.core_Mat_nGetVec4f(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec4f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC4);
            NativeMethods.core_Mat_nGetVec4f(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec6f[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC(6));
            NativeMethods.core_Mat_nGetVec6f(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Vec6f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC(6));
            NativeMethods.core_Mat_nGetVec6f(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC2);
            NativeMethods.core_Mat_nGetPoint(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC2);
            NativeMethods.core_Mat_nGetPoint(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point2f[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC2);
            NativeMethods.core_Mat_nGetPoint2f(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point2f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC2);
            NativeMethods.core_Mat_nGetPoint2f(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point2d[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64FC2);
            NativeMethods.core_Mat_nGetPoint2d(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point2d[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64FC2);
            NativeMethods.core_Mat_nGetPoint2d(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point3i[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC3);
            NativeMethods.core_Mat_nGetPoint3i(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point3i[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC3);
            NativeMethods.core_Mat_nGetPoint3i(ptr, row, col, data, data.Length);
        }


        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point3f[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC3);
            NativeMethods.core_Mat_nGetPoint3f(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point3f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC3);
            NativeMethods.core_Mat_nGetPoint3f(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point3d[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
            NativeMethods.core_Mat_nGetPoint3d(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point3d[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
            NativeMethods.core_Mat_nGetPoint3d(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Rect[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC4);
            NativeMethods.core_Mat_nGetRect(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Rect[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC4);
            NativeMethods.core_Mat_nGetRect(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, DMatch[] data)
        {
            CheckArgumentsForConvert(row, col, data);
            Vec4f[] dataV = new Vec4f[data.Length];
            NativeMethods.core_Mat_nGetVec4f(ptr, row, col, dataV, dataV.Length);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (DMatch)dataV[i];
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
            CheckArgumentsForConvert(row, col, data);
            int dim0 = data.GetLength(0);
            int dim1 = data.GetLength(1);
            Vec4f[,] dataV = new Vec4f[dim0, dim1];
            NativeMethods.core_Mat_nGetVec4f(ptr, row, col, dataV, dataV.Length);
            for (int i = 0; i < dim0; i++)
            {
                for (int j = 0; j < dim1; j++)
                {
                    data[i, j] = (DMatch)dataV[i, j];
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
        public void SetArray(int row, int col, params byte[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_8U);
            NativeMethods.core_Mat_nSetB(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, byte[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_8U);
            NativeMethods.core_Mat_nSetB(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params short[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_16S, MatType.CV_16U);
            NativeMethods.core_Mat_nSetS(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, short[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_16S, MatType.CV_16U);
            NativeMethods.core_Mat_nSetS(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params ushort[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_16S, MatType.CV_16U);
            NativeMethods.core_Mat_nSetS(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, ushort[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_16S, MatType.CV_16U);
            NativeMethods.core_Mat_nSetS(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params int[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32S);
            NativeMethods.core_Mat_nSetI(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, int[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32S);
            NativeMethods.core_Mat_nSetI(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params float[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32F);
            NativeMethods.core_Mat_nSetF(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, float[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32F);
            NativeMethods.core_Mat_nSetF(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params double[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64F);
            NativeMethods.core_Mat_nSetD(ptr, row, col, data, data.Length);
        }     
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, double[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64F);
            NativeMethods.core_Mat_nSetD(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Vec3b[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_8UC3);
            NativeMethods.core_Mat_nSetVec3b(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec3b[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_8UC3);
            NativeMethods.core_Mat_nSetVec3b(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Vec3d[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
            NativeMethods.core_Mat_nSetVec3d(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec3d[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
            NativeMethods.core_Mat_nSetVec3d(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Vec4f[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC4);
            NativeMethods.core_Mat_nSetVec4f(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec4f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC4);
            NativeMethods.core_Mat_nSetVec4f(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Vec6f[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC(6));
            NativeMethods.core_Mat_nSetVec6f(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Vec6f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC(6));
            NativeMethods.core_Mat_nSetVec6f(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Point[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC2);
            NativeMethods.core_Mat_nSetPoint(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC2);
            NativeMethods.core_Mat_nSetPoint(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Point2f[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC2);
            NativeMethods.core_Mat_nSetPoint2f(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point2f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC2);
            NativeMethods.core_Mat_nSetPoint2f(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Point2d[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64FC2);
            NativeMethods.core_Mat_nSetPoint2d(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point2d[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64FC2);
            NativeMethods.core_Mat_nSetPoint2d(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Point3i[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC3);
            NativeMethods.core_Mat_nSetPoint3i(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point3i[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC3);
            NativeMethods.core_Mat_nSetPoint3i(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Point3f[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC3);
            NativeMethods.core_Mat_nSetPoint3f(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point3f[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32FC3);
            NativeMethods.core_Mat_nSetPoint3f(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Point3d[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
            NativeMethods.core_Mat_nSetPoint3d(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Point3d[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
            NativeMethods.core_Mat_nSetPoint3d(ptr, row, col, data, data.Length);
        }


        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params Rect[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC4);
            NativeMethods.core_Mat_nSetRect(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, Rect[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC4);
            NativeMethods.core_Mat_nSetRect(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, params DMatch[] data)
        {
            CheckArgumentsForConvert(row, col, data);
            Vec4f[] dataV = EnumerableEx.SelectToArray(data, delegate(DMatch d)
            {
                return (Vec4f)d;
            });
            NativeMethods.core_Mat_nSetVec4f(ptr, row, col, dataV, dataV.Length);
        }
        /// <summary>
        /// Set the specified array data to this matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void SetArray(int row, int col, DMatch[,] data)
        {
            CheckArgumentsForConvert(row, col, data);
            Vec4f[] dataV = EnumerableEx.SelectToArray(data, delegate(DMatch d)
            {
                return (Vec4f)d;
            });
            NativeMethods.core_Mat_nSetVec4f(ptr, row, col, dataV, dataV.Length);
        }
        #endregion

        #endregion
    }

}
