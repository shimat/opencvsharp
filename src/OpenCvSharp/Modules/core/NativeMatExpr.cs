using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Matrix expression
/// </summary>
internal sealed partial class NativeMatExpr : CvObject
{
    #region Init & Disposal

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ptr"></param>
    internal NativeMatExpr(IntPtr ptr)
    {
        InitSafeHandle(ptr);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mat"></param>
    internal NativeMatExpr(Mat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_new2(mat.CvPtr, out var p));
        InitSafeHandle(p);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.core_MatExpr_delete(h))));
    }

    #endregion

    #region Cast

    /// <summary>
    /// Convert to cv::Mat
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static implicit operator Mat(NativeMatExpr self)
    {
#pragma warning disable CA1065 // TODO
        ArgumentNullException.ThrowIfNull(self);
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
                NativeMethods.core_MatExpr_toMat(Handle, mat.CvPtr));
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
    public static implicit operator NativeMatExpr(Mat mat)
    {
        return new NativeMatExpr(mat);
    }

    /// <summary>
    /// Convert cv::Mat to cv::MatExpr
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public static NativeMatExpr FromMat(Mat mat)
    {
        return new NativeMatExpr(mat);
    }

    #endregion

    #region Operators

#pragma warning disable 1591
        
    public static NativeMatExpr operator +(NativeMatExpr e) => e;

    public NativeMatExpr Plus() => this;

    public static NativeMatExpr operator -(NativeMatExpr e)
    {
        ArgumentNullException.ThrowIfNull(e);
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorUnaryMinus_MatExpr(e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public NativeMatExpr Negate() => -this;

    public static NativeMatExpr operator ~(NativeMatExpr e)
    {
        ArgumentNullException.ThrowIfNull(e);
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorUnaryNot_MatExpr(e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public NativeMatExpr OnesComplement() => ~this;

    public static NativeMatExpr operator +(NativeMatExpr e, Mat m)
    {
        ArgumentNullException.ThrowIfNull(e);
        ArgumentNullException.ThrowIfNull(m);
        e.ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorAdd_MatExprMat(e.CvPtr, m.CvPtr, out var ret));
        GC.KeepAlive(e);
        GC.KeepAlive(m);
        return new NativeMatExpr(ret);
    }
        
    public static NativeMatExpr operator +(Mat m, NativeMatExpr e)
    {
        ArgumentNullException.ThrowIfNull(m);
        ArgumentNullException.ThrowIfNull(e);
        m.ThrowIfDisposed();
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorAdd_MatMatExpr(m.CvPtr, e.CvPtr, out var ret));
        GC.KeepAlive(m);
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator +(NativeMatExpr e, Scalar s)
    {
        ArgumentNullException.ThrowIfNull(e);
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorAdd_MatExprScalar(e.CvPtr, s, out var ret));
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator +(Scalar s, NativeMatExpr e)
    {
        ArgumentNullException.ThrowIfNull(e);
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorAdd_ScalarMatExpr(s, e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator +(NativeMatExpr e1, NativeMatExpr e2)
    {
        ArgumentNullException.ThrowIfNull(e1);
        ArgumentNullException.ThrowIfNull(e2);
        e1.ThrowIfDisposed();
        e2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorAdd_MatExprMatExpr(e1.CvPtr, e2.CvPtr, out var ret));
        GC.KeepAlive(e1);
        GC.KeepAlive(e2);
        return new NativeMatExpr(ret);
    }

    public NativeMatExpr Add(Mat m) => this + m;
    public NativeMatExpr Add(NativeMatExpr me) => this + me;
    public NativeMatExpr Add(Scalar s) => this + s;

    public static NativeMatExpr operator -(NativeMatExpr e, Mat m)
    {
        ArgumentNullException.ThrowIfNull(e);
        ArgumentNullException.ThrowIfNull(m);
        e.ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorSubtract_MatExprMat(e.CvPtr, m.CvPtr, out var ret));
        GC.KeepAlive(e);
        GC.KeepAlive(m);
        return new NativeMatExpr(ret);
    }
        
    public static NativeMatExpr operator -(Mat m, NativeMatExpr e)
    {
        ArgumentNullException.ThrowIfNull(m);
        ArgumentNullException.ThrowIfNull(e);
        m.ThrowIfDisposed();
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorSubtract_MatMatExpr(m.CvPtr, e.CvPtr, out var ret));
        GC.KeepAlive(m);
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator -(NativeMatExpr e, Scalar s)
    {
        ArgumentNullException.ThrowIfNull(e);
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorSubtract_MatExprScalar(e.CvPtr, s, out var ret));
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator -(Scalar s, NativeMatExpr e)
    {
        ArgumentNullException.ThrowIfNull(e);
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorSubtract_ScalarMatExpr(s, e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator -(NativeMatExpr e1, NativeMatExpr e2)
    {
        ArgumentNullException.ThrowIfNull(e1);
        ArgumentNullException.ThrowIfNull(e2);
        e1.ThrowIfDisposed();
        e2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorSubtract_MatExprMatExpr(e1.CvPtr, e2.CvPtr, out var ret));
        GC.KeepAlive(e1);
        GC.KeepAlive(e2);
        return new NativeMatExpr(ret);
    }

    public NativeMatExpr Subtract(Mat m) => this - m;
    public NativeMatExpr Subtract(NativeMatExpr me) => this - me;
    public NativeMatExpr Subtract(Scalar s) => this - s;

    public static NativeMatExpr operator *(NativeMatExpr e, Mat m)
    {
        ArgumentNullException.ThrowIfNull(e);
        ArgumentNullException.ThrowIfNull(m);
        e.ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorMultiply_MatExprMat(e.CvPtr, m.CvPtr, out var ret));
        GC.KeepAlive(e);
        GC.KeepAlive(m);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator *(Mat m, NativeMatExpr e)
    {
        ArgumentNullException.ThrowIfNull(m);
        ArgumentNullException.ThrowIfNull(e);
        m.ThrowIfDisposed();
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorMultiply_MatMatExpr(m.CvPtr, e.CvPtr, out var ret));
        GC.KeepAlive(m);
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator *(NativeMatExpr e, double s)
    {
        ArgumentNullException.ThrowIfNull(e);
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorMultiply_MatExprDouble(e.CvPtr, s, out var ret));
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator *(double s, NativeMatExpr e)
    {
        ArgumentNullException.ThrowIfNull(e);
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorMultiply_DoubleMatExpr(s, e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator *(NativeMatExpr e1, NativeMatExpr e2)
    {
        ArgumentNullException.ThrowIfNull(e1);
        ArgumentNullException.ThrowIfNull(e2);
        e1.ThrowIfDisposed();
        e2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorMultiply_MatExprMatExpr(e1.CvPtr, e2.CvPtr, out var ret));
        GC.KeepAlive(e1);
        GC.KeepAlive(e2);
        return new NativeMatExpr(ret);
    }

    public NativeMatExpr Multiply(Mat m) => this * m;
    public NativeMatExpr Multiply(NativeMatExpr me) => this * me;
    public NativeMatExpr Multiply(double s) => this * s;

    public static NativeMatExpr operator /(NativeMatExpr e, Mat m)
    {
        ArgumentNullException.ThrowIfNull(e);
        ArgumentNullException.ThrowIfNull(m);
        e.ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorDivide_MatExprMat(e.CvPtr, m.CvPtr, out var ret));
        GC.KeepAlive(e);
        GC.KeepAlive(m);
        return new NativeMatExpr(ret);
    }
        
    public static NativeMatExpr operator /(Mat m, NativeMatExpr e)
    {
        ArgumentNullException.ThrowIfNull(m);
        ArgumentNullException.ThrowIfNull(e);
        m.ThrowIfDisposed();
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorDivide_MatMatExpr(m.CvPtr, e.CvPtr, out var ret));
        GC.KeepAlive(m);
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator /(NativeMatExpr e, double s)
    {
        ArgumentNullException.ThrowIfNull(e);
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorDivide_MatExprDouble(e.CvPtr, s, out var ret));
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator /(double s, NativeMatExpr e)
    {
        ArgumentNullException.ThrowIfNull(e);
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorDivide_DoubleMatExpr(s, e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    }

    public static NativeMatExpr operator /(NativeMatExpr e1, NativeMatExpr e2)
    {
        ArgumentNullException.ThrowIfNull(e1);
        ArgumentNullException.ThrowIfNull(e2);
        e1.ThrowIfDisposed();
        e2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_operatorDivide_MatExprMatExpr(e1.CvPtr, e2.CvPtr, out var ret));
        GC.KeepAlive(e1);
        GC.KeepAlive(e2);
        return new NativeMatExpr(ret);
    }

    public NativeMatExpr Divide(Mat m) => this / m;
    public NativeMatExpr Divide(NativeMatExpr me) => this / me;
    public NativeMatExpr Divide(double s) => this / s;

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
    public NativeMatExpr this[int rowStart, int rowEnd, int colStart, int colEnd]
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
    public NativeMatExpr this[Range rowRange, Range colRange]
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
    public NativeMatExpr this[Rect roi]
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
    public NativeMatExpr Row(int y)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_row(Handle, y, out var ret));
        return new NativeMatExpr(ret);
    }

    /// <summary>
    /// Creates a matrix header for the specified matrix column.
    /// </summary>
    /// <param name="x">A 0-based column index.</param>
    /// <returns></returns>
    public NativeMatExpr Col(int x)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_col(Handle, x, out var ret));
        return new NativeMatExpr(ret);
    }

    /// <summary>
    /// Extracts a diagonal from a matrix
    /// </summary>
    /// <param name="d">d index of the diagonal, with the following values:
    /// - d=0 is the main diagonal.
    /// - d&lt;0 is a diagonal from the lower half. For example, d=-1 means the diagonal is set immediately below the main one.
    /// - d&gt;0 is a diagonal from the upper half. For example, d=1 means the diagonal is set immediately above the main one.</param>
    /// <returns></returns>
    public NativeMatExpr Diag(MatDiagType d = MatDiagType.Main)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_diag(Handle, (int) d, out var ret));
        var retVal = new NativeMatExpr(ret);
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
    public NativeMatExpr SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_submat(Handle, rowStart, rowEnd, colStart, colEnd, out var ret));
        var retVal = new NativeMatExpr(ret);
        return retVal;
    }

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    /// <param name="rowRange"></param>
    /// <param name="colRange"></param>
    /// <returns></returns>
    public NativeMatExpr SubMat(Range rowRange, Range colRange)
    {
        return SubMat(rowRange.Start, rowRange.End, colRange.Start, colRange.End);
    }

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    /// <param name="roi"></param>
    /// <returns></returns>
    public NativeMatExpr SubMat(Rect roi)
    {
        return SubMat(roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);
    }

    /// <summary>
    /// Transposes a matrix.
    /// </summary>
    /// <returns></returns>
    public NativeMatExpr T()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_t(Handle, out var ret));
        var retVal = new NativeMatExpr(ret);
        return retVal;
    }

    /// <summary>
    /// Inverses a matrix.
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public NativeMatExpr Inv(DecompTypes method = DecompTypes.LU)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_inv(Handle, (int) method, out var ret));
        var retVal = new NativeMatExpr(ret);
        return retVal;
    }

    /// <summary>
    /// Performs an element-wise multiplication or division of the two matrices.
    /// </summary>
    /// <param name="e">Another array of the same type and the same size as this, or a matrix expression.</param>
    /// <param name="scale">Optional scale factor.</param>
    /// <returns></returns>
    public NativeMatExpr Mul(NativeMatExpr e, double scale = 1.0)
    {
        ArgumentNullException.ThrowIfNull(e);
        ThrowIfDisposed();
        e.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_mul_toMatExpr(Handle, e.CvPtr, scale, out var ret));

        GC.KeepAlive(e);
        var retVal = new NativeMatExpr(ret);
        return retVal;

    }

    /// <summary>
    /// Performs an element-wise multiplication or division of the two matrices.
    /// </summary>
    /// <param name="m">Another array of the same type and the same size as this, or a matrix expression.</param>
    /// <param name="scale">Optional scale factor.</param>
    /// <returns></returns>
    public NativeMatExpr Mul(Mat m, double scale = 1.0)
    {
        ArgumentNullException.ThrowIfNull(m);
        ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_mul_toMat(Handle, m.CvPtr, scale, out var ret));

        GC.KeepAlive(m);
        var retVal = new NativeMatExpr(ret);
        return retVal;
    }

    /// <summary>
    /// Computes a cross-product of two 3-element vectors.
    /// </summary>
    /// <param name="m">Another cross-product operand.</param>
    /// <returns></returns>
    public Mat Cross(Mat m)
    {
        ArgumentNullException.ThrowIfNull(m);

        ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_cross(Handle, m.CvPtr, out var ret));

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
        ArgumentNullException.ThrowIfNull(m);
        ThrowIfDisposed();
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_dot(Handle, m.CvPtr, out var ret));

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
            NativeMethods.core_MatExpr_size(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the type of a matrix element.
    /// </summary>
    public MatType Type()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_MatExpr_type(Handle, out var ret));
        return (MatType) ret;
    }

    #endregion
}
