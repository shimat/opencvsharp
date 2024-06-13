using OpenCvSharp.Internal;
using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// OpenCV C++ n-dimensional dense array class (cv::Mat)
/// </summary>
public class UMat : DisposableCvObject
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

    /// <summary>
    /// Creates from native cv::Mat* pointer
    /// </summary>
    /// <param name="ptr"></param>
    internal UMat(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Native object address is NULL");
        this.ptr = ptr;
    }

    /// <summary>
    /// Creates from native cv::UMat* pointer
    /// </summary>
    /// <param name="ptr"></param>
    public static UMat FromNativePointer(IntPtr ptr)
        => new(ptr);

    /// <summary>
    /// Creates empty Mat
    /// </summary>
    public UMat(UMatUsageFlags usageFlags = UMatUsageFlags.None)
    {
        NativeMethods.HandleException(
            NativeMethods.core_UMat_new1((int)usageFlags, out ptr));
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="m"></param>
    protected UMat(UMat m)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_UMat_new6(m.ptr, out ptr));
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("imread failed.");
    }

    /// <summary>
    /// constructs 2D matrix of the specified size and type
    /// </summary>
    /// <param name="rows">Number of rows in a 2D array.</param>
    /// <param name="cols">Number of columns in a 2D array.</param>
    /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
    /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
    /// <param name="usageFlags">usage flags for allocator</param>
    public UMat(int rows, int cols, MatType type, UMatUsageFlags usageFlags = UMatUsageFlags.None)
    {
        NativeMethods.HandleException(
            NativeMethods.core_UMat_new2(rows, cols, type, (int)usageFlags, out ptr));
    }

    /// <summary>
    /// constructs 2D matrix of the specified size and type
    /// </summary>
    /// <param name="size">2D array size: Size(cols, rows) . In the Size() constructor, 
    /// the number of rows and the number of columns go in the reverse order.</param>
    /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
    /// or MatType.CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
    /// <param name="usageFlags">usage flags for allocator</param>
    public UMat(Size size, MatType type, UMatUsageFlags usageFlags = UMatUsageFlags.None)
    {
        NativeMethods.HandleException(
            NativeMethods.core_UMat_new2(size.Height, size.Width, type, (int)usageFlags, out ptr));
    }

    /// <summary>
    /// constructs 2D matrix and fills it with the specified Scalar value.
    /// </summary>
    /// <param name="rows">Number of rows in a 2D array.</param>
    /// <param name="cols">Number of columns in a 2D array.</param>
    /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
    /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
    /// <param name="s">An optional value to initialize each matrix element with. 
    /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
    /// <param name="usageFlags">usage flags for allocator</param>
    public UMat(int rows, int cols, MatType type, Scalar s, UMatUsageFlags usageFlags = UMatUsageFlags.None)
    {
        NativeMethods.HandleException(
            NativeMethods.core_UMat_new3(rows, cols, type, s, (int)usageFlags, out ptr));
    }

    /// <summary>
    /// constructs 2D matrix and fills it with the specified Scalar value.
    /// </summary>
    /// <param name="size">2D array size: Size(cols, rows) . In the Size() constructor, 
    /// the number of rows and the number of columns go in the reverse order.</param>
    /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
    /// or CV_8UC(n), ..., CV_64FC(n) to create multi-channel (up to CV_CN_MAX channels) matrices.</param>
    /// <param name="s">An optional value to initialize each matrix element with. 
    /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
    /// <param name="usageFlags">usage flags for allocator</param>
    public UMat(Size size, MatType type, Scalar s, UMatUsageFlags usageFlags = UMatUsageFlags.None)
    {
        NativeMethods.HandleException(
            NativeMethods.core_UMat_new3(size.Height, size.Width, type, s, (int)usageFlags, out ptr));
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
    /// <param name="usageFlags">usage flags for allocator</param>
    public UMat(UMat m, Range rowRange, Range colRange, UMatUsageFlags usageFlags = UMatUsageFlags.None)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        m.ThrowIfDisposed();

        NativeMethods.HandleException(NativeMethods.core_UMat_new7(m.ptr, rowRange, colRange, (int)usageFlags, out ptr));
        GC.KeepAlive(m);
    }

    /// <summary>
    /// creates a matrix header for a part of the bigger matrix
    /// </summary>
    /// <param name="m">Array that (as a whole or partly) is assigned to the constructed matrix. 
    /// No data is copied by these constructors. Instead, the header pointing to m data or its sub-array 
    /// is constructed and associated with it. The reference counter, if any, is incremented. 
    /// So, when you modify the matrix formed using such a constructor, you also modify the corresponding elements of m . 
    /// If you want to have an independent copy of the sub-array, use Mat.Clone() .</param>
    /// <param name="ranges">Array of selected ranges of m along each dimensionality.</param>
    public UMat(UMat m, params Range[] ranges)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        if (ranges is null)
            throw new ArgumentNullException(nameof(ranges));
        if (ranges.Length == 0)
            throw new ArgumentException("empty ranges", nameof(ranges));
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_UMat_new9(m.ptr, ranges, out ptr));
        GC.KeepAlive(m);
    }

    /// <summary>
    /// creates a matrix header for a part of the bigger matrix
    /// </summary>
    /// <param name="m">Array that (as a whole or partly) is assigned to the constructed matrix. 
    /// No data is copied by these constructors. Instead, the header pointing to m data or its sub-array 
    /// is constructed and associated with it. The reference counter, if any, is incremented. 
    /// So, when you modify the matrix formed using such a constructor, you also modify the corresponding elements of m . 
    /// If you want to have an independent copy of the sub-array, use Mat.Clone() .</param>
    /// <param name="roi">Region of interest.</param>
    public UMat(UMat m, Rect roi)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_UMat_new8(m.ptr, roi, out ptr));
        GC.KeepAlive(m);
    }

    /// <summary>
    /// constructs n-dimensional matrix
    /// </summary>
    /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
    /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
    /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
    public UMat(IEnumerable<int> sizes, MatType type)
    {
        if (sizes is null)
            throw new ArgumentNullException(nameof(sizes));

        var sizesArray = sizes.ToArray();
        NativeMethods.HandleException(
            NativeMethods.core_UMat_new4(sizesArray.Length, sizesArray, type, out ptr));
    }

    /// <summary>
    /// constructs n-dimensional matrix
    /// </summary>
    /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
    /// <param name="type">Array type. Use MatType.CV_8UC1, ..., CV_64FC4 to create 1-4 channel matrices, 
    /// or MatType. CV_8UC(n), ..., CV_64FC(n) to create multi-channel matrices.</param>
    /// <param name="s">An optional value to initialize each matrix element with. 
    /// To set all the matrix elements to the particular value after the construction, use SetTo(Scalar s) method .</param>
    public UMat(IEnumerable<int> sizes, MatType type, Scalar s)
    {
        if (sizes is null)
            throw new ArgumentNullException(nameof(sizes));
        var sizesArray = sizes.ToArray();
        NativeMethods.HandleException(
            NativeMethods.core_UMat_new5(sizesArray.Length, sizesArray, type, s, out ptr));
    }

    /// <summary>
    /// Releases the resources
    /// </summary>
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
                NativeMethods.core_UMat_delete(ptr));
        base.DisposeUnmanaged();
    }

    #endregion

    #region Static

    /// <summary>
    /// Extracts a diagonal from a matrix, or creates a diagonal matrix.
    /// </summary>
    /// <param name="d">One-dimensional matrix that represents the main diagonal.</param>
    /// <returns></returns>
    public static UMat Diag(UMat d)
    {
        if (d is null)
            throw new ArgumentNullException(nameof(d));

        NativeMethods.HandleException(
            NativeMethods.core_UMat_diag_static(d.CvPtr, out var ret));
        GC.KeepAlive(d);
        var retVal = new UMat(ret);
        return retVal;
    }

    /// <summary>
    /// Returns a zero array of the specified size and type.
    /// </summary>
    /// <param name="rows">Number of rows.</param>
    /// <param name="cols">Number of columns.</param>
    /// <param name="type">Created matrix type.</param>
    /// <returns></returns>
    public static UMat Zeros(int rows, int cols, MatType type)
    {
        NativeMethods.HandleException(
            NativeMethods.core_UMat_zeros1(rows, cols, type, out var ret));
        var retVal = new UMat(ret);
        return retVal;
    }

    /// <summary>
    /// Returns a zero array of the specified size and type.
    /// </summary>
    /// <param name="size">Alternative to the matrix size specification Size(cols, rows) .</param>
    /// <param name="type">Created matrix type.</param>
    /// <returns></returns>
    public static UMat Zeros(Size size, MatType type)
    {
        return Zeros(size.Height, size.Width, type);
    }

    /// <summary>
    /// Returns a zero array of the specified size and type.
    /// </summary>
    /// <param name="type">Created matrix type.</param>
    /// <param name="sizes"></param>
    /// <returns></returns>
    public static UMat Zeros(MatType type, params int[] sizes)
    {
        if (sizes is null)
            throw new ArgumentNullException(nameof(sizes));

        NativeMethods.HandleException(
            NativeMethods.core_UMat_zeros2(sizes.Length, sizes, type.Value, out var ret));
        var retVal = new UMat(ret);
        return retVal;
    }

    /// <summary>
    /// Returns an array of all 1’s of the specified size and type.
    /// </summary>
    /// <param name="rows">Number of rows.</param>
    /// <param name="cols">Number of columns.</param>
    /// <param name="type">Created matrix type.</param>
    /// <returns></returns>
    public static UMat Ones(int rows, int cols, MatType type)
    {
        NativeMethods.HandleException(
            NativeMethods.core_UMat_ones1(rows, cols, type, out var ret));
        var retVal = new UMat(ret);
        return retVal;
    }

    /// <summary>
    /// Returns an array of all 1’s of the specified size and type.
    /// </summary>
    /// <param name="size">Alternative to the matrix size specification Size(cols, rows) .</param>
    /// <param name="type">Created matrix type.</param>
    /// <returns></returns>
    public static UMat Ones(Size size, MatType type)
    {
        return Ones(size.Height, size.Width, type);
    }

    /// <summary>
    /// Returns an array of all 1’s of the specified size and type.
    /// </summary>
    /// <param name="type">Created matrix type.</param>
    /// <param name="sizes">Array of integers specifying the array shape.</param>
    /// <returns></returns>
    public static UMat Ones(MatType type, params int[] sizes)
    {
        if (sizes is null)
            throw new ArgumentNullException(nameof(sizes));

        NativeMethods.HandleException(
            NativeMethods.core_UMat_ones2(sizes.Length, sizes, type, out var ret));
        var retVal = new UMat(ret);
        return retVal;
    }

    /// <summary>
    /// Returns an identity matrix of the specified size and type.
    /// </summary>
    /// <param name="size">Alternative to the matrix size specification Size(cols, rows) .</param>
    /// <param name="type">Created matrix type.</param>
    /// <returns></returns>
    public static UMat Eye(Size size, MatType type)
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
    public static UMat Eye(int rows, int cols, MatType type)
    {
        NativeMethods.HandleException(
            NativeMethods.core_UMat_eye(rows, cols, type, out var ret));
        var retVal = new UMat(ret);
        return retVal;
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
    public UMat this[int rowStart, int rowEnd, int colStart, int colEnd]
    {
        get => SubMat(rowStart, rowEnd, colStart, colEnd);
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();
            //if (Type() != value.Type())
            //    throw new ArgumentException("Mat type mismatch");
            if (Dims != value.Dims)
                throw new ArgumentException("Dimension mismatch");

            using var sub = SubMat(rowStart, rowEnd, colStart, colEnd);
            if (sub.Size() != value.Size())
                throw new ArgumentException("Specified ROI != mat.Size()");
            value.CopyTo(sub);
        }
    }

