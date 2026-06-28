using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// A purely managed, lazily-evaluated matrix expression — the result of <see cref="Mat"/>
/// arithmetic. This is the managed counterpart of OpenCV's <c>cv::MatExpr</c> (issue #1974).
/// </summary>
/// <remarks>
/// <para>
/// A <see cref="Mat"/> operator such as <c>a + b</c> returns a <see cref="MatExpr"/> without
/// creating any native object: it simply captures its operands in a deferred delegate. The native
/// <c>cv::MatExpr</c> chain is built only when the expression is materialized (<see cref="ToMat"/>
/// or the implicit conversion to <see cref="Mat"/>), and every native intermediate is disposed
/// immediately during that evaluation. Nothing escapes to the finalizer, intermediates never
/// extend operand lifetimes, and no <c>using</c> dance is required: a chain such as
/// <c>255 - mat * 0.8</c> is leak-free and can be received straight into a <c>Mat</c>.
/// </para>
/// <para>
/// Operators that OpenCV only defines on <c>Mat</c> (the comparisons, the bitwise operators,
/// <c>min</c>/<c>max</c>) are evaluated by materializing the operand subtrees to <see cref="Mat"/>
/// at that node and applying the <c>Mat</c>-level operation — exactly what OpenCV C++ does, since
/// those operators take <c>Mat</c> and implicitly evaluate any expression operands. The arithmetic
/// operators (<c>+ - * /</c>) and <c>abs</c> keep OpenCV's native cross-node expression fusion.
/// </para>
/// </remarks>
public sealed class MatExpr
{
    // Deferred evaluation. Invoking this builds the native cv::MatExpr (wrapped as NativeMatExpr)
    // for this subtree; the returned object is owned by the caller and every intermediate created
    // inside is already disposed.
    private readonly Func<NativeMatExpr> evaluate;

    private MatExpr(Func<NativeMatExpr> evaluate) => this.evaluate = evaluate;

    internal NativeMatExpr Eval() => evaluate();

    // Builds a leaf/source node from a factory that produces a fresh NativeMatExpr on each
    // materialization (e.g. Mat.Eye/Zeros/Ones). The factory must create a new instance every
    // call because Eval may run more than once for a reused subtree.
    internal static MatExpr FromExpr(Func<NativeMatExpr> factory) =>
        new(factory ?? throw new ArgumentNullException(nameof(factory)));

    #region Materialization

    /// <summary>
    /// Materializes the expression into a new <see cref="Mat"/>.
    /// </summary>
    public Mat ToMat()
    {
        using var expr = Eval();
        return expr.ToMat();
    }

    /// <summary>
    /// Wraps a <see cref="Mat"/> as a leaf node of the expression tree.
    /// </summary>
    public static MatExpr From(Mat mat)
    {
        if (mat is null)
            throw new ArgumentNullException(nameof(mat));
        // Capturing 'mat' keeps it alive until the (possibly much later) materialization.
        return new MatExpr(() => new NativeMatExpr(mat));
    }

    /// <summary>
    /// Materializes the expression into a new <see cref="Mat"/>.
    /// </summary>
    public static implicit operator Mat(MatExpr node) =>
        (node ?? throw new ArgumentNullException(nameof(node))).ToMat();

    // NOTE: There is deliberately no implicit Mat -> MatExpr conversion. Combined with the
    // implicit MatExpr -> Mat above it would make every mixed expression (e.g. node + mat,
    // or even node + Scalar via node -> Mat) ambiguous against Mat's own operators (CS9342).
    // Wrap Mat leaves explicitly with From(), or use the Mat-operand operator overloads below.

    #endregion

#pragma warning disable 1591

    #region Arithmetic operators

    public static MatExpr operator +(MatExpr e) => NotNull(e);
    public static MatExpr operator -(MatExpr e)
    {
        NotNull(e);
        return new MatExpr(() => { using var inner = e.Eval(); return -inner; });
    }

