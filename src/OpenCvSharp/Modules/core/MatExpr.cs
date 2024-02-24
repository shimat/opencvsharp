using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Matrix expression
/// </summary>
public sealed partial class MatExpr : DisposableCvObject
{
    #region Init & Disposal

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ptr"></param>
    internal MatExpr(IntPtr ptr)
    {
        this.ptr = ptr;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mat"></param>
    internal MatExpr(Mat mat)
    {
        if (mat is null)
            throw new ArgumentNullException(nameof(mat));
        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_new2(mat.CvPtr, out ptr));
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_delete(ptr));
        base.DisposeUnmanaged();
    }

    #endregion

    #region Cast

    /// <summary>
    /// Convert to cv::Mat
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static implicit operator Mat(MatExpr self)
    {
#pragma warning disable CA1065 // TODO
        if (self is null)
            throw new ArgumentNullException(nameof(self));
#pragma warning restore CA1065 
        return self.ToMat();
    }

    /// <summary>
    /// Convert to cv::Mat
    /// </summary>
    /// <returns></returns>
    public Mat ToMat()
    {
        Mat? mat = null;
        try
        {
            mat = new Mat();
            NativeMethods.HandleException(
                NativeMethods.core_MatExpr_toMat(ptr, mat.CvPtr));
            GC.KeepAlive(this);
            return mat;
        }
        catch
        {
            mat?.Dispose();
            throw;
        }
    }

    /// <summary>
    /// Convert cv::Mat to cv::MatExpr
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public static implicit operator MatExpr(Mat mat)
    {
        return new MatExpr(mat);
    }

    /// <summary>
    /// Convert cv::Mat to cv::MatExpr
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public static MatExpr FromMat(Mat mat)
    {
        return new MatExpr(mat);
    }

    #endregion

    #region Operators

