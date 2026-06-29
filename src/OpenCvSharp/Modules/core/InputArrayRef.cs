using System.Runtime.InteropServices;

namespace OpenCvSharp;

// FOUNDATION for the InputArray/OutputArray ref-struct redesign (issue: allocation-free arrays).
//
// A handle-less, stack-only proxy that mirrors OpenCV's cv::_InputArray: it carries just a native
// handle + a kind tag (and an inline payload for scalar/vector operands). No native _InputArray is
// allocated on the managed side; the extern boundary receives the proxy BY VALUE and rebuilds a
// cv::_InputArray/_OutputArray on its own stack (see fromInputProxy/fromOutputProxy in my_types.h).
// This makes implicit-conversion temporaries (e.g. Cv2.Foo(mat, dst)) allocation-free and removes
// the non-deterministic finalizer cleanup of the current class-based InputArray.
//
// Named *Ref while the class-based InputArray/OutputArray still exist; the big-bang migration
// renames these over them. Scope (owner decision, "Option 1"): handle kinds (Mat/UMat/MatExpr) and
// inline value kinds (Scalar/double/Vec). Array / Span / vector-of-Mat inputs are NOT carried here
// (they get dedicated ReadOnlySpan / out Mat[] signatures), so a proxy never owns pinned memory.

/// <summary>Kind of array a ref-struct proxy refers to. Must match the switch in my_types.h.</summary>
public enum ArrayProxyKind
{
    /// <summary>No array (cv::noArray()).</summary>
    None = 0,
    /// <summary>A <see cref="Mat"/>.</summary>
    Mat = 1,
    /// <summary>A <see cref="UMat"/>.</summary>
    UMat = 2,
    /// <summary>A <see cref="MatExpr"/> (materialized to a native cv::MatExpr).</summary>
    MatExpr = 3,
    /// <summary>A <see cref="Scalar"/> value (inline).</summary>
    Scalar = 4,
    /// <summary>A scalar <see cref="double"/> value (inline, as Scalar(d,0,0,0)).</summary>
    Double = 5,
    /// <summary>A small fixed-length vector value (inline).</summary>
    Vec = 6,
}

/// <summary>
/// Blittable plain-old-data mirror of <c>interop::ArrayProxy</c> (my_types.h). Passed BY VALUE
/// across the P/Invoke boundary; no field is a managed reference, so it marshals 1:1.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct ArrayProxy
{
    public IntPtr Handle;     // Mat/UMat/NativeMatExpr CvPtr for handle kinds; zero otherwise
    public int Kind;          // ArrayProxyKind
    public int VecDepth;      // Vec only: CV_8U..CV_64F element depth; otherwise 0
    public int VecLength;     // Vec only: element count (2/3/4/6); otherwise 0
    // Inline payload: Scalar (4 doubles) / double (1) / Vec (raw bytes, <= 48). 6 doubles == 48 bytes.
    public double Payload0;
    public double Payload1;
    public double Payload2;
    public double Payload3;
    public double Payload4;
    public double Payload5;

    public static ArrayProxy FromScalar(in Scalar s) => new()
    {
        Handle = IntPtr.Zero,
        Kind = (int)ArrayProxyKind.Scalar,
        Payload0 = s.Val0,
        Payload1 = s.Val1,
        Payload2 = s.Val2,
        Payload3 = s.Val3,
    };
}

