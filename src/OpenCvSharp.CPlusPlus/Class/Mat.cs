using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus.Prototype;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// OpenCVのC++版行列クラス
    /// </summary>
#else
    /// <summary>
    /// OpenCV C++ matrix class.
    /// </summary>
#endif
    public class Mat : DisposableCvObject, ICloneable
    {
        #region Const
        // ReSharper disable InconsistentNaming
        /// <summary>
        /// 
        /// </summary>
        protected const int MAGIC_VAL = 0x42FF0000;
        /// <summary>
        /// 
        /// </summary>
        protected const int AUTO_STEP = 0;
        /// <summary>
        /// 
        /// </summary>
        protected const int CONTINUOUS_FLAG = CvConst.CV_MAT_CONT_FLAG;
        // ReSharper restore InconsistentNaming
        #endregion

        #region Fields
        /// <summary>
        /// sizeof(Mat)
        /// </summary>
        public static readonly int SizeOf;
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;
        #endregion

        #region Init and Disposal
        /// <summary>
        /// static constructor
        /// </summary>
        static Mat()
        {
            try
            {
                SizeOf = CppInvoke.Mat_sizeof();
            }
            catch (DllNotFoundException e)
            {
                PInvokeHelper.DllImportError(e);
                throw;
            }
            catch (BadImageFormatException e)
            {
                PInvokeHelper.DllImportError(e);
                throw;
            }
        }
        #region Constructor
#if LANG_JP
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public Mat()
        {
            ptr = CppInvoke.Mat_new1();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// Loads image from the specified file name using cv::imread
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="flags"></param>
        public Mat(string filename, LoadMode flags)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            if (!System.IO.File.Exists(filename))
                throw new System.IO.FileNotFoundException("", filename);

            //_ptr = CppInvoke.Mat_new1();
            //CppInvoke.cv_imread(filename, flags, _ptr);
            using (IplImage img = new IplImage(filename, flags))
            {
                ptr = CppInvoke.Mat_new8(img.CvPtr, true);
            }
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        public Mat(int rows, int cols, MatrixType type)
        {
            if (rows <= 0)
                throw new ArgumentOutOfRangeException("rows");
            if (cols <= 0)
                throw new ArgumentOutOfRangeException("cols");
            ptr = CppInvoke.Mat_new2(rows, cols, type);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public Mat(CvSize size, MatrixType type)
            : this(size.Height, size.Width, type)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <param name="s"></param>
        public Mat(int rows, int cols, MatrixType type, CvScalar s)
        {
            if (rows <= 0)
                throw new ArgumentOutOfRangeException("rows");
            if (cols <= 0)
                throw new ArgumentOutOfRangeException("cols");
            ptr = CppInvoke.Mat_new3(rows, cols, type, (CvScalar)s);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="s"></param>
        public Mat(CvSize size, MatrixType type, CvScalar s)
            : this(size.Height, size.Width, type, s)
        {
        }     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="step"></param>
        public Mat(int rows, int cols, MatrixType type, IntPtr data, uint step)
        {
            if (rows <= 0)
                throw new ArgumentOutOfRangeException("rows");
            if (cols <= 0)
                throw new ArgumentOutOfRangeException("cols");
            ptr = CppInvoke.Mat_new4(rows, cols, type, data, step);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="step"></param>
        public Mat(CvSize size, MatrixType type, IntPtr data, uint step)
            : this(size.Height, size.Width, type, data, step)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        public Mat(Mat m, CvSlice rowRange, CvSlice colRange)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            ptr = CppInvoke.Mat_new5(m.CvPtr, rowRange, colRange);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="roi"></param>
        public Mat(Mat m, CvRect roi)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            ptr = CppInvoke.Mat_new6(m.CvPtr, (CvRect)roi);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public Mat(CvMat m)
            : this(m, false)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="copyData"></param>
        public Mat(CvMat m, bool copyData)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            ptr = CppInvoke.Mat_new7(m.CvPtr, copyData);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
            if (copyData == false)
                IsEnabledDispose = false;
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        public Mat(IplImage img)
            : this(img, false)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="copyData"></param>
        public Mat(IplImage img, bool copyData)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            ptr = CppInvoke.Mat_new8(img.CvPtr, copyData);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
            if (copyData == false)
                IsEnabledDispose = false;
        }  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="depth"></param>
        /// <param name="copyData"></param>
        public Mat(Array vec, BitDepth depth, bool copyData)
        {
            if (vec == null)
                throw new ArgumentNullException("vec");
            using (ScopedGCHandle vecPtr = new ScopedGCHandle(vec, GCHandleType.Pinned))
            {
                int depthType;
                int elemSize;
                switch(depth)
                {
                    case BitDepth.U8:
                        depthType = CvConst.CV_8U; elemSize = sizeof(byte); break;
                    case BitDepth.S8:
                        depthType = CvConst.CV_8S; elemSize = sizeof(sbyte); break;
                    case BitDepth.U16:
                        depthType = CvConst.CV_16U; elemSize = sizeof(ushort); break;
                    case BitDepth.S16:
                        depthType = CvConst.CV_16S; elemSize = sizeof(short); break;
                    case BitDepth.S32:
                        depthType = CvConst.CV_32S; elemSize = sizeof(int); break;
                    case BitDepth.F32:
                        depthType = CvConst.CV_32F; elemSize = sizeof(float); break;
                    case BitDepth.F64:
                        depthType = CvConst.CV_64F; elemSize = sizeof(double); break;
                    default:
                        throw new ArgumentException();
                }
                ptr = CppInvoke.Mat_new9(vecPtr.AddrOfPinnedObject(), vec.Length, depthType, elemSize, copyData);
                if (ptr == IntPtr.Zero)
                    throw new OpenCvSharpException();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public Mat(IntPtr ptr)
        {
            base.ptr = ptr;
        }
        #endregion
        #region Dispose
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
            Dispose(true);
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
            if (!this.disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {                        
                    }
                    if (IsEnabledDispose)
                    {
                        CppInvoke.Mat_delete(ptr);
                    }
                    this.disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion
        #endregion

        #region Operators
        #region Unary
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Mat operator -(Mat src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (src.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opUnaryMinus(src.CvPtr, dst.CvPtr);
            return dst;
        }
        #endregion
        #region Binary
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static Mat operator +(Mat src1, Mat src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (src1.disposed || src2.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opBinaryPlus1(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            return dst;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static Mat operator +(Mat src1, CvScalar src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src1.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opBinaryPlus2(src1.CvPtr, src2, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static Mat operator -(Mat src1, Mat src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (src1.disposed || src2.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opBinaryMinus1(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            return dst;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static Mat operator -(Mat src1, CvScalar src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src1.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opBinaryMinus2(src1.CvPtr, src2, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static Mat operator *(Mat src1, Mat src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (src1.disposed || src2.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opBinaryMultiply(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static Mat operator /(Mat src1, Mat src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (src1.disposed || src2.disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_opBinaryDivide(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            return dst;
        }
        #endregion
        #region Cast
        /// <summary>
        /// converts header to CvMat; no data is copied
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator CvMat(Mat self)
        {
            if (self == null)
                return null;
            return self.ToCvMat();
        }

        /// <summary>
        /// converts header to IplImage; no data is copied
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator IplImage(Mat self)
        {
            if (self == null)
                return null;
            return self.ToIplImage();
        }

        /// <summary>
        /// converts CvMat to Mat; no data is copied
        /// </summary>
        /// <param name="cvmat"></param>
        /// <returns></returns>
        public static implicit operator Mat(CvMat cvmat)
        {
            if (cvmat == null)
                return null;
            return new Mat(cvmat, false);
        }

        /// <summary>
        /// converts header to IplImage; no data is copied
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static implicit operator Mat(IplImage image)
        {
            if (image == null)
                return null;
            return new Mat(image, false);
        }

        #endregion
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
                if (disposed)
                    throw new ObjectDisposedException("Mat");
                return CppInvoke.Mat_flags(ptr);
            }
        }
        /// <summary>
        /// the number of rows
        /// </summary>
        public int Rows
        {
            get 
            {
                if (disposed)
                    throw new ObjectDisposedException("Mat");
                return CppInvoke.Mat_rows(ptr); 
            }
        }
        /// <summary>
        /// the number of columns
        /// </summary>
        public int Cols
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("Mat");
                return CppInvoke.Mat_cols(ptr);
            }
        }
        /// <summary>
        /// a distance between successive rows in bytes; includes the gap if any
        /// </summary>
        public uint Step
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("Mat");
                return CppInvoke.Mat_step(ptr);
            }
        }
        /// <summary>
        /// pointer to the data
        /// </summary>
        public IntPtr Data
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("Mat");
                return CppInvoke.Mat_data(ptr);
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
                if (disposed)
                    throw new ObjectDisposedException("Mat");
                return CppInvoke.Mat_refcount(ptr);
            }
        }
        /// <summary>
        /// helper fields used in locateROI and adjustROI
        /// </summary>
        public IntPtr DataStart
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("Mat");
                return CppInvoke.Mat_datastart(ptr);
            }
        }
        /// <summary>
        /// helper fields used in locateROI and adjustROI
        /// </summary>
        public IntPtr DataEnd
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("Mat");
                return CppInvoke.Mat_dataend(ptr);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public MatrixType Type
        {
            get
            {
                return (MatrixType)Cv.MAT_TYPE(Flags);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ElemSize
        {
            get
            {
                return Cv.ELEM_SIZE(Flags);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ElemSize1
        {
            get
            {
                return Cv.ELEM_SIZE1(Flags);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Depth 
        {
            get
            {
                return Cv.MAT_DEPTH(Flags);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Channels
        {
            get 
            {
                return Cv.MAT_CN(Flags);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Bpp
        {
            get
            {
                return (int)Math.Pow(2, ((Depth / 2) + 1) + 2);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public CvSize Size
        {
            get
            {
                return new CvSize(Cols, Rows);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roi"></param>
        /// <returns></returns>
        public virtual Mat this[CvRect roi]
        {
            get
            {
                Mat result = new Mat();
                CppInvoke.Mat_opRange1(ptr, roi, result.CvPtr);
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        /// <returns></returns>
        public virtual Mat this[CvSlice rowRange, CvSlice colRange]
        {
            get
            {
                Mat result = new Mat();
                CppInvoke.Mat_opRange2(ptr, rowRange, colRange, result.CvPtr);
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public virtual IntPtr this[int y, int x]
        {
            get
            {
                //( (unsigned)y < (unsigned)rows && (unsigned)x < (unsigned)cols && sizeof(_Tp) == elemSize() );
                return new IntPtr(Data.ToInt64() + (long)(Step * (uint)y) + (ElemSize * x));
            }
        }

        #endregion

        #region Methods
        #region Static methods
        /// <summary>
        /// constructs a square diagonal matrix which main diagonal is vector "d"
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Mat Diag(Mat d)
        {
            if (d == null)
                throw new ArgumentNullException("d");
            Mat outValue = new Mat();
            CppInvoke.Mat_diag2(d.CvPtr, outValue.CvPtr);
            return outValue;
        }

        /// <summary>
        /// Matlab-style matrix initialization
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Mat Zeros(int rows, int cols, MatrixType type)
        {
            Mat outValue = new Mat();
            CppInvoke.Mat_zeros(rows, cols, type, outValue.CvPtr);
            return outValue;
        }
        /// <summary>
        /// Matlab-style matrix initialization
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Mat Zeros(CvSize size, MatrixType type)
        {
            return Zeros(size.Height, size.Width, type);
        }

        /// <summary>
        /// Matlab-style matrix initialization
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Mat Ones(int rows, int cols, MatrixType type)
        {
            Mat outValue = new Mat();
            CppInvoke.Mat_ones(rows, cols, type, outValue.CvPtr);
            return outValue;
        }
        /// <summary>
        /// Matlab-style matrix initialization
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Mat Ones(CvSize size, MatrixType type)
        {
            return Ones(size.Height, size.Width, type);
        }

        /// <summary>
        /// Matlab-style matrix initialization
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Mat Eye(int rows, int cols, MatrixType type)
        {
            Mat outValue = new Mat();
            CppInvoke.Mat_eye(rows, cols, type, outValue.CvPtr);
            return outValue;
        }
        /// <summary>
        /// Matlab-style matrix initialization
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Mat Eye(CvSize size, MatrixType type)
        {
            return Eye(size.Height, size.Width, type);
        }
        #endregion
        #region Instance methods
        /// <summary>
        /// returns a new matrix header for the specified row
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public Mat Row(int y)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            Mat outValue = new Mat();
            CppInvoke.Mat_row(ptr, y, outValue.CvPtr);
            return outValue;
        }
        /// <summary>
        /// returns a new matrix header for the specified column
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Mat Col(int x)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            Mat outValue = new Mat();
            CppInvoke.Mat_col(ptr, x, outValue.CvPtr);
            return outValue;
        }
        /// <summary>
        /// returns a new matrix header for the specified row span
        /// </summary>
        /// <param name="startrow"></param>
        /// <param name="endrow"></param>
        /// <returns></returns>
        public Mat RowRange(int startrow, int endrow)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            Mat outValue = new Mat();
            CppInvoke.Mat_rowRange(ptr, startrow, endrow, outValue.CvPtr);
            return outValue;
        }
        /// <summary>
        /// returns a new matrix header for the specified row span
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public Mat RowRange(CvSlice r)
        {
            return RowRange(r.StartIndex, r.EndIndex);
        }
        /// <summary>
        /// returns a new matrix header for the specified column span
        /// </summary>
        /// <param name="startcol"></param>
        /// <param name="endcol"></param>
        /// <returns></returns>
        public Mat ColRange(int startcol, int endcol) 
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            Mat outValue = new Mat();
            CppInvoke.Mat_colRange(ptr, startcol, endcol, outValue.CvPtr);
            return outValue;
        }
        /// <summary>
        /// returns a new matrix header for the specified column span
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public Mat ColRange(CvSlice r)
        {
            return ColRange(r.StartIndex, r.EndIndex);
        }

        /// <summary>
        /// returns a new matrix header for the specified diagonal
        /// </summary>
        /// <returns></returns>
        public Mat Diag()
        {
            return Diag(MatDiagType.Main);
        }
        /// <summary>
        /// returns a new matrix header for the specified diagonal
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public Mat Diag(MatDiagType d)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            Mat outValue = new Mat();
            CppInvoke.Mat_diag1(ptr, d, outValue.CvPtr);
            return outValue;
        }

        /// <summary>
        /// returns deep copy of the matrix, i.e. the data is copied
        /// </summary>
        /// <returns></returns>
        public Mat Clone()
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            Mat outValue = new Mat();
            CppInvoke.Mat_clone(ptr, outValue.CvPtr);
            return outValue;
        }
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// copies those matrix elements to "m"
        /// </summary>
        /// <param name="m"></param>
        public void CopyTo(Mat m)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            if (m == null)
                throw new ArgumentNullException("m");
            CppInvoke.Mat_copyTo1(ptr, m.CvPtr);
        }
        /// <summary>
        /// copies those matrix elements to "m" that are marked with non-zero mask elements.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="mask"></param>
        public void CopyTo(Mat m, Mat mask)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            if (m == null)
                throw new ArgumentNullException("m");
            if (mask == null)
                throw new ArgumentNullException("mask");
            CppInvoke.Mat_copyTo2(ptr, m.CvPtr, mask.CvPtr);
        }

        /// <summary>
        /// converts matrix to another datatype with optional scalng. See cvConvertScale.
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="rtype"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <returns></returns>
        public void ConvertTo(Mat dst, MatrixType rtype, double alpha = 1, double beta = 0)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            CppInvoke.Mat_convertTo(ptr, dst.CvPtr, rtype, alpha, beta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public void AssignTo(Mat m)
        {
            CppInvoke.Mat_assignTo(ptr, m.CvPtr, -1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="type"></param>
        public void AssignTo(Mat m, MatrixType type)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            if (m == null)
                throw new ArgumentNullException("m");
            CppInvoke.Mat_assignTo(ptr, m.CvPtr, (int)type);
        }

        /// <summary>
        /// sets some of the matrix elements to s, according to the mask
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public Mat SetTo(Mat value, Mat mask = null)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            if (value == null)
                throw new ArgumentNullException("value");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            Mat dst = new Mat();
            CppInvoke.Mat_setTo(ptr, value.CvPtr, maskPtr, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// creates alternative matrix header for the same data, with different
        /// number of channels and/or different number of rows. see cvReshape.
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public Mat Reshape(int cn, int rows)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            Mat outValue = new Mat();
            CppInvoke.Mat_reshape(ptr, cn, rows, outValue.CvPtr);
            return outValue;
        }

        /// <summary>
        /// computes cross-product of 2 3D vectors
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public Mat Cross(Mat m) 
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            if (m == null)
                throw new ArgumentNullException("m");
            Mat outValue = new Mat();
            CppInvoke.Mat_cross(ptr, m.CvPtr, outValue.CvPtr);
            return outValue;
        }

        /// <summary>
        /// computes dot-product
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public double Dot(Mat m)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            if (m == null)
                throw new ArgumentNullException("m");
            return CppInvoke.Mat_dot(ptr, m.CvPtr);
        }

        /// <summary>
        /// allocates new matrix data unless the matrix already has specified size and type.
        /// previous data is unreferenced if needed.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        public void Create(int rows, int cols, MatrixType type)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            CppInvoke.Mat_create(ptr, rows, cols, type);
        }
        /// <summary>
        /// allocates new matrix data unless the matrix already has specified size and type.
        /// previous data is unreferenced if needed.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public void Create(CvSize size, MatrixType type)
        {
            Create(size.Height, size.Width, type);
        }

        /// <summary>
        /// locates matrix header within a parent matrix.
        /// </summary>
        /// <param name="wholeSize"></param>
        /// <param name="ofs"></param>
        public void LocateROI(out CvSize wholeSize, out CvPoint ofs)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            CppInvoke.Mat_locateROI(ptr, out wholeSize, out ofs);
        }

        /// <summary>
        /// moves/resizes the current matrix ROI inside the parent matrix.
        /// </summary>
        /// <param name="dtop"></param>
        /// <param name="dbottom"></param>
        /// <param name="dleft"></param>
        /// <param name="dright"></param>
        /// <returns></returns>
        public Mat AdjustROI(int dtop, int dbottom, int dleft, int dright)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_adjustROI(ptr, dtop, dbottom, dleft, dright, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// matrix transposition by means of matrix expressions
        /// </summary>
        /// <returns></returns>
        public Mat T()
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_t(ptr, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// matrix inversion by means of matrix expressions
        /// </summary>
        /// <returns></returns>
        public Mat Inv(InvertMethod method = InvertMethod.LU)
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            Mat dst = new Mat();
            CppInvoke.Mat_inv(ptr, method, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// converts header to CvMat; no data is copied
        /// </summary>
        /// <returns></returns>
        public CvMat ToCvMat()
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            CvMat mat = new CvMat();
            mat.IsEnabledDispose = false;
            CppInvoke.Mat_opCvMat(ptr, mat.CvPtr);
            return mat;
        }
        /// <summary>
        /// converts header to IplImage; no data is copied
        /// </summary>
        /// <returns></returns>
        public IplImage ToIplImage()
        {
            if (disposed)
                throw new ObjectDisposedException("Mat");
            IplImage ipl = new IplImage();
            ipl.IsEnabledDispose = false;
            CppInvoke.Mat_opIplImage(ptr, ipl.CvPtr);
            return ipl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsContinuous()
        {
            return (Flags & CONTINUOUS_FLAG) != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public T At<T>(int y, int x)
        {
            return Get<T>(y, x);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pt"></param>
        /// <returns></returns>
        public T At<T>(CvPoint pt)
        {
            return Get<T>(pt.X, pt.Y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public T Get<T>(int y, int x)
        {
            IntPtr p = new IntPtr(Data.ToInt64() + (long)(Step * (uint)y) + (ElemSize * x)); 
            return (T)Marshal.PtrToStructure(p, typeof(T));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="value"></param>
        public void Set<T>(int y, int x, T value)
        {
            IntPtr p = new IntPtr(Data.ToInt64() + (long)(Step * (uint)y) + (ElemSize * x)); 
            /*
            using (StructurePointer<T> valuePtr = new StructurePointer<T>(value))
            {
                Util.CopyMemory(p, valuePtr, Marshal.SizeOf(typeof(T)));
            }
            //*/
            Marshal.StructureToPtr(value, p, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public IntPtr Ptr(int y = 0)
        {
            unsafe
            {
                return new IntPtr((byte*)Data + (y * Step));
            }
        }


        #region ToBitmap
#if LANG_JP
        /// <summary>
        /// System.Drawing.Bitmapに変換する
        /// </summary>
        /// <returns>System.Drawing.Bitmap</returns>
#else
        /// <summary>
        /// Converts Mat to System.Drawing.Bitmap
        /// </summary>
        /// <returns></returns>
#endif
        public Bitmap ToBitmap()
        {
            return BitmapConverter.ToBitmap(ToIplImage());
        }
#if LANG_JP
        /// <summary>
        /// System.Drawing.Bitmapに変換する
        /// </summary>
        /// <param name="pf">ピクセル深度</param>
        /// <returns>System.Drawing.Bitmap</returns>
#else
        /// <summary>
        /// Converts Mat to System.Drawing.Bitmap
        /// </summary>
        /// <param name="pf">Pixel Depth</param>
        /// <returns></returns>
#endif
        public Bitmap ToBitmap(PixelFormat pf)
        {
            return BitmapConverter.ToBitmap(ToIplImage(), pf);
        }

#if LANG_JP
        /// <summary>
        /// 指定した出力先にSystem.Drawing.Bitmapとして変換する
        /// </summary>
        /// <param name="dst">出力先のSystem.Drawing.Bitmap</param>
#else
        /// <summary>
        /// Converts Mat to System.Drawing.Bitmap
        /// </summary>
        /// <param name="dst">Bitmap</param>
#endif
        public void ToBitmap(Bitmap dst)
        {
            BitmapConverter.ToBitmap(ToIplImage(), dst);
        }
        #endregion
        #endregion
        #endregion
    }
}
