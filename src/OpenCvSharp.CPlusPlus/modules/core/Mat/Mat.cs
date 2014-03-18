using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// OpenCV C++ n-dimensional dense array class (cv::Mat)
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
        /// Creates empty Mat
        /// </summary>
        public Mat()
        {
            ptr = CppInvoke.core_Mat_new1();
        }


        /// <summary>
        /// Loads an image from a file.
        /// </summary>
        /// <param name="fileName">Name of file to be loaded.</param>
        /// <param name="flags">Specifies color type of the loaded image</param>
        public Mat(string fileName, LoadMode flags = LoadMode.Color)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            ptr = CppInvoke.highgui_imread(fileName, (int)flags);
        }

        /// <summary>
        /// constructs 2D matrix of the specified size and type
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        public Mat(int rows, int cols, MatType type)
        {
            ptr = CppInvoke.core_Mat_new2(rows, cols, type);
        }

        /// <summary>
        /// constructs 2D matrix of the specified size and type
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) . In the Size() constructor, 
        /// the number of rows and the number of columns go in the reverse order.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        public Mat(Size size, MatType type)
        {
            ptr = CppInvoke.core_Mat_new2(size.Width, size.Height, type);
        }

        /// <summary>
        /// constucts 2D matrix and fills it with the specified Scalar value.
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
        public Mat(int rows, int cols, MatType type, Scalar s)
        {
            ptr = CppInvoke.core_Mat_new3(rows, cols, type, s);
        }

        /// <summary>
        /// constucts 2D matrix and fills it with the specified Scalar value.
        /// </summary>
        /// <param name="size">2D array size: Size(cols, rows) . In the Size() constructor, 
        /// the number of rows and the number of columns go in the reverse order.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
        public Mat(Size size, MatType type, Scalar s)
        {
            ptr = CppInvoke.core_Mat_new3(size.Width, size.Height, type, s);
        }

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
        public Mat(Mat m, Range rowRange, Range? colRange = null)
        {
            if (colRange.HasValue)
                ptr = CppInvoke.core_Mat_new4(m.ptr, rowRange, colRange.Value);
            else
                ptr = CppInvoke.core_Mat_new5(m.ptr, rowRange);
        }

        /// <summary>
        /// creates a matrix header for a part of the bigger matrix
        /// </summary>
        /// <param name="m">Array that (as a whole or partly) is assigned to the constructed matrix. 
        /// No data is copied by these constructors. Instead, the header pointing to m data or its sub-array 
        /// is constructed and associated with it. The reference counter, if any, is incremented. 
        /// So, when you modify the matrix formed using such a constructor, you also modify the corresponding elements of m . 
        /// If you want to have an independent copy of the sub-array, use Mat::clone() .</param>
        /// <param name="ranges">Array of selected ranges of m along each dimensionality.</param>
        public Mat(Mat m, params Range[] ranges)
        {
            ptr = CppInvoke.core_Mat_new6(m.ptr, ranges);
        }

        /// <summary>
        /// creates a matrix header for a part of the bigger matrix
        /// </summary>
        /// <param name="m"></param>
        /// <param name="roi">Region of interest.</param>
        public Mat(Mat m, Rect roi)
        {
            ptr = CppInvoke.core_Mat_new7(m.ptr, roi);
        }

        /// <summary>
        /// constructor for matrix headers pointing to user-allocated data
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        /// <param name="data">Pointer to the user data. Matrix constructors that take data and step parameters do not allocate matrix data. 
        /// Instead, they just initialize the matrix header that points to the specified data, which means that no data is copied. 
        /// This operation is very efficient and can be used to process external data using OpenCV functions. 
        /// The external data is not automatically deallocated, so you should take care of it.</param>
        /// <param name="step">Number of bytes each matrix row occupies. The value should include the padding bytes at the end of each row, if any.
        /// If the parameter is missing (set to AUTO_STEP ), no padding is assumed and the actual step is calculated as cols*elemSize() .</param>
        public Mat(int rows, int cols, MatType type, IntPtr data, long step = 0)
        {
            ptr = CppInvoke.core_Mat_new8(rows, cols, type, data, new IntPtr(step));
        }

        /// <summary>
        /// constructor for matrix headers pointing to user-allocated data
        /// </summary>
        /// <param name="rows">Number of rows in a 2D array.</param>
        /// <param name="cols">Number of columns in a 2D array.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        /// <param name="data">Pointer to the user data. Matrix constructors that take data and step parameters do not allocate matrix data. 
        /// Instead, they just initialize the matrix header that points to the specified data, which means that no data is copied. 
        /// This operation is very efficient and can be used to process external data using OpenCV functions. 
        /// The external data is not automatically deallocated, so you should take care of it.</param>
        /// <param name="step">Number of bytes each matrix row occupies. The value should include the padding bytes at the end of each row, if any.
        /// If the parameter is missing (set to AUTO_STEP ), no padding is assumed and the actual step is calculated as cols*elemSize() .</param>
        public Mat(int rows, int cols, MatType type, Array data, long step = 0)
        {
            GCHandle handle = AllocGCHandle(data);
            ptr = CppInvoke.core_Mat_new8(rows, cols, type,
                handle.AddrOfPinnedObject(), new IntPtr(step));
        }

        /// <summary>
        /// constructor for matrix headers pointing to user-allocated data
        /// </summary>
        /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        /// <param name="data">Pointer to the user data. Matrix constructors that take data and step parameters do not allocate matrix data. 
        /// Instead, they just initialize the matrix header that points to the specified data, which means that no data is copied. 
        /// This operation is very efficient and can be used to process external data using OpenCV functions. 
        /// The external data is not automatically deallocated, so you should take care of it.</param>
        /// <param name="steps">Array of ndims-1 steps in case of a multi-dimensional array (the last step is always set to the element size). 
        /// If not specified, the matrix is assumed to be continuous.</param>
        public Mat(IEnumerable<int> sizes, MatType type, IntPtr data, IEnumerable<long> steps = null)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            if (data == IntPtr.Zero)
                throw new ArgumentNullException("data");
            int[] sizesArray = EnumerableEx.ToArray(sizes);
            if (steps == null)
            {
                ptr = CppInvoke.core_Mat_new9(sizesArray.Length, sizesArray, type, data, IntPtr.Zero);
            }
            else
            {
                IntPtr[] stepsArray = EnumerableEx.SelectToArray(steps, delegate(long s)
                {
                    return new IntPtr(s);
                });
                ptr = CppInvoke.core_Mat_new9(sizesArray.Length, sizesArray, type, data, stepsArray);
            }
        }

        /// <summary>
        /// constructor for matrix headers pointing to user-allocated data
        /// </summary>
        /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        /// <param name="data">Pointer to the user data. Matrix constructors that take data and step parameters do not allocate matrix data. 
        /// Instead, they just initialize the matrix header that points to the specified data, which means that no data is copied. 
        /// This operation is very efficient and can be used to process external data using OpenCV functions. 
        /// The external data is not automatically deallocated, so you should take care of it.</param>
        /// <param name="steps">Array of ndims-1 steps in case of a multi-dimensional array (the last step is always set to the element size). 
        /// If not specified, the matrix is assumed to be continuous.</param>
        public Mat(IEnumerable<int> sizes, MatType type, Array data, IEnumerable<long> steps = null)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            if (data == null)
                throw new ArgumentNullException("data");

            GCHandle handle = AllocGCHandle(data);
            int[] sizesArray = EnumerableEx.ToArray(sizes);
            if (steps == null)
            {
                ptr = CppInvoke.core_Mat_new9(sizesArray.Length, sizesArray,
                    type, handle.AddrOfPinnedObject(), IntPtr.Zero);
            }
            else
            {
                IntPtr[] stepsArray = EnumerableEx.SelectToArray(steps, delegate(long s)
                {
                    return new IntPtr(s);
                });
                ptr = CppInvoke.core_Mat_new9(sizesArray.Length, sizesArray,
                    type, handle.AddrOfPinnedObject(), stepsArray);
            }
        }

        /// <summary>
        /// constructs n-dimensional matrix
        /// </summary>
        /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        public Mat(IEnumerable<int> sizes, MatType type)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");

            int[] sizesArray = EnumerableEx.ToArray(sizes);
            ptr = CppInvoke.core_Mat_new10(sizesArray.Length, sizesArray, type);
        }

        /// <summary>
        /// constructs n-dimensional matrix
        /// </summary>
        /// <param name="sizes"></param>
        /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
        /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
        /// <param name="s">An optional value to initialize each matrix element with. 
        /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
        public Mat(IEnumerable<int> sizes, MatType type, Scalar s)
        {
            if (sizes == null)
                throw new ArgumentNullException("sizes");
            int[] sizesArray = EnumerableEx.ToArray(sizes);
            ptr = CppInvoke.core_Mat_new11(sizesArray.Length, sizesArray, type, s);
        }

        /// <summary>
        /// converts old-style CvMat to the new matrix; the data is not copied by default
        /// </summary>
        /// <param name="m">Old style CvMat object</param>
        /// <param name="copyData">Flag to specify whether the underlying data of the the old-style CvMat should be 
        /// copied to (true) or shared with (false) the newly constructed matrix. When the data is copied, 
        /// the allocated buffer is managed using Mat reference counting mechanism. While the data is shared, 
        /// the reference counter is NULL, and you should not deallocate the data until the matrix is not destructed.</param>
        public Mat(CvMat m, bool copyData = false)
        {
            if (m == null)
                throw new ArgumentNullException("m");
            m.ThrowIfDisposed();
            ptr = CppInvoke.core_Mat_new_FromCvMat(m.CvPtr, copyData ? 1 : 0);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

        /// <summary>
        /// converts old-style IplImage to the new matrix; the data is not copied by default
        /// </summary>
        /// <param name="img">Old style IplImage object</param>
        /// <param name="copyData">Flag to specify whether the underlying data of the the old-style IplImage should be 
        /// copied to (true) or shared with (false) the newly constructed matrix. When the data is copied, 
        /// the allocated buffer is managed using Mat reference counting mechanism. While the data is shared, 
        /// the reference counter is NULL, and you should not deallocate the data until the matrix is not destructed.</param>
        public Mat(IplImage img, bool copyData = false)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();
            ptr = CppInvoke.core_Mat_new_FromIplImage(img.CvPtr, copyData ? 1 : 0);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
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
                            CppInvoke.core_Mat_delete(ptr);
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

#if LANG_JP
        /// <summary>
        /// System.Drawing.BitmapのインスタンスからIplImageを生成する
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the IplImage instance from System.Drawing.Bitmap
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
#endif
        public static Mat FromBitmap(Bitmap bmp)
        {
            if (bmp == null)
                throw new ArgumentNullException("bmp");

            return BitmapConverter2.ToMat(bmp);
        }

#if LANG_JP
        /// <summary>
        /// System.IO.StreamのインスタンスからIplImageを生成する
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the IplImage instance from System.IO.Stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#endif
        public static Mat FromStream(Stream stream, LoadMode mode)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (stream.Length > Int32.MaxValue)
                throw new ArgumentException("Not supported stream (too long)");

            byte[] buf = new byte[stream.Length];
            stream.Read(buf, 0, buf.Length);
            return FromImageData(buf, mode);
        }