    public MatExpr Plus() => this;
    public MatExpr Negate() => -this;

    public static MatExpr operator +(MatExpr a, MatExpr b) => Combine(a, b, static (l, r) => l + r);
    public static MatExpr operator +(MatExpr a, Mat b) => Combine(a, b, static (l, r) => l + r);
    public static MatExpr operator +(Mat a, MatExpr b) => Combine(b, a, static (r, l) => l + r);
    public static MatExpr operator +(MatExpr a, Scalar s) => Map(a, e => e + s);
    public static MatExpr operator +(Scalar s, MatExpr a) => Map(a, e => s + e);

    public static MatExpr operator -(MatExpr a, MatExpr b) => Combine(a, b, static (l, r) => l - r);
    public static MatExpr operator -(MatExpr a, Mat b) => Combine(a, b, static (l, r) => l - r);
    public static MatExpr operator -(Mat a, MatExpr b) => Combine(b, a, static (r, l) => l - r);
    public static MatExpr operator -(MatExpr a, Scalar s) => Map(a, e => e - s);
    public static MatExpr operator -(Scalar s, MatExpr a) => Map(a, e => s - e);

    public static MatExpr operator *(MatExpr a, MatExpr b) => Combine(a, b, static (l, r) => l * r);
    public static MatExpr operator *(MatExpr a, Mat b) => Combine(a, b, static (l, r) => l * r);
    public static MatExpr operator *(Mat a, MatExpr b) => Combine(b, a, static (r, l) => l * r);
    public static MatExpr operator *(MatExpr a, double s) => Map(a, e => e * s);
    public static MatExpr operator *(double s, MatExpr a) => Map(a, e => s * e);

    public static MatExpr operator /(MatExpr a, MatExpr b) => Combine(a, b, static (l, r) => l / r);
    public static MatExpr operator /(MatExpr a, Mat b) => Combine(a, b, static (l, r) => l / r);
    public static MatExpr operator /(Mat a, MatExpr b) => Combine(b, a, static (r, l) => l / r);
    public static MatExpr operator /(MatExpr a, double s) => Map(a, e => e / s);
    public static MatExpr operator /(double s, MatExpr a) => Map(a, e => s / e);

    public MatExpr Add(MatExpr e) => this + e;
    public MatExpr Add(Mat m) => this + m;
    public MatExpr Add(Scalar s) => this + s;
    public MatExpr Subtract(MatExpr e) => this - e;
    public MatExpr Subtract(Mat m) => this - m;
    public MatExpr Subtract(Scalar s) => this - s;
    public MatExpr Multiply(MatExpr e) => this * e;
    public MatExpr Multiply(Mat m) => this * m;
    public MatExpr Multiply(double s) => this * s;
    public MatExpr Divide(MatExpr e) => this / e;
    public MatExpr Divide(Mat m) => this / m;
    public MatExpr Divide(double s) => this / s;

    #endregion

    #region Bitwise operators (materialize operands to Mat)

    public static MatExpr operator ~(MatExpr e) => MapMat(NotNull(e), NativeNot);

    public static MatExpr operator &(MatExpr a, MatExpr b) => CombineMat(a, b, NativeAnd);
    public static MatExpr operator &(MatExpr a, Mat b) => CombineMat(a, b, NativeAnd);
    public static MatExpr operator &(Mat a, MatExpr b) => CombineMat(b, a, static (r, l) => NativeAnd(l, r));
    public static MatExpr operator &(MatExpr a, double s) => MapMat(a, m => NativeAnd(m, s));
    public static MatExpr operator &(double s, MatExpr a) => MapMat(a, m => NativeAnd(s, m));

    public static MatExpr operator |(MatExpr a, MatExpr b) => CombineMat(a, b, NativeOr);
    public static MatExpr operator |(MatExpr a, Mat b) => CombineMat(a, b, NativeOr);
    public static MatExpr operator |(Mat a, MatExpr b) => CombineMat(b, a, static (r, l) => NativeOr(l, r));
    public static MatExpr operator |(MatExpr a, double s) => MapMat(a, m => NativeOr(m, s));
    public static MatExpr operator |(double s, MatExpr a) => MapMat(a, m => NativeOr(s, m));

