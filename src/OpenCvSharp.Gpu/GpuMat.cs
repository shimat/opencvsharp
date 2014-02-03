/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Utilities;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.Gpu
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
    public partial class GpuMat : DisposableCvObject, ICloneable
    {
        #region Fields
        /// <summary>
        /// sizeof(GpuMat)
        /// </summary>
        public static readonly int SizeOf;
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;
        #endregion

        #region Init and Disposal
        /// <summary>
        /// static constructor
        /// </summary>
        static GpuMat()
        {
            SizeOf = GpuInvoke.GpuMat_sizeof();
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
        public GpuMat()
        {
            ptr = GpuInvoke.GpuMat_new1();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        public GpuMat(int rows, int cols, MatrixType type)
        {
            if (rows <= 0)
                throw new ArgumentOutOfRangeException("rows");
            if (cols <= 0)
                throw new ArgumentOutOfRangeException("cols");
            ptr = GpuInvoke.GpuMat_new2(rows, cols, type);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="step"></param>
        public GpuMat(int rows, int cols, MatrixType type, IntPtr data, uint step)
        {
            if (rows <= 0)
                throw new ArgumentOutOfRangeException("rows");
            if (cols <= 0)
                throw new ArgumentOutOfRangeException("cols");
            ptr = GpuInvoke.GpuMat_new3(rows, cols, type, data, step);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public GpuMat(Mat m)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            ptr = GpuInvoke.GpuMat_new4(m.CvPtr);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public GpuMat(GpuMat m)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            ptr = GpuInvoke.GpuMat_new5(m.CvPtr);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public GpuMat(CvSize size, MatrixType type)
        {
            ptr = GpuInvoke.GpuMat_new6(size, type);
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
        public GpuMat(CvSize size, MatrixType type, IntPtr data, uint step)
        {
            ptr = GpuInvoke.GpuMat_new7(size, type, data, step);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="type"></param>
        /// <param name="s"></param>
        public GpuMat(int rows, int cols, MatrixType type, CvScalar s)
        {
            if (rows <= 0)
                throw new ArgumentOutOfRangeException("rows");
            if (cols <= 0)
                throw new ArgumentOutOfRangeException("cols");
            ptr = GpuInvoke.GpuMat_new8(rows, cols, type, (CvScalar)s);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rowRange"></param>
        /// <param name="colRange"></param>
        public GpuMat(GpuMat m, CvSlice rowRange, CvSlice colRange)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            ptr = GpuInvoke.GpuMat_new9(m.CvPtr, rowRange, colRange);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="roi"></param>
        public GpuMat(GpuMat m, CvRect roi)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            ptr = GpuInvoke.GpuMat_new10(m.CvPtr, (CvRect)roi);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="s"></param>
        public GpuMat(CvSize size, MatrixType type, CvScalar s)
        {
            ptr = GpuInvoke.GpuMat_new11(size, type, s);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
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
            if (!this._disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {                        
                    }
                    if (IsEnabledDispose)
                    {
                        GpuInvoke.GpuMat_delete(ptr);
                    }
                    this._disposed = true;
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
#if LANG_JP
        /// <summary>
        /// ビット反転演算子
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Unary bitwise complement operator
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
#endif
        public static GpuMat operator~(GpuMat src)
        {
            if (src == null)
                throw new ArgumentNullException("src");

            GpuMat dst = new GpuMat();
            GpuInvoke.GpuMat_opComplement(src.CvPtr, dst.CvPtr);
            return dst;
        }
        #endregion
        #region Binary
#if LANG_JP
        /// <summary>
        /// AND演算子
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Binary  bitwise AND operator
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
#endif
        public static GpuMat operator &(GpuMat src1, GpuMat src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");

            GpuMat dst = new GpuMat();
            GpuInvoke.GpuMat_opAnd(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            return dst;
        }
#if LANG_JP
        /// <summary>
        /// OR演算子
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Binary  bitwise OR operator
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
#endif
        public static GpuMat operator |(GpuMat src1, GpuMat src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");

            GpuMat dst = new GpuMat();
            GpuInvoke.GpuMat_opOr(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            return dst;
        }
#if LANG_JP
        /// <summary>
        /// XOR演算子
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Binary  bitwise XOR operator
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
#endif
        public static GpuMat operator ^(GpuMat src1, GpuMat src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");

            GpuMat dst = new GpuMat();
            GpuInvoke.GpuMat_opXor(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            return dst;
        }
        #endregion
        #region Cast
        /// <summary>
        /// converts header to CvMat; no data is copied
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static explicit operator GpuMat(Mat mat)
        {
            if (mat == null)
                return null;

            GpuMat gpumat = new GpuMat();
            GpuInvoke.GpuMat_opGpuMat(mat.CvPtr, gpumat.CvPtr);
            return gpumat;
        }
        /// <summary>
        /// converts header to IplImage; no data is copied
        /// </summary>
        /// <param name="gpumat"></param>
        /// <returns></returns>
        public static implicit operator Mat(GpuMat gpumat)
        {
            if (gpumat == null)
                return null;

            Mat mat = new Mat();
            GpuInvoke.GpuMat_opMat(gpumat.CvPtr, mat.CvPtr);
            return mat;
        }
        #endregion
        #region Indexer
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
                GpuInvoke.GpuMat_opRange1(ptr, roi, result.CvPtr);
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
                GpuInvoke.GpuMat_opRange2(ptr, rowRange, colRange, result.CvPtr);
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
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                return GpuInvoke.GpuMat_flags(ptr);
            }
        }
        /// <summary>
        /// the number of rows
        /// </summary>
        public int Rows
        {
            get 
            {
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                return GpuInvoke.GpuMat_rows(ptr); 
            }
        }
        /// <summary>
        /// the number of columns
        /// </summary>
        public int Cols
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                return GpuInvoke.GpuMat_cols(ptr);
            }
        }
        /// <summary>
        /// a distance between successive rows in bytes; includes the gap if any
        /// </summary>
        public uint Step
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                return GpuInvoke.GpuMat_step(ptr);
            }
        }
        /// <summary>
        /// pointer to the data
        /// </summary>
        public IntPtr Data
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                unsafe
                {
                    return (IntPtr)GpuInvoke.GpuMat_data(ptr);
                }
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
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                return (IntPtr)GpuInvoke.GpuMat_refcount(ptr);
            }
        }
        /// <summary>
        /// helper fields used in locateROI and adjustROI
        /// </summary>
        public IntPtr DataStart
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                return (IntPtr)GpuInvoke.GpuMat_datastart(ptr);
            }
        }
        /// <summary>
        /// helper fields used in locateROI and adjustROI
        /// </summary>
        public IntPtr DataEnd
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                return (IntPtr)GpuInvoke.GpuMat_dataend(ptr);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public MatrixType Type
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                return GpuInvoke.GpuMat_type(ptr);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public uint ElemSize
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                return GpuInvoke.GpuMat_elemSize(ptr);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public uint ElemSize1
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                return GpuInvoke.GpuMat_elemSize1(ptr);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Depth 
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                return GpuInvoke.GpuMat_depth(ptr);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Channels
        {
            get 
            {
                if (_disposed)
                    throw new ObjectDisposedException("GpuMat");
                return GpuInvoke.GpuMat_channels(ptr);
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


        #endregion

        #region Methods
        #region Static methods
        #endregion
        #region Instance methods
        /// <summary>
        /// returns a new matrix header for the specified row
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public GpuMat Row(int y)
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            GpuMat outValue = new GpuMat();
            GpuInvoke.GpuMat_row(ptr, y, outValue.CvPtr);
            return outValue;
        }
        /// <summary>
        /// returns a new matrix header for the specified column
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public GpuMat Col(int x)
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            GpuMat outValue = new GpuMat();
            GpuInvoke.GpuMat_col(ptr, x, outValue.CvPtr);
            return outValue;
        }
        /// <summary>
        /// returns a new matrix header for the specified row span
        /// </summary>
        /// <param name="startrow"></param>
        /// <param name="endrow"></param>
        /// <returns></returns>
        public GpuMat RowRange(int startrow, int endrow)
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            GpuMat outValue = new GpuMat();
            GpuInvoke.GpuMat_rowRange(ptr, startrow, endrow, outValue.CvPtr);
            return outValue;
        }
        /// <summary>
        /// returns a new matrix header for the specified row span
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public GpuMat RowRange(CvSlice r)
        {
            return RowRange(r.StartIndex, r.EndIndex);
        }
        /// <summary>
        /// returns a new matrix header for the specified column span
        /// </summary>
        /// <param name="startcol"></param>
        /// <param name="endcol"></param>
        /// <returns></returns>
        public GpuMat ColRange(int startcol, int endcol) 
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            GpuMat outValue = new GpuMat();
            GpuInvoke.GpuMat_colRange(ptr, startcol, endcol, outValue.CvPtr);
            return outValue;
        }
        /// <summary>
        /// returns a new matrix header for the specified column span
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public GpuMat ColRange(CvSlice r)
        {
            return ColRange(r.StartIndex, r.EndIndex);
        }

        /// <summary>
        /// returns deep copy of the matrix, i.e. the data is copied
        /// </summary>
        /// <returns></returns>
        public GpuMat Clone()
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            GpuMat outValue = new GpuMat();
            GpuInvoke.GpuMat_clone(ptr, outValue.CvPtr);
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
        public void CopyTo(GpuMat m)
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            if (m == null)
                throw new ArgumentNullException("m");
            GpuInvoke.GpuMat_copyTo1(ptr, m.CvPtr);
        }
        /// <summary>
        /// copies those matrix elements to "m" that are marked with non-zero mask elements.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="mask"></param>
        public void CopyTo(GpuMat m, GpuMat mask)
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            if (m == null)
                throw new ArgumentNullException("m");
            if (mask == null)
                throw new ArgumentNullException("mask");
            GpuInvoke.GpuMat_copyTo2(ptr, m.CvPtr, mask.CvPtr);
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
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            GpuInvoke.GpuMat_convertTo(ptr, dst.CvPtr, (int)rtype, alpha, beta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public void AssignTo(GpuMat m)
        {
            GpuInvoke.GpuMat_assignTo(ptr, m.CvPtr, -1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="type"></param>
        public void AssignTo(GpuMat m, MatrixType type)
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            if (m == null)
                throw new ArgumentNullException("m");
            GpuInvoke.GpuMat_assignTo(ptr, m.CvPtr, (int)type);
        }

        /// <summary>
        /// sets some of the matrix elements to s, according to the mask
        /// </summary>
        /// <param name="s"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public GpuMat SetTo(CvScalar s, GpuMat mask = null)
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            GpuMat dst = new GpuMat();
            GpuInvoke.GpuMat_setTo(ptr, s, maskPtr, dst.CvPtr);
            return dst;
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
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            GpuMat outValue = new GpuMat();
            GpuInvoke.GpuMat_reshape(ptr, cn, rows, outValue.CvPtr);
            return outValue;
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
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            GpuInvoke.GpuMat_create1(ptr, rows, cols, type);
        }
        /// <summary>
        /// allocates new matrix data unless the matrix already has specified size and type.
        /// previous data is unreferenced if needed.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public void Create(CvSize size, MatrixType type)
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            GpuInvoke.GpuMat_create2(ptr, size, type);
        }
        /*
        /// <summary>
        /// decreases reference counter;
        /// deallocate the data when reference counter reaches 0.
        /// </summary>
        public void Release()
        {
            if (disposed)
                throw new ObjectDisposedException("GpuMat");
            CppInvoke.gpu_GpuMat_release(_ptr);
        }
        //*/
        /// <summary>
        /// swaps with other smart pointer
        /// </summary>
        /// <param name="mat"></param>
        public void Swap(GpuMat mat)
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            if (mat == null)
                throw new ArgumentNullException("mat");
            GpuInvoke.GpuMat_swap(ptr, mat.CvPtr);
        }
        /// <summary>
        /// locates matrix header within a parent matrix.
        /// </summary>
        /// <param name="wholeSize"></param>
        /// <param name="ofs"></param>
        public void LocateROI(out CvSize wholeSize, out CvPoint ofs)
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            GpuInvoke.GpuMat_locateROI(ptr, out wholeSize, out ofs);
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
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            GpuMat dst = new GpuMat();
            GpuInvoke.GpuMat_adjustROI(ptr, dtop, dbottom, dleft, dright, dst.CvPtr);
            return dst;
        }

        /// <summary>
        /// matrix transposition by means of matrix expressions
        /// </summary>
        /// <returns></returns>
        public GpuMat T()
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            GpuMat dst = new GpuMat();
            GpuInvoke.GpuMat_t(ptr, dst.CvPtr);
            return dst;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsContinuous()
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            return GpuInvoke.GpuMat_isContinuous(ptr);
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
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
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
        public unsafe byte* Ptr(int y = 0)
        {
            if (_disposed)
                throw new ObjectDisposedException("GpuMat");
            return GpuInvoke.GpuMat_ptr(ptr, y);
        }
        #endregion
        #endregion
    }
}