#if NETCOREAPP3_1_OR_GREATER || NETSTANDARD2_1
    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    /// <param name="rowRange">Start and end row of the extracted submatrix. The upper boundary is not included. 
    /// To select all the rows, use Range.All().</param>
    /// <param name="colRange">Start and end column of the extracted submatrix. 
    /// The upper boundary is not included. To select all the columns, use Range.All().</param>
    /// <returns></returns>
    public UMat this[System.Range rowRange, System.Range colRange]
    {
        get => SubMat(rowRange, colRange);
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();
            //if (Type() != value.Type())
            //    throw new ArgumentException("Mat type mismatch");
            if (Dims != value.Dims)
                throw new ArgumentException("Dimension mismatch");

            using var sub = SubMat(rowRange, colRange);
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
    public UMat this[Range rowRange, Range colRange]
    {
        get => SubMat(rowRange, colRange);
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();
            //if (Type() != value.Type())
            //    throw new ArgumentException("Mat type mismatch");
            if (Dims != value.Dims)
                throw new ArgumentException("Dimension mismatch");

            using var sub = SubMat(rowRange, colRange);
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
    [SuppressMessage("Microsoft.Design", "CA1043: Use integral or string argument for indexers")]
    public UMat this[Rect roi]
    {
        get => SubMat(roi);
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();
            //if (Type() != value.Type())
            //    throw new ArgumentException("Mat type mismatch");
            if (Dims != value.Dims)
                throw new ArgumentException("Dimension mismatch");

            if (roi.Size != value.Size())
                throw new ArgumentException("Specified ROI != mat.Size()");
            using var sub = SubMat(roi);
            value.CopyTo(sub);
        }
    }

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    /// <param name="ranges">Array of selected ranges along each array dimension.</param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Design", "CA1043: Use integral or string argument for indexers")]
    public UMat this[params Range[] ranges]
    {
        get => SubMat(ranges);
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();
            //if (Type() != value.Type())
            //    throw new ArgumentException("Mat type mismatch");

            using var sub = SubMat(ranges);

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
    /// Returns the UMat data as a Mat.
    /// </summary>
    /// <param name="accessFlags">AccessFlag determining the mode in which the data is to be acquired</param>
    /// <returns></returns>
    public Mat GetMat(AccessFlag accessFlags)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_UMat_getMat(ptr, (int)accessFlags, out var matPtr));
        return new Mat(matPtr);
    }

    /// <summary>
    /// Creates a matrix header for the specified matrix column.
    /// </summary>
    /// <param name="x">A 0-based column index.</param>
    /// <returns></returns>
    public UMat Col(int x)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_UMat_col(ptr, x, out var matPtr));
        return new UMat(matPtr);
    }

    /// <summary>
    /// Creates a matrix header for the specified column span.
    /// </summary>
    /// <param name="startCol">An inclusive 0-based start index of the column span.</param>
    /// <param name="endCol"> An exclusive 0-based ending index of the column span.</param>
    /// <returns></returns>
    public UMat ColRange(int startCol, int endCol)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_UMat_colRange(ptr, startCol, endCol, out var matPtr));
        GC.KeepAlive(this);
        return new UMat(matPtr);
    }

    /// <summary>
    /// Creates a matrix header for the specified column span.
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public UMat ColRange(Range range)
    {
        return ColRange(range.Start, range.End);
    }