#pragma warning disable 1591
        
    public static MatExpr operator +(MatExpr e) => e;

    public MatExpr Plus() => this;

    public static MatExpr operator -(MatExpr e)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorUnaryMinus_MatExpr(e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public MatExpr Negate() => -this;

    public static MatExpr operator ~(MatExpr e)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorUnaryNot_MatExpr(e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public MatExpr OnesComplement() => ~this;

    public static MatExpr operator +(MatExpr e, Mat m)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        e.ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorAdd_MatExprMat(e.CvPtr, m.CvPtr, out var ret));
        GC.KeepAlive(e);
        GC.KeepAlive(m);
        return new MatExpr(ret);
    }
        
    public static MatExpr operator +(Mat m, MatExpr e)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        m.ThrowIfDisposed();
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorAdd_MatMatExpr(m.CvPtr, e.CvPtr, out var ret));
        GC.KeepAlive(m);
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public static MatExpr operator +(MatExpr e, Scalar s)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorAdd_MatExprScalar(e.CvPtr, s, out var ret));
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public static MatExpr operator +(Scalar s, MatExpr e)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorAdd_ScalarMatExpr(s, e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public static MatExpr operator +(MatExpr e1, MatExpr e2)
    {
        if (e1 is null)
            throw new ArgumentNullException(nameof(e1));
        if (e2 is null)
            throw new ArgumentNullException(nameof(e2));
        e1.ThrowIfDisposed();
        e2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorAdd_MatExprMatExpr(e1.CvPtr, e2.CvPtr, out var ret));
        GC.KeepAlive(e1);
        GC.KeepAlive(e2);
        return new MatExpr(ret);
    }

    public MatExpr Add(Mat m) => this + m;
    public MatExpr Add(MatExpr me) => this + me;
    public MatExpr Add(Scalar s) => this + s;

    public static MatExpr operator -(MatExpr e, Mat m)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        e.ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorSubtract_MatExprMat(e.CvPtr, m.CvPtr, out var ret));
        GC.KeepAlive(e);
        GC.KeepAlive(m);
        return new MatExpr(ret);
    }
        
    public static MatExpr operator -(Mat m, MatExpr e)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        m.ThrowIfDisposed();
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorSubtract_MatMatExpr(m.CvPtr, e.CvPtr, out var ret));
        GC.KeepAlive(m);
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public static MatExpr operator -(MatExpr e, Scalar s)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorSubtract_MatExprScalar(e.CvPtr, s, out var ret));
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public static MatExpr operator -(Scalar s, MatExpr e)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorSubtract_ScalarMatExpr(s, e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public static MatExpr operator -(MatExpr e1, MatExpr e2)
    {
        if (e1 is null)
            throw new ArgumentNullException(nameof(e1));
        if (e2 is null)
            throw new ArgumentNullException(nameof(e2));
        e1.ThrowIfDisposed();
        e2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorSubtract_MatExprMatExpr(e1.CvPtr, e2.CvPtr, out var ret));
        GC.KeepAlive(e1);
        GC.KeepAlive(e2);
        return new MatExpr(ret);
    }

    public MatExpr Subtract(Mat m) => this - m;
    public MatExpr Subtract(MatExpr me) => this - me;
    public MatExpr Subtract(Scalar s) => this - s;

    public static MatExpr operator *(MatExpr e, Mat m)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        e.ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorMultiply_MatExprMat(e.CvPtr, m.CvPtr, out var ret));
        GC.KeepAlive(e);
        GC.KeepAlive(m);
        return new MatExpr(ret);
    }

    public static MatExpr operator *(Mat m, MatExpr e)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        m.ThrowIfDisposed();
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorMultiply_MatMatExpr(m.CvPtr, e.CvPtr, out var ret));
        GC.KeepAlive(m);
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public static MatExpr operator *(MatExpr e, double s)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorMultiply_MatExprDouble(e.CvPtr, s, out var ret));
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public static MatExpr operator *(double s, MatExpr e)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorMultiply_DoubleMatExpr(s, e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public static MatExpr operator *(MatExpr e1, MatExpr e2)
    {
        if (e1 is null)
            throw new ArgumentNullException(nameof(e1));
        if (e2 is null)
            throw new ArgumentNullException(nameof(e2));
        e1.ThrowIfDisposed();
        e2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorMultiply_MatExprMatExpr(e1.CvPtr, e2.CvPtr, out var ret));
        GC.KeepAlive(e1);
        GC.KeepAlive(e2);
        return new MatExpr(ret);
    }

    public MatExpr Multiply(Mat m) => this * m;
    public MatExpr Multiply(MatExpr me) => this * me;
    public MatExpr Multiply(double s) => this * s;

    public static MatExpr operator /(MatExpr e, Mat m)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        e.ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorDivide_MatExprMat(e.CvPtr, m.CvPtr, out var ret));
        GC.KeepAlive(e);
        GC.KeepAlive(m);
        return new MatExpr(ret);
    }
        
    public static MatExpr operator /(Mat m, MatExpr e)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        m.ThrowIfDisposed();
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorDivide_MatMatExpr(m.CvPtr, e.CvPtr, out var ret));
        GC.KeepAlive(m);
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public static MatExpr operator /(MatExpr e, double s)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorDivide_MatExprDouble(e.CvPtr, s, out var ret));
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public static MatExpr operator /(double s, MatExpr e)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorDivide_DoubleMatExpr(s, e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new MatExpr(ret);
    }

    public static MatExpr operator /(MatExpr e1, MatExpr e2)
    {
        if (e1 is null)
            throw new ArgumentNullException(nameof(e1));
        if (e2 is null)
            throw new ArgumentNullException(nameof(e2));
        e1.ThrowIfDisposed();
        e2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorDivide_MatExprMatExpr(e1.CvPtr, e2.CvPtr, out var ret));
        GC.KeepAlive(e1);
        GC.KeepAlive(e2);
        return new MatExpr(ret);
    }

    public MatExpr Divide(Mat m) => this / m;
    public MatExpr Divide(MatExpr me) => this / me;
    public MatExpr Divide(double s) => this / s;