/// <summary>
/// Stack-only input proxy (see file header). Carries a native handle or an inline value; building
/// one allocates nothing on the managed heap.
/// </summary>
public readonly ref struct InputArrayRef
{
    // Keeps the source Mat/UMat/NativeMatExpr alive across the native call (the proxy stores only
    // its raw handle).
    internal readonly object? Source;
    internal readonly ArrayProxy Proxy;

    private InputArrayRef(object? source, ArrayProxy proxy)
    {
        Source = source;
        Proxy = proxy;
    }

    /// <summary>Wraps a <see cref="Mat"/> (no allocation).</summary>
    public static implicit operator InputArrayRef(Mat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        mat.ThrowIfDisposed();
        return new InputArrayRef(mat, new ArrayProxy { Handle = mat.CvPtr, Kind = (int)ArrayProxyKind.Mat });
    }

    /// <summary>Wraps a <see cref="UMat"/> (no allocation).</summary>
    public static implicit operator InputArrayRef(UMat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        mat.ThrowIfDisposed();
        return new InputArrayRef(mat, new ArrayProxy { Handle = mat.CvPtr, Kind = (int)ArrayProxyKind.UMat });
    }

    /// <summary>
    /// Wraps a <see cref="MatExpr"/>. The expression is materialized into a native cv::MatExpr
    /// (kept alive via <see cref="Source"/>), so this path is not allocation-free — matching the
    /// inherent cost of feeding a lazy expression into an OpenCV call.
    /// </summary>
    public static implicit operator InputArrayRef(MatExpr expr)
    {
        ArgumentNullException.ThrowIfNull(expr);
        var native = expr.Eval();
        return new InputArrayRef(native, new ArrayProxy { Handle = native.CvPtr, Kind = (int)ArrayProxyKind.MatExpr });
    }

    /// <summary>Wraps a <see cref="Scalar"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArrayRef(Scalar s) =>
        new(null, ArrayProxy.FromScalar(s));

    /// <summary>Wraps a <see cref="double"/> value (no allocation; travels inline as Scalar(d,0,0,0)).</summary>
    public static implicit operator InputArrayRef(double d) =>
        new(null, new ArrayProxy { Kind = (int)ArrayProxyKind.Double, Payload0 = d });
}

/// <summary>
/// Stack-only output proxy (see file header). Single Mat/UMat output only — native writes through
/// the referenced matrix directly, so no write-back (Fix/AssignResult) is needed.
/// </summary>
public readonly ref struct OutputArrayRef
{
    internal readonly object? Source;
    internal readonly ArrayProxy Proxy;

    private OutputArrayRef(object? source, ArrayProxy proxy)
    {
        Source = source;
        Proxy = proxy;
    }

    /// <summary>Wraps a <see cref="Mat"/> output (no allocation).</summary>
    public static implicit operator OutputArrayRef(Mat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        mat.ThrowIfDisposed();
        return new OutputArrayRef(mat, new ArrayProxy { Handle = mat.CvPtr, Kind = (int)ArrayProxyKind.Mat });
    }

    /// <summary>Wraps a <see cref="UMat"/> output (no allocation).</summary>
    public static implicit operator OutputArrayRef(UMat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        mat.ThrowIfDisposed();
        return new OutputArrayRef(mat, new ArrayProxy { Handle = mat.CvPtr, Kind = (int)ArrayProxyKind.UMat });
    }
}

/// <summary>
/// Stack-only input/output proxy (see file header). Single Mat/UMat only; its read/write role is
/// flag-dependent in OpenCV, so it is kept as one type (not split into in/out variants).
/// </summary>
public readonly ref struct InputOutputArrayRef
{
    internal readonly object? Source;
    internal readonly ArrayProxy Proxy;

    private InputOutputArrayRef(object? source, ArrayProxy proxy)
    {
        Source = source;
        Proxy = proxy;
    }

    /// <summary>Wraps a <see cref="Mat"/> in/out target (no allocation).</summary>
    public static implicit operator InputOutputArrayRef(Mat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        mat.ThrowIfDisposed();
        return new InputOutputArrayRef(mat, new ArrayProxy { Handle = mat.CvPtr, Kind = (int)ArrayProxyKind.Mat });
    }

    /// <summary>Wraps a <see cref="UMat"/> in/out target (no allocation).</summary>
    public static implicit operator InputOutputArrayRef(UMat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        mat.ThrowIfDisposed();
        return new InputOutputArrayRef(mat, new ArrayProxy { Handle = mat.CvPtr, Kind = (int)ArrayProxyKind.UMat });
    }
}