#if NETCOREAPP3_1_OR_GREATER || NETSTANDARD2_1
    /// <summary>
    /// Creates a matrix header for the specified column span.
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public UMat ColRange(System.Range range)
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
    public UMat Row(int y)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_UMat_row(ptr, y, out var matPtr));
        return new UMat(matPtr);
    }

    /// <summary>
    /// Creates a matrix header for the specified row span.
    /// </summary>
    /// <param name="startRow"></param>
    /// <param name="endRow"></param>
    /// <returns></returns>
    public UMat RowRange(int startRow, int endRow)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_UMat_rowRange(ptr, startRow, endRow, out var matPtr));
        GC.KeepAlive(this);
        return new UMat(matPtr);
    }

    /// <summary>
    ///  Creates a matrix header for the specified row span.
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public UMat RowRange(Range range)
    {
        return RowRange(range.Start, range.End);
    }

#if NETCOREAPP3_1_OR_GREATER || NETSTANDARD2_1
    /// <summary>
    ///  Creates a matrix header for the specified row span.
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public UMat RowRange(System.Range range)
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
    public UMat Diag(MatDiagType d = MatDiagType.Main)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_UMat_diag(ptr, (int)d, out var ret));
        GC.KeepAlive(this);
        var retVal = new UMat(ret);
        return retVal;
    }

    /// <summary>
    /// Creates a full copy of the matrix.
    /// </summary>
    /// <returns></returns>
    public UMat Clone()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_UMat_clone(ptr, out var ret));
        GC.KeepAlive(this);
        var retVal = new UMat(ret);
        return retVal;
    }

    /// <summary>
    /// Returns the partial Mat of the specified Mat
    /// </summary>
    /// <param name="roi"></param>
    /// <returns></returns>
    public UMat Clone(Rect roi)
    {
        using var part = new UMat(this, roi);
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
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        m.ThrowIfNotReady();
        mask?.ThrowIfDisposed();

        if (mask is null)
        {
            NativeMethods.HandleException(
                NativeMethods.core_UMat_copyTo1(ptr, m.CvPtr));
        }
        else
        {
            var maskPtr = Cv2.ToPtr(mask);
            NativeMethods.HandleException(
                NativeMethods.core_UMat_copyTo2(ptr, m.CvPtr, maskPtr));
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
    public void CopyTo(UMat m, InputArray? mask = null)
    {
        ThrowIfDisposed();
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        m.ThrowIfDisposed();
        mask?.ThrowIfDisposed();

        if (mask is null)
        {
            NativeMethods.HandleException(
                NativeMethods.core_UMat_copyTo_toUMat1(ptr, m.CvPtr));
        }
        else
        {
            var maskPtr = Cv2.ToPtr(mask);
            NativeMethods.HandleException(
                NativeMethods.core_UMat_copyTo_toUMat2(ptr, m.CvPtr, maskPtr));
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
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        m.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.core_UMat_convertTo(ptr, m.CvPtr, rtype, alpha, beta));

        GC.KeepAlive(this);
        m.Fix();
    }

    /// <summary>
    /// Provides a functional form of convertTo.
    /// </summary>
    /// <param name="m">Destination array.</param>
    /// <param name="type">Desired destination array depth (or -1 if it should be the same as the source type).</param>
    public void AssignTo(UMat m, MatType? type = null)
    {
        ThrowIfDisposed();
        if (m is null)
            throw new ArgumentNullException(nameof(m));

        NativeMethods.HandleException(
            NativeMethods.core_UMat_assignTo(ptr, m.CvPtr, type?.Value ?? -1));

        GC.KeepAlive(this);
        GC.KeepAlive(m);
    }

    /// <summary>
    /// Sets all or some of the array elements to the specified value.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="mask"></param>
    /// <returns></returns>
    public UMat SetTo(Scalar value, UMat? mask = null)
    {
        ThrowIfDisposed();

        var maskPtr = Cv2.ToPtr(mask);
        NativeMethods.HandleException(
            NativeMethods.core_UMat_setTo_Scalar(ptr, value, maskPtr));

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
    public UMat SetTo(InputArray value, UMat? mask = null)
    {
        ThrowIfDisposed();
        if (value is null)
            throw new ArgumentNullException(nameof(value));
        value.ThrowIfDisposed();

        var maskPtr = Cv2.ToPtr(mask);
        NativeMethods.HandleException(
            NativeMethods.core_UMat_setTo_InputArray(ptr, value.CvPtr, maskPtr));

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
    public UMat Reshape(int cn, int rows = 0)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_UMat_reshape1(ptr, cn, rows, out var ret));

        GC.KeepAlive(this);
        var retVal = new UMat(ret);
        return retVal;
    }

    /// <summary>
    /// Changes the shape and/or the number of channels of a 2D matrix without copying the data.
    /// </summary>
    /// <param name="cn">New number of channels. If the parameter is 0, the number of channels remains the same.</param>
    /// <param name="newDims">New number of rows. If the parameter is 0, the number of rows remains the same.</param>
    /// <returns></returns>
    public UMat Reshape(int cn, params int[] newDims)
    {
        if (newDims is null)
            throw new ArgumentNullException(nameof(newDims));

        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_UMat_reshape2(ptr, cn, newDims.Length, newDims, out var ret));

        GC.KeepAlive(this);
        var retVal = new UMat(ret);
        return retVal;
    }

    /// <summary>
    /// Transposes a matrix.
    /// </summary>
    /// <returns></returns>
    public UMat T()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_UMat_t(ptr, out var ret));

        GC.KeepAlive(this);
        var retVal = new UMat(ret);
        return retVal;
    }

    /// <summary>
    /// Inverses a matrix.
    /// </summary>
    /// <param name="method">Matrix inversion method</param>
    /// <returns></returns>
    public UMat Inv(DecompTypes method = DecompTypes.LU)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_UMat_inv(ptr, (int)method, out var ret));

        GC.KeepAlive(this);
        var retVal = new UMat(ret);
        return retVal;
    }

    /// <summary>
    /// Performs an element-wise multiplication or division of the two matrices.
    /// </summary>
    /// <param name="m"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public UMat Mul(InputArray m, double scale = 1)
    {
        ThrowIfDisposed();
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_UMat_mul(ptr, m.CvPtr, scale, out var ret));

        GC.KeepAlive(this);
        GC.KeepAlive(m);
        var retVal = new UMat(ret);
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
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_UMat_dot(ptr, m.CvPtr, out var ret));

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
            NativeMethods.core_UMat_create1(ptr, rows, cols, type));
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
        if (sizes is null)
            throw new ArgumentNullException(nameof(sizes));
        if (sizes.Length < 2)
            throw new ArgumentException("sizes.Length < 2");
        NativeMethods.HandleException(
            NativeMethods.core_UMat_create2(ptr, sizes.Length, sizes, type));
        GC.KeepAlive(this);
    }

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
            NativeMethods.core_UMat_locateROI(ptr, out wholeSize, out ofs));
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
    // ReSharper disable IdentifierTypo
    public UMat AdjustROI(int dtop, int dbottom, int dleft, int dright)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_UMat_adjustROI(ptr, dtop, dbottom, dleft, dright, out var ret));
        GC.KeepAlive(this);
        var retVal = new UMat(ret);
        return retVal;
    }
    // ReSharper restore IdentifierTypo

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    /// <param name="rowStart"></param>
    /// <param name="rowEnd"></param>
    /// <param name="colStart"></param>
    /// <param name="colEnd"></param>
    /// <returns></returns>
    public UMat SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
    {
        if (rowStart >= rowEnd)
            throw new ArgumentException("rowStart >= rowEnd");
        if (colStart >= colEnd)
            throw new ArgumentException("colStart >= colEnd");

        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_UMat_subMat1(ptr, rowStart, rowEnd, colStart, colEnd, out var ret));
        GC.KeepAlive(this);
        var retVal = new UMat(ret);
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
    public UMat SubMat(Range rowRange, Range colRange)
    {
        return SubMat(rowRange.Start, rowRange.End, colRange.Start, colRange.End);
    }