#pragma warning restore 1591

    #endregion

    #region Methods

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    /// <param name="rowStart"></param>
    /// <param name="rowEnd"></param>
    /// <param name="colStart"></param>
    /// <param name="colEnd"></param>
    /// <returns></returns>
    public MatExpr this[int rowStart, int rowEnd, int colStart, int colEnd]
    {
        get
        {
            ThrowIfDisposed();
            return SubMat(rowStart, rowEnd, colStart, colEnd);
        }
    }

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    /// <param name="rowRange"></param>
    /// <param name="colRange"></param>
    /// <returns></returns>
    public MatExpr this[Range rowRange, Range colRange]
    {
        get
        {
            ThrowIfDisposed();
            return SubMat(rowRange, colRange);
        }
    }

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    /// <param name="roi"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Design", "CA1043: Use integral or string argument for indexers")]
    public MatExpr this[Rect roi]
    {
        get
        {
            ThrowIfDisposed();
            return SubMat(roi);
        }
    }

    /// <summary>
    /// Creates a matrix header for the specified matrix row.
    /// </summary>
    /// <param name="y">A 0-based row index.</param>
    /// <returns></returns>
    public MatExpr Row(int y)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_row(ptr, y, out var ret));
        GC.KeepAlive(this);
        return new MatExpr(ret);
    }

    /// <summary>
    /// Creates a matrix header for the specified matrix column.
    /// </summary>
    /// <param name="x">A 0-based column index.</param>
    /// <returns></returns>
    public MatExpr Col(int x)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_col(ptr, x, out var ret));
        GC.KeepAlive(this);
        return new MatExpr(ret);
    }

    /// <summary>
    /// Extracts a diagonal from a matrix
    /// </summary>
    /// <param name="d">d index of the diagonal, with the following values:
    /// - d=0 is the main diagonal.
    /// - d&lt;0 is a diagonal from the lower half. For example, d=-1 means the diagonal is set immediately below the main one.
    /// - d&gt;0 is a diagonal from the upper half. For example, d=1 means the diagonal is set immediately above the main one.</param>
    /// <returns></returns>
    public MatExpr Diag(MatDiagType d = MatDiagType.Main)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_diag(ptr, (int) d, out var ret));
        GC.KeepAlive(this);
        var retVal = new MatExpr(ret);
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
    public MatExpr SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_submat(ptr, rowStart, rowEnd, colStart, colEnd, out var ret));
        GC.KeepAlive(this);
        var retVal = new MatExpr(ret);
        return retVal;
    }

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    /// <param name="rowRange"></param>
    /// <param name="colRange"></param>
    /// <returns></returns>
    public MatExpr SubMat(Range rowRange, Range colRange)
    {
        return SubMat(rowRange.Start, rowRange.End, colRange.Start, colRange.End);
    }

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    /// <param name="roi"></param>
    /// <returns></returns>
    public MatExpr SubMat(Rect roi)
    {
        return SubMat(roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);
    }

    /// <summary>
    /// Transposes a matrix.
    /// </summary>
    /// <returns></returns>
    public MatExpr T()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_t(ptr, out var ret));
        GC.KeepAlive(this);
        var retVal = new MatExpr(ret);
        return retVal;
    }

    /// <summary>
    /// Inverses a matrix.
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public MatExpr Inv(DecompTypes method = DecompTypes.LU)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_inv(ptr, (int) method, out var ret));
        GC.KeepAlive(this);
        var retVal = new MatExpr(ret);
        return retVal;
    }

    /// <summary>
    /// Performs an element-wise multiplication or division of the two matrices.
    /// </summary>
    /// <param name="e">Another array of the same type and the same size as this, or a matrix expression.</param>
    /// <param name="scale">Optional scale factor.</param>
    /// <returns></returns>
    public MatExpr Mul(MatExpr e, double scale = 1.0)
    {
        if (e is null)
            throw new ArgumentNullException(nameof(e));
        ThrowIfDisposed();
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_mul_toMatExpr(ptr, e.CvPtr, scale, out var ret));

        GC.KeepAlive(this);
        GC.KeepAlive(e);
        var retVal = new MatExpr(ret);
        return retVal;

    }

    /// <summary>
    /// Performs an element-wise multiplication or division of the two matrices.
    /// </summary>
    /// <param name="m">Another array of the same type and the same size as this, or a matrix expression.</param>
    /// <param name="scale">Optional scale factor.</param>
    /// <returns></returns>
    public MatExpr Mul(Mat m, double scale = 1.0)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_mul_toMat(ptr, m.CvPtr, scale, out var ret));

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
    public Mat Cross(Mat m)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));

        ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_cross(ptr, m.CvPtr, out var ret));

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
    public double Dot(Mat m)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_dot(ptr, m.CvPtr, out var ret));

        GC.KeepAlive(this);
        GC.KeepAlive(m);
        return ret;
    }

    /// <summary>
    /// Returns the size of a matrix element.
    /// </summary>
    public Size Size()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_size(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Returns the type of a matrix element.
    /// </summary>
    public MatType Type()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_type(ptr, out var ret));
        GC.KeepAlive(this);
        return (MatType) ret;
    }

    #endregion
}
