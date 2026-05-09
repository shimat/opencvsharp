#if ENABLED_CUDA

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    //https://docs.opencv.org/3.4/d0/d60/classcv_1_1cuda_1_1GpuMat.html
    /// <summary>
    /// Smart pointer for GPU memory with reference counting. Its interface is mostly similar with cv::Mat.
    /// </summary>
    public class GpuMat : CvObject
    {
        #region Init and Disposal

        /// <summary>
        /// Creates from native cv::gpu::GpuMat* pointer
        /// </summary>
        /// <param name="ptr"></param>
        public GpuMat(IntPtr ptr)
        {
            ThrowIfNotAvailable();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Native object address is NULL");
            InitSafeHandle(ptr);
        }

        /// <summary>
        /// Creates empty GpuMat
        /// </summary>
        public GpuMat()
        {
            ThrowIfNotAvailable();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_new1(out IntPtr p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException();
            InitSafeHandle(p);
        }

        /// <summary>
        /// constructs 2D matrix of the specified size and type
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
        public GpuMat(int rows, int cols, MatType type)
        {
            ThrowIfNotAvailable();
            if (rows <= 0)
                throw new ArgumentOutOfRangeException(nameof(rows));
            if (cols <= 0)
                throw new ArgumentOutOfRangeException(nameof(cols));
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_new2(rows, cols, (int)type, out IntPtr p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException();
            InitSafeHandle(p);
        }

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
        public GpuMat(int rows, int cols, MatType type, IntPtr data, long step)
        {
            ThrowIfNotAvailable();
            if (rows <= 0)
                throw new ArgumentOutOfRangeException(nameof(rows));
            if (cols <= 0)
                throw new ArgumentOutOfRangeException(nameof(cols));
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_new3(rows, cols, (int)type, data, (ulong)step, out IntPtr p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException();
            InitSafeHandle(p);
        }

        /// <summary>
        /// constructs 2D matrix of the specified size and type
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) </param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType.CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
        public GpuMat(Size size, MatType type)
        {
            ThrowIfNotAvailable();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_new6(size, (int)type, out IntPtr p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException();
            InitSafeHandle(p);
        }

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
        public GpuMat(Size size, MatType type, IntPtr data, long step = 0)
        {
            ThrowIfNotAvailable();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_new7(size, (int)type, data, (ulong)step, out IntPtr p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException();
            InitSafeHandle(p);
        }

        /// <summary>
        /// creates a matrix for other matrix
        /// </summary>
        /// <param name="m">Array that (as a whole) is assigned to the constructed matrix.</param>
        public GpuMat(Mat m)
        {
            ThrowIfNotAvailable();
            if (m is null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_new4(m.CvPtr, out IntPtr p));
            GC.KeepAlive(m);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException();
            InitSafeHandle(p);
        }

        /// <summary>
        /// creates a matrix for other matrix
        /// </summary>
        /// <param name="m">GpuMat that (as a whole) is assigned to the constructed matrix.</param>
        public GpuMat(GpuMat m)
        {
            ThrowIfNotAvailable();
            if (m is null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_new5(m.CvPtr, out IntPtr p));
            GC.KeepAlive(m);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException();
            InitSafeHandle(p);
        }

        /// <summary>
        /// constucts 2D matrix and fills it with the specified Scalar value.
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
        public GpuMat(int rows, int cols, MatType type, Scalar s)
        {
            ThrowIfNotAvailable();
            if (rows <= 0)
                throw new ArgumentOutOfRangeException(nameof(rows));
            if (cols <= 0)
                throw new ArgumentOutOfRangeException(nameof(cols));
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_new8(rows, cols, (int)type, s, out IntPtr p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException();
            InitSafeHandle(p);
        }

        /// <summary>
        /// constucts 2D matrix and fills it with the specified Scalar value.
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) .</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
        public GpuMat(Size size, MatType type, Scalar s)
        {
            ThrowIfNotAvailable();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_new11(size, (int)type, s, out IntPtr p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException();
            InitSafeHandle(p);
        }

        /// <summary>
        /// creates a matrix header for a part of the bigger matrix
        /// </summary>
        /// <param name="m">Array that (as a whole or partly) is assigned to the constructed matrix. </param>
        /// <param name="rowRange">Range of the m rows to take. As usual, the range start is inclusive and the range end is exclusive. 
        /// Use Range.All to take all the rows.</param>
        /// <param name="colRange">Range of the m columns to take. Use Range.All to take all the columns.</param>
        public GpuMat(GpuMat m, Range rowRange, Range colRange)
        {
            ThrowIfNotAvailable();
            if (m is null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_new9(m.CvPtr, rowRange, colRange , out IntPtr p));
            GC.KeepAlive(m);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException();
            InitSafeHandle(p);
        }

        /// <summary>
        /// creates a matrix header for a part of the bigger matrix
        /// </summary>
        /// <param name="m">Array that (as a whole or partly) is assigned to the constructed matrix..</param>
        /// <param name="roi">Region of interest.</param>
        public GpuMat(GpuMat m, Rect roi)
        {
            ThrowIfNotAvailable();
            if (m is null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_new10(m.CvPtr, roi, out IntPtr p));
            GC.KeepAlive(m);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException();
            InitSafeHandle(p);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        public void Release()
        {
            Dispose();
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>

        private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
        {
            SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
                static h => NativeMethods.cuda_GpuMat_delete(h)));
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
            if (mat is null)
                return null;

            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_opToGpuMat(mat.CvPtr, out IntPtr ret));
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
            if (gpumat is null)
                return null;

            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_opToMat(gpumat.CvPtr, out IntPtr ret));
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
                NativeMethods.HandleException(NativeMethods.cuda_GpuMat_flags(CvPtr, out int ret));
                return ret;
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
                NativeMethods.HandleException(NativeMethods.cuda_GpuMat_rows(CvPtr, out int ret));
                return ret;
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
                NativeMethods.HandleException(NativeMethods.cuda_GpuMat_cols(CvPtr, out int ret));
                return ret;
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
                NativeMethods.HandleException(NativeMethods.cuda_GpuMat_rows(CvPtr, out int ret));
                return ret;
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
                NativeMethods.HandleException(NativeMethods.cuda_GpuMat_cols(CvPtr, out int ret));
                return ret;
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
                NativeMethods.HandleException(NativeMethods.cuda_GpuMat_data(CvPtr, out IntPtr ret));
                return ret;
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
                NativeMethods.HandleException(NativeMethods.cuda_GpuMat_refcount(CvPtr, out IntPtr ret));
                return ret;
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
                NativeMethods.HandleException(NativeMethods.cuda_GpuMat_datastart(CvPtr, out IntPtr ret));
                return ret;
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
                NativeMethods.HandleException(NativeMethods.cuda_GpuMat_dataend(CvPtr, out IntPtr ret));
                return ret;
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

        /// <summary>
        /// Returns the raw CUDA device pointer to the matrix data.
        /// </summary>
        public IntPtr CudaPtr
        {
            get
            {
                ThrowIfDisposed();

                NativeMethods.HandleException(
                    NativeMethods.cuda_GpuMat_cudaPtr(CvPtr, out IntPtr ptr));

                GC.KeepAlive(this);
                return ptr;
            }
        }

        /// <summary>
        /// Internal use method: updates the continuity flag.
        /// Call this if you manually manipulate the GpuMat data pointer or step.
        /// </summary>
        public void UpdateContinuityFlag()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_updateContinuityFlag(CvPtr));
            GC.KeepAlive(this);
        }

        #endregion
        #region Static Allocators
        /// <summary>
        /// Returns the default allocator.
        /// </summary>
        public static IntPtr DefaultAllocator()
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_defaultAllocator(out IntPtr ptr));
            return ptr;
        }

        /// <summary>
        /// Returns the standard allocator.
        /// </summary>
        public static IntPtr GetStdAllocator()
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_getStdAllocator(out IntPtr ptr));
            return ptr;
        }

        /// <summary>
        /// Sets the default allocator.
        /// </summary>
        /// <param name="allocator">Pointer to a custom GpuMat::Allocator instance.</param>
        public static void SetDefaultAllocator(IntPtr allocator)
        {
            if (allocator == IntPtr.Zero)
                throw new ArgumentNullException(nameof(allocator));

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_setDefaultAllocator(allocator));
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
                NativeMethods.HandleException(NativeMethods.cuda_GpuMat_opRange1(CvPtr, roi, out IntPtr ret));
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
                NativeMethods.HandleException(NativeMethods.cuda_GpuMat_opRange2(CvPtr, rowRange, colRange, out IntPtr ret));
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
                    NativeMethods.HandleException(NativeMethods.cuda_GpuMat_colRange(CvPtr, startcol, endcol, out IntPtr ret));
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
                            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_col(parent.ptr, x, out IntPtr matPtr));
                            GC.KeepAlive(this);
                            return new GpuMat(matPtr);
                        }
                        set
                        {
                            parent.ThrowIfDisposed();
                            if (value is null)
                                throw new ArgumentNullException(nameof(value));
                            value.ThrowIfDisposed();

                            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_col(parent.ptr, x, out IntPtr matPtr));
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
                            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_colRange(parent.ptr, startCol, endCol, out IntPtr matPtr));
                            GC.KeepAlive(this);
                            return new GpuMat(matPtr);
                        }
                        set
                        {
                            parent.ThrowIfDisposed();
                            if (value is null)
                                throw new ArgumentNullException(nameof(value));
                            value.ThrowIfDisposed();

                            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_colRange(parent.ptr, startCol, endCol, out IntPtr colMatPtr));
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
                    NativeMethods.HandleException(NativeMethods.cuda_GpuMat_rowRange(CvPtr, startrow, endrow, out IntPtr ret));
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
                            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_row(parent.ptr, x, out IntPtr matPtr));
                            GC.KeepAlive(this);
                            return new GpuMat(matPtr);
                        }
                        set
                        {
                            parent.ThrowIfDisposed();
                            if (value is null)
                                throw new ArgumentNullException(nameof(value));
                            value.ThrowIfDisposed();

                            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_row(parent.ptr, x, out IntPtr matPtr));
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
                            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_rowRange(parent.ptr, startCol, endCol, out IntPtr matPtr));
                            GC.KeepAlive(this);
                            return new GpuMat(matPtr);
                        }
                        set
                        {
                            parent.ThrowIfDisposed();
                            if (value is null)
                                throw new ArgumentNullException(nameof(value));
                            value.ThrowIfDisposed();

                            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_rowRange(parent.ptr, startCol, endCol, out IntPtr matPtr));
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
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_isContinuous(CvPtr, out int res));
            GC.KeepAlive(this);
            return res !=0;
        }

        /// <summary>
        /// Returns the number of matrix channels.
        /// </summary>
        /// <returns></returns>
        public int Channels()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_channels(CvPtr, out int res));
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
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_depth(CvPtr, out int res));
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
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_elemSize(CvPtr, out ulong res));
            GC.KeepAlive(this);
            return (long)res;
        }

        /// <summary>
        /// Returns the size of each matrix element channel in bytes.
        /// </summary>
        /// <returns></returns>
        public long ElemSize1()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_elemSize1(CvPtr, out ulong res));
            GC.KeepAlive(this);
            return (long)res;
        }

        /// <summary>
        /// Returns a matrix size.
        /// </summary>
        /// <returns></returns>
        public Size Size()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_size(CvPtr, out OpenCvSharp.Size res));
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// a distance between successive rows in bytes; includes the gap if any
        /// </summary>
        public long Step()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_step(CvPtr, out ulong res));
            GC.KeepAlive(this);
            return (long)res;
        }

        /// <summary>
        /// Returns a normalized step.
        /// </summary>
        public long Step1()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_step1(CvPtr, out ulong res));
            GC.KeepAlive(this);
            return (long)res;
        }

        /// <summary>
        /// Returns the type of a matrix element.
        /// </summary>
        /// <returns></returns>
        public MatType Type()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_type(CvPtr, out int res));
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
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_empty(CvPtr, out int res));
            GC.KeepAlive(this);
            return res != 0;
        }

        /// <summary>
        /// Pefroms blocking upload data to GpuMat.
        /// </summary>
        /// <param name="m"></param>
        public void Upload(OpenCvSharp.InputArray m)
        {
            ThrowIfDisposed();
            NativeMethods.cuda_GpuMat_upload(CvPtr, m.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }

        /// <summary>
        /// Performs non-blocking upload data to GpuMat.
        /// </summary>
        public void Upload(OpenCvSharp.InputArray m, Stream stream)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            ThrowIfDisposed();
            // Use m.CvPtr instead of arr.CvPtr
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_upload_stream(CvPtr, m.CvPtr, stream.CvPtr));
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            GC.KeepAlive(stream);
        }

        /// <summary>
        /// Downloads data from device to host memory. Blocking calls.
        /// </summary>
        /// <param name="m"></param>
        public void Download(OpenCvSharp.OutputArray m)
        {
            ThrowIfDisposed();
            NativeMethods.cuda_GpuMat_download(CvPtr, m.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }
        /// <summary>
        /// Performs non-blocking download data from GpuMat.
        /// </summary>
        public void Download(OpenCvSharp.OutputArray m, Stream stream)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_download_stream(CvPtr, m.CvPtr, stream.CvPtr));
            GC.KeepAlive(this);
            GC.KeepAlive(m);
            GC.KeepAlive(stream);
        }

        /// <summary>
        /// returns deep copy of the matrix, i.e. the data is copied
        /// </summary>
        /// <returns></returns>
        public GpuMat Clone()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_clone(CvPtr, out IntPtr ret));
            GC.KeepAlive(this);
            return new GpuMat(ret);
        }

        #region CopyTo

        /// <summary>
        /// bindings overload which copies the GpuMat content to device memory (Blocking call) 
        /// </summary>
        public void CopyTo(GpuMat dst)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_copyTo1(CvPtr, dst.CvPtr,  IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// bindings overload which copies those GpuMat elements to "m" that are marked with non-zero mask elements (Blocking call)
        /// </summary>
        public void CopyTo(GpuMat dst, GpuMat mask)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (mask == null)
                throw new ArgumentNullException(nameof(dst));

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_copyTo_mask1(CvPtr, dst.CvPtr, mask.CvPtr, IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// bindings overload which copies those GpuMat elements to "m" that are marked with non-zero mask elements (Non-Blocking call) 
        /// </summary>
        public void CopyTo(GpuMat dst, GpuMat mask, OpenCvSharp.Cuda.Stream? stream = null)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (mask == null)
                throw new ArgumentNullException(nameof(dst));

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_copyTo_mask1(CvPtr, dst.CvPtr, mask.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// bindings overload which copies the GpuMat content to device memory (Non-Blocking call) 
        /// </summary>
        public void CopyTo(GpuMat dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_copyTo1(CvPtr, dst.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// bindings overload which copies the GpuMat content to device memory (Blocking call) 
        /// </summary>
        public void CopyTo(OpenCvSharp.Cuda.OutputArray dst)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_copyTo2(CvPtr, dst.CvPtr, IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// bindings overload which copies those GpuMat elements to "m" that are marked with non-zero mask elements (Blocking call)
        /// </summary>
        public void CopyTo(OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.InputArray mask)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (mask == null)
                throw new ArgumentNullException(nameof(dst));

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_copyTo_mask2(CvPtr, dst.CvPtr, mask.CvPtr, IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// bindings overload which copies those GpuMat elements to "m" that are marked with non-zero mask elements (Non-Blocking call) 
        /// </summary>
        public void CopyTo(OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.InputArray mask, OpenCvSharp.Cuda.Stream? stream = null)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (mask == null)
                throw new ArgumentNullException(nameof(dst));

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_copyTo_mask2(CvPtr, dst.CvPtr, mask.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
        }

        /// <summary>
        /// bindings overload which copies the GpuMat content to device memory (Non-Blocking call) 
        /// </summary>
        public void CopyTo(OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_copyTo2(CvPtr, dst.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(this);
        }

        #endregion

        #region ConvertTo

        /// <summary>
        /// bindings overload which converts GpuMat to another datatype (Blocking call) 
        /// </summary>
        public void ConvertTo(GpuMat dst, MatType rtype)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_convertTo1(CvPtr, dst.CvPtr, rtype.Value, 1.0, 0.0, IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// bindings overload which converts GpuMat to another datatype with scaling (Non-Blocking call) 
        /// </summary>
        public void ConvertTo(GpuMat dst, MatType rtype, double alpha, double beta, Stream stream)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_convertTo1(CvPtr, dst.CvPtr, rtype.Value, alpha, beta, stream?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// bindings overload which converts GpuMat to another datatype (Non-Blocking call) 
        /// </summary>
        public void ConvertTo(GpuMat dst, MatType rtype, Stream stream)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_convertTo1(CvPtr, dst.CvPtr, rtype.Value, 1.0, 0.0, stream?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// converts GpuMat to another datatype (Blocking call) 
        /// </summary>
        public void ConvertTo(OpenCvSharp.Cuda.OutputArray dst, MatType rtype)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_convertTo2(CvPtr, dst.CvPtr, rtype.Value, 1.0, 0.0, IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// converts GpuMat to another datatype with scaling (Non-Blocking call) 
        /// </summary>
        public void ConvertTo(OpenCvSharp.Cuda.OutputArray dst, MatType rtype, double alpha, double beta, Stream? stream = null)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_convertTo2(CvPtr, dst.CvPtr, rtype.Value, alpha, beta, stream?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(this);
        }


        /// <summary>
        /// converts GpuMat to another datatype with scaling (Blocking call) 
        /// </summary>
        public void ConvertTo(OpenCvSharp.Cuda.OutputArray dst, MatType rtype, double alpha, double beta = 0.0)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_convertTo2(CvPtr, dst.CvPtr, rtype.Value, alpha, beta,  IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// bindings overload which converts GpuMat to another datatype with scaling(Blocking call) 
        /// </summary>
        public void ConvertTo(OpenCvSharp.Cuda.OutputArray dst, MatType rtype, double alpha, Stream stream)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_convertTo2(CvPtr, dst.CvPtr, rtype.Value, alpha, 0.0, stream?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// converts GpuMat to another datatype (Non-Blocking call) 
        /// </summary>
        public void ConvertTo(OutputArray dst, MatType rtype, Stream stream)
        {
            ThrowIfDisposed();
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMat_convertTo2(CvPtr, dst.CvPtr, rtype.Value, 1.0, 0.0, stream?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(dst);
            GC.KeepAlive(this);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public void AssignTo(GpuMat m)
        {
            ThrowIfDisposed();
            NativeMethods.cuda_GpuMat_assignTo(CvPtr, m.CvPtr, -1);
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
            if (m is null)
                throw new ArgumentNullException(nameof(m));
            NativeMethods.cuda_GpuMat_assignTo(CvPtr, m.CvPtr, (int)type);
            GC.KeepAlive(this);
            GC.KeepAlive(m);
        }

        /// <summary>
        /// sets some of the matrix elements to s, according to the mask
        /// </summary>
        /// <param name="s"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public GpuMat SetTo(Scalar s)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_setTo(CvPtr, s, IntPtr.Zero, out IntPtr ret));
            GC.KeepAlive(this);
            return new GpuMat(ret);
        }

        /// <summary>
        /// sets some of the matrix elements to s, according to the mask
        /// </summary>
        /// <param name="s"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public GpuMat SetTo(Scalar s, OpenCvSharp.Cuda.InputArray mask)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_setTo(CvPtr, s, Cv2.ToPtr(mask), out IntPtr ret));
            GC.KeepAlive(this);
            GC.KeepAlive(mask);
            return new GpuMat(ret);
        }

        /// <summary>
        /// sets some of the GpuMat elements to s, according to the mask (Non-Blocking call)
        /// </summary>
        public void SetTo(Scalar s, OpenCvSharp.Cuda.InputArray mask, Stream stream)
        {
            if (stream == null) 
                throw new ArgumentNullException(nameof(stream));
            ThrowIfDisposed();
            // We use Cv2.ToPtr helper to handle the case where mask might be null
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_setTo_stream(CvPtr, s, Cv2.ToPtr(mask), stream.CvPtr, out _));
            GC.KeepAlive(this);
            GC.KeepAlive(mask);
            GC.KeepAlive(stream);
        }

        /// <summary>
        /// sets some of the GpuMat elements to s, according to the mask (Non-Blocking call)
        /// </summary>
        public void SetTo(Scalar s,  Stream stream)
        {
            if (stream == null) 
                throw new ArgumentNullException(nameof(stream));
            ThrowIfDisposed();
            // We use Cv2.ToPtr helper to handle the case where mask might be null
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_setTo_stream(CvPtr, s, IntPtr.Zero, stream.CvPtr, out _));
            GC.KeepAlive(this);
            GC.KeepAlive(stream);
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
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_reshape(CvPtr, cn, rows, out IntPtr ret));
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
            NativeMethods.cuda_GpuMat_create1(CvPtr, rows, cols, (int)type);
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
            NativeMethods.cuda_GpuMat_create2(CvPtr, size, (int)type);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// swaps with other smart pointer
        /// </summary>
        /// <param name="mat"></param>
        public void Swap(GpuMat mat)
        {
            ThrowIfDisposed();
            if (mat is null)
                throw new ArgumentNullException(nameof(mat));
            NativeMethods.cuda_GpuMat_swap(CvPtr, mat.CvPtr);
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
            NativeMethods.cuda_GpuMat_locateROI(CvPtr, out wholeSize, out ofs);
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
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_adjustROI(CvPtr, dtop, dbottom, dleft, dright, out IntPtr ret));
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
            NativeMethods.HandleException(NativeMethods.cuda_GpuMat_ptr(CvPtr, y, out IntPtr res));
            GC.KeepAlive(this);
            return (byte*)res;
        }

        /// <summary>
        /// Returns a string that represents this Mat.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "GpuMat [ " +
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
            if (Cv2.Cuda.GetCudaEnabledDeviceCount() < 1)
                throw new OpenCvSharpException("GPU module cannot be used.");
        }

    }
}

#endif