#if NETCOREAPP3_1_OR_GREATER || NETSTANDARD2_1
    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    /// <param name="rowRange">Start and end row of the extracted submatrix. The upper boundary is not included.
    /// To select all the rows, use Range::all().</param>
    /// <param name="colRange">Start and end column of the extracted submatrix. The upper boundary is not included.
    /// To select all the columns, use Range::all().</param>
    /// <returns></returns>
    public UMat SubMat(System.Range rowRange, System.Range colRange)
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
    public UMat SubMat(Rect roi)
    {
        return SubMat(roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);
    }

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    /// <param name="ranges">Array of selected ranges along each array dimension.</param>
    /// <returns></returns>
    public UMat SubMat(params Range[] ranges)
    {
        if (ranges is null)
            throw new ArgumentNullException(nameof(ranges));

        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_UMat_subMat2(ptr, ranges.Length, ranges, out var ret));
        var retVal = new UMat(ret);
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
            NativeMethods.core_UMat_isContinuous(ptr, out var ret));
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
            NativeMethods.core_UMat_isSubmatrix(ptr, out var ret));
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
            NativeMethods.core_UMat_elemSize(ptr, out var ret));
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
            NativeMethods.core_UMat_elemSize1(ptr, out var ret));
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
            NativeMethods.core_UMat_type(ptr, out var ret));
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
            NativeMethods.core_UMat_depth(ptr, out var ret));
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
            NativeMethods.core_UMat_channels(ptr, out var ret));
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
            NativeMethods.core_UMat_step1(ptr, i, out var ret));
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
            NativeMethods.core_UMat_empty(ptr, out var ret));
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
            NativeMethods.core_UMat_total(ptr, out var ret));
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
            NativeMethods.core_UMat_checkVector(
                ptr, elemChannels, depth, requireContinuous ? 1 : 0, out var ret));
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
                NativeMethods.core_UMat_flags(ptr, out var ret));
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
                NativeMethods.core_UMat_dims(ptr, out var ret));
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
                NativeMethods.core_UMat_rows(ptr, out var ret));
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
                NativeMethods.core_UMat_cols(ptr, out var ret));
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
    /// Returns a matrix size.
    /// </summary>
    /// <returns></returns>
    public Size Size()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_UMat_size(ptr, out var ret));
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
            NativeMethods.core_UMat_sizeAt(ptr, dim, out var ret));
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
            NativeMethods.core_UMat_step(ptr, out var ret));
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
            NativeMethods.core_UMat_stepAt(ptr, i, out var ret));
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
        if (IsDisposed)
            return "Mat [disposed]";

        return "Mat [ " +
               Rows + "*" + Cols + "*" + Type().ToString() +
               ", IsContinuous=" + IsContinuous() + ", IsSubmatrix=" + IsSubmatrix() +
               ", Ptr=0x" + Convert.ToString(ptr.ToInt64(), 16) +
               " ]";
    }

    #endregion

    #region EmptyClone

    /// <summary>
    /// Makes a Mat that have the same size, depth and channels as this image
    /// </summary>
    /// <returns></returns>
    public UMat EmptyClone(UMatUsageFlags usageFlags = UMatUsageFlags.None)
    {
        ThrowIfDisposed();
        return new UMat(Size(), Type(), usageFlags);
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    /// <param name="usageFlags">usage flags for allocator</param>
    /// <returns></returns>
    public UMat Alignment(int n = 4, UMatUsageFlags usageFlags = UMatUsageFlags.None)
    {
        var newCols = Cv2.AlignSize(Cols, n);
        using var pMat = new UMat(Rows, newCols, Type(), usageFlags);
#pragma warning disable CA2000
        var roiMat = new UMat(pMat, new Rect(0, 0, Cols, Rows));
#pragma warning restore CA2000
        CopyTo(roiMat);
        return roiMat;
    }
        
    #endregion
}