#if LANG_JP
        /// <summary>
        /// 画像データ(JPEG等の画像をメモリに展開したもの)からIplImageを生成する (cvDecodeImage)
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the IplImage instance from image data (using cvDecodeImage) 
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#endif
        public static Mat ImDecode(byte[] imageBytes, LoadMode mode = LoadMode.Color)
        {
            if (imageBytes == null)
                throw new ArgumentNullException("imageBytes");
            return Cv2.ImDecode(imageBytes, mode);
        }
#if LANG_JP
        /// <summary>
        /// 画像データ(JPEG等の画像をメモリに展開したもの)からIplImageを生成する (cvDecodeImage)
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the IplImage instance from image data (using cvDecodeImage) 
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#endif
        public static Mat FromImageData(byte[] imageBytes, LoadMode mode = LoadMode.Color)
        {
            return ImDecode(imageBytes, mode);
        }
        #endregion

        #endregion

        #region Static
        /// <summary>
        /// sizeof(cv::Mat)
        /// </summary>
        public static readonly int SizeOf = (int)CppInvoke.core_Mat_sizeof();

        #region Diag

        /// <summary>
        /// Extracts a diagonal from a matrix, or creates a diagonal matrix.
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
            IntPtr retPtr = CppInvoke.core_Mat_eye(rows, cols, type);
            MatExpr retVal = new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_Mat_ones(rows, cols, type);
            MatExpr retVal = new MatExpr(retPtr);
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
                throw new ArgumentNullException("sizes");

            IntPtr retPtr = CppInvoke.core_Mat_ones(sizes.Length, sizes, type);
            MatExpr retVal = new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_Mat_zeros(rows, cols, type);
            MatExpr retVal = new MatExpr(retPtr);
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
                throw new ArgumentNullException("sizes");

            IntPtr retPtr = CppInvoke.core_Mat_zeros(sizes.Length, sizes, type);
            MatExpr retVal = new MatExpr(retPtr);
            return retVal;
        }

        #endregion
        #endregion

        #region Operators
        #region Cast

        /// <summary>
        /// Creates the IplImage clone instance for the matrix.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator IplImage(Mat self)
        {
            return self.ToIplImage();
        }

        /// <summary>
        /// Creates the IplImage clone instance or header for the matrix.
        /// </summary>
        /// <param name="adjustAlignment">If true, this method returns an IplImage that is adjusted alignment;
        /// otherwise, a header of IplImage is returned.</param>
        /// <returns></returns>
        public IplImage ToIplImage(bool adjustAlignment = true)
        {
            ThrowIfDisposed();

            if (adjustAlignment)
            {
                IntPtr imgPtr;
                CppInvoke.core_Mat_IplImage_alignment(ptr, out imgPtr);
                return new IplImage(imgPtr);
            }

            IplImage img = new IplImage(false);
            CppInvoke.core_Mat_IplImage(ptr, img.CvPtr);
            return img;
        }

        /// <summary>
        /// Creates the CvMat clone instance for the matrix.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator CvMat(Mat self)
        {
            return self.ToCvMat();
        }


        /// <summary>
        /// Creates the CvMat header or clone instance for the matrix.
        /// </summary>
        /// <returns></returns>
        public CvMat ToCvMat()
        {
            ThrowIfDisposed();

            CvMat mat = new CvMat(false);
            CppInvoke.core_Mat_CvMat(ptr, mat.CvPtr);

            return mat;
        }

        #endregion
        #region Arithmetic
        #region Unary
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static MatExpr operator -(Mat mat)
        {
            IntPtr expr = CppInvoke.core_operatorUnaryMinus_Mat(mat.CvPtr);
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
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();

            IntPtr retPtr = CppInvoke.core_operatorAdd_MatMat(a.CvPtr, b.CvPtr);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            
            IntPtr retPtr = CppInvoke.core_operatorAdd_MatScalar(a.CvPtr, s);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorAdd_ScalarMat(s, a.CvPtr);
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
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorSubtract_MatMat(a.CvPtr, b.CvPtr);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorSubtract_MatScalar(a.CvPtr, s);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorSubtract_ScalarMat(s, a.CvPtr);
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
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorMultiply_MatMat(a.CvPtr, b.CvPtr);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorMultiply_MatDouble(a.CvPtr, s);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorMultiply_DoubleMat(s, a.CvPtr);
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
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorDivide_MatMat(a.CvPtr, b.CvPtr);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorDivide_MatDouble(a.CvPtr, s);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorDivide_DoubleMat(s, a.CvPtr);
            return new MatExpr(retPtr);
        }

        #endregion
        #region Comparison