    public static MatExpr operator ^(MatExpr a, MatExpr b) => CombineMat(a, b, NativeXor);
    public static MatExpr operator ^(MatExpr a, Mat b) => CombineMat(a, b, NativeXor);
    public static MatExpr operator ^(Mat a, MatExpr b) => CombineMat(b, a, static (r, l) => NativeXor(l, r));
    public static MatExpr operator ^(MatExpr a, double s) => MapMat(a, m => NativeXor(m, s));
    public static MatExpr operator ^(double s, MatExpr a) => MapMat(a, m => NativeXor(s, m));

    public MatExpr OnesComplement() => ~this;
    public MatExpr BitwiseAnd(MatExpr e) => this & e;
    public MatExpr BitwiseAnd(Mat m) => this & m;
    public MatExpr BitwiseAnd(double s) => this & s;
    public MatExpr BitwiseOr(MatExpr e) => this | e;
    public MatExpr BitwiseOr(Mat m) => this | m;
    public MatExpr BitwiseOr(double s) => this | s;
    public MatExpr Xor(MatExpr e) => this ^ e;
    public MatExpr Xor(Mat m) => this ^ m;
    public MatExpr Xor(double s) => this ^ s;

    #endregion

#pragma warning restore 1591

    #region Comparison (materialize operands to Mat)

    /// <summary>operator &lt;</summary>
    public MatExpr LessThan(MatExpr e) => CombineMat(this, NotNull(e), NativeLt);
    /// <summary>operator &lt;</summary>
    public MatExpr LessThan(Mat m) => CombineMat(this, m, NativeLt);
    /// <summary>operator &lt;</summary>
    public MatExpr LessThan(double d) => MapMat(this, m => NativeLt(m, d));

    /// <summary>operator &lt;=</summary>
    public MatExpr LessThanOrEqual(MatExpr e) => CombineMat(this, NotNull(e), NativeLe);
    /// <summary>operator &lt;=</summary>
    public MatExpr LessThanOrEqual(Mat m) => CombineMat(this, m, NativeLe);
    /// <summary>operator &lt;=</summary>
    public MatExpr LessThanOrEqual(double d) => MapMat(this, m => NativeLe(m, d));

    /// <summary>operator &gt;</summary>
    public MatExpr GreaterThan(MatExpr e) => CombineMat(this, NotNull(e), NativeGt);
    /// <summary>operator &gt;</summary>
    public MatExpr GreaterThan(Mat m) => CombineMat(this, m, NativeGt);
    /// <summary>operator &gt;</summary>
    public MatExpr GreaterThan(double d) => MapMat(this, m => NativeGt(m, d));

    /// <summary>operator &gt;=</summary>
    public MatExpr GreaterThanOrEqual(MatExpr e) => CombineMat(this, NotNull(e), NativeGe);
    /// <summary>operator &gt;=</summary>
    public MatExpr GreaterThanOrEqual(Mat m) => CombineMat(this, m, NativeGe);
    /// <summary>operator &gt;=</summary>
    public MatExpr GreaterThanOrEqual(double d) => MapMat(this, m => NativeGe(m, d));

    /// <summary>operator ==</summary>
    public MatExpr Equal(MatExpr e) => CombineMat(this, NotNull(e), NativeEq);
    /// <summary>operator ==</summary>
    public MatExpr Equal(Mat m) => CombineMat(this, m, NativeEq);
    /// <summary>operator ==</summary>
    public MatExpr Equal(double d) => MapMat(this, m => NativeEq(m, d));

