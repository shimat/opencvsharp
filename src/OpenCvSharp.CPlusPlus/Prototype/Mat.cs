using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// cv::Mat
    /// </summary>
    public class Mat : DisposableCvObject, ICloneable
    {
        private bool disposed;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public Mat(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Native object address is NULL");
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        public Mat()
        {
            ptr = CppInvoke.core_Mat_new();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        public Mat(int rows, int cols, MatrixType type)
        {
            ptr = CppInvoke.core_Mat_new(rows, cols, (int)type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public Mat(Size size, int type)
        {
            ptr = CppInvoke.core_Mat_new(size.Width, size.Height, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <param name="s"></param>
        public Mat(int rows, int cols, int type, Scalar s)
        {
            ptr = CppInvoke.core_Mat_new(rows, cols, type, s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="s"></param>
        public Mat(Size size, int type, Scalar s)
        {
            ptr = CppInvoke.core_Mat_new(size.Width, size.Height, type, s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        public Mat(Mat m, Range rowRange, Range colRange)
        {
            ptr = CppInvoke.core_Mat_new(m.ptr, rowRange, colRange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rowRange"></param>
        public Mat(Mat m, Range rowRange)
        {
            ptr = CppInvoke.core_Mat_new(m.ptr, rowRange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="roi"></param>
        public Mat(Mat m, Rect roi)
        {
            ptr = CppInvoke.core_Mat_new(m.ptr, roi);
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
                    CppInvoke.core_Mat_delete(ptr);
                    //CppInvoke.core_Mat_release(ptr);
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        #endregion

        #region Static
        #region Diag
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Mat Diag(Mat d)
        {
            return d.Diag();
        }
        #endregion
        #region Eye
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Eye(Size size, MatrixType type)
        {
            return Eye(size.Height, size.Width, type);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Eye(int rows, int cols, MatrixType type)
        {
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_eye(rows, cols, (int)type);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Ones
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Ones(int rows, int cols, MatrixType type)
        {
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_ones(rows, cols, (int)type); 
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Ones(Size size, MatrixType type)
        {
            return Ones(size.Height, size.Width, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sizes"></param>
        /// <returns></returns>
        public static MatExpr Ones(MatrixType type, params int[] sizes)
        {
            if(sizes == null)
                throw new ArgumentNullException("sizes");
            /*
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_ones(sizes.Length, sizes, (int)type);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }*/
            throw new NotImplementedException(); // Undefined this in .lib file
        }
        #endregion
        #region Zeros
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Zeros(int rows, int cols, MatrixType type)
        {
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_zeros(rows, cols, (int)type);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MatExpr Zeros(Size size, MatrixType type)
        {
            return Zeros(size.Height, size.Width, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sizes"></param>
        /// <returns></returns>
        public static MatExpr Zeros(MatrixType type, params int[] sizes)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            /*
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_zeros(sizes.Length, sizes, (int)type);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }*/
            throw new NotImplementedException();
        }
        #endregion
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowStart"></param>
        /// <param name="rowEnd"></param>
        /// <param name="colStart"></param>
        /// <param name="colEnd"></param>
        /// <returns></returns>
        public Mat this[int rowStart, int rowEnd, int colStart, int colEnd]
        {
            get { return SubMat(rowStart, rowEnd, colStart, colEnd); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        /// <returns></returns>
        public Mat this[Range rowRange, Range colRange]
        {
            get { return SubMat(rowRange, colRange); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roi"></param>
        /// <returns></returns>
        public Mat this[Rect roi]
        {
            get { return SubMat(roi); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ranges"></param>
        /// <returns></returns>
        public Mat this[params Range[] ranges]
        {
            get { return SubMat(ranges); }
        }
        #endregion

        #region Public Methods
        #region AdjustROI
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtop"></param>
        /// <param name="dbottom"></param>
        /// <param name="dleft"></param>
        /// <param name="dright"></param>
        /// <returns></returns>
        public Mat AdjustROI(int dtop, int dbottom, int dleft, int dright)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_adjustROI(ptr, dtop, dbottom, dleft, dright);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        #endregion
        #region AssignTo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="type"></param>
        public void AssignTo(Mat m, MatrixType type)
        {
            ThrowIfDisposed();
            if(m == null)
                throw new ArgumentNullException("m");
            try
            {
                CppInvoke.core_Mat_assignTo(ptr, m.CvPtr, (int)type);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public void AssignTo(Mat m)
        {
            try
            {
                CppInvoke.core_Mat_assignTo(ptr, m.CvPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Channels
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Channels()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_channels(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
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
            try
            {
                int retVal = CppInvoke.core_Mat_checkVector(ptr, elemChannels);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
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
            try
            {
                int retVal = CppInvoke.core_Mat_checkVector(ptr, elemChannels, depth);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
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
            try
            {
                int retVal = CppInvoke.core_Mat_checkVector(
                    ptr, elemChannels, depth, requireContinuous ? 1 : 0);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Clone
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat Clone()
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_clone(ptr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
        #region Col
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Mat Col(int x)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_col(ptr, x);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Cols
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Cols
        {
            get
            {
                if (colsVal == int.MinValue)
                {
                    try
                    {
                        colsVal = CppInvoke.core_Mat_cols(ptr);
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
                return colsVal;
            }
        }
        /// <summary>
        /// 
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
        #region ColRange
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startCol"></param>
        /// <param name="endCol"></param>
        /// <returns></returns>
        public Mat ColRange(int startCol, int endCol)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_colRange(ptr, startCol, endCol);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public Mat ColRange(Range r)
        {
            return ColRange(r.Start, r.End);
        }
        #endregion
        #region Dims
        /// <summary>
        /// 
        /// </summary>
        public int Dims
        {
            get
            {
                ThrowIfDisposed();
                try
                {
                    return CppInvoke.core_Mat_dims(ptr);
                }
                catch (BadImageFormatException ex)
                {
                    throw PInvokeHelper.CreateException(ex);
                }
            }
        }
        #endregion
        #region ConvertTo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rtype"></param>
        public void ConvertTo(Mat m, int rtype)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            try
            {
                CppInvoke.core_Mat_convertTo(ptr, m.CvPtr, rtype);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rtype"></param>
        /// <param name="alpha"></param>
        public void ConvertTo(Mat m, int rtype, double alpha)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            try
            {
                CppInvoke.core_Mat_convertTo(ptr, m.CvPtr, rtype, alpha);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rtype"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        public void ConvertTo(Mat m, int rtype, double alpha, double beta)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            try
            {
                CppInvoke.core_Mat_convertTo(ptr, m.CvPtr, rtype, alpha, beta);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region CopyTo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public void CopyTo(Mat m)
        {
            CopyTo(m, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="mask"></param>
        public void CopyTo(Mat m, Mat mask)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            try
            {
                IntPtr maskPtr = GetCvPtr(mask);
                CppInvoke.core_Mat_copyTo(ptr, m.CvPtr, maskPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Create
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        public void Create(int rows, int cols, MatrixType type)
        {
            ThrowIfDisposed();
            try
            {
                CppInvoke.core_Mat_create(ptr, rows, cols, (int)type);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public void Create(Size size, MatrixType type)
        {
            Create(size.Width, size.Height, type);
        }
        #endregion
        #region Cross
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public Mat Cross(Mat m)
        {
            ThrowIfDisposed();
            if(m == null)
                throw new ArgumentNullException("m");
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_cross(ptr, m.CvPtr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Data
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public unsafe byte* DataPointer
        {
            get
            {
                ThrowIfDisposed();
                try
                {
                    return CppInvoke.core_Mat_data(ptr);
                }
                catch (BadImageFormatException ex)
                {
                    throw PInvokeHelper.CreateException(ex);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public IntPtr DataStart
        {
            get
            {
                ThrowIfDisposed();
                try
                {
                    return CppInvoke.core_Mat_datastart(ptr);
                }
                catch (BadImageFormatException ex)
                {
                    throw PInvokeHelper.CreateException(ex);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public IntPtr DataEnd
        {
            get
            {
                ThrowIfDisposed();
                try
                {
                    return CppInvoke.core_Mat_dataend(ptr);
                }
                catch (BadImageFormatException ex)
                {
                    throw PInvokeHelper.CreateException(ex);
                }
            }
        }
        #endregion
        #region Depth
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Depth()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_depth(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Diag
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat Diag()
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_diag(ptr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public Mat Diag(MatDiagType d)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_diag(ptr, (int)d);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Dot
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public double Dot(Mat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            try
            {
                return CppInvoke.core_Mat_dot(ptr, m.CvPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region ElemSize
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long ElemSize()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_elemSize(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region ElemSize
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long ElemSize1()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_elemSize1(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Empty
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_empty(ptr) != 0;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Inv
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat Inv()
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_inv(ptr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public Mat Inv(MatrixDecomposition method)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_inv(ptr, (int)method);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region IsContinuous
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsContinuous()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_isContinuous(ptr) != 0;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region IsSubmatirx
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsSubmatrix()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_isSubmatrix(ptr) != 0;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region LocateROI
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wholeSize"></param>
        /// <param name="ofs"></param>
        public void LocateROI(out Size wholeSize, out Point ofs)
        {
            ThrowIfDisposed();
            try
            {
                CvSize wholeSize2;
                CvPoint ofs2;
                CppInvoke.core_Mat_locateROI(ptr, out wholeSize2, out ofs2);
                wholeSize = wholeSize2;
                ofs = ofs2;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Mul
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public MatExpr Mul(Mat m)
        {
            ThrowIfDisposed();
            if(m == null)
                throw new ArgumentNullException();
            try
            {
                IntPtr mPtr = m.CvPtr;
                IntPtr retPtr = CppInvoke.core_Mat_mul(ptr, mPtr);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public MatExpr Mul(Mat m, double scale)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException();
            try
            {
                IntPtr mPtr = m.CvPtr;
                IntPtr retPtr = CppInvoke.core_Mat_mul(ptr, mPtr, scale);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static MatExpr operator *(Mat self, Mat m)
        {
            return self.Mul(m);
        }
        #endregion
        #region PushBack
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public void PushBack(Mat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException();
            try
            {
                IntPtr mPtr = GetCvPtr(m);
                CppInvoke.core_Mat_push_back(ptr, mPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Reshape
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        public Mat Reshape(int cn)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_reshape(ptr, cn);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public Mat Reshape(int cn, int rows)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_reshape(ptr, cn, rows);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="newDims"></param>
        /// <returns></returns>
        public Mat Reshape(int cn, params int[] newDims)
        {
            ThrowIfDisposed();
            if (newDims == null)
                throw new ArgumentNullException("newDims");
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_reshape(ptr, cn, newDims.Length, newDims);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Row
        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public Mat Row(int y)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_row(ptr, y);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region RowRange
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <returns></returns>
        public Mat RowRange(int startRow, int endRow)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_rowRange(ptr, startRow, endRow);
                MatExpr retVal = new MatExpr(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public Mat RowRange(Range r)
        {
            return RowRange(r.Start, r.End);
        }
        #endregion
        #region Rows
        /// <summary>
        /// 
        /// </summary>
        public int Rows
        {
            get
            {
                if (rowsVal == int.MinValue)
                {
                    try
                    {
                        rowsVal = CppInvoke.core_Mat_cols(ptr);
                    }
                    catch (BadImageFormatException ex)
                    {
                        throw PInvokeHelper.CreateException(ex);
                    }
                }
                return rowsVal;
            }
        }
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Mat SetTo(Scalar value)
        {
            return SetTo(value, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public Mat SetTo(Scalar value, Mat mask)
        {
            ThrowIfDisposed();
            try
            {
                IntPtr maskPtr = GetCvPtr(mask);
                IntPtr retPtr = CppInvoke.core_Mat_setTo(ptr, value, maskPtr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Mat SetTo(Mat value)
        {
            return SetTo(value, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public Mat SetTo(Mat value, Mat mask)
        {
            ThrowIfDisposed();
            if(value == null)
                throw new ArgumentNullException("value");
            try
            {
                IntPtr maskPtr = GetCvPtr(mask);
                IntPtr retPtr = CppInvoke.core_Mat_setTo(ptr, value.CvPtr, maskPtr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Size
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Size Size()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_size(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        public int Size(int dim)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_sizeAt(ptr, dim);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
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
            try
            {
                return CppInvoke.core_Mat_step(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Step(int i)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_stepAt(ptr, i);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Step1
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long Step1()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_step1(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Step1(int i)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_step1(ptr, i);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
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
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_subMat(ptr, rowStart, rowEnd, colStart, colEnd);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
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
            if(ranges == null)
                throw new ArgumentNullException();

            ThrowIfDisposed();
            try
            {
                CvSlice[] slices = new CvSlice[ranges.Length];
                for (int i = 0; i < ranges.Length; i++)
                {
                    slices[i] = ranges[i];
                }

                IntPtr retPtr = CppInvoke.core_Mat_subMat(ptr, slices.Length, slices);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region T
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat T()
        {
            ThrowIfDisposed();
            try
            {
                IntPtr retPtr = CppInvoke.core_Mat_t(ptr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Total
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long Total()
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_total(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region Type
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MatrixType Type()
        {
            ThrowIfDisposed();
            try
            {
                return (MatrixType)CppInvoke.core_Mat_type(ptr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region ToString
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Mat [ " +
                   Rows + "*" + Cols + "*" + CvType.TypeToString((int)Type()) +
                   ", IsContinuous=" + IsContinuous() + ", IsSubmatrix=" + IsSubmatrix() +
                   ", NativeObject=0x" + Convert.ToString(ptr.ToInt64(), 16) +
                   ", DataAddr=0x" + Convert.ToString(Data.ToInt64(), 16) +
                   " ]";
        }
        #endregion
        #region Dump
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Dump()
        {
            ThrowIfDisposed();
            try
            {
                unsafe
                {
                    sbyte *buf = CppInvoke.core_Mat_dump(ptr);
                    string ret = new string(buf);
                    CppInvoke.core_Mat_dump_delete(buf);
                    return ret;
                }
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion

        #region Ptr*D
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i0"></param>
        /// <returns></returns>
        public IntPtr Ptr(int i0)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_ptr1d(ptr, i0);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        public IntPtr Ptr(int i0, int i1)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_ptr2d(ptr, i0, i1);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public IntPtr Ptr(int i0, int i1, int i2)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_ptr3d(ptr, i0, i1, i2);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public IntPtr Ptr(params int[] idx)
        {
            ThrowIfDisposed();
            try
            {
                return CppInvoke.core_Mat_ptrnd(ptr, idx);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion

        #region At
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public sealed class Indexer<T>
        {
            private readonly Mat parent;
            private readonly long ptrVal;
            private readonly long[] steps;

            internal Indexer(Mat parent)
            {
                this.parent = parent;
                this.ptrVal = parent.Data.ToInt64();

                int dims = parent.Dims;
                steps = new long[dims];
                for (int i = 0; i < dims; i++)
                {
                    steps[i] = parent.Step(i);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <returns></returns>
            public T this[int i0]
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
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <returns></returns>
            public T this[int i0, int i1]
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
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <param name="i2"></param>
            /// <returns></returns>
            public T this[int i0, int i1, int i2]
            {
                get
                {
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                    return (T)Marshal.PtrToStructure(p, typeof(T));
                }
                set
                {
                    IntPtr p = new IntPtr(ptrVal + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                    Marshal.StructureToPtr(value, p, false);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Indexer<T> GetIndexer<T>()
        {
            return new Indexer<T>(this);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Put(int row, int col, params double[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            return nPutD(ptr, row, col, data.Length, data);*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Put(int row, int col, float[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_32F)
            {
                return nPutF(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Put(int row, int col, int[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_32S)
            {
                return nPutI(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Put(int row, int col, short[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_16U || CvType.Depth(t) == CvType.CV_16S)
            {
                return nPutS(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Put(int row, int col, byte[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_8U || CvType.Depth(t) == CvType.CV_8S)
            {
                return nPutB(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Get(int row, int col, byte[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_8U || CvType.Depth(t) == CvType.CV_8S)
            {
                return nGetB(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Get(int row, int col, short[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_16U || CvType.Depth(t) == CvType.CV_16S)
            {
                return nGetS(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Get(int row, int col, int[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_32S)
            {
                return nGetI(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Get(int row, int col, float[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})", 
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_32F)
            {
                return nGetF(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Get(int row, int col, double[] data)
        {
            throw new NotImplementedException();
            /*int t = Type();
            if (data == null || data.Length % CvType.Channels(t) != 0)
                throw new OpenCvSharpException(
                    "Provided data element number ({0}) should be multiple of the Mat channels count ({1})",
                    (data == null ? 0 : data.Length), CvType.Channels(t));
            if (CvType.Depth(t) == CvType.CV_64F)
            {
                return nGetD(ptr, row, col, data.Length, data);
            }
            throw new OpenCvSharpException("Mat data type is not compatible: " + t);*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public double[] Get(int row, int col)
        {
            throw new NotImplementedException();
            //return nGet(ptr, row, col);
        }
        #endregion
        /*
        // C++: void Mat::assignTo(Mat m, int type = -1)
        private static extern void n_assignTo(IntPtr nativeObj, IntPtr m_nativeObj, int type);

        private static extern void n_assignTo(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: int Mat::channels()
        private static extern int n_channels(IntPtr nativeObj);

        // C++: int Mat::checkVector(int elemChannels, int depth = -1, bool
        // requireContinuous = true)
        private static extern int n_checkVector(IntPtr nativeObj, int elemChannels, int depth, bool requireContinuous);

        private static extern int n_checkVector(IntPtr nativeObj, int elemChannels, int depth);

        private static extern int n_checkVector(IntPtr nativeObj, int elemChannels);

        // C++: Mat Mat::clone()
        private static extern IntPtr n_clone(IntPtr nativeObj);

        // C++: Mat Mat::col(int x)
        private static extern IntPtr n_col(IntPtr nativeObj, int x);

        // C++: Mat Mat::colRange(int startcol, int endcol)
        private static extern IntPtr n_colRange(IntPtr nativeObj, int startcol, int endcol);

        // C++: int Mat::dims()
        private static extern int n_dims(IntPtr nativeObj);

        // C++: int Mat::cols()
        private static extern int n_cols(IntPtr nativeObj);

        // C++: void Mat::convertTo(Mat& m, int rtype, double alpha = 1, double beta
        // = 0)
        private static extern void n_convertTo(IntPtr nativeObj, IntPtr m_nativeObj, int rtype, double alpha, double beta);

        private static extern void n_convertTo(IntPtr nativeObj, IntPtr m_nativeObj, int rtype, double alpha);

        private static extern void n_convertTo(IntPtr nativeObj, IntPtr m_nativeObj, int rtype);

        // C++: void Mat::copyTo(Mat& m)
        private static extern void n_copyTo(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: void Mat::copyTo(Mat& m, Mat mask)
        private static extern void n_copyTo(IntPtr nativeObj, IntPtr m_nativeObj, IntPtr mask_nativeObj);

        // C++: void Mat::create(int rows, int cols, int type)
        private static extern void n_create(IntPtr nativeObj, int rows, int cols, int type);

        // C++: void Mat::create(Size size, int type)
        private static extern void n_create(IntPtr nativeObj, double size_width, double size_height, int type);

        // C++: Mat Mat::cross(Mat m)
        private static extern IntPtr n_cross(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: long Mat::dataAddr()
        private static extern IntPtr n_dataAddr(IntPtr nativeObj);

        // C++: int Mat::depth()
        private static extern int n_depth(IntPtr nativeObj);

        // C++: Mat Mat::diag(int d = 0)
        private static extern IntPtr n_diag(IntPtr nativeObj, int d);

        // C++: static Mat Mat::diag(Mat d)
        private static extern IntPtr n_diag(IntPtr d_nativeObj);

        // C++: double Mat::dot(Mat m)
        private static extern double n_dot(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: size_t Mat::elemSize()
        private static extern long n_elemSize(IntPtr nativeObj);

        // C++: size_t Mat::elemSize1()
        private static extern long n_elemSize1(IntPtr nativeObj);

        // C++: bool Mat::empty()
        private static extern bool n_empty(IntPtr nativeObj);

        // C++: static Mat Mat::eye(int rows, int cols, int type)
        private static extern IntPtr n_eye(int rows, int cols, int type);

        // C++: static Mat Mat::eye(Size size, int type)
        private static extern IntPtr n_eye(double size_width, double size_height, int type);

        // C++: Mat Mat::inv(int method = DECOMP_LU)
        private static extern IntPtr n_inv(IntPtr nativeObj, int method);

        private static extern IntPtr n_inv(IntPtr nativeObj);

        // C++: bool Mat::isContinuous()
        private static extern bool n_isContinuous(IntPtr nativeObj);

        // C++: bool Mat::isSubmatrix()
        private static extern bool n_isSubmatrix(IntPtr nativeObj);

        // C++: void Mat::locateROI(Size wholeSize, Point ofs)
        private static extern void locateROI_0(IntPtr nativeObj, double[] wholeSize_out, double[] ofs_out);

        // C++: Mat Mat::mul(Mat m, double scale = 1)
        private static extern IntPtr n_mul(IntPtr nativeObj, IntPtr m_nativeObj, double scale);

        private static extern IntPtr n_mul(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: static Mat Mat::ones(int rows, int cols, int type)
        private static extern IntPtr n_ones(int rows, int cols, int type);

        // C++: static Mat Mat::ones(Size size, int type)
        private static extern IntPtr n_ones(double size_width, double size_height, int type);

        // C++: void Mat::push_back(Mat m)
        private static extern void n_push_back(IntPtr nativeObj, IntPtr m_nativeObj);

        // C++: void Mat::release()
        private static extern void n_release(IntPtr nativeObj);

        // C++: Mat Mat::reshape(int cn, int rows = 0)
        private static extern IntPtr n_reshape(IntPtr nativeObj, int cn, int rows);

        private static extern IntPtr n_reshape(IntPtr nativeObj, int cn);

        // C++: Mat Mat::row(int y)
        private static extern IntPtr n_row(IntPtr nativeObj, int y);

        // C++: Mat Mat::rowRange(int startrow, int endrow)
        private static extern IntPtr n_rowRange(IntPtr nativeObj, int startrow, int endrow);

        // C++: int Mat::rows()
        private static extern int n_rows(IntPtr nativeObj);

        // C++: Mat Mat::operator =(Scalar s)
        private static extern IntPtr n_setTo(IntPtr nativeObj, double s_val0, double s_val1, double s_val2, double s_val3);

        // C++: Mat Mat::setTo(Scalar value, Mat mask = Mat())
        private static extern IntPtr n_setTo(IntPtr nativeObj, double s_val0, double s_val1, double s_val2, double s_val3,
                                           IntPtr mask_nativeObj);

        // C++: Mat Mat::setTo(Mat value, Mat mask = Mat())
        private static extern IntPtr n_setTo(IntPtr nativeObj, IntPtr value_nativeObj, IntPtr mask_nativeObj);

        private static extern IntPtr n_setTo(IntPtr nativeObj, IntPtr value_nativeObj);

        // C++: Size Mat::size()
        private static extern double[] n_size(IntPtr nativeObj);

        // C++: size_t Mat::step1(int i = 0)
        private static extern long n_step1(IntPtr nativeObj, int i);

        private static extern long n_step1(IntPtr nativeObj);

        // C++: Mat Mat::operator()(Range rowRange, Range colRange)
        private static extern IntPtr n_submat_rr(IntPtr nativeObj, int rowRange_start, int rowRange_end, int colRange_start,
                                               int colRange_end);

        // C++: Mat Mat::operator()(Rect roi)
        private static extern IntPtr n_submat(IntPtr nativeObj, int roi_x, int roi_y, int roi_width, int roi_height);

        // C++: Mat Mat::t()
        private static extern IntPtr n_t(IntPtr nativeObj);

        // C++: size_t Mat::total()
        private static extern long n_total(IntPtr nativeObj);

        // C++: int Mat::type()
        private static extern int n_type(IntPtr nativeObj);

        // C++: static Mat Mat::zeros(int rows, int cols, int type)
        private static extern IntPtr n_zeros(int rows, int cols, int type);

        // C++: static Mat Mat::zeros(Size size, int type)
        private static extern IntPtr n_zeros(double size_width, double size_height, int type);

        // extern support for java finalize()
        private static extern void n_delete(IntPtr nativeObj);

        private static extern int nPutD(IntPtr self, int row, int col, int count, double[] data);

        private static extern int nPutF(IntPtr self, int row, int col, int count, float[] data);

        private static extern int nPutI(IntPtr self, int row, int col, int count, int[] data);

        private static extern int nPutS(IntPtr self, int row, int col, int count, short[] data);

        private static extern int nPutB(IntPtr self, int row, int col, int count, byte[] data);

        private static extern int nGetB(IntPtr self, int row, int col, int count, byte[] vals);

        private static extern int nGetS(IntPtr self, int row, int col, int count, short[] vals);

        private static extern int nGetI(IntPtr self, int row, int col, int count, int[] vals);

        private static extern int nGetF(IntPtr self, int row, int col, int count, float[] vals);

        private static extern int nGetD(IntPtr self, int row, int col, int count, double[] vals);

        private static extern double[] nGet(IntPtr self, int row, int col);

        private static extern String nDump(IntPtr self);
        */
    }

}