#pragma warning disable 1591
        public static MatExpr operator <(Mat a, Mat b)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator <(Mat a, double s)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator <(double s, Mat a)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator <=(Mat a, Mat b)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator <=(Mat a, double s)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator <=(double s, Mat a)
        {
            throw new NotImplementedException();
        }

        /*
        public static MatExpr operator ==(Mat a, Mat b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
                return true;
            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
                return false;
            
        }
        public static MatExpr operator ==(Mat a, double s) { throw new NotImplementedException(); }
        public static MatExpr operator ==(double s, Mat a) { throw new NotImplementedException(); }

        public static MatExpr operator !=(Mat a, Mat b) { throw new NotImplementedException(); }
        public static MatExpr operator !=(Mat a, double s) { throw new NotImplementedException(); }
        public static MatExpr operator !=(double s, Mat a) { throw new NotImplementedException(); }
        */

        public static MatExpr operator >=(Mat a, Mat b)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator >=(Mat a, double s)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator >=(double s, Mat a)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator >(Mat a, Mat b)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator >(Mat a, double s)
        {
            throw new NotImplementedException();
        }

        public static MatExpr operator >(double s, Mat a)
        {
            throw new NotImplementedException();
        }
#pragma warning restore 1591
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
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorAnd_MatMat(a.CvPtr, b.CvPtr);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorAnd_MatDouble(a.CvPtr, s);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorAnd_DoubleMat(s, a.CvPtr);
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
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorOr_MatMat(a.CvPtr, b.CvPtr);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorOr_MatDouble(a.CvPtr, s);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorOr_DoubleMat(s, a.CvPtr);
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
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorXor_MatMat(a.CvPtr, b.CvPtr);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorXor_MatDouble(a.CvPtr, s);
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
                throw new ArgumentNullException("a");
            a.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorXor_DoubleMat(s, a.CvPtr);
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
                throw new ArgumentNullException("m");
            m.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_operatorNot_Mat(m.CvPtr);
            return new MatExpr(retPtr);
        }

        #endregion
        #endregion
        #endregion
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
            get
            {
                return SubMat(rowStart, rowEnd, colStart, colEnd);
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
        public MatExpr this[Range rowRange, Range colRange]
        {
            get
            {
                return SubMat(rowRange, colRange);
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
        }
        #endregion
        #region MatExpr Indexers
        #region SubMat
        /// <summary>
        /// 
        /// </summary>
        public class MatExprIndexer : MatRangeExprIndexer
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
                get { return parent.SubMat(rowStart, rowEnd, colStart, colEnd); }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    Mat submat = parent.SubMat(rowStart, rowEnd, colStart, colEnd);
                    CppInvoke.core_Mat_assignment_FromMatExpr(submat.CvPtr, value.CvPtr);
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
                get { return parent.SubMat(rowRange, colRange); }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    Mat submat = parent.SubMat(rowRange, colRange);
                    CppInvoke.core_Mat_assignment_FromMatExpr(submat.CvPtr, value.CvPtr);
                }
            }

            /// <summary>
            /// Extracts a rectangular submatrix.
            /// </summary>
            /// <param name="roi">Extracted submatrix specified as a rectangle.</param>
            /// <returns></returns>
            public override MatExpr this[Rect roi]
            {
                get { return parent.SubMat(roi); }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    Mat submat = parent.SubMat(roi);
                    CppInvoke.core_Mat_assignment_FromMatExpr(submat.CvPtr, value.CvPtr);
                }
            }

            /// <summary>
            /// Extracts a rectangular submatrix.
            /// </summary>
            /// <param name="ranges">Array of selected ranges along each array dimension.</param>
            /// <returns></returns>
            public override MatExpr this[params Range[] ranges]
            {
                get { return parent.SubMat(ranges); }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    Mat submat = parent.SubMat(ranges);
                    CppInvoke.core_Mat_assignment_FromMatExpr(submat.CvPtr, value.CvPtr);
                }
            }
        }

        /// <summary>
        /// Indexer to access partial Mat as MatExpr
        /// </summary>
        /// <returns></returns>
        public MatExprIndexer Expr
        {
            get { return matExprIndexer ?? (matExprIndexer = new MatExprIndexer(this)); }
        }
        private MatExprIndexer matExprIndexer;

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
                    parent.ThrowIfDisposed();
                    IntPtr matExprPtr = CppInvoke.core_Mat_col_toMatExpr(parent.ptr, x);
                    MatExpr matExpr = new MatExpr(matExprPtr);
                    return matExpr;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    parent.ThrowIfDisposed();
                    IntPtr colMatPtr = CppInvoke.core_Mat_col_toMat(parent.ptr, x);
                    CppInvoke.core_Mat_assignment_FromMatExpr(colMatPtr, value.CvPtr);
                    CppInvoke.core_Mat_delete(colMatPtr);
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
                    parent.ThrowIfDisposed();
                    IntPtr matExprPtr = CppInvoke.core_Mat_colRange_toMatExpr(parent.ptr, startCol, endCol);
                    MatExpr matExpr = new MatExpr(matExprPtr);
                    return matExpr;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    parent.ThrowIfDisposed();
                    IntPtr colMatPtr = CppInvoke.core_Mat_colRange_toMat(parent.ptr, startCol, endCol);
                    CppInvoke.core_Mat_assignment_FromMatExpr(colMatPtr, value.CvPtr);
                    CppInvoke.core_Mat_delete(colMatPtr);
                }
            }
        }

        /// <summary>
        /// Indexer to access Mat column as MatExpr
        /// </summary>
        /// <returns></returns>
        public ColExprIndexer ColExpr
        {
            get { return colExprIndexer ?? (colExprIndexer = new ColExprIndexer(this)); }
        }
        private ColExprIndexer colExprIndexer;
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
                    parent.ThrowIfDisposed();
                    IntPtr matExprPtr = CppInvoke.core_Mat_row_toMatExpr(parent.ptr, y);
                    MatExpr matExpr = new MatExpr(matExprPtr);
                    return matExpr;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    parent.ThrowIfDisposed();
                    IntPtr rowMatPtr = CppInvoke.core_Mat_row_toMat(parent.ptr, y);
                    CppInvoke.core_Mat_assignment_FromMatExpr(rowMatPtr, value.CvPtr);
                    CppInvoke.core_Mat_delete(rowMatPtr);
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
                    parent.ThrowIfDisposed();
                    IntPtr matExprPtr = CppInvoke.core_Mat_rowRange_toMatExpr(parent.ptr, startRow, endRow);
                    MatExpr matExpr = new MatExpr(matExprPtr);
                    return matExpr;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    parent.ThrowIfDisposed();
                    IntPtr rowMatPtr = CppInvoke.core_Mat_rowRange_toMat(parent.ptr, startRow, endRow);
                    CppInvoke.core_Mat_assignment_FromMatExpr(rowMatPtr, value.CvPtr);
                }
            }
        }

        /// <summary>
        /// Indexer to access Mat row as MatExpr
        /// </summary>
        /// <returns></returns>
        public RowExprIndexer RowExpr
        {
            get { return rowExprIndexer ?? (rowExprIndexer = new RowExprIndexer(this)); }
        }
        private RowExprIndexer rowExprIndexer;

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
        public Mat AdjustROI(int dtop, int dbottom, int dleft, int dright)
        {
            ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_Mat_adjustROI(ptr, dtop, dbottom, dleft, dright);
            Mat retVal = new Mat(retPtr);
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
                throw new ArgumentNullException("m");
            CppInvoke.core_Mat_assignTo(ptr, m.CvPtr, type);
        }

        /// <summary>
        /// Provides a functional form of convertTo.
        /// </summary>
        /// <param name="m">Destination array.</param>
        public void AssignTo(Mat m)
        {
            CppInvoke.core_Mat_assignTo(ptr, m.CvPtr);
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
            return CppInvoke.core_Mat_channels(ptr);
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
            return CppInvoke.core_Mat_checkVector(ptr, elemChannels);
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
            return CppInvoke.core_Mat_checkVector(ptr, elemChannels, depth);
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
            return CppInvoke.core_Mat_checkVector(
                    ptr, elemChannels, depth, requireContinuous ? 1 : 0);
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
            IntPtr retPtr = CppInvoke.core_Mat_clone(ptr);
            Mat retVal = new Mat(retPtr);
            return retVal;
        }

        object ICloneable.Clone()
        {
            return Clone();
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
                    colsVal = CppInvoke.core_Mat_cols(ptr);
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
                return CppInvoke.core_Mat_dims(ptr);
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
            CppInvoke.core_Mat_convertTo(ptr, m.CvPtr, rtype, alpha, beta);
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
        public void CopyTo(Mat m, Mat mask)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException("m");
            IntPtr maskPtr = Cv2.ToPtr(mask);
            CppInvoke.core_Mat_copyTo(ptr, m.CvPtr, maskPtr);
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
            CppInvoke.core_Mat_create(ptr, rows, cols, type);
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
            CppInvoke.core_Mat_create(ptr, sizes.Length, sizes, type);
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
            IntPtr retPtr = CppInvoke.core_Mat_cross(ptr, m.CvPtr);
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
                return CppInvoke.core_Mat_data(ptr);
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
                return CppInvoke.core_Mat_datastart(ptr);
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
                return CppInvoke.core_Mat_dataend(ptr);
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
            return CppInvoke.core_Mat_depth(ptr);
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
            IntPtr retPtr = CppInvoke.core_Mat_diag(ptr, (int)d);
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
            return CppInvoke.core_Mat_dot(ptr, m.CvPtr);
        }

        #endregion
        #region ElemSize

        /// <summary>
        /// Returns the matrix element size in bytes.
        /// </summary>
        /// <returns></returns>
        public ulong ElemSize()
        {
            ThrowIfDisposed();
            return CppInvoke.core_Mat_elemSize(ptr);
        }

        #endregion
        #region ElemSize1

        /// <summary>
        /// Returns the size of each matrix element channel in bytes.
        /// </summary>
        /// <returns></returns>
        public ulong ElemSize1()
        {
            ThrowIfDisposed();
            return CppInvoke.core_Mat_elemSize1(ptr);
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
            return CppInvoke.core_Mat_empty(ptr) != 0;
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
            IntPtr retPtr = CppInvoke.core_Mat_inv(ptr, (int)method);
            Mat retVal = new Mat(retPtr);
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
            return CppInvoke.core_Mat_isContinuous(ptr) != 0;
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
            return CppInvoke.core_Mat_isSubmatrix(ptr) != 0;
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
            CppInvoke.core_Mat_locateROI(ptr, out wholeSize2, out ofs2);
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
            IntPtr retPtr = CppInvoke.core_Mat_mul(ptr, mPtr, scale);
            MatExpr retVal = new MatExpr(retPtr);
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
            IntPtr retPtr = CppInvoke.core_Mat_reshape(ptr, cn, rows);
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
            IntPtr retPtr = CppInvoke.core_Mat_reshape(ptr, cn, newDims.Length, newDims);
            Mat retVal = new Mat(retPtr);
            return retVal;
        }

        #endregion
        #region RowRange
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <returns></returns>
        public Mat RowRange(int startRow, int endRow)
        {
            return Row[startRow, endRow];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Mat RowRange(Range range)
        {
            return Row[range];
        }
        */
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
                    rowsVal = CppInvoke.core_Mat_rows(ptr);
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
            IntPtr retPtr = CppInvoke.core_Mat_setTo(ptr, value, maskPtr);
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
            IntPtr retPtr = CppInvoke.core_Mat_setTo(ptr, value.CvPtr, maskPtr);
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
            return CppInvoke.core_Mat_size(ptr);
        }

        /// <summary>
        /// Returns a matrix size.
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        public int Size(int dim)
        {
            ThrowIfDisposed();
            return CppInvoke.core_Mat_sizeAt(ptr, dim);
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
            return CppInvoke.core_Mat_step(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public ulong Step(int i)
        {
            ThrowIfDisposed();
            return CppInvoke.core_Mat_stepAt(ptr, i);
        }

        #endregion
        #region Step1

        /// <summary>
        /// Returns a normalized step.
        /// </summary>
        /// <returns></returns>
        public ulong Step1()
        {
            ThrowIfDisposed();
            return CppInvoke.core_Mat_step1(ptr);
        }

        /// <summary>
        /// Returns a normalized step.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public ulong Step1(int i)
        {
            ThrowIfDisposed();
            return CppInvoke.core_Mat_step1(ptr, i);
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
            IntPtr retPtr = CppInvoke.core_Mat_t(ptr);
            Mat retVal = new Mat(retPtr);
            return retVal;
        }

        #endregion
        #region Total

        /// <summary>
        /// Returns the total number of array elements.
        /// </summary>
        /// <returns></returns>
        public ulong Total()
        {
            ThrowIfDisposed();
            return CppInvoke.core_Mat_total(ptr);
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
            return CppInvoke.core_Mat_type(ptr);
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
                sbyte* buf = CppInvoke.core_Mat_dump(ptr, formatStr);
                string ret = new string(buf);
                CppInvoke.core_Mat_dump_delete(buf);
                return ret;
            }
        }

        private string GetDumpFormatString(DumpFormat format)
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
            return CppInvoke.core_Mat_ptr1d(ptr, i0);
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
            return CppInvoke.core_Mat_ptr2d(ptr, i0, i1);
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
            return CppInvoke.core_Mat_ptr3d(ptr, i0, i1, i2);
        }

        /// <summary>
        /// Returns a pointer to the specified matrix element.
        /// </summary>
        /// <param name="idx">Array of Mat::dims indices.</param>
        /// <returns></returns>
        public IntPtr Ptr(params int[] idx)
        {
            ThrowIfDisposed();
            return CppInvoke.core_Mat_ptrnd(ptr, idx);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Mat Col(int x)
        {
            ThrowIfDisposed();
            IntPtr matPtr = CppInvoke.core_Mat_col_toMat(ptr, x);
            return new Mat(matPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startCol"></param>
        /// <param name="endCol"></param>
        /// <returns></returns>
        public Mat ColRange(int startCol, int endCol)
        {
            ThrowIfDisposed();
            IntPtr matPtr = CppInvoke.core_Mat_colRange_toMat(ptr, startCol, endCol);
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

        #endregion
        #region Row/RowRange

        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public Mat Row(int y)
        {
            ThrowIfDisposed();
            IntPtr matPtr = CppInvoke.core_Mat_row_toMat(ptr, y);
            return new Mat(matPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <returns></returns>
        public Mat RowRange(int startRow, int endRow)
        {
            ThrowIfDisposed();
            IntPtr matPtr = CppInvoke.core_Mat_rowRange_toMat(ptr, startRow, endRow);
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
            IntPtr retPtr = CppInvoke.core_Mat_subMat(ptr, rowStart, rowEnd, colStart, colEnd);
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

            IntPtr retPtr = CppInvoke.core_Mat_subMat(ptr, slices.Length, slices);
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
            CppInvoke.core_Mat_nGetB(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetB(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetS(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetS(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetS(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetS(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetI(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetI(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetF(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetF(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetD(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetD(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetD(ptr, row, col, ret, ret.Length);
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
            CppInvoke.core_Mat_nGetVec3b(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetVec3b(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetVec3d(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetVec3d(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetVec4f(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetVec4f(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetVec6f(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetVec6f(ptr, row, col, data, data.Length);
        }

        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point[] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC(2));
            CppInvoke.core_Mat_nGetPoint(ptr, row, col, data, data.Length);
        }
        /// <summary>
        /// Get the data of this matrix as array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="data"></param>
        public void GetArray(int row, int col, Point[,] data)
        {
            CheckArgumentsForConvert(row, col, data, MatType.CV_32SC(2));
            CppInvoke.core_Mat_nGetPoint(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetPoint2f(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetPoint2f(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetPoint2d(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetPoint2d(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetDMatch(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nGetDMatch(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetB(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetB(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetS(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetS(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetS(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetS(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetI(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetI(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetF(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetF(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetD(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetD(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetVec3b(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetVec3b(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetVec3d(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetVec3d(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetVec4f(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetVec4f(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetVec6f(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetVec6f(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetPoint(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetPoint(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetPoint2f(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetPoint2f(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetPoint2d(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetPoint2d(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetDMatch(ptr, row, col, data, data.Length);
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
            CppInvoke.core_Mat_nSetDMatch(ptr, row, col, data, data.Length);
        }
        #endregion

        #region Add

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="m">Added line(s)</param>
        public void Add(Mat m)
        {
            ThrowIfDisposed();
            if (m == null)
                throw new ArgumentNullException();
            m.ThrowIfDisposed();
            CppInvoke.core_Mat_push_back_Mat(ptr, m.CvPtr);
        }


        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element(s)</param>
        public void Add(ushort value)
        {
            ThrowIfDisposed();
            CppInvoke.core_Mat_push_back_ushort(ptr, value);
        }
        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element(s)</param>
        public void Add(int value)
        {
            ThrowIfDisposed();
            CppInvoke.core_Mat_push_back_int(ptr, value);
        }

        /// <summary>
        /// Adds elements to the bottom of the matrix. (Mat::push_back)
        /// </summary>
        /// <param name="value">Added element(s)</param>
        public void Add(double value)
        {
            ThrowIfDisposed();
            CppInvoke.core_Mat_push_back_double(ptr, value);
        }
        #endregion

        #region ToBitmap

        /// <summary>
        /// Converts Mat to byte array using cv::imencode
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public byte[] ToImageData(string ext, params ImageEncodingParam[] prms)
        {
            byte[] imageBytes;
            Cv2.ImEncode(ext, this, out imageBytes, prms);
            return imageBytes;
        }

        /// <summary>
        /// Converts Mat to System.Drawing.Bitmap
        /// </summary>
        /// <returns></returns>
        public Bitmap ToBitmap()
        {
            return ToBitmap(".png");
        }
        /// <summary>
        /// Converts Mat to System.Drawing.Bitmap
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public Bitmap ToBitmap(string ext, params ImageEncodingParam[] prms)
        {
            byte[] imageBytes;
            Cv2.ImEncode(ext, this, out imageBytes, prms);
            using (MemoryStream stream = new MemoryStream(imageBytes))
            {
                return new Bitmap(stream);
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Mat Alignment(int n = 4)
        {
            int newCols = Cv2.AlignSize(Cols, n);
            Mat pMat = new Mat(Rows, newCols, Type());
            Mat roiMat = new Mat(pMat, new Rect(0, 0, Cols, Rows));
            CopyTo(roiMat);
            return roiMat;
        }

        #endregion

        #region Cv2 Methods

        #region Line
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ. [既定値は1]</param>
        /// <param name="lineType">線分の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Line(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ. [既定値は1]</param>
        /// <param name="lineType">線分の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public void Line(Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Line(this, pt1, pt2, color, thickness, lineType, shift);
        }
        #endregion
        #region Rectangle
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public void Rectangle(Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Rectangle(this, pt1, pt2, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public void Rectangle(Rect rect, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Rectangle(this, rect, color, thickness, lineType, shift);
        }
        #endregion
        #region Circle
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="centerX">円の中心のx座標</param>
        /// <param name="centerY">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．[既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="lineType">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public void Circle(int centerX, int centerY, int radius, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Circle(this, centerX, centerY, radius, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．[既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="lineType">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public void Circle(Point center, int radius, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Circle(this, center, radius, color, thickness, lineType, shift);
        }
        #endregion
        #region Ellipse
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="startAngle">楕円弧の開始角度</param>
        /// <param name="endAngle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
        /// <param name="thickness">楕円弧の線の幅 [既定値は1]</param>
        /// <param name="lineType">楕円弧の線の種類 [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と軸の長さの小数点以下の桁を表すビット数 [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="startAngle">Starting angle of the elliptic arc. </param>
        /// <param name="endAngle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse arc. [By default this is 1]</param>
        /// <param name="lineType">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and axes' values. [By default this is 0]</param>
#endif
        public void Ellipse(Point center, Size axes, double angle, double startAngle, double endAngle, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Ellipse(this, center, axes, angle, startAngle, endAngle, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
        /// <param name="thickness">楕円境界線の幅．[既定値は1]</param>
        /// <param name="lineType">楕円境界線の種類．[既定値はLineType.Link8]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. [By default this is 1]</param>
        /// <param name="lineType">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
#endif
        public void Ellipse(RotatedRect box, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8)
        {
            Cv2.Ellipse(this, box, color, thickness, lineType);
        }
        #endregion
        #region FillConvexPoly
#if LANG_JP
        /// <summary>
        /// 塗りつぶされた凸ポリゴンを描きます．
        /// </summary>
        /// <param name="pts">ポリゴンの頂点．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">ポリゴンの枠線の種類，</param>
        /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
#else
        /// <summary>
        /// Fills a convex polygon.
        /// </summary>
        /// <param name="pts">The polygon vertices</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
#endif
        public void FillConvexPoly(IEnumerable<Point> pts, Scalar color,
            LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.FillConvexPoly(this, pts, color, lineType, shift);
        }
        #endregion
        #region FillPoly
#if LANG_JP
        /// <summary>
        /// 1つ，または複数のポリゴンで区切られた領域を塗りつぶします．
        /// </summary>
        /// <param name="pts">ポリゴンの配列．各要素は，点の配列で表現されます．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">ポリゴンの枠線の種類，</param>
        /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
        /// <param name="offset"></param>
#else
        /// <summary>
        /// Fills the area bounded by one or more polygons
        /// </summary>
        /// <param name="pts">Array of polygons, each represented as an array of points</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
        /// <param name="offset"></param>
#endif
        public void FillPoly(IEnumerable<IEnumerable<Point>> pts, Scalar color,
            LineType lineType = LineType.Link8, int shift = 0, Point? offset = null)
        {
            Cv2.FillPoly(this, pts, color, lineType, shift, offset);
        }
        #endregion
        #region Polylines
        /// <summary>
        /// draws one or more polygonal curves
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="isClosed"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        /// <param name="lineType"></param>
        /// <param name="shift"></param>
        public void Polylines(IEnumerable<IEnumerable<Point>> pts, bool isClosed, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Cv2.Polylines(this, pts, isClosed, color, thickness, lineType, shift);
        }
        #endregion
        #region PutText
        /// <summary>
        /// renders text string in the image
        /// </summary>
        /// <param name="text"></param>
        /// <param name="org"></param>
        /// <param name="fontFace"></param>
        /// <param name="fontScale"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        /// <param name="lineType"></param>
        /// <param name="bottomLeftOrigin"></param>
        public void PutText(string text, Point org,
            FontFace fontFace, double fontScale, Scalar color,
            int thickness = 1, 
            LineType lineType = LineType.Link8, 
            bool bottomLeftOrigin = false)
        {
            Cv2.PutText(this, text, org, fontFace, fontScale, color, thickness, lineType, bottomLeftOrigin);
        }
        #endregion
        #region ImEncode / ToBytes
        /// <summary>
        /// Encodes an image into a memory buffer.
        /// </summary>
        /// <param name="ext">Encodes an image into a memory buffer.</param>
        /// <param name="prms">Format-specific parameters.</param>
        /// <returns></returns>
        public byte[] ImEncode(string ext = ".png", int[] prms = null)
        {
            byte[] buf;
            Cv2.ImEncode(ext, this, out buf, prms);
            return buf;
        }
        /// <summary>
        /// Encodes an image into a memory buffer.
        /// </summary>
        /// <param name="ext">Encodes an image into a memory buffer.</param>
        /// <param name="prms">Format-specific parameters.</param>
        /// <returns></returns>
        public byte[] ImEncode(string ext = ".png", params ImageEncodingParam[] prms)
        {
            byte[] buf;
            Cv2.ImEncode(ext, this, out buf, prms);
            return buf;
        }
        /// <summary>
        /// Encodes an image into a memory buffer.
        /// </summary>
        /// <param name="ext">Encodes an image into a memory buffer.</param>
        /// <param name="prms">Format-specific parameters.</param>
        /// <returns></returns>
        public byte[] ToBytes(string ext = ".png", int[] prms = null)
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
        #endregion
        #region ImWrite
        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public bool ImWrite(string fileName, int[] prms = null)
        {
            return Cv2.ImWrite(fileName, this, prms);
        }
        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public bool ImWrite(string fileName, params ImageEncodingParam[] prms)
        {
            return Cv2.ImWrite(fileName, this, prms);
        }
        #endregion

        #endregion
    }

}