    /// <summary>operator !=</summary>
    public MatExpr NotEqual(MatExpr e) => CombineMat(this, NotNull(e), NativeNe);
    /// <summary>operator !=</summary>
    public MatExpr NotEqual(Mat m) => CombineMat(this, m, NativeNe);
    /// <summary>operator !=</summary>
    public MatExpr NotEqual(double d) => MapMat(this, m => NativeNe(m, d));

    #endregion

    #region Element-wise functions

    /// <summary>
    /// Computes an absolute value of each matrix element (cv::abs). Keeps native expression fusion.
    /// </summary>
    public MatExpr Abs() => new(() =>
    {
        using var e = Eval();
        NativeMethods.HandleException(NativeMethods.core_abs_MatExpr(e.CvPtr, out var ret));
        GC.KeepAlive(e);
        return new NativeMatExpr(ret);
    });

    /// <summary>
    /// Per-element minimum (cv::min). Operands are materialized to Mat.
    /// </summary>
    public MatExpr Min(MatExpr e) => new(() =>
    {
        using var l = ToMat();
        using var r = NotNull(e).ToMat();
        using var dst = new Mat();
        Cv2.Min(l, r, dst);
        return new NativeMatExpr(dst);
    });

    /// <summary>
    /// Per-element minimum (cv::min). Operands are materialized to Mat.
    /// </summary>
    public MatExpr Min(Mat m) => new(() =>
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        using var l = ToMat();
        using var dst = new Mat();
        Cv2.Min(l, m, dst);
        return new NativeMatExpr(dst);
    });

    /// <summary>
    /// Per-element minimum against a scalar value (cv::min).
    /// </summary>
    public MatExpr Min(double d) => new(() =>
    {
        using var l = ToMat();
        using var dst = new Mat();
        Cv2.Min(l, d, dst);
        return new NativeMatExpr(dst);
    });

    /// <summary>
    /// Per-element maximum (cv::max). Operands are materialized to Mat.
    /// </summary>
    public MatExpr Max(MatExpr e) => new(() =>
    {
        using var l = ToMat();
        using var r = NotNull(e).ToMat();
        using var dst = new Mat();
        Cv2.Max(l, r, dst);
        return new NativeMatExpr(dst);
    });

    /// <summary>
    /// Per-element maximum (cv::max). Operands are materialized to Mat.
    /// </summary>
    public MatExpr Max(Mat m) => new(() =>
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        using var l = ToMat();
        using var dst = new Mat();
        Cv2.Max(l, m, dst);
        return new NativeMatExpr(dst);
    });

    /// <summary>
    /// Per-element maximum against a scalar value (cv::max).
    /// </summary>
    public MatExpr Max(double d) => new(() =>
    {
        using var l = ToMat();
        using var dst = new Mat();
        Cv2.Max(l, d, dst);
        return new NativeMatExpr(dst);
    });

    #endregion

    #region Matrix methods

    /// <summary>
    /// Per-element multiplication (cv::MatExpr::mul).
    /// </summary>
    public MatExpr Mul(MatExpr e, double scale = 1.0)
    {
        NotNull(e);
        return new MatExpr(() => { using var a = Eval(); using var b = e.Eval(); return a.Mul(b, scale); });
    }

    /// <summary>
    /// Per-element multiplication (cv::MatExpr::mul).
    /// </summary>
    public MatExpr Mul(Mat m, double scale = 1.0)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        return new MatExpr(() => { using var a = Eval(); return a.Mul(m, scale); });
    }

    /// <summary>
    /// Transposition (cv::MatExpr::t).
    /// </summary>
    public MatExpr T() => new(() => { using var e = Eval(); return e.T(); });

    /// <summary>
    /// Inversion (cv::MatExpr::inv).
    /// </summary>
    public MatExpr Inv(DecompTypes method = DecompTypes.LU) => new(() => { using var e = Eval(); return e.Inv(method); });

    /// <summary>
    /// Creates a matrix header for the specified matrix row.
    /// </summary>
    public MatExpr Row(int y) => new(() => { using var e = Eval(); return e.Row(y); });

    /// <summary>
    /// Creates a matrix header for the specified matrix column.
    /// </summary>
    public MatExpr Col(int x) => new(() => { using var e = Eval(); return e.Col(x); });

    /// <summary>
    /// Extracts a diagonal from a matrix.
    /// </summary>
    public MatExpr Diag(MatDiagType d = MatDiagType.Main) => new(() => { using var e = Eval(); return e.Diag(d); });

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    public MatExpr SubMat(int rowStart, int rowEnd, int colStart, int colEnd) =>
        new(() => { using var e = Eval(); return e.SubMat(rowStart, rowEnd, colStart, colEnd); });

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    public MatExpr SubMat(Range rowRange, Range colRange) =>
        SubMat(rowRange.Start, rowRange.End, colRange.Start, colRange.End);

    /// <summary>
    /// Extracts a rectangular submatrix.
    /// </summary>
    public MatExpr SubMat(Rect roi) => SubMat(roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);

    /// <summary>
    /// Computes a cross-product of two 3-element vectors. Materializes the expression.
    /// </summary>
    public Mat Cross(Mat m)
    {
        using var e = Eval();
        return e.Cross(m);
    }

    /// <summary>
    /// Computes a dot-product of two vectors. Materializes the expression.
    /// </summary>
    public double Dot(Mat m)
    {
        using var e = Eval();
        return e.Dot(m);
    }

    /// <summary>
    /// Returns the size of the matrix. Materializes the expression.
    /// </summary>
    public Size Size()
    {
        using var e = Eval();
        return e.Size();
    }

    /// <summary>
    /// Returns the element type of the matrix. Materializes the expression.
    /// </summary>
    public MatType Type()
    {
        using var e = Eval();
        return e.Type();
    }

    #endregion

    #region Helpers

    private static MatExpr NotNull(MatExpr node) =>
        node ?? throw new ArgumentNullException(nameof(node));

    // Unary mapping over the native NativeMatExpr (keeps native fusion).
    private static MatExpr Map(MatExpr a, Func<NativeMatExpr, NativeMatExpr> op)
    {
        NotNull(a);
        return new MatExpr(() => { using var e = a.Eval(); return op(e); });
    }

    // Binary combination over two native NativeMatExpr operands (keeps native fusion).
    private static MatExpr Combine(MatExpr a, MatExpr b, Func<NativeMatExpr, NativeMatExpr, NativeMatExpr> op)
    {
        NotNull(a);
        NotNull(b);
        return new MatExpr(() => { using var l = a.Eval(); using var r = b.Eval(); return op(l, r); });
    }

    // Binary combination where one operand is a Mat (still uses a NativeMatExpr-level operator).
    private static MatExpr Combine(MatExpr a, Mat b, Func<NativeMatExpr, Mat, NativeMatExpr> op)
    {
        NotNull(a);
        if (b is null)
            throw new ArgumentNullException(nameof(b));
        return new MatExpr(() => { using var l = a.Eval(); return op(l, b); });
    }

    // Unary mapping that requires a materialized Mat (for Mat-only operations).
    private static MatExpr MapMat(MatExpr a, Func<Mat, NativeMatExpr> op)
    {
        NotNull(a);
        return new MatExpr(() => { using var m = a.ToMat(); return op(m); });
    }

    // Binary combination that materializes both operands to Mat (for Mat-only operations).
    private static MatExpr CombineMat(MatExpr a, MatExpr b, Func<Mat, Mat, NativeMatExpr> op)
    {
        NotNull(a);
        NotNull(b);
        return new MatExpr(() => { using var l = a.ToMat(); using var r = b.ToMat(); return op(l, r); });
    }

    // Binary combination that materializes the node operand to Mat (the other is already a Mat).
    private static MatExpr CombineMat(MatExpr a, Mat b, Func<Mat, Mat, NativeMatExpr> op)
    {
        NotNull(a);
        if (b is null)
            throw new ArgumentNullException(nameof(b));
        return new MatExpr(() => { using var l = a.ToMat(); return op(l, b); });
    }

    // Native Mat-level primitives. OpenCV defines the bitwise and comparison operators only on
    // Mat (they return a fresh cv::MatExpr), so these wrap the extern calls directly rather than
    // going through Mat's now-lazy C# operators. Each keeps its operands alive across the call.

    private static NativeMatExpr NativeNot(Mat m)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorNot(m.CvPtr, out var ret));
        GC.KeepAlive(m);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeAnd(Mat a, Mat b)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorAnd_MatMat(a.CvPtr, b.CvPtr, out var ret));
        GC.KeepAlive(a);
        GC.KeepAlive(b);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeAnd(Mat a, double s)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorAnd_MatDouble(a.CvPtr, s, out var ret));
        GC.KeepAlive(a);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeAnd(double s, Mat a)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorAnd_DoubleMat(s, a.CvPtr, out var ret));
        GC.KeepAlive(a);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeOr(Mat a, Mat b)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorOr_MatMat(a.CvPtr, b.CvPtr, out var ret));
        GC.KeepAlive(a);
        GC.KeepAlive(b);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeOr(Mat a, double s)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorOr_MatDouble(a.CvPtr, s, out var ret));
        GC.KeepAlive(a);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeOr(double s, Mat a)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorOr_DoubleMat(s, a.CvPtr, out var ret));
        GC.KeepAlive(a);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeXor(Mat a, Mat b)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorXor_MatMat(a.CvPtr, b.CvPtr, out var ret));
        GC.KeepAlive(a);
        GC.KeepAlive(b);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeXor(Mat a, double s)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorXor_MatDouble(a.CvPtr, s, out var ret));
        GC.KeepAlive(a);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeXor(double s, Mat a)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorXor_DoubleMat(s, a.CvPtr, out var ret));
        GC.KeepAlive(a);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeLt(Mat a, Mat b)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorLT_MatMat(a.Handle, b.CvPtr, out var ret));
        GC.KeepAlive(a);
        GC.KeepAlive(b);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeLt(Mat a, double d)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorLT_MatDouble(a.Handle, d, out var ret));
        GC.KeepAlive(a);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeLe(Mat a, Mat b)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorLE_MatMat(a.Handle, b.CvPtr, out var ret));
        GC.KeepAlive(a);
        GC.KeepAlive(b);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeLe(Mat a, double d)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorLE_MatDouble(a.Handle, d, out var ret));
        GC.KeepAlive(a);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeGt(Mat a, Mat b)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorGT_MatMat(a.Handle, b.CvPtr, out var ret));
        GC.KeepAlive(a);
        GC.KeepAlive(b);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeGt(Mat a, double d)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorGT_MatDouble(a.Handle, d, out var ret));
        GC.KeepAlive(a);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeGe(Mat a, Mat b)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorGE_MatMat(a.Handle, b.CvPtr, out var ret));
        GC.KeepAlive(a);
        GC.KeepAlive(b);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeGe(Mat a, double d)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorGE_MatDouble(a.Handle, d, out var ret));
        GC.KeepAlive(a);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeEq(Mat a, Mat b)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorEQ_MatMat(a.Handle, b.CvPtr, out var ret));
        GC.KeepAlive(a);
        GC.KeepAlive(b);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeEq(Mat a, double d)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorEQ_MatDouble(a.Handle, d, out var ret));
        GC.KeepAlive(a);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeNe(Mat a, Mat b)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorNE_MatMat(a.Handle, b.CvPtr, out var ret));
        GC.KeepAlive(a);
        GC.KeepAlive(b);
        return new NativeMatExpr(ret);
    }

    private static NativeMatExpr NativeNe(Mat a, double d)
    {
        NativeMethods.HandleException(NativeMethods.core_Mat_operatorNE_MatDouble(a.Handle, d, out var ret));
        GC.KeepAlive(a);
        return new NativeMatExpr(ret);
    }

    #endregion
}
